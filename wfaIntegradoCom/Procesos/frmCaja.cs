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
                
                fnBuscarVentas(0 ,4, cboTipoReporte.SelectedValue.ToString(),  -1);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void fnBuscarVentas(Int32 numPag,Int32 idUsuario,String cboTRep, Int32 tipoCon)
        {
            Busquedas clsBusq = new Busquedas();
            BLCaja blcaja = new BLCaja();
            List<ReporteBloque> lstBusq = new List<ReporteBloque>();
            clsBusq.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBusq.chkActivarDia = chkDiaEspecificoG.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value,5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value,5);
            clsBusq.cod1 = cboTipoReporte.SelectedValue.ToString();
            clsBusq.cod2 = "";
            clsBusq.numPagina = numPag;
            clsBusq.tipoCon = tipoCon;
            clsBusq.cod3 = idUsuario.ToString();
            clsBusq.cod4 = "0";
            clsBusq.cBuscar = "";
            lstBusq=blcaja.blBuscarVentas(clsBusq);
            if (lstBusq.Count>0)
            {
                fnGenerarPaneles(lstBusq);

            }

            //var controles = flowLayoutPanel1.Controls.OfType<SiticoneLabel>();
           


        }

        private void fnGenerarPaneles(List<ReporteBloque> lstBusq)
        {
            Color color =new Color();
            Color colorHeader =new Color();
            flowLayoutPanel1.Controls.Clear();
            for (Int32 i = 0; i < lstBusq.Count; i++)
            {
                if (lstBusq[i].ImporteRow < 100)
                {
                    color = Color.Red;
                    colorHeader = Color.DarkRed;
                }
                else if (lstBusq[i].ImporteRow >= 100 && lstBusq[i].ImporteRow < 400)
                {
                    color = Color.Orange;
                    colorHeader = Color.DarkOrange;

                }
                else if (lstBusq[i].ImporteRow >= 400 && lstBusq[i].ImporteRow < 1000)
                {
                    color = Color.Yellow;
                    colorHeader = Color.GreenYellow;

                }
                else if (lstBusq[i].ImporteRow >= 1000 )
                {
                    color = Color.Green;
                    colorHeader = Color.DarkGreen;

                }
                //Panel princilal
                SiticonePanel panel = new SiticonePanel();
                panel.Name = "panel" + i;
                panel.Size = new Size(190, 120);
                panel.BackColor = color;
                panel.BorderRadius = 15;
                panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                panel.BorderThickness = 5;
                panel.BorderColor = Color.Black;

                // panel Header
                SiticonePanel pnHead = new SiticonePanel();
                pnHead.Name = "pnHead" + i;
                pnHead.BackColor = colorHeader;
                pnHead.Size = new Size(190, 25);


                SiticoneLabel lblH = new SiticoneLabel();
                lblH.Name = "lblHeader" + i;
                lblH.AutoSize = false;
                lblH.Size = new Size(190, 25);
                //lblH.BackColor = Color.YellowGreen;
                lblH.Location = new Point(0, 0);
                lblH.Text = FunGeneral.FormatearCadenaTitleCase(lstBusq[i].Detallereporte);
                lblH.TextAlignment = ContentAlignment.MiddleCenter;
                lblH.Font = new Font("Arial", 13F, GraphicsUnit.Pixel);
                pnHead.Controls.Add(lblH);
                panel.Controls.Add(pnHead);

                //Panel Izquierdo
                SiticonePanel pnIzquierdo = new SiticonePanel();
                pnIzquierdo.Name = "pnIzquierdo" + i;
                //pnIzquierdo.BackColor = Color.Green;
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
                pnIzquierdo.Controls.Add(lblIzq);

                panel.Controls.Add(pnIzquierdo);
                //Panel Derecho
                SiticonePanel pnDerecho = new SiticonePanel();
                pnDerecho.Name = "pnDerecho" + i;
                //pnDerecho.BackColor = Color.Blue;
                pnDerecho.Size = new Size(95, 70);
                pnDerecho.Location = new Point(95, 25);
                panel.Controls.Add(pnDerecho);

                //Panel Footer
                SiticonePanel pnFooter = new SiticonePanel();
                pnFooter.Name = "pnFooter" + i;
                pnFooter.BackColor = colorHeader;
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
                pnFooter.Controls.Add(lblF);


                panel.Controls.Add(pnFooter);

                flowLayoutPanel1.Controls.Add(panel);
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
                fnBuscarVentas(0, 4, cboTipoReporte.SelectedValue.ToString(), -1);

            }
        }
    }
}
