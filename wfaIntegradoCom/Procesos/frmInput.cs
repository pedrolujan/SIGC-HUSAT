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

namespace wfaIntegradoCom.Procesos
{
    public partial class frmInput : Form
    {
        public frmInput()
        {
            InitializeComponent();
        }
        Boolean estDescripcion = false;
        Int32 lnTipoLLamada = 0;
        String cTitulo = "";
        String TextBtn1 = "";
        String TextBtn2 = "";
       
        public void Inicio(Int32 tipLlamada,String titulo,String texBtn1,String textBtn2)
        {
            lnTipoLLamada=tipLlamada;
            cTitulo=titulo;
            TextBtn1 = texBtn1;
            TextBtn2 = textBtn2;
            this.ShowDialog();
        }
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            String Descripcion=txtDescripcion.Text.ToString();
            if (estDescripcion)
            {
                if (lnTipoLLamada==-1)
                {
                    frmAnularVenta frm = new frmAnularVenta();
                    frm.fnRecibirDescripcion(Descripcion); 
                }
            }
            this.Dispose(); 
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtDescripcion, lblDescipcion, pbDescricion, true, true,true,10,200,200,200,"Describa Correctamente el proceso");
            estDescripcion = result.Item1;
        }

        private void frmInput_Load(object sender, EventArgs e)
        {
            try
            {
                if (lnTipoLLamada==-1)
                {
                    lblTitulo.Text = cTitulo;
                    btnContinuar.Text = TextBtn1;
                    btnCancelar.Text = TextBtn2;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }
    }
}
