using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ConfigMesa
    {

         public ConfigMesa() { }

        Int32 _idConfigMesa = 0;
        public Int32 idConfigMesa { get { return _idConfigMesa; } set { _idConfigMesa = value; } }

        string _cCodTab = "";
        public String cCodTab { get { return _cCodTab; } set { _cCodTab = value; } }

        Int32 _idLote = 0;
        public Int32 idLote { get { return _idLote; } set { _idLote = value; } }

        Int16 _idSucursal = 0;
        public Int16 idSucursal { get { return _idSucursal; } set { _idSucursal = value; } }

        String _cProducto = "";
        public String cProducto { get { return _cProducto; } set { _cProducto = value.Trim(); } }

        String _cNombreMesa = "";
        public String cNombreMesa { get { return _cNombreMesa; } set { _cNombreMesa = value.Trim(); } }

        String _cNomProveedor = "";
        public String cNomProveedor { get { return _cNomProveedor; } set { _cNomProveedor = value.Trim(); } }

        decimal _mPrecioPublico = 0;
        public Decimal mPrecioPublico { get { return _mPrecioPublico; } set { _mPrecioPublico = value; } }

        decimal _mPrecioCompra = 0;
        public Decimal mPrecioCompra { get { return _mPrecioCompra; } set { _mPrecioCompra = value; } }

        decimal _mPrecioEspecial = 0;
        public Decimal mPrecioEspecial { get { return _mPrecioEspecial; } set { _mPrecioEspecial = value; } }

        decimal _Compra = 0;
        public Decimal Compra { get { return _Compra; } set { _Compra = value; } }
        
        decimal _mPrecioxMayor = 0;
        public Decimal mPrecioxMayor { get { return _mPrecioxMayor; } set { _mPrecioxMayor = value; } }

        decimal _Stock = 0;
        public Decimal Stock { get { return _Stock; } set { _Stock = value; } }

        bool _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        DateTime _dFechaRegiastro ;
        public DateTime dFechaRegiastro { get { return _dFechaRegiastro; } set { _dFechaRegiastro = value; } }

        int _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        public ConfigMesa(Int32 pidConfigMesa,String pcCodTab, Int32 pidLote, string pcNombreMesa, string pcNomProveedor, string pcNombreProducto)
        {
            idConfigMesa = pidConfigMesa;
            cCodTab = pcCodTab;
            cNombreMesa = pcNombreMesa;
            idLote = pidLote;
            cNomProveedor = pcNomProveedor;
            cProducto = pcNombreProducto;
            
        }

        public ConfigMesa(Int32 pidConfigMesa, Int32 pidLote,string pcNomProveedor, string pcProducto,
            decimal pmCompra, decimal pmStock, decimal pmPrecioCompra, decimal pmPrecioPublico, decimal pmPrecioEspecial, decimal pmPrecioxMayor, 
             bool pbEstado)
        {
            idConfigMesa = pidConfigMesa;
            idLote = pidLote;
            cNomProveedor = pcNomProveedor;
            cProducto=pcProducto;
            Compra = pmCompra;
            Stock = pmStock;
            mPrecioCompra = pmPrecioCompra;
            mPrecioPublico = pmPrecioPublico;
            mPrecioEspecial = pmPrecioEspecial;
            mPrecioxMayor = pmPrecioxMayor;
            bEstado = pbEstado;
        }

    }
}
