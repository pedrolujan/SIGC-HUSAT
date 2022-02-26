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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmRegistrarMarcaVehiculo : Form
    {
        
        public frmRegistrarMarcaVehiculo()
        {
            InitializeComponent();
        }
        Int16 lnTipoCon = 0;
        Int16 lnTipoLlamada = 0;

        Boolean estClase, estMarca, estModelo, estPlaca, estSerie, estAnio, estColor, estUso, estPropietario;
        String msjClase, msjMarca, msjModelo, msjPlaca, msjSerie, msjAnio, msjColor, msjUso, msjPropietario;
        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();
        }
       
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
           String lcResultado = "";  

            if (estClase==true && estMarca==true)
            {
               lcResultado = fnGuardarMarca(lnTipoCon);
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente Marca", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Grabar Marca. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Complete todos los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private String fnGuardarMarca(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLAttrVehiculo objAttrV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            MarcaVehiculo objMarca = new MarcaVehiculo();
            //Boolean bCargar = false;

            try
            {
                objMarca.idMarca = Convert.ToInt32(txtCodMarca.Text);
                objMarca.cNomMarca = Convert.ToString(txtMarca.Text.Trim());
                objMarca.idClase = Convert.ToInt32(cboClaseV.SelectedValue);
                objMarca.bEstado = Convert.ToBoolean(chkEstadoMarca.Checked);
                objMarca.dFechaReg = dFechaSis;
                objMarca.idUsuario = Variables.gnCodUser;

                lcValidar = objAttrV.blGrabarMarca(objMarca, idTipoCon).Trim();
                fnLimpiarControles();
                fnHabilitarControles(false, 1);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarAttrVehiculo", "fnGuardarMarca", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        //private String fnGuardarModelo(Int16 idTipoCon)
        //{
        //    DateTime dFechaSis = Variables.gdFechaSis;
        //    BLAttrVehiculo objAttrV = new BLAttrVehiculo();
        //    clsUtil objUtil = new clsUtil();
        //    String lcValidar = "";
        //    ModeloVehiculo objModelo = new ModeloVehiculo();
        //    //Boolean bCargar = false;
        //    try
        //    {
        //        objModelo.idModelo = Convert.ToInt32(txtCodModelo.Text);
        //        objModelo.cNomModelo = Convert.ToString(txtModelo.Text.Trim());
        //        objModelo.bEstado = Convert.ToBoolean(chkEstadoModelo.Checked);
        //        //objMarca.dFechaReg = dFechaSis;
        //        //objMarca.idUsuario = Convert.ToInt32(txtCodMarca.Text); 

        //        lcValidar = objAttrV.blGrabarModelo(objModelo, idTipoCon).Trim();
        //        fnLimpiarControles(1);
        //        //fnHabilitarControles(false, 1);
        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("frmRegitsrarAttrVehiculo", "fnGuardarModelo", ex.Message);
        //        lcValidar = "NO";
        //    }

        //    return lcValidar;

        //}
        private void fnHabilitarControles(Boolean pbHabilitar, Int16 pnTipoTab)
        {
            if (pnTipoTab == 1)
            {
                gbMarca.Enabled = pbHabilitar;
                saveToolStripButton.Enabled = pbHabilitar;
            }
            else if (pnTipoTab == 2)
            {
                gbMarca.Enabled = pbHabilitar;
                saveToolStripButton.Enabled = pbHabilitar;

            }
            
        }

        private void fnLimpiarControles()
        {
                txtCodMarca.Text = "0";
                txtMarca.Text = "";
                chkEstadoMarca.Checked = true;
                lvMarca.Visible = false;
                txtBuscarMarca.Text = "";
                epVehiculo.Clear();
                txtBuscarMarca.Focus();
            cboClaseV.SelectedValue = 0;
        }  

        private void txtBuscarMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon = 0;

                if (rbCodigoMarca.Checked == true)
                {

                    pnTipocon = 0;
                }
                else
                {
                    pnTipocon = 1;
                }

                fnBuscarMarcaV(txtBuscarMarca.Text.Trim(), pnTipocon);
            }
        }

        private Boolean fnBuscarMarcaV(String pcBuscar, Int16 pnTipoCon)
        {
            BLAttrVehiculo objAttrV = new BLAttrVehiculo();
            Boolean pbhabilitaLista = false;

            clsUtil objUtil = new clsUtil();
            List<MarcaVehiculo> lstMarcaV = null;
            ListViewItem lstItem = null;
            try
            {
                lstMarcaV = new List<MarcaVehiculo>();
                //lstMarcaV = objAttrV.blBuscarMarcaV(pcBuscar, pnTipoCon);
                if (lstMarcaV.Count == 0)
                {
                    blResulBusqueda.Text = "No se encontraron datos para la busqueda  ( " + lstMarcaV.Count + " )";
                    blResulBusqueda.ForeColor = Color.Red;
                }
                else
                {
                    blResulBusqueda.Text = "Resultados de tu busqueda   ( " + lstMarcaV.Count + " )";
                    blResulBusqueda.ForeColor = Color.Green;
                }
                lvMarca.Items.Clear();
                foreach (MarcaVehiculo objMarca in lstMarcaV)
                {
                    lstItem = lvMarca.Items.Add(objMarca.idMarca.ToString());
                    lstItem.SubItems.Add(objMarca.cNomMarca);
                    lstItem.SubItems.Add(objMarca.cNomClase);
                    if (objMarca.bEstado==true)
                    {
                        lstItem.SubItems.Add("Activo");
                    }
                    else
                    {
                        lstItem.SubItems.Add("Inactivo");
                    }
                    
                    pbhabilitaLista = true;
                }

                lvMarca.Visible = pbhabilitaLista;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAttrVehiculo", "fnBuscarMarcaV", ex.Message);
                return false;
            }

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
           

            if (cboClaseV.SelectedIndex!=0)
            {
                var result = fnValidarTexbox(txtMarca, lblCboMarca, pbMarca, false, 0, true);
                estMarca = result.Item1;
                msjMarca = result.Item2;
            }

            Int32 ValidaMarca = fnValidarMarcaExistente(txtMarca.Text.Trim(), txtMarca2.Text.Trim(),Convert.ToInt16(cboClaseV.SelectedValue), lnTipoCon);
           
            if (ValidaMarca==1)
            {
                var resultExistencia = fnValidaDatosDuplicados(txtMarca, lblCboMarca, pbMarca, true, true);
                estMarca = resultExistencia.Item1;
                msjMarca = resultExistencia.Item2;
                MessageBox.Show("Esta marca ya existe verifique su clase ó ingrese otra Marca", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            
        }

        private Boolean fnRecuperarMarcaEsp()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (lvMarca.Items.Count > 0)
                {
                    ListView.SelectedListViewItemCollection item = lvMarca.SelectedItems;
                    if (item.Count > 0)
                    {
                        frmRegistrarVehiculo.fnRecuperarMarca(item[0].Text.Trim(),1);
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


        private void lvMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(lvMarca.Items.Count > 0)
            {
                ListView.SelectedListViewItemCollection item = lvMarca.SelectedItems;
                txtCodMarca.Text = item[0].SubItems[0].Text;
                txtMarca.Text = item[0].SubItems[1].Text;
                chkEstadoMarca.Checked = Convert.ToBoolean(item[0].SubItems[3].Text);
                lvMarca.Visible = false;
                fnHabilitarControles(true, 1);
                txtBuscarMarca.Text = "";
                lnTipoCon = 1;
            }
        }

        private void frmRegistrarMarcaVehiculo_Click(object sender, EventArgs e)
        {
            if (lvMarca.Visible==true)
            {
                lvMarca.Visible = false;
            }
        }

        //private Boolean fnListarMarcaEspecifica()
        //{
        //    clsUtil objUtil = new clsUtil();
        //    try
        //    {

        //        if (lvMarca.Items.Count > 0)
        //        {
        //            BLAttrVehiculo objMarca = new BLAttrVehiculo();
        //            MarcaVehiculo[] lstMarca= new MarcaVehiculo[1];

        //            ListView.SelectedListViewItemCollection item = lvMarca.SelectedItems;
        //            if (item.Count > 0)
        //            {
        //                lstMarca = objMarca.blListarMarcaEspecifica(Convert.ToInt32(item[0].SubItems[0].Text)).ToArray();

        //                if (lstMarca.GetLength(0) > 0)
        //                {
        //                    txtCodMarca.Text = Convert.ToString(lstMarca[0].idMarca);
        //                    txtMarca2.Text = Convert.ToString(lstMarca[0].cNomMarca);
        //                    txtMarca.Text = Convert.ToString(lstMarca[0].cNomMarca);
        //                    cboClaseV.SelectedValue = lstMarca[0].idClase;
        //                    chkEstadoMarca.Checked = lstMarca[0].bEstado;
        //                    lvMarca.Visible = false;
        //                    fnHabilitarControles(true,1);
        //                    txtBuscarMarca.Text = "";
        //                    lnTipoCon = 1;
        //                }
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnListarMarcaEspecifica", ex.Message);
        //        return false;
        //    }
        //}

        //private Boolean fnListarModeloEspecifico()
        //{
        //    clsUtil objUtil = new clsUtil();
        //    try
        //    {

        //        if (lvModelo.Items.Count > 0)
        //        {
        //            BLAttrVehiculo objModelo = new BLAttrVehiculo();
        //            ModeloVehiculo[] lstModelo = new ModeloVehiculo[1];

        //            ListView.SelectedListViewItemCollection item = lvModelo.SelectedItems;
        //            if (item.Count > 0)
        //            {
        //                lstModelo = objModelo.blListarModelo(Convert.ToInt32(item[0].SubItems[0].Text)).ToArray();

        //                if (lstModelo.GetLength(0) > 0)
        //                {
        //                    txtCodModelo.Text = Convert.ToString(lstModelo[0].idModelo);
        //                    txtModelo.Text = Convert.ToString(lstModelo[0].cNomModelo);
        //                    chkEstadoModelo.Checked = lstModelo[0].bEstado;
        //                    lvModelo.Visible = false;
        //                    fnHabilitarControles(true,2);
        //                    txtBuscarModelo.Text = "";
        //                    lnTipoCon = 1;
        //                }
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnListarMarcaEspecifica", ex.Message);
        //        return false;
        //    }
        //}


        private void lvMarca_DoubleClick(object sender, EventArgs e)
        {
            //if (lnTipoLlamada == 0)
            //{
           
            Boolean bResul = false;
                //bResul = fnListarMarcaEspecifica();
                //if (!bResul)
                //{
                //    MessageBox.Show("Error al Cargar Marca Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.Close();
                //}
            //}else if(lnTipoLlamada==1)
            //{

            //    Boolean bResul = false;
            //    bResul = fnRecuperarMarcaEsp();
            //    if (!bResul)
            //    {
            //        MessageBox.Show("Error al Recuperar Marca Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //    else
            //    {
            //        this.Dispose();
            //    }
            //}

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

      
        private void frmRegistrarAttrVehiculo_Load(object sender, EventArgs e)
        {
           
            fnHabilitarControles(false, 1);
           
            Boolean bResult = false;
            bResult = fnLLenarClaseVehiculo();
            pbClase.Image = null;
            lblCboClase.Text = "";
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Clase Vehiculo", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnHabilitarControles(true, 2);
            fnLimpiarControles();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnHabilitarControles(true, 1);
            fnLimpiarControles();
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            fnValidarTipografia(e, 1, true);
        }
        private Boolean fnLLenarClaseVehiculo()
        {
            BLAttrVehiculo objClaseV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            List<ClaseVehiculo> lstClase = new List<ClaseVehiculo>();

            try
            {
                lstClase = objClaseV.blDevolverClaseV(0);
                cboClaseV.ValueMember = "idClase";
                cboClaseV.DisplayMember = "cNomClase";
                cboClaseV.DataSource = lstClase;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarClaseVehiculo", ex.Message);
                return false;
            }
            finally
            {
                lstClase = null;
            }
        }
        private Int32 fnValidarMarcaExistente(String txtMarca, String txtMarca2, Int16 idClase, Int16 pnTipoCon)
        {

            BLAttrVehiculo objMarcaV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            Int32 validarMarca = 0;

            try
            {
                validarMarca = objMarcaV.blDevolverValidarMarcaExistente(txtMarca, txtMarca2, idClase, pnTipoCon);

                return validarMarca;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLLnenarProvinciaxDepa", ex.Message);
                return validarMarca;
            }
            finally
            {
            }
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
                e.KeyChar = char.ToUpper(e.KeyChar);
                if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar)) || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                if (Char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }
        public Tuple<Boolean, String> fnValidaDatosDuplicados(TextBox txt, Label lbl, PictureBox img, Boolean Obligatorio, Boolean Existencia)
        {
            Boolean estad;
            String msj;
            if (Existencia == true)
            {
                img.Image = Properties.Resources.error;
                msj = "Esta marca ya existe\n( Verifique su clase ó ingrese otra Marca )";

                lbl.Text = msj;
                estad = false;
                return Tuple.Create(estad, msj);

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                estad = true;
                return Tuple.Create(estad, msj);
            }
        }
        private Tuple<Boolean, String> fnValidarTexbox(TextBox txt, Label lbl, PictureBox img, Boolean maximo, Int32 num, Boolean Obligatorio)
        {
            String msj;

            if (txt.Text == null || txt.Text.Trim() == "" && Obligatorio == true)
            {
                img.Image = Properties.Resources.error;
                msj = "Ingrese datos (campo obligatorio)";
                lbl.Text = msj;

                return Tuple.Create(false, msj);



            }
            else if (txt.Text == null || txt.Text.Trim() == "" && Obligatorio == false)
            {
                img.Image = Properties.Resources.ok;
                msj = "Sin datos (campo no obligatorio)";
                lbl.Text = msj;
                lbl.ForeColor = Color.Green;

                return Tuple.Create(true, msj);
            }
            else if (maximo)
            {
                if (txt.Text.Length == num)
                {
                    img.Image = Properties.Resources.ok;
                    msj = "";
                    lbl.Text = msj;

                    return Tuple.Create(true, msj);

                }
                else
                {
                    img.Image = Properties.Resources.error;
                    msj = "Datos incompletos (campo obligatorio)";
                    lbl.Text = msj;

                    return Tuple.Create(false, msj);



                }
            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;

                return Tuple.Create(true, msj);
            }



        }

        private Tuple<Boolean, String> fnValidarCombobox(ComboBox cbo, Label lbl, PictureBox img)
        {
            String msj;
            Boolean estado = false;
            if (cbo.SelectedIndex == 0)
            {
                img.Image = Properties.Resources.error;
                msj = "Seleccione una opción";
                lbl.Text = msj;
                estado = false;
                return Tuple.Create(estado, msj);

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                estado = true;
                return Tuple.Create(estado, msj);
            }
        }

        private void cboClaseV_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = fnValidarCombobox(cboClaseV, lblCboClase, pbClase);
            estClase = result.Item1;
            msjClase = result.Item2;


            

            if (cboClaseV.SelectedIndex == 0)
            {                
                txtMarca.Enabled = false;
                chkEstadoMarca.Enabled = false;
               
            }
            else if(cboClaseV.SelectedIndex != 0 && txtMarca.Text.Trim()!="")
            {
                Int32 ValidaMarca = fnValidarMarcaExistente(txtMarca.Text.Trim(), txtMarca2.Text.Trim(), Convert.ToInt16(cboClaseV.SelectedValue), lnTipoCon);

                if (ValidaMarca == 1)
                {
                    var resultExistencia = fnValidaDatosDuplicados(txtMarca, lblCboMarca, pbMarca, true, true);
                    estMarca = resultExistencia.Item1;
                    msjMarca = resultExistencia.Item2;
                    MessageBox.Show("Esta marca ya existe verifique su clase ó ingrese otra Marca", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    var resultExistencia = fnValidaDatosDuplicados(txtMarca, lblCboMarca, pbMarca, true, false);
                    estMarca = resultExistencia.Item1;
                    msjMarca = resultExistencia.Item2;
                }
                txtMarca.Enabled = true;
                chkEstadoMarca.Enabled = true;
            }
            else
            {
                txtMarca.Enabled = true;
                chkEstadoMarca.Enabled = true;
            }
        }
    }
}
