using CapaEntidad;
using CapaNegocio;
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
    public partial class frmActaCierreCaja : Form
    {
        public frmActaCierreCaja()
        {
            InitializeComponent();
        }

        static List<ReporteBloque> lstReporteIngresos = new List<ReporteBloque>();
        static List<ReporteBloque> lstDetalleIngresos = new List<ReporteBloque>();
        static List<ReporteBloque> lstReporteEgresos = new List<ReporteBloque>();
        static List<CuadreCaja> lstReporteCuandrecaja = new List<CuadreCaja>();
        static List<xmlActaCierraCaja> xmlActaCierreCaja = new List<xmlActaCierraCaja>();
        static Int32 lnTipoCon = 0;
        public void Inicio(List<xmlActaCierraCaja> xmlActacierre, Int32 tipoCon)
        {
            lstReporteIngresos = xmlActacierre[0].ListaReporteIngresos;
            lstDetalleIngresos = xmlActacierre[0].ListaReporteDetalleIngresos;
            lstReporteEgresos = xmlActacierre[0].ListaReporteEgresos;
            lstReporteCuandrecaja= xmlActacierre[0].ListaCuadreCaja;
            xmlActaCierreCaja = xmlActacierre;
            lnTipoCon = tipoCon;
            this.ShowDialog();
        }
        private void frmActaCierreCaja_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            fnCargarReporte(xmlActaCierreCaja,lstReporteIngresos, lstDetalleIngresos, lstReporteEgresos,lstReporteCuandrecaja);
        }
        private void fnCargarReporte(List<xmlActaCierraCaja> xmlActa,List<ReporteBloque> lstIngresos, List<ReporteBloque> lstDetIngresos, List<ReporteBloque> lstEgresos, List<CuadreCaja> lstCuandre)
        {
            
            ReportParameter[] parameters = new ReportParameter[5];
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            parameters[0] = new ReportParameter("prFecha", Convert.ToString(xmlActa[0].dtFechaRegistro));
            parameters[1] = new ReportParameter("prSucursal", FunGeneral.FormatearCadenaTitleCase(xmlActa[0].cNomSucursal));
            //parameters[2] = new ReportParameter("prUsuario", FunGeneral.FormatearCadenaTitleCase(clt.cPrimerNom+" "+ clt.cApePat+" "+ clt.cApeMat));
            parameters[2] = new ReportParameter("prUsuario", FunGeneral.FormatearCadenaTitleCase(xmlActa[0].nomPersonal));      
            parameters[3] = new ReportParameter("RazonSocial", Convert.ToString(Variables.gsEmpresa));
            parameters[4] = new ReportParameter("prTurno", xmlActa[0].turno);
            //parameters[4] = new ReportParameter("prTurno", Variables.gdFechaSis.Hour < 15 ? " Mañana" : " Tarde");

            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.prtActaCierreCaja.rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsReporte", lstIngresos));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDetalleIngresos", lstDetIngresos));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsReporteEgresos", lstEgresos));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCuadreCaja", lstCuandre));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCerrarGuardarCierre_Click(object sender, EventArgs e)
        {
            BLCaja bl = new BLCaja();
            Boolean est = false;
            est=bl.blGuardarCierreCaja(xmlActaCierreCaja,-1);
            if (est==true)
            {
                MessageBox.Show("Cierre de caja guardado exitosamnete","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Dispose();
            }
        }
    }
}
