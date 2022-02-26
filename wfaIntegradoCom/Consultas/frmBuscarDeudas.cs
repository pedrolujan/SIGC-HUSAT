using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Mantenedores;
using wfaIntegradoCom.Proceso;

namespace wfaIntegradoCom.Consultas
{
    public partial class frmBuscarDeudas : Form
    {
        public frmBuscarDeudas()
        {
            InitializeComponent();
        }

        private void frmBuscarPagos_Load(object sender, EventArgs e)
        {
            btnBuscar_Click(sender,e);
        }

        private Boolean fnConsultarDeudas(String pcFechaIni, string pcFechaFin, int pnIdLote, Int16 pnTipoLlamada)
        {
            BLDocumentoVenta objDocVenta = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            List<DetalleVenta> lstDeudas = null;
            try
            {
                lstDeudas = new List<DetalleVenta>();
                lstDeudas = objDocVenta.BLConsultarDeudas(pcFechaIni, pcFechaFin, pnIdLote, pnTipoLlamada);
                dataGridView1.DataSource = null;
                if (lstDeudas.Count > 0)
                {
                    //decimal decTotalImporte = (from x in lstDeudas select x.Importe).Sum();
                    //decimal decTotalDeuda = (from x in lstDeudas select x.Deuda).Sum();
                    dataGridView1.DataSource = lstDeudas;
                    //txtDeuda.Text =  decTotalDeuda.ToString("#0.00");
                    //txtImporte.Text = decTotalImporte.ToString("#0.00");
                }
                else
                {
                    MessageBox.Show( "No se encuentra registros de Deudas", "Consutar Deudas");
                }
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmDocumentoVenta", "fnConsultarDeudas", ex.Message);
                return false;
            }
            finally
            {
                lstDeudas = null;
                objDocVenta = null;
                objUtil = null;
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string lcFechaIni = "";
            string lcFechaFin = "";
            bool lbResultado = true;

            lcFechaIni = FunGeneral.GetFechaHoraFormato(dateTimePicker1.Value, 5) + " 00:00:00.000";
            lcFechaFin = FunGeneral.GetFechaHoraFormato(dateTimePicker2.Value, 5) + " 23:59:59.000";

            lbResultado = fnConsultarDeudas(lcFechaIni, lcFechaFin, 0, 0);
            if (!lbResultado)
                MessageBox.Show("Volver a Intentar Cargar Deudas", "Consutar Deudas");
        }


        private void tbcCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tbcCliente.TabIndex == 0)
            {
                dateTimePicker1.Value = DateTime.Now.AddDays(-1);
                dateTimePicker2.Value = DateTime.Now;
            }
            else
            {
                txtCliente.Text = string.Empty;
                txtCodigo.Text = string.Empty;
            }
            txtDeuda.Text = string.Empty;
            txtImporte.Text = string.Empty;
            dataGridView1.DataSource = null;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) != 0)
                {
                    int intidCliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idProducto"].Value);
                    frmRegistrarCobros frmCobros = new frmRegistrarCobros();
                    frmCobros.fnTipoLlamada(intidCliente);
                    frmCobros.ShowDialog();
                }
            }
        }

        static string lcCliente = string.Empty;
        static int lidCliente = 0;
        public static void fnRecuperarCliente(String pcCliente, int pintIdCliente)
        {
            lcCliente = pcCliente;
            lidCliente = pintIdCliente;
        }

        private Boolean fnObtenerCliente()
        {
            clsUtil objUtil = new clsUtil();
            bool lbResultado = false;
            try
            {
                if (lidCliente > 0)
                {
                    txtCliente.Text = lcCliente;
                    txtCodigo.Text = lidCliente.ToString();
                    lbResultado = fnConsultarDeudas(null, null, lidCliente, 1);
                    if (!lbResultado)
                        MessageBox.Show("Volver a Intentar Cargar Deudas", "Consutar Deudas");
                }
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmBuscarDeuda", "fnObtenerCliente", ex.Message);
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean lbResul = false;
            frmBuscarCliente frmCliente = new frmBuscarCliente();
            frmCliente.Inicio(3);
            lbResul = fnObtenerCliente();
            if (!lbResul)
            {
                MessageBox.Show("Error al Agregar Cliente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
