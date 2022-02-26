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
    public class BLCategoria
    {

        public DataTable BLListarCategoria()
        {

            DACategoria daobjUsuario = new DACategoria();
            try
            {
                return daobjUsuario.DAListarCategoria();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String BLRegistrarCategoria(Int32 peiCodigoCategoria, String pecNombreCategoria, String pecDescripcion, Int32 pebEstado, String pecFecha, Int32 peiIdUsuario, Int32 peiTipo)
        {
            DACategoria daobjUsuario = new DACategoria();
            try
            {
                return daobjUsuario.DARegistrarCategoria(peiCodigoCategoria, pecNombreCategoria, pecDescripcion, pebEstado, pecFecha, peiIdUsuario, peiTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable blBuscarPlanDataTable(String pcBuscar, Int16 piTipoCon, Int32 idTipoPlan)
        {
            DACategoria objPlan = new DACategoria();
            try
            {
                return objPlan.daBuscarPlanDataTable(pcBuscar, piTipoCon, idTipoPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CategoriaEquipo blListarPlanDataGrid(Int32 codPlan)
        {
            DACategoria objPlan = new DACategoria();
            try
            {
                return objPlan.daListarPlanDatatable(codPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Int16 blBuscarNombreCategoria(String pcBuscar)
        {

            DACategoria objAcc = new DACategoria();
            try
            {
                return objAcc.daBuscarNombreCategoria(pcBuscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
