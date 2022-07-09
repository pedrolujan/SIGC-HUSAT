using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLCaja
    {
        DACaja dcaja ;
        public List<ReporteBloque> blBuscarVentas(Busquedas clsBusq)
        {
            dcaja = new DACaja();
            try
            {
                return dcaja.daBuscarVentas( clsBusq);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }

        }
    }
}
