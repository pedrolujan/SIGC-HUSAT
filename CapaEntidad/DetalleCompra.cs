using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleCompra
    {

        public DetalleCompra() { }

        Int32 _idDetalleCompra = 0;
        public Int32 idDetalleCompra { get { return _idDetalleCompra; } set { _idDetalleCompra = value; } }

        Int32 _idOrden = 0;
        public Int32 idOrden { get { return _idOrden; } set { _idOrden = value; } }

        Int32 _idProducto = 0;
        public Int32 idProducto { get { return _idProducto; } set { _idProducto = value; } }

        String _cProducto = "";
        public String cProducto { get { return _cProducto; } set { _cProducto = value.Trim(); } }

        String _cNomProveedor = "";
        public String cNomProveedor { get { return _cNomProveedor; } set { _cNomProveedor = value.Trim(); } }

        Decimal _Cantidad = 0;
        public Decimal Cantidad { get { return _Cantidad; } set { _Cantidad = value; } }

        Decimal _PrecioCompra = 0;
        public Decimal PrecioCompra { get { return _PrecioCompra; } set { _PrecioCompra = value; } }

        Int32 _idUnidadMedida = 0;
        public Int32 idUnidadMedida { get { return _idUnidadMedida; } set { _idUnidadMedida = value; } }

        string _cNombreUM = "";
        public String cNombreUM { get { return _cNombreUM; } set { _cNombreUM = value; } }

        Decimal _Importe = 0;
        public Decimal Importe { get { return _Importe; } set { _Importe = value; } }

        DateTime _dFechaCompra ;
        public DateTime dFechaCompra { get { return _dFechaCompra; } set { _dFechaCompra = value; } }

        string _cStock = "";
        public String cStock { get { return _cStock; } set { _cStock = value; } }
        
        public DetalleCompra(Int32 pidDetalleCompra, Int32 pidOrden, Int32 pidProducto, String pcNombreProducto, Decimal pCantidad, Decimal pPrecioCompra
           ,Int32 pidUnidadMedida,String pcNombreUM, Decimal pImporte)
        {
            idDetalleCompra = pidDetalleCompra;
            idOrden = pidOrden;
            idProducto = pidProducto;
            cProducto = pcNombreProducto;
            Cantidad = pCantidad;
            PrecioCompra = pPrecioCompra;
            idUnidadMedida = pidUnidadMedida;
            Importe = pImporte;
            cNombreUM = pcNombreUM;
            
        }

        public DetalleCompra(Int32 pidDetalleCompra, Int32 pidProducto, String pcNombreProducto, String pcNomProveedor, Decimal pCantidad, Decimal pPrecioCompra, DateTime pdFechaCompra, string pcStock, int pidUnidadMedida)
        {
            idDetalleCompra = pidDetalleCompra;
            idProducto = pidProducto;
            cProducto = pcNombreProducto;
            cNomProveedor = pcNomProveedor;
            Cantidad = pCantidad;
            PrecioCompra = pPrecioCompra;
            dFechaCompra = pdFechaCompra;
            cStock = pcStock;
            idUnidadMedida = pidUnidadMedida;
        }

    }
}
