using CapaConexion;
using CapaEntidad;
using CapaUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class DAOtrasVenta
    {
        public DAOtrasVenta() { }

        private clsUtil objUtil = null;
        public DataTable daBuscarTipoVenta(String pcBuscar, List<TipoVenta> lsTipoVenta,Int32 numPaginacion,Int32 tipocon)
        {
            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<Equipo> lstEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@idTipoVenta", SqlDbType.Int);
                pa[1].Value = lsTipoVenta[0].idTipoVenta;
                pa[2] = new SqlParameter("@idMarca", SqlDbType.Int);
                pa[2].Value = lsTipoVenta[0].idMarca;
                pa[3] = new SqlParameter("@idModelo", SqlDbType.Int);
                pa[3].Value = lsTipoVenta[0].idModelo;
                pa[4] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[4].Value = numPaginacion;
              


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarDatosTipoVenta", pa);


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
                lstEquipo = null;
            }

        }

        public DataTable daListarVentas(Int32 idDocumento, String pcBusqueda, Boolean activarFechas, DateTime fechaInicio, DateTime fechaFin, Int32 tipoVenta,String tipoDocVenta, Int32 idMarca, Int32 idModelo, Int32 pagInicio)
        {
            SqlParameter[] pa = new SqlParameter[10];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<Equipo> lstEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idDocumento", SqlDbType.VarChar, 8);
                pa[0].Value = idDocumento;
                pa[1] = new SqlParameter("@pcBusqueda", SqlDbType.VarChar,40);
                pa[1].Value = pcBusqueda;
                pa[2] = new SqlParameter("@activaFecha", SqlDbType.Bit);
                pa[2].Value = activarFechas;
                pa[3] = new SqlParameter("@dFechaIn", SqlDbType.DateTime);
                pa[3].Value = fechaInicio;
                pa[4] = new SqlParameter("@dFechaFin", SqlDbType.DateTime);
                pa[4].Value = fechaFin;
                pa[5] = new SqlParameter("@idTipoTransaccion", SqlDbType.Int);
                pa[5].Value = tipoVenta;
                pa[6] = new SqlParameter("@tipoDocVenta", SqlDbType.NVarChar,10);
                pa[6].Value = tipoDocVenta;
                pa[7] = new SqlParameter("@idMarca", SqlDbType.Int);
                pa[7].Value = idMarca;
                pa[8] = new SqlParameter("@idModelo", SqlDbType.Int);
                pa[8].Value = idModelo;
                pa[9] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[9].Value = pagInicio;

                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspListarOtrasVenta", pa);


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
                lstEquipo = null;
            }

        }
        public DataTable daDevolverTipoVenta(Int32 TipoVenta, Int32 idObjVenta)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idTipoVenta", SqlDbType.Int);
                pa[0].Value = TipoVenta;
                pa[1] = new SqlParameter("@idObjVenta", SqlDbType.Int);
                pa[1].Value = idObjVenta;
                


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspDevolverDatosTipoVenta", pa);


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

        public Boolean daGuardarOtrasVenta(OtrasVentas clsOtrasVentas, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[23];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            int intRowsAffected = 0;
            

            string xmlData = clsUtil.Serialize(clsOtrasVentas.lstDetalleVenta);
            string xmlTrandiaria = clsUtil.Serialize(clsOtrasVentas.lstTrandiaria);
            string xmlDocumentoDeVenta = clsUtil.Serialize(clsOtrasVentas.lstXmlDocVenta);
            string xmlActaCambioTitularidad = clsUtil.Serialize(clsOtrasVentas.lstXmlActTitularidad);
            string xmlActaCambioVehicular = clsUtil.Serialize(clsOtrasVentas.lstXmlActCambioVehicular);
            string xmOtrasVentas = clsUtil.Serialize(clsOtrasVentas.lstOtrasVenta);
            try
            {
                if (clsOtrasVentas.lstOtrasVenta.Count == 1)
                {

                }
                pa[0] = new SqlParameter("@idTipoTransaccion", SqlDbType.Int);
                pa[0].Value = clsOtrasVentas.lstOtrasVenta[0].idTipoTransaccion;

                pa[1] = new SqlParameter("@idObjVenta", SqlDbType.Int);
                pa[1].Value = clsOtrasVentas.lstOtrasVenta[0].idObjVenta;

                pa[2] = new SqlParameter("@xmlDetalleVenta", SqlDbType.Xml);
                pa[2].Value = xmlData;

                pa[3] = new SqlParameter("@xmlTrandiaria", SqlDbType.Xml);
                pa[3].Value = xmlTrandiaria;

                pa[4] = new SqlParameter("@xmlDocumentoVenta", SqlDbType.Xml);
                pa[4].Value = xmlDocumentoDeVenta;

                pa[5] = new SqlParameter("@xmlActa", SqlDbType.Xml);
                pa[5].Value = clsOtrasVentas.lstOtrasVenta[0].idTipoTransaccion ==4 && clsOtrasVentas.lstOtrasVenta[0].idValida ==-1? xmlActaCambioTitularidad: xmlActaCambioVehicular;

                pa[6] = new SqlParameter("@idContratoAnterior", SqlDbType.Int);
                pa[6].Value = clsOtrasVentas.clsClienteAntecesor.idContrato;

                pa[7] = new SqlParameter("@idContratoNuevo", SqlDbType.Int);
                pa[7].Value = clsOtrasVentas.clsClienteDocumentoVenta.idContrato;

                pa[8] = new SqlParameter("@idClienteAntecesor", SqlDbType.Int);
                pa[8].Value = clsOtrasVentas.clsClienteAntecesor.idCliente;

                pa[9] = new SqlParameter("@idClienteNuevo", SqlDbType.Int);
                pa[9].Value = clsOtrasVentas.clsClienteDocumentoVenta.idCliente;

                pa[10] = new SqlParameter("@idVehiculo", SqlDbType.Int);
                pa[10].Value = clsOtrasVentas.clsVehiculo.idVehiculo;

                pa[11] = new SqlParameter("@idVehiculoProcesos", SqlDbType.Int);
                pa[11].Value = clsOtrasVentas.clsVehiculoProcesos.idVehiculo;

                pa[12] = new SqlParameter("@dFechaOperacion", SqlDbType.DateTime);
                pa[12].Value = clsOtrasVentas.dFechaOperacion;

                pa[13] = new SqlParameter("@dFechaRegistro", SqlDbType.DateTime);
                pa[13].Value = clsOtrasVentas.dFechaRegistro;

                pa[14] = new SqlParameter("@idUsuario", SqlDbType.Int);
                pa[14].Value = clsOtrasVentas.iddUsuario;

                pa[15] = new SqlParameter("@idMoneda", SqlDbType.Int);
                pa[15].Value = clsOtrasVentas.idMoneda;

                pa[16] = new SqlParameter("@peiTipoCon", SqlDbType.Int);
                pa[16].Value = tipoCon;

                pa[17] = new SqlParameter("@codigoDocumentoVentaTC", SqlDbType.NVarChar,8);
                pa[17].Value = clsOtrasVentas.CodDocumento;

                pa[18] = new SqlParameter("@idValida", SqlDbType.Int);
                pa[18].Value = clsOtrasVentas.lstOtrasVenta[0].idValida;
                
                pa[19] = new SqlParameter("@idEquipo", SqlDbType.Int);
                pa[19].Value = clsOtrasVentas.clsEquipoImeis.idEquipoImeis;

                pa[20] = new SqlParameter("@igvValor", SqlDbType.Money);
                pa[20].Value = clsOtrasVentas.lstXmlDocVenta[0].xmlDocumentoVenta[0].nIGV;

                pa[21] = new SqlParameter("@totalVenta", SqlDbType.Money);
                pa[21].Value = clsOtrasVentas.lstXmlDocVenta[0].xmlDocumentoVenta[0].nMontoTotal;

                pa[22] = new SqlParameter("@countItems", SqlDbType.Int);
                pa[22].Value = clsOtrasVentas.lstDetalleVenta.Count;

                objCnx = new clsConexion("");
                intRowsAffected = objCnx.EjecutarProcedimiento("uspGuardarOtrasVentas", pa);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }
        //MOD ADD//
        //public DataTable daListarDocumentoventa(Int32 codVenta)
        //{
        //    SqlParameter[] pa = new SqlParameter[4];
        //    DataTable dtDocVenta = new DataTable();
        //    clsConexion objCnx = null;


        //    objUtil = new clsUtil();
          
           
        //    try
        //    {

        //        pa[0] = new SqlParameter("@codVenta", SqlDbType.NVarChar, 15);
        //        pa[0].Value = "";
        //        pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int);
        //        pa[1].Value = 0;
        //        pa[2] = new SqlParameter("@tipoTarifa", SqlDbType.Int);
        //        pa[2].Value = 0;
        //        pa[3] = new SqlParameter("@idContrato", SqlDbType.Int);
        //        pa[3].Value = codVenta;


        //        objCnx = new clsConexion("");
        //        dtDocVenta = objCnx.EjecutarProcedimientoDT("uspBuscarDocumentoVentas", pa);

             
        //    }
        //    catch (Exception ex)
        //    {
               
        //    }
        //    finally
        //    {
        //        if (objCnx != null)
        //            objCnx.CierraConexion();
        //        objCnx = null;
        //    }
        //}
        public xmlDocumentoVentaGeneral daBuscarDocumentoVenta(Int32 codVenta)
        {
            SqlParameter[] pa = new SqlParameter[4];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            DataTable dtDocumento = new DataTable();
            xmlDocumentoVentaGeneral lstDocumentoVenta = new xmlDocumentoVentaGeneral();
            String xmlDocventa = "";
            //string xmlData = clsUtil.Serialize(lstOtrasVentas);
            try
            {

                pa[0] = new SqlParameter("@codVenta", SqlDbType.NVarChar,15);
                pa[0].Value = "";
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[1].Value = 0;
                pa[2] = new SqlParameter("@tipoTarifa", SqlDbType.Int);
                pa[2].Value = 0;
                pa[3] = new SqlParameter("@idContrato", SqlDbType.Int);
                pa[3].Value = codVenta;


                objCnx = new clsConexion("");
                dtDocumento = objCnx.EjecutarProcedimientoDT("uspBuscarDocumentoVentas", pa);
               
                foreach (DataRow drMenu in dtDocumento.Rows)
                {
                    xmlDocventa = Convert.ToString(drMenu["Documentoventa"]);

                }
                lstDocumentoVenta = clsUtil.Deserialize<xmlDocumentoVentaGeneral>(xmlDocventa);
                return lstDocumentoVenta;
            }
            catch (Exception ex)
            {
                return lstDocumentoVenta;
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }

        public xmlActaTitularidad daBuscarActaCambio(Int32 idContrato ,Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            DataTable dtDocumento = new DataTable();
            xmlActaTitularidad lstActaCambio = new xmlActaTitularidad();
            String xmlActaCambio = "";
            //string xmlData = clsUtil.Serialize(lstOtrasVentas);
            try
            {

                pa[0] = new SqlParameter("@idContrato", SqlDbType.Int);
                pa[0].Value = idContrato;
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[1].Value = tipoCon;
               


                objCnx = new clsConexion("");
                dtDocumento = objCnx.EjecutarProcedimientoDT("uspBuscarActaCambioTit_Vehi", pa);

                foreach (DataRow drMenu in dtDocumento.Rows)
                {
                    xmlActaCambio = Convert.ToString(drMenu["actaCambio"]);

                }
                lstActaCambio = clsUtil.Deserialize<xmlActaTitularidad>(xmlActaCambio);
                return lstActaCambio;
            }
            catch (Exception ex)
            {
                return lstActaCambio;
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }
        public xmlActaCambioVehicular daBuscarActaCambioVehicular(Int32 idContrato ,Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            DataTable dtDocumento = new DataTable();
            xmlActaCambioVehicular lstActaCambio = new xmlActaCambioVehicular();
            String xmlActaCambio = "";
            //string xmlData = clsUtil.Serialize(lstOtrasVentas);
            try
            {

                pa[0] = new SqlParameter("@idContrato", SqlDbType.Int);
                pa[0].Value = idContrato;
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[1].Value = tipoCon;
               


                objCnx = new clsConexion("");
                dtDocumento = objCnx.EjecutarProcedimientoDT("uspBuscarActaCambioTit_Vehi", pa);

                foreach (DataRow drMenu in dtDocumento.Rows)
                {
                    xmlActaCambio = Convert.ToString(drMenu["actaCambio"]);

                }
                lstActaCambio = clsUtil.Deserialize<xmlActaCambioVehicular>(xmlActaCambio);
                return lstActaCambio;
            }
            catch (Exception ex)
            {
                return lstActaCambio;
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }
        public xmlDocumentoVentaGeneral daBuscarDocumentoVentaGeneral(String codVenta,Int32 idTipoCon, Int32 idTipoTarifa,Int32 idContrato)
        {
            SqlParameter[] pa = new SqlParameter[4];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            DataTable dtDocumento = new DataTable();
            xmlDocumentoVentaGeneral lstDocumentoVenta = new xmlDocumentoVentaGeneral();
            String xmlDocventa = "";
            String codigoDocumento = "";
            String DescripEstadoPP = "";
            String PlacaVehiculos = "";
            String Cdirrecion = "";
            String Cliente = "";
            String TipoPago = "";
            String character = ",";
            //string xmlData = clsUtil.Serialize(lstOtrasVentas);
            try
            {

                pa[0] = new SqlParameter("@codVenta", SqlDbType.VarChar, 20);
                pa[0].Value = codVenta;
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[1].Value = idTipoCon;
                pa[2] = new SqlParameter("@tipoTarifa", SqlDbType.Int);
                pa[2].Value = idTipoTarifa;
                pa[3] = new SqlParameter("@idContrato", SqlDbType.Int);
                pa[3].Value = idContrato;


                objCnx = new clsConexion("");
                dtDocumento = objCnx.EjecutarProcedimientoDT("uspBuscarDocumentoVentas", pa);

                foreach (DataRow drMenu in dtDocumento.Rows)
                {
                    DescripEstadoPP = Convert.ToString(drMenu["descripcionEstadoVenta"]).ToLower();
                    codigoDocumento = Convert.ToString(drMenu["codDocumentoCorrelativo"]);
                    xmlDocventa = Convert.ToString(drMenu["Documentoventa"]);
                    PlacaVehiculos = Convert.ToString(drMenu["Vehiculos"]).ToString().Remove(Convert.ToString(drMenu["Vehiculos"]).ToString().ToString().LastIndexOf(character), character.Length);
                    Cdirrecion = Convert.ToString(drMenu["direccionRespPago"]).ToString();
                    Cliente = Convert.ToString(drMenu["cCliente"]).ToString();
                    TipoPago = Convert.ToString(drMenu["tipoPago"]).ToString();

                }
                lstDocumentoVenta = clsUtil.Deserialize<xmlDocumentoVentaGeneral>(xmlDocventa);
                lstDocumentoVenta.xmlDocumentoVenta[0].cDescripEstadoPP = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(DescripEstadoPP);
                //lstDocumentoVenta.xmlDocumentoVenta[0].cVehiculos = PlacaVehiculos;
                lstDocumentoVenta.xmlDocumentoVenta[0].cCodDocumentoVenta = codigoDocumento;
                //lstDocumentoVenta.xmlDocumentoVenta[0].cCliente = Cliente;
                lstDocumentoVenta.xmlDocumentoVenta[0].cDescripcionTipoPago = TipoPago;
                lstDocumentoVenta.xmlDocumentoVenta[0].cDireccion = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Cdirrecion);

                return lstDocumentoVenta;
            }
            catch (Exception ex)
            {
                return lstDocumentoVenta;
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }

        public List<Cargo> daDevolverTablaCod(String cCodTab,Int32 idTipoDocPers, Int32 Busqueda)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecCodTab", SqlDbType.NVarChar, 8);
                pa[0].Value = cCodTab;
                pa[1] = new SqlParameter("@idTipoDoc", SqlDbType.Int);
                pa[1].Value = idTipoDocPers;
                pa[2] = new SqlParameter("@TipoBusqueda", SqlDbType.Int);
                pa[2].Value = Busqueda;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarTiposDocumentoEmitir", pa);

                List<Cargo> lstCargo = new List<Cargo>();
                String strTipo = Busqueda == 0 ? "Seleccione opcion" : "TODOS";
                lstCargo.Add(new Cargo(
                        Convert.ToString("0"),
                        Convert.ToString(strTipo),
                        Convert.ToString("1")));
                if (idTipoDocPers!= 0)
                {
                    foreach (DataRow drMenu in dtUsuario.Rows)
                    {
                        lstCargo.Add(new Cargo(
                            Convert.ToString(drMenu["cCodTab"]),
                            Convert.ToString(drMenu["cNomTab"]),
                            Convert.ToString(drMenu["cValor"])));
                    }
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
        public Double daDevolverIgv(String cCodTab)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            Double igv = 0;

            try
            {

                pa[0] = new SqlParameter("@pecCodTab", SqlDbType.NVarChar, 8);
                pa[0].Value = cCodTab;
              


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspDevolverIGV", pa);

                    foreach (DataRow drMenu in dtUsuario.Rows)
                    {
                        igv =Convert.ToDouble(drMenu["cValor"]);
                    }



                return igv;

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

        public DataTable daBuscarCliente(String nroDocumento, String estCliente,Int32 idVehiculo, Int32 tipoCon)
        {

            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtCliente;
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peNroDocumento", SqlDbType.NVarChar, 15) { Value = nroDocumento };
                pa[1] = new SqlParameter("@peEstadoCliente", SqlDbType.NVarChar, 15) { Value = estCliente };
                pa[2] = new SqlParameter("@idVehiculo", SqlDbType.Int) { Value = idVehiculo };
                pa[3] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = tipoCon };

                objCnx = new clsConexion("");
                dtCliente = objCnx.EjecutarProcedimientoDT("uspBuscarDatosOtrasVenta", pa);

                return dtCliente;

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
                dtCliente = null;
            }

        }
        public DataTable daListarClienteOtrasVentas(Int32 idCliente, Int32 id2, Int32 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtUsuario;
            clsConexion objCnx = null;
            Cliente lstCliente;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidCliente", SqlDbType.Int) { Value = idCliente };
                pa[1] = new SqlParameter("@id2", SqlDbType.Int) { Value = id2 };
                pa[2] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = pnTipoCon };

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarClienteOtrasVentas", pa);

                //lstCliente = new Cliente();
                

                return dtUsuario;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daListarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstCliente = null;
            }

        }

    }
}
