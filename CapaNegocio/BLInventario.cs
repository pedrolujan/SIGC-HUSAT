using CapaDato;
using CapaEntidad;
using CapaEntidad.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLInventario
    {
        private DAInventario objInventario = null;
        public BLInventario() {
            objInventario = new DAInventario();
        }

        public List<DetalleInventario> blDevolverInventarioxProducto(int pIdAlmacen, int pidProducto = 0)
        {

            try
            {
                return objInventario.daDevolverInventarioxProducto(pIdAlmacen, pidProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public List<DetalleInventario> blDevolverInventarioxLote(int pIdAlmacen, int pidLote = 0)
        {

            try
            {
                return objInventario.daDevolverInventarioxLote(pIdAlmacen, pidLote);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool daGuardarInventario(GenericMasterDetail<Inventario, DetalleInventario> genericMasterDetail)
        {
            try
            {
                return objInventario.daGuardarInventario(genericMasterDetail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        }
}
