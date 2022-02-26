using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Proveedor
    {
        public Proveedor() { }

        Int32 _idProveedor=0;
        public Int32 idProveedor { get { return _idProveedor; } set { _idProveedor = value; } }

        String _cNomProveedor = "";
        public String cNomProveedor { get { return _cNomProveedor; } set { _cNomProveedor = value; } }

        String _cDocumento = "";
        public String cDocumento { get { return _cDocumento; } set { _cDocumento = value; } }

        String _cDireccion = "";
        public String cDireccion { get { return _cDireccion; } set { _cDireccion = value; } }

        String _cReferencia = "";
        public String cReferencia { get { return _cReferencia; } set { _cReferencia = value; } }

        String _cTelCelular = "";
        public String cTelCelular { get { return _cTelCelular; } set { _cTelCelular = value; } }

        String _cTelFijo = "";
        public String cTelFijo { get { return _cTelFijo; } set { _cTelFijo = value; } }

        DateTime _dFechaCreacion ;
        public DateTime dFechaCreacion { get { return _dFechaCreacion; } set { _dFechaCreacion = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        DateTime _dFechaReg ;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        Int32 _idZona = 0;
        public Int32 idZona { get { return _idZona; } set { _idZona = value; } }

        String _cNomDep = "";
        public String cNomDep { get { return _cNomDep; } set { _cNomDep = value; } }

        String _cNomProv = "";
        public String cNomProv { get { return _cNomProv; } set { _cNomProv = value; } }

        String _cNomDist = "";
        public String cNomDist { get { return _cNomDist; } set { _cNomDist = value; } }

        public Proveedor(Int32 pidProveedor, String pcNomProveedor, String pcDocumento, String pcDireccion)
        {
            idProveedor = pidProveedor;
            cNomProveedor = pcNomProveedor;
            cDocumento = pcDocumento;
            cDireccion = pcDireccion;
        }

        public Proveedor(Int32 pidProveedor, String pcNomProveedor)
        {
            idProveedor = pidProveedor;
            cNomProveedor = pcNomProveedor;
        }

        public Proveedor(Int32 pidProveedor, String pcNomProveedor, String pcDocumento, String pcDireccion,String
            pcReferencia, String pcTelFijo, String pcTelCelular, DateTime pdFechaCreacion, Boolean pbEstado,
            String pcNomDep, String pcNomProv, String pcNomDist)
        {
            idProveedor=pidProveedor;
            cNomProveedor=pcNomProveedor;
            cDocumento=pcDocumento;
            cDireccion = pcDireccion;
            cReferencia = pcReferencia;
            cTelFijo = pcTelFijo;
            cTelCelular = pcTelCelular;
            dFechaCreacion = pdFechaCreacion;
            bEstado = pbEstado;
            cNomDep = pcNomDep;
            cNomProv = pcNomProv;
            cNomDist = pcNomDist;
        }               

    }
}
