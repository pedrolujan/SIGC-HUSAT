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

namespace wfaIntegradoCom.Procesos
{
    public partial class frmOpcionesProducto : Form
    {
        DataTable dtMarca;
        DataTable dtCategoria;
        DataTable dtUnidadMedida;
        DataTable dtEquivalencia;
        DataTable dtProducto;
        Int16 lnTipoLlamada = 0;

        public frmOpcionesProducto()
        {
            InitializeComponent();
        }

        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();
        }

        private void frmOpcionesProducto_Load(object sender, EventArgs e)
        {
            pCargarMarcas();
            pCargarCategoria();
            pCargarUnidadMedida();
            pCargarCombosUnidadMedida();
            pCargarEquivalencia();
            pCargarProducto();
            pCargarCombosProducto();
            cboBusquedaMarca.SelectedIndex = 0;
            cboBusquedaCategoria.SelectedIndex = 0;
            cboBusquedaUM.SelectedIndex = 0;
            cboBusquedaProducto.SelectedIndex = 0;

            if (lnTipoLlamada == 0)
            {
            }
            else if (lnTipoLlamada == 1 || lnTipoLlamada==2)
            {
                tcPrincipal.SelectedIndex = 4;
                gbProducto.Visible = false;
                Height = 500;
                gbListadoProd.Left = 12;
                gbListadoProd.Top = 10;
                gbListadoProd.Height = 400;
                gbListadoProd.Width = 570;
                dgvListaProducto.Left = 13;
                dgvListaProducto.Top = 40;
                dgvListaProducto.Height = 350;
                dgvListaProducto.Width = 550;
                txtCriterioProducto.Focus();
            }
            else
            {               
                tcPrincipal.SelectedIndex = 2;
                gbUnidadMed.Visible = false;
                gbListadoUM.Top = 10;
            }
        }
        private void pCargarMarcas()
        {
            BLMarca objMarca = new BLMarca();
            clsUtil objUtil = new clsUtil();
            dtMarca = null;
            dtMarca= new DataTable();
            try 
            {
                dtMarca = objMarca.BLListarMarcas();
                dgvListadoMarca.DataSource = dtMarca;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOpcionesProducto-Marca", "pCargarMarcas", ex.Message);
                MessageBox.Show(ex.Message, "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Question);
            }
        }

        private void pCargarCategoria()
        {
            BLCategoria objCategoria = new BLCategoria();
            clsUtil objUtil = new clsUtil();
            dtCategoria = null;
            dtCategoria = new DataTable();
            try
            {
                dtCategoria = objCategoria.BLListarCategoria();
                dgvListadoCategoria.DataSource = dtCategoria;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOpcionesProducto-Categoria", "pCargarCategoria", ex.Message);
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void pCargarCombosUnidadMedida()
        {
            BLUnidadMedida objUMCombo = new BLUnidadMedida();
            clsUtil objUtil = new clsUtil();
            DataTable dtUMCombo1 = new DataTable();
            DataTable dtUMCombo2 = new DataTable();
            try
            {
                dtUMCombo1 = objUMCombo.BLListarUnidadMedidaCombo();
                cboUMOrigen.ValueMember = "idUnidadMedida";
                cboUMOrigen.DisplayMember = "cNombreUM";
                cboUMOrigen.DataSource = dtUMCombo1;
                dtUMCombo2 = dtUMCombo1.Copy();
                if (dtUMCombo1.Rows.Count>0)
                {
                  cboUMOrigen.SelectedIndex = 0;
                }
                cboUMDestino.ValueMember = "idUnidadMedida";
                cboUMDestino.DisplayMember = "cNombreUM";
                cboUMDestino.DataSource = dtUMCombo2;
                if (dtUMCombo2.Rows.Count>0)
                {
                  cboUMDestino.SelectedIndex = 0;
                }
                
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOpcionesProducto-Categoria", "pCargarCombosUnidadMedida", ex.Message);
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void pCargarCombosProducto()
        {
            BLCategoria objCat = new BLCategoria();
            BLProducto objUnd = new BLProducto();
            BLMarca objMarc = new BLMarca();

            clsUtil objUtil = new clsUtil();
            DataTable dtCat = new DataTable();
            DataTable dtUnid = new DataTable();
            DataTable dtMarc = new DataTable();
            try
            {
                dtCat = objCat.BLListarCategoria();
                dtUnid = objUnd.BLListarUnidadMedidaProducto();
                cboUnidadMedidaProducto.ValueMember = "idUnidadMedida";
                cboUnidadMedidaProducto.DisplayMember = "cNombreUM";
                cboUnidadMedidaProducto.DataSource = dtUnid;
                if (dtUnid.Rows.Count >0)
                {
                  cboUnidadMedidaProducto.SelectedIndex = 0;
                }
                dtCat = objCat.BLListarCategoria();
                cboCategoriaProducto.ValueMember = "idCategoria";
                cboCategoriaProducto.DisplayMember = "cNombre";
                cboCategoriaProducto.DataSource = dtCat;
                if (dtCat.Rows.Count>0)
                {
                    cboCategoriaProducto.SelectedIndex = 0;
                }
                dtMarc = objMarc.BLListarMarcas();
                cboMarcaProducto.ValueMember = "idMarca";
                cboMarcaProducto.DisplayMember = "cNombreMarca";
                cboMarcaProducto.DataSource = dtMarc;
                if (dtMarc.Rows.Count > 0)
                {
                    cboMarcaProducto.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOpcionesProducto-Categoria", "pCargarCombosUnidadMedida", ex.Message);
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    
        //private void pCargarComboLineaProducto()
        //{
        //    DataTable dtLineaCombo = new DataTable();
        //    BLLineaProducto objLinea = new BLLineaProducto();
        //    clsUtil objUtil = new clsUtil();
           
        //    try
        //    {
        //        dtLineaCombo = objLinea.BLListarLineaProductoCombo();
        //        cboSeleccionaCategoria.DisplayMember = "cNombre";
        //        cboSeleccionaCategoria.ValueMember = "idCategoria";
        //        cboSeleccionaCategoria.DataSource = dtLineaCombo;
        //        if (dtLineaCombo.Rows.Count > 0)
        //        {
        //            cboSeleccionaCategoria.SelectedIndex = 0;
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("frmOpcionesProducto-Linea", "pCargarComboLineaProducto", ex.Message);
        //        MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
        //    }
        //}

        private void pCargarUnidadMedida()
        {
            BLUnidadMedida objUM = new BLUnidadMedida();
            clsUtil objUtil = new clsUtil();
            dtUnidadMedida = null;
            dtUnidadMedida = new DataTable();
            try
            {
                dtUnidadMedida = objUM.BLListarUnidadMedida();
                dgvUM.DataSource = dtUnidadMedida;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOpcionesProducto-Categoria", "pCargarUnidadMedida", ex.Message);
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void pCargarEquivalencia()
        {
            BLEquivalencia objUM = new BLEquivalencia();
            clsUtil objUtil = new clsUtil();
            dtEquivalencia = null;
            dtEquivalencia = new DataTable();
            try
            {
                dtEquivalencia = objUM.BLListarEquivalencia();
                dgvListadoEquiv.DataSource = dtEquivalencia;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOpcionesProducto-Categoria", "pCargarEquivalencia", ex.Message);
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void pCargarProducto()
        {
            BLProducto objUM = new BLProducto();
            clsUtil objUtil = new clsUtil();
            dtProducto = null;
            dtProducto = new DataTable();
            try
            {
                dtProducto = objUM.BLListarProducto();
                dgvListaProducto.DataSource = dtProducto;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOpcionesProducto-Producto", "pCargarProducto", ex.Message);
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void dgvListadoMarca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                if (MessageBox.Show("Desea Editar la Marca Seleccionada?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtCodigoMarca.Text = dgvListadoMarca.Rows[e.RowIndex].Cells["idMarca"].Value.ToString();
                    txtNombreMarca.Text = dgvListadoMarca.Rows[e.RowIndex].Cells["cNombreMarca"].Value.ToString();
                    txtDescripcionMarca.Text = dgvListadoMarca.Rows[e.RowIndex].Cells["cDescripcion"].Value.ToString();
                    if (dgvListadoMarca.Rows[e.RowIndex].Cells["cEstado"].Value.ToString() == "ACTIVO")
                    {
                        rbActivo.Checked = true;
                    }
                    else
                    {
                        rbInactivo.Checked = true;
                    }
                }
                    

            }
        }

        private void dgvListadoCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (MessageBox.Show("Desea Editar la Categoria Seleccionada?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtCodigoCategoria.Text = dgvListadoCategoria.Rows[e.RowIndex].Cells["idCategoria"].Value.ToString();
                    txtNombreCategoria.Text = dgvListadoCategoria.Rows[e.RowIndex].Cells["cNombre"].Value.ToString();
                    txtDescripcionCategoria.Text = dgvListadoCategoria.Rows[e.RowIndex].Cells["cDescripcionCategoria"].Value.ToString();
                    if (dgvListadoCategoria.Rows[e.RowIndex].Cells["cEstadoCategoria"].Value.ToString() == "ACTIVO")
                    {
                        rbActivoCategoria.Checked = true;
                    }
                    else
                    {
                        rbInactivocategoria.Checked = true;
                    }
                }


            }
        }     
     
        private void dgvUM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (lnTipoLlamada == 2)
                {
                    frmDocumentoVenta.fnRecuperarUnidadMedida(Convert.ToInt32(dgvUM.Rows[e.RowIndex].Cells[0].Value), Convert.ToString(dgvUM.Rows[e.RowIndex].Cells[1].Value));
                    this.Dispose();
                }
                else
                {
                    if (MessageBox.Show("Desea Editar la Unidad de Medida Seleccionada?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtCodigoUM.Text = dgvUM.Rows[e.RowIndex].Cells["idUnidadMedida"].Value.ToString();
                        txtNombreUM.Text = dgvUM.Rows[e.RowIndex].Cells["cNombreUM"].Value.ToString();
                        txtAbreviaturaUM.Text = dgvUM.Rows[e.RowIndex].Cells["cAbreviaturaUM"].Value.ToString();
                        if (dgvUM.Rows[e.RowIndex].Cells["cEstadoUM"].Value.ToString() == "ACTIVO")
                        {
                            rbActivoUM.Checked = true;
                        }
                        else
                        {
                            rbInactivoUM.Checked = true;
                        }
                    } 
                }

            }
        }
        private void dgvListadoEquiv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (MessageBox.Show("Desea Editar la Equivalencia de Medida Seleccionada?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtCodigoEquiv.Text = dgvListadoEquiv.Rows[e.RowIndex].Cells["idUMEquivalencia"].Value.ToString();
                    cboUMOrigen.SelectedValue =Convert.ToInt32( dgvListadoEquiv.Rows[e.RowIndex].Cells["idUMOrigen"].Value.ToString());
                    cboUMDestino.SelectedValue = Convert.ToInt32(dgvListadoEquiv.Rows[e.RowIndex].Cells["idUMDestino"].Value.ToString());
                    txtUMOrigen.Text = Convert.ToString(dgvListadoEquiv.Rows[e.RowIndex].Cells["mValorOrigen"].Value.ToString());
                    txtUMDestino.Text = Convert.ToString(dgvListadoEquiv.Rows[e.RowIndex].Cells["mValorDestino"].Value.ToString());
                    if (dgvListadoEquiv.Rows[e.RowIndex].Cells["cEstadoEquiv"].Value.ToString() == "ACTIVO")
                    {
                        rbActivoEquiv.Checked = true;
                    }
                    else
                    {
                        rbInactivoEquiv.Checked = true;
                    }
                }
            }
        }
        private void dgvListaProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (lnTipoLlamada == 1)
                    {
                        frmDocumentoVenta.fnRecuperarProducto(Convert.ToInt32(dgvListaProducto.Rows[e.RowIndex].Cells[0].Value));
                        this.Dispose();
                    }
                    else if (lnTipoLlamada == 2)
                    {
                        frmOrdenCompra.fnRecuperarProducto(Convert.ToInt32(dgvListaProducto.Rows[e.RowIndex].Cells[0].Value), Convert.ToString(dgvListaProducto.Rows[e.RowIndex].Cells[1].Value));
                        this.Dispose();
                    }
                    else
                    {

                        if (MessageBox.Show("Desea Editar el Producto Seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            txtCodigoProducto.Text = dgvListaProducto.Rows[e.RowIndex].Cells["idProducto"].Value.ToString();
                            txtNombreProducto.Text = dgvListaProducto.Rows[e.RowIndex].Cells["cNombreProducto"].Value.ToString();
                            txtDescripcionProducto.Text = dgvListaProducto.Rows[e.RowIndex].Cells["cDescripcionProducto"].Value.ToString();
                            cboCategoriaProducto.SelectedValue = Convert.ToInt32(dgvListaProducto.Rows[e.RowIndex].Cells["idCategoriaProducto"].Value.ToString());
                            cboUnidadMedidaProducto.SelectedValue = Convert.ToInt32(dgvListaProducto.Rows[e.RowIndex].Cells["idUnidadMedidaProducto"].Value.ToString());
                            cboMarcaProducto.SelectedValue = Convert.ToInt32(dgvListaProducto.Rows[e.RowIndex].Cells["idMarcaProductoP"].Value.ToString());
                            textBox1.Text = dgvListaProducto.Rows[e.RowIndex].Cells["StockMin"].Value.ToString();
                            if (dgvListaProducto.Rows[e.RowIndex].Cells["bEstadoProducto"].Value.ToString() == "ACTIVO")
                            {
                                rbActivoProducto.Checked = true;
                            }
                            else
                            {
                                rbInactivoProducto.Checked = true;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOpcionesProducto", "dgvListaProducto_CellDoubleClick", ex.Message);
                MessageBox.Show("Error al Buscar Producto Especifico. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void pCancelar()
        {
            txtCodigoMarca.Text = "";
            txtNombreMarca.Text = "";
            txtDescripcionMarca.Text = "";
            rbActivo.Checked = true;
            txtCriterioMarca.Text = "";
            pCargarMarcas();
        }

        private void pCancelarCategoria()
        {
            txtCodigoCategoria.Text = "";
            txtNombreCategoria.Text = "";
            txtDescripcionCategoria.Text = "";
            rbActivoCategoria.Checked = true;
            txtCriterioCategoria.Text = "";
            pCargarCategoria();
        }

        private void pCancelarUM()
        {
            txtCodigoUM.Text = "";
            txtNombreUM.Text = "";
            txtAbreviaturaUM.Text = "";
            rbActivoUM.Checked = true;
            txtCriterioUM.Text = "";
            pCargarUnidadMedida();
        }
        private void pCancelarEquivalencia()
        {
            txtCodigoEquiv.Text = "";
            txtUMOrigen.Text = "";
            txtUMDestino.Text = "";
            rbActivoEquiv.Checked = true;
            txtCriterioEquiv.Text = "";
            cboUMOrigen.SelectedIndex = 0;
            cboUMDestino.SelectedIndex = 0;
            pCargarEquivalencia();
        }
        private void pCancelarProducto()
        {
            txtCodigoProducto.Text = "";
            txtNombreProducto.Text = "";
            txtDescripcionProducto.Text = "";
            rbActivoProducto.Checked = true;
            txtCriterioProducto.Text = "";
            if (cboCategoriaProducto.Items.Count>0)
            {
                cboCategoriaProducto.SelectedIndex = 0;
            }
            if (cboUnidadMedidaProducto.Items.Count>0)
            {
                cboUnidadMedidaProducto.SelectedIndex = 0;
            }
            if (cboMarcaProducto.Items.Count > 0)
            {
                cboMarcaProducto.SelectedIndex = 0;
            }
            pCargarProducto();
        }
        private void tsbCancelarMarca_Click(object sender, EventArgs e)
        {
            pCancelar();
        }

        private void txtCancelarCategoria_Click(object sender, EventArgs e)
        {
            pCancelarCategoria();
        }
        
        private void tsbCancelarUM_Click(object sender, EventArgs e)
        {
            pCancelarUM();
        }
        private void tsbCancelarEquiv_Click(object sender, EventArgs e)
        {
            pCancelarEquivalencia();
        }
        private void txtCriterioMarca_TextChanged(object sender, EventArgs e)
        {
            DataView dv;
            if(txtCriterioMarca.Text.Trim().Length <=0)
            {
                dgvListadoMarca.DataSource = dtMarca;
            }
            else
            {
                if (cboBusquedaMarca.SelectedIndex == 0)
                {
                    int Resul;
                    if (int.TryParse(txtCriterioMarca.Text.Trim(), out Resul))
                    {
                        dv = new DataView(dtMarca, "idMarca = " + txtCriterioMarca.Text.Trim() + " ", "idMarca Asc", DataViewRowState.CurrentRows);
                        dgvListadoMarca.DataSource = dv;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un Criterio Correcto: Numérico", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        txtCriterioMarca.Text = "";
                    }
                }
                else
                {
                    dv = new DataView(dtMarca, "cNombreMarca like '%" + txtCriterioMarca.Text.Trim() + "%' ", "cNombreMarca Asc", DataViewRowState.CurrentRows);
                    dgvListadoMarca.DataSource = dv;
                }
                
            }
            
        }
        private void txtCriterioCategoria_TextChanged(object sender, EventArgs e)
        {
            DataView dv;
            if (txtCriterioCategoria.Text.Trim().Length <= 0)
            {
                dgvListadoCategoria.DataSource = dtCategoria;
            }
            else
            {
                if (cboBusquedaCategoria.SelectedIndex == 0)
                {
                    int Resul;
                    if (int.TryParse(txtCriterioCategoria.Text.Trim(), out Resul))
                    {
                        dv = new DataView(dtCategoria, "idCategoria = " + txtCriterioCategoria.Text.Trim() + " ", "idCategoria Asc", DataViewRowState.CurrentRows);
                        dgvListadoCategoria.DataSource = dv;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un Criterio Correcto: Numérico", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        txtCriterioCategoria.Text = "";
                    }
                }
                else
                {
                    dv = new DataView(dtCategoria, "cNombre like '%" + txtCriterioCategoria.Text.Trim() + "%' ", "cNombre Asc", DataViewRowState.CurrentRows);
                    dgvListadoCategoria.DataSource = dv;
                }
                
            }
        }
        private void txtCriterioUM_TextChanged(object sender, EventArgs e)
        {
            DataView dv;
            if (txtCriterioUM.Text.Trim().Length <= 0)
            {
                dgvUM.DataSource = dtUnidadMedida;
            }
            else
            {
                if (cboBusquedaUM.SelectedIndex == 0)
                {
                    int Resul;
                    if (int.TryParse(txtCriterioUM.Text.Trim(), out Resul))
                    {
                        dv = new DataView(dtUnidadMedida, "idUnidadMedida = " + txtCriterioUM.Text.Trim() + " ", "idUnidadMedida Asc", DataViewRowState.CurrentRows);
                        dgvUM.DataSource = dv;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un Criterio Correcto: Numérico", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        txtCriterioUM.Text = "";
                    }
                }
                else
                {
                    dv = new DataView(dtUnidadMedida, "cNombreUM like '%" + txtCriterioUM.Text.Trim() + "%' ", "cNombreUM Asc", DataViewRowState.CurrentRows);
                    dgvUM.DataSource = dv;
                }

            }
        }
       
        private void txtCriterioEquiv_TextChanged(object sender, EventArgs e)
        {
            DataView dv;
            if (txtCriterioEquiv.Text.Trim().Length <= 0)
            {
                dgvListadoEquiv.DataSource = dtEquivalencia;
            }
            else
            {
                if (cboBusquedaEquiv.SelectedIndex == 0)
                {
                    int Resul;
                    if (int.TryParse(txtCriterioEquiv.Text.Trim(), out Resul))
                    {
                        dv = new DataView(dtEquivalencia, "idUMEquivalencia = " + txtCriterioEquiv.Text.Trim() + " ", "idUMEquivalencia Asc", DataViewRowState.CurrentRows);
                        dgvListadoEquiv.DataSource = dv;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un Criterio Correcto: Numérico", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        txtCriterioEquiv.Text = "";
                    }
                }
                else
                {
                    dv = new DataView(dtEquivalencia, "cNombreUMOrigen like '%" + txtCriterioEquiv.Text.Trim() + "%' ", "cNombreUMOrigen Asc", DataViewRowState.CurrentRows);
                    dgvListadoEquiv.DataSource = dv;
                }

            }
        }
        private void txtCriterioProducto_TextChanged(object sender, EventArgs e)
        {
            DataView dv;
            if (txtCriterioProducto.Text.Trim().Length <= 0)
            {
                dgvListaProducto.DataSource = dtProducto;
            }
            else
            {
                if (cboBusquedaProducto.SelectedIndex == 0)
                {
                    int Resul;
                    if (int.TryParse(txtCriterioProducto.Text.Trim(), out Resul))
                    {
                        dv = new DataView(dtProducto, "idProducto = " + txtCriterioProducto.Text.Trim() + " ", "idProducto Asc", DataViewRowState.CurrentRows);
                        dgvListaProducto.DataSource = dv;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un Criterio Correcto: Numérico", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        txtCriterioProducto.Text = "";
                    }
                }
                else
                {
                    dv = new DataView(dtProducto, "cNombreProducto like '%" + txtCriterioProducto.Text.Trim() + "%' ", "cNombreProducto Asc", DataViewRowState.CurrentRows);
                    dgvListaProducto.DataSource = dv;
                }

            }
        }
        private void tsbGuardarMarca_Click(object sender, EventArgs e)
        {
            String lsResultado = "";
            Int32 liCodigo=0;
            Int32 lbEstado=0 ;
            clsUtil objUtil = new clsUtil();
            if(pValidaIngreso()==false)
            {
                BLMarca objMarca = new BLMarca();
                if(txtCodigoMarca.Text.Trim().Length>0)
                {
                    liCodigo=Int32.Parse(txtCodigoMarca.Text.Trim());
                }
                if(rbActivo.Checked ==true )
                {
                    lbEstado=1;
                }
                lsResultado = objMarca.BLRegistrarMarca(liCodigo, txtNombreMarca.Text.Trim(), txtDescripcionMarca.Text.Trim(), lbEstado, objUtil.GetFechaHoraFormato(Variables.gdFechaSis, 2), Variables.gnCodUser, 2);
                if (lsResultado.Trim().Length>0)
                {
                    MessageBox.Show(lsResultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Marca Registrada correctamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    pCancelar();
                }
                pCargarMarcas();
                pCargarCombosProducto();
            }
        }

        private void tsbGuardarCategoria_Click(object sender, EventArgs e)
        {
            String lsResultado = "";
            Int32 liCodigo = 0;
            Int32 lbEstado = 0;
            clsUtil objUtil = new clsUtil();
            if (pValidaIngresoCategoria() == false)
            {
                BLCategoria objMarca = new BLCategoria();
                if (txtCodigoCategoria.Text.Trim().Length > 0)
                {
                    liCodigo = Int32.Parse(txtCodigoCategoria.Text.Trim());
                }
                if (rbActivoCategoria.Checked == true)
                {
                    lbEstado = 1;
                }
                lsResultado = objMarca.BLRegistrarCategoria(liCodigo, txtNombreCategoria.Text.Trim(), txtDescripcionCategoria.Text.Trim(), lbEstado, objUtil.GetFechaHoraFormato(Variables.gdFechaSis, 2), Variables.gnCodUser, 2);
                if (lsResultado.Trim().Length > 0)
                {
                    MessageBox.Show(lsResultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Categoria Registrada correctamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    pCancelarCategoria();
                }
                pCargarCategoria();
                pCargarCombosProducto();
            }
        }
        private void tsbGrabarUM_Click(object sender, EventArgs e)
        {
            String lsResultado = "";
            Int32 liCodigo = 0;
            Int32 lbEstado = 0;
            clsUtil objUtil = new clsUtil();
            if (pValidaIngresoUnidadMedida() == false)
            {
                BLUnidadMedida objMarca = new BLUnidadMedida();
                if (txtCodigoUM.Text.Trim().Length > 0)
                {
                    liCodigo = Int32.Parse(txtCodigoUM.Text.Trim());
                }
                if (rbActivoUM.Checked == true)
                {
                    lbEstado = 1;
                }
                lsResultado = objMarca.BLRegistrarUnidadMedida(liCodigo, txtNombreUM.Text.Trim(), txtAbreviaturaUM.Text.Trim(), lbEstado, objUtil.GetFechaHoraFormato(Variables.gdFechaSis, 2), Variables.gnCodUser, 2);
                if (lsResultado.Trim().Length > 0)
                {
                    MessageBox.Show(lsResultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Unidad de Medida Registrada correctamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    pCancelarUM();
                }
                pCargarUnidadMedida();
                pCancelarUM();
                pCargarCombosProducto();
                pCargarCombosUnidadMedida();
            }
        }
        private void tsbGrabarEquiv_Click(object sender, EventArgs e)
        {
            String lsResultado = "";
            Int32 liCodigo = 0;
            Int32 lbEstado = 0;
            clsUtil objUtil = new clsUtil();
            if (pValidaIngresoEquivalencia() == false)
            {
                BLEquivalencia objMarca = new BLEquivalencia();
                if (txtCodigoEquiv.Text.Trim().Length > 0)
                {
                    liCodigo = Int32.Parse(txtCodigoEquiv.Text.Trim());
                }
                if (rbActivoEquiv.Checked == true)
                {
                    lbEstado = 1;
                }
                lsResultado = objMarca.BLRegistrarEquivalencia(liCodigo, Convert.ToInt32(cboUMOrigen.SelectedValue), Convert.ToInt32(cboUMDestino.SelectedValue), Convert.ToDecimal(txtUMOrigen.Text),Convert.ToDecimal(txtUMDestino.Text), lbEstado,  objUtil.GetFechaHoraFormato(Variables.gdFechaSis, 2), Variables.gnCodUser, 2);
                if (lsResultado.Trim().Length > 0)
                {
                    MessageBox.Show(lsResultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Equivalencia de Unidad de Medida Registrada correctamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    pCancelarEquivalencia();
                }
                pCargarEquivalencia();
                pCargarCombosProducto();
            }
        }
        private void tsbGrabarProducto_Click(object sender, EventArgs e)
        {
            String lsResultado = "";
            Int32 liCodigo = 0;
            Int32 lbEstado = 0;
            clsUtil objUtil = new clsUtil();
            if (pValidaIngresoProducto() == false)
            {
                BLProducto objMarca = new BLProducto();
                if (txtCodigoProducto.Text.Trim().Length > 0)
                {
                    liCodigo = Int32.Parse(txtCodigoProducto.Text.Trim());
                }
                if (rbActivoProducto.Checked == true)
                {
                    lbEstado = 1;
                }
                lsResultado = objMarca.BLRegistrarProducto(liCodigo, Convert.ToString(txtNombreProducto.Text), Convert.ToString(txtDescripcionProducto.Text), Convert.ToInt32(cboCategoriaProducto.SelectedValue),Convert.ToInt32(cboUnidadMedidaProducto.SelectedValue), Convert.ToInt32(cboMarcaProducto.SelectedValue),Convert.ToDecimal(textBox1.Text.Trim()), lbEstado, objUtil.GetFechaHoraFormato(Variables.gdFechaSis, 2), Variables.gnCodUser);
                if (lsResultado.Trim().Length > 0)
                {
                    MessageBox.Show(lsResultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Producto Registrado Correctamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    pCancelarProducto();
                }
                pCargarProducto();
            }
        }
        private Boolean pValidaIngreso()
        {
            Boolean bValor=false ;
            if (txtNombreMarca.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Ingrese un Nombre de Marca.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor= true;
            }
            return bValor;
        }
        private Boolean pValidaIngresoCategoria()
        {
            Boolean bValor = false;
            if (txtNombreCategoria.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Ingrese un Nombre de Categoria.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
            }
            return bValor;
        }

        private Boolean pValidaIngresoUnidadMedida()
        {
            Boolean bValor = false;
            if (txtNombreUM.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Ingrese un Nombre de Unidad de Medida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
            }
            return bValor;
        }

        private Boolean pValidaIngresoEquivalencia()
        {
            decimal Resul;
            Boolean bValor = false;
            if(cboUMOrigen.Items.Count<=0 || cboUMDestino.Items.Count<=0)
            {
                MessageBox.Show("No seleccionó Unidades de Medida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
                return bValor;
            }
            if (decimal.TryParse(txtUMOrigen.Text.Trim(), out Resul))
            {
                if (decimal.TryParse(txtUMDestino.Text.Trim(), out Resul))
                {
                    bValor = false;
                }
                else
                {
                    MessageBox.Show("Ingrese correctamente el valor de la Unidad Destino.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    bValor = true;
                }
            }
            else
            {
                MessageBox.Show("Ingrese correctamente el valor de la Unidad Origen.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
            }
            return bValor;
        }
        private Boolean pValidaIngresoProducto()
        {
            Boolean bValor = false;
            if (txtNombreProducto.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Ingrese un Nombre de Producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
                return bValor;
            }
            if(cboCategoriaProducto.Items.Count<=0)
            {
                MessageBox.Show("Seleccione una Categoria.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
                return bValor;
            }
            if (cboUnidadMedidaProducto.Items.Count <= 0)
            {
                MessageBox.Show("Seleccione una Unidad de Medida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
                return bValor;
            }
           
            return bValor;
        }

        private void txtUMDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //Decimal ldNumerador = 0;
                //Decimal ldDenominador = 0;
                //Decimal ldResultado = 0;
                decimal Resul;
                if (decimal.TryParse(txtUMOrigen.Text.Trim(), out Resul))
                {
                    if (decimal.TryParse(txtUMDestino.Text.Trim(), out Resul))
                    {
                        //ldNumerador = Convert.ToDecimal(txtUMOrigen.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture);
                        //ldDenominador = Convert.ToDecimal(txtUMDestino.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture);
                        //ldResultado = ldNumerador / ldDenominador;
                        //ldResultado = Math.Round(ldResultado, 15);
                        //txtUMDestino.Text = Convert.ToString(ldResultado, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        MessageBox.Show("Ingrese correctamente el valor de la Unidad Destino.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        txtUMDestino.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese correctamente el valor de la Unidad Origen.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    txtUMOrigen.Text = "";
                }
                  
            }
        
        }
           
        private void tsbCancelarProducto_Click(object sender, EventArgs e)
        {
            pCancelarProducto();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnPrecio_Click(object sender, EventArgs e)
        {
            frmPrecio frm = new frmPrecio();
            int Codigo = txtCodigoProducto.Text.Trim() != "" ? Convert.ToInt32(txtCodigoProducto.Text.Trim()) :0;
            if (Codigo > 0)
            {
                frm.fnInicio(Codigo);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccionar un Producto del Listado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
