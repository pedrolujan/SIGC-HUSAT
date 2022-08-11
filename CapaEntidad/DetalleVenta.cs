using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleVenta
    {
        public DetalleVenta() { }
        public Int32 IdDetalleVenta { get; set; }
        public Int32 Numeracion { get; set; }
        public Double PrecioUni { get; set; }
        public String Descripcion { get; set; }
        public Int32 Cantidad { get; set; }
        public Int32 idTipoTarifa { get; set; }
        public Int32 IdTipoDescuento { get; set; }
        public Double Descuento { get; set; }
        public Double gananciaRedondeo { get; set; }
        public Double TotalTipoDescuento { get; set; }
        public Double TotalDescuento { get; set; }
        public Double TotalPUCant { get; set; }
        public Double Couta { get; set; }
        public Double Importe { get; set; }
        public String cSimbolo { get; set; }

        public Int32 idObjetoVenta { get; set; }
        public Int32 idTipoTransaccion { get; set; }

    }
    public class DetalleVentaMensual
    {
        public DetalleVentaMensual() { }
        public Int32 IdDetalleVenta { get; set; }
        public Int32 Numeracion { get; set; }
        public Double PrecioUni { get; set; }
        public String Descripcion { get; set; }
        public Int32 Cantidad { get; set; }
        public Int32 idTipoTarifa { get; set; }
        public Int32 IdTipoDescuento { get; set; }
        public Double Descuento { get; set; }
        public Double gananciaRedondeo { get; set; }
        public Double TotalTipoDescuento { get; set; }
        public Double TotalDescuento { get; set; }
        public Double TotalPUCant { get; set; }
        public Double Couta { get; set; }
        public Double Importe { get; set; }
        public String cSimbolo { get; set; }
        public DateTime periodoInicio { get; set; }
        public DateTime periodoFinal { get; set; }
        public DateTime fechaEmision { get; set; }
        public DateTime fechaVencimiento { get; set; }

    }


    public class DetalleVentaCabecera
    {
        public DetalleVentaCabecera() { }

        public String NombreDocumento { get; set; }
        public String CodDocumento { get; set; }
        public Double SubTotal { get; set; }
        public Double Prorrateo { get; set; }
        public Double IGV { get; set; }
        public Double Total { get; set; }
        public String SimboloMoneda { get; set; }
        public List<DetalleVenta> lstDetalleVenta { get; set; }

        public static Double fnCalcularProrrateo(Double costoPlan, Int32 ciclo, DateTime fechaActual)
        {
            Double montoDia = costoPlan / 30;
            Int32 diaFechaActual = fechaActual.Day;
            Int32 mesFechaActual = fechaActual.Month;
            Int32 anoFechaActual = fechaActual.Year;
            Double diasDeProrrateo = 0;
            ciclo = ciclo == 0 ? 1 : ciclo;
            if(ciclo > diaFechaActual)
            {
                diasDeProrrateo = ciclo - diaFechaActual;
            }else if (ciclo < diaFechaActual)
            {

                DateTime fechaCiclo = DateTime.Parse($"{ciclo}/{mesFechaActual}/{anoFechaActual}").AddMonths(1);
                diasDeProrrateo = (fechaCiclo - fechaActual).Days;
            }
            Double devolverOtro = Convert.ToDouble(string.Format("{0:0.00}", montoDia * diasDeProrrateo));
            Decimal devolver =Convert.ToDecimal(montoDia * diasDeProrrateo);

            //Decimal redond = Math.Round(Convert.ToDecimal(devolver), 2);
            return devolverOtro;
        
        }
        public static Double fnRedondearDecimales(Double num)
        {
            Double devolVer = 0;
            if (num <= Convert.ToDouble("0.00"))
            {
                devolVer = Convert.ToDouble(string.Format("{0:0.00}", 0.00));
            }
            else if (num<=Convert.ToDouble("0.10"))
            {
                devolVer = Convert.ToDouble(string.Format("{0:0.00}", 0.10));

            }else if (num > Convert.ToDouble("0.10") && num <= Convert.ToDouble("0.20"))
            {
                devolVer = Convert.ToDouble(string.Format("{0:0.00}", 0.20));
            }
            else if (num > Convert.ToDouble("0.20") && num <= Convert.ToDouble("0.30"))
            {
                devolVer = Convert.ToDouble(string.Format("{0:0.00}", 0.30));
            }
            else if (num > Convert.ToDouble("0.30") && num <= Convert.ToDouble("0.40"))
            {
                devolVer = Convert.ToDouble(string.Format("{0:0.00}", 0.40));
            }
            else if (num > Convert.ToDouble("0.40") && num <= Convert.ToDouble("0.50"))
            {
                devolVer = Convert.ToDouble(string.Format("{0:0.00}", 0.50));
            }
            else if (num > Convert.ToDouble("0.50") && num <= Convert.ToDouble("0.60"))
            {
                devolVer = Convert.ToDouble(string.Format("{0:0.00}", 0.60));
            }
            else if (num > Convert.ToDouble("0.60") && num <= Convert.ToDouble("0.70"))
            {
                devolVer = Convert.ToDouble(string.Format("{0:0.00}", 0.70));
            }
            else if (num > Convert.ToDouble("0.70") && num <= Convert.ToDouble("0.80"))
            {
                devolVer = Convert.ToDouble(string.Format("{0:0.00}", 0.80));
            }
            else if (num > Convert.ToDouble("0.80") && num <= Convert.ToDouble("0.90"))
            {
                devolVer = Convert.ToDouble(string.Format("{0:0.00}", 0.90));
            }
            else if (num > Convert.ToDouble("0.90") && num <= Convert.ToDouble("1.00"))
            {
                devolVer = Convert.ToDouble(string.Format("{0:0.00}", 1.00));
            }
            return devolVer;
        }
    }
    public class xmlDocumentoVentaGeneral
    {
        public xmlDocumentoVentaGeneral() { }


        public List<DocumentoVenta> xmlDocumentoVenta{ get; set; }
        public List<DetalleVenta> xmlDetalleVentas { get; set; }
    }

    public class xmlActaCierraCaja
    {
        public xmlActaCierraCaja() { }


        public List<ReporteBloque> ListaReporteIngresos { get; set; }
        public List<ReporteBloque> ListaReporteDetalleIngresos { get; set; }
        public List<ReporteBloque> ListaReporteEgresos { get; set; }
        public List<CuadreCaja> ListaCuadreCaja { get; set; }
        public String cUsuario { get; set; }
        public String nomPersonal { get; set; }
        public Int32 idUsuario { get; set; }
        public Int32 idSucursal { get; set; }
        public String cNomSucursal { get; set; }
        public String turno { get; set; }
        public DateTime dtFechaRegistro { get; set; }

    }
}
