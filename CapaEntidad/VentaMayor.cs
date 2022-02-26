using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class VentaMayor
    {

        public VentaMayor() { }

        Int32 _idVentaMayor = 0;
        public Int32 idVentaMayor { get { return _idVentaMayor; } set { _idVentaMayor = value; } }

        Int32 _idLote = 0;
        public Int32 idLote { get { return _idLote; } set { _idLote = value; } }

        Int32 _idCliente = 0;
        public Int32 idCliente { get { return _idCliente; } set { _idCliente = value; } }

        string _cProducto = "";
        public String cProducto { get { return _cProducto; } set { _cProducto = value; } }

        Int32 _idSucursal = 0;
        public Int32 idSucursal { get { return _idSucursal; } set { _idSucursal = value; } }

        decimal _mPrecioVenta = 0;
        public Decimal mPrecioVenta { get { return _mPrecioVenta; } set { _mPrecioVenta = value; } }

        decimal _nCantidad = 0;
        public Decimal nCantidad { get { return _nCantidad; } set { _nCantidad = value; } }

        decimal _nCantidadUM= 0;
        public Decimal nCantidadUM { get { return _nCantidadUM; } set { _nCantidadUM = value; } }

        decimal _mMontoTotal = 0;
        public Decimal mMontoTotal { get { return _mMontoTotal; } set { _mMontoTotal = value; } }

        decimal _mMontoPagar = 0;
        public Decimal mMontoPagar { get { return _mMontoPagar; } set { _mMontoPagar = value; } }

        string _cTipoPago = "";
        public String cTipoPago { get { return _cTipoPago; } set { _cTipoPago = value.Trim(); } }

        string _cEstado = "";
        public String cEstado { get { return _cEstado; } set { _cEstado = value; } }

        DateTime _dFechaRegistro;
        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

        int _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }


    }
}
