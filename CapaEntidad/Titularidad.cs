using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Titularidad
    {
        public Titularidad() { }

        public List<Cliente> listaClientes { get; set; }
        public List<Vehiculo> listaVehiculo { get; set; }
        public List<ModeloVehiculo> listaModeloV { get; set; }
        public List<MarcaVehiculo> listaMarcaM { get; set; }
        public List<DetalleVenta> listaDetalleV { get; set; }
        public List<DocumentoVenta> listaDocVenta { get; set; }
        public DateTime FechaTitularidad { get; set; }
        public DateTime FechaRegistroT { get; set; }
        public Int32 idCliente { get; set; }
        public Int32 idModelo { get; set; }
        public Int32 idVentaGeneral { get; set; }
    }
}
