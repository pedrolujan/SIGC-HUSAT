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
    public class DAPlanes
    {
        private clsUtil objUtil = null;
        public List<Planes> daDevolverPlanes(Int32 idPlan)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtPlan = new DataTable();
            clsConexion objCnx = null;
            List<Planes> lstPlan = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidPlan", SqlDbType.Int);
                pa[0].Value = idPlan;


                objCnx = new clsConexion("");
                dtPlan = objCnx.EjecutarProcedimientoDT("uspListarPlanes", pa);

                lstPlan = new List<Planes>();
                foreach (DataRow drMenu in dtPlan.Rows)
                {
                    lstPlan.Add(new Planes(Convert.ToInt32(drMenu["idPlan"]),
                        Convert.ToString(drMenu["nombrePlan"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstPlan;

            }
            catch (Exception ex)
            {
                lstPlan = null;
                objUtil.gsLogAplicativo("DAPlanes.cs", "daDevolverPlan", ex.Message);
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

        public List<Planes> daDevolverPlan(Int32 idPlan)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtPlan = new DataTable();
            clsConexion objCnx = null;
            List<Planes> lstPlan = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidPlan", SqlDbType.Int);
                pa[0].Value = idPlan;


                objCnx = new clsConexion("");
                dtPlan = objCnx.EjecutarProcedimientoDT("uspListarPlan", pa);

                lstPlan = new List<Planes>();
                foreach (DataRow drMenu in dtPlan.Rows)
                {
                    lstPlan.Add(new Planes(Convert.ToInt32(drMenu["idPlan"]),
                        Convert.ToString(drMenu["nombrePlan"]),
                        Convert.ToBoolean(drMenu["estadoPlan"])));
                }

                return lstPlan;

            }
            catch (Exception ex)
            {
                lstPlan = null;
                objUtil.gsLogAplicativo("DAPlanes.cs", "daDevolverPlan", ex.Message);
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

        public String daGrabarPlan(Planes objPlan, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[7];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidPlan", SqlDbType.Int);
                pa[0].Value = objPlan.idPlan;
                pa[1] = new SqlParameter("@pecNomPlan", SqlDbType.NVarChar, 50);
                pa[1].Value = objPlan.cPlan;
                pa[2] = new SqlParameter("@peidPerioricidad", SqlDbType.Int);
                pa[2].Value = objPlan.idPerioricidad;
                pa[3] = new SqlParameter("@peFechaRegistro", SqlDbType.DateTime);
                pa[3].Value = objPlan.dFechaRegistro;
                pa[4] = new SqlParameter("@peIdUsuario", SqlDbType.Int);
                pa[4].Value = objPlan.idUsuario;
                pa[5] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[5].Value = objPlan.bEstado;
                pa[6] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[6].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarPlan", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPlanes.cs", "daGrabarPlan", ex.Message);
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

        public List<Planes> daBuscarPlan(String pcBuscar, Int16 piTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtPlanes = new DataTable();
            clsConexion objCnx = null;
            List<Planes> lstPlanes = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 20);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = piTipoCon;


                objCnx = new clsConexion("");
                dtPlanes = objCnx.EjecutarProcedimientoDT("uspBuscarPlan", pa);

                lstPlanes = new List<Planes>();
                foreach (DataRow drMenu in dtPlanes.Rows)
                {
                    lstPlanes.Add(new Planes(Convert.ToInt32(drMenu["idPlan"]),
                        Convert.ToString(drMenu["nombrePlan"]),
                         Convert.ToString(drMenu["nombrePerio"]),
                    Convert.ToBoolean(drMenu["estadoPlan"])));

                }

                return lstPlanes;

            }
            catch (Exception ex)
            {
                lstPlanes = null;
                objUtil.gsLogAplicativo("DAPlanes.cs", "daBuscarPlan", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstPlanes = null;
            }
        }

        public List<Planes> daListarPlan(Int32 idAccesorio)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtPlan = new DataTable();
            clsConexion objCnx = null;
            List<Planes> lstplan = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidPlan", SqlDbType.Int);
                pa[0].Value = idAccesorio;

                objCnx = new clsConexion("");
                dtPlan = objCnx.EjecutarProcedimientoDT("uspListarPlan", pa);

                lstplan = new List<Planes>();
                foreach (DataRow drMenu in dtPlan.Rows)
                {
                    lstplan.Add(new Planes(Convert.ToInt32(drMenu["idPlan"]),
                                                Convert.ToString(drMenu["nombrePlan"]),
                                                Convert.ToInt32(drMenu["idPerioricidad"]),                                  
                                                Convert.ToBoolean(drMenu["estadoPlan"]))); 
                }

                return lstplan;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPlanes.cs", "daListarPlan", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstplan = null;
            }

        }

        public List<Planes> daListarPlanes(Boolean pbEstado)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtPlan = new DataTable();
            clsConexion objCnx = null;
            List<Planes> lstPlan = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[0].Value = pbEstado;
                objCnx = new clsConexion("");
                dtPlan = objCnx.EjecutarProcedimientoDT("uspListarPlanes", pa);

                lstPlan = new List<Planes>();
                foreach (DataRow drMenu in dtPlan.Rows)
                {
                    lstPlan.Add(new Planes(Convert.ToInt32(drMenu["idPlan"]),
                        Convert.ToString(drMenu["cPlan"])));
                } 

                return lstPlan;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPlanes.cs", "daListarPlanes", ex.Message);
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
    }
}
