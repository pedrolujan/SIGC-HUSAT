using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLEgresos
    {
        public BLEgresos() { }
        DAEgresos daEgre;
        public Boolean blGuardarEgresos(List<Pagos> lstPagos, List<xmlDocumentoVentaGeneral> xmlDVG, Egresos clsEgresos)
        {
            daEgre = new DAEgresos();
            try
            {
                return daEgre.daGuardarEgresos(lstPagos,xmlDVG, clsEgresos);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
