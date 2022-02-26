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
    public partial class frmRegistrarUbigeo : Form
    {
        public frmRegistrarUbigeo()
        {
            InitializeComponent();
        }

        Int16 lnTipoCon = 0;

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
                objUtil.gsLogAplicativo("frmRegitsrarUbigeo", "fnLLnenarProvinciaxDepa", ex.Message);
                return false;
            }
            finally
            { lstProv = null; }
        }

        private Boolean fnLLnenarProvincia()
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            List<Provincia> lstProv = new List<Provincia>();

            try
            {
                
                lstProv = objUbigeo.blDevolverProvincia(0);
                cboProvincia.ValueMember = "idProv";
                cboProvincia.DisplayMember = "cNomProv";
                cboProvincia.DataSource = lstProv;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarUbigeo", "fnLLnenarProvincia", ex.Message);
                return false;
            }
            finally
            { lstProv = null; }
        }

        private Boolean fnLlenarDepartamento(ComboBox Combo)
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            List<Departamento> lstDepart= new List<Departamento>();

            try
            {
                lstDepart = objUbigeo.blDevolverDepartamento(0);
                Combo.ValueMember = "idDepa";
                Combo.DisplayMember = "cNomDep";
                Combo.DataSource = lstDepart;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarUbigeo", "fnLlenarDepartamento", ex.Message);
                return false;         
            }

        }

        private Boolean fnBuscarDepartamento(String pcBuscar, Int16 pnTipoCon)
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            Boolean pbhabilitaLista = false;


            clsUtil objUtil = new clsUtil();
            List<Departamento> lstDepartamento = null;
            ListViewItem lstItem = null;
            try
            {

                lstDepartamento = new List<Departamento>();
                lstDepartamento = objUbigeo.blBuscarDepartamento(pcBuscar, pnTipoCon);
                lvDepa.Items.Clear();
                foreach(Departamento objDepa in lstDepartamento)
                {
                    lstItem = lvDepa.Items.Add(objDepa.idDepa.ToString());
                    lstItem.SubItems.Add(objDepa.cNomDep);
                    lstItem.SubItems.Add(objDepa.bEstado.ToString());
                    pbhabilitaLista = true;
                }

                lvDepa.Visible = pbhabilitaLista;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarUbigeo", "fnBuscarDepartamento", ex.Message);
                return false;
            }

        }

        private Boolean fnBuscarProvincia(String pcBuscar, Int16 pnTipoCon)
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            Boolean pbhabilitaLista = false;


            clsUtil objUtil = new clsUtil();
            List<Provincia> lstProv = null;
            ListViewItem lstItem = null;
            try
            {

                lstProv = new List<Provincia>();
                lstProv = objUbigeo.blBuscarProvincia(pcBuscar, pnTipoCon);
                lvProvincia.Items.Clear();
                foreach (Provincia objProv in lstProv)
                {
                    lstItem = lvProvincia.Items.Add(objProv.idProv.ToString());
                    lstItem.SubItems.Add(objProv.cNomProv);
                    lstItem.SubItems.Add(objProv.cNomDep);
                    lstItem.SubItems.Add(objProv.bEstado.ToString());
                    pbhabilitaLista = true;
                }

                lvProvincia.Visible = pbhabilitaLista;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarUbigeo", "fnBuscarProvincia", ex.Message);
                return false;
            }

        }

        private Boolean fnBuscarDistrito(String pcBuscar, Int16 pnTipoCon)
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            Boolean pbhabilitaLista = false;


            clsUtil objUtil = new clsUtil();
            List<Distrito> lstDist = null;
            ListViewItem lstItem = null;
            try
            {

                lstDist = new List<Distrito>();
                lstDist = objUbigeo.blBuscarDistrito(pcBuscar, pnTipoCon);
                lvDistrito.Items.Clear();
                foreach (Distrito objDist in lstDist)
                {
                    lstItem = lvDistrito.Items.Add(objDist.idDist.ToString());
                    lstItem.SubItems.Add(objDist.cNomDist);
                    lstItem.SubItems.Add(objDist.cNomProv);
                    lstItem.SubItems.Add(objDist.cNomDep);
                    lstItem.SubItems.Add(objDist.bEstado.ToString());
                    pbhabilitaLista = true;
                }

                lvDistrito.Visible = pbhabilitaLista;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarUbigeo", "fnBuscarProvincia", ex.Message);
                return false;
            }

        }

        private void tbUbigeo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean lbResul = false;
            if (tbUbigeo.SelectedIndex == 0)
            {
                fnHabilitarControles(false,1);
                fnLimpiarControles(1);
            }
            else if (tbUbigeo.SelectedIndex == 1)
            {
                fnHabilitarControles(false, 2);
                fnLimpiarControles(2);
                lbResul=fnLlenarDepartamento(cboDepartamento);
                if (!lbResul)
                {
                    MessageBox.Show("Error al Obtener Listado de Departamentos", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else {
                fnHabilitarControles(false, 3);
                fnLimpiarControles(3);
                lbResul = fnLlenarDepartamento(cboDepartamento2);
                if (!lbResul) MessageBox.Show("Error al Obetner Listado de Departamentos", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lbResul = fnLLnenarProvincia();
                if (!lbResul) MessageBox.Show("Error al Obetner Listado de Provincias", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void fnHabilitarControles(Boolean pbHabilitar,Int16 pnTipoTab)
        {
            if (pnTipoTab==1)
            {
                gbDepa.Enabled = pbHabilitar;
                saveToolStripButton.Enabled = pbHabilitar;
            }
            else if (pnTipoTab == 2)
            {
                gbProv.Enabled = pbHabilitar;
                toolStripButton2.Enabled = pbHabilitar;

            }
            else {
                gbDist.Enabled = pbHabilitar;
                toolStripButton5.Enabled = pbHabilitar;
            }
        }

        private void fnLimpiarControles(Int16 pnTipoTab)
        {
            if (pnTipoTab == 1)
            {
                txtCodDepa.Text = "0";
                txtDepartamento.Text = "";
                chkEstadoDepa.Checked = true;
                lvDepa.Visible = false;
                txtBuscarDepa.Text = "";
                epUsuario.Clear();
                txtBuscarDepa.Focus();
            }
            else if (pnTipoTab == 2)
            {
                txtCodProv.Text = "0";
                txtProvincia.Text = "";
                cboDepartamento.SelectedIndex = -1;
                chkEstadoDepa.Checked = true;
                epUsuario.Clear();
                epControlOk.Clear();
                lvProvincia.Visible = false;
                txtBuscarProv.Text = "";
                txtBuscarProv.Focus();
            }
            else 
            {
                txtCodDist.Text = "0";
                txtDistrito.Text = "";
                cboDepartamento2.SelectedIndex = -1;
                cboProvincia.SelectedIndex = -1;
                chkEstadoDist.Checked = true;
                epUsuario.Clear();
                epControlOk.Clear();
                lvDistrito.Visible = false;
                txtBuscarDist.Text = "";
                txtBuscarDist.Focus();
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnHabilitarControles(true,1);
            fnLimpiarControles(1);
        }

      
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            String lcResultado = "";

            epUsuario.Clear();

            if (txtDepartamento.Text.Trim().Length <= 0)
            {
                epUsuario.SetError(txtDepartamento, "Ingresar Usuario");
            }
            else
            {
                epUsuario.SetError(txtDepartamento, "");
            }
          

            if (txtDepartamento.Text.Trim().Length > 0 )
            {
                lcResultado = fnGuardarDepartamento(lnTipoCon);
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente Departamento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Grabar Departamento. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txtBuscarDepa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon=0;

                if(rbCodigo.Checked ==true)
                {

                    pnTipocon=0;
                }
                else{
                  pnTipocon=1;
                }

                fnBuscarDepartamento(txtBuscarDepa.Text.Trim(), pnTipocon);
            }
        }

        private void rbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCodigo.Checked==true)
            {
                fnLimpiarControles(1);
                fnHabilitarControles(false, 1);
            }
        }

        private void rbDepa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDepa.Checked == true)
            {
                txtBuscarDepa.Text = "";
                txtBuscarDepa.Focus();
                lvDepa.Visible = false;
            }
        }

        private String fnGuardarDepartamento(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Departamento objDepa = new Departamento();
            //Boolean bCargar = false;

            try
            {
                objDepa.idDepa = Convert.ToInt32(txtCodDepa.Text);
                objDepa.cNomDep = Convert.ToString(txtDepartamento.Text.Trim());
                objDepa.bEstado = Convert.ToBoolean(chkEstadoDepa.Checked);
                objDepa.dFechaReg = dFechaSis;
                objDepa.idUsuario = Variables.gnCodUser;

                lcValidar = objUbigeo.blGrabarDepartamento(objDepa, idTipoCon).Trim();
                fnLimpiarControles(1);
                fnHabilitarControles(false,1);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarUbigeo", "fnGuardarDepartamento", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            String lcResultado = "";

            epUsuario.Clear();

            if (txtProvincia.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtProvincia, "");
                epUsuario.SetError(txtProvincia, "Ingresar Nombre de Provincia");
            }
            else
            {
                epUsuario.SetError(txtProvincia, "");
                epControlOk.SetError(txtProvincia, "Ingreso Correcto de Provincia");

            }
            if (cboDepartamento.SelectedValue == null)
            {
                epControlOk.SetError(cboDepartamento, "");
                epUsuario.SetError(cboDepartamento, "Elegir Departamento!!!");
            }
            else
            {
                epUsuario.SetError(cboDepartamento, "");
                epControlOk.SetError(cboDepartamento, "Eligio Departamento Correcto");
            }


            if (txtProvincia.Text.Trim().Length > 0 && cboDepartamento.SelectedValue !=null)
            {
                lcResultado = fnGuardarProvincia(lnTipoCon);
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente Provincia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Grabar Provincia. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnHabilitarControles(true, 2);
            fnLimpiarControles(2);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscarProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon = 0;

                if (rbCodProv.Checked == true)
                {
                    pnTipocon = 0;
                }
                if(rbNomProv.Checked== true)
                {
                    pnTipocon = 1;
                }

                fnBuscarProvincia(txtBuscarProv.Text.Trim(), pnTipocon);
            }
        }

        private void txtBuscarDist_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon = 0;
                bool lbResul = false;

                if (rbCodDist.Checked == true)
                {
                    pnTipocon = 0;
                }
                if (rbDist.Checked == true)
                {
                    pnTipocon = 1;
                }

                lbResul = fnBuscarDistrito(txtBuscarDist.Text.Trim(), pnTipocon);

                if (lbResul == false) MessageBox.Show("Error al Buscar Distrito. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void rbCodProv_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCodProv.Checked == true)
            {
                fnLimpiarControles(2);
                fnHabilitarControles(false, 2);
            }
        }

        private void rbNomProv_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNomProv.Checked == true)
            {
                fnLimpiarControles(2);
                fnHabilitarControles(false, 2);
            }
        }


        private String fnGuardarProvincia(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Provincia objProv = new Provincia();
            //Boolean bCargar = false;

            try
            {
                objProv.idProv = Convert.ToInt32(txtCodProv.Text);
                objProv.cNomProv = Convert.ToString(txtProvincia.Text.Trim());
                objProv.idDepa = Convert.ToInt32(cboDepartamento.SelectedValue);
                objProv.bEstado = Convert.ToBoolean(chkEstadoProv.Checked);
                objProv.dFechaReg = dFechaSis;
                objProv.idUsuario = Variables.gnCodUser;

                lcValidar = objUbigeo.blGrabarProvincia(objProv, idTipoCon).Trim();
                fnLimpiarControles(2);
                fnHabilitarControles(false, 2);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarUbigeo", "fnGuardarProvincia", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private String fnGuardarDistrito(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Distrito objDist = new Distrito();
            //Boolean bCargar = false;

            try
            {
                objDist.idDist = Convert.ToInt32(txtCodDist.Text);
                objDist.idProv = Convert.ToInt32(cboProvincia.SelectedValue);
                objDist.cNomDist = Convert.ToString(txtDistrito.Text.Trim());
                objDist.bEstado = Convert.ToBoolean(chkEstadoDist.Checked);
                objDist.dFechaReg = dFechaSis;
                objDist.idUsuario = Variables.gnCodUser;

                lcValidar = objUbigeo.blGrabarDistrito(objDist, idTipoCon).Trim();
                fnLimpiarControles(3);
                fnHabilitarControles(false, 3);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarUbigeo", "fnGuardarDistrito", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            String lcResultado = "";

            epUsuario.Clear();

            if (txtDistrito.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtDistrito, "");
                epUsuario.SetError(txtDistrito, "Ingresar Nombre de Distrito");
            }
            else
            {
                epUsuario.SetError(txtProvincia, "");
                epControlOk.SetError(txtDistrito, "Distrito Correcto");
            }
            if (cboDepartamento2.SelectedValue == null)
            {
                epControlOk.SetError(cboDepartamento2, "");
                epUsuario.SetError(cboDepartamento2, "Elegir Departamento!!!");
            }
            else
            {
                epUsuario.SetError(cboDepartamento2, "");
                epControlOk.SetError(cboDepartamento2, "Eligio Departamento Correcto");
            }
            if (cboProvincia.SelectedValue == null)
            {
                epControlOk.SetError(cboProvincia, "");
                epUsuario.SetError(cboProvincia, "Elegir Provincia!!!");
            }
            else
            {
                epUsuario.SetError(cboProvincia, "");
                epControlOk.SetError(cboProvincia, "Eligio Provincia Correcta");
            }


            if (txtDistrito.Text.Trim().Length > 0 && cboDepartamento2.SelectedValue != null && cboProvincia.SelectedValue != null)
            {
                lcResultado = fnGuardarDistrito(lnTipoCon);
                if (lcResultado == "OK")
                {
                    
                    MessageBox.Show("Se Grabo Satisfactoriamente Distrito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Grabar Distrito. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnHabilitarControles(true, 3);
            fnLimpiarControles(3);
        }

        private void cboDepartamento2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento2.SelectedValue !=null)
            {
                fnLLnenarProvinciaxDepa(Convert.ToInt32(cboDepartamento2.SelectedValue));
            }
        }

        private void lvDepa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lvDepa.Items.Count > 0)
            {
                ListView.SelectedListViewItemCollection item = lvDepa.SelectedItems;
                txtCodDepa.Text = item[0].SubItems[0].Text;
                txtCodProv.Text = item[0].SubItems[1].Text;
                chkEstadoProv.Checked = Convert.ToBoolean(item[0].SubItems[3].Text);
                lvDepa.Visible = false;
                fnHabilitarControles(true, 1);
                txtBuscarDepa.Text = "";
                lnTipoCon = 1;
            }
        }

        private void lvDepa_DoubleClick(object sender, EventArgs e)
        {
            if (lvDepa.Items.Count > 0)
            {
                ListView.SelectedListViewItemCollection item = lvDepa.SelectedItems;
                txtCodDepa.Text = item[0].SubItems[0].Text;
                txtCodProv.Text = item[0].SubItems[1].Text;
                chkEstadoProv.Checked = Convert.ToBoolean(item[0].SubItems[3].Text);
                lvDepa.Visible = false;
                fnHabilitarControles(true, 1);
                txtBuscarDepa.Text = "";
                lnTipoCon = 1;
            }
        }

        private void lvDistrito_DoubleClick(object sender, EventArgs e)
        {
            if (lvDistrito.Items.Count > 0)
            {
                ListView.SelectedListViewItemCollection item = lvDistrito.SelectedItems;
                txtCodDist.Text = item[0].SubItems[0].Text;
                txtDistrito.Text = item[0].SubItems[1].Text;
                cboProvincia.Text = item[0].SubItems[2].Text;
                cboDepartamento2.Text = item[0].SubItems[3].Text;
                chkEstadoDist.Checked = Convert.ToBoolean(item[0].SubItems[4].Text);
                lvDistrito.Visible = false;
                fnHabilitarControles(true, 3);
                txtBuscarProv.Text = "";
                lnTipoCon = 1;
            }
        }

        private void lvDistrito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lvDistrito.Items.Count > 0)
            {
                ListView.SelectedListViewItemCollection item = lvDistrito.SelectedItems;
                txtCodDist.Text = item[0].SubItems[0].Text;
                txtDistrito.Text = item[0].SubItems[1].Text;
                cboProvincia.Text = item[0].SubItems[2].Text;
                cboDepartamento2.Text = item[0].SubItems[3].Text;
                chkEstadoDist.Checked = Convert.ToBoolean(item[0].SubItems[4].Text);
                lvDistrito.Visible = false;
                fnHabilitarControles(true, 3);
                txtBuscarProv.Text = "";
                lnTipoCon = 1;
            }
        }

    

        private void lvProvincia_DoubleClick(object sender, EventArgs e)
        {
            if (lvProvincia.Items.Count > 0)
            {
                ListView.SelectedListViewItemCollection item = lvProvincia.SelectedItems;
                txtCodProv.Text = item[0].SubItems[0].Text;
                txtProvincia.Text = item[0].SubItems[1].Text;
                cboDepartamento.Text = item[0].SubItems[2].Text;
                chkEstadoProv.Checked = Convert.ToBoolean(item[0].SubItems[3].Text);
                lvProvincia.Visible = false;
                fnHabilitarControles(true, 2);
                txtBuscarProv.Text = "";
                lnTipoCon = 1;
            }
        }

        private void lvProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lvProvincia.Items.Count > 0)
            {
                ListView.SelectedListViewItemCollection item = lvProvincia.SelectedItems;
                txtCodProv.Text = item[0].SubItems[0].Text;
                txtProvincia.Text = item[0].SubItems[1].Text;
                cboDepartamento.Text = item[0].SubItems[2].Text;
                chkEstadoProv.Checked = Convert.ToBoolean(item[0].SubItems[3].Text);
                lvProvincia.Visible = false;
                fnHabilitarControles(true, 2);
                txtBuscarProv.Text = "";
                lnTipoCon = 1;
            }
        }

        private void rbCodDist_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCodDist.Checked == true)
            {
                fnLimpiarControles(3);
                fnHabilitarControles(false, 3);
            }
        }

        private void rbDist_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDist.Checked == true)
            {
                fnLimpiarControles(3);
                fnHabilitarControles(false, 3);
            }
        }

        private void frmRegistrarUbigeo_Load(object sender, EventArgs e)
        {

        }
    }
}
