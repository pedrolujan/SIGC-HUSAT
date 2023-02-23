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
using wfaIntegradoCom.Mantenedores;
using System.Globalization;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmOrdenCompra : Form
    {

        public frmOrdenCompra()
        {
            InitializeComponent();
        }

        Int16 lnTipoLlamada = 0;
        Int16 lnTipoCon = 0;
        static String lcProveedor = "";
        static String lcDireccion = "";
        static String lcNroDoc = "";
        static Int32 lidProducto = 0;
        static String lcNomProd = "";
        Decimal lnIGV = 0;
        Int16 lnTipoBuscar = 1;
        static String cTipoPago = "";
        static Decimal nMontoPagar = 0;

        public static void fnRecuperarProducto(Int32 pidProducto, String pcNomProd)
        {
            lidProducto = pidProducto;
            lcNomProd = pcNomProd;
        }

        public static void fnRecuperarTipoPago(string pcTipoPago, decimal pnMontoPagar)
        {
            cTipoPago = pcTipoPago;
            nMontoPagar = pnMontoPagar;
        }

        private Boolean fnListarProveedorEspecifico()
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                BLProveedor objProvee = new BLProveedor();
                Proveedor[] lstProvee = new Proveedor[1];

                lstProvee = objProvee.blListarProveedor(Convert.ToInt32(cboCliente.SelectedValue)).ToArray();
                if (lstProvee.GetLength(0) > 0)
                {
                    txtDireccion.Text = Convert.ToString(lstProvee[0].cDireccion);
                    txtDoc.Text = Convert.ToString(lstProvee[0].cDocumento);
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnListarProveedorEspecifico", ex.Message);
                return false;
            }
        }

        private void fnHabilitarDocumento(Boolean pbHabilitar, Int16 pnTipoLlamda)
        {

                gbDocumento.Enabled = pbHabilitar;
                gbCliente.Enabled = pbHabilitar;
                dgvDetalleVenta.Enabled = pbHabilitar;
                gbBuscar.Visible = pnTipoLlamda==3 ? pbHabilitar : !pbHabilitar;
                tsbImprimir.Enabled = pnTipoLlamda == 0 ? pbHabilitar : !pbHabilitar;
                tsbGuardar.Enabled = pbHabilitar;
                lblAnulado.Visible = pnTipoLlamda==3?true:false;
            
        }

        private Boolean fnListarProveedorActivo(Boolean pbEstado, String codTipoOrden)
        {
            BLProveedor objCliente = new BLProveedor();
            clsUtil objUtil = new clsUtil();
            List<Proveedor> lsProveedor = new List<Proveedor>();

            try
            {
                lsProveedor = objCliente.blListarProveedores(pbEstado,true,codTipoOrden);
                cboCliente.DataSource = null;
                cboCliente.ValueMember = "idProveedor";
                cboCliente.DisplayMember = "cNomProveedor";
                cboCliente.DataSource = lsProveedor;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnListarProveedorActivo", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objCliente = null;
                lsProveedor = null;
            }

        }

        public static void fnRecuperarProveedor(String pcCliente, String pcDireccion, String pcNroDoc)
        {
            lcProveedor = pcCliente;
            lcDireccion = pcDireccion;
            lcNroDoc = pcNroDoc;
        }

        private Boolean fnObtenerProveedor()
        {
            bool bResul = false;
            clsUtil objUtil = new clsUtil();
            try
            {
                bResul = fnListarProveedorActivo(true,"");
                if (bResul == false)
                    return false;
                cboCliente.Text = lcProveedor;
                txtDireccion.Text = lcDireccion;
                txtDoc.Text = lcNroDoc;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnObtenerProveedor", ex.Message);
                return false;
            }
        }
        private void frmOrdenCompra_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;
            Cargo[] arrParametro2 = new Cargo[1];
            clsUtil objUtil = new clsUtil();

            try
            {

                if (lnTipoLlamada == 0)
                {
                    //arrParametro2 = FunGeneral.fnDevolverParametro("PIGV0001");

                    //if (arrParametro2 == null)
                    //{
                    //    MessageBox.Show("Error al Cargar IGV(Impuesto General a las Ventas)", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    this.Close();
                    //}
                    //lnIGV = Convert.ToDecimal(arrParametro2[0].cValor);
                    //lblIGV.Text = "IGV(" + Convert.ToString(lnIGV) + " %)";


                    bResult = FunGeneral.fnLlenarTablaCod(cboEstado, "ESDO");
                    if (!bResult)
                    {
                        MessageBox.Show("Error al Cargar TablaCod - Estado del Documento de Venta", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }

                    bResult = fnListarProveedorActivo(true,"");
                    if (!bResult)
                    {
                        MessageBox.Show("Error al Cargar Proveedores Activos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    dtFecha.Value = Variables.gdFechaSis;
                    dateTimePicker2.Value = Variables.gdFechaSis;
                    fnHabilitarDocumento(true, 1);
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "frmOrdenCompra_Load", ex.Message);
            }
            finally
            {
                objUtil = null;
                arrParametro2 = null;
            }

        }

        private void fnVisibilida(Boolean pbVisibilidad, String pcTipoDoc)
        {

            lblSubTotal.Visible = !pbVisibilidad;
            lblIGV.Visible = !pbVisibilidad;
            txtSubTotal.Visible = !pbVisibilidad;
            txtIGV.Visible = !pbVisibilidad;

        }


        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedValue != null)
            {
                Boolean lbResult = false;
                lbResult = fnListarProveedorEspecifico();
                if (!lbResult)
                {
                    cboCliente.SelectedIndex = -1;
                    MessageBox.Show("Error al Obtener Proveedor Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Boolean lbResul = false;

            frmRegistrarProveedor frmProveedor = new frmRegistrarProveedor();

            frmProveedor.Inicio(2);

            lbResul = fnObtenerProveedor();
            if (!lbResul)
            {
                MessageBox.Show("Error al Agregar Proveedor", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Boolean lbResul = false;

            frmRegistrarProveedor frmProveedor = new frmRegistrarProveedor();

            frmProveedor.Inicio(1);

            lbResul = fnObtenerProveedor();
            if (!lbResul)
            {
                MessageBox.Show("Error al Agregar Proveedor", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvDetalleVenta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvDetalleVenta.Columns[e.ColumnIndex].Name == "btnNuevo" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvDetalleVenta.Rows[e.RowIndex].Cells["btnNuevo"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\Buscar.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvDetalleVenta.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dgvDetalleVenta.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }
        }

        private void LLenarComboGrilla(DataGridViewComboBoxCell combo, int idProducto)
        {
            BLProducto objProducto = new BLProducto();
            combo.DataSource = objProducto.DADevolverUMxProducto(idProducto);
        }


        private Boolean fnDevolverProducto(Int32 pidProducto, Int16 piTipoCon)
        {
            BLProducto objProducto = new BLProducto();
            Producto[] lstProducto = null;
            clsUtil objUtil = new clsUtil();
            DataGridViewRow row = dgvDetalleVenta.CurrentRow;
            DataGridViewComboBoxCell dgccell;
            Boolean lbResul = false;

            try
            {
                lstProducto = new Producto[1];
                lstProducto = objProducto.BLGetDevolverProducto(pidProducto, piTipoCon,Variables.idSucursal, 1).ToArray();
                if (lstProducto.GetLength(0) > 0)
                {

                    if (dgvDetalleVenta.CurrentRow != null)
                    {
                        dgccell = (DataGridViewComboBoxCell)dgvDetalleVenta.CurrentRow.Cells[7];
                        LLenarComboGrilla(dgccell, pidProducto);
                        row.Cells[2].Value = pidProducto;
                        row.Cells[3].Value = lstProducto[0].cProducto;
                        row.Cells[5].Value = lstProducto[0].Stock;
                        row.Cells[6].Value = lstProducto[0].mPrecioCompra;                     
                        row.Cells[7].Value = lstProducto[0].idUnidadMedida;
                        row.Cells[8].Value = lstProducto[0].Stock * lstProducto[0].mPrecioCompra;
                    }
                    else
                    {
                        dgccell = (DataGridViewComboBoxCell)dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[7];
                        LLenarComboGrilla(dgccell, pidProducto);
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[2].Value = pidProducto;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[3].Value = lstProducto[0].cProducto;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[5].Value = lstProducto[0].Stock;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[6].Value = lstProducto[0].mPrecioCompra;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[7].Value = lstProducto[0].idUnidadMedida;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[8].Value = lstProducto[0].Stock * lstProducto[0].mPrecioCompra;
                    }
                }
                else
                {
                    tsbGuardar.Enabled = false;
                    MessageBox.Show("Ingrese un codigo de Producto que se encuentre registrado.", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                tsbGuardar.Enabled = true;
                lbResul = true;
            }
            catch (Exception ex)
            {
                tsbGuardar.Enabled = false;
                lbResul = false;
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnDevolverProducto", ex.Message);
            }
            finally
            {
                objProducto = null;
                lstProducto = null;
                objUtil = null;
            }
            return lbResul;
        }

        private Boolean fnCalcularTotal()
        {

            int i = 0;
            Decimal lnSubTotal = 0;
            clsUtil objUtil = new clsUtil();
            try
            {

                for (i = 0; i <= dgvDetalleVenta.Rows.Count - 1; i++)
                {
                    lnSubTotal = lnSubTotal + Convert.ToDecimal(dgvDetalleVenta.Rows[i].Cells[8].Value);
                }
                txtSubTotal.Text = Convert.ToString(Math.Round(lnSubTotal / ((lnIGV / 100) + 1), 2));
                txtIGV.Text = Convert.ToString(Math.Round(lnSubTotal - lnSubTotal / ((lnIGV / 100) + 1), 2));
                txtTotal.Text = Convert.ToString(Math.Round(lnSubTotal, 2));

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

        private void dgvDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetalleVenta.Columns["btnNuevo"].Index && e.RowIndex >= 0)
            {
                Boolean lbResul = false;
                lidProducto = 0;
                frmOpcionesProducto frmProducto = new frmOpcionesProducto();
                frmProducto.Inicio(2);
                if (lidProducto > 0)
                {

                    lbResul = fnDevolverProducto(lidProducto, 9);

                    if (lbResul == false)
                    {
                        MessageBox.Show("Error al Obtener Producto Especifico. Comunicar a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    lbResul = fnCalcularTotal();
                    if (lbResul == false)
                    {
                        MessageBox.Show("Ha ocurrido un Error al Calcular Total. Comunicar a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void fnLimpiarControles()
        {

            BLCargo objCargo = new BLCargo();
            txtidVenta.Text = "0";
            cboCliente.SelectedIndex = -1;
            dtFecha.Value = Variables.gdFechaSis;
            txtNroDoc.Text = "";
            txtDoc.Text = "";
            txtDireccion.Text = "";
            dgvDetalleVenta.DataSource = null;
            dgvDetalleVenta.Rows.Clear();
            tsbImprimir.Enabled = false;
            txtSubTotal.Text = "0";
            txtTotal.Text = "0";
            txtIGV.Text = "0";
            txtBuscarDoc.Text = "";
            epControlOk.Clear();
            epUsuario.Clear();
            cboEstado.SelectedIndex = 0;
            txtNroDoc.Text = "";
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnLimpiarControles();
            fnHabilitarDocumento(true, 1);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void fnBuscarporTipo()
        {
            String pbBuscar = "";
            clsUtil objUtil = new clsUtil();
            try
            {

                if (lvBuscarFov.SelectedIndices.Count <= 0)
                {
                    return;
                }
                int intselectedindex = lvBuscarFov.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    pbBuscar = lvBuscarFov.Items[intselectedindex].Text;
                }

                if (pbBuscar == "Codigo de Orden")
                {
                    txtBuscarDoc.Text = "";
                    txtBuscarDoc.Visible = true;
                    dateTimePicker2.Visible = false;
                    lvVenta.Visible = false;
                    lnTipoBuscar = 1;
                    txtBuscarDoc.Focus();
                }
                else if (pbBuscar == "Nro. Lote")
                {
                    txtBuscarDoc.Text = "";
                    txtBuscarDoc.Visible = true;
                    dateTimePicker2.Visible = false;
                    lvVenta.Visible = false;
                    lnTipoBuscar = 6;
                    txtBuscarDoc.Focus();
                }
                else if (pbBuscar == "Doc. Compra")
                {
                    txtBuscarDoc.Text = "";
                    txtBuscarDoc.Visible = true;
                    dateTimePicker2.Visible = false;
                    lvVenta.Visible = false;
                    lnTipoBuscar = 2;
                    txtBuscarDoc.Focus();
                }
                else if (pbBuscar == "Proveedor")
                {
                    txtBuscarDoc.Text = "";
                    txtBuscarDoc.Visible = true;
                    dateTimePicker2.Visible = false;
                    lvVenta.Visible = false;
                    lnTipoBuscar = 3;
                    txtBuscarDoc.Focus();
                }
                else if (pbBuscar == "Nro. Documento")
                {
                    txtBuscarDoc.Text = "";
                    txtBuscarDoc.Visible = true;
                    dateTimePicker2.Visible = false;
                    lvVenta.Visible = false;
                    lnTipoBuscar = 4;
                    txtBuscarDoc.Focus();
                }
                else if (pbBuscar == "Fecha de Compra")
                {
                    txtBuscarDoc.Text = "";
                    txtBuscarDoc.Visible = false;
                    dateTimePicker2.Visible = true;
                    dateTimePicker2.Focus();
                    lvVenta.Visible = false;
                    lnTipoBuscar = 5;
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnBuscarporTipo", ex.Message);
                MessageBox.Show("Error al Buscar por Tipo Documento Venta. Volver a Buscar Documento de Venta. Si continua en mas de 3 ocasiones avise a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                objUtil = null;
            }

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnHabilitarDocumento(false, 0);
            lvBuscarFov.Items[0].Selected = true;
            fnBuscarporTipo();
        }

        private void lvBuscarFov_KeyPress(object sender, KeyPressEventArgs e)
        {
            fnBuscarporTipo();
        }

        private void lvBuscarFov_Click(object sender, EventArgs e)
        {
            fnBuscarporTipo();
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void Column2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void _SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;

            if (combo != null)
            {
                combo.SelectAll();
            }

        }

        private void dgvDetalleVenta_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cb = e.Control as ComboBox;
            if (cb != null)
            {
                cb.SelectionChangeCommitted -= _SelectionChangeCommitted;
                cb.SelectionChangeCommitted += _SelectionChangeCommitted;
            }
            else
            {
                e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
                e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);

                if (dgvDetalleVenta.CurrentCell.ColumnIndex == 2) //Desired Column
                {

                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
                    }
                }

                else if (dgvDetalleVenta.CurrentCell.ColumnIndex == 5) //Desired Column
                {

                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
                else if (dgvDetalleVenta.CurrentCell.ColumnIndex == 6) //Desired Column
                {

                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
            }
        }

        private void dgvDetalleVenta_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {

            }
        }

        private DataTable fnCargarDetalleCompra()
        {
            DataTable dtDetalleCompra = new DataTable();
            DataRow drFila = null;
            int i = 0, j = 0;
            clsUtil objUtil = new clsUtil();
            try
            {
                dtDetalleCompra.Columns.Add(new DataColumn("idDetalleCompra", typeof(Int32)));
                dtDetalleCompra.Columns.Add(new DataColumn("idOrden", typeof(Int32)));
                dtDetalleCompra.Columns.Add(new DataColumn("idProducto", typeof(Int32)));
                dtDetalleCompra.Columns.Add(new DataColumn("Cantidad", typeof(Int32)));
                dtDetalleCompra.Columns.Add(new DataColumn("PrecioCompra", typeof(Decimal)));
                dtDetalleCompra.Columns.Add(new DataColumn("idUnidadMedida", typeof(Decimal)));

                for (i = 0; i <= dgvDetalleVenta.Rows.Count - 1; i++)
                {
                    if (dgvDetalleVenta.Rows[i].IsNewRow == false)
                    {
                        drFila = dtDetalleCompra.NewRow();
                        for (j = 0; j <= dtDetalleCompra.Columns.Count; j++)
                        {
                            if (j == 1)
                                drFila[j] = Convert.ToInt32(txtidVenta.Text.Trim());
                            else if (j == 4 || j == 5 || j == 6)
                                drFila[j - 1] = dgvDetalleVenta.Rows[i].Cells[j + 1].Value == null ? 0 : dgvDetalleVenta.Rows[i].Cells[j + 1].Value;
                            else if (j == 0 || j == 2)
                                drFila[j] = dgvDetalleVenta.Rows[i].Cells[j].Value == null ? 0 : dgvDetalleVenta.Rows[i].Cells[j].Value;
                        }

                        dtDetalleCompra.Rows.Add(drFila);

                    }

                }

                return dtDetalleCompra;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnCargarDetalleCompra", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                dtDetalleCompra = null;
            }
        }

        //private String fnGuardarOrdenCompra(Int16 idTipoCon,String tipoordencompra, out Int32 pidOrden,out string pclote)
        //{
        //    DateTime dFechaSis = Variables.gdFechaSis;
        //    DataTable dtDetalleCompra = null;
        //    BLOrdenCompra blobjVenta = new BLOrdenCompra();
        //    clsUtil objUtil = new clsUtil();
        //    String lcValidar = "";
        //    OrdenCompra objVenta = new OrdenCompra();
        //    try
        //    {
        //        objVenta.idOrden = Convert.ToInt32(txtidVenta.Text.Trim());
        //        objVenta.cDocCompra = Convert.ToString(txtNroDoc.Text.Trim());
        //        objVenta.dFechaCompra = dtFecha.Value;
        //        objVenta.iEstado = Convert.ToString(cboEstado.SelectedValue.ToString().Substring(4, 4).Trim());
        //        objVenta.cTipoPago = cTipoPago;
        //        objVenta.nMontoPagar = nMontoPagar;
        //        objVenta.idProveedor = Convert.ToInt32(cboCliente.SelectedValue);
        //        objVenta.idSucursal = Variables.idSucursal;
        //        objVenta.dFechaRegistro = dFechaSis;
        //        objVenta.idUsuario = Variables.gnCodUser;
        //        objVenta.bEstadoRecep = true;

        //        dtDetalleCompra = new DataTable();
        //        dtDetalleCompra = fnCargarDetalleCompra();
        //        List<TablaOrdenIngreso> Tbla = new List<TablaOrdenIngreso>();
        //        //lcValidar = blobjVenta.blGrabarCompra(Tbla, tipoordencompra,clsOperador, objVenta, dtDetalleCompra, idTipoCon, out pidOrden, out pclote).Trim();
                
        //        fnLimpiarControles();
        //        fnHabilitarDocumento(true, 1);

        //    }
        //    catch (Exception ex)
        //    {
        //        pidOrden=0;
        //        pclote = "";
        //        lcValidar = "NO";
        //        objUtil.gsLogAplicativo("frmOrdenCompra", "fnGuardarOrdenCompra", ex.Message);
        //    }

        //    return lcValidar;

        //}

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            String lcResultado = "";
            string lcImprimirLote = "";
            int lidOrden=0;

            epControlOk.Clear();
            epUsuario.Clear();

            if (txtNroDoc.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtNroDoc, "");
                epUsuario.SetError(txtNroDoc, "Ingresar Nro de Orden de Compra");
            }
            else
            {
                epUsuario.SetError(txtNroDoc, "");
                epControlOk.SetError(txtNroDoc, "Ingreso Correcto de Numero de Orden de Compra");
            }
            if (cboCliente.SelectedValue == null)
            {
                epControlOk.SetError(cboCliente, "");
                epUsuario.SetError(cboCliente, "Elegir Proveedor para la Orden de Compra");
            }
            else
            {
                epUsuario.SetError(cboCliente, "");
                epControlOk.SetError(cboCliente, "Ingreso Correcto de Proveedor para Orden de Compra");
            }

            if (txtNroDoc.Text.Trim() != "" && cboCliente.SelectedValue != null)
            {
                String tipoordencompra = "";
                frmTipoPago frmTipo = new frmTipoPago();
                //frmTipo.Inicio(1, Convert.ToDouble(txtTotal.Text),"S/");

               //lcResultado = fnGuardarOrdenCompra(lnTipoCon, tipoordencompra, out lidOrden, out lcImprimirLote);
                if (lcResultado == "OK")
                {
                    string strActivarImpresion = FunGeneral.fnDevolverParametro("ACIM0001") != null ? (FunGeneral.fnDevolverParametro("ACIM0001")[0].cValor) : "1";
                    if (strActivarImpresion=="1")
                    {
                        Impresiones.frmImpresion frmImpre = new Impresiones.frmImpresion();
                        frmImpre.fnInicio(1, "Imprimir Orden de Compra", lidOrden);
                    }
                    MessageBox.Show("Se Grabo Satisfactoriamente la Orden de Compra." + "\n" + lcImprimirLote, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Grabar Orden de Compra. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        Boolean notlastColumn = false;
        private void dgvDetalleVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleVenta.ColumnCount - 1 == e.ColumnIndex)  //if last column
            {
                KeyEventArgs forKeyDown = new KeyEventArgs(Keys.Enter);
                notlastColumn = false;
                dgvDetalleVenta_KeyDown(dgvDetalleVenta, forKeyDown);
            }
            else
            {
                SendKeys.Send("{up}");
                SendKeys.Send("{right}");
            }
        }

        private void dgvDetalleVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && notlastColumn) //if not last column move to nex
            {
                SendKeys.Send("{up}");
                SendKeys.Send("{right}");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{home}");//go to first column
                notlastColumn = true;
            }
        }

        private void dgvDetalleVenta_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Boolean lbResul = false;
            Int32 liProductoChange = 0;
            if (dgvDetalleVenta.Rows.Count > 0)
            {
                if (e.ColumnIndex == 5 || e.ColumnIndex == 6)
                {

                    dgvDetalleVenta.Rows[e.RowIndex].Cells[8].Value = Math.Round((Convert.ToDecimal(dgvDetalleVenta.Rows[e.RowIndex].Cells[5].Value is Nullable ? 0 : dgvDetalleVenta.Rows[e.RowIndex].Cells[5].Value) * Convert.ToDecimal(dgvDetalleVenta.Rows[e.RowIndex].Cells[6].Value == null ? 0 : dgvDetalleVenta.Rows[e.RowIndex].Cells[6].Value)), 2);
                    lbResul = fnCalcularTotal();
                    if (lbResul == false)
                    {
                        MessageBox.Show("Ha ocurrido un Error al Calcular Totales de Orden de Compra", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                }
                else if (e.ColumnIndex == 2)
                {
                    if (dgvDetalleVenta.Rows[e.RowIndex].Cells[2].Value != null)
                    {
                        if (Convert.ToInt32(dgvDetalleVenta.Rows[e.RowIndex].Cells[2].Value) > 0)
                        {
                            liProductoChange = Convert.ToInt32(dgvDetalleVenta.Rows[e.RowIndex].Cells[2].Value);

                            lbResul = fnDevolverProducto(liProductoChange, 9);

                            if (lbResul == false)
                            {
                                MessageBox.Show("Error al Obtener Producto Especifico. Comunicar a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }

                            //lbResul = fnCalcularTotal();
                            //if (lbResul == false)
                            //{
                            //    MessageBox.Show("Ha ocurrido un Error al Calcular Documento de Venta. Comunicar a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //    return;
                            //}
                        }
                        else
                        {
                            MessageBox.Show("Ingrese Codigo de Producto Correcto", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un Error al Buscar Producto. Comunicar a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private Boolean fnBuscarOrdenCompra(String pcBuscar, Int16 pnTipoCon)
        {
            BLOrdenCompra objDocVenta = new BLOrdenCompra();
            Boolean pbhabilitaLista = false;


            clsUtil objUtil = new clsUtil();
            List<OrdenCompra> lstDocVenta = null;
            ListViewItem lstItem = null;
            try
            {

                lstDocVenta = new List<OrdenCompra>();
                lstDocVenta = objDocVenta.blBuscarOrdenCompra(pcBuscar, pnTipoCon);
                lvVenta.Items.Clear();
                foreach (OrdenCompra objVenta in lstDocVenta)
                {
                    lstItem = lvVenta.Items.Add(objVenta.idOrden.ToString());
                    lstItem.SubItems.Add(objVenta.cDocCompra);
                    lstItem.SubItems.Add(objUtil.GetFechaHoraFormato(objVenta.dFechaCompra, 1));
                    lstItem.SubItems.Add(objVenta.cNomProveedor);
                    lstItem.SubItems.Add(objVenta.cDocumento);
                    pbhabilitaLista = true;
                }

                lvVenta.Visible = pbhabilitaLista;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnBuscarOrdenCompra", ex.Message);
                return false;
            }
            finally
            {
                lstDocVenta = null;
                objDocVenta = null;
                objUtil = null;
            }

        }

        private void txtBuscarDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {

                Boolean bResul = false;

                bResul = fnBuscarOrdenCompra(txtBuscarDoc.Text.Trim(), lnTipoBuscar);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Orden de Compra. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            Boolean bResul = false;

            bResul = fnBuscarOrdenCompra(FunGeneral.GetFechaHoraFormato(dateTimePicker2.Value,3), lnTipoBuscar);
            if (!bResul)
            {
                MessageBox.Show("Error al Buscar Orden de Compra. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void dateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {

                Boolean bResul = false;

                bResul = fnBuscarOrdenCompra(dateTimePicker2.Value.ToString(), lnTipoBuscar);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Orden de Compra. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        private Boolean fnLLenarGrillaDetalleCompra(Int32 pidOrden)
        {
            BLOrdenCompra objDocVenta = new BLOrdenCompra();
            List<DetalleCompra> lstDetalleVenta = new List<DetalleCompra>();
            clsUtil objUtil = new clsUtil();
            DataGridViewComboBoxCell dgccell;

            try
            {
                lstDetalleVenta = objDocVenta.blListarDetalleCompra(pidOrden);
                dgvDetalleVenta.DataSource = null;
                detalleCompraBindingSource1.DataSource = lstDetalleVenta;
                dgvDetalleVenta.DataSource = detalleCompraBindingSource1;
                detalleCompraBindingSource1.ResetBindings(false);
                
                if (lstDetalleVenta.Count > 0)
                {

                     foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
                        {
                            dgccell = (DataGridViewComboBoxCell)row.Cells[7];
                            LLenarComboGrilla(dgccell, Convert.ToInt32(row.Cells[2].Value));
                        }

               }

                fnCalcularTotal();

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnLLenarGrillaDetalleCompra", ex.Message);
                return false;
            }
            finally
            {
                lstDetalleVenta = null;
            }
        }

        private String fnListarOrdenCompra()
        {
            clsUtil objUtil = new clsUtil();
            Boolean lbResul = false;
            try
            {

                if (lvVenta.Items.Count > 0)
                {
                    BLOrdenCompra objVenta = new BLOrdenCompra();
                    OrdenCompra[] lstVenta = new OrdenCompra[1];

                    ListView.SelectedListViewItemCollection item = lvVenta.SelectedItems;
                    lstVenta = objVenta.blListarOrden(Convert.ToInt32(item[0].SubItems[0].Text)).ToArray();

                    if (lstVenta.GetLength(0) > 0)
                    {
                        txtidVenta.Text = Convert.ToString(lstVenta[0].idOrden);
                        txtNroDoc.Text = Convert.ToString(lstVenta[0].cDocCompra);
                        dtFecha.Value = lstVenta[0].dFechaCompra;
                        txtDoc.Text = Convert.ToString(lstVenta[0].cDocumento);
                        cboCliente.Text = Convert.ToString(lstVenta[0].cNomProveedor);
                        txtDireccion.Text = Convert.ToString(lstVenta[0].cDireccion);
                        cboEstado.SelectedValue = "ESDO000"+lstVenta[0].iEstado;
                        lbResul = fnLLenarGrillaDetalleCompra(lstVenta[0].idOrden);

                        if (lbResul == false)
                        {
                            return "Error al Obtener Datos Detalle de Compra. Volver a Buscar Documento";
                        }

                        lvVenta.Visible = false;
                        if (lstVenta[0].iEstado == "3")
                            fnHabilitarDocumento(false, 3);
                        else
                            fnHabilitarDocumento(true, 0);

                        txtBuscarDoc.Text = "";
                        lnTipoCon = 1;
                    }
                    else
                    {
                        return "Error al Obtener Datos de Orden de Compra. Volver a Buscar Orden";
                    }
                }

                return "OK";
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnListarOrdenCompra", ex.Message);
                return ex.Message + ". Comunicar al Administrador de Sistema";
            }
        }

        private void lvVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            String cResul = "";
            if (e.KeyChar == (Char)Keys.Enter)
            {

                cResul = fnListarOrdenCompra();
                if (cResul.Trim() != "OK")
                {
                    MessageBox.Show(cResul, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
        }

        private void lvVenta_DoubleClick(object sender, EventArgs e)
        {
            String cResul = "";
            cResul = fnListarOrdenCompra();
            if (cResul.Trim() != "OK")
            {
                MessageBox.Show(cResul, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void dgvDetalleVenta_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowCount > 0)
            {
                fnCalcularTotal();
            }
        }

        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            Int32 idOrden = 0;
            Impresiones.frmImpresion frmImpre = new Impresiones.frmImpresion();

            idOrden = Convert.ToInt32(txtidVenta.Text.Trim());
            frmImpre.fnInicio(1, "Imprimir Orden de Compra", idOrden);
        }

    }
}
