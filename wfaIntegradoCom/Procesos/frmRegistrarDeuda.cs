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
    public partial class frmRegistrarDeuda : Form
    {
        public frmRegistrarDeuda()
        {
            InitializeComponent();
        }

        Int32 liOrden = 0;
        Decimal lnSaldo = 0;

        private Boolean fnListarOrdenxProveedor(Int32 pidProveedor, Int16 pidEstado)
        {
            BLOrdenCompra objOrden = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            DataTable dtOrden = new DataTable();

            try
            {
                dtOrden = objOrden.BLListarOrdenxProveedor(pidProveedor, pidEstado);
                dgdListaOrden.DataSource = dtOrden;

                if (dgdListaOrden.Rows.Count <= 0)
                {
                    liOrden = 0;
                    fnListarPagoDeudaOC(liOrden);
                    lnSaldo = 0;
                }
                
                fnCalcularTotal();

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarDeuda", "fnListarOrdenxProveedor", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objOrden = null;
                dtOrden = null;
            }
        }

        private Boolean fnListarPagoDeudaOC(Int32 pidDocumento)
        {
            BLOrdenCompra objOrden = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            DataTable dtOrden = new DataTable();

            try
            {
                dtOrden = objOrden.BLListarPagoDeudaOC(pidDocumento);
                dataGridView1.DataSource = dtOrden;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarDeuda", "fnListarPagoDeudaOC", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objOrden = null;
                dtOrden = null;
            }
        }

        private Boolean fnListarProveedorActivo(Boolean pbEstado)
        {
            BLProveedor objCliente = new BLProveedor();
            clsUtil objUtil = new clsUtil();
            List<Proveedor> lsProveedor = new List<Proveedor>();

            try
            {
                lsProveedor = objCliente.blListarProveedores(pbEstado,false,"");
                cboCliente.DataSource = null;
                cboCliente.ValueMember = "idProveedor";
                cboCliente.DisplayMember = "cNomProveedor";
                cboCliente.DataSource = lsProveedor;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarDeuda", "fnListarProveedorActivo", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objCliente = null;
                lsProveedor = null;
            }

        }

        private Boolean fnCalcularTotal()
        {

            int i = 0;
            Decimal lnSubTotal = 0;
            clsUtil objUtil = new clsUtil();
            try
            {

                for (i = 0; i <= dgdListaOrden.Rows.Count - 1; i++)
                {
                    lnSubTotal = lnSubTotal + Convert.ToDecimal(dgdListaOrden.Rows[i].Cells[5].Value);
                }
                label6.Text = Convert.ToString(Math.Round(lnSubTotal, 2));

                return true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarDeuda", "fnCalcularTotal", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
            }

        }

        private void frmRegistrarDeuda_Load(object sender, EventArgs e)
        {
            bool bResult = false;
            //if (FunGeneral.fnVerificarApertura())
            //{
                bResult = fnListarProveedorActivo(true);
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Proveedores Activos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                checkBox1_CheckedChanged_1(sender, e);
            //}
            //else
            //{
            //    MessageBox.Show("Debe Aperturar Caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();
            //}
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedValue != null)
            {
                epUsuario.Clear();
                fnListarOrdenxProveedor(Convert.ToInt32(cboCliente.SelectedValue), 2);
                if (checkBox1.Checked)
                {
                    lnSaldo = Convert.ToDecimal(label6.Text);
                }
            }
        }

        private String fnRegistrarPagoDeuda(decimal pnMontoPagar)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLOrdenCompra blobjVenta = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            OrdenCompra objVenta = new OrdenCompra();
            int lidProvedor = 0;
            try
            {
                lidProvedor=Convert.ToInt32(cboCliente.SelectedValue);
                objVenta.idOrden = checkBox1.Checked==true?0:liOrden;
                objVenta.idSucursal = Variables.idSucursal;
                objVenta.nMontoPagar = pnMontoPagar;
                objVenta.dFechaRegistro = dFechaSis;
                objVenta.idUsuario = Variables.gnCodUser;
                objVenta.idProveedor= lidProvedor;
                
                lcValidar = blobjVenta.BLPagarDeuda(objVenta, lnSaldo).Trim();
                fnListarPagoDeudaOC(liOrden);
                fnListarOrdenxProveedor(lidProvedor, 2);
                //fnLimpiarControles();
                //fnHabilitarDocumento(true, 1);
            }
            catch (Exception ex)
            {
                lcValidar = "NO";
                objUtil.gsLogAplicativo("frmRegistrarDeuda", "fnRegistrarPagoDeuda", ex.Message);
            }

            return lcValidar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lcResultado = "";
            decimal lnMontoPagar=0;
            epUsuario.SetError(textBox1, "");
            epUsuario.SetError(cboCliente, "");

            lnMontoPagar = Math.Round(Convert.ToDecimal(textBox1.Text.Trim() == "" ? "0" : textBox1.Text.Trim()), 2);

            if (cboCliente.SelectedValue != null)
            {

                if (lnMontoPagar > 0)
                {
                    if (lnMontoPagar <= lnSaldo)
                    {
                        if (MessageBox.Show("¿Desea Pagar Deuda?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            lcResultado = fnRegistrarPagoDeuda(lnMontoPagar);
                            if (lcResultado == "OK")
                            {
                                textBox1.Text = "";
                                MessageBox.Show("Se Grabo Satisfactoriamente el Pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error al Grabar Pago de Deuda. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            }

                        }
                    }
                    else
                    {
                        epUsuario.SetError(textBox1, "Monto a Pagar no puede ser mayor al saldo");
                    }
                }
                else
                {
                    epUsuario.SetError(textBox1, "Monto a pagar debe ser mayor a Cero");
                }
            }
            else
                epUsuario.SetError(cboCliente, "Elegir un Proveedor Válido");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                dateTimePicker1.Focus();
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

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                button1.Focus();
            }
        }

        private String fnAnularPagoDeuda(int pidTrandiaria, int pidOrden, int pidUsuario, string pcFechaSis)
        {
            epUsuario.Clear();
            DateTime dFechaSis = Variables.gdFechaSis;
            BLOrdenCompra blobjVenta = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            try
            {

                lcValidar = blobjVenta.blAnularPagoDeuda(pidTrandiaria, pidOrden, pidUsuario, pcFechaSis).Trim();
                fnListarPagoDeudaOC(pidOrden);
                fnListarOrdenxProveedor(Convert.ToInt32(cboCliente.SelectedValue), 2);

            }
            catch (Exception ex)
            {
                lcValidar = "NO";
                objUtil.gsLogAplicativo("frmRegistrarDeuda", "fnAnularPagoDeuda", ex.Message);
            }

            return lcValidar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int liTrandiaria = 0;
            epUsuario.SetError(cboCliente, "");
            if (cboCliente.SelectedValue != null)
            {
                if (!checkBox1.Checked)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        liTrandiaria = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                        liOrden = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                        if (MessageBox.Show("Desea Anular el pago seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            fnAnularPagoDeuda(liTrandiaria, liOrden, Variables.gnCodUser, FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis,3));
                        }
                    }
                }
                else
                {
                    epUsuario.SetError(checkBox1, "Debe de quitar el check de Pago a Proveedor");
                }
            }
            else
                epUsuario.SetError(cboCliente, "Elegir un Proveedor Válido");
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int liTrandiaria = 0;
            if (cboCliente.SelectedValue != null)
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    liTrandiaria = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    liOrden = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                    
                    if (MessageBox.Show("Desea Anular el pago seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        fnAnularPagoDeuda(liTrandiaria, liOrden, Variables.gnCodUser, FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 3));
                    }

                }
            }
            else
                epUsuario.SetError(cboCliente, "Elegir un Proveedor Válido");
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox1.Enabled = true;
                lnSaldo = Convert.ToDecimal(label6.Text.Trim() == "" ? "0" : label6.Text.Trim());
            }
            else
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox1.Enabled = false;
                lnSaldo = 0;
            }
        }

        private void dgdListaOrden_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            liOrden = 0;
            lnSaldo = 0;
            if (dgdListaOrden.RowCount > 0)
            {
                groupBox1.Enabled = true;
                liOrden = Convert.ToInt32(dgdListaOrden.CurrentRow.Cells[0].Value);
                lnSaldo = Convert.ToDecimal(dgdListaOrden.CurrentRow.Cells[3].Value);
                fnListarPagoDeudaOC(liOrden);
            }
        }

        private void dgdListaOrden_SelectionChanged(object sender, EventArgs e)
        {
            liOrden = 0;
            lnSaldo = 0;
            if (dgdListaOrden.RowCount > 0)
            {
                liOrden = Convert.ToInt32(dgdListaOrden.CurrentRow.Cells[0].Value);
                lnSaldo = Convert.ToDecimal(dgdListaOrden.CurrentRow.Cells[3].Value);
                fnListarPagoDeudaOC(liOrden);
            }
        }

    }
}
