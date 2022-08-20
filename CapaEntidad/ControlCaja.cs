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

        public Int32 numero { get; set; }
        public String Codigoreporte { get; set; }
        public String cUsuario { get; set; }
        public String Detallereporte { get; set; }
        public Int32 Cantidad { get; set; }
        public Double ImporteRow { get; set; }
        public Double ImporteTipoCambio { get; set; }

        public Double ImporteSumado { get; set; }
        public String MonImporteSumado { get; set; }
        public Double ImporteTotal { get; set; }
        public Int32 idMoneda { get; set; }
        public Int32 idAuxiliar { get; set; }
        public String codAuxiliar { get; set; }
        public String SimboloMoneda { get; set; }
        public String MonImporteRow { get; set; }
        public Boolean estado { get; set; }
        

    }

    public class Busquedas
    {
        public Busquedas() { }

        public Boolean chkActivarFechas { get; set; }
        public Boolean chkActivarDia { get; set; }
        public String dtFechaIni { get; set; }
        public String dtFechaFin { get; set; }
        public String cod1 { get; set; }
        public String cod2 { get; set; }
        public String cod3 { get; set; }
        public String cod4 { get; set; }
        public String cod5 { get; set; }
        public String cod6 { get; set; }
        public String cod7 { get; set; }
        public String cBuscar { get; set; }
        public Int32 numPagina { get; set; }
        public Int32 tipoCon { get; set; }
        public Int32 idUsuario { get; set; }

    }

}
