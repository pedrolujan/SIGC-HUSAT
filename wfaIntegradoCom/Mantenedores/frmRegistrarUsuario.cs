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
    public partial class frmRegistrarUsuario : Form
    {
        public frmRegistrarUsuario()
        {
            InitializeComponent();
        }

        Int16 lnTipoCon = 0;
        
        private Boolean fnCargarUsuario(Int32 idUsuario)
        {
            BLUsuario objUsuario = new BLUsuario();


            clsUtil objUtil = new clsUtil();
            List<Usuario> lstUsuario = null;
            try
            {

                lstUsuario = new List<Usuario>();
                lstUsuario = objUsuario.daDevolverUsuario(0);
                usuarioBindingSource.DataSource = lstUsuario;
                dgvUsuario.DataSource = usuarioBindingSource.DataSource;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarUsuario", "fnCargarUsuario", ex.Message);
                return false;  
            }

        }

        private void fnCargarComboPersonal()
        {
            BLPersonal objPersonal = new BLPersonal();
            List<Personal> lstPersonal = new List<Personal>();
            clsUtil objUtil= new clsUtil();

            try
            {

                lstPersonal = objPersonal.blDevolverPersonal(0);
                comboBox1.DataSource = lstPersonal;
                comboBox1.DisplayMember = "cPersonal";
                comboBox1.ValueMember = "idPersonal";
    
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarUsuario", "fnCargarComboPersonal", ex.Message);
            }

        }

        private void frmRegistrarUsuario_Load(object sender, EventArgs e)
        {
            Boolean bResul = false;

            bResul =fnCargarUsuario(0);
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar Usuarios", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            fnCargarComboPersonal();
            fnHabilitarControles(false);
        }

        private void fnDevolverUsuario(Int32 idUsuario)
        {
            BLUsuario objUsuario = new BLUsuario();
            clsUtil objUtil = new clsUtil();

            Usuario[] arrUsuario = new Usuario[1];
            try
            {
                arrUsuario = objUsuario.daDevolverUsuario(idUsuario).ToArray();
                txtIdUsuario.Text = arrUsuario[0].idUsuario.ToString().Trim();
                txtUsuario.Text = arrUsuario[0].cUser.ToString().Trim();
                txtClave.Text = arrUsuario[0].cClave.ToString().Trim();
                chkEstado.Checked = Convert.ToBoolean(arrUsuario[0].bEstado);
                comboBox1.Text = Convert.ToString(arrUsuario[0].cPersonal);
            }
            catch (Exception ex)
            { 
                objUtil.gsLogAplicativo("frmRegitsrarUsuario","fnDevolverUsuario",ex.Message);
                MessageBox.Show("Error al Obtener Datos de Usuario. Comunicar con Administrador de Sistema", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvUsuario_CurrentCellChanged(object sender, EventArgs e)
        {
          
        }

        private void fnHabilitarControles(Boolean pbHabilitar)
        {
            gbUsuario.Enabled = pbHabilitar;
            saveToolStripButton.Enabled = pbHabilitar;
        }

        private void fnLimpiarControles()
        {
            txtIdUsuario.Text = "0";
            txtUsuario.Text = "";
            txtClave.Text = "";
            chkEstado.Checked = true;
            comboBox1.SelectedIndex = -1;
            epControlOk.Clear();
            epUsuario.Clear();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnHabilitarControles(true);
            fnLimpiarControles();
        }

        private String fnGuardarUsuario( Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLUsuario objblUsuario= new BLUsuario();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Usuario objUsuario = new Usuario();
            Boolean bCargar = false;

            try
            {
                objUsuario.idUsuario = Convert.ToInt32(txtIdUsuario.Text);
                objUsuario.cUser = Convert.ToString(txtUsuario.Text.Trim());
                objUsuario.cClave = txtClave.Text;
                objUsuario.bEstado = Convert.ToBoolean(chkEstado.Checked);
                objUsuario.idPersonal = Convert.ToInt32(comboBox1.SelectedValue);
                objUsuario.dFechaReg = dFechaSis;
                objUsuario.dFechaActua = dFechaSis;
                objUsuario.idUserReg = Variables.gnCodUser;

                lcValidar=objblUsuario.daGrabarUsuario(objUsuario, idTipoCon).Trim();

                bCargar=fnCargarUsuario(0);
                if (bCargar == false)
                {
                    lcValidar = "XX";
                    return lcValidar;
                }
                    fnLimpiarControles();
                    fnHabilitarControles(false);

                                
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarUsuario", "fnGuardarUsuario", ex.Message);
                lcValidar= "NO";
            }

            return lcValidar;

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            String lcResultado = "";

            epControlOk.Clear();
            epUsuario.Clear();

            if (txtUsuario.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtUsuario, "");
                epUsuario.SetError(txtUsuario, "Ingresar Usuario");
            }
            else {
                epUsuario.SetError(txtUsuario, ""); 
                epControlOk.SetError(txtUsuario, "Ingreso Usuario Correcto");
               }
            if (txtClave.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtClave, "");
                epUsuario.SetError(txtClave, "Ingresar Clave");
            }
            else {
                epUsuario.SetError(txtClave, "");
                epControlOk.SetError(txtClave, "Ingreso Clave Correcto"); 
            }
            if (comboBox1.SelectedValue == null)
            {
                epControlOk.SetError(comboBox1, "");
                epUsuario.SetError(comboBox1, "Elegir Personal"); }
            else { 
                epUsuario.SetError(comboBox1, "");
                epControlOk.SetError(comboBox1, "Eligio Personal");
            }


            if (txtUsuario.Text.Trim().Length > 0 && txtClave.Text.Trim().Length > 0 && comboBox1.SelectedValue != null)
            {
                lcResultado= fnGuardarUsuario(lnTipoCon);
                if (lcResultado=="OK")
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente Usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (lcResultado == "XX")
                {
                    MessageBox.Show("Error al Cargar Usuarios. Vuelva a Ingresar a Formulario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);     
                }
                else{
                    MessageBox.Show("Error al Grabar Usuario. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            
        }

        private void dgvUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lnTipoCon = 1;
            fnHabilitarControles(true);
        }
        
        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvUsuario_SelectionChanged_1(object sender, EventArgs e)
        {
            int idUsuario = 0;
            Boolean bFilaSele = false;
            if (dgvUsuario.RowCount > 0)
            {
                bFilaSele = dgvUsuario.CurrentRow.Selected;

                if (bFilaSele)
                {
                    idUsuario = Convert.ToInt32(dgvUsuario.CurrentRow.Cells[0].Value);
                    fnLimpiarControles();
                    fnDevolverUsuario(idUsuario);
                    fnHabilitarControles(false);
                }
            }
        }

      
    }
}
