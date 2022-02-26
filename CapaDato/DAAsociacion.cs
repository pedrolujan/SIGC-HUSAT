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
    public class DAAsociacion
    {
        clsUtil objUtil;
        public String daGrabarAsociacion(Asociacion objOprador, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[7];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peIdOperador", SqlDbType.Int);
                pa[0].Value = objOprador.idAsociacion;
                pa[1] = new SqlParameter("@pebEstado", SqlDbType.Bit, 1);
                pa[1].Value = objOprador.bEstado;
                pa[2] = new SqlParameter("@peFechaRegistro", SqlDbType.DateTime);
                pa[2].Value = objOprador.dFechaRegistro;
                pa[3] = new SqlParameter("@peIdUsuario", SqlDbType.Int);
                pa[3].Value = objOprador.idUsuario;
                pa[4] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[4].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarOperador", pa);

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
                objOprador = null;
            }
        }
        public List<Asociacion> daBuscarAsociacion(String pcBuscar, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            List<Asociacion> lstOperador = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspBuscarOperador", pa);

                lstOperador = new List<Asociacion>();
                //foreach (DataRow drMenu in dtOperador.Rows)
                //{
                //    lstOperador.Add(new Asociacion(
                //        Convert.ToInt32(drMenu["idOperador"]),
                //        Convert.ToString(drMenu["cSimCard"]),
                //        Convert.ToString(drMenu["cNombre"]),
                //        Convert.ToBoolean(drMenu["bEstado"])));
                //}
                return lstOperador;
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
                lstOperador = null;
            }
        }
        public List<Asociacion> daListarAsociacion(Int32 idAsociacion)
        {

            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Asociacion> lstOperador = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidOperador", SqlDbType.Int);
                pa[0].Value = idAsociacion;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarOperador", pa);

                lstOperador = new List<Asociacion>();
                //foreach (DataRow drMenu in dtUsuario.Rows)
                //{
                //    lstOperador.Add(new Asociacion(
                //        Convert.ToInt32(drMenu["idOperador"]),
                //        Convert.ToString(drMenu["cSimCard"]),
                //        Convert.ToString(drMenu["cNombre"]),
                //        Convert.ToBoolean(drMenu["bEstado"])));
                //}

                return lstOperador;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daListarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstOperador = null;
            }
        }
    }
}
