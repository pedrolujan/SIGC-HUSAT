using CapaEntidad;
using Microsoft.Reporting.WinForms;
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

namespace wfaIntegradoCom.Consultas
{
    public partial class frmRptContrato : Form
    {
        public frmRptContrato()
        {
            InitializeComponent();
        }
        List<Cliente> lstCliente = new List<Cliente>();
        List<Vehiculo> lstVehiculo = new List<Vehiculo>();
        List<Contrato> lstContrato = new List<Contrato>();

        private void frmRptContrato_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            fnCargarReporte(lstCliente,lstVehiculo, lstContrato);
        }
        public void Inicio(List<Cliente> lstCli,List<Vehiculo>lstVh, List<Contrato> lstCt)
        {
            lstCliente = lstCli;
            lstVehiculo = lstVh;
            lstContrato = lstCt;
            this.ShowDialog();
        }
        private void fnCargarReporte(List<Cliente> lstC, List<Vehiculo> lstV,List<Contrato> lstCt)
        {
            ReportParameter[] parameters = new ReportParameter[1];
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            parameters[0] = new ReportParameter("rpFecha", Convert.ToString(Variables.gdFechaSis));
            //parameters[1] = new ReportParameter("rpEmpresaDir", Variables.gsEmpresaDir);
            //parameters[2] = new ReportParameter("rpUsuario", Variables.gsCodUser);
            //parameters[3] = new ReportParameter("rpRucEmpresa", Variables.gsRuc);
            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.rptContrato.rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCliente", lstC));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsVehiculo", lstV));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsContrato", lstCt));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }
    }
}
