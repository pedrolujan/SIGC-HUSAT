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
using wfaIntegradoCom.Procesos;
using wfaIntegradoCom.Consultas;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmBuscarCliente : Form
    {

        Int16 lnTipoLlamada = 0;


        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        Int16 lnTipoCon = 0;

        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();
        }

        private Boolean fnBuscarCliente(String pcBuscar, Int16 pnTipoCon)
        {
            BLCliente objCli = new BLCliente();
            Boolean pbhabilitaLista = false;


            clsUtil objUtil = new clsUtil();
            List<Cliente> lstCliente = null;
            ListViewItem lstItem = null;
            try
            {

                lstCliente = new List<Cliente>();
                //lstCliente = objCli.blBuscarCliente(pcBuscar, pnTipoCon);
                lvCliente.Items.Clear();
                //foreach (Cliente objCliente in lstCliente)
                //{
                //    lstItem = lvCliente.Items.Add(objCliente.idCliente.ToString());
                //    lstItem.SubItems.Add(objCliente.cCliente);
                //    lstItem.SubItems.Add(objCliente.cDocumento);
                //    lstItem.SubItems.Add(objCliente.cTiDo);
                //    lstItem.SubItems.Add(objCliente.cTelCelular);
                //    if (objCliente.bEstado == true)
                //    {
                //        lstItem.SubItems.Add("Activo");
                //    }
                //    else
                //    {
                //        lstItem.SubItems.Add("Inactivo");
                //    }
                //    pbhabilitaLista = true;
                //}

                lvCliente.Visible = pbhabilitaLista;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnBuscarCliente", ex.Message);
                return false;
            }
            finally
            {
                lstCliente = null;
                objCli = null;
                objUtil = null;
            }

        }

        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon = 0;
                Boolean bResul = false;

                if (rbCodigo.Checked == true)
                {

                    pnTipocon = 0;
                }
                else if (rbRazon.Checked == true)
                {
                    pnTipocon = 1;
                }
                else if (rbDoc.Checked == true)
                {
                    pnTipocon = 2;
                }

                bResul = fnBuscarCliente(txtBuscarCliente.Text.Trim(), pnTipocon);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private Boolean fnRecuperarClienteEsp()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (lvCliente.Items.Count > 0)
                {
                    ListView.SelectedListViewItemCollection item = lvCliente.SelectedItems;
                    if (item.Count > 0)
                    {
                        //frmDocumentoVenta.fnRecuperarCliente(item[0].Text.Trim(), item[0].SubItems[4].Text.ToString().Trim(), item[0].SubItems[3].Text.ToString().Trim(), item[0].SubItems[2].Text.ToString().Trim(), 1);
                        frmRegistrarVehiculo.fnRecuperarCliente(item[0].Text.Trim(), item[0].SubItems[4].Text.ToString().Trim(), item[0].SubItems[3].Text.ToString().Trim(), item[0].SubItems[2].Text.ToString().Trim(), 1);
                    }
                  
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnRecuperarClienteEsp", ex.Message);
                return false;
            }
        }

        private Boolean fnRecuperarClienteEspDeuda()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (lvCliente.Items.Count > 0)
                {
                    ListView.SelectedListViewItemCollection item = lvCliente.SelectedItems;
                    if (item.Count > 0)
                    {
                        frmBuscarDeudas.fnRecuperarCliente(item[0].SubItems[1].Text.ToString().Trim(), Convert.ToInt32(item[0].Text.Trim()));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnRecuperarClienteEspDeuda", ex.Message);
                return false;
            }
        }

        private Boolean fnRecuperarClienteEsprptVenta()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (lvCliente.Items.Count > 0)
                {
                    ListView.SelectedListViewItemCollection item = lvCliente.SelectedItems;
                    if (item.Count > 0)
                    {
                        frmReporteVenta.fnRecuperarCliente(item[0].SubItems[1].Text.ToString().Trim(), Convert.ToInt32(item[0].Text.Trim()));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnRecuperarClienteEsprptVenta", ex.Message);
                return false;
            }
        }


        

        private void lvCliente_DoubleClick(object sender, EventArgs e)
        {
           if (lnTipoLlamada == 1)
            {
                Boolean bResul = false;
                bResul = fnRecuperarClienteEsp();
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar Cliente Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else {
                    this.Dispose(); }
            }
            else if(lnTipoLlamada == 3)
            {
                Boolean bResul = false;
                bResul = fnRecuperarClienteEspDeuda();
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar Cliente Especifico en Deudas", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.Dispose();
                }
            }
            else if (lnTipoLlamada == 4)
            {
                Boolean bResul = false;
                bResul = fnRecuperarClienteEsprptVenta();
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar Cliente Especifico en Reporte de Ventas", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.Dispose();
                }
            }
        }


        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private Boolean fnLlenarTablaCod(ComboBox cboCombo, String cCodTab)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverTablaCod(cCodTab);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }

        private void frmRegistrarCliente_Load(object sender, EventArgs e)
        {
            Int16 pnTipocon = 0;
            Boolean bResul = false;

            if (rbCodigo.Checked == true)
            {

                pnTipocon = 0;
            }
            else if (rbRazon.Checked == true)
            {
                pnTipocon = 1;
            }
            else if (rbDoc.Checked == true)
            {
                pnTipocon = 2;
            }
            bResul = fnBuscarCliente(txtBuscarCliente.Text.Trim(), pnTipocon);
            if (!bResul)
            {
                MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (lnTipoLlamada == 0)
            {
            }
            else if (lnTipoLlamada == 1)
            {
                this.Text = "Consultar Cliente";
                Height = 500;
                lvCliente.Visible = true;
                lvCliente.Left = 12;
                lvCliente.Top = 60;
                lvCliente.Height = 390;
                lvCliente.Width = 635;
                //fnOcultarObjeto(lnTipoLlamada);
            }
            else if (lnTipoLlamada == 2)
            {
                //Boolean bResult = false;

                //bResult = fnLlenarDepartamento();
                //if (!bResult)
                //{
                //    MessageBox.Show("Error al Cargar Departamentos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.Close();
                //}
                //bResult = fnLlenarTablaCod(cboTipoDoc, "TIDO");
                //if (!bResult)
                //{
                //    MessageBox.Show("Error al Cargar TablaCod - Tipo Documento", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.Close();
                //}
                //bResult = fnLlenarTablaCod(cboTipoCliente, "TIPE");
                //if (!bResult)
                //{
                //    MessageBox.Show("Error al Cargar TablaCod - Tipo de Persona", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.Close();
                //}
                //fnHabilitarControles(true);
                //fnOcultarObjeto(lnTipoLlamada);
            }
            else if (lnTipoLlamada == 3)
            {
                this.Text = "Consultar Cliente";
                Height = 500;
                lvCliente.Visible = true;
                lvCliente.Left = 12;
                lvCliente.Top = 60;
                lvCliente.Height = 390;
                lvCliente.Width = 635;
                //fnOcultarObjeto(lnTipoLlamada);
            }
            else if (lnTipoLlamada == 4)
            {
                this.Text = "Consultar Cliente";
                Height = 500;
                lvCliente.Visible = true;
                lvCliente.Left = 12;
                lvCliente.Top = 60;
                lvCliente.Height = 390;
                lvCliente.Width = 635;
                //fnOcultarObjeto(lnTipoLlamada);
            }
        }

        private void rbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            //if (lnTipoLlamada == 0)
            //{
            //    if (rbCodigo.Checked == true)
            //    {
            //        fnLimpiarControles();
            //        fnHabilitarControles(false);
            //    }
            //}
            //else {
            //    txtBuscarCliente.Text = "";
            //    txtBuscarCliente.Focus();
            //    lvCliente.Items.Clear();
            //}
        }

        private void rbDoc_CheckedChanged(object sender, EventArgs e)
        {
            //if(lnTipoLlamada==0)
            //{ 
            //    if (rbDoc.Checked == true)
            //    {
            //        fnLimpiarControles();
            //        fnHabilitarControles(false);
            //    }
            //}
            //else 
            //{
            //    txtBuscarCliente.Text = "";
            //    txtBuscarCliente.Focus();
            //    lvCliente.Items.Clear();
            //}
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
           
        }

        private void lvCliente_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    if (lnTipoLlamada == 0)
                    {
                        //Boolean bResul = false;
                        //bResul = fnListarClienteEspecifico();
                        //if (!bResul)
                        //{
                        //    MessageBox.Show("Error al Cargar Cliente Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    this.Close();
                        //}
                    }
                    else if (lnTipoLlamada == 1)
                    {
                        Boolean bResul = false;
                        bResul = fnRecuperarClienteEsp();
                        if (!bResul)
                        {
                            MessageBox.Show("Error al Recuperar Cliente Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else { this.Dispose(); }
                    }
                    else if (lnTipoLlamada == 3)
                    {
                        Boolean bResul = false;
                        bResul = fnRecuperarClienteEspDeuda();
                        if (!bResul)
                        {
                            MessageBox.Show("Error al Recuperar Cliente Especifico en Deudas", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            this.Dispose();
                        }
                    }
                    else if (lnTipoLlamada == 4)
                    {
                        Boolean bResul = false;
                        bResul = fnRecuperarClienteEsprptVenta();
                        if (!bResul)
                        {
                            MessageBox.Show("Error al Recuperar Cliente Especifico en Reporte Venta", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            this.Dispose();
                        }
                    }
                }
        }

        private void txtdni_KeyPress(object sender, KeyPressEventArgs e)
        {

            
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

        private void txtTelFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void txtTelCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
