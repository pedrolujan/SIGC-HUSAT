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

        private void frmExportConsultasCronograma_Load(object sender, EventArgs e)
        {
            //CargarReporte(lstDocumentoVenta, lstDetalleVentas);
            this.reportViewer1.RefreshReport();
        }
        private void CargarReporte(List<DocumentoVenta> lstDocumento, List<OtrasVentas> lstDC)
        {
            List<OtrasVentas> lstDetaVenta = lstDC;
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
            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.rptVPOtrasVentas.rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DatosCliente", lstDocumento));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DetalleOtrasVentas", lstDetaVenta));
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DatosTotalPagos", lstTotPag));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }
    }
}
