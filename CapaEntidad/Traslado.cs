using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Traslado
    {
        public Traslado() { }

        Int32 _idTraslado = 0;
        public Int32 idTraslado { get { return _idTraslado; } set { _idTraslado = value; } }

        Int16 _idAlmacenOrigen = 0;
        public Int16 idAlmacenOrigen { get { return _idAlmacenOrigen; } set { _idAlmacenOrigen = value; } }

        Int16 _idAlmacenDestino = 0;
        public Int16 idAlmacenDestino { get { return _idAlmacenDestino; } set { _idAlmacenDestino = value; } }

        string  _cAlmacenOrigen = "";
        public String cAlmacenOrigen { get { return _cAlmacenOrigen; } set { _cAlmacenOrigen = value; } }

        string _cAlmacenDestino= "";
        public String cAlmacenDestino { get { return _cAlmacenDestino; } set { _cAlmacenDestino = value; } }

        Int16 _idSucursal = 0;
        public Int16 idSucursal { get { return _idSucursal; } set { _idSucursal = value; } }

        bool _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        DateTime _dFechaRegistro ;
        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

        int _idUsuario = 0;
        public Int32 idUsuarioRegistro { get { return _idUsuario; } set { _idUsuario = value; } }

        public Traslado(int pidTraslado, string pcAlmacenOrigen, string pcAlmacenDestino, DateTime pdFechaRegistro, bool pbEstado)
        {
            idTraslado=pidTraslado;
            cAlmacenOrigen = pcAlmacenOrigen;
            cAlmacenDestino = pcAlmacenDestino;
            dFechaRegistro = pdFechaRegistro;
            bEstado = pbEstado;
        }

    }
}
