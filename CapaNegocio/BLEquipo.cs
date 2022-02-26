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
    public class BLEquipo
    {
        public BLEquipo(){}
       
       
        public bool blGrabarEquipo(Equipo objEquipo, Int16 pnTipoCon, List<EquipoAccesorios> lstAccesorios)
        {

            DAEquipo daobjPlan = new DAEquipo();
            try
            {
                return daobjPlan.daGrabarEquipo(objEquipo, pnTipoCon, lstAccesorios);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Boolean blValidarEquipoAccesorio(Int32 idPlanAccesorio , Int16 pnTipoCon)
        {
            DAEquipo objPlan = new DAEquipo();

            try
            {
                return objPlan.daValidarEquipoAccesorio(idPlanAccesorio,pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Equipo> blDevolverEquipo(Int32 idPlan)
        {

            DAEquipo objEquipo = new DAEquipo();
            try
            {
                return objEquipo.daDevolverEquipo(idPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
       
        
        public List<Equipo> blBuscarEquipo(String pcBuscar, Int16 piTipoCon)
        {
            DAEquipo objEquipo = new DAEquipo();
            try
            {
                return objEquipo.daBuscarEquipo(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarEquipoDatatable(String pcBuscar, Int16 piTipoCon)
        {
            DAEquipo objEquipo = new DAEquipo();
            try
            {
                return objEquipo.daBuscarEquipoDatatable(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Equipo blListarPlan(Int32 idPlan)
        {
            DAEquipo objPlan = new DAEquipo();
            try
            {
                return objPlan.daListarEquipoDatatable(idPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarEquipoDataTable(String pcBuscar, String piTipoCon, Int32 idCategoria, Int32 idMarca, Int32 idModelo, Int32 numPagina, Int32 tipoCon)
        {
            DAEquipo objPlan = new DAEquipo();
            try
            {
                return objPlan.daBuscarEquipoDataTable(pcBuscar, piTipoCon, idCategoria,idMarca,idModelo,numPagina,tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Equipo blListarPlanDataGrid(Int32 codPlan)
        {
            DAEquipo objEquipo = new DAEquipo();
            try
            {
                return objEquipo.daListarEquipoDatatable(codPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool blGrabarAccesoriosNoAgregados(Int32 idEquipo, Int16 pnTipoCon, List<EquipoAccesorios> lstAccesorios)
        {

            DAEquipo daobjPlan = new DAEquipo();
            try
            {
                return daobjPlan.daGrabarAccesoriosNoAgregados(idEquipo, pnTipoCon, lstAccesorios);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Int16 blBuscarNombreEquipo(Int32 idCategoria, Int32 idMarca, Int32 idModelo, String pcBuscar, Int16 pnTipoCon)
        {

            DAEquipo objAcc = new DAEquipo();
            try
            {
                return objAcc.daBuscarNombreEquipo(idCategoria,idMarca,idModelo, pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Equipo> blListarEquipo(Int32 idAccesorio, Int32 peTipoCon)
        {
            DAEquipo objAccesorio = new DAEquipo();
            try
            {
                return objAccesorio.daListarEquipo(idAccesorio, peTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<CategoriaEquipo> blDevolverCategoriaEquipo(Int32 idAccesorio, Boolean buscar)
        {
            DAEquipo objAccesorio = new DAEquipo();
            try
            {
                return objAccesorio.daDevolverCategoriaEquipo(idAccesorio, buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MarcaEquipo> blDevolverMarcaEquipo(Int32 pnTipoCon,Int32 idMarca, Boolean buscar)
        {
            DAEquipo objAccesorio = new DAEquipo();
            try
            {
                return objAccesorio.daDevolverMarcaEquipo(pnTipoCon,idMarca, buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ModeloEquipo> blDevolverModeloEquipo(Int32 idMarca, Boolean buscar,Int16 pntipoCon)
        {
            DAEquipo objAccesorio = new DAEquipo();
            try
            {
                return objAccesorio.daDevolverModeloEquipo(idMarca, buscar, pntipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarEquipoHistorial( Int32 idEquipo, Int32 numPagina, Int32 tipoCon)
        {
            DAEquipo objPlan = new DAEquipo();
            try
            {
                return objPlan.daBuscarEquipoHistorial(idEquipo, numPagina, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
