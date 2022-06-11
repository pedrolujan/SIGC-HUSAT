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
using System.Globalization;
using CapaNegocio;
using CapaUtil;
using CapaEntidad;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmTipoPago : Form
    {
        public frmTipoPago()
        {
            InitializeComponent();
        }

        Int32 lnTipoLLamada = 0;
        Double lnMontoPagar = 0;
        String SImboloMoneda = "";
        Boolean estTipoVenta, estEntidadVenta, estTotalAPagar, estPagaCon, estVuelto, estObservaciones,estNroOperacion;
        String lblTipoVentaa, lblEntidadVenta, lblTotalAPagar, lblPagaConn, lblVueltoo, lblObservacioneso, lblNroOperacion;

        public void Inicio(int pnTipo, double pnMontoPagar,String sMoneda)
        {
            lnTipoLLamada = pnTipo;
            lnMontoPagar = pnMontoPagar;
            SImboloMoneda = sMoneda;
            this.ShowDialog();
        }

        private void cboEntidadesPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            String valorTipoPago = Convert.ToString(cboTipoPago.SelectedValue);

            if (valorTipoPago == "TIPA0001" || valorTipoPago== "TIPA0005" || valorTipoPago== "TIPA0006")
            {
               
            }
            else
            {
                var res = FunValidaciones.fnValidarCombobox(cboEntidadesPago, lblEntidadPagos, pbEntidad);
                estEntidadVenta = res.Item1;
                lblEntidadVenta = res.Item2;
            }
        }

        private void txtCanPagar_TextChanged(object sender, EventArgs e)
        {
            var Resp = FunValidaciones.fnValidarTexboxs(txtCanPagar,lblMontoAPagar,pbMontoAPagar,true,false,false,0,1000,5,10,"Regrese a la Venta para Calcular total a pagar");
            estTotalAPagar = Resp.Item1;
            lblTotalAPagar = Resp.Item2;
        }

        private void txtPagaCon_TextChanged(object sender, EventArgs e)
        {
            String valorTipoPago = Convert.ToString(cboTipoPago.SelectedValue);
            if (valorTipoPago== "TIPA0001")
            {
                var Resp = FunValidaciones.fnValidarTexboxs(txtPagaCon, lblPagaCon, pbPagaCon, true, false, false, 0, 1000, 5, 10, "Ingrese monto a pagar");
                estPagaCon = Resp.Item1;
                lblPagaConn = Resp.Item2;
            }
            else
            {
                estPagaCon = true;
                lblPagaConn = "";
            }
            
        }

        private void txtNumeroOperacion_TextChanged(object sender, EventArgs e)
        {
            String valorTipoPago = Convert.ToString(cboTipoPago.SelectedValue);
            if (valorTipoPago == "TIPA0001" || valorTipoPago == "TIPA0005" || valorTipoPago == "TIPA0006")
            {

            }
            else
            {
                var Resp = FunValidaciones.fnValidarTexboxs(txtNumeroOperacion, lblTipoVenta, pbTipoVenta, true, true, true,4, 25, 25, 25, "Ingrese Número de óperacion");
                estNroOperacion = Resp.Item1;
                lblNroOperacion = Resp.Item2;
            }
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            if (lnTipoLLamada == 0)
            {
                Mantenedores.frmRegistrarVenta fmr = new Mantenedores.frmRegistrarVenta();
                fmr.fnCambiarEstadoVenta(false);
            }

            if (lnTipoLLamada == -1)
            {
                frmControlPagoVenta frm1 = new frmControlPagoVenta();
                frm1.fnCambiarEstadoVenta(false);
            }
            else if (lnTipoLLamada == -2)
            {
                frmOtrasVentas fr = new frmOtrasVentas();
                fr.fnRecuperarEstadoGenVenta(false);
                fr.fnCondicionProcesos(0);

            }
        }

        private void txtVuelto_TextChanged(object sender, EventArgs e)
        {
            String valorTipoPago = Convert.ToString(cboTipoPago.SelectedValue);
            if (valorTipoPago == "TIPA0001")
            {
                var Resp = FunValidaciones.fnValidarTexboxs(txtVuelto, lblVuelto, pbVuelto, true, false, false, 0, 1000, 5, 10, "Ingrese a monto a pago");
                estVuelto = Resp.Item1;
                lblVueltoo = Resp.Item2;
            }
            else
            {
                estVuelto = true;
                lblVueltoo = "";

            }

        }

        private void txtObsevacion_TextChanged(object sender, EventArgs e)
        {
            var Resp = FunValidaciones.fnValidarTexboxs(txtObsevacion, lblObservaciones, pbOservacion,false, true, false, 0, 0, 5, 1000, "Ingrese descripcionCorrectamente");
            estObservaciones = Resp.Item1;
            lblObservacioneso = Resp.Item2;
        }

        private void cboTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pbTipoVenta.Image = Properties.Resources.ok;
            estTipoVenta = true;
            lblTipoVentaa = "";
        }

        private void frmTipoPago_Load(object sender, EventArgs e)
        {
            bool bResult = false;
            FunValidaciones.fnColorAceptarCancelar(btnAceptar, btnCancelar);
            bResult = FunGeneral.fnLlenarTablaCod(cboTipoPago, "TIPA");
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar TablaCod - Tipo de Pago", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
           
            fnLlenarCombobox(cboTipoVenta, "TIVTR00"+ lnTipoLLamada,2,false);
            txtCanPagar.Text = string.Format("{0:0.00}", lnMontoPagar);
            lblMoneda.Text = SImboloMoneda;
            lblMoneda1.Text = SImboloMoneda;
            lblMoneda2.Text = SImboloMoneda;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = FunValidaciones.fnValidarCombobox(cboTipoPago, lblTipoPago, pbTipoPago);
            estTipoVenta = res.Item1;
            lblTipoVentaa = res.Item2;
            cboEntidadesPago_SelectedIndexChanged(sender, e);
            txtNumeroOperacion_TextChanged(sender, e);
            txtCanPagar_TextChanged(sender, e);
            txtPagaCon_TextChanged(sender, e);
            txtVuelto_TextChanged(sender, e);

            if (estTipoVenta == true && estEntidadVenta == true && estTotalAPagar == true && estPagaCon == true && estVuelto == true && estNroOperacion == true)
            {
                String TipoPago = Convert.ToString(cboTipoPago.SelectedValue);
                List<Pagos> lstEntidades = new List<Pagos>();
                Double pagaCon = TipoPago == "TIPA0001" ? Convert.ToDouble(txtPagaCon.Text) : Convert.ToDouble(txtCanPagar.Text);
                String estadoPrimerPago = "";
                if (TipoPago == "TIPA0001")
                {
                    if (Convert.ToDouble(txtCanPagar.Text) <= (txtPagaCon.Text == "" ? 0 : Convert.ToDouble(txtPagaCon.Text)))
                    {
                        estadoPrimerPago = "ESPP0001";
                    }
                    else
                    {
                        estadoPrimerPago = "ESPP0002";
                    }
                }
                else
                {
                    estadoPrimerPago = "ESPP0001";
                }

                lstEntidades.Add(new Pagos
                {
                    codTipoPago = Convert.ToString(cboTipoPago.SelectedValue),
                    cDescripTipoPago = Convert.ToString(cboTipoPago.Text),
                    idEntidadPago = Convert.ToInt32(cboEntidadesPago.SelectedValue),
                    cNumeroOperacion = Convert.ToString(txtNumeroOperacion.Text),
                    cantAPagar = Convert.ToDouble(txtCanPagar.Text),
                    PagaCon = pagaCon,
                    vuelto = Convert.ToDouble(txtVuelto.Text == "" ? "0" : txtVuelto.Text),
                    cTipoVenta = Convert.ToString(cboTipoVenta.SelectedValue),
                    Observaciones = Convert.ToString(txtObsevacion.Text),
                    dFechaRegistro = Variables.gdFechaSis,
                    dFechaPago = Variables.gdFechaSis,
                    idUsario = Variables.gnCodUser,
                    cEstadoPP = estadoPrimerPago
                });
                //opcion para venta general
                if (lnTipoLLamada == 0)
                {
                    Consultas.frmVPVenta frm = new Consultas.frmVPVenta();
                    //MessageBox.Show("Todo Correcto");
                    Mantenedores.frmRegistrarVenta.fnRecuperarTipoPago(lstEntidades);
                    frm.fnCambiarEstado(true);
                    this.Close();
                }
                // opcion para pagos mensuales
                else if (lnTipoLLamada == -1)
                {
                    Procesos.frmControlPagoVenta.fnRecuperarTipoPago(lstEntidades);
                    frmControlPagoVenta frm = new frmControlPagoVenta();
                    frm.fnCambiarEstadoVenta(true);
                    this.Close();
                } 
                // opcion para otrasVentas
                else if (lnTipoLLamada == -2)
                {
                    frmOtrasVentas.fnRecuperarTipoPago(lstEntidades);
                    frmOtrasVentas frm2 = new frmOtrasVentas();
                    frm2.fnRecuperarEstadoGenVenta(true);
                    this.Close();

                }
                else
                {
                    frmDocumentoVenta.fnRecuperarTipoPago(cboTipoPago.SelectedValue.ToString(), Convert.ToDecimal(txtCanPagar.Text), cboTipoPago.Text);
                    this.Close();
                }
            }
            
            else
            {
                MessageBox.Show("Porfavor Complete todod los datos"," Aviso !!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

            if (e.KeyChar == (Char)Keys.Enter)
            {
                txtPagaCon.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            NumberFormatInfo nfi = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;

            char decSeperator;

            decSeperator = nfi.CurrencyDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar) | e.KeyChar == decSeperator))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            //if (e.KeyChar == decSeperator
            //    && (sender as TextBox).Text.IndexOf(decSeperator) > -1)
            //{
            //    e.Handled = true;
            //}
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Decimal pagaCon = Convert.ToDecimal(txtPagaCon.Text.Trim() == "" ? "0" : txtPagaCon.Text.Trim());
                if (pagaCon< Convert.ToDecimal(txtCanPagar.Text.Trim()))
                {
                    estPagaCon = false;
                    MessageBox.Show("Porfavor Ingrese Monto a pagar Correctamnete", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pbPagaCon.Image = Properties.Resources.error;
                    lblPagaCon.Text = "Ingrese monto Correcto";
                }
                else
                {
                    lblPagaCon.Text = "";
                    estPagaCon = false;
                    pbPagaCon.Image = Properties.Resources.ok;
                    Decimal CalcularVuelto = Math.Round(pagaCon - Convert.ToDecimal(txtCanPagar.Text.Trim() == "" ? "0" : txtCanPagar.Text.Trim()), 2);
                    txtVuelto.Text = Convert.ToString(CalcularVuelto);
                }
                
            }
        }

        private void fnMostrarCombo(Boolean estado)
        {
            cboEntidadesPago.Enabled = estado;
            cboEntidadesPago.Visible = estado;
            lblEntidad.Enabled = estado;
            lblEntidad.Visible = estado;
            pbEntidad.Visible = estado;
            lblEntidadPagos.Visible = estado;
            lblNOperacion.Visible = estado;
            txtNumeroOperacion.Visible = estado;
            pbTipoVenta.Visible = estado;
            lblTipoVenta.Visible = estado;

            


        }

        private void fnActivarpagaConYVuelto(Boolean estado)
        {
            pbPagaCon.Visible = estado;
            txtPagaCon.Visible = estado;
            txtVuelto.Visible = estado;
            label6.Visible = estado;
            pbVuelto.Visible = estado;
            lblMoneda1.Visible = estado;
            lblMoneda2.Visible = estado;
            lblPagaCon.Visible = estado;
            label4.Visible = estado;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var res = FunValidaciones.fnValidarCombobox(cboTipoPago, lblTipoPago, pbTipoPago);
            estTipoVenta = res.Item1;
            lblTipoVentaa = res.Item2;
            String ValorCombo = cboTipoPago.SelectedValue.ToString().Trim();

            if (ValorCombo== "TIPA0001" || ValorCombo=="0")
            {
                estEntidadVenta = true;
                fnMostrarCombo(false);
                fnActivarpagaConYVuelto(true);
                estNroOperacion = true;
            }
            else
            {
                if (ValorCombo == "TIPA0005" || ValorCombo == "TIPA0006")
                {
                    fnActivarpagaConYVuelto(false);
                    fnMostrarCombo(false);
                    estEntidadVenta = true;
                    estNroOperacion = true;
                }
                else
                {
                    fnLlenarCombobox(cboEntidadesPago, Convert.ToString(cboTipoPago.SelectedValue), 0,false);
                    fnMostrarCombo(true);
                    fnActivarpagaConYVuelto(false);
                    estEntidadVenta = false;
                    estNroOperacion = false;
                }
               
                //txtNumeroOperacion.Text = "000";
            }
            //else
            //{
            //    estEntidadVenta = true;
            //    fnMostrarCombo(false);
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (lnTipoLLamada==0)
            {
                Mantenedores.frmRegistrarVenta fmr = new Mantenedores.frmRegistrarVenta();
                fmr.fnCambiarEstadoVenta(false);
            }
            
            if (lnTipoLLamada == -1)
            {
                frmControlPagoVenta frm1 = new frmControlPagoVenta();
                frm1.fnCambiarEstadoVenta(false);
            }
            else if (lnTipoLLamada == -2)
            {
                frmOtrasVentas fr = new frmOtrasVentas();
                fr.fnRecuperarEstadoGenVenta(false);
                fr.fnCondicionProcesos(0);

            }
            this.Dispose();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public static Boolean fnLlenarCombobox(ComboBox cboCombo, String cCodTab,Int32 lnTipoCon, Boolean estBusq)
        {
            BLTipoPagos objTablaCod = new BLTipoPagos();
            clsUtil objUtil = new clsUtil();
            List<EntidadesPago> lstTablaCod = new List<EntidadesPago>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverEntidadPago(cCodTab,  lnTipoCon,  estBusq);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodEntidad";
                cboCombo.DisplayMember = "nomEntidadPago";
                cboCombo.DataSource = lstTablaCod;

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

       
    }
}
