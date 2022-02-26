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

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmRegistrarProveedor : Form
    {
        public frmRegistrarProveedor()
        {
            InitializeComponent();
        }

        Int16 lnTipoCon = 0;
        Int16 lnTipoLlamada = 0;

        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();
        }

        private void fnHabilitarControles(Boolean pbHabilitar)
        {
            gbProveedor.Enabled = pbHabilitar;
            gbUbigeo.Enabled = pbHabilitar;
            saveToolStripButton.Enabled = pbHabilitar;
        }

        private void fnLimpiarControles()
        {
            txtIdProov.Text = "0";
            txtRazon.Text = "";
            txtRuc.Text = "";
            txtDireccion.Text = "";
            txtReferencia.Text = "";
            chkEstado.Checked = true;
            txtFijo.Text = "";
            txtCelular.Text = "";
            dateTimePicker1.Value = Variables.gdFechaSis;
            cboPais.SelectedValue = 0;
            cboDepartamento.SelectedValue = 0;
            cboProvincia.SelectedValue = 0;
            cboDistrito.SelectedValue = 0;
            txtBuscaProov.Text = "";
            lvProveedor.Visible = false;
            epUsuario.Clear();
            epControlOk.Clear();
            txtBuscaProov.Focus();

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnHabilitarControles(true);
            fnLimpiarControles();
        }

        private Boolean fnLLnenarProvinciaxDepa(Int32 idDepa)
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            List<Provincia> lstProv = new List<Provincia>();

            try
            {

                lstProv = objUbigeo.blDevolverProvincia(idDepa);
                cboProvincia.DataSource = null;
                cboProvincia.ValueMember = "idProv";
                cboProvincia.DisplayMember = "cNomProv";
                cboProvincia.DataSource = lstProv;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarProveedor", "fnLLnenarProvinciaxDepa", ex.Message);
                return false;
            }
            finally
            { lstProv = null; }
        }

        private Boolean fnLLnenarDistritoxProvincia(Int32 idProv)
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            List<Distrito> lstDist = new List<Distrito>();

            try
            {

                lstDist = objUbigeo.blDevolverDistrito(idProv);
                cboDistrito.DataSource = null;
                cboDistrito.ValueMember = "idDist";
                cboDistrito.DisplayMember = "cNomDist";
                cboDistrito.DataSource = lstDist;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarProveedor", "fnLLnenarProvinciaxDepa", ex.Message);
                return false;
            }
            finally
            { lstDist = null; }
        }

        private Boolean fnLlenarDepartamentoPorPais(Int32 idDepartamento)
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            List<Departamento> lstDepart = new List<Departamento>();

            try
            {
                lstDepart = objUbigeo.blDevolverDepartamento(idDepartamento);
                cboDepartamento.ValueMember = "idDepa";
                cboDepartamento.DisplayMember = "cNomDep";
                cboDepartamento.DataSource = lstDepart;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarProveedor", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        private Boolean fnLlenarPais()
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            List<Pais> lstPais = new List<Pais>();

            try
            {
                lstPais = objUbigeo.blDevolverPais(0);
                cboPais.ValueMember = "idPais";
                cboPais.DisplayMember = "nombre";
                cboPais.DataSource = lstPais;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarProveedor", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        private void frmRegistrarProveedor_Load(object sender, EventArgs e)
        {
            if (lnTipoLlamada == 0)
            {
                Boolean bResult = false;

                bResult = fnLlenarPais();
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Departamentos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   
                }

                
                fnHabilitarControles(false);
            }
            else if (lnTipoLlamada == 1)
            {
                this.Text = "Consultar Proveedor";
                Height = 500;
                lvProveedor.Visible = true;
                lvProveedor.Left = 12;
                lvProveedor.Top = 60;
                lvProveedor.Height = 390;
                lvProveedor.Width = 693;
                fnOcultarObjeto(lnTipoLlamada);
            }
            else if (lnTipoLlamada == 2)
            {
                Boolean bResult = false;


                bResult = fnLlenarPais();
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Departamentos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                fnHabilitarControles(true);
                fnOcultarObjeto(lnTipoLlamada);
            }

        }

        private void fnOcultarObjeto(Int16 lnTipo)
        {
            if (lnTipo == 1)
            {
                gbProveedor.Visible = false;
                gbUbigeo.Visible = false;
                tsBotonera.Visible = false;
            }
            else if (lnTipo == 2)
            {
                gbBuscarDepa.Visible = false;
                txtBuscaProov.Visible = false;
            }
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.SelectedValue != null)
            {
                Boolean bResul = false;
                bResul = fnLLnenarProvinciaxDepa(Convert.ToInt32(cboDepartamento.SelectedValue));

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Provincias por Departamento","Aviso!!!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedValue != null)
            {
                Boolean bResul = false;
                bResul = fnLLnenarDistritoxProvincia(Convert.ToInt32(cboProvincia.SelectedValue));

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Provincias por Departamento", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private Boolean fnRecuperarProveedorEsp()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (lvProveedor.Items.Count > 0)
                {
                    ListView.SelectedListViewItemCollection item = lvProveedor.SelectedItems;
                    if (item.Count > 0)
                    {
                        Procesos.frmOrdenCompraEquipos.fnRecuperarProveedor(item[0].SubItems[1].Text.ToString().Trim(), item[0].SubItems[3].Text.ToString().Trim(), item[0].SubItems[2].Text.ToString());
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarProveedor", "fnRecuperarProveedorEsp", ex.Message);
                return false;
            }
        }

        private Boolean fnBuscarProveedor(String pcBuscar, Int16 pnTipoCon)
        {
            BLProveedor objProv = new BLProveedor();
            Boolean pbhabilitaLista = false;


            clsUtil objUtil = new clsUtil();
            List<Proveedor> lstProveedor = null;
            ListViewItem lstItem = null;
            try
            {

                lstProveedor = new List<Proveedor>();
                lstProveedor = objProv.blDevolverProveedor(pcBuscar, pnTipoCon);
                lvProveedor.Items.Clear();
                foreach (Proveedor objProov in lstProveedor)
                {
                    lstItem = lvProveedor.Items.Add(objProov.idProveedor.ToString());
                    lstItem.SubItems.Add(objProov.cNomProveedor);
                    lstItem.SubItems.Add(objProov.cDocumento);
                    lstItem.SubItems.Add(objProov.cDireccion);
                    pbhabilitaLista = true;
                }

                lvProveedor.Visible = pbhabilitaLista;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarProveedor", "fnBuscarProveedor", ex.Message);
                return false;
            }
            finally
            { 
             objProv=null;
            }

        }

        private void txtBuscaProov_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon = 0;
                Boolean bResul = false;

                if (rbCodigo.Checked == true)
                {

                    pnTipocon = 0;
                }
                else if (rbRazon.Checked == true)
                {
                    pnTipocon = 1;
                }
                else if (rbDoc.Checked == true)
                {
                    pnTipocon = 2;
                }

                bResul=fnBuscarProveedor(txtBuscaProov.Text.Trim(), pnTipocon);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Proveedor. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private String fnGuardarProveedor(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLProveedor blobjProov = new BLProveedor();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Proveedor objProov = new Proveedor();
            //Boolean bCargar = false;

            try
            {
                objProov.idProveedor = Convert.ToInt32(txtIdProov.Text.Trim());
                objProov.cNomProveedor = Convert.ToString(txtRazon.Text.Trim());
                objProov.cDocumento = Convert.ToString(txtRuc.Text.Trim());
                objProov.cDireccion = Convert.ToString(txtDireccion.Text.Trim());
                objProov.cReferencia = Convert.ToString(txtReferencia.Text.Trim());
                objProov.cTelFijo = Convert.ToString(txtFijo.Text.Trim());
                objProov.cTelCelular = Convert.ToString(txtCelular.Text.Trim());
                objProov.dFechaCreacion = Convert.ToDateTime(dateTimePicker1.Value);
                objProov.bEstado = Convert.ToBoolean(chkEstado.Checked);
                objProov.dFechaReg = dFechaSis;
                objProov.idUsuario = Variables.gnCodUser;
                objProov.idZona = Convert.ToInt32(cboDistrito.SelectedValue);

                lcValidar = blobjProov.blGrabarProveedor(objProov, idTipoCon).Trim();
                fnLimpiarControles();
                fnHabilitarControles(false);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarProveedor", "fnGuardarProveedor", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            String lcResultado = "";
            String lcProveedor = "";
            String lcDireccion = "";
            String lcDoc = "";

            epControlOk.Clear();
            epUsuario.Clear();

            if (txtRazon.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtRazon, "");
                epUsuario.SetError(txtRazon, "Ingresar Razon Social");
            }
            else
            {
                epUsuario.SetError(txtRazon, "");
                epControlOk.SetError(txtRazon, "Ingreso Correcto de Razon Social");
            }

            if (txtRuc.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtRuc, "");
                epUsuario.SetError(txtRuc, "Ingresar Documento");
            }
            else
            {
                epUsuario.SetError(txtRuc, "");
                epControlOk.SetError(txtRuc, "Ingreso Correcto de Documento");
            }
            if (cboDepartamento.SelectedValue == null)            
            {
                epControlOk.SetError(cboDepartamento, "");
                epUsuario.SetError(cboDepartamento, "Elegir Departamento");
            }
            else
            {
                epUsuario.SetError(cboDepartamento, "");
                epControlOk.SetError(cboDepartamento, "Eligio Departamento Correcto");
            }
            if (cboProvincia.SelectedValue == null)    
            {
                epControlOk.SetError(cboProvincia, "");
                epUsuario.SetError(cboProvincia, "Elegir Provincia");
            }
            else
            {
                epUsuario.SetError(cboProvincia, "");
                epControlOk.SetError(cboProvincia, "Eligio Provincia Correcta");
            }
            if (cboDistrito.SelectedValue == null)
            {
                epControlOk.SetError(cboDistrito, "");
                epUsuario.SetError(cboDistrito, "Elegir Distrito");
            }
            else
            {
                epUsuario.SetError(cboDistrito, "");
                epControlOk.SetError(cboDistrito, "Eligio Distrito Correcto");
            }


            if (txtRazon.Text.Trim().Length > 0 && txtRuc.Text.Trim().Length > 0 && cboDepartamento.SelectedValue != null && cboProvincia.SelectedValue != null && cboDistrito.SelectedValue != null)
            {
                lcProveedor = txtRazon.Text.Trim();
                lcDireccion = txtDireccion.Text;
                lcDoc = txtRuc.Text.Trim();

                lcResultado = fnGuardarProveedor(lnTipoCon);
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente Proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (lnTipoLlamada == 2)
                    {
                        Procesos.frmOrdenCompra.fnRecuperarProveedor(lcProveedor, lcDireccion, lcDoc);
                        this.Dispose();
                    }     
                }
                else
                {
                    MessageBox.Show("Error al Grabar Proveedor. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private Boolean fnListarProveedorEspecifico()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (lvProveedor.Items.Count > 0)
                {
                    BLProveedor objProvee = new BLProveedor();
                    Proveedor[] lstProvee = new Proveedor[1];

                    ListView.SelectedListViewItemCollection item = lvProveedor.SelectedItems;
                    lstProvee = objProvee.blListarProveedor(Convert.ToInt32(item[0].SubItems[0].Text)).ToArray();
                    txtIdProov.Text = Convert.ToString(lstProvee[0].idProveedor);
                    txtRazon.Text = Convert.ToString(lstProvee[0].cNomProveedor);
                    txtRuc.Text = Convert.ToString(lstProvee[0].cDocumento);
                    txtDireccion.Text = Convert.ToString(lstProvee[0].cDireccion);
                    txtReferencia.Text = Convert.ToString(lstProvee[0].cReferencia);
                    txtFijo.Text = Convert.ToString(lstProvee[0].cTelFijo);
                    txtCelular.Text = Convert.ToString(lstProvee[0].cTelCelular);
                    dateTimePicker1.Value = lstProvee[0].dFechaCreacion;
                    chkEstado.Checked = Convert.ToBoolean(lstProvee[0].bEstado);
                    cboDepartamento.Text = Convert.ToString(lstProvee[0].cNomDep.Trim());
                    cboProvincia.Text = Convert.ToString(lstProvee[0].cNomProv.Trim());
                    cboDistrito.Text = Convert.ToString(lstProvee[0].cNomDist.Trim());
                    lvProveedor.Visible = false;
                    fnHabilitarControles(true);
                    txtBuscaProov.Text = "";
                    lnTipoCon = 1;
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarProveedor", "fnListarProveedorEspecifico", ex.Message);
                return false;
            }
        }

        private void lvProveedor_DoubleClick(object sender, EventArgs e)
        {
            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                bResul = fnListarProveedorEspecifico();
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Proveedor Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            else if (lnTipoLlamada == 1)
            {
                Boolean bResul = false;
                bResul = fnRecuperarProveedorEsp();
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar Proveedor Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else { this.Dispose(); }

            }

        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (lnTipoLlamada == 0)
                {
                    Boolean bResul = false;
                    bResul = fnListarProveedorEspecifico();
                    if (!bResul)
                    {
                        MessageBox.Show("Error al Cargar Proveedor Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                }
                else if (lnTipoLlamada == 1)
                { 
                    Boolean bResul = false;
                    bResul = fnRecuperarProveedorEsp();
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar Proveedor Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else { this.Dispose(); }
                    
                }
            }
        }

        private void rbRazon_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRazon.Checked == true)
            {
                fnLimpiarControles();
                fnHabilitarControles(false);
            }
        }

        private void rbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCodigo.Checked == true)
            {
                fnLimpiarControles();
                fnHabilitarControles(false);
            }
        }

        private void rbDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDoc.Checked == true)
            {
                fnLimpiarControles();
                fnHabilitarControles(false);
            }
        }

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResul ;
            Int32 idPais = Convert.ToInt32(cboPais.SelectedValue == null ? "0" : cboPais.SelectedValue.ToString());
            {
               
                bResul = fnLlenarDepartamentoPorPais(Convert.ToInt32(idPais));

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Departamento por Pais", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }
    }
}
