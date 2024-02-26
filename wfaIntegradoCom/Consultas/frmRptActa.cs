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
using wfaIntegradoCom.Mantenedores;

namespace wfaIntegradoCom.Consultas
{
    public partial class frmRptActa : Form
    {
        public frmRptActa()
        {
            InitializeComponent();
        }

        List<Cliente> lstCliente = new List<Cliente>();
        List<Vehiculo> lstVehiculo = new List<Vehiculo>();
        List<Equipo_imeis> lstEquipo = new List<Equipo_imeis>();
        List<Plan> lstPlan = new List<Plan>();
        List<AccesoriosEquipo>lstAccesorios=new List<AccesoriosEquipo>();
        List<ServicioEquipo> lstServicios = new List<ServicioEquipo>();
        Instalacion clsIntalacion = new Instalacion();
        String Observacion = "";
        String TecnicoH = "";
        Int32 lnTipoCon = 0;
              


        public void Inicio(List<Cliente> lstCli, List<Vehiculo> lstVh, List<Equipo_imeis> lstEq, List<Plan> lstPl,List<AccesoriosEquipo> lstAcce,List<ServicioEquipo>lstServ,String Observaciones,Instalacion clsInt,Int32 TipoCon)
        {
            lstCliente = lstCli;
            lstVehiculo = lstVh;
            lstEquipo = lstEq;
            lstPlan = lstPl;
            lstAccesorios = lstAcce;
            lstServicios = lstServ;
            Observacion = Observaciones;
            clsIntalacion = clsInt;
            lnTipoCon = TipoCon;


            this.ShowDialog();
        }
        private void frmRptActa_Load(object sender, EventArgs e)
        {
            FunValidaciones.fnColorAceptarCancelar(btnFinalizarInstalacion,btnVolver);

            Int32 CountAccSer =Convert.ToInt32( lstServicios.Count() - lstAccesorios.Count());

            for (Int32 i = 0; i < CountAccSer; i++)
            {
                lstAccesorios.Add(new AccesoriosEquipo
                {

                    idAccesorios = 0,
                    NombreAccesorio=""
                    
                });
            }

            if (lnTipoCon==0)
            {

            }
            else if (lnTipoCon==1)
            {
                btnFinalizarInstalacion.Visible = false;
                btnVolver.Visible = false;
                label1.Visible = true;
            }
            

            this.reportViewer1.RefreshReport();
            fnCargarRptActa(lstCliente, lstVehiculo, lstEquipo, lstPlan,lstAccesorios,lstServicios,Observacion, clsIntalacion);
            
        }

        private void btnFinalizarInstalacion_Click(object sender, EventArgs e)
        {
            frmInstalacionEquipo frmInstalacion = new frmInstalacionEquipo();
            frmInstalacion.fnValidarEstado(true);
            this.Close();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmInstalacionEquipo frmInstalacion = new frmInstalacionEquipo();
            frmInstalacion.fnValidarEstado(false);
            this.Close();
        }
        private void fnCargarRptActa(List<Cliente> lstCli, List<Vehiculo> lstVh, List<Equipo_imeis> lstEq, List<Plan> lstPl, List<AccesoriosEquipo> lstAc, List<ServicioEquipo> lstSer, String observaciones,Instalacion clsInt)
        {

            ReportParameter[] parameters = new ReportParameter[9];
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            String rutaArchivo = FunGeneral.GetRootPath() + @"\QR\ACTA\"+ clsInt.codigoInstalacion+".png";

            if (File.Exists(rutaArchivo))
            {
                clsInt.imgQr = File.ReadAllBytes(rutaArchivo);
               
            }
            else
            {
                clsUtil cls = new clsUtil();
                cls.ObtenerQr(clsInt.codigoInstalacion, "ACTA", clsInt.codigoInstalacion);

                clsInt.imgQr = File.ReadAllBytes(rutaArchivo);
            }
            MemoryStream ms = new MemoryStream(clsInt.imgQr);

            parameters[0] = new ReportParameter("dFechaSistema", Convert.ToString(Variables.gdFechaSis));
            parameters[1] = new ReportParameter("dFechaRefIns", Convert.ToString(clsInt.dFechaIntal));
            parameters[2] = new ReportParameter("prObservacion", observaciones);
            parameters[3] = new ReportParameter("prTecnico", clsInt.cUsuario);
            parameters[4] = new ReportParameter("RazonSocial", Convert.ToString(Variables.gsEmpresa));
            parameters[5] = new ReportParameter("prCodigoInstalacion", clsInt.codigoInstalacion);
            parameters[6] = new ReportParameter("prFechaHasta", Convert.ToString(clsInt.dFechaIntal.AddMonths(+12).AddDays(-1)));
            parameters[7] = new ReportParameter("prQr", Convert.ToBase64String(ms.ToArray()));
            parameters[8] = new ReportParameter("prTipoActa", Convert.ToString(clsInt.tipoActa));

            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.rptActaInstalacion.rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCliente", lstCli));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsVehiculo", lstVh));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsEquipo", lstEq));
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDetalleEquipo", lstEq));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsPlan", lstPl));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsAccesorio", lstAc));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsServicios", lstSer));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            string nombreArchivo = "ACTA DE INSTALACION - " + lstCliente[0].cNombre + " " + lstCliente[0].cApePat + " " + lstCliente[0].cApeMat; // Especificar el nombre deseado para el archivo

            // Modificar el nombre del archivo en la descarga
            ReportViewer viewer = (ReportViewer)sender;
            viewer.LocalReport.DisplayName = nombreArchivo;
        }
    }
}
