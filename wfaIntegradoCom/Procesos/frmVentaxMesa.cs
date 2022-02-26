using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using wfaIntegradoCom.Funciones;


namespace wfaIntegradoCom.Procesos
{
    public partial class frmVentaxMesa : Form
    {
        public frmVentaxMesa()
        {
            InitializeComponent();
                       
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
        string lcCodMesa = "";
        int lnTipoVenta = 0;
        string lcCliente = "";
        public void Inicio(string pcCodMesa, int piTipoVenta, string pcCliente)
        {
            lcCodMesa = pcCodMesa;
            lnTipoVenta = piTipoVenta;
            lcCliente = pcCliente;
        }
        ConfigMesa[] arrParametro2 = new ConfigMesa[1];
        private String fnListarLotexMesa(String pcCodMesa)
        {
            
            BLConfigMesa objMesa = new BLConfigMesa();
            clsUtil objUtil = new clsUtil();

            try
            {
                
                arrParametro2 = objMesa.blListarMesaConfigurada(pcCodMesa, Variables.idSucursal).ToArray();

                if (arrParametro2.GetLength(0) > 0)
                {
                    this.Text = Convert.ToString(pcCodMesa + " - " + arrParametro2[0].cProducto +" - Stock: " + arrParametro2[0].Stock.ToString() );
                    return "OK";
                }
                else
                {
                    return "NO";
                }


                
            }
            catch (Exception ex)
            {
                arrParametro2 = null;
                objUtil.gsLogAplicativo("frmConfigMesa", "fnListarLotexMesa", ex.Message);
                return "XX";
            }
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
                objUtil.gsLogAplicativo("frmVentaxMesa", "fnListarClientesActivo", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objCliente = null;
                lsCliente = null;
            }

        }

        private void frmVentaxMesa_Load(object sender, EventArgs e)
        {
            bool bResult = false;
            string cResul = "";        

                cResul = fnListarLotexMesa(lcCodMesa);
                if (cResul == "NO")
                {
                    MessageBox.Show("No tiene una mesa de Nro " + lcCodMesa + " configurada", "Elegir otra Mesa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (cResul == "XX")
                {
                    MessageBox.Show("Error al cargar la mesa configurada por lote", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                bResult = fnListarClientesActivo(true);
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Clientes Activos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                btnPublico_Click(sender, e);
                if (lnTipoVenta == 1)
                {
                    cboCliente.Text = lcCliente;
                    cboCliente.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnImprimir.Enabled = false;
                }
            
        }

        private String  fnCalularImporte(decimal pncantidad, decimal pnprecio)
        {
            string cImporte = "";

            cImporte= Math.Round(pncantidad * pnprecio,2).ToString();

            return cImporte;
        }

        private String fnCalularVuelto(decimal pnImporte, decimal pnPago)
        {
            string cVuelto = "";

            cVuelto = Math.Round(pnPago - pnImporte, 2).ToString();

            return cVuelto;
        }

        private void btnPublico_Click(object sender, EventArgs e)
        {
            if (arrParametro2.GetLength(0) > 0)
            {
                txtPrecio.Text = Convert.ToString(Math.Round(arrParametro2[0].mPrecioPublico,2));
                txtImporte.Text = fnCalularImporte(Convert.ToDecimal(txtCantidad.Text.Trim() == "" ? "0" : txtCantidad.Text.Trim()), Convert.ToDecimal(txtPrecio.Text.Trim() == "" ? "0" : txtPrecio.Text.Trim()));
                if(radioButton3.Checked)
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                else
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                txtCantidad.Focus();
            }
        }

        private void btnEspecial_Click(object sender, EventArgs e)
        {
            if (arrParametro2.GetLength(0) > 0)
            {
                txtPrecio.Text = Convert.ToString(Math.Round(arrParametro2[0].mPrecioEspecial,2));
                txtImporte.Text = fnCalularImporte(Convert.ToDecimal(txtCantidad.Text.Trim() == "" ? "0" : txtCantidad.Text.Trim()), Convert.ToDecimal(txtPrecio.Text.Trim() == "" ? "0" : txtPrecio.Text.Trim()));
                if (radioButton3.Checked)
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                else
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                txtCantidad.Focus();
            }
        }

        private void btnMayor_Click(object sender, EventArgs e)
        {
            if (arrParametro2.GetLength(0) > 0)
            {
                txtPrecio.Text = Convert.ToString(Math.Round(arrParametro2[0].mPrecioxMayor,2));
                txtImporte.Text = fnCalularImporte(Convert.ToDecimal(txtCantidad.Text.Trim() == "" ? "0" : txtCantidad.Text.Trim()), Convert.ToDecimal(txtPrecio.Text.Trim() == "" ? "0" : txtPrecio.Text.Trim()));
                if (radioButton3.Checked)
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                else
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                txtCantidad.Focus();
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
                        label5.Visible = true;
                        txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                    }
                    else
                    {
                        txtVuelto.Visible = false;
                        label5.Visible = false;
                    }
                }
                else
                {
                    if (lnPago > 0)
                    {
                        txtVuelto.Visible = true;
                        label5.Visible = true;
                        txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                    }
                    else
                    {
                        txtVuelto.Visible = false;
                        label5.Visible = false;
                    }
                }
                
                if (lnTipoVenta == 0)
                    btnGuardar.Focus();
                else
                    btnAgregar.Focus();
                e.SuppressKeyPress = true;

            }
          
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Limpiar()
        {
            epUsuario.Clear();
            epControlOk.Clear();
            cboCliente.SelectedIndex = 0;
            radioButton1.Checked=true;
            txtCantidad.Text = "0";
            txtPrecio.Text = Convert.ToString(arrParametro2[0].mPrecioPublico);
            txtImporte.Text = "0";
            txtPago.Text = "0";
            txtVuelto.Text = "0";
            txtCantidad.Focus();
        }

        private String fnGuardarVentaMesa()
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLVentaMesa blobjVenta = new BLVentaMesa();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            VentaMesa objVenta = new VentaMesa();
            try
            {
                objVenta.cCodTab = lcCodMesa;
                objVenta.idCliente = Convert.ToInt32(cboCliente.SelectedValue);
                objVenta.idSucursal = Variables.idSucursal;
                objVenta.nCantidad = Convert.ToDecimal(txtCantidad.Text);
                objVenta.mPrecioVenta = Convert.ToDecimal(txtPrecio.Text);
                objVenta.mMontoTotal = Convert.ToDecimal(txtImporte.Text);
                objVenta.mMontoPagar = Convert.ToDecimal(txtACuenta.Text);
                objVenta.cTipoPago = radioButton1.Checked == true ? "TIPA0001" : "TIPA0002";
                objVenta.cEstado = radioButton1.Checked == true ? "ESVM0001" :"ESVM0002";
                objVenta.dFechaRegistro = dFechaSis;
                objVenta.idUsuario = Variables.gnCodUser;

                lcValidar = blobjVenta.blGrabarVentaMesa(objVenta).Trim();
                Limpiar();

            }
            catch (Exception ex)
            {
                lcValidar = "NO";
                objUtil.gsLogAplicativo("frmVentaxMesa", "fnGuardarVentaMesa", ex.Message);
            }

            return lcValidar;

        }

        private void fnGuardar()
        {
            String lcResultado = "";
            decimal lnCantidad = 0;
            decimal lnPrecio = 0;
            decimal lnImporte = 0;
            decimal lnPagar = 0;
            bool bCorrecto = true;

            epControlOk.Clear();
            epUsuario.Clear();

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

            if (cboCliente.SelectedValue != null && lnCantidad > 0 && lnPrecio > 0 && bCorrecto)
            {
                lcResultado = fnGuardarVentaMesa();
                if (lcResultado != "OK")
                {
                    MessageBox.Show("Error al Grabar la Venta de la Mesa. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            fnGuardar();
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

        private void txtACuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                txtPago.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private VentaMesa AgregarFilaVenta(){

            DateTime dFechaSis = Variables.gdFechaSis;
            VentaMesa objVenta = new VentaMesa();

            objVenta.cCodTab = lcCodMesa;
            objVenta.idCliente = Convert.ToInt32(cboCliente.SelectedValue);
            objVenta.cProducto = arrParametro2.GetLength(0)<=0?"":arrParametro2[0].cProducto;
            objVenta.idSucursal = Variables.idSucursal;
            objVenta.nCantidad = Convert.ToDecimal(txtCantidad.Text);
            objVenta.mPrecioVenta = Convert.ToDecimal(txtPrecio.Text);
            objVenta.mMontoTotal = Convert.ToDecimal(txtImporte.Text);
            objVenta.mMontoPagar = Convert.ToDecimal(txtACuenta.Text);
            objVenta.cTipoPago = radioButton1.Checked == true ? "TIPA0001" : "TIPA0002";
            objVenta.cEstado = radioButton1.Checked == true ? "ESVM0001" : "ESVM0002";
            objVenta.dFechaRegistro = dFechaSis;
            objVenta.idUsuario = Variables.gnCodUser;

            return objVenta;
        }

        private void fnAgregarVenta()
        {
            VentaMesa objVenta = null;

            decimal lnCantidad = 0;
            decimal lnPrecio = 0;
            decimal lnImporte = 0;
            decimal lnPagar = 0;
            bool bCorrecto = true;

            epControlOk.Clear();
            epUsuario.Clear();

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

            if (cboCliente.SelectedValue != null && lnCantidad > 0 && lnPrecio > 0 && bCorrecto)
            {

                IForms formInterface = this.Owner as IForms;

                if (formInterface != null)
                {
                    objVenta = AgregarFilaVenta();
                    formInterface.AgregarVenta(objVenta, cboCliente.Text.Trim());
                    this.Dispose();
                }

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            fnAgregarVenta();
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

        private void txtACuenta_Leave(object sender, EventArgs e)
        {
            txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
            txtPago.Focus();
        }

        private void txtPago_Leave(object sender, EventArgs e)
        {
            decimal lnPago = 0;
            lnPago = Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim());
            if (radioButton1.Checked == true)
            {
                if (lnPago > 0)
                {
                    label5.Visible = true;
                    txtVuelto.Visible = true;
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                }
                else
                {
                    label5.Visible = true;
                    txtVuelto.Visible = true;
                }
            }
            else
            {
                if (lnPago > 0)
                {
                    label5.Visible = true;
                    txtVuelto.Visible = true;
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtACuenta.Text.Trim() == "" ? "0" : txtACuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                }
                else
                {
                    label5.Visible = true;
                    txtVuelto.Visible = true;
                }
                
            }
                
            btnGuardar.Focus();
        }


    }
}
