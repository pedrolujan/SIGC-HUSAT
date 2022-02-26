using HubFirebase.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubFirebase
{
    [HubName("FirebaseHub")]
    public class FirebaseHub : Hub<IFirebaseClient>, IFirebaseApi
    {

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
        private Firebase.IFirebaseRealTime Controller { get; }
        #endregion Private members

        #region Constructors
        internal FirebaseHub(Firebase.IFirebaseRealTime controller)
        {
            Controller = controller;
            SafelySubscribeToControllerEvents();
        }

        #endregion Constructors

        #region primary Methods
        private async Task OnController_StatusChangeFirebase(object s, global::Firebase.Database.Streaming.FirebaseEvent<dynamic> e)
        {
            await Task.Run(() =>
            {
                GenericResponse<dynamic> genericResponse = new GenericResponse<dynamic>();
                try
                {
                    genericResponse = FormatHelper.fnFormatobjectFirebase(e);
                    genericResponse.Status = 200;
                    genericResponse.Message = "OK";
                    Clients.All.StatusChangeFirebase(genericResponse);
                }
                catch (Exception)
                {
                }
            });
        }

        public async Task<OrderResponse<dynamic>> getOrderId(string Codigo)
        {
            OrderResponse<dynamic> objReponse = new OrderResponse<dynamic>();
            try
            {
                objReponse = await Controller.getOrderId(Codigo);
            }
            catch
            {
                objReponse.Message = "Error al Obtener Pedido en el Hub";
                objReponse.Status = 500;
            }

            return objReponse;
        }

        public async Task<OrderResponse<dynamic>> updateOrderId(string Codigo, int intEstado)
        {
            OrderResponse<dynamic> objReponse = new OrderResponse<dynamic>();
            try
            {
                objReponse = await Controller.updateOrderId(Codigo, intEstado);
            }
            catch
            {
                objReponse.Message = "Error al Obtener Pedido en el Hub";
                objReponse.Status = 500;
            }

            return objReponse;
        }
        #endregion

        #region Auxiliar methods

        private void SafelySubscribeToControllerEvents()
        {
            if (!SubscribedToControllerEvents)
            {
              
                Controller.StatusChangedFirebase += async (s, e) => await OnController_StatusChangeFirebase(s, e);
                SubscribedToControllerEvents = true;
            }
        }

      
        #endregion Auxiliar methods

    }
}
