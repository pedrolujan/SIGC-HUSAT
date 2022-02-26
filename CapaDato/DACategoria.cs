using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaConexion;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using CapaUtil;


namespace CapaDato
{
    public class DACategoria
    {
        private clsUtil objUtil = null;

        public DataTable DAListarCategoria()
        {
            DataTable dtCategoria = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                lsSql = "uspMantenimientoCategoria 0,'','',0,'',0,1";
                objCnx = new clsConexion("");
                dtCategoria = objCnx.CargaDataTable(lsSql);
                return dtCategoria;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACategoria.cs", "DAListarCategoria", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public String DARegistrarCategoria(Int32 peiCodigoCategoria, String pecNombreCategoria, String pecDescripcion, Int32 pebEstado, String pecFecha, Int32 peiIdUsuario, Int32 peiTipo)
        {
            DataTable dtcategoria = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsResultado;
            String lsSql = "";
            try
            {
                lsSql = "uspMantenimientoCategoria " + Convert.ToString(peiCodigoCategoria) + ",'" + pecNombreCategoria + "','" + pecDescripcion + "'," + Convert.ToString(pebEstado) + ",'" + pecFecha + "'," + Convert.ToString(peiIdUsuario) + ",2";
                objCnx = new clsConexion("");
                dtcategoria = objCnx.CargaDataTable(lsSql);
                lsResultado = Convert.ToString(dtcategoria.Rows[0]["cResul"]);

                return lsResultado;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACategoria.cs", "DARegistrarCategoria", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public DataTable daBuscarPlanDataTable(String pcBuscar, Int16 pnTipoCon, Int32 idTipoPlan)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();



            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.Real);
                pa[1].Value = pnTipoCon;
                
                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarCategoriaE", pa);

                return dtEquipo;



            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }



        }

        public CategoriaEquipo daListarPlanDatatable(Int32 codPlan)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            CategoriaEquipo lstPlan = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peidCategoria", SqlDbType.Int);
                pa[0].Value = codPlan;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarCategoriaEquipo", pa);

                lstPlan = new CategoriaEquipo();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPlan.idCategoria = Convert.ToInt32(drMenu["idCategoria"]);
                    lstPlan.cNomCategoria = Convert.ToString(drMenu["cNombre"]);
                    lstPlan.cDescripCategoria = Convert.ToString(drMenu["cObservacion"]);
                    lstPlan.bEstado = Convert.ToBoolean(drMenu["bEstado"]);
                    
                }

                return lstPlan;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPlan.cs", "daListarPlan", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstPlan = null;
            }
        }

        public Int16 daBuscarNombreCategoria(String pcBuscar)
        {

            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.NVarChar, 45);
                pa[0].Value = pcBuscar;
               


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarNombreCategoria", pa);

                Int16 numFilas;

                if (dtUsuario.Rows.Count > 0)
                {
                    numFilas = 1;
                }
                else
                {
                    numFilas = 0;
                }

                return numFilas;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;

            }

        }
    }
}
