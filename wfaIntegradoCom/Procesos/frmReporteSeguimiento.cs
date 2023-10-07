using CapaDato;
using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Microsoft.Reporting.WinForms;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
//using System.Windows.Media;
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmReporteSeguimiento : Form
    {
        public frmReporteSeguimiento()
        {
            InitializeComponent();
        }
        List<Reporte> lstReporteSeguimiento = new List<Reporte>();
        private void frmReporteSeguimiento_Load(object sender, EventArgs e)
        {
            try
            {
                Boolean bResult = false;
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
                FunGeneral.fnLlenarTablaCodTipoCon(cboTipoReporte,"TRSG",false);
                
                fnLlenarUsuariosConAccion(cboUsuario, dtpFechaInicialBus,dtpFechaFinalBus,true);
                bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboEstadoCliente, "ESPR", true);
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar - Estado Cliente", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            this.reportViewer1.RefreshReport();
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            fnBuscarReporte(dgvListaPorBloque,0);
        }

        private Color fnColor(double indicador)
        {
            Color bgColor = new Color();
            if (indicador >= 1 && indicador < 2)
            {
                bgColor = Color.Green;
            }
            else if (indicador >= 2 && indicador < 3)
            {
                bgColor = Variables.ColorAmbarIndicador;

            }
            else if (indicador >= 3)
            {
                bgColor = Variables.ColorRedIndicador;
            }
            else
            {
                bgColor = Color.Black;    
            }
            return bgColor;
        }
        private void fnBuscarReporte(SiticoneDataGridView dgv, Int32 tipoCon)
        {
            Busquedas rpt = new Busquedas();
            BLProspecto bl = new BLProspecto();
            List<Reporte> lstReporte = new List<Reporte>();
            rpt.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            rpt.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtpFechaInicialBus.Value,5);
            rpt.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtpFechaFinalBus.Value,5);
            rpt.cod1=Convert.ToString(cboTipoReporte.SelectedValue).ToString();
            rpt.cod2=Convert.ToString(cboEstadoCliente.SelectedValue).ToString();
            rpt.idUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
            rpt.cBuscar=txtBuscar.Text.ToString();
            rpt.tipoCon=tipoCon;

            lstReporte=bl.blBuscarReporte(rpt);
            lstReporteSeguimiento = lstReporte;
            Int32 y = 0;
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            Int32 ancho = 0;
            Int32 totalRows = lstReporte.Count;
            if (totalRows > 0)
            {
                if (rpt.cod1 == "TRSG0001")
                {
                    
                    //Int32 countPotencial = 0;
                    //Int32 countRetirado = 0;
                    //Int32 countAnulado = 0;
                    //Int32 countComprador = 0;
                    //Int32 countTorales = 0;

                    dgv.Columns.Add("id", "id");
                    dgv.Columns.Add("n", "N°");
                    dgv.Columns.Add("Usuario", "Usuario");
                    dgv.Columns.Add("POTENCIAL", "POTENCIAL");
                    dgv.Columns.Add("RETIRADO", "RETIRADO");
                    dgv.Columns.Add("COMPRADOR", "COMPRADOR");
                    dgv.Columns.Add("TOTALES", "TOTALES");
                    dgv.Columns.Add("", "");
                    dgv.Columns.Add("COEFICIENTE", "COEFICIENTE");

                    foreach (Reporte it in lstReporte)
                    {

                        //Int32 sumColumns = Convert.ToInt32(it.coddAux2) + Convert.ToInt32(it.coddAux3) + Convert.ToInt32(it.coddAux5) ;
                        //double indicador = (double)sumColumns / Convert.ToInt32(it.coddAux5);
                        //indicador = Double.IsInfinity(indicador) ? 0 : indicador;

                        //countPotencial += Convert.ToInt32(it.coddAux2);
                        //countRetirado+=Convert.ToInt32(it.coddAux3);
                        //countAnulado+=Convert.ToInt32(it.coddAux4);
                        //countComprador+=Convert.ToInt32(it.coddAux5);
                        //countTorales += sumColumns;
                        //lstReporte[y].SumColumns = sumColumns;
                        
                       
                        dgv.Rows.Add(
                                    it.idUsuario,
                                    y + 1,
                                    it.coddAux1,
                                    it.coddAux2,
                                    it.coddAux3,
                                    it.coddAux5,
                                    it.SumColumns,
                                    "",
                                    it.indicador==0?"Indefinido":String.Format("{0:#,##0.0}", it.indicador)

                                    );
                       
                       
                        dgv.Rows[y].Cells[6].Style.BackColor = Variables.ColorGroupBox;
                        dgv.Rows[y].Cells[6].Style.ForeColor = Color.White;
                        dgv.Rows[y].Cells[8].Style.BackColor = fnColor(it.indicador);
                        dgv.Rows[y].Cells[8].Style.ForeColor = Color.White;
                        y++;
                    }
                    //double indicadorTotal = (double)countTorales / countComprador;
                    dgv.Columns[6].HeaderCell.Style.BackColor = Variables.ColorGroupBox;
                    dgv.Columns[7].HeaderCell.Style.BackColor = Color.White;
                    dgv.Columns[8].HeaderCell.Style.BackColor = Variables.ColorGroupBox;
                    dgv.Rows.Add("", "", "", "", "", "", "");
                    dgv.Rows.Add("","", "TOTALES", lstReporte[0].SumRowsAux2, lstReporte[0].SumRowsAux3, lstReporte[0].SumRowsAux5, lstReporte[0].SumRowsTotalFilas, "", String.Format("{0:#,##0.0}", lstReporte[0].indicadorTotalFilas));

                    dgv.Rows[y + 1].DefaultCellStyle.ForeColor = Color.White;
                    dgv.Rows[y + 1].DefaultCellStyle.BackColor = Variables.ColorGroupBox;
                    dgv.Rows[y+1].Cells[8].Style.BackColor = fnColor(lstReporte[0].indicadorTotalFilas);
                    dgv.Rows[y+1].Cells[8].Style.ForeColor = Color.White;


                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 10;
                    dgv.Columns[2].Width = 50;
                    dgv.Columns[3].Width = 50;
                    dgv.Columns[4].Width = 50;
                    dgv.Columns[5].Width = 50;
                    dgv.Columns[6].Width = 50;
                    dgv.Columns[7].Width = 30;
                    dgv.Columns[8].Width = 100;


                    fnGraficos(lstReporte, lstReporte[0].SumRowsAux5);
                }
                else if (rpt.cod1 == "TRSG0002")
                {
                    Int32 counOficina = 0;
                    Int32 counReferencia = 0;
                    Int32 counFacebook = 0;
                    Int32 counWhatsApp = 0;
                    Int32 counLlamada = 0;
                    Int32 counCliente = 0;
                    Int32 counSoat = 0;
                    Int32 counTotales = 0;

                    dgv.Columns.Add("id", "id");
                    dgv.Columns.Add("n", "N°");
                    dgv.Columns.Add("Usuario", "Usuario");
                    dgv.Columns.Add("OFICINA", "OFICINA");
                    dgv.Columns.Add("REFERENCIA", "REFERENCIA");
                    dgv.Columns.Add("FACEBOOK", "FACEBOOK");
                    dgv.Columns.Add("WHATSAPP", "WHATSAPP");
                    dgv.Columns.Add("LLAMADA", "LLAMADA");
                    dgv.Columns.Add("CLIENTE", "CLIENTE");
                    dgv.Columns.Add("SOAT", "SOAT");
                    dgv.Columns.Add("TOTALES", "TOTALES");

                    foreach (Reporte it in lstReporte)
                    {
                        Int32 sumColumns= Convert.ToInt32(it.coddAux2)+Convert.ToInt32(it.coddAux3)+Convert.ToInt32(it.coddAux4)+ Convert.ToInt32(it.coddAux5)+ Convert.ToInt32(it.coddAux6)+ Convert.ToInt32(it.coddAux7)+ Convert.ToInt32(it.coddAux8);
                        counOficina += Convert.ToInt32(it.coddAux2);
                        counReferencia+=Convert.ToInt32(it.coddAux3);
                        counFacebook+=Convert .ToInt32(it.coddAux4);
                        counWhatsApp+=Convert .ToInt32(it.coddAux5);
                        counLlamada+=Convert .ToInt32(it.coddAux6);
                        counCliente+=Convert .ToInt32(it.coddAux7);
                        counSoat += Convert .ToInt32(it.coddAux8);
                        counTotales += sumColumns;
                        lstReporte[y].SumColumns = sumColumns;
                        dgv.Rows.Add(
                                    it.idUsuario,
                                    y + 1,
                                    it.coddAux1,
                                    it.coddAux2,
                                    it.coddAux3,
                                    it.coddAux4,
                                    it.coddAux5,
                                    it.coddAux6,
                                    it.coddAux7,
                                    it.coddAux8,
                                    sumColumns

                                    );
                       
                        dgv.Rows[y].Cells[10].Style.BackColor = Variables.ColorGroupBox;
                        dgv.Rows[y].Cells[10].Style.ForeColor = Color.White;
                        y++;
                    }
                    dgv.Columns[9].HeaderCell.Style.BackColor= Variables.ColorGroupBox;
                    dgv.Rows.Add("", "", "", "", "", "", "","","","");
                    dgv.Rows.Add("", "", "TOTALES", counOficina, counReferencia, counFacebook, counWhatsApp,counLlamada,counCliente, counSoat, counTotales);
                    dgv.Rows[y + 1].DefaultCellStyle.ForeColor = Color.White;
                    dgv.Rows[y + 1].DefaultCellStyle.BackColor = Variables.ColorGroupBox;

                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 10;
                    dgv.Columns[2].Width = 50;
                    dgv.Columns[3].Width = 50;
                    dgv.Columns[4].Width = 50;
                    dgv.Columns[5].Width = 50;
                    dgv.Columns[6].Width = 50;
                    dgv.Columns[7].Width = 50;
                    dgv.Columns[8].Width = 50;
                    dgv.Columns[9].Width = 50;
                    dgv.Columns[10].Width = 100;

                    fnGraficos(lstReporte, counTotales);

                }
            }
            else
            {
                dgv.Columns.Add("n", "No se encontró resultados");
                dgv.Columns[0].Width = 100;
            }
            dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.Height = ((totalRows + 3) * (dgv.ThemeStyle.RowsStyle.Height + 2));

            chart1.Location = new Point(chart1.Location.X,(dgv.Location.Y+dgv.Height)+10);
            siticonePanel3.Location = new Point(siticonePanel3.Location.X, chart1.Location.Y);

            siticoneSeparator1.Location = new Point(siticoneSeparator1.Location.X, (chart1.Location.Y + chart1.Height + 30));
            //dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleVertical;

            //for (int i = 0; i < dgv.Columns.Count; i++)
            //{
            //    ancho += dgv.Columns[i].Width;
            //}

            //dgv.Width = ancho;



            this.reportViewer1.RefreshReport();
            fnCargarReporte();

        }

        private void fnGraficos(List<Reporte> lstReporte,Int32 countTotales)
        {
            String codTipoReporte = cboTipoReporte.SelectedValue.ToString();
            
            //chart1.Series.Clear();
            chart1.Series[0].Points.Clear();
            
            Int32 y = 0;
            ArrayList series = new ArrayList();
            ArrayList items = new ArrayList();
            chart1.Titles[0].Text = codTipoReporte== "TRSG0001" ? "Grafico Estadistico de Ventas": "Grafico Estadistico de Prospectos";
            foreach (Reporte it in lstReporte)
            {
                //if (chart1.Series.Count > 0 && chart1.Series[y - 1].Name == it.coddAux1)
                //{
                //    chart1.Series[it.coddAux1].Points.Clear();
                //}
                series.Add(it.coddAux1);
                Decimal datoY = decimal.Round((Decimal)(codTipoReporte== "TRSG0001"? Convert.ToInt32(it.coddAux5) * 100 : it.SumColumns * 100) / countTotales, 2);
                lstReporte[y].numPorcentaje = datoY;

                items.Add(it.numPorcentaje);
                //chart1.Series.Add(it.coddAux1);
                //chart1.Series[it.coddAux1].Points.AddXY("Ventas",datoY);
                //chart2.Series["Series1"].Points.AddXY(it.coddAux1, datoY);
                y++;
            }
           chart1.Series[0].Points.DataBindXY(series, items);
            //chart1.Height = lstReporte.Count < 5 ? (lstReporte.Count * 110) : lstReporte.Count > 10 ? (lstReporte.Count * 80) : (lstReporte.Count * 60) - lstReporte.Count * lstReporte.Count;
            //chart1.Width = lstReporte.Count < 5 ? 800 : 993;
            //fnGraficosPie(lstReporte, countTotales);
        }

        private void fnGraficosPie(List<Reporte> lstReporte, Int32 countTotales)
        {

            chart1.Series[0].Points.Clear();

            Int32 y = 0;
            ArrayList series = new ArrayList();
            ArrayList items = new ArrayList();
            //chart2.Series.Clear();
            foreach (Reporte it in lstReporte)
            {
                series.Add(it.coddAux1);
                Decimal datoY = decimal.Round((Decimal)(it.SumColumns * 100) / countTotales, 2);
                lstReporte[y].numPorcentaje = datoY;

                items.Add(it.numPorcentaje);
              
                y++;
            }

            chart1.Series[0].Points.DataBindXY(series, items);
            for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            {
                chart1.Series[0].Points[i].Label = lstReporte[i].numPorcentaje+"%";
                chart1.Series[0].Points[i].LegendText = lstReporte[i].coddAux1;

            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(Char)Keys.Enter)
            {
                fnBuscarReporte(dgvListaPorBloque, 0);
            }
        }

        private void chkHabilitarFechasBusG_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechasBusG.Checked==true)
            {
                gbBuscar.Enabled = true;
            }
            else
            {
                gbBuscar.Enabled = false;
                fnLlenarUsuariosConAccion(cboUsuario, dtpFechaInicialBus, dtpFechaFinalBus, true);
            }
            
        }

        private void dtpFechaInicialBus_ValueChanged(object sender, EventArgs e)
        {
            fnLlenarUsuariosConAccion(cboUsuario, dtpFechaInicialBus, dtpFechaFinalBus, true);
        }
        public void fnLlenarUsuariosConAccion(SiticoneComboBox cbo, SiticoneDateTimePicker dtIni, SiticoneDateTimePicker dtFin, Boolean estado)
        {
            DAControlCaja dc = new DAControlCaja();
            List<Usuario> lstUsuario = new List<Usuario>();
            DataTable dt = new DataTable();
            String FI = FunGeneral.GetFechaHoraFormato(dtIni.Value, 5);
            String FF = FunGeneral.GetFechaHoraFormato(dtFin.Value, 5);
            Boolean chk = chkHabilitarFechasBusG.Checked;
            Int32 tipCOn =-2;

            dt = dc.daDevolverSoloUsuario(chk, FI, FF, tipCOn);

            lstUsuario.Add(new Usuario(
                Convert.ToInt32(0),
                Convert.ToString(estado ? "TODOS" : "Selecc. Usuario")
              ));

            foreach (DataRow drMenu in dt.Rows)
            {
                lstUsuario.Add(new Usuario(
                    Convert.ToInt32(drMenu["idUsuario"]),
                    Convert.ToString(drMenu["cUser"])
                    ));
            }
            cbo.ValueMember = "idUsuario";
            cbo.DisplayMember = "cUser";
            cbo.DataSource = lstUsuario;
            cbo.SelectedValue = Variables.gsCargoUsuario != "PETR0006" ? 0 : Variables.gnCodUser;
            cbo.Enabled = Variables.gsCargoUsuario != "PETR0006" ? true :false;


        }

        private void dtpFechaFinalBus_ValueChanged(object sender, EventArgs e)
        {
            fnLlenarUsuariosConAccion(cboUsuario, dtpFechaInicialBus, dtpFechaFinalBus, true);
        }

        private void tbcDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Int32 index = tbcDatos.SelectedIndex;
            
            //if (index==1)
            //{
            //    this.reportViewer1.RefreshReport();
            //    fnCargarReporte();
            //}
        }

        private void fnCargarReporte()
        {
            String codTipoReporte = cboTipoReporte.SelectedValue.ToString();
            String strRuta = codTipoReporte== "TRSG0001" ? "wfaIntegradoCom.Consultas.rptReporteSeguimiento.rdlc" : "wfaIntegradoCom.Consultas.rptReporteSeguimientoTipoVisita.rdlc";
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
            reportViewer1.LocalReport.ReportEmbeddedResource = strRuta;
            //reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsReporte", lstReporteSeguimiento));
            //reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.RefreshReport();
        }
    }
}
