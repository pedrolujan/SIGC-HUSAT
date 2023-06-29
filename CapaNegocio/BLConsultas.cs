using CapaDato;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLConsultas
    {
        public DataTable blBuscarHistorialSimCard(String simcard, Int32 tipoCon)
        {
            DAconsultas daobjEquipo = new DAconsultas();
            try
            {
                return daobjEquipo.daBuscarHistorialSimCard(simcard, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public DataTable blBuscarDatosEspecificos(Int32 dato, Int32 tipoCon)
        {
            DAconsultas daobjEquipo = new DAconsultas();
            try
            {
                return daobjEquipo.daBuscarDatosEspecificos(dato,tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public DataTable DaBuscarReactivacionEspecificos(int v, object tipoCon)
        {
            throw new NotImplementedException();
        }
    }
}
