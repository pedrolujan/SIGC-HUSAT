using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cargo
    {

        public Cargo()
        { }

        String _cCodTab = "";
        public String cCodTab { get { return _cCodTab; } set { _cCodTab = value; } }

        String _cNomTab = "";
        public String cNomTab { get { return _cNomTab; } set { _cNomTab = value; } }

        String _cValor = "";
        public String cValor { get { return _cValor; } set { _cValor = value; } }

        Boolean _bEstado = false    ;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        DateTime _dFechaReg ;
        public DateTime dFechaReg { get { return _dFechaReg; } set { _dFechaReg = value; } }

        Int32 _idUsuario=0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

     
        public Cargo(String pcCodTab, String pcNomTab, Boolean pbEstado)
        {
            cCodTab = pcCodTab;
            cNomTab = pcNomTab;
            bEstado = pbEstado;
        }

        public Cargo(String pcCodTab, String pcNomTab, String pcValor)
        {
            cCodTab = pcCodTab;
            cNomTab = pcNomTab;
            cValor = pcValor;
        }

    }
}
