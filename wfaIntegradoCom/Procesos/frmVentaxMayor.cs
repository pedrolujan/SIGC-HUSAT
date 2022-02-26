using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Consultas;
using System.Globalization;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmVentaxMayor : Form
    {
        public frmVentaxMayor()
        {
            InitializeComponent();
        }

        private Boolean fnListarClientesActivo(Boolean pbEstado)
        {
            BLCliente objCliente = new BLCliente();
            clsUtil objUtil = new clsUtil();
            List<Cliente> lsCliente = new List<Cliente>();

            try
            {
                lsCliente = objCliente.blListarClientes(pbEstado);
                cboCliente.DataSource = null;
                cboCliente.ValueMember = "idCliente";
                cboCliente.DisplayMember = "cCliente";
                cboCliente.DataSource = lsCliente;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmVentaxMayor", "fnListarClientesActivo", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objCliente = null;
                lsCliente = null;
            }

        }

        private void frmVentaxMayor_Load(object sender, EventArgs e)
        {
            bool bResult = false;

            bResult = fnListarClientesActivo(true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Clientes Activos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void Limpiar()
        {
            txtidLote.Text = "";
            txtProducto.Text = "";
            txtStock.Text = "";
            txtPrecio.Text = "0";
            txtCantidad.Text = "0";
            txtImporte.Text = "0";
            radioButton1.Checked = true;
            numericUpDown1.Value = 0;
            txtACuenta.Text = "0";
            txtPago.Text = "0";
            txtVuelto.Text = "0";
            cboCliente.Focus();
            epControlOk.Clear();
            epUsuario.Clear();
        }
        private Boolean fnListarLote(Int32 pidLote)
        {
            BLOrdenCompra objCliente = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            DataTable dtLote = new DataTable();

            try
            {
                dtLote = objCliente.BLListarLote(pidLote, 1, true, true,Variables.idSucursal,0,0);
                if (dtLote.Rows.Count > 0)
                {
                    txtProducto.Text = dtLote.Rows[0]["cNombreProducto"].ToString();
                    txtStock.Text = dtLote.Rows[0]["Stock"].ToString();
                }
                else
                { Limpiar(); }


                return true;
            }
            catch (Exception ex)
            {
                dtLote = null;
                objUtil.gsLogAplicativo("frmConfigMesa", "fnListarLote", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objCliente = null;
            }

        }

        public static void fnRecuperarLote(Int32 pidLote)
        {
            lidLote = pidLote;
        }

        static Int32 lidLote = 0;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarLote frmBuscar = new frmBuscarLote();
            frmBuscar.fnInicio(1,0,0);
            frmBuscar.ShowDialog();
            txtidLote.Text = Convert.ToString(lidLote);
            bool bResult = false;

            bResult = fnListarLote(lidLote);
            if (!bResult)
            {
                MessageBox.Show("Error al obtener Lote Específico", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private String fnCalularImporte(decimal pncantidad, decimal pnprecio)
        {
            string cImporte = "";

            cImporte = Math.Round(pncantidad * pnprecio, 2).ToString();

            return cImporte;
        }

        private String fnCalularVuelto(decimal pnImporte, decimal pnPago)
        {
            string cVuelto = "";

            cVuelto = Math.Round(pnPago - pnImporte, 2).ToString();

            return cVuelto;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                lblACuenta.Visible = true;
                txtACuenta.Visible = true;
                txtACuenta.Text = "0";
                txtImporte.Text = fnCalularImporte(Convert.ToDecimal(txtCantidad.Text.Trim() == "" ? "0" : txtCantidad.Text.Trim()), Convert.ToDecimal(txtPrecio.Text.Trim() == "" ? "0" : txtPrecio.Text.Trim()));
                txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                txtACuenta.Focus();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                lblACuenta.Visible = false;
                txtACuenta.Visible = false;
                txtImporte.Text = fnCalularImporte(Convert.ToDecimal(txtCantidad.Text.Trim() == "" ? "0" : txtCantidad.Text.Trim()), Convert.ToDecimal(txtPrecio.Text.Trim() == "" ? "0" : txtPrecio.Text.Trim()));
                txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                txtPago.Focus();
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo nfi = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;

            char decSeperator;

            decSeperator = nfi.CurrencyDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar)
            | e.KeyChar == decSeperator))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == decSeperator
                && (sender as TextBox).Text.IndexOf(decSeperator) > -1)
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtImporte.Text = fnCalularImporte(Convert.ToDecimal(txtCantidad.Text.Trim() == "" ? "0" : txtCantidad.Text.Trim()), Convert.ToDecimal(txtPrecio.Text.Trim() == "" ? "0" : txtPrecio.Text.Trim()));
                if (radioButton3.Checked)
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                else
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                txtPrecio.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo nfi = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;

            char decSeperator;

            decSeperator = nfi.CurrencyDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar)
            | e.KeyChar == decSeperator))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == decSeperator
                && (sender as TextBox).Text.IndexOf(decSeperator) > -1)
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtImporte.Text = fnCalularImporte(Convert.ToDecimal(txtCantidad.Text.Trim() == "" ? "0" : txtCantidad.Text.Trim()), Convert.ToDecimal(txtPrecio.Text.Trim() == "" ? "0" : txtPrecio.Text.Trim()));
                if (radioButton3.Checked)
                {
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                    txtACuenta.Focus();
                }
                else
                {
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                    txtPago.Focus();
                }
                e.SuppressKeyPress = true;

            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            txtImporte.Text = fnCalularImporte(Convert.ToDecimal(txtCantidad.Text.Trim() == "" ? "0" : txtCantidad.Text.Trim()), Convert.ToDecimal(txtPrecio.Text.Trim() == "" ? "0" : txtPrecio.Text.Trim()));
            if (radioButton3.Checked)
            {
                txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                txtACuenta.Focus();
            }
            else
            {
                txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                txtPago.Focus();
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            txtImporte.Text = fnCalularImporte(Convert.ToDecimal(txtCantidad.Text.Trim() == "" ? "0" : txtCantidad.Text.Trim()), Convert.ToDecimal(txtPrecio.Text.Trim() == "" ? "0" : txtPrecio.Text.Trim()));
            if (radioButton3.Checked)
                txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
            else
                txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
            txtPrecio.Focus();
        }

        private void txtACuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                txtPago.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void txtACuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo nfi = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;

            char decSeperator;

            decSeperator = nfi.CurrencyDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar)
            | e.KeyChar == decSeperator))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == decSeperator
                && (sender as TextBox).Text.IndexOf(decSeperator) > -1)
            {
                e.Handled = true;
            }
        }

        private void txtACuenta_Leave(object sender, EventArgs e)
        {
            txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
            txtPago.Focus();
        }
        int lnTipoVenta = 0;
        private void txtPago_KeyDown(object sender, KeyEventArgs e)
        {
            decimal lnPago = 0;
            if (e.KeyCode == Keys.Enter)
            {
                lnPago = Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim());
                if (radioButton1.Checked == true)
                {
                    if (lnPago > 0)
                    {
                        txtVuelto.Visible = true;
                        lblSaco.Visible = true;
                        txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                    }
                    else
                    {
                        txtVuelto.Visible = false;
                        lblSaco.Visible = false;
                    }
                }
                else
                {
                    if (lnPago > 0)
                    {
                        txtVuelto.Visible = true;
                        lblSaco.Visible = true;
                        txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                    }
                    else
                    {
                        txtVuelto.Visible = false;
                        lblSaco.Visible = false;
                    }
                }
                
                if (lnTipoVenta == 0)
                    btnGuardar.Focus();
                else
                    btnAgregar.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo nfi = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;

            char decSeperator;

            decSeperator = nfi.CurrencyDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar)
            | e.KeyChar == decSeperator))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == decSeperator
                && (sender as TextBox).Text.IndexOf(decSeperator) > -1)
            {
                e.Handled = true;
            }
        }

        private void fnGuardar()
        {
            String lcResultado = "";
            decimal lnCantidad = 0;
            decimal lnPrecio = 0;
            decimal lnImporte = 0;
            decimal lnPagar = 0;
            decimal lnNroSaco = 0;
            bool bCorrecto = true;

            epControlOk.Clear();
            epUsuario.Clear();

            lnNroSaco = numericUpDown1.Value;
            lnCantidad = txtCantidad.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtCantidad.Text.Trim());
            lnPrecio = txtPrecio.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtPrecio.Text.Trim());
            lnImporte = txtImporte.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtImporte.Text.Trim());
            lnPagar = txtACuenta.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtACuenta.Text.Trim());

            if (cboCliente.SelectedValue == null)
            {
                epControlOk.SetError(cboCliente, "");
                epUsuario.SetError(cboCliente, "Elegir Cliente para la Venta de Mesa");
                cboCliente.Focus();
            }
            else
            {
                epUsuario.SetError(cboCliente, "");
                epControlOk.SetError(cboCliente, "Seleción Correcta de Cliente");
            }

            if (lnNroSaco <= 0)
            {
                epControlOk.SetError(numericUpDown1, "");
                epUsuario.SetError(numericUpDown1, "Ingresar Nro de Sacos");
                numericUpDown1.Focus();
            }
            else
            {
                epUsuario.SetError(numericUpDown1, "");
                epControlOk.SetError(numericUpDown1, "Ingreso Correcto de Nro de Sacos");
            }

            if (lnCantidad <= 0)
            {
                epControlOk.SetError(txtCantidad, "");
                epUsuario.SetError(txtCantidad, "Ingresar Cantidad para esta Venta");
                txtCantidad.Focus();
            }
            else
            {
                epUsuario.SetError(txtCantidad, "");
                epControlOk.SetError(txtCantidad, "Ingreso Correcto de Cantidad");
            }

            if (lnPrecio <= 0)
            {
                epControlOk.SetError(txtPrecio, "");
                epUsuario.SetError(txtPrecio, "Ingresar Precio Venta para esta Mesa");
                txtPrecio.Focus();
            }
            else
            {
                epUsuario.SetError(txtPrecio, "");
                epControlOk.SetError(txtPrecio, "Ingreso Correcto de Precio Venta");
            }
            if (radioButton3.Checked)
            {
                if (lnPagar >= lnImporte)
                {
                    epControlOk.SetError(txtACuenta, "");
                    epUsuario.SetError(txtACuenta, "Si la venta es al Crédito el Monto la cuenta a pagar debe ser menor al Importe");
                    txtACuenta.Focus();
                    bCorrecto = false;
                }
                else
                {
                    bCorrecto = true;
                    epUsuario.SetError(txtACuenta, "");
                    epControlOk.SetError(txtACuenta, "Monto a Pagar es Correcto");
                }
            }

            if (cboCliente.SelectedValue != null && lnNroSaco>0 && lnCantidad > 0 && lnPrecio > 0 && bCorrecto)
            {
                lcResultado = fnGuardarVentaxMayor();
                if (lcResultado != "OK")
                {
                    MessageBox.Show("Error al Grabar la Venta por Mayor. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private String fnGuardarVentaxMayor()
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLVentaMesa blobjVenta = new BLVentaMesa();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            VentaMayor objVenta = new VentaMayor();
            try
            {
                objVenta.idVentaMayor = 0;
                objVenta.idLote = Convert.ToInt32(txtidLote.Text.Trim());
                objVenta.idCliente = Convert.ToInt32(cboCliente.SelectedValue);
                objVenta.idSucursal = Variables.idSucursal;
                objVenta.nCantidad = Convert.ToDecimal(txtCantidad.Text);
                objVenta.nCantidadUM = numericUpDown1.Value;
                objVenta.mPrecioVenta = Convert.ToDecimal(txtPrecio.Text);
                objVenta.mMontoTotal = Convert.ToDecimal(txtImporte.Text);
                objVenta.mMontoPagar = Convert.ToDecimal(txtACuenta.Text);
                objVenta.cTipoPago = radioButton1.Checked == true ? "TIPA0001" : "TIPA0002";
                objVenta.cEstado = radioButton1.Checked == true ? "ESVM0001" : "ESVM0002";
                objVenta.dFechaRegistro = dFechaSis;
                objVenta.idUsuario = Variables.gnCodUser;

                lcValidar = blobjVenta.blGrabarVentaxMayor(objVenta).Trim();
                Limpiar();

            }
            catch (Exception ex)
            {
                lcValidar = "NO";
                objUtil.gsLogAplicativo("frmVentaxMesa", "fnGuardarVentaMesa", ex.Message);
            }

            return lcValidar;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            fnGuardar();
            //lnTipoVenta = 0;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //lnTipoVenta = 1;
        }

        private void txtPago_Leave(object sender, EventArgs e)
        {
            decimal lnPago = 0;
            lnPago = Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim());
                if (radioButton1.Checked == true)
                {
                    if (lnPago > 0)
                    {
                        txtVuelto.Visible = true;
                        lblSaco.Visible = true;
                        txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                    }
                    else
                    {
                        txtVuelto.Visible = false;
                        lblSaco.Visible = false;
                    }
                }
                else
                {
                    if (lnPago > 0)
                    {
                        txtVuelto.Visible = true;
                        lblSaco.Visible = true;
                        txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                    }
                    else
                    {
                        txtVuelto.Visible = false;
                        lblSaco.Visible = false;
                    }
                }
            btnGuardar.Focus();
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCantidad.Focus();
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
