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
    public class DAPerioricidad
    {
        clsUtil objUtil;
        public String daGrabarPerioricidad(Perioricidad objPerio, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[6];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peIdPerioricidad", SqlDbType.Int);
                pa[0].Value = objPerio.idPerio;
                pa[1] = new SqlParameter("@peNombrePerioricidad", SqlDbType.NVarChar, 15);
                pa[1].Value = objPerio.nombrePerio;
                pa[2] = new SqlParameter("@pebEstado", SqlDbType.Bit, 1);
                pa[2].Value = objPerio.bEstado;
                pa[3] = new SqlParameter("@peFechaRegistro", SqlDbType.DateTime);
                pa[3].Value = objPerio.dFechaRegistro;
                pa[4] = new SqlParameter("@peIdUsuario", SqlDbType.Int);
                pa[4].Value = objPerio.idUsuario;
                pa[5] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[5].Value = pnTipoCon;
                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarPerioricidad", pa);

                return "OK";
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPerioricidad.cs", "daGrabarPerioricidad", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
                objPerio = null;
            }
        }
        public Int16 daBuscarNombrePerio(String pcBuscar, Int16 pnTipoCon)
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
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarNombrePerioricidad", pa);

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
                objUtil.gsLogAplicativo("DAPerio.cs", "daBuscarPerio", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;

            }

        }
        public List<Perioricidad> daBuscarPerio(String pcBuscar, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtPerio = new DataTable();
            clsConexion objCnx = null;
            List<Perioricidad> lstPerio = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;
                objCnx = new clsConexion("");
                dtPerio = objCnx.EjecutarProcedimientoDT("uspBuscarPerioricidad", pa);

                lstPerio = new List<Perioricidad>();
                foreach (DataRow drMenu in dtPerio.Rows)
                {
                    lstPerio.Add(new Perioricidad(
                        Convert.ToInt32(drMenu["idPerioricidad"]),
                        Convert.ToString(drMenu["cNombre"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }
                return lstPerio;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPerio.cs", "daBuscarPerioricidad", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstPerio = null;
            }
        }
        public List<Perioricidad> daListarPerioricidad(Int32 idPerio)
        {

            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Perioricidad> lstPerio = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidPerioricidad", SqlDbType.Int);
                pa[0].Value = idPerio;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarPerioricidad", pa);

                lstPerio = new List<Perioricidad>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPerio.Add(new Perioricidad(
                        Convert.ToInt32(drMenu["idPerioricidad"]),
                        Convert.ToString(drMenu["cNombre"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }
                return lstPerio;
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
                lstPerio = null;
            }
        }

        public List<Perioricidad> daDevolverPerioricidad(Int32 idPerio)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Perioricidad> lstPerio = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidPerioricidad", SqlDbType.Int);
                pa[0].Value = idPerio;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarPerioricidad", pa);

                lstPerio = new List<Perioricidad>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPerio.Add(new Perioricidad(Convert.ToInt32(drMenu["idPerioricidad"]),
                        Convert.ToString(drMenu["cNombre"]),
                           Convert.ToBoolean(drMenu["bEstado"])));
                }
                return lstPerio;

            }
            catch (Exception ex)
            {
                lstPerio = null;
                objUtil.gsLogAplicativo("DAPerio.cs", "daDevolverPerio", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstPerio = null;
            }

        }
    }
}
