using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Procesos;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmTipoVenta : Form
    {
        public frmTipoVenta()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (listView1.SelectedItems[0].Text == "Venta General")
                {
                    frmRegistrarVenta frmDoc = new frmRegistrarVenta();
                    frmDoc.ShowDialog();
                }
                else if (listView1.SelectedItems[0].Text == "Otras Ventas")
                {
                    MessageBox.Show("Opcion aun no disponible ","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmTipoVenta_Load(object sender, EventArgs e)
        {
            listView1.Items[0].Selected = true;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (listView1.SelectedItems[0].Text == "Venta General")
                {
                    frmRegistrarVenta frmDoc = new frmRegistrarVenta();
                    frmDoc.ShowDialog();
                }
                else if (listView1.SelectedItems[0].Text == "Otras Ventas")
                {
                    MessageBox.Show("Opcion aun no disponible ", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    if (listView1.SelectedItems[0].Text == "Venta General")
                    {
                        frmRegistrarVenta frmDoc = new frmRegistrarVenta();
                        frmDoc.ShowDialog();
                    }
                    else if (listView1.SelectedItems[0].Text == "Otras Ventas")
                    {
                        MessageBox.Show("Opcion aun no disponible ", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

    }
}
