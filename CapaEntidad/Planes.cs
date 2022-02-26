using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Planes
    {
        public Planes() { }

        Int32 _idPlan = 0;
        public Int32 idPlan { get { return _idPlan; } set { _idPlan = value; } }

        String _cPlan = "";
        public String cPlan { get { return _cPlan; } set { _cPlan = value; } }

        String _cPerio = "";
        public String cPerio { get { return _cPerio; } set { _cPerio = value; } }

        Int32 _idPerioricidad = 0;
        public Int32 idPerioricidad { get { return _idPerioricidad; } set { _idPerioricidad = value; } }

        DateTime _dFechaRegistro;
        public DateTime dFechaRegistro { get { return _dFechaRegistro; } set { _dFechaRegistro = value; } }

        Int32 _idUsuario = 0;
        public Int32 idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        Boolean _bEstado = false;
        public Boolean bEstado { get { return _bEstado; } set { _bEstado = value; } }

        public Planes(Int32 pidPlan, String pcNomPlan,Int32 pidEstadoPlan, Boolean pbEstado)
        {
            idPlan = pidPlan;
            cPlan = pcNomPlan;
            idPerioricidad = pidEstadoPlan;
           
            bEstado = pbEstado;
        }
        
        public Planes(Int32 pidPlan, String pcNomPlan, String pcNombrePerio, Boolean pbEstado)
        {
            idPlan = pidPlan;
            cPlan = pcNomPlan;
            cPerio = pcNombrePerio;
            bEstado = pbEstado;
           
        }
       
        public Planes(Int32 pidPlan, String pcNomPlan, Boolean pbEstado)
        {
            idPlan = pidPlan;
            cPlan = pcNomPlan;
            bEstado = pbEstado;
        }
        public Planes(Int32 pidPlan, String pcNomPlan)
        {
            idPlan = pidPlan;
            cPlan = pcNomPlan;
            
        }

    }
}
