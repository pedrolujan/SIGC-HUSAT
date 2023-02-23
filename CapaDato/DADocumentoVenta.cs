using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaUtil;
using CapaConexion;
using System.Data.SqlClient;
using System.Data;

namespace CapaDato
{
    public class DADocumentoVenta
    {

        public DADocumentoVenta() { }

        private clsUtil objUtil = null;

        public List<DocumentoVenta> daBuscarDocVenta(String pcBuscar, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            List<DocumentoVenta> lstVenta = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;


                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspBuscarDocVenta", pa);

                lstVenta = new List<DocumentoVenta>();

                foreach (DataRow drMenu in dtVenta.Rows)
                {
                    lstVenta.Add(new DocumentoVenta(Convert.ToInt32(drMenu["idVenta"]), Convert.ToString(drMenu["cDocumento"])
                    , Convert.ToString(drMenu["cCliente"]), Convert.ToString(drMenu["cDocVenta"]), Convert.ToDateTime(drMenu["dFechaVenta"])));
                }

                return lstVenta;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daBuscarDocVenta", ex.Message);
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
        public DataTable daBuscarDocumentoPorEmitir(Boolean chkActivaFecha,String dtFechaIni, String dtFechaFin, String pcBuscar, Int32 numPagina,Int32 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[6];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            List<DocumentoVenta> lstVenta = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@chkHabFecha", SqlDbType.Bit);
                pa[0].Value = chkActivaFecha;
                pa[1] = new SqlParameter("@FechaInicial", SqlDbType.Date);
                pa[1].Value = dtFechaIni;
                pa[2] = new SqlParameter("@FechaFinal", SqlDbType.Date);
                pa[2].Value = dtFechaFin;
                pa[3] = new SqlParameter("@Buscar", SqlDbType.VarChar, 50);
                pa[3].Value = pcBuscar;
                pa[4] = new SqlParameter("@numPagina", SqlDbType.TinyInt);
                pa[4].Value = numPagina;
                pa[5] = new SqlParameter("@TipoCon", SqlDbType.TinyInt);
                pa[5].Value = pnTipoCon;


                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspBuscarDocumentosEmitidosEnSunat", pa);

                return dtVenta;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daBuscarDocVenta", ex.Message);
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

        public List<DocumentoVenta> daListarDocVenta(Int32 pidVenta)
        {

            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            List<DocumentoVenta> lstVenta = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidVenta", SqlDbType.Int);
                pa[0].Value = pidVenta;

                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspListarDocVenta", pa);

                lstVenta = new List<DocumentoVenta>();
                foreach (DataRow drMenu in dtVenta.Rows)
                {
                    //lstVenta.Add(new DocumentoVenta(Convert.ToInt32(drMenu["idVenta"]), Convert.ToString(drMenu["cTipoDoc"]),
                    //    Convert.ToString(drMenu["cTiDo"]),
                    //     Convert.ToString(drMenu["cDocumento"]), Convert.ToString(drMenu["cCliente"]),
                    //     Convert.ToString(drMenu["cDocVenta"]), Convert.ToDateTime(drMenu["dFechaVenta"]),
                    //     Convert.ToString(drMenu["cEstado"]), Convert.ToString(drMenu["cDireccion"]), Convert.ToString(drMenu["cNroGuiaRem"]),
                    //     Convert.ToString(drMenu["cNroGuiaTrans"]), Convert.ToString(drMenu["cTipoPago"]),
                    //     Convert.ToDecimal(drMenu["nNroIGV"]), Convert.ToDateTime(drMenu["dCancelado"]),
                    //     Convert.ToDouble(drMenu["nSubtotal"]), Convert.ToDouble(drMenu["nIGV"]), Convert.ToDouble(drMenu["nTotal"]), Convert.ToString(drMenu["cUsuario"])));
                }

                return lstVenta;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daListarDocVenta", ex.Message);
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

        public List<DetalleVenta> daListarDetalleVenta(Int32 pidVenta)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            DetalleVenta dv = new DetalleVenta();
            List<DetalleVenta> lstVenta = new List<DetalleVenta>();
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidVenta", SqlDbType.Int);
                pa[0].Value = pidVenta;

                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspListarDetalleVenta", pa);

                lstVenta = new List<DetalleVenta>();
                foreach (DataRow drMenu in dtVenta.Rows)
                {
                    dv.IdDetalleVenta = Convert.ToInt32(drMenu["idDetalleVenta"]);
                    dv.Descripcion = Convert.ToString(drMenu["cProducto"]);
                    dv.PrecioUni = Convert.ToDouble(drMenu["PrecioCompra"]);
                    //lstVenta.Add(new DetalleVenta(Convert.ToInt32(drMenu["idDetalleVenta"]), Convert.ToInt32(drMenu["idVenta"]),
                    //    Convert.ToInt32(drMenu["idProducto"]), Convert.ToString(drMenu["cProducto"]),
                    //    Convert.ToInt32(drMenu["Cantidad"]), Convert.ToDecimal(drMenu["PrecioCompra"]),
                    //    Convert.ToDecimal(drMenu["PrecioVenta"]), Convert.ToDecimal(drMenu["mDescuento"]),
                    //    Convert.ToInt32(drMenu["idUnidadMedida"]), Convert.ToInt32(drMenu["idUnidadOrigen"]),
                    //    Convert.ToString(drMenu["cNombreUM"]), Convert.ToDecimal(drMenu["Importe"]), Convert.ToInt32(drMenu["idLote"])));
                }
                lstVenta.Add(dv);
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

        public Decimal DADevolverUnidadDestino(Int32 pidUnidadMedida, Int32 pidUnidaDest)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            Decimal lnValorDest = 0;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidUnidadMedida", SqlDbType.Int);
                pa[0].Value = pidUnidadMedida;
                pa[1] = new SqlParameter("@peidUnidadDest", SqlDbType.Int);
                pa[1].Value = pidUnidaDest;

                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspDevolverValorDestino", pa);

                if (dtVenta.Rows.Count > 0)
                {
                    lnValorDest = Convert.ToDecimal(dtVenta.Rows[0]["mValorDestino"]);
                }
                else { lnValorDest = 0; }

                return lnValorDest;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "DADevolverUnidadDestino", ex.Message);
                return -99;
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public String daGrabarVenta(DocumentoVenta objDocVenta, DataTable dtDetalleVenta, out Int32 pidVenta, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[21];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidVenta", SqlDbType.Int);
                pa[0].Value = objDocVenta.idVenta;
                pa[1] = new SqlParameter("@pecTipoDoc", SqlDbType.NVarChar, 8);
                pa[1].Value = objDocVenta.cTipoDoc;
                pa[2] = new SqlParameter("@peidCliente", SqlDbType.Int);
                pa[2].Value = objDocVenta.idCliente;
                pa[3] = new SqlParameter("@pecDocVenta", SqlDbType.NVarChar, 20);
                pa[3].Value = objDocVenta.cDocVenta;
                pa[4] = new SqlParameter("@pedFechaVenta", SqlDbType.DateTime);
                pa[4].Value = objDocVenta.dFechaVenta;
                pa[5] = new SqlParameter("@pecEstado", SqlDbType.NVarChar, 8);
                pa[5].Value = objDocVenta.cEstado;
                pa[6] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[6].Value = objDocVenta.idUsuario;
                pa[7] = new SqlParameter("@pecNroGuiaTrans", SqlDbType.NVarChar, 15);
                pa[7].Value = objDocVenta.cNroGuiaTrans;
                pa[8] = new SqlParameter("@pecNroGuiaRem", SqlDbType.NVarChar, 15);
                pa[8].Value = objDocVenta.cNroGuiaRem;
                pa[9] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[9].Value = objDocVenta.dFechaRegistro;
                pa[10] = new SqlParameter("@pecTipoPago", SqlDbType.NVarChar, 8);
                pa[10].Value = objDocVenta.cTipoPago;
                pa[11] = new SqlParameter("@penNroIGV", SqlDbType.Decimal);
                pa[11].Value = objDocVenta.nNroIGV;
                pa[12] = new SqlParameter("@pedCancelado", SqlDbType.DateTime);
                pa[12].Value = objDocVenta.dCancelado;
                pa[13] = new SqlParameter("@pedFechaAct", SqlDbType.DateTime);
                pa[13].Value = objDocVenta.dFechaAct;
                pa[14] = new SqlParameter("@peidUsuAct", SqlDbType.Int);
                pa[14].Value = objDocVenta.idUsuAct;
                pa[15] = new SqlParameter("@tbDetalleVenta", SqlDbType.Structured);
                pa[15].Value = dtDetalleVenta;
                pa[16] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[16].Value = pnTipoCon;
                pa[17] = new SqlParameter("@peidSucursal", SqlDbType.Int);
                pa[17].Value = objDocVenta.idSucursal;
                pa[18] = new SqlParameter("@penMontoPagar", SqlDbType.Decimal);
                pa[18].Value = objDocVenta.nMontoPagar;
                pa[19] = new SqlParameter("@penMontoTotal", SqlDbType.Decimal);
                pa[19].Value = objDocVenta.nMontoTotal;
                pa[20] = new SqlParameter("@psidVenta", SqlDbType.Int);
                pa[20].Direction = ParameterDirection.Output;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarDocVenta", pa);
                pidVenta = Convert.ToInt32(pa[20].Value);

                return "OK";

            }
            catch (Exception ex)
            {
                pidVenta = 0;
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daGrabarVenta", ex.Message);
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
        public String daGuardarConfiguraCionDocumento(String codDoc,String serie,String numero)
        {
            SqlParameter[] pa = new SqlParameter[3];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@codDocumento", SqlDbType.VarChar,8);
                pa[0].Value = codDoc;
                pa[1] = new SqlParameter("@serie", SqlDbType.NVarChar, 5);
                pa[1].Value = serie;
                pa[2] = new SqlParameter("@numero", SqlDbType.Int);
                pa[2].Value = numero;
               

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarConfiguracionDocventa", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daGrabarVenta", ex.Message);
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

        public DataTable DAListarVentaxCliente(Int32 pidCliente, String pcEstado, String pcEstadoVM)
        {

            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtCompra = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidCliente", SqlDbType.Int);
                pa[0].Value = pidCliente;
                pa[1] = new SqlParameter("@pecEstado", SqlDbType.VarChar, 8);
                pa[1].Value = pcEstado;
                pa[2] = new SqlParameter("@pecEstadoVM", SqlDbType.VarChar, 8);
                pa[2].Value = pcEstadoVM;

                objCnx = new clsConexion("");
                dtCompra = objCnx.EjecutarProcedimientoDT("uspObtenerVenta", pa);


                return dtCompra;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "DAListarVentaxCliente", ex.Message);
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

        public String daPagarCobro(DocumentoVenta objDocVenta, decimal pnSaldo)
        {
            SqlParameter[] pa = new SqlParameter[8];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidVenta", SqlDbType.Int);
                pa[0].Value = objDocVenta.idVenta;
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
                pa[6] = new SqlParameter("@peidCliente", SqlDbType.Int);
                pa[6].Value = objDocVenta.idCliente;
                pa[7] = new SqlParameter("@peiTipoOpe", SqlDbType.Int);
                pa[7].Value = objDocVenta.iTipoOpe;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspPagarCobro", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daPagarCobro", ex.Message);
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

        public DataTable DAListarPagoCobroVenta(Int32 pidDocumento)
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
                dtCompra = objCnx.EjecutarProcedimientoDT("uspPagosCobros", pa);


                return dtCompra;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "DAListarPagoCobroVenta", ex.Message);
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

        public DataTable daAnularVenta(Boolean chk, String fechaInicial, String fechafinal, string cBuscar,Int32 numPagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[6];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            DataTable dtcodventa;
            try
            {
                pa[0] = new SqlParameter("@chkHabFecha", SqlDbType.Bit);
                pa[0].Value = chk;
                pa[1] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
                pa[1].Value = fechaInicial;
                pa[2] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
                pa[2].Value = fechafinal;
                pa[3] = new SqlParameter("@CodDocCorrelativo", SqlDbType.NVarChar, 20);
                pa[3].Value = cBuscar;
                pa[4] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[4].Value = numPagina;
                pa[5] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[5].Value = tipoCon;

                objCnx = new clsConexion("");
                dtcodventa = objCnx.EjecutarProcedimientoDT("uspBuscarDocVentasAnulacion", pa);


                return dtcodventa;
            }

            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daAnularVenta", ex.Message);
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
        public Boolean daAnularDocumentoVeta(String codDocVenta,Int32 idOperacion, List<xmlDocumentoVentaGeneral> xml, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[7];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String cCodVenta = "";
            DataTable dtresp = new DataTable();
            String xmlNotaCredito = clsUtil.Serialize(xml);


            try
            {
                pa[0] = new SqlParameter("@codDocVenta", SqlDbType.NVarChar, 20) { Value = codDocVenta };
                pa[1] = new SqlParameter("@idOperacion", SqlDbType.Int) { Value = idOperacion };
                pa[2] = new SqlParameter("@descripcion", SqlDbType.NVarChar, 500) { Value = xml[0].xmlDocumentoVenta[0].cVehiculos };
                pa[3] = new SqlParameter("@fechaRegistro", SqlDbType.DateTime) { Value = xml[0].xmlDocumentoVenta[0].dFechaVenta };
                pa[4] = new SqlParameter("@xmlDocumento", SqlDbType.Xml) { Value = xmlNotaCredito };
                pa[5] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = xml[0].xmlDocumentoVenta[0].idUsuario };
                pa[6] = new SqlParameter("@tipoCon", SqlDbType.Int) { Value =  tipoCon };

                objCnx = new clsConexion("");
                dtresp = objCnx.EjecutarProcedimientoDT("uspAnularDocumentoVenta", pa);
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daDevolverAccesorio", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }


        public String daAnularPagoCobro(int pidTrandiaria, int pidVenta, int pidUsuario, string pcFechaSis, int iTipoOpe)
        {
            SqlParameter[] pa = new SqlParameter[5];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidTrandiaria", SqlDbType.Int);
                pa[0].Value = pidTrandiaria;
                pa[1] = new SqlParameter("@peidDocumento", SqlDbType.Int);
                pa[1].Value = pidVenta;
                pa[2] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[2].Value = pidUsuario;
                pa[3] = new SqlParameter("@pecFechaSis", SqlDbType.VarChar, 30);
                pa[3].Value = pcFechaSis;
                pa[4] = new SqlParameter("@peiTipoOpe", SqlDbType.Int);
                pa[4].Value = iTipoOpe;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspAnularPagoCobros", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daAnularPagoCobro", ex.Message);
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

        public String daAperturarCaja(Int16 pidSucursal, decimal pnMontoApertura, int pidUsuario, string dFechaRegistro, int pidOperacion, List<ReporteBloque> lstCierreAnterior)
        {
            SqlParameter[] pa = new SqlParameter[6];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String xmlCierreAnterior = clsUtil.Serialize(lstCierreAnterior);

            try
            {
                pa[0] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[0].Value = pidSucursal;
                pa[1] = new SqlParameter("@penMontoPagar", SqlDbType.Money);
                pa[1].Value = pnMontoApertura;
                pa[2] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[2].Value = pidUsuario;
                pa[3] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[3].Value = dFechaRegistro;
                pa[4] = new SqlParameter("@peidOperacion", SqlDbType.Int);
                pa[4].Value = pidOperacion;
                pa[5] = new SqlParameter("@xmlCierreAnterior", SqlDbType.Xml);
                pa[5].Value = xmlCierreAnterior;
           
                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspAperturarCaja", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daAperturarCaja", ex.Message);
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

        public List<CuadreCaja> daVerificarApertura(String pcFechaSist, Int16 pidSucursal, Int32 idUsuario)
        {
            SqlParameter[] pa = new SqlParameter[4];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            Boolean bVerificar = false;
            DataTable dt = new DataTable();
            List<CuadreCaja> lstCuadreCaja= new List<CuadreCaja>();
            Trandiaria trn;
            Int32 rows = 0;

            try
            {
                pa[0] = new SqlParameter("@pedFechaSist", SqlDbType.Date);
                pa[0].Value = pcFechaSist;
                pa[1] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[1].Value = pidSucursal;
                pa[2] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[2].Value = idUsuario;
                pa[3] = new SqlParameter("@fechaActual", SqlDbType.DateTime);
                pa[3].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                objCnx = new clsConexion("");
                dt = objCnx.EjecutarProcedimientoDT("uspVerificarApertura", pa);

                foreach (DataRow item in dt.Rows)
                {
                    lstCuadreCaja.Add(new CuadreCaja
                    {
                        idTrandiaria = Convert.ToInt32(item["idTrandiaria"]),
                        Detalle=Convert.ToString(item["detalle"]),
                        idOperacion = Convert.ToInt32(item["idOperacion"]),
                        importeSaldo = Convert.ToDouble(item["TotalPago"]),
                        idMoneda = Convert.ToInt32(item["idMoneda"]),
                        SimbloMon = Convert.ToString(item["cSimbolo"])

                    }) ;

                }
                
                
                return lstCuadreCaja;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daVerificarApertura", ex.Message);
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
        public List<ReporteBloque> daBuscarImporteCierreAnterior(String pcFechaSist, Int16 pidSucursal, Int32 idUsuario, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[4];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            Boolean bVerificar = false;
            DataTable dt = new DataTable();
            List<ReporteBloque> lstImporteDeCierreAnt = new List<ReporteBloque>();
            try
            {
                pa[0] = new SqlParameter("@pedFechaSist", SqlDbType.DateTime);
                pa[0].Value = pcFechaSist;
                pa[1] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[1].Value = pidSucursal;
                pa[2] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[2].Value = idUsuario;
                pa[3] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[3].Value = tipoCon;
                objCnx = new clsConexion("");
                dt=objCnx.EjecutarProcedimientoDT("uspBuscarImporteCierreAnterior", pa);

                Int32 y = 0;
                foreach (DataRow item in dt.Rows)
                {
                    lstImporteDeCierreAnt.Add(new ReporteBloque
                    {
                        numero=y+1,
                        idAuxiliar=Convert.ToInt32(item["idTrandiaria"]),
                        ImporteTotal =Convert.ToDouble(item["SUM_ROW"]),
                        SimboloMoneda=Convert.ToString(item["cSimbolo"]),
                        Detallereporte= Convert.ToString(item["cFlag"])

                    });
                    y++;
                }
                
                return lstImporteDeCierreAnt;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daVerificarApertura", ex.Message);
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

        public List<Cuadre> DAListarCajaDia(string pcFecha, Int32 pidUsuario, Int16 pidSucursal, out decimal pnSaldo)
        {

            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtCompra = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            List<Cuadre> lstVenta = null;
            try
            {

                pa[0] = new SqlParameter("@pedFecha", SqlDbType.Date);
                pa[0].Value = pcFecha;
                pa[1] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[1].Value = pidUsuario;
                pa[2] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[2].Value = pidSucursal;
                pa[3] = new SqlParameter("@psmMontoSaldo", SqlDbType.Decimal);
                pa[3].Direction = ParameterDirection.Output;

                objCnx = new clsConexion("");
                dtCompra = objCnx.EjecutarProcedimientoDT("uspCuadrarCaja", pa);
                objCnx.CierraConexion();
                pnSaldo = Math.Round(Convert.ToDecimal(pa[3].Value), 2);

                lstVenta = new List<Cuadre>();
                foreach (DataRow drMenu in dtCompra.Rows)
                {
                    lstVenta.Add(new Cuadre
                        (
                        Convert.ToInt32(drMenu["idTrandiaria"]),
                        Convert.ToDateTime(drMenu["dFecha"]), 
                        Convert.ToString(drMenu["cNombreOperacion"]),
                        Convert.ToDecimal(drMenu["mIngreso"]), 
                        Convert.ToDecimal(drMenu["mSalida"]),
                        Convert.ToDecimal(drMenu["mSaldo"]), 
                        Convert.ToString(drMenu["cUser"]),
                        Convert.ToInt32(drMenu["idDocumento"])

                        ));
                }

                return lstVenta;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "DAListarCajaDia", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtCompra = null;
                lstVenta = null;
            }

        }

        public Boolean daEliminarMovCaja(Int32 pidTrandiaria, int pidUsuario, string pcFechaSis)
        {
            SqlParameter[] pa = new SqlParameter[3];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidTrandiaria", SqlDbType.Int);
                pa[0].Value = pidTrandiaria;
                pa[1] = new SqlParameter("@peidUsduario", SqlDbType.Int);
                pa[1].Value = pidUsuario;
                pa[2] = new SqlParameter("@pecFechaSis", SqlDbType.VarChar, 30);
                pa[2].Value = pcFechaSis;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspEliminarMovCaja", pa);
                objCnx.CierraConexion();

                return true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daEliminarMovCaja", ex.Message);
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

        public DataTable DAListarConcepto(string pcTipoConcepto, string pcTipoOpe)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtCompra = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecTipoConcepto", SqlDbType.VarChar, 8);
                pa[0].Value = pcTipoConcepto;
                pa[1] = new SqlParameter("@pecTipoOpe", SqlDbType.VarChar, 1);
                pa[1].Value = pcTipoOpe;

                objCnx = new clsConexion("");
                dtCompra = objCnx.EjecutarProcedimientoDT("uspListarConcepto", pa);
                objCnx.CierraConexion();

                return dtCompra;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "DAListarConcepto", ex.Message);
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

        public DataTable DAListarExtorno(string pcFecha, string pcBuscar, Int16 pidSucursal, Int16 piTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtCompra = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecFecha", SqlDbType.VarChar, 20);
                pa[0].Value = pcFecha;
                pa[1] = new SqlParameter("@pecBuscar", SqlDbType.VarChar, 50);
                pa[1].Value = pcBuscar;
                pa[2] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[2].Value = pidSucursal;
                pa[3] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[3].Value = piTipoCon;

                objCnx = new clsConexion("");
                dtCompra = objCnx.EjecutarProcedimientoDT("uspListaExtorno", pa);
                objCnx.CierraConexion();

                return dtCompra;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "DAListarExtorno", ex.Message);
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

        public String daExtornarVenta(Int32 pidVenta, Int16 pidSucursal, Int32 pidUsuario, string pcFecha, Int16 piTipoVenta)
        {
            SqlParameter[] pa = new SqlParameter[5];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidVenta", SqlDbType.Int);
                pa[0].Value = pidVenta;
                pa[1] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[1].Value = pidSucursal;
                pa[2] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[2].Value = pidUsuario;
                pa[3] = new SqlParameter("@pecFecha", SqlDbType.DateTime);
                pa[3].Value = pcFecha;
                pa[4] = new SqlParameter("@peidTipoVenta", SqlDbType.TinyInt);
                pa[4].Value = piTipoVenta;



                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspExtornarVenta", pa);
                objCnx.CierraConexion();

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daExtornarVenta", ex.Message);
                return "NO";
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;

            }

        }

        public List<DetalleVenta> daReporteVenta(String pcFechaIni, String pcFechaFin)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            List<DetalleVenta> lstVenta = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecFechaIni", SqlDbType.DateTime);
                pa[0].Value = pcFechaIni;
                pa[1] = new SqlParameter("@pecFechaFin", SqlDbType.DateTime);
                pa[1].Value = pcFechaFin;

                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspReportarVenta", pa);

                lstVenta = new List<DetalleVenta>();
                foreach (DataRow drMenu in dtVenta.Rows)
                {
                    //lstVenta.Add(new DetalleVenta(Convert.ToInt32(drMenu["idVenta"]),
                    //    Convert.ToInt32(drMenu["Cantidad"]), Convert.ToDecimal(drMenu["PrecioVenta"]), 
                    //     Convert.ToDecimal(drMenu["Importe"])
                    //    , Convert.ToDecimal(drMenu["Ganancia"]), Convert.ToDecimal(drMenu["PorcGanancia"]),
                    //     Convert.ToInt32(drMenu["TipoVenta"]), Convert.ToDecimal(drMenu["Deuda"])));
                }

                return lstVenta;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daReporteVenta", ex.Message);
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

        public List<DetalleVenta> daReporteVentaXLote(Int32 pidLote)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            List<DetalleVenta> lstVenta = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidLote", SqlDbType.Int);
                pa[0].Value = pidLote;

                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspReportarVentaXLote", pa);

                lstVenta = new List<DetalleVenta>();
                foreach (DataRow drMenu in dtVenta.Rows)
                {
                    //lstVenta.Add(new DetalleVenta(Convert.ToInt32(drMenu["idVenta"]),
                    //     Convert.ToInt32(drMenu["Cantidad"]), Convert.ToDecimal(drMenu["PrecioVenta"]),
                    //    Convert.ToDecimal(drMenu["Importe"])
                    //    , Convert.ToDecimal(drMenu["Ganancia"]), Convert.ToDecimal(drMenu["PorcGanancia"]),
                    //    Convert.ToInt32(drMenu["TipoVenta"]), Convert.ToDecimal(drMenu["Deuda"])));
                }

                return lstVenta;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daReporteVenta", ex.Message);
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

        public List<ReporteBloque> daReporteVentaXCliente(Int32 pintidCliente)
        {
            SqlParameter[] pa = new SqlParameter[6];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            List<DetalleVenta> lstVenta = new List<DetalleVenta>();
            List<ReporteBloque> lsRepBloque = new List<ReporteBloque>();
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@chkHabilitarFecha", SqlDbType.Bit);
                pa[0].Value = true;
                pa[1] = new SqlParameter("@chkDiaEspecifico", SqlDbType.Bit);
                pa[1].Value = false;
                pa[2] = new SqlParameter("@dtFechaIni", SqlDbType.Date);
                pa[2].Value = "2022/06/01";
                pa[3] = new SqlParameter("@dtFechaFin", SqlDbType.Date);
                pa[3].Value = "2022/06/23";
                pa[4] = new SqlParameter("@codTipoReporte", SqlDbType.NVarChar,10);
                pa[4].Value = "TRPT0001";
                pa[5] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[5].Value = -1;

                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspBuscarReporteConGrafica", pa);

                
                foreach (DataRow dr in dtVenta.Rows)
                {
                    lsRepBloque.Add(new ReporteBloque
                    {
                        Codigoreporte = dr["id"].ToString(),
                        Detallereporte = dr["descripcion"].ToString(),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        idMoneda = Convert.ToInt32(dr["idMoneda"]),
                        SimboloMoneda = dr["cSimbolo"].ToString(),
                        ImporteTipoCambio = Convert.ToDouble(dr["cTipoCambio"]),
                        ImporteRow = Convert.ToDouble(dr["montoTotal"])
                    });
                    //lstVenta.Add(new DetalleVenta
                    //    (
                    //    Convert.ToInt32(drMenu["idVenta"]),
                    //    Convert.ToInt32(drMenu["Cantidad"]),
                    //    Convert.ToDecimal(drMenu["PrecioVenta"]),
                    //     Convert.ToDecimal(drMenu["Importe"])
                    //    , Convert.ToDecimal(drMenu["Ganancia"]), Convert.ToDecimal(drMenu["PorcGanancia"]),
                    //    Convert.ToInt32(drMenu["TipoVenta"])
                    //    , Convert.ToDecimal(drMenu["Deuda"])
                    //    ));
                }

                return lsRepBloque;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daReporteVentaXCliente", ex.Message);
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

        public List<DetalleVenta> daConsultarDeudas(string pcFechaIni = null, string pcFechaFin = null, int pintIdLote=0, Int16 pnTipoLlamada =0)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtVenta = new DataTable();
            clsConexion objCnx = null;
            List<DetalleVenta> lstDeudas = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecFechaIni", SqlDbType.DateTime);
                pa[0].Value = pcFechaIni;
                pa[1] = new SqlParameter("@pecFechaFin", SqlDbType.DateTime);
                pa[1].Value = pcFechaFin;
                pa[2] = new SqlParameter("@peintIdCliente", SqlDbType.Int);
                pa[2].Value = pintIdLote;
                pa[3] = new SqlParameter("@petinTipoLlamada", SqlDbType.TinyInt);
                pa[3].Value = pnTipoLlamada;

                objCnx = new clsConexion("");
                dtVenta = objCnx.EjecutarProcedimientoDT("uspConsultarDeudas", pa);

                lstDeudas = new List<DetalleVenta>();
                foreach (DataRow drMenu in dtVenta.Rows)
                {
                    //lstDeudas.Add(new DetalleVenta(Convert.ToInt32(drMenu["idCliente"]),
                    //    Convert.ToString(drMenu["Cliente"]),Convert.ToDecimal(drMenu["Importe"])
                    //    , Convert.ToDecimal(drMenu["Deuda"]), Convert.ToInt32(drMenu["DiasTranscurridos"])));
                }

                return lstDeudas;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DADocumentoVenta.cs", "daConsultarDeudas", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstDeudas = null;
            }

        }

    }
}
