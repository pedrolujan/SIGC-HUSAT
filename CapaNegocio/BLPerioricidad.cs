using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLPerioricidad
    {
        public BLPerioricidad() { }

        public String blGrabarPerioricidad(Perioricidad objPerio, Int16 pnTipoCon)
        {
            DAPerioricidad daobjPerio = new DAPerioricidad();
            try
            {
                return daobjPerio.daGrabarPerioricidad(objPerio, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Int16 blBuscarNombrePerio(String pcBuscar, Int16 pnTipoCon)
        {

            DAPerioricidad objPerio = new DAPerioricidad();
            try
            {
                return objPerio.daBuscarNombrePerio(pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Perioricidad> blBuscarPerio(String pcBuscar, Int16 pnTipoCon)
        {
            DAPerioricidad objPerio = new DAPerioricidad();
            try
            {
                return objPerio.daBuscarPerio(pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Perioricidad> blListarPerioricidad(Int32 idPerio)
        {
            DAPerioricidad objPerio = new DAPerioricidad();
            try
            {
                return objPerio.daListarPerioricidad(idPerio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Perioricidad> blDevolverPerioricidad(Int32 idPerio)
        {
            DAPerioricidad objPerio = new DAPerioricidad();
            try
            {
                return objPerio.daDevolverPerioricidad(idPerio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
