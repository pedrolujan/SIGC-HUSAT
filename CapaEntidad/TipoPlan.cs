using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TipoPlan
    {
        public TipoPlan() { }

        public Int32 idTipoPlan { get; set; }
        public String nombreTipoPlan { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public Int32 idUsuario { get; set; }
        public Boolean bEstado { get; set; }
        public Int32 cMeses { get; set; }
        public String cDescripcion { get; set; }
        public Boolean conCiclo { get; set; }
        public List<TipoPlan> lstTipoPlan { get; set; }

        public TipoPlan(Int32 pnCodTipoPlan, String pcNombreTipoPlan,Int32 pcMeses,String pcDescripcion, Boolean pbEstado,Boolean pnConCiclo)
        {
            idTipoPlan = pnCodTipoPlan;
            nombreTipoPlan = pcNombreTipoPlan;
            cMeses = pcMeses;
            cDescripcion = pcDescripcion;
            bEstado = pbEstado;
            conCiclo = pnConCiclo;
        }

        public TipoPlan(Int32 pnCodTipoPlan, String pcNombreTipoPlan,Int32 numMeses)
        {
            idTipoPlan = pnCodTipoPlan;
            nombreTipoPlan = pcNombreTipoPlan;
            cMeses = numMeses;
        }

        public static TipoPlan fnObtenerTipoPlanSeleccionado(Int32 idTP, List<TipoPlan> lstTipoPlan)
        {
            foreach (TipoPlan tp in lstTipoPlan)
            {
                if (tp.idTipoPlan == idTP)
                {
                    return tp;
                }
            }
            return new TipoPlan();
        }
    }


}
