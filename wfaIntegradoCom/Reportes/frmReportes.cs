using CapaEntidad;
using CapaNegocio;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Reportes
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }
        BLControlPagos  obRecaudacion;
        List<Reporte> lstReporte = new List<Reporte>();
        List<Reporte> lstReporteRenovacion = new List<Reporte>();
        
        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Int32 lnTipioLlamada = 0;
        public void Inicio(Int32 tipoLla)
        {
            lnTipioLlamada = tipoLla;
            this.Show();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms[this.Name] != null)
                {
                    if (lnTipioLlamada == 0)
                    {
                        tabControl1.SelectedIndex = 0;
                        tabControl1.Controls.RemoveAt(1);
                    }
                    else if (lnTipioLlamada == 1)
                    {
                        tabControl1.SelectedIndex = 1;
                        tabControl1.Controls.RemoveAt(0);
                    }
                }
               

                FunGeneral.fnLlenarCiclo(0,cboCiclo,true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboEstado, "ESPV", true);
                FunGeneral.fnLlenarTablaCodTipoCon(siticoneComboBox1, "TICN", true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboTipoReporte, "TRRC", false);
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));

                siticoneDateTimePicker1.Value = Variables.gdFechaSis;
                siticoneDateTimePicker2.Value = siticoneDateTimePicker1.Value.AddDays(-(siticoneDateTimePicker1.Value.Day - 1)).AddMonths(-(siticoneDateTimePicker1.Value.Month-1));
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            fnBuscarReporte();
        }
        private void fnBuscarReporte()
        {
            obRecaudacion = new BLControlPagos();
            DataTable dt = new DataTable();
            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtpFechaInicialBus.Value,5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtpFechaFinalBus.Value,5);
            clsBusq.cBuscar = txtBuscar.Text.ToString();
            clsBusq.cod1 = cboTipoReporte.SelectedValue.ToString();
            clsBusq.cod2=cboEstado.SelectedValue.ToString();
            clsBusq.cod3 = cboCiclo.SelectedValue.ToString();
            clsBusq.cod4 = "0";


            lstReporte = obRecaudacion.blBuscarReporte(clsBusq);
            fnCargarReporte(reportViewer1);
            fnTamanioReporte(reportViewer1);
            string strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(8);
        }

        private void fnCargarReporte(ReportViewer rptv)
        {
            //String codTipoReporte = cboTipoReporte.SelectedValue.ToString();
            String strRuta = lnTipioLlamada == 0?"wfaIntegradoCom.Consultas.rptReporteRecaudacion.rdlc": "wfaIntegradoCom.Consultas.rptReporteRenovacion.rdlc";
            //List<PagoPrincipal> lstPagoPrinci = lstPP;
            ReportParameter[] parameters = new ReportParameter[3];
            ///Mostrar datos en el reporte
            rptv.Reset();
            rptv.LocalReport.DataSources.Clear();
            rptv.ProcessingMode = ProcessingMode.Local;
            //parameters[0] = new ReportParameter("rpEmpresa", Variables.gsEmpresa);
            parameters[0] = new ReportParameter("rpSucursal", Variables.gsSucursal);
            parameters[1] = new ReportParameter("rpEmpresaDir", Variables.gsEmpresaDir);
            parameters[2] = new ReportParameter("rpRuc", Variables.gsRuc);
            rptv.LocalReport.ReportEmbeddedResource = strRuta;
            //reportViewer1.LocalReport.SetParameters(parameters);
            rptv.LocalReport.DataSources.Add(new ReportDataSource("dtReporte", lnTipioLlamada == 0?lstReporte:lstReporteRenovacion));
            rptv.ZoomMode = ZoomMode.PageWidth;
            rptv.RefreshReport();
        }

        private void fnTamanioReporte(ReportViewer rptv)
        {
            Int32 wd = this.Size.Width;
            if (wd < 800)
            {
                rptv.ZoomMode = ZoomMode.PageWidth;
            }
            else
            {
                rptv.ZoomMode = ZoomMode.Percent;
            }
        }
    
        private void gunaControlBox3_Click(object sender, EventArgs e)
        {
            fnTamanioReporte(reportViewer1);
            fnTamanioReporte(reportViewer2);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void pbBuscar1_Click(object sender, EventArgs e)
        {
            fnBuscarReporteRenovacion();
        }

        private void fnBuscarReporteRenovacion()
        {
            obRecaudacion = new BLControlPagos();
            DataTable dt = new DataTable();
            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = siticoneCheckBox1.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(siticoneDateTimePicker2.Value, 5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(siticoneDateTimePicker1.Value, 5);
            clsBusq.cBuscar = txtBuscar.Text.ToString();
            clsBusq.cod1 = siticoneComboBox1.SelectedValue.ToString();
            clsBusq.cod2 = siticoneComboBox1.SelectedValue.ToString();
            clsBusq.cod3 = siticoneComboBox1.SelectedValue.ToString();
            clsBusq.cod4 = "0";
            clsBusq.tipoCon = 1;

            lstReporteRenovacion = obRecaudacion.blBuscarReporteRenovaciones(clsBusq);
            fnCargarReporte(reportViewer2);
            fnTamanioReporte(reportViewer2);
            string strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(8);
        }

        private void siticoneTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                fnBuscarReporteRenovacion();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar== (char)Keys.Enter)
            {
                fnBuscarReporte();
            }
        }

        private void cboTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            String cod = cboTipoReporte.SelectedValue.ToString();
            if (cod== "TRRC0001")
            {
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
               
            }
            else
            {
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1)).AddMonths(-(dtpFechaFinalBus.Value.Month - 1));
            }
        }
    }
}
