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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Mantenedores;
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
        static Boolean estadoGuardarPago = false;
        static DateTime stDtFechaDePago = DateTime.Now;
        Boolean estFecha = false, estMoneda = false, estDocumento = false;
        static List<Moneda> lstMon = new List<Moneda>();
        static Moneda clsMoneda = new Moneda();
        static List<Cliente> lstCliente = new List<Cliente>();
        static Cliente clsCliente = new Cliente();
        static List<DocumentoVenta> lstDocumentoVenta = new List<DocumentoVenta>();
        static List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();
        static DataTable dtResultados = new DataTable();
        static int tabInicio = 0;
        static bool dEstadoBusquedaPaginacion = false;
        string UsuarioDocumentoVenta="";
        string TipoPago = "";
        string PlacaVehiculo = "";
        Int32 IdUsuarioRegistro =0 ;
        public void fnRecuperarTipoPago(List<Pagos> lstEntidades)
        {
            lstPagosTrand = lstEntidades;
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
                FunGeneral.fnValidarFechaPago(dtFechaPago, pbFechaPago, 0);
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
                dtFechafinal.Value = Variables.gdFechaSis;
                dtFechaInicio.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
                fnLLenarMoneda(cboMoneda, 0, false);
                cboMoneda.SelectedValue = 1;
                if (Variables.gsCargoUsuario== "PETR0007")
                {
                    contextMenuStrip1.Enabled=true;
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
            Int32 numRows = 0;
            Int32 filas = 6;
            String cBuscar = txtBuscarFecha.Text.ToString();
            String fechaInicio = FunGeneral.GetFechaHoraFormato(dtFechaInicio.Value, 5);
            String fechaFin = FunGeneral.GetFechaHoraFormato(dtFechafinal.Value, 5);
            Boolean chkHabilita = chkHabilitarFechasBus.Checked;
            dtResultados = new DataTable();
            dt = blV.blBuscarPagosPendientes(chkHabilita, cBuscar, fechaInicio, fechaFin, numPagina, TipoCon);
            dtResultados = dt;
            numRows = dt.Rows.Count;
            DataGridView dgv = dgvCuotas;
            try
            {
                lstCliente.Clear();
                if (numRows > 0)
                {
                    pnDatosPago.Visible = true;
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
                        dEstadoBusquedaPaginacion = false;
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
                            cDireccion = dr["cDireccion"].ToString()+" " + dr["cNomdist"]+" "+ dr["cNomProv"]+" "+ dr["cNomDep"]

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
            dEstadoBusquedaPaginacion = true;

            dt = blV.blBuscarVentaPagoPendientes(chkHabilita, cBuscar, fechaInicio, fechaFin, numPagina, tipoCon);

            numRows = dt.Rows.Count;
            DataGridView dgv = dgvVentas;

            try
            {
                lstCliente.Clear();
                if (numRows > 0)
                {
                    pnDatosPago.Visible = true;
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
                        Double importeRestante = Convert.ToDouble(dr["TotalPago"]) - Convert.ToDouble(dr["pagaCon"]);

                        lstDVenta.Add(new ReporteBloque
                        {
                            idAuxiliar = Convert.ToInt32(dr["idTrandiaria"]),
                            ImporteRow = importeRestante,
                            MasDetallereporte = dr["cNombreOperacion"].ToString(),
                            idMoneda = Convert.ToInt32(cboMoneda.SelectedValue),
                            Codigoreporte = dr["vehiculo"].ToString()

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
                            cDireccion = dr["cDireccion"].ToString()

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
                                        (FunGeneral.fnFormatearPrecio("S/.", importeRestante, 1)),
                                        dr["cUser"],
                                        dr["cNomTab"]
                                    );
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
                    dgv.Columns[10].Width = 30;
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

        private List<DetalleVenta> fnDetalleventa()
        {
            List<DetalleVenta> lstDetV = new List<DetalleVenta>();
            Int32 cantidad = 1;
            Double precioUnitario = lstPagosTrand[0].PagaCon;
            double importe = lstPagosTrand[0].PagaCon;
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
        private List<DetalleVenta> fnDetalleventaActualizar()
        {
            List<DetalleVenta> lstDetV = new List<DetalleVenta>();
            Int32 cantidad = 1;
            Double precioUnitario = lstPagosTrand[0].PagaCon;
            double importe = lstPagosTrand[0].PagaCon;
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
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvR = dgvVentas.Rows[e.RowIndex];
            Int32 idTrandiaria = Convert.ToInt32(dgvR.Cells[0].Value);
            DataGridView dgv = dgvVentas;
            if (dgv.Columns[e.ColumnIndex].Name == "Icono")
            {
                if (estDocumento && estMoneda && estFecha)
                {
                    Double montoRestante = Convert.ToDouble(dgvR.Cells[0].Value);
                    Procesos.frmTipoPago fmr = new Procesos.frmTipoPago();
                    ReporteBloque repBloque = lstDVenta.Find(i => i.idAuxiliar == idTrandiaria);
                    fmr.Inicio(-4, repBloque.ImporteRow, lstDVenta[0].idMoneda == 1 ? "S/" : "$");
                    clsCliente = lstCliente.Find(i => i.idCliente == idTrandiaria);

                    if (estadoGuardarPago == true)
                    {
                        frmRegistrarEgresos f = new frmRegistrarEgresos();

                        lstDetalleVenta = fnDetalleventa();
                        lstDocumentoVenta = fnDocumentoVentaHeader(f.fnCalcularCabeceraDetalle(lstDetalleVenta));

                        //estadoGuardarPago = false;
                        //fnGenerarDocumento();
                        //if (estadoGuardarPago==true)
                        //{
                        fnCompletarPago(idTrandiaria, 0);
                        //}

                    }
                }
                else
                {
                    MessageBox.Show("Por favor complete todo los datos", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                clsCliente = lstCliente.Find(i => i.idCliente == idTrandiaria);
                frmRegistrarVenta.fnLlenarComprobante(cboTipoDocEmitir, "DOVE", clsCliente.cTiDo, 0); ;
            }


        }
        private void fnGenerarDocumento()
        {
            Consultas.frmVPVenta frm = new Consultas.frmVPVenta();
            frmRegistrarEgresos f = new frmRegistrarEgresos();

            lstDetalleVenta = fnDetalleventa();
            lstDocumentoVenta = fnDocumentoVentaHeader(f.fnCalcularCabeceraDetalle(lstDetalleVenta));
            frm.Inicio(lstDocumentoVenta, lstDetalleVenta, -5);
        }
        private List<DocumentoVenta> fnDocumentoVentaHeader(DetalleVentaCabecera dvc)
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
                SimboloMoneda = clsMoneda.cSimbolo,
                cCodDocumentoVenta = Convert.ToString(cboTipoDocEmitir.SelectedValue),
                NombreDocumento = Convert.ToString(cboTipoDocEmitir.Text),
                dFechaVenta = FunGeneral.fnUpdateFechas(stDtFechaDePago),
                idMoneda = clsMoneda.idMoneda,
                nSubtotal = dvc.SubTotal,
                nNroIGV = 18,
                nIGV = dvc.IGV,
                nMontoTotal = dvc.Total,
                cUsuario = clsUsuario.cPrimerNom + " " + clsUsuario.cApePat + " " + clsUsuario.cApeMat,
                cVehiculos = lstDVenta[0].Codigoreporte,
                cDescripcionTipoPago = lstPagosTrand[0].cDescripTipoPago,
                cDescripEstadoPP = lstPagosTrand[0].cEstadoPP == "ESPP0001" ? "PAGADO" : "PAGO INCONPLETO",
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
                nSubtotal = dvc.SubTotal,
                nNroIGV = 18,
                nIGV = dvc.IGV,
                nMontoTotal = dvc.Total,
                cUsuario = UsuarioDocumentoVenta,
                cVehiculos = PlacaVehiculo,
                cDescripcionTipoPago = TipoPago,
                cDescripEstadoPP = "PAGADO" ,
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

        private void fnCompletarPago(Int32 idTrandiaria, Int32 tipoCon)
        {
            BLVentaGeneral blV = new BLVentaGeneral();
            Boolean est = false;

            List<xmlDocumentoVentaGeneral> lstXmlDocVenta = new List<xmlDocumentoVentaGeneral>();
            lstXmlDocVenta.Add(new xmlDocumentoVentaGeneral
            {
                xmlDocumentoVenta = lstDocumentoVenta,
                xmlDetalleVentas = lstDetalleVenta
            });

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
                xmlDocVenta = objTipoVenta.blBuscarDocumentoPagoPendientes(cCodVenta,-1);
                xmlDocumentoVenta.Add(xmlDocVenta);

                Consultas.frmVPVenta abrirFrmVPOtrasVentas = new Consultas.frmVPVenta();
                abrirFrmVPOtrasVentas.Inicio(xmlDocumentoVenta[0].xmlDocumentoVenta, xmlDocumentoVenta[0].xmlDetalleVentas, 1);

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
            else {
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
                        PrecioUni = Convert.ToDouble(dt["importe"].ToString()),
                        Descuento = 0,
                        gananciaRedondeo = 0,
                        TotalTipoDescuento = 0,
                        IdTipoDescuento = 0,
                        Cantidad = 1,
                        Couta = 0,
                        Importe = Convert.ToDouble(dt["importe"].ToString()),
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
             DialogResult res= MessageBox.Show("Desea Actualizar Los Datos", "Aletar", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
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
            dt = blV.blActualizarPagos(xmlDocVenta,idConcepto,FechaRegistro,Usuario);

            if (dt == true)
            {
                MessageBox.Show("Los Datos se Han Actualizado","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("Error Al actualizar","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        

        public DetalleVentaCabecera fnCalcularCabeceraDetalle(List<DetalleVenta> lstDV)
        {
            DetalleVentaCabecera clsDVC = new DetalleVentaCabecera();
            DetalleVenta dvMensual = new DetalleVenta();
            clsDVC.IGV = 0;
            clsDVC.Total = lstDV.Sum(item => item.Importe);
            clsDVC.SubTotal = (clsDVC.Total / 1.18);
            clsDVC.IGV = (clsDVC.Total - clsDVC.SubTotal);
            clsDVC.SimboloMoneda = clsMoneda.cSimbolo;
            clsDVC.NombreDocumento = Convert.ToString(cboDVenta.Text);
            clsDVC.CodDocumento = Convert.ToString(cboDVenta.SelectedValue);

            return clsDVC;
        }

        private void cboPaginaCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarPagosPendientes(Convert.ToInt32(cboPaginaCuotas.Text) , 0);
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
            var res = FunGeneral.fnValidarFechaPago(dtFechaPago, pbFechaPago, 1);
            estFecha = res.Item1;
            erFechaPago.Text = res.Item2;
            stDtFechaDePago = FunGeneral.fnUpdateFechas(dtFechaPago.Value);
        }
    }
}
