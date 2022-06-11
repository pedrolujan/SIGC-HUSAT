using CapaEntidad;
using CapaNegocio;
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
    public partial class frmControlCaja : Form
    {
        public frmControlCaja()
        {
            InitializeComponent();
        }

        private void frmControlCaja_Load(object sender, EventArgs e)
        {
            try
            {

                FunGeneral.fnLlenarTablaCodTipoCon(cboMetodopago, "TIPA",true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboDocumentoVenta, "DOVE",true);

                frmRegistrarVenta frm = new frmRegistrarVenta();
                frm.fnLlenarTipoTarifa(0, cboTipoVenta, true);

                fnListarTipoPago(cboTipoPago, "ESDOV", true);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void fnListarTipoPago(ComboBox cbo,String id,Boolean estado)
        {
            BLControlCaja bl = new BLControlCaja();
            List<ControlCaja> lstControl = new List<ControlCaja>();

            lstControl= bl.blFnLLenarTipoPago(id, estado);

            cbo.DataSource = null;
            cbo.ValueMember = "codTipoPago";
            cbo.DisplayMember = "descripTipoPago";
            cbo.DataSource = lstControl;

        }

        private void cboMetodopago_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmTipoPago.fnLlenarCombobox(btnEntidadPago,cboMetodopago.SelectedValue.ToString(),0,true);
        }
    }
}
