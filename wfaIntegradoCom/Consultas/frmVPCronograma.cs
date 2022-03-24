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
    public partial class frmVPCronograma : Form
    {
        public frmVPCronograma()
        {
            InitializeComponent();
        }
        List<DetalleCronograma> lstDetalleCronograma = new List<DetalleCronograma>();
        public void Inicio(List<DetalleCronograma> lstDC,Int32 TipCon)
        {
            lstDetalleCronograma = lstDC;
            
            //lstVehiculo = lstV;
            //lstPagoPrincipales = lstPP;

            ShowDialog();
        }
        

        private void frmVPCronograma_Load(object sender, EventArgs e)
        {
            CargarReporte(lstDetalleCronograma);
            this.reportViewer1.RefreshReport();
        }
        private void CargarReporte(List<DetalleCronograma> lstDcr)
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
            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.frmVPCronograma.rdlc";
            //reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtDetalleCronograma", lstDcr));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }
    }
}
