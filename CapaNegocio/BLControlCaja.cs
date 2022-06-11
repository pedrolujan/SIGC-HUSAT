using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLControlCaja
    {
        public BLControlCaja() { }

        public List<ControlCaja> blFnLLenarTipoPago(String id,Boolean estado)
        {
            DAControlCaja dc = new DAControlCaja();
            try
            {
                return dc.daFnLlenarTipoPago(id,estado);

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }
}
