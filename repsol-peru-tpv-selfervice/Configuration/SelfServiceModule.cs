using HubFirebase;
using Microsoft.Owin.Hosting;
using selferviceSIGC.Controller;
using selferviceSIGC.Core;
using System;
using System.Collections.Generic;

namespace selferviceSIGC.Configuration
{
    public class SelfServiceModule : ISelfServiceModule
    {
        #region Private Variables
        private IDisposable _webApi;
        private IDisposable _hubFirebase { get; set; }
        // private TestController _testController;
        #endregion

        #region Constructor

        public SelfServiceModule()
        {
          //  _testController = new TestController();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Configure and Initialize Web Api
        /// </summary>
        /// <returns></returns>
        private IDisposable ConfigureAndInitializeWebapi()
        {
            return WebApp.Start<StartUp>("http://localhost:8085");
        }

        private IDisposable ConfigureAndInitializeSignalRFirebase()
        {
            return Microsoft.Owin.Hosting.WebApp.Start<Startup_Hub>("http://localhost:8086");
        }

        private void Disconnect()
        {
            if(_webApi != null)
            {
                _webApi.Dispose();
            }

            if (_hubFirebase != null)
            {
                _hubFirebase.Dispose();
            }
        }

       
        

        #endregion

        #region Public Methods
        /// <summary>
        /// Create Web Api Server
        /// </summary>
        public void CreateWebApiServer()
        {
            if(_webApi == null)
            {
                _webApi = ConfigureAndInitializeWebapi();
            }
        }

        /// <summary>
        /// Create Web Api Server
        /// </summary>
        public void CreateSignalR()
        {
            if (_hubFirebase == null)
            {
                _hubFirebase = ConfigureAndInitializeSignalRFirebase();
            }
        }

        public void Dispose()
        {
            Disconnect();
        }

        #endregion

    }
}
