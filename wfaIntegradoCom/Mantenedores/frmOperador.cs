using CapaEntidad;
using CapaNegocio;
using CapaUtil;
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
    public partial class frmOperador : Form
    {
        public frmOperador()
        {
            InitializeComponent();
        }
        Int32 lnTipoLlamada = 0;
        Int32 idProveedorBusq = 0;
        String tipingreso = "";
        Operador oper = new Operador();
        List<Operador> lstOperador = new List<Operador>();

        private void frmOperador_Load(object sender, EventArgs e)
        {
           




        }
        public void fnDevolveroperador(DataGridView dgv,String tipingreso, Int32 idProveedor)
        {
            BLOrdenCompra objOrdenCompra = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            DataTable dtoperador = new DataTable();

            
           
           
            dtoperador = objOrdenCompra.blDevolverOperadores(idProveedor, tipingreso);
            Int32 totalResultados = dtoperador.Rows.Count;
            if (totalResultados > 0)
            {


                for (int i = 0; i < totalResultados ; i++)
                {
                    lstOperador.Add(new Operador
                    {
                        idOperador= Convert.ToInt32(dtoperador.Rows[i][0]),
                        NomOperador=Convert.ToString(dtoperador.Rows[i][1])

                    });

                    dgv.Rows.Add(
                        dtoperador.Rows[i][0],
                        dtoperador.Rows[i][1]);


            }
            }

        }


        public void Inicio(Int16 pnTipoLlamada,String tipoingreso, Int32 idProv)
        {
            lnTipoLlamada = pnTipoLlamada;
            idProveedorBusq = idProv;
            tipingreso = tipoingreso;
            if (lnTipoLlamada == 1)
            {

                fnDevolveroperador(dgvOperador, tipingreso, idProveedorBusq);

            }

            ShowDialog();

        }
        //-----------------------------------
      

        private void dgvOperador_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmOrdenCompraEquipos fmrorden = new frmOrdenCompraEquipos();

            Int32 IdOperador= Convert.ToInt32(dgvOperador.CurrentRow.Cells[0].Value);


            Operador ope = new Operador();

            ope = lstOperador.First(s => s.idOperador == IdOperador);

            fmrorden.fnObtenerOperador(ope);

            this.Close();

        }                

        private void gbDatosProveedor_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void siticoneGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void SiticoneHtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void SiticoneHtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void SiticoneHtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
