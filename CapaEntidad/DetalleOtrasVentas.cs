using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class DetalleOtrasVentas
   {
        public DetalleOtrasVentas() { }
        public Int32 IdDetalleVenta { get; set; }
        public Int32 IdObjVenta{ get; set; }
        public Int32 IdTipoTransaccion { get; set; }
        public Double Costo { get; set; }
        public Int32 Cantidad { get; set; }
        public Int32 IdTipoDescuento { get; set; }
        public Double Descuento { get; set; }

        public DetalleOtrasVentas(Int32 iddetalleventa, Int32 idventa,
            Int32 idtipotransaccion, Double costo, Int32 cantidad,
            Int32 idtipodescuento, Double descuento)
        {
            IdDetalleVenta = iddetalleventa;
            IdObjVenta = idventa;
            IdTipoTransaccion = idtipotransaccion;
            Costo = costo;
            Cantidad = cantidad;
            IdTipoDescuento = idtipodescuento;
            Descuento = descuento;
        }
    }
}
