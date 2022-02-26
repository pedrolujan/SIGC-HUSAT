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
using Guna.UI.WinForms;
using Siticone.UI.WinForms;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmRegistrarTipoPlan : Form
    {
        public frmRegistrarTipoPlan()
        {
            InitializeComponent();
           
            fnHabilitarGroupBoxs(false);
            cboBuscar.SelectedIndex = 0;
            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            FunValidaciones.fnColorBotones(btnNuevo,btnEditar,btnGuardar,btnSalir);
            fnLimpiarControles();
        }

        Int16 lnTipoCon = 0;
        Int32 lnTipoLlamada = 0;
        Boolean estActualizar;

        Boolean estNombre, estMeses, estDescripcion;
        String msjNombre, msjMeses, msjDescripcion;

        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();
        }

        private Boolean fnBuscarTipoPlan(String pcBuscar, Int16 pnTipoCon)
        {
            BLTipoPlan objTPlan = new BLTipoPlan();
            Boolean pbhabilitaLista = false;


            clsUtil objUtil = new clsUtil();
            List<TipoPlan> lstTipoPlan = null;
            ListViewItem lstItem = null;
            try
            {

                lstTipoPlan = new List<TipoPlan>();
                lstTipoPlan = objTPlan.blBuscarTipoPlan(pcBuscar, pnTipoCon);
                //lvTipoPlan.Items.Clear();
                foreach (TipoPlan objTipoPlan in lstTipoPlan)
                {
                    //lstItem = lvTipoPlan.Items.Add(objTipoPlan.idTipoPlan.ToString());
                    lstItem.SubItems.Add(objTipoPlan.nombreTipoPlan);


                    pbhabilitaLista = true;
                }

                //lvTipoPlan.Visible = pbhabilitaLista;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnBuscarCliente", ex.Message);
                return false;
            }
            finally
            {
                lstTipoPlan = null;
                objTPlan = null;
                objUtil = null;
            }

        }
        
        private Tuple<Boolean, String> fnValidarTexboxSQL(SiticoneTextBox txt, Label lbl, PictureBox img, Boolean maximo, Int32 num)
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

            }
            else if (estActualizar)
            {

                if (txtActualizar.Text.Trim() == txt.Text.Trim())
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
                    bResul = fnBuscarNombreTipoPlan(txt.Text.Trim(), pnTipocon);
                    return Tuple.Create(bResul, msj);

                }

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                bResul = fnBuscarNombreTipoPlan(txt.Text.Trim(), pnTipocon);
                return Tuple.Create(bResul, msj);

            }


        }
       
        private Boolean fnBuscarNombreTipoPlan(String pcBuscar, Int16 pnTipoCon)
        {
            BLTipoPlan objTiPlan = new BLTipoPlan();
            clsUtil objUtil = new clsUtil();
            Int16 numResult = 0;

            try
            {

                numResult = objTiPlan.blBuscarNombreTipoPlan(pcBuscar, pnTipoCon);

                if (numResult == 1)
                {
                    erNombre.Text = "Este nombre ya existe (Ingrese otro nombre)";
                    erNombre.ForeColor = Color.Red;
                    imgNombre.Image = Properties.Resources.error;
                    return false;
                }
                else if (numResult == 0)
                {
                    erNombre.Text = "";
                    imgNombre.Image = Properties.Resources.ok;
                    return true;
                }
                else
                {
                    erNombre.Text = "Ocurrió otro error";
                    erNombre.ForeColor = Color.Red;
                    imgNombre.Image = Properties.Resources.error;
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorio", "fnBuscarAccesorio", ex.Message);
                return false;
            }
            finally
            {

                objTiPlan = null;
                objUtil = null;
            }
        }

        
        private String fnGuardarTipoPlan(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLTipoPlan blTipoPlan = new BLTipoPlan();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            TipoPlan objTipoPlan = new TipoPlan();
            try
            {
                objTipoPlan.idTipoPlan = Convert.ToInt32(txtCodigo.Text.Trim());
                objTipoPlan.nombreTipoPlan = Convert.ToString(txtNombre.Text.Trim());
                objTipoPlan.cMeses = Convert.ToInt32(txtMeses.Text.Trim());
                objTipoPlan.cDescripcion = Convert.ToString(txtDescripcion.Text.Trim());
                objTipoPlan.dFechaRegistro = dFechaSis;
                objTipoPlan.idUsuario = Variables.gnCodUser;
                objTipoPlan.bEstado = Convert.ToBoolean(chkEstado.Checked);

                lcValidar = blTipoPlan.blGrabarTipoPlan(objTipoPlan, idTipoCon).Trim();
                fnLimpiarControles();
                
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarTipoPlan", "fnGuardarTipoPlan", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }
        private void fnVerValidacion(Boolean estado)
        {
            /////TEXBOXS/////
            erNombre.Visible = estado;
            erMeses.Visible = estado;
            erDescripcion.Visible = estado;
            /////PICTUREBOXS////
            imgNombre.Visible = estado;
            imgMeses.Visible = estado;
            imgDescripcion.Visible = estado;

        }
        private void fnHabilitarGroupBoxs(Boolean pbAccesorio)
        {
            gbFormTipoPlan.Enabled = pbAccesorio;
        }

        private void fnLimpiarControles()
        {

           
            
            
            /////TEXBOXS/////
            txtCodigo.Text = "0";
            txtNombre.Text = "";
            txtMeses.Text = "";
            txtDescripcion.Text = "";
            txtBuscar.Text = "";


            ////LABELS////
            erNombre.Text = "";
            erMeses.Text = "";
            erDescripcion.Text = "";
            erNumResultados.Text = "";

            ////PICTUREBOXS////
            imgNombre.Image = null;
            imgMeses.Image = null;
            imgDescripcion.Image = null;

           ////CHEKSBOXS/////
            chkEstado.Checked = true;

            ////LISTBOXS/////
            dgTipoPlan.Visible = false;

            txtBuscar.Focus();

        }


        private void txtMeses_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtMeses, erMeses, imgMeses, true, false, true, 1, 12, 0,2, "Ingrese un mes correcto");
            estMeses = result.Item1;
            msjMeses = result.Item2;
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtDescripcion, erDescripcion, imgDescripcion, false, true, true, 0, 0, 3,200, "Datos Imcompletos");

            estDescripcion = result.Item1;
            msjDescripcion = result.Item2;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true,erNombre);
            
        }

        private void txtMeses_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", false,erMeses);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);
            e.KeyChar = char.ToUpper(e.KeyChar);

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

            
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon = 0;

                if (cboBuscar.SelectedIndex == 1)
                {
                    pnTipocon = 1;
                }
                else if (cboBuscar.SelectedIndex == 2)
                {
                    pnTipocon = 2;
                }
                else
                {
                    pnTipocon = 0;
                }

                fnBuscarTabla(txtBuscar.Text.Trim(), pnTipocon);
            }
           
        }

        private Boolean fnBuscarTabla(String pcBuscar, Int16 pnTipoCon)
        {
            BLTipoPlan objTipPlan = new BLTipoPlan();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();
            List<TipoPlan> lstTipoPlan = null;
            try
            {
                lstTipoPlan = new List<TipoPlan>();
                datTipoPlan = objTipPlan.blBuscarTipoPlanDataTable(pcBuscar, pnTipoCon);

                if (datTipoPlan.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("NOMBRE");
                    dt.Columns.Add("NR MESES");
                    dt.Columns.Add("ESTADO");

                    String estado = "";
                    for (int i = 0; i <= datTipoPlan.Rows.Count - 1; i++)
                    {
                        if (Convert.ToBoolean(datTipoPlan.Rows[i][3]) == true)
                        {
                            estado = "ACTIVO";
                        }
                        else
                        {
                            estado = "INACTIVO";
                        }
                        object[] row = { datTipoPlan.Rows[i][0], datTipoPlan.Rows[i][1], datTipoPlan.Rows[i][2], estado };
                        dt.Rows.Add(row);

                    }
                    erNumResultados.Text = "Nr. de Resultados (" + datTipoPlan.Rows.Count + ")";
                    erNumResultados.ForeColor = Variables.ColorSuccess;
                    dgTipoPlan.DataSource = dt;
                    dgTipoPlan.Visible = true;
                    return true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dgTipoPlan.DataSource = dt;
                    dgTipoPlan.Visible = false;
                    erNumResultados.Text = "Nr. de Resultados (" + datTipoPlan.Rows.Count + ")";
                    erNumResultados.ForeColor = Variables.ColorError;
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnHabilitarGroupBoxs(true);
            fnVerValidacion(true);
            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, true);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);

        }

        private void dgTipoPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            estActualizar = true;
            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                bResul = fnListarTipoPlanEspecifico(e);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Equipo Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //this.Close();
                }
            }
            else if (lnTipoLlamada == 1)
            {
                Boolean bResul = false;
                //bResul = fnRecuperarAccesorioEsp();
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar Equipo Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.Dispose();
                }
            }
        }

        private Boolean fnListarTipoPlanEspecifico(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                if (dgTipoPlan.Rows.Count > 0)
                {
                    BLTipoPlan objTipPlan = new BLTipoPlan();
                    TipoPlan lstTipoPlan = new TipoPlan();
                    DataTable dtEquipo = new DataTable();

                   
                    lstTipoPlan = objTipPlan.blListarTipoPlanDataGrid(Convert.ToInt32(dgTipoPlan.Rows[e.RowIndex].Cells[0].Value));

                    if (lstTipoPlan.idTipoPlan > 0)
                    {
                        txtActualizar.Text = Convert.ToString(lstTipoPlan.nombreTipoPlan.ToString().Trim());
                        txtCodigo.Text = Convert.ToString(lstTipoPlan.idTipoPlan.ToString().Trim());
                        txtNombre.Text = Convert.ToString(lstTipoPlan.nombreTipoPlan.ToString().Trim());
                        txtMeses.Text = Convert.ToString(lstTipoPlan.cMeses.ToString());
                        txtDescripcion.Text = Convert.ToString(lstTipoPlan.cDescripcion.ToString().Trim());
              
                        chkEstado.Checked = lstTipoPlan.bEstado;
                       
                        dgTipoPlan.Visible = false;
                        fnHabilitarGroupBoxs(false);
                        fnVerValidacion(false);

                        FunValidaciones.fnHabilitarBoton(btnNuevo, true);
                        FunValidaciones.fnHabilitarBoton(btnEditar, true);
                        FunValidaciones.fnHabilitarBoton(btnGuardar, false);
                        FunValidaciones.fnHabilitarBoton(btnSalir, true);
                        txtBuscar.Text = "";
                        lnTipoCon = 1;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            fnHabilitarGroupBoxs(true);
            fnVerValidacion(true);

            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, true);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnHabilitarGroupBoxs(false);

            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            Int16 pnTipocon;
            if (cboBuscar.SelectedIndex == 1)
            {
                pnTipocon = 1;
            }
            else if (cboBuscar.SelectedIndex == 2)
            {
                pnTipocon = 2;
            }
            else
            {
                pnTipocon = 0;
            }

            fnBuscarTabla(txtBuscar.Text.Trim(), pnTipocon);
        }

        private void rdbNombre_CheckedChanged(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnHabilitarGroupBoxs(false);

            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);

        }

        private void rdbMeses_CheckedChanged(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnHabilitarGroupBoxs(false);

            //FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            //FunValidaciones.fnHabilitarBoton(btnEditar, false);
            //FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            //FunValidaciones.fnHabilitarBoton(btnSalir, true);
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String lcResultado;

            txtNombre_TextChanged(sender,e);
            txtMeses_TextChanged(sender,e);
            txtDescripcion_TextChanged(sender,e);
            if (estNombre && estMeses && estDescripcion)
            {
                lcResultado = fnGuardarTipoPlan(lnTipoCon);
                if (lcResultado == "OK")
                {

                    MessageBox.Show("Se Guardó Satisfactoriamente Tipo Plan", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //if (lnTipoLlamada == 2)
                    //{
                    //    frmDocumentoVenta.fnRecuperarCliente(lcCliente, lcDireccion, lcTipoDoc, lcDoc);
                    //    this.Dispose();
                    //}


                    //FunValidaciones.fnHabilitarBoton(btnNuevo, true);
                    //FunValidaciones.fnHabilitarBoton(btnEditar, false);
                    //FunValidaciones.fnHabilitarBoton(btnGuardar, false);
                    //FunValidaciones.fnHabilitarBoton(btnSalir, true);
                    
                }
                else
                {
                    MessageBox.Show("Error en Tipo Plan. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                
            }
            else
            {
                MessageBox.Show("Complete correctamente los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexboxSQL(txtNombre, erNombre, imgNombre, false, 0);
            estNombre = result.Item1;
            msjDescripcion = result.Item2;

            txtNombre.MaxLength = 45;

        }
    }
}
