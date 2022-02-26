using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class VentaMesa
    {
        public VentaMesa() { }

        Int32 _idVentaMesa = 0;
        public Int32 idVentaMesa { get { return _idVentaMesa; } set { _idVentaMesa = value; } }

        Int32 _idConfigMesa = 0;
        public Int32 idConfigMesa { get { return _idConfigMesa; } set { _idConfigMesa = value; } }

        Int32 _idCliente = 0;
        public Int32 idCliente { get { return _idCliente; } set { _idCliente = value; } }

        string _cProducto = "";
        public String cProducto { get { return _cProducto; } set { _cProducto = value; } }

        Int32 _idSucursal = 0;
        public Int32 idSucursal { get { return _idSucursal; } set { _idSucursal = value; } }

        decimal _mPrecioVenta = 0;
        public Decimal mPrecioVenta { get { return _mPrecioVenta; } set { _mPrecioVenta = value; } }

        decimal _mMontoTotal = 0;
        public Decimal mMontoTotal { get { return _mMontoTotal; } set { _mMontoTotal = value; } }

        decimal _mMontoPagar = 0;
        public Decimal mMontoPagar { get { return _mMontoPagar; } set { _mMontoPagar = value; } }

        decimal _nCantidad = 0;
        public Decimal nCantidad { get { return _nCantidad; } set { _nCantidad = value; } }
        
        string _cTipoPago = "";
        public String cTipoPago { get { return _cTipoPago; } set { _cTipoPago = value.Trim(); } }

        string _cCodTab = "";
        public String cCodTab { get { return _cCodTab; } set { _cCodTab = value.Trim(); } }

        string _cEstado = "";
        public String cEstado { get { return _cEstado; } set { _cEstado = value; } }

        DateTime _dFechaRegistro ;
        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

        int _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        DateTime _dFechaAct ;
        public DateTime dFechaAct { get { return _dFechaAct; } set { _dFechaAct = value; } }

        int _idUsuarioAct = 0;
        public Int32 idUsuarioAct { get { return _idUsuarioAct; } set { _idUsuarioAct = value; } }

        //public VentaMesa(Int32 pidConfigMesa,String pcCodTab, Int32 pidLote, string pcNombreMesa, string pcNomProveedor, string pcNombreProducto)
        //{
        //    idConfigMesa = pidConfigMesa;
        //    cCodTab = pcCodTab;
        //    cNombreMesa = pcNombreMesa;
        //    idLote = pidLote;
        //    cNomProveedor = pcNomProveedor;
        //    cProducto = pcNombreProducto;
            
        //}

        //public ConfigMesa(Int32 pidConfigMesa, Int32 pidLote,string pcNomProveedor, string pcProducto,
        //    decimal pmCompra, decimal pmStock, decimal pmPrecioCompra, decimal pmPrecioPublico, decimal pmPrecioEspecial, decimal pmPrecioxMayor, 
        //     bool pbEstado)
        //{
        //    idConfigMesa = pidConfigMesa;
        //    idLote = pidLote;
        //    cNomProveedor = pcNomProveedor;
        //    cProducto=pcProducto;
        //    Compra = pmCompra;
        //    Stock = pmStock;
        //    mPrecioCompra = pmPrecioCompra;
        //    mPrecioPublico = pmPrecioPublico;
        //    mPrecioEspecial = pmPrecioEspecial;
        //    mPrecioxMayor = pmPrecioxMayor;
        //    bEstado = pbEstado;
        //}
    }
}
