using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;


namespace wfaIntegradoCom.Procesos
{
    public partial class frmAnularVenta : Form
    {
        public frmAnularVenta()
        {
            InitializeComponent();
        }
        //MOD//
        //public void fnBuscarVentas(Int32 cCodVenta)
        //{
        //    BLOtrasVenta daObjTipoVenta = new BLOtrasVenta();
        //    //clsUtil objUtil = new clsUtil();
        //    DataTable dtResul = new DataTable();
        //    String BuscaVenta = txtBuscar.Text.Trim();

        //    Int32 totalresult;
       
          
        //    try
        //    {
        //       // String BuscaVenta = Convert.ToString(txtBuscar.Text.Trim());

                
        //        dtResul = daObjTipoVenta.blListarDocumentoVenta(cCodVenta);
        //        totalresult = dtResul.Rows.Count;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Boolean bResul;
            
       
                    ////bResul = fnBuscarVentas(dgVentas, 0, -1);
                    //if (!bResul)
                    //{
                    //    MessageBox.Show("ERROR al buscar Venta. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //}
                

            

            DataGridView dg = dgVentas;

           // String idDocVenta = Convert.ToString(txtBuscar.Text);
            Int32 idDocVenta = Convert.ToInt32(dg.CurrentRow.Cells[0].Value);
            //fnListarVentas( idDocVenta);
        }
    }
}
