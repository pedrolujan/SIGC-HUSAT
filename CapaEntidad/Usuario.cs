using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public Usuario()
        { }

        Int32 _idUsuario=0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        String _cUser = "";
        public String cUser { get { return _cUser; } set { _cUser = value; } }

        String _cClave = "";
        public String cClave { get { return _cClave; } set { _cClave = value; } }

        Boolean _bEstado = false    ;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        Int32 _idPersonal = 0;
        public Int32 idPersonal { get { return _idPersonal; } set { _idPersonal = value; } }

        String _cPersonal = "";
        public String cPersonal { get { return _cPersonal; } set { _cPersonal = value; } }

        DateTime _dFechaReg ;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }

        DateTime _dFechaActua;
        public DateTime dFechaActua { get { return _dFechaActua; } set { _dFechaActua = value; } }

        Int32 _idUserReg = 0;
        public Int32 idUserReg { get { return _idUserReg; } set { _idUserReg = value; } }


        public Usuario(Int32 pnidUsuario, String pccUser)
        {
            idUsuario = pnidUsuario;
            cUser = pccUser;
        }

        public Usuario(string pcPersonal, String pccUser)
        {
            cPersonal = pcPersonal;
            cUser = pccUser;
        }

        public Usuario(Int32 pnidUsuario, String pccUser, String pccClave, Boolean pbbEstado, String pcPersonal)
        {
            idUsuario = pnidUsuario;
            cUser = pccUser;
            cClave = pccClave;
            bEstado = pbbEstado;
            cPersonal = pcPersonal;                    
        }


    }
}
