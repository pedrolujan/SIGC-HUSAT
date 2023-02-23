using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class VentaGeneral
    {
        public VentaGeneral() { }

        public Int32 IdVentaGeneral { get; set; }
        public String codigoVenta { get; set; }
        public Int32 IdUsuario { get; set; }
        public String Estado { get; set; }
        public String cCodEstadoPP { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaVenta { get; set; }
        public Cliente ClsCliente { get; set; }
        public Cliente ClsResponsablePago { get; set; }
        public List<Vehiculo> lstVehiculo { get; set; }
        public List<Vehiculo> lstVehiculoNRenov { get; set; }
        public Plan ClsPlan { get; set; }
        public Tarifa ClsTarifa { get; set; }
        public Equipo_imeis ClsEquipoImies { get; set; }
        public Moneda ClsMoneda { get; set; }
        public Ciclo ClsCiclo { get; set; }
        public CambioMonedaVenta clsCambioMoneda { get; set; }
        public DetalleVentaCabecera clsDetalleVentaCabecera { get; set; }
        public Contrato clsContrato { get; set; }
        public Cronograma clsCronograma { get; set; }
        public List<DetalleCronograma> lstDetalleCronograma { get; set; }
        public List<Pagos> lstPagos { get; set; }

        public String codDireccionInstalacion { get; set; }
        public String DescripDireccionInstalacion { get; set; }
        public String codigoCorrelativo { get; set; }
        public DateTime FechaDeInstalacion { get; set; }

        public Int32 estFinalizacionContrato { get; set; }
        

    }
    public class CambioMonedaVenta : Moneda
    {
        public CambioMonedaVenta() { }
        public Int32 IdMonedaEntrada { get; set; }
        public Double PrecioEntrada { get; set; }
        public Double PrecioCambio { get; set; }
        public Double PrecioSalida { get; set; }

        public CambioMonedaVenta( Double preciosalida, Double preciocambio)
        {
            PrecioSalida = preciosalida;
            PrecioCambio = preciocambio;
        }

    }
    //public class Descuentos
    //{
    //    public Int32 IdTarifa { get; set; }
    //    public Int32 Numeracion { get; set; }
    //    public String Nombre { get; set; }
    //    public Double PrecioOriginal { get; set; }
    //    public Int32 TipoDescuento { get; set; }
    //    public Double Descuento { get; set; }
    //    public Double TotalDescuento { get; set; }
    //    public Double Subtotal { get; set; }
    //    public Int32 Cuotas { get; set; }
    //    public Int32 Cantidad { get; set; }
    //    public Double Total { get; set; }
    //}
}
