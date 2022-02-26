using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using CapaUtil;


namespace CapaNegocio
{
    public class DAUsuario
    {
        public DAUsuario() { }

        private clsUtil objUtil = null;

        public List<Usuario> daDevolverUsuario(Int32 idUsuario)
        {

            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peiidUsuario", SqlDbType.Int);
                pa[0].Value = idUsuario;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarUsuario", pa);
 
                List<Usuario> lstUsuario = new List<Usuario>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstUsuario.Add(new Usuario(Convert.ToInt32(drMenu["idUsuario"]), Convert.ToString(drMenu["cUser"]),
                           Convert.ToString(drMenu["cClave"]), Convert.ToBoolean(drMenu["bEstado"]),
                           Convert.ToString(drMenu["cPersonal"])));
                }

                return lstUsuario;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAUsuario.cs", "daDevolverUsuario", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
                
        }

        public String daGrabarUsuario(Usuario objUsuario, Int16 pnTipoCon )
        {
            SqlParameter[] pa = new SqlParameter[9];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecUsuario", SqlDbType.VarChar,20);
                pa[0].Value = objUsuario.cUser;
                pa[1] = new SqlParameter("@pecClave", SqlDbType.VarChar, 50);
                pa[1].Value = objUsuario.cClave;
                pa[2] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[2].Value = objUsuario.bEstado;
                pa[3] = new SqlParameter("@peidPersonal", SqlDbType.Int);
                pa[3].Value = objUsuario.idPersonal;
                pa[4] = new SqlParameter("@pedFechaReg", SqlDbType.DateTime);
                pa[4].Value = objUsuario.dFechaReg;
                pa[5] = new SqlParameter("@pedFechaActua", SqlDbType.DateTime);
                pa[5].Value = objUsuario.dFechaActua;
                pa[6] = new SqlParameter("@peidUserReg", SqlDbType.Int);
                pa[6].Value = objUsuario.idUserReg;
                pa[7] = new SqlParameter("@peiIdUsuario", SqlDbType.Int);
                pa[7].Value = objUsuario.idUsuario;
                pa[8] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[8].Value = pnTipoCon;


                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspRegistrarUsuario",pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAUsuario.cs", "daDevolverUsuario", ex.Message);
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

        public DataTable DAListarAplicacion(bool pbestado)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtAplicacion = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[0].Value = pbestado;


                objCnx = new clsConexion("");
                dtAplicacion = objCnx.EjecutarProcedimientoDT("uspListarAplicacion", pa);
                objCnx.CierraConexion();
             
                return dtAplicacion;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAUsuario.cs", "DAListarAplicacion", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtAplicacion = null;
            } 
        }

        public List<Usuario> DAListarCargooUsuario(bool pbestado, Int16 piTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtCargo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[0].Value = pbestado;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = piTipoCon;
                
                objCnx = new clsConexion("");
                dtCargo = objCnx.EjecutarProcedimientoDT("uspListarCargooUsuario", pa);
                objCnx.CierraConexion();
                List<Usuario> lstUsuario = new List<Usuario>();
                foreach (DataRow drMenu in dtCargo.Rows)
                {

                    lstUsuario.Add(new Usuario(Convert.ToString(drMenu["idUsuario"]), Convert.ToString(drMenu["cUser"])));
                }

                return lstUsuario;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAUsuario.cs", "DAListarCargooUsuario", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtCargo = null;
            }
        }

        public List<Usuario> daDevolverSoloUsuario(Int32 tipoCon,Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<Usuario> lstUsuario = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peTipoCon", SqlDbType.Real);
                pa[0].Value = tipoCon;


                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarSoloUsuarios", pa);

                lstUsuario = new List<Usuario>();

                lstUsuario.Add(new Usuario(
                    Convert.ToInt32(0),
                    Convert.ToString(buscar ? "TODOS" : "Selecc. Usuario")
                  ));

                foreach (DataRow drMenu in dtVehiculo.Rows)
                {
                    lstUsuario.Add(new Usuario(
                        Convert.ToInt32(drMenu["idUsuario"]),
                        Convert.ToString(drMenu["cUser"])
                        ));
                }

                return lstUsuario;

            }
            catch (Exception ex)
            {
                lstUsuario = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverClaseV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstUsuario = null;
            }

        }

    }
}
