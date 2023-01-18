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
        static Pagos clsPagosGeneral = new Pagos();
        static List<Pagos> lstEntidades = new List<Pagos>();
        public void Inicio(int pnTipo, double pnMontoPagar,String sMoneda)
        {
            lnTipoLLamada = pnTipo;
            lnMontoPagar = pnMontoPagar;
            SImboloMoneda = sMoneda;
            clsPagosGeneral.cantAPagar = pnMontoPagar;
            clsPagosGeneral.SimboloMoneda = sMoneda;
            this.ShowDialog();
        }

       
        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            fnVolver();
        }

        private void txtObsevacion_TextChanged(object sender, EventArgs e)
        {
            var Resp = FunValidaciones.fnValidarTexboxs(txtObsevacion, lblObservaciones, pbOservacion,false, true, false, 0, 0, 5, 1000, "Ingrese descripcionCorrectamente");
            estObservaciones = Resp.Item1;
            lblObservacioneso = Resp.Item2;
        }

        private void lbEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Int32 index = lbEntidades.SelectedIndices[0];
        }

        private void dgvEntidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEntidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEntidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }

        private void dgvEntidades_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void elimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 index= dgvEntidades.CurrentRow.Index;
            Pagos clsTemporal = new Pagos();
            for (int i = 0; i < lstEntidades.Count; i++)
            {
                if (i == index)
                {
                    clsTemporal = lstEntidades[i];
                    break;
                }
            }
            lstEntidades.Remove(clsTemporal);
            fnLlenarListBox();
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void fnRecibirEntidades(Pagos cls ,Int32 tipoCon)
        {
            lstEntidades.Add(new Pagos
            {
                codTipoPago = cls.codTipoPago,
                cDescripTipoPago = cls.cDescripTipoPago,
                idEntidadPago = cls.idEntidadPago,
                cNumeroOperacion = cls.cNumeroOperacion,
                cDescripcionEstadoPP=cls.cDescripcionEstadoPP,
                cantAPagar = clsPagosGeneral.cantAPagar,
                PagaCon = cls.PagaCon,
                vuelto = cls.vuelto,
                cTipoVenta = Convert.ToString(cboTipoVenta.SelectedValue),
                Observaciones = Convert.ToString(txtObsevacion.Text),
                dFechaRegistro = Variables.gdFechaSis,
                dFechaPago = Variables.gdFechaSis,
                idUsario = Variables.gnCodUser,
                cEstadoPP = rdbSi.Checked==true? "ESPP0001" : "ESPP0004",
                idMoneda = clsPagosGeneral.idMoneda
            });

            fnLlenarListBox();
        }

        private void fnLlenarListBox()
        {
            dgvEntidades.Rows.Clear();
            txtImporteRestante.Text= FunGeneral.fnFormatearPrecio(clsPagosGeneral.SimboloMoneda, (clsPagosGeneral.cantAPagar- lstEntidades.Sum(i=>i.PagaCon)), 1);
            Int32 y = 0;
            String entidadpagos = "";
            foreach (Pagos pg in lstEntidades)
            {
                entidadpagos = pg.cDescripcionEstadoPP == pg.cDescripTipoPago ? "":" - "+ pg.cDescripcionEstadoPP;
                dgvEntidades.Rows.Add(pg.cDescripTipoPago + entidadpagos+ " - " + FunGeneral.fnFormatearPrecio(clsPagosGeneral.SimboloMoneda,pg.PagaCon,0));
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (clsPagosGeneral.cantAPagar > lstEntidades.Sum(i => i.PagaCon) || txtTotalAPagar.Text.ToString()==txtImporteRestante.Text.ToString())
            {
                frmEntidadPagos frm = new frmEntidadPagos();
                clsPagosGeneral.PagaCon = (clsPagosGeneral.cantAPagar - lstEntidades.Sum(i => i.PagaCon));
                frm.Inicio(clsPagosGeneral, 0);
                fnLlenarListBox();
            }
            else
            {
                MessageBox.Show("inporte insuficiente para agregar entidades de págo","Aviso!!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void rdbNo_CheckedChanged(object sender, EventArgs e)
        {

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
      
        private void cboTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pbTipoVenta.Image = Properties.Resources.ok;
            estTipoVenta = true;
            lblTipoVentaa = "";
        }

        private void frmTipoPago_Load(object sender, EventArgs e)
        {
            try
            {
                lstEntidades.Clear();
                FunValidaciones.fnColorAceptarCancelar(btnAceptar, btnCancelar);
                txtTotalAPagar.Text = FunGeneral.fnFormatearPrecio(clsPagosGeneral.SimboloMoneda,clsPagosGeneral.cantAPagar,1);
                txtImporteRestante.Text = FunGeneral.fnFormatearPrecio(clsPagosGeneral.SimboloMoneda,clsPagosGeneral.cantAPagar,1);

                fnLlenarCombobox(cboTipoVenta, "TIVTR00" + lnTipoLLamada, 2, false);
                btnAdd.Focus();
                if (lnTipoLLamada == -3 || lnTipoLLamada == 3)
                {
                    btnAceptar.Text = "Guardar Movimiento";
                    btnAceptar.Width = btnAceptar.Width + 15;
                }
                if (lnTipoLLamada == -3)
                {
                    rdbNo.Enabled = false;
                    rdbNo.Visible=false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (rdbSi.Checked==true)
            {
                if (clsPagosGeneral.cantAPagar==lstEntidades.Sum(i => i.PagaCon))
                {
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
                    else if (lnTipoLLamada == -3 || lnTipoLLamada == 3)
                    {
                        frmRegistrarEgresos frm = new frmRegistrarEgresos();
                        frm.fnRecuperarEstadoGenVenta(true);
                        frm.fnRecuperarTipoPago(lstEntidades);
                        this.Close();
                    }
                    else if (lnTipoLLamada == -4)
                    {
                        frmPagosPendientes frm = new frmPagosPendientes();
                        frm.fnRecuperarEstadoGenVenta(true);
                        frm.fnRecuperarTipoPago(lstEntidades);
                        this.Close();
                    }
                    else
                    {
                        //frmDocumentoVenta.fnRecuperarTipoPago(cboTipoPago.SelectedValue.ToString(), Convert.ToDecimal(txtCanPagar.Text), cboTipoPago.Text);
                        this.Close();
                    }
                }else
                {
                    MessageBox.Show("Por favor Ingrese el monto correcto. Agregue entidades de págo ","Aviso!!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }             
                
            }else if (rdbNo.Checked == true)
            {
                DialogResult resp = new DialogResult();
                resp= MessageBox.Show("En realidad deseá guardar el pago como págo pendiente?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (resp==DialogResult.Yes)
                {
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
                    else if (lnTipoLLamada == -3 || lnTipoLLamada == 3)
                    {
                        frmRegistrarEgresos frm = new frmRegistrarEgresos();
                        frm.fnRecuperarEstadoGenVenta(true);
                        frm.fnRecuperarTipoPago(lstEntidades);
                        this.Close();
                    }
                    else if (lnTipoLLamada == -4)
                    {
                        frmPagosPendientes frm = new frmPagosPendientes();
                        frm.fnRecuperarEstadoGenVenta(true);
                        frm.fnRecuperarTipoPago(lstEntidades);
                        this.Close();
                    }
                    else
                    {
                        //frmDocumentoVenta.fnRecuperarTipoPago(cboTipoPago.SelectedValue.ToString(), Convert.ToDecimal(txtCanPagar.Text), cboTipoPago.Text);
                        this.Close();
                    }
                }
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
                txtTotalAPagar.Focus();
            }
        }

        
        private void fnVolver()
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
            else if (lnTipoLLamada == -3 || lnTipoLLamada == 3)
            {
                frmRegistrarEgresos frm = new frmRegistrarEgresos();
                frm.fnRecuperarEstadoGenVenta(false);

            }
            else if (lnTipoLLamada == -4)
            {
                frmPagosPendientes frm = new frmPagosPendientes();
                frm.fnRecuperarEstadoGenVenta(false);

            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            fnVolver();

            this.Dispose();
        }


       
    }
}
