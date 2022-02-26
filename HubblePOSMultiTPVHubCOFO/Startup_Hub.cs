using Newtonsoft.Json;
using HubFirebase.Models.Serialization;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using HubFirebase.Firebase;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(HubFirebase.Startup_Hub))]
namespace HubFirebase
{
    public class Startup_Hub
    {
        public void Configuration(IAppBuilder app)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new SignalRContractResolver()
            };
            JsonSerializer serializer = JsonSerializer.Create(settings);

            //Aumentamos el tamaño buffer de signalR
            GlobalHost.Configuration.MaxIncomingWebSocketMessageSize = 131072; // 128kb

            // Registramos un serializador propio para exponer métodos y propiedades en camelCase.
            GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => serializer);
            // Se registran las dependencias de los Hubs. Si se quisieran manejar también las dependencias de los controladores habría que agregar la lógica aquí.
            // Ojo, porque si la complejidad de dependencias crece entonces habría que usar un IOC (Ninject, Castle Windsor, ...) que sobrescribiese el resolver de SingalR
           GlobalHost.DependencyResolver.Register(typeof(FirebaseHub), () => new FirebaseHub(FirebaseRealTime.Instance));

            // TODO: La siguiente línea está puesta únicamente con propósito de depuración.
            var hubConfiguration = new HubConfiguration() { EnableDetailedErrors = true };


            app.UseCors(CorsOptions.AllowAll)
               .MapSignalR(hubConfiguration);

        }
    }
}
