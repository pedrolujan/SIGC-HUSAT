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
    public class DALineaProducto
    {
        private clsUtil objUtil = null;

        public DataTable DAListarLineaProducto()
        {
            DataTable dtLinea = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                lsSql = "uspMantenimientoLinea 0,'',1,1,1,'',1";
                objCnx = new clsConexion("");
                dtLinea = objCnx.CargaDataTable(lsSql);
                return dtLinea;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DALineaProducto.cs", "DAListarLineaProducto", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public DataTable DAListarLineaProductoCombo()
        {
            DataTable dtLinea = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                lsSql = "uspMantenimientoLinea 0,'',1,1,1,'',3";
                objCnx = new clsConexion("");
                dtLinea = objCnx.CargaDataTable(lsSql);
                return dtLinea;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DALineaProducto.cs", "DAListarLineaProductoCombo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public String DARegistrarLineaProducto(Int32 peiCodigoLinea, String pecNombreLinea,Int32 pebEstado, Int32 pecCodigoCategoria, String pecFecha, Int32 peiIdUsuario, Int32 peiTipo)
        {
            DataTable dtLineaProducto = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsResultado;
            String lsSql = "";
            try
            {
                lsSql = "uspMantenimientoLinea " + Convert.ToString(peiCodigoLinea) + ",'" + pecNombreLinea + "'," + Convert.ToString(pebEstado) + "," + Convert.ToString(pecCodigoCategoria) + "," + Convert.ToString(peiIdUsuario) + ",'" + pecFecha + "',2";
                objCnx = new clsConexion("");
                dtLineaProducto = objCnx.CargaDataTable(lsSql);
                lsResultado = Convert.ToString(dtLineaProducto.Rows[0]["cResul"]);
                return lsResultado;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DALineaProducto.cs", "DARegistrarLineaProducto", ex.Message);
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
