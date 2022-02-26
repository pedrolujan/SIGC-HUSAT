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
    public class DAAlmacen
    {
        private clsUtil objUtil = null;

        public DataTable DAListarAlmacen()
        {
            DataTable dtAlmacen= new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                lsSql = "uspMantenimientoAlmacen 0,'',1,1,'',1,1";
                objCnx = new clsConexion("");
                dtAlmacen = objCnx.CargaDataTable(lsSql);
                return dtAlmacen;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAlmacen.cs", "DAListarAlmacen", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public String DARegistrarAlmacen(Int32 peiCodigoAlmacen, String pecNombreAlmacen, Int32 peiCodigoSucursal, Int32 pebEstado, String pecFecha, Int32 peiIdUsuario, Int32 peiTipo)
        {
            DataTable dtAlmacen = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsResultado;
            String lsSql = "";
            try
            {
                lsSql = "uspMantenimientoAlmacen " + Convert.ToString(peiCodigoAlmacen) + ",'" + pecNombreAlmacen + "'," + Convert.ToString(peiCodigoSucursal) + "," + Convert.ToString(pebEstado) + ",'" + pecFecha + "'," + Convert.ToString(peiIdUsuario) + ",2";
                objCnx = new clsConexion("");
                dtAlmacen = objCnx.CargaDataTable(lsSql);
                lsResultado = Convert.ToString(dtAlmacen.Rows[0]["cResul"]);

                return lsResultado;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAlmacen.cs", "DARegistrarAlmacen", ex.Message);
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
