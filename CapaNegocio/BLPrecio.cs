using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLPrecio
    {
        DAPrecio objPrecio = null;
        public BLPrecio()
        {
            objPrecio = new DAPrecio();
        }

        public List<Precio> blDevolverPrecioxProducto(int pidProducto)
        {
            try
            {
                return objPrecio.daDevolverPrecioxProducto(pidProducto);

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public bool blGuardarPrecio(List<Precio> lstprecio)
        {
            try
            {
                return objPrecio.daGuardarPrecio(lstprecio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public decimal blDevolverPrecioxProductoXUM(int pidProducto, int pidUnidadMedida)
        {
            try
            {
                return objPrecio.daDevolverPrecioxProductoXUM(pidProducto,pidUnidadMedida);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
