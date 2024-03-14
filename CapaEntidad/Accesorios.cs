using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Accesorios
    {
        
        public Accesorios() { }

        Int32 _idAccesorio = 0;
        public Int32 idAccesorio { get { return _idAccesorio; } set { _idAccesorio = value; } }

        String _cAccesorio = "";
        public String cAccesorio { get { return _cAccesorio; } set { _cAccesorio = value; } }

        String _cCodTabCod = "";
        public String cCodTabCod { get { return _cCodTabCod; } set { _cCodTabCod = value; } }

        DateTime _dFechaRegistro;
        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }
        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        Double _cPrecio;
        public Double cPrecio { get { return _cPrecio; } set { _cPrecio = value; } }

        String _cDescripcion = "";
        public String cDescripcion { get { return _cDescripcion; } set { _cDescripcion = value; } }
        
        Int32 _cStock = 0;
        public Int32 cStock { get { return _cStock; } set { _cStock = value; } }

        String _cNombre = "";

        public String cNombre { get { return _cNombre; } set { _cNombre = value; } }

        

        public Accesorios(Int32 pidAccesorio, String pcNomAccesorio, Double pcPrecio,String pcDescripcion, Boolean pbEstado)
        {
            idAccesorio = pidAccesorio;
            cAccesorio = pcNomAccesorio;
            cPrecio = pcPrecio;
            cDescripcion = pcDescripcion;
            bEstado = pbEstado;
            
           
        }
        public Accesorios(Int32 pidAccesorio, String pcNomAccesorio, Double pcPrecio,Int32 pcStock, Boolean pbEstado)
        {
            idAccesorio = pidAccesorio;
            cAccesorio = pcNomAccesorio;
            cPrecio = pcPrecio;
            cStock = pcStock;
            bEstado = pbEstado;
        }
        public Accesorios(String cCodTab, String pcNomAccesorio, Boolean pbEstado)
        {
            cCodTabCod = cCodTab;
            cAccesorio = pcNomAccesorio;
            bEstado = pbEstado;
        }
        public Accesorios(Int32 pidAccesorio, String pcNomAccesorio)
        {
            idAccesorio = pidAccesorio;
            cAccesorio = pcNomAccesorio;
        }
    }

    public class EquipoAccesorios
    {
        public EquipoAccesorios() { }

        Int32 _idEquipoAccesorios = 0;
        public Int32 idEquipoAccesorios { get { return _idEquipoAccesorios; }set { _idEquipoAccesorios = value; } }

        Int32 _idEquipo = 0;
        public Int32 idEquipo { get { return _idEquipo; }set { _idEquipo = value; } }

        Int32 _idAccesorio = 0;
        public Int32 idAccesorio { get { return _idAccesorio; }set { _idAccesorio = value; } }

        DateTime _dFechaRegistro;

        public DateTime dFechaRegistro { get { return _dFechaRegistro; }set { _dFechaRegistro = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; }set { _idUsuario = value; } }

        Boolean _bEstado;
        public Boolean bEstado { get { return _bEstado; }set { _bEstado = value; } }
    }

   

}
