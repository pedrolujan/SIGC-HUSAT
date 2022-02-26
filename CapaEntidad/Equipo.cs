using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Equipo
    {
        public Equipo() { }

        Int32 _idEquipo = 0;
        public Int32 idEquipo { get { return _idEquipo; } set { _idEquipo = value; } }

        String _cNombre = "";
        public String cNombre { get { return _cNombre; }set { _cNombre = value; } }

        Int32 _imei = 0;
        public Int32 imei { get { return _imei; } set { _imei = value; } }

        String _serie = "";
        public String serie { get { return _serie; } set { _serie = value; } }

        Int32 _idCategoria = 0;
        public Int32 idCategoria { get { return _idCategoria; } set { _idCategoria = value; } }

        Int32 _idMarcaEquipo = 0;
        public Int32 idMarcaEquipo { get { return _idMarcaEquipo; } set { _idMarcaEquipo = value; } }


        Int32 _idModeloEquipo= 0;
        public Int32 idModeloEquipo { get { return _idModeloEquipo; } set { _idModeloEquipo = value; } }
       

        Int32 _idOperador = 0;
        public Int32 idOperador { get { return _idOperador; } set { _idOperador = value; } }

        Int32 _SimCard = 0;
        public Int32 SimCard { get { return _SimCard; } set { _SimCard = value; } }

        String _cOperador = "";
        public String cOperador { get { return _cOperador; } set { _cOperador = value; } }

        DateTime _dFechaRegistro;
        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        Boolean _bestado = false;
        public Boolean bEstado { get { return _bestado; } set { _bestado = value; } }

        Double _cPrecio;
        public Double cPrecio { get { return _cPrecio; } set { _cPrecio = value; } }

        String _cObservacion;
        public String cObservacion { get { return _cObservacion;  }set { _cObservacion = value; } }

        Int32 _idAccesorio;
        public Int32 idAccesorio { get { return _idAccesorio; }set { _idAccesorio = value; } }
        Int32 _idEquipoAccesorio;
        public Int32 idEquipoAccesorio { get { return _idEquipoAccesorio; } set { _idEquipoAccesorio = value; } }

        String _accesorios;
        public String accesorios { get { return _accesorios; } set { _accesorios = value; } }
        public Equipo(Int32 pnidEquipo, Int32 pnimei, Int32 pnMarca, Int32 pnidOperador)
        {
            idEquipo = pnidEquipo;
            imei = pnimei;
            idMarcaEquipo = pnMarca;
            idOperador = pnidOperador;
        }
        public Equipo(Int32 pnidEquipo, Int32 pnimei, Boolean pbEstado)
        {
            idEquipo = pnidEquipo;
            imei = pnimei;
            bEstado = pbEstado;
        }
        public Equipo(Int32 pnidEquipo, Int32 pnimei, String pcSerie, Boolean pbEstado)
        {
            idEquipo = pnidEquipo;
            imei = pnimei;
            serie = pcSerie;
            bEstado = pbEstado;
        }

        public Equipo(Int32 pnidEquipo, Int32 pnimei,String pcSerie,Int32 pnCategoria,Int32 pnMarca, Int32 pnModelo, Int32 pnOperador, Boolean pbEstado)
        {
            idEquipo = pnidEquipo;
            imei = pnimei;
            serie = pcSerie;
            idCategoria = pnCategoria;
            idMarcaEquipo = pnMarca;
            idModeloEquipo = pnModelo;
            idOperador = pnOperador;
            bEstado = pbEstado;
        }

        public Equipo(Int32 pnidEquipo,String pnNombreEquipo,Double pnPrecio,Boolean pnbEstado)
        {
            idEquipo = pnidEquipo;
            cNombre = pnNombreEquipo;
            cPrecio = pnPrecio;
            bEstado = pnbEstado;
        }

        
    }

    public class RegistrarEquipo
    {
        public RegistrarEquipo() { }

        Int32 _idEquipo = 0;
        public Int32 idEquipo { get { return _idEquipo; } set { _idEquipo = value; } }

        

        String _NombreEquipo = "";
        public String NombreEquipo { get { return _NombreEquipo; } set { _NombreEquipo = value; } }

        Int32 _idCategoria = 0;
        public Int32 idCategoria { get { return _idCategoria; } set { _idCategoria = value; } }

        Int32 _idMarcaEquipo = 0;
        public Int32 idMarcaEquipo { get { return _idMarcaEquipo; } set { _idMarcaEquipo = value; } }


        Int32 _idModeloEquipo = 0;
        public Int32 idModeloEquipo { get { return _idModeloEquipo; } set { _idModeloEquipo = value; } }

        String _Observacion = "";
        public String Observacion { get { return _Observacion; } set { _Observacion = value; } }

        DateTime _dFechaRegistro;
        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        Boolean _bestado = false;
        public Boolean bEstado { get { return _bestado; } set { _bestado = value; } }


        public RegistrarEquipo(Int32 pnidEquipo, String pnNombreEquipo, Boolean pbEstado)
        {
            idEquipo = pnidEquipo;
            NombreEquipo = pnNombreEquipo;
            bEstado = pbEstado;
        }
        public RegistrarEquipo(Int32 pnidEquipo, String pnNombreEquipo, Int32 pnidCategoria, Int32 pnidMarca, Int32 pnidModelo, Boolean pbEstado)
        {
            idEquipo = pnidEquipo;
            NombreEquipo = pnNombreEquipo;
            idCategoria = pnidCategoria;
            idMarcaEquipo = pnidMarca;
            idModeloEquipo = pnidModelo;
            bEstado = pbEstado;
        }



    }

    public class PlanEquipo
    {
        public PlanEquipo() { }

        Int32 _idPlanEquipo = 0;
        public Int32 idPlanEquipo { get { return _idPlanEquipo; } set { _idPlanEquipo = value; } }

        Int32 _idEquipo = 0;
        public Int32 idEquipo { get { return _idEquipo; } set { _idEquipo = value; } }

        Int32 _idPlan = 0;
        public Int32 idPlan { get { return _idPlan; } set { _idPlan = value; } }

        DateTime _dFechaRegistro;

        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        Boolean _bEstado;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }
    }
}
