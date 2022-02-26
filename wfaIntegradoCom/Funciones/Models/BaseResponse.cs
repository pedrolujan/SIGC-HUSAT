namespace wfaIntegradoCom.Funciones.Models
{
    public abstract class BaseResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}