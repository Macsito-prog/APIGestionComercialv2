namespace GestionComercial.API.Utilidad
{
    public class Response<T>
    {
        //respuesta a las solicitudes de las APIs. La <T> la hace genérica, recibe cualquier objeto

        public bool status { get; set; }
        public T value {get; set; } 

        public string msg { get; set; }
    }
}
