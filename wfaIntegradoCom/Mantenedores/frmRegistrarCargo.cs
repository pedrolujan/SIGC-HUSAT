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
    public partial class frmRegistrarCargo : Form
    {
        public frmRegistrarCargo()
        {
            InitializeComponent();
        }

        Int16 lnTipoCon = 0;

        private Boolean fnCargarCargo(String cCodTab)
        {
            BLCargo objCargo = new BLCargo();
            
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstCargo = null;
            try
            {

                lstCargo = new List<Cargo>();
                lstCargo = objCargo.blDevolverCargo(cCodTab);
                cargoBindingSource.DataSource = lstCargo;
                dgvCargo.DataSource = cargoBindingSource.DataSource;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCargo", "fnCargarCargo", ex.Message);
                return false;
            }

        }

        private void fnDevolverCargoEspecifico(String pcCodTab)
        {
            BLCargo objCargo = new BLCargo();
            clsUtil objUtil = new clsUtil();

            Cargo[] arrUsuario = new Cargo[1];
            try
            {
                arrUsuario = objCargo.blDevolverCargo(pcCodTab).ToArray();
                txtIdCargo.Text = arrUsuario[0].cCodTab.ToString().Trim();
                txtCargo.Text = arrUsuario[0].cNomTab.ToString().Trim();
                chkEstado.Checked = Convert.ToBoolean(arrUsuario[0].bEstado);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCargo", "fnDevolverCargo", ex.Message);
                MessageBox.Show("Error al Obtener Datos de Cargo", "Aviso");
            }
        }

        private void fnHabilitarControles(Boolean pbHabilitar)
        {
            gbUsuario.Enabled = pbHabilitar;
            saveToolStripButton.Enabled = pbHabilitar;
        }

        private void fnLimpiarControles()
        {
            txtIdCargo.Text = "";
            txtCargo.Text = "";
            chkEstado.Checked = true;
            epControlOk.Clear();
            epUsuario.Clear();
        }

        private void gbUsuario_Enter(object sender, EventArgs e)
        {

        }

        private String fnGuardarCargo(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLCargo objblCargo = new BLCargo();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Cargo objCargo = new Cargo();
            Boolean bCargar = false;

            try
            {
                objCargo.cCodTab = Convert.ToString(txtIdCargo.Text);
                objCargo.cNomTab = Convert.ToString(txtCargo.Text.Trim());
                objCargo.bEstado = Convert.ToBoolean(chkEstado.Checked);
                objCargo.dFechaReg = dFechaSis;
                objCargo.idUsuario = Variables.gnCodUser;

                lcValidar = objblCargo.blGrabarCargo(objCargo, idTipoCon).Trim();

                bCargar = fnCargarCargo("");
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
                objUtil.gsLogAplicativo("frmRegistrarCargo", "fnGuardarCargo", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            String lcResultado = "";

            epControlOk.Clear();
            epUsuario.Clear();

            if (txtCargo.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtCargo, "");
                epUsuario.SetError(txtCargo, "Ingresar Cargo");
            }
            else
            {
                epUsuario.SetError(txtCargo, "");
                epControlOk.SetError(txtCargo, "Ingreso de Cargo Correcto");
            }


            if (txtCargo.Text.Trim().Length > 0 )
            {
                lcResultado = fnGuardarCargo(lnTipoCon);
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente Cargo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (lcResultado == "XX")
                {
                    MessageBox.Show("Error al Cargar Cargos. Vuelva a Ingresar a Formulario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Error al Grabar Cargo. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void frmRegistrarCargo_Load(object sender, EventArgs e)
        {
            Boolean bResul = false;
            bResul=fnCargarCargo("");
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar Cargos. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            fnHabilitarControles(false);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnHabilitarControles(true);
            fnLimpiarControles();
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCargo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lnTipoCon = 1;
            fnHabilitarControles(true);
        }

        private void dgvCargo_SelectionChanged(object sender, EventArgs e)
        {
            String cCodTab = "";
            Boolean bFilaSele = false;
            if (dgvCargo.RowCount > 0)
            {
                bFilaSele = dgvCargo.CurrentRow.Selected;

                if (bFilaSele)
                {
                    cCodTab = Convert.ToString(dgvCargo.CurrentRow.Cells[0].Value);
                    fnDevolverCargoEspecifico(cCodTab);
                    fnHabilitarControles(false);
                }
            }
        }

        private void txtCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
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
    }
}
