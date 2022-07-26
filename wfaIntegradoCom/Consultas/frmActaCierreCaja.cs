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
    public partial class frmActaCierreCaja : Form
    {
        public frmActaCierreCaja()
        {
            InitializeComponent();
        }

        static List<ReporteBloque> lstReporteBloque = new List<ReporteBloque>();
        static Int32 lnTipoCon = 0;
        public void Inicio(List<ReporteBloque> lstR,Int32 tipoCon)
        {
            lstReporteBloque = lstR;
            lnTipoCon = tipoCon;
            this.ShowDialog();
        }
        private void frmActaCierreCaja_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            fnCargarReporte(lstReporteBloque);
        }
        private void fnCargarReporte(List<ReporteBloque> lstRep)
        {
            Personal clt = Variables.clasePersonal;
            ReportParameter[] parameters = new ReportParameter[5];
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            parameters[0] = new ReportParameter("prFecha", Convert.ToString(Variables.gdFechaSis));
            parameters[1] = new ReportParameter("prSucursal", Variables.gsSucursal);
            parameters[2] = new ReportParameter("prUsuario", clt.cPrimerNom+" "+ clt.cApePat+" "+ clt.cApeMat);
            parameters[3] = new ReportParameter("RazonSocial", Convert.ToString(Variables.gsEmpresa));
            parameters[4] = new ReportParameter("prTurno", Variables.gdFechaSis.Hour < 15 ? " Mañana" : " Tarde");

            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.prtActaCierreCaja.rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsReporte", lstRep));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }
    }
}
