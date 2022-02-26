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
    public class DAUnidadMedida
    {
        private clsUtil objUtil = null;

        public DataTable DAListarUnidadMedida()
        {
            DataTable dtUM = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                lsSql = "uspMantenimientoUnidadMedida 0,'','',1,'',1,1";
                objCnx = new clsConexion("");
                dtUM = objCnx.CargaDataTable(lsSql);
                return dtUM;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAUnidadMedida.cs", "DAListarUnidadMedida", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public String DARegistrarUnidadMedida(Int32 peiCodigoUM, String pecNombreUM, String pecAbrevUM, Int32 pebEstado, String pecFecha, Int32 peiIdUsuario, Int32 peiTipo)
        {
            DataTable dtcategoria = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsResultado;
            String lsSql = "";
            try
            {
                lsSql = "uspMantenimientoUnidadMedida " + Convert.ToString(peiCodigoUM) + ",'" + pecNombreUM + "','" + pecAbrevUM + "'," + Convert.ToString(pebEstado) + ",'" + pecFecha + "'," + Convert.ToString(peiIdUsuario) + "," + peiTipo + " ";
                objCnx = new clsConexion("");
                dtcategoria = objCnx.CargaDataTable(lsSql);
                lsResultado = Convert.ToString(dtcategoria.Rows[0]["cResul"]);

                return lsResultado;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAUnidadMedida.cs", "DARegistrarUnidadMedida", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public DataTable DAListarUnidadMedidaCombo()
        {
            DataTable dtUM = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                lsSql = "uspMantenimientoUnidadMedida 0,'','',1,'',1,3";
                objCnx = new clsConexion("");
                dtUM = objCnx.CargaDataTable(lsSql);
                return dtUM;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAUnidadMedida.cs", "DAListarUnidadMedidaCombo", ex.Message);
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
