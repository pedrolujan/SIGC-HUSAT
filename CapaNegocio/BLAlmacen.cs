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
    public class BLAlmacen
    {
        public DataTable BLListarAlmacen()
        {

            DAAlmacen daobjUsuario = new DAAlmacen();
            try
            {
                return daobjUsuario.DAListarAlmacen();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String BLRegistrarAlmacen(Int32 peiCodigoCategoria, String pecNombreCategoria, Int32 peiCodigoSucursal, Int32 pebEstado, String pecFecha, Int32 peiIdUsuario, Int32 peiTipo)
        {
            DAAlmacen daobjUsuario = new DAAlmacen();
            try
            {
                return daobjUsuario.DARegistrarAlmacen(peiCodigoCategoria, pecNombreCategoria, peiCodigoSucursal, pebEstado, pecFecha, peiIdUsuario, peiTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
