using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TipoDescuento
    {
        public TipoDescuento() { }

        public Int32 IdTipoDescuento { get; set; }
        public String Nombre { get; set; }
        public Int32 Cantidad { get; set; }
        public Double Precio { get; set; }
        public Double Descuento { get; set; }
        public String Simbolo { get; set; }

        public TipoDescuento(Int32 idtipodescuento,String nombre,Int32 cantidad,String simbolo)
        {
            IdTipoDescuento = idtipodescuento;
            Nombre = nombre;
            Cantidad = cantidad;
            Simbolo = simbolo;
        }

        public static TipoDescuento fnObtnerTipoDescuentoSelecccionado(Int32 idTipoDescuento, List<TipoDescuento> lstTD)
        {
            foreach(TipoDescuento item in lstTD)
            {
                if(item.IdTipoDescuento == idTipoDescuento)
                {
                    return item;
                }
            }
            return new TipoDescuento();
        }
    }
}
