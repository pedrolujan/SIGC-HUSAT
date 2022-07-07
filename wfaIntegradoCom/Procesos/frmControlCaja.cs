using CapaEntidad;
using CapaNegocio;
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
        private void fnBuscarReporteGeneralVentas(Int32 numPagina, Int32 tipoCon)
        {
            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();
            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBusq.chkActivarDia = chkDiaEspecificoG.Checked;
            clsBusq.dtFechaIni= FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value, 5);
            clsBusq.dtFechaFin= FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value, 5);
            clsBusq.cod1= cboTipoReporte.SelectedValue.ToString();
            clsBusq.cod2= tipoCon==-1?"": codOperacion;
            clsBusq.cod3= "";
            clsBusq.cod4= "";
            clsBusq.cBuscar= txtBuscarRepGeneral.Text.ToString();
            clsBusq.numPagina = numPagina;
            clsBusq.tipoCon = tipoCon;

            String codTipoReporte = cboTipoReporte.SelectedValue.ToString();
            String codTipoOperacion = "";

            Int32 TipoPlan = 0;
            Int32 tipotarifa = 0;

            String cBuscar = txtBuscarRepGeneral.Text.ToString();
            Boolean chkHabilitarFechas = chkHabilitarFechasBusG.Checked;
            Boolean chkDiaEsp = chkDiaEspecificoG.Checked;

            Int32 filas = 10;

            lsReporteBloque = bl.BuscarReporteGeneralVentas( clsBusq);
            Int32 totalRows = lsReporteBloque.Count;
            
           

            Int32 y = 0;

            if (totalRows>0)
            {
                if (tipoCon == -1)
                {
                    lsReporteBloqueGen = lsReporteBloque;
                    dgvListaPorBloque.Columns.Clear();
                    dgvListaPorBloque.Rows.Clear();
                    dgvListaPorBloque.Columns.Add("id", "id");
                    dgvListaPorBloque.Columns.Add("num", "N°");
                    dgvListaPorBloque.Columns.Add("detalle", "Detalle");
                    dgvListaPorBloque.Columns.Add("cantidad", "Cantidad");
                    dgvListaPorBloque.Columns.Add("Importe", "Importe");
                    this.dgvListaPorBloque.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
                        dgvListaPorBloque.Rows.Add(
                            clsRep.Codigoreporte,
                            y + 1,
                            clsRep.Detallereporte,
                            clsRep.Cantidad,
                            FunGeneral.fnFormatearPrecio(clsRep.SimboloMoneda, clsRep.ImporteRow, 0)
                            );
                        y += 1;
                        dgvListaPorBloque.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgvListaPorBloque.Rows[i].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                    lblTotalBloque.Text="IMPORTE TOTAL: "+ FunGeneral.fnFormatearPrecio("S/.", lsReporteBloque.Sum(i => i.idMoneda == 2 ? (i.ImporteTipoCambio * i.ImporteRow) : i.ImporteRow), 0);
                   
                    dgvListaPorBloque.Columns[0].Visible = false;
                    dgvListaPorBloque.Columns[1].Width = 10;
                    dgvListaPorBloque.Columns[2].Width = 100;
                    dgvListaPorBloque.Columns[3].Width = 20;
                    dgvListaPorBloque.Columns[4].Width = 100;
                    dgvListaPorBloque.Height = ((totalRows+1) * (dgvListaPorBloque.ThemeStyle.RowsStyle.Height+3));
                    lblTotalBloque.Location = new Point(lblTotalBloque.Location.X, dgvListaPorBloque.Height+15);
                    lblMontoTotalRepBloque.Text = FunGeneral.fnFormatearPrecio("S/.", lsReporteBloque.Sum(i => i.idMoneda==2?(i.ImporteTipoCambio*i.ImporteRow):i.ImporteRow), 0);

                }else if (tipoCon==-2)
                {
                    ReporteBloque clsReporte = lsReporteBloqueGen.Find(i => i.Codigoreporte == codOperacion);
                    siticoneDataGridView1.Columns.Clear();
                    siticoneDataGridView1.Rows.Clear();
                    siticoneDataGridView1.Columns.Add("id", "id");
                    siticoneDataGridView1.Columns.Add("num", "N°");
                    siticoneDataGridView1.Columns.Add("detalle", "Detalle de "+clsReporte.Detallereporte);
                    siticoneDataGridView1.Columns.Add("cantidad", "Cantidad");
                    siticoneDataGridView1.Columns.Add("Importe", "Importe");
                    this.siticoneDataGridView1.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    for (Int32 i = 0; i < totalRows; i++)
                    {
                        ReporteBloque clsRep = lsReporteBloque[i];
                        siticoneDataGridView1.Rows.Add(
                            clsRep.Codigoreporte,
                            y + 1,
                            clsRep.Detallereporte,
                            clsRep.Cantidad,
                            FunGeneral.fnFormatearPrecio(clsRep.SimboloMoneda, clsRep.ImporteRow, 0)
                            );
                        y += 1;
                        siticoneDataGridView1.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        siticoneDataGridView1.Rows[i].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }

                    siticoneDataGridView1.Rows.Add("","","","","");
                    siticoneDataGridView1.Rows.Add("TOTAL","","IMPORTE TOTAL","", FunGeneral.fnFormatearPrecio("S/.", lsReporteBloque.Sum(i => i.idMoneda == 2 ? (i.ImporteTipoCambio * i.ImporteRow) : i.ImporteRow), 0));
                    siticoneDataGridView1.Rows[y+1].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    siticoneDataGridView1.Rows[y+1].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    siticoneDataGridView1.Rows[y + 1].DefaultCellStyle.ForeColor = Color.Red;
                    siticoneDataGridView1.Columns[0].Visible = false;
                    siticoneDataGridView1.Columns[1].Width = 10;
                    siticoneDataGridView1.Columns[2].Width = 100;
                    siticoneDataGridView1.Columns[3].Width = 20;
                    siticoneDataGridView1.Columns[4].Width = 100;
                    siticoneDataGridView1.ColumnHeadersVisible = false;
                    siticoneDataGridView1.Height = ((totalRows+2) * (siticoneDataGridView1.ThemeStyle.RowsStyle.Height+3));

                }

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
            String CodOperacion = cboTipoReporte.SelectedValue.ToString();
            if (CodOperacion== "TRPT0001")
            {
                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboOperacion, "idOperacion", "cNombreOperacion", "OperacionHusat", "estValida", "1", false);
            }
            else if (CodOperacion == "TRPT0002")
            {
                //siticonePanel2.Visible = true;
                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboOperacion, "cCodTab", "cNomTab", "TablaCod", "cCodTab", "TIPA", false);

            }
            else if (CodOperacion == "TRPT0003")
            {
                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboOperacion, "idUsuario", "cUser", "Usuario", "estValida", "1", false);

            }
            else if (CodOperacion == "TRPT0004")
            {
                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboOperacion, "cCodTab", "cNomTab", "TablaCod", "cCodTab", "DOVE", false);


            }


            fnBuscarReporteGeneralVentas(0, -1);
        }

        private void txtBuscarRepGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                fnBuscarReporteGeneralVentas(0,-1);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvListaPorBloque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codTipoReporte = cboTipoReporte.SelectedValue.ToString();
            Int32 pointToWindow = MousePosition.Y;
            codOperacion = dgvListaPorBloque.CurrentRow.Cells[0].Value.ToString();
            Int32 x = dgvListaPorBloque.GetCellDisplayRectangle(e.RowIndex, e.ColumnIndex,false).Right ;
            Int32 y = dgvListaPorBloque.GetRowDisplayRectangle(e.RowIndex,false).Y;
            siticoneDataGridView1.Location = new Point(dgvListaPorBloque.Right, y+2);
            siticoneDataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.None;
            siticoneDataGridView1.BorderStyle = BorderStyle.FixedSingle;
           
            fnBuscarReporteGeneralVentas(0, -2);

        }

        private void dgvListaPorBloque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var mousePosition = dgvListaPorBloque.PointToClient(Cursor.Position);
            //cmsAccion.Show(dgvListaPorBloque, mousePosition.X, mousePosition.Y);

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

                ReporteBloque clsReporte = lsReporteBloque.Find(i => i.Codigoreporte == codOperacion);
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
            fnBuscarReporteGeneralVentas(0, -1);
        }

        private void dgvListaPorBloque_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var mousePosition = dgvListaPorBloque.PointToClient(Cursor.Position);
            cmsAccion.Show(dgvListaPorBloque, mousePosition.X, mousePosition.Y);
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
           

                if (e.Value.ToString()== "Total")
                {
                    dgview.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Variables.ColorSuccess;
                    //e.CellStyle.ForeColor = Variables.ColorSuccess;
                }
                
            
        }
    }
}
