using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Departamento
    {
        public Departamento()
        { }

        Int32 _idDepa = 0;
        public Int32 idDepa { get { return _idDepa; } set { _idDepa = value; } }

        String _cNomDep = "";
        public String cNomDep { get { return _cNomDep; } set { _cNomDep = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }

        public Departamento(Int32 pidDepa, String pcNomDep, Boolean pbEstado)
        {
            idDepa = pidDepa;
            cNomDep = pcNomDep;
            bEstado = pbEstado;
        }

    }

    public class Provincia
    {

        public Provincia()
        { }

        Int32 _idProv = 0;
        public Int32 idProv { get { return _idProv; } set { _idProv = value; } }

        String _cNomProv = "";
        public String cNomProv { get { return _cNomProv; } set { _cNomProv = value; } }

        Int32 _idDepa = 0;
        public Int32 idDepa { get { return _idDepa; } set { _idDepa = value; } }

        String _cNomDep = "";
        public String cNomDep { get { return _cNomDep; } set { _cNomDep = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }

        public Provincia(Int32 pidProv, String pcNomProv, String pcNomDep, Boolean pbEstado)
        {
            idProv = pidProv;
            cNomProv = pcNomProv;
            cNomDep = pcNomDep;
            bEstado = pbEstado;
        }

    }

    public class Distrito
    {
        public Distrito()
        { }

        Int32 _idDist = 0;
        public Int32 idDist { get { return _idDist; } set { _idDist = value; } }

        String _cNomDist = "";
        public String cNomDist { get { return _cNomDist; } set { _cNomDist = value; } }

        Int32 _idProv = 0;
        public Int32 idProv { get { return _idProv; } set { _idProv = value; } }

        String _cNomProv = "";
        public String cNomProv { get { return _cNomProv; } set { _cNomProv = value; } }

        String _cNomDep = "";
        public String cNomDep { get { return _cNomDep; } set { _cNomDep = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        DateTime _dFechaReg;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }

        public Distrito(Int32 pidDist, String pcNomDist, Boolean pbEstado)
        {
            idDist = pidDist;
            cNomDist = pcNomDist;
            bEstado = pbEstado;
        }

        public Distrito(Int32 pidDist, String pcNomDist, String pcNomProv, String pcNomDep, Boolean pbEstado)
        {
            idDist = pidDist;
            cNomDist = pcNomDist;
            cNomDep = pcNomDep;
            cNomProv = pcNomProv;
            bEstado = pbEstado;
        }

    }

    public class Pais
    {
        public Pais()
        { }

        Int32 _idPais;
        public Int32 idPais { get { return _idPais; } set { _idPais = value; } }

        String _nombre;
        public String nombre { get { return _nombre; } set { _nombre = value; } }

        Boolean _estado;
        public Boolean estado { get { return _estado; }set { _estado = value; } }

        public Pais(Int32 pnIdPais,String pnNombre,Boolean pnEstado)
        {
            idPais = pnIdPais;
            nombre = pnNombre;
            estado = pnEstado;
        }

    }
}
