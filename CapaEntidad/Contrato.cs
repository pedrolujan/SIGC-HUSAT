using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Contrato
    {
        public Contrato() { }

        public Int32 idContrato { get; set; }
        public Int32 idVenta { get; set; }
        public String codContrato { get; set; }
        public String tipoContrato { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime fechaPago { get; set; }
        public Int32 idUsuario { get; set; }
        public byte[] imgQr  { get; set; }
    }


    public class XMLContrato
    {
        public XMLContrato() { }

        public Cliente clsCliente { get; set; }
        public Cliente clsResponsablePago { get; set; }
        public List<Vehiculo> lstVehiculo { get; set; }
        public Plan clsPlan { get; set; }
    }
}
