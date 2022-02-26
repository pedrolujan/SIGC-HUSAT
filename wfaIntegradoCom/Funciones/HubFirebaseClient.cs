using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones.Models;

namespace wfaIntegradoCom.Funciones
{
    public class HubFirebaseClient:IDisposable
    {
        static HubConnection _signalRConnection;
        static IHubProxy _hubProxy;
        public event EventHandler<dynamic> changeStatusFirebase;
        public event EventHandler<StateChange> Hub_StateChanged;

        #region Private members
        private static readonly object _mutex = new object();
        private static volatile bool _subscribedToControllerEvents = false;

        private static bool SubscribedToControllerEvents
        {
            get
            {
                lock (_mutex)
                {
                    return _subscribedToControllerEvents;
                }
            }
            set
            {
                lock (_mutex)
                {
                    _subscribedToControllerEvents = value;
                }
            }
        }
        #endregion Private members

        public HubFirebaseClient(){
            SafelySubscribeToControllerEvents();
        }

        public void connectAsync()
        {
            //Create a connection for the SignalR server
            _signalRConnection = new HubConnection("http://localhost:8086/signalr");
            _signalRConnection.StateChanged +=  HubConnection_StateChanged;

            //Get a proxy object that will be used to interact with the specific hub on the server
            //Ther may be many hubs hosted on the server, so provide the type name for the hub
            _hubProxy = _signalRConnection.CreateHubProxy("FirebaseHub");

            //Reigster to the "AddMessage" callback method of the hub
            //This method is invoked by the hub
            _hubProxy.On<GenericResponse<dynamic>>("StatusChangeFirebase", (data) =>
                fnEventInvoke(data)
               );

            try
            {
                //Connect to the server
                _signalRConnection.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}");
            }
        }

        private  void fnEventInvoke(GenericResponse<dynamic> data)
        {
            changeStatusFirebase?.BeginInvoke(this, data, asyncResult => changeStatusFirebase.EndInvoke(asyncResult), @object: null);
        }

        private void HubConnection_StateChanged(StateChange obj)
        {
            Hub_StateChanged?.BeginInvoke(this, obj, asyncResult => Hub_StateChanged.EndInvoke(asyncResult), @object: null);
        }

        public async Task<OrderEspecificResponse<dynamic>> fnGetOrderId(string Codigo)
        {
            OrderEspecificResponse<dynamic> orderEspecific = null;
            object[] param = new object[1];
            param[0] = Codigo;
            orderEspecific = await _hubProxy.Invoke<OrderEspecificResponse<dynamic>>("getOrderId", param);

            return orderEspecific;
        }

        public bool fnUpdateOrderId(string Codigo, int intEstado)
        {
            OrderResponse orderResponse = null;
            object[] param = new object[2];
            param[0] = Codigo;
            param[1] = intEstado;
            orderResponse = _hubProxy.Invoke<OrderResponse>("updateOrderId", param).Result;

            return orderResponse.Status == 200 ? true: false;
        }

        #region Auxiliar methods

        private void SafelySubscribeToControllerEvents()
        {
            if (!SubscribedToControllerEvents)
            {

                connectAsync();
                SubscribedToControllerEvents = true;
            }
        }


        #endregion Auxiliar methods

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                    _signalRConnection.Dispose();
                    _signalRConnection = null;
                    _hubProxy = null;
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.
                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~HubFirebaseClient() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
