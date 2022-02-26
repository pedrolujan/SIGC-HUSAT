using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Almacen
    {
        public Almacen() { }

        Int32 _idAlmacen = 0;
        public Int32 idAlmacen { get { return _idAlmacen; } set { _idAlmacen = value; } }

        String _cNomAlmacen = "";
        public String cNomAlmacen { get { return _cNomAlmacen; } set { _cNomAlmacen = value.Trim(); } }

        public Almacen(int pidAlmacen, string pcNomAlmacen)
        {
            idAlmacen = pidAlmacen;
            cNomAlmacen = pcNomAlmacen;
        }

    }
}
