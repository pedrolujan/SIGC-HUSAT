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
    public class BLUnidadMedida
    {
        public DataTable BLListarUnidadMedida()
        {

            DAUnidadMedida daobjUsuario = new DAUnidadMedida();
            try
            {
                return daobjUsuario.DAListarUnidadMedida();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String BLRegistrarUnidadMedida(Int32 peiCodigoUM, String pecNombreUM, String pecAbrev, Int32 pebEstado, String pecFecha, Int32 peiIdUsuario, Int32 peiTipo)
        {
            DAUnidadMedida daobjUsuario = new DAUnidadMedida();
            try
            {
                return daobjUsuario.DARegistrarUnidadMedida(peiCodigoUM, pecNombreUM, pecAbrev, pebEstado, pecFecha, peiIdUsuario, peiTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable BLListarUnidadMedidaCombo()
        {

            DAUnidadMedida daobjUsuario = new DAUnidadMedida();
            try
            {
                return daobjUsuario.DAListarUnidadMedidaCombo();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
