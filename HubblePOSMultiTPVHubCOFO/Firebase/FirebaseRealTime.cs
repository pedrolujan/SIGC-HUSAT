using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Streaming;
using HubFirebase.Helpers;
using HubFirebase.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubFirebase.Firebase
{
    public class FirebaseRealTime : IFirebaseRealTime, IDisposable
    {
        #region constructor
        public FirebaseRealTime() {
            fnGetDataFirebase("orders");
        }
        #endregion constructor

        #region Instance

        /// <summary>
        /// Devuelve la referencia única a la instancia de esta clase.
        /// </summary>
        public static IFirebaseRealTime Instance => _instance;

        #endregion Instance

        /// <summary>
        /// Representa la instancia única a esta clase.
        /// </summary>
        private static volatile IFirebaseRealTime _instance = new FirebaseRealTime();

        static FirebaseAuthLink auth = null;
        static string _userId = null;
        public event EventHandler<FirebaseEvent<dynamic>> StatusChangedFirebase;
        IDisposable sucripcion = null;
        FirebaseClient firebase = null;

        private void fnSuscriptionFirebase(string strTabla)
        {
            firebase = ClienteAutenticadoConEmail();
            sucripcion = firebase
                .Child(strTabla)
                //.OrderByKey()
                //.StartAt(auth.User.LocalId)
                //.EndAt(auth.User.LocalId)
                .AsObservable<dynamic>()
                .Subscribe(tabla =>
                     StatusChangedFirebase?.Invoke(this, tabla)
                );
        }

        private void fnGetDataFirebase(string strNombreTabla)
        {
            try
            {
                fnSuscriptionFirebase(strNombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static FirebaseClient ClienteAutenticadoConEmail()
        {
            var firebaseClient = new FirebaseClient(
                  "https://emsac-3ce35.firebaseio.com/",
                  new FirebaseOptions
                  {
                      AuthTokenAsyncFactory = () => LoginWithEmailAndPasswordAsync(false)
                  });
            return firebaseClient;
        }

        private static async Task<string> LoginWithEmailAndPasswordAsync(bool createUser)
        {

            if (auth != null)
            {
                if (auth.IsExpired())
                {
                    await auth.GetFreshAuthAsync();
                }
                return auth.FirebaseToken;
            }

            // manage oauth login to Google / Facebook etc.
            // call FirebaseAuthentication.net library to get the Firebase Token
            // return the token
            string email = "eduvi292@gmail.com";
            string password = "Edu44456908"; // "testPassword";
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCDUYsXTuRnE9902tU7nsaW9sixcLmN-Z8"));
            // Definido a nivel de clase. Si ya tenemos AuthLink se retorna el que se hizo inicialmente
            // FirebaseAuthLink auth = null;
            try
            {
                if (createUser)
                {
                    auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                    // The auth Object will contain auth.User and the Authentication Token from the request
                }
                else
                {
                    auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            _userId = auth.User.LocalId;
            return auth.FirebaseToken;
        }

        public async Task<OrderResponse<dynamic>> getOrderId(string codigo)
        {
            OrderResponse<dynamic> order = new OrderResponse<dynamic>();
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCDUYsXTuRnE9902tU7nsaW9sixcLmN-Z8"));
                FirebaseAuthLink _auth = await authProvider.SignInWithEmailAndPasswordAsync("eduvi292@gmail.com", "Edu44456908");
                string strparam = "?auth=" + _auth.FirebaseToken + "&orderBy=\"$key\"&equalTo=\"" +codigo+ "\"";
                order.obj = ApiHelper.Get("https://emsac-3ce35.firebaseio.com/orders.json" + strparam, null, null);
                JObject rss = JObject.Parse(order.obj.Item2);
                order.obj = rss[codigo].ToString();
                order.Status = 200;
                order.Message = "OK";
            }
            catch 
            {
                order.obj = null;
                order.Status = 500;
                order.Message = "Error Interno en Api de Pedidos";
            }

            return order;
        }

        public async Task<OrderResponse<dynamic>> updateOrderId(string codigo, int intEstado)
        {
            OrderResponse<dynamic> order = new OrderResponse<dynamic>();
            try
            {
                //dynamic objDinamico = JsonConvert.DeserializeObject<dynamic>(strPutRequest);
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCDUYsXTuRnE9902tU7nsaW9sixcLmN-Z8"));
                FirebaseAuthLink _auth = await authProvider.SignInWithEmailAndPasswordAsync("eduvi292@gmail.com", "Edu44456908");
                string strparam = "?auth=" + _auth.FirebaseToken;
                order.obj = ApiHelper.Put<dynamic>("https://emsac-3ce35.firebaseio.com/orders/"+codigo+"/intEstado.json" + strparam, intEstado, "Application/Json", null, null);

                string strResponse = Convert.ToString(order.obj.Item1);
                if (strResponse == "OK")
                {
                    order.Status = 200;
                    order.Message = "OK";
                }
                else
                {
                    order.Status = 400;
                    order.Message = strResponse;
                }
            }
            catch
            {
                order.obj = null;
                order.Status = 500;
                order.Message = "Error Interno en Api de Pedidos";
            }

            return order;
        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    firebase.Dispose();
                    sucripcion.Dispose();
                    auth = null;
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~FirebaseRealTime() {
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
