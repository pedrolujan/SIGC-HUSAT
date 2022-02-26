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
using CapaEntidad.Generic;
using Newtonsoft.Json;
using wfaIntegradoCom.Funciones.Models;

namespace wfaIntegradoCom
{
    public partial class frmRegistrarCobros : Form
    {
        public frmRegistrarCobros()
        {
            InitializeComponent();
        }

        int idCliente = 0;

        public void fnTipoLlamada(int pintIdCliente)
        {
            idCliente = pintIdCliente;
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
                objUtil.gsLogAplicativo("frmRegistrarCobro", "fnListarClientesActivo", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objCliente = null;
                lsCliente = null;
            }

        }

        Int32 lidVenta = 0;
        Decimal lnSaldo = 0;
        int liTipoOpe = 0;

        private Boolean fnListarVentaxCliente(Int32 pidCliente, string pcEstado, string pcEstadoVM)
        {
            BLDocumentoVenta objOrden = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtOrden = new DataTable();

            try
            {
                dtOrden = objOrden.BLListarVentaxCliente(pidCliente, pcEstado,pcEstadoVM);
                dgdListaOrden.DataSource = dtOrden;

                if (dgdListaOrden.Rows.Count <= 0)
                {
                    lidVenta = 0;
                    fnListarPagoCobroVenta(lidVenta);
                    lnSaldo = 0;
                    liTipoOpe = 0;
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

        private Boolean fnListarPagoCobroVenta(Int32 pidDocumento)
        {
            BLDocumentoVenta objOrden = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtOrden = new DataTable();

            try
            {
                dtOrden = objOrden.BLListarPagoCobroVenta(pidDocumento);
                dataGridView1.DataSource = dtOrden;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCobro", "fnListarPagoCobroVenta", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objOrden = null;
                dtOrden = null;
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
                    lnSubTotal = lnSubTotal + Convert.ToDecimal(dgdListaOrden.Rows[i].Cells[3].Value);
                }
                label6.Text = Convert.ToString(Math.Round(lnSubTotal, 2));

                return true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCobro", "fnCalcularTotal", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
            }

        }

        private void frmRegistrarCobros_Load(object sender, EventArgs e)
        {
            bool bResult = false;

            //if (FunGeneral.fnVerificarApertura())
            //{

                bResult = fnListarClientesActivo(true);
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Clientes Activos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                checkBox1_CheckedChanged(sender, e);

            if (idCliente> 0)
            {
                cboCliente.SelectedValue = idCliente;
                cboCliente_SelectedIndexChanged(sender, e);
                textBox1.Focus();
            }
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
                fnListarVentaxCliente(Convert.ToInt32(cboCliente.SelectedValue), "ESDO0002", "ESVM0002");
                if (checkBox1.Checked)
                {
                    lnSaldo = Convert.ToDecimal(label6.Text);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
            lidVenta = 0;
            lnSaldo = 0;
            liTipoOpe = 0;
            //Boolean bFilaSele = false;
            if (dgdListaOrden.RowCount > 0)
            {
                //bFilaSele = dgdListaOrden.CurrentRow.Selected;

                //if (bFilaSele)
                //{
                groupBox1.Enabled = true;
                lidVenta = Convert.ToInt32(dgdListaOrden.CurrentRow.Cells[0].Value);
                lnSaldo = Convert.ToDecimal(dgdListaOrden.CurrentRow.Cells[3].Value);
                liTipoOpe = Convert.ToInt32(dgdListaOrden.CurrentRow.Cells[4].Value);
                fnListarPagoCobroVenta(lidVenta);
                //}
            }
        }

        private void dgdListaOrden_SelectionChanged(object sender, EventArgs e)
        {
            lidVenta = 0;
            lnSaldo = 0;
            //Boolean bFilaSele = false;
            if (dgdListaOrden.RowCount > 0)
            {
                //bFilaSele = dgdListaOrden.CurrentRow.Selected;

                //if (bFilaSele)
                //{
                lidVenta = Convert.ToInt32(dgdListaOrden.CurrentRow.Cells[0].Value);
                lnSaldo = Convert.ToDecimal(dgdListaOrden.CurrentRow.Cells[3].Value);
                liTipoOpe = Convert.ToInt32(dgdListaOrden.CurrentRow.Cells[4].Value);
                fnListarPagoCobroVenta(lidVenta);
                //}
            }
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

        private String fnRegistrarPagoCobro(decimal pnMontoPagar)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLDocumentoVenta blobjVenta = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            DocumentoVenta objVenta = new DocumentoVenta();
            int lidCliente= 0;
            try
            {
                lidCliente = Convert.ToInt32(cboCliente.SelectedValue);
                objVenta.idVenta = checkBox1.Checked == true ? 0 : lidVenta;
                objVenta.idSucursal = Variables.idSucursal;
                objVenta.nMontoPagar = Convert.ToDouble(pnMontoPagar);
                objVenta.dFechaRegistro = dFechaSis;
                objVenta.idUsuario = Variables.gnCodUser;
                objVenta.idCliente = lidCliente;
                objVenta.iTipoOpe = liTipoOpe;
                objVenta.cCliente = cboCliente.Text;
                objVenta.cUsuario = Variables.gsCodUser;
                objVenta.nSubtotal = Convert.ToDouble(Math.Round(Convert.ToDecimal(label6.Text) - pnMontoPagar, 2));
                objVenta.nMontoTotal = Convert.ToDouble(Math.Round(Convert.ToDecimal(label6.Text), 2));

                lcValidar = blobjVenta.BLPagarCobro(objVenta, lnSaldo).Trim();
                if (lcValidar == "OK")
                {
                    fnImprimirCobro(objVenta);
                    fnListarVentaxCliente(lidCliente, "ESDO0002", "ESVM0002");
                    fnListarPagoCobroVenta(lidVenta);
                }
            }
            catch (Exception ex)
            {
                lcValidar = "NO";
                objUtil.gsLogAplicativo("frmRegistrarCobro", "fnRegistrarPagoCobro", ex.Message);
            }

            return lcValidar;
        }

        private void fnImprimirCobro(DocumentoVenta objVenta)
        {
            GenericMasterDetail<DocumentoVenta, DetalleVenta> genericMasterDetail = new GenericMasterDetail<DocumentoVenta, DetalleVenta>
            {
                Header = objVenta,
                Detail = new List<DetalleVenta>(),
                empresa = new Empresa
                {
                    RazonSocial = Variables.gsEmpresa,
                    Ruc = Variables.gsRuc
                },
                sucursal = Variables.sucursal
            };

            GenericDocument<DocumentoVenta, DetalleVenta> document = new GenericDocument<DocumentoVenta, DetalleVenta>
            {
                Document = genericMasterDetail
            };

            string jsonDocument = JsonConvert.SerializeObject(document);
            PrintRequest printRequest = new PrintRequest
            {
                Identity = "",
                OperatorId = "",
                StringifiedDocumentData = jsonDocument,
                NumberOfCopies = 1,
                TargetPrinterName = Variables.gsImpresora,
                TemplateName = "Cobro_Deuda",
                PaperWidth = 80
            };
            FunGeneral.fnImprimirVoucher(printRequest);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lcResultado = "";
            decimal lnMontoPagar = 0;
            epUsuario.SetError(textBox1, "");
            epUsuario.SetError(cboCliente, "");
            
            lnMontoPagar = Math.Round(Convert.ToDecimal(textBox1.Text.Trim() == "" ? "0" : textBox1.Text.Trim()), 2);

            if (cboCliente.SelectedValue != null)
            {

                if (lnMontoPagar > 0)
                {
                    if (lnMontoPagar <= lnSaldo)
                    {
                        if (MessageBox.Show("¿Desea Pagar Cobro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            lcResultado = fnRegistrarPagoCobro(lnMontoPagar);
                            if (lcResultado == "OK")
                            {
                                textBox1.Text = "";
                                MessageBox.Show("Se Grabo Satisfactoriamente el Pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error al Grabar Pago de Cobro. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                epUsuario.SetError(cboCliente, "Elegir un Cliente Válido");
        }
        
        private String fnAnularPagoCobro(int pidTrandiaria, int pidVenta, int pidUsuario, string pcFechaSis, int piTipoOpe)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLDocumentoVenta blobjVenta = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            
            try
            {

                lcValidar = blobjVenta.blAnularPagoCobro(pidTrandiaria, pidVenta, pidUsuario, pcFechaSis, piTipoOpe).Trim();
                fnListarVentaxCliente(Convert.ToInt32(cboCliente.SelectedValue), "ESDO0002", "ESVM0002");
                fnListarPagoCobroVenta(pidVenta);


            }
            catch (Exception ex)
            {
                lcValidar = "NO";
                objUtil.gsLogAplicativo("frmRegistrarCobro", "fnAnularPagoCobro", ex.Message);
            }

            return lcValidar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int liTrandiaria = 0;
            int liTipoOpe=0;
            epUsuario.SetError(cboCliente, "");
            if (cboCliente.SelectedValue != null)
            {
                if (!checkBox1.Checked)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        liTrandiaria = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                        lidVenta = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                        liTipoOpe = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                        if (MessageBox.Show("Desea Anular el pago seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            fnAnularPagoCobro(liTrandiaria, lidVenta, Variables.gnCodUser, FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis,3),liTipoOpe);
                        }
                    }
                }
                else
                {
                    epUsuario.SetError(checkBox1, "Debe de quitar el check de Pago a Cliente");
                }
            }
            else
                epUsuario.SetError(cboCliente, "Elegir un Proveedor Válido");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int liTrandiaria = 0;
            int liTipoOpe = 0;
            if (cboCliente.SelectedValue != null)
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    liTrandiaria = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    lidVenta = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                    liTipoOpe = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                    if (MessageBox.Show("Desea Anular el pago seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        fnAnularPagoCobro(liTrandiaria, lidVenta, Variables.gnCodUser, FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 3), liTipoOpe);
                    }

                }
            }
            else
                epUsuario.SetError(cboCliente, "Elegir un Cliente Válido");
        }
    }
}
