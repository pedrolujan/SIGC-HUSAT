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
    public class DAPrecio
    {
        private clsUtil objUtil = null;
        public List<Precio> daDevolverPrecioxProducto(int pidProducto)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peIdProducto", SqlDbType.Int);
                pa[0].Value = pidProducto;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarPreciosxProductoxUM", pa);

                List<Precio> lstPrecio = new List<Precio>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPrecio.Add(new Precio
                    {
                        idPrecio = Convert.ToInt32(drMenu["idPrecio"]),
                        intIdUnidaMedida = Convert.ToInt32(drMenu["idUnidadMedida"]),
                        idProducto = Convert.ToInt32(drMenu["idProducto"]),
                        strDescripcion = Convert.ToString(drMenu["cNombreProducto"]),
                        precio = Convert.ToDecimal(drMenu["Precio"]),
                        PrecioActual = Convert.ToDecimal(drMenu["PrecioActual"]),
                    });
                }

                return lstPrecio;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPrecio.cs", "daDevolverPrecioxProducto", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }

        public bool daGuardarPrecio(List<Precio> lstprecio)
        {
            SqlParameter[] pa = new SqlParameter[1];
            int intRowsAffected = 0;
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            string xmlData = clsUtil.Serialize(lstprecio);
            try
            {

                pa[0] = new SqlParameter("@xmlData", SqlDbType.Xml);
                pa[0].Value = xmlData;

                objCnx = new clsConexion("");
                intRowsAffected = objCnx.EjecutarProcedimiento("uspGuardarPrecio", pa);

                return true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPrecio.cs", "daGuardarPrecio", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }

        public decimal daDevolverPrecioxProductoXUM(int pidProducto, int pidUnidadMedida)
        {


            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtPrecio = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            decimal price = 0;

            try
            {
                pa[0] = new SqlParameter("@peidProducto", SqlDbType.Int);
                pa[0].Value = pidProducto;
                pa[1] = new SqlParameter("@peidUnidadMedida", SqlDbType.Int);
                pa[1].Value = pidUnidadMedida;


                objCnx = new clsConexion("");
                dtPrecio = objCnx.EjecutarProcedimientoDT("uspGetPricexProductoxUM", pa);


                if(dtPrecio != null)
                {
                    if(dtPrecio.Rows.Count == 1)
                        price = Convert.ToDecimal(dtPrecio.Rows[0]["precio"]);
                }
                else
                {
                    price = 0;
                }
             

                return price;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPrecio.cs", "daDevolverPrecioxProductoXUM", ex.Message);
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
