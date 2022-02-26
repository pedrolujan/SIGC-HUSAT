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
using wfaIntegradoCom.Procesos;
using System.Runtime.InteropServices;
using wfaIntegradoCom.Mantenedores;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmMesa : Form, IForms
    {

        public frmMesa()
        {
            InitializeComponent();
            ControlMover.Init(this.toolStrip3, this.panel4, wfaIntegradoCom.Mantenedores.ControlMover.Direction.Any);
            ControlMover.fnCentrar(panel4, this);
        }

        DataTable dtVenta = null;

        private void fnConstruirEstructura()
        {
            dtVenta = new DataTable();
            dtVenta.Columns.Add("cCodTab", typeof(string));
            dtVenta.Columns.Add("idCliente", typeof(int));
            dtVenta.Columns.Add("cProducto", typeof(string));
            dtVenta.Columns.Add("idSucursal", typeof(int));
            dtVenta.Columns.Add("nCantidad", typeof(decimal));
            dtVenta.Columns.Add("mPrecioVenta", typeof(decimal));
            dtVenta.Columns.Add("mMontoTotal", typeof(decimal));
            dtVenta.Columns.Add("mMontoPagar", typeof(decimal));
            dtVenta.Columns.Add("cTipoPago", typeof(string));
            dtVenta.Columns.Add("cEstado", typeof(string));
            dtVenta.Columns.Add("dFechaRegistro", typeof(DateTime));
            dtVenta.Columns.Add("idUsuario", typeof(int));
        }

        private Boolean fnCalcularTotal()
        {

            int i = 0;
            Decimal lnSubTotal = 0;
            clsUtil objUtil = new clsUtil();
            try
            {

                for (i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    lnSubTotal = lnSubTotal + Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                }
                txtImporte.Text = Convert.ToString(Math.Round(lnSubTotal, 2));

                return true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnCalcularTotal", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
            }

        }

        int liTipoVenta = 0;        
        public void AgregarVenta(VentaMesa objVenta, string Cliente)
        {
            bool bResul = false;
            dtVenta.Rows.Add(objVenta.cCodTab, objVenta.idCliente,objVenta.cProducto, objVenta.idSucursal, objVenta.nCantidad, objVenta.mPrecioVenta, objVenta.mMontoTotal, objVenta.mMontoPagar, objVenta.cTipoPago, objVenta.cEstado, objVenta.dFechaRegistro, objVenta.idUsuario);
            if (dtVenta.Rows.Count > 0)
            {
                panel4.Visible = true;
                tsbCarrito.Visible = true;
                lblCliente.Text = Cliente;
                dataGridView1.DataSource = dtVenta;
                bResul=fnCalcularTotal();
                if (!bResul)
                {
                    MessageBox.Show("Error al Calcular Total de Importe - Confgiuración de Mesas", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    splitContainer1.Enabled = false;
                }
                lblMontoVendido.Text = "S/. " + txtImporte.Text;
                liTipoVenta = 1;
            }
            else
            {
                this.panel4.Visible = false;
                tsbCarrito.Visible = false;
                lblMontoVendido.Text = "";
                lblCliente.Text = "";
                dataGridView1.DataSource = null;
                liTipoVenta = 0;
            }
        }


        private Boolean fnCargarMesa()
        {
            List <ConfigMesa> lsConfigMesa= null;
            BLConfigMesa objMesa= new BLConfigMesa();
            clsUtil objUtil = new clsUtil();
            try
            {

                lsConfigMesa = objMesa.blListarMesa(true,Funciones.Variables.idSucursal);
                if (lsConfigMesa.Count > 0)
                {
                    foreach (ConfigMesa drFila in lsConfigMesa)
                    {
                        ToolStripButton obj = new ToolStripButton();

                        obj.Name = drFila.cCodTab;
                        obj.Text = drFila.cNombreMesa;
                        obj.TextAlign = ContentAlignment.MiddleRight;
                        obj.Enabled = drFila.idLote==0?false:true;
                        obj.Image = wfaIntegradoCom.Properties.Resources.images5EPEE1LT;
                        obj.ImageAlign = ContentAlignment.MiddleLeft;
                        obj.ImageScaling = ToolStripItemImageScaling.None;

                        toolStrip1.Items.Add(obj);
                        
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                lsConfigMesa = null;
                objUtil.gsLogAplicativo("frmMesa", "fnCargarMesa", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                lsConfigMesa = null;
            }

        }

        private void frmMesa_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;
            bResult = fnCargarMesa();

            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Mesas - Confgiuración de Mesas", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            toolStripTextBox1.Focus();
            fnConstruirEstructura();
         
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (toolStripTextBox1.Text.Trim() != "")
                {
                    string lcName = "";
                    lcName =lcName.PadLeft(4 - toolStripTextBox1.Text.Trim().Length,'0')+toolStripTextBox1.Text.Trim();
                    lcName = "MESA" + lcName;
                    fnAbrirVentaxMesa(lcName,liTipoVenta, lblCliente.Text);
                }
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


        private void fnAbrirVentaxMesa(String pcName,int piTipoVenta, string pcCliente)
        {
            frmVentaxMesa frmMesa = new frmVentaxMesa();
            frmMesa.Inicio(pcName,piTipoVenta,pcCliente);
            frmMesa.ShowDialog(this);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            fnAbrirVentaxMesa(e.ClickedItem.Name.Trim(), liTipoVenta, lblCliente.Text);

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            toolStripTextBox1.Focus();
            liTipoVenta = 1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                lblACuenta.Visible = false;
                txtaCuenta.Visible = false;
                txtPago.Focus();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                lblACuenta.Visible = true;
                txtaCuenta.Visible = true;
                txtaCuenta.Focus();
            }
        }

        private String fnCalularVuelto(decimal pnImporte, decimal pnPago)
        {
            string cVuelto = "";

            cVuelto = Math.Round(pnPago - pnImporte, 2).ToString();

            return cVuelto;
        }

        private void txtaCuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtaCuenta.Text.Trim() == "" ? "0" : txtaCuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                txtPago.Focus();
            }
        }

        private void txtPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (radioButton1.Checked == true)
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
                else
                    txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtaCuenta.Text.Trim() == "" ? "0" : txtaCuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));

                btnGuardar.Focus();
            }
        }

        private void txtaCuenta_Leave(object sender, EventArgs e)
        {
            txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtaCuenta.Text.Trim() == "" ? "0" : txtaCuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
        }

        private void txtPago_Leave(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtImporte.Text.Trim() == "" ? "0" : txtImporte.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
            else
                txtVuelto.Text = fnCalularVuelto(Convert.ToDecimal(txtaCuenta.Text.Trim() == "" ? "0" : txtaCuenta.Text.Trim()), Convert.ToDecimal(txtPago.Text.Trim() == "" ? "0" : txtPago.Text.Trim()));
        }

        private String fnGuardarVentaMesaMasiva()
        {
            DateTime dFechaSis = Funciones.Variables.gdFechaSis;
            BLVentaMesa blobjVenta = new BLVentaMesa();
            clsUtil objUtil = new clsUtil();
            DataTable dtVenta = new DataTable();
            String lcValidar = "";
            string cTipoPago = "";
            decimal mMontoTotal = 0;
            decimal mMontoPagar = 0;
            try
            {
                cTipoPago = radioButton1.Checked == true ? "TIPA0001" : "TIPA0002";
                mMontoTotal = Convert.ToDecimal(txtImporte.Text);
                mMontoPagar = Convert.ToDecimal(txtaCuenta.Text);
                dtVenta = (DataTable)dataGridView1.DataSource;

            
                lcValidar = blobjVenta.blGrabarVentaMesaMasiva(dtVenta,cTipoPago,mMontoTotal,mMontoPagar).Trim();
                Limpiar();

            }
            catch (Exception ex)
            {
                lcValidar = "NO";
                objUtil.gsLogAplicativo("frmVentaxMesa", "fnGuardarVentaMesaMasiva", ex.Message);
            }

            return lcValidar;

        }

        private void Limpiar()
        {
            panel4.Visible = false;
            lblCliente.Text = "";
            dataGridView1.DataSource = null;
            lblMontoVendido.Text = "";
            tsbCarrito.Visible = false;
            dtVenta = null;
            fnConstruirEstructura();
            liTipoVenta = 0;
            toolStripTextBox1.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String lcResultado = "";
            decimal lnImporte = 0;
            decimal lnPagar = 0;
            bool bCorrecto = true;

            epControlOk.Clear();
            epUsuario.Clear();

            lnImporte = txtImporte.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtImporte.Text.Trim());
            lnPagar = txtaCuenta.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtaCuenta.Text.Trim());

     
            if (radioButton3.Checked)
            {
                if (lnPagar >= lnImporte)
                {
                    epControlOk.SetError(txtaCuenta, "");
                    epUsuario.SetError(txtaCuenta, "Si la venta es al Crédito el Monto la cuenta a pagar debe ser menor al Importe");
                    txtaCuenta.Focus();
                    bCorrecto = false;
                }
                else
                {
                    bCorrecto = true;
                    epUsuario.SetError(txtaCuenta, "");
                    epControlOk.SetError(txtaCuenta, "Monto a Pagar es Correcto");
                }
            }

            if (bCorrecto)
            {
                lcResultado = fnGuardarVentaMesaMasiva();
                if (lcResultado != "OK")
                {
                    MessageBox.Show("Error al Grabar la Venta Masiva. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int fila = -1;
            bool bResul = false;
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    fila = dataGridView1.CurrentRow.Index;
                    if (fila != -1)
                    {
                        //dtVenta.Rows[fila].Delete();
                        dataGridView1.Rows.RemoveAt(fila);
                        bResul = fnCalcularTotal();
                        if (!bResul)
                        {
                            MessageBox.Show("Error al Calcular Total de Importe - Confgiuración de Mesas", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            splitContainer1.Enabled = false;
                        }
                        lblMontoVendido.Text = "S/. " + txtImporte.Text;
                    }
                    
                }
                else MessageBox.Show("Elegir una Fila a Eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
