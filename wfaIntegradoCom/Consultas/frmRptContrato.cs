using CapaEntidad;
using CapaUtil;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            String rutaArchivo = FunGeneral.GetRootPath() + @"\QR\CONTRATO\" + lstCt[0].codContrato + ".png";

            if (File.Exists(rutaArchivo))
            {
                lstCt[0].imgQr = File.ReadAllBytes(rutaArchivo);

            }
            else
            {
                clsUtil cls = new clsUtil();
                cls.ObtenerQr("HUSAT GPS CONTRATO: "+lstCt[0].codContrato+" - CLIENTE: "+ lstC[0].cDocumento, "CONTRATO", lstCt[0].codContrato);

                lstCt[0].imgQr = File.ReadAllBytes(rutaArchivo);
            }
            MemoryStream ms = new MemoryStream(lstCt[0].imgQr);

            ReportParameter[] parameters = new ReportParameter[2];
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            parameters[0] = new ReportParameter("rpFecha", Convert.ToString(Variables.gdFechaSis));
            parameters[1] = new ReportParameter("prQr", Convert.ToBase64String(ms.ToArray()));

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

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            string nombreArchivo = "CONTRATO - " + lstCliente[0].cNombre + " " + lstCliente[0].cApePat+" "+ lstCliente[0].cApeMat; // Especificar el nombre deseado para el archivo

            // Modificar el nombre del archivo en la descarga
            ReportViewer viewer = (ReportViewer)sender;
            viewer.LocalReport.DisplayName = nombreArchivo;
        }
    }
}
