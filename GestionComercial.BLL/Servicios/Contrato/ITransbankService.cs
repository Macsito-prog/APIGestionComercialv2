using GestionComercial.DTO;
using Transbank.Webpay.WebpayPlus.Responses;

namespace GestionComercial.BLL.Servicios.Contrato
{
    public interface ITransbankService
    {
        TransbankConfirmDTO confirmar(string token);
        TransbankResponseDTO createTransaction(TransbankDTO payload);
    }
}