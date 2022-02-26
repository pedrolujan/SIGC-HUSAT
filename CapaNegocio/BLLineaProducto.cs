using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidad;
using CapaDato;
namespace CapaNegocio
{
    public class BLLineaProducto
    {

        public DataTable BLListarLineaProducto()
        {

            DALineaProducto daobjUsuario = new DALineaProducto();
            try
            {
                return daobjUsuario.DAListarLineaProducto();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable BLListarLineaProductoCombo()
        {

            DALineaProducto daobjUsuario = new DALineaProducto();
            try
            {
                return daobjUsuario.DAListarLineaProductoCombo();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String BLRegistrarLineaProducto(Int32 peiCodigoLinea, String pecNombreLinea, Int32 pebEstado, Int32 pecCodigoCategoria, String pecFecha, Int32 peiIdUsuario, Int32 peiTipo)
        {
            DALineaProducto daobjUsuario = new DALineaProducto();
            try
            {
                return daobjUsuario.DARegistrarLineaProducto(peiCodigoLinea, pecNombreLinea, pebEstado, pecCodigoCategoria, pecFecha, peiIdUsuario, peiTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
