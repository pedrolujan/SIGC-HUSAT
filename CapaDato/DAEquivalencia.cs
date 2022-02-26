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
    public class DAEquivalencia
    {
        private clsUtil objUtil = null;

        public DataTable DAListarEquivalencia()
        {
            DataTable dtUM = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                lsSql = "uspMantenimientoEquivalencia 0,1,2,1,2.88,1,'20141215',1,1";
                objCnx = new clsConexion("");
                dtUM = objCnx.CargaDataTable(lsSql);
                return dtUM;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAEquivalencia.cs", "DAListarEquivalencia", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public String DARegistrarEquivalencia(Int32 peiCodigoEquiv, Int32 peiCodigoUMOrigen, Int32 peiCodigoUMDestino,Decimal pemValorUMOrigen,Decimal pemValorUMDestino ,Int32 pebEstado, String pecFecha, Int32 peiIdUsuario, Int32 peiTipo)
        {
            DataTable dtcategoria = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsResultado;
            String lsSql = "";
            try
            {
                lsSql = "uspMantenimientoEquivalencia " + Convert.ToString(peiCodigoEquiv) + "," + Convert.ToString(peiCodigoUMOrigen) + "," + Convert.ToString(peiCodigoUMDestino) + "," + Convert.ToString(pemValorUMOrigen) + "," + Convert.ToString(pemValorUMDestino) + "," + Convert.ToString(pebEstado) + ",'" + pecFecha + "'," + Convert.ToString(peiIdUsuario) + ",2";
                objCnx = new clsConexion("");
                dtcategoria = objCnx.CargaDataTable(lsSql);
                lsResultado = Convert.ToString(dtcategoria.Rows[0]["cResul"]);

                return lsResultado;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAEquivalencia.cs", "DARegistrarEquivalencia", ex.Message);
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
