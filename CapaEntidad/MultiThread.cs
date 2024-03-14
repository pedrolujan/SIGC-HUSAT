using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class MultiThread
    {
        public Thread[] thread { get; set; }

        public MultiThread(int NroHilos)
        {
            thread = new Thread[NroHilos];

        }

    }
}
