using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pagos
    {
        public Pagos() { }
        public Int32 index { get; set; }
        public String codTipoPago { get; set; }

        public String cDescripTipoPago { get; set; }
        public Int32 idEntidadPago { get; set; }
        public Int32 Unidades { get; set; }
        public Double cantAPagar { get; set; }
        public String cTipoVenta { get; set; }
        public String cNumeroOperacion { get; set; }
        public Double PagaCon { get; set; }
        public Double vuelto { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public DateTime dFechaPago { get; set; }
        public String Observaciones { get; set; }
        public Int32 idUsario { get; set; }
        public Int32 idMoneda { get; set; }
        public String SimboloMoneda { get; set; }
        public String cEstadoPP { get; set; }
        public String cDescripcionEstadoPP { get; set; }

    }

    public class EntidadesPago
    {
        public EntidadesPago() { }
        public Int32 idEntidadPago { get; set; }
        public String cCodEntidad { get; set; }
        public String nomEntidadPago { get; set; }

        public EntidadesPago(Int32 idEntidad, String pcNomEnt)
        {
            idEntidadPago = idEntidad;
            nomEntidadPago = pcNomEnt;
        }
        public EntidadesPago(String idEntidad, String pcNomEnt)
        {
            cCodEntidad = idEntidad;
            nomEntidadPago = pcNomEnt;
        }
    } 
}
