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
using wfaIntegradoCom.Procesos;
using wfaIntegradoCom.Mantenedores;
using wfaIntegradoCom.Impresiones;
using System.Globalization;
using wfaIntegradoCom.Funciones.Models;
using CapaEntidad.Generic;
using Newtonsoft.Json;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmDocumentoVenta : Form
    {
        public frmDocumentoVenta()
        {
            InitializeComponent();
        }

        Int16 lnTipoLlamada = 0;
        Int16 lnTipoCon = 0;
        static String lcCliente = "";
        static String lcDireccion = "";
        static String lcTipoDoc = "";
        static String lcNroDoc = "";
        static Int32 lidProducto = 0;
        static Int32 lidUnidadMedida = 0;
        static String lcNombreUM = "";
        Decimal lnIGV = 0;
        Int16 lnTipoBuscar = 1;
        static int lnTipoValor = 0;
        BLPrecio objprecio = null;

        public static void fnRecuperarCliente(String pcCliente, String pcDireccion, String pcTipoDoc, String pcNroDoc, int pnTipoValor = 0)
        {
            lcCliente = pcCliente;
            lcDireccion = pcDireccion;
            lcTipoDoc = pcTipoDoc;
            lcNroDoc = pcNroDoc;
            lnTipoValor = pnTipoValor;
        }

        public static void fnRecuperarProducto(Int32 pidProducto)
        {
            lidProducto = pidProducto;
        }

        public static void fnRecuperarUnidadMedida(Int32 pidUnidadMedida, String pcNombreUM)
        {
            lidUnidadMedida = pidUnidadMedida;
            lcNombreUM = pcNombreUM;
        }

        private Boolean fnObtenerCliente()
        {
            bool bResul = false;
            clsUtil objUtil = new clsUtil();
            try
            {
                bResul = fnListarClientesActivo(true);
                if (bResul == false)
                    return false;
                if (lnTipoValor == 0)
                    cboCliente.Text = lcCliente;
                else
                    cboCliente.SelectedValue = Convert.ToInt32(lcCliente);
                txtDireccion.Text = lcDireccion;
                lbTipoDoc.Text = lcTipoDoc;
                txtDoc.Text = lcNroDoc;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmDocumentoVenta", "fnObtenerCliente", ex.Message);
                return false;
            }
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
                objUtil.gsLogAplicativo("frmDocumentoVenta", "fnListarClientesActivo", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objCliente = null;
                lsCliente = null;
            }

        }

        private Boolean fnLLenarGrillaDetalleVenta(Int32 pidVenta)
        {

            BLDocumentoVenta objDocVenta = new BLDocumentoVenta();
            List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();
            clsUtil objUtil = new clsUtil();
            DataGridViewComboBoxCell dgccell;

            try
            {
                //lstDetalleVenta = objDocVenta.blListarDetalleVenta(pidVenta);
                //dgvDetalleVenta.DataSource = null;

                //if (lstDetalleVenta.Count > 0)
                //{
                //    detalleVentaBindingSource.DataSource = lstDetalleVenta;
                //    dgvDetalleVenta.DataSource = detalleVentaBindingSource;
                //    detalleVentaBindingSource.ResetBindings(false);

                //    foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
                //    {
                //        dgccell = (DataGridViewComboBoxCell)row.Cells[5];
                //        LLenarComboGrilla(dgccell, Convert.ToInt32(row.Cells[12].Value));
                //    }

                //}

                fnCalcularTotal();

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmDocumentoVenta", "fnLLenarGrillaDetalleVenta", ex.Message);
                return false;
            }
            finally
            {
                lstDetalleVenta = null;
            }

        }

        private void frmDocumentoVenta_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;
            Cargo[] arrParametro2 = new Cargo[1];
            clsUtil objUtil = new clsUtil();

            try
            {

                //if (FunGeneral.fnVerificarApertura())
                //{
                dgvDetalleVenta.DataSource = null;
                if (lnTipoLlamada == 0)
                {
                    arrParametro2 = FunGeneral.fnDevolverParametro("PIGV0001");

                    if (arrParametro2 == null)
                    {
                        MessageBox.Show("Error al Cargar IGV(Impuesto General a las Ventas)", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    lnIGV = Convert.ToDecimal(arrParametro2[0].cValor);
                    lblIGV.Text = "IGV(" + Convert.ToString(lnIGV) + " %)";

                    bResult = FunGeneral.fnLlenarTablaCod(cboTipoDocuVen, "DOVE");
                    if (!bResult)
                    {
                        MessageBox.Show("Error al Cargar TablaCod - Tipo Documento de Venta", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }

                    //bResult = FunGeneral.fnLlenarTablaCod(cboTipoPago, "TIPA");
                    //if (!bResult)
                    //{
                    //    MessageBox.Show("Error al Cargar TablaCod - Tipo de Pago", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    this.Close();
                    //}

                    bResult = FunGeneral.fnLlenarTablaCod(cboEstado, "ESDO");
                    if (!bResult)
                    {
                        MessageBox.Show("Error al Cargar TablaCod - Estado del Documento de Venta", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }

                    bResult = fnListarClientesActivo(true);
                    if (!bResult)
                    {
                        MessageBox.Show("Error al Cargar Clientes Activos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    dtFecha.Value = Variables.gdFechaSis;
                    dateTimePicker1.Value = Variables.gdFechaSis;
                    dateTimePicker2.Value = Variables.gdFechaSis;
                    fnHabilitarDocumento(true, 1);
                }
                //}
                //else {

                //    MessageBox.Show("Deber Aperturar Caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.Close();

                //}
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmDocumentoVenta", "frmDocumentoVenta_Load", ex.Message);
            }
            finally
            {
                objUtil = null;
                arrParametro2 = null;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Boolean lbResul = false;

            frmBuscarCliente frmCliente = new frmBuscarCliente();

            frmCliente.Inicio(2);

            lbResul = fnObtenerCliente();
            if (!lbResul)
            {
                MessageBox.Show("Error al Agregar Cliente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Boolean lbResul = false;

            frmBuscarCliente frmCliente = new frmBuscarCliente();

            frmCliente.Inicio(1);

            lbResul = fnObtenerCliente();
            if (!lbResul)
            {
                MessageBox.Show("Error al Agregar Cliente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Boolean fnObtenerClienteEspecifico()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (cboCliente.SelectedValue != null)
                {
                    BLCliente objCli = new BLCliente();
                    Cliente lstCliente = new Cliente();

                    lstCliente = objCli.blListarCliente(1,0);

                    if (lstCliente.idCliente > 0)
                    {
                        txtDireccion.Text = Convert.ToString(lstCliente.cDireccion);
                        lbTipoDoc.Text = Convert.ToString(lstCliente.cTiDo);
                        txtDoc.Text = Convert.ToString(lstCliente.cDocumento);
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmDocumentoVenta", "fnListarClienteEspecifico", ex.Message);
                return false;
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedValue != null)
            {
                Boolean lbResult = false;
                lbResult = fnObtenerClienteEspecifico();
                if (!lbResult)
                {
                    cboCliente.SelectedIndex = -1;
                    MessageBox.Show("Error al Obtener Cliente Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void fnVisibilida(Boolean pbVisibilidad, String pcTipoDoc)
        {

            lblNroDoc.Text = "Nro. " + cboTipoDocuVen.Text;
            if (pcTipoDoc == "DOVE0002")
                gbGuia.Visible = !pbVisibilidad;
            else if (pcTipoDoc == "DOVE0003")
                gbGuia.Visible = !pbVisibilidad;
            else
                gbGuia.Visible = pbVisibilidad;
            lblSubTotal.Visible = !pbVisibilidad;
            lblIGV.Visible = !pbVisibilidad;
            txtSubTotal.Visible = !pbVisibilidad;
            txtIGV.Visible = !pbVisibilidad;

        }

        private void cboTipoDocuVen_SelectedIndexChanged(object sender, EventArgs e)
         {
            String cTipoDocVen = "";
            String lcCorrelativo = "";
            clsUtil objUtil = new clsUtil();
            BLCargo objCargo = new BLCargo();
            try
            {
                if (cboTipoDocuVen.Items.Count > 0)
                {
                    cTipoDocVen = cboTipoDocuVen.SelectedValue.ToString().Trim();
                    lcCorrelativo = objCargo.blDevolverCorrelativo(cTipoDocVen);

                    if (lcCorrelativo == "" || lcCorrelativo == "XX")
                    {
                        MessageBox.Show("Error al Obtener Nro de Documento Fisico. Avise a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //this.Close();
                    }
                    else
                    {
                        txtNroDoc.Text = lcCorrelativo;

                        if (cTipoDocVen == "DOVE0001")
                        {
                            fnVisibilida(false, cTipoDocVen);
                        }
                        else if (cTipoDocVen == "DOVE0002")
                        {
                            fnVisibilida(false, cTipoDocVen);
                        }
                        else if (cTipoDocVen == "DOVE0003")
                        {
                            fnVisibilida(true, cTipoDocVen);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmDocumentoVenta", "fnListarDocumentoVenta", ex.Message);
                MessageBox.Show("Error al Buscar pot Tipo. Volver a Buscar Documento de Venta. Si continua en mas de 3 ocasiones avise a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void fnHabilitarDocumento(Boolean pbHabilitar, Int16 pnTipoLlamda)
        {
            gbDocumento.Enabled = pbHabilitar;
            gbCliente.Enabled = pbHabilitar;
            gbGuia.Enabled = pbHabilitar;
            dgvDetalleVenta.Enabled = pbHabilitar;
            gbBuscar.Visible = pnTipoLlamda == 3 ? pbHabilitar : !pbHabilitar;
            //tsbImprimir.Enabled = pnTipoLlamda == 0 ? pbHabilitar : !pbHabilitar;
            tsbGuardar.Enabled = pbHabilitar;
            lblAnulado.Visible = pnTipoLlamda == 3 ? true : false;
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnHabilitarDocumento(false, 0);
            lvBuscarFov.Items[0].Selected = true;
            fnBuscarporTipo();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private String fnListarDocumentoVenta()
        {
            clsUtil objUtil = new clsUtil();
            Boolean lbResul = false;
            try
            {

                if (lvVenta.Items.Count > 0)
                {
                    BLDocumentoVenta objVenta = new BLDocumentoVenta();
                    DocumentoVenta[] lstVenta = new DocumentoVenta[1];

                    ListView.SelectedListViewItemCollection item = lvVenta.SelectedItems;
                    lstVenta = objVenta.blListarDocVenta(Convert.ToInt32(item[0].SubItems[0].Text)).ToArray();

                    if (lstVenta.GetLength(0) > 0)
                    {
                        txtidVenta.Text = Convert.ToString(lstVenta[0].idVenta);
                        txtNroDoc.Text = Convert.ToString(lstVenta[0].cDocVenta);
                        lnIGV = lstVenta[0].nNroIGV;
                        cboTipoDocuVen.Text = Convert.ToString(lstVenta[0].cTipoDoc);
                        cboEstado.Text = Convert.ToString(lstVenta[0].cEstado);
                        dateTimePicker1.Value = lstVenta[0].dCancelado;
                        dtFecha.Value = lstVenta[0].dFechaVenta;
                        txtDoc.Text = Convert.ToString(lstVenta[0].cDocumento);
                        //lbTipoDoc.Text = Convert.ToString(lstVenta[0].cTiDo);
                        cboCliente.Text = Convert.ToString(lstVenta[0].cCliente);
                        txtDireccion.Text = Convert.ToString(lstVenta[0].cDireccion);
                        txtNroGuiaRem.Text = Convert.ToString(lstVenta[0].cNroGuiaRem);
                        txtGuiaTrans.Text = Convert.ToString(lstVenta[0].cNroGuiaTrans);

                        lbResul = fnLLenarGrillaDetalleVenta(lstVenta[0].idVenta);

                        if (lbResul == false)
                        {
                            return "Error al Obtener Datos Detalle de Documento de Venta. Volver a Buscar Documento";
                        }

                        lbResul = fnCalcularTotal();
                        if (lbResul == false)
                        {
                            return "Ha ocurrido un Error al Calcular Totales en Documento de Venta. Comunicar a Administrador de Sistema";
                        }

                        lvVenta.Visible = false;
                        if (lstVenta[0].cEstado.Trim() == "Anulado")
                            fnHabilitarDocumento(false, 3);
                        else
                            fnHabilitarDocumento(true, 0);

                        txtBuscarDoc.Text = "";
                        lnTipoCon = 1;
                    }
                    else
                    {
                        return "Error al Obtener Datos de Documento de Venta. Volver a Buscar Documento";
                    }
                }

                return "OK";
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmDocumentoVenta", "fnListarDocumentoVenta", ex.Message);
                return ex.Message + ". Comunicar al Administrador de Sistema";
            }
        }

        private Boolean fnBuscarDocVenta(String pcBuscar, Int16 pnTipoCon)
        {
            BLDocumentoVenta objDocVenta = new BLDocumentoVenta();
            Boolean pbhabilitaLista = false;


            clsUtil objUtil = new clsUtil();
            List<DocumentoVenta> lstDocVenta = null;
            ListViewItem lstItem = null;
            try
            {

                lstDocVenta = new List<DocumentoVenta>();
                //lstDocVenta = objDocVenta.blBuscarDocVenta(pcBuscar, pnTipoCon);
                lvVenta.Items.Clear();
                foreach (DocumentoVenta objVenta in lstDocVenta)
                {
                    lstItem = lvVenta.Items.Add(objVenta.idVenta.ToString());
                    lstItem.SubItems.Add(objVenta.cDocVenta);
                    lstItem.SubItems.Add(objUtil.GetFechaHoraFormato(objVenta.dFechaVenta, 1));
                    lstItem.SubItems.Add(objVenta.cCliente);
                    lstItem.SubItems.Add(objVenta.cDocumento);
                    //lstItem.SubItems.Add(objVenta.cTiDo);
                    pbhabilitaLista = true;
                }

                lvVenta.Visible = pbhabilitaLista;
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

        private void txtBuscarDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {

                Boolean bResul = false;

                bResul = fnBuscarDocVenta(txtBuscarDoc.Text.Trim(), lnTipoBuscar);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Documento de Venta. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

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

                if (pbBuscar == "Cod. Venta")
                {
                    txtBuscarDoc.Text = "";
                    txtBuscarDoc.Visible = true;
                    dateTimePicker2.Visible = false;
                    lvVenta.Visible = false;
                    lnTipoBuscar = 1;
                    txtBuscarDoc.Focus();
                }
                else if (pbBuscar == "Doc. Venta")
                {
                    txtBuscarDoc.Text = "";
                    txtBuscarDoc.Visible = true;
                    dateTimePicker2.Visible = false;
                    lvVenta.Visible = false;
                    lnTipoBuscar = 2;
                    txtBuscarDoc.Focus();
                }
                else if (pbBuscar == "Nombre Cliente")
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
                else if (pbBuscar == "Fecha de Venta")
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
                objUtil.gsLogAplicativo("frmDocumentoVenta", "fnBuscarporTipo", ex.Message);
                MessageBox.Show("Error al Buscar por Tipo Documento Venta. Volver a Buscar Documento de Venta. Si continua en mas de 3 ocasiones avise a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                objUtil = null;
            }

        }

        private void lvBuscarFov_Click(object sender, EventArgs e)
        {
            fnBuscarporTipo();
        }

        private void lvBuscarFov_KeyPress(object sender, KeyPressEventArgs e)
        {
            fnBuscarporTipo();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnLimpiarControles();
            fnHabilitarDocumento(true, 1);
        }

        private DataTable fnCargarDetalleVenta(out List<DetalleVenta> plstDetalleVenta)
        {
            DataTable dtDetalleVenta = new DataTable();
            DataRow drFila = null;
            int i = 0, j = 0;
            clsUtil objUtil = new clsUtil();
            BLDocumentoVenta objVenta = new BLDocumentoVenta();
            List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();
            DetalleVenta detalleVenta = null;
            try
            {
                dtDetalleVenta.Columns.Add(new DataColumn("idDetalleVenta", typeof(Int32)));
                dtDetalleVenta.Columns.Add(new DataColumn("idVenta", typeof(Int32)));
                dtDetalleVenta.Columns.Add(new DataColumn("idProducto", typeof(Int32)));
                dtDetalleVenta.Columns.Add(new DataColumn("idUnidadMedida", typeof(Int32)));
                dtDetalleVenta.Columns.Add(new DataColumn("Cantidad", typeof(Decimal)));
                dtDetalleVenta.Columns.Add(new DataColumn("PrecioCompra", typeof(Decimal)));
                dtDetalleVenta.Columns.Add(new DataColumn("PrecioVenta", typeof(Decimal)));
                dtDetalleVenta.Columns.Add(new DataColumn("mDescuento", typeof(Decimal)));


                for (i = 0; i <= dgvDetalleVenta.Rows.Count - 1; i++)
                {
                    if (dgvDetalleVenta.Rows[i].IsNewRow == false)
                    {
                        drFila = dtDetalleVenta.NewRow();
                        detalleVenta = new DetalleVenta();
                        for (j = 0; j <= dtDetalleVenta.Columns.Count - 1; j++)
                        {
                            if (j == 1)
                            {
                                int idVentaRow = 0;
                                idVentaRow = Convert.ToInt32(txtidVenta.Text.Trim());
                                drFila[j] = idVentaRow;
                                //detalleVenta.idVenta = idVentaRow;
                            }
                            else if (j == 3)
                            {
                                string cNombreProducto = Convert.ToString(dgvDetalleVenta.Rows[i].Cells[j].Value == null ? "" : dgvDetalleVenta.Rows[i].Cells[j].Value);
                                int idUnidaMedidaRow = Convert.ToInt32(dgvDetalleVenta.Rows[i].Cells[j + 2].Value == null ? 0 : dgvDetalleVenta.Rows[i].Cells[j + 2].Value);
                                drFila[j] = idUnidaMedidaRow;
                                //detalleVenta.idUnidadMedida = idUnidaMedidaRow;
                                //detalleVenta.cProducto = cNombreProducto;
                            }
                            else if (j == 4)
                            {
                                decimal CantidaRow = Convert.ToDecimal(dgvDetalleVenta.Rows[i].Cells[j + 3].Value == null ? 0 : dgvDetalleVenta.Rows[i].Cells[j + 3].Value);
                                //detalleVenta.Cantidad = CantidaRow;
                                drFila[j] = CantidaRow;
                            }
                            else if (j == 5)
                            {
                                string cNombreUM = Convert.ToString(dgvDetalleVenta.Rows[i].Cells[j].EditedFormattedValue == null ? 0 : dgvDetalleVenta.Rows[i].Cells[j].EditedFormattedValue);
                                decimal precioCompraRow = Convert.ToDecimal(dgvDetalleVenta.Rows[i].Cells[j + 3].Value == null ? 0 : dgvDetalleVenta.Rows[i].Cells[j + 3].Value);
                                //detalleVenta.PrecioCompra = precioCompraRow;
                                //detalleVenta.cNombreUM = cNombreUM;
                                drFila[j] = precioCompraRow;
                            }
                            else if (j == 6)
                            {
                                decimal precioVentaRow = Convert.ToDecimal(dgvDetalleVenta.Rows[i].Cells[j + 3].Value == null ? 0 : dgvDetalleVenta.Rows[i].Cells[j + 3].Value);
                                //detalleVenta.PrecioVenta = precioVentaRow;
                                drFila[j] = precioVentaRow;
                            }
                            else if (j == 7)
                            {
                                decimal DescuentoRow = Convert.ToDecimal(dgvDetalleVenta.Rows[i].Cells[j + 3].Value == null ? 0 : dgvDetalleVenta.Rows[i].Cells[j + 3].Value);
                                //detalleVenta.mDescuento = DescuentoRow;
                                drFila[j] = DescuentoRow;
                            }
                            else if (j == 0)
                            {
                                int idDetalleVentaRow = Convert.ToInt32(dgvDetalleVenta.Rows[i].Cells[j].Value == null ? 0 : dgvDetalleVenta.Rows[i].Cells[j].Value);
                                drFila[j] = idDetalleVentaRow;
                                //detalleVenta.idDetalleVenta = idDetalleVentaRow;
                            }
                            else if (j == 2)
                            {
                                int idProductoRow = Convert.ToInt32(dgvDetalleVenta.Rows[i].Cells[j].Value == null ? 0 : dgvDetalleVenta.Rows[i].Cells[j].Value);
                                drFila[j] = idProductoRow;
                                //detalleVenta.idProducto = idProductoRow;
                            }
                        }
                        /*etalleVenta.Importe = detalleVenta.PrecioVenta * detalleVenta.Cantidad;*/
                        lstDetalleVenta.Add(detalleVenta);
                        dtDetalleVenta.Rows.Add(drFila);
                    }

                }
                plstDetalleVenta = lstDetalleVenta;
                return dtDetalleVenta;
            }
            catch (Exception ex)
            {
                plstDetalleVenta = null;
                objUtil.gsLogAplicativo("frmDocumentoVenta.cs", "fnCargarDetalleVenta", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                objVenta = null;
                objUtil = null;
                dtDetalleVenta = null;
            }
        }

        static String cTipoPago = string.Empty;
        static Decimal nMontoPagar = 0;
        static string cDescripcionTipoPago = string.Empty;
        public static void fnRecuperarTipoPago(string pcTipoPago, decimal pnMontoPagar, string pcDescripcionTipoPago = "CONTADO")
        {
            cTipoPago = pcTipoPago;
            nMontoPagar = pnMontoPagar;
            cDescripcionTipoPago = pcDescripcionTipoPago;
        }

        private String fnGuardarDocumentoVenta(Int16 idTipoCon, out Int32 pidVenta, out GenericMasterDetail<DocumentoVenta, DetalleVenta> masterDetail)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            DataTable dtDetalleVenta = null;
            BLDocumentoVenta blobjVenta = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            List<DetalleVenta> lstDetalle = new List<DetalleVenta>();
            DocumentoVenta objVenta = new DocumentoVenta();
            try
            {
                objVenta.idVenta = Convert.ToInt32(txtidVenta.Text.Trim());
                objVenta.cDescripcionTiDo = lbTipoDoc.Text;
                objVenta.cDocumento = txtDoc.Text;
                objVenta.cTipoDoc = Convert.ToString(cboTipoDocuVen.SelectedValue);
                objVenta.cDescripcionTipoDoc = cboTipoDocuVen.Text;
                objVenta.cDocVenta = Convert.ToString(txtNroDoc.Text.Trim());
                objVenta.dFechaVenta = dtFecha.Value;
                objVenta.cEstado = Convert.ToString(cboEstado.SelectedValue);
                objVenta.cDescripcionEstado = cboEstado.Text;
                objVenta.cTipoPago = cTipoPago;
                objVenta.cDescripcionTipoPago = cDescripcionTipoPago;
                objVenta.idCliente = Convert.ToInt32(cboCliente.SelectedValue);
                objVenta.cCliente = cboCliente.Text;
                objVenta.cNroGuiaRem = Convert.ToString(txtNroGuiaRem.Text.Trim());
                objVenta.cNroGuiaTrans = Convert.ToString(txtGuiaTrans.Text.Trim());
                objVenta.dFechaRegistro = dFechaSis;
                objVenta.nNroIGV = lnIGV;
                objVenta.dCancelado = dateTimePicker1.Value;
                objVenta.idUsuario = Variables.gnCodUser;
                objVenta.dFechaAct = dFechaSis;
                objVenta.idUsuAct = Variables.gnCodUser;
                objVenta.idSucursal = Variables.idSucursal;
                objVenta.nMontoPagar =Convert.ToDouble(nMontoPagar);
                //objVenta.nMontoTotal = Convert.ToDecimal(txtTotal.Text);
                //objVenta.nIGV = Convert.ToDecimal(txtIGV.Text);
                //objVenta.nSubtotal = Convert.ToDecimal(txtSubTotal.Text);
                objVenta.cUsuario = Variables.gsCodUser;
                dtDetalleVenta = new DataTable();
                dtDetalleVenta = fnCargarDetalleVenta(out lstDetalle);

                //lstDetalle = fnListarDetalleVenta(dtDetalleVenta);
                GenericMasterDetail<DocumentoVenta, DetalleVenta> genericMasterDetail = new GenericMasterDetail<DocumentoVenta, DetalleVenta>
                {
                    Header = objVenta,
                    Detail = lstDetalle

                };
                masterDetail = genericMasterDetail;
                lcValidar = blobjVenta.blGrabarVenta(objVenta, dtDetalleVenta, out pidVenta, idTipoCon).Trim();
                fnLimpiarControles();
                fnHabilitarDocumento(true, 1);
            }
            catch (Exception ex)
            {
                lcValidar = "NO";
                masterDetail = null;
                pidVenta = 0;
                objUtil.gsLogAplicativo("frmDocumentoVenta", "fnGuardarDocumentoVenta", ex.Message);
            }
            return lcValidar;
        }
        /*
        private List<DetalleVenta> fnListarDetalleVenta(DataTable dtDetalleVenta)
        {
            List<DetalleVenta> detalleVentas = new List<DetalleVenta>();
            foreach (DataRow row in dtDetalleVenta.Rows)
            {
                detalleVentas.Add(new DetalleVenta
                {
                    idDetalleVenta = Convert.ToInt32(row["idDetalleVenta"]),
                    idVenta = Convert.ToInt32(row["idVenta"]),
                    idProducto = Convert.ToInt32(row["idProducto"]),
                    idUnidadMedida = Convert.ToInt32(row["idUnidadMedida"]),
                    Cantidad = Convert.ToDecimal(row["Cantidad"]),
                    PrecioCompra = Convert.ToDecimal(row["PrecioCompra"]),
                    PrecioVenta = Convert.ToDecimal(row["PrecioVenta"]),
                    mDescuento = Convert.ToDecimal(row["mDescuento"]),
                });
            }

            return detalleVentas;
        }*/

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            String lcResultado = "";
            Int32 liVenta = 0;
            GenericMasterDetail<DocumentoVenta, DetalleVenta> masterDetail = null;

            epControlOk.Clear();
            epUsuario.Clear();

            if (txtNroDoc.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtNroDoc, "");
                epUsuario.SetError(txtNroDoc, "Ingresar Nro de Documento de Venta");
            }
            else
            {
                epUsuario.SetError(txtNroDoc, "");
                epControlOk.SetError(txtNroDoc, "Ingreso Correcto de Numero de Documento de Venta");
            }
            if (cboCliente.SelectedValue == null)
            {
                epControlOk.SetError(cboCliente, "");
                epUsuario.SetError(cboCliente, "Elegir Cliente para el Documento de Venta");
            }
            else
            {
                epUsuario.SetError(cboCliente, "");
                epControlOk.SetError(cboCliente, "Ingreso Correcto de Cliente para Documento de Venta");
            }

            if (txtNroDoc.Text.Trim() == "" && cboCliente.SelectedValue != null)
            {

                string strIdClienteContado = FunGeneral.fnDevolverParametro("CLC0001") != null ? (FunGeneral.fnDevolverParametro("CLC0001")[0].cValor.Trim()) : "2";

                frmTipoPago frmTipo = new frmTipoPago();
                //frmTipo.Inicio(2, Convert.ToDouble(txtTotal.Text),"S/");

                if (strIdClienteContado == cboCliente.SelectedValue.ToString() && Math.Round(nMontoPagar, 2) < Math.Round(Convert.ToDecimal(txtTotal.Text), 2))
                {
                    MessageBox.Show("Cliente Publico en General no puede generar una deuda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    lcResultado = fnGuardarDocumentoVenta(lnTipoCon, out liVenta, out masterDetail);
                    if (lcResultado == "OK")
                    {
                        string strActivarImpresion = FunGeneral.fnDevolverParametro("ACIM0002") != null ? (FunGeneral.fnDevolverParametro("ACIM0002")[0].cValor.Trim()) : "1";
                        if (strActivarImpresion == "1")
                        {
                            if (Variables.bitActivePrintDirect)
                            {
                                masterDetail.empresa = new Empresa
                                {
                                    RazonSocial = Variables.gsEmpresa,
                                    Ruc = Variables.gsRuc
                                };
                                masterDetail.sucursal = Variables.sucursal;
                                GenericDocument<DocumentoVenta, DetalleVenta> document = new GenericDocument<DocumentoVenta, DetalleVenta>
                                {
                                    Document = masterDetail
                                };

                                string documentjson = JsonConvert.SerializeObject(document);

                                PrintRequest printRequest = new PrintRequest
                                {
                                    Identity = "",
                                    OperatorId = "",
                                    StringifiedDocumentData = documentjson,
                                    NumberOfCopies = 1,
                                    TargetPrinterName = Variables.gsImpresora,
                                    TemplateName = "Venta",
                                    PaperWidth = 80
                                };
                                FunGeneral.fnImprimirVoucher(printRequest);
                            }
                            else
                            {
                                frmImpresion frmImpre = new frmImpresion();
                                frmImpre.fnInicio(0, "Imprimir Documento de Venta", liVenta);
                            }
                        }
                        MessageBox.Show("Se Grabo Satisfactoriamente Documento de Venta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al Grabar Documento de Venta. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }

        }

        private void dateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Boolean bResul = false;

                bResul = fnBuscarDocVenta(FunGeneral.GetFechaHoraFormato(dateTimePicker2.Value, 5), lnTipoBuscar);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Documento de Venta. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Boolean bResul = false;

            bResul = fnBuscarDocVenta(FunGeneral.GetFechaHoraFormato(dateTimePicker2.Value, 5), lnTipoBuscar);
            if (!bResul)
            {
                MessageBox.Show("Error al Buscar Documento de Venta. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lvVenta_DoubleClick(object sender, EventArgs e)
        {
            String cResul = "";
            cResul = fnListarDocumentoVenta();
            if (cResul.Trim() != "OK")
            {
                MessageBox.Show(cResul, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void fnLimpiarControles()
        {
            String lcCorrelativo = "";

            BLCargo objCargo = new BLCargo();
            txtidVenta.Text = "0";
            cboCliente.SelectedIndex = -1;
            dtFecha.Value = Variables.gdFechaSis;
            txtNroDoc.Text = "";
            txtDoc.Text = "";
            txtDireccion.Text = "";
            txtGuiaTrans.Text = "";
            txtNroGuiaRem.Text = "";
            dgvDetalleVenta.DataSource = null;
            dgvDetalleVenta.Rows.Clear();
            tsbImprimir.Enabled = false;
            txtSubTotal.Text = "";
            txtTotal.Text = "";
            txtIGV.Text = "";
            txtBuscarDoc.Text = "";
            epControlOk.Clear();
            epUsuario.Clear();
            cboEstado.SelectedIndex = 0;
            lnTipoCon = 0;
            cboTipoDocuVen.SelectedIndex = 0;
            lcCorrelativo = objCargo.blDevolverCorrelativo(cboTipoDocuVen.SelectedValue.ToString().Trim());

            if (lcCorrelativo == "" || lcCorrelativo == "XX")
            {
                MessageBox.Show("Error al Obtener Nro de Documento Fisico. Avise a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            txtNroDoc.Text = lcCorrelativo;
        }

        private void dgvDetalleVenta_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {

            }

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

        private void dgvDetalleVenta_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvDetalleVenta.CurrentCell.IsComboBoxCell())
            {
                //if (dgvDetalleVenta.Columns[dgvDetalleVenta.CurrentCell.ColumnIndex].Name == "ContactsColumn")
                //{
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.SelectionChangeCommitted -= _SelectionChangeCommitted;
                    cb.SelectionChangeCommitted += _SelectionChangeCommitted;
                }
                //}
            }
            else
            {
                e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
                e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);
                //e.Control.KeyDown -= new KeyEventHandler(Column2_KeyDown);

                if (dgvDetalleVenta.CurrentCell.ColumnIndex == 2) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
                        //tb.KeyDown += new KeyEventHandler(Column2_KeyDown);
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
                else if (dgvDetalleVenta.CurrentCell.ColumnIndex == 7) //Desired Column
                {

                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
                else if (dgvDetalleVenta.CurrentCell.ColumnIndex == 8) //Desired Column
                {

                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }

            }
        }        //private void Column2_KeyDown(object sender, KeyEventArgs e)

        private void LLenarComboGrilla(DataGridViewComboBoxCell combo, int idProducto)
        {
            BLProducto objProducto = new BLProducto();
            combo.DataSource = objProducto.DADevolverUMxProducto(idProducto);
        }

        private Boolean fnDevolverProducto(Int32 pidProducto, Int16 piTipoCon, out string strMensaje)
        {
            BLProducto objProducto = new BLProducto();
            Producto[] lstProducto = null;
            clsUtil objUtil = new clsUtil();
            DataGridViewRow row = dgvDetalleVenta.CurrentRow;
            DataGridViewComboBoxCell dgccell;
            Boolean lbResul = false;
            objprecio = new BLPrecio();

            try
            {
                lstProducto = new Producto[1];
                lstProducto = objProducto.BLGetDevolverProducto(pidProducto, piTipoCon, Variables.idSucursal, 1).ToArray();
                if (lstProducto.GetLength(0) > 0)
                {
                    decimal price = objprecio.blDevolverPrecioxProductoXUM(lstProducto[0].idProducto, lstProducto[0].idUnidadMedida);
                    if (dgvDetalleVenta.CurrentRow != null)
                    {
                        dgccell = (DataGridViewComboBoxCell)dgvDetalleVenta.CurrentRow.Cells[5];
                        LLenarComboGrilla(dgccell, lstProducto[0].idProducto);
                        row.Cells[2].Value = pidProducto;
                        row.Cells[3].Value = lstProducto[0].cProducto;
                        row.Cells[5].Value = lstProducto[0].idUnidadMedida;
                        row.Cells[6].Value = lstProducto[0].idUnidadOrigen;
                        row.Cells[7].Value = lstProducto[0].Stock;
                        row.Cells[7].Selected = true;
                        row.Cells[8].Value = lstProducto[0].mPrecioCompra;
                        row.Cells[9].Value = price;//lstProducto[0].mPrecioVenta;
                        row.Cells[10].Value = lstProducto[0].mDescuento;
                        row.Cells[11].Value = row.Cells[11].Value = Math.Round((Convert.ToDecimal(row.Cells[7].Value is Nullable ? 0 : row.Cells[7].Value) * Convert.ToDecimal(row.Cells[9].Value == null ? 0 : row.Cells[9].Value)) - ((Convert.ToDecimal(row.Cells[7].Value == null ? 0 : row.Cells[7].Value)) * Convert.ToDecimal(row.Cells[9].Value == null ? 0 : row.Cells[9].Value) * (Convert.ToDecimal(row.Cells[10].Value == null ? 0 : row.Cells[10].Value) / 100)), 2);//lstProducto[0].Stock * lstProducto[0].mPrecioVenta - (lstProducto[0].Stock * lstProducto[0].mPrecioVenta) * (lstProducto[0].mDescuento/100);
                        row.Cells[12].Value = lstProducto[0].idProducto;
                    }
                    else
                    {
                        dgccell = (DataGridViewComboBoxCell)dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[5];
                        LLenarComboGrilla(dgccell, lstProducto[0].idProducto);
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[2].Value = pidProducto;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[3].Value = lstProducto[0].cProducto;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[5].Value = lstProducto[0].idUnidadMedida;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[6].Value = lstProducto[0].idUnidadOrigen;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[7].Value = lstProducto[0].Stock;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[7].Selected = true;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[8].Value = lstProducto[0].mPrecioCompra;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[9].Value = price;//lstProducto[0].mPrecioVenta;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[10].Value = lstProducto[0].mDescuento;
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[11].Value = dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[11].Value = Math.Round((Convert.ToDecimal(dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[7].Value is Nullable ? 0 : dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[7].Value) * Convert.ToDecimal(dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[9].Value == null ? 0 : dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[9].Value)) - ((Convert.ToDecimal(dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[7].Value == null ? 0 : dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[7].Value)) * Convert.ToDecimal(dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[9].Value == null ? 0 : dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[9].Value) * (Convert.ToDecimal(dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[10].Value == null ? 0 : dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[10].Value) / 100)), 2);//lstProducto[0].Stock * lstProducto[0].mPrecioVenta - (lstProducto[0].Stock * lstProducto[0].mPrecioVenta) * (lstProducto[0].mDescuento/100);
                        dgvDetalleVenta.Rows[dgvDetalleVenta.NewRowIndex].Cells[12].Value = lstProducto[0].idProducto;

                    }
                    lbResul = fnCalcularTotal();
                    if (lbResul == false)
                    {
                        strMensaje = "Ha ocurrido un Error al Calcular Totales de Documento de Venta";
                        return false;
                    }
                }
                else
                {
                    tsbGuardar.Enabled = false;
                    dgvDetalleVenta.Rows.Remove(dgvDetalleVenta.CurrentRow);
                    strMensaje = "Ingrese un codigo de Lote o Producto que se encuentre registrado.";
                    return false;
                }

                //lbResul = fnDevolverUM(lstProducto[0].idUnidadMedida);

                //if (lbResul == false)
                //{
                //    tsbGuardar.Enabled = false;
                //    return false;
                //}
                strMensaje = "";
                tsbGuardar.Enabled = true;
                lbResul = true;
            }
            catch (Exception ex)
            {
                tsbGuardar.Enabled = false;
                lbResul = false;
                strMensaje = "Error no controlado al Devolver Producto";
                objUtil.gsLogAplicativo("frmDocumentoVenta", "fnDevolverProducto", ex.Message);
            }
            finally
            {
                objProducto = null;
                lstProducto = null;
                objUtil = null;
            }
            return lbResul;
        }

        private void _SelectionChangeCommitted(object sender, EventArgs e)
        {
            bool lbResul = false;
            ComboBox combo = sender as ComboBox;
            objprecio = new BLPrecio();

            if (combo != null)
            {
                int idUnidadMedida = Convert.ToInt32(combo.SelectedValue);
                int idProducto = Convert.ToInt32(dgvDetalleVenta.CurrentRow.Cells[12].Value);
                decimal price = objprecio.blDevolverPrecioxProductoXUM(idProducto, idUnidadMedida);
                dgvDetalleVenta.CurrentRow.Cells[9].Value = price;
                dgvDetalleVenta.CurrentRow.Cells[7].Value = 0;

                lbResul = fnCalcularTotal();
                if (lbResul == false)
                {
                    MessageBox.Show("Ha ocurrido un Error al Calcular Totales de Documento de Venta", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            //Variables.bitActivePrintDirect = false;
            if (Variables.bitActivePrintDirect)
            {
                int idVenta = Convert.ToInt32(txtidVenta.Text.Trim());
                BLDocumentoVenta objVenta = new BLDocumentoVenta();
                DocumentoVenta[] lstVenta = new DocumentoVenta[1];
                List<DetalleVenta> lstDetalleVen = new List<DetalleVenta>();

                lstVenta = objVenta.blListarDocVenta(idVenta).ToArray();
                //lstDetalleVen = objVenta.blListarDetalleVenta(idVenta);
                GenericMasterDetail<DocumentoVenta, DetalleVenta> genericMasterDetail = new GenericMasterDetail<DocumentoVenta, DetalleVenta>
                {
                    Header = lstVenta[0],
                    Detail = lstDetalleVen,
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
                    TemplateName = "Venta",
                    PaperWidth = 80
                };
                FunGeneral.fnImprimirVoucher(printRequest);
            }
            else
            {
                Int32 idVenta = 0;
                frmImpresion frmImpre = new frmImpresion();
                idVenta = Convert.ToInt32(txtidVenta.Text.Trim());
                frmImpre.fnInicio(0, "Imprimir Documento de Venta", idVenta);
            }
        }

        private void lvVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            String cResul = "";
            cResul = fnListarDocumentoVenta();
            if (cResul.Trim() != "OK")
            {
                MessageBox.Show(cResul, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOpcionesProducto frmProducto = new frmOpcionesProducto();
            frmProducto.ShowDialog();
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
                if (e.ColumnIndex == 2)
                {
                    if (dgvDetalleVenta.Rows[e.RowIndex].Cells[2].Value != null)
                    {
                        int idProductoGrilla = Convert.ToInt32(dgvDetalleVenta.Rows[e.RowIndex].Cells[2].Value.ToString() == "" ? 0 : dgvDetalleVenta.Rows[e.RowIndex].Cells[2].Value);
                        if (idProductoGrilla > 0)
                        {
                            bool lbResul = false;
                            string strOutMensaje = string.Empty;
                            lbResul = fnDevolverProducto(idProductoGrilla, 10, out strOutMensaje);

                            if (lbResul == false)
                            {
                                MessageBox.Show(strOutMensaje, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }

                        }
                        else
                        {
                            LimpiarFilaGrilla(dgvDetalleVenta.Rows[e.RowIndex]);
                            MessageBox.Show("Ingrese Codigo de Producto Correcto", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        LimpiarFilaGrilla(dgvDetalleVenta.Rows[e.RowIndex]);
                        MessageBox.Show("Ha ocurrido un Error al Buscar Producto. Comunicar a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                if (e.ColumnIndex != 5)
                {
                    SendKeys.Send("{up}");
                    SendKeys.Send("{right}");
                }
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

        private Boolean fnCalcularTotal()
        {

            int i = 0;
            decimal lnSubTotal = 0;
            clsUtil objUtil = new clsUtil();
            try
            {

                for (i = 0; i <= dgvDetalleVenta.Rows.Count - 1; i++)
                {
                    lnSubTotal = lnSubTotal + Convert.ToDecimal(dgvDetalleVenta.Rows[i].Cells[11].Value);
                }
                txtSubTotal.Text = Convert.ToString(Math.Round(lnSubTotal / ((lnIGV / 100) + 1), 2));
                txtIGV.Text = Convert.ToString(Math.Round(lnSubTotal - lnSubTotal / ((lnIGV / 100) + 1), 2));
                txtTotal.Text = Convert.ToString(Math.Round(lnSubTotal, 2)); 

                return true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmDocumentoVenta", "fnCalcularTotal", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
            }

        }

        private void LimpiarFilaGrilla(DataGridViewRow fila)
        {
            fila.Cells[1].Value = "";
            fila.Cells[3].Value = "";
            fila.Cells[4].Value = "";
            fila.Cells[5].Value = "";
            fila.Cells[6].Value = "";
            fila.Cells[7].Value = "";
            fila.Cells[8].Value = "";
            fila.Cells[9].Value = "";
            fila.Cells[10].Value = "";
            fila.Cells[11].Value = "0";
        }

        private void dgvDetalleVenta_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Boolean lbResul = false;
            if (dgvDetalleVenta.Rows.Count > 0)
            {
                if (e.ColumnIndex == 7 || e.ColumnIndex == 9 || e.ColumnIndex == 10)
                {
                    decimal cantidad = Convert.ToDecimal(dgvDetalleVenta.Rows[e.RowIndex].Cells[7].Value == null ? 0 : dgvDetalleVenta.Rows[e.RowIndex].Cells[7].Value.ToString() =="" ? 0 : dgvDetalleVenta.Rows[e.RowIndex].Cells[7].Value);
                    decimal precio = Convert.ToDecimal(dgvDetalleVenta.Rows[e.RowIndex].Cells[9].Value == null ? 0 : dgvDetalleVenta.Rows[e.RowIndex].Cells[9].Value.ToString() == "" ? 0 : dgvDetalleVenta.Rows[e.RowIndex].Cells[9].Value);
                    decimal descuento = Convert.ToDecimal(dgvDetalleVenta.Rows[e.RowIndex].Cells[10].Value == null ? 0 : dgvDetalleVenta.Rows[e.RowIndex].Cells[10].Value.ToString() == "" ? 0 : dgvDetalleVenta.Rows[e.RowIndex].Cells[10].Value);
                    if (dgvDetalleVenta.Rows[e.RowIndex].Cells[5].Value != null)
                    {
                        if (dgvDetalleVenta.Rows[e.RowIndex].Cells[5].Value.ToString() != "")
                        {
                            dgvDetalleVenta.Rows[e.RowIndex].Cells[11].Value = Math.Round((cantidad * precio) - (cantidad * precio * descuento), 2);
                            lbResul = fnCalcularTotal();
                            if (lbResul == false)
                            {
                                MessageBox.Show("Ha ocurrido un Error al Calcular Totales de Documento de Venta", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                    }
                }
              
            }
        }

        private void buscarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boolean lbResul = false;
            string stroutMensaje = string.Empty;
            if (lidProducto > 0)
            {
                    lbResul = fnDevolverProducto(lidProducto, 8, out stroutMensaje);

                    if (lbResul == false)
                    {
                        MessageBox.Show(stroutMensaje, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }                 

                    lbResul = fnCalcularTotal();
                    if (lbResul == false)
                    {
                        MessageBox.Show("Ha ocurrido un Error al Calcular Documento de Venta. Comunicar a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Boolean lbResul = false;
            frmOpcionesProducto frmProducto = new frmOpcionesProducto();
            frmProducto.Inicio(2);
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

        private void dgvDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean lbResul = false;
            string stroutMensaje = string.Empty;
            if (e.ColumnIndex == dgvDetalleVenta.Columns["btnNuevo"].Index && e.RowIndex >= 0)
            {
                lidProducto = 0;
                Consultas.frmBuscarLote frmBuscar = new Consultas.frmBuscarLote();
                frmBuscar.fnInicio(3, 0,0);
                frmBuscar.ShowDialog();

                if (lidProducto > 0)
                {

                    lbResul = fnDevolverProducto(lidProducto, 10, out stroutMensaje);

                    if (lbResul == false)
                    {
                        MessageBox.Show(stroutMensaje, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    lbResul = fnCalcularTotal();
                    if (lbResul == false)
                    {
                        MessageBox.Show("Ha ocurrido un Error al Calcular Documento de Venta. Comunicar a Administrador de Sistema", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }

        }

        private void dgvDetalleVenta_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowCount > 0)
            {
                fnCalcularTotal();
            }
        }

        private void dgvDetalleVenta_CellEnter(object sender, DataGridViewCellEventArgs e)
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

        private void dgvDetalleVenta_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvDetalleVenta.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
