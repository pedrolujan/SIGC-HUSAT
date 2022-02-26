using System.Net;
using System.Net.Http.Headers;

namespace selferviceSIGC.Handler
{
    /// <summary>
    /// Base Api Log
    /// </summary>
    internal class LogApi
    {
        /// <summary>
        /// Request Property
        /// </summary>
        public RequestApi Request { get; set; }
        /// <summary>
        /// Response Property
        /// </summary>
        public ResponseApi Response { get; set; }

    }

    /// <summary>
    /// Request Log
    /// </summary>
    internal class RequestApi
    {
        /// <summary>
        /// ContentType property
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// Url Property
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Method Property
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// Header Property
        /// </summary>
        public HttpHeaders Headers { get; set; }
        /// <summary>
        /// Request Date Time property
        /// </summary>
        public string RequestDateTime { get; set; }
        /// <summary>
        /// Body content Property
        /// </summary>
        public object Body { get; set; }
    }

    /// <summary>
    /// Response Log
    /// </summary>
    internal class ResponseApi
    {
        /// <summary>
        /// Content Type Property
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// Http Status code property
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// Response Date Time property
        /// </summary>
        public string ResponseDateTime { get; set; }
        /// <summary>
        /// Body content response property
        /// </summary>
        public object Body { get; set; }

    }
}
