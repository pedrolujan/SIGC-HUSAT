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
    public class DAProducto
    {
        private clsUtil objUtil = null;

        public DataTable DAListarProducto()
        {
            DataTable dtProducto = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {


                lsSql = "uspMantenimientoProducto 0,'','',1,1,1,1,1,'',1,0,1";
                objCnx = new clsConexion("");
                dtProducto = objCnx.CargaDataTable(lsSql);
                return dtProducto;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAProducto.cs", "DAListarProducto", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
     
        public List<Producto> DAGetDevolverProducto(Int32 idProducto, Int16 lnTipoCon,Int16 pidSucursal,Int16 lnTipo)
        {
            DataTable dtProducto = new DataTable();
            clsConexion objCnx = null;
            List<Producto> lstProducto = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                lsSql = "uspMantenimientoProducto " + idProducto + ",'','',1,1,1,1,1,'',1,"+pidSucursal+"," + lnTipoCon;
                objCnx = new clsConexion("");
                dtProducto = objCnx.CargaDataTable(lsSql);



                lstProducto = new List<Producto>();

                if (lnTipo == 0)
                {

                    foreach (DataRow drMenu in dtProducto.Rows)
                    {
                        lstProducto.Add(new Producto(Convert.ToInt32(drMenu["idProducto"]), Convert.ToString(drMenu["cProducto"])));
                    }
                }
                else
                {
                    foreach (DataRow drMenu in dtProducto.Rows)
                    {
                        lstProducto.Add(new Producto(Convert.ToInt32(drMenu["idProducto"]), Convert.ToString(drMenu["cProducto"]),
                         Convert.ToDecimal(drMenu["Stock"]), Convert.ToDecimal(drMenu["mPrecioCompra"]),
                         Convert.ToDecimal(drMenu["mPrecioVenta"]), Convert.ToDecimal(drMenu["mDescuento"]),
                          Convert.ToInt32(drMenu["idUnidadMedida"]), Convert.ToString(drMenu["cNombreUM"])
                          , Convert.ToInt32(drMenu["idUnidadOrigen"]), Convert.ToInt32(drMenu["idLote"])));
                    }
                }

                return lstProducto;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAProducto.cs", "DAListarProducto", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstProducto = null;
                dtProducto = null;
            }

        }

        public String DARegistrarProducto(Int32 peiCodigoProducto, String pecNombreProducto , String   pecDescripcionProducto , Int32   peiCodigoCategoria , Int32   peiCodigoUnidadMedida , Int32 peiCodigoMarcaProducto,Decimal pnStockMin, Int32   pebEstado , String   pedFechaRegistro , Int32   peiIdUsuario )
        {
           
            DataTable dtProducto = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsResultado;
            String lsSql = "";
            try
            {
                lsSql = "uspMantenimientoProducto " + Convert.ToString(peiCodigoProducto) + ",'" + pecNombreProducto + "','" + pecDescripcionProducto + "'," + Convert.ToString(peiCodigoCategoria) + "," + Convert.ToString(peiCodigoUnidadMedida) + "," + Convert.ToString(peiCodigoMarcaProducto) + ","  + Convert.ToString(pnStockMin) + "," + Convert.ToString(pebEstado) + ",'" + pedFechaRegistro + "'," + Convert.ToString(peiIdUsuario) + ",0,2";
                objCnx = new clsConexion("");
                dtProducto = objCnx.CargaDataTable(lsSql);
                lsResultado = Convert.ToString(dtProducto.Rows[0]["cResul"]);

                return lsResultado;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAProducto.cs", "DARegistrarProducto", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public DataTable DAListarLineaXProducto(Int32 peiCodigoCategoria)
        {
            DataTable dtProducto = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                lsSql = "uspMantenimientoProducto 0,'',''," + Convert.ToString(peiCodigoCategoria) + ",1,1,1,0,0,0,0,0,0,1,1,'',1,0,3";
                objCnx = new clsConexion("");
                dtProducto = objCnx.CargaDataTable(lsSql);
                return dtProducto;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAProducto.cs", "DAListarLineaXProducto", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public DataTable DAListarUnidadMedidaProducto()
        {
            DataTable dtProducto = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                lsSql = "uspMantenimientoProducto 0,'','',1,1,1,1,1,'20141214',1,0,4";
                objCnx = new clsConexion("");
                dtProducto = objCnx.CargaDataTable(lsSql);
                return dtProducto;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAProducto.cs", "DAListarUnidadMedidaProducto", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
       
        public DataTable DAListarProductoOrdeCompra()
        {
            DataTable dtProducto = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                lsSql = "uspMantenimientoProducto 0,'','',1,1,1,1,1,'',1,0,5";
                objCnx = new clsConexion("");
                dtProducto = objCnx.CargaDataTable(lsSql);
                return dtProducto;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAProducto.cs", "DAListarProductoOrdeCompra", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public DataTable DAListarProductoUnidadMedida(Int32 peiCodigoUM)
        {
            DataTable dtProducto = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String lsSql = "";
            try
            {

                //uspMantenimientoProducto 3,'','',1,1,1,1,0,0,0,0,0,0,1,'',1,6
                lsSql = "uspMantenimientoProducto " + Convert.ToString(peiCodigoUM) + ",'','',1,1,1,1,1,'',1,0,6";
                objCnx = new clsConexion("");
                dtProducto = objCnx.CargaDataTable(lsSql);
                return dtProducto;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAProducto.cs", "DAListarProductoUnidadMedida", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public List<UnidadMedida> DADevolverUMxProducto(Int32 idProducto)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            clsUtil objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peiidProducto", SqlDbType.Int);
                pa[0].Value = idProducto;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspObtenerUnidadMedida", pa);

                List<UnidadMedida> lstUnidad = new List<UnidadMedida>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {

                    lstUnidad.Add(new UnidadMedida(Convert.ToInt32(drMenu["idUnidadMedida"]), Convert.ToString(drMenu["cNomUM"])));
                }

                return lstUnidad;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAProducto.cs", "DADevolverUMxProducto", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }

          public List<UnidadMedida> DADevolverValorUMB(Int32 pidProducto, decimal pnStock)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            clsUtil objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peiidProducto", SqlDbType.Int);
                pa[0].Value = pidProducto;
                pa[1] = new SqlParameter("@penStock", SqlDbType.Decimal);
                pa[1].Value = pnStock;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspObtenerValorUM", pa);

                List<UnidadMedida> lstUnidad = new List<UnidadMedida>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {

                    lstUnidad.Add(new UnidadMedida(Convert.ToInt32(drMenu["idUnidadMedida"]), Convert.ToString(drMenu["cStock"])));
                }

                return lstUnidad;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAProducto.cs", "DADevolverValorUMB", ex.Message);
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
