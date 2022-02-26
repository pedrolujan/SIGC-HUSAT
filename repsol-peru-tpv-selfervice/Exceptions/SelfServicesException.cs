using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selferviceSIGC.Exceptions
{
    [Serializable]
    public class SelfServicesException : Exception
    {
       

        public SelfServicesException()
        {

        }


        public SelfServicesException(string module, int HResult)
             : base(string.Format("Error en la carga de datos de {0}, Código de error: {1}", module, HResult))
        {
  
        }

        public SelfServicesException(string module, int HResult, Exception inner)
            :base(string.Format("Error en la carga de datos de {0}, Código de error: {1}", module, HResult), inner)
        {

        }
    }
}
