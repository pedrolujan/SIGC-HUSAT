
namespace selferviceSIGC.Model.Api.Response
{
    internal class GenericResponse<T>
    {
        /// <summary>
        /// Object Data
        /// </summary>
        public T Data { get; set; }

        public ErrorManager ErrorManager { get; set; }
    }
}
