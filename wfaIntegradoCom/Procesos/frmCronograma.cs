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

namespace wfaIntegradoCom.Procesos
{
    public partial class frmCronograma : Form
    {
        public frmCronograma()
        {
            InitializeComponent();
        }
        public static List<DetalleCronograma> lstDetalleCronograma ;
        public static List<Vehiculo> lstVehiculo;
        public static List<DetalleVenta> lstPagoPrincipal;
        public static List<Moneda> lstMoneda;
        
        public void Inicio(List<DetalleCronograma> lstDC, List<Vehiculo> lstV,List<DetalleVenta> lstPP, List<Moneda> lstM)
        {
            lstVehiculo = new List<Vehiculo>();
            lstDetalleCronograma = new List<DetalleCronograma>();
            lstMoneda = new List<Moneda>();
            lstDetalleCronograma = lstDC;
            lstVehiculo = lstV;
            lstPagoPrincipal = lstPP;
            lstMoneda = lstM;
            ShowDialog();
        }

        private void frmCronograma_Load(object sender, EventArgs e)
        {
            fnLLenarVehiculosADataGrid(lstVehiculo, dgvVehiculos);
            CargarReporte(lstDetalleCronograma, lstPagoPrincipal, lstMoneda);
            this.reportViewer1.RefreshReport();
        }

        private Int32 fnContarVehiculosActivos(List<Vehiculo> lstV)
        {
            int numActivos = 0;
            foreach (Vehiculo item in lstV)
            {
                if (item.bEstado)
                {
                    numActivos += 1;
                   
                }
            }
            return numActivos;
        }

        private Boolean fnListarFecha(List<DetalleCronograma> lstDC, List<Vehiculo> lstV, DataGridView dgv)
        {
            Double TotalPagar = 0;
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("N° CUOTA");
            dt.Columns.Add("PERIODO INICIO");
            dt.Columns.Add("PERIODO FINAL");
            dt.Columns.Add("FECHA EMISIÓN");
            dt.Columns.Add("VENCE");
            dt.Columns.Add("MONTOS NUMERICOS");
            dt.Columns.Add("DESCRIPCIÓN");
            dt.Columns.Add("PRECIO");
            dt.Columns.Add("N° VEHICULOS");
            dt.Columns.Add("IMPORTE");
            dt.Columns.Add("ESTADO");

            for (int i = 0; i < lstDC.Count; i++)
            {
                Double montoMes = lstDC[i].montoPago;
                Double cantVehiculos = fnContarVehiculosActivos(lstVehiculo);
                Double precioTotal = lstDC[i].montoPago * cantVehiculos;
                object[] row = {
                    $"{i+1}",
                    lstDC[i].periodoInicio.ToString("dd MMM yyyy"),
                    lstDC[i].periodoFinal.ToString("dd MMM yyyy"),
                    lstDC[i].fechaEmision.ToString("dd MMM yyyy"),
                    lstDC[i].fechaVencimiento.ToString("dd MMM yyyy"),
                    montoMes,
                    lstDC[i].descripcion,
                    $"S/ {String.Format("{0:0.00}",montoMes)}",
                    cantVehiculos,
                    "S/ " + Math.Round(precioTotal, 2),
                    "PENDIENTE"
                };

                TotalPagar += precioTotal;
                dt.Rows.Add(row);
            }

            //lblTotalPagar.Text = "S/ " + Math.Round(TotalPagar, 2);
            dgv.DataSource = dt;

            dgv.Columns[0].Width = 30;
            dgv.Columns[1].Width = 40;
            dgv.Columns[2].Width = 40;
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Width = 40;
            dgv.Columns[5].Visible = false;
            dgv.Columns[6].Width = 90;
            dgv.Columns[7].Width = 50;
            dgv.Columns[8].Width = 60;
            dgv.Columns[9].Width = 100;
            dgv.Columns[10].Visible = false;

            return true;
        }

        private void fnLLenarVehiculosADataGrid(List<Vehiculo> lstV, DataGridView dgv)
        {
            dgvVehiculos.Rows.Clear();
            foreach (Vehiculo item in lstV)
            {
                dgvVehiculos.Rows.Add(
                    item.idVehiculo,
                    item.vPlaca,
                    item.bEstado
                );
            }
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].Width = 50;
        }

        private void dgvVehiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVehiculos.Rows.Count > 0)
            {
                int filaSeleccionada = e.RowIndex;
                int columnaSeleccionada = e.ColumnIndex;
                Boolean estSeleccionado;
                if (columnaSeleccionada == 2)
                {
                    estSeleccionado = Convert.ToBoolean(dgvVehiculos[columnaSeleccionada, filaSeleccionada].Value);
                    //foreach (DetalleVenta item in lstDetalleCronograma)
                    //{
                    //    item.Cantidad = !estSeleccionado;
                    //}
                    
                    fnLLenarVehiculosADataGrid(lstVehiculo, dgvVehiculos);
                    CargarReporte(lstDetalleCronograma, lstPagoPrincipal, lstMoneda);
                }
            }
        }

        private String fnConvertirDoubleaStringPrecio(Decimal valor)
        {
            string cadena = String.Format("{0:0.00}", valor);
            return cadena;
        }
        private void CargarReporte(List<DetalleCronograma> lstDC, List<DetalleVenta> lstPP,List<Moneda> lstM)
        {
            List<DetalleCronograma> lstDetaCrono = lstDC;
            List<DetalleVenta> lstPagoPrinci = lstPP;
            List<Moneda> lstMoneda = lstM;
            ReportParameter[] parametros = new ReportParameter[3];
            Decimal sumaPrimerPago = lstPP.Sum(item => item.Importe);
            Decimal sumaCronograma = lstDC.Sum(item => item.total);
            Decimal sumaPagoTotal = lstPP.Count>0?sumaPrimerPago + sumaCronograma: sumaCronograma;
            string sSumaPagoTotal = $"{lstPP[0].cSimbolo} {fnConvertirDoubleaStringPrecio(sumaPagoTotal)}";
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            parametros[0] = new ReportParameter("prSumaPrimerPago", fnConvertirDoubleaStringPrecio(sumaPrimerPago));
            parametros[1] = new ReportParameter("prSumaCronograma", fnConvertirDoubleaStringPrecio(sumaCronograma));
            parametros[2] = new ReportParameter("prSumaPagoTotal", sSumaPagoTotal);
            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.rptCronograma.rdlc";
            reportViewer1.LocalReport.SetParameters(parametros);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DetalleCronograma", lstDetaCrono));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("PrimerPago", lstPagoPrinci));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("claseMoneda", lstMoneda));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }
    }

    
}
