using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmVPVentaGeneral : Form
    {
        public frmVPVentaGeneral()
        {
            InitializeComponent();
        }
        private VentaGeneral clsVG;
        private void frmVPVentaGeneral_Load(object sender, EventArgs e)
        {
            clsVG = new VentaGeneral();
            this.reportViewer1.RefreshReport();
        }

        private void fnLlenarCliente(Cliente clsC)
        {
            txtTipPersonaC.Text = clsC.clsTC.TCnombre;
            txtTipDocumentoC.Text = clsC.clsTD.TCnombre;
            txtDocumentoC.Text = clsC.cDocumento;
            txtDocumentoC.Text = clsC.cNombre;
            txtCorreoC.Text = clsC.cCorreo;
            txtTelefonoC.Text = clsC.cTelFijo;
            txtCelularC.Text = clsC.cTelCelular;
            txtDireccionC.Text = clsC.cDireccion;
        }
        private void fnLLenarRespPago(Cliente clsRP)
        {
            txtTipPersonaRP.Text = clsRP.clsTC.TCnombre;
            txtTipDocumentoRP.Text = clsRP.clsTD.TDnombre;
            txtDocumentoRP.Text = clsRP.cDocumento;
            txtNombreRP.Text = clsRP.cNombre;
            txtCorreoRP.Text = clsRP.cCorreo;
            txtTelefonoFijoRP.Text = clsRP.cTelFijo;
            txtCelularRP.Text = clsRP.cTelCelular;
            txtDireccionRP.Text = clsRP.cDireccion;
        }
        private void fnLlenarVehiculos(List<Vehiculo> lstV,DataGridView dgv)
        {
            dgv.Rows.Clear();
            Int32 i = 0;
            foreach (Vehiculo item in lstV)
            {
                dgv.Rows.Add(
                    item.idVehiculo,
                    i + 1,
                    item.vPlaca,
                    $"{item.vClase} / {item.vMarcaV} / {item.vModeloV}",
                    item.ModoUso
                );
                i += 1;
            }
        }
        private void fnLlenarPlan(Plan clsP, Ciclo clsC, DetalleVenta clsDV)
        {
            txtTipoPlan.Text = clsP.clsTP.nombreTipoPlan;
            txtPlan.Text = clsP.nombrePlan;
            txtCiclo.Text = clsC.Dia;
        }

        private void fnLlenarDetalleVentas(DetalleVentaCabecera clsDVC,List<DetalleVenta> lstPP, List<DetalleVenta> lstDV, DataGridView dgv)
        {
            dgv.Rows.Clear();
            Int32 i = 0;
            txtIGV.Text = Convert.ToString(clsDVC.IGV);
            txtSubTotal.Text = Convert.ToString(clsDVC.ValorVenta);
            txtTotal.Text = Convert.ToString(clsDVC.ImporteTotal);
            txtTotalFijo.Text = Convert.ToString(clsDVC.ImporteTotal);
            foreach (DetalleVenta item in lstDV)
            {
                dgv.Rows.Add(
                    item.IdDetalleVenta,
                    i + 1,
                    item.Descripcion,
                    item.PrecioUni,
                    item.Descuento,
                    item.Couta,
                    item.Cantidad,
                    item.Importe
                );
                i += 1;
            }

            foreach (DetalleVenta item in lstPP)
            {
                dgv.Rows.Add(
                    item.IdDetalleVenta,
                    i + 1,
                    item.Descripcion,
                    item.PrecioUni,
                    item.Descuento,
                    item.Couta,
                    item.Cantidad,
                    item.Importe
                );
                i += 1;
            }
        }
    }
}
