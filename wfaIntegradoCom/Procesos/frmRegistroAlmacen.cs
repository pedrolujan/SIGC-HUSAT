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
    public partial class frmRegistroAlmacen : Form
    {
        DataTable dtAlmacen;

        public frmRegistroAlmacen()
        {
            InitializeComponent();
        }
        private void pCargarSucursal()
        {
            BLSucursal objSucursal = new BLSucursal();
            clsUtil objUtil = new clsUtil();
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
                objUtil.gsLogAplicativo("frmRegistroAlmacen", "pCargarSucursal", ex.Message);
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }
        private void pCargarAlmacen()
        {
            BLAlmacen objSucursal = new BLAlmacen();
            clsUtil objUtil = new clsUtil();
            dtAlmacen = null;
            dtAlmacen = new DataTable();
            try
            {
                dtAlmacen = objSucursal.BLListarAlmacen();
                dgvListadoAlmacen.DataSource = dtAlmacen;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistroAlmacen", "pCargarAlmacen", ex.Message);
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void frmRegistroAlmacen_Load(object sender, EventArgs e)
        {
            pCargarAlmacen();
            pCargarSucursal();
        }
        private void pCancelarAlmacen()
        {
            txtCodigoAlmacen.Text = "";
            txtNombreAlmacen.Text = "";
            rbActivo.Checked = true;
            if (cboSucursal.Items.Count > 0)
            {
                cboSucursal.SelectedIndex = 0;
            }
            pCargarAlmacen();
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            pCancelarAlmacen();
        }

        private void dgvListadoAlmacen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (MessageBox.Show("Desea Editar el Almacen Seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtCodigoAlmacen.Text = dgvListadoAlmacen.Rows[e.RowIndex].Cells["idAlmacen"].Value.ToString();
                    txtNombreAlmacen.Text = dgvListadoAlmacen.Rows[e.RowIndex].Cells["cNomAlmacen"].Value.ToString();
                    cboSucursal.SelectedValue = Convert.ToInt32(dgvListadoAlmacen.Rows[e.RowIndex].Cells["idSucursal"].Value.ToString());
                    if (dgvListadoAlmacen.Rows[e.RowIndex].Cells["bEstado"].Value.ToString() == "ACTIVO")
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
        private Boolean pValidaIngresoAlmacen()
        {
            Boolean bValor = false;
            if (txtNombreAlmacen.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Ingrese un Nombre de Almacen.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
            }
            if (cboSucursal.Items.Count <= 0)
            {
                MessageBox.Show("Selecione Sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                bValor = true;
            }
           
            return bValor;
        }

        private void tsbGrabar_Click(object sender, EventArgs e)
        {
            String lsResultado = "";
            Int32 liCodigo = 0;
            Int32 lbEstado = 0;
            clsUtil objUtil = new clsUtil();
            if (pValidaIngresoAlmacen() == false)
            {
                BLAlmacen objMarca = new BLAlmacen();
                if (txtCodigoAlmacen.Text.Trim().Length > 0)
                {
                    liCodigo = Int32.Parse(txtCodigoAlmacen.Text.Trim());
                }
                if (rbActivo.Checked == true)
                {
                    lbEstado = 1;
                }
                lsResultado = objMarca.BLRegistrarAlmacen(liCodigo, Convert.ToString(txtNombreAlmacen.Text.Trim()), Convert.ToInt32(cboSucursal.SelectedValue),lbEstado, objUtil.GetFechaHoraFormato(Variables.gdFechaSis, 2), Variables.gnCodUser, 2);
                if (lsResultado.Trim().Length > 0)
                {
                    MessageBox.Show(lsResultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Almacén Registrada correctamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    pCancelarAlmacen();
                }

            }
        }
    }
}
