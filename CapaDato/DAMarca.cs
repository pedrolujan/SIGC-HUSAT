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
    public class DAMarca
    {

        private clsUtil objUtil = null;

        
        public DataTable DAListarMarcas()
        {
            //SqlParameter[] pa = new SqlParameter[7];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                lsSql = "uspMantenimientoMarca 0,'','',0,'',0,1";
                objCnx = new clsConexion("");
                dtUsuario = objCnx.CargaDataTable(lsSql);
                return dtUsuario;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAMarca.cs", "DAListarMarcas", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public String DARegistrarMarca(Int32 peiCodigoMarca,String pecNombreMarca,String pecDescripcion,Int32 pebEstado,String pecFecha,Int32 peiIdUsuario,Int32 peiTipo)
        {
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsResultado;
            String lsSql = "";
            try
            {

                
                lsSql = "uspMantenimientoMarca " + Convert.ToString(peiCodigoMarca) + ",'" + pecNombreMarca + "','" + pecDescripcion + "'," + Convert.ToString(pebEstado) + ",'" + pecFecha + "'," +Convert.ToString (peiIdUsuario) + ",2";


                objCnx = new clsConexion("");
                dtUsuario = objCnx.CargaDataTable(lsSql);
                lsResultado = Convert.ToString(dtUsuario.Rows[0]["cResul"]);
                               
                return lsResultado;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAMarca.cs", "DARegistrarMarca", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public DataTable daBuscarPlanDataTable(String pcBuscar, Int16 pnTipoCon, Int32 idCategoria)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();



            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.Real);
                pa[1].Value = pnTipoCon;
                pa[2] = new SqlParameter("@peidCategoria", SqlDbType.Int);
                pa[2].Value = idCategoria;

                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarMarcaE", pa);

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

        public MarcaEquipo daListarPlanDatatable(Int32 codPlan)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            MarcaEquipo lstPlan = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peidMarca", SqlDbType.Int);
                pa[0].Value = codPlan;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarMarcaEquipo", pa);

                lstPlan = new MarcaEquipo();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPlan.idMarca = Convert.ToInt32(drMenu["idMarcaEquipo"]);
                    lstPlan.idCategoria = Convert.ToInt32(drMenu["idCategoria"]);
                    lstPlan.cNomMarca = Convert.ToString(drMenu["cNombreMarca"]);
                    lstPlan.cDescripMarca = Convert.ToString(drMenu["cObservaciones"]);
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

        public Int16 daBuscarNombreMarca(String pcBuscar, Int32 pcidCategoria)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peidCategoria", SqlDbType.Int);
                pa[1].Value = pcidCategoria;
                
               
                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarNombreMarca", pa);

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
