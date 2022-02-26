using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;
using CapaUtil;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Consultas;
using System.Globalization;


namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmConfigMesa : Form
    {
        public frmConfigMesa()
        {
            InitializeComponent();
        }

        static Int32 lidLote = 0;

        private Boolean fnListarLote(Int32 pidLote)
        {
            BLOrdenCompra objCliente = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            DataTable dtLote = new DataTable();
           
            try
            {
                dtLote = objCliente.BLListarLote(pidLote,1,true,true, Variables.idSucursal,1,0);
                if (dtLote.Rows.Count > 0)
                {
                    txtProveedor.Text = dtLote.Rows[0]["cNomProveedor"].ToString();
                    txtProducto.Text = dtLote.Rows[0]["cNombreProducto"].ToString();
                    txtPrecioCompra.Text = dtLote.Rows[0]["mPrecioCompra"].ToString();
                    txtCantidadCompra.Text = dtLote.Rows[0]["Compra"].ToString();
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
                return  false;
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

        private void frmConfigMesa_Load(object sender, EventArgs e)
        {
            bool bResult = false;
            bResult = FunGeneral.fnLlenarTablaCod(cboMesa, "MESA");
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Mesa - Configurador de Mesas", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

        }

        private Boolean fnListarLotexMesa(String pcCodMesa)
        {
            ConfigMesa[] arrParametro2= new ConfigMesa[1];
            BLConfigMesa objMesa = new BLConfigMesa();
            clsUtil objUtil = new clsUtil();

            try
            {
                Limpiar();
                arrParametro2 = objMesa.blListarMesaConfigurada(pcCodMesa,Variables.idSucursal).ToArray();

                if (arrParametro2 != null)
                {
                    txtCodigo.Text = Convert.ToString(arrParametro2[0].idConfigMesa);
                    txtidLote.Text = Convert.ToString(arrParametro2[0].idLote);
                    txtProveedor.Text = arrParametro2[0].cNomProveedor;
                    txtProducto.Text = arrParametro2[0].cProducto;
                    txtPrecioPublico.Text = arrParametro2[0].mPrecioPublico.ToString();
                    txtPrecioCompra.Text = arrParametro2[0].mPrecioCompra.ToString();
                    txtPrecioEspecial.Text = arrParametro2[0].mPrecioEspecial.ToString();
                    txtPrecioMayor.Text = arrParametro2[0].mPrecioxMayor.ToString();
                    checkBox1.Checked = arrParametro2[0].bEstado;
                    txtCantidadCompra.Text = arrParametro2[0].Compra.ToString();
                    txtStock.Text = arrParametro2[0].Stock.ToString();
                }

                return true;
            }
            catch (Exception ex)
            {
                arrParametro2 = null;
                objUtil.gsLogAplicativo("frmConfigMesa", "fnListarLotexMesa", ex.Message);
                return false;
            }
        }

        private void Limpiar()
        {
            txtidLote.Text = "";
            txtCodigo.Text = "0";
            txtProveedor.Text = "";
            txtProducto.Text = "";
            txtCantidadCompra.Text = "";
            txtStock.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioPublico.Text = "";
            txtPrecioEspecial.Text = "";
            txtPrecioMayor.Text = "";
            checkBox1.Checked = true;
            cboMesa.Focus();
            epControlOk.Clear();
            epUsuario.Clear();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cboMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboMesa.SelectedValue!=null)
            {
                fnListarLotexMesa(cboMesa.SelectedValue.ToString());
                txtidLote.Focus();
            }
        }

        private void txtidLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                bool bResult = false;

                bResult = fnListarLote(Convert.ToInt32(txtidLote.Text));
                if (!bResult)
                {
                    MessageBox.Show("Error al obtener Lote Específico", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                checkBox1.Focus();
            }
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                txtPrecioPublico.Focus();
            }
        }

        private void txtPrecioPublico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                txtPrecioEspecial.Focus();
            }
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

        private void txtPrecioEspecial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                txtPrecioMayor.Focus();
            }
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

        private void txtPrecioMayor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                saveToolStripButton.Select();
            }
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

        private String fnGuardarConfigMesa()
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLConfigMesa blobjVenta = new BLConfigMesa();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            ConfigMesa objVenta = new ConfigMesa();
            try
            {
                objVenta.idConfigMesa = Convert.ToInt32(txtCodigo.Text.Trim());
                objVenta.cCodTab = Convert.ToString(cboMesa.SelectedValue);
                objVenta.idLote = Convert.ToInt32(txtidLote.Text);
                objVenta.idSucursal = Variables.idSucursal;
                objVenta.mPrecioPublico = Convert.ToDecimal(txtPrecioPublico.Text);
                objVenta.mPrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                objVenta.mPrecioEspecial = Convert.ToDecimal(txtPrecioEspecial.Text);
                objVenta.mPrecioxMayor = Convert.ToDecimal(txtPrecioMayor.Text);
                objVenta.bEstado = checkBox1.Checked;
                objVenta.dFechaRegiastro = dFechaSis;
                objVenta.idUsuario = Variables.gnCodUser;
              
                lcValidar = blobjVenta.blGrabarConfigMesa(objVenta).Trim();
                Limpiar();
                //fnHabilitarDocumento(true, 1);
            }
            catch (Exception ex)
            {
                lcValidar = "NO";
                objUtil.gsLogAplicativo("frmConfigMesa", "fnGuardarConfigMesa", ex.Message);
            }

            return lcValidar;

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            String lcResultado = "";

            epControlOk.Clear();
            epUsuario.Clear();

            if (txtidLote.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtidLote, "");
                epUsuario.SetError(txtidLote, "Ingresar Nro de Lote");
            }
            else
            {
                epUsuario.SetError(txtidLote, "");
                epControlOk.SetError(txtidLote, "Ingreso Correcto de Numero de Lote");
            }
            if (cboMesa.SelectedValue == null)
            {
                epControlOk.SetError(cboMesa, "");
                epUsuario.SetError(cboMesa, "Elegir Mesa para la Confgiuración de Mesa");
            }
            else
            {
                epUsuario.SetError(cboMesa, "");
                epControlOk.SetError(cboMesa, "Seleción Correcta de Mesa");
            }

            if (txtPrecioPublico.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtPrecioPublico, "");
                epUsuario.SetError(txtPrecioPublico, "Ingresar Precio Público para esta Mesa");
            }
            else
            {
                epUsuario.SetError(txtPrecioPublico, "");
                epControlOk.SetError(txtPrecioPublico, "Ingreso Correcto de Precio Publico");
            }

            if (txtPrecioEspecial.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtPrecioEspecial, "");
                epUsuario.SetError(txtPrecioEspecial, "Ingresar Precio Especial para esta Mesa");
            }
            else
            {
                epUsuario.SetError(txtPrecioEspecial, "");
                epControlOk.SetError(txtPrecioEspecial, "Ingreso Correcto de Precio Especial");
            }

            if (txtPrecioMayor.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtPrecioMayor, "");
                epUsuario.SetError(txtPrecioMayor, "Ingresar Precio por Mayor para esta Mesa");
            }
            else
            {
                epUsuario.SetError(txtPrecioMayor, "");
                epControlOk.SetError(txtPrecioMayor, "Ingreso Correcto de Precio por Mayor");
            }

            if (txtidLote.Text.Trim() != "" && cboMesa.SelectedValue != null && txtPrecioPublico.Text.Trim() != "" && txtPrecioEspecial.Text.Trim() != "" && txtPrecioMayor.Text.Trim() != "")
            {

                lcResultado = fnGuardarConfigMesa();
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente la Configuración de la Mesa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Grabar la Configuración de la Mesa. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarLote frmBuscar = new frmBuscarLote();
            frmBuscar.fnInicio(0, 1,0);
            frmBuscar.ShowDialog();
            txtidLote.Text = Convert.ToString(lidLote);
            bool bResult = false;

            bResult = fnListarLote(lidLote);
            if (!bResult)
            {
                MessageBox.Show("Error al obtener Lote Específico", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


       
    }
}
