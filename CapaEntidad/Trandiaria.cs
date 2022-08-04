using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Trandiaria
    {
        public Trandiaria() { }
        public Int32 idTrandiaria { get; set; }
        public Int32 idUsuario  { get; set; }
        public String sFechaPago { get; set; }
        public String sFechaRegistro { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class Egresos
    {
        public Egresos() { }

        public Int32 idEgreso { get; set; }
        public String cargo { get; set; }
        public String Usuario { get; set; }

        public Double importe { get; set; }
        public String  DetalleEgreso { get; set; }
    }
}
