using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Microsoft.Reporting.WinForms;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Mantenedores;

namespace wfaIntegradoCom.Consultas
{
    public partial class frmReporteVenta : Form
    {
        public frmReporteVenta()
        {
            InitializeComponent();
        }

        private String fnReportarVenta(string pcFechaIni, string pcFechaFin)
        {
            BLDocumentoVenta objVenta = new BLDocumentoVenta();
            List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();
            clsUtil objUtil = new clsUtil();
            ReportParameter[] parameters = new ReportParameter[4];
            try
            {
                
                reportViewer1.Reset();
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                parameters[0] = new ReportParameter("rpFechaIni", pcFechaIni);
                parameters[1] = new ReportParameter("rpFechaFin", pcFechaFin);
                parameters[2] = new ReportParameter("rpUsuario", Variables.gsCodUser);
                parameters[3] = new ReportParameter("TipoConsuta", "0");
                reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.rptReporteVenta.rdlc";
                reportViewer1.LocalReport.SetParameters(parameters);
                lstDetalleVenta = objVenta.BLReporteVenta(pcFechaIni, pcFechaFin);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsVenta", lstDetalleVenta));
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();

                return "OK";
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmReporteVenta", "fnReportarVenta", ex.Message);
                return "NO";
            }
            finally
            {
                objUtil = null;
                lstDetalleVenta = null;
                objVenta = null;
            }
        }

        private String fnReportarVentaxLote(Int32 pidLote)
        {
            BLDocumentoVenta objVenta = new BLDocumentoVenta();
            List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();
            clsUtil objUtil = new clsUtil();
            string lcFecha = "";
            ReportParameter[] parameters = new ReportParameter[5];
            try
            {
                lcFecha = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 5);
                reportViewer1.Reset();
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                parameters[0] = new ReportParameter("rpFechaIni", lcFecha);
                parameters[1] = new ReportParameter("rpFechaFin", lcFecha);
                parameters[2] = new ReportParameter("rpUsuario", Variables.gsCodUser);
                parameters[3] = new ReportParameter("rpNroLote", pidLote.ToString());
                parameters[4] = new ReportParameter("TipoConsuta", "1");
                reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.rptReporteVenta.rdlc";
                reportViewer1.LocalReport.SetParameters(parameters);
                lstDetalleVenta = objVenta.BLReporteVentaXLote(pidLote);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsVenta", lstDetalleVenta));
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();

                return "OK";
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmReporteVenta", "fnReportarVentaxLote", ex.Message);
                return "NO";
            }
            finally
            {
                objUtil = null;
                lstDetalleVenta = null;
                objVenta = null;
            }
        }

        private String fnReportarVentaxCliente(Int32 pintidCliente)
        {
            BLDocumentoVenta objVenta = new BLDocumentoVenta();
            List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();
            clsUtil objUtil = new clsUtil();
            string lcFecha = "";
            ReportParameter[] parameters = new ReportParameter[5];
            try
            {
                lcFecha = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 5);
                reportViewer1.Reset();
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                parameters[0] = new ReportParameter("rpFechaIni", lcFecha);
                parameters[1] = new ReportParameter("rpFechaFin", lcFecha);
                parameters[2] = new ReportParameter("rpUsuario", Variables.gsCodUser);
                parameters[3] = new ReportParameter("rpCliente", pintidCliente.ToString());
                parameters[4] = new ReportParameter("TipoConsuta", "2");
                reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.rptReporteVenta.rdlc";
                reportViewer1.LocalReport.SetParameters(parameters);
                lstDetalleVenta = objVenta.BLReporteVentaXCliente(pintidCliente);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsVenta", lstDetalleVenta));
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();

                return "OK";
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmReporteVenta", "fnReportarVentaxCliente", ex.Message);
                return "NO";
            }
            finally
            {
                objUtil = null;
                lstDetalleVenta = null;
                objVenta = null;
            }
        }

        private void frmReporteVenta_Load(object sender, EventArgs e)
        {
            string lcFechaIni = "";
            string lcFechaFin = "";
            string lcResultado = "";

            dateTimePicker1.Value = Variables.gdFechaSis;
            dateTimePicker2.Value = Variables.gdFechaSis;
            lcFechaIni = FunGeneral.GetFechaHoraFormato(dateTimePicker1.Value, 5) + " 00:00:00.000";
            lcFechaFin = FunGeneral.GetFechaHoraFormato(dateTimePicker2.Value, 5) + " 23:59:59.000";

            lcResultado = fnReportarVenta(lcFechaIni, lcFechaFin).Trim();
            if (lcResultado != "OK")
                reportViewer1.Enabled = false;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string lcFechaIni = "";
            string lcFechaFin = "";
            string lcResultado = "";

            lcFechaIni = FunGeneral.GetFechaHoraFormato(dateTimePicker1.Value, 5) + " 00:00:00.000";
            lcFechaFin = FunGeneral.GetFechaHoraFormato(dateTimePicker2.Value, 5) + " 23:59:59.000";

            lcResultado = fnReportarVenta(lcFechaIni, lcFechaFin).Trim();
            if (lcResultado != "OK")
                reportViewer1.Enabled = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lcFechaIni = "";
            string lcFechaFin = "";
            string lcResultado = "";

            if (tbcCliente.SelectedTab.Name == "tbpFechas")
            {

                dateTimePicker1.Value = Variables.gdFechaSis;
                dateTimePicker2.Value = Variables.gdFechaSis;
                lcFechaIni = FunGeneral.GetFechaHoraFormato(dateTimePicker1.Value, 5) + " 00:00:00.000";
                lcFechaFin = FunGeneral.GetFechaHoraFormato(dateTimePicker2.Value, 5) + " 23:59:59.000";

                lcResultado = fnReportarVenta(lcFechaIni, lcFechaFin).Trim();
                if (lcResultado != "OK")
                    reportViewer1.Enabled = false;
            }
            else if (tbcCliente.SelectedTab.Name == "tbpCliente")
            {
                btnBuscarCliente.Focus();
                reportViewer1.Reset();
                reportViewer1.LocalReport.DataSources.Clear();
            }
            else
            {
                textBox1.Text = "";
                textBox1.Focus();
                reportViewer1.Reset();
                reportViewer1.LocalReport.DataSources.Clear();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string lcResultado="";
            int idLote=0;
            if (e.KeyCode == Keys.Enter)
            {
                idLote = Convert.ToInt32(textBox1.Text.Trim() == "" ? "0" : textBox1.Text.Trim());
                if (idLote > 0)
                {
                    lcResultado = fnReportarVentaxLote(idLote).Trim();
                    if (lcResultado != "OK")
                        reportViewer1.Enabled = false;
                }
                else
                {
                    reportViewer1.Reset();
                    reportViewer1.LocalReport.DataSources.Clear();
                }
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void reportViewer1_Drillthrough(object sender, DrillthroughEventArgs e)
        {
                BLDocumentoVenta objVenta = new BLDocumentoVenta();
                DocumentoVenta[] lstVenta = new DocumentoVenta[1];
                List<DetalleVenta> lstDetalleVen = new List<DetalleVenta>();
                clsUtil objUtil = new clsUtil();
                ReportParameter[] parameters = new ReportParameter[1];
                try
                {
                    LocalReport localReport = (LocalReport)e.Report;
                    IList<ReportParameter> list = localReport.OriginalParametersToDrillthrough;
                    int idVenta = Convert.ToInt32(list[0].Values[0].ToString());
                    lstVenta = objVenta.blListarDocVenta(idVenta).ToArray();
                    //lstDetalleVen = objVenta.blListarDetalleVenta(idVenta);
                    localReport.SetParameters(new ReportParameter("rpEmpresa", Variables.gsEmpresa));
                    localReport.DataSources.Add(new ReportDataSource("dsVenta", lstVenta));
                    localReport.DataSources.Add(new ReportDataSource("dsDetalleVenta", lstDetalleVen));
                }
                catch (Exception ex)
                {
                    objUtil.gsLogAplicativo("frmImpresion", "fnImprimir", ex.Message);
                }
                finally
                {
                    objUtil = null;
                    lstDetalleVen = null;
                    lstVenta = null;
                }
            

        }

        private void fnConsultarxCliente(int pidCliente)
        {
            string lcResultado = "";
            int idCliente = pidCliente;

            if (idCliente > 0 )
            {
                lcResultado = fnReportarVentaxCliente(idCliente).Trim();
                if (lcResultado != "OK")
                    reportViewer1.Enabled = false;
            }
            else
            {
                reportViewer1.Reset();
                reportViewer1.LocalReport.DataSources.Clear();
            }
        }

        static int lidCliente = 0;
        static string lcCliente = string.Empty;
        public static void fnRecuperarCliente(String pcCliente, int pintIdCliente)
        {
            lcCliente = pcCliente;
            lidCliente = pintIdCliente;
        }

        private Boolean fnObtenerCliente()
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                if (lidCliente > 0)
                {
                    txtCliente.Text = lcCliente;
                    txtCodigo.Text = lidCliente.ToString();
                    fnConsultarxCliente(lidCliente);
                }
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmReporteVenta", "fnObtenerCliente", ex.Message);
                return false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Boolean lbResul = false;
            frmBuscarCliente frmCliente = new frmBuscarCliente();
            frmCliente.Inicio(4);
            lbResul = fnObtenerCliente();
            if (!lbResul)
            {
                MessageBox.Show("Error al Agregar Cliente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
