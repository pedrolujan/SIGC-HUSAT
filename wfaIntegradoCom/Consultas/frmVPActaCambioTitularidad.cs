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
    public partial class frmVPActaCambioTitularidad : Form
    {
        public frmVPActaCambioTitularidad()
        {
            InitializeComponent();
        }
        List<Cliente> lstClienteNuevo=new List<Cliente>();
        List<Cliente> lstClienteAntiguo=new List<Cliente>();
        List<Vehiculo> lstVehiculo=new List<Vehiculo>();

        List<Vehiculo> lstVehiculoAnterior = new List<Vehiculo>();
        List<Vehiculo> lstVehiculoActual= new List<Vehiculo>();
        List<Cliente> lstCliente = new List<Cliente>();
        List<Equipo_imeis> lstEquipoImeis = new List<Equipo_imeis>();
        Int32 lnTipoCon = 0;
        public void Inicio(List<Cliente> lstClienteN, List<Cliente> lstClienteA,List<Vehiculo> lstVh,Int32 tipoC)
        {
            lstClienteNuevo.Clear();
            lstClienteAntiguo.Clear();
            lstVehiculo.Clear();

            lstClienteNuevo = lstClienteN;
            lstClienteAntiguo = lstClienteA;
            lstVehiculo = lstVh;
            lnTipoCon = tipoC;
            this.ShowDialog();
        }
        public void Inicio2(List<Vehiculo>lstVAn,Vehiculo lstVAc,Equipo_imeis lstEi,Cliente lstCl,Int32 lnTC)
        {
            lstVehiculoAnterior.Clear();
            lstVehiculoActual.Clear();
            lstCliente.Clear();
            lstEquipoImeis.Clear();

            lstVehiculoAnterior = lstVAn;
            lstVehiculoActual.Add(lstVAc);
            lstCliente.Add(lstCl);
            lstEquipoImeis.Add(lstEi);
            lnTipoCon = lnTC;
            this.ShowDialog();


        }
        private void frmVPActaCambioTitularidad_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            if (lnTipoCon==-1)
            {
                fnCargarReporte(lstClienteNuevo,lstClienteAntiguo,lstVehiculo);
            }else if (lnTipoCon==-2)
            {
                fnCargarReporte2(lstVehiculoAnterior, lstVehiculoActual,  lstEquipoImeis, lstCliente);
            }
        }
        private void fnCargarReporte(List<Cliente> lstClienteN, List<Cliente> lstClienteA, List<Vehiculo> lstVh)
        {            
            ReportParameter[] parameters = new ReportParameter[2];
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            parameters[0] = new ReportParameter("rpRazonSocial", Variables.gsEmpresa);
            parameters[1] = new ReportParameter("rpRucEmpresa", Variables.gsRuc);
            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.rptActaCambioTitularidad.rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsClienteNuevo", lstClienteN));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsClienteAntiguo", lstClienteA));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsVehiculo", lstVh));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }
        private void fnCargarReporte2(List<Vehiculo> lstVAn, List<Vehiculo> lstVAc, List<Equipo_imeis> lstEi, List<Cliente> lstCl)
        {            
            ReportParameter[] param = new ReportParameter[2];
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            param[0] = new ReportParameter("rpRazonSocial", Variables.gsEmpresa);
            param[1] = new ReportParameter("rpRucEmpresa", Variables.gsRuc);
            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.ActaCambioVehicular.rdlc";
            reportViewer1.LocalReport.SetParameters(param);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtVehiculoAnterior", lstVAn));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtVehiculoActual", lstVAc));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtEquipoImeis", lstEi));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtCliente", lstCl));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGenerarVenta_Click(object sender, EventArgs e)
        {
            if (lnTipoCon==-1)
            {
                frmOtrasVentas fr = new frmOtrasVentas();
                fr.fnCondicionProcesos(-2);
            }else if (lnTipoCon==-2)
            {
                frmOtrasVentas fr = new frmOtrasVentas();
                fr.fnCondicionProcesos(-3);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmOtrasVentas fr = new frmOtrasVentas();
            fr.fnCondicionProcesos(0);
        }
    }
}
