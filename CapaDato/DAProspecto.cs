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
    public class DAProspecto
    {
        private clsUtil objUtil = null;
        public String daGrabarProspectoPlan(ProspectosPlan objProspecto, Int32 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[21];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String xmlVentas= clsUtil.Serialize(objProspecto.lstVentasSeleccionadas);

            try
            {
                pa[0] = new SqlParameter("@idProspectoPlan", SqlDbType.Int) { Value = objProspecto.idProspectoPlan };
                pa[1] = new SqlParameter("@idPropectos", SqlDbType.Int) { Value = objProspecto.idProspecto };
                pa[2] = new SqlParameter("@cNroCelular", SqlDbType.NVarChar, 15) { Value = objProspecto.celular1 };
                pa[3] = new SqlParameter("@cNroCelular2", SqlDbType.NVarChar, 15) { Value = objProspecto.celular2 };
                pa[4] = new SqlParameter("@cNombre", SqlDbType.NVarChar, 45) { Value = objProspecto.nombres };
                pa[5] = new SqlParameter("@cApellido", SqlDbType.NVarChar, 45) { Value = objProspecto.apellidos };
                pa[6] = new SqlParameter("@cCorreo", SqlDbType.NVarChar, 45) { Value = objProspecto.correo };
                pa[7] = new SqlParameter("@idUso", SqlDbType.Int) { Value = objProspecto.idModoUso };
                pa[8] = new SqlParameter("@cTipoContacto", SqlDbType.NVarChar, 15) { Value = objProspecto.idTipoContacto };
                pa[9] = new SqlParameter("@cObservacion", SqlDbType.NVarChar, 1000) { Value = objProspecto.observaciones };
                pa[10] = new SqlParameter("@idEquipo_Plan", SqlDbType.Int) { Value = objProspecto.idEquipo };
                pa[11] = new SqlParameter("@cCantidadEquipos", SqlDbType.Int) { Value = objProspecto.cantEquipos };
                pa[12] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = objProspecto.idUsuario };
                pa[13] = new SqlParameter("@dFechaRegistro", SqlDbType.DateTime) { Value = objProspecto.fechaRegistro };
                pa[14] = new SqlParameter("@peiTipoCon", SqlDbType.Int) { Value = pnTipoCon };
                pa[15] = new SqlParameter("@bEstado", SqlDbType.NVarChar, 15) { Value = objProspecto.estadoCliente};
                pa[16] = new SqlParameter("@idTipoPlan", SqlDbType.Int) { Value = objProspecto.idTipoPlan };
                pa[17] = new SqlParameter("@idPlan", SqlDbType.Int) { Value = objProspecto.idPlan };
                pa[18] = new SqlParameter("@fechaVisita", SqlDbType.DateTime) { Value = objProspecto.fechaVisita };
                pa[19] = new SqlParameter("@idTarifa", SqlDbType.Int) { Value = objProspecto.idTarifa };
                pa[20] = new SqlParameter("@xmlVentas", SqlDbType.Xml) {Value= xmlVentas };

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarProspectoPlan", pa);

                return "OK";
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daGrabarAccesorio", ex.Message);
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

        public DataTable daBuscarProspectoPlanDataTable(String pcBuscar,String celular, String estado, Int32 numPagina, Int32 tipoCon,String tipoContacto, String fechaInicial, String fechaFinal, Boolean habilitarFecha, Boolean fechaVisita, Boolean fechaRegistroSeg, Boolean fechaSigSeg,Int32 idUsuario,Int32 idTipoPlan,Int32 idPlan, Int32 idTarifa,String lColor , String fechaActual)
        {
            SqlParameter[] pa = new SqlParameter[18];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peBuscar", SqlDbType.VarChar, 45) { Value = pcBuscar };
                pa[1] = new SqlParameter("@peEstado", SqlDbType.NVarChar, 15) { Value = estado };
                pa[2] = new SqlParameter("@cTipoContacto", SqlDbType.NVarChar, 15) { Value = tipoContacto };
                pa[3] = new SqlParameter("@numPagina", SqlDbType.Int) { Value = numPagina };
                pa[4] = new SqlParameter("@tipoCon", SqlDbType.Real) { Value = tipoCon };
                pa[5] = new SqlParameter("@numCelular", SqlDbType.VarChar, 15) { Value = celular };
                pa[6] = new SqlParameter("@fechaInicial", SqlDbType.Date) { Value = fechaInicial };
                pa[7] = new SqlParameter("@fechaFinal", SqlDbType.Date) { Value = fechaFinal };
                pa[8] = new SqlParameter("@habilitarFecha", SqlDbType.TinyInt) { Value = habilitarFecha };
                pa[9] = new SqlParameter("@fechaVisita", SqlDbType.TinyInt) { Value = fechaVisita };
                pa[10] = new SqlParameter("@fechaRegSeg", SqlDbType.TinyInt) { Value = fechaRegistroSeg };
                pa[11] = new SqlParameter("@fechaSigSeg", SqlDbType.TinyInt) { Value = fechaSigSeg };
                pa[12] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = idUsuario };
                pa[13] = new SqlParameter("@idTipoPlan", SqlDbType.Int) { Value = idTipoPlan };
                pa[14] = new SqlParameter("@idPlan", SqlDbType.Int) { Value = idPlan };
                pa[15] = new SqlParameter("@idTipoTarifa", SqlDbType.Int) { Value = idTarifa };
                pa[16] = new SqlParameter("@LetraColor", SqlDbType.VarChar) { Value = lColor };
                pa[17] = new SqlParameter("@dFechaActual", SqlDbType.DateTime) { Value =fechaActual  };

                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspBuscarProspectoPlan", pa);

                return dtAccesorio;
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
        public DataTable daBuscarProspectoDataTable(String numCelular, String nombreCliente, Int32 numPagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@nombreCliente", SqlDbType.VarChar, 45);
                pa[0].Value = nombreCliente;
                pa[1] = new SqlParameter("@numCelular", SqlDbType.NVarChar, 15);
                pa[1].Value = numCelular;
                pa[2] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[2].Value = numPagina;
                pa[3] = new SqlParameter("@tipoCon", SqlDbType.Real);
                pa[3].Value = tipoCon;
                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspBuscarProspectoEspecifico", pa);

                return dtAccesorio;
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

        public ProspectosPlan daListarProspectoPlanDatatable(Int32 idCliente, Int32 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            ProspectosPlan lstProsp = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peIdProspecto", SqlDbType.Int);
                pa[0].Value = idCliente;
                pa[1] = new SqlParameter("@peTipoCon", SqlDbType.Int);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarProspectoPlan", pa);

                lstProsp = new ProspectosPlan();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstProsp.idProspectoPlan = Convert.ToInt32(drMenu["idProspectoPlan"]);
                    lstProsp.idProspecto = Convert.ToInt32(drMenu["idProspecto"]);
                    lstProsp.nombres = Convert.ToString(drMenu["cNombre"]);
                    lstProsp.apellidos = Convert.ToString(drMenu["cApellido"]);
                    lstProsp.celular1 = Convert.ToString(drMenu["cNroCelular1"]);
                    lstProsp.celular2 = Convert.ToString(drMenu["cNroCelular2"]);
                    lstProsp.estadoCliente = Convert.ToString(drMenu["bEstadoCliente"]);
                    lstProsp.correo = Convert.ToString(drMenu["cCorreo"]);
                    lstProsp.idClase = Convert.ToInt32(drMenu["idClaseV"]);
                    lstProsp.idModoUso = Convert.ToInt32(drMenu["idUso"]);
                    lstProsp.idTipoContacto = Convert.ToString(drMenu["cTipoContacto"]);
                    lstProsp.observaciones = Convert.ToString(drMenu["cObservacion"]);
                    lstProsp.idTipoPlan = Convert.ToInt32(drMenu["idTipoPlan"]);
                    lstProsp.idPlan = Convert.ToInt32(drMenu["idPlan"]);
                    lstProsp.idEquipo = Convert.ToInt32(drMenu["idEquipoPlan"]);
                    lstProsp.cantEquipos = Convert.ToInt32(drMenu["cCanEquipos"]);
                    lstProsp.fechaVisita = Convert.ToDateTime(drMenu["dFechaVisita"]);
                    lstProsp.nombreUsuario = Convert.ToString(drMenu["cUser"]);
                    lstProsp.idTarifa = Convert.ToInt32(drMenu["idTarifa"]);
                }

                return lstProsp;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daListarEquipo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstProsp = null;
            }
        }
        public List<Reporte> daBuscarReporte(Busquedas clsBusq)
        {

            SqlParameter[] pa = new SqlParameter[8];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Reporte> lstReporte = new List<Reporte>();
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@dtFechaIni", SqlDbType.Date);
                pa[0].Value = clsBusq.dtFechaIni;
                pa[1] = new SqlParameter("@dtFechaFin", SqlDbType.Date);
                pa[1].Value = clsBusq.dtFechaFin;
                pa[2] = new SqlParameter("@codTipoReporte", SqlDbType.VarChar,8);
                pa[2].Value = clsBusq.cod1;
                pa[3] = new SqlParameter("@codEstadoCliente", SqlDbType.VarChar,8);
                pa[3].Value = clsBusq.cod2;
                pa[4] = new SqlParameter("@cBuscar", SqlDbType.VarChar,50);
                pa[4].Value = clsBusq.cBuscar;
                pa[5] = new SqlParameter("@idUsuario", SqlDbType.Int);
                pa[5].Value = clsBusq.idUsuario;
                pa[6] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[6].Value = clsBusq.tipoCon;
                pa[7] = new SqlParameter("@chkHabilitarFecha", SqlDbType.Bit);
                pa[7].Value = clsBusq.chkActivarFechas;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarReporteSeguimiento", pa);

                Int32 y = 0;
                if (clsBusq.cod1== "TRSG0001")
                {
                    Int32 countPotencial = 0;
                    Int32 countRetirado = 0;
                    Int32 countAnulado = 0;
                    Int32 countComprador = 0;
                    Int32 countTorales = 0;


                    foreach (DataRow dr in dtUsuario.Rows)
                    {
                        Int32 totalFil = Convert.ToInt32(dr["POTENCIAL"]) + Convert.ToInt32(dr["RETIRADO"]) + Convert.ToInt32(dr["ANULADO"]) + Convert.ToInt32(dr["COMPRADOR"]);
                        double indica = (double)totalFil / Convert.ToInt32(dr["COMPRADOR"]);
                        indica = Double.IsInfinity(indica) ? 0 : indica;
                        countPotencial += Convert.ToInt32(dr["POTENCIAL"]);
                        countRetirado += Convert.ToInt32(dr["RETIRADO"]);
                        countAnulado += Convert.ToInt32(dr["ANULADO"]);
                        countComprador += Convert.ToInt32(dr["COMPRADOR"]);
                        countTorales += totalFil;

                        lstReporte.Add(new Reporte
                        {
                            numero = y + 1,
                            idUsuario = Convert.ToInt32(dr["idUsuario"]),
                            coddAux1 = dr["cUser"].ToString(),
                            coddAux2 = dr["POTENCIAL"].ToString(),
                            nombreAux2 = "POTENCIAL",
                            coddAux3 = dr["RETIRADO"].ToString(),
                            nombreAux3 = "RETIRADO",
                            coddAux4 = dr["ANULADO"].ToString(),
                            nombreAux4 = "ANULADO",
                            coddAux5 = dr["COMPRADOR"].ToString(),
                            nombreAux5 = "COMPRADOR",
                            SumColumns = totalFil,
                            indicador = indica,
                            strIndicador= String.Format("{0:#,##0.0}", indica)

                        }) ;
                        lstReporte[0].SumRowsAux2 = countPotencial;
                        lstReporte[0].SumRowsAux3 = countRetirado;
                        lstReporte[0].SumRowsAux4 = countAnulado;
                        lstReporte[0].SumRowsAux5= countComprador;
                        lstReporte[0].SumRowsTotalFilas= countTorales;
                        lstReporte[0].indicadorTotalFilas= (double)countTorales / countComprador;
                        lstReporte[0].strIndicadorTotalFilas = String.Format("{0:#,##0.0}", (double)countTorales / countComprador);
                        y++;
                    }
                    
                }
                else if (clsBusq.cod1 == "TRSG0002")
                {
                    Int32 counOficina = 0;
                    Int32 counReferencia = 0;
                    Int32 counFacebook = 0;
                    Int32 counWhatsApp = 0;
                    Int32 counLlamada = 0;
                    Int32 counCliente = 0;
                    Int32 counSoat = 0;
                    Int32 counTotales = 0;

                    foreach (DataRow dr in dtUsuario.Rows)
                    {
                        Int32 totalFil = Convert.ToInt32(dr["OFICINA"]) + Convert.ToInt32(dr["REFERENCIA"]) + Convert.ToInt32(dr["FACEBOOK"]) + Convert.ToInt32(dr["WHATSAPP"])+ Convert.ToInt32(dr["LLAMADA"])+ Convert.ToInt32(dr["CLIENTE"])+ Convert.ToInt32(dr["SOAT"]);
                        counOficina += Convert.ToInt32(dr["OFICINA"]);
                        counReferencia += Convert.ToInt32(dr["REFERENCIA"]);
                        counFacebook += Convert.ToInt32(dr["FACEBOOK"]);
                        counWhatsApp += Convert.ToInt32(dr["WHATSAPP"]);
                        counLlamada += Convert.ToInt32(dr["LLAMADA"]);
                        counCliente += Convert.ToInt32(dr["CLIENTE"]);
                        counSoat += Convert.ToInt32(dr["SOAT"]);
                        counTotales += totalFil;

                        lstReporte.Add(new Reporte
                        {
                            idUsuario = Convert.ToInt32(dr["idUsuario"]),
                            coddAux1 = dr["cUser"].ToString(),
                            coddAux2 = dr["OFICINA"].ToString(),
                            coddAux3 = dr["REFERENCIA"].ToString(),
                            coddAux4 = dr["FACEBOOK"].ToString(),
                            coddAux5 = dr["WHATSAPP"].ToString(),
                            coddAux6 = dr["LLAMADA"].ToString(),
                            coddAux7 = dr["CLIENTE"].ToString(),
                            coddAux8 = dr["SOAT"].ToString(),
                            SumColumns = totalFil
                        });
                        lstReporte[0].SumRowsAux2 = counOficina;
                        lstReporte[0].SumRowsAux3 = counReferencia;
                        lstReporte[0].SumRowsAux4 = counFacebook;
                        lstReporte[0].SumRowsAux5 = counWhatsApp;
                        lstReporte[0].SumRowsAux6 = counLlamada;
                        lstReporte[0].SumRowsAux7 = counCliente;
                        lstReporte[0].SumRowsAux8 = counSoat;


                    }
                        lstReporte[0].SumRowsTotalFilas = counTotales;
                }
                

                return lstReporte;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daListarEquipo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }
        public List<ReporteBloque> daBuscarVentasRealizadas(Busquedas clsBusq)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<ReporteBloque> lstReporte = new List<ReporteBloque>();
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@pcBuscar", SqlDbType.VarChar,50);
                pa[0].Value = clsBusq.cBuscar;
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[1].Value = clsBusq.tipoCon;
               

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarVentasSeguimiento", pa);

                Int32 y = 0;

                foreach (DataRow dr in dtUsuario.Rows)
                {


                    lstReporte.Add(new ReporteBloque
                    {
                        Codigoreporte = Convert.ToString(dr["idContrato"]),
                        codAuxiliar = Convert.ToString(dr["Vehiculo"]),
                        Detallereporte = FormatearCadenaTitleCase(dr["CLiente"].ToString()),
                       

                    });
                    y++;
                }
                   



                return lstReporte;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daListarEquipo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }
        public string FormatearCadenaTitleCase(String str)
        {
            String dat = str.ToLower();
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dat); ;
        }
        public Prospecto daListarProspectoDatatable(Int32 idCliente, Int32 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Prospecto lstProsp = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peIdProspecto", SqlDbType.Int);
                pa[0].Value = idCliente;
                pa[1] = new SqlParameter("@peTipoCon", SqlDbType.Int);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarProspectoEspecifico", pa);

                lstProsp = new Prospecto();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstProsp.idProspecto = Convert.ToInt32(drMenu["idProspecto"]);
                    lstProsp.nombres = Convert.ToString(drMenu["cNombre"]);
                    lstProsp.apellidos = Convert.ToString(drMenu["cApellido"]);
                    lstProsp.celular1 = Convert.ToString(drMenu["cNroCelular1"]);
                    lstProsp.celular2 = Convert.ToString(drMenu["cNroCelular2"]);
                    lstProsp.correo = Convert.ToString(drMenu["cCorreo"]);
                }

                return lstProsp;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daListarEquipo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstProsp = null;
            }
        }

        public Int16 daBuscarTelefonoProspecto(String pcBuscar, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 15);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.Int);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarTelefonoProspecto", pa);

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

        public Prospecto daBuscarClienteXTelefono(String pcBuscar, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Prospecto lstProsp = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 15);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.Int);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarClienteXTelefono", pa);

                lstProsp = new Prospecto();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstProsp.idProspecto = Convert.ToInt32(drMenu["idProspecto"]);
                    lstProsp.nombres = Convert.ToString(drMenu["cNombre"]);
                    lstProsp.apellidos = Convert.ToString(drMenu["cApellido"]);
                    lstProsp.celular1 = Convert.ToString(drMenu["cNroCelular1"]);
                    lstProsp.celular2 = Convert.ToString(drMenu["cNroCelular2"]);
                    lstProsp.correo = Convert.ToString(drMenu["cCorreo"]);


                }

                return lstProsp;

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
        public DataTable daBuscarPlanXTelefono(String pcBuscar, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 15);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.Int);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarPlanesXTelefono", pa);

                return dtUsuario;

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
        public String daGrabarSeguimiento(Seguimiento objProspecto, Int32 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[9];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            String xmlVentas=clsUtil.Serialize(objProspecto.lstVentasSeleccionadas);

            try
            {
                pa[0] = new SqlParameter("@idSeguimiento", SqlDbType.Int);
                pa[0].Value = objProspecto.idSeguimiento;
                pa[1] = new SqlParameter("@idProspectoPlan", SqlDbType.Int);
                pa[1].Value = objProspecto.idProspectoPlan;
                pa[2] = new SqlParameter("@cObservacion", SqlDbType.NVarChar, 1000);
                pa[2].Value = objProspecto.observacion;
                pa[3] = new SqlParameter("@cFechaSigSegimiento", SqlDbType.DateTime);
                pa[3].Value = objProspecto.fechaProxSeguimiento;
                pa[4] = new SqlParameter("@dFechaRegistro", SqlDbType.DateTime );
                pa[4].Value = objProspecto.fechaRegistro;
                pa[5] = new SqlParameter("@idUsuario", SqlDbType.Int);
                pa[5].Value = objProspecto.idUsuario;
                pa[6] = new SqlParameter("@peTipoCon", SqlDbType.Int);
                pa[6].Value = pnTipoCon;
                pa[7] = new SqlParameter("@estadoCliente", SqlDbType.NVarChar,15);
                pa[7].Value = objProspecto.estadoCliente;
                pa[8] = new SqlParameter("@xmlVentas", SqlDbType.Xml);
                pa[8].Value = xmlVentas;


                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarSeguimiento", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daGrabarAccesorio", ex.Message);
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

        public DataSet daBuscarSeguimientoDataTable(Int32 idOferta, Int32 numPagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataSet dtAccesorio = new DataSet();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idProspectoPlan", SqlDbType.Int);
                pa[0].Value = idOferta;
                pa[1] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[1].Value = numPagina;
                pa[2] = new SqlParameter("@tipoCon", SqlDbType.Real);
                pa[2].Value = tipoCon;
                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDS("uspBuscarSeguimientoEspecifico", pa);

                return dtAccesorio;
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


        public String daGrabarProspecto(Prospecto objProspecto, Int32 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[9];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idPropectos", SqlDbType.Int);
                pa[0].Value = objProspecto.idProspecto;
                pa[1] = new SqlParameter("@cNombre", SqlDbType.NVarChar, 45);
                pa[1].Value = objProspecto.nombres;
                pa[2] = new SqlParameter("@cApellido", SqlDbType.NVarChar, 45);
                pa[2].Value = objProspecto.apellidos;
                pa[3] = new SqlParameter("@cNroCelular", SqlDbType.NVarChar, 15);
                pa[3].Value = objProspecto.celular1;
                pa[4] = new SqlParameter("@cNroCelular2", SqlDbType.NVarChar, 15);
                pa[4].Value = objProspecto.celular2;
                pa[5] = new SqlParameter("@cCorreo", SqlDbType.NVarChar, 45);
                pa[5].Value = objProspecto.correo;
                pa[6] = new SqlParameter("@idUsuario", SqlDbType.Int);
                pa[6].Value = objProspecto.idUsuario;
                pa[7] = new SqlParameter("@dFechaRegistro", SqlDbType.DateTime);
                pa[7].Value = objProspecto.fechaRegistro;
                pa[8] = new SqlParameter("@peiTipoCon", SqlDbType.Int);
                pa[8].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarProspectos", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daGrabarAccesorio", ex.Message);
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


        public totalRanking daTotalesRankingSeguimiento(String pcBuscar, String celular, String tipoContacto, String fechaInicial, String fechaFinal, Boolean habilitarFecha, Boolean fechaVisita, Boolean fechaRegistroSeg, Boolean fechaSigSeg, Int32 idUsuario, String fechaActual,Int32 idTipoPlan, Int32 idPlan,Int32 idTipoTarifa)
        {
            SqlParameter[] pa = new SqlParameter[14];
            DataTable dtUsuario = new DataTable();
            totalRanking lstTotRank ;
            clsConexion objCnx = null;

            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peBuscar", SqlDbType.VarChar, 45) { Value = pcBuscar };
                pa[1] = new SqlParameter("@cTipoContacto", SqlDbType.NVarChar, 15) { Value = tipoContacto };
                pa[2] = new SqlParameter("@numCelular", SqlDbType.VarChar, 15) { Value = celular };
                pa[3] = new SqlParameter("@fechaInicial", SqlDbType.Date) { Value = fechaInicial };
                pa[4] = new SqlParameter("@fechaFinal", SqlDbType.Date) { Value = fechaFinal };
                pa[5] = new SqlParameter("@habilitarFecha", SqlDbType.TinyInt) { Value = habilitarFecha };
                pa[6] = new SqlParameter("@fechaVisita", SqlDbType.TinyInt) { Value = fechaVisita };
                pa[7] = new SqlParameter("@fechaRegistro", SqlDbType.TinyInt) { Value = fechaRegistroSeg };
                pa[8] = new SqlParameter("@fechaProxSeg", SqlDbType.TinyInt) { Value = fechaSigSeg };
                pa[9] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = idUsuario };
                pa[10] = new SqlParameter("@fechaActual", SqlDbType.Date) { Value = fechaActual };
                pa[11] = new SqlParameter("@idTipoPlan", SqlDbType.Int) { Value = idTipoPlan };
                pa[12] = new SqlParameter("@idPlan", SqlDbType.Int) { Value = idPlan };
                pa[13] = new SqlParameter("@idTipoTarifa", SqlDbType.Int) { Value = idTipoTarifa };
                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarColoresSeguimiento", pa);

                lstTotRank = new totalRanking();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstTotRank.totalVerdes = Convert.ToInt32(drMenu["CANTVERDE"]);
                    lstTotRank.totalAmarillos = Convert.ToInt32(drMenu["CANTAMARILLO"]);
                    lstTotRank.totalRojos = Convert.ToInt32(drMenu["CANTROJOS"]);
                }
                return lstTotRank;
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
