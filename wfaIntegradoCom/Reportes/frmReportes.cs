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

        private void frmReportes_Load(object sender, EventArgs e)
        {
            try
            {
                FunGeneral.fnLlenarCiclo(0,cboCiclo,true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboEstado, "ESPV", true);
                FunGeneral.fnLlenarTablaCodTipoCon(siticoneComboBox1, "TICN", true);
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
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
            clsBusq.cod1 = cboCiclo.SelectedValue.ToString();
            clsBusq.cod2=cboEstado.SelectedValue.ToString();
            clsBusq.cod3 = "0";

            lstReporte = obRecaudacion.blBuscarReporte(clsBusq);
            fnCargarReporte();
            fnTamanioReporte();
            string strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(8);
        }

        private void fnCargarReporte()
        {
            //String codTipoReporte = cboTipoReporte.SelectedValue.ToString();
            String strRuta = tabControl1.SelectedIndex==0?"wfaIntegradoCom.Consultas.rptReporteRecaudacion.rdlc": "wfaIntegradoCom.Consultas.rptReporteRecaudacion.rdlc";
            //List<PagoPrincipal> lstPagoPrinci = lstPP;
            ReportParameter[] parameters = new ReportParameter[3];
            ///Mostrar datos en el reporte
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            //parameters[0] = new ReportParameter("rpEmpresa", Variables.gsEmpresa);
            parameters[0] = new ReportParameter("rpSucursal", Variables.gsSucursal);
            parameters[1] = new ReportParameter("rpEmpresaDir", Variables.gsEmpresaDir);
            parameters[2] = new ReportParameter("rpRuc", Variables.gsRuc);
            reportViewer1.LocalReport.ReportEmbeddedResource = strRuta;
            //reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtReporte", lstReporte));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }

        private void fnTamanioReporte()
        {
            Int32 wd = this.Size.Width;
            if (wd < 800)
            {
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
            }
            else
            {
                reportViewer1.ZoomMode = ZoomMode.Percent;
            }
        }
    
        private void gunaControlBox3_Click(object sender, EventArgs e)
        {
            fnTamanioReporte();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void pbBuscar1_Click(object sender, EventArgs e)
        {

        }

        private void fnBuscarReporteRenovacion()
        {
            obRecaudacion = new BLControlPagos();
            DataTable dt = new DataTable();
            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = siticoneCheckBox1.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtpFechaInicialBus.Value, 5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtpFechaFinalBus.Value, 5);
            clsBusq.cBuscar = txtBuscar.Text.ToString();
            clsBusq.cod1 = siticoneComboBox1.SelectedValue.ToString();

            lstReporteRenovacion = obRecaudacion.blBuscarReporteRenovaciones(clsBusq);
            fnCargarReporte();
            fnTamanioReporte();
            string strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(8);
        }
    }
}
