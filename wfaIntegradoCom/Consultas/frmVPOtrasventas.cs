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
using wfaIntegradoCom.Procesos;

namespace wfaIntegradoCom.Consultas
{
    public partial class frmVPOtrasVentas : Form
    {
        public frmVPOtrasVentas()
        {
            InitializeComponent();
        }
        List<OtrasVentas>  lstDetalleVentas ;
        List<DocumentoVenta> lstDocumentoVenta;
        List<TotalPagosVenta> lstTotalPagos;
        Boolean EstadoGenerarVenta = false;
        Int32 TipoCon = 0;
        public void Inicio(List<DocumentoVenta> lstDocumento,List<OtrasVentas> lstDC,Int32 TipCon)
        {
            lstDocumentoVenta = new List<DocumentoVenta>();
            lstDetalleVentas = new List<OtrasVentas>();
            lstTotalPagos = new List<TotalPagosVenta>();
            lstDocumentoVenta = lstDocumento;
            lstDetalleVentas = lstDC;
            TipoCon = TipCon;
            //lstVehiculo = lstV;
            //lstPagoPrincipales = lstPP;

            ShowDialog();
        }


        private void frmVPOtrasVentas_Load(object sender, EventArgs e)
        {
            FunValidaciones.fnColorAceptarCancelar(btnAceptar,btnCancelar);
            if (TipoCon==1)
            {
                this.reportViewer1.Height = 628;
                this.reportViewer1.ShowPrintButton = true;
                this.reportViewer1.ShowExportButton = true;
            }
            else
            {
                this.reportViewer1.Height = 508;
                this.reportViewer1.ShowPrintButton = false;
                this.reportViewer1.ShowExportButton = false;
            }
            CargarReporte(lstDocumentoVenta, lstDetalleVentas);
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
            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas..rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DatosCliente", lstDocumento));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DetalleOtrasVentas", lstDetaVenta));
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DatosTotalPagos", lstTotPag));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }

        private void btnGenerarVenta_Click(object sender, EventArgs e)
        {
            EstadoGenerarVenta = true;

            frmOtrasVentas.fnRecuperarEstadoGenVenta(EstadoGenerarVenta);
            this.Close();
        }
       

        private void btnEditarVenta_Click(object sender, EventArgs e)
        {
            EstadoGenerarVenta = false;

            frmOtrasVentas.fnRecuperarEstadoGenVenta(EstadoGenerarVenta);

            this.Close();

        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
