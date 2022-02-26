using Autofac;
using Autofac.Integration.WebApi;
using selferviceSIGC.Core.Business;
using System.Linq;
using System.Reflection;

namespace selferviceSIGC.App_Start
{
    /// <summary>
    /// Class DI
    /// </summary>
    internal static class ContainerConfigDI
    {
        /// <summary>
        /// Configure DI
        /// </summary>
        /// <returns></returns>
        internal static IContainer ConfigureDI()
        {
            var builder = new ContainerBuilder();

            // Register Web API controller in executing assembly. 
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    .Where(x => x.Namespace.Contains("Core.Business"))
            //    .AsImplementedInterfaces();

            builder.RegisterType<StartUpService>().As<IStartUpService>();
            builder.RegisterType<PrintService>().As<IPrintService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            //builder.RegisterType<ClientService>().As<IClientService>();
            //builder.RegisterType<ProductService>().As<IProductService>();
            //builder.RegisterType<FuelingService>().As<IFuelingService>();
            //builder.RegisterType<Logger>().As<ILogger>();
            //builder.RegisterType<DocumentService>().As<IDocumentService>();

            // Create and assign a dependency resolver for Web API to use.
            return builder.Build();
        }
    }
}
