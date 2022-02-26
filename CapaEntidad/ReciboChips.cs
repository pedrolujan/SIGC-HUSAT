using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ReciboChips
    {
        public ReciboChips() { }

        Int32 _idRecibo = 0;
        public Int32 idRecibo { get { return _idRecibo; } set { _idRecibo = value; } }

        String _observacion = "";
        public String observacion { get { return _observacion; } set { _observacion = value; } }

        Int32 _CicloPago = 0;
        public Int32 CicloPago { get { return _CicloPago; } set { _CicloPago = value; } }

    }
}
