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
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Procesos;

namespace wfaIntegradoCom
{
    public partial class frmUsuario : Form
    {
        BLSucursal objBLSucursal = null;
        public frmUsuario()
        {
            InitializeComponent();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void fnValidarUsuario(String pcUsuario,String pcClave,String pcMaquina,String pcVersion,Int32 pnAplicacion )
        {
            BLAcceso objAccesso = new BLAcceso();
            String lcResultado = "";
            Int32 lnidUsuario=0;

            lcResultado=objAccesso.BLValidarIngreso(dateTimePicker1.Value,pcUsuario, pcClave, pcMaquina, pcVersion, pnAplicacion,out lnidUsuario);

            if (lcResultado.Trim() == "OK")
            {
                objBLSucursal = new BLSucursal();
                Variables.gsCodUser = pcUsuario;
                Variables.gsVersion = lblVersion.Text;
                Variables.gnCodUser = lnidUsuario;
                Variables.idSucursal = Convert.ToInt16(cboSucursal.SelectedValue);
                Variables.gsSucursal = cboSucursal.Text.Trim();
                Variables.gdFechaSis = DateTime.Now;
                Variables.sucursal = objBLSucursal.DAListarSucursalxID(Variables.idSucursal);
                DialogResult = DialogResult.OK;
                DataTable dtResp = new DataTable();
                dtResp = objAccesso.BLBuscarCargoUsuario(Variables.gnCodUser);
                Variables.clasePersonal=FunGeneral.fnObtenerUsuarioActual();


                //Loading();

                foreach (DataRow dr in dtResp.Rows)
                {
                    Variables.gsCargoUsuario = Convert.ToString(dr["cCodTab"]);
                }

            }
            else if (lcResultado.Trim()== "Usuario no Registrado.")
            {
                txtUser.Text = "";
                txtClave.Text = "";
                txtUser.Focus();
                MessageBox.Show(lcResultado.Trim(), "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else {
                //txtUser.Text = "";
                txtClave.Text = "";
                txtClave.Focus();
                MessageBox.Show(lcResultado.Trim(),"Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        public void fnInicarSesion()
        {
           
            String pcUsuario = "", pcClave = "", pcMaquina = "", pcVersion = "";

            pcUsuario = txtUser.Text.Trim();
            pcClave = txtClave.Text.Trim();
            pcMaquina = Environment.MachineName.Trim();
            pcVersion = lblVersion.Text.Trim();
            if (pcUsuario != "")
            {
                if (pcClave != "")
                {
                    fnValidarUsuario(pcUsuario, pcClave, pcMaquina, pcVersion, 1);
                }
                else
                {
                    MessageBox.Show("Ingresar un Contraseña", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtClave.Focus();
                }

            }
            else
            {
                MessageBox.Show("Ingresar un Usuario", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtUser.Focus();
            }

            
        }
        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnInicarSesion();
            }
        }

        private void pCargarSucursal()
        {
            BLSucursal objSucursal = new BLSucursal();
            CapaUtil.clsUtil objUtil = new CapaUtil.clsUtil();
            DataTable dtSucursal = new DataTable();
            try
            {
                dtSucursal = objSucursal.BLListarSucursal();
                cboSucursal.ValueMember = "idSucursal";
                cboSucursal.DisplayMember = "cNombreSucursal";
                cboSucursal.DataSource = dtSucursal;
                if (dtSucursal.Rows.Count > 0)
                {
                    cboSucursal.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmUsuario", "pCargarSucursal", ex.Message);
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            pCargarSucursal();
            lblVersion.Text = "Versión: " + ProductVersion.Trim();
            
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                txtClave.Focus();
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            fnInicarSesion();
        }
        private void fnVercontraseña()
        {
            if (chkVerContraseña.Checked == true)
            {
                txtClave.UseSystemPasswordChar = false;

            }
            else
            {
                txtClave.UseSystemPasswordChar = true;


            }
        }
        private void chkVerContraseña_CheckedChanged(object sender, EventArgs e)
        {
            fnVercontraseña();
            txtClave.Focus();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            fnVercontraseña();
           
        }


    }
}
