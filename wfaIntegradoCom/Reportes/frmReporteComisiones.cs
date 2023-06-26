using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;
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
using wfaIntegradoCom.Mantenedores;
using ZXing;

namespace wfaIntegradoCom.Reportes
{
    public partial class frmReporteComisiones : Form
    {
        public frmReporteComisiones()
        {
            InitializeComponent();
        }
        static Point location = new Point();
        static Size size=new Size();
        static List<Reporte> lstReporte = new List<Reporte>();
        static List<Reporte> lstReporteMinimalista = new List<Reporte>();

        private void frmReporteComisiones_Load(object sender, EventArgs e)
        {
            try
            {
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));

                FunGeneral.fnLlenarUsuariosConAccion(cboUsuario,chkHabilitarFechasBusG.Checked,dtpFechaInicialBus.Value,dtpFechaFinalBus.Value,true,-2);
                frmSeguimiento frmSeg=new frmSeguimiento();
                frmSeg.fnLlenarTipoPlan(0,cboTipoContrato,0);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cboTipoContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 idcboBuscarTipoPlan = Convert.ToInt32(cboTipoContrato.SelectedValue ?? 0);
          
                frmSeguimiento frm = new frmSeguimiento();
                frm.fnLLenarPlanxTipoPlan(siticoneComboBox1, true, 0, idcboBuscarTipoPlan);
          
        }

      
        private void MaximizeFormWithoutTaskbar()
        {
            string nombreIcono = iconPictureBox1.IconChar.ToString();
           
            Rectangle screenBounds = Screen.FromControl(this).WorkingArea;
            if (nombreIcono== "WindowMaximize")
            {
                location = this.Location;
                size= this.Size;

                this.Location = screenBounds.Location;
                this.Size = screenBounds.Size;
                iconPictureBox1.IconChar = IconChar.WindowRestore;
            }
            else
            {
                this.Location = location;
                this.Size = size;
                iconPictureBox1.IconChar = IconChar.WindowMaximize;
            }

            // Obtener el tamaño y posición de la pantalla actual

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            MaximizeFormWithoutTaskbar();
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            fnBuscarReporte();
        }

        private void fnBuscarReporte()
        {
            BLControlPagos blcontrol = new BLControlPagos();
           
            try
            {
                Busquedas busquedas = new Busquedas();
                busquedas.cBuscar=txtBuscar.Text.ToString();
                busquedas.chkActivarFechas = chkHabilitarFechasBusG.Checked;
                busquedas.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtpFechaInicialBus.Value,5);
                busquedas.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtpFechaFinalBus.Value,5);
                busquedas.cod1 = cboTipoContrato.SelectedValue.ToString();
                busquedas.cod2= siticoneComboBox1.SelectedValue.ToString();
                busquedas.idUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
                var resp =blcontrol.blBuscarReporteComisiones(busquedas);
                lstReporte = resp.Item1;
                lstReporteMinimalista = resp.Item2;
                for (int i = 0; i < lstReporte.Count; i++)
                {
                    lstReporte[i].nombreAux1 = FunGeneral.FormatearCadenaTitleCase(lstReporte[i].nombreAux1);
                    lstReporte[i].nombreAux2 = FunGeneral.FormatearCadenaTitleCase(lstReporte[i].nombreAux2);
                    lstReporte[i].nombreAux3 = FunGeneral.FormatearCadenaTitleCase(lstReporte[i].nombreAux3);

                }
                for (int i = 0; i < lstReporteMinimalista.Count; i++)
                {
                    lstReporteMinimalista[i].nombreAux1 = FunGeneral.FormatearCadenaTitleCase(lstReporteMinimalista[i].nombreAux1);
                    lstReporteMinimalista[i].dtFecha = dtpFechaFinalBus.Value;
                    

                }
                fnCargarReporte(lstReporteMinimalista,lstReporte);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void fnCargarReporte(List<Reporte> lstRpMinimalista, List<Reporte>  lstReporte)
        {
            ReportViewer rptv = reportViewer1;
            //String codTipoReporte = cboTipoReporte.SelectedValue.ToString();
            String strRuta = "wfaIntegradoCom.Consultas.reporteComisiones.rdlc";
            //List<PagoPrincipal> lstPagoPrinci = lstPP;
            ReportParameter[] parameters = new ReportParameter[3];
            ///Mostrar datos en el reporte
            rptv.Reset();
            rptv.LocalReport.DataSources.Clear();
            rptv.ProcessingMode = ProcessingMode.Local;
            //parameters[0] = new ReportParameter("rpEmpresa", Variables.gsEmpresa);
            parameters[0] = new ReportParameter("rpSucursal", Variables.gsSucursal);
            parameters[1] = new ReportParameter("rpEmpresaDir", Variables.gsEmpresaDir);
            parameters[2] = new ReportParameter("rpRuc", Variables.gsRuc);
            rptv.LocalReport.ReportEmbeddedResource = strRuta;
            //reportViewer1.LocalReport.SetParameters(parameters);
            rptv.LocalReport.DataSources.Add(new ReportDataSource("dtReporte", lstReporte));
            rptv.LocalReport.DataSources.Add(new ReportDataSource("dtReporteMinimalista", lstRpMinimalista));
            rptv.ZoomMode = ZoomMode.Percent;
            rptv.RefreshReport();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                fnBuscarReporte();
            }
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            string nombreArchivo = "Reporte de comisiones mes: " + lstReporteMinimalista[0].dtFecha.ToString("MMMM yyyy") ; 

            // Modificar el nombre del archivo en la descarga
            ReportViewer viewer = (ReportViewer)sender;
            viewer.LocalReport.DisplayName = nombreArchivo;
        }
    }
}
