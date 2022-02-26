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
    public class DASucursal
    {
        private clsUtil objUtil = null;

        public DataTable DAListarSucursal()
        {
            DataTable dtSucursal = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                lsSql = "uspMantenimientoSucursal 0,'',1,'',1,'',1,1";
                objCnx = new clsConexion("");
                dtSucursal = objCnx.CargaDataTable(lsSql);
                return dtSucursal;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DASucursal.cs", "DAListarSucursal", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public Sucursal DAListarSucursalxID(int pIdSucursal=0)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peIdSucursal", SqlDbType.Int);
                pa[0].Value = pIdSucursal;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspGetSucursalxID", pa);

                Sucursal objSucursal = new Sucursal();
                foreach (DataRow drSucursal in dtUsuario.Rows)
                {
                    objSucursal = new Sucursal
                    {
                        Nombre = Convert.ToString(drSucursal["cNombreSucursal"]),
                        Direccion = Convert.ToString(drSucursal["cDireccion"]),
                        Ubigeo = Convert.ToString(drSucursal["Ubigeo"])
                    };
                }

                return objSucursal;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAInventario.cs", "daDevolverInventarioxProducto", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public String DARegistrarSucursal(Int32 peiCodigoSucursal, String pecNombreSucursal, Int32 peiCodigoDistrito,String pecDireccion ,Int32 pebEstado, String pecFecha, Int32 peiIdUsuario, Int32 peiTipo)
        {
            DataTable dtSucursal = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsResultado;
            String lsSql = "";
            try
            {
                lsSql = "uspMantenimientoSucursal " + Convert.ToString(peiCodigoSucursal) + ",'" + pecNombreSucursal + "'," + Convert.ToString(peiCodigoDistrito) + ",'" + pecDireccion + "'," + Convert.ToString(pebEstado) + ",'" + pecFecha + "'," + Convert.ToString(peiIdUsuario) + ",2";
                objCnx = new clsConexion("");
                dtSucursal = objCnx.CargaDataTable(lsSql);
                lsResultado = Convert.ToString(dtSucursal.Rows[0]["cResul"]);

                return lsResultado;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DASucursal.cs", "DARegistrarSucursal", ex.Message);
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
