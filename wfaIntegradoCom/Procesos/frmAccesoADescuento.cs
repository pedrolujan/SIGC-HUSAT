using CapaNegocio;
using CapaUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmAccesoADescuento : Form
    {
        public frmAccesoADescuento()
        {
            InitializeComponent();
        }
        static Int32 lnTipoLlamada;
        private void btnAccesoDescuento_Click(object sender, EventArgs e)
        {
            Boolean bResult;
            bResult = fnValidarAccesoDescuento();
            if (bResult)
            {
                this.Dispose();
            }
           
        }
        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();
        }

        private Boolean fnValidarAccesoDescuento()
        {

            clsUtil objUtil = new clsUtil();
            BLTipoDescuento objTD = new BLTipoDescuento();
            String usuario = txtUsuario.Text.Trim();
            String clave = txtClave.Text.Trim();
            Int32 valorAcceso = 0;

            try
            {
                if(usuario == "" || clave == "")
                {
                    MessageBox.Show("Porfavor Ingrese los 2 campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
                else
                {
                    valorAcceso = objTD.BLValidarDescuento(usuario, clave);
                    return fnMostrarMensajeAcceso(valorAcceso);
                }
                
                return false;
            }
            catch (Exception ex)         
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }
        }
        private Boolean fnMostrarMensajeAcceso(Int32 valorAcceso)
        {
            switch (valorAcceso)
            {
                case 1: 
                    
                    
                    fnAplicarDescuento();
                    return true;
                    break;
                   
                case 2:
                    MessageBox.Show("Contraseña Incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    break;

                case 3:
                    MessageBox.Show("El Usuario no tiene privilegio para Descuento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 4:
                    MessageBox.Show("El usuario ingresado está DESACTIVADO", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

            }
            return false;
        }

        private void frmAccesoADescuento_Load(object sender, EventArgs e)
        {
            switch (lnTipoLlamada)
            {
                case 2:

                    break;
            }
        }

        private Boolean fnAplicarDescuento()
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                Boolean habilitarDescuento = true;

                Mantenedores.frmRegistrarVenta.fnRespuestaValidacion(habilitarDescuento);
                frmControlPagoVenta.fnRespuestaValidacion(habilitarDescuento);
                frmOtrasVentas.fnRespuestaValidacion(habilitarDescuento);
                //frmEditarCaja.fnRespuestaValidacion(habilitarDescuento);


                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarProveedor", "fnRecuperarProveedorEsp", ex.Message);
                return false;
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Boolean bResult;
                bResult = fnValidarAccesoDescuento();
                if (bResult)
                {
                    this.Dispose();
                }
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                txtClave.Focus();
            }
        }
    }
}
