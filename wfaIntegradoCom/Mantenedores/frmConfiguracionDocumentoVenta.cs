using CapaDato;
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

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmConfiguracionDocumentoVenta : Form
    {
        public frmConfiguracionDocumentoVenta()
        {
            InitializeComponent();
        }
        List<Cargo> lstDocumentoVenta = new List<Cargo>();
        private void frmConfiguracionDocumentoVenta_Load(object sender, EventArgs e)
        {
            lstDocumentoVenta=FunGeneral.fnLlenarTablaCodTipoConReturnLista(cboComprobanteP,"DOVE",false);
        }

        private void cboComprobanteP_SelectedIndexChanged(object sender, EventArgs e)
        {
            String srtCod = cboComprobanteP.SelectedValue.ToString();
            Cargo clsCargo = lstDocumentoVenta.Find(i => i.cCodTab == srtCod);
            txtBuscar.Texts = clsCargo is Cargo? clsCargo.SerieDoc:"";
            rjTextBox1.Texts = clsCargo is Cargo ? clsCargo.nValor2:"0";

            rjTextBox2.Texts = clsCargo is Cargo ? FunGeneral.generarCorrelativoDocumento(Convert.ToInt32(clsCargo.nValor2)): FunGeneral.generarCorrelativoDocumento(0);
        }

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(rjTextBox1.Texts.ToString()) ;
            rjTextBox2.Texts =FunGeneral.generarCorrelativoDocumento(num);
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            DADocumentoVenta dDocVenta=new DADocumentoVenta();
            String codDocumento = cboComprobanteP.SelectedValue.ToString(); ;
            String Serie = txtBuscar.Texts.ToString();
            String numero = rjTextBox1.Texts.ToString();
            String Correlativo = rjTextBox2.Texts.ToString();
            String res= dDocVenta.daGuardarConfiguraCionDocumento(codDocumento, Serie, numero);
            if (res=="OK")
            {
                MessageBox.Show("Datos Actualizados Correctamente","Aviso!!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al Guardad Cambios", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
