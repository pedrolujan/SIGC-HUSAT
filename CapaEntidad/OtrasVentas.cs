using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CapaEntidad
{
    public class OtrasVentas
    {
        public OtrasVentas() { }

        public Int32 idObjVenta { get; set; }
        public Int32 numeracion { get; set; }
        public String DetalleVentas { get; set; }
        public Double precioUnico { get; set; }
        public Double precioUnicoCambio { get; set; }
        public Int32 unidades { get; set; }
        public Double descuentoCantidad { get; set; }
        public Double descuentoPrecio { get; set; }
        public Double precioNeto { get; set; }
        public Int32 idTipoTransaccion { get; set; }
        public Int32 idTipoDescuento { get; set; }
        public Int32 idMoneda { get; set; }
        public String simbMoneda { get; set; }
        public Int32 idCliente { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public DateTime dFechaOperacion { get; set; }
        public String CodDocumento { get; set; }
        public Double IgvPorcentaje { get; set; }
        public Double IgvPrecio { get; set; }
        public Double TotalVenta { get; set; }
        public Int32 iddUsuario { get; set; }
        public String Visivilidad { get; set; }
        public String NombreDocumento { get; set; }
        public String cUsuario { get; set; }
        public List<OtrasVentas> lstOtrasVenta { get; set; }
        public Cliente clsClienteDocumentoVenta { get; set; }
        public Cliente clsClienteAntecesor { get; set; }
        public Vehiculo clsVehiculo { get; set; }
        public Equipo_imeis clsEquipoImeis { get; set; }
        public List<Equipo_imeis> lstClienteImeis { get; set; }
        public List<DetalleVenta> lstDetalleVenta { get; set; }
        public List<Pagos> lstTrandiaria { get; set; }
    }

    public class StokAccesorios
    {
        public StokAccesorios() { }
        public Int32 IdAccesorio { get; set; }
        public Int32 StokAccesorio { get; set; }
        public String NombreAccesorio { get; set; }
    }

    public class TotalPagosVenta
    {
        public TotalPagosVenta() { }
        public Double Subtotal { get; set; }
        public Double Igv { get; set; }
        public Double Total { get; set; }
        public String cCodDocumentoVenta { get; set; }
        public Int32 idMoneda { get; set; }
        public String SimboloMoneda { get; set; }
    }

    public class xmlDocumentoVenta
    {
        public xmlDocumentoVenta() { }
        

        public List<DocumentoVenta> xmlResponsablePago { get; set; }
        public List<OtrasVentas> xmlDetalleVentas { get; set; }
        public List<TotalPagosVenta> xmlTotalesVenta { get; set; }
    }
    public class xmlActaTitularidad
    {
        public xmlActaTitularidad() { }

        public List<Cliente> lstClienteDocVenta { get; set; }
        public List<Cliente> lstClienteAntecesor { get; set; }
        public List<Vehiculo> lstVehiculo { get; set; }
    }

}
