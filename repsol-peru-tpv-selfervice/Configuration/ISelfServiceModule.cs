using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selferviceSIGC.Configuration
{
    public interface ISelfServiceModule : IDisposable
    {
        /// <summary>
        /// Create Web Api Server
        /// </summary>
        void CreateWebApiServer();

        void CreateSignalR();
    }
}
