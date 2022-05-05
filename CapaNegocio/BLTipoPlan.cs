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
    public class BLTipoPlan
    {
        public BLTipoPlan() { }

        public String blGrabarTipoPlan(TipoPlan objTipoPlan, Int16 pnTipoCon)
        {

            DATipoPlan daobjTipoPlan = new DATipoPlan();
            try
            {
                return daobjTipoPlan.daGrabarTipoPlan(objTipoPlan, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blBuscarTipoPlanDataTable(String pcBuscar, Int16 piTipoCon)
        {
            DATipoPlan objEquipo = new DATipoPlan();
            try
            {
                return objEquipo.daBuscarTipoPlanDataTable(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Int16 blBuscarNombreTipoPlan(String pcBuscar, Int16 pnTipoCon)
        {

            DATipoPlan objAcc = new DATipoPlan();
            try
            {
                return objAcc.daBuscarNombreTipoPlan(pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public TipoPlan blListarTipoPlanDataGrid(Int32 idPlan)
        {
            DATipoPlan objPlan = new DATipoPlan();
            try
            {
                return objPlan.daListarTipoPlanDatatable(idPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<TipoPlan> blBuscarTipoPlan(String pcBuscar, Int16 pnTipoCon)
        {

            DATipoPlan objTipoPlan = new DATipoPlan();
            try
            {
                return objTipoPlan.daBuscarTipoPlan(pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<TipoPlan> blListarTipoPlan(Int32 idTipoPlan)
        {
            DATipoPlan objTipoPlan = new DATipoPlan();
            try
            {
                return objTipoPlan.daListarTipoPlan(idTipoPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


       public List<TipoPlan> blDevolverTipoPlan(Int32 idTipoPlan, Int32 tipBusqueda)
       {

            BLCargo objTablaCod = new BLCargo();
            List<Cargo> lstTablaCod = new List<Cargo>();
            DATipoPlan objTipoPlan = new DATipoPlan();
            try
            {
                return objTipoPlan.daDevolverTipoPlan(idTipoPlan,tipBusqueda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

       }

       
    }
}
