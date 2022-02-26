using selferviceSIGC.Model.Business;
using System.Collections.Generic;

namespace selferviceSIGC.Core
{
    public partial class SelfServiceBase
    {
        #region Singleton
        private static SelfServiceBase _instance;

        public static SelfServiceBase Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SelfServiceBase();
                }
                return _instance;
            }
        }
        #endregion

        #region Base Methods - Internal


        /// <summary>
        /// 
        /// </summary>
        internal int idUser;

        /// <summary>
        /// 
        /// </summary>
        internal int idSucursal;


        #endregion

        #region Delegates

        /// <summary>
        /// Event of Delegate StoreDelegateHandler
        /// </summary>



        public delegate List<object> ConfigurationDelegate();

        public event ConfigurationDelegate getLoadServerHandler;

        #endregion

        #region Access Delegates Events Response
        internal List<object> getLoadServer()
        {
            return getLoadServerHandler();
        }
        #endregion

    }
}
