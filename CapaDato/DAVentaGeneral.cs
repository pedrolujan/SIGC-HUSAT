using CapaConexion;
using CapaEntidad;
using CapaUtil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class DAVentaGeneral
    {
        private clsUtil objUtil = null;
        public Boolean daGenerarVentaGeneral(VentaGeneral clsVentaGeneral, List<xmlDocumentoVentaGeneral> xmlDocVenta, byte[] btImage, Int16 tipoCon)
        {

            SqlParameter[] pa = new SqlParameter[34];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            List<VentaGeneral> lstVentaGeneral = new List<VentaGeneral>();
            List<Cliente> lstCliente = new List<Cliente>();
            lstCliente.Add(clsVentaGeneral.ClsCliente);
            String xmlDetalleCronograma = clsUtil.Serialize(clsVentaGeneral.lstDetalleCronograma);
            String xmlDetalleVenta = clsUtil.Serialize(clsVentaGeneral.clsDetalleVentaCabecera.lstDetalleVenta);
            String xmlVehiculo = clsUtil.Serialize(clsVentaGeneral.lstVehiculo);
            String xmlTrandiaria = clsUtil.Serialize(clsVentaGeneral.lstPagos);
            lstVentaGeneral.Add(clsVentaGeneral);
            String xmlVentaGeneral = clsUtil.Serialize(lstVentaGeneral);
            String xmlDocumentoVenta = clsUtil.Serialize(xmlDocVenta);
            String xmlCliente = clsUtil.Serialize(lstCliente);
            String xmlDataVNR = clsUtil.Serialize(clsVentaGeneral.lstVehiculoNRenov);

            try
            {
                pa[0] = new SqlParameter("@idVentaGeneral", SqlDbType.Int) { Value = clsVentaGeneral.IdVentaGeneral };
                pa[1] = new SqlParameter("@idCliente", SqlDbType.Int) { Value = clsVentaGeneral.ClsCliente.idCliente };
                pa[2] = new SqlParameter("@idRespPago", SqlDbType.Int) { Value = clsVentaGeneral.ClsResponsablePago.idCliente};
                pa[3] = new SqlParameter("@idPlan", SqlDbType.Int) { Value = clsVentaGeneral.ClsPlan.idPlan };
                pa[4] = new SqlParameter("@idCiclo", SqlDbType.Int) { Value = clsVentaGeneral.ClsCiclo.IdCiclo };
                pa[5] = new SqlParameter("@idMoneda", SqlDbType.Int) { Value = clsVentaGeneral.ClsMoneda.idMoneda };
                pa[6] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsVentaGeneral.IdUsuario };
                pa[7] = new SqlParameter("@dFechaRegistro", SqlDbType.DateTime) { Value = clsVentaGeneral.FechaRegistro };
                pa[8] = new SqlParameter("@estado", SqlDbType.NVarChar, 8) { Value = clsVentaGeneral.Estado };
                pa[9] = new SqlParameter("@tipoCon", SqlDbType.Int) { Value = tipoCon };
                pa[10] = new SqlParameter("@xmlData", SqlDbType.Xml) { Value = xmlDetalleCronograma };
                pa[11] = new SqlParameter("@xmlData2", SqlDbType.Xml) { Value = xmlDetalleVenta };
                pa[12] = new SqlParameter("@xmlData3", SqlDbType.Xml) { Value = xmlVehiculo };
                pa[13] = new SqlParameter("@xmlData4", SqlDbType.Xml) { Value = xmlVentaGeneral };
                pa[14] = new SqlParameter("@xmlTrandiaria", SqlDbType.Xml) { Value = xmlTrandiaria };
                pa[15] = new SqlParameter("@periodoInicio", SqlDbType.DateTime) { Value = clsVentaGeneral.FechaVenta /*clsVentaGeneral.lstDetalleCronograma.First().periodoInicio */};
                pa[16] = new SqlParameter("@periodoFinal", SqlDbType.DateTime) { Value = clsVentaGeneral.FechaVenta.AddYears(1).AddDays(-1) /*clsVentaGeneral.lstDetalleCronograma.Last().periodoFinal*/ };
                pa[17] = new SqlParameter("@igvValor", SqlDbType.Money) { Value = clsVentaGeneral.clsDetalleVentaCabecera.IGV };
                pa[18] = new SqlParameter("@totalVenta", SqlDbType.Money) { Value = clsVentaGeneral.clsDetalleVentaCabecera.Total };
                pa[19] = new SqlParameter("@xmlDocumentoVenta", SqlDbType.Xml) { Value = xmlDocumentoVenta };
                pa[20] = new SqlParameter("@codDireccionInstalacion", SqlDbType.NVarChar, 8) { Value = clsVentaGeneral.codDireccionInstalacion };
                pa[21] = new SqlParameter("@DescripDireccionInstalacion", SqlDbType.NVarChar, 1000) { Value = clsVentaGeneral.DescripDireccionInstalacion };
                pa[22] = new SqlParameter("@dFechaDeInstalacion", SqlDbType.DateTime) { Value = clsVentaGeneral.FechaDeInstalacion };
                pa[23] = new SqlParameter("@cCodEstadoPP", SqlDbType.NVarChar, 8) { Value = clsVentaGeneral.cCodEstadoPP };
                pa[24] = new SqlParameter("@xmlCliente", SqlDbType.Xml) { Value = xmlCliente };
                pa[25] = new SqlParameter("@idTipoTarifa", SqlDbType.Int) { Value = clsVentaGeneral.ClsTarifa.IdTipoTarifa };
                pa[26] = new SqlParameter("@CodigoVentaGeneral", SqlDbType.NVarChar, 20) { Value = clsVentaGeneral.codigoVenta };
                pa[27] = new SqlParameter("@xmlDataVNR", SqlDbType.Xml) { Value = xmlDataVNR };
                pa[28] = new SqlParameter("@FinalizacionContrato", SqlDbType.Int) { Value = clsVentaGeneral.estFinalizacionContrato };
                pa[29] = new SqlParameter("@dFechaPago", SqlDbType.DateTime) { Value = clsVentaGeneral.FechaPago };
                pa[30] = new SqlParameter("@dFechaVenta", SqlDbType.DateTime) { Value = clsVentaGeneral.FechaVenta };
                pa[31] = new SqlParameter("@ImgQR", SqlDbType.Image) { Value =  btImage };
                pa[32] = new SqlParameter("@CorrelativoDocumento", SqlDbType.VarChar,13) { Value = clsVentaGeneral.codigoCorrelativo };
                pa[33] = new SqlParameter("@idContrato", SqlDbType.Int) { Value = tipoCon==0?0: clsVentaGeneral.clsContrato.idContrato };
                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimientoDT("uspGuardarVentaGeneral", pa);

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

        public Boolean DAActualizarEstadoContratoAutomatico(Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[1];

            clsConexion objCnx = null;
            DataTable dtAECA = new DataTable();
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@tipoCon", SqlDbType.Int) { Value = tipoCon };

                objCnx = new clsConexion("");
                dtAECA = objCnx.EjecutarProcedimientoDT("uspActualizarEstadoContratoAutomatico", pa);
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


        public String daBuscarVentaAImprimir(VentaGeneral clsVentaGeneral, Int16 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[12];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String cCodVenta = "";
            DataTable dtresp = new DataTable();

            try
            {
                pa[0] = new SqlParameter("@idCliente", SqlDbType.Int) { Value = clsVentaGeneral.ClsCliente.idCliente };
                pa[1] = new SqlParameter("@idRespPago", SqlDbType.Int) { Value = clsVentaGeneral.ClsResponsablePago.idCliente };
                pa[2] = new SqlParameter("@idPlan", SqlDbType.Int) { Value = clsVentaGeneral.ClsPlan.idPlan };
                pa[3] = new SqlParameter("@idCiclo", SqlDbType.Int) { Value = clsVentaGeneral.ClsCiclo.IdCiclo };
                pa[4] = new SqlParameter("@idMoneda", SqlDbType.Int) { Value = clsVentaGeneral.ClsMoneda.idMoneda };
                pa[5] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsVentaGeneral.IdUsuario };
                pa[6] = new SqlParameter("@dFechaRegistro", SqlDbType.DateTime) { Value = clsVentaGeneral.FechaRegistro };
                pa[7] = new SqlParameter("@estado", SqlDbType.NVarChar, 8) { Value = clsVentaGeneral.Estado };
                pa[8] = new SqlParameter("@tipoCon", SqlDbType.Int) { Value = tipoCon };
                pa[9] = new SqlParameter("@totalVenta", SqlDbType.Money) { Value = clsVentaGeneral.clsDetalleVentaCabecera.Total };
                pa[10] = new SqlParameter("@codDireccionInstalacion", SqlDbType.NVarChar, 8) { Value = clsVentaGeneral.codDireccionInstalacion };
                pa[11] = new SqlParameter("@cCodEstadoPP", SqlDbType.NVarChar, 8) { Value = clsVentaGeneral.cCodEstadoPP };
                objCnx = new clsConexion("");
                dtresp = objCnx.EjecutarProcedimientoDT("uspBuscarCodVenta", pa);
                foreach (DataRow drMenu in dtresp.Rows)
                {
                    cCodVenta = Convert.ToString(drMenu["CodigoVenta"]);
                }
                return cCodVenta;
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

        public DataTable daBuscarContrato(String codventa, String Placa, Int32 idContrato)
        {
            SqlParameter[] pa = new SqlParameter[3];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String cCodVenta = "";
            DataTable dtresp = new DataTable();

            try
            {
                pa[0] = new SqlParameter("@codVenta", SqlDbType.NVarChar) { Value = codventa };
                pa[1] = new SqlParameter("@plcaVehiculo", SqlDbType.NVarChar) { Value = Placa };
                pa[2] = new SqlParameter("@idContrato", SqlDbType.Int) { Value = idContrato };

                objCnx = new clsConexion("");
                dtresp = objCnx.EjecutarProcedimientoDT("uspBuscarContrato", pa);
                return dtresp;
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
        public xmlInstalacion daBuscarActaInstalacion(String codventa, String Placa, Int32 idTipoVenta)
        {
            SqlParameter[] pa = new SqlParameter[3];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String cCodVenta = "";
            DataTable dtresp = new DataTable();
            xmlInstalacion xmlInstal = new xmlInstalacion();
            List<AccesoriosEquipo> lstaAcc = new List<AccesoriosEquipo>();
            List<ServicioEquipo> lstaServ = new List<ServicioEquipo>();
            List<AccesoriosEquipo> lstaAccesorioActual = new List<AccesoriosEquipo>();
            List<ServicioEquipo> lstaServicioActual = new List<ServicioEquipo>();
            DataSet dtMenu = new DataSet();
            DataView dvaccesorio = new DataView();
            DataView dvservicio = new DataView();
            DataView dvgen = new DataView();
            String xmlActaInstalacion = "";
            String CodigoActaInstalacion = "";
            String usuario = "";
            String TipoVenta = "";

            try
            {
                pa[0] = new SqlParameter("@CodigoVenta", SqlDbType.NVarChar, 20) { Value = codventa };
                pa[1] = new SqlParameter("@PlacaVehiculo", SqlDbType.NVarChar, 20) { Value = Placa };
                pa[2] = new SqlParameter("@idTipoVenta", SqlDbType.Int) { Value = idTipoVenta };

                objCnx = new clsConexion("");
                dtMenu = objCnx.EjecutarProcedimientoDS("uspBuscarActaInstalacion", pa);
                dvgen = new DataView(dtMenu.Tables[0]);
                dvaccesorio = new DataView(dtMenu.Tables[1]);
                dvservicio = new DataView(dtMenu.Tables[2]);

                foreach (DataRowView dr in dvgen)
                {
                    xmlActaInstalacion = Convert.ToString(dr["XmlInstalacion"]);
                    CodigoActaInstalacion = Convert.ToString(dr["CodigoInstalacion"]);
                    usuario = Convert.ToString(dr["cUsuario"]);
                    TipoVenta = Convert.ToString(dr["TipoVenta"]);
                }

                foreach (DataRowView dr in dvaccesorio)
                {
                    lstaAcc.Add(new AccesoriosEquipo
                    {
                        checkAccesorio = true,
                        idAccesorios = Convert.ToInt32(dr["idAccesorio"]),
                        NombreAccesorio = Convert.ToString(dr["cAccesorioGps"])
                    });
                }
                foreach (DataRowView dr in dvservicio)
                {
                    lstaServ.Add(new ServicioEquipo
                    {
                        checkServicio = true,
                        idServicios = Convert.ToInt32(dr["idServicio"]),
                        NombreServicio = Convert.ToString(dr["cServicioGps"])
                    });
                }


                if (xmlActaInstalacion != "")
                {
                    xmlInstal = clsUtil.Deserialize<xmlInstalacion>(xmlActaInstalacion);
                    lstaAccesorioActual = xmlInstal.ListaAccesorio;
                    lstaServicioActual = xmlInstal.ListaServicio;

                    for (int i = 0; i < lstaAccesorioActual.Count; i++)
                    {
                        for (int j = 0; j < lstaAcc.Count; j++)
                        {
                            if (lstaAccesorioActual[i].idAccesorios == lstaAcc[j].idAccesorios)
                            {
                                lstaAccesorioActual[i].checkAccesorio = true;
                            }
                        }


                    }

                    for (int i = 0; i < lstaServicioActual.Count; i++)
                    {
                        for (int j = 0; j < lstaServ.Count; j++)
                        {
                            if (lstaServicioActual[i].idServicios == lstaServ[j].idServicios)
                            {
                                lstaServicioActual[i].checkServicio = true;
                            }
                        }


                    }
                    xmlInstal.clsInstalacion.codigoInstalacion = CodigoActaInstalacion;
                    xmlInstal.ListaAccesorio = lstaAccesorioActual;
                    xmlInstal.ListaServicio = lstaServicioActual;
                    xmlInstal.clsInstalacion.cUsuario = usuario;
                    xmlInstal.ListaPlan[0].tarifas = TipoVenta;
                }

                return xmlInstal;
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
        public Boolean daAnularventa(String codventa)
        {
            SqlParameter[] pa = new SqlParameter[1];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String cCodVenta = "";
            DataTable dtresp = new DataTable();

            try
            {
                pa[0] = new SqlParameter("@codVenta", SqlDbType.NVarChar, 20) { Value = codventa };

                objCnx = new clsConexion("");
                dtresp = objCnx.EjecutarProcedimientoDT("uspAnularVenta", pa);
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
        public Boolean daActualizarTemaUsuario(Int32 idUsuario, String codTema)
        {
            SqlParameter[] pa = new SqlParameter[2];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String cCodVenta = "";
            DataTable dtresp = new DataTable();

            try
            {
                pa[0] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = idUsuario };
                pa[1] = new SqlParameter("@codTema", SqlDbType.NVarChar, 8) { Value = codTema };

                objCnx = new clsConexion("");
                dtresp = objCnx.EjecutarProcedimientoDT("uspActualizarTemaUsuario", pa);
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
        public DataTable daBuscarVentaGeneral(Boolean habilitarfechas, String fechaInical, String fechaFinal, String fechaAct, String placaVehiculo, String cEstadoInstal, Int32 numPagina, Int32 tipoLLamada, Int32 tipoCon, Int32 codTipoVenta, String estadoTipoContrato, Boolean habilitarRenovaciones, Int32 IdTipoPlan, String valorRadio)
        {
            SqlParameter[] pa = new SqlParameter[14];
            DataTable dtVentaG;
            clsConexion objCnx = null;

            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peHabilitarFechas", SqlDbType.TinyInt) { Value = habilitarfechas };
                pa[1] = new SqlParameter("@peFechaInical", SqlDbType.DateTime) { Value = fechaInical };
                pa[2] = new SqlParameter("@peFechaFinal", SqlDbType.DateTime) { Value = fechaFinal };
                pa[3] = new SqlParameter("@peFechaActual", SqlDbType.DateTime) { Value = fechaAct };
                pa[4] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 15) { Value = placaVehiculo };
                pa[5] = new SqlParameter("@pcEstadoInstal", SqlDbType.VarChar, 15) { Value = cEstadoInstal };
                pa[6] = new SqlParameter("@numPagina", SqlDbType.Int) { Value = numPagina };
                pa[7] = new SqlParameter("@tipoLLamada", SqlDbType.Int) { Value = tipoLLamada };
                pa[8] = new SqlParameter("@tipoCon", SqlDbType.Real) { Value = tipoCon };
                pa[9] = new SqlParameter("@codTipoVenta", SqlDbType.Int) { Value = codTipoVenta };
                pa[10] = new SqlParameter("@estadoTipoContrato", SqlDbType.NVarChar, 8) { Value = estadoTipoContrato };
                pa[11] = new SqlParameter("@pehabilitarRenovaciones", SqlDbType.TinyInt) { Value = habilitarRenovaciones };
                pa[12] = new SqlParameter("@IdTipoPlan", SqlDbType.Int) { Value = IdTipoPlan };
                pa[13] = new SqlParameter("@valorRadio", SqlDbType.NVarChar, 8) { Value = valorRadio };

                objCnx = new clsConexion("");
                if (habilitarRenovaciones == false)
                {
                    dtVentaG = objCnx.EjecutarProcedimientoDT("uspBuscarRenovaciones", pa);
                }
                else
                {
                    dtVentaG = objCnx.EjecutarProcedimientoDT("uspBuscarVentaGeneral", pa);
                }

                return dtVentaG;
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
        public DataTable daBuscarVentaPagoPendiente(Boolean chk, String  CodEstadoPago, String busq, String dfechaIni, String dfechaFin, Int32 numPagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[7];
            DataTable dtVentaG;
            clsConexion objCnx = null;

            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peHabilitarFechas", SqlDbType.Bit) { Value = chk };
                pa[1] = new SqlParameter("@CodEstadoPago", SqlDbType.VarChar,15) { Value = CodEstadoPago };
                pa[2] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 15) { Value = busq };
                pa[3] = new SqlParameter("@peFechaInical", SqlDbType.Date) { Value = dfechaIni };
                pa[4] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = dfechaFin };
                pa[5] = new SqlParameter("@numPagina", SqlDbType.VarChar, 15) { Value = numPagina };
                pa[6] = new SqlParameter("@tipoCon", SqlDbType.Int) { Value = tipoCon };

                objCnx = new clsConexion("");
                dtVentaG = objCnx.EjecutarProcedimientoDT("uspBuscarPagoPendiente", pa);
                return dtVentaG;
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


        public DataTable daBuscarPagosPendiente( Int32 idTrandiaria, Boolean chk, String busq, String dfechaIni, String dfechaFin, Int32 numPagina, Int32 tipoCon)
        {

            SqlParameter[] pa = new SqlParameter[7];
            DataTable dtVentaG;
            clsConexion objCnx = null;

            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idTrandiaria", SqlDbType.Int) { Value = idTrandiaria };
                pa[1] = new SqlParameter("@peHabilitarFechas", SqlDbType.Bit) { Value = chk };
                pa[2] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 15) { Value = busq };
                pa[3] = new SqlParameter("@peFechaInical", SqlDbType.Date) { Value = dfechaIni };
                pa[4] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = dfechaFin };
                pa[5] = new SqlParameter("@numPagina", SqlDbType.VarChar, 15) { Value = numPagina };
                pa[6] = new SqlParameter("@tipoCon", SqlDbType.Int) { Value = tipoCon };

                objCnx = new clsConexion("");
                dtVentaG = objCnx.EjecutarProcedimientoDT("uspBuscarCuotasPagadasPagoPendiente", pa);
                return dtVentaG;
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

        public Boolean daGuardarActualizacionCuotas(List<xmlDocumentoVentaGeneral> xmlDocVenta, Int32 idConcepto, DateTime FechaRegistro, Int32 Usuario)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtVentaG;
            clsConexion objCnx = null;

            String xmDocumentoVenta = clsUtil.Serialize(xmlDocVenta);
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idConcepto", SqlDbType.Int) { Value = idConcepto };
                pa[1] = new SqlParameter("@IdUsuario", SqlDbType.Int) { Value = Usuario };
                pa[2] = new SqlParameter("@dtFechaRegistro", SqlDbType.DateTime) { Value = FechaRegistro };
                pa[3] = new SqlParameter("@xmlDocumentoVenta", SqlDbType.Xml) { Value = xmDocumentoVenta };

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimientoDT("uspGuardarActualizacion", pa);
                return true;
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
        public Boolean daGuardarpagosPendientes(Int32 idTrandiaria, List<Pagos> lstTrand, List<xmlDocumentoVentaGeneral> lstXml, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[6];
            DataTable dtVentaG;
            clsConexion objCnx = null;
            String xmlTrandiaria = clsUtil.Serialize(lstTrand);
            String xmDocumentoVenta = clsUtil.Serialize(lstXml);
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idTrandiaria", SqlDbType.Int) { Value = idTrandiaria };
                pa[1] = new SqlParameter("@xmlTrandiaria", SqlDbType.Xml) { Value = xmlTrandiaria };
                pa[2] = new SqlParameter("@xmlDocumentoVenta", SqlDbType.Xml) { Value = xmDocumentoVenta };
                pa[3] = new SqlParameter("@dtFechaRegistro", SqlDbType.DateTime) { Value = lstTrand[0].dFechaPago };
                pa[4] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = lstTrand[0].idUsario };
                pa[5] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = tipoCon };

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimientoDT("uspGuardarPagosPendientes", pa);
                return true;
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

        public Personal daDevolverUsuarioActual(Int32 Usuario)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVentaG = new DataTable();
            clsConexion objCnx = null;
            Personal cUsuario = new Personal();
            objUtil = new clsUtil();

            List<Personal> lstPersonal = new List<Personal>();
            try
            {
                pa[0] = new SqlParameter("@idUsuario", SqlDbType.TinyInt) { Value = Usuario };


                objCnx = new clsConexion("");
                dtVentaG = objCnx.EjecutarProcedimientoDT("uspObtenerUsuarioActual", pa);
                foreach (DataRow drMenu in dtVentaG.Rows)
                {
                    if (drMenu["Perfil"].ToString() == "")
                    {
                        cUsuario.idUsuario = Convert.ToInt32(drMenu["idUsuario"]);
                        cUsuario.idPersonal = Convert.ToInt32(drMenu["idPersonal"]);
                        cUsuario.cUsuario = Convert.ToString(drMenu["cUser"]);
                        cUsuario.cPrimerNom = Convert.ToString(drMenu["cPrimerNom"]);
                        cUsuario.cApePat = Convert.ToString(drMenu["cApePat"]);
                        cUsuario.cApeMat = Convert.ToString(drMenu["cApeMat"]);
                        cUsuario.cDireccion = Convert.ToString(drMenu["cDireccion"]);
                        cUsuario.cDocumento = Convert.ToString(drMenu["cDocumento"]);
                        cUsuario.codTema = Convert.ToString(drMenu["codTema"]);
                    }
                    else
                    {



                        byte[] b = (Byte[])drMenu["Perfil"];
                        MemoryStream ms = new MemoryStream(b);

                        cUsuario.idUsuario = Convert.ToInt32(drMenu["idUsuario"]);
                        cUsuario.idPersonal = Convert.ToInt32(drMenu["idPersonal"]);
                        cUsuario.cUsuario = Convert.ToString(drMenu["cUser"]);
                        cUsuario.cPrimerNom = Convert.ToString(drMenu["cPrimerNom"]);
                        cUsuario.cApePat = Convert.ToString(drMenu["cApePat"]);
                        cUsuario.cApeMat = Convert.ToString(drMenu["cApeMat"]);
                        cUsuario.cDireccion = Convert.ToString(drMenu["cDireccion"]);
                        cUsuario.cDocumento = Convert.ToString(drMenu["cDocumento"]);
                        cUsuario.codTema = Convert.ToString(drMenu["codTema"]);
                        cUsuario.strPerfil = ms;
                    }
                }
                return cUsuario;
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
        public List<Personal> daDevolverusuariosPersonal(Int32 Usuario)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVentaG = new DataTable();
            clsConexion objCnx = null;
            Personal cUsuario ;
            List<Personal> lstUsuario = new List<Personal>();
            objUtil = new clsUtil();

            List<Personal> lstPersonal = new List<Personal>();
            try
            {
                pa[0] = new SqlParameter("@idUsuario", SqlDbType.TinyInt) { Value = Usuario };


                objCnx = new clsConexion("");
                dtVentaG = objCnx.EjecutarProcedimientoDT("uspObtenerUsuarioActual", pa);
                foreach (DataRow drMenu in dtVentaG.Rows)
                {
                    cUsuario = new Personal();
                    if (drMenu["Perfil"].ToString() == "")
                    {
                        cUsuario.idUsuario = Convert.ToInt32(drMenu["idUsuario"]);
                        cUsuario.idPersonal = Convert.ToInt32(drMenu["idPersonal"]);
                        cUsuario.cUsuario = Convert.ToString(drMenu["cUser"]);
                        cUsuario.cPrimerNom = Convert.ToString(drMenu["cPrimerNom"]);
                        cUsuario.cApePat = Convert.ToString(drMenu["cApePat"]);
                        cUsuario.cApeMat = Convert.ToString(drMenu["cApeMat"]);
                        cUsuario.cDireccion = Convert.ToString(drMenu["cDireccion"]);
                        cUsuario.cDocumento = Convert.ToString(drMenu["cDocumento"]);
                        cUsuario.codTema = Convert.ToString(drMenu["codTema"]);
                    }
                    else
                    {



                        byte[] b = (Byte[])drMenu["Perfil"];
                        MemoryStream ms = new MemoryStream(b);

                        cUsuario.idUsuario = Convert.ToInt32(drMenu["idUsuario"]);
                        cUsuario.idPersonal = Convert.ToInt32(drMenu["idPersonal"]);
                        cUsuario.cUsuario = Convert.ToString(drMenu["cUser"]);
                        cUsuario.cPrimerNom = Convert.ToString(drMenu["cPrimerNom"]);
                        cUsuario.cApePat = Convert.ToString(drMenu["cApePat"]);
                        cUsuario.cApeMat = Convert.ToString(drMenu["cApeMat"]);
                        cUsuario.cDireccion = Convert.ToString(drMenu["cDireccion"]);
                        cUsuario.cDocumento = Convert.ToString(drMenu["cDocumento"]);
                        cUsuario.codTema = Convert.ToString(drMenu["codTema"]);
                        cUsuario.strPerfil = ms;
                    }
                    lstUsuario.Add(cUsuario);
                }
                return lstUsuario;
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
        public Int32 daValidarContratoReciente(Int32 idContrato)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVentaG = new DataTable();
            clsConexion objCnx = null;
            Int32 idCOntratoValido = 0;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idContrato", SqlDbType.Int) { Value = idContrato };


                objCnx = new clsConexion("");
                dtVentaG = objCnx.EjecutarProcedimientoDT("uspBusacrContratoReciente", pa);
                foreach (DataRow drMenu in dtVentaG.Rows)
                {
                    idCOntratoValido = Convert.ToInt32(drMenu["idContratoValido"]);
                }
                return idCOntratoValido;
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

        public List<VentaGeneral> daDevolverVehiculoRenovacion(String cBuscar, String codVenta, Int32 idVehiculo, Int32 idContrato, List<Vehiculo> lstCT)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtVentaG = new DataTable();
            DataTable dtDetCronograma = new DataTable();
            clsConexion objCnx = null;
            List<VentaGeneral> objVenta = new List<VentaGeneral>();
            List<Vehiculo> lstVehiculo = new List<Vehiculo>();
            List<DetalleCronograma> lstDetCronograma = new List<DetalleCronograma>();
            List<DetalleVenta> lstDetVenta = new List<DetalleVenta>();
            DetalleVentaCabecera clsDetVentaCabecera = new DetalleVentaCabecera();
            Cliente clsCliente = new Cliente();
            Cliente clsRespPago = new Cliente();
            Plan ClsPlan = new Plan();
            Contrato clsContrato = new Contrato();
            Cronograma clsCronograma = new Cronograma();
            Ciclo clsCiclo = new Ciclo();
            Tarifa clsTarifa = new Tarifa();
            Moneda clsMoneda = new Moneda();
            String cUsuario = "";
            String xmlIsdContrato = clsUtil.Serialize(lstCT);
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@CodVenta", SqlDbType.NVarChar, 20) { Value = codVenta };
                pa[1] = new SqlParameter("@idCliente", SqlDbType.Int) { Value = idVehiculo };
                pa[2] = new SqlParameter("@cBuscar", SqlDbType.NVarChar, 8) { Value = cBuscar };
                pa[3] = new SqlParameter("@idContrato", SqlDbType.Int) { Value = idContrato };
                //pa[4] = new SqlParameter("@xmlidsContrato", SqlDbType.Xml) { Value = xmlIsdContrato };

                objCnx = new clsConexion("");
                dtVentaG = objCnx.EjecutarProcedimientoDT("uspObtenerVehiculoRenovacion_prueba", pa);
                if (idVehiculo == 0 && codVenta == "")
                {
                    foreach (DataRow drMenu in dtVentaG.Rows)
                    {
                        lstVehiculo.Add(new Vehiculo
                        {
                            idVehiculo = Convert.ToInt32(drMenu["idVehiculo"]),
                            vPlaca = Convert.ToString(drMenu["vPlaca"])
                        });

                        objVenta.Add(new VentaGeneral
                        {
                            codigoVenta = Convert.ToString(drMenu["codigoVenta"]),
                            lstVehiculo = lstVehiculo
                        });


                    }
                }
                else
                {
                    if (cBuscar == "")
                    {
                        clsCliente.cTipPers = Convert.ToInt32(dtVentaG.Rows[0][3]);
                        clsCliente.idCliente = Convert.ToInt32(dtVentaG.Rows[0][38]);
                        clsCliente.cTiDo = Convert.ToInt32(dtVentaG.Rows[0][5]);
                        clsCliente.cDocumento = Convert.ToString(dtVentaG.Rows[0][7]);
                        clsCliente.cApePat = Convert.ToString(dtVentaG.Rows[0][8]);
                        clsCliente.cApeMat = Convert.ToString(dtVentaG.Rows[0][9]);
                        clsCliente.cNombre = Convert.ToString(dtVentaG.Rows[0][10]);
                        clsCliente.cCorreo = Convert.ToString(dtVentaG.Rows[0][11]);
                        clsCliente.cTelFijo = Convert.ToString(dtVentaG.Rows[0][12]);
                        clsCliente.cTelCelular = Convert.ToString(dtVentaG.Rows[0][13]);
                        clsCliente.cDireccion = Convert.ToString(dtVentaG.Rows[0][14]);
                        clsTarifa.IdTipoTarifa = Convert.ToInt32(dtVentaG.Rows[0][25]);
                        
                        //responsable de pago

                        clsRespPago.cTipPers = Convert.ToInt32(dtVentaG.Rows[0][40]);
                        clsRespPago.idCliente = Convert.ToInt32(dtVentaG.Rows[0][39]);
                        clsRespPago.cTiDo = Convert.ToInt32(dtVentaG.Rows[0][41]);
                        clsRespPago.cDocumento = Convert.ToString(dtVentaG.Rows[0][42]);
                        clsRespPago.cApePat = Convert.ToString(dtVentaG.Rows[0][43]);
                        clsRespPago.cApeMat = Convert.ToString(dtVentaG.Rows[0][44]);
                        clsRespPago.cNombre = Convert.ToString(dtVentaG.Rows[0][45]);
                        clsRespPago.cCorreo = Convert.ToString(dtVentaG.Rows[0][46]);
                        clsRespPago.cTelFijo = Convert.ToString(dtVentaG.Rows[0][47]);
                        clsRespPago.cTelCelular = Convert.ToString(dtVentaG.Rows[0][48]);
                        clsRespPago.cDireccion = Convert.ToString(dtVentaG.Rows[0][49]);

                        lstVehiculo.Add(new Vehiculo
                        {
                            idVehiculo = Convert.ToInt32(dtVentaG.Rows[0][15]),
                            vPlaca = Convert.ToString(dtVentaG.Rows[0][16]),
                            vClase = Convert.ToString(dtVentaG.Rows[0][17]),
                            vMarcaV = Convert.ToString(dtVentaG.Rows[0][18]),
                            vModeloV = Convert.ToString(dtVentaG.Rows[0][19]),
                            vModUso = Convert.ToString(dtVentaG.Rows[0][20]),
                        });

                        ClsPlan.idTipoPlan = Convert.ToInt32(dtVentaG.Rows[0][22]);
                        ClsPlan.idPlan = Convert.ToInt32(dtVentaG.Rows[0][21]);
                        clsCiclo.IdCiclo = Convert.ToInt32(dtVentaG.Rows[0][1]);
                        clsMoneda.idMoneda = Convert.ToInt32(dtVentaG.Rows[0][2]);
                        clsContrato.idContrato = Convert.ToInt32(dtVentaG.Rows[0][24]);

                        clsCronograma.periodoInicio = Convert.ToDateTime(dtVentaG.Rows[0][36]);
                        clsCronograma.periodoFinal = Convert.ToDateTime(dtVentaG.Rows[0][37]);
                        int i = 0;
                        foreach (DataRow drMenu in dtVentaG.Rows)
                        {
                            lstDetVenta.Add(new DetalleVenta
                            {
                                IdDetalleVenta = Convert.ToInt32(drMenu["idDetalleVenta"]),
                                Numeracion = i + 1,
                                idTipoTarifa = Convert.ToInt32(drMenu["idTarifa"]),
                                Cantidad = Convert.ToInt32(drMenu["ROOW"]),
                                Descripcion = Convert.ToString(drMenu["Descripcion"]),
                                PrecioUni = Convert.ToDouble(drMenu["costo"]),
                                Descuento = Convert.ToDouble(drMenu["descuentoCantidad"]),
                                TotalTipoDescuento = Convert.ToDouble(drMenu["descuentoPrecio"]),
                                IdTipoDescuento = Convert.ToInt32(drMenu["idTipoDescuento"]),
                                Importe = (Convert.ToDouble(drMenu["costo"]) - Convert.ToDouble(drMenu["descuentoPrecio"]))
                            });
                            i++;
                        }
                        clsDetVentaCabecera.lstDetalleVenta = lstDetVenta;
                        objVenta.Add(new VentaGeneral
                        {
                            FechaRegistro = Convert.ToDateTime(dtVentaG.Rows[0][23]),
                            codigoVenta = Convert.ToString(dtVentaG.Rows[0][0]),
                            FechaPago = Convert.ToDateTime(dtVentaG.Rows[0][26]),
                            FechaVenta = Convert.ToDateTime(dtVentaG.Rows[0][27]),
                            lstVehiculo = lstVehiculo,
                            ClsCliente = clsCliente,
                            ClsResponsablePago= clsRespPago,
                            ClsPlan = ClsPlan,
                            ClsTarifa = clsTarifa,
                            clsDetalleVentaCabecera = clsDetVentaCabecera,
                            ClsCiclo = clsCiclo,
                            ClsMoneda = clsMoneda,
                            clsContrato = clsContrato,
                            clsCronograma = clsCronograma

                        });
                    }
                    else if (cBuscar != "")
                    {
                        foreach (DataRow drMenu in dtVentaG.Rows)
                        {
                            lstDetCronograma.Add(new DetalleCronograma
                            {

                                idDetalleCronograma = Convert.ToInt16(drMenu["idDetalleCronograma"]),
                                periodoInicio = Convert.ToDateTime(drMenu["periodoInicio"]),
                                periodoFinal = Convert.ToDateTime(drMenu["periodoFinal"]),
                                fechaEmision = Convert.ToDateTime(drMenu["fechaEmision"]),
                                fechaVencimiento = Convert.ToDateTime(drMenu["fechaVencimiento"]),
                                //periodoInicio=Convert.ToDateTime(dtVentaG.Rows[0][23]),
                                //periodoFinal=Convert.ToDateTime(dtVentaG.Rows[0][23]),
                                //fechaEmision=Convert.ToDateTime(dtVentaG.Rows[0][23]),
                                //fechaVencimiento=Convert.ToDateTime(dtVentaG.Rows[0][23]),

                                //periodoInicio=Convert.ToDateTime(dtVentaG.Rows[0][23]),
                                //periodoInicio=Convert.ToDateTime(dtVentaG.Rows[0][23]),
                                //periodoInicio=Convert.ToDateTime(dtVentaG.Rows[0][23]),
                                //periodoInicio=Convert.ToDateTime(dtVentaG.Rows[0][23])
                            });
                        }
                        objVenta.Add(new VentaGeneral
                        {

                            lstDetalleCronograma = lstDetCronograma

                        });
                    }

                }
                return objVenta;
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

    }
}
