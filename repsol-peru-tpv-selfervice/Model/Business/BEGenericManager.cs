using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selferviceSIGC.Model.Business
{
    public class BEGenericManager<T>
    {
        /// <summary>
        /// Object Data
        /// </summary>
        public T Data { get; set; }

        public List<ErrorGeneric> error { get; set; }
    }
}
