using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using selferviceSIGC.Core.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace selferviceSIGC.Core.Helper
{
    internal static class ApiHelper
    {
        #region GET
        /// <summary>
        /// Get Method
        /// </summary>
        /// <param name="url"></param>
        /// <param name="logger"></param>
        /// <param name="queryParams"></param>
        /// <param name="headers"></param>
        /// <param name="tracer"></param>
        /// <returns></returns>
        public static Tuple<HttpStatusCode, string> Get(string url,
            //ILogger logger,
            Dictionary<string, string> queryParams = null,
            Dictionary<string, string> headers = null, 
            bool tracer = true)
        {

            Tuple<HttpStatusCode, string> response;
            using (HttpClientHandler httpClientHandler = new HttpClientHandler())
            {
                using (HttpClient httpClient = new HttpClient(new LoggingHandler(httpClientHandler, tracer)))
                {
                    AddHeaders(httpClient, headers);

                    HttpResponseMessage httpResponse = httpClient.GetAsync(PrepareUrl(url, queryParams)).Result;
                    
                    response = new Tuple<HttpStatusCode, string>(httpResponse.StatusCode, httpResponse.Content.ReadAsStringAsync().Result);

                }
            }
            return response;
        }
        #endregion

        #region POST
        /// <summary>
        /// Post Method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="contentType"></param>
        /// <param name="logger"></param>
        /// <param name="queryParams"></param>
        /// <param name="headers"></param>
        /// <param name="tracer"></param>
        /// <returns></returns>
        public static Tuple<HttpStatusCode, string> Post<T>(string url,
            T request,
            string contentType,
            //ILogger logger,
            Dictionary<string, string> queryParams = null, 
            Dictionary<string, string> headers = null, 
            bool tracer = true) where T : class
        {
            Tuple<HttpStatusCode, string> response;
            using (HttpClientHandler httpClientHandler = new HttpClientHandler())
            {
                using (HttpClient httpClient = new HttpClient(new LoggingHandler(httpClientHandler, tracer)))
                {
                    AddHeaders(httpClient, headers);
                    var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    var httpContent = new StringContent(json);
                    if (!string.IsNullOrWhiteSpace(contentType)) httpContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

                    HttpResponseMessage httpResponse = httpClient.PostAsync(PrepareUrl(url, queryParams), httpContent).Result;


                    response = new Tuple<HttpStatusCode, string>(httpResponse.StatusCode, httpResponse.Content.ReadAsStringAsync().Result);
                }
            }

            return response;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Add headers
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="additionalHeaders"></param>
        private static void AddHeaders(HttpClient httpClient, Dictionary<string, string> additionalHeaders)
        {
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            //No additional headers to be added
            if (additionalHeaders == null)
                return;

            foreach (KeyValuePair<string, string> current in additionalHeaders)
            {
                httpClient.DefaultRequestHeaders.Add(current.Key, current.Value);
            }
        }

        /// <summary>
        /// Prepare url for api
        /// </summary>
        /// <param name="url"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Thrown when URL is not valid</exception>
        private static string PrepareUrl(string url, Dictionary<string, string> queryParams)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException("The Url is not valid");

            if (queryParams == null) return url;

            if (url.Contains("/{{") || url.Contains("}}/"))
            {
                foreach (KeyValuePair<string, string> current in queryParams)
                {
                    url = url.Replace("{{" + string.Format("{0}", current.Key) + "}}", current.Value);
                }
            }
            else
            {
                string queryString = string.Join("&", queryParams.Select(x => string.Format("{0}={1}", x.Key, x.Value)).ToList());
                if (url.EndsWith("?"))
                {
                    url += queryString;
                }
                else
                {
                    url += string.Format("?{0}", queryString);
                }
            }

            return url;
        }
        #endregion
    }

    internal class LoggingHandler : DelegatingHandler
    {
        private readonly bool _tracer;
        //private ILogger _logger;

        public LoggingHandler(HttpMessageHandler innerHandler, bool tracer)
       : base(innerHandler)
        {
            _tracer = tracer;
            //_logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_tracer)
            {
                string logRequest = string.Empty;
                string logResponse = string.Empty;
                logRequest = request.ToString();
                if (request.Content != null)
                {
                    logRequest += "\n" + request.Content.ReadAsStringAsync().Result;
                }

                HttpResponseMessage response = base.SendAsync(request, cancellationToken).Result;

                logResponse = response.ToString();
                if (response.Content != null)
                {
                    logResponse += "\n" + response.Content.ReadAsStringAsync().Result;
                }

                LogApiHelper logApi = new LogApiHelper
                {
                    Request = logRequest,
                    Response = logResponse
                };
                SendToLog(logApi);
                return response;
            }

            return base.SendAsync(request, cancellationToken).Result;

        }

        /// <summary>
        /// Save Log in Trazas_Servicios 
        /// </summary>
        /// <param name="logMetadata"></param>
        private void SendToLog(LogApiHelper logMetadata)
        {
            //_logger.writeInfo("API Helper Interceptor", JsonConvert.SerializeObject(logMetadata, Formatting.Indented));
        }

    }

    internal class LogApiHelper
    {
        public string Request { get; set; }
        public string Response { get; set; }

    }
}
