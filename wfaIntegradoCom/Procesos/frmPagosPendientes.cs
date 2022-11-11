using FontAwesome.Sharp;
using Siticone.UI.WinForms;
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
    public partial class frmPagosPendientes : Form
    {
        public frmPagosPendientes()
        {
            InitializeComponent();
        }
       
        private void frmPagosPendientes_Load(object sender, EventArgs e)
        {

        }
        private void fnBuscarLabelEnPanel(SiticonePanel pn)
        {
            var ts = pn.Controls.OfType<Label>();
            foreach (Label ib in ts)
            {
                //ib.ForeColor = ;
            }
        }
        private void fnObtenerIconButonDePanel(SiticonePanel pn)
        {
           
        }
    }
}
