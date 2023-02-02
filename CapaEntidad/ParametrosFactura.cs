using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ParametrosFactura
    {
        public String Serie { get; set; }   
        public String Correlativo { get; set; }
        public String CodigoComprobante { get; set; }
        public DateTime fecha_venta { get; set; }   
        public DateTime Fecha_de_pago { get; set; }   
        public Decimal contadorProductos { get; set; }   
        public Decimal TotSubtotal { get; set; }   
        public Decimal Monto_total { get; set; }   
        public Decimal TotalIgv { get; set; }   
        public Decimal Porcentaje_IGV { get; set; }
    }
}
