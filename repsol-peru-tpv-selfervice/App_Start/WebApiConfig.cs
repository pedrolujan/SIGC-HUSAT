using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace selferviceSIGC.App_Start
{
    public static class WebApiConfig
    {
        /// <summary>
        /// Register api configuration
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                  name: "selfServicesAPI",
                  routeTemplate: "api/{controller}/{id}",
                  defaults: new { id = RouteParameter.Optional });

            //config.Routes.MapHttpRoute(
            //      name: "selfServicesAPI",
            //      routeTemplate: "api/{controller}/{action}/{id}",
            //      defaults: new { id = RouteParameter.Optional });

            config.EnableCors(
                new EnableCorsAttribute(
                    origins: string.Join(",", "*"),
                    methods: string.Join(",", "GET,POST,PUT,DELETE,OPTIONS"),
                    headers: string.Join(",", "*")
                ));


            JsonMediaTypeFormatter formatter = new JsonMediaTypeFormatter()
            {
                SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                    DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat
                }
            };

            formatter.SupportedMediaTypes.Clear();
            formatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));

            config.Formatters.Clear();
            config.Formatters.Add(formatter);

        }
    }
}
