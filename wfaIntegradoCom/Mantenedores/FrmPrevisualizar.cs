using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class FrmPrevisualizar : Form
    {
        public FrmPrevisualizar()
        {
            InitializeComponent();
        }
        Int32 lnTipoLlamada = 0;
        String DatosAMostrar = "";
        public void inicio(Int32 tipLlamada, String dato)
        {
            lnTipoLlamada = tipLlamada;
            DatosAMostrar=dato;
            this.ShowDialog();
        }

        private void FrmPrevisualizar_Load(object sender, EventArgs e)
        {
            txtPrevisualizarTexto.Text = DatosAMostrar;
        }
    }
}
