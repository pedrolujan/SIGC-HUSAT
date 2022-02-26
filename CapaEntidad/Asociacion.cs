using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Asociacion
    {
        public Asociacion() { }

        Int32 _idAsociacion = 0;
        public Int32 idAsociacion { get { return _idAsociacion; } set { _idAsociacion = value; } }

        String _codAsociacion = "";
        public String codAsociacion { get { return _codAsociacion; } set { _codAsociacion = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        DateTime _dFechaRegistro;
        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        public Asociacion(Int32 pnIdAsociacion,  Boolean pbEstado )
        {
            idAsociacion = pnIdAsociacion;
            _bEstado = pbEstado;
        }

        public Asociacion(Int32 pnIdAsociacion)
        {
            idAsociacion = pnIdAsociacion;
        }

        public Asociacion(Int32 pnIdAsociacion, String pnCodAsociacion, Boolean pbEstado)
        {
            idAsociacion = pnIdAsociacion;
            codAsociacion = pnCodAsociacion;
            _bEstado = pbEstado;
        }
    }
}
