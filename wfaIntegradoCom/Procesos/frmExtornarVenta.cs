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
    public partial class frmExtornarVenta : Form
    {
        public frmExtornarVenta()
        {
            InitializeComponent();
        }

        private Boolean fnListarExtorno(string pcFecha, string pcBuscar, Int16 pidSucursal, Int16 piTipoCon)
        {
            BLDocumentoVenta objOrden = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtOrden = new DataTable();

            try
            {
                dtOrden = objOrden.BLListarExtorno(pcFecha, pcBuscar, pidSucursal, piTipoCon);
                dataGridView1.DataSource = dtOrden;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmExtornarVenta", "fnListarExtorno", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objOrden = null;
                dtOrden = null;
            }
        }

        string pcFecha = "";
        private void frmExtornarVenta_Load(object sender, EventArgs e)
        {
            bool bResult = false;
            
            pcFecha = Funciones.FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 5);

            bResult = fnListarExtorno(pcFecha, Variables.gsCodUser,Variables.idSucursal,0);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Lista de Venta a Extornar", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool bResult = false;
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (comboBox1.Text.Trim() == "Usuario")
                {
                    if (textBox1.Text.Trim() != "")
                    {
                        bResult = fnListarExtorno(pcFecha, textBox1.Text.Trim(),0, 1);
                        if (!bResult)
                        {
                            MessageBox.Show("Error al Cargar Lista de Venta a Extornar", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else if (comboBox1.Text.Trim() == "Cliente")
                {
                    if (textBox1.Text.Trim() != "")
                    {
                        bResult = fnListarExtorno(pcFecha, textBox1.Text.Trim(),0, 2);
                        if (!bResult)
                        {
                            MessageBox.Show("Error al Cargar Lista de Venta a Extornar", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    if (textBox1.Text.Trim() != "")
                    {
                        string lcName = "";
                        lcName = lcName.PadLeft(4 - textBox1.Text.Trim().Length, '0') + textBox1.Text.Trim();
                        lcName = "MESA" + lcName;
                        bResult = fnListarExtorno(pcFecha, lcName,0, 3);
                        if (!bResult)
                        {
                            MessageBox.Show("Error al Cargar Lista de Venta a Extornar", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                    if (Char.IsDigit(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else if (Char.IsControl(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else if (Char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private String fnExtornarVenta()
        {
            BLDocumentoVenta objOrden = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtOrden = new DataTable();
            string  lcResul = "";
            bool bResult = false;
            string cFecha="";

            try
            {
                cFecha=FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis,6);
                if (dataGridView1.Rows.Count > 0)
                {
                    lidVenta = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                    lidSucursal = Convert.ToInt16(dataGridView1.CurrentRow.Cells[5].Value);
                    lidTipoVenta = Convert.ToInt16(dataGridView1.CurrentRow.Cells[6].Value);
                    if (lidVenta > 0)
                    {
                        lcResul = objOrden.blExtornarVenta(lidVenta, lidSucursal, Variables.gnCodUser, cFecha,lidTipoVenta);
                        if (lcResul == "OK")
                        {
                            bResult = fnListarExtorno(pcFecha, Funciones.Variables.gsCodUser,Variables.idSucursal, 0);
                            if (!bResult)
                            {
                                return "XY";
                            }
                        }
                    }
                    else return "OK";
                }
                else { return "OK"; }

                return lcResul;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmExtornarVenta", "fnExtornarVenta", ex.Message);
                return "XX";
            }
            finally
            {
                objUtil = null;
                objOrden = null;
                dtOrden = null;
            }
        }

        private void btnExtornar_Click(object sender, EventArgs e)
        {
            string lcResul = "";

            lcResul = fnExtornarVenta().Trim();
            if (lcResul != "OK")
            {
                MessageBox.Show(lcResul == "XY" ? "Error al Cargar Lista de Pendientes de Extorno" : "Error al Extornar Venta por Mesa", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else { lidVenta = 0; lidSucursal = 0; }
        }
        int lidVenta=0;
        Int16 lidSucursal=0;
        Int16 lidTipoVenta = 0;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
              lidVenta = 0;
            //Boolean bFilaSele = false;
              if (dataGridView1.RowCount > 0)
              {
                  lidVenta = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                  lidSucursal = Convert.ToInt16(dataGridView1.CurrentRow.Cells[5].Value);
                  lidTipoVenta = Convert.ToInt16(dataGridView1.CurrentRow.Cells[6].Value);
              }

        }
    }
}
