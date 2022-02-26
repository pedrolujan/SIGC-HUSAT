using CapaEntidad;
using CapaEntidad.Generic;
using CapaNegocio;
using CapaUtil;
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
    public partial class frmAjusteInventario : Form
    {
        public frmAjusteInventario()
        {
            InitializeComponent();
        }

        static int lidProducto = 0;
        static string lcNombreProducto = string.Empty;
        BLInventario objInventario = null;
        List<DetalleInventario> lstInventario = null;
        clsUtil objUtil = null;

        public static void fnRecuperarProducto(Int32 pidProducto, string pcNombreProducto)
        {
            lidProducto = pidProducto;
            lcNombreProducto = pcNombreProducto;
        }


        private void fnListarSucursal(ComboBox cboDinamico)
        {
            BLSucursal objSucursal = new BLSucursal();
            objUtil = new clsUtil();
            DataTable dtSucursal = new DataTable();
            try
            {
                dtSucursal = objSucursal.BLListarSucursal();
                cboDinamico.ValueMember = "idSucursal";
                cboDinamico.DisplayMember = "cNombreSucursal";
                cboDinamico.DataSource = dtSucursal;
                if (dtSucursal.Rows.Count > 0)
                {
                    cboDinamico.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmAjusteInventario", "fnListarSucursal", ex.Message);
                MessageBox.Show("Error al cargar Sucursales", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private Boolean fnListarAlmacen(Boolean pbEstado, int idSucursal, ComboBox cboDinamico)
        {
            BLTraslado objAlmacen = new BLTraslado();
            clsUtil objUtil = new clsUtil();
            List<Almacen> lstAlmacen = new List<Almacen>();

            try
            {
                lstAlmacen = objAlmacen.BLListarAlmacen(pbEstado, idSucursal);
                cboDinamico.DataSource = null;
                cboDinamico.ValueMember = "idAlmacen";
                cboDinamico.DisplayMember = "cNomAlmacen";
                cboDinamico.DataSource = lstAlmacen;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmAjusteInventario", "fnListarAlmacen", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objAlmacen = null;
                lstAlmacen = null;
            }
        }

        private Boolean fnListarInventario(int idAlmacen, int idProducto=0)
        {
            objInventario = new BLInventario();
            objUtil = new clsUtil();
            lstInventario = new List<DetalleInventario>();

            try
            {
                lstInventario = objInventario.blDevolverInventarioxProducto(idAlmacen, idProducto);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lstInventario;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmAjusteInventario", "fnListarInventario", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objInventario = null;
                lstInventario = null;
            }

        }

        private Boolean fnListarInventarioxLote(int idAlmacen, int idLote = 0)
        {
            objInventario = new BLInventario();
            objUtil = new clsUtil();
            lstInventario = new List<DetalleInventario>();

            try
            {
                lstInventario = objInventario.blDevolverInventarioxLote(idAlmacen, idLote);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lstInventario;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmAjusteInventario", "fnListarInventarioxLote", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objInventario = null;
                lstInventario = null;
            }

        }

        private void frmAjusteInventario_Load(object sender, EventArgs e)
        {
            fnListarSucursal(cboSucursal);
        }

        private void cboSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSucursal.SelectedIndex != -1)
                fnListarAlmacen(true, Convert.ToInt32(cboSucursal.SelectedValue), cboAlmacen);
            else
                MessageBox.Show("No se ha cargado correctamente la Sucursal", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cboAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAlmacen.SelectedIndex != -1)
                fnListarInventario( Convert.ToInt32(cboAlmacen.SelectedValue));
            else
                MessageBox.Show("No se ha cargado correctamente los Inventarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lidProducto = 0;
            bool lbResul = false;
            Consultas.frmBuscarLote frmBuscar = new Consultas.frmBuscarLote();
            frmBuscar.fnInicio(4, 0, 0);
            frmBuscar.ShowDialog();
            if (lidProducto > 0)
            {
                txtIdProducto.Text = lidProducto.ToString();
                txtNombreProducto.Text = lcNombreProducto;
                lbResul = fnListarInventario(Convert.ToInt32(cboAlmacen.SelectedValue), lidProducto);
                if (lbResul == false)
                {
                    MessageBox.Show("Error al Obtener Inventario Especifico. Comunicar a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void Limpiar()
        {
            dataGridView1.DataSource = null;
            txtNroLote.Text = string.Empty;
            txtIdProducto.Text = string.Empty;
            txtNombreProducto.Text = string.Empty;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                Limpiar();
            }
            else
            {
                Limpiar();
                fnListarSucursal(cboSucursal2);
            }
        }

        private void cboSucursal2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnListarAlmacen(true,Convert.ToInt32(cboSucursal2.SelectedValue), cboAlmacen2);
        }

        private void cboAlmacen2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnListarInventarioxLote(Convert.ToInt32(cboAlmacen2.SelectedValue));
        }

        private void txtNroLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idLote = Convert.ToInt32(txtNroLote.Text);
                fnListarInventarioxLote(Convert.ToInt32(cboAlmacen2.SelectedValue), idLote);
            }
        }

        private void txtNroLote_KeyPress(object sender, KeyPressEventArgs e)
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

        private List<DetalleInventario> fnRecorrerGrilla()
        {
            List<DetalleInventario> detalleInventarios = new List<DetalleInventario>();
            decimal intConteo = 0;
            decimal intStock = 0;
            bool blnCerrarInventario = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                intConteo = Convert.ToDecimal(row.Cells[4].Value);
                intStock = Convert.ToDecimal(row.Cells[5].Value);
                blnCerrarInventario = Convert.ToBoolean(((DataGridViewCheckBoxCell)(row.Cells[6])).EditedFormattedValue);
                if (intConteo != intStock || !blnCerrarInventario)
                {
                    detalleInventarios.Add(
                    new DetalleInventario
                    {
                        idDetalleInventario = Convert.ToInt32(row.Cells[0].Value),
                        idInventario = Convert.ToInt32(row.Cells[0].Value),
                        idLote = Convert.ToInt32(row.Cells[1].Value),
                        idProducto = Convert.ToInt32(row.Cells[2].Value),
                        Cantidad = intConteo,
                        Stock = intStock,
                        bEstado = blnCerrarInventario,
                    }
                    );
                }
            }
            return detalleInventarios;
        }

        private void fnGuardarAjusteInventario(int pidSucursal, int pIdAlmacen, int pidInventario)
        {
            bool blnResultado = false;
            objUtil = new clsUtil();
            BLInventario objInventario = new BLInventario();
            try
            {
                GenericMasterDetail<Inventario, DetalleInventario> genericMasterDetail = new GenericMasterDetail<Inventario, DetalleInventario>
                {
                    Header = new Inventario
                    {
                        idInventario = pidInventario,
                        idSucursal = pidSucursal,
                        idAlmacen = pIdAlmacen,
                        idUsuario = Variables.gnCodUser,
                        dFechaRegistro = Variables.gdFechaSis,
                        cComentario = txtComentario.Text
                    },
                    Detail = fnRecorrerGrilla()

                };

                if (genericMasterDetail.Detail.Count > 0)
                {
                    if (MessageBox.Show("¿Desea Guardar Ajuste de Inventario a Producto(s) Seleccionado(s)?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        blnResultado = objInventario.daGuardarInventario(genericMasterDetail);

                        if (blnResultado)
                        {
                            Limpiar();
                            MessageBox.Show("Guardado correctamente el Ajuste de Inventario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No ha realizado el ajuste de algun producto o Lote", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch(Exception ex)
            {
                objUtil.gsLogAplicativo("frmAjusteInventario", "fnGuardarAjusteInventario", ex.Message);
                MessageBox.Show("Error no controlado. Comunicar a Departamento de Sistemas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            int idInventario = 0;
            int idAlmacen = 0;
            int idSucursal = 0;
            if (tabControl1.SelectedIndex == 0)
            {
                idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);
                idSucursal = Convert.ToInt32(cboSucursal.SelectedValue);
            }
            else
            {
                idAlmacen = Convert.ToInt32(cboAlmacen2.SelectedValue);
                idSucursal = Convert.ToInt32(cboSucursal2.SelectedValue);
            }
            fnGuardarAjusteInventario(idSucursal,idAlmacen, idInventario);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            if (dataGridView1.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
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
    }
}
