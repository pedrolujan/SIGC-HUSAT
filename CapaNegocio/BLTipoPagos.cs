using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLTipoPagos
    {
        public List<EntidadesPago> blDevolverEntidadPago(String cCodTipoPago, Int32 lnTipoCon)
        {

            DATipoPago daobjEntidad = new DATipoPago();
            try
            {
                return daobjEntidad.daDevolverEntidadPago(cCodTipoPago,  lnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
