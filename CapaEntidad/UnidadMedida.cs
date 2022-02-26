using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class UnidadMedida
    {
        Int32 _idUnidadMedida = 0;
        public Int32 idUnidadMedida { get { return _idUnidadMedida; } set { _idUnidadMedida = value; } }

        String _cNombreUM = "";
        public String cNombreUM { get { return _cNombreUM; } set { _cNombreUM = value.Trim(); } }

        public UnidadMedida(Int32 pidUnidadMedida, String pcNombreUM)
        {
            idUnidadMedida = pidUnidadMedida;
            cNombreUM = pcNombreUM;
        }

    }
}
