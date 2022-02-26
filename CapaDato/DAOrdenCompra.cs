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
    public class DAOrdenCompra
    {
        public DAOrdenCompra() { }

        private clsUtil objUtil = null;

        public List<OrdenCompra> daBuscarOrdenCompra(String pcBuscar, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            List<OrdenCompra> lstVenta = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;


                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspBuscarOrdenCompra", pa);

                lstVenta = new List<OrdenCompra>();

                foreach (DataRow drMenu in dtVenta.Rows)
                {
                    lstVenta.Add(new OrdenCompra(Convert.ToInt32(drMenu["idOrden"]), Convert.ToString(drMenu["cDocumento"])
                    , Convert.ToString(drMenu["cNomProveedor"]), Convert.ToString(drMenu["cDocCompra"]), Convert.ToDateTime(drMenu["dFechaCompra"])));
                }

                return lstVenta;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAOrdenCompra.cs", "daBuscarOrdenCompra", ex.Message);
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

        public List<OrdenCompra> daListarOrdenCompra(Int32 pidOrden)
        {

            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtCompra = new DataTable();
            clsConexion objCnx = null;
            List<OrdenCompra> lstOrden = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidOrden", SqlDbType.Int);
                pa[0].Value = pidOrden;

                objCnx = new clsConexion("");
                dtCompra = objCnx.EjecutarProcedimientoDT("uspListarOrden", pa);

                lstOrden = new List<OrdenCompra>();
                foreach (DataRow drMenu in dtCompra.Rows)
                {
                    lstOrden.Add(new OrdenCompra(Convert.ToInt32(drMenu["idOrden"]), Convert.ToString(drMenu["cTipoPago"]),
                         Convert.ToString(drMenu["cDocumento"]), Convert.ToString(drMenu["cNomProveedor"]),
                         Convert.ToString(drMenu["cDocCompra"]), Convert.ToDateTime(drMenu["dFechaCompra"]),
                         Convert.ToString(drMenu["iEstado"]), Convert.ToString(drMenu["cDireccion"])));
                }

                return lstOrden;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAOrdenCompra.cs", "daListarOrdenCompra", ex.Message);
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

        public List<DetalleCompra> daListarDetalleCompra(Int32 pidOrden)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            List<DetalleCompra> lstVenta = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidOrden", SqlDbType.Int);
                pa[0].Value = pidOrden;


                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspListarDetalleCompra", pa);

                lstVenta = new List<DetalleCompra>();
                foreach (DataRow drMenu in dtVenta.Rows)
                {
                    lstVenta.Add(new DetalleCompra(Convert.ToInt32(drMenu["idDetalleCompra"]), Convert.ToInt32(drMenu["idOrden"]),
                        Convert.ToInt32(drMenu["idProducto"]), Convert.ToString(drMenu["cProducto"]),
                        Convert.ToInt32(drMenu["Cantidad"]), Convert.ToDecimal(drMenu["PrecioCompra"]),
                         Convert.ToInt32(drMenu["idUnidadMedida"]), Convert.ToString(drMenu["cNombreUM"]), Convert.ToDecimal(drMenu["Importe"])));
                }

                return lstVenta;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daListarDetalleVenta", ex.Message);
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

        public String daGrabarOrden(List<TablaOrdenIngreso> lstOrdenIngreso, Operador clsOperador, String tipoordencompra, OrdenCompra objDocVenta, DataTable dtDetalleCompra, Int16 pnTipoCon, out Int32 pidOrden, out string pcLote)
        {
            SqlParameter[] pa = new SqlParameter[21];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            string xmlData = clsUtil.Serialize(lstOrdenIngreso);
            int lidOrden = 0;

            try
            {
                pa[0] = new SqlParameter("@peidOrdenIngreso", SqlDbType.Int);
                pa[0].Value = objDocVenta.idOrden;
                pa[1] = new SqlParameter("@peNroCompra", SqlDbType.NVarChar, 45);
                pa[1].Value = objDocVenta.cDocCompra;
                pa[2] = new SqlParameter("@peEstado", SqlDbType.NVarChar, 45);
                pa[2].Value = objDocVenta.iEstado;
                pa[3] = new SqlParameter("@peFechaCompra", SqlDbType.DateTime);
                pa[3].Value = objDocVenta.dFechaCompra;
                pa[4] = new SqlParameter("@peidProveedor", SqlDbType.Int);
                pa[4].Value = objDocVenta.idProveedor;
                pa[5] = new SqlParameter("@peidSucursal", SqlDbType.Int);
                pa[5].Value = objDocVenta.idSucursal;
                pa[6] = new SqlParameter("@peCodTipoPago", SqlDbType.NVarChar, 8);
                pa[6].Value = objDocVenta.cTipoPago;
                pa[7] = new SqlParameter("@xmlData", SqlDbType.Xml);
                pa[7].Value = xmlData;
                pa[8] = new SqlParameter("@peSubTotal", SqlDbType.Decimal);
                pa[8].Value = objDocVenta.subTotal;
                pa[9] = new SqlParameter("@peIGV", SqlDbType.Decimal);
                pa[9].Value = objDocVenta.IGV;
                pa[10] = new SqlParameter("@peTotal", SqlDbType.Decimal);
                pa[10].Value = objDocVenta.nMontoPagar;
                pa[11] = new SqlParameter("@peFechaRegistro", SqlDbType.DateTime);
                pa[11].Value = objDocVenta.dFechaRegistro;
                pa[12] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[12].Value = objDocVenta.idUsuario;
                pa[13] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[13].Value = pnTipoCon;
                pa[14] = new SqlParameter("@peObservacion", SqlDbType.NVarChar, 200);
                pa[14].Value = objDocVenta.observaciones;
                pa[15] = new SqlParameter("@peidMoneda", SqlDbType.Int);
                pa[15].Value = objDocVenta.idMoneda;
                pa[16] = new SqlParameter("@peEstadoIGV", SqlDbType.Bit);
                pa[16].Value = objDocVenta.chekIGV;
                pa[17] = new SqlParameter("@peCostoEnvio", SqlDbType.Money);
                pa[17].Value = objDocVenta.costoEnvio;
                pa[18] = new SqlParameter("@peOtrosCargos", SqlDbType.Money);
                pa[18].Value = objDocVenta.otrosCostos;
                pa[19] = new SqlParameter("@tipoOrdenCompra", SqlDbType.VarChar,20);
                pa[19].Value = tipoordencompra;
                pa[20] = new SqlParameter("@operador", SqlDbType.Int);
                pa[20].Value = clsOperador.idOperador;



                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarDocCompraEquipo", pa);
                pidOrden = 0;
                pcLote = null;
                //lidOrden = Convert.ToInt32(pa[15].Value);
                //pidOrden = lidOrden;
                //pcLote = DAImprimirLote(lidOrden);


                return "OK";

            }
            catch (Exception ex)
            {
                //pidOrden = 0;
                //pcLote = "";
                objUtil.gsLogAplicativo("DAOrdenCompra.cs", "daGrabarOrden", ex.Message);
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

        public DataTable DAListarOrdenxProveedor(Int32 pidProveedor, Int16 peidEstado)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtCompra = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidProveedor", SqlDbType.Int);
                pa[0].Value = pidProveedor;
                pa[1] = new SqlParameter("@peidEstado", SqlDbType.TinyInt);
                pa[1].Value = peidEstado;

                objCnx = new clsConexion("");
                dtCompra = objCnx.EjecutarProcedimientoDT("uspObtenerOC", pa);


                return dtCompra;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAOrdenCompra.cs", "DAListarOrdenxProveedor", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtCompra = null;
            }

        }

        public String daPagarDeuda(OrdenCompra objDocVenta, decimal pnSaldo)
        {
            SqlParameter[] pa = new SqlParameter[7];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidOrden", SqlDbType.Int);
                pa[0].Value = objDocVenta.idOrden;
                pa[1] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[1].Value = objDocVenta.idSucursal;
                pa[2] = new SqlParameter("@penMontoPagar", SqlDbType.Decimal);
                pa[2].Value = objDocVenta.nMontoPagar;
                pa[3] = new SqlParameter("@penSaldo", SqlDbType.Decimal);
                pa[3].Value = pnSaldo;
                pa[4] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[4].Value = objDocVenta.idUsuario;
                pa[5] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[5].Value = objDocVenta.dFechaRegistro;
                pa[6] = new SqlParameter("@peidProveedor", SqlDbType.Int);
                pa[6].Value = objDocVenta.idProveedor;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspPagarDeuda", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAOrdenCompra.cs", "daPagarDeuda", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;

            }

        }

        public DataTable DAListarPagoDeudaOC(Int32 pidDocumento)
        {

            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtCompra = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidDocumento", SqlDbType.Int);
                pa[0].Value = pidDocumento;

                objCnx = new clsConexion("");
                dtCompra = objCnx.EjecutarProcedimientoDT("uspPagosDeudas", pa);


                return dtCompra;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAOrdenCompra.cs", "DAListarPagoDeudaOC", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtCompra = null;
            }

        }

        public String daAnularPagoDeuda(int pidTrandiaria, int pidOrden, int pidUsuario, string pcFechaSis)
        {
            SqlParameter[] pa = new SqlParameter[4];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidTrandiaria", SqlDbType.Int);
                pa[0].Value = pidTrandiaria;
                pa[1] = new SqlParameter("@peidDocumento", SqlDbType.Int);
                pa[1].Value = pidOrden;
                pa[2] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[2].Value = pidUsuario;
                pa[3] = new SqlParameter("@pecFechaSis", SqlDbType.VarChar, 30);
                pa[3].Value = pcFechaSis;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspAnularPagoDeuda", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAOrdenCompra.cs", "daAnularPagoDeuda", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;

            }

        }

        public DataTable DAListarLote(Int32 pidLote, Int16 piEstado, bool pbestado, bool pbEstadoRecepcion, Int16 pidSucursal, Int16 piTipoSucursal, Int16 pidAlmacen)
        {

            SqlParameter[] pa = new SqlParameter[7];
            DataTable dtCompra = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidLote", SqlDbType.Int);
                pa[0].Value = pidLote;
                pa[1] = new SqlParameter("@peiEstado", SqlDbType.TinyInt);
                pa[1].Value = piEstado;
                pa[2] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[2].Value = pbestado;
                pa[3] = new SqlParameter("@pebEstadoRecepcion", SqlDbType.Bit);
                pa[3].Value = pbEstadoRecepcion;
                pa[4] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[4].Value = pidSucursal;
                pa[5] = new SqlParameter("@peiTipoSucursal", SqlDbType.TinyInt);
                pa[5].Value = piTipoSucursal;
                pa[6] = new SqlParameter("@peidAlmacen", SqlDbType.SmallInt);
                pa[6].Value = pidAlmacen;

                objCnx = new clsConexion("");
                dtCompra = objCnx.EjecutarProcedimientoDT("uspListarLote", pa);

                return dtCompra;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAOrdenCompra.cs", "DAListarLote", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtCompra = null;
            }

        }

        public DataTable DAListarLotexMesa(String pcCodMesa)
        {

            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtCompra = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecMesa", SqlDbType.VarChar, 8);
                pa[0].Value = pcCodMesa;

                objCnx = new clsConexion("");
                dtCompra = objCnx.EjecutarProcedimientoDT("uspListarMesaConfigurada", pa);

                return dtCompra;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAOrdenCompra.cs", "DAListarLotexMesa", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtCompra = null;
            }

        }

        public List<DetalleCompra> daBuscarLote(String pcBuscar, Int16 pidSucursal, Int16 pnTipoCon, Int16 piTipoSucursal, Int16 pidAlmacen)
        {

            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            List<DetalleCompra> lstVenta = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[1].Value = pidSucursal;
                pa[2] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[2].Value = pnTipoCon;
                pa[3] = new SqlParameter("@peiTipoSucursal", SqlDbType.TinyInt);
                pa[3].Value = piTipoSucursal;
                pa[4] = new SqlParameter("@peidAlmacen", SqlDbType.SmallInt);
                pa[4].Value = pidAlmacen;




                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspBuscarLote", pa);

                lstVenta = new List<DetalleCompra>();

                foreach (DataRow drMenu in dtVenta.Rows)
                {
                    lstVenta.Add(new DetalleCompra(Convert.ToInt32(drMenu["idDetalleCompra"]), Convert.ToInt32(drMenu["idProducto"])
                        , Convert.ToString(drMenu["cNombreProducto"]), Convert.ToString(drMenu["cNomProveedor"]),
                        Convert.ToDecimal(drMenu["nCanridad"]), Convert.ToDecimal(drMenu["PrecioCompra"]),
                        Convert.ToDateTime(drMenu["dFechaCompra"]),
                    Convert.ToString(drMenu["cStock"]), Convert.ToInt32(drMenu["idUnidadMedida"])));
                }

                return lstVenta;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAOrdenCompra.cs", "daBuscarLote", ex.Message);
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

        public String DAImprimirLote(Int32 pidOrden)
        {

            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtCompra = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            string lcLote = "";

            try
            {

                pa[0] = new SqlParameter("@peidOrden", SqlDbType.Int);
                pa[0].Value = pidOrden;

                objCnx = new clsConexion("");
                dtCompra = objCnx.EjecutarProcedimientoDT("uspImprimirLote", pa);

                if (dtCompra.Rows.Count > 0)
                {
                    lcLote = dtCompra.Rows[0]["Lote"].ToString().Trim();
                }

                return lcLote;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAOrdenCompra.cs", "DAListarLotexMesa", ex.Message);
                return "XX";
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtCompra = null;
                lcLote = "";
            }

        }

        public DataTable daBuscarOrdenDataTable(String pcBuscar, String pnTipoIngreso, String estPago, DateTime fechaInicial, DateTime fechaFinal, Int32 numPagina, Int32 tipoCon, Int32 idProveedor, Boolean habilitarFechas, String tipocompra)
        {
            SqlParameter[] pa = new SqlParameter[10];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();



            try
            {
                pa[0] = new SqlParameter("@docCompra", SqlDbType.NVarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@tipoIngreso", SqlDbType.NVarChar, 50);
                pa[1].Value = pnTipoIngreso;
                pa[2] = new SqlParameter("@estPago", SqlDbType.NVarChar, 50);
                pa[2].Value = estPago;
                pa[3] = new SqlParameter("@fechaInicio", SqlDbType.DateTime);
                pa[3].Value = fechaInicial;
                pa[4] = new SqlParameter("@fechaFinal", SqlDbType.DateTime);
                pa[4].Value = fechaFinal;
                pa[5] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[5].Value = numPagina;
                pa[6] = new SqlParameter("@tipoCon", SqlDbType.Real);
                pa[6].Value = tipoCon;
                pa[7] = new SqlParameter("@idProveedor", SqlDbType.Int);
                pa[7].Value = idProveedor;
                pa[8] = new SqlParameter("@habilitarFechas", SqlDbType.TinyInt, 1);
                pa[8].Value = habilitarFechas;
                pa[9] = new SqlParameter("@TipoCompra", SqlDbType.NVarChar, 20);
                pa[9].Value = tipocompra;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarOrdenIngresoEquipoPaginacion", pa);

                return dtEquipo;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }



        }

        public DataTable daBuscarDetalleDataTable( String pcBuscar, String pnTipoIngreso, DateTime fechaInicial, DateTime fechaFinal, Int32 numPagina, Int32 tipoCon, String estIngresoImies, Boolean habilitarFechas, String cboEstadoIngreso, String CodTipoIngreso)
        {
            SqlParameter[] pa = new SqlParameter[10];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@docCompra", SqlDbType.NVarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@tipoIngreso", SqlDbType.NVarChar, 50);
                pa[1].Value = pnTipoIngreso;
                pa[2] = new SqlParameter("@fechaInicio", SqlDbType.DateTime);
                pa[2].Value = fechaInicial;
                pa[3] = new SqlParameter("@fechaFinal", SqlDbType.DateTime);
                pa[3].Value = fechaFinal;
                pa[4] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[4].Value = numPagina;
                pa[5] = new SqlParameter("@tipoCon", SqlDbType.Real);
                pa[5].Value = tipoCon;
                pa[6] = new SqlParameter("@estIngImies", SqlDbType.NVarChar, 1);
                pa[6].Value = estIngresoImies;
                pa[7] = new SqlParameter("@habilitarFechas", SqlDbType.TinyInt);
                pa[7].Value = habilitarFechas;
                pa[8] = new SqlParameter("@estadoIngreso", SqlDbType.NVarChar, 8);
                pa[8].Value = cboEstadoIngreso;
                pa[9] = new SqlParameter("@CodTipoIngreso", SqlDbType.NVarChar, 8);
                pa[9].Value = CodTipoIngreso;

                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarDetalleIngresoEquipoPaginacion", pa);

                return dtEquipo;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }



        }
        /// ////////////////////////////////
        public Int16 daBuscarDocumentoOrden(String pcBuscar, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;

                pa[1] = new SqlParameter("@tipocon", SqlDbType.Int);
                pa[1].Value = pnTipoCon;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarDocumentoOrdenIngresoEquipo", pa);

                Int16 numFilas;

                if (dtUsuario.Rows.Count > 0)
                {
                    numFilas = 1;
                }
                else
                {
                    numFilas = 0;
                }

                return numFilas;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;

            }

        }

        public OrdenCompra daListarOrdenDatatable(Int32 codPlan)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            OrdenCompra lstOrden = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peCodPlan", SqlDbType.Int);
                pa[0].Value = codPlan;
                //pa[1] = new SqlParameter("@tipocompra", SqlDbType.NVarChar, 20);
                //pa[1].Value = tipocompra;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarOrdenIngresoEquipo", pa);

                lstOrden = new OrdenCompra();
               
                    foreach (DataRow drMenu in dtUsuario.Rows)
                    {
                        lstOrden.idOrden = Convert.ToInt32(drMenu["idOrden"]);
                        lstOrden.cTipoPago = Convert.ToString(drMenu["cTipoPago"]);
                        lstOrden.dFechaRegistro = Convert.ToDateTime(drMenu["dFechaReg"]);
                        lstOrden.cDocumento = Convert.ToString(drMenu["cDocCompra"]);
                        lstOrden.iEstado = Convert.ToString(drMenu["bEstado"]);
                        lstOrden.dFechaCompra = Convert.ToDateTime(drMenu["dFechaCompra"]);
                        lstOrden.idProveedor = Convert.ToInt32(drMenu["idProveedor"]);
                        lstOrden.detalleCompra = Convert.ToString(drMenu["DetalleCompra"]);
                        lstOrden.observaciones = Convert.ToString(drMenu["cObservacion"]);
                        lstOrden.idMoneda = Convert.ToInt32(drMenu["idMoneda"]);
                        lstOrden.chekIGV = Convert.ToBoolean(drMenu["bEstadoIGV"]);
                        lstOrden.costoEnvio = Convert.ToDouble(drMenu["costoEnvio"]);
                        lstOrden.otrosCostos = Convert.ToDouble(drMenu["otrosCargos"]);
                    }

                
                return lstOrden;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPlan.cs", "daListarPlan", ex.Message);
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



        public ordencompraSimCard daListarOrdenSimCard(Int32 codplan)
        {
            
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            ordencompraSimCard lstsimcard = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peCodPlan", SqlDbType.Int);
                pa[0].Value = codplan;
            

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("usplistarordeningresoSimCard", pa);
                lstsimcard = new ordencompraSimCard();
            
                foreach (DataRow drmenu in dtUsuario.Rows)
                {
                    lstsimcard.idordenSimCard = Convert.ToInt32(drmenu["idRecibo"]);
                    lstsimcard.numeroingreso = Convert.ToString(drmenu["numeroRecibo"]);
                    lstsimcard.proveedor = Convert.ToString(drmenu["cNomProveedor"]);
                    lstsimcard.tipoingreso = Convert.ToString(drmenu["tipoorden"]);
                    lstsimcard.moneda = Convert.ToString(drmenu["tipomoneda"]);
                    lstsimcard.tipocompra = Convert.ToString(drmenu["tipocompra"]);
                    lstsimcard.fechacompra = Convert.ToDateTime(drmenu["FechaCompra"]);
                    lstsimcard.fechaingreso = Convert.ToDateTime(drmenu["dFechaRegistro"]);
                    lstsimcard.idoperador = Convert.ToInt32(drmenu["idOperador"]);
                    lstsimcard.operador = Convert.ToString(drmenu["operador"]);
                    lstsimcard.cantidad = Convert.ToInt32(drmenu["Stock"]);
                    lstsimcard.precioUnitario = Convert.ToDecimal(drmenu["PrecioCompra"]);
                    lstsimcard.envio = Convert.ToDecimal(drmenu["Envio"]);
                    lstsimcard.otroscargos = Convert.ToDecimal(drmenu["OtrosCargos"]);



                }




                return lstsimcard;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPlan.cs", "daListarPlan", ex.Message);
                throw new Exception(ex.Message);

            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                    objCnx = null;
                    lstsimcard = null;
            }
        }


        

        public DataTable daBuscarHistorialDataTable(String pcBuscar,String ordencompra)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();



            try
            {
                pa[0] = new SqlParameter("@docCompra", SqlDbType.NVarChar, 45);
                pa[0].Value = pcBuscar;

                pa[1] = new SqlParameter("@ordencompra", SqlDbType.NVarChar, 20);
                pa[1].Value = ordencompra;



                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarHistorialOIEquipo", pa);

                return dtEquipo;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }



        }

        public DataTable daBuscarImiesDataTable(Int32 idDetalle, Int32 numPagina, Int32 tipo, String tipoIngreso)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idDetalleIngreso", SqlDbType.Int);
                pa[0].Value = idDetalle;
                pa[1] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[1].Value = numPagina;
                pa[2] = new SqlParameter("@tipoCon", SqlDbType.Real);
                pa[2].Value = tipo;
                pa[3] = new SqlParameter("@tipoIngreso", SqlDbType.NVarChar,8);
                pa[3].Value = tipoIngreso;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarImeisDeOrdenIngreso", pa);

                return dtEquipo;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public List<Cargo> daDevolverTablaCod(Int32 tipoLlamada)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@penTipoLlamada", SqlDbType.NVarChar, 8);
                pa[0].Value = tipoLlamada;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarEstadoTablaCod", pa);

                List<Cargo> lstCargo = new List<Cargo>();
                lstCargo.Add(new Cargo(
                        Convert.ToString("0"),
                        Convert.ToString("Seleccione opcion"),
                        Convert.ToString("1")));

                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstCargo.Add(new Cargo(
                        Convert.ToString(drMenu["cCodTab"]),
                        Convert.ToString(drMenu["cNomTab"]),
                        Convert.ToString(drMenu["cValor"])));
                }

                return lstCargo;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACargo.cs", "daDevolverTablaCod", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public List<TipoOrdenCompra> daDevolverTipoCompra(Int32 idTabcod)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtCompra = new DataTable();
            clsConexion objCnx = null;
            List<TipoOrdenCompra> lstOrdenCompra = null;
            Boolean estado = false;
            objUtil = new clsUtil();

            //List<Cargo> lstCargo = new List<Cargo>();
            //lstCargo.Add(new Cargo(
            //        Convert.ToString("0"),
            //        Convert.ToString("Seleccione opcion"),
            //        Convert.ToString("1")));

            //foreach (DataRow drMenu in dtUsuario.Rows)
            //{
            //    lstCargo.Add(new Cargo(
            //        Convert.ToString(drMenu["cCodTab"]),
            //        Convert.ToString(drMenu["cNomTab"]),
            //        Convert.ToString(drMenu["cValor"])));
            //}


            try
            {
                pa[0] = new SqlParameter("@lnIdTabcod", SqlDbType.Int);
                pa[0].Value = idTabcod;

                objCnx = new clsConexion("");

                dtCompra = objCnx.EjecutarProcedimientoDT("uspTipoOrdenCompra", pa);

                lstOrdenCompra = new List<TipoOrdenCompra>();

                String Itemcero = (estado == true) ? "Seleccione Orden Compra" : "Seleccione Orden Compra";


                lstOrdenCompra.Add(new TipoOrdenCompra(
                    Convert.ToInt32(0),
                    Convert.ToString(Itemcero)));

                foreach (DataRow drMenu in dtCompra.Rows)
                {
                    lstOrdenCompra.Add(new TipoOrdenCompra(
                        Convert.ToInt32(drMenu["cCodTab"]),
                        Convert.ToString(drMenu["cNomTab"])));

                }



                return lstOrdenCompra;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACargo.cs", "daDevolverTablaCod", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }


        }
        public DataTable daMostrarOperadores(Int32 idProveedor,String tipingreso)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peIdProveedor", SqlDbType.Int);
                pa[0].Value = idProveedor;

                pa[1] = new SqlParameter("@tipoingreso", SqlDbType.NVarChar,20);
                pa[1].Value = tipingreso;

                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspDevolverOperador", pa);
                            
                return dtOperador;
            }
             
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACargo.cs", "daDevolverTablaCod", ex.Message);
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
