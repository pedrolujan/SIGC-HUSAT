using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntidad;

namespace CapaNegocio
{
   public  class BLConfigMesa
    {
       public List<ConfigMesa> blListarMesaConfigurada(string pcCodMesa, Int16 pidSucursal)
        {
            DAConfigMesa objMesa = new DAConfigMesa();
            try
            {
                return objMesa.daListarMesaConfigurada(pcCodMesa,pidSucursal);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         public String blGrabarConfigMesa(ConfigMesa objDocVenta)
         {
             DAConfigMesa objMesa = new DAConfigMesa();
             try
             {
                 return objMesa.daGrabarConfigMesa(objDocVenta);

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }

         public List<ConfigMesa> blListarMesa(bool pbEstado,Int16 pidSucursal)
         {
             DAConfigMesa objMesa = new DAConfigMesa();
             try
             {
                 return objMesa.daListarMesa(pbEstado, pidSucursal);

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }

    }
}
