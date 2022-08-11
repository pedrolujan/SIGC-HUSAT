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
    public partial class frmAperturaCaja : Form
    {
        public frmAperturaCaja()
        {
            InitializeComponent();
        }
        public void Inicio()
        {

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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegistrar.Focus();
                e.SuppressKeyPress = true;
            }
        }


        private String fnAperturarCaja(decimal lnMonto)
        { 
            String lcResultado="";
            BLDocumentoVenta obj = new BLDocumentoVenta();
            clsUtil objUtil= new clsUtil();
            try
            {

                lcResultado = obj.blAperturarCaja(Variables.idSucursal, lnMonto, Variables.gnCodUser, FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 3),1);
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Aperturó su caja exitosamente","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                this.Dispose();
                return lcResultado;

            }
            catch(Exception ex)
            {
                lcResultado = "XX";
                objUtil.gsLogAplicativo("frmAperturaCaja", "fnAperturarCaja", ex.Message);
                return lcResultado;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string lcResultado = "";
            decimal lnMonto = 0;
            epUsuario.Clear();
            lnMonto = Convert.ToDecimal(txtMonto.Text.Trim() == "" ? "0" : txtMonto.Text.Trim());
            if (lnMonto>=0)
            {
                if (lnMonto == 0)
                {
                    DialogResult mr = MessageBox.Show("En realidad desea aperturar caja en Cero ?", "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (mr == DialogResult.Yes)
                    {
                        lcResultado = fnAperturarCaja(lnMonto);
                        if (lcResultado != "OK")
                        {
                            MessageBox.Show("Error al Aperturar Caja. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }
                else
                {
                    lcResultado = fnAperturarCaja(lnMonto);
                    if (lcResultado != "OK")
                    {
                        MessageBox.Show("Error al Aperturar Caja. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("El Monto no puede ser Menor a cero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }    

        private void frmAperturaCaja_Load(object sender, EventArgs e)
        {
            if (!(FunGeneral.fnVerificarApertura(Variables.gnCodUser)==1?true:false))
            {
                txtFecha.Text = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 6);
                txtUsuario.Text = Variables.gsCodUser;
                txtMonto.Focus();
            }
            else
            {
                this.Text = "Aperturar Caja - Ya se ha aperturado caja en el día";
                txtFecha.Text = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 6);
                txtUsuario.Text = Variables.gsCodUser;
                txtMonto.Enabled = false;
                btnRegistrar.Enabled = false;
            }
        }

        private void btnRegistrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string lcResultado = "";
                decimal lnMonto = 0;
                lnMonto = Convert.ToDecimal(txtMonto.Text.Trim() == "" ? "0" : txtMonto.Text.Trim());
                epUsuario.Clear();
                if (lnMonto > 0)
                {
                    lcResultado = fnAperturarCaja(lnMonto);
                    if (lcResultado != "OK")
                    {
                        MessageBox.Show("Error al Aperturar Caja. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else { epUsuario.SetError(txtMonto, "Ingresar un monto de Apertura de Caja"); }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
