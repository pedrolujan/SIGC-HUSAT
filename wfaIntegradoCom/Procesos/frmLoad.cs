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

namespace wfaIntegradoCom.Procesos
{
    public partial class frmLoad : Form
    {
        public frmLoad()
        {
            InitializeComponent();

        }
        DataSet dtMenu = new DataSet();

        public void Inicio()
        {
            this.ShowDialog();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (ProgressBar1.Value < 100)
            {
                ProgressBar1.Value += 1;
                
                lblStatus.Text = ProgressBar1.Value.ToString() + "%";

            }
            else
            {
                if (ProgressBar1.Value >= 100)
                {
                    timer1.Stop();
                    MDIParent1 frm = new MDIParent1();

                    frm.fnLoadCarga(true);
                    this.Dispose();

                }
                
            }
               
        }

        private void frmLoad_Load(object sender, EventArgs e) 
        {
           TransparencyKey = Color.Transparent;

            this.timer1.Start();
            BLMenu objMenu = new BLMenu();
            MDIParent1 frmMDI = new MDIParent1();
            
            //dtMenu = objMenu.BLCargarMenu(Variables.gnCodUser, 1);
            //frmMDI.fnRecibirDtMenu(dtMenu);
            //frmMDI.fnCargarMenuAccesoRapido();
            //frmMDI.fnCargarMenuPrin();
            siticoneWinProgressIndicator1.Start();

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void CLICK(object sender, EventArgs e)
        {

        }
    }
}
