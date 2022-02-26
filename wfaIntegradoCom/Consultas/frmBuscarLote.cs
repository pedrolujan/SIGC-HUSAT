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
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Mantenedores;

namespace wfaIntegradoCom.Consultas
{
    public partial class frmBuscarLote : Form
    {
        public frmBuscarLote()
        {
            InitializeComponent();
        }

        int lnTipoLlamada = 0;
        Int16 lnTipoSucursal = 0;
        Int16 lnidAlmacen=0;

        public void fnInicio(int pidTipo, Int16 piTipoSucursal, Int16 pidAlmacen)
        {
            lnTipoLlamada = pidTipo;
            lnTipoSucursal = piTipoSucursal;
            lnidAlmacen = pidAlmacen;
        }

        private void LLenarComboGrilla(DataGridViewComboBoxCell combo, int idProducto, decimal pnStock)
        {
            BLProducto objProducto = new BLProducto();
            combo.ValueMember = "idUnidadMedida";
            combo.DisplayMember = "cNombreUM";
            combo.DataSource = objProducto.BLDevolverValorUMB(idProducto,pnStock);
        }

        private Boolean fnBuscarLote(String pcBuscar, Int16 pidSucursal, Int16 pnTipoCon, Int16 piTipoSuc, Int16 pidAlmacen)
        {
            BLOrdenCompra objDocVenta = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            List<DetalleCompra> lstDocVenta = null;
            DataGridViewComboBoxCell dgccell;
            try
            {

                lstDocVenta = new List<DetalleCompra>();
                lstDocVenta = objDocVenta.BLBuscarLote(pcBuscar,pidSucursal, pnTipoCon, piTipoSuc,pidAlmacen);
                dataGridView1.DataSource = null;
                if (lstDocVenta.Count > 0)
                {
                    detalleCompraBindingSource.DataSource = lstDocVenta;
                    dataGridView1.DataSource = detalleCompraBindingSource;
                    detalleCompraBindingSource.ResetBindings(false);

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        dgccell = (DataGridViewComboBoxCell)row.Cells[5];
                        LLenarComboGrilla(dgccell, Convert.ToInt32(row.Cells[1].Value), Convert.ToDecimal(row.Cells[4].Value));
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmDocumentoVenta", "fnBuscarDocVenta", ex.Message);
                return false;
            }
            finally
            {
                lstDocVenta = null;
                objDocVenta = null;
                objUtil = null;
            }

        }

        private void frmBuscarLote_Load(object sender, EventArgs e)
        {
            cboBuscar.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        Int16 lnTipoCon = 0;
        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBuscar.Text == "Nro. Lote")
            {
                txtBuscar.Visible = true;
                dtpFecha.Visible = false;
                txtBuscar.Text = "";
                dataGridView1.DataSource = null;
                txtBuscar.Focus();
                lnTipoCon = 0;
            }
            else if (cboBuscar.Text == "Nombre de Producto")
            {
                txtBuscar.Visible = true;
                dtpFecha.Visible = false;
                txtBuscar.Text = "";
                dataGridView1.DataSource = null;
                txtBuscar.Focus();
                lnTipoCon = 2;
            }
            else
            {
                txtBuscar.Visible = false;
                dtpFecha.Visible = true;
                dataGridView1.DataSource = null;
                dtpFecha.Focus();
                lnTipoCon = 1;
                dtpFecha_ValueChanged(sender, e);
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            String lcFecha = "";
            bool lbResul = false;

            lcFecha = FunGeneral.GetFechaHoraFormato(dtpFecha.Value,5);
            lbResul = fnBuscarLote(lcFecha, Variables.idSucursal, 1, lnTipoSucursal,lnidAlmacen);
            if (!lbResul)
            {
                MessageBox.Show("Error al Buscar Lote. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool lbResul = false;
                epUsuario.Clear();
                if (txtBuscar.Text.Trim() != "")
                {
                    lbResul = fnBuscarLote(txtBuscar.Text.Trim(),Variables.idSucursal, lnTipoCon,lnTipoSucursal,lnidAlmacen);
                    if (!lbResul)
                    {
                        MessageBox.Show("Error al Buscar Lote. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    epUsuario.SetError(txtBuscar,"Ingresar Dato a Buscar");
                }
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lnTipoCon == 0)
            {
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
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int idLote = 0;
                    string cNombreProducto = string.Empty;
                    idLote = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    if (lnTipoLlamada == 0)
                        frmConfigMesa.fnRecuperarLote(idLote);
                    else if (lnTipoLlamada == 1)
                        wfaIntegradoCom.Procesos.frmVentaxMayor.fnRecuperarLote(idLote);
                    else if (lnTipoLlamada == 2)
                        wfaIntegradoCom.Procesos.frmRecepcionarOrdenCompra.fnRecuperarLote(idLote);
                    else if (lnTipoLlamada == 3)
                        wfaIntegradoCom.Procesos.frmDocumentoVenta.fnRecuperarProducto(idLote);
                    else
                    {
                        int idProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                        cNombreProducto = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                        Procesos.frmAjusteInventario.fnRecuperarProducto(idProducto, cNombreProducto);
                    }
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmDocumentoVenta", "dataGridView1_CellDoubleClick", ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int idLote = 0;
                    string cNombreProducto = string.Empty;
                    idLote = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    if (lnTipoLlamada == 0)
                        frmConfigMesa.fnRecuperarLote(idLote);
                    else if (lnTipoLlamada == 1)
                        wfaIntegradoCom.Procesos.frmVentaxMayor.fnRecuperarLote(idLote);
                    else if (lnTipoLlamada == 2)
                        wfaIntegradoCom.Procesos.frmRecepcionarOrdenCompra.fnRecuperarLote(idLote);
                    else if (lnTipoLlamada == 3)
                        wfaIntegradoCom.Procesos.frmDocumentoVenta.fnRecuperarProducto(idLote);
                    else
                    {
                        int idProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                        cNombreProducto = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                        Procesos.frmAjusteInventario.fnRecuperarProducto(idProducto, cNombreProducto);
                    }
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmDocumentoVenta", "dataGridView1_CellDoubleClick", ex.Message);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {

            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1); //Make sure the clicked row/column is valid.
            var datagridview = sender as DataGridView;

            // Check to make sure the cell clicked is the cell containing the combobox 
            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var datagridview = sender as DataGridView;
            datagridview.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
