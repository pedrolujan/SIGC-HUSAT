using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLAsociacion
    {
        public List<Asociacion> blDevolverAsociacion(Int32 idAsociacion)
        {

            DAAsociacion objAsoc = new DAAsociacion();
            try
            {
                return objAsoc.daListarAsociacion(idAsociacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }       
        public String blGrabarAsociacion(Asociacion objAsociacion, Int16 pnTipoCon)
        {
            DAAsociacion objAsoc = new DAAsociacion();
            try
            {
                return objAsoc.daGrabarAsociacion(objAsociacion, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Asociacion> blBuscarAsociacion(String pcBuscar, Int16 piTipoCon)
        {
            DAAsociacion objAsoc = new DAAsociacion();
            try
            {
                return objAsoc.daBuscarAsociacion(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Asociacion> blListarAccesorio(Int32 idAsociacion)
        {
            DAAsociacion objAsoc = new DAAsociacion();
            try
            {
                return objAsoc.daListarAsociacion(idAsociacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
