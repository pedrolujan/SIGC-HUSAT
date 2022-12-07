using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Microsoft.AspNet.SignalR.Client.Hubs;
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
    public partial class frmEntidadPagos : Form
    {
        public frmEntidadPagos()
        {
            InitializeComponent();
        }
        Boolean estNroOperacion = false, estEntidadVenta = false, estTipoPago=false,estCantPago=false;

        Int32 lnTipoLlamda=0;
        Pagos clsPagos = new Pagos();
        public void Inicio(Pagos cls,Int32 tipoLlamada)
        {
            lnTipoLlamda=tipoLlamada;   
            clsPagos=cls;   
            this.ShowDialog();
        }
        private void frmEntidadPagos_Load(object sender, EventArgs e)
        {
            try
            {
                txtCanPagar.ReadOnly = false;
               Boolean bResult = false;
                bResult = FunGeneral.fnLlenarTablaCod(cboTipoPago, "TIPA");
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar TablaCod - Tipo de Pago", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                if (lnTipoLlamda==0)
                {
                    lblImporte.Text = "Importe: " + FunGeneral.fnFormatearPrecio(clsPagos.SimboloMoneda,clsPagos.PagaCon,1);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cboEntidadesPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            var res = FunValidaciones.fnValidarCombobox(cboEntidadesPago, lblEntidadPagos, pbEntidad);
            estEntidadVenta = res.Item1;
        }

        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            var res = FunValidaciones.fnValidarCombobox(cboTipoPago, lblTipoPago, pbTipoPago);
            estTipoPago = res.Item1;

            fnLlenarCombobox(cboEntidadesPago, Convert.ToString(cboTipoPago.SelectedValue), 0, false);

            String ValorCombo = cboTipoPago.SelectedValue.ToString().Trim();
            if (ValorCombo == "TIPA0001" || ValorCombo == "0" || ValorCombo == "TIPA0005" || ValorCombo == "TIPA0006")
            {
                estEntidadVenta = true;
                fnMostrarCombo(false);
                estNroOperacion = true;
                cboEntidadesPago.SelectedIndex = ValorCombo != "0" ? 1 : 0;
            }
            else
            {
                fnMostrarCombo(true);
                estEntidadVenta = false;
                estNroOperacion = false;;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            txtNumeroOperacion_TextChanged( sender,  e);
            if (estTipoPago && estEntidadVenta && estCantPago && estNroOperacion)
            {
                Pagos clsEnviar = new Pagos();
                clsEnviar.codTipoPago = Convert.ToString(cboTipoPago.SelectedValue);
                clsEnviar.cDescripTipoPago = Convert.ToString(cboTipoPago.Text);
                clsEnviar.idEntidadPago = Convert.ToInt32(cboEntidadesPago.SelectedValue);
                clsEnviar.PagaCon = txtCanPagar.Text == "" ? 0 : FunGeneral.fnLimpiarDescuentos(txtCanPagar.Text);
                clsEnviar.cNumeroOperacion = Convert.ToString(txtNumeroOperacion.Text);
                clsEnviar.cDescripcionEstadoPP = cboEntidadesPago.Text.ToString();
                frmTipoPago frm = new frmTipoPago();
                frm.fnRecibirEntidades(clsEnviar, lnTipoLlamda);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Por favor Complete correctamente todo los datos","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void txtCanPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                fnValidarpagaCon();
            }
        }

        private void fnValidarpagaCon()
        {
            Double PrecioADescontar = FunGeneral.fnLimpiarDescuentos(txtCanPagar.Text.ToString());
            if (PrecioADescontar <= clsPagos.PagaCon)
            {
                txtCanPagar.Text = FunGeneral.fnFormatearPrecio(clsPagos.SimboloMoneda, PrecioADescontar, 0);
                lblCanpagar.Text = "";
                pbMontoAPagar.Image = Properties.Resources.ok;
                estCantPago = true;
                if (txtCanPagar.Text.ToString()=="")
                {
                    lblCanpagar.Text = "Ingrese Monto correcto";
                    pbMontoAPagar.Image = Properties.Resources.error;
                    estCantPago = false;
                }
            }
            else
            {
                lblCanpagar.Text = "Ingrese Monto correcto";
                pbMontoAPagar.Image = Properties.Resources.error;
                estCantPago = false;
            }
        }

        private void txtNumeroOperacion_TextChanged(object sender, EventArgs e)
        {
            if (estNroOperacion==false)
            {
                var res = FunValidaciones.fnValidarTexboxs(txtNumeroOperacion, lblOperacion, pbOperacion, true, true, true, 3, 15, 15, 15, "Ingresar numero operacion ");
                estNroOperacion = res.Item1;
            }
             
        }

        private void txtCanPagar_Leave(object sender, EventArgs e)
        {
            Double PrecioADescontar = FunGeneral.fnLimpiarDescuentos(txtCanPagar.Text.ToString());
            txtCanPagar.Text = FunGeneral.fnFormatearPrecio(clsPagos.SimboloMoneda, PrecioADescontar, 0);
            fnValidarpagaCon();
        }

        private void fnMostrarCombo(Boolean estado)
        {
            cboEntidadesPago.Enabled = estado;
            cboEntidadesPago.Visible = estado;
            lblEntidad.Enabled = estado;
            lblEntidad.Visible = estado;
            pbEntidad.Visible = estado;
            lblEntidadPagos.Visible = estado;

            if (cboTipoPago.SelectedValue.ToString() == "TIPA0006" && estado == false)
            {
                lblNOperacion.Visible = !estado;
                txtNumeroOperacion.Visible = !estado;
                pbOperacion.Visible = !estado;
                lblOperacion.Visible = !estado;

            }
            else
            {
                lblNOperacion.Visible = estado;
                txtNumeroOperacion.Visible = estado;
                txtNumeroOperacion.Text = "";
                pbOperacion.Visible = estado;
                lblOperacion.Visible = estado;

            }





        }
        public static Boolean fnLlenarCombobox(ComboBox cboCombo, String cCodTab, Int32 lnTipoCon, Boolean estBusq)
        {
            BLTipoPagos objTablaCod = new BLTipoPagos();
            clsUtil objUtil = new clsUtil();
            List<EntidadesPago> lstTablaCod = new List<EntidadesPago>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverEntidadPago(cCodTab, lnTipoCon, estBusq);
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
