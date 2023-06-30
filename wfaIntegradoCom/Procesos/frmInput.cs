using CapaEntidad;
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
       List<Cargo> lsTipoAnulacion=new List<Cargo>();
       Cargo clsTipoAnulacion=new Cargo();
        public void Inicio(Int32 tipLlamada,String titulo,String texBtn1,String textBtn2)
        {
            lnTipoLLamada=tipLlamada;
            cTitulo=titulo;
            TextBtn1 = texBtn1;
            TextBtn2 = textBtn2;
            this.ShowDialog();
        }

        private Boolean fnValidarDatos()
        {
            Boolean bValida=false;
            String codTipoAnulacion=cboTipoAnulacion.SelectedValue is null?"0": cboTipoAnulacion.SelectedValue.ToString();
            if (lnTipoLLamada==-1)
            {
                if (codTipoAnulacion!="0" && txtDescripcion.Text.Length>3)
                {
                    bValida = true;
                }
                else
                {
                    MessageBox.Show("Por Complete todo los datos","Aviso.",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    bValida = false;

                }

            }
            else
            {
                if (txtDescripcion.Text.Length > 3)
                {
                    bValida = true;
                }
                else
                {
                    MessageBox.Show("Por Complete todo los datos", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    bValida = false;
                }
            }
            return bValida;
        }
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            String Descripcion=txtDescripcion.Text.ToString();
            if (txtDescripcion.Text.ToString().Length>5)
            {
                if (fnValidarDatos())
                {
                    if (lnTipoLLamada == -1 || lnTipoLLamada == -2)
                    {
                        frmAnularVenta frm = new frmAnularVenta();
                        frm.fnRecibirDescripcion(Descripcion, clsTipoAnulacion);
                       
                    }
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Describa el motivo por favor", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
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
                lblTitulo.Text = cTitulo;
                btnContinuar.Text = TextBtn1;
                btnCancelar.Text = TextBtn2;

                if (lnTipoLLamada == -1 || lnTipoLLamada == -2)
                {
                    lsTipoAnulacion =FunGeneral.fnLlenarCboSegunTablaTipoConReturnLista(cboTipoAnulacion, "Codigo", "Descripcion", "Tiposnotacredito", "estado", "1", false);
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

        private void cboTipoAnulacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id = cboTipoAnulacion.SelectedValue.ToString();
            clsTipoAnulacion = lsTipoAnulacion.Find(i=>i.cCodTab== id);
        }
    }
}
