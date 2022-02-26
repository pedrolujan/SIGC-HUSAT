using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDato;
using System.Data;

namespace CapaNegocio
{
    public class BLVentaMesa
    {

        public String blGrabarVentaMesa(VentaMesa objDocVenta)
        {

            DAVentaMesa objVenta = new DAVentaMesa();
            try
            {
                return objVenta.daGrabarVentaMesa(objDocVenta);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public String blGrabarVentaMesaMasiva(DataTable dtVenta, string pcTipoPago, decimal mMontoTotal, decimal mMontoPagar)
        {
            DAVentaMesa objVenta = new DAVentaMesa();
            try
            {
                return objVenta.daGrabarVentaMesaMasiva(dtVenta,pcTipoPago,mMontoTotal,mMontoPagar);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String blGrabarVentaxMayor(VentaMayor objDocVenta)
        {

            DAVentaMesa objVenta = new DAVentaMesa();
            try
            {
                return objVenta.daGrabarVentaxMayor(objDocVenta);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
