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
    public partial class frmRegistrarModeloVehiculo : Form
    {
        
        public frmRegistrarModeloVehiculo()
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
       
       
        private String fnGuardarModelo(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLAttrVehiculo objAttrV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            ModeloVehiculo objModelo = new ModeloVehiculo();
            //Boolean bCargar = false;
            try
            {
                objModelo.idModelo = Convert.ToInt32(txtCodModelo.Text);
                objModelo.cNomModelo = Convert.ToString(txtModelo.Text.Trim());
                objModelo.bEstado = Convert.ToBoolean(chkEstadoModelo.Checked);
                objModelo.idMarca = Convert.ToInt32(cboMarcaVh.SelectedValue);
                objModelo.dFechaReg = dFechaSis;
                objModelo.idUsuario = Variables.gnCodUser; 

                lcValidar = objAttrV.blGrabarModelo(objModelo, idTipoCon).Trim();
                fnLimpiarControles();
                fnHabilitarControles(false);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarAttrVehiculo", "fnGuardarModelo", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }
        private void fnHabilitarControles(Boolean pbHabilitar)
        {
            gbModelo.Enabled = pbHabilitar;
            gbClase_Marca.Enabled = pbHabilitar;
            saveToolStripButtonMod.Enabled = pbHabilitar;            
        }

        private void fnLimpiarControles()
        {
            
                txtCodModelo.Text = "0";
                txtModelo.Text = "";
                chkEstadoModelo.Checked = true;
                epVehiculo.Clear();
                epControlOk.Clear();
                lvModelo.Visible = false;
                txtBuscarModelo.Text = "";
                txtBuscarModelo.Focus();
            cboClaseV.SelectedIndex = 0;
            
            
        }

        private void saveToolStripButtonMod_Click(object sender, EventArgs e)
        {
            String lcResultado = "";
           
            if (estClase == false)
            {
                var Clase = fnValidarCombobox(cboClaseV, lblCboClase, pbClase);
                msjClase = Clase.Item2;
            }

            
            if (estMarca == false)
            {
                var Marca = fnValidarCombobox(cboMarcaVh, lblCboMarca, pbMarca);
                msjMarca = Marca.Item2;
            }

            
            if(estModelo ==false)
            {
                var Modelo = fnValidarTexbox(txtModelo, lblCboModelo, pbModelo, false, 0, true);
                msjModelo = Modelo.Item2;
            }


            
            if (estClase == true && estMarca == true && estModelo== true)
            {
               
                lcResultado = fnGuardarModelo(lnTipoCon);
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente Modelo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Grabar Modelo. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else 
            {
                if (txtModelo.Text.Length > 0)
                {
                    Int32 ValidaModelo = fnValidarModeloExistente(txtModelo.Text.Trim(), txtModelo2.Text.Trim(), Convert.ToInt16(cboClaseV.SelectedValue), Convert.ToInt16(cboMarcaVh.SelectedValue), lnTipoCon);
                    if (ValidaModelo == 1)
                    {
                        var resultExistencia = fnValidaDatosDuplicados(txtModelo, lblCboModelo, pbModelo, true, true);
                        estModelo = resultExistencia.Item1;
                        msjModelo = resultExistencia.Item2;

                        MessageBox.Show("Este modelo ya existe", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                else
                {
                    MessageBox.Show("Complete todos los campos Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
        }

        private void txtBuscarModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon = 0;

                if (rbCodModelo.Checked == true)
                {
                    pnTipocon = 0;
                }else
                {
                    pnTipocon = 1;
                }

                fnBuscarModeloV(txtBuscarModelo.Text.Trim(), pnTipocon);
            }
        }

        private Boolean fnBuscarModeloV(String pcBuscar, Int16 pnTipoCon)
        {
            BLAttrVehiculo objAttrV = new BLAttrVehiculo();
            Boolean pbhabilitaLista = false;

            clsUtil objUtil = new clsUtil();
            List<ModeloVehiculo> lstModeloV = null;
            ListViewItem lstItem = null;
            try
            {
                lstModeloV = new List<ModeloVehiculo>();
                lstModeloV = objAttrV.blBuscarModeloV(pcBuscar, pnTipoCon);
                if (lstModeloV.Count == 0)
                {
                    blResulBusqueda.Text = "No se encontraron datos para la busqueda  ( " + lstModeloV.Count + " )";
                    blResulBusqueda.ForeColor = Color.Red;
                }
                else
                {
                    blResulBusqueda.Text = "Resultados de tu busqueda   ( " + lstModeloV.Count + " )";
                    blResulBusqueda.ForeColor = Color.Green;
                }
                lvModelo.Items.Clear();
                foreach (ModeloVehiculo objModelo in lstModeloV)
                {
                    lstItem = lvModelo.Items.Add(objModelo.idModelo.ToString());
                    lstItem.SubItems.Add(objModelo.cNomModelo);
                    lstItem.SubItems.Add(objModelo.cNomClase);
                    lstItem.SubItems.Add(objModelo.cNomMarca);
                    if (objModelo.bEstado==true)
                    {
                        lstItem.SubItems.Add("Activo");
                    }
                    else
                    {
                        lstItem.SubItems.Add("Inactivo");
                    }
                    pbhabilitaLista = true;
                }

                lvModelo.Visible = pbhabilitaLista;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAttrVehiculo", "fnBuscarModeloV", ex.Message);
                return false;
            }

        }

        private void cboMarcaVh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClaseV.SelectedIndex!=0)
            {
                var result = fnValidarCombobox(cboMarcaVh, lblCboMarca, pbMarca);
                estMarca = result.Item1;
                msjMarca = result.Item2;
            }
            if (cboMarcaVh.SelectedIndex==0)
            {
                txtModelo.Enabled = false;
                chkEstadoModelo.Enabled = false;
            }
            else if (cboMarcaVh.SelectedIndex!=0 && txtModelo.Text.Trim()!="")
            {
                Int32 ValidaModelo = fnValidarModeloExistente(txtModelo.Text.Trim(), txtModelo2.Text.Trim(), Convert.ToInt16(cboClaseV.SelectedValue), Convert.ToInt16(cboMarcaVh.SelectedValue), lnTipoCon);

                if (ValidaModelo == 1)
                {
                    var resultExistencia = fnValidaDatosDuplicados(txtModelo, lblCboModelo, pbModelo, true, true);
                    estModelo = resultExistencia.Item1;
                    msjModelo = resultExistencia.Item2;

                    MessageBox.Show("Este modelo ya existe", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    var resultExistencia = fnValidaDatosDuplicados(txtModelo, lblCboModelo, pbModelo, true, false);
                    estModelo = resultExistencia.Item1;
                    msjModelo = resultExistencia.Item2;
                }
            }
            if (cboMarcaVh.SelectedIndex!=0) 
            {                    
               txtModelo.Enabled = true;
               chkEstadoModelo.Enabled = true;
             }
        }

        private void gbProv_Enter(object sender, EventArgs e)
        {

        }

        private void txtModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsSymbol(e.KeyChar)))
            {
                e.Handled = true;
            }
            e.KeyChar = char.ToUpper(e.KeyChar);
           

        }


        private Boolean fnListarModeloEspecifico()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (lvModelo.Items.Count > 0)
                {
                    BLAttrVehiculo objModelo = new BLAttrVehiculo();
                    ModeloVehiculo[] lstModelo = new ModeloVehiculo[1];

                    ListView.SelectedListViewItemCollection item = lvModelo.SelectedItems;
                    if (item.Count > 0)
                    {
                        lstModelo = objModelo.blListarModelo(Convert.ToInt32(item[0].SubItems[0].Text)).ToArray();

                        if (lstModelo.GetLength(0) > 0)
                        {
                            txtCodModelo.Text = Convert.ToString(lstModelo[0].idModelo);
                            txtModelo2.Text = Convert.ToString(lstModelo[0].cNomModelo);
                            txtModelo.Text = Convert.ToString(lstModelo[0].cNomModelo);
                            chkEstadoModelo.Checked = lstModelo[0].bEstado;
                            cboClaseV.SelectedValue = lstModelo[0].idClase;
                            cboMarcaVh.SelectedValue = lstModelo[0].idMarca;
                            lvModelo.Visible = false;
                            fnHabilitarControles(true);
                            txtBuscarModelo.Text = "";
                            lnTipoCon = 1;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnListarMarcaEspecifica", ex.Message);
                return false;
            }
        }

        private void lvModelo_DoubleClick_1(object sender, EventArgs e)
        {
            Boolean bResul = false;
            bResul = fnListarModeloEspecifico();
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar Modelo Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void txtCodModelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmRegistrarModeloVehiculo_Click(object sender, EventArgs e)
        {
            if (lvModelo.Visible==true)
            {
                lvModelo.Visible = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmRegistrarAttrVehiculo_Load(object sender, EventArgs e)
        {
            
            Boolean bResult = false;
            bResult = fnLLenarClaseVehiculo();
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Clase Vehiculo", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }


            fnHabilitarControles(false);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnHabilitarControles(true);
            fnLimpiarControles();
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {

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
                pbClase.Image = null;
                lblCboClase.Text = "";
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

        private Boolean fnLLenarMarcaxClase(Int32 idClase)
        {

            BLAttrVehiculo objMarcaV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            List<MarcaVehiculo> lstMarcaV = new List<MarcaVehiculo>();

            try
            {

                lstMarcaV = objMarcaV.blDevolverMarcaV(idClase);
                cboMarcaVh.DataSource = null;
                cboMarcaVh.ValueMember = "idMarca";
                cboMarcaVh.DisplayMember = "cNomMarca";
                cboMarcaVh.DataSource = lstMarcaV;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLLnenarProvinciaxDepa", ex.Message);
                return false;
            }
            finally
            {
                lstMarcaV = null;
            }
        }

        private void cboClaseV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClaseV.SelectedIndex==0)
            {
                cboMarcaVh.Enabled = false;
                txtModelo.Enabled = false;
                chkEstadoModelo.Enabled = false;
                var result = fnValidarCombobox(cboClaseV, lblCboClase, pbClase);
                estClase = result.Item1;
                msjClase = result.Item2;
            }
            else
            {
                var result = fnValidarCombobox(cboClaseV, lblCboClase, pbClase);
                estClase = result.Item1;
                msjClase = result.Item2;

                cboMarcaVh.Enabled = true;
                
            }
            if (cboClaseV.SelectedValue != null)
            {
                Boolean bResul = false;
                bResul = fnLLenarMarcaxClase(Convert.ToInt32(cboClaseV.SelectedValue));

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Marcas por Clase", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                msj = "Este modelo ya existe ( Verifique Clase Ó Marca )\n de lo contario ingrese otro Modelo";

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

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {
            if (cboClaseV.SelectedIndex != 0 && cboMarcaVh.SelectedIndex!=0)
            {
                var result = fnValidarTexbox(txtModelo, lblCboModelo, pbModelo, false, 0, true);
                estModelo = result.Item1;
                msjModelo = result.Item2;

                Int32 ValidaModelo = fnValidarModeloExistente(txtModelo.Text.Trim(), txtModelo2.Text.Trim(), Convert.ToInt16(cboClaseV.SelectedValue), Convert.ToInt16(cboMarcaVh.SelectedValue), lnTipoCon);

                if (ValidaModelo == 1)
                {
                    var resultExistencia = fnValidaDatosDuplicados(txtModelo, lblCboModelo, pbModelo, true, true);
                    estModelo = resultExistencia.Item1;
                    msjModelo = resultExistencia.Item2;

                    MessageBox.Show("Este modelo ya existe", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private Int32 fnValidarModeloExistente(String txtModelo, String txtModelo2, Int16 idClase,Int16 idMarca, Int16 pnTipoCon)
        {

            BLAttrVehiculo objModeloV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            Int32 validarModelo = 0;

            try
            {
                validarModelo = objModeloV.blDevolverValidarModeloExistente(txtModelo, txtModelo2, idClase, idMarca, pnTipoCon);

                return validarModelo;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLLnenarProvinciaxDepa", ex.Message);
                return validarModelo;
            }
            finally
            {
            }
        }
    }
}
