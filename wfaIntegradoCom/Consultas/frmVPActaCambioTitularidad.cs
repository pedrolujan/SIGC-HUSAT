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
    public partial class frmVPActaCambioTitularidad : Form
    {
        public frmVPActaCambioTitularidad()
        {
            InitializeComponent();
        }
        List<Cliente> lstClienteNuevo=new List<Cliente>();
        List<Cliente> lstClienteAntiguo=new List<Cliente>();
        List<Vehiculo> lstVehiculo=new List<Vehiculo>();
        Int32 lnTipoCon = 0;
        public void Inicio(List<Cliente> lstClienteN, List<Cliente> lstClienteA,List<Vehiculo> lstVh,Int32 tipoC)
        {
            lstClienteNuevo.Clear();
            lstClienteAntiguo.Clear();
            lstVehiculo.Clear();

            lstClienteNuevo = lstClienteN;
            lstClienteAntiguo = lstClienteA;
            lstVehiculo = lstVh;
            lnTipoCon = tipoC;
            this.ShowDialog();
        }
        private void frmVPActaCambioTitularidad_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            fnCargarReporte(lstClienteNuevo,lstClienteAntiguo,lstVehiculo);
        }
        private void fnCargarReporte(List<Cliente> lstClienteN, List<Cliente> lstClienteA, List<Vehiculo> lstVh)
        {            
            ReportParameter[] parameters = new ReportParameter[2];
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            parameters[0] = new ReportParameter("rpRazonSocial", Variables.gsEmpresa);
            parameters[1] = new ReportParameter("rpRucEmpresa", Variables.gsRuc);
            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.rptActaCambioTitularidad.rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsClienteNuevo", lstClienteN));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsClienteAntiguo", lstClienteA));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsVehiculo", lstVh));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }

    }
}
