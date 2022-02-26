using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class AdministrarEquipos
    {
        public AdministrarEquipos() { }

        Int32 _idEquipoImeis = 0;
        public Int32 idEquipoImeis { get { return _idEquipoImeis; } set { _idEquipoImeis = value; } }

        
        String _imei = "";
        public String imei { get { return _imei; } set { _imei = value; } }

        String _serie = "";
        public String serie { get { return _serie; } set { _serie = value; } }

        String _nombreEquipo = "";
        public String nombreEquipo { get { return _nombreEquipo; } set { _nombreEquipo = value; } }

        String _idPlataformaEquipo = "";
        public String idPlataformaEquipo { get { return _idPlataformaEquipo; } set { _idPlataformaEquipo = value; } }

        String _idEstadoEquipo = "";
        public String idEstadoEquipo { get { return _idEstadoEquipo; } set { _idEstadoEquipo = value; } }

        Int32 _idSimCard = 0;
        public Int32 idSimCard { get { return _idSimCard; } set { _idSimCard = value; } }

        String _SimCard = "";
        public String SimCard { get { return _SimCard; } set { _SimCard = value; } }

        Int32 _idSimCardExistente = 0;
        public Int32 idSimCardExistente { get { return _idSimCardExistente; } set { _idSimCardExistente = value; } }

        DateTime _dFechaMovimiento;
        public DateTime dFechaMovimiento { get { return _dFechaMovimiento; } set { _dFechaMovimiento = value; } }

        DateTime _dFecharegistro;
        public DateTime dFecharegistro { get { return _dFecharegistro; } set { _dFecharegistro = value; } }

        String _dFechaActivo;
        public String dFechaActivo { get { return _dFechaActivo; } set { _dFechaActivo = value; } }

        String _dFechaExpiracion;
        public String dFechaExpiracion { get { return _dFechaExpiracion; } set { _dFechaExpiracion = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        String _Observacion = "";
        public String Observacion { get { return _Observacion; } set { _Observacion = value; } }

        Int32 _totalRegistros = 0;
        public Int32 totalRegistros { get { return _totalRegistros; } set { _totalRegistros = value; } }

        String _cantPaginas = "";
        public String cantPaginas { get { return _cantPaginas; } set { _cantPaginas = value; } }

        String _observacion;
        public String observacion { get { return _observacion; } set { _observacion = value; } }
        public AdministrarEquipos(Int32 pnidEquipo, Int32 pnidSimCard, Boolean pbEstado)
        {
            idEquipoImeis = pnidEquipo;
            idSimCard = pnidSimCard;
            bEstado = pbEstado;


        }
        public AdministrarEquipos(Int32 pnidEquipo, String pnSerie, String pnImei, Boolean pbEstado)
        {
            idEquipoImeis = pnidEquipo;
            serie = pnSerie;
            imei = pnImei;

            bEstado = pbEstado;
        }

        public AdministrarEquipos(Int32 pnTotalRegistros, String pnCantPaginas)
        {
            totalRegistros = pnTotalRegistros;
            cantPaginas = pnCantPaginas;


        }
    }

    public class AsignarImeisADocumento
    {
        public AsignarImeisADocumento() { }

        Int32 _idEquipoImeis = 0;
        public Int32 idEquipoImeis { get { return _idEquipoImeis; } set { _idEquipoImeis = value; } }

        Int32 _idDocumento = 0;
        public Int32 idDocumento { get { return _idDocumento; } set { _idDocumento = value; } }

        Int32 _stokImeis = 0;
        public Int32 stokImeis { get { return _stokImeis; } set { _stokImeis = value; } }


        DateTime _dFechaMovimiento;
        public DateTime dFechaMovimiento { get { return _dFechaMovimiento; } set { _dFechaMovimiento = value; } }

        DateTime _dFecharegistro;
        public DateTime dFecharegistro { get { return _dFecharegistro; } set { _dFecharegistro = value; } }

        
        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        String _observacion;
        public String observacion { get { return _observacion; } set { _observacion = value; } }
        
        public AsignarImeisADocumento(Int32 pnidEquipo, Int32 pnidDocumento, Boolean pbEstado)
        {
            idEquipoImeis = pnidEquipo;
            idDocumento = pnidDocumento;
            bEstado = pbEstado;
        }

    }
}
