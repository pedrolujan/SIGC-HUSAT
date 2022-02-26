using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selferviceSIGC.Model.Business
{
    public class Amount
    {
        /// <summary>
        /// Currency Property
        /// </summary>
        [DisplayName("currency")]
        public string Currency { get; set; }

        public int[] values { get; set; }
    }
}
