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
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmRegistrarPerioricidad : Form
    {
        public frmRegistrarPerioricidad()
        {
            InitializeComponent();
        }
        Boolean estNombrePerio, estActualizar;
        String msjNombrePerio;
        Int16 lnTipoCon = 0;
        Int32 lnTipoLlamada = 0;

        private Boolean fnBuscarPerioricidad(String pcBuscar, Int16 pnTipoCon)
        {
            BLPerioricidad objPer = new BLPerioricidad();
            Boolean pbhabilitaLista = false;


            clsUtil objUtil = new clsUtil();
            List<Perioricidad> lstPerio = null;
            ListViewItem lstItem = null;
            try
            {

                lstPerio = new List<Perioricidad>();
                lstPerio = objPer.blBuscarPerio(pcBuscar, pnTipoCon);
                lvPerio.Items.Clear();
                foreach (Perioricidad objPerio in lstPerio)
                {
                    lstItem = lvPerio.Items.Add(objPerio.idPerio.ToString());

                    lstItem.SubItems.Add(objPerio.nombrePerio);

                    pbhabilitaLista = true;
                }

                lvPerio.Visible = pbhabilitaLista;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarPerioricidad", "fnBuscarPerio", ex.Message);
                return false;
            }
            finally
            {
                lstPerio = null;
                objPer = null;
                objUtil = null;
            }

        }
        private void fnLimpiarControles()
        {
            txtNombrePerio.Focus();
            ////TEXBOXS////
            txtIdPerio.Text = "0";
            txtNombrePerio.Text = "";
            txtBuscarPerio.Text = "";
            ////LABELS/////
            erPerio.Text = "";
            ////LISTBOX////
            lvPerio.Visible = false;
            ////ESTADOS///
            estNombrePerio = false;
            ////PICTUREBOXS///
            imgPerio.Image = null;

        }
        private Boolean fnListarPerioricidadEspecifico()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (lvPerio.Items.Count > 0)
                {
                    BLPerioricidad objPer = new BLPerioricidad();
                    Perioricidad[] lstPerio = new Perioricidad[1];

                    ListView.SelectedListViewItemCollection item = lvPerio.SelectedItems;
                    if (item.Count > 0)
                    {
                        lstPerio = objPer.blListarPerioricidad(Convert.ToInt32(item[0].SubItems[0].Text)).ToArray();

                        if (lstPerio.GetLength(0) > 0)
                        {
                            txtIdPerio.Text = Convert.ToString(lstPerio[0].idPerio);
                            txtNombrePerio.Text = Convert.ToString(lstPerio[0].nombrePerio);


                            lvPerio.Visible = false;
                            fnHabilitarControles(true);
                            txtBuscarPerio.Text = "";
                            lnTipoCon = 1;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarPerio", "fnListarPerioEspecifico", ex.Message);
                return false;
            }
        }
        private void fnHabilitarControles(Boolean pbHabilitar)
        {
            gbPerio.Enabled = pbHabilitar;
            saveToolStripButton.Enabled = pbHabilitar;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            String lcResultado = "";


            var result1 = fnValidarTexboxSQL(txtNombrePerio, erPerio, imgPerio, false, 0);

            estNombrePerio = result1.Item1;
            msjNombrePerio = result1.Item2;


            if (estNombrePerio == true)
            {


                lcResultado = fnGuardarPerioricidad(lnTipoCon);
                if (lcResultado == "OK")
                {

                    MessageBox.Show("Se Grabo Satisfactoriamente Perioricidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {

                    MessageBox.Show("Error al Grabar Perio. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Complete correctamente los campos", "Respuesta Perioricidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private String fnGuardarPerioricidad(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLPerioricidad blPerio = new BLPerioricidad();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Perioricidad objPerio = new Perioricidad();
            try
            {
                objPerio.idPerio = Convert.ToInt32(txtIdPerio.Text.Trim());
                objPerio.nombrePerio = Convert.ToString(txtNombrePerio.Text.Trim());

                objPerio.bEstado = Convert.ToBoolean(chkEstado.Checked);
                objPerio.dFechaRegistro = dFechaSis;
                objPerio.idUsuario = Variables.gnCodUser;

                lcValidar = blPerio.blGrabarPerioricidad(objPerio, idTipoCon).Trim();
                fnLimpiarControles();
                fnHabilitarControles(false);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarPerio", "fnGuardarPerio", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private void txtBuscarPerio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon = 0;
                Boolean bResul = false;

                if (rbNombrePerio.Checked == true)
                {
                    pnTipocon = 0;
                }


                bResul = fnBuscarPerioricidad(txtBuscarPerio.Text.Trim(), pnTipocon);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Periodo. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void lvPerio_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                bResul = fnListarPerioricidadEspecifico();
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Cliente Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnHabilitarControles(true);
            fnLimpiarControles();
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmRegistrarPerioricidad_Load(object sender, EventArgs e)
        {
            fnHabilitarControles(false);
        }

        private Tuple<Boolean, String> fnValidarTexboxSQL(TextBox txt, Label lbl, PictureBox img, Boolean maximo, Int32 num)
        {
            String msj;
            Boolean bResul;
            Int16 pnTipocon = 0;

            if (txt.Text == null || txt.Text.Trim() == "")
            {
                img.Image = Properties.Resources.error;
                msj = "Ingrese datos (campo obligatorio)";
                lbl.Text = msj;

                return Tuple.Create(false, msj);

            } else if (estActualizar == true)
            { 

                if (txt.Text.Trim() == txt.Text.Trim())
                {
                    img.Image = Properties.Resources.ok;
                    msj = "";
                    lbl.Text = msj;

                    return Tuple.Create(true, msj);
                }
                else
                {
                    img.Image = Properties.Resources.ok;
                    msj = "";
                    lbl.Text = msj;
                    bResul = fnBuscarNombrePerio(txt.Text.Trim(), pnTipocon);
                    return Tuple.Create(bResul, msj);

                }

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                bResul = fnBuscarNombrePerio(txt.Text.Trim(), pnTipocon);
                return Tuple.Create(bResul, msj);

            }
               
        
        }
           

        

        private Boolean fnBuscarNombrePerio(String pcBuscar, Int16 pnTipoCon)
        {
            BLPerioricidad objPer = new BLPerioricidad();
            clsUtil objUtil = new clsUtil();
            Int16 numResult = 0;

            try
            {

                numResult = objPer.blBuscarNombrePerio(pcBuscar, pnTipoCon);

                if (numResult == 1)
                {
                    erPerio.Text = "Este nombre ya existe (Ingrese otro nombre)";
                    erPerio.ForeColor = Color.Red;
                    imgPerio.Image = Properties.Resources.error;
                    return false;
                }
                else if (numResult == 0)
                {
                    erPerio.Text = "";
                    imgPerio.Image = Properties.Resources.ok;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnBuscarCliente", ex.Message);
                return false;
            }
            finally
            {

                objPer = null;
                objUtil = null;
            }
        }
        private void txtNombrePerio_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexboxSQL(txtNombrePerio, erPerio, imgPerio, false, 0);
            
            estNombrePerio = result.Item1;
            msjNombrePerio = result.Item2;
        }
        void fnValidarTipografia(KeyPressEventArgs e, Int32 num, Boolean mayusculas)
        {
            if (num == 1)
            {
                if (mayusculas)
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                    if ((Char.IsLetter(e.KeyChar)) || (Char.IsControl(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
                    {
                        e.Handled = false;

                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.KeyChar = char.ToLower(e.KeyChar);
                    if ((Char.IsLetter(e.KeyChar)) || (Char.IsControl(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
                    {
                        e.Handled = false;


                    }
                    else
                    {
                        e.Handled = true;
                    }
                }


            }
            else if (num == 2)
            {
                if ((Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (num == 3)
            {
                if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar)) || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (num == 4)
            {

                if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar))
                    || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar))
                    || (e.KeyChar == '@') || (e.KeyChar == '_') || (e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (num == 5)
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
                if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar))
                     || (Char.IsControl(e.KeyChar) || (e.KeyChar == '.')))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }

        }
        private void txtNombrePerio_KeyPress(object sender, KeyPressEventArgs e)
        {
            fnValidarTipografia(e, 1, true);
        }
    }
}
