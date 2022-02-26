using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Personal
    {

        public Personal()
        { }

        Int32 _idPersonal=0;
        public Int32 idPersonal { get { return _idPersonal; } set { _idPersonal = value; } }

        String _cPersonal = "";
        public String cPersonal { get { return _cPersonal; } set { _cPersonal = value; } }

        String _cApePat = "";
        public String cApePat { get { return _cApePat; } set { _cApePat = value; } }

        String _cApeMat = "";
        public String cApeMat { get { return _cApeMat; } set { _cApeMat = value; } }

        String _cPrimerNom = "";
        public String cPrimerNom { get { return _cPrimerNom; } set { _cPrimerNom = value; } }

        String _cSegundoNom = "";
        public String cSegundoNom { get { return _cSegundoNom; } set { _cSegundoNom = value; } }

        String _cDocumento = "";
        public String cDocumento { get { return _cDocumento; } set { _cDocumento = value; } }

        String _cDireccion = "";
        public String cDireccion { get { return _cDireccion; } set { _cDireccion = value; } }

        DateTime _dFecNac;
        public DateTime dFecNac { get { return _dFecNac; } set { _dFecNac = value; } }

        String _cTipoCargo="";
        public String cTipoCargo { get { return _cTipoCargo; } set { _cTipoCargo = value; } }

        String _cTelefono = "";
        public String cTelefono { get { return _cTelefono; } set { _cTelefono = value; } }

        Boolean _bestado=false;
        public Boolean bEstado { get { return _bestado; } set { _bestado = value; } }

        DateTime _dFechaRegistro ;
        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

        Int32 _idUsuarioReg = 0;
        public Int32 idUsuarioReg { get { return _idUsuarioReg; } set { _idUsuarioReg = value; } }

        Int32 _idZona = 0;
        public Int32 idZona { get { return _idZona; } set { _idZona = value; } }

        String _cNomDep = "";
        public String cNomDep { get { return _cNomDep; } set { _cNomDep = value; } }

        String _cNomProv = "";
        public String cNomProv { get { return _cNomProv; } set { _cNomProv = value; } }

        String _cNomDist = "";
        public String cNomDist { get { return _cNomDist; } set { _cNomDist = value; } }

        public Personal(Int32 pnidPersonal, String pcPersonal)
        {
            idPersonal = pnidPersonal;
            cPersonal = pcPersonal;
        }

        public Personal(Int32 pnidPersonal, String pcPersonal, String pcDocumento)
        {
            idPersonal = pnidPersonal;
            cPersonal = pcPersonal;
            cDocumento = pcDocumento;
        }

        public Personal(Int32 pdidPersonal, String pcApePat,String pcApeMat,String pcPrimerNom,String pcSegundoNom
            , String pcDocumento, String pcDireccion, DateTime pdFecNac,
            String pcTipoCargo, String pcTelefono, Boolean pbEstado,
            String pcNomDep, String pcNomProv, String pcNomDist)
        {
            idPersonal = pdidPersonal;
            cApePat = pcApePat;
            cApeMat = pcApeMat;
            cPrimerNom = pcPrimerNom;
            cSegundoNom = pcSegundoNom;
            cDocumento=pcDocumento;
            cDireccion = pcDireccion;
            dFecNac = pdFecNac;
            cTipoCargo = pcTipoCargo;
            cTelefono = pcTelefono;
            bEstado = pbEstado;
            cNomDep = pcNomDep;
            cNomProv = pcNomProv;
            cNomDist = pcNomDist;
        }             

    }
}
