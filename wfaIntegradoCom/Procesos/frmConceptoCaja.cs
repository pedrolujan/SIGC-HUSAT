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
using System.Globalization;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmConceptoCaja : Form
    {
        public frmConceptoCaja()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private String fnRegistrarMovimiento(decimal lnMonto, int idOperacion)
        {
            String lcResultado = "";
            BLDocumentoVenta obj = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            try
            {

                lcResultado = obj.blAperturarCaja(Variables.idSucursal, lnMonto, Variables.gnCodUser, FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 3), idOperacion);
                if (lcResultado == "OK")
                    this.Dispose();
                return lcResultado;

            }
            catch (Exception ex)
            {
                lcResultado = "XX";
                objUtil.gsLogAplicativo("frmConceptoCaja", "fnRegistrarMovimiento", ex.Message);
                return lcResultado;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            string lcResultado = "";
            decimal lnMonto = 0;
            epUsuario.Clear();

            if (comboBox1.SelectedValue == null)
                epUsuario.SetError(comboBox1, "Elegir un Tipo de Concepto");

            lnMonto = Convert.ToDecimal(textBox2.Text.Trim() == "" ? "0" : textBox2.Text.Trim());
            if (lnMonto <= 0)
                epUsuario.SetError(textBox2, "Ingresar Monto de Movimiento de Caja");

            if (lnMonto > 0 && comboBox1.SelectedValue != null)
            {

                lcResultado = fnRegistrarMovimiento(lnMonto, Convert.ToInt32(comboBox1.SelectedValue));
                if (lcResultado != "OK")
                    MessageBox.Show("Error al Registrar Movimiento de Caja. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
                
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fnListarConcepto("TICO0002", "1");
        }

        private Boolean fnListarConcepto(string pcTipoConcepto, string pcTipoOpe)
        {
            BLDocumentoVenta objDocumento = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtLista = new DataTable();

            try
            {
                dtLista = objDocumento.BLListarConcepto(pcTipoConcepto, pcTipoOpe);
                comboBox1.DataSource = null;
                comboBox1.ValueMember = "idOperacion";
                comboBox1.DisplayMember = "cNombreOperacion";
                comboBox1.DataSource = dtLista;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmConceptoCaja", "fnListarConcepto", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objDocumento = null;
                dtLista = null;
            }

        }

        private void frmConceptoCaja_Load(object sender, EventArgs e)
        {
            txtFecha.Text = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 6);
            radioButton1_CheckedChanged(sender, e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                btnAtras.Focus();
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                textBox2.Focus();
            }
        
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                textBox2.Focus();
            }
      
        }

        private void radioButton1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void radioButton2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                fnListarConcepto("TICO0002", "2");
            }
        }
    }
}
