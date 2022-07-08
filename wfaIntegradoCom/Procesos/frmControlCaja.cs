using CapaDato;
using CapaEntidad;
using CapaNegocio;
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

namespace wfaIntegradoCom.Procesos
{
    public partial class frmControlCaja : Form
    {
        public frmControlCaja()
        {
            InitializeComponent();
        }
        BLControlCaja bl;
        static Int32 tabInicio=0;
        List<ReporteBloque> lsReporteBloque = new List<ReporteBloque>();
        List<ReporteBloque> lsReporteBloqueGen = new List<ReporteBloque>();
        String codOperacion = "";
        String codTipoReporte = "";
        private void frmControlCaja_Load(object sender, EventArgs e)
        {
            try
            {
                dtFechaFinG.Value = Variables.gdFechaSis;
                dtFechaInicioG.Value = dtFechaFinG.Value.AddDays(-(dtFechaFinG.Value.Day - 1));

                //FunGeneral.fnLlenarTablaCodTipoCon(cboMetodopago, "TIPA",true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboTipoReporte, "TRPT", false);
                //FunGeneral.fnLlenarTablaCodTipoCon(cboDocumentoVenta, "DOVE",true);
                frmBuscarVentas frmBV = new frmBuscarVentas();
                //frmBV.fnlistarUsuario(cboUsuario, 2, true);

                frmRegistrarVenta frm = new frmRegistrarVenta();
                //frm.fnLlenarTipoTarifa(0, cboTipoVenta, true);
                //frm.fnLlenarTipoPlan(0, cboTipoPlanP, 0);
                //fnListarTipoPago(cboTipoPago,0, "ESDOV", true);

                //panel1.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                //fnActivarControles(false);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void fnListarTipoPago(ComboBox cbo,Int32 idTipPlan,String id,Boolean estado)
        {
            bl = new BLControlCaja();
            List<ControlCaja> lstControl = new List<ControlCaja>();

            lstControl= bl.blFnLLenarTipoPago( idTipPlan,id, estado);

            cbo.DataSource = null;
            cbo.ValueMember = "codTipoPago";
            cbo.DisplayMember = "descripTipoPago";
            cbo.DataSource = lstControl;

        }

        //private void cboMetodopago_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    frmTipoPago.fnLlenarCombobox(btnEntidadPago,cboMetodopago.SelectedValue.ToString(),0,true);
        //}

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                fnBuscarVentasCaja(codOperacion, 0,-1);
            }
        }
        private void fnBuscarVentasCaja(String codOperacion, Int32 numPagina, Int32 tipoCon)
        {
            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();
            Busquedas clsBus = new Busquedas();

            clsBus.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value,5);
            clsBus.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value,5);
            clsBus.cod1 = cboTipoReporte.SelectedValue.ToString();
            clsBus.cod2 = codOperacion;
            clsBus.cod3 = siticonePanel3.Visible == false? codOperacion: cboFiltro.SelectedValue.ToString();
            clsBus.cod4 = cboSubFiltro.SelectedValue.ToString();
            clsBus.numPagina = numPagina;
            clsBus.tipoCon = tipoCon;
            clsBus.cBuscar = siticoneTextBox1.Text.ToString();
            clsBus.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBus.chkActivarDia = chkDiaEspecificoG.Checked;
            clsBus.idUsuario = 0;

            Int32 filas = 10;

            dtRes = bl.blfnBuscarVentasCaja(clsBus);
            Int32 totalRows = dtRes.Rows.Count;
            dgvListaVentas.Rows.Clear();

            Int32 y = 0;

            if (totalRows>0)
            {
                if (numPagina == 0)
                {
                    y = 0;
                }
                else
                {
                    tabInicio = (numPagina - 1) * filas;
                    y = tabInicio;
                }
                foreach (DataRow dr in dtRes.Rows)
                {
                    dgvListaVentas.Rows.Add(
                        dr["idTrandiaria"].ToString(),
                        //dr["idDocumentoVenta"].ToString(),
                        y+1,
                       FunGeneral.GetFechaHoraFormato(Convert.ToDateTime(dr["fechaPago"]), 1),
                       dr["cNombreOperacion"],
                       dr["metodopago"],
                       dr["cNombreEntidad"].ToString()== "CONTADO"?"": dr["cNombreEntidad"],
                       dr["cNumeroOperacion"],
                       dr["nomDocumentoVenta"],
                       dr["tipotarifa"],
                       dr["cUser"],
                       FunGeneral.fnFormatearPrecio(dr["cSimbolo"].ToString(), Convert.ToDouble(dr["TotalPago"]),1)
                        );
                    y += 1;
                }

                if (numPagina == 0)
                {
                    gbPaginacion.Visible = true;
                    Int32 totalRegistros = Convert.ToInt32(dtRes.Rows[0][0]);
                    FunValidaciones.fnCalcularPaginacion(totalRegistros, filas, totalRows, cboPagina, btnTotalPag, btnNumFilas, btnTotalReg);
                }

                siticoneLabel14.Text = FunGeneral.fnFormatearPrecio("S/.", Convert.ToDouble(dtRes.Rows[0][1]), 0);
                dgvListaVentas.Visible = true;
            }
            else
            {
                //btnMontoTotal.Text = FunGeneral.fnFormatearPrecio("S/.", Convert.ToDouble(000), 0);
            }
            
        }
        private void fnBuscarReporteGeneralVentas(SiticoneDataGridView dgv, Int32 numPagina, Int32 tipoCon)
        {
            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();
            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBusq.chkActivarDia = chkDiaEspecificoG.Checked;
            clsBusq.dtFechaIni= FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value, 5);
            clsBusq.dtFechaFin= FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value, 5);
            clsBusq.cod1= cboTipoReporte.Items.Count == 0?"0": cboTipoReporte.SelectedValue.ToString();
            clsBusq.cod2= tipoCon==-1?"": codOperacion;
            clsBusq.cod3= cboOperacion.SelectedValue.ToString();
            clsBusq.cod4= "";
            clsBusq.cBuscar= txtBuscarRepGeneral.Text.ToString();
            clsBusq.numPagina = numPagina;
            clsBusq.tipoCon = tipoCon;

            String codTipoOperacion = "";

            Int32 TipoPlan = 0;
            Int32 tipotarifa = 0;

            String cBuscar = txtBuscarRepGeneral.Text.ToString();
            Boolean chkHabilitarFechas = chkHabilitarFechasBusG.Checked;
            Boolean chkDiaEsp = chkDiaEspecificoG.Checked;

            Int32 filas = 10;

            lsReporteBloque = bl.BuscarReporteGeneralVentas( clsBusq);
            Int32 totalRows = lsReporteBloque.Count;

            siticoneDataGridView1.Visible = false;
            lblHeaderDetalle.Visible = false;
            dgvEmergente.Visible = false;

             Int32 y = 0;

            if (totalRows>0)
            {
                if (tipoCon == -1)
                {
                    lsReporteBloqueGen = lsReporteBloque;
                    dgv.Columns.Clear();
                    dgv.Rows.Clear();
                    dgv.Columns.Add("id", "id");
                    dgv.Columns.Add("num", "N°");
                    dgv.Columns.Add("detalle", "Detalle");
                    dgv.Columns.Add("cantidad", "Cantidad");
                    dgv.Columns.Add("Importe", "Importe");

                    if (numPagina == 0)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (numPagina - 1) * filas;
                        y = tabInicio;
                    }

                    for (Int32 i = 0; i < totalRows; i++)
                    {
                        ReporteBloque clsRep = lsReporteBloque[i];
                        dgv.Rows.Add(
                            clsRep.Codigoreporte,
                            y + 1,
                            clsRep.Detallereporte,
                            clsRep.Cantidad,
                            FunGeneral.fnFormatearPrecio(clsRep.SimboloMoneda, clsRep.ImporteRow, 0)
                            );
                        y += 1;
                        dgv.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgv.Rows[i].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                    dgv.Rows.Add("", "", "", "", "");
                    dgv.Rows.Add("TOTAL", "", "IMPORTE TOTAL", "", FunGeneral.fnFormatearPrecio("S/.", lsReporteBloque.Sum(i => i.idMoneda == 2 ? (i.ImporteTipoCambio * i.ImporteRow) : i.ImporteRow), 0));
                    dgv.Rows[y + 1].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv.Rows[y + 1].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 10;
                    dgv.Columns[2].Width = 100;
                    dgv.Columns[3].Width = 20;
                    dgv.Columns[4].Width = 100;
                    dgv.Height = ((totalRows+3) * (dgv.ThemeStyle.RowsStyle.Height+ 2));
                    dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    lblMontoTotalRepBloque.Text = FunGeneral.fnFormatearPrecio("S/.", lsReporteBloque.Sum(i => i.idMoneda==2?(i.ImporteTipoCambio*i.ImporteRow):i.ImporteRow), 0);

                }else if (tipoCon==-2)
                {
                    ReporteBloque clsReporte = lsReporteBloqueGen.Find(i => i.Codigoreporte == codOperacion);
                    dgv.Columns.Clear();
                    dgv.Rows.Clear();
                    dgv.Columns.Add("id", "id");
                    dgv.Columns.Add("detalle", "Detalle de "+clsReporte.Detallereporte);
                    dgv.Columns.Add("cantidad", "Cantidad");
                    dgv.Columns.Add("Importe", "Importe");
                    dgv.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    lblHeaderDetalle.Text = "Detalle de " + clsReporte.Detallereporte;
                    lblHeaderDetalle.Visible = true;
                    for (Int32 i = 0; i < totalRows; i++)
                    {
                        ReporteBloque clsRep = lsReporteBloque[i];
                        dgv.Rows.Add(
                            clsRep.Codigoreporte,
                            clsRep.Detallereporte,
                            clsRep.Cantidad,
                            FunGeneral.fnFormatearPrecio(clsRep.SimboloMoneda, clsRep.ImporteRow, 0)
                            );
                        y += 1;
                        dgv.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgv.Rows[i].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                    dgv.Visible = true;

                    dgv.Rows.Add("","","","");
                    dgv.Rows.Add("TOTAL","IMPORTE TOTAL","", FunGeneral.fnFormatearPrecio("S/.", lsReporteBloque.Sum(i => i.idMoneda == 2 ? (i.ImporteTipoCambio * i.ImporteRow) : i.ImporteRow), 0));
                    dgv.Rows[y + 1].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv.Rows[y + 1].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 100;
                    dgv.Columns[2].Width = 20;
                    dgv.Columns[3].Width = 100;
                    dgv.ColumnHeadersVisible = false;

                    
                    dgv.Height = ((totalRows+2) * (dgv.ThemeStyle.RowsStyle.Height+2));
                    dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                }
                
                dgv.Rows[y + 1].DefaultCellStyle.ForeColor = Color.White;
                dgv.Rows[y + 1].DefaultCellStyle.BackColor = Color.Red;
                dgv.Rows[y + 1].DefaultCellStyle.Font= new Font("Arial", 15F, GraphicsUnit.Pixel);
                //this.dgvListaPorBloque.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;




                //if (numPagina == 0)
                //{
                //    //cboPaginacion.Visible = true;
                //    Int32 totalRegistros = Convert.ToInt32(dtRes.Rows[0][0]);
                //    FunValidaciones.fnCalcularPaginacion(totalRegistros, filas,  totalRows, cboPagina,btnTotalPag,btnNumFilas,btnTotalReg);
                //}


            }
            else
            {
                dgv.Columns.Clear();
                dgvListaPorBloque.Columns.Add("id", "NO SE ENCONTRARON RESULTADOS PARA LA BUSQUEDA");
                lblMontoTotalRepBloque.Text = FunGeneral.fnFormatearPrecio("S/.", Convert.ToDouble(000), 0);
            }
            
        }

        private void siticoneLabel3_Click(object sender, EventArgs e)
        {

        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarVentasCaja("",0, -1);
        }

        private void cboTipoPlanP_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fnListarTipoPago(cboTipoPago, Convert.ToInt32(cboTipoPlanP.SelectedValue), "ESDOV", true);
            //Int32 cbo = Convert.ToInt32(cboTipoPlanP.SelectedValue);
            //if (codTipoReporte == "TRPT0001")
            //{
            //    if (codOperacion == "3" || codOperacion == "5")
            //    {
            //        if (codOperacion == "3")
            //        {
            //            if (cbo==1)
            //            {
            //                cboTipoPago.SelectedValue = "ESDOV001";

            //            }else if (cbo == 2)
            //            {
            //                cboTipoPago.SelectedValue = "ESDOV002";

            //            }

            //        }
            //        else if (codOperacion == "5")
            //        {
            //            if (cbo == 1)
            //            {
            //                cboTipoPago.SelectedValue = "ESDOV003";
            //            }
            //            else if (cbo == 2)
            //            {
            //                cboTipoPago.SelectedValue = "ESDOV004";

            //            }

            //        }
            //        cboTipoPago.Enabled = false;
            //    }
            //}
        }

        private void chkHabilitarFechasBus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechasBusG.Checked == true)
            {
                gbHabilitarBusqFechas.Enabled = true;
                chkDiaEspecificoG.Visible = true;
            }
            else
            {
                gbHabilitarBusqFechas.Enabled = false;
                chkDiaEspecificoG.Visible = false;
                chkDiaEspecificoG.Checked = false;
            }
        }

        private void chkDiaEspecifico_CheckedChanged(object sender, EventArgs e)
        {
            fnValidarBusquedaDia();
        }
        private void fnValidarBusquedaDia()
        {
            if (chkDiaEspecificoG.Checked==true)
            {
                label2.Visible = false;
                dtFechaFinG.Visible = false;
                label1.Text = "Elija el dia para buscar:";
            }
            else
            {
                label2.Visible = true;
                dtFechaFinG.Visible = true;
                label1.Text = "Fecha Inicio:";
            }
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            fnBuscarVentasCaja(codOperacion, 0, -1);
        }

        private void cboTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            //siticonePanel2.Visible = false;
            pbIndica.Visible = false;
            String CodOperacion = cboTipoReporte.SelectedValue.ToString();
            //if (CodOperacion== "TRPT0001")
            //{
            //    FunGeneral.fnLlenarCboSegunTablaTipoCon(cboOperacion, "idOperacion", "cNombreOperacion", "OperacionHusat", "estValida", "1", false);
            //}
            //else if (CodOperacion == "TRPT0002")
            //{
            //    //siticonePanel2.Visible = true;
            //    FunGeneral.fnLlenarCboSegunTablaTipoCon(cboOperacion, "cCodTab", "cNomTab", "TablaCod", "cCodTab", "TIPA", false);

            //}
            //else if (CodOperacion == "TRPT0003")
            //{
            //    FunGeneral.fnLlenarCboSegunTablaTipoCon(cboOperacion, "idUsuario", "cUser", "Usuario", "estValida", "1", false);

            //}
            //else if (CodOperacion == "TRPT0004")
            //{
            //    FunGeneral.fnLlenarCboSegunTablaTipoCon(cboOperacion, "cCodTab", "cNomTab", "TablaCod", "cCodTab", "DOVE", false);


            //}


            fnBuscarReporteGeneralVentas(dgvListaPorBloque,0, -1);
           
        }

        private void txtBuscarRepGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                fnBuscarReporteGeneralVentas(dgvListaPorBloque,0, -1);
            }
        }

        private void fnLlenarUsuariosConAccion(ComboBox cbo,SiticoneDateTimePicker dtIni, SiticoneDateTimePicker dtFin,Boolean estado)
        {
            DAControlCaja dc = new DAControlCaja();
            List<Usuario> lstUsuario = new List<Usuario>();
            DataTable dt = new DataTable();
            String FI = FunGeneral.GetFechaHoraFormato(dtIni.Value, 5);
            String FF = FunGeneral.GetFechaHoraFormato(dtFin.Value, 5);
            Boolean chk = chkDiaEspecificoG.Checked;
            
            dt = dc.daDevolverSoloUsuario(chk, FI, FF);

                lstUsuario.Add(new Usuario(
                    Convert.ToInt32(0),
                    Convert.ToString(estado ? "TODOS" : "Selecc. Usuario")
                  ));

            foreach (DataRow drMenu in dt.Rows)
            {
                lstUsuario.Add(new Usuario(
                    Convert.ToInt32(drMenu["idUsuario"]),
                    Convert.ToString(drMenu["cUser"])
                    ));
            }
            cbo.ValueMember = "idUsuario";
            cbo.DisplayMember = "cUser";
            cbo.DataSource = lstUsuario;    

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvListaPorBloque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codTipoReporte = cboTipoReporte.SelectedValue.ToString();
            codOperacion = dgvListaPorBloque.CurrentRow.Cells[0].Value.ToString();

            dgvEmergente.Visible = false;
            if (codOperacion=="" || codOperacion == "TOTAL")
            {

            }
            else
            {
                if (codTipoReporte == "TRPT0001" || codTipoReporte == "TRPT0002")
                {
                    fnBuscarReporteGeneralVentas(siticoneDataGridView1, 0, -2);

                }
                else
                {
                    ReporteBloque clsReporte = lsReporteBloqueGen.Find(i => i.Codigoreporte == codOperacion);
                    lblHeaderDetalle.Text = "Detalle de " + clsReporte.Detallereporte;
                    lblHeaderDetalle.Visible = true;
                    fnBuscarDatosTablaEmergente(dgvEmergente, codOperacion);
                    dgvEmergente.Width = siticoneDataGridView1.Width;
                    dgvEmergente.Location = siticoneDataGridView1.Location;

                }
                Int32 x = dgvListaPorBloque.GetCellDisplayRectangle(e.RowIndex, e.ColumnIndex, false).Right;
                Int32 y = dgvListaPorBloque.GetRowDisplayRectangle(e.RowIndex, false).Y;
                //siticoneDataGridView1.Location = new Point(dgvListaPorBloque.Right + 15, y + 2);
                pbIndica.Location = new Point(dgvListaPorBloque.Right + 15, y + 2);
                pbIndica.Visible = true;
            }
            


        }

        private void dgvListaPorBloque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var mousePosition = dgvListaPorBloque.PointToClient(Cursor.Position);
            //cmsAccion.Show(dgvListaPorBloque, mousePosition.X, mousePosition.Y);
            dgvEmergente.Visible = false;

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        void cboCronograma_MouseWheel(object sender, MouseEventArgs e)
        {
            if (panel1.AutoScrollPosition.Y >=0)
            {
                fnActivarControles(false);
            }
            else
            {
                fnActivarControles(true);
            }
        }

        private void fnActivarControles(Boolean estado)
        {
            siticoneGroupBox4.Visible = estado;
            dgvListaVentas.Visible = estado;
            panel2.Visible = estado;
            siticonePanel6.Visible = estado;
            gbPaginacion.Visible = estado;
        }
        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                // Scroll has ended
                // You can use hScrollBar1.Value
            }
        }

        private void fnMostrarCombobox(String codTipoReporte, String codOperacion)
        {
            siticonePanel3.Visible = true;
            if (codTipoReporte == "TRPT0001")
            {
                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboFiltro, "cCodTab", "cNomTab", "TablaCod", "cCodTab", "TIPA", true);
                if (codOperacion == "4")
                {
                    //FunGeneral.fnLlenarCboSegunTablaTipoCon(cboFiltro,"idUsuario","cUser","Usuario","estValida","1",true);

                }
                else if (codOperacion == "3" || codOperacion == "5")
                {
                    
                  
                }
                else if (codOperacion == "6" || codOperacion == "7")
                {
                    
                }
            }
            else if (codTipoReporte == "TRPT0002")
            {
                siticonePanel3.Visible = false;
                frmTipoPago.fnLlenarCombobox(cboSubFiltro,codOperacion, 0, true);
            }else if (codTipoReporte == "TRPT0004")
            {
                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboFiltro, "cCodTab", "cNomTab", "TablaCod", "cCodTab", "TIPA", true);

            }
        }
        private void verDetalletsm_Click(object sender, EventArgs e)
        {
            if (dgvListaPorBloque.CurrentRow!=  null)
            {
                codTipoReporte = cboTipoReporte.SelectedValue.ToString();

                codOperacion = dgvListaPorBloque.CurrentRow.Cells[0].Value.ToString();
                fnMostrarCombobox(codTipoReporte, codOperacion);

                ReporteBloque clsReporte = lsReporteBloqueGen.Find(i => i.Codigoreporte == codOperacion);
                lblDetalleInfo.Text = clsReporte.Detallereporte + " Cantidad. " + clsReporte.Cantidad + " Importe. " + FunGeneral.fnFormatearPrecio(clsReporte.SimboloMoneda, clsReporte.ImporteRow, 0);
                fnBuscarVentasCaja(codOperacion, 0, -1);

                fnActivarControles(true);
                tabControl1.SelectedIndex = 1;
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            fnBuscarVentasCaja(codOperacion, 0, -1);
        }

        private void btnEntidadPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        
        }

        private void siticoneTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                fnBuscarVentasCaja(codOperacion, 0, -1);
            }
        }

        private void cboPagina_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            fnBuscarVentasCaja(codOperacion, Convert.ToInt32(cboPagina.Text), -1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fnBuscarReporteGeneralVentas(dgvListaPorBloque,0, -1);
        }

        private void dgvListaPorBloque_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var mousePosition = dgvListaPorBloque.PointToClient(Cursor.Position);
            //cmsAccion.Show(dgvListaPorBloque, mousePosition.X, mousePosition.Y);
        }

        private void dgvListaPorBloque_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
                    if (!clickedRow.Selected)
                    {
                        dgvListaPorBloque.CurrentCell = clickedRow.Cells[e.ColumnIndex];

                    }
                    else
                    {
                        var mousePosition = dgvListaPorBloque.PointToClient(Cursor.Position);
                        cmsAccion.Show(dgvListaPorBloque, mousePosition);
                    }

                }
            }
        }

        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (codTipoReporte != "TRPT0002")
            {
                if (cboFiltro.SelectedValue != null)
                {
                    frmTipoPago.fnLlenarCombobox(cboSubFiltro, cboFiltro.SelectedValue.ToString(), 0, true);
                }

            }
        }

        private void dgvListaPorBloque_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            DataGridView dgview = sender as DataGridView;

            String nombreCabecera = dgview.Columns[e.ColumnIndex].Name;
           

               
                
            
        }

        private void cboPagina_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            fnBuscarVentasCaja(codOperacion, Convert.ToInt32(cboPagina.Text), -1);
        }

        private void dtFechaInicioG_ValueChanged(object sender, EventArgs e)
        {
            fnLlenarUsuariosConAccion(cboOperacion, dtFechaInicioG, dtFechaFinG, true);
        }

        private void dtFechaFinG_ValueChanged(object sender, EventArgs e)
        {
            fnLlenarUsuariosConAccion(cboOperacion, dtFechaInicioG, dtFechaFinG, true);
        }

        private void cboOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarReporteGeneralVentas(dgvListaPorBloque, 0, -1);
        }

        private void siticoneDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String codSubReporte = siticoneDataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (codSubReporte=="" || codSubReporte == "TOTAL")
            {
                
            }
            else
            {
                Int32 x = siticoneDataGridView1.Left + 135;
                Int32 y = siticoneDataGridView1.GetRowDisplayRectangle(e.RowIndex, false).Y;
                dgvEmergente.Location = new Point(x, y + 60);
                dgvEmergente.Width = siticoneDataGridView1.Width - 135;
                fnBuscarDatosTablaEmergente(dgvEmergente, codSubReporte);
            }
            
        }
        private void fnBuscarDatosTablaEmergente(SiticoneDataGridView dgv,String codSubReporte)
        {

            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();
            Busquedas clsBus = new Busquedas();
            List<ReporteBloque> lstRep = new List<ReporteBloque>();

            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBusq.chkActivarDia = chkDiaEspecificoG.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value, 5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value, 5);
            clsBusq.cod1 = cboTipoReporte.Items.Count == 0 ? "0" : cboTipoReporte.SelectedValue.ToString();
            clsBusq.cod2 =  codOperacion;
            clsBusq.cod3 = cboOperacion.SelectedValue.ToString();
            clsBusq.cod4 = codSubReporte;
            clsBusq.cBuscar = txtBuscarRepGeneral.Text.ToString();
            clsBusq.numPagina = 0;
            clsBusq.tipoCon = -3;

            lstRep = bl.BuscarReporteGeneralVentas(clsBusq);
            dgv.Visible = false;
            dgv.Columns.Clear();
            dgv.Rows.Clear();
            ReporteBloque clsReporte = lsReporteBloque.Find(i => i.Codigoreporte == codSubReporte);
            dgv.Columns.Add("id", "id");
            dgv.Columns.Add("detalle", "Detalle de ");
            dgv.Columns.Add("cantidad", "Cantidad");
            dgv.Columns.Add("Importe", "Importe");
            dgv.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.None;
            //lblHeaderDetalle.Text = "Detalle de " + clsReporte.Detallereporte;
            lblHeaderDetalle.Visible = true;
            Int32 y = 0;
            if (clsBusq.numPagina == 0)
            {
                y = 0;
            }
            else
            {
                tabInicio = (clsBusq.numPagina - 1) * 20;
                y = tabInicio;
            }
            for (Int32 i = 0; i < lstRep.Count; i++)
            {
                ReporteBloque clsRep = lstRep[i];
                dgv.Rows.Add(
                    clsRep.Codigoreporte,
                   clsRep.Detallereporte.Length<=10?  Convert.ToDateTime(clsRep.Detallereporte).ToString("dd MMM yyyy"): clsRep.Detallereporte,
                    clsRep.Cantidad,
                    FunGeneral.fnFormatearPrecio(clsRep.SimboloMoneda, clsRep.ImporteRow, 0)
                    );
                y += 1;
                dgv.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Rows[i].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Rows[i].Cells[1].Style.Padding = new Padding(30, 0, 0, 0);
            }
            dgv.Visible = true;

            dgv.Rows.Add("", "", "", "");
            dgv.Rows.Add("TOTAL", "IMPORTE TOTAL DE " + clsReporte.Detallereporte, "", FunGeneral.fnFormatearPrecio("S/.", lstRep.Sum(i => i.idMoneda == 2 ? (i.ImporteTipoCambio * i.ImporteRow) : i.ImporteRow), 0));
            dgv.Rows[y + 1].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Rows[y + 1].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].Width = 20;
            dgv.Columns[3].Width = 100;
            dgv.ColumnHeadersVisible = false;


            dgv.Height = ((lstRep.Count + 2) * (dgv.ThemeStyle.RowsStyle.Height+1));
            dgv.Rows[y + 1].DefaultCellStyle.ForeColor = Color.White;
            dgv.Rows[y + 1].DefaultCellStyle.BackColor = Color.DarkRed;
            dgv.Rows[y + 1].Cells[1].Style.Padding = new Padding(30, 0, 0, 0);
            dgv.Rows[y + 1].DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
        }
    }
}
