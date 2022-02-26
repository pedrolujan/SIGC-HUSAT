using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Perioricidad
    {
        public Perioricidad() { }
        Int32 _idPerio = 0;

        public Int32 idPerio { get { return _idPerio; } set { _idPerio = value; } }

        String _nombrePerio = "";

        public String nombrePerio { get { return _nombrePerio; } set { _nombrePerio = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }


        DateTime _dFechaRegistro;
        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        public Perioricidad(Int32 pnCodPerio, String pcNombrePerio, Boolean pbEstado)
        {
            idPerio = pnCodPerio;
            nombrePerio = pcNombrePerio;
            _bEstado = pbEstado;
        }

        public Perioricidad(Int32 pnCodPerio, String pcNombrePerio)
        {
            idPerio = pnCodPerio;
            nombrePerio = pcNombrePerio;
        }
    }
}
