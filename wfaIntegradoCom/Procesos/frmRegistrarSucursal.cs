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
namespace wfaIntegradoCom.Procesos
{
    public partial class frmRegistrarSucursal : Form
    {
        DataTable dtSucursal;
        public frmRegistrarSucursal()
        {
            InitializeComponent();
        }
        private void pCargaSucursales()
        {
            BLSucursal objSucursal = new BLSucursal();
            clsUtil objUtil = new clsUtil();
            dtSucursal = null;
            dtSucursal = new DataTable();
            try
            {
                dtSucursal = objSucursal.BLListarSucursal();
                dgvListadoSucursal.DataSource = dtSucursal;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarSucursal", "pCargaSucursales", ex.Message);
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
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

        private Boolean fnLlenarDepartamento()
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            List<Departamento> lstDepart = new List<Departamento>();

            try
            {
                lstDepart = objUbigeo.blDevolverDepartamento(0);
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

        private void frmRegistrarSucursal_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;

            bResult = fnLlenarDepartamento();
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Departamentos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                pCargaSucursales();
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
                    MessageBox.Show("Error al Cargar Provincias por Departamento", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void dgvListadoSucursal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (MessageBox.Show("Desea Editar la Sucursal Seleccionada?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtCodigoSucursal.Text = dgvListadoSucursal.Rows[e.RowIndex].Cells["idSucursal"].Value.ToString();
                    txtNombreSucursal.Text = dgvListadoSucursal.Rows[e.RowIndex].Cells["cNombreSucursal"].Value.ToString();
                    cboDepartamento.SelectedValue = Convert.ToInt32(dgvListadoSucursal.Rows[e.RowIndex].Cells["idDepa"].Value.ToString()) ;
                    cboProvincia.SelectedValue = Convert.ToInt32(dgvListadoSucursal.Rows[e.RowIndex].Cells["idProv"].Value.ToString());
                    cboDistrito.SelectedValue = Convert.ToInt32(dgvListadoSucursal.Rows[e.RowIndex].Cells["idDist"].Value.ToString());
                    txtDireccion.Text = dgvListadoSucursal.Rows[e.RowIndex].Cells["cDireccion"].Value.ToString();
                    if (dgvListadoSucursal.Rows[e.RowIndex].Cells["bEstado"].Value.ToString() == "ACTIVO")
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

        private void tsbGrabar_Click(object sender, EventArgs e)
        {
            String lsResultado = "";
            Int32 liCodigo = 0;
            Int32 lbEstado = 0;
            clsUtil objUtil = new clsUtil();
            if (pValidaIngresoSucursal() == false)
            {
                BLSucursal objMarca = new BLSucursal();
                if (txtCodigoSucursal.Text.Trim().Length > 0)
                {
                    liCodigo = Int32.Parse(txtCodigoSucursal.Text.Trim());
                }
                if (rbActivo.Checked == true)
                {
                    lbEstado = 1;
                }
                lsResultado = objMarca.BLRegistrarSucursal(liCodigo,Convert.ToString(txtNombreSucursal.Text.Trim()),Convert.ToInt32(cboDistrito.SelectedValue) ,Convert.ToString(txtDireccion.Text.Trim()), lbEstado, objUtil.GetFechaHoraFormato(Variables.gdFechaSis, 2), Variables.gnCodUser, 2);
                if (lsResultado.Trim().Length > 0)
                {
                    MessageBox.Show(lsResultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Sucursal Registrada correctamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    pCancelarSucursal();
                }
                
            }
        }
        private void pCancelarSucursal()
        {
            txtCodigoSucursal.Text = "";
            txtNombreSucursal.Text = "";
            txtDireccion.Text = "";
            rbActivo.Checked = true;
            if(cboDepartamento.Items.Count > 0)
            {
                cboDepartamento.SelectedIndex = 0;
            }
            if (cboDepartamento.Items.Count > 0)
            {
                cboProvincia.SelectedIndex = 0;
            }
            if (cboDepartamento.Items.Count > 0)
            {
                cboDistrito.SelectedIndex = 0;
            }
            pCargaSucursales();
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            pCancelarSucursal();
        }
        private Boolean pValidaIngresoSucursal()
        {
            Boolean bValor = false;
            if (txtNombreSucursal.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Ingrese un Nombre de Sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
            }
            if (txtDireccion.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Ingrese una Dirección.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
            }
            if (cboDepartamento.Items.Count <= 0)
            {
                MessageBox.Show("Selecione Departamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
            }
            if (cboProvincia.Items.Count <= 0)
            {
                MessageBox.Show("Selecione Provincia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
            }
            if (cboDistrito.Items.Count <= 0)
            {
                MessageBox.Show("Selecione Distrito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
            }
            return bValor;
        }
    }
}
