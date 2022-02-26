using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Mantenedores;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmReferenciaInstalacion : Form
    {
        public frmReferenciaInstalacion()
        {
            InitializeComponent();
        }
        Int32 lnTipoLLamada = 0;
        DateTime dtFechaInstalacion;
        Boolean estaCboDirecInstal, estatxtDescDirecInsrtalacion;
        String msgCboDirecInstal, msgtxtDescDirecInsrtalacion;

        public void Inicio(int pnTipo,DateTime dtFechInstalacion)
        {
            lnTipoLLamada = pnTipo;
            dtFechaInstalacion = dtFechInstalacion;
            this.ShowDialog();
        }
        private void frmReferenciaInstalacion_Load(object sender, EventArgs e)
        {
            dtpFechaInstalacion.Value = Variables.gdFechaSis;
            pbFechaInstalacion.Image = Properties.Resources.ok;
            dtpFechaInstalacion.Value = dtFechaInstalacion;
            FunValidaciones.fnColorAceptarCancelar(btnAceptar,btnCancelar);
            Boolean bResult = false;
            bResult = FunGeneral.fnLlenarTablaCod(cboDirInstalacion, "DRIN");
            
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Direccion de instalacion", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void txtDireccionDeInstalacion_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(cboDirInstalacion.SelectedValue) == "DRIN0002")
            {
                var result = FunValidaciones.fnValidarTexboxs(txtDireccionDeInstalacion, lblDescDireccionInstalacion, pbDescDireccionInstalacion, true, true, true, 10, 1000, 1000, 1000, "Ingrese Correctamente Destalle de instalacion");
                estatxtDescDirecInsrtalacion = result.Item1;
                msgtxtDescDirecInsrtalacion = result.Item2;
            }
            else
            {
                estatxtDescDirecInsrtalacion = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboDirInstalacion, lblDirInstalacion, pbDirInstal);
            estaCboDirecInstal = result.Item1;
            msgCboDirecInstal = result.Item2;
            txtDireccionDeInstalacion_TextChanged(sender, e);
            if (estaCboDirecInstal==true && estatxtDescDirecInsrtalacion==true)
            {
                frmRegistrarVenta frmRegVenta = new frmRegistrarVenta();
                frmRegVenta.fnObtenerDatosDeRefInstalacion(Convert.ToString(cboDirInstalacion.SelectedValue), Convert.ToString(txtDireccionDeInstalacion.Text), dtpFechaInstalacion, true);
                this.Close();
            }
            else
            {
                MessageBox.Show("Porfavor complete todo los datos","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
           
        }

        private void cboDirInstalacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboDirInstalacion, lblDirInstalacion, pbDirInstal);
            estaCboDirecInstal = result.Item1;
            msgCboDirecInstal = result.Item2;
            if (Convert.ToString(cboDirInstalacion.SelectedValue) != "0")
            {
                if (Convert.ToString(cboDirInstalacion.SelectedValue) == "DRIN0002")
                {
                    frActivarDescripcionInstalacion(true);
                }
                else
                {
                    frActivarDescripcionInstalacion(false);
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmRegistrarVenta frmRegVenta = new frmRegistrarVenta();
            frmRegVenta.fnObtenerDatosDeRefInstalacion("","",dtpFechaInstalacion, false);
            this.Close();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            frmRegistrarVenta frmRegVenta = new frmRegistrarVenta();
            frmRegVenta.fnObtenerDatosDeRefInstalacion("", "", dtpFechaInstalacion, false);
            this.Close();
        }

        private void frActivarDescripcionInstalacion(Boolean estado)
        {
            txtDireccionDeInstalacion.Enabled = estado;
            if (estado==false)
            {
                pbDescDireccionInstalacion.Image = Properties.Resources.ok;
                txtDireccionDeInstalacion.Text ="LA INSTALACION SE REALIZARÁ EN LA OFICINA AV. FEDERICO VILLAREAL N° 319" ;
            }
            else
            {
                txtDireccionDeInstalacion.Text = "";
            }
            
            lblDescDireccionInstalacion.Visible = estado;
        }

        private void fnLimpiarControles()
        {
            cboDirInstalacion.SelectedValue = "0";
            panel.Text = "";
            pbDescDireccionInstalacion.Image = null;
            lblDescDireccionInstalacion.Text = "";
            pbDirInstal.Image = null;
            lblDirInstalacion.Text = "";
        }
    }
}
