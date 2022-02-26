using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Generic
{
    public class GenericMasterDetail<T, Y>
    {
        public T Header { get; set; }
        public List<Y> Detail { get; set; }
        public Empresa empresa { get; set; }
        public Sucursal sucursal { get; set; }
    }
}
