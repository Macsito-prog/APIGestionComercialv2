using GestionComercial.BLL.Servicios.Contrato;
using GestionComercial.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transbank.Common;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus;
using Transbank.Webpay.WebpayPlus.Responses;

namespace GestionComercial.BLL.Servicios
{
    public class TransbankService : ITransbankService
    {
        public TransbankResponseDTO createTransaction(TransbankDTO payload)
        {
            var tx = new Transaction(new Options(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY, WebpayIntegrationType.Test));
            var response = tx.Create(payload.buyOrder, payload.sessionId, payload.amount, payload.returnUrl);
            var trxResponse = new TransbankResponseDTO();
            trxResponse.url = response.Url + "?token_ws=" + response.Token;
            return trxResponse;


        }

        public TransbankConfirmDTO confirmar(string token)
        {
            var tx = new Transaction(new Options(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY, WebpayIntegrationType.Test));
            var response = tx.Commit(token);
            var trxResponse = new TransbankConfirmDTO();
            trxResponse.monto = response.Amount;
            trxResponse.estado = response.Status;
            trxResponse.fechaTransaccion = response.TransactionDate;

            return trxResponse;
        }




    }
}
