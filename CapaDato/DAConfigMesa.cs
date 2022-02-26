using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaUtil;
using System.Data.SqlClient;
using System.Data;
using CapaConexion;

namespace CapaDato
{
    public class DAConfigMesa
    {

        public DAConfigMesa() { }

        private clsUtil objUtil = null;

        public List<ConfigMesa> daListarMesaConfigurada(string pcCodMesa, Int16 pidSucursal)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtCompra = new DataTable();
            clsConexion objCnx = null;
            List<ConfigMesa> lstOrden = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecMesa", SqlDbType.VarChar,8);
                pa[0].Value = pcCodMesa;
                pa[1] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[1].Value = pidSucursal;

                objCnx = new clsConexion("");
                dtCompra = objCnx.EjecutarProcedimientoDT("uspListarMesaConfigurada", pa);

                lstOrden = new List<ConfigMesa>();
                foreach (DataRow drMenu in dtCompra.Rows)
                {
                    lstOrden.Add(new ConfigMesa(Convert.ToInt32(drMenu["idConfigMesa"]), Convert.ToInt32(drMenu["idLote"]), Convert.ToString(drMenu["cNomProveedor"]),
                        Convert.ToString(drMenu["cNombreProducto"]),
                         Convert.ToDecimal(drMenu["Compra"]), Convert.ToDecimal(drMenu["Stock"]),
                         Convert.ToDecimal(drMenu["mPrecioCompra"]), Convert.ToDecimal(drMenu["mPrecioPublico"]), Convert.ToDecimal(drMenu["mPrecioEspecial"])
                         , Convert.ToDecimal(drMenu["mPrecioxMayor"]), Convert.ToBoolean(drMenu["bEstado"])));
                }
                return lstOrden;               

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAConfigMesa.cs", "daListarMesaConfigurada", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstOrden = null;
            }

        }

        public String daGrabarConfigMesa(ConfigMesa objDocVenta)
        {
            SqlParameter[] pa = new SqlParameter[11];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidConfigMesa", SqlDbType.Int);
                pa[0].Value = objDocVenta.idConfigMesa;
                pa[1] = new SqlParameter("@pecCodTab", SqlDbType.VarChar,8);
                pa[1].Value = objDocVenta.cCodTab;
                pa[2] = new SqlParameter("@peidLote", SqlDbType.Int);
                pa[2].Value = objDocVenta.idLote;
                pa[3] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[3].Value = objDocVenta.idSucursal;
                pa[4] = new SqlParameter("@pemPrecioPublico", SqlDbType.Money);
                pa[4].Value = objDocVenta.mPrecioPublico;
                pa[5] = new SqlParameter("@pemPrecioCompra", SqlDbType.Money);
                pa[5].Value = objDocVenta.mPrecioCompra;
                pa[6] = new SqlParameter("@pemPrecioEspecial", SqlDbType.Money);
                pa[6].Value = objDocVenta.mPrecioEspecial;
                pa[7] = new SqlParameter("@pemPrecioxMayor", SqlDbType.Money);
                pa[7].Value = objDocVenta.mPrecioxMayor;
                pa[8] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[8].Value = objDocVenta.bEstado;
                pa[9] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[9].Value = objDocVenta.idUsuario;
                pa[10] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[10].Value = objDocVenta.dFechaRegiastro;
              
                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarConfigMesa", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAConfigMesa.cs", "daGrabarConfigMesa", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
                objDocVenta = null;

            }

        }

        public List<ConfigMesa> daListarMesa(bool pbestado, Int16 pidSucursal)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtCompra = new DataTable();
            clsConexion objCnx = null;
            List<ConfigMesa> lstOrden = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[0].Value = pbestado;
                pa[1] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[1].Value = pidSucursal;

                objCnx = new clsConexion("");
                dtCompra = objCnx.EjecutarProcedimientoDT("uspListarMesa", pa);

                lstOrden = new List<ConfigMesa>();
                foreach (DataRow drMenu in dtCompra.Rows)
                {
                    lstOrden.Add(new ConfigMesa(Convert.ToInt32(drMenu.IsNull("idConfigMesa") == true ? 0 : drMenu["idConfigMesa"]), Convert.ToString(drMenu["cCodTab"]), Convert.ToInt32(drMenu.IsNull("idLote") == true ? 0 : drMenu["idLote"]), Convert.ToString(drMenu["cNomTab"])
                        , Convert.ToString(drMenu.IsNull("cNomProveedor") == true ? "" : drMenu["cNomProveedor"]),
                        Convert.ToString(drMenu.IsNull("cNombreProducto") == true ? "" : drMenu["cNombreProducto"])));
                }

                return lstOrden;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAConfigMesa.cs", "daListarMesa", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstOrden = null;
            }

        }

    }
}
