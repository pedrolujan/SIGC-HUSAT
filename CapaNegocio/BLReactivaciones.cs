using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLReactivaciones
    {
        private object simcard;

        public DataTable BlBuscarReactivacion(Int32 condicion,String dato  )
        {
            DAReactivaciones daobjEquipo = new DAReactivaciones();
            try
            {
                return daobjEquipo.DABuscarReactivacion(condicion,dato);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public DataTable blBuscarReactivacionEspecifico(Int32 condicion, Int32 idContrato)
        {
              DAReactivaciones daobjEquipo = new DAReactivaciones();
            try
            {
                return daobjEquipo.daBuscarReactivacionEspecificos(condicion, idContrato);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public Int32 blGuardarReactivaciones(Reactivaciones clsReac, String Condicion)
        {
            DAReactivaciones daobjEquipo = new DAReactivaciones();
            try
            {
                return daobjEquipo.daGuardarReactivaciones(clsReac, Condicion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }


    }



}