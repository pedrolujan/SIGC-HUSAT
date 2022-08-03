using CapaEntidad;
using Siticone.UI.WinForms;
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

namespace wfaIntegradoCom.Procesos
{
    public partial class frmRegistrarEgresos : Form
    {
        public frmRegistrarEgresos()
        {
            InitializeComponent();
        }
        static List<Moneda> lstMoneda = new List<Moneda>();
        static Moneda clsMoneda = new Moneda();
        Boolean estArea, estUsuario, estMoneda, estImporte, estDescripcion;

        private void frmRegistrarEgresos_Load(object sender, EventArgs e)
        {
            try
            {
                FunGeneral.fnLlenarTablaCodTipoCon(cboArea, "PETR",false);
                lstMoneda=FunGeneral.fnLLenarMoneda(cboMoneda,0,false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            estArea=FunValidaciones.fnValidarCombobox(cboArea,lblArea,pbArea).Item1;

           FunGeneral.fnLlenarUsuarioPorCargo(cboUsuario, cboArea.SelectedValue.ToString(), false);
            
        }

        private void txtPlacaVehiculo_TextChanged(object sender, EventArgs e)
        {
            estImporte= fnValidarTexbox(txtImporte, lblImporte, pbImporte);


        }
        private Boolean fnValidarTexbox(SiticoneTextBox txt,Label lbl,PictureBox pb)
        {
            String str= txt.Text.ToString();
            Boolean estado = false;
            if (str == "" || str=="0" || Convert.ToDouble(str)+1==1)
            {
                lbl.Text = "Ingrese Correctamente el importe";
                pb.Image = Properties.Resources.error;
                txt.BorderColor = Variables.ColorError;
                estado = false;

            }
            else 
            {
                lbl.Text = "";
                pb.Image = Properties.Resources.ok;
                txt.BorderColor = Variables.ColorSuccess;
                estado = true;
            }
            return estado;
        }

        private void txtPlacaVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo nfi = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;

            char decSeperator;

            decSeperator = nfi.CurrencyDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar) | e.KeyChar == decSeperator))
            {
                e.Handled = true;
            }
        }

        private void txtPlacaVehiculo_Leave(object sender, EventArgs e)
        {
            txtImporte.Text = FunGeneral.fnFormatearPrecio("", txtImporte.Text.ToString() == "" ? 0 : Convert.ToDouble(txtImporte.Text.ToString()), -1);

        }

        private void btnGuardarEgreso_Click(object sender, EventArgs e)
        {
            frmTipoPago frmtp = new frmTipoPago();
            estArea = FunValidaciones.fnValidarCombobox(cboArea, lblArea, pbArea).Item1;
            cboUsuario_SelectedIndexChanged(sender, e);
            estMoneda = FunValidaciones.fnValidarCombobox(cboMoneda, lblMoneda, pbMoneda).Item1;
            txtPlacaVehiculo_TextChanged( sender,  e);
            siticoneTextBox1_TextChanged( sender,  e);
            if (estArea && estUsuario && estMoneda && estImporte && estDescripcion)
            {
                frmtp.Inicio(-3, Convert.ToDouble(txtImporte.Text.ToString()), clsMoneda.cSimbolo);
            }
            else
            {
                MessageBox.Show("Complente Correctamente los campos","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
           estMoneda= FunValidaciones.fnValidarCombobox(cboMoneda, lblMoneda, pbMoneda).Item1;
            clsMoneda = lstMoneda.Find(i => i.idMoneda == Convert.ToInt32(cboMoneda.SelectedValue));
        }

        private void cboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            estUsuario= FunValidaciones.fnValidarCombobox(cboUsuario, lblUsuario, pbUsuario).Item1;
        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {
            estDescripcion=FunValidaciones.fnValidarTexboxs(txtDescripcion,lblDescripcion , pbDescripcion,true,true,true,15,1000,1000,1000,"Por favor describa correctamente la operación").Item1;

        }
    }
}
