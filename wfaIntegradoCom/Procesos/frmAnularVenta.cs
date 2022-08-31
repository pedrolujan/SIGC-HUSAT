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
using CapaUtil;
using CapaDato;




namespace wfaIntegradoCom.Procesos
{
    public partial class frmAnularVenta : Form
    {
        public frmAnularVenta()
        {
            InitializeComponent();
        }
        //MOD//
        private void  fnBuscarVentas( DateTime fechainicial, DateTime fechafinal , String cbuscar  )
        {
            BLDocumentoVenta objdocVenta = new BLDocumentoVenta();
           
            clsUtil objUtil = new clsUtil();
            DataTable dtcodventa = new DataTable();

            DataGridView dg = dgVentas;


            Int32 totalresult;

            

            try
            {
                // String BuscaVenta = Convert.ToString(txtBuscar.Text.Trim());


                dtcodventa = objdocVenta.BLListarVentas(fechainicial , fechafinal , cbuscar);
                totalresult = dtcodventa.Rows.Count;
                foreach (DataRow dr in dtcodventa.Rows)
                {
                    dgVentas.Rows.Add( dr["codDocumentoCorrelativo"], dr["cNombre"], dr["vPlaca"], dr["dfecharegistro"], dr["cUser"]);
                }
                //dg.Columns[0].Visible = false;
                //dg.Columns[1].Width = 50;
                //dg.Columns[2].Visible = false;
                //dg.Columns[3].Width = 50;
                //dg.Columns[4].Visible = false;
                //dg.Columns[5].Width = 45;
                //dg.Columns[6].Width = 75;
                //dg.Columns[7].Visible = false;
                //dg.Columns[8].Width = 45;
                //dg.Columns[9].Width = 45;
                //dg.Columns[10].Width = 45;


                dgVentas.Visible = true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
              

                
            }

        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            Int32 numCaracNroDocumento = txtBuscar.TextLength;
            if (numCaracNroDocumento > 10)
            {
                dgVentas.Rows.Clear();
                String cbuscar = txtBuscar.Text.Trim();

                DateTime fechainicial = dtpFechaInicialBus.Value;
                DateTime fechafinal = dtpFechaFinalBus.Value;


                if (cbFechas.Checked == false)
                {

                    string strFechaActual = "2018-01-31 16:56:00";
                    DateTime fechainicio = DateTime.Parse(strFechaActual);

                    DateTime fechaactual = DateTime.Now;
                    fnBuscarVentas(fechainicio, fechaactual, cbuscar);
                }
                else if (cbFechas.Checked == true)
                {


                    fnBuscarVentas(fechainicial, fechafinal, cbuscar);
                }
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //IMGbuscar (Lupa)//
            dgVentas.Rows.Clear();
            String cbuscar = txtBuscar.Text.Trim();

            DateTime fechainicial = dtpFechaInicialBus.Value;
            DateTime fechafinal = dtpFechaFinalBus.Value;


            if (cbFechas.Checked == false)
            {

                string strFechaActual = "2018-01-31 16:56:00";
                DateTime fechainicio = DateTime.Parse(strFechaActual);

                DateTime fechaactual = DateTime.Now;
                fnBuscarVentas(fechainicio, fechaactual, cbuscar);
            }
            else if (cbFechas.Checked == true)
            {

                
            fnBuscarVentas(fechainicial, fechafinal, cbuscar);
            }





            // String idDocVenta = Convert.ToString(txtBuscar.Text);
           // Int32 idDocVenta = Convert.ToInt32(dg.CurrentRow.Cells[0].Value);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            dgVentas.Rows.Clear();
            String cbuscar = txtBuscar.Text.Trim();

            DateTime fechainicial = dtpFechaInicialBus.Value;
            DateTime fechafinal = dtpFechaFinalBus.Value;

            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarVentas(fechainicial, fechafinal, cbuscar);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFechas.Checked == true)
            {
                gbBuscarListaVentas.Enabled = true;
            }
            else
                gbBuscarListaVentas.Enabled = false;
        }

        private void eliminarRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {

            BLDocumentoVenta objdocVenta = new BLDocumentoVenta();
            Boolean estadoOpe = false;

            String codDocVenta = Convert.ToString(dgVentas.CurrentRow.Cells[2].Value);
            DialogResult resultDialog = MessageBox.Show("¿En realidad desea anular esta Documento?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

            if (resultDialog == DialogResult.Yes)
            {
                estadoOpe = objdocVenta.BLDAnularDocumentoVenta(codDocVenta);
                
                if (estadoOpe == true)
                {
                    MessageBox.Show("Documento anulada correctamente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al anular el Documento de Venta", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            clsUtil clsUtil = new clsUtil();
           DialogResult dr =  MessageBox.Show("Acabas de presionar el boton -Eliminar Registro- ", "Avisito xd", MessageBoxButtons.OK, MessageBoxIcon.Question);

            if (dr  == DialogResult.OK)
            {

                MessageBox.Show("Acabas de Aceptar el Mensaje anterior", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
            }

            try
            {

            }
            catch (Exception )
            {

                throw;
            }


        }

        private void frmAnularVenta_Load(object sender, EventArgs e)
        {
            DateTime fechaactual = DateTime.Now;
            dtpFechaFinalBus.Value = fechaactual;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbR0.Checked == true)
            {
                txtBuscar.Text = cbR0.Text;

                cbF0.Checked = false;
            }
          
        }

        private void cbF0_CheckedChanged(object sender, EventArgs e)
        {
        if (cbF0.Checked == true)
            {
                txtBuscar.Text = cbF0.Text;

                cbR0.Checked = false;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
