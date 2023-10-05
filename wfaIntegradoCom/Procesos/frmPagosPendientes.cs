using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using FontAwesome.Sharp;
using Siticone.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Mantenedores;
using wfaIntegradoCom.Sunat;
using static wfaIntegradoCom.Mantenedores.ControlMover;
using Icon = System.Drawing.Icon;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmPagosPendientes : Form
    {
        public frmPagosPendientes()
        {
            InitializeComponent();
        }
        static List<ReporteBloque> lstDVenta = new List<ReporteBloque>();
        static List<Pagos> lstPagosTrand = new List<Pagos>();
        static List<Cargo> lstDocumentoVentaEmitir = new List<Cargo>();
        static Cargo clsDocumentoVentaEmitir = new Cargo();
        static Boolean estadoGuardarPago = false;
        static DateTime stDtFechaDePago = DateTime.Now;
        Boolean estFecha = false, estMoneda = false,estTipoPago=false, estDocumento = false;
        static List<Moneda> lstMon = new List<Moneda>();
        static Moneda clsMoneda = new Moneda();
        static List<Cliente> lstCliente = new List<Cliente>();
        static Cliente clsCliente = new Cliente();
        static List<DocumentoVenta> lstDocumentoVenta = new List<DocumentoVenta>();
        static List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();
        static DataTable dtResultados = new DataTable();
        static int tabInicio = 0;
        static bool dEstadoBusquedaPaginacion = false;
        static bool dEstadoPagina = false;
        string UsuarioDocumentoVenta = "";
        string TipoPago = "";
        string PlacaVehiculo = "";
        static List<DetalleVenta> lsDetalleVentaRecibidoParaEnviarASunat = new List<DetalleVenta>();
        static List<DetalleVenta> lsDetalleVentaRecibidoParaXml = new List<DetalleVenta>();
        static List<DocumentoVenta> lsDocumentoVentaParaXml = new List<DocumentoVenta>();
        Int32 IdUsuarioRegistro = 0;
        static int IdTra = 0;
        Int32 intRespuestaSunat = 0;
        String stDocumentoCleinte = "";
        public void Inicio(String idtrand)
        {
            stDocumentoCleinte=idtrand;
            ShowDialog();
        }
        public void fnRecuperarTipoPago(List<Pagos> lstEntidades,List<DetalleVenta> lstDetVentas,List<DocumentoVenta> docVenta, List<DetalleVenta>dtv )
        {
            lstPagosTrand = lstEntidades;

            lsDetalleVentaRecibidoParaXml = lstDetVentas;
            lsDocumentoVentaParaXml = docVenta;

            String destalle = "";
            List<DetalleVenta> lstDetalleParaSunat = new List<DetalleVenta>();
            Decimal ImporteARestar = 0;
            Decimal importeParaDocumentoReal = 0;
            foreach (var detalle in lstDetVentas)
            {
                if (detalle.Importe > 0)
                {
                    lstDetalleParaSunat.Add(detalle);
                }
                else
                {
                    ImporteARestar += detalle.Importe*-1;
                }
            }
            Int32 y=0;
            if (docVenta[0].idTipoTarifa==1)
            {
                y = 0;
                foreach (var dv in lstEntidades)
                {
                    lsDetalleVentaRecibidoParaEnviarASunat.Add(new DetalleVenta
                    {
                        Numeracion = y + 1,
                        Descripcion = "Servicio de monitoreo GPS",
                        idTipoTarifa = 2,
                        PrecioUni = dv.PagaCon,
                        Descuento = 0,
                        gananciaRedondeo = 0,
                        TotalTipoDescuento = 0,
                        IdTipoDescuento = 0,
                        Cantidad = 1,
                        Couta = 1,
                        Importe = dv.PagaCon,
                        cSimbolo = "S/.",

                        preciounitario = Convert.ToDecimal(dv.PagaCon),
                        ImporteRow = (Convert.ToDecimal(dv.PagaCon) * 1),
                        mtoValorVentaItem = (Convert.ToDecimal(dv.PagaCon) * 1),
                        Unidad_de_medida = "ZZ"

                    });
                    y++;

                }
                
               
                
            }
            else
            {
                lsDetalleVentaRecibidoParaEnviarASunat = lstDetalleParaSunat;
                foreach (var item in lstDetalleParaSunat)
                {
                    if (lstDetalleParaSunat[y].Importe >= ImporteARestar)
                    {
                        importeParaDocumentoReal = lstDetalleParaSunat[y].Importe - ImporteARestar;
                        ImporteARestar = lstDetalleParaSunat[y].Importe - ImporteARestar;

                    }
                    else if (lstDetalleParaSunat[y].Importe > ImporteARestar)
                    {
                        importeParaDocumentoReal = ImporteARestar;
                        ImporteARestar = ImporteARestar > 0 ? ImporteARestar - ImporteARestar : 0;
                    }

                    lsDetalleVentaRecibidoParaEnviarASunat[y].Numeracion = 1;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].IdDetalleVenta = lstDetalleParaSunat[y].IdDetalleVenta;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].Descripcion = lstDetalleParaSunat[y].Descripcion;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].idTipoTarifa = lstDetalleParaSunat[y].idTipoTarifa;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].PrecioUni = lstDetalleParaSunat[y].preciounitario;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].Descuento = lstDetalleParaSunat[y].Descuento;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].gananciaRedondeo = lstDetalleParaSunat[y].gananciaRedondeo;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].TotalTipoDescuento = lstDetalleParaSunat[y].TotalTipoDescuento;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].IdTipoDescuento = lstDetalleParaSunat[y].IdTipoDescuento;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].Cantidad = lstDetalleParaSunat[y].Cantidad;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].Couta = lstDetalleParaSunat[y].Couta;

                    lsDetalleVentaRecibidoParaEnviarASunat[y].Importe = importeParaDocumentoReal;//lsDetalleVenta[y].Importe;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].importeRestante = (lstDetalleParaSunat[y].preciounitario - importeParaDocumentoReal);
                    lsDetalleVentaRecibidoParaEnviarASunat[y].ImporteActicipo = importeParaDocumentoReal;//lsDetalleVenta[y].Importe;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].cSimbolo = lstDetalleParaSunat[y].cSimbolo;

                    lsDetalleVentaRecibidoParaEnviarASunat[y].preciounitario = importeParaDocumentoReal;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].ImporteRow = importeParaDocumentoReal;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].mtoValorVentaItem = importeParaDocumentoReal;
                    lsDetalleVentaRecibidoParaEnviarASunat[y].Unidad_de_medida = "ZZ";
                    lsDetalleVentaRecibidoParaEnviarASunat[y].idOperacionItem = lsDetalleVentaRecibidoParaEnviarASunat[y].importeRestante == 0 ? 0 : 2;
                    y++;
                }
            }
            
            //lsDetalleVentaRecibidoParaPagar = lstDetVentas;
            for (int i = 0; i < lstPagosTrand.Count; i++)
            {
                lstPagosTrand[i].dFechaPago = FunGeneral.fnUpdateFechas(stDtFechaDePago);
                lstPagosTrand[i].idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                lstPagosTrand[i].idUsario = Variables.gnCodUser;
            }

        }

        public void fnRecuperarEstadoGenVenta(Boolean estado)
        {
            estadoGuardarPago = estado;
        }
        private Boolean fnLLenarMoneda(ComboBox cbo, Int32 idMoneda, Boolean buscar)
        {
            BLMoneda objMoneda = new BLMoneda();
            clsUtil objUtil = new clsUtil();
            List<Moneda> lstMoneda;

            try
            {
                lstMoneda = objMoneda.blDevolverMoneda(idMoneda, buscar);
                cbo.ValueMember = "idMoneda";
                cbo.DisplayMember = "cNombre";
                cbo.DataSource = lstMoneda;

                lstMon = lstMoneda;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarClaseVehiculo", ex.Message);
                return false;
            }
            finally
            {
                lstMoneda = null;
            }
        }
        private void fnActivarFechas()
        {
            if (chkHabilitarFechasBus.Checked == true)
            {
                siticoneGroupBox1.Enabled = true;
            }
            else
            {

                siticoneGroupBox1.Enabled = false;
            }
        }
        private void frmPagosPendientes_Load(object sender, EventArgs e)
        {
            try
            {
                ColorThemas.ElegirThema(Variables.clasePersonal.codTema);
                FunGeneral.fnThemaAFormularios(pnFondo);
                dtFechaPago.Value = Variables.gdFechaSis;
                //FunGeneral.fnValidarFechaPago(dtFechaPago, pbFechaPago, 0);
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
                dtFechafinal.Value = Variables.gdFechaSis;
                dtFechaInicio.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
                fnLLenarMoneda(cboMoneda, 0, false);
                cboMoneda.SelectedValue = 1;
                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboEstado, "cCodTab", "cNomTab", "TablaCod", "nValor1",
                    "estPagos", false);
                cboEstado.SelectedValue = "ESPP0002";
                



                if (Variables.gsCargoUsuario == "PETR0007")
                {
                    contextMenuStrip1.Enabled = true;
                    contextMenuStrip1.Visible = true;
                    cboDVenta.Visible = true;
                }
                else
                {
                    contextMenuStrip1.Enabled = false;
                    contextMenuStrip1.Visible = false;
                    cboDVenta.Visible = false;
                    lblComboVenta.Visible = false;
                    txtBuscarFecha.Size = new Size(428, 36);
                    btnBuscar.Location = new Point(945, 63);
                    contextMenuStrip1.Items.Clear();
                }
                if (stDocumentoCleinte != "")
                {
                    chkHabilitarFechasBus.Checked = false;
                    fnBusacarVentas(0, -1);
                }
                

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void fnBuscarLabelEnPanel(SiticonePanel pn)
        {
            var ts = pn.Controls.OfType<Label>();
            foreach (Label lb in ts)
            {
                //lb.ForeColor = ;
            }
        }


        private void fnBuscarPagosPendientes(Int32 numPagina, Int32 TipoCon)
        {
            BLVentaGeneral blV = new BLVentaGeneral();
            DataTable dt = new DataTable();
            Int32 idTrandiaria = IdTra;
            Int32 numRows = 0;
            Int32 filas = 6;
            String cBuscar = txtBuscarFecha.Text.ToString();
            String fechaInicio = FunGeneral.GetFechaHoraFormato(dtFechaInicio.Value, 5);
            String fechaFin = FunGeneral.GetFechaHoraFormato(dtFechafinal.Value, 5);
            Boolean chkHabilita = chkFecha.Checked;

            dEstadoPagina = true;

            dtResultados = new DataTable();
            dt = blV.blBuscarPagosPendientes(idTrandiaria, chkHabilita, cBuscar, fechaInicio, fechaFin, numPagina, TipoCon);
            dtResultados = dt;
            numRows = dt.Rows.Count;
            DataGridView dgv = dgvCuotas;
            try
            {
                lstCliente.Clear();
                if (numRows > 0)
                {
                    //pnDatosPago.Visible = true;
                    dgv.Columns.Clear();
                    dgv.Rows.Clear();
                    lstDVenta.Clear();
                    DataGridViewButtonColumn db = new DataGridViewButtonColumn();
                    dgv.Columns.Add("idConcepto", "idConcepto");
                    dgv.Columns.Add("idtrandiaria", "idtrandiaria");
                    dgv.Columns.Add("N", "N°");
                    dgv.Columns.Add("fechaPago", "Fecha Pago");
                    dgv.Columns.Add("Cliente", "Cliente");
                    dgv.Columns.Add("Vehiculo", "Vehiculo");
                    dgv.Columns.Add("Operacion", "Operacion");
                    dgv.Columns.Add("Importe", "Importe");
                    dgv.Columns.Add("Usuario", "Usuario");
                    dgv.Columns.Add("Icono", "Accion");
                    int y = 0;
                    if (numPagina == 0)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (numPagina - 1) * filas;
                        y = tabInicio;
                        
                        dEstadoPagina = false;
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        lstCliente.Add(new Cliente
                        {
                            idCliente = Convert.ToInt32(dr["IdConcepto"]),
                            cNombre = dr["cNombre"].ToString(),
                            cApePat = dr["cApePat"].ToString(),
                            cApeMat = dr["cApeMat"].ToString(),
                            cTiDo = Convert.ToInt32(dr["cTiDo"]),
                            cTipoDoc = dr["TipoDocumento"].ToString(),
                            cDocumento = dr["cDocumento"].ToString(),
                            ubigeo= dr["cDireccion"].ToString() + " " + dr["cNomdist"] + " " + dr["cNomProv"] + " " + dr["cNomDep"],
                            cDireccion = dr["cDireccion"].ToString().Trim()

                        });


                        dgv.Rows.Add(
                                        dr["idConcepto"],
                                        dr["idTrandiaria"],
                                        y + 1,
                                       Convert.ToDateTime(dr["dFechaPago"]).ToString("dd MMM yy hh:mm tt"),
                                        dr["cNombre"] + " " + dr["cApePat"],
                                        dr["vPlaca"],
                                        dr["cNombreOperacion"],
                                        FunGeneral.fnFormatearPrecio("S/.", Convert.ToDouble(dr["importe"]), 1),
                                        dr["cUser"]

                                    );
                        y++;
                    }
                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Visible = false;
                    dgv.Columns[2].Width = 2;
                    dgv.Columns[3].Width = 16;
                    dgv.Columns[4].Width = 30;
                    dgv.Columns[5].Width = 8;
                    dgv.Columns[6].Width = 12;
                    dgv.Columns[7].Width = 8;
                    dgv.Columns[8].Width = 12;
                    dgv.Columns[9].Width = 80;

                    dgv.Visible = true;
                    if (numPagina == 0)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(dt.Rows[0][0]);
                        FunValidaciones.fnCalcularPaginacion(
                            totalRegistros,
                            filas,
                            numRows,
                            cboPaginaCuotas,
                            btnTotalPaginaCuotas,
                            btnNumeroPaginasCuotas,
                            btnTotalRegCuotas
                        );
                        
                        dEstadoPagina = false;
                    }
                    else
                    {
                        btnNumFilas.Text = Convert.ToString(numRows);
                    }
                }
                else
                {
                    //pnDatosPago.Visible = false;
                    dgv.Columns.Clear();
                    dgv.Rows.Clear();
                    lstDVenta.Clear();
                    dgv.Columns.Add("SinDatos", "No se encontraron resultados");
                    dgv.Columns[0].Visible = true;
                    dgv.Columns[0].Width = 100;
                    dgv.Visible = true;
                }
            }

            catch (Exception ex)
            {
                throw;
            }


        }

        private void fnBusacarVentas(Int32 numPagina, Int32 tipoCon)
        {

            BLVentaGeneral blV = new BLVentaGeneral();
            DataTable dt = new DataTable();
            Int32 numRows = 0;
            Int32 filas = 15;
            String cBuscar = txtBuscar.Text.ToString();
            String fechaInicio = FunGeneral.GetFechaHoraFormato(dtpFechaInicialBus.Value, 5);
            String fechaFin = FunGeneral.GetFechaHoraFormato(dtpFechaFinalBus.Value, 5);
            Boolean chkHabilita = chkHabilitarFechasBus.Checked;
            String CodEstadoPago = cboEstado.SelectedValue.ToString();
            String idTrandiaria = stDocumentoCleinte;

            dEstadoBusquedaPaginacion = true;
            

            dt = blV.blBuscarVentaPagoPendientes(chkHabilita, CodEstadoPago, cBuscar, fechaInicio, fechaFin, numPagina, idTrandiaria, tipoCon);
            dtResultados = dt;
            numRows = dt.Rows.Count;
            DataGridView dgv = dgvVentas;

            try
            {
                lstCliente.Clear();
                if (numRows > 0)
                {
                    //pnDatosPago.Visible = true;
                    dgv.Columns.Clear();
                    dgv.Rows.Clear();
                    lstDVenta.Clear();
                    DataGridViewButtonColumn db = new DataGridViewButtonColumn();

                    dgv.Columns.Add("idTrandiaria", "idTrandiaria");
                    dgv.Columns.Add("N", "N°");
                    dgv.Columns.Add("fechaPago", "Fecha ult. Pago");
                    dgv.Columns.Add("Cliente", "Cliente");
                    dgv.Columns.Add("Vehiculo", "Vehiculo");
                    dgv.Columns.Add("Operacion", "Operacion");
                    dgv.Columns.Add("TotalPago", "Importe Total");
                    dgv.Columns.Add("ImporteAbonado", "Importe Abonado");
                    dgv.Columns.Add("ImporteRestante", "Importe Restante");
                    dgv.Columns.Add("Usuario", "Usuario");
                    dgv.Columns.Add("Estado", "Estado");
                    dgv.Columns.Add("Icono", "Accion");
                    dgv.Columns.Add("idTipotarifa", "idTipotarifa");
                    //dgv.Columns.Add("Icono", "Icono",dataGridViewColumn);

                    int y = 0;
                    if (numPagina == 0)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (numPagina - 1) * filas;
                        y = tabInicio;
                        dEstadoBusquedaPaginacion = false;
                       
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        Decimal importeRestante = Convert.ToDecimal(dr["TotalPago"]) - Convert.ToDecimal(dr["pagaCon"]);

                        lstDVenta.Add(new ReporteBloque
                        {
                            idAuxiliar = Convert.ToInt32(dr["idTrandiaria"]),
                            ImporteRow = importeRestante,
                            ImporteTotal = Convert.ToDouble(dr["TotalPago"]),
                            MasDetallereporte = dr["cNombreOperacion"].ToString(),
                            idMoneda = Convert.ToInt32(cboMoneda.SelectedValue),
                            Codigoreporte = dr["vehiculo"].ToString(),
                            idOperacion=Convert.ToInt32(dr["idOperacion"])

                        });

                        lstCliente.Add(new Cliente
                        {
                            idCliente = Convert.ToInt32(dr["idTrandiaria"]),
                            cNombre = dr["cNombre"].ToString(),
                            cApePat = dr["cApePat"].ToString(),
                            cApeMat = dr["cApeMat"].ToString(),
                            cTiDo = Convert.ToInt32(dr["cTiDo"]),
                            cTipoDoc = dr["tipoDocumento"].ToString(),
                            cDocumento = dr["cDocumento"].ToString(),
                            ubigeo = dr["cUbigeo"].ToString(),
                            cDireccion = dr["cDireccion"].ToString().Trim()

                        });

                        dgv.Rows.Add(
                                        dr["idTrandiaria"],
                                        y + 1,
                                       Convert.ToDateTime(dr["dFechaPago"]).ToString("dd MMM yyyy hh:mm tt"),
                                        dr["cNombre"] + " " + dr["cApePat"],
                                        dr["vehiculo"],
                                        dr["cNombreOperacion"],
                                        FunGeneral.fnFormatearPrecio("S/.", Convert.ToDouble(dr["TotalPago"]), 1),
                                        FunGeneral.fnFormatearPrecio("S/.", Convert.ToDouble(dr["pagaCon"]), 1),
                                        (FunGeneral.fnFormatearPrecioDC("S/.", importeRestante, 1)),
                                        dr["cUser"],
                                        dr["cNomTab"],
                                        "",
                                        dr["idTipoTarifa"]
                                    );
                        if (cboEstado.SelectedValue.ToString() == "ESPP0001")
                        {
                            dgv.Rows[y].Cells[10].Style.BackColor = Color.Green;
                            dgv.Rows[y].Cells[10].Style.ForeColor = Color.White;
                            dgv.Columns[11].Visible = false;
                        }

                        y++;
                    }
                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 10;
                    dgv.Columns[2].Width = 60;
                    dgv.Columns[3].Width = 70;
                    dgv.Columns[4].Width = 30;
                    dgv.Columns[5].Width = 50;
                    dgv.Columns[6].Width = 30;
                    dgv.Columns[7].Width = 30;
                    dgv.Columns[8].Width = 30;
                    dgv.Columns[9].Width = 30;
                    dgv.Columns[12].Visible=false;
                    dgv.Columns[10].Width = cboEstado.SelectedValue.ToString() == "ESPP0001" ? 90 : 30;
                    dgv.Visible = true;

                    if (numPagina == 0)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(dt.Rows[0][0]);
                        FunValidaciones.fnCalcularPaginacion(
                            totalRegistros,
                            filas,
                            numRows,
                            cboPagina,
                            btnTotalPag,
                            btnNumFilas,
                            btnTotalReg
                        );
                        dEstadoBusquedaPaginacion = false;
                        
                    }
                    else
                    {
                        btnNumFilas.Text = Convert.ToString(numRows);
                    }
                }
                else
                {
                    pnDatosPago.Visible = false;
                    dgv.Columns.Clear();
                    dgv.Rows.Clear();
                    lstDVenta.Clear();
                    dgv.Columns.Add("SinDatos", "No se encontraron resultados");
                    dgv.Columns[0].Visible = true;
                    dgv.Columns[0].Width = 100;
                    dgv.Visible = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }




        }
        

        private List<DetalleVenta> fnDetalleventa(Int32 idTrandiaria, Int32 idTipoTarifa)
        {
            
            List<DetalleVenta> lstDetV = new List<DetalleVenta>();
            List<DetalleVenta> lstDetV1 = new List<DetalleVenta>();
          
            lstDetV=FunGeneral.fnObtenerDetalleVenta(idTrandiaria, idTipoTarifa);

            //Int32 cantidad = 1;
            //Decimal dMontoRestante = 0;
            //foreach (DataRow dt in dtResultados.Rows)
            //{
            //    if (idTrandiaria == Convert.ToInt32(dt["idTrandiaria"]))
            //    {
            //        dMontoRestante = Convert.ToDecimal(dt["TotalPago"]) - Convert.ToDecimal(dt["pagaCon"]);
            //    }
            //}
            //Decimal importe = dMontoRestante;
            //String descripcion = lstDVenta[0].idOperacion == 4 ? "RENTA MENSUAL" : lstDVenta[0].MasDetallereporte;
           
            int y = 0;
            foreach (DetalleVenta d in lstDetV)
            {
                lstDetV1.Add(new DetalleVenta
                {
                    IdDetalleVenta = d.IdDetalleVenta,
                    Numeracion = 1 + y,
                    Descripcion = d.Descripcion,
                    idTipoTarifa =d.idTipoTarifa,
                    PrecioUni = d.PrecioUni,
                    Descuento = d.Descuento,
                    TotalTipoDescuento = d.TotalTipoDescuento,
                    IdTipoDescuento = d.IdTipoDescuento,
                    Cantidad = 1,
                    Couta = 0,
                    Importe = d.Importe,
                    cSimbolo = clsMoneda.cSimbolo,
                    preciounitario = Convert.ToDecimal(d.Importe),
                    ImporteRow = (Convert.ToDecimal(d.Importe) * 1),
                    importeRestante=d.importeRestante,
                    mtoValorVentaItem = (Convert.ToDecimal(d.Importe) * 1),

                    Unidad_de_medida = "ZZ"
                });
                y++;
            }


            if (lstDetV1.Count>0)
            {
                lstDetV1[0].idObjetoVenta = idTrandiaria;

            }


            return lstDetV1;

        }
        private List<DetalleVenta> fnDetalleventaActualizar()
        {
            List<DetalleVenta> lstDetV = new List<DetalleVenta>();
            Int32 cantidad = 1;
            Decimal precioUnitario = lstPagosTrand[0].PagaCon;
            Decimal importe = lstPagosTrand[0].PagaCon;
            String descripcion = lstDVenta[0].MasDetallereporte;

            lstDetV.Add(new DetalleVenta
            {
                Numeracion = 1,
                Descripcion = "CUOTA " + descripcion,
                idTipoTarifa = 0,
                PrecioUni = precioUnitario,
                Descuento = 0,
                gananciaRedondeo = 0,
                TotalTipoDescuento = 0,
                IdTipoDescuento = 0,
                Cantidad = 1,
                Couta = 0,
                Importe = importe,
                cSimbolo = clsMoneda.cSimbolo,
            });
            return lstDetV;

        }
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBusacarVentas(0, -1);
            }
        }

        private void dgvVentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvVentas.Columns[e.ColumnIndex].Name == "Icono" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvVentas.Rows[e.RowIndex].Cells["Icono"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\pagar.ico");


                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvVentas.Rows[e.RowIndex].Height = 35;
                this.dgvVentas.Columns[e.ColumnIndex].Width = 45;


                e.Handled = true;

            }
            if (e.RowIndex >= 0)
            {
                this.dgvVentas.Rows[e.RowIndex].Height = 35;

            }
        }


        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pnDatosPago.Visible=false;
            DataGridViewRow dgvR = dgvVentas.Rows[e.RowIndex];
            Int32 idTrandiaria = Convert.ToInt32(dgvR.Cells[0].Value);
            DataGridView dgv = dgvVentas;
            Decimal dMontoRestante = 0;
            if (dgv.Columns[e.ColumnIndex].Name == "Icono")
            {
                clsCliente = lstCliente.Find(i => i.idCliente == idTrandiaria);
                if (!(clsCliente is Cliente))
                {
                    MessageBox.Show("Ocurrio un error inesperado, por favor busque nuevamente los datos","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                lstDocumentoVentaEmitir =frmRegistrarVenta.fnLlenarComprobante(cboTipoDocEmitir, "DOVE", clsCliente.cTiDo, 0);
                foreach (DataRow dt in dtResultados.Rows)
                {
                    if (idTrandiaria == Convert.ToInt32(dt["idTrandiaria"]))
                    {
                        dMontoRestante = Convert.ToDecimal(dt["TotalPago"]) - Convert.ToDecimal(dt["pagaCon"]);
                    }
                }
                

                pnDatosPago.Visible=true;
                Int32 x = dgvVentas.Left + (dgvVentas.Width/4);
                Int32 y = dgvVentas.GetRowDisplayRectangle(e.RowIndex, false).Y;
                pnDatosPago.Location = new Point(x-18, y+208);
                //pnDatosPago.Width = dgvVentas.Width - 50;



            }
            else
            {
                
            }


        }
        private void fnCargarDatosDeDocumento()
        {
            if (estDocumento && estMoneda && estFecha)
            {
                
                Int32 idTrandiaria = Convert.ToInt32(dgvVentas.CurrentRow.Cells[0].Value);
                Int32 idTipoTarifa = Convert.ToInt32(dgvVentas.CurrentRow.Cells[12].Value);
                frmRegistrarEgresos f = new frmRegistrarEgresos();

                lstDetalleVenta = fnDetalleventa(idTrandiaria, 0);
                if (lstDetalleVenta.Count <= 0)
                {
                    MessageBox.Show("Ocurrio un error al buscar anticipo", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lstDocumentoVenta = fnDocumentoVentaHeader(f.fnCalcularCabeceraDetalle(lstDetalleVenta), idTrandiaria, idTipoTarifa);
                lstDocumentoVenta[0].idTrandiaria=lstDocumentoVenta.Count > 0 ?idTrandiaria:0;
                Procesos.frmTipoPago fmr = new Procesos.frmTipoPago();
                ReporteBloque repBloque = lstDVenta.Find(i => i.idAuxiliar == idTrandiaria);
                fmr.Inicio(-4, lstDocumentoVenta,lstDetalleVenta, lstDVenta[0].idMoneda == 1 ? "S/" : "$");
                clsCliente = lstCliente.Find(i => i.idCliente == idTrandiaria);

                if (estadoGuardarPago == true)
                {
                    fnCompletarPago(idTrandiaria, 0);
                }
            }
            else
            {
                MessageBox.Show("Por favor complete todo los datos", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void fnLlenadClaseDocumento()
        {
            Int32 j = 0;
            foreach (Cargo item in lstDocumentoVentaEmitir)
            {
                lstDocumentoVentaEmitir[j].dFechaPago = dtFechaPago.Value;
                lstDocumentoVentaEmitir[j].dFechaVenta = dtFechaPago.Value;
                j++;
            }
            if (cboTipoDocEmitir.Items.Count > 0)
            {
                clsDocumentoVentaEmitir = lstDocumentoVentaEmitir.Find(i => i.cCodTab == cboTipoDocEmitir.SelectedValue.ToString());
            }


        }

        private List<DocumentoVenta> fnDocumentoVentaHeader(DetalleVentaCabecera dvc,Int32 idTrandiaria,Int32 idTipoTarifa)
        {

            List<DocumentoVenta> lsDocVenta = new List<DocumentoVenta>();
            TipoTarifa lstTipoVenta = new TipoTarifa();
            BLVentaGeneral blVG = new BLVentaGeneral();
            //lstTipoVenta = lstTipoTarifa.First(s => s.IdTipoTarifa == Convert.ToInt32(cboTipoVenta.SelectedValue));
            Personal clsUsuario = Variables.clasePersonal;
            PrecioALetras pal = new PrecioALetras();
            //string RecioALetras = ConvertirPrecioEnLetras(Convert.ToDecimal(lstdvc.ImporteTotal));
            string RecioALetras2 = pal.Convertir(dvc.ImporteTotal.ToString(), true, " SOLES");

            Personal clsPers = blVG.blObtenerUsuarioActual(0);
            ReporteBloque RepVehic = new ReporteBloque();
            RepVehic = lstDVenta.Find(i=>i.idAuxiliar== idTrandiaria);
            lsDocVenta.Add(new DocumentoVenta
            {
                idVenta= dvc.idTrandiaria,
                idCliente = clsPers.idPersonal,
                cCliente = clsCliente.cTiDo == 2 || clsCliente.cTiDo == 4 ? clsCliente.cApePat + " " + clsCliente.cApeMat + " " + clsCliente.cNombre : FunGeneral.FormatearCadenaTitleCase(clsCliente.cApePat + " " + clsCliente.cApeMat + " " + clsCliente.cNombre),
                cTipoDoc = clsCliente.cTipoDoc,
                cDireccion = clsCliente.cDireccion.ToString() != "-" ? FunGeneral.FormatearCadenaTitleCase(clsCliente.ubigeo) : clsCliente.cDireccion.ToString(),
                cDocumento = clsCliente.cDocumento,
                SimboloMoneda = clsMoneda.cSimbolo,
                cCodDocumentoVenta = Convert.ToString(cboTipoDocEmitir.SelectedValue),
                CodigoCorrelativo = clsDocumentoVentaEmitir.SerieDoc + "-" + FunGeneral.generarCorrelativoDocumento(Convert.ToInt32(clsDocumentoVentaEmitir.nValor2)),
                NombreDocumento = Convert.ToString(cboTipoDocEmitir.Text),
                dFechaVenta = FunGeneral.fnUpdateFechas(stDtFechaDePago),
                idMoneda = clsMoneda.idMoneda,
                nSubtotal = dvc.ValorVenta,
                nNroIGV = 18,
                nIGV = dvc.IGV,
                nMontoTotal = dvc.ImporteTotal,
                PrecioEnLetras = RecioALetras2,
                cUsuario = clsUsuario.cPrimerNom + " " + clsUsuario.cApePat,
                cVehiculos = RepVehic.Codigoreporte,
                cDescripcionTipoPago = (lstPagosTrand.Count > 0) ? FunGeneral.FormatearCadenaTitleCase(lstPagosTrand[0].cDescripTipoPago) : "",
                cDescripEstadoPP = (lstPagosTrand.Count > 0) ? lstPagosTrand[0].cEstadoPP : "",
                cTipoVenta = "PAGOS PENDIENTES",
                cEstado = "PAGOSPENDIENTES",
                idTipoTarifa = idTipoTarifa,
                //est0 = tabIndex == 0 ? false : true,
                est1 = false,
                estValida = true ,//chkTipoPago.Checked

            }) ;
            return lsDocVenta;


            //DocumentoVenta.cTipoDoc = Convert.ToString(cboTipoDocumento.Text);
            //DocumentoVenta.cVehiculos = lstvehiculo[0].vPlaca;
            //lstDocVenta.Add(DocumentoVenta);
        }
        private List<DocumentoVenta> fnDocumentoVentaHeaderActualizar(DetalleVentaCabecera dvc)
        {

            List<DocumentoVenta> lsDocVenta = new List<DocumentoVenta>();
            TipoTarifa lstTipoVenta = new TipoTarifa();
            BLVentaGeneral blVG = new BLVentaGeneral();
            //lstTipoVenta = lstTipoTarifa.First(s => s.IdTipoTarifa == Convert.ToInt32(cboTipoVenta.SelectedValue));
            Personal clsUsuario = Variables.clasePersonal;

            Personal clsPers = blVG.blObtenerUsuarioActual(0);
            lsDocVenta.Add(new DocumentoVenta
            {
                idCliente = clsPers.idPersonal,
                cCliente = FunGeneral.FormatearCadenaTitleCase(clsCliente.cNombre + " " + clsCliente.cApePat + " " + clsCliente.cApeMat),
                cTipoDoc = clsCliente.cTipoDoc,
                cDireccion = FunGeneral.FormatearCadenaTitleCase(clsCliente.cDireccion),
                cDocumento = clsCliente.cDocumento,
                SimboloMoneda = dvc.SimboloMoneda,
                cCodDocumentoVenta = Convert.ToString(cboDVenta.SelectedValue),
                NombreDocumento = Convert.ToString(cboDVenta.Text),
                dFechaVenta = stDtFechaDePago,
                idMoneda = 1,
                nSubtotal = dvc.ValorVenta,
                nNroIGV = 18,
                nIGV = dvc.IGV,
                nMontoTotal = dvc.ImporteTotal,
                cUsuario = UsuarioDocumentoVenta,
                cVehiculos = PlacaVehiculo,
                cDescripcionTipoPago = TipoPago,
                cDescripEstadoPP = "PAGADO",
                cTipoVenta = "PAGOS PENDIENTES",
                cEstado = "PAGOSPENDIENTES",
                //est0 = tabIndex == 0 ? false : true,
                est1 = false

            });
            return lsDocVenta;


            //DocumentoVenta.cTipoDoc = Convert.ToString(cboTipoDocumento.Text);
            //DocumentoVenta.cVehiculos = lstvehiculo[0].vPlaca;
            //lstDocVenta.Add(DocumentoVenta);
        }
        private byte[] fnEnviarFacturaASunat()
        {
            //Cargo clsCargo1 = lstDocumentoVentaEmitir.Find(i => i.cCodTab == cboComprobanteP.SelectedValue.ToString());
            EmitirFactura emf = new EmitirFactura();
            String rutaArchivo = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR\";
            byte[] imageBytes = File.ReadAllBytes(rutaArchivo + "QR\\QrDefecto.png");
        
                if (clsDocumentoVentaEmitir.cCodTab == "DOVE0002" || clsDocumentoVentaEmitir.cCodTab == "DOVE0001")
                {
                    intRespuestaSunat = 0;
                    int resp = emf.EmitirFacturasContado(clsCliente, lsDetalleVentaRecibidoParaEnviarASunat, lsDocumentoVentaParaXml, clsDocumentoVentaEmitir);
                    intRespuestaSunat = resp;
                    //resp = 0;
                    if (resp == 1)
                    {

                        String nombreQR = clsCliente.cDocumento + "-" + clsDocumentoVentaEmitir.nValor1 + "-" + clsDocumentoVentaEmitir.SerieDoc + "-" + FunGeneral.generarCorrelativoDocumento(Convert.ToInt32(clsDocumentoVentaEmitir.nValor2));
                        //bitmap.Save(rutaArchivo + "QR\\" + nombreQR + ".png");
                        imageBytes = File.ReadAllBytes(rutaArchivo + "QR\\" + nombreQR + ".png");
                    }
                }
                else
                {
                    intRespuestaSunat = 1;
                }

           
            //intRespuestaSunat = 1;
            return imageBytes;
        }

        private void fnCompletarPago(Int32 idTrandiaria, Int32 tipoCon)
        {
            BLVentaGeneral blV = new BLVentaGeneral();
            Boolean est = false;
            byte[] btImage = new byte[] { };
            List<xmlDocumentoVentaGeneral> lstXmlDocVenta = new List<xmlDocumentoVentaGeneral>();
            btImage = fnEnviarFacturaASunat();

            lstXmlDocVenta.Add(new xmlDocumentoVentaGeneral
            {
                xmlDocumentoVenta = lsDocumentoVentaParaXml,
                xmlDetalleVentas = lsDetalleVentaRecibidoParaXml,
                imgDocumento= btImage

            });
           
            if (intRespuestaSunat == 1)
            {
                est = blV.blGuardarpagosPendientes(idTrandiaria, lstPagosTrand, lstXmlDocVenta, tipoCon);
                if (est == true)
                {
                    MessageBox.Show("Importe guardado Exitosamente", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fnBusacarVentas(0, -1);
                    estadoGuardarPago = false;
                }
                else
                {
                    MessageBox.Show("Error al guardar Importe", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error al enviar documento a la sunat", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            fnBusacarVentas(0, -1);
        }

        private void chkHabilitarFechasBus_CheckedChanged(object sender, EventArgs e)
        {
            fnActivarFechas();
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            var est = FunValidaciones.fnValidarCombobox(cboMoneda, erMoneda, imgMoneda);
            estMoneda = est.Item1;
            clsMoneda = lstMon.Find(i => i.idMoneda == Convert.ToInt32(cboMoneda.SelectedValue));
        }

        private void cboTipoDocEmitir_SelectedIndexChanged(object sender, EventArgs e)
        {
            var est = FunValidaciones.fnValidarCombobox(cboTipoDocEmitir, lblDocVenta, pbDocVenta);
            estDocumento = est.Item1;
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecha.Checked)
            {
                gbFecha.Enabled = true;
            }
            else
                gbFecha.Enabled = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fnBuscarPagosPendientes(0, 0);
        }

        private void dgvCuotas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvCuotas.Columns[e.ColumnIndex].Name == "Icono" && e.RowIndex >= 0)
            {


                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvCuotas.Rows[e.RowIndex].Cells["Icono"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\Impresora.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvCuotas.Rows[e.RowIndex].Height = 45;
                this.dgvCuotas.Columns[e.ColumnIndex].Width = 45;


                e.Handled = true;



            }
        }
        private void fnBuscarDocumentoVenta(Int32 cCodVenta)
        {
            BLOtrasVenta objTipoVenta = new BLOtrasVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtResp = new DataTable();
            List<TipoVenta> lsTipoVenta = new List<TipoVenta>();
            Int32 filas = 20;
            List<xmlDocumentoVentaGeneral> xmlDocumentoVenta = new List<xmlDocumentoVentaGeneral>();
            xmlDocumentoVentaGeneral xmlDocVenta = new xmlDocumentoVentaGeneral();

            try
            {
                xmlDocVenta = objTipoVenta.blBuscarDocumentoPagoPendientes(cCodVenta, -1);
                xmlDocumentoVenta.Add(xmlDocVenta);

                Consultas.frmVPVenta abrirFrmVPOtrasVentas = new Consultas.frmVPVenta();
                abrirFrmVPOtrasVentas.Inicio(xmlDocumentoVenta[0].xmlDocumentoVenta, xmlDocumentoVenta[0].xmlDetalleVentas, xmlDocumentoVenta[0].imgDocumento, 1);
                

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnListarProveedorActivo", ex.Message);

            }
            finally
            {
                objUtil = null;
                objTipoVenta = null;
                lsTipoVenta = null;
            }
        }

        private void dgvCuotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCuotas.Columns["Icono"].Index && e.RowIndex >= 0)
            {
                Int32 idTipoVenta = Convert.ToInt32(dgvCuotas.CurrentRow.Cells[1].Value);
                fnBuscarDocumentoVenta(idTipoVenta);
                var mousePosition = dgvCuotas.PointToClient(Cursor.Position);
            }
            else
            {
                Int32 idCliente = Convert.ToInt32(dgvCuotas.CurrentRow.Cells[0].Value);
                clsCliente = lstCliente.Find(i => i.idCliente == idCliente);
                frmRegistrarVenta.fnLlenarComprobante(cboDVenta, "DOVE", clsCliente.cTiDo, 0); ;
            }

        }

        private void actualizarPágoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 IdConcepto = Convert.ToInt32(dgvCuotas.CurrentRow.Cells[0].Value);
            lstDetalleVenta.Clear();
            foreach (DataRow dt in dtResultados.Rows)
            {
                if (IdConcepto == Convert.ToInt32(dt["idCOncepto"].ToString()))
                {
                    stDtFechaDePago = Convert.ToDateTime(dt["dFechaPago"]);
                    UsuarioDocumentoVenta = dt["cPrimerNom"].ToString() + dt["cApePat"] + dt["cApeMat"];
                    IdUsuarioRegistro = Convert.ToInt32(dt["idUsuario"]);
                    TipoPago = dt["TipoPago"].ToString();
                    PlacaVehiculo = dt["vPlaca"].ToString();
                    lstDetalleVenta.Add(new DetalleVenta
                    {
                        Numeracion = 1,
                        Descripcion = "CUOTA " + dt["cNombreOperacion"].ToString(),
                        idTipoTarifa = 0,
                        PrecioUni = Convert.ToDecimal(dt["importe"].ToString()),
                        Descuento = 0,
                        gananciaRedondeo = 0,
                        TotalTipoDescuento = 0,
                        IdTipoDescuento = 0,
                        Cantidad = 1,
                        Couta = 0,
                        Importe = Convert.ToDecimal(dt["importe"].ToString()),
                        cSimbolo = "S/."
                    });
                    break;
                }

            }
            lstDocumentoVenta = fnDocumentoVentaHeaderActualizar(fnCalcularCabeceraDetalle(lstDetalleVenta));

            List<xmlDocumentoVentaGeneral> lstXmlDocVenta = new List<xmlDocumentoVentaGeneral>();
            lstXmlDocVenta.Add(new xmlDocumentoVentaGeneral
            {
                xmlDocumentoVenta = lstDocumentoVenta,
                xmlDetalleVentas = lstDetalleVenta
            });
            DialogResult res = MessageBox.Show("Desea Actualizar Los Datos", "Aletar", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (res == DialogResult.OK)
            {
                fnAcutualizarFacura(lstXmlDocVenta, IdConcepto, stDtFechaDePago, IdUsuarioRegistro);
            }

            //Consultas.frmVPVenta abrirFrmVPOtrasVentas = new Consultas.frmVPVenta();
            //abrirFrmVPOtrasVentas.Inicio(lstDocumentoVenta, lstDetalleVenta, 1);
        }

        private void fnAcutualizarFacura(List<xmlDocumentoVentaGeneral> xmlDocVenta, Int32 idConcepto, DateTime FechaRegistro, Int32 Usuario)
        {

            BLVentaGeneral blV = new BLVentaGeneral();
            Boolean dt = false;
            dt = blV.blActualizarPagos(xmlDocVenta, idConcepto, FechaRegistro, Usuario);

            if (dt == true)
            {
                MessageBox.Show("Los Datos se Han Actualizado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error Al actualizar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public DetalleVentaCabecera fnCalcularCabeceraDetalle(List<DetalleVenta> lstDV)
        {
            DetalleVentaCabecera clsDVC = new DetalleVentaCabecera();
            DetalleVenta dvMensual = new DetalleVenta();
            clsDVC.IGV = 0;
            clsDVC.ImporteTotal = lstDV.Sum(item => item.Importe);
            clsDVC.ValorVenta = (clsDVC.ImporteTotal / 1.18m);
            clsDVC.IGV = (clsDVC.ImporteTotal - clsDVC.ValorVenta);
            clsDVC.SimboloMoneda = clsMoneda.cSimbolo;
            clsDVC.NombreDocumento = Convert.ToString(cboDVenta.Text);
            clsDVC.CodDocumento = Convert.ToString(cboDVenta.SelectedValue);

            return clsDVC;
        }

        private void cboPaginaCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dEstadoPagina == false)
            {
                fnBuscarPagosPendientes(Convert.ToInt32(cboPaginaCuotas.Text), 0);
            }
            
        }

        private void txtBuscarFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarPagosPendientes(0, 0);
            }
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void verHistorialDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {


            IdTra = Convert.ToInt32(dgvVentas.CurrentRow.Cells[0].Value);
            chkFecha.Checked = false;
            fnBuscarPagosPendientes(0, 0);

            
            tabCuotas.SelectedIndex = 1;
        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvVentas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
                    if (!clickedRow.Selected)
                    {
                        dgvVentas.CurrentCell = clickedRow.Cells[e.ColumnIndex];

                    }
                    else
                    {
                        var mousePosition = dgvVentas.PointToClient(Cursor.Position);
                       
                    }

                }
            }
        }

        private void btnGusrdarPago_Click(object sender, EventArgs e)
        {
            fnCargarDatosDeDocumento();
        }

        private void cboTipoDocEmitir_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboTipoDocEmitir, lblDocVenta, pbDocVenta);
            estDocumento = result.Item1;
            //msgComprabanteP = result.Item2;
            if (estDocumento == true)
            {
                fnLlenadClaseDocumento();
               
            }
        }

        private void PanelTop_Paint(object sender, PaintEventArgs e)
        {

        }

     

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dEstadoBusquedaPaginacion == false)
            {
                fnBusacarVentas(Convert.ToInt32(cboPagina.Text), -1);
            }
        }

        private void dtFechaPago_ValueChanged(object sender, EventArgs e)
        {
            //var res = FunGeneral.fnValidarFechaPago(dtFechaPago, pbFechaPago, 1);
            estFecha = true;// res.Item1;
            erFechaPago.Text = ""; //res.Item2;
            stDtFechaDePago = FunGeneral.fnUpdateFechas(dtFechaPago.Value);
        }
    }
}
