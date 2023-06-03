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

        static List<ReporteBloque> lstReporteIngresosCategoria = new List<ReporteBloque>();
        static List<ReporteBloque> lstReporteIngresosOperacion = new List<ReporteBloque>();
        static List<ReporteBloque> lstReporteIngresosMedioPago = new List<ReporteBloque>();
        static List<ReporteBloque> lstDetalleIngresos = new List<ReporteBloque>();
        static List<ReporteBloque> lstReporteEgresos = new List<ReporteBloque>();
        static List<ReporteBloque> lstCajaChica = new List<ReporteBloque>();
        static List<CuadreCaja> lstReporteCuandrecaja = new List<CuadreCaja>();
        static List<CuadreCaja> lstAperturaCaja = new List<CuadreCaja>();
        static List<xmlActaCierraCaja> xmlActaCierreCaja = new List<xmlActaCierraCaja>();
        static Int32 lnTipoCon = 0;
        public void Inicio(List<xmlActaCierraCaja> xmlActacierre, Int32 tipoCon)
        {
            lstReporteIngresosCategoria = xmlActacierre[0].ListaReporteIngresosCategoria;
            lstReporteIngresosOperacion = xmlActacierre[0].ListaReporteIngresosOperacion;
            lstReporteIngresosMedioPago = xmlActacierre[0].ListaReporteIngresosMedioPago;
            lstDetalleIngresos = xmlActacierre[0].ListaReporteDetalleIngresos;
            lstReporteEgresos = xmlActacierre[0].ListaReporteEgresos;
            lstReporteCuandrecaja= xmlActacierre[0].ListaCuadreCaja;
            lstCajaChica = xmlActacierre[0].ListaCajaChica;
            lstAperturaCaja= xmlActacierre[0].ListaAperturaCaja;    
            xmlActaCierreCaja = xmlActacierre;
            lnTipoCon = tipoCon;
            this.ShowDialog();
        }
        private void frmActaCierreCaja_Load(object sender, EventArgs e)
        {
            if (lnTipoCon == -1)
            {
                btnCerrarGuardarCierre.Enabled = false;
                reportViewer1.ShowToolBar=true;
            }
            else if (lnTipoCon == 1)
            {
                reportViewer1.ShowToolBar = false;
                btnCerrarGuardarCierre.Enabled = true;
            }
            this.reportViewer1.RefreshReport();
            fnCargarReporte(xmlActaCierreCaja);
        }
        private void fnCargarReporte(List<xmlActaCierraCaja> xmlActa)
        {            
            ReportParameter[] parameters = new ReportParameter[5];
            List<ReporteBloque> lstCH = new List<ReporteBloque>();
            int y = 0;
            foreach (ReporteBloque i in xmlActa[0].ListaCajaChica)
            {
                if (i.Codigoreporte == "TIPA0001")
                {
                    lstCH.Add(i);
                    //lstCH[y].numero = (y + 1);
                    //y++;    
                }
            }
            lstCH[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lstCH[0].SimboloMoneda, lstCH[0].ImporteRow, 0);
            xmlActa[0].ListaAperturaCaja[0].Detalle = FunGeneral.FormatearCadenaTitleCase(xmlActa[0].ListaAperturaCaja[0].Detalle);
            xmlActa[0].ListaAperturaCaja[0].MonImporteSaldo = FunGeneral.fnFormatearPrecioDC("S/.", xmlActa[0].ListaAperturaCaja.Sum(i => i.importeSaldo), 1); ;

            List<ReporteBloque> lstCP = new List<ReporteBloque>();
            lstCP.Add(xmlActa[0].ListaCajaChica.Find(i => i.codAuxiliar == "TEGR0002"));
            lstCP[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lstCP[0].SimboloMoneda, lstCP[0].ImporteRow, 0);
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
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsApertura", xmlActa[0].ListaAperturaCaja));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDetalleIngresosContado", xmlActa[0].ListaReporteDetalleIngresos));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsReporteEgresos", xmlActa[0].ListaReporteEgresos));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCajaChica", xmlActa[0].ListaCajaChica));
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCopias", lstCP));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCuadreCaja", xmlActa[0].ListaCuadreCaja));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDetalleIngresosCategoria", xmlActa[0].ListaReporteIngresosCategoria));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDetalleIngresosOperacion", xmlActa[0].ListaReporteIngresosOperacion));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDetalleIngresosMedioPago", xmlActa[0].ListaReporteIngresosMedioPago));
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
            est = bl.blGuardarCierreCaja(xmlActaCierreCaja, Variables.lstCuardreCaja, -1);
            if (est==true)
            {
                MessageBox.Show("Cierre de caja guardado exitosamnete","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            string nombreArchivo = "CIERRE DE CAJA - " + Variables.clasePersonal.cPrimerNom+" "+ Variables.clasePersonal.cApePat+" "+ Variables.clasePersonal.cApeMat +' '+ xmlActaCierreCaja[0].dtFechaRegistro.ToString("dd-MM-yyyy hh.mm tt");

            // Modificar el nombre del archivo en la descarga
            ReportViewer viewer = (ReportViewer)sender;
            viewer.LocalReport.DisplayName = nombreArchivo;
        }
    }
}
