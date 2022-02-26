using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Precio
    {
       public int idPrecio { get; set; }
       public int idProducto { get; set; }
       public int intIdUnidaMedida { get; set; }
       public string strDescripcion { get; set; }
       public decimal precio { get; set; }
       public decimal PrecioActual { get; set; }
       public int idUsuario { get; set; }
       public DateTime dFechaRegistro { get; set; }
       public bool bitEstado { get; set; }
    }
}
