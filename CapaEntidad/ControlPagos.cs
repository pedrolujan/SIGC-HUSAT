using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ControlPagos
    {
        public ControlPagos() { }

        public Int32 idUsuario { get; set; }
        public String cCodVenta { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime fechaVenta { get; set; }
        public DateTime fechaPago { get; set; }
        public List<Cliente> ListaClientesBusqueda { get; set; }
        public Cliente claseCliente { get; set; }
        public Vehiculo claseVehiculo { get; set; }
        public Int32 idCiclo { get; set; }
        public Plan clasePlan { get; set; }
        public  Cronograma claseCronograma { get; set; }
        public List<DetalleCronograma> listaDetalleCronograma { get; set; }
        public DetalleCronograma claseDetalleCronograma { get; set; }
        public Pagos clasePagos { get; set; }
        public Tarifa claseTarifa = new Tarifa();
        public List<Pagos> listaPagosTrandiaria = new List<Pagos>();
        public Moneda claseMoneda = new Moneda();
        public List<DetalleVenta> listaDetalleVenta = new List<DetalleVenta>();
        public List<DocumentoVenta> listaDocumentoVenta = new List<DocumentoVenta>();
        public byte[] byteQr { get; set; }  
        public String CodCorrelativoFactura { get; set; }  

    }
}
