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
   public class BLCate_Mar_Mod
    {
        public List<MarcaEquipo> blDevolverMarcaEquipo(Int32 idCategoria,Int16 pnTipoCon, Boolean buscar)
        {

            DACate_Mar_Mod objMarcaE = new DACate_Mar_Mod();
            try
            {
                return objMarcaE.daDevolverMarcaEquipo(idCategoria,pnTipoCon,buscar );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<ModeloEquipo> blDevolverModeloEquipo(Int32 idModeloE,Int16 pnTipoCon,Boolean buscar)
        {

            DACate_Mar_Mod objModeloE = new DACate_Mar_Mod();
            try
            {
                return objModeloE.daDevolverModeloEquipo(idModeloE,pnTipoCon,buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //public List<Operador> blDevolverOperador(Int32 idOperadorE)
        //{

        //    DAOperador objModeloE = new DAOperador();
        //    try
        //    {
        //        return objModeloE.daDevolverModeloEquipo(idOperadorE);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}
        public List<CategoriaEquipo> blDevolverCategoriaEquipo(Int32 idCategoria,Boolean buscar)
        {

            DACate_Mar_Mod objCategoria = new DACate_Mar_Mod();
            try
            {
                return objCategoria.daDevolverCategoriaEquipo(idCategoria,buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        
        public String blGrabarCategoria(CategoriaEquipo objCategoria, Int16 pnTipoCon)
        {
            DACate_Mar_Mod objCat_Marc_Mod = new DACate_Mar_Mod();
            try
            {
                return objCat_Marc_Mod.daGrabarCategoriaEquipo(objCategoria, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public String blGrabarMarca(MarcaEquipo objMarca, Int16 pnTipoCon)
        {
            DACate_Mar_Mod objCat_Marc_Mod = new DACate_Mar_Mod();
            try
            {
                return objCat_Marc_Mod.daGrabarMarcaEquipo(objMarca, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public String blGrabarModelo(ModeloEquipo objModelo, Int16 pnTipoCon)
        {
            DACate_Mar_Mod objCat_Marc_Mod = new DACate_Mar_Mod();
            try
            {
                return objCat_Marc_Mod.daGrabarModeloEquipo(objModelo, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<CategoriaEquipo> blBuscarCategoriaE(String pcBuscar, Int16 piTipoCon)
        {
            DACate_Mar_Mod objCat_Marc_Mod = new DACate_Mar_Mod();
            try
            {
                return objCat_Marc_Mod.daBuscarCategoriaE(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<MarcaEquipo> blBuscarMarcaE(String pcBuscar, Int16 piTipoCon)
        {
            DACate_Mar_Mod objCat_Marc_Mod = new DACate_Mar_Mod();
            try
            {
                return objCat_Marc_Mod.daBuscarMarcaE(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ModeloEquipo> blBuscarModeloE(String pcBuscar, Int16 piTipoCon)
        {
            DACate_Mar_Mod objCat_Marc_Mod = new DACate_Mar_Mod();
            try
            {
                return objCat_Marc_Mod.daBuscarModeloE(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public List<ModeloVehiculo> blListarModelo(Int32 idVehiulo)
        {
            DAAttrVehiculo objModeloV = new DAAttrVehiculo();
            try
            {
                return objModeloV.daListarModelo(idVehiulo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public List<MarcaVehiculo> blListarMarcasV(Boolean pbEstado)
        //{
        //    DAAttrVehiculo objMarca = new DAAttrVehiculo();
        //    try
        //    {
        //        return objMarca.daListarMarcas(pbEstado);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public List<ModeloVehiculo> blListarModelosV(Boolean pbEstado)
        //{
        //    DAAttrVehiculo objModelo = new DAAttrVehiculo();
        //    try
        //    {
        //        return objModelo.daListarModelos(pbEstado);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


        public ModeloEquipo blListarModeloDataGrid(Int32 codPlan)
        {
            DACate_Mar_Mod objPlan = new DACate_Mar_Mod();
            try
            {
                return objPlan.daListarModeloDatatable(codPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarPlanDataTable(String pcBuscar, Int16 piTipoCon, Int32 idCategoria, Int32 idMarca)
        {
            DACate_Mar_Mod objPlan = new DACate_Mar_Mod();
            try
            {
                return objPlan.daBuscarModeloDataTable(pcBuscar, piTipoCon, idCategoria,idMarca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Int16 blBuscarNombreModelo(String pcBuscar, Int32 pcTipoPlan)
        {

            DACate_Mar_Mod objAcc = new DACate_Mar_Mod();
            try
            {
                return objAcc.daBuscarNombreModelo(pcBuscar, pcTipoPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
