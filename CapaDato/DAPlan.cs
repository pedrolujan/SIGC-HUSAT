using CapaConexion;
using CapaEntidad;
using CapaUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class DAPlan
    {
        clsUtil objUtil;
        String idMaximo;
        String idReturn;

        public Int16 daBuscarNombrePlan(String pcBuscar,Boolean pcEstado,Int32 pcTipoPlan, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peEstado", SqlDbType.Bit,1);
                pa[1].Value = pcEstado;
                pa[2] = new SqlParameter("@peIdTipoPlan", SqlDbType.Int);
                pa[2].Value = pcTipoPlan;
                pa[3] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[3].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarNombrePlan", pa);

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

        public DataTable daBuscarPlanDatatable(String pcBuscar, String pnTipoCon, Int32 idTipoPlan,Int32 numPagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtPlan = new DataTable();
            clsConexion objCnx = null;
            List<Plan> lstPlan = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.NVarChar,1);
                pa[1].Value = pnTipoCon;
                pa[2] = new SqlParameter("@peIdTipoPlan", SqlDbType.Int);
                pa[2].Value = idTipoPlan;
                pa[3] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[3].Value = numPagina;
                pa[4] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[4].Value = tipoCon;
                objCnx = new clsConexion("");
                dtPlan = objCnx.EjecutarProcedimientoDT("uspBuscarPlan", pa);

                return dtPlan;

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
                lstPlan = null;
            }



        }

        public Boolean daValidarTipoPlan(Int32 idTipoPlan)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Plan lstPlan = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peIdTipoPlan", SqlDbType.NVarChar, 20);
                pa[0].Value = idTipoPlan;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspValidarEstadoTipoPlan", pa);

                lstPlan = new Plan();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPlan.estado = Convert.ToBoolean(drMenu["bEstado"]);
                    
                }

                return lstPlan.estado;
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

        public Boolean daValidarPlanEquipo(Int32 idPlanEquipo,Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Plan lstPlan = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peIdPlanEquipo", SqlDbType.Int);
                pa[0].Value = idPlanEquipo;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspValidarEstadoEquipo", pa);

                lstPlan = new Plan();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPlan.estado = Convert.ToBoolean(drMenu["bEstado"]);

                }

                return lstPlan.estado;
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

        public Plan daListarPlanDatatable(Int32 codPlan)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Plan lstPlan = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peCodPlan", SqlDbType.Int);
                pa[0].Value = codPlan;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarPlan", pa);

                lstPlan = new Plan();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPlan.idPlan = Convert.ToInt32(drMenu["idPlan"]);
                    lstPlan.idTipoPlan = Convert.ToInt32(drMenu["idTipoPlan"]);
                    lstPlan.nombrePlan = Convert.ToString(drMenu["nombrePlan"]);
                    lstPlan.precio = Convert.ToDouble(drMenu["precPlan"]);
                    lstPlan.equipos =Convert.ToString(drMenu["Equipos"]);
                    lstPlan.descripcion = Convert.ToString(drMenu["descPlan"]);
                    lstPlan.estado = Convert.ToBoolean(drMenu["estadoPlan"]);
                    lstPlan.idMoneda = Convert.ToInt32(drMenu["idMoneda"]);
                    lstPlan.PrecioEquipo = Convert.ToDouble(drMenu["precioEquipo"]);
                    lstPlan.PrecioRenovacion = Convert.ToDouble(drMenu["precioRenovacion"]);
                    lstPlan.tarifas = Convert.ToString(drMenu["tarifas"]);
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
        public bool daGrabarPlan(Plan objPlan, Int16 pnTipoCon, List<PlanEquipo> lstEquipos, List<Tarifa> lstTarifas)
        {
            SqlParameter[] pa = new SqlParameter[14];
                      
            objUtil = new clsUtil();
            int intRowsAffected = 0;
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            string xmlData = clsUtil.Serialize(lstEquipos);
            string xmlData2 = clsUtil.Serialize(lstTarifas);

            try
            {
                pa[0] = new SqlParameter("@peidPlan", SqlDbType.Int) { Value = objPlan.idPlan };
                pa[1] = new SqlParameter("@pecNombre", SqlDbType.NVarChar, 45) { Value = objPlan.nombrePlan };
                pa[2] = new SqlParameter("@cPrecio", SqlDbType.Money) { Value = objPlan.precio };
                pa[3] = new SqlParameter("@cDescripcion", SqlDbType.NVarChar, 200) { Value = objPlan.descripcion };
                pa[4] = new SqlParameter("@peIdUsuario", SqlDbType.Int) { Value = objPlan.idUsuario };
                pa[5] = new SqlParameter("@dfechaRegistro", SqlDbType.DateTime) { Value = objPlan.fechaRegistro };
                pa[6] = new SqlParameter("@pebEstado", SqlDbType.Bit, 1) { Value = objPlan.estado };
                pa[7] = new SqlParameter("@peIdTipoPlan", SqlDbType.Int) { Value = objPlan.idTipoPlan };
                pa[8] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt) { Value = pnTipoCon };
                pa[9] = new SqlParameter("@xmlData", SqlDbType.Xml) { Value = xmlData };
                pa[10] = new SqlParameter("@idMoneda", SqlDbType.Int) { Value = objPlan.idMoneda };
                pa[11] = new SqlParameter("@precioEquipo", SqlDbType.Money) { Value = objPlan.PrecioEquipo };
                pa[12] = new SqlParameter("@precioRenovacion", SqlDbType.Money) { Value = objPlan.PrecioRenovacion };
                pa[13] = new SqlParameter("@xmlData2", SqlDbType.Xml) { Value = xmlData2 };

                objCnx = new clsConexion("");
                intRowsAffected = objCnx.EjecutarProcedimiento("uspGuardarPlan", pa);

                return true;
               
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daGrabarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
                objPlan = null;
            }
        }
        public bool daGrabarEquiposNoAgregados(Int32 idPlan, Int16 pnTipoCon, List<PlanEquipo> lstEquipos)
        {
            SqlParameter[] pa = new SqlParameter[3];


            objUtil = new clsUtil();
            int intRowsAffected = 0;
            clsConexion objCnx = null;

            string xmlData = clsUtil.Serialize(lstEquipos);

            try
            {

                pa[0] = new SqlParameter("@peIdPlan", SqlDbType.Int);
                pa[0].Value = idPlan;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;
                pa[2] = new SqlParameter("@xmlData", SqlDbType.Xml);
                pa[2].Value = xmlData;



                objCnx = new clsConexion("");
                intRowsAffected = objCnx.EjecutarProcedimiento("uspGuardarEquiposNoAgregados", pa);

                return true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daGrabarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;

            }
        }


        public List<Plan> daDevolverPlanDeTipoPlan(Int32 idTipoPlan, Boolean buscar, Int16 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtTipoPlan = new DataTable();
            clsConexion objCnx = null;
            List<Plan> lstTipoPlan = null;
            objUtil = new clsUtil();

            try
            {
                if (tipoCon==-1 || tipoCon==-2)
                {
                    tipoCon = 0;
                }
                pa[0] = new SqlParameter("@peidTipoPlan", SqlDbType.Int);
                pa[0].Value = idTipoPlan;
                pa[1] = new SqlParameter("@pnTipoCon", SqlDbType.Real);
                pa[1].Value = tipoCon;



                objCnx = new clsConexion("");
                dtTipoPlan = objCnx.EjecutarProcedimientoDT("uspListarPlanDeTipodePlan", pa);

                lstTipoPlan = new List<Plan>();
                lstTipoPlan.Add(new Plan(
                       Convert.ToInt32("0"),
                       Convert.ToString(buscar ? "TODOS" : "Selecc. Plan" ),
                       Convert.ToBoolean(true),
                        Convert.ToDouble(0),
                        1,
                        0
                       ));
                foreach (DataRow drMenu in dtTipoPlan.Rows)
                {
                    lstTipoPlan.Add(new Plan(

                        Convert.ToInt32(drMenu["idPlan"]),
                        Convert.ToString(drMenu["cNombre"]),
                        Convert.ToBoolean(drMenu["bEstado"]),
                        Convert.ToDouble(drMenu["cPrecio"]),
                        Convert.ToInt32(drMenu["idMoneda"]),
                        Convert.ToInt32(drMenu["idTipoPlan"])
                        ));
                }

                return lstTipoPlan;

            }
            catch (Exception ex)
            {
                lstTipoPlan = null;
                objUtil.gsLogAplicativo("DAPlanes.cs", "daDevolverPlan", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstTipoPlan = null;
            }

        }

        public Plan daListarPlanProspecto(Int32 codPlan)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Plan lstPlan = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peCodPlan", SqlDbType.Int);
                pa[0].Value = codPlan;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarPlanEquiposProspecto", pa);

                lstPlan = new Plan();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPlan.equipos = Convert.ToString(drMenu["Equipos"]);
                    
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

        public DataTable daBuscarHistorialPlan(Int32 idTipoPlan, Int32 numPagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtPlan = new DataTable();
            clsConexion objCnx = null;
           
            objUtil = new clsUtil();
            try
            {
                
                pa[0] = new SqlParameter("@peidPlan", SqlDbType.Int);
                pa[0].Value = idTipoPlan;
                pa[1] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[1].Value = numPagina;
                pa[2] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[2].Value = tipoCon;
                objCnx = new clsConexion("");
                dtPlan = objCnx.EjecutarProcedimientoDT("uspListarHistorialPlan", pa);

                return dtPlan;

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
