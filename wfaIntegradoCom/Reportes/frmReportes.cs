using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Mantenedores;

namespace wfaIntegradoCom.Reportes
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }
        BLControlPagos  obRecaudacion;
        List<Reporte> lstReporte = new List<Reporte>();
        List<Reporte> lstReporteRenovacion = new List<Reporte>();
        List<Reporte> lstReporteVentas = new List<Reporte>();
        
        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Int32 lnTipioLlamada = 0;
        public void Inicio(Int32 tipoLla)
        {
            lnTipioLlamada = tipoLla;
            this.Show();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms[this.Name] != null)
                {
                    if (lnTipioLlamada == 0)
                    {
                        tabControl1.SelectedIndex = 0;
                        tabControl1.Controls.RemoveAt(1);
                    }
                    else if (lnTipioLlamada == 1)
                    {
                        tabControl1.SelectedIndex = 1;
                        tabControl1.Controls.RemoveAt(0);
                    }
                }
               

                FunGeneral.fnLlenarCiclo(0,cboCiclo,true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboEstado, "ESPV", true);
                FunGeneral.fnLlenarTablaCodTipoCon(siticoneComboBox1, "TICN", true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboTipoReporte, "TRRC", false);

                FunGeneral.fnLlenarTablaCodTipoCon(cboTiporeport, "TRRN", false);
                cboTiporeport.SelectedValue = "TRRN0001";

                FunGeneral.fnLlenarTablaCodTipoCon(cboTipoReporteVentas, "TRRV", false);
                cboTipoReporteVentas.SelectedValue = "TRRV0001";

                FunGeneral.fnLlenarTablaCodTipoCon(cboTipoFiltroVentas, "TRFV", false);
                cboTipoFiltroVentas.SelectedValue = "TRFV0001";

                frmRegistrarVenta frm = new frmRegistrarVenta();
                frm.fnLlenarTipoPlan(0, cboTipoPlan, 0);
               
                cboTipoReporte.SelectedValue = "TRRC0001";

                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboFiltraIngresos, "idOperacion", "cNombreOperacion", "OperacionHusat", "cTipoConcepto", "TICO0004", true);

                cboRepVentaAnio.DataSource = Enumerable.Range(2018, (Variables.gdFechaSis.Year-2018)+1).ToList();
                cboRepVentaAnio.SelectedIndex = cboRepVentaAnio.Items.IndexOf(Variables.gdFechaSis.Year);
                fnLlenarCbos(cboMes,2,true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static Boolean fnLlenarCbos(ComboBox cboCombo, Int32 tipoCon, Boolean buscar)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod.Add(new Cargo(
                       Convert.ToString("0"),
                       Convert.ToString(buscar ? "TODOS" : "Selecc. opcion"),
                       Convert.ToString("1")));

                if (tipoCon==2)
                {
                    for (int i = 1; i < 13; i++)
                    {
                        lstTablaCod.Add(new Cargo
                        {
                            cCodTab = "" + i,
                            cNomTab = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i)
                        });
                    }

                    cboCombo.DataSource = null;
                    cboCombo.ValueMember = "cCodTab";
                    cboCombo.DisplayMember = "cNomTab";
                    cboCombo.DataSource = lstTablaCod;
                }
                

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }
        private void pbBuscar_Click(object sender, EventArgs e)
        {
            fnBuscarReporte();
        }
        private void fnBuscarReporte()
        {
            obRecaudacion = new BLControlPagos();
            DataTable dt = new DataTable();
            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtpFechaInicialBus.Value,5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtpFechaFinalBus.Value,5);
            clsBusq.cBuscar = txtBuscar.Text.ToString();
            clsBusq.cod1 = cboTipoReporte.SelectedValue.ToString();
            clsBusq.cod2=cboEstado.SelectedValue.ToString();
            clsBusq.cod3 = cboCiclo.SelectedValue.ToString();
            clsBusq.cod4 = "0";


            lstReporte = obRecaudacion.blBuscarReporte(clsBusq);
            fnCargarReporte(reportViewer1);
            fnTamanioReporte(reportViewer1);
            string strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(8);
        }

        private void fnCargarReporte(ReportViewer rptv)
        {
            //String codTipoReporte = cboTipoReporte.SelectedValue.ToString();
            String strRuta = lnTipioLlamada == 0?"wfaIntegradoCom.Consultas.rptReporteRecaudacion.rdlc": "wfaIntegradoCom.Consultas.rptReporteRenovacion.rdlc";
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
            rptv.LocalReport.DataSources.Add(new ReportDataSource("dtReporte", lnTipioLlamada == 0?lstReporte:lstReporteRenovacion));
            rptv.ZoomMode = ZoomMode.PageWidth;
            rptv.RefreshReport();
        }

        private void fnTamanioReporte(ReportViewer rptv)
        {
            Int32 wd = this.Size.Width;
            if (wd < 800)
            {
                rptv.ZoomMode = ZoomMode.PageWidth;
            }
            else
            {
                rptv.ZoomMode = ZoomMode.Percent;
            }
        }
    
        private void gunaControlBox3_Click(object sender, EventArgs e)
        {
            fnTamanioReporte(reportViewer1);
            fnTamanioReporte(reportViewer2);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void pbBuscar1_Click(object sender, EventArgs e)
        {
            fnBuscarReporteRenovacion();
        }

        private void fnBuscarReporteRenovacion()
        {
            obRecaudacion = new BLControlPagos();
            DataTable dt = new DataTable();
            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = siticoneCheckBox1.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtFechaIniRenova.Value, 5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFinRenova.Value, 5);
            clsBusq.cBuscar = txtBuscar.Text.ToString();
            clsBusq.cod1 = cboTiporeport.SelectedValue.ToString();
            clsBusq.cod2 = cboTipoPlan.SelectedValue.ToString();
            clsBusq.cod3 = siticoneComboBox1.SelectedValue.ToString();
            clsBusq.cod4 = "0";
            clsBusq.tipoCon = 0;

            lstReporteRenovacion = obRecaudacion.blBuscarReporteRenovaciones(clsBusq);
            fnCargarReporte(reportViewer2);
            fnTamanioReporte(reportViewer2);
            string strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(8);
        }
        private void fnBuscarReporteVenta()
        {
            obRecaudacion = new BLControlPagos();
            DataTable dt = new DataTable();
            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = false;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis,5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 5);
            clsBusq.cBuscar = siticoneTextBox2.Text.ToString();
            clsBusq.cod1 = cboTipoReporteVentas.SelectedValue.ToString();
            clsBusq.cod2 = cboTipoFiltroVentas.SelectedValue.ToString();
            clsBusq.cod3 = cboRepVentaAnio.SelectedValue.ToString();
            clsBusq.cod4 = cboMes.SelectedValue.ToString();
            clsBusq.cod5 = cboFiltraIngresos.SelectedValue.ToString();   
            clsBusq.tipoCon = 0;

            lstReporteVentas = obRecaudacion.blBuscarReporteVentas(clsBusq);
            fnCargarReporte(reportViewer3);
            fnTamanioReporte(reportViewer3);
        }

        private void siticoneTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                fnBuscarReporteRenovacion();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar== (char)Keys.Enter)
            {
                fnBuscarReporte();
            }
        }

        private void cboTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            String cod = cboTipoReporte.SelectedValue.ToString();
            if (cod== "TRRC0001")
            {
                //dtpFechaFinalBus.Value = Variables.gdFechaSis;
                //dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
                DateTime dtt = Variables.gdFechaSis.AddDays(-Variables.gdFechaSis.Day);
                dtpFechaFinalBus.Value = Variables.gdFechaSis.AddDays(DateTime.DaysInMonth(Variables.gdFechaSis.Year, Variables.gdFechaSis.Month) - Variables.gdFechaSis.Day);
                dtpFechaInicialBus.Value = Variables.gdFechaSis.AddDays(-(Variables.gdFechaSis.Day-1));

            }
            else
            {
                //dtpFechaFinalBus.Value = Variables.gdFechaSis;
                //dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1)).AddMonths(-(dtpFechaFinalBus.Value.Month - 1));

                DateTime dt = Variables.gdFechaSis.AddMonths(12 - Variables.gdFechaSis.Month);
                dtpFechaFinalBus.Value = dt.AddDays(DateTime.DaysInMonth(dt.Year, dt.Month) - Variables.gdFechaSis.Day);
                dtpFechaInicialBus.Value = Variables.gdFechaSis.AddDays(-(Variables.gdFechaSis.Day - 1));
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            fnBuscarReporteVenta();
        }

        private void cboTiporeport_SelectedIndexChanged(object sender, EventArgs e)
        {
            String cod = cboTiporeport.SelectedValue.ToString();
            if (cod== "TRRN0001")
            {
                DateTime dt = Variables.gdFechaSis.AddMonths(12-Variables.gdFechaSis.Month);
                dtFechaIniRenova.Value = Variables.gdFechaSis.AddMonths(-(Variables.gdFechaSis.Month - 1)).AddDays(-(Variables.gdFechaSis.Day-1));

                dtFechaFinRenova.Value = dt.AddDays(DateTime.DaysInMonth(dt.Year, dt.Month)- Variables.gdFechaSis.Day);
               
            }
            else
            {
                dtFechaIniRenova.Value = Variables.gdFechaSis.AddDays(-(Variables.gdFechaSis.Day - 1));

                dtFechaFinRenova.Value = Variables.gdFechaSis.AddDays(DateTime.DaysInMonth(Variables.gdFechaSis.Year, Variables.gdFechaSis.Month) - Variables.gdFechaSis.Day);
            }
        }
    }
}
