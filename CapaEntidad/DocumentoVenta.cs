using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DocumentoVenta
    {
        public DocumentoVenta() { }

        Int32 _idVenta = 0;
        public Int32 idVenta { get { return _idVenta; } set { _idVenta = value; } }

        String _cTipoDoc = "";
        public String cTipoDoc { get { return _cTipoDoc; } set { _cTipoDoc = value; } }

        String _TipoPersona = "";
        public String TipoPersona { get { return _TipoPersona; } set { _TipoPersona = value; } }
        public string cDescripcionTipoDoc { get; set; }

        Int32 _cTiDocPersona = 0;
        public Int32 cTiDocPersona { get { return _cTiDocPersona; } set { _cTiDocPersona = value; } }

        Int32 _cTipPersona = 0;
        public Int32 cTipPersona { get { return _cTipPersona; } set { _cTipPersona = value; } }

        public string cDescripcionTiDo { get; set; }

        String _cDocumento = "";
        public String cDocumento { get { return _cDocumento; } set { _cDocumento = value; } }

        Int16 _idSucursal = 0;
        public Int16 idSucursal { get { return _idSucursal; } set { _idSucursal = value; } }

        Int32 _idCliente = 0;
        public Int32 idCliente { get { return _idCliente; } set { _idCliente = value; } }

        String _cCliente = "";
        public String cCliente { get { return _cCliente; } set { _cCliente = value; } }

        String _cDocVenta = "";
        public String cDocVenta { get { return _cDocVenta; } set { _cDocVenta = value; } }
        String _codigoDocVenta = "";
        public String codigoDocVenta { get { return _codigoDocVenta; } set { _codigoDocVenta = value; } }


        DateTime _dFechaVenta;
        public DateTime dFechaVenta { get { return _dFechaVenta; } set { _dFechaVenta = value; } }

        String _cEstado = "";
        public String cEstado { get { return _cEstado; } set { _cEstado = value; } }

        public String cDescripcionEstado { get; set; }
        public String cCodEstadoPP { get; set; }
        public String cDescripEstadoPP { get; set; }

        String _cDireccion = "";
        public String cDireccion { get { return _cDireccion; } set { _cDireccion = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        String _cNroGuiaTrans = "";
        public String cNroGuiaTrans { get { return _cNroGuiaTrans; } set { _cNroGuiaTrans = value; } }

        String _cNroGuiaRem = "";
        public String cNroGuiaRem { get { return _cNroGuiaRem; } set { _cNroGuiaRem = value; } }

        DateTime _dFechaRegistro;
        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

        String _cTipoPago = "";
        public String cTipoPago { get { return _cTipoPago; } set { _cTipoPago = value; } }

        public String cDescripcionTipoPago { get; set; }

        Decimal _nNroIGV = 0;
        public Decimal nNroIGV { get { return _nNroIGV; } set { _nNroIGV = value; } }

        DateTime _dCancelado;
        public DateTime dCancelado { get { return _dCancelado; } set { _dCancelado = value; } }

        DateTime _dFechaAct;
        public DateTime dFechaAct { get { return _dFechaAct; } set { _dFechaAct = value; } }

        Int32 _idUsuAct = 0;
        public Int32 idUsuAct { get { return _idUsuAct; } set { _idUsuAct = value; } }

        Double _nMontoPagar = 0;
        public Double nMontoPagar { get { return _nMontoPagar; } set { _nMontoPagar = value; } }

        Double _nSubTotal = 0;
        public Double nSubtotal { get { return _nSubTotal; } set { _nSubTotal = value; } }

        Double _nIGV = 0;
        public Double nIGV { get { return _nIGV; } set { _nIGV = value; } }

        Double _nMontoTotal = 0;
        public Double nMontoTotal { get { return _nMontoTotal; } set { _nMontoTotal = value; } }

        Int32 _iTipoOpe = 0;
        public Int32 iTipoOpe { get { return _iTipoOpe; } set { _iTipoOpe = value; } }

        public String cCodDocumentoVenta { get; set; }
        public String NombreDocumento { get; set; }
        public Int32 idMoneda { get; set; }
        public String SimboloMoneda { get; set; }
        public String cVehiculos { get; set; }

        public String cUsuario { get; set; }
        public String cTipoVenta { get; set; }

        public Boolean est0 { get; set; }
        public Boolean est1 { get; set; }

        //public DocumentoVenta(Int32 pidVenta, Int32 pcTipoDoc, Int32 pcTiDo, String pcDocumento, String pcCliente, String pcDocVenta,
        //    DateTime pdFechaVenta,String pcEstado,String pcDireccion,String pcNroGuiaTrans, String pcNroGuiaRem
        //    , String pcTipoPago, Decimal pnNroIGV, DateTime pdCancelado)
        //{
        //    idVenta = pidVenta;
        //    cTipoDoc = pcTipoDoc;
        //    cTiDo = pcTiDo;
        //    cDocumento = pcDocumento;
        //    cCliente = pcCliente;
        //    cDocVenta = pcDocVenta;
        //    dFechaVenta = pdFechaVenta;
        //    cEstado = pcEstado;
        //    cDireccion = pcDireccion;
        //    cNroGuiaTrans=pcNroGuiaTrans;
        //    cNroGuiaRem = pcNroGuiaRem;
        //    cTipoPago = pcTipoPago;
        //    nNroIGV = pnNroIGV;
        //    dCancelado = pdCancelado;
        //}

        //public DocumentoVenta(Int32 pidVenta, String pcTipoDoc, Int32 pcTiDo, String pcDocumento, String pcCliente, String pcDocVenta,
        //    DateTime pdFechaVenta, String pcEstado, String pcDireccion, String pcNroGuiaTrans, String pcNroGuiaRem
        //    , String pcTipoPago, Decimal pnNroIGV, DateTime pdCancelado, Double pnSubtotal, Double pnIGV, Double pnMontoTotal, 
        //    string pcUsuario)
        //{
        //    idVenta = pidVenta;
        //    cTipoDoc = pcTipoDoc;
        //    cDescripcionTipoDoc = pcTipoDoc;
        //    _cTiDocPersona = pcTiDo;
        //    cDescripcionTiDo = pcTiDo;
        //    cDocumento = pcDocumento;
        //    cCliente = pcCliente;
        //    cDocVenta = pcDocVenta;
        //    dFechaVenta = pdFechaVenta;
        //    cEstado = pcEstado;
        //    cDescripcionEstado = pcEstado;
        //    cDireccion = pcDireccion;
        //    cNroGuiaTrans = pcNroGuiaTrans;
        //    cNroGuiaRem = pcNroGuiaRem;
        //    cTipoPago = pcTipoPago;
        //    nNroIGV = pnNroIGV;
        //    dCancelado = pdCancelado;
        //    nSubtotal = pnSubtotal;
        //    nIGV = pnIGV;
        //    nMontoTotal = pnMontoTotal;
        //    cUsuario = pcUsuario;
        //    cDescripcionTipoPago = pcTipoPago;
        //}

        public DocumentoVenta(Int32 pidVenta, String pcDocumento, String pcCliente, String pcDocVenta,
            DateTime pdFechaVenta)
        {
            idVenta = pidVenta;
            cDocumento = pcDocumento;
            cCliente = pcCliente;
            cDocVenta = pcDocVenta;
            dFechaVenta = pdFechaVenta;
        }

    }

}
