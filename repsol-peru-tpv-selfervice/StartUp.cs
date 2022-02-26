using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using selferviceSIGC.App_Start;
using selferviceSIGC.Core.Business;
using selferviceSIGC.Handler;
using System.Web.Http;

namespace selferviceSIGC
{
    public class StartUp
    {

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            var container = ContainerConfigDI.ConfigureDI();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);

            app.UseWebApi(config);
            //app.MapSignalR();

            // add handler log
            //config.MessageHandlers.Add(new ApiLogHandler(container.Resolve<ILogger>()));
        }

    }
}
