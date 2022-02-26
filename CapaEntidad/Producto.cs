using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {

        public Producto()
        { }

        Int32 _idProducto=0;
        public Int32 idProducto { get { return _idProducto; } set { _idProducto = value; } }

        String _cProducto = "";
        public String cProducto { get { return _cProducto; } set { _cProducto = value.Trim(); } }

        Decimal _Stock = 0;
        public Decimal Stock { get { return _Stock; } set { _Stock = value; } }

        Decimal _mPrecioCompra = 0;
        public Decimal mPrecioCompra { get { return _mPrecioCompra; } set { _mPrecioCompra = value; } }

        Decimal _mPrecioVenta = 0;
        public Decimal mPrecioVenta { get { return _mPrecioVenta; } set { _mPrecioVenta = value; } }

        Decimal _mDescuento = 0;
        public Decimal mDescuento { get { return _mDescuento; } set { _mDescuento = value; } }

        Int32 _idUnidadMedida = 0;
        public Int32 idUnidadMedida { get { return _idUnidadMedida; } set { _idUnidadMedida = value; } }

        String _cNombreUM = "";
        public String cNombreUM { get { return _cNombreUM; } set { _cNombreUM = value; } }

        Int32 _idUnidadOrigen = 0;
        public Int32 idUnidadOrigen { get { return _idUnidadOrigen; } set { _idUnidadOrigen = value; } }

        Int32 _idLote = 0;
        public Int32 idLote { get { return _idLote; } set { _idLote = value; } }

        public Producto(Int32 pnidProducto, String pcProducto)
        {
            idProducto = pnidProducto;
            cProducto = pcProducto;
        }

        public Producto(Int32 pnidProducto,String pcProducto, Decimal pStock, Decimal pmPrecioCompra, Decimal pmPrecioVenta, Decimal pmDescuento, Int32 pidUnidadMedida
            , String pcNombreUM, Int32 pidUnidadOrigen, int pidLote)
        {
            idProducto = pnidProducto;
            cProducto = pcProducto;
            Stock = pStock;
            mPrecioCompra = pmPrecioCompra;
            mPrecioVenta = pmPrecioVenta;
            mDescuento = pmDescuento;
            idUnidadMedida = pidUnidadMedida;
            cNombreUM = pcNombreUM;
            idUnidadOrigen = pidUnidadOrigen;
            idLote = pidLote;
        }

    }
}
