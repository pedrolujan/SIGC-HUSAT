using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLCiclo
    {
        public List<Ciclo> blDevolverCiclo(Int32 idCiclo, Boolean tipBusqueda)
        {

            DACiclo objTipoPlan = new DACiclo();
            try
            {
                return objTipoPlan.daDevolverCiclo(idCiclo, tipBusqueda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
