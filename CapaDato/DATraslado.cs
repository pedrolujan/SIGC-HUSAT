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
    public class DATraslado
    {

        public DATraslado() { }

        clsUtil objUtil = null;

        public String daGrabarTraslado(Traslado objDocVenta, DataTable dtDetalleTraslado,out int pidTraslado)
        {
            SqlParameter[] pa = new SqlParameter[9];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidTraslado", SqlDbType.Int);
                pa[0].Value = objDocVenta.idTraslado;
                pa[1] = new SqlParameter("@peidAlmacenOrigen", SqlDbType.SmallInt);
                pa[1].Value = objDocVenta.idAlmacenOrigen;
                pa[2] = new SqlParameter("@peidAlmacenDestino", SqlDbType.SmallInt);
                pa[2].Value = objDocVenta.idAlmacenDestino;
                pa[3] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[3].Value = objDocVenta.idSucursal;
                pa[4] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[4].Value = objDocVenta.bEstado;
                pa[5] = new SqlParameter("@peidUsuarioRegistro", SqlDbType.Int);
                pa[5].Value = objDocVenta.idUsuarioRegistro;
                pa[6] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[6].Value = objDocVenta.dFechaRegistro;
                pa[7] = new SqlParameter("@tbDetalleTraslado", SqlDbType.Structured);
                pa[7].Value = dtDetalleTraslado;
                pa[8] = new SqlParameter("@psidTraslado", SqlDbType.Int);
                pa[8].Direction = ParameterDirection.Output;
                
                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarTraslado", pa);
                objCnx.CierraConexion();
                pidTraslado = Convert.ToInt32(pa[8].Value);

                return "OK";

            }
            catch (Exception ex)
            {
                pidTraslado = 0;
                objUtil.gsLogAplicativo("DATraslado.cs", "daGrabarTraslado", ex.Message);
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

        public List<Traslado> daBuscarTraslado(String pcBuscar, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            List<Traslado> lstVenta = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;


                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspListarTraslados", pa);

                lstVenta = new List<Traslado>();

                foreach (DataRow drMenu in dtVenta.Rows)
                {
                    lstVenta.Add(new Traslado(Convert.ToInt32(drMenu["idTraslado"]), Convert.ToString(drMenu["cAlmacenOrigen"])
                    , Convert.ToString(drMenu["cAlmacenDestino"]), Convert.ToDateTime(drMenu["dFechaRegistro"]), Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstVenta;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAtraslado.cs", "daBuscarTraslado", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstVenta = null;
            }

        }

        public List<Almacen> daListarAlmacen(bool pbEstado , int idSucursal = 0)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            List<Almacen> lstVenta = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[0].Value = pbEstado;
                pa[1] = new SqlParameter("@peintIdSucursal", SqlDbType.Int);
                pa[1].Value = idSucursal;

                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspListarAlmacen", pa);
                objCnx.CierraConexion();

                lstVenta = new List<Almacen>();

                foreach (DataRow drMenu in dtVenta.Rows)
                {
                    lstVenta.Add(new Almacen(Convert.ToInt32(drMenu["idAlmacen"]), Convert.ToString(drMenu["cNomAlmacen"])));
                }

                return lstVenta;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAtraslado.cs", "daListarAlmacen", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstVenta = null;
            }

        }

        public List<DetalleTraslado> daListarDetalleTraslado(int pidTraslado, bool pbEstado)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            List<DetalleTraslado> lstVenta = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pidTraslado", SqlDbType.Int);
                pa[0].Value = pidTraslado;
                pa[1] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[1].Value = pbEstado;

                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspListarDetalleTraslado", pa);
                objCnx.CierraConexion();

                lstVenta = new List<DetalleTraslado>();

                foreach (DataRow drMenu in dtVenta.Rows)
                {
                    lstVenta.Add(new DetalleTraslado(Convert.ToInt32(drMenu["idDetalleTraslado"]), Convert.ToInt32(drMenu["idLote"]),
                        Convert.ToString(drMenu["cNombreProducto"]), Convert.ToInt32(drMenu["nCantidad"]), Convert.ToString(drMenu["cNombreUM"])));
                }

                return lstVenta;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAtraslado.cs", "daListarDetalleTraslado", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstVenta = null;
            }

        }

    }
}
