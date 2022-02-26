using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Equipo_imeis
    {
        public Equipo_imeis() { }

        Int32 _idEquipoImeis = 0;
        public Int32 idEquipoImeis { get { return _idEquipoImeis; } set { _idEquipoImeis = value; } }

        Int32 _idEquipo = 0;
        public Int32 idEquipo { get { return _idEquipo; } set { _idEquipo = value; } }

        Int32 _idOrdenIngreso = 0;
        public Int32 idOrdenIngreso { get { return _idOrdenIngreso; } set { _idOrdenIngreso = value; } }

        String _nomEquipo = "";
        public String nomEquipo { get { return _nomEquipo; } set { _nomEquipo = value; } }

        String _CodOrden = "";
        public String CodOrden { get { return _CodOrden; } set { _CodOrden = value; } }


        String _imei = "";
        public String imei { get { return _imei; } set { _imei = value; } }

        String _serie = "";
        public String serie { get { return _serie; } set { _serie = value; } }

        String _origenEquipo = "";
        public String origenEquipo { get { return _origenEquipo; } set { _origenEquipo = value; } }

        String _TipoIngreso = "";
        public String TipoIngreso { get { return _TipoIngreso; } set { _TipoIngreso = value; } }

        String _idPlataformaEquipo = "";
        public String idPlataformaEquipo { get { return _idPlataformaEquipo; } set { _idPlataformaEquipo = value; } }

        String _bEstadoEquipo = "";
        public String bEstadoEquipo { get { return _bEstadoEquipo; } set { _bEstadoEquipo = value; } }

        Int32 _idSimCard = 0;
        public Int32 idSimCard { get { return _idSimCard; } set { _idSimCard = value; } }
        DateTime _dFechaRegistro;

        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

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

        String _ModeloEquipo = "";
        public String ModeloEquipo { get { return _ModeloEquipo; } set { _ModeloEquipo = value; } }

        String _OperadorEquipo = "";
        public String OperadorEquipo { get{ return _OperadorEquipo; }set { _OperadorEquipo = value; } }

        String _SimCardEquipo = "";
        public String SimCardEquipo { get { return _SimCardEquipo; }set { _SimCardEquipo = value; } }

        String _MarcaEquipo = "";
        public String MarcaEquipo { get{ return _MarcaEquipo; }set { _MarcaEquipo = value; } }


        public Double precioEquipo { get; set; }
        public Int32 idMoneda { get; set; }
        public Double Descuento { get; set; }
        public Moneda ClsMoneda { get; set; }
        public Equipo_imeis(Int32 pnidEquipo, String pnNombreEquipo, Boolean pbEstado)
        {
            idEquipo = pnidEquipo;
            nomEquipo = pnNombreEquipo;
            bEstado = pbEstado;

        }
        public Equipo_imeis(Int32 pnidEquipo, String pnSerie, String pnImei, Boolean pbEstado)
        {
            idEquipoImeis = pnidEquipo;
            serie = pnSerie;
            imei = pnImei;

            bEstado = pbEstado;
        }

        public Equipo_imeis(Int32 pnTotalRegistros, String pnCantPaginas)
        {
            totalRegistros = pnTotalRegistros;
            cantPaginas = pnCantPaginas;


        }
        public Equipo_imeis(Int32 idEquipos, String imeis,Int32 tRegistros)
        {
            idEquipoImeis = idEquipos;
            imei = imeis;
            totalRegistros = tRegistros;


        }

    }

    public class EstadoImeis
    {
        public EstadoImeis() { }

        String _idEstadoImeis = "";
        public String idEstadoImeis { get { return _idEstadoImeis; } set { _idEstadoImeis = value; } }

        String _nombreEstado = "";
        public String nombreEstado { get { return _nombreEstado; } set { _nombreEstado = value; } }


        public EstadoImeis(String pnidEquipo, String pnNombreEquipo)
        {
            idEstadoImeis = pnidEquipo;
            nombreEstado = pnNombreEquipo;
        }
    }

    public class Imeis_paginas
    {
        public Imeis_paginas() { }

        Int32 _pagina = 0;
        public Int32 pagina { get { return _pagina; } set { _pagina = value; } }
    }

}
