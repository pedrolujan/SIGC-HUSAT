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
        static List<ReporteBloque> lstDVenta=new List<ReporteBloque>();
        static List<Pagos> lstPagosTrand = new List<Pagos>();
        static Boolean estadoGuardarPago = false;
        static DateTime stDtFechaDePago=DateTime.Now;
        Boolean estFecha=false, estMoneda=false,estDocumento=false;
        static List<Moneda> lstMon = new List<Moneda>();
        static Moneda clsMoneda = new Moneda();
        static List<Cliente> lstCliente=new List<Cliente>();
        static Cliente clsCliente=new Cliente();
        static List<DocumentoVenta> lstDocumentoVenta = new List<DocumentoVenta>();
        static List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();

        static int tabInicio = 0;
        static bool dEstadoBusquedaPaginacion = false;

        public  void fnRecuperarTipoPago(List<Pagos> lstEntidades)
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
            if (chkHabilitarFechasBus.Checked==true)
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
                fnLLenarMoneda(cboMoneda,0,false);
                cboMoneda.SelectedValue = 1;
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
        private void fnObtenerIconButonDePanel(SiticonePanel pn)
        {
           
        }

        private void fnBusacarVentas(Int32 numPagina,Int32 tipoCon)
        {
            BLVentaGeneral blV = new BLVentaGeneral();
            DataTable dt = new DataTable();
            Int32 numRows = 0;
            Int32 filas = 15;
            String cBuscar = txtBuscar.Text.ToString();
            String fechaInicio = FunGeneral.GetFechaHoraFormato(dtpFechaInicialBus.Value,5);
            String fechaFin = FunGeneral.GetFechaHoraFormato(dtpFechaFinalBus.Value,5);
            Boolean chkHabilita = chkHabilitarFechasBus.Checked;
            dEstadoBusquedaPaginacion = true;

            dt =blV.blBuscarVentaPagoPendientes(chkHabilita,cBuscar,fechaInicio,fechaFin,numPagina,tipoCon);
            numRows=dt.Rows.Count;
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
                    dgv.Columns.Add("Icono","Accion");   
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
                            Codigoreporte= dr["vehiculo"].ToString()

                        }) ;

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

                        }) ;

                        dgv.Rows.Add(
                                        dr["idTrandiaria"],
                                        y + 1,
                                       Convert.ToDateTime(dr["dFechaPago"]).ToString("dd MMM yyyy hh:mm tt"),
                                        dr["cNombre"]+" "+ dr["cApePat"],
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
                Descripcion = "CUOTA "+descripcion,
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
            if (dgv.Columns[e.ColumnIndex].Name== "Icono")
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
                    MessageBox.Show("Por favor complete todo los datos","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
                cCliente = FunGeneral.FormatearCadenaTitleCase(clsCliente.cNombre+" "+ clsCliente.cApePat+" "+ clsCliente.cApeMat),
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
                cDescripEstadoPP = lstPagosTrand[0].cEstadoPP=="ESPP0001"?"PAGADO":"PAGO INCONPLETO",
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
                xmlDocumentoVenta=lstDocumentoVenta,
                xmlDetalleVentas=lstDetalleVenta
            });

            est = blV.blGuardarpagosPendientes(idTrandiaria, lstPagosTrand, lstXmlDocVenta, tipoCon);
            if (est==true)
            {
                MessageBox.Show("Importe guardado Exitosamente","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                fnBusacarVentas(0, -1);
                estadoGuardarPago=false;
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
           var est= FunValidaciones.fnValidarCombobox(cboMoneda,erMoneda,imgMoneda);
            estMoneda = est.Item1;
            clsMoneda = lstMon.Find(i => i.idMoneda == Convert.ToInt32(cboMoneda.SelectedValue));
        }

        private void cboTipoDocEmitir_SelectedIndexChanged(object sender, EventArgs e)
        {
            var est = FunValidaciones.fnValidarCombobox(cboTipoDocEmitir, lblDocVenta, pbDocVenta);
            estDocumento = est.Item1;
        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dEstadoBusquedaPaginacion==false)
            {
                fnBusacarVentas(Convert.ToInt32(cboPagina.Text), -1);
            }
        }

        private void dtFechaPago_ValueChanged(object sender, EventArgs e)
        {
            var res= FunGeneral.fnValidarFechaPago(dtFechaPago, pbFechaPago, 1);
            estFecha = res.Item1;
            erFechaPago.Text = res.Item2;
            stDtFechaDePago = FunGeneral.fnUpdateFechas(dtFechaPago.Value);
        }
    }
}
