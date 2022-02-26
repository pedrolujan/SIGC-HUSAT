using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Inventario
    {
        public int idInventario { get; set; }
        public int idSucursal { get; set; }
        public int idAlmacen { get; set; }
        public int idUsuario { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public string cComentario { get; set; }
    }
}
