using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaUtil;
using CapaEntidad;
using CapaNegocio;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Consultas;
using System.Globalization;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmRecepcionarOrdenCompra : Form
    {
        public frmRecepcionarOrdenCompra()
        {
            InitializeComponent();
        }

        private Boolean fnListarAlmacen(Boolean pbEstado)
        {
            BLTraslado objCliente = new BLTraslado();
            clsUtil objUtil = new clsUtil();
            List<Almacen> lstAlmacen = new List<Almacen>();

            try
            {
                lstAlmacen = objCliente.BLListarAlmacen(pbEstado);
                cboBuscarAlmacen.DataSource = null;
                cboBuscarAlmacen.ValueMember = "idAlmacen";
                cboBuscarAlmacen.DisplayMember = "cNomAlmacen";
                cboBuscarAlmacen.DataSource = lstAlmacen;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRecepcionarOrdenCompra", "fnListarAlmacen", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objCliente = null;
                lstAlmacen = null;
            }

        }

        private Boolean fnListarAlmacenOrigen(Boolean pbEstado)
        {
            BLTraslado objCliente = new BLTraslado();
            clsUtil objUtil = new clsUtil();
            List<Almacen> lstAlmacenOrigen = new List<Almacen>();

            try
            {
                lstAlmacenOrigen = objCliente.BLListarAlmacen(pbEstado);
                cboOrigen.DataSource = null;
                cboOrigen.ValueMember = "idAlmacen";
                cboOrigen.DisplayMember = "cNomAlmacen";
                cboOrigen.DataSource = lstAlmacenOrigen;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRecepcionarOrdenCompra", "fnListarAlmacenOrigen", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objCliente = null;
                lstAlmacenOrigen = null;
            }

        }

        private Boolean fnListarAlmacenDestino(Boolean pbEstado)
        {
            BLTraslado objCliente = new BLTraslado();
            clsUtil objUtil = new clsUtil();
            List<Almacen> lstAlmacenDestino = new List<Almacen>();

            try
            {
                lstAlmacenDestino = objCliente.BLListarAlmacen(pbEstado);
                cboDestino.DataSource = null;
                cboDestino.ValueMember = "idAlmacen";
                cboDestino.DisplayMember = "cNomAlmacen";
                cboDestino.DataSource = lstAlmacenDestino;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRecepcionarOrdenCompra", "fnListarAlmacenDestino", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objCliente = null;
                lstAlmacenDestino = null;
            }

        }

        private void frmRecepcionarOrdenCompra_Load(object sender, EventArgs e)
        {
            bool bResult = false;

            bResult = fnListarAlmacenOrigen(true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Almacenes Origenes Activos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = fnListarAlmacenDestino(true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Destinos Activos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = fnListarAlmacen(true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Almacenes para búsqueda", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            fnHabilitarDocumento(true, 1);
        }

        Int16 lnTipoCon = 0;

        private Boolean fnBuscarTraslado(String pcBuscar, Int16 pnTipoCon)
        {
            BLTraslado objDocVenta = new BLTraslado();
            clsUtil objUtil = new clsUtil();
            List<Traslado> lstDocVenta = null;
            ListViewItem lstItem = null;
            try
            {

                lstDocVenta = new List<Traslado>();
                lstDocVenta = objDocVenta.blBuscarTraslado(pcBuscar, pnTipoCon);
                lvProveedor.Items.Clear();

                foreach (Traslado objVenta in lstDocVenta)
                {
                    lstItem = lvProveedor.Items.Add(objVenta.idTraslado.ToString());
                    lstItem.SubItems.Add(objVenta.cAlmacenOrigen);
                    lstItem.SubItems.Add(objVenta.cAlmacenDestino);
                    lstItem.SubItems.Add(objUtil.GetFechaHoraFormato(objVenta.dFechaRegistro,1));
                    lstItem.SubItems.Add(objVenta.bEstado==true? "Activo" : "Inactivo");
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRecepcionarOrdenCompra", "fnBuscarTraslado", ex.Message);
                return false;
            }
            finally
            {
                lstDocVenta = null;
                objDocVenta = null;
                objUtil = null;
            }

        }

        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBuscar.Text == "Nro. Traslado")
            {
                txtBuscar.Visible = true;
                cboBuscarAlmacen.Visible = false;
                dtpFecha.Visible = false;
                txtBuscar.Text = "";
                lvProveedor.Items.Clear();
                txtBuscar.Focus();
                lnTipoCon = 0;
            }
            else if (cboBuscar.Text == "Almacen Origen")
            {
                txtBuscar.Visible = false;
                dtpFecha.Visible = false;
                cboBuscarAlmacen.Visible = true;
                cboBuscarAlmacen.SelectedIndex = 0;
                lvProveedor.Items.Clear();
                cboBuscarAlmacen.Focus();
                lnTipoCon = 1;
            }
            else
            {
                txtBuscar.Visible = false;
                cboBuscarAlmacen.Visible = false;
                dtpFecha.Visible = true;
                lvProveedor.Items.Clear();
                dtpFecha.Focus();
                lnTipoCon = 2;
                dtpFecha_ValueChanged(sender, e);
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Boolean bResul = false;

                bResul = fnBuscarTraslado(txtBuscar.Text.Trim(), lnTipoCon);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Traslado. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

            Boolean bResul = false;

            bResul = fnBuscarTraslado(FunGeneral.GetFechaHoraFormato(dtpFecha.Value, 3), lnTipoCon);
            if (!bResul)
            {
                MessageBox.Show("Error al Buscar Traslado. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void fnDevolverTraslado(int fila , int columna)
        {
            txtNroDoc.Text = dgvMovimiento.Rows[fila].Cells[columna].Value.ToString();
            chkEstado.Checked = Convert.ToBoolean(dgvMovimiento.Rows[fila].Cells[columna].Value);
        }

        private void dgvMovimiento_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvMovimiento.Columns[e.ColumnIndex].Name == "btnBuscar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvMovimiento.Rows[e.RowIndex].Cells["btnBuscar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\Buscar.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvMovimiento.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dgvMovimiento.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }
        }
        static int lidLote = 0;
        public static void fnRecuperarLote(Int32 pidLote)
        {
            lidLote = pidLote;
        }

        private Boolean fnDevolverLote(Int32 pidLote, Int16 pidAlmacen)
        {
            BLOrdenCompra objCliente = new BLOrdenCompra();
            DataTable dtLote = new DataTable();
            clsUtil objUtil = new clsUtil();
            DataGridViewRow row = dgvMovimiento.CurrentRow;
            Boolean lbResul = false;
           
            try
            {
                dtLote = objCliente.BLListarLote(pidLote, 1, true, true, Variables.idSucursal, 0, pidAlmacen);
                if (dtLote.Rows.Count > 0)
                {
            
                    if (dgvMovimiento.CurrentRow != null)
                    {
                        row.Cells[1].Value = pidLote;
                        row.Cells[2].Value = dtLote.Rows[0]["cNombreProducto"].ToString();
                        row.Cells[4].Value = dtLote.Rows[0]["Stock"].ToString();
                        row.Cells[4].Selected = true;
                        row.Cells[5].Value = dtLote.Rows[0]["cNombreUM"].ToString();
                        
                    }
                    else
                    {

                        dgvMovimiento.Rows[dgvMovimiento.NewRowIndex].Cells[1].Value = pidLote;
                        dgvMovimiento.Rows[dgvMovimiento.NewRowIndex].Cells[2].Value = dtLote.Rows[0]["cNombreProducto"].ToString();
                        dgvMovimiento.Rows[dgvMovimiento.NewRowIndex].Cells[4].Value = dtLote.Rows[0]["Stock"].ToString();
                        dgvMovimiento.Rows[dgvMovimiento.NewRowIndex].Cells[4].Selected = true;
                        dgvMovimiento.Rows[dgvMovimiento.NewRowIndex].Cells[5].Value = dtLote.Rows[0]["cNombreUM"].ToString();

                    }
                }
                else
                {
                    tsbGuardar.Enabled = false;
                    MessageBox.Show("Ingrese un codigo de Lote que se encuentre registrado.", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                tsbGuardar.Enabled = true;
                lbResul = true;
            }
            catch (Exception ex)
            {
                tsbGuardar.Enabled = false;
                lbResul = false;
                objUtil.gsLogAplicativo("frmRecepcionarOrdenCompra", "fnDevolverLote", ex.Message);
            }
            finally
            {
                objCliente = null;
                dtLote = null;
                objUtil = null;
            }
            return lbResul;
        }

        private void dgvMovimiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvMovimiento.Columns["btnBuscar"].Index && e.RowIndex >= 0)
            {
                Boolean lbResul = false;
                lidLote = 0;
                frmBuscarLote frmLote = new frmBuscarLote();
                frmLote.fnInicio(2, 0,Convert.ToInt16(cboOrigen.SelectedValue));
                frmLote.ShowDialog();
                if (lidLote > 0)
                {

                    lbResul = fnDevolverLote(lidLote,Convert.ToInt16(cboOrigen.SelectedValue));

                    if (lbResul == false)
                    {
                        MessageBox.Show("Error al Obtener Lote Específico. Comunicar a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }


        private DataTable fnCargarDetalleTraslado()
        {
            DataTable dtDetalle = new DataTable();
            int i = 0, j = 0;
            DataRow drFila;
            clsUtil objUtil = new clsUtil();
            try
            {
                dtDetalle.Columns.Add(new DataColumn("idDetalleTraslado", typeof(Int32)));
                dtDetalle.Columns.Add(new DataColumn("idTraslado", typeof(Int32)));
                dtDetalle.Columns.Add(new DataColumn("idLote", typeof(Int32)));
                dtDetalle.Columns.Add(new DataColumn("Cantidad", typeof(Decimal)));

                for (i = 0; i <= dgvMovimiento.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(dgvMovimiento.Rows[i].Cells[1].Value) > 0 && Convert.ToInt32(dgvMovimiento.Rows[i].Cells[4].Value) > 0)
                    {
                        drFila = dtDetalle.NewRow();
                        for (j = 0; j <= dtDetalle.Columns.Count; j++)
                        {
                            if (j == 1 )
                                drFila[j] = Convert.ToInt32(txtNroDoc.Text.Trim());
                            else if (j == 2)
                                drFila[j] = dgvMovimiento.Rows[i].Cells[j-1].Value == null ? 0 : dgvMovimiento.Rows[i].Cells[j-1].Value;
                            else if (j == 4 )
                                drFila[j - 1] = dgvMovimiento.Rows[i].Cells[j].Value == null ? 0 : dgvMovimiento.Rows[i].Cells[j].Value;
                            else if (j == 0)
                                drFila[j] = dgvMovimiento.Rows[i].Cells[j].Value == null ? 0 : dgvMovimiento.Rows[i].Cells[j].Value;
                        }

                        dtDetalle.Rows.Add(drFila);

                    }

                }

                return dtDetalle;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRecepcionarOrdenCompra", "fnCargarDetalleTraslado", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                dtDetalle = null;
            }
        }

        private void fnLimpiarControles()
        {
            epControlOk.Clear();
            epUsuario.Clear();
            txtNroDoc.Text = "0";
            lvProveedor.Items.Clear();
            cboOrigen.SelectedIndex = -1;
            cboDestino.SelectedIndex = -1;
            cboBuscar.SelectedIndex = 0;
            chkEstado.Checked = true;
            dgvMovimiento.DataSource = null;
        }

        private void fnHabilitarDocumento(Boolean pbHabilitar, Int16 pnTipoLlamda)
        {

            paBuscar.Enabled = !pbHabilitar;
            paTraslado.Enabled = pbHabilitar;
            paDetalle.Enabled = pbHabilitar;
            tsbImprimir.Enabled = pnTipoLlamda == 0 ? pbHabilitar : !pbHabilitar;
            tsbGuardar.Enabled = pbHabilitar;
            lblAnulado.Visible = pnTipoLlamda == 3 ? true : false;

        }

        private String fnGuardarTraslado(out Int32 pidTraslado)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            DataTable dtDetalleTraslado = null;
            BLTraslado blobjVenta = new BLTraslado();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Traslado objVenta = new Traslado();
            try
            {
                objVenta.idTraslado = Convert.ToInt32(txtNroDoc.Text.Trim());
                objVenta.idAlmacenOrigen = Convert.ToInt16(cboOrigen.SelectedValue);
                objVenta.idAlmacenDestino = Convert.ToInt16(cboDestino.SelectedValue);
                objVenta.idSucursal = Variables.idSucursal;
                objVenta.bEstado = chkEstado.Checked;
                objVenta.idUsuarioRegistro = Variables.gnCodUser;
                objVenta.dFechaRegistro = dFechaSis;

                dtDetalleTraslado = new DataTable();
                dtDetalleTraslado = fnCargarDetalleTraslado();

                lcValidar = blobjVenta.BLGrabarTraslado(objVenta, dtDetalleTraslado, out pidTraslado).Trim();
                fnLimpiarControles();
                fnHabilitarDocumento(true, 1);
            }
            catch (Exception ex)
            {
                pidTraslado = 0;
                lcValidar = "NO";
                objUtil.gsLogAplicativo("frmRecepcionarOrdenCompra", "fnGuardarTraslado", ex.Message);
            }

            return lcValidar;

        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            String lcResultado = "";
            int lidTraslado = 0;

            epControlOk.Clear();
            epUsuario.Clear();


            if (cboOrigen.SelectedValue == null)
            {
                epControlOk.SetError(cboOrigen, "");
                epUsuario.SetError(cboOrigen, "Elegir Almacén Origen para el Traslado");
            }
            else
            {
                epUsuario.SetError(cboOrigen, "");
                epControlOk.SetError(cboOrigen, "Seleecione un Almacén Origen para el Traslado");
            }
            if (cboDestino.SelectedValue == null)
            {
                epControlOk.SetError(cboDestino, "");
                epUsuario.SetError(cboDestino, "Elegir Almacén Destino para el Traslado");
            }
            else
            {
                epUsuario.SetError(cboDestino, "");
                epControlOk.SetError(cboDestino, "Seleecione un Almacén Destino para el Traslado");
            }


            if (cboDestino.SelectedValue != null && cboDestino.SelectedValue != null)
            {

                lcResultado = fnGuardarTraslado(out lidTraslado);
                if (lcResultado == "OK")
                {
                    Impresiones.frmImpresion frmImpre = new Impresiones.frmImpresion();
                    frmImpre.fnInicio(2, "Imprimir Traslado entre Almacenes", lidTraslado);
                    MessageBox.Show("Se Grabo Satisfactoriamente el Traslado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Grabar Traslado. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnHabilitarDocumento(true, 1);
            fnHabilitarTraslado(true);
        }

        private Boolean fnLlenarDetalle(int pidTraslado, bool pbEstado)
        {
            BLTraslado objTraslado = new BLTraslado();
            clsUtil objUtil = new clsUtil();
            List<DetalleTraslado> lstDetalle = new List<DetalleTraslado>();
            try
            {
                lstDetalle = objTraslado.BLListarDetalleTraslado(pidTraslado, pbEstado);
                dgvMovimiento.DataSource = null;
                dgvMovimiento.DataSource = lstDetalle;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRecepcionarOrdenCompra", "fnLlenarDetalle", ex.Message);
                return false;
            }
        }


        private void fnHabilitarTraslado(bool pbHabilitar)
        {
            cboOrigen.Enabled = pbHabilitar;
            cboDestino.Enabled = pbHabilitar;
            dgvMovimiento.Enabled = pbHabilitar;
        }

        private void fnSeleccionarTraslado()
        {

            if (lvProveedor.Items.Count > 0)
            {
                bool bResul = false;
                ListView.SelectedListViewItemCollection item = lvProveedor.SelectedItems;
                txtNroDoc.Text = item[0].SubItems[0].Text;
                chkEstado.Checked = item[0].SubItems[4].Text.Trim() == "Activo" ? true : false;
                cboOrigen.Text = item[0].SubItems[1].Text.Trim();
                cboDestino.Text = item[0].SubItems[2].Text.Trim();
                bResul = fnLlenarDetalle(Convert.ToInt32(txtNroDoc.Text), true);
                if (!bResul)
                {
                    splitContainer1.Enabled = false;
                    MessageBox.Show("Ha ocurrido un error al llenar Detalle de Traslado. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                fnHabilitarTraslado(chkEstado.Checked);
                fnHabilitarDocumento(true, Convert.ToInt16(chkEstado.Checked == true ? 1 : 3));
                tsbGuardar.Enabled = chkEstado.Checked;
                tsbImprimir.Enabled = true;
            }

        }

        private void lvProveedor_DoubleClick(object sender, EventArgs e)
        {
            fnSeleccionarTraslado();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            fnHabilitarDocumento(false, 1);
            fnLimpiarControles();
        }

        private void cboBuscarAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBuscarAlmacen.SelectedValue != null)
            {
                Boolean bResul = false;

                bResul = fnBuscarTraslado(cboBuscarAlmacen.SelectedValue.ToString(), lnTipoCon);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Traslado por Codigo de Almacén Origen. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lvProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fnSeleccionarTraslado();
            }
        }

        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            Int32 idTrslado = 0;
            Impresiones.frmImpresion frmImpre = new Impresiones.frmImpresion();

            idTrslado = Convert.ToInt32(txtNroDoc.Text.Trim());
            frmImpre.fnInicio(2, "Imprimir Traslado entre Almacenes", idTrslado);
        }

    }
}
