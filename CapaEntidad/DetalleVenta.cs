using System;
using System.Collections.Generic;
using System.IO;
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
        public Decimal PrecioUni { get; set; }
        public Decimal Total_a_pagar { get; set; }
        public Decimal mtoValorVentaItem { get; set; }
        public Decimal preciounitario { get; set; }
        public String Descripcion { get; set; }
        public String CodigoProducto { get; set; }
        public String Unidad_de_medida { get; set; }
        public Int32 Cantidad { get; set; }
        public Int32 idTipoTarifa { get; set; }
        public Int32 IdTipoDescuento { get; set; }
        public Int32 idOperacion { get; set; }
        public Decimal Descuento { get; set; }
        public Decimal gananciaRedondeo { get; set; }
        public Decimal TotalTipoDescuento { get; set; }
        public Decimal TotalDescuento { get; set; }
        public Decimal ImporteActicipo { get; set; }
        public Decimal TotalPUCant { get; set; }
        public Decimal Couta { get; set; }
        public Decimal Importe { get; set; }
        public Decimal importeRestante { get; set; }
        public Decimal ImporteRow { get; set; }
        public DateTime dtFechaRegistro { get; set; }
        public Decimal valorRedondeo { get; set; }
        public String cSimbolo { get; set; }
        
        public Int32 idOperacionItem { get; set; }
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
        public Int32 idTrandiaria { get; set; }
        public String CodDocumento { get; set; }
        public Decimal SubtotalVentas { get; set; }
        public Decimal Anticipos { get; set; }
        public Decimal Descuentos { get; set; }
        public Decimal ValorVenta { get; set; }
        public Decimal Prorrateo { get; set; }
        public Decimal IGV { get; set; }
        public Decimal ImporteTotal { get; set; }
        public Decimal TotalRedondeo { get; set; }
        public String SimboloMoneda { get; set; }
        public List<DetalleVenta> lstDetalleVenta { get; set; }

        public static decimal fnCalcularProrrateo(Decimal costoPlan, Int32 ciclo, DateTime fechaActual)
        {
            Decimal montoDia = costoPlan / 30;
            Int32 diaFechaActual = fechaActual.Day;
            Int32 mesFechaActual = fechaActual.Month;
            Int32 anoFechaActual = fechaActual.Year;
            Decimal diasDeProrrateo = 0;

            Int32 numDiasMes = DateTime.DaysInMonth(fechaActual.Year, fechaActual.Month);
            ciclo = ciclo == 0 ? 1 : ciclo;

            DateTime dtActual= Convert.ToDateTime(fechaActual.ToShortDateString());
            if(ciclo > diaFechaActual)
            {
                //diasDeProrrateo = numDiasMes - diaFechaActual;
                int diaTemp = ciclo == 15 ? ciclo : numDiasMes;
                DateTime fechaCiclo = DateTime.Parse($"{diaTemp}/{mesFechaActual}/{anoFechaActual}");
                diasDeProrrateo = (fechaCiclo - dtActual).Days;
            }
            else if (ciclo < diaFechaActual)
            {
                DateTime fechaCiclo=DateTime.Now;
                if (ciclo==30 && numDiasMes> ciclo)
                {
                    fechaCiclo = DateTime.Parse($"{numDiasMes}/{mesFechaActual}/{anoFechaActual}");
                }
                else
                {
                    fechaCiclo = DateTime.Parse($"{ciclo}/{mesFechaActual}/{anoFechaActual}").AddMonths(1);
                }

                diasDeProrrateo = (fechaCiclo - dtActual).Days;
            }
            else
            {
                DateTime fechaCiclo = DateTime.Now;
                if (ciclo == 30 && numDiasMes > ciclo)
                {
                    fechaCiclo = DateTime.Parse($"{numDiasMes}/{mesFechaActual}/{anoFechaActual}");
                }
                else
                {
                    fechaCiclo = DateTime.Parse($"{ciclo}/{mesFechaActual}/{anoFechaActual}").AddMonths(1);
                }

                diasDeProrrateo = (fechaCiclo - dtActual).Days;
            }
            Decimal devolverOtro = Convert.ToDecimal(string.Format("{0:0.00}", montoDia * diasDeProrrateo));
            Decimal devolver =Convert.ToDecimal(montoDia * diasDeProrrateo);

            //Decimal redond = Math.Round(Convert.ToDecimal(devolver), 2);
            return devolverOtro;
        
        }
        public static Decimal fnRedondearDecimales(Decimal num)
        {
            Decimal devolVer = 0;
            if (num <= Convert.ToDecimal("0.00"))
            {
                devolVer = Convert.ToDecimal(string.Format("{0:0.00}", 0.00));
            }
            else if (num<=Convert.ToDecimal("0.10"))
            {
                devolVer = Convert.ToDecimal(string.Format("{0:0.00}", 0.10));

            }else if (num > Convert.ToDecimal("0.10") && num <= Convert.ToDecimal("0.20"))
            {
                devolVer = Convert.ToDecimal(string.Format("{0:0.00}", 0.20));
            }
            else if (num > Convert.ToDecimal("0.20") && num <= Convert.ToDecimal("0.30"))
            {
                devolVer = Convert.ToDecimal(string.Format("{0:0.00}", 0.30));
            }
            else if (num > Convert.ToDecimal("0.30") && num <= Convert.ToDecimal("0.40"))
            {
                devolVer = Convert.ToDecimal(string.Format("{0:0.00}", 0.40));
            }
            else if (num > Convert.ToDecimal("0.40") && num <= Convert.ToDecimal("0.50"))
            {
                devolVer = Convert.ToDecimal(string.Format("{0:0.00}", 0.50));
            }
            else if (num > Convert.ToDecimal("0.50") && num <= Convert.ToDecimal("0.60"))
            {
                devolVer = Convert.ToDecimal(string.Format("{0:0.00}", 0.60));
            }
            else if (num > Convert.ToDecimal("0.60") && num <= Convert.ToDecimal("0.70"))
            {
                devolVer = Convert.ToDecimal(string.Format("{0:0.00}", 0.70));
            }
            else if (num > Convert.ToDecimal("0.70") && num <= Convert.ToDecimal("0.80"))
            {
                devolVer = Convert.ToDecimal(string.Format("{0:0.00}", 0.80));
            }
            else if (num > Convert.ToDecimal("0.80") && num <= Convert.ToDecimal("0.90"))
            {
                devolVer = Convert.ToDecimal(string.Format("{0:0.00}", 0.90));
            }
            else if (num > Convert.ToDecimal("0.90") && num <= Convert.ToDecimal("1.00"))
            {
                devolVer = Convert.ToDecimal(string.Format("{0:0.00}", 1.00));
            }
            return devolVer;
        }
    }
    public class xmlDocumentoVentaGeneral
    {
        public xmlDocumentoVentaGeneral() { }


        public List<DocumentoVenta> xmlDocumentoVenta{ get; set; }
        public List<DetalleVenta> xmlDetalleVentas { get; set; }
        public Byte[] imgDocumento { get; set; }
        public MemoryStream memoryStream { get; set; }
    }

    public class xmlActaCierraCaja
    {
        public xmlActaCierraCaja() { }


        public List<ReporteBloque> ListaReporteIngresos { get; set; }
        public List<ReporteBloque> ListaReporteDetalleIngresos { get; set; }
        public List<ReporteBloque> ListaReporteEgresos { get; set; }
        public List<ReporteBloque> ListaCajaChica { get; set; }
        public List<CuadreCaja> ListaCuadreCaja { get; set; }
        public List<CuadreCaja> ListaAperturaCaja { get; set; }
        public String cUsuario { get; set; }
        public String nomPersonal { get; set; }
        public Int32 idUsuario { get; set; }
        public Int32 idSucursal { get; set; }
        public String cNomSucursal { get; set; }
        public String turno { get; set; }
        public DateTime dtFechaRegistro { get; set; }

    }
}
