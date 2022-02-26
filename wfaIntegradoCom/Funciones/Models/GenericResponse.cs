
namespace wfaIntegradoCom.Funciones.Models
{
    internal class GenericResponse<T>:BaseResponse
    {
        /// <summary>
        /// Object Data
        /// </summary>
        public string key { get; set; }
        public int evenType { get; set; }
        public T obj { get; set; }

        //public ErrorManager ErrorManager { get; set; }
    }
}
