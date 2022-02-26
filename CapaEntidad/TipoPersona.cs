using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TipoPersona
    {
        public TipoPersona() { }

        public Int32 id { get; set; }
        public String nombre { get; set; }
        public Boolean estado { get; set; }
        public DateTime fechaRegsitro { get; set; }

    }
}
