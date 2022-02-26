using Newtonsoft.Json;
using selferviceSIGC.Core.Business;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace selferviceSIGC.Handler
{
    /// <summary>
    ///Api loggin Handler
    /// </summary>
    internal class ApiLogHandler : DelegatingHandler
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public ApiLogHandler()
        {
        }

        /// <summary>
        /// Interceptor
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestMetadata = BuildRequestMetadata(request);
            var response = await base.SendAsync(request, cancellationToken);
            var responseMetada = BuildResponseMetadata(response);

            LogApi logApi = new LogApi
            {
                Request = requestMetadata,
                Response = responseMetada
            };

            SendToLog(logApi);
            return response;
        }

        /// <summary>
        /// Build Request model
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private RequestApi BuildRequestMetadata(HttpRequestMessage request)
        {
            var requestMessage = request.Content.ReadAsByteArrayAsync();
            RequestApi requestApi = new RequestApi
            {
                ContentType = request.Content.Headers.ContentType == null ? string.Empty : request.Content.Headers.ContentType.ToString(),
                Url = request.RequestUri.ToString(),
                RequestDateTime = DateTime.Now.ToString("s"),
                Headers = request.Headers,                
                Method = request.Method.ToString(),
                Body = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(requestMessage.Result))
            };

            return requestApi;
        }

        /// <summary>
        /// Build response model
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private ResponseApi BuildResponseMetadata(HttpResponseMessage response)
        {
            var responseMessate = response.Content.ReadAsByteArrayAsync();

            ResponseApi responseApi = new ResponseApi
            {
                ContentType = response.Content.Headers.ContentType.ToString(),
                StatusCode = response.StatusCode,
                ResponseDateTime = DateTime.Now.ToString("s"),
                Body = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(responseMessate.Result))
            };

            return responseApi;
        }

        /// <summary>
        /// Send to log
        /// </summary>
        /// <param name="logMetadata"></param>
        private void SendToLog(LogApi logMetadata)
        {
           // _logger.writeInfo("API Interceptor", JsonConvert.SerializeObject(logMetadata, Formatting.Indented));
        }
    }
}
