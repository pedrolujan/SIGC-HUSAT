using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Siticone.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Mantenedores;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmOrdenCompraEquipos : Form
    {
        public frmOrdenCompraEquipos()
        {
            InitializeComponent();
        }
       
        Boolean estPasoLoad;
        static Int32 tabInicio;
        Boolean estActualizar;
        Boolean estTipoIngreso,estFechaIngreso, estCboEstado, estFechaCompra, estNroDocumento, estCboProveedor, estTabla,estObservacion,estEstadoExterno,estObservacionExterna,estMoneda,estOrdencompra;
        String msjTipoIngreso,msjFechaIngreso, msjCboEstado, msjFechaCompra, msjNroDocumento, msjCboProveedor,msjTabla,msjObservacion,msjEstadoExterno,msjObservacionExterno,msjMoneda,msjOrdencompra;

        Int16 lnTipoLlamada = 0;
        Int16 lnTipoCon = 0;
        static String lcProveedor = "";
        static String lcDireccion = "";
        static String lcNroDoc = "";
        static Int32 lidProducto = 0;
        static String lcNomProd = "";
        
        static String cTipoPago = "";
        static Decimal nMontoPagar = 0;
        static Double lnIGV = 0;
        static Double lnEnvio = 0;
        static Double lnOtrosCargos = 0;
        static String lnSimbolo = "";
        static List<Moneda> lstMonedaSimbolo = null;
        Boolean estDesplegar = false;
        



        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            tabControl.SelectedIndex = 1;
            ShowDialog();
        }
       
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

                lstProvee = objProvee.blListarProveedor(Convert.ToInt32(cboProveedor.SelectedValue)).ToArray();
                if (lstProvee.GetLength(0) > 0)
                {
                    txtDireccion.Text = Convert.ToString(lstProvee[0].cDireccion);
                    txtRuc.Text = Convert.ToString(lstProvee[0].cDocumento);
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

            gbCompra.Enabled = pbHabilitar;
            gbProveedor.Enabled = pbHabilitar;
            dgCompraEquipos.Enabled = pbHabilitar;
            gbBuscar.Visible = pnTipoLlamda == 3 ? pbHabilitar : !pbHabilitar;
            btnGuardar.Enabled = pbHabilitar;
        }

        private Boolean fnListarProveedorActivo(Boolean pbEstado,SiticoneComboBox cbo,Boolean buscar, String codTipoOrden)
        {
            BLProveedor objCliente = new BLProveedor();
            clsUtil objUtil = new clsUtil();
            List<Proveedor> lsProveedor = new List<Proveedor>();
            
            try
            {
                lsProveedor = objCliente.blListarProveedores(pbEstado,buscar,codTipoOrden);
                cbo.DataSource = null;
                cbo.ValueMember = "idProveedor";
                cbo.DisplayMember = "cNomProveedor";
                cbo.DataSource = lsProveedor;

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
                bResul = fnListarProveedorActivo(true,cboProveedor,false, Convert.ToString(cboOrdenCompra.SelectedValue));
                if (bResul == false)
                    return false;
                cboProveedor.Text = lcProveedor;
                txtDireccion.Text = lcDireccion;
                txtRuc.Text = lcNroDoc;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnObtenerProveedor", ex.Message);
                return false;
            }
        }

        private void fnCargarCombobox()
        {
            Boolean bResult = false;
            //fnLlenarcboOrdenCompra
            bResult=FunGeneral.fnLlenarTablaCodTipoCon(cboOrdenCompra, "TIOC", false);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Tipo de Orden Compra", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboTipoIngreso, "TIOI", false);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Tipo de Orden de Ingreso", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboTipoIngresoBuscar, "TIOI", true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Tipo de Orden de Ingreso Buscar", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboEstado, "ESDO00", false);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar TablaCod - Estado del Documento de Venta", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboEstadoBuscar, "ESDO00", true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar TablaCod - Estado del Documento de Venta", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = fnLlenarCboMoneda(cboMoneda, 0, false);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar CboMoneda", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboBuscarTipoOrden, "TIOC", true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Tipo de Orden Compra", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboseleccioningreso, "TIOC", true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Tipo de Orden Compra", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }


        }

        public static Boolean fnLlenarCboMoneda(ComboBox cboCombo, Int32 idMoneda, Boolean buscar)
        {
            BLMoneda objMoneda = new BLMoneda();
            clsUtil objUtil = new clsUtil();
            List<Moneda> lstMoneda = new List<Moneda>();

            try
            {
                lstMoneda = objMoneda.blDevolverMoneda(idMoneda, buscar);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "idMoneda";
                cboCombo.DisplayMember = "cNombre";
                cboCombo.DataSource = lstMoneda;

                lstMonedaSimbolo = lstMoneda;

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
                objMoneda = null;
                lstMoneda = null;
            }

        }
        private void frmOrdenCompraEquipos_Load(object sender, EventArgs e)
        {
            estPasoLoad = false;
            Boolean bResult = false;
            Cargo[] arrParametro2 = new Cargo[1];
            clsUtil objUtil = new clsUtil();
           

            try
            {
                cboEstadoExterno.SelectedIndex = 0;
                FunValidaciones.fnColorBotones(btnNuevo1, btnEditar, btnGuardar, btnSalir);
                
                DateTime fechaInicial = Variables.gdFechaSis.AddDays(- 30);
                DateTime fechaFinal = Variables.gdFechaSis;
                dtpFechaInicio.Value = fechaInicial;
                dtpFechaFinal.Value = fechaFinal;
                if (lnTipoLlamada == 0)
                {
                    fnCargarCombobox();

                   
                    
                    
                }else if (lnTipoLlamada == 1)
                {
                    tabControl.TabPages.RemoveAt(2);
                    tabControl.TabPages.RemoveAt(0);
                    

                }
                btnNuevo_Click(sender, e);
                gbPaginacion.Visible = false;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "frmOrdenCompra_Load", ex.Message);
            }
            finally
            {
                objUtil = null;
                arrParametro2 = null;
                estPasoLoad = true;
            }
        }

        

        private void cboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cboProveedor.SelectedValue == null || Convert.ToInt32(cboProveedor.SelectedValue.ToString()) == 0)
            {
                txtRuc.Text = "";
                txtDireccion.Text = "";
               
            }
           
            else
            {
                Boolean lbResult = false;
                lbResult = fnListarProveedorEspecifico();
                if (!lbResult)
                {
                    cboProveedor.SelectedIndex = 0;
                    MessageBox.Show("Error al Obtener Proveedor Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            var result = Funciones.FunValidaciones.fnValidarCombobox(cboProveedor, erProveedor, imgProveedor);
            estCboProveedor = result.Item1;
            msjCboProveedor = result.Item2;

            for (int i = 0; i < dgCompraEquipos.Rows.Count; i++)
            {
                dgCompraEquipos.Rows[i].Cells[0].Value = null;
                dgCompraEquipos.Rows[i].Cells[0].Style.BackColor = Color.White;
                dgCompraEquipos.Rows[i].Cells[1].Value = null;
                dgCompraEquipos.Rows[i].Cells[3].Value = null;
                dgCompraEquipos.Rows[i].Cells[4].Value = null;

                fnCalcularTotal();


                //dgCompraEquipos.Rows[i].Cells[1].Value = "";
                //dgCompraEquipos.Rows[i].Cells[0].Value = "";
                //dgCompraEquipos.Rows[i].Cells[3].Value = "";
                //dgCompraEquipos.Rows[i].Cells[4].Value = "";
                //dgCompraEquipos.Rows[i].Cells[5].Value = "";

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

        private void dgCompraEquipos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgCompraEquipos.Columns[e.ColumnIndex].Name == "btnNuevo" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgCompraEquipos.Rows[e.RowIndex].Cells["btnNuevo"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\search.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgCompraEquipos.Rows[e.RowIndex].Height =  30;
                this.dgCompraEquipos.Columns[e.ColumnIndex].Width = 30;
                

                e.Handled = true;

                
            }

            if (e.ColumnIndex >= 0 && this.dgCompraEquipos.Columns[e.ColumnIndex].Name == "btnEliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celBoton2 = this.dgCompraEquipos.Rows[e.RowIndex].Cells["btnEliminar"] as DataGridViewButtonCell;
                Icon icoAtomico2 = new Icon(Application.StartupPath + @"\delete.ico");
                
                e.Graphics.DrawIcon(icoAtomico2, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.dgCompraEquipos.Rows[e.RowIndex].Height = 30;
                this.dgCompraEquipos.Columns[e.ColumnIndex].Width = 30;

                e.Handled = true;
            }

        }


        private Boolean fnCalcularTotal()
        {
            clsUtil objUtil = new clsUtil();
            
            int i = 0;
            Double lnTotalTabla = 0;
            Double lnSubTotal = 0;
            
            lnEnvio = Convert.ToDouble(txtEnvio.Text.ToString() == "" ? "0" : txtEnvio.Text.ToString());
            lnOtrosCargos = Convert.ToDouble(txtOtrosCargos.Text.ToString() == "" ? "0" : txtOtrosCargos.Text.ToString());
            try
            {

                for (i = 0; i <= dgCompraEquipos.Rows.Count - 1; i++)
                {
                    lnTotalTabla = lnTotalTabla + Convert.ToDouble(dgCompraEquipos.Rows[i].Cells[5].Value);

                }
               
                txtSubTotal.Text = lnSimbolo + " " + String.Format("{0:0.00}",lnTotalTabla);
                lnSubTotal = lnTotalTabla + lnEnvio;
                
                Double lnTotalIGV =(lnSubTotal * lnIGV);
                txtIGV.Text = lnSimbolo + " " + String.Format("{0:0.00}", lnTotalIGV);
                txtTotal.Text = lnSimbolo + " " + String.Format("{0:0.00}", (lnSubTotal + lnTotalIGV + lnOtrosCargos));

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
        private void fnLimpiarControles()
        {

            BLCargo objCargo = new BLCargo();

            /////TEXBOXS/////
            txtIdCompra.Text = "0";
            txtDocumento.Text = "";
            txtRuc.Text = "";
            txtDireccion.Text = "";
            txtSubTotal.Text = "0";
            txtTotal.Text = "0";
            txtIGV.Text = "0";
            txtOtrosCargos.Text = "0";
            txtEnvio.Text = "0";
            txtObservacion.Text = "";
            txtActualizar.Text = "";
            txtObservacionExterna.Text = "";
            
            txtDocumentoVer.Visible = false;
            txtDocumentoVer.Text = "";
            
            /////COMBOBOXS////
            cboProveedor.SelectedValue = 0;
            cboEstado.SelectedValue = "0";
            cboMoneda.SelectedValue = 0;
            cboEstadoExterno.SelectedIndex = 0;
            cboMoneda.Enabled = true;
            
            /////FECHAS/////
            dtpFechaCompra.Value = Variables.gdFechaSis;
            dtpFechaIngreso.Value = Variables.gdFechaSis;

            /////DATAGRIDS/////
            dgCompraEquipos.DataSource = null;
            dgCompraEquipos.Rows.Clear();

            /////LABELS/////
            erFechaIngreso.Text = "";
            erNroDocumento.Text = "";
            erEstado.Text = "";
            erFechaCompra.Text = "";
            erProveedor.Text = "";
            erTabla.Text = "";
            erEstadoExterna.Text = "";
            erObservacionExterno.Text = "";
            erMoneda.Text = "";
            erObservacion.Text = "";
            verHistorialOrden.Visible = false;
            lblVerDocumento.Visible = false;

            /////PICTURBOXS/////
            imgTipoOrden.Image = null;
            imgFechaIngreso.Image = null;
            imgNrDocumento.Image = null;
            imgEstado.Image = null;
            imgFechaCompra.Image = null;
            imgProveedor.Image = null;
            imgTotal.Image = null;
            imgEstadoExterno.Image = null;
            imgMoneda.Image = null;
            imgObservacion.Image = null;
            imgObservacionExterno.Image = null;

            gbBuscar.Visible = true;
            gbCompra.Height = 192;
            verSeparacion.Visible = false;

        }

        private void fnEditar(Int16 tipoCon, Boolean estado)
        {
            if(tipoCon == 1)
            {
                gbTipoIngreso.Enabled = estado;
                gbCompra.Enabled = estado;

                gbProveedor.Enabled = estado;
                dgCompraEquipos.Enabled = estado;
                txtEnvio.Enabled = estado;
                txtOtrosCargos.Enabled = estado;
                chkIncluirIGV.Enabled = estado;
            }
            else if (tipoCon == 2 )
            {
                String codItem = cboTipoIngreso.SelectedValue == null ? "NULL" : cboTipoIngreso.SelectedValue.ToString();

                if (codItem == "TIOI0001")
                {
                    gbCompra.Enabled = estado;
                    txtDocumento.Enabled = true;


                    dtpFechaCompra.Enabled = false;
                    ///////////////////////////////
                    cboMoneda.Enabled = false;                      
                    //////////////////////////////
                }
                else
                {
                   
                    gbTipoIngreso.Enabled = estado;
                    cboTipoIngreso.Enabled = false;
                    dtpFechaIngreso.Enabled = false;

                }
                    
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            cboOrdenCompra.Enabled = true;
            cboOrdenCompra.SelectedValue = "0";
            cboTipoIngreso.SelectedValue = "0";
            fnLimpiarControles();
            FunValidaciones.fnHabilitarBoton(btnNuevo1, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, true);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            lblFechaIngreso.Visible = false;
            lblEstado.Visible = false;
            cboEstadoExterno.Visible = false;
            gbTipoIngreso.Enabled = true;
            cboTipoIngreso.Enabled = false;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void _SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;

            if (combo != null)
            {
                combo.SelectAll();
            }

        }
        private void dgCompraEquipos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

                if (dgCompraEquipos.CurrentCell.ColumnIndex == 0) //Desired Column
                {

                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
                    }
                }

                else if (dgCompraEquipos.CurrentCell.ColumnIndex == 3) //Desired Column
                {

                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
                else if (dgCompraEquipos.CurrentCell.ColumnIndex == 4) //Desired Column
                {

                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
            }
        }
        private Boolean fnValidarUltimaCelda(DataGridView dtg, Int32 i ,Int32 j)
        {
            String cell = dtg.Rows[i].Cells[j].Value == null ? "" : dgCompraEquipos.Rows[i].Cells[j].Value.ToString();
            if(cell == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Tuple<Boolean, String> fnValidarTabla(DataGridView dtg, Label lbl, PictureBox img)
        {
            DataTable dtDetalleCompra = new DataTable();
            Int32 i ,j;
            String msj;
            Boolean cel1, cel2, cel4, cel5, cel6;

            Int32 numFilas = (dtg.Rows.Count - 1 == 0 ? 1 : dtg.Rows.Count);

            int[] codigosEquipo = new int[numFilas];

            for (i = 0; i <= dtg.Rows.Count - 1; i++)
            {

                cel1 = fnValidarUltimaCelda(dtg, i, 0);
                cel2 = fnValidarUltimaCelda(dtg, i, 1);
                cel4 = fnValidarUltimaCelda(dtg, i, 3);
                cel5 = fnValidarUltimaCelda(dtg, i, 4);
                cel6 = fnValidarUltimaCelda(dtg, i, 5);

                if(cel1 && cel2 && cel4 && cel5 && cel4 && cel6)
                {
                    if(dtg.Rows.Count == 1)
                    {
                        img.Image = Properties.Resources.error;
                        msj = "Complete la tabla correctamente";
                        lbl.Text = msj;

                        return Tuple.Create(false, msj);
                    }

                }
                else
                {
                    Int32 codigo = Convert.ToInt32(dgCompraEquipos.Rows[i].Cells[0].Value == null ? "0" : dgCompraEquipos.Rows[i].Cells[0].Value.ToString());
                    Boolean repetido = codigosEquipo.Contains(codigo);
                    if (repetido)
                    {
                        dgCompraEquipos.Rows[i].Cells[0].Style.BackColor = Color.FromArgb(255, 204, 187);
                        img.Image = Properties.Resources.error;
                        msj = "No se pueden repetir los mismos equipos en una Orden de Compra\nCorrija la celda sombreada";
                        lbl.Text = msj;

                        return Tuple.Create(false, msj);
                    }
                    else
                    {
                        codigosEquipo[i] = codigo;
                        for (j = 0; j < dtg.Columns.Count; j++)
                        {

                            if (!(j == 2 || j == 6 || j == 7))
                            {
                                String celda = dgCompraEquipos.Rows[i].Cells[j].Value == null ? "" : dgCompraEquipos.Rows[i].Cells[j].Value.ToString();
                                if (celda == "")
                                {
                                    dgCompraEquipos.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(255, 204, 187);                                   img.Image = Properties.Resources.error;
                                    msj = "Ingrese datos en la celda sombreada";
                                    lbl.Text = msj;

                                    return Tuple.Create(false, msj);

                                }
                                else
                                {
                                   
                                    codigosEquipo[i] = codigo;
                                    dgCompraEquipos.Rows[i].Cells[j].Style.BackColor = Color.White;
                                   

                                }
                            }


                        }
                        
                        
                    }
                    
                }
 
            }

            img.Image = Properties.Resources.ok;
            msj = "";
            lbl.Text = msj;

            return Tuple.Create(true, msj);

        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            String valorComboEstado = cboEstado.SelectedValue == null ? "0" : cboEstado.SelectedValue.ToString();
            
            if(lnTipoCon == 1)
            {
                if (valorComboEstado == "ESDO0003")
                {
                    gbCompra.Height = 308;
                }
                else
                {
                    gbCompra.Height = 192;

                }
            }
            
            var result = fnValidarComboboxEstadoPago(cboEstado, erEstado, imgEstado,lnTipoCon);
            estCboEstado = result.Item1;
            msjCboEstado = result.Item2;
        }

        public static Tuple<Boolean, String> fnValidarComboboxEstadoPago(SiticoneComboBox cbo, Label lbl, PictureBox img, Int32 TipoCon)
        {
            String msj;

            if (cbo.SelectedIndex == 0 || cbo.SelectedIndex == -1 || cbo.SelectedIndex == null)
            {
                img.Image = Properties.Resources.error;


                lbl.ForeColor = Variables.ColorError;

                msj = "Seleccione una opción";
                lbl.Text = msj;
                return Tuple.Create(false, msj);

            }
            else if (TipoCon == 0)
            {
                String valorSelect = cbo.SelectedValue == null ? "0" : cbo.SelectedValue.ToString();
                if (valorSelect == "ESDO0003")
                {
                    img.Image = Properties.Resources.error;


                    lbl.ForeColor = Variables.ColorError;

                    msj = "Opción no valida para registro";
                    lbl.Text = msj;
                    return Tuple.Create(false, msj);
                }
                else{

                    img.Image = Properties.Resources.ok;
                    lbl.ForeColor = Variables.ColorSuccess;

                    msj = "";
                    lbl.Text = msj;
                    return Tuple.Create(true, msj);
                }
                
            }
            else
            {

                img.Image = Properties.Resources.ok;

                lbl.ForeColor = Variables.ColorSuccess;
                msj = "";
                lbl.Text = msj;
                return Tuple.Create(true, msj);


            }
        }

        public static Tuple<Boolean, String> fnValidarComboboxEstadoExterno(SiticoneComboBox cbo, Label lbl, PictureBox img, Int32 TipoCon)
        {
            String msj;

            if (cbo.SelectedIndex == 0 || cbo.SelectedIndex == -1 || cbo.SelectedIndex == null)
            {
                img.Image = Properties.Resources.error;


                lbl.ForeColor = Variables.ColorError;

                msj = "Seleccione una opción";
                lbl.Text = msj;
                return Tuple.Create(false, msj);

            }
            else if (TipoCon == 0)
            {
                
                if (cbo.SelectedIndex == 2)
                {
                    img.Image = Properties.Resources.error;


                    lbl.ForeColor = Variables.ColorError;

                    msj = "Opción no valida para registro";
                    lbl.Text = msj;
                    return Tuple.Create(false, msj);
                }
                else
                {

                    img.Image = Properties.Resources.ok;
                    lbl.ForeColor = Variables.ColorSuccess;

                    msj = "";
                    lbl.Text = msj;
                    return Tuple.Create(true, msj);
                }

            }
            else
            {

                img.Image = Properties.Resources.ok;

                lbl.ForeColor = Variables.ColorSuccess;
                msj = "";
                lbl.Text = msj;
                return Tuple.Create(true, msj);


            }
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {

            var result = fnValidarTexboxSQL(txtDocumento, erNroDocumento, imgNrDocumento, true, 7);
            estNroDocumento = result.Item1;
            msjNroDocumento = result.Item2;
        }

        private Tuple<Boolean, String> fnValidarTexboxSQL(SiticoneTextBox txt, Label lbl, PictureBox img, Boolean maximo, Int32 num)
        {
            String msj;
            Boolean bResul;
            Int16 pnTipocon = 0;

            if (txt.Text == null || txt.Text.Trim() == "")
            {
                img.Image = Properties.Resources.error;
                msj = "Ingrese datos (campo obligatorio)";
                lbl.Text = msj;

                return Tuple.Create(false, msj);

            }
            else if (estActualizar)
            {

                if (maximo)
                {
                    Int32 lengtDocuemento = txtDocumento.Text.Length;
                    if (lengtDocuemento < num)
                    {
                        img.Image = Properties.Resources.error;
                        msj = "Mínimo 8 caracteres";
                        lbl.Text = msj;
                        return Tuple.Create(false, msj);
                    }
                    else
                    {
                        if (txtActualizar.Text.Trim() == txt.Text.Trim())
                        {
                            img.Image = Properties.Resources.ok;
                            msj = "";
                            lbl.Text = msj;

                            return Tuple.Create(true, msj);
                        }
                        else
                        {
                            img.Image = Properties.Resources.ok;
                            msj = "";
                            lbl.Text = msj;
                            bResul = fnBuscarDocumentoOrden(txt.Text.Trim(), pnTipocon);
                            return Tuple.Create(bResul, msj);

                        }
                    }

                }
                else
                {
                    img.Image = Properties.Resources.error;
                    msj = "Mínimo 8 caracteres";
                    lbl.Text = msj;
                    return Tuple.Create(false, msj);
                }


               

            }
            else
            {
                if (maximo)
                {
                    Int32 lengtDocuemento = txtDocumento.Text.Length;
                    if(lengtDocuemento < num)
                    {
                        img.Image = Properties.Resources.error;
                        msj = "Mínimo 8 caracteres";
                        lbl.Text = msj;
                        return Tuple.Create(false, msj);
                    }
                    else
                    {
                        img.Image = Properties.Resources.ok;
                        msj = "";
                        lbl.Text = msj;
                        bResul = fnBuscarDocumentoOrden(txt.Text.Trim(), pnTipocon);
                        return Tuple.Create(bResul, msj);
                    }
                    
                }
                else
                {
                    img.Image = Properties.Resources.error;
                    msj = "Mínimo 8 caracteres";
                    lbl.Text = msj;
                    return Tuple.Create(false, msj);
                }
                

            }


        }

        private Boolean fnBuscarDocumentoOrden(String pcBuscar, Int16 pnTipoCon)
        {
            BLOrdenCompra objPlan = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            Int16 numResult = 0;

            if(cboBuscarTipoOrden.Text=="SIM CARD")
            {
                pnTipoCon = 1;
            }
            else if (cboBuscarTipoOrden.Text == "EQUIPOS")
            {
                pnTipoCon = 0;
            }



            try
            {
                numResult = objPlan.blBuscarDocumentoOrden(pcBuscar,pnTipoCon);

                if (numResult == 1)
                {
                    erNroDocumento.Text = "Este Documento ya existe (Ingrese otro)";
                    erNroDocumento.ForeColor = Color.Red;
                    imgNrDocumento.Image = Properties.Resources.error;
                    return false;
                }
                else if (numResult == 0)
                {
                    erNroDocumento.Text = "";
                    imgNrDocumento.Image = Properties.Resources.ok;
                    return true;
                }
                else
                {
                    erNroDocumento.Text = "Ocurrió otro error";
                    erNroDocumento.ForeColor = Color.Red;
                    imgNrDocumento.Image = Properties.Resources.error;
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorio", "fnBuscarAccesorio", ex.Message);
                return false;
            }
            finally
            {

                objPlan = null;
                objUtil = null;
            }
        }

        private void dtpFechaCompra_ValueChanged(object sender, EventArgs e)
        {
            var result = fnValidarFecha(dtpFechaCompra, imgFechaCompra, erFechaCompra);
            estFechaCompra = result.Item1;
            msjFechaCompra = result.Item2;
        }

        private Tuple<Boolean, String> fnValidarFecha(SiticoneDateTimePicker dtp, PictureBox img, Label lbl)
        {
            String msj;
            String dateSelectText = dtp.Value.ToString("dd-MM-yyyy");
            String dateSistemText = DateTime.Today.ToString("dd-MM-yyyy");

            DateTime dateSelect = Convert.ToDateTime(dateSelectText);
            DateTime dateSistem = Convert.ToDateTime(dateSistemText);
            if ((dtp.Value.AddYears(10) <= DateTime.Today))
            {
                msj = "Fecha de compra no puede ser mayor a 10 años";
                lbl.Text = msj;
                lbl.ForeColor = Color.Red;
                img.Image = Properties.Resources.error;
                
                return Tuple.Create(false, msj);
            }
            else if (dateSelect > dateSistem)
            {
                msj = "Fecha de compra no puede ser mayor a hoy";
                lbl.Text = msj;
                lbl.ForeColor = Color.Red;
                img.Image = Properties.Resources.error;
               
                return Tuple.Create(false, msj);
            }
            else
            {
                msj = "";
                lbl.Text = msj;
                img.Image = Properties.Resources.ok;
                lbl.ForeColor = Color.Green;

                return Tuple.Create(true, msj);

            }

        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "DIRECCION", true,erNroDocumento);
        }

        static String  cellNombreEquipo = "";
        static Int32 cellidEquipo;
        public static void fnObtenerEquipo(Int32 idEquipo, String marca,String modelo,String nombre)
        {
            cellidEquipo = idEquipo;
            cellNombreEquipo = nombre+ " (Marca: " +marca + ", Modelo: " + modelo + ")" ;
            
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

                for (i = 0; i <= dgCompraEquipos.Rows.Count - 1; i++)
                {
                    if (dgCompraEquipos.Rows[i].IsNewRow == false)
                    {
                        drFila = dtDetalleCompra.NewRow();
                        for (j = 0; j <= dtDetalleCompra.Columns.Count; j++)
                        {
                            if (j == 1)
                                drFila[j] = Convert.ToInt32(txtIdCompra.Text.Trim());
                            else if (j == 4 || j == 5 || j == 6)
                                drFila[j - 1] = dgCompraEquipos.Rows[i].Cells[j + 1].Value == null ? 0 : dgCompraEquipos.Rows[i].Cells[j + 1].Value;
                            else if (j == 0 || j == 2)
                                drFila[j] = dgCompraEquipos.Rows[i].Cells[j].Value == null ? 0 : dgCompraEquipos.Rows[i].Cells[j].Value;
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

        private void dtpFechaIngreso_ValueChanged(object sender, EventArgs e)
        {
            var result = fnValidarFecha(dtpFechaIngreso, imgFechaIngreso, erFechaIngreso);
            estFechaIngreso = result.Item1;
            msjFechaIngreso = result.Item2;
        }

        
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                String busqueda = txtBuscar.Text.Trim().ToString();
                fnBuscarTabla(busqueda,0,-1);
            }
        }

        private DateTime fnCalcularSoloFecha(DateTime fecha)
        {
            String TextSoloFecha = fecha.ToString("yyyy/MM/dd");
            DateTime dtFecha = Convert.ToDateTime(TextSoloFecha);
            return dtFecha;
        }

        private Boolean fnBuscarTabla(String pcBuscar, Int32 numPagina, Int32 tipoCon)
        {
            BLOrdenCompra objPlan = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();
            List<OrdenCompra> lstPlan = null;
            Int32 filas = 15;
            String tipocompra = cboBuscarTipoOrden.Text;

            try
            {
                lstPlan = new List<OrdenCompra>();

                String pnTipoIngreso = cboTipoIngresoBuscar.SelectedValue == null ? "0" : cboTipoIngresoBuscar.SelectedValue.ToString();
                String estPago = cboEstadoBuscar.SelectedValue == null ? "0" : cboEstadoBuscar.SelectedValue.ToString();
                DateTime fechaInicial = fnCalcularSoloFecha(dtpFechaInicio.Value);
                DateTime fechaFinal = (fnCalcularSoloFecha(dtpFechaFinal.Value)).AddDays(1);
                Int32 idProveedor = Convert.ToInt32(cboProveedorBuscar.SelectedValue == null ? "0" : cboProveedorBuscar.SelectedValue.ToString());

                Boolean habilitarFechas = Convert.ToBoolean(chkHabilitarFechas.Checked);

                datTipoPlan = objPlan.blBuscarOrdenDataTable(pcBuscar, pnTipoIngreso, estPago, fechaInicial, fechaFinal, numPagina, tipoCon, idProveedor, habilitarFechas, tipocompra);

                Int32 totalResultados = datTipoPlan.Rows.Count;




                DataTable dt = new DataTable();
                if (totalResultados > 0 && tipocompra == "EQUIPOS")
                {


                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("SUCURSAL");
                    dt.Columns.Add("TIPO ORDEN");
                    dt.Columns.Add("COD. INGRESO");
                    dt.Columns.Add("PROVEEDOR");
                    dt.Columns.Add("CANT. EQUIPOS");
                    dt.Columns.Add("ESTADO");
                    dt.Columns.Add("FECHA INGRESO");


                }


                if (tipocompra == "SIM CARD")
                {

                    dt.Clear();
                    dt.Columns.Add("idUsuario");
                    dt.Columns.Add("idRecibo");
                    dt.Columns.Add("Numero Recibo");
                    dt.Columns.Add("Proveedor");
                    dt.Columns.Add("Tipo Pago");
                    dt.Columns.Add("Tipo MOneda");
                    dt.Columns.Add("Tipo Compra");
                    dt.Columns.Add("FechaCompra");
                    dt.Columns.Add("dFechaRegistro");
                    
                    //return true;

                }






                        Int32 y;

                        if (tipoCon == -1)
                        {
                            y = 0;
                        }
                        else
                        {
                            tabInicio = (numPagina - 1) * filas;
                            y = tabInicio;
                        }
                        Boolean ingresoImeis;
                        for (int i = 0; i <= totalResultados - 1; i++)
                        {
                            y += 1;
                    var fecha= datTipoPlan.Rows[i][7];

                            DateTime fechatabla = Convert.ToDateTime(datTipoPlan.Rows[i][7]);

                            String fechaIngreso = fechatabla.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-ES"));
                            object[] row = {
                                    datTipoPlan.Rows[i][0],
                                    y,
                                    datTipoPlan.Rows[i][1],
                                    datTipoPlan.Rows[i][2],
                                    datTipoPlan.Rows[i][3],
                                    datTipoPlan.Rows[i][4],
                                    datTipoPlan.Rows[i][5],
                                    datTipoPlan.Rows[i][6],
                                    fechaIngreso
                                };

                            dt.Rows.Add(row);


                        }

                        dgOrdenIngreso.DataSource = dt;

                        dgOrdenIngreso.Columns[0].Visible = false;
                        dgOrdenIngreso.Columns[1].Width = 30;
                        dgOrdenIngreso.Columns[2].Width = 100;
                        dgOrdenIngreso.Columns[3].Width = 80;
                        dgOrdenIngreso.Columns[4].Width = 100;
                        dgOrdenIngreso.Columns[5].Width = 200;
                        dgOrdenIngreso.Columns[6].Width = 100;
                        dgOrdenIngreso.Columns[7].Width = 100;
                        dgOrdenIngreso.Columns[8].Width = 150;


                        dgOrdenIngreso.Visible = true;
                        if (tipoCon == -1)
                        {
                            gbPaginacion.Visible = true;
                            Int32 totalRegistros = Convert.ToInt32(datTipoPlan.Rows[0][8]);
                            fnCalcularPaginacion(totalRegistros, filas, totalResultados);
                        }
                        else
                        {
                            btnNumFilas.Text = Convert.ToString(totalResultados);
                        }


                        return true;
                    
                    //else
                    //{
                    //    //DataTable dt = new DataTable();
                    //    dt.Clear();
                    //    dt.Columns.Add("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS");
                    //    dgOrdenIngreso.DataSource = dt;
                    //    gbPaginacion.Visible = false;
                    //    return false;
                    //}


                

                //else
                //{
                //    DataTable dt = new DataTable();
                //    dt.Clear();
                //    dt.Columns.Add("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS");
                //    dgOrdenIngreso.DataSource = dt;
                //    gbPaginacion.Visible = false;
                //    return false;
                //} 

                


            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private void fnCalcularPaginacion(Int32 totalRegistros,Int32 filas,Int32 totalResultados)
        {
            Int32 residuo;
            Int32 cantidadPaginas;
            residuo = totalRegistros % filas;
            if(residuo == 0)
            {
                cantidadPaginas = (totalRegistros / filas);
            }
            else
            {
                cantidadPaginas = (totalRegistros / filas) + 1;
            }

            cboPagina.Items.Clear();

            for(Int32 i = 1; i <= cantidadPaginas; i++)
            {
                cboPagina.Items.Add(i); 

            }

            cboPagina.SelectedIndex = 0;
            btnTotalPaginas.Text = Convert.ToString(cantidadPaginas);
            btnNumFilas.Text = Convert.ToString(totalResultados);
            btnTotalRegistros.Text = Convert.ToString(totalRegistros);

            
        }
        private void dgOrdenIngreso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String tipocompra = cboBuscarTipoOrden.Text;
            estActualizar = true;

            if (lnTipoLlamada == 0)
            {
                if (tipocompra == "EQUIPOS")
                {

                    Boolean bResul;
                    bResul = fnListarOrdenIngresoEspecifico(e);
                    if (!bResul)
                    {
                        MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                }
                else
                {
                   
                    Boolean bresult;
                    bresult = fnListarOrdenIngresoSimCardEspecifico(e);
                    if (!bresult)
                    {
                        MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                }
          

            }
            else if (lnTipoLlamada == 1)
            {

            }
        }

        private Boolean fnListarOrdenIngresoSimCardEspecifico(DataGridViewCellEventArgs e)
        {
            clsUtil objutil = new clsUtil();
            Boolean bresult;
           

            try
            {
                if(dgCompraEquipos.Rows.Count>0)
                {
                    BLOrdenCompra objingreso = new BLOrdenCompra();
                    ordencompraSimCard lstsimcard = new ordencompraSimCard();
                    DataTable dtAccesorio = new DataTable();



                    lstsimcard = objingreso.blListarOrdenSimCardDGV(Convert.ToInt32(dgOrdenIngreso.Rows[e.RowIndex].Cells[0].Value));



                    String tipocompra = cboBuscarTipoOrden.Text;
                    estActualizar = true;
                    lnTipoCon = 1;
                    cboTipoIngreso.Text = Convert.ToString(lstsimcard.tipoingreso.ToString());
                    cboOrdenCompra.Text = tipocompra;
                    txtActualizar.Text = Convert.ToString(lstsimcard.numeroingreso.ToString().Trim());
                    txtDocumento.Text = Convert.ToString(lstsimcard.numeroingreso.ToString().Trim());
                    cboMoneda.Text = Convert.ToString(lstsimcard.moneda.ToString());
                    dtpFechaCompra.Value = Convert.ToDateTime(lstsimcard.fechacompra.ToString());
                    cboEstado.Text = Convert.ToString(lstsimcard.tipocompra.ToString());
                    cboProveedor.Text = Convert.ToString(lstsimcard.proveedor.ToString());
                    txtIdCompra.Text = Convert.ToString(lstsimcard.idordenSimCard.ToString());
                  

                    txtEnvio.Text = Convert.ToString(lstsimcard.envio);
                    txtOtrosCargos.Text = Convert.ToString(lstsimcard.otroscargos);

          

                    dgCompraEquipos.Rows[0].Cells[0].Value = lstsimcard.idordenSimCard;
                    dgCompraEquipos.Rows[0].Cells[1].Value = lstsimcard.operador;
                    dgCompraEquipos.Rows[0].Cells[3].Value = lstsimcard.cantidad;
                    dgCompraEquipos.Rows[0].Cells[4].Value = lstsimcard.precioUnitario;

                    gbProveedor.Enabled = false;
                    gbTipoIngreso.Enabled = false;
                    gbCompra.Enabled = false;
                    dgCompraEquipos.Enabled = false;
                    cboOrdenCompra.Enabled = false;
                    txtEnvio.Enabled = false;
                    txtOtrosCargos.Enabled = false;
                    tabControl.SelectedIndex = 0;


                    btnEditar.Enabled = true;

                }
                return true;
            }
            catch(Exception ex)
            {
                objutil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;


            }
        }

        private Boolean fnListarOrdenIngresoEspecifico(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            Boolean bResult;
           

            try
            {
                if (dgCompraEquipos.Rows.Count > 0)
                {
                    BLOrdenCompra objOrden = new BLOrdenCompra();
                    OrdenCompra lstOrden = new OrdenCompra();
                    DataTable dtAccesorio = new DataTable();
                    //String tipocompra = cboBuscarTipoOrden.Text;

                    lstOrden = objOrden.blListarOrdenDataGrid(Convert.ToInt32(dgOrdenIngreso.Rows[e.RowIndex].Cells[0].Value));

                   
                    estActualizar = true;
                    lnTipoCon = 1;
                    String tipoIngreso = lstOrden.cTipoPago.Trim();
                    cboTipoIngreso.SelectedValue = Convert.ToString(lstOrden.cTipoPago.Trim());
                    txtActualizar.Text = Convert.ToString(lstOrden.cDocumento.ToString().Trim());
                    dtpFechaIngreso.Value = Convert.ToDateTime(lstOrden.dFechaRegistro.ToString().Trim());
                    txtDocumento.Text = Convert.ToString(lstOrden.cDocumento.ToString().Trim());
                    txtDocumentoVer.Text = Convert.ToString(lstOrden.cDocumento.ToString().Trim());
                    if (tipoIngreso == "TIOI0001")
                    {
                        String valorEstado = Convert.ToString(lstOrden.iEstado.ToString().Trim());
                        cboEstado.SelectedValue = valorEstado;
                        txtObservacion.Text = Convert.ToString(lstOrden.observaciones.ToString().Trim());
                        if(valorEstado == "ESDO0003")
                        {
                            FunValidaciones.fnHabilitarBoton(btnEditar, false);
                        }
                        else
                        {
                            FunValidaciones.fnHabilitarBoton(btnEditar, true);
                        }

                    }
                    else
                    {
                        String valorEstado = lstOrden.iEstado.ToString().Trim();
                        if (valorEstado == "ESDO0003")
                        {
                            cboEstadoExterno.SelectedIndex = 2;
                        }
                        else
                        {
                            cboEstadoExterno.SelectedIndex = 1;
                        }
                           
                        txtObservacionExterna.Text = Convert.ToString(lstOrden.observaciones.ToString().Trim());

                    }
                    dtpFechaCompra.Value = Convert.ToDateTime(lstOrden.dFechaCompra.ToString());
                    cboProveedor.SelectedValue = Convert.ToInt32(lstOrden.idProveedor.ToString());
                    txtIdCompra.Text = Convert.ToString(lstOrden.idOrden.ToString().Trim());
                    cboMoneda.SelectedValue = Convert.ToInt32(lstOrden.idMoneda.ToString());
                    chkIncluirIGV.Checked = Convert.ToBoolean(lstOrden.chekIGV);
                    txtEnvio.Text = Convert.ToString(lstOrden.costoEnvio);
                    txtOtrosCargos.Text = Convert.ToString(lstOrden.otrosCostos);
                    bResult = fnListarDetalleIngreso(lstOrden.detalleCompra);

                    if (!bResult)
                    {
                        MessageBox.Show("Error al listar Detalle Ingreso", "Orden Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    

                    FunValidaciones.fnHabilitarBoton(btnNuevo1, true);
                    
                    FunValidaciones.fnHabilitarBoton(btnGuardar, false);
                    FunValidaciones.fnHabilitarBoton(btnSalir, true);
                    txtBuscar.Text = "";
                    
                    tabControl.SelectedIndex = 0;
                    verHistorialOrden.Visible = true;
                    txtDocumentoVer.Visible = true;
                    verSeparacion.Visible = true;
                    lblVerDocumento.Visible = true;
                    fnEditar(1, false);
                }


                return true;
            }
            catch (Exception ex)
            {

                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;


            }
        }

        private Boolean fnListarDetalleIngreso(String equipos)
        {
            clsUtil objUtil = new clsUtil();
            DataTable datatable = new DataTable();
            datatable = dgCompraEquipos.DataSource as DataTable;
            xmlDetalleIngreso.Items objAcc = new xmlDetalleIngreso.Items();
            try
            {

                    
                XmlSerializer serializer = new XmlSerializer(typeof(xmlDetalleIngreso.Items));
                using (TextReader reader = new StringReader(equipos))
                {
                    //de esta manera se deserializa
                    objAcc = (xmlDetalleIngreso.Items)serializer.Deserialize(reader);
                }
                dgCompraEquipos.Rows.Clear();
               
                for (Int32 i = 0; i <= objAcc.Item.Count - 1; i++)
                {

                    DataGridViewRow row = (DataGridViewRow)dgCompraEquipos.Rows[i].Clone();
                    dgCompraEquipos.Rows.Add(row);
                    dgCompraEquipos.Rows[i].Cells[0].Value = objAcc.Item[i].IdEquipo;
                    dgCompraEquipos.Rows[i].Cells[1].Value = objAcc.Item[i].Equipos;
                    dgCompraEquipos.Rows[i].Cells[3].Value = objAcc.Item[i].Cantidad;
                    dgCompraEquipos.Rows[i].Cells[4].Value = objAcc.Item[i].PrecioCompra;

                }
                
                return true;
               

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;

            }



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (estDesplegar)
            {
                gbCompra.Height = 308;
                estDesplegar = false;
            }
            else
            {
                gbCompra.Height = 192;
                estDesplegar = true;
            }
            
        }

        private void label21_Click(object sender, EventArgs e)
        {
            String busqueda = txtDocumento.Text.Trim().ToString();
            String ordencompra = cboseleccioningreso.Text;
            txtDocumentoHistorial.Text = busqueda;
            
            tabControl.SelectedIndex = 2;
            fnBuscarHistorial(busqueda, ordencompra);
        }

        //////////////////////////////////////////////////////////////////////////

        private void siticoneTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            if (e.KeyChar == (Char)Keys.Enter)
            {
                String ordencompra = cboseleccioningreso.Text;



                String busqueda = txtDocumentoHistorial.Text.Trim().ToString();

                fnBuscarHistorial(busqueda, ordencompra);
            }
        }



        //////////////////////////////////////////////////////////////////////////
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboTipoIngresoBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscar.Text.Trim().ToString();

                fnBuscarTabla(busqueda, 0, -1);
            }
            
        }

        private void cboEstadoBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscar.Text.Trim().ToString();

                fnBuscarTabla(busqueda, 0, -1);
            }
        }

        private void cboTipoIngresoBuscar_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cboEstadoBuscar_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            String busqueda = txtBuscar.Text.Trim().ToString();
            Int32 pagina = Convert.ToInt32(cboPagina.Text.ToString());

            fnBuscarTabla(busqueda, pagina, -2);
        }

        private void lblSubTotal_Click(object sender, EventArgs e)
        {

        }

        private void siticoneCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            fnValidarIGV();
        }

        private void fnValidarIGV()
        {
            if (chkIncluirIGV.Checked == true)
            {
                lnIGV = 0.18;
                fnCalcularTotal();
            }
            else
            {
                lnIGV = 0;
                fnCalcularTotal();

            }
        }

        private void txtEnvio_TextChanged_1(object sender, EventArgs e)
        {
            
            fnValidarIGV();
            fnCalcularTotal();
        }

        private void txtEnvio_Leave(object sender, EventArgs e)
        {
            if (txtEnvio.Text.ToString() == "")
            {
                txtEnvio.Text = "0";
            }
        }

        private void txtOtrosCargos_Leave(object sender, EventArgs e)
        {
            if (txtOtrosCargos.Text.ToString() == "")
            {
                txtOtrosCargos.Text = "0";
            }
        }

        private void dgOrdenIngreso_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            DataGridView dgv = sender as DataGridView;

            String nombreCabecera = dgv.Columns[e.ColumnIndex].HeaderText.ToString();

            if (nombreCabecera == "ESTADO")
            {
                String valorCelda = e.Value.ToString();
                if (valorCelda == "PAGADO")
                {

                    e.CellStyle.ForeColor = Variables.ColorSuccess;
                }
                else if (valorCelda == "PENDIENTE")
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }
                else
                {
                    e.CellStyle.ForeColor = Variables.ColorError;
                }

            }
            
            
        }

        private void cboProveedorBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscar.Text.Trim().ToString();

                fnBuscarTabla(busqueda, 0, -1);
            }
        }

        private void cboEstIngresoImeis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscar.Text.Trim().ToString();

                fnBuscarTabla(busqueda, 0, -1);
            }
        }

        private void dgHistorialEquipo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            String nombreCabecera = dgv.Columns[e.ColumnIndex].HeaderText.ToString();

            if (nombreCabecera == "ESTADO")
            {
                String valorCelda = e.Value.ToString();
                if (valorCelda == "PAGADO")
                {

                    e.CellStyle.ForeColor = Variables.ColorSuccess;
                }
                else if (valorCelda == "PENDIENTE")
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }
                else
                {
                    e.CellStyle.ForeColor = Variables.ColorError;
                }

            }
        }
        /// //////////////////////////////////////////////////////////////////////////////////////
        private void txtDocumento_Leave(object sender, EventArgs e)
        {

       
            

        
        }

        private void txtEnvio_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "MONEDA", false);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            String busqueda = txtBuscar.Text.Trim().ToString();
            fnBuscarTabla(busqueda, 0, -1);
        }

        //private Boolean fnLlenarcboOrdenCompra(Int32 idTabcod)
        //{
        //    BLOrdenCompra objOrdenCompra = new BLOrdenCompra();
        //    clsUtil objUtil = new clsUtil();
        //    DataTable dtResultados = new DataTable();
        //    List<TipoOrdenCompra> lstOrdenCompra = new List<TipoOrdenCompra>();
        //    try
        //    {
        //        lstOrdenCompra = objOrdenCompra.blDevolverTipoCompra(idTabcod);



        //         cboOrdenCompra.ValueMember = "idOrdenCompra";
        //        cboOrdenCompra.DisplayMember = "NombreOrdenCompra";
        //
        //
        //        .DataSource = lstOrdenCompra;




        //        return true;
        //    }
        //    catch (Exception ex)
        //    {

        //        return false;
        //    }
        //    finally
        //    {
        //        lstOrdenCompra = null;
        //    }
        //}

        private void siticoneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResult = false;
            bResult = fnListarProveedorActivo(true, cboProveedor, false, Convert.ToString(cboOrdenCompra.SelectedValue));
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Proveedores Activos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }


            String ordencompra = cboOrdenCompra.SelectedValue == null ? "NULL" : cboOrdenCompra.SelectedValue.ToString();

            if (ordencompra == "TIOC0001")
            {
                cboTipoIngreso.Enabled = true;
       
                txtDocumento.Enabled = true;
                cboTipoIngreso.SelectedIndex = 0;

            }
            else if (ordencompra == "TIOC0002")
            {
                cboTipoIngreso.Enabled = true;
                txtDocumento.Text = "";
                txtDocumento.Enabled = false;
                cboTipoIngreso.SelectedIndex = 0;

            }
        
            else 
            {
                
                cboTipoIngreso.Enabled = false;
                fnLimpiarControles();

                ////GROUPBOXS////
                gbCompra.Enabled = false;
                gbProveedor.Enabled = false;
                gbCompra.Visible = true;
                gbProveedor.Visible = true;

                /////TEXBOXS//////
                txtSubTotal.Visible = true;
                txtIGV.Visible = true;
                txtTotal.Visible = true;
                txtObservacionExterna.Visible = false;
                dtpFechaIngreso.Visible = false;

                /////LABELS/////
                lblEstado.Visible = false;
                lblFechaIngreso.Visible = false;
                erEstadoExterna.Visible = false;
                lblObservacionExterna.Visible = false;
                erObservacionExterno.Visible = false;
                txtEnvio.Enabled = false;
                txtOtrosCargos.Enabled = false;

                /////PICTUREBOXS////
                imgFechaIngreso.Visible = true;
                imgObservacionExterno.Visible = false;

                /////COMBOBOXS////
                cboEstadoExterno.Visible = false;
               

                ////TAMAÑOS Y POSICIONES DE DATAGRIDVIEW
                dgCompraEquipos.Location = new Point(12, 395); 
                dgCompraEquipos.Height = 138;
                dgCompraEquipos.Enabled = false;

                /////ESTADOS
                estNroDocumento = false;
                estCboEstado = false;
                estFechaCompra = false;
                estCboProveedor = false;
                estEstadoExterno = false;
                estObservacionExterna = false;
            }

            var result = FunValidaciones.fnValidarCombobox(cboOrdenCompra, erordencompra, pbordencompra);
            estOrdencompra = result.Item1;
            msjOrdencompra = result.Item2;

        }

        private void cboProveedor_Click(object sender, EventArgs e)
        {
          
        }

        private void txtEnvio_TextChanged(object sender, EventArgs e)
        {
            
            
            fnValidarIGV();
            fnCalcularTotal();
        }

        private void txtEnvio_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "MONEDA", false);
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboMoneda, erMoneda, imgMoneda);
            estMoneda = result.Item1;
            msjMoneda = result.Item2;

            Int32 itemSelect = Convert.ToInt32(cboMoneda.SelectedValue == null ? "0" : cboMoneda.SelectedValue.ToString());

            if(itemSelect != 0)
            {
                lnSimbolo = lstMonedaSimbolo[itemSelect].cSimbolo;
            }
            else
            {
                lnSimbolo = "";
            }
            

            fnCalcularTotal();
            
        }

        private void cboTipoIngresoBuscar_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cboBuscarTipoOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscar.Text.Trim().ToString();

                fnBuscarTabla(busqueda, 0, -1);
            }
        }

        private void dgOrdenIngreso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            String ordencompra = cboseleccioningreso.Text;



            String busqueda = txtDocumentoHistorial.Text.Trim().ToString();

            fnBuscarHistorial(busqueda, ordencompra);
        }

        private void cboseleccioningreso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDocumentoHistorial_TextChanged(object sender, EventArgs e)
        {

        }

        private Boolean fnBuscarHistorial(String pcBuscar,String ordencompra)
        {
            BLOrdenCompra objPlan = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();
           


            try
            {
                
                
                datTipoPlan = objPlan.blBuscarHistorialDataTable(pcBuscar, ordencompra);

                String TipoIngreso = cboTipoIngresoBuscar.SelectedValue.ToString();
                if (datTipoPlan.Rows.Count > 0)
                {
                   

                        DataTable dt = new DataTable();
                        dt.Clear();
                        dt.Columns.Add("N°");
                        dt.Columns.Add("COD. DOCUMENTO");
                        dt.Columns.Add("ESTADO");
                        dt.Columns.Add("OBSERVACION");
                        dt.Columns.Add("FECHA DE CAMBIO");
                        dt.Columns.Add("USUARIO");
                    

                    Int32 y = 0;
                    for (int i = 0; i <= datTipoPlan.Rows.Count - 1; i++)
                    {
                        y += 1;
                        
                        object[] row = {
                            
                            y,
                            datTipoPlan.Rows[i][0],
                            datTipoPlan.Rows[i][1],
                            datTipoPlan.Rows[i][2],
                            datTipoPlan.Rows[i][3],
                            datTipoPlan.Rows[i][4]
                       
                        };

                        dt.Rows.Add(row);
                    }
                    resultadosHistorial.Text = "Nr. de Resultados (" + datTipoPlan.Rows.Count + ")";
                    resultadosHistorial.ForeColor = Variables.ColorSuccess;
                    dgHistorialEquipo.DataSource = dt;

                    dgHistorialEquipo.Columns[0].Width = 50;
                    dgHistorialEquipo.Columns[1].Width = 100;
                    dgHistorialEquipo.Columns[2].Width = 100;
                    dgHistorialEquipo.Columns[3].Width = 200;
                    dgHistorialEquipo.Columns[4].Width = 100;
                    dgHistorialEquipo.Columns[5].Width = 100;


                    dgHistorialEquipo.Visible = true;
                    return true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dgHistorialEquipo.DataSource = dt;
                    dgHistorialEquipo.Visible = false;
                    resultadosHistorial.Text = "No se encontró resultados con este Código";
                    resultadosHistorial.ForeColor = Variables.ColorError;
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private void verHistorialOrden_ClientSizeChanged(object sender, EventArgs e)
        {

        }

       

        private void cboEstadoExterno_SelectedIndexChanged(object sender, EventArgs e)
        {
            String codItem = cboTipoIngreso.SelectedValue == null ? "NULL" : cboTipoIngreso.SelectedValue.ToString();

            if (codItem == "TIOI0002")
            {
                if (cboEstadoExterno.SelectedIndex == 1)
                {
                    cboEstado.SelectedValue = "ESDO0001";
                }
                else if(cboEstadoExterno.SelectedIndex == 2)
                {
                    cboEstado.SelectedValue = "ESDO0003";

                }
            }

            var result = fnValidarComboboxEstadoExterno(cboEstadoExterno, erEstadoExterna, imgEstadoExterno,lnTipoCon);
            estEstadoExterno = result.Item1;
            msjEstadoExterno = result.Item2;
             
        }

        private void txtObservacionExterna_TextChanged(object sender, EventArgs e)
        {
            if(cboEstadoExterno.SelectedIndex == 1)
            {
                var result = FunValidaciones.fnValidarTexboxs(txtObservacionExterna, erObservacionExterno, imgObservacionExterno, false, true, true, 0, 0, 3, 200, "Complete correctamente");
                estObservacionExterna = result.Item1;
                msjObservacionExterno = result.Item2;
            }
            else if (cboEstadoExterno.SelectedIndex == 2)
            {
                var result = FunValidaciones.fnValidarTexboxs(txtObservacionExterna, erObservacionExterno, imgObservacionExterno, true, true, true, 5, 200, 3, 200, "Complete correctamente");
                estObservacionExterna = result.Item1;
                msjObservacionExterno = result.Item2;
            }
            else
            {
                var result = FunValidaciones.fnValidarTexboxs(txtObservacionExterna, erObservacionExterno, imgObservacionExterno, false, true, true, 0, 0, 3, 200, "Complete correctamente");
                estObservacionExterna = result.Item1;
                msjObservacionExterno = result.Item2;
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, true);
            fnEditar(2, true);
        }

        private void txtObservacion_TextChanged(object sender, EventArgs e)
        {
            String valorComboEstado = cboEstado.SelectedValue == null ? "0" : cboEstado.SelectedValue.ToString();

            if (valorComboEstado == "ESDO0003")
            {
                var result = FunValidaciones.fnValidarTexboxs(txtObservacion, erObservacion, imgObservacion, true, true, true, 5, 200, 3, 200, "Complete el campo correctamente");
                estObservacion = result.Item1;
                msjObservacion = result.Item2;
            }
            else
            {
                var result = FunValidaciones.fnValidarTexboxs(txtObservacion, erObservacion, imgObservacion, false, true, true, 0, 0, 3, 200, "Complete el campo correctamente");
                estObservacion = result.Item1;
                msjObservacion = result.Item2;
            }
           
        }

        private String fnGuardarOrdenCompra(Int16 idTipoCon, Operador clsOperador, String tipoordencompra, out Int32 pidOrden, out string pclote)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            DataTable dtDetalleCompra = null;
            BLOrdenCompra blobjVenta = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            OrdenCompra objVenta = new OrdenCompra();
             //= new Operador();

            try
            {
                //if(tipoLlamada==1 &&  cboOrdenCompra.SelectedIndex==1)

                objVenta.idOrden = Convert.ToInt32(txtIdCompra.Text.Trim());
                objVenta.cDocCompra = Convert.ToString(txtDocumento.Text.Trim());

                String codItem = cboTipoIngreso.SelectedValue == null ? "NULL" : cboTipoIngreso.SelectedValue.ToString();

                objVenta.dFechaCompra = (codItem == "TIOI0001" ? dtpFechaCompra.Value : dtpFechaIngreso.Value);
                objVenta.iEstado = Convert.ToString(cboEstado.SelectedValue.ToString().Trim());

                objVenta.observaciones = Convert.ToString(codItem == "TIOI0001" ? txtObservacion.Text.ToString().Trim() : txtObservacionExterna.Text.ToString().Trim());
                objVenta.cTipoPago = Convert.ToString(cboTipoIngreso.SelectedValue.ToString());
                objVenta.nMontoPagar = nMontoPagar;
                objVenta.idProveedor = Convert.ToInt32(cboProveedor.SelectedValue == null || cboProveedor.SelectedValue.ToString() == "0" ? "1" : cboProveedor.SelectedValue.ToString());
                objVenta.idSucursal = 1;
                objVenta.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue.ToString());
                objVenta.chekIGV = Convert.ToBoolean(chkIncluirIGV.Checked == true ? 1 : 0);
                objVenta.costoEnvio = Convert.ToDouble(txtEnvio.Text.ToString());
                objVenta.otrosCostos = Convert.ToDouble(txtOtrosCargos.Text.ToString());
                objVenta.dFechaRegistro = dFechaSis;
                objVenta.idUsuario = Variables.gnCodUser;

                dtDetalleCompra = new DataTable();

                List<TablaOrdenIngreso> hola = fnObtenerDatosTabla();
                dtDetalleCompra = fnCargarDetalleCompra();

                lcValidar = blobjVenta.blGrabarCompra(fnObtenerDatosTabla(), clsOperador, tipoordencompra, objVenta, dtDetalleCompra, idTipoCon, out pidOrden, out pclote).Trim();

                fnHabilitarDocumento(true, 1);

            }//  lcValidar = blobjVenta.blGrabarCompra(fnObtenerDatosTabla(), clsOperador,tipoordencompra, objVenta, dtDetalleCompra,   idTipoCon, out pidOrden, out pclote).Trim();


            catch (Exception ex)
            {
                pidOrden = 0;
                pclote = "";
                lcValidar = "NO";
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnGuardarOrdenCompra", ex.Message);
            }

            return lcValidar;

        }

        private List<TablaOrdenIngreso> fnObtenerDatosTabla()
        {
            List<TablaOrdenIngreso> ListOrdenIngreso = new  List<TablaOrdenIngreso>();

            for (int fila = 0; fila < dgCompraEquipos.Rows.Count - 1; fila++) { 
               
                ListOrdenIngreso.Add( new TablaOrdenIngreso
                {
                    idEquipo = Convert.ToInt32(dgCompraEquipos.Rows[fila].Cells[0].Value.ToString()),
                    cantidad = Convert.ToInt32(dgCompraEquipos.Rows[fila].Cells[3].Value.ToString()),
                    precioUnitario = Convert.ToDecimal(dgCompraEquipos.Rows[fila].Cells[4].Value == null ? "0": dgCompraEquipos.Rows[fila].Cells[4].Value.ToString()),
                    precioNeto = Convert.ToDecimal(dgCompraEquipos.Rows[fila].Cells[5].Value == null ? "0" : dgCompraEquipos.Rows[fila].Cells[5].Value.ToString())

                });
                   
            }
             return ListOrdenIngreso;
            
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            //var result = FunValidaciones.fnValidarTexboxs(txtTotal, erTotal, imgTotal, true, false,true, 1, 999999, 45, 45, "Complete la tabla correctamente");
            //estTotal = result.Item1;
            //msjTotal = result.Item2;
        }

        

        private void cboTipoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            String codItem = cboTipoIngreso.SelectedValue == null ? "NULL" : cboTipoIngreso.SelectedValue.ToString();
            
            if(codItem == "TIOI0001")
            {
                fnLimpiarControles();

                /////GROUPBOXS////
                gbCompra.Enabled = true;
                gbProveedor.Enabled = true;
                gbCompra.Visible = true;
                gbProveedor.Visible = true;

                ////TEXTBOXS/////
                txtObservacionExterna.Visible = false;
                //txtDocumento.Enabled = true;
                txtEnvio.Enabled = true;
                txtOtrosCargos.Enabled = true;

                if (cboOrdenCompra.Text == "SIM CARD")
                {
                    txtDocumento.Enabled = false;
                }
                else
                {
                    txtDocumento.Enabled = true;
                }

                ////TAMAÑOS Y POSICIONES DE DATAGRIDVIEW
                dgCompraEquipos.Location = new Point(12, 395);
                dgCompraEquipos.Height = 138;
                dtpFechaIngreso.Visible = false;
                dgCompraEquipos.Enabled = true;
                txtPrecioUnitario.DefaultCellStyle.NullValue = null;
                txtPrecioUnitario.ReadOnly = false;

                /////LABELS/////
                lblEstado.Visible = false;
                lblFechaIngreso.Visible = false;
                erEstadoExterna.Visible = false;
                erObservacionExterno.Visible = false;
                lblObservacionExterna.Visible = false;
                erObservacionExterno.Visible = false;
                
                /////PICTUREBOXS////
                imgFechaIngreso.Visible = false;
                imgEstadoExterno.Visible = false;
                imgObservacionExterno.Visible = false;

                /////COMBOBOXS////
                cboEstadoExterno.Visible = false;
                cboMoneda.SelectedValue = 0;

                

                ////DATATIMEPICKER////
                dtpFechaCompra.Enabled = true;

                /////CHECKBOXS/////               
                chkIncluirIGV.Checked = false;
                chkIncluirIGV.Visible = true;
                chkIncluirIGV.Enabled = true;

            }
            else if (codItem == "TIOI0002")
            {
                fnLimpiarControles();

                /////GROUPBOXS/////
                gbCompra.Enabled = false;
                gbProveedor.Enabled = false;
                gbCompra.Visible = false;
                gbProveedor.Visible = false;
                dtpFechaIngreso.Visible = true;

                /////TEXTBOXS/////
                txtSubTotal.Visible = true;
                txtObservacionExterna.Visible = true;
                txtEnvio.Enabled = false;
                txtOtrosCargos.Enabled = false;
              

                /////LABELS/////
                lblEstado.Visible = true;
                lblFechaIngreso.Visible = true;               
                lblObservacionExterna.Visible = true;
                erObservacionExterno.Visible = true;
                erEstadoExterna.Visible = true;
                erEstadoExterna.Visible = true;

                /////PICTUREBOXS////
                imgFechaIngreso.Visible = true;
                imgEstadoExterno.Visible = true;
                imgObservacionExterno.Visible = true;

                /////COMBOBOXS////
                cboEstadoExterno.Visible = true;
                cboMoneda.SelectedValue = 1;

                ////TAMAÑOS Y POSICIONES DE DATAGRIDVIEW
                dgCompraEquipos.Location = new Point(12, 184);
                dgCompraEquipos.Height = 340;
                dgCompraEquipos.Enabled = true;
                
                txtPrecioUnitario.ReadOnly = true;

                /////DATAPICKERS////
                dtpFechaIngreso.Enabled = true;

                

                /////CHECKBOXS/////               
                chkIncluirIGV.Checked = false;
                chkIncluirIGV.Visible = false;
               

            }
          
            else
            {
                fnLimpiarControles();

                ////GROUPBOXS////
                gbCompra.Enabled = false;
                gbProveedor.Enabled = false;
                gbCompra.Visible = true;
                gbProveedor.Visible = true;

                /////TEXBOXS//////
                txtSubTotal.Visible = true;
                txtIGV.Visible = true;
                txtTotal.Visible = true;
                txtObservacionExterna.Visible = false;
                dtpFechaIngreso.Visible = false;
                
                /////LABELS/////
                lblEstado.Visible = false;
                lblFechaIngreso.Visible = false;
                erEstadoExterna.Visible = false;
                lblObservacionExterna.Visible = false;
                erObservacionExterno.Visible = false;
                txtEnvio.Enabled = false;
                txtOtrosCargos.Enabled = false;

                /////PICTUREBOXS////
                imgFechaIngreso.Visible = true;
                imgObservacionExterno.Visible = false;

                /////COMBOBOXS////
                cboEstadoExterno.Visible = false;

                ////TAMAÑOS Y POSICIONES DE DATAGRIDVIEW
                dgCompraEquipos.Location = new Point(12,390);
                dgCompraEquipos.Height = 138;
                dgCompraEquipos.Enabled = false;

                /////ESTADOS
                estNroDocumento = false;
                estCboEstado = false;
                estFechaCompra = false;
                estCboProveedor = false;
                estEstadoExterno = false;
                estObservacionExterna = false;
            }

            var result = FunValidaciones.fnValidarCombobox(cboTipoIngreso, erTipoOrden, imgTipoOrden);
            estTipoIngreso = result.Item1;
            msjTipoIngreso = result.Item2;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var result = fnValidarTabla(dgCompraEquipos, erTabla, imgTotal);
            estTabla = result.Item1;
            msjTabla = result.Item2;
            txtObservacion_TextChanged(sender, e);
            
           
            String lcResultado = "";
            string lcImprimirLote = "";
            int lidOrden = 0;
            String tipoordencompra = cboOrdenCompra.Text;

            String codItem = cboTipoIngreso.SelectedValue == null ? "NULL" : cboTipoIngreso.SelectedValue.ToString();

            String ordenit = cboOrdenCompra.SelectedValue == null ? "NULL" : cboOrdenCompra.SelectedValue.ToString();



            if (codItem == "TIOI0002")
            {
                /////ESTADOS
                estNroDocumento = true;
                estCboEstado = true;
                estFechaCompra = true;
                estCboProveedor = true;
                estObservacion = true;
                cboEstadoExterno_SelectedIndexChanged(sender, e);
                var result1 = FunValidaciones.fnValidarCombobox(cboTipoIngreso, erTipoOrden, imgTipoOrden);
                estTipoIngreso = result1.Item1;
                msjTipoIngreso = result1.Item2;
                dtpFechaIngreso_ValueChanged(sender, e);
                var result2 = fnValidarComboboxEstadoExterno(cboEstadoExterno, erEstadoExterna, imgEstadoExterno, lnTipoCon);
                estEstadoExterno = result2.Item1;
                msjEstadoExterno = result2.Item2;
                txtObservacionExterna_TextChanged(sender, e);


            }
            else
            {
                /////ESTADOS
                estNroDocumento = false;
                estCboEstado = false;
                estFechaCompra = false;
                estCboProveedor = false;
                estEstadoExterno = true;
                estObservacionExterna = true;
                estFechaIngreso = true;

                var result1 = FunValidaciones.fnValidarCombobox(cboTipoIngreso, erTipoOrden, imgTipoOrden);
                estTipoIngreso = result1.Item1;
                msjTipoIngreso = result1.Item2;
                var result2 = fnValidarComboboxEstadoPago(cboEstado, erEstado, imgEstado, lnTipoCon);
                estCboEstado = result2.Item1;
                msjCboEstado = result2.Item2;
                //txtDocumento_Leave(sender, e);
                dtpFechaCompra_ValueChanged(sender, e);
                var result3 = Funciones.FunValidaciones.fnValidarCombobox(cboProveedor, erProveedor, imgProveedor);
                estCboProveedor = result3.Item1;
                msjCboProveedor = result3.Item2;
                if (btnEditar.Enabled = true)
                {
                    txtDocumento_TextChanged (sender, e);
                }
                else
                {

                }
            }
            //&& estNroDocumento
            if (estTipoIngreso && estFechaIngreso  && estCboEstado && estFechaCompra && estCboProveedor && estTabla && estObservacion && estEstadoExterno && estObservacionExterna && estMoneda)
            {
                

                    lcResultado = fnGuardarOrdenCompra(lnTipoCon, clsOperador, tipoordencompra, out lidOrden, out lcImprimirLote);
                    if (lcResultado == "OK")
                    {
                        btnNuevo_Click(sender, e);
                        string strActivarImpresion = FunGeneral.fnDevolverParametro("ACIM0001") != null ? (FunGeneral.fnDevolverParametro("ACIM0001")[0].cValor) : "1";
                        if (strActivarImpresion == "1")
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
            else
            {
                MessageBox.Show("Complete corrrectamente los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        Boolean notlastColumn = false;

        

        private void dgCompraEquipos_KeyDown(object sender, KeyEventArgs e)
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

        private void dgCompraEquipos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Boolean lbResul = false;
            
            Int32 filaIndice = e.RowIndex == -1 ? 0 : e.RowIndex;
            if (dgCompraEquipos.Rows.Count > 0)
            {

                if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
                {
                    String codItem = cboTipoIngreso.SelectedValue == null ? "NULL" : cboTipoIngreso.SelectedValue.ToString();

                    if (codItem == "TIOI0002")   
                    {
                        dgCompraEquipos.Rows[filaIndice].Cells[4].Value = "0";
                    }
                    else
                    {

                    }
                    Double precioNetoOri = (Convert.ToDouble(dgCompraEquipos.Rows[filaIndice].Cells[3].Value is Nullable ? 0 : dgCompraEquipos.Rows[filaIndice].Cells[3].Value) * Convert.ToDouble(dgCompraEquipos.Rows[filaIndice].Cells[4].Value == null ? 0 : dgCompraEquipos.Rows[filaIndice].Cells[4].Value));
                    dgCompraEquipos.Rows[filaIndice].Cells[5].Value = precioNetoOri;
                    dgCompraEquipos.Rows[filaIndice].Cells[6].Value = String.Format("{0:0.00}",precioNetoOri);
                    fnValidarIGV();
                    lbResul = fnCalcularTotal();
                    if (lbResul == false)
                    {
                        MessageBox.Show("Ha ocurrido un Error al Calcular Totales de Orden de Compra", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                }
                
            }
        }
        static Operador clsOperador = new Operador();
        public void fnObtenerOperador(Operador oper)
        {
            clsOperador = oper;
            
        }


        private void dgCompraEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgCompraEquipos.Columns["btnNuevo"].Index && e.RowIndex >= 0)
            {
                              
                if (cboProveedor.SelectedIndex > 0 && Convert.ToInt32(cboOrdenCompra.SelectedIndex) == 2)
                {
                    String tipoingreso=cboTipoIngreso.Text;
                    
                    frmOperador frmoperador = new frmOperador();
                    frmoperador.Inicio(1, tipoingreso, Convert.ToInt32(cboProveedor.SelectedValue));
                                       

                    dgCompraEquipos.Rows[e.RowIndex].Cells[0].Value = clsOperador.idOperador;
                    dgCompraEquipos.Rows[e.RowIndex].Cells[1].Value = clsOperador.NomOperador;


                }
                else if (cboTipoIngreso.Text=="EXTERNO" && Convert.ToInt32(cboOrdenCompra.SelectedIndex)==2)
                {
                    String tipoingreso = cboTipoIngreso.Text;

                    frmOperador frmoperador = new frmOperador();
                    frmoperador.Inicio(1, tipoingreso, Convert.ToInt32(cboProveedor.SelectedValue));


                    dgCompraEquipos.Rows[e.RowIndex].Cells[0].Value = clsOperador.idOperador;
                    dgCompraEquipos.Rows[e.RowIndex].Cells[1].Value = clsOperador.NomOperador;


                }
                else
                {
                    lidProducto = 0;
                    frmRegistrarEquipo frmEquipo = new frmRegistrarEquipo();
                    frmEquipo.Inicio(3);

                    dgCompraEquipos.Rows[e.RowIndex].Cells[0].Value = cellidEquipo;
                    dgCompraEquipos.Rows[e.RowIndex].Cells[1].Value = cellNombreEquipo;

                }
            }

            if(e.ColumnIndex == dgCompraEquipos.Columns["btnEliminar"].Index && e.RowIndex >= 0){

                //Int32 numfilas = (dgCompraEquipos.Rows.Count)-1;
                //if (e.RowIndex == 0 || e.RowIndex == numfilas)
                //{
                //    dgCompraEquipos.Rows[e.RowIndex].Cells[0].Value = null;
                //    dgCompraEquipos.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.White;
                //    dgCompraEquipos.Rows[e.RowIndex].Cells[1].Value = null;
                //    dgCompraEquipos.Rows[e.RowIndex].Cells[3].Value = null;
                //    dgCompraEquipos.Rows[e.RowIndex].Cells[4].Value = null;


                //}
                //else
                //{
                //    dgCompraEquipos.Rows.RemoveAt(e.RowIndex);
                //}
                fnlimpiardgv(e);

                fnCalcularTotal();

            }
            

        }
        private void fnlimpiardgv(DataGridViewCellEventArgs e)
        {
            
            Int32 numfilas = (dgCompraEquipos.Rows.Count) - 1;
            if (e.RowIndex == 0 || e.RowIndex == numfilas)
            {
                dgCompraEquipos.Rows[e.RowIndex].Cells[0].Value = null;
                dgCompraEquipos.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.White;
                dgCompraEquipos.Rows[e.RowIndex].Cells[1].Value = null;
                dgCompraEquipos.Rows[e.RowIndex].Cells[3].Value = null;
                dgCompraEquipos.Rows[e.RowIndex].Cells[4].Value = null;


            }
            else
            {
                dgCompraEquipos.Rows.RemoveAt(e.RowIndex);
            }

        }

    
    }
}
