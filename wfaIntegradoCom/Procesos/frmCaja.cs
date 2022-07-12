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

namespace wfaIntegradoCom.Procesos
{
    public partial class frmCaja : Form
    {
        public frmCaja()
        {
            InitializeComponent();
        }
        static Int32 tabInicio = 0;
        List<ReporteBloque> lsReporteBloque = new List<ReporteBloque>();
        List<ReporteBloque> lsReporteBloqueGen = new List<ReporteBloque>();
        private void chkDiaEspecificoG_CheckedChanged(object sender, EventArgs e)
        {
            fnValidarBusquedaDia();
        }
        private void fnValidarBusquedaDia()
        {
            if (chkDiaEspecificoG.Checked == true)
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
        private void frmCaja_Load(object sender, EventArgs e)
        {
            try
            {
                dtFechaFinG.Value = Variables.gdFechaSis;
                dtFechaInicioG.Value = dtFechaFinG.Value.AddDays(-(dtFechaFinG.Value.Day - 1));
                fnValidarBusquedaDia();
                FunGeneral.fnLlenarTablaCodTipoCon(cboTipoReporte, "TRPT", true);
                
                fnBuscarVentas(dgvListaPorBloque,0, 4, cboTipoReporte.SelectedValue.ToString(),  -1);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void fnBuscarVentas(SiticoneDataGridView dgv, Int32 numPagina, Int32 idUsuario,String cboTRep, Int32 tipoCon)
        {
            Busquedas clsBusq = new Busquedas();
            BLCaja blcaja = new BLCaja();
            Int32 filas = 50;
            List<ReporteBloque> lstBusq = new List<ReporteBloque>();
            clsBusq.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBusq.chkActivarDia = chkDiaEspecificoG.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value,5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value,5);
            clsBusq.cod1 = cboTipoReporte.SelectedValue.ToString();
            clsBusq.cod2 = "";
            clsBusq.numPagina = numPagina;
            clsBusq.tipoCon = tipoCon;
            clsBusq.cod3 = idUsuario.ToString();
            clsBusq.cod4 = "0";
            clsBusq.cBuscar = "";
            lsReporteBloque = blcaja.blBuscarVentas(clsBusq);
            Int32 totalRows = lsReporteBloque.Count;
            if (totalRows > 0)
            {
                fnGenerarPaneles(lsReporteBloque);
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

                    Int32 y = 0;
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
                    dgv.Height = ((totalRows + 3) * (dgv.ThemeStyle.RowsStyle.Height + 2));
                    dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                }


            }

            //var controles = flowLayoutPanel1.Controls.OfType<SiticoneLabel>();
           


        }
        private Color fnDevolVerColorTransparente(Int32 alfa,Color colr)
        {
            return Color.FromArgb(alfa, colr);
        }

        private void fnGenerarPaneles(List<ReporteBloque> lstBusq)
        {
            Color colorFondo =new Color();
            Color colorHeaderFooter =new Color();
            Color colorLetraHF =new Color();
            Color colorLetraBody =new Color();
            flowLayoutPanel1.Controls.Clear();
            colorLetraHF = Color.LightGray;
            colorLetraBody = Color.Black;
            for (Int32 i = 0; i < lstBusq.Count; i++)
            {
                if (lstBusq[i].ImporteRow < 100)
                {
                    colorFondo = Color.FromArgb(205, 76, 70);
                }
                else if (lstBusq[i].ImporteRow >= 100 && lstBusq[i].ImporteRow < 300)
                {
                    colorFondo = Color.FromArgb(240, 130, 33);
                }
                else if (lstBusq[i].ImporteRow >= 300 && lstBusq[i].ImporteRow < 700)
                {
                    colorFondo = Color.FromArgb(251, 191, 69);
                }
                else if (lstBusq[i].ImporteRow >= 700 && lstBusq[i].ImporteRow < 1000)
                {
                    colorFondo = Color.FromArgb(1, 139, 211);
                }
                else if (lstBusq[i].ImporteRow >= 1000 )
                {
                    colorFondo = Color.FromArgb(2, 195, 130);
                }
                colorHeaderFooter = fnDevolVerColorTransparente(120, Color.Black);
                //Panel princilal
                SiticonePanel panelFondo = new SiticonePanel();
                panelFondo.Name = "panel" + i;
                panelFondo.Size = new Size(190, 120);
                panelFondo.BorderRadius = 10;
                panelFondo.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                panelFondo.BackColor = Color.Transparent;
                panelFondo.FillColor = colorFondo;

                SiticonePanel panel = new SiticonePanel();
                panel.Name = "panel" + i;
                panel.Size = new Size(190, 120);
                panel.BorderRadius = 10;
                panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;                
                panel.BackColor = Color.Transparent;
                panel.FillColor = colorHeaderFooter;
                panelFondo.Controls.Add(panel);
                // panel Header
                SiticonePanel pnHead = new SiticonePanel();
                pnHead.Name = "pnHead" + i;
                pnHead.Size = new Size(190, 25);
                pnHead.BackColor = Color.Transparent;
                //pnHead.FillColor = ;
                pnHead.BorderRadius=10;


                
                

                SiticoneLabel lblH = new SiticoneLabel();
                lblH.Name = "lblHeader" + i;
                lblH.AutoSize = false;
                lblH.Size = new Size(190, 25);
                lblH.BackColor = Color.Transparent;
                lblH.Location = new Point(0, 0);
                lblH.Text = FunGeneral.FormatearCadenaTitleCase(lstBusq[i].Detallereporte);
                lblH.TextAlignment = ContentAlignment.MiddleCenter;
                lblH.Font = new Font("Arial", 13F, GraphicsUnit.Pixel);
                lblH.ForeColor = colorLetraHF;
                pnHead.Controls.Add(lblH);
                panel.Controls.Add(pnHead);

                //Panel Izquierdo
                SiticonePanel pnIzquierdo = new SiticonePanel();
                pnIzquierdo.Name = "pnIzquierdo" + i;
                pnIzquierdo.BackColor = colorFondo;
                pnIzquierdo.Size = new Size(95, 70);
                pnIzquierdo.Location = new Point(0, 25);


                SiticoneLabel lblIzq = new SiticoneLabel();
                lblIzq.Name = "lblIzquierdo" + i;
                lblIzq.AutoSize = false;
                lblIzq.Size = new Size(95, 70);
                lblIzq.Location = new Point(0, 0);
                lblIzq.Text = "" + lstBusq[i].Cantidad;
                lblIzq.TextAlignment = ContentAlignment.MiddleCenter;
                lblIzq.Font = new Font("Arial", 20F, GraphicsUnit.Pixel);
                lblIzq.ForeColor = colorLetraBody;
                pnIzquierdo.Controls.Add(lblIzq);

                panel.Controls.Add(pnIzquierdo);
                //Panel Derecho
                SiticonePanel pnDerecho = new SiticonePanel();
                pnDerecho.Name = "pnDerecho" + i;
                pnDerecho.BackColor = colorFondo;
                pnDerecho.Size = new Size(95, 70);
                pnDerecho.Location = new Point(95, 25);
                panel.Controls.Add(pnDerecho);

                //Panel Footer
                SiticonePanel pnFooter = new SiticonePanel();
                pnFooter.Name = "pnFooter" + i;
                //pnFooter.BackColor = colorHeader;
                pnFooter.Size = new Size(190, 25);
                pnFooter.Location = new Point(0, 95);

                SiticoneLabel lblF = new SiticoneLabel();
                lblF.Name = "lblFooter" + i;
                lblF.AutoSize = false;
                lblF.Size = new Size(190, 25); ;
                lblF.Location = new Point(0, 0);
                lblF.Text = "Importe: " + FunGeneral.fnFormatearPrecio("S/.", lstBusq[i].ImporteRow, 0);
                //lblF.BackColor = "Dark"+ color;
                lblF.TextAlignment = ContentAlignment.MiddleCenter;
                lblF.Font = new Font("Arial", 13F, GraphicsUnit.Pixel);
                lblF.ForeColor = colorLetraHF;
                pnFooter.Controls.Add(lblF);


                panel.Controls.Add(pnFooter);

                flowLayoutPanel1.Controls.Add(panelFondo);
            }
        }
        private void siticoneLabel1_Click(object sender, EventArgs e)
        {

        }

        private void lblHeader1_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar== (char)Keys.Enter)
            {
                fnBuscarVentas(dgvListaPorBloque, 0, 4, cboTipoReporte.SelectedValue.ToString(), -1);

            }
        }

        private void dgvListaPorBloque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
