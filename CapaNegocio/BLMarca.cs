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
    public class BLMarca
    {
        public DataTable BLListarMarcas()
        {

            DAMarca daobjUsuario = new DAMarca();
            try
            {
                return daobjUsuario.DAListarMarcas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String BLRegistrarMarca(Int32 peiCodigoMarca, String pecNombreMarca, String pecDescripcion, Int32 pebEstado, String pecFecha, Int32 peiIdUsuario, Int32 peiTipo)
        {
            DAMarca daobjUsuario = new DAMarca();
            try
            {
                return daobjUsuario.DARegistrarMarca( peiCodigoMarca,  pecNombreMarca,  pecDescripcion,  pebEstado,  pecFecha,  peiIdUsuario,  peiTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blBuscarPlanDataTable(String pcBuscar, Int16 piTipoCon, Int32 idCategoria)
        {
            DAMarca objPlan = new DAMarca();
            try
            {
                return objPlan.daBuscarPlanDataTable(pcBuscar, piTipoCon, idCategoria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MarcaEquipo blListarPlanDataGrid(Int32 codPlan)
        {
            DAMarca objPlan = new DAMarca();
            try
            {
                return objPlan.daListarPlanDatatable(codPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Int16 blBuscarNombreMarca(String pcBuscar,Int32 pcTipoPlan)
        {

            DAMarca objAcc = new DAMarca();
            try
            {
                return objAcc.daBuscarNombreMarca(pcBuscar, pcTipoPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
