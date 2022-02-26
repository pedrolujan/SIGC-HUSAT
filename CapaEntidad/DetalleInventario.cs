using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleInventario
    {
        public int idDetalleInventario { get; set; }
        public int idInventario { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Stock { get; set; }
        public bool bEstado { get; set; }
        public string cNombreProducto { get; set; }
        public int idLote { get; set; }
        public int idProducto { get; set; }

    }
}
