using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class OrdenCompra
    {

         public OrdenCompra() { }

        Int32 _idOrden = 0;
        public Int32 idOrden { get { return _idOrden; } set { _idOrden = value; } }

        String _cTipoPago = "";
        public String cTipoPago { get { return _cTipoPago; } set { _cTipoPago = value; } }

        String _cDocumento = "";
        public String cDocumento { get { return _cDocumento; } set { _cDocumento = value; } }

        Int32 _idProveedor = 0;
        public Int32 idProveedor { get { return _idProveedor; } set { _idProveedor = value; } }

        Int16 _idSucursal = 0;
        public Int16 idSucursal { get { return _idSucursal; } set { _idSucursal = value; } }

        Int32 _idPersonal = 0;
        public Int32 idPersonal { get { return _idPersonal; } set { _idPersonal = value; } }

        String _cNomProveedor = "";
        public String cNomProveedor { get { return _cNomProveedor; } set { _cNomProveedor = value; } }

        String _cDocCompra = "";
        public String cDocCompra { get { return _cDocCompra; } set { _cDocCompra = value; } }

        DateTime _dFechaCompra;
        public DateTime dFechaCompra { get { return _dFechaCompra; } set { _dFechaCompra = value; } }

        String _iEstado ;
        public String iEstado { get { return _iEstado; } set { _iEstado = value; } }

        bool _bEstadoRecep = false;
        public bool bEstadoRecep { get { return _bEstadoRecep; } set { _bEstadoRecep = value; } }

        String _cDireccion = "";
        public String cDireccion { get { return _cDireccion; } set { _cDireccion = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        decimal _nMontoPagar = 0;
        public Decimal nMontoPagar { get { return _nMontoPagar; } set { _nMontoPagar = value; } }

        Int32 _idUsuarioRecepcion = 0;
        public Int32 idUsuarioRecepcion { get { return _idUsuarioRecepcion; } set { _idUsuarioRecepcion = value; } }

        DateTime _dFechaRegistro;
        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

        DateTime _dFechaRecepcion;
        public DateTime dFechaRecepcion { get { return _dFechaRecepcion; } set { _dFechaRecepcion = value; } }

        Double _IGV;
        public Double IGV { get { return _IGV; }set { _IGV = value; } }

        Double _subTotal;
        public Double subTotal { get { return _subTotal; }set { _subTotal = value; } }

        String _detalleCompra;
        public String detalleCompra { get { return _detalleCompra; } set { _detalleCompra = value; } }

        String _observaciones;
        public String observaciones { get { return _observaciones; }set { _observaciones = value; } }

        Int32 _idMoneda;
        public Int32 idMoneda { get { return _idMoneda; }set { _idMoneda = value; } }

        Boolean _chekIGV;
        public Boolean chekIGV { get { return _chekIGV; } set { _chekIGV = value; } }

        Double _costoEnvio;
        public Double costoEnvio { get { return _costoEnvio; } set { _costoEnvio = value; } }

        Double _otrosCostos;
        public Double otrosCostos { get { return _otrosCostos; }set { _otrosCostos = value; } }

        public OrdenCompra(Int32 pidOrden, String pcTipoPago, String pcDocumento, String pcNomProveedor, String pcDocCompra,
            DateTime pdFechaCompra,String piEstado,String pcDireccion)
        {
            idOrden = pidOrden;
            cTipoPago = pcTipoPago;
            cDocumento = pcDocumento;
            cNomProveedor = pcNomProveedor;
            cDocCompra = pcDocCompra;
            dFechaCompra = pdFechaCompra;
            iEstado = piEstado;
            cDireccion = pcDireccion;
        }

        public OrdenCompra(Int32 pidOrden, String pcDocumento, String pcNomProveedor, String pcDocCompra,
            DateTime pdFechaCompra)
        {
            idOrden = pidOrden;
            cDocumento = pcDocumento;
            cNomProveedor = pcNomProveedor;
            cDocCompra = pcDocCompra;
            dFechaCompra = pdFechaCompra;
        }
    }

    public class TablaOrdenIngreso
    {
        public TablaOrdenIngreso() { }

        Int32 _idEquipo = 0;
        public Int32 idEquipo { get { return _idEquipo; } set { _idEquipo = value; } }

        Int32 _cantidad = 0;
        public Int32 cantidad { get { return _cantidad; }set { _cantidad = value; } }

        Decimal _precioUnitario;
        public Decimal precioUnitario { get { return _precioUnitario; }set { _precioUnitario = value; } }

        Decimal _precioNeto;
        public Decimal precioNeto { get { return _precioNeto; } set { _precioNeto = value; } }


    }
    public class TipoOrdenCompra
    {
        public TipoOrdenCompra() { }

        Int32 _idOrdenCompra = 0;
        public Int32 idOrdenCompra { get { return _idOrdenCompra; } set { _idOrdenCompra = value; } }

        String _NombreOrdenCompra = "";
        public String NombreOrdenCompra { get { return _NombreOrdenCompra; } set { _NombreOrdenCompra = value; } }





        public TipoOrdenCompra(Int32 idtabcod, String NomOrdencompra)
        {
            idOrdenCompra = idtabcod;
            NombreOrdenCompra = NomOrdencompra;

        }


    }
    public class ordencompraSimCard
    {
        public ordencompraSimCard() { }

        Int32 _idordeningreso = 0;
        public Int32 idordenSimCard { get { return _idordeningreso; }set { _idordeningreso = value; } }

        String _numeroingreso = "";
        public String numeroingreso { get{ return _numeroingreso; }set{ _numeroingreso = value; } }

        String _proveedor = "";
        public String proveedor { get{ return _proveedor; }set{ _proveedor = value; } }

        Int32 _idOperador = 0;
        public Int32 idoperador { get { return _idOperador; }set{ _idOperador = value; } }

        String _Operador = "";
        public String operador { get{ return _Operador; }set{ _Operador = value; } }

        String _tipoingreso = "";
        public String tipoingreso { get{ return _tipoingreso; }set{ _tipoingreso = value; } }

        String _tipomoneda = "";
        public String moneda { get{ return _tipomoneda; }set{ _tipomoneda = value; } }

        String _tipocompra = "";
        public String tipocompra { get{ return _tipocompra; }set{ _tipocompra = value; } }

        DateTime _fechacompra;
        public DateTime fechacompra { get{ return _fechacompra; }set{ _fechacompra = value; } }

        DateTime _fechaingreso;
        public DateTime fechaingreso { get{ return _fechaingreso; }set{ _fechacompra = value; } }

        Int32 _cantidad = 0;
        public Int32 cantidad { get{ return _cantidad; }set{ _cantidad = value; } }

        Decimal _precioUnitarioSC;
        public Decimal precioUnitario { get { return _precioUnitarioSC; } set { _precioUnitarioSC = value; } }

        Decimal _envio;
        public Decimal envio { get { return _envio; } set { _envio = value; } }

        Decimal _otroscargos;
        public Decimal otroscargos { get { return _otroscargos; } set { _otroscargos = value; } }



    }
}
