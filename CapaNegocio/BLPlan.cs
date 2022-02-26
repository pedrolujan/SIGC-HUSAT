using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLPlan
    {
        public Int16 blBuscarNombrePlan(String pcBuscar, Boolean pcEstado, Int32 pcTipoPlan, Int16 pnTipoCon)
        {

            DAPlan objAcc = new DAPlan();
            try
            {
                return objAcc.daBuscarNombrePlan(pcBuscar, pcEstado, pcTipoPlan, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
        public Plan blListarPlanDataGrid(Int32 codPlan)
        {
            DAPlan objPlan = new DAPlan();
            try
            {
                return objPlan.daListarPlanDatatable(codPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean blValidarPlanEquipo(Int32 idPlanEquipo,Int16 pnTipoCon)
        {
            DAPlan objPlan = new DAPlan();
            
            try
            {
                return objPlan.daValidarPlanEquipo(idPlanEquipo,pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Boolean blValidarTipoPlan(Int32 idTipoPlan)
        {
            DAPlan objPlan = new DAPlan();
            try
            {
                return objPlan.daValidarTipoPlan(idTipoPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public DataTable blBuscarPlanDataTable(String pcBuscar, String piTipoCon,Int32 idTipoPlan, Int32 numPagina, Int32 tipoCon)
        {
            DAPlan objPlan = new DAPlan();
            try
            {
                return objPlan.daBuscarPlanDatatable(pcBuscar, piTipoCon, idTipoPlan,numPagina,tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool blGrabarPlan(Plan objTipoPlan, Int16 pnTipoCon, List<PlanEquipo> lstEquipos,List<Tarifa> lstTarifa)
        {

            DAPlan daobjPlan = new DAPlan();
            try
            {
                return daobjPlan.daGrabarPlan(objTipoPlan, pnTipoCon, lstEquipos,lstTarifa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public bool blGrabarEquiposNoAgregados(Int32 idPlan, Int16 pnTipoCon, List<PlanEquipo> lstEquipos)
        {

            DAPlan daobjPlan = new DAPlan();
            try
            {
                return daobjPlan.daGrabarEquiposNoAgregados(idPlan, pnTipoCon, lstEquipos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public List<Plan> blDevolverPlanDeTipoPlan(Int32 idTipoPlan, Boolean tipBusqueda,Int16 tipoCon)
        {

            DAPlan objTipoPlan = new DAPlan();
            try
            {
                return objTipoPlan.daDevolverPlanDeTipoPlan(idTipoPlan, tipBusqueda,tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Plan blListarPlanProspecto(Int32 codPlan)
        {
            DAPlan objPlan = new DAPlan();
            try
            {
                return objPlan.daListarPlanProspecto(codPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarHitorialPlan(Int32 idPlan, Int32 numPagina, Int32 tipoCon)
        {
            DAPlan objPlan = new DAPlan();
            try
            {
                return objPlan.daBuscarHistorialPlan(idPlan, numPagina, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
