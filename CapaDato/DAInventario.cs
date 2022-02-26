using CapaConexion;
using CapaEntidad;
using CapaEntidad.Generic;
using CapaUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDato
{
    public class DAInventario
    {
        private clsUtil objUtil = null;
        public List<DetalleInventario> daDevolverInventarioxProducto(int pIdAlmacen, int pidProducto= 0)
        {


            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peIdAlmacen", SqlDbType.Int);
                pa[0].Value = pIdAlmacen;
                pa[1] = new SqlParameter("@peIdProducto", SqlDbType.Int);
                pa[1].Value = pidProducto;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspCargarInventario", pa);

                List<DetalleInventario> lstInventario = new List<DetalleInventario>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstInventario.Add(new DetalleInventario
                    {
                        idDetalleInventario = Convert.ToInt32(drMenu["idMovimiento"]),
                        idLote = Convert.ToInt32(drMenu["idLote"]),
                        idProducto = Convert.ToInt32(drMenu["idProducto"]),
                        cNombreProducto = Convert.ToString(drMenu["cNombreProducto"]),
                        Cantidad = Convert.ToInt32(drMenu["nCanridad"]),
                        Stock = Convert.ToInt32(drMenu["stock"]),
                        bEstado = Convert.ToBoolean(drMenu["bEstado"])
                    });
                }

                return lstInventario;

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

        public List<DetalleInventario> daDevolverInventarioxLote(int pIdAlmacen, int pidLote = 0)
        {


            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peIdAlmacen", SqlDbType.Int);
                pa[0].Value = pIdAlmacen;
                pa[1] = new SqlParameter("@peIdLote", SqlDbType.Int);
                pa[1].Value = pidLote;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspCargarInventarioxLote", pa);

                List<DetalleInventario> lstInventario = new List<DetalleInventario>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstInventario.Add(new DetalleInventario
                    {
                        idDetalleInventario = Convert.ToInt32(drMenu["idMovimiento"]),
                        idLote = Convert.ToInt32(drMenu["idLote"]),
                        idProducto = Convert.ToInt32(drMenu["idProducto"]),
                        cNombreProducto = Convert.ToString(drMenu["cNombreProducto"]),
                        Cantidad = Convert.ToInt32(drMenu["nCanridad"]),
                        Stock = Convert.ToInt32(drMenu["stock"]),
                        bEstado = Convert.ToBoolean(drMenu["bEstado"])
                    });
                }

                return lstInventario;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAInventario.cs", "daDevolverInventarioxLote", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public bool daGuardarInventario(GenericMasterDetail<Inventario,DetalleInventario> genericMasterDetail)
        {
            SqlParameter[] pa = new SqlParameter[1];
            int intRowsAffected = 0;
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            string xmlData = clsUtil.Serialize(genericMasterDetail);
            try
            {

                pa[0] = new SqlParameter("@xmlData", SqlDbType.Xml);
                pa[0].Value = xmlData;

                objCnx = new clsConexion("");
                intRowsAffected = objCnx.EjecutarProcedimiento("uspGuardarInventario", pa);

                return true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAInventario.cs", "daDevolverInventarioxLote", ex.Message);
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
