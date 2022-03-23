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
    public partial class frmExportConsultasCronograma : Form
    {
        public frmExportConsultasCronograma()
        {
            InitializeComponent();
        }
        List<Cliente> lstCliente= new List<Cliente>();
        String TituloInforme = "";
        Int32 TipoCon = 0;
        public void Inicio(List<Cliente> lstCli,String titu, Int32 TipCon)
        {
            lstCliente = lstCli;
            TipoCon = TipCon;
            TituloInforme = titu;
            //lstVehiculo = lstV;
            //lstPagoPrincipales = lstPP;

            ShowDialog();
        }
        private void frmExportConsultasCronograma_Load(object sender, EventArgs e)
        {
            CargarReporte(lstCliente,TituloInforme);
            this.reportViewer1.RefreshReport();
        }
        private void CargarReporte(List<Cliente> lstDocumento,String tituloInforme)
        {
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
            parameters[2] = new ReportParameter("Titulo", tituloInforme);
            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.frmExportConsultasCronograma.rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtCliente", lstDocumento));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }
    }
}
