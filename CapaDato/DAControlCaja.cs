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
    public class DAControlCaja
    {
        public DAControlCaja() { }
        clsUtil objUtil;
        public List<ControlCaja> daFnLlenarTipoPago(Int32 idTipPlan,String id, Boolean estado)
        {
            SqlParameter[] pa = new SqlParameter[2];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@codTipoPago", SqlDbType.VarChar) { Value = id };
                pa[1] = new SqlParameter("@idTipPlan", SqlDbType.Int) { Value =  idTipPlan };
                objCnx = new clsConexion("");

                dt = objCnx.EjecutarProcedimientoDT("uspListarTipoPaPago", pa);

                lstControl.Add(new ControlCaja
                {
                    codTipoPago = "0",
                    descripTipoPago =Convert.ToString(estado == true ? "TODOS" : "Selec. Opcion"),
                    estado=false

                }); 

                foreach (DataRow d in dt.Rows)
                {
                    lstControl.Add(new ControlCaja
                    {
                        codTipoPago=d["cCodTab"].ToString(),
                        descripTipoPago=d["cNomTab"].ToString(),
                        estado=Convert.ToBoolean(d["bEstado"])
                    });

                }
                return lstControl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public DataTable daFnBuscarVentasCaja(Busquedas clsBus)
        {
            SqlParameter[] pa = new SqlParameter[12];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@chkHabilitarFecha", SqlDbType.TinyInt) { Value = clsBus.chkActivarFechas }; 
                pa[1] = new SqlParameter("@chkDiaEspecifico", SqlDbType.TinyInt) { Value = clsBus.chkActivarDia }; 
                pa[2] = new SqlParameter("@dtFechaIni", SqlDbType.Date) { Value = clsBus.dtFechaIni };
                pa[3] = new SqlParameter("@dtFechaFin", SqlDbType.Date) { Value = clsBus.dtFechaFin };
                pa[4] = new SqlParameter("@codTipoReporte", SqlDbType.VarChar) { Value = clsBus.cod1 };
                pa[5] = new SqlParameter("@codTipoOperacion", SqlDbType.VarChar) { Value = clsBus.cod2 };
                pa[6] = new SqlParameter("@codTipoPago", SqlDbType.VarChar) { Value = clsBus.cod3 };
                pa[7] = new SqlParameter("@idEntidadPago", SqlDbType.Int) { Value = clsBus.cod4 };
                pa[8] = new SqlParameter("@cBuscar", SqlDbType.VarChar) { Value = clsBus.cBuscar }; 
                pa[9] = new SqlParameter("@numPagina", SqlDbType.VarChar) { Value = clsBus.numPagina }; 
                pa[10] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = clsBus.tipoCon }; 
                pa[11] = new SqlParameter("@idUsuario", SqlDbType.TinyInt) { Value = clsBus.idUsuario }; 

                 objCnx = new clsConexion("");

                return dt = objCnx.EjecutarProcedimientoDT("uspBuscarDetalleReporteVentas", pa);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public Tuple<List<ReporteBloque>,List<ReporteBloque>> daBuscarReporteGeneralVentas(Busquedas clsBusq)
        {
            SqlParameter[] pa = new SqlParameter[12];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataSet dtMenu = new DataSet();
            List<ReporteBloque> lsDasboard = new List<ReporteBloque>();
            List<ReporteBloque> lsRepBloque = new List<ReporteBloque>();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@dtFechaIni", SqlDbType.Date) { Value = clsBusq.dtFechaIni };
                pa[1] = new SqlParameter("@dtFechaFin", SqlDbType.Date) { Value = clsBusq.dtFechaFin };
                pa[2] = new SqlParameter("@codTipoReporte", SqlDbType.VarChar) { Value = clsBusq.cod1 };
                pa[3] = new SqlParameter("@codTipoOperacion", SqlDbType.VarChar) { Value = clsBusq.cod2 };
                pa[4] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsBusq.cod3 };
                pa[5] = new SqlParameter("@codSubConsulta", SqlDbType.VarChar) { Value = clsBusq.cod4 };
                pa[6] = new SqlParameter("@idTipoTarifa", SqlDbType.Int) { Value = 0 };
                pa[7] = new SqlParameter("@cBuscar", SqlDbType.VarChar) { Value = clsBusq.cBuscar }; 
                pa[8] = new SqlParameter("@numPagina", SqlDbType.VarChar) { Value = clsBusq.numPagina }; 
                pa[9] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = clsBusq.tipoCon }; 
                pa[10] = new SqlParameter("@chkHabilitarFecha", SqlDbType.TinyInt) { Value = clsBusq.chkActivarFechas }; 
                pa[11] = new SqlParameter("@chkDiaEspecifico", SqlDbType.TinyInt) { Value = clsBusq.chkActivarDia }; 

                 objCnx = new clsConexion("");

                dtMenu = objCnx.EjecutarProcedimientoDS("uspBuscarDashBoard", pa);
                if (clsBusq.cod1.Length>5)
                {
                    //DataView dvDasboard = new DataView(dtMenu.Tables[0]);
                    DataView dvParatablas = new DataView(dtMenu.Tables[1]);

                    //foreach (DataRowView dr in dvDasboard)
                    //{
                    //    lsDasboard.Add(new ReporteBloque
                    //    {
                    //        Codigoreporte = dr["id"].ToString(),
                    //        Detallereporte = dr["descripcion"].ToString(),
                    //        Cantidad = Convert.ToInt32(dr["cantidad"]),
                    //        idMoneda = Convert.ToInt32(dr["idMoneda"]),
                    //        SimboloMoneda = dr["cSimbolo"].ToString(),
                    //        ImporteTipoCambio = Convert.ToDouble(dr["cTipoCambio"]),
                    //        ImporteRow = Convert.ToDouble(dr["montoTotal"])
                    //    });
                    //}
                    foreach (DataRowView dr in dvParatablas)
                    {
                        lsRepBloque.Add(new ReporteBloque
                        {
                            Codigoreporte = dr["id"].ToString(),
                            Detallereporte = FormatearCadenaTitleCase(dr["descripcion"].ToString()),
                            Cantidad = Convert.ToInt32(dr["cantidad"]),
                            idMoneda = Convert.ToInt32(dr["idMoneda"]),
                            SimboloMoneda = dr["cSimbolo"].ToString(),
                            ImporteTipoCambio = Convert.ToDecimal(dr["cTipoCambio"]),
                            ImporteRow = Convert.ToDecimal(dr["montoTotal"])
                        });

                    }
                }
               

                return Tuple.Create(lsDasboard, lsRepBloque);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }

        public Tuple<List<ReporteBloque>,List<ReporteBloque>> daBuscarDashBoard(Busquedas clsBusq)
        {
            SqlParameter[] pa = new SqlParameter[12];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataSet dtMenu = new DataSet();
            List<ReporteBloque> lsDasboard = new List<ReporteBloque>();
            List<ReporteBloque> lsRepBloque = new List<ReporteBloque>();
            List<ReporteBloque> lstEgresos= new List<ReporteBloque>();
            List<ReporteBloque> lstCajaChica= new List<ReporteBloque>();
            DataView dvEgresos = new DataView();
            DataView dvCajaChica = new DataView();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@dtFechaIni", SqlDbType.Date) { Value = clsBusq.dtFechaIni };
                pa[1] = new SqlParameter("@dtFechaFin", SqlDbType.Date) { Value = clsBusq.dtFechaFin };
                pa[2] = new SqlParameter("@codTipoReporte", SqlDbType.VarChar) { Value = clsBusq.cod1 };
                pa[3] = new SqlParameter("@codTipoOperacion", SqlDbType.VarChar) { Value = clsBusq.cod2 };
                pa[4] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsBusq.cod3 };
                pa[5] = new SqlParameter("@codSubConsulta", SqlDbType.VarChar) { Value = clsBusq.cod4 };
                pa[6] = new SqlParameter("@idTipoTarifa", SqlDbType.Int) { Value = 0 };
                pa[7] = new SqlParameter("@cBuscar", SqlDbType.VarChar) { Value = clsBusq.cBuscar }; 
                pa[8] = new SqlParameter("@numPagina", SqlDbType.VarChar) { Value = clsBusq.numPagina }; 
                pa[9] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = clsBusq.tipoCon }; 
                pa[10] = new SqlParameter("@chkHabilitarFecha", SqlDbType.TinyInt) { Value = clsBusq.chkActivarFechas }; 
                pa[11] = new SqlParameter("@chkDiaEspecifico", SqlDbType.TinyInt) { Value = clsBusq.chkActivarDia }; 

                 objCnx = new clsConexion("");

                dtMenu = objCnx.EjecutarProcedimientoDS("uspBuscarDashBoard", pa);
                dvCajaChica = new DataView(dtMenu.Tables[0]);
                
                
                foreach (DataRowView dr in dvCajaChica)
                {
                    lstCajaChica.Add(new ReporteBloque
                    {
                        Codigoreporte = Convert.ToString(dr["id"]),
                        codAuxiliar = Convert.ToString(dr["codigoValida"]),
                        Detallereporte = FormatearCadenaTitleCase(dr["nomCajaChica"].ToString()),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        idMoneda = Convert.ToInt32(dr["idMoneda"]),
                        SimboloMoneda = Convert.ToInt32(dr["idMoneda"])==1?"S/.":"$/.",
                        ImporteTipoCambio = Convert.ToDecimal(dr["cTipoCambio"]),
                        ImporteRow = Convert.ToDecimal(dr["montoTotal"]),

                    });
                }

                List<ReporteBloque> lstCH = new List<ReporteBloque>();
                lstCH.Add(lstCajaChica.Find(i => i.Codigoreporte == "TEGR0003"));
                if (lstCH[0] is null)
                {
                    lstCajaChica.Add(new ReporteBloque
                    {
                        Codigoreporte = "TEGR0003",
                        codAuxiliar = "",
                        Detallereporte = FormatearCadenaTitleCase("Caja chica"),
                        Cantidad = 0,
                        idMoneda = Convert.ToInt32(1),
                        SimboloMoneda = "S/.",
                        ImporteTipoCambio = Convert.ToDecimal(0.20),
                        ImporteRow = Convert.ToDecimal(0)
                    });
                }
               
                
                if (clsBusq.cod1.Length>5)
                {
                    DataView dvParatablas = new DataView(dtMenu.Tables[1]);

                    
                    foreach (DataRowView dr in dvParatablas)
                    {
                        lsRepBloque.Add(new ReporteBloque
                        {
                            Codigoreporte = dr["id"].ToString(),
                            Detallereporte = FormatearCadenaTitleCase(dr["descripcion"].ToString()),
                            Cantidad = Convert.ToInt32(dr["cantidad"]),
                            idMoneda = Convert.ToInt32(dr["idMoneda"]),
                            SimboloMoneda = dr["cSimbolo"].ToString(),
                            ImporteTipoCambio = Convert.ToDecimal(dr["cTipoCambio"]),
                            ImporteRow = Convert.ToDecimal(dr["montoTotal"])
                        });

                    }
                }
                

                return Tuple.Create( lsRepBloque, lstCajaChica);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public Tuple<List<ReporteBloque>,List<ReporteBloque>, List<ReporteBloque>> daBuscarReporteDiario(Busquedas clsBusq)
        {
            SqlParameter[] pa = new SqlParameter[3];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataSet dtMenu = new DataSet();
            List<ReporteBloque> lsCategoria = new List<ReporteBloque>();
            List<ReporteBloque> lsOperacion = new List<ReporteBloque>();
            List<ReporteBloque> lsMedioPago= new List<ReporteBloque>();

            DataView dvBusquedaPorCategoria = new DataView();
            DataView dvBusquedaPorOperacion = new DataView();
            DataView dvBusquedaPorMedioPago = new DataView();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                
                pa[0] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsBusq.cod3 };
                pa[1] = new SqlParameter("@dtFechaBusqueda", SqlDbType.Date) { Value = clsBusq.dtFechaIni };
                pa[2] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = clsBusq.tipoCon };                 

                 objCnx = new clsConexion("");

                dtMenu = objCnx.EjecutarProcedimientoDS("uspBuscarReporteDiario", pa);
                dvBusquedaPorCategoria = new DataView(dtMenu.Tables[0]);
                dvBusquedaPorOperacion = new DataView(dtMenu.Tables[1]);
                dvBusquedaPorMedioPago = new DataView(dtMenu.Tables[2]);
                int y = 0;
                foreach (DataRowView dr in dvBusquedaPorCategoria)
                {
                    lsCategoria.Add(new ReporteBloque
                    {
                        numero = y + 1,
                        Codigoreporte = dr["id"].ToString(),
                        Detallereporte = FormatearCadenaTitleCase(dr["descripcion"].ToString()),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        idMoneda = Convert.ToInt32(dr["idMoneda"]),
                        SimboloMoneda = dr["cSimbolo"].ToString(),
                        ImporteTipoCambio = Convert.ToDecimal(dr["cTipoCambio"]),
                        ImporteRow = Convert.ToDecimal(dr["montoTotal"])
                    });
                    y++;
                }

                y = 0;
                foreach (DataRowView dr in dvBusquedaPorOperacion)
                {
                    lsOperacion.Add(new ReporteBloque
                    {
                        numero = y + 1,
                        Codigoreporte = dr["id"].ToString(),
                        Detallereporte = FormatearCadenaTitleCase(dr["descripcion"].ToString()),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        idMoneda = Convert.ToInt32(dr["idMoneda"]),
                        SimboloMoneda = dr["cSimbolo"].ToString(),
                        ImporteTipoCambio = Convert.ToDecimal(dr["cTipoCambio"]),
                        ImporteRow = Convert.ToDecimal(dr["montoTotal"])
                    });
                    y++;
                }
                y = 0;
                foreach (DataRowView dr in dvBusquedaPorMedioPago)
                {
                    lsMedioPago.Add(new ReporteBloque
                    {
                        numero=y+1,
                        Codigoreporte = dr["id"].ToString(),
                        Detallereporte = FormatearCadenaTitleCase(dr["descripcion"].ToString()),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        idMoneda = Convert.ToInt32(dr["idMoneda"]),
                        SimboloMoneda = dr["cSimbolo"].ToString(),
                        ImporteTipoCambio = Convert.ToDecimal(dr["cTipoCambio"]),
                        ImporteRow = Convert.ToDecimal(dr["montoTotal"])
                    });
                    y++;
                }
                


                return Tuple.Create(lsCategoria, lsOperacion, lsMedioPago);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public List<ReporteBloque> daBuscarEgresos(Busquedas clsBusq)
        {
            SqlParameter[] pa = new SqlParameter[13];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataSet dtMenu = new DataSet();
            List<ReporteBloque> lsDasboard = new List<ReporteBloque>();
            List<ReporteBloque> lsRepBloque = new List<ReporteBloque>();
            List<ReporteBloque> lstEgresos= new List<ReporteBloque>();
            List<ReporteBloque> lstCajaChica= new List<ReporteBloque>();
            DataView dvEgresos = new DataView();
            DataView dvCajaChica = new DataView();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@dtFechaIni", SqlDbType.Date) { Value = clsBusq.dtFechaIni };
                pa[1] = new SqlParameter("@dtFechaFin", SqlDbType.Date) { Value = clsBusq.dtFechaFin };
                pa[2] = new SqlParameter("@codTipoReporte", SqlDbType.VarChar) { Value = clsBusq.cod1 };
                pa[3] = new SqlParameter("@codTipoOperacion", SqlDbType.VarChar) { Value = clsBusq.cod2 };
                pa[4] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsBusq.cod3 };
                pa[5] = new SqlParameter("@codSubConsulta", SqlDbType.VarChar) { Value = clsBusq.cod4 };
                pa[6] = new SqlParameter("@idTipoTarifa", SqlDbType.Int) { Value = 0 };
                pa[7] = new SqlParameter("@cBuscar", SqlDbType.VarChar) { Value = clsBusq.cBuscar }; 
                pa[8] = new SqlParameter("@numPagina", SqlDbType.VarChar) { Value = clsBusq.numPagina }; 
                pa[9] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = clsBusq.tipoCon }; 
                pa[10] = new SqlParameter("@chkHabilitarFecha", SqlDbType.TinyInt) { Value = clsBusq.chkActivarFechas }; 
                pa[11] = new SqlParameter("@chkDiaEspecifico", SqlDbType.TinyInt) { Value = clsBusq.chkActivarDia }; 
                pa[12] = new SqlParameter("@dFechaActual", SqlDbType.DateTime) { Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm") }; 

                 objCnx = new clsConexion("");

                dtMenu = objCnx.EjecutarProcedimientoDS("uspBuscarEgresos", pa);           
                dvEgresos= new DataView(dtMenu.Tables[0]);

                foreach (DataRowView dr in dvEgresos)
                {
                    lstEgresos.Add(new ReporteBloque
                    {
                        Codigoreporte = dr["id"].ToString(),
                        Detallereporte = FormatearCadenaTitleCase(dr["descripcion"].ToString()),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        idMoneda = Convert.ToInt32(dr["idMoneda"]),
                        codAuxiliar = FormatearCadenaTitleCase(Convert.ToString(dr["fuente"])),
                        codAuxiliar1 = Convert.ToString(dr["codAuxiliar"]),
                        SimboloMoneda = dr["cSimbolo"].ToString(),
                        ImporteTipoCambio = Convert.ToDecimal(dr["cTipoCambio"]),
                        ImporteRow = Convert.ToDecimal(dr["montoTotal"]),
                        MasDetallereporte= Convert.ToString(dr["masDetalle"]),
                    });

                }



                return lstEgresos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }

        public List<ReporteBloque> daDetalleParaCuadre(Busquedas clsBusq,List<ReporteBloque> lstRep)
        {
            SqlParameter[] pa = new SqlParameter[13];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataSet dtMenu = new DataSet();
            List<ReporteBloque> lsDasboard = new List<ReporteBloque>();
            DataView dvEgresos = new DataView();
            clsConexion objCnx = null;
            String xmlDatos= clsUtil.Serialize(lstRep);
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@dtFechaIni", SqlDbType.DateTime) { Value = clsBusq.dtFechaIni };
                pa[1] = new SqlParameter("@dtFechaFin", SqlDbType.Date) { Value = clsBusq.dtFechaFin };
                pa[2] = new SqlParameter("@codTipoReporte", SqlDbType.VarChar) { Value = clsBusq.cod1 };
                pa[3] = new SqlParameter("@codTipoOperacion", SqlDbType.VarChar) { Value = clsBusq.cod2 };
                pa[4] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsBusq.cod3 };
                pa[5] = new SqlParameter("@codSubConsulta", SqlDbType.VarChar) { Value = clsBusq.cod4 };
                pa[6] = new SqlParameter("@idTipoTarifa", SqlDbType.Int) { Value = 0 };
                pa[7] = new SqlParameter("@cBuscar", SqlDbType.VarChar) { Value = clsBusq.cBuscar }; 
                pa[8] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = clsBusq.tipoCon }; 
                pa[9] = new SqlParameter("@chkHabilitarFecha", SqlDbType.TinyInt) { Value = clsBusq.chkActivarFechas }; 
                pa[10] = new SqlParameter("@chkDiaEspecifico", SqlDbType.TinyInt) { Value = clsBusq.chkActivarDia }; 
                pa[11] = new SqlParameter("@xmlDatos", SqlDbType.Xml) { Value = xmlDatos };
                pa[12] = new SqlParameter("@dFechaActual", SqlDbType.DateTime) { Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm") };
                objCnx = new clsConexion("");

                dtMenu = objCnx.EjecutarProcedimientoDS("uspBuscarDetalleParaCuadreCaja", pa);

               DataView dvDasboard = new DataView(dtMenu.Tables[0]);
                Int32 y = 0;
                foreach (DataRowView dr in dvDasboard)
                {
                    lsDasboard.Add(new ReporteBloque
                    {
                        numero = y + 1,
                        Codigoreporte = dr["id"].ToString(),
                        Detallereporte = FormatearCadenaTitleCase(dr["descripcion"].ToString()),
                        codAuxiliar = dr["nomTipoPago"].ToString(),
                        idOperacion = Convert.ToInt32(dr["idOperacion"]),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        idMoneda = Convert.ToInt32(dr["idMoneda"]),
                        SimboloMoneda = dr["cSimbolo"].ToString(),
                        ImporteTipoCambio = Convert.ToDecimal(dr["cTipoCambio"]),
                        ImporteRow = Convert.ToDecimal(dr["montoTotal"]),
                        cUsuario = Convert.ToString(dr["IdUsuario"]),
                        //dFecha = Convert.ToDateTime(dr["dFechaRegistro"])
                    }) ;
                    y++;
                }
                



                return lsDasboard;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public List<CajaChica> daObtenerImporteCaja(String dtFecha, String fechaActual, Int32 idUsuario)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            List<CajaChica> lstImporte = new List<CajaChica>(); 

            try
            {
                pa[0] = new SqlParameter("@fechaBusqueda", SqlDbType.Date);
                pa[0].Value = dtFecha;
                pa[1] = new SqlParameter("@fechaActual", SqlDbType.Date);
                pa[1].Value = fechaActual;
                pa[2] = new SqlParameter("@idUsuario", SqlDbType.Int);
                pa[2].Value = idUsuario;


                objCnx = new clsConexion("");
                dtResult = objCnx.EjecutarProcedimientoDT("uspObtenerImporteEnCaja", pa);
                foreach (DataRow dt in dtResult.Rows)
                {
                    lstImporte.Add(new CajaChica
                    {
                        IdMoneda = 1,
                        Usuario = dt["Usuario"].ToString(),
                        importe = Convert.ToDecimal(dt["ImporteCaja"])
                    });
                }


                return lstImporte;

            }
            catch (Exception ex)
            {
                lstImporte = null;

                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstImporte = null;
            }

        }
        public List<ReporteBloque> daBuscarMovimientocaja(Busquedas clsBusq,Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[11];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataSet dtMenu = new DataSet();
            List<ReporteBloque> lsDasboard = new List<ReporteBloque>();
            DataView dvEgresos = new DataView();
            clsConexion objCnx = null;
            //String xmlDatos= clsUtil.Serialize(lstRep);
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@dtFechaIni", SqlDbType.Date) { Value = clsBusq.dtFechaIni };
                pa[1] = new SqlParameter("@dtFechaFin", SqlDbType.Date) { Value = clsBusq.dtFechaFin };
                pa[2] = new SqlParameter("@codTipoReporte", SqlDbType.VarChar) { Value = clsBusq.cod1 };
                pa[3] = new SqlParameter("@codTipoOperacion", SqlDbType.VarChar) { Value = clsBusq.cod2 };
                pa[4] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsBusq.cod3 };
                pa[5] = new SqlParameter("@codSubConsulta", SqlDbType.VarChar) { Value = clsBusq.cod4 };
                pa[6] = new SqlParameter("@idTipoTarifa", SqlDbType.Int) { Value = 0 };
                pa[7] = new SqlParameter("@cBuscar", SqlDbType.VarChar) { Value = clsBusq.cBuscar }; 
                pa[8] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = clsBusq.tipoCon }; 
                pa[9] = new SqlParameter("@chkHabilitarFecha", SqlDbType.TinyInt) { Value = clsBusq.chkActivarFechas }; 
                pa[10] = new SqlParameter("@chkDiaEspecifico", SqlDbType.TinyInt) { Value = clsBusq.chkActivarDia }; 
                //pa[11] = new SqlParameter("@xmlDatos", SqlDbType.Xml) { Value = xmlDatos }; 

                 objCnx = new clsConexion("");

                dtMenu = objCnx.EjecutarProcedimientoDS("uspBuscarMovimientoCaja", pa);

               DataView dvDasboard = new DataView(dtMenu.Tables[0]);
               DataView dvApertura = new DataView(dtMenu.Tables[0]);
                Int32 y = 0;
                foreach (DataRowView dr in dvDasboard)
                {
                    lsDasboard.Add(new ReporteBloque
                    {
                        numero =y+1,
                        Codigoreporte = dr["id"].ToString(),
                        Detallereporte = FormatearCadenaTitleCase(dr["descripcion"].ToString()),
                        cUsuario = FormatearCadenaTitleCase(dr["cUser"].ToString()),
                        codAuxiliar = Convert.ToString(Convert.ToDateTime(dr["dFechaRegistro"]).ToString("dd/MM/yyyy hh:mm tt")),                        
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        idMoneda = Convert.ToInt32(dr["idMoneda"]),
                        SimboloMoneda = dr["cSimbolo"].ToString(),
                        ImporteTipoCambio = Convert.ToDecimal(dr["cTipoCambio"]),
                        ImporteRow = Convert.ToDecimal(dr["montoTotal"])
                    });
                    y++;
                }
                



                return lsDasboard;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public List<xmlActaCierraCaja> daBuscarActaCierreCaja(Int32 id, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataSet dtMenu = new DataSet();
            List<xmlActaCierraCaja> lsActaCierre = new List<xmlActaCierraCaja>();
            xmlActaCierraCaja clsActaCierre = new xmlActaCierraCaja();
            DataView dvEgresos = new DataView();
            clsConexion objCnx = null;
            String xmlDocventa = "";
            //String xmlDatos= clsUtil.Serialize(lstRep);
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idTrandiaria", SqlDbType.Int) { Value = id };
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int) { Value = tipoCon };
              
                //pa[11] = new SqlParameter("@xmlDatos", SqlDbType.Xml) { Value = xmlDatos }; 

                 objCnx = new clsConexion("");

                dtMenu = objCnx.EjecutarProcedimientoDS("uspBuscarCierreCajaEspecifico", pa);

               DataView dvDasboard = new DataView(dtMenu.Tables[0]);
                Int32 y = 0;
                foreach (DataRowView dr in dvDasboard)
                {
                    xmlDocventa = Convert.ToString(dr["actaCierre"]);
                }
                clsActaCierre = clsUtil.Deserialize<xmlActaCierraCaja>(xmlDocventa);

                lsActaCierre.Add(clsActaCierre);

                return lsActaCierre;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public  string FormatearCadenaTitleCase(String str)
        {
            String dat = str.ToLower();
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dat); ;
        }

        public DataTable daDevolverSoloUsuario(Boolean chk, String dtI, String dtFin, Int32 tipCOn)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<Usuario> lstUsuario = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@dtInicio", SqlDbType.Date);
                pa[0].Value = dtI;
                pa[1] = new SqlParameter("@dtFin", SqlDbType.Date);
                pa[1].Value = dtFin;
                pa[2] = new SqlParameter("@chk", SqlDbType.Bit);
                pa[2].Value = chk;
                pa[3] = new SqlParameter("@tipoCOn", SqlDbType.Int);
                pa[3].Value = tipCOn;


                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarUsuariosConTrandiarias", pa);

                

                return dtVehiculo;

            }
            catch (Exception ex)
            {
                lstUsuario = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverClaseV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstUsuario = null;
            }

        }
    }
}
