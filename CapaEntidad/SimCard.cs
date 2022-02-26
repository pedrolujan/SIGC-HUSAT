using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class SimCard
    {
        public SimCard() { }

        Int32 _idChip = 0;
        public Int32 idChip { get { return _idChip; } set { _idChip = value; } }
        String _ImeiEquipo = "";
        public String ImeiEquipo { get { return _ImeiEquipo; } set { _ImeiEquipo = value; } }

        Int32 _simCard = 0;
        public Int32 simCard { get { return _simCard; } set { _simCard = value; } }


        //String _StrsimCard = "";
        public String StrsimCard { get; set; }

        public String RepetidosimCard { get; set; }

        public String CodigoSimCard { get; set; }

        public String RepetidoCodigoSimCard { get; set; }

        public String iddetalleordensimcard { get; set; }


        Int32 _idOperador = 0;
        public Int32 idOperador { get { return _idOperador; } set { _idOperador = value; } }

        String _cNomperador = "";
        public String cNomperador { get { return _cNomperador; } set { _cNomperador = value; } }

        Boolean _bEstadoOperador = false;
        public Boolean bEstadoOperador { get { return _bEstadoOperador; } set { _bEstadoOperador = value; } }

        String _observacion = "";
        public String observacion { get { return _observacion; } set { _observacion = value; } }

        Int32 _CicloPago = 0;
        public Int32 CicloPago { get { return _CicloPago; } set { _CicloPago = value; } }

        Int32 _idRecibo = 0;
        public Int32 idRecibo { get { return _idRecibo; } set { _idRecibo = value; } }

        String _cNumRecibo = "";
        public String cNumRecibo { get { return _cNumRecibo; } set { _cNumRecibo = value; } }

        String _idEstado = "";
        public String idEstado { get { return _idEstado; } set { _idEstado = value; } }

        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }

        DateTime _dFechaCompra;
        public DateTime dFechaCompra { get { return _dFechaCompra; } set { _dFechaCompra = value; } }

        DateTime _dFechaPago;
        public DateTime dFechaPago { get { return _dFechaPago; } set { _dFechaPago = value; } }

        String _dFechaReactivacion;
        public String dFechaReactivacion { get { return _dFechaReactivacion; } set { _dFechaReactivacion = value; } }

        Int32 _rNumeroDias = 0;
        public Int32 rNumeroDias { get { return _rNumeroDias; } set { _rNumeroDias = value; } }

        String _dFechaBaja;
        public String dFechaBaja { get { return _dFechaBaja; } set { _dFechaBaja = value; } }

        String _dFechaSuspencion;
        public String dFechaSuspencion { get { return _dFechaSuspencion; } set { _dFechaSuspencion = value; } }
        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        Boolean _bEstadoPago = false;
        public Boolean bEstadoPago { get { return _bEstadoPago; } set { _bEstadoPago = value; } }

        Int32 _totalRegistros = 0;
        public Int32 totalRegistros { get { return _totalRegistros; } set { _totalRegistros = value; } }

        String _cantPaginas = "";
        public String cantPaginas { get { return _cantPaginas; } set { _cantPaginas = value; } }

        public SimCard(Int32 pidOperador, Int32 pnSimCard, String pcOperador, String pnidEstado)
        {
            idChip = pidOperador;
            simCard = pnSimCard;
            cNomperador = pcOperador;
            idEstado = pnidEstado;
        }
        public SimCard(Int32 pidOperador, Int32 pcSimCard, String pcObservacion, String pnidEstado, DateTime pdfechaReg, Int32 pnIdUsuario)
        {
            idChip = pidOperador;
            simCard = pcSimCard;
            observacion = pcObservacion;
            idEstado = pnidEstado;
            dFechaReg = pdfechaReg;
            idUsuario = pnIdUsuario;
        }
        public SimCard(Int32 pnidRecibo, String pcNumRecibo)
        {
            idRecibo = pnidRecibo;
            cNumRecibo = pcNumRecibo;
        }
        public SimCard(Int32 pnNumRecibo)
        {
            idRecibo = pnNumRecibo;
        }
        public SimCard(Int32 pnIdOperador, String pcNomOperador, Boolean pbEstado)
        {
            idOperador = pnIdOperador;
            cNomperador = pcNomOperador;
            bEstadoOperador = pbEstado;
        }
    }


    public class AsignarReciboAChips
    {
        public AsignarReciboAChips() { }

        Int32 _idChip = 0;
        public Int32 idChip { get { return _idChip; } set { _idChip = value; } }

        Int32 _idRecibo = 0;
        public Int32 idRecibo { get { return _idRecibo; } set { _idRecibo = value; } }

        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }
    }

    public class RealizarPago
    {
        public RealizarPago() { }

        DateTime _dFechaPago;
        public DateTime dFechaPago { get { return _dFechaPago; } set { _dFechaPago = value; } }

        DateTime _dFechaProximoPago;
        public DateTime dFechaProximoPago { get { return _dFechaProximoPago; } set { _dFechaProximoPago = value; } }

        Boolean _bEstadoPago = false;
        public Boolean bEstadoPago { get { return _bEstadoPago; } set { _bEstadoPago = value; } }

        String _observacion = "";
        public String observacion { get { return _observacion; } set { _observacion = value; } }
    }

    public class Operador
    {
        public Operador() { }

        Int32 _idOperador = 0;
        public Int32 idOperador { get { return _idOperador; } set { _idOperador = value; } }

        String _NomOperador = "";
        public String NomOperador { get { return _NomOperador; } set { _NomOperador = value; } }
    }
    public class OrdenSimCard
    {
        public OrdenSimCard() { }

        Int32 _idDetalleSC = 0;
        public Int32 idDetalleSC { get { return _idDetalleSC; } set { _idDetalleSC = value; } }

        String _NumeroRecibo = "";
        public String NumeroRecibo { get { return _NumeroRecibo; } set { _NumeroRecibo = value; } }

        Int32 _StockOrdenSC = 0;
        public Int32 StockOrdenSC { get { return _StockOrdenSC; } set { _StockOrdenSC = value; } }

        String _TipoIngreso = "";
        public String TipoIngreso { get{ return _TipoIngreso; }set{ _TipoIngreso = value; } }

        String _OperadorSC = "";
        public String OperadorSC { get { return _OperadorSC; }set{ _OperadorSC = value; } }
    }

        
        
}



    
