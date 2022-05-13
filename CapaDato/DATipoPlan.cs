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
    public class DATipoPlan
    {
        clsUtil objUtil;
        public String daGrabarTipoPlan(TipoPlan objTipoPlan, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[8];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peIdTipoPlan", SqlDbType.Int);
                pa[0].Value = objTipoPlan.idTipoPlan; 
                pa[1] = new SqlParameter("@peNombreTipoPlan", SqlDbType.NVarChar, 45);
                pa[1].Value = objTipoPlan.nombreTipoPlan;
                pa[2] = new SqlParameter("@peMeses", SqlDbType.Int);
                pa[2].Value = objTipoPlan.cMeses;
                pa[3] = new SqlParameter("@peDescripcion", SqlDbType.NVarChar,200);
                pa[3].Value = objTipoPlan.cDescripcion;
                pa[4] = new SqlParameter("@peIdUsuario", SqlDbType.Int);
                pa[4].Value = objTipoPlan.idUsuario;
                pa[5] = new SqlParameter("@peFechaRegistro", SqlDbType.DateTime);
                pa[5].Value = objTipoPlan.dFechaRegistro;
                pa[6] = new SqlParameter("@pebEstado", SqlDbType.Bit, 1);
                pa[6].Value = objTipoPlan.bEstado;
                pa[7] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[7].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarTipoPlan", pa);

                return "OK";

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
                objTipoPlan = null;
            }
        }

        public DataTable daBuscarTipoPlanDataTable(String pcBuscar, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<TipoPlan> lstTipoPlan = null;
            objUtil = new clsUtil();



            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;
                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarTipoPlan", pa);

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
                lstTipoPlan = null;
            }



        }

        public TipoPlan daListarTipoPlanDatatable(Int32 idCliente)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            TipoPlan lstTipoPlan = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peidTipoPlan", SqlDbType.Int);
                pa[0].Value = idCliente;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarTipoPlan", pa);

                lstTipoPlan = new TipoPlan();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstTipoPlan.idTipoPlan = Convert.ToInt32(drMenu["idTipoPlan"]);
                    lstTipoPlan.nombreTipoPlan = Convert.ToString(drMenu["cNombre"]);
                    lstTipoPlan.cMeses = Convert.ToInt32(drMenu["cMeses"]);
                    lstTipoPlan.cDescripcion = Convert.ToString(drMenu["cDescripcion"]);
                    lstTipoPlan.bEstado = Convert.ToBoolean(drMenu["bEstado"]);
                }

                return lstTipoPlan;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daListarEquipo", ex.Message);
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

        public Int16 daBuscarNombreTipoPlan(String pcBuscar, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarNombreTipoPlan", pa);

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
        public List<TipoPlan> daBuscarTipoPlan(String pcBuscar, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtTipoPlan = new DataTable();
            clsConexion objCnx = null;
            List<TipoPlan> lstTipoPlan = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtTipoPlan = objCnx.EjecutarProcedimientoDT("uspBuscarTipoPlan", pa);

                lstTipoPlan = new List<TipoPlan>();
                foreach (DataRow drMenu in dtTipoPlan.Rows)
                {
                    lstTipoPlan.Add(new TipoPlan(
                        Convert.ToInt32(drMenu["idTipoPlan"]),
                        Convert.ToString(drMenu["cNombre"]),
                        Convert.ToInt32(drMenu["cMeses"]),
                        Convert.ToString(drMenu["cDescripcion"]),
                        Convert.ToBoolean(drMenu["bEstado"]),
                        Convert.ToBoolean(drMenu["cConCiclo"])
                        ));
                }
                return lstTipoPlan;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DATipoPlan.cs", "daTipoPlan", ex.Message);
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
        public List<TipoPlan> daListarTipoPlan(Int32 idTipoPlan)
        {

            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<TipoPlan> lstTipoPlan = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidTipoPlan", SqlDbType.Int);
                pa[0].Value = idTipoPlan;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarTipoPlan", pa);

                lstTipoPlan = new List<TipoPlan>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstTipoPlan.Add(new TipoPlan(
                        Convert.ToInt32(drMenu["idTipoPlan"]),
                        Convert.ToString(drMenu["cNombre"]), 
                        Convert.ToInt32(drMenu["cMeses"]),
                        Convert.ToString(drMenu["cDescripcion"]),
                        Convert.ToBoolean(drMenu["bEstado"]),
                        Convert.ToBoolean(drMenu["cConCiclo"])
                        ));
                }

                return lstTipoPlan;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DATipoPlan.cs", "daListarTipoPlan", ex.Message);
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

        public List<TipoPlan> daDevolverTipoPlan(Int32 idTipoPlan, Int32 tipBusqueda)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtTipoPlan = new DataTable();
            clsConexion objCnx = null;
            List<TipoPlan> lstTipoPlan = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidTipoPlan", SqlDbType.Int);
                pa[0].Value = idTipoPlan;


                objCnx = new clsConexion("");
                dtTipoPlan = objCnx.EjecutarProcedimientoDT("uspListarTipoPlan", pa);

                lstTipoPlan = new List<TipoPlan>();
                lstTipoPlan.Add(new TipoPlan(
                       Convert.ToInt32("0"),
                       Convert.ToString( tipBusqueda == 1 ? "Selecc. T. Plan" : "TODOS" ),
                       Convert.ToInt32("0"),
                       Convert.ToString(""),
                       Convert.ToBoolean(1),
                       Convert.ToBoolean(1)
                       ));
                foreach (DataRow drMenu in dtTipoPlan.Rows)
                {
                    lstTipoPlan.Add(new TipoPlan(
                        Convert.ToInt32(drMenu["idTipoPlan"]),
                        Convert.ToString(drMenu["cNombre"]),
                        Convert.ToInt32(drMenu["cMeses"]),
                        Convert.ToString(drMenu["cDescripcion"]),
                        Convert.ToBoolean(drMenu["bEstado"]),
                        Convert.ToBoolean(drMenu["cConCiclo"])
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
    }
}
