using CapaEntidad.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfaIntegradoCom.Funciones.Models
{
    public class GenericDocument<T,Y>
    {
        public GenericMasterDetail<T,Y> Document { get; set; }
    }
}
