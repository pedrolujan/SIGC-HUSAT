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
using CapaEntidad;
using CapaUtil;
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmMovimientoCaja : Form
    {

        Int32 intTipoLlamada = 0;

        public frmMovimientoCaja()
        {
            InitializeComponent();
        }

        public frmMovimientoCaja(int pintTipoLllamada)
        {
            InitializeComponent();
            intTipoLlamada = pintTipoLllamada;
        }

        public Boolean fnCargarUsuario()
        {
            BLUsuario objUsuario = new BLUsuario();
            clsUtil objUtil = new clsUtil();
            List<Usuario> lstUsuario = new List<Usuario>();
            try
            {
                lstUsuario = objUsuario.BLListarCargooUsuario(true, 1);

                cboUsuario.DisplayMember = "cUser";
                cboUsuario.ValueMember = "cPersonal";
                cboUsuario.DataSource = lstUsuario;
                
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmMovimientoCaja", "fnCargarUsuario", ex.Message);
                return false;
            }
            finally
            {
                objUsuario = null;
                lstUsuario = null;
            }

           
        }

        static decimal lnMontoArqueo=0;

        public static void fnObtenerMontoArqueo(decimal pnArqueo)
        {
            lnMontoArqueo=pnArqueo;
        }

        private Boolean fnListarCajaDia(String pcFecha,Int32 pidUsuario, out decimal pnSaldo)
        {
            BLDocumentoVenta objOrden = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            List<Cuadre> lstCaja = null;

            try
            {
                lstCaja = new List<Cuadre>();
                lstCaja = objOrden.blListarCajaDia(pcFecha, pidUsuario, Variables.idSucursal, out pnSaldo);
                dataGridView1.DataSource = lstCaja;
                return true;
            }
            catch (Exception ex)
            {
                pnSaldo = 0;
                objUtil.gsLogAplicativo("frmMovimientoCaja", "fnListarCajaDia", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objOrden = null;
                lstCaja = null;
            }
        }

        string pcFecha = "";
        private void frmMovimientoCaja_Load(object sender, EventArgs e)
        {
            bool bResult = false;
            decimal nSaldo = 0;
            int intUsuario = 0; 

            if (intTipoLlamada == 0)
            {
                //paBusqueda.Visible = true;
                //bResult = fnCargarUsuario();
                //pcFecha = FunGeneral.GetFechaHoraFormato(dateTimePicker1.Value, 5);
                //intUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
                paBusqueda.Visible = false;
                pcFecha = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 5);
                intUsuario = Variables.gnCodUser;

            }
            else
            {
                paBusqueda.Visible = true;
                bResult = fnCargarUsuario();
                pcFecha = FunGeneral.GetFechaHoraFormato(dateTimePicker1.Value, 5);
                intUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
            }
            bResult = fnListarCajaDia(pcFecha, intUsuario, out nSaldo);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            textBox1.Text = nSaldo.ToString();
        }

        Int32 lidTrandiaria = 0;

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            lidTrandiaria = 0;
            //Boolean bFilaSele = false;
            if (dataGridView1.RowCount > 0)
            {
                lidTrandiaria = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
        }

        private Boolean fnEliminarMovCaja(Int32 pidTrandiaria, int pidUsuario, string pcFechaSis)
        {
            BLDocumentoVenta objOrden = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtOrden = new DataTable();
            bool lbResul = false;

            try
            {
                lbResul = objOrden.blEliminarMovCaja(pidTrandiaria,pidUsuario,pcFechaSis);
                return lbResul;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmMovimientoCaja", "fnEliminarMovCaja", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objOrden = null;
                dtOrden = null;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool lbResul = false;
            decimal  lnSaldo = 0;
                    if (dataGridView1.Rows.Count > 0)
                    {
                        if (lidTrandiaria > 0)
                        {
                            if (MessageBox.Show("Desea eliminar el Movimiento de Caja Seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                lbResul=fnEliminarMovCaja(lidTrandiaria,Variables.gnCodUser,FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis,3));
                                if (!lbResul)
                                    MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                else
                                {
                                    lbResul = fnListarCajaDia(pcFecha, Funciones.Variables.gnCodUser, out lnSaldo);
                                    if (!lbResul)
                                    {
                                        MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.Close();
                                    }
                                    textBox1.Text = lnSaldo.ToString();
                                }
                            }
                        }
                    }
            
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool lbResul = false;
            decimal lnSaldo = 0;

            if (dataGridView1.Rows.Count > 0)
            {
                lidTrandiaria = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                if (lidTrandiaria > 0)
                {
                    if (MessageBox.Show("Desea eliminar el Movimiento de Caja Seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        lbResul = fnEliminarMovCaja(lidTrandiaria, Variables.gnCodUser, FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 3));
                        if (!lbResul)
                            MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        else
                        {
                            lbResul = fnListarCajaDia(pcFecha, Funciones.Variables.gnCodUser, out lnSaldo);
                            if (!lbResul)
                            {
                                MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();
                            }
                            textBox1.Text = lnSaldo.ToString();
                        }
                    }
                }
            }
        }

        private String fnCerrarCaja(decimal lnMonto)
        {
            String lcResultado = "";
            BLDocumentoVenta obj = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            try
            {

                lcResultado = obj.blAperturarCaja(Variables.idSucursal, lnMonto, Variables.gnCodUser, FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 3), 11);
                if (lcResultado == "OK")
                    this.Dispose();
                return lcResultado;

            }
            catch (Exception ex)
            {
                lcResultado = "XX";
                objUtil.gsLogAplicativo("frmMovimientoCaja", "fnCerrarCaja", ex.Message);
                return lcResultado;
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            String lcResultado = "";
            decimal lnMontoSaldo=0;
            decimal lnMontoArqueo=0;

            if (FunGeneral.fnVerificarApertura())
            {
                lnMontoSaldo=Convert.ToDecimal(textBox1.Text.Trim() == "" ? "0" : textBox1.Text.Trim());
                lnMontoArqueo=Convert.ToDecimal(txtMontoArqueo.Text.Trim() == "" ? "0" : txtMontoArqueo.Text.Trim());
                if (lnMontoArqueo >= lnMontoSaldo)
                {
                    lcResultado = fnCerrarCaja(lnMontoArqueo);
                    if (lcResultado != "OK")
                    {
                        btnCerrar.Enabled = false;
                        MessageBox.Show("Error al Cerrar Caja. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else {
                    MessageBox.Show("Verificar su caja tiene un descuadre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else {
                MessageBox.Show("Debe Aperturar Caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnArqueo_Click(object sender, EventArgs e)
        {
            frmArquearCaja frmArqueo = new frmArquearCaja();
            frmArqueo.ShowDialog();
            txtMontoArqueo.Text = lnMontoArqueo.ToString();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Impresiones.frmImpresion frmImpre = new Impresiones.frmImpresion();
            frmImpre.fnInicio(3, "Imprimir Cuadre de Caja", 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool lbResul = false;
            decimal lnSaldo = 0;
            frmAperturaCaja frmCaja = new frmAperturaCaja();
            frmCaja.ShowDialog();
            lbResul = fnListarCajaDia(pcFecha, Funciones.Variables.gnCodUser, out lnSaldo);
            if (!lbResul)
            {
                MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            textBox1.Text = lnSaldo.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            decimal nSaldo = 0;
            int intUsuario = 0;

            pcFecha = FunGeneral.GetFechaHoraFormato(dateTimePicker1.Value, 5);
            intUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
        
            bResult = fnListarCajaDia(pcFecha, intUsuario, out nSaldo);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            textBox1.Text = nSaldo.ToString();
        }
    }
}
