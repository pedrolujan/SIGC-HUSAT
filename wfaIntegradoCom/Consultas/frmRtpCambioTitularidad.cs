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
    public partial class frmRtpCambioTitularidad : Form
    {
        public frmRtpCambioTitularidad()

        {
            InitializeComponent();
        }
        List<OtrasVentas> lstOtrasVentas = new List<OtrasVentas>();
        List<Cliente> lstclienteA = new List<Cliente>();
        List<Cliente> lstclientesN = new List<Cliente>();
        List<Vehiculo> lstVehiculo = new List<Vehiculo>();
        String cboCombobox="x";
        List<DocumentoVenta> lstDocumentoVentas = new List<DocumentoVenta>();
        Titularidad clsTitularidad = new Titularidad();
        String Observaciones = "";
        Int32 lnTipoCon = 0;

        public void inicio(List<OtrasVentas> lstOtrasV, List<Cliente> lstclienteAntiguo,List<Vehiculo> lstVehicu, String obser, Titularidad clsTitu, List<DocumentoVenta> docVenta, Cliente lstPros,String cboComboBox)
        {


            lstclientesN.Clear();
            lstclienteA.Clear();
            lstDocumentoVentas.Clear();
            lstVehiculo.Clear();


            lstOtrasVentas = lstOtrasV;
           lstclienteA = lstclienteAntiguo;
            lstclientesN.Add( lstPros);
            lstVehiculo = lstVehicu;
           Observaciones = obser;
           clsTitularidad = clsTitu;
           lstDocumentoVentas= docVenta ;
            cboCombobox = cboComboBox;
            lnTipoCon = lnTipoCon;

            //fnCargarCambioTitularidad(lstOtrasVentas, lstclienteAntiguo, lstVehiculo, Observaciones, clsTitularidad, lstclientesN, cboCombobox);

            this.ShowDialog();

        }
        private void fnCargarCambioTitularidad(List<OtrasVentas> otrasVentas, List<Cliente> lstclienteAntiguo, List<Vehiculo> lstVehiculo,  String observaciones,Titularidad clsTitu, List<Cliente>lstclienteN,String cboComboB)
        {
           

            ReportParameter[] parameters = new ReportParameter[4];
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            parameters[0]=new ReportParameter("dFechaSistema", Convert.ToString(Variables.gdFechaSis));
            parameters[1] = new ReportParameter("dtFechaTitularidad", Convert.ToString(clsTitu.FechaTitularidad));
            parameters[2] = new ReportParameter("cboMotivo",cboComboB);
            parameters[3] = new ReportParameter("RazonSocial", Convert.ToString(Variables.gsEmpresa));
           
            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.rptCambioTitularidad.rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCliente",lstclienteAntiguo));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsclienteN",  lstclienteN));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsVehiculo", lstVehiculo));
            
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void frmRtpCambioTitularidad_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            fnCargarCambioTitularidad(lstOtrasVentas,lstclienteA, lstVehiculo,Observaciones, clsTitularidad,lstclientesN,cboCombobox);
        }
    private void reportViewer1_Load(object sender, EventArgs e)
        {
            FunValidaciones.fnColorAceptarCancelar(btnFinalizarInstalacion, btnVolver);
            Int32 CountAccSer = Convert.ToInt32(lstOtrasVentas.Count() - lstOtrasVentas.Count());

            for (Int32 i = 0; i < CountAccSer; i++)
            {
                lstOtrasVentas.Add(new OtrasVentas
                {
                    iddUsuario = 0,
                    cUsuario = ""

                });
            }

            if (lnTipoCon == 0)
            {

            }
            else if (lnTipoCon == 1)
            {
                btnFinalizarInstalacion.Visible = false;
                btnVolver.Visible = false;
                label1.Visible = true;
            }


            this.reportViewer1.RefreshReport();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {


            this.Close();
        }

        private void btnFinalizarInstalacion_Click(object sender, EventArgs e)
        {
            //frmVPOtrasVentas frmOTRASVENTAS = new frmVPOtrasVentas();
            //frmOTRASVENTAS.fnValidarEstado(true);
            this.Close();
        }
    }
}
