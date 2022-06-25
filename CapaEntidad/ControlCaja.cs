using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ControlCaja
    {
        public ControlCaja() { }

        public String codTipoPago { get; set; }
        public String descripTipoPago { get; set; }
        public Boolean estado { get; set; }

    }

    public class ReporteBloque
    {
        public ReporteBloque() { }

        public String Codigoreporte { get; set; }
        public String Detallereporte { get; set; }
        public Int32 Cantidad { get; set; }
        public Double ImporteRow { get; set; }
        public Double ImporteTipoCambio { get; set; }

        public Double ImporteSumado { get; set; }
        public Double ImporteTotal { get; set; }
        public Int32 idMoneda { get; set; }
        public String SimboloMoneda { get; set; }
        public Boolean estado { get; set; }

    }

}
