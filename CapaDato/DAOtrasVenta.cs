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
            SqlParameter[] pa = new SqlParameter[6];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<Equipo> lstEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@idTipoVenta", SqlDbType.VarChar, 8);
                pa[1].Value = lsTipoVenta[0].idTipoVenta;
                pa[2] = new SqlParameter("@idMarca", SqlDbType.Int);
                pa[2].Value = lsTipoVenta[0].idMarca;
                pa[3] = new SqlParameter("@idModelo", SqlDbType.Int);
                pa[3].Value = lsTipoVenta[0].idModelo;
                pa[4] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[4].Value = numPaginacion;
                pa[5] = new SqlParameter("@peiTipoConPagima", SqlDbType.Int);
                pa[5].Value = tipocon;


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

        public DataTable daListarVentas(Int32 idDocumento, String pcBusqueda, Boolean activarFechas, DateTime fechaInicio, DateTime fechaFin,Int32 pagInicio,Int32 TipoConPagina)
        {
            SqlParameter[] pa = new SqlParameter[7];
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
                pa[2] = new SqlParameter("@activaFecha", SqlDbType.Int);
                pa[2].Value = activarFechas;
                pa[3] = new SqlParameter("@dFechaIn", SqlDbType.DateTime);
                pa[3].Value = fechaInicio;
                pa[4] = new SqlParameter("@dFechaFin", SqlDbType.DateTime);
                pa[4].Value = fechaFin;
                pa[5] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[5].Value = pagInicio;
                pa[6] = new SqlParameter("@peiTipoConPagina", SqlDbType.Int);
                pa[6].Value = TipoConPagina;

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
        public DataTable daDevolverTipoVenta(String TipoVenta, Int32 idObjVenta)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idTipoVenta", SqlDbType.VarChar, 8);
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

        public Boolean daGuardarOtrasVenta(List<OtrasVentas> lstOtrasVentas, List<Pagos> lstPagos, List<xmlDocumentoVenta> xmlDocumentoVenta, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[4];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            int intRowsAffected = 0;
            string xmlData = clsUtil.Serialize(lstOtrasVentas);
            string xmlTrandiaria = clsUtil.Serialize(lstPagos);
            string xmlDocumentoDeVenta = clsUtil.Serialize(xmlDocumentoVenta);
            try
            {

                pa[0] = new SqlParameter("@xmlData", SqlDbType.Xml);
                pa[0].Value = xmlData;
                pa[1] = new SqlParameter("@xmlTrandiaria", SqlDbType.Xml);
                pa[1].Value = xmlTrandiaria;
                pa[2] = new SqlParameter("@xmlDocumentoDeVenta", SqlDbType.Xml);
                pa[2].Value = xmlDocumentoDeVenta;
                pa[3] = new SqlParameter("@peiTipoCon", SqlDbType.Int);
                pa[3].Value = tipoCon;

                objCnx = new clsConexion("");
                intRowsAffected=objCnx.EjecutarProcedimiento("uspGuardarOtrasVentas", pa);
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

        public xmlDocumentoVenta daBuscarDocumentoVenta(String codVenta)
        {
            SqlParameter[] pa = new SqlParameter[2];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            DataTable dtDocumento = new DataTable();
           xmlDocumentoVenta lstDocumentoVenta = new xmlDocumentoVenta();
            String xmlDocventa = "";
            //string xmlData = clsUtil.Serialize(lstOtrasVentas);
            try
            {

                pa[0] = new SqlParameter("@codVenta", SqlDbType.VarChar,8);
                pa[0].Value = codVenta;
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[1].Value = 0;


                objCnx = new clsConexion("");
                dtDocumento = objCnx.EjecutarProcedimientoDT("uspBuscarDocumentoVentas", pa);
               
                foreach (DataRow drMenu in dtDocumento.Rows)
                {
                    xmlDocventa = Convert.ToString(drMenu["Documentoventa"]);

                }
                lstDocumentoVenta = clsUtil.Deserialize<xmlDocumentoVenta>(xmlDocventa);
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

                pa[0] = new SqlParameter("@codVenta", SqlDbType.VarChar, 8);
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
                lstDocumentoVenta.xmlDocumentoVenta[0].cVehiculos = PlacaVehiculos;
                lstDocumentoVenta.xmlDocumentoVenta[0].cCodDocumentoVenta = codigoDocumento;
                lstDocumentoVenta.xmlDocumentoVenta[0].cCliente = Cliente;
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

    }
}
