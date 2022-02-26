using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selferviceSIGC.Model.Business
{
    public class ErrorGeneric
    {
        /// <summary>
        /// Assign error code 
        /// </summary>
        public int ErrorNumber { get; set; }

        /// <summary>
        /// Error description
        /// </summary>
        public string Description { get; set; }
    }
}
