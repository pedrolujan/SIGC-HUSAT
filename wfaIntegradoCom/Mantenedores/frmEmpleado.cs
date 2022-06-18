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

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmEmpleado : Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }

        static Int32 tabInicio;
        Int16 lnTipoCon = 0;

        private Boolean fnLLenarCargo()
        {
            BLCargo objCargo = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstProv = new List<Cargo>();

            try
            {

                lstProv = objCargo.blDevolverCargo("PETR0000");
                cboCargo.ValueMember = "cCodTab";
                cboCargo.DisplayMember = "cNomTab";
                cboCargo.DataSource = lstProv;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmEmpleado", "fnLLenarCargo", ex.Message);
                return false;
            }
            finally
            { lstProv = null; }
        }

        private Boolean fnLLnenarProvinciaxDepa(Int32 idDepa)
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            List<Provincia> lstProv = new List<Provincia>();

            try
            {

                lstProv = objUbigeo.blDevolverProvincia(idDepa);
                cboProvincia.DataSource = null;
                cboProvincia.ValueMember = "idProv";
                cboProvincia.DisplayMember = "cNomProv";
                cboProvincia.DataSource = lstProv;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmEmpleado", "fnLLnenarProvinciaxDepa", ex.Message);
                return false;
            }
            finally
            { lstProv = null; }
        }

        private Boolean fnLLnenarDistritoxProvincia(Int32 idProv)
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            List<Distrito> lstDist = new List<Distrito>();

            try
            {

                lstDist = objUbigeo.blDevolverDistrito(idProv);
                cboDistrito.DataSource = null;
                cboDistrito.ValueMember = "idDist";
                cboDistrito.DisplayMember = "cNomDist";
                cboDistrito.DataSource = lstDist;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmEmpleado", "fnLLnenarProvinciaxDepa", ex.Message);
                return false;
            }
            finally
            { lstDist = null; }
        }

        private Boolean fnLlenarDepartamento()
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            List<Departamento> lstDepart = new List<Departamento>();

            try
            {
                lstDepart = objUbigeo.blDevolverDepartamento(0);
                cboDepartamento.ValueMember = "idDepa";
                cboDepartamento.DisplayMember = "cNomDep";
                cboDepartamento.DataSource = lstDepart;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmEmpleado", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;

            bResult = fnLlenarDepartamento();
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Departamentos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = fnLLenarCargo();
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Cargos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            fnHabilitarControles(false);
        }
             
        private void fnHabilitarControles(Boolean pbHabilitar)
        {
            gbEmpleado.Enabled = pbHabilitar;
            gbUbigeo.Enabled = pbHabilitar;
            saveToolStripButton.Enabled = pbHabilitar;
           
        }

        private void fnLimpiarControles()
        {
            txtIdPersonal.Text = "0";
            txtApePat.Text = "";
            txtApeMat.Text = "";
            txtPrimerNom.Text = "";
            txtSegundoNom.Text = "";
            txtdni.Text = "";
            txtDireccion.Text = "";
            chkEstado.Checked = true;
            txtTelefono.Text = "";
            dateTimePicker1.Value = Variables.gdFechaSis;
            cboCargo.SelectedIndex = -1;
            cboDepartamento.SelectedIndex = -1;
            cboProvincia.SelectedIndex = -1;
            cboDistrito.SelectedIndex = -1;
            txtBuscarEmpleado.Text = "";
            gbPaginacion.Enabled = true;
            lvempleado.Visible = false;
            epUsuario.Clear();
            epControlOk.Clear();
            txtBuscarEmpleado.Focus();

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnHabilitarControles(true);

            fnLimpiarControles();
            gbPaginacion.Enabled = false;
        }

        private Boolean fnBuscarEmpleado(Int32 NumPagina, Int32 pnTipoCon)
        {
            BLPersonal objPers = new BLPersonal();
            
            DataTable datPersonal = new DataTable();
            Boolean pbhabilitaLista = false;

            String pcBuscar = txtBuscarEmpleado.Text;

            clsUtil objUtil = new clsUtil();
            List<Personal> lsPersonal = null;
            ListViewItem lstItem = null;
        
            Int32 filas = 10;
           
            
            try
            {

                lsPersonal = new List<Personal>();
                lsPersonal = objPers.blBuscarPersonal(NumPagina ,pcBuscar, pnTipoCon);
                lvempleado.Rows.Clear();
                Int32 totalResultados = lsPersonal.Count;
                if (lsPersonal.Count > 0)
                {

                    String estado = "";
                    Int32 y;
                    if (NumPagina == 0)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (NumPagina - 1) * filas;
                        y = tabInicio;
                    }
                    foreach (Personal objPersona in lsPersonal)
                    {
                        lvempleado.Rows.Add(objPersona.idPersonal.ToString(), objPersona.cPersonal, objPersona.cDocumento);

                        pbhabilitaLista = true;
                    }
                    if (NumPagina == 0)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(lsPersonal[0].TotalRows);
                        FunValidaciones.fnCalcularPaginacion(
                            totalRegistros,
                            filas,
                            totalResultados,
                            cboPaginacion,
                            btnTotalPaginas,
                            btnNumFilas,
                            btnTotalReg
                        );
                    }
                    
                    btnNumFilas.Text = Convert.ToString(lsPersonal.Count);

                    lvempleado.Visible = true;
                }
                return true;
            }

            

            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmEmpleado", "fnBuscarEmpleado", ex.Message);
                return false;
            }
            finally
            {
                lsPersonal = null;
                objPers = null;
                objUtil = null;
            }

        }

        private void txtBuscarEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {

                gbPaginacion.Enabled = true;
                gbEmpleado.Enabled = false;
                gbUbigeo.Enabled = false;
                fnBuscarEmpleado(0, 0);

            }
        }

        private Boolean fnListarPersonalEspecifico()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (lvempleado.Rows.Count > 0)
                {
                    BLPersonal objPers = new BLPersonal();
                    Personal[] lstPers = new Personal[1];

                    //ListView.SelectedListViewItemCollection item = lvempleado.SelectedItems;

                    Int32 idPersonal = Convert.ToInt32(lvempleado.CurrentRow.Cells[0].Value);
                    lstPers = objPers.blListarPersonal(idPersonal).ToArray();
                    txtIdPersonal.Text = Convert.ToString(lstPers[0].idPersonal);
                    txtApePat.Text = Convert.ToString(lstPers[0].cApePat);
                    txtApeMat.Text = Convert.ToString(lstPers[0].cApeMat);
                    txtPrimerNom.Text = Convert.ToString(lstPers[0].cPrimerNom);
                    txtSegundoNom.Text = Convert.ToString(lstPers[0].cSegundoNom);
                    txtdni.Text = Convert.ToString(lstPers[0].cDocumento);
                    txtDireccion.Text = Convert.ToString(lstPers[0].cDireccion);
                    txtTelefono.Text = Convert.ToString(lstPers[0].cTelefono);
                    cboCargo.Text = Convert.ToString(lstPers[0].cTipoCargo);
                    dateTimePicker1.Value = lstPers[0].dFecNac;
                    chkEstado.Checked = Convert.ToBoolean(lstPers[0].bEstado);
                    cboDepartamento.Text = Convert.ToString(lstPers[0].cNomDep.Trim());
                    cboProvincia.Text = Convert.ToString(lstPers[0].cNomProv.Trim());
                    cboDistrito.Text = Convert.ToString(lstPers[0].cNomDist.Trim());
                    lvempleado.Visible = false;
                    fnHabilitarControles(true);
                    gbPaginacion.Enabled = false;
                    btnTotalPaginas.Text = "";
                    btnNumFilas.Text = "";
                    btnTotalReg.Text = "";
                    cboPaginacion.Text = "";
                    txtBuscarEmpleado.Text = "";
                    lnTipoCon = 1;
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmEmpleado", "fnListarPersonalEspecifico", ex.Message);
                return false;
            }
        }

        private void lvempleado_DoubleClick(object sender, EventArgs e)
        {
            Boolean bResul = false;
            bResul = fnListarPersonalEspecifico();
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar Personal Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void lvempleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Boolean bResul = false;
                bResul = fnListarPersonalEspecifico();
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Personal Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.SelectedValue != null)
            {
                Boolean bResul = false;
                bResul = fnLLnenarProvinciaxDepa(Convert.ToInt32(cboDepartamento.SelectedValue));

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Provincias por Departamento", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedValue != null)
            {
                Boolean bResul = false;
                bResul = fnLLnenarDistritoxProvincia(Convert.ToInt32(cboProvincia.SelectedValue));

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Provincias por Departamento", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private String fnGuardarPersonal(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLPersonal blobjPersonal = new BLPersonal();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Personal objPersonal = new Personal();
            try
            {
                objPersonal.idPersonal = Convert.ToInt32(txtIdPersonal.Text.Trim());
                objPersonal.cApePat = Convert.ToString(txtApePat.Text.Trim());
                objPersonal.cApeMat = Convert.ToString(txtApeMat.Text.Trim());
                objPersonal.cPrimerNom = Convert.ToString(txtPrimerNom.Text.Trim());
                objPersonal.cSegundoNom = Convert.ToString(txtSegundoNom.Text.Trim());
                objPersonal.cDocumento = Convert.ToString(txtdni.Text.Trim());
                objPersonal.cDireccion = Convert.ToString(txtDireccion.Text.Trim());
                objPersonal.cTelefono = Convert.ToString(txtTelefono.Text.Trim());
                objPersonal.dFecNac = Convert.ToDateTime(dateTimePicker1.Value);
                objPersonal.cTipoCargo = cboCargo.SelectedValue.ToString().Trim();
                objPersonal.bEstado = Convert.ToBoolean(chkEstado.Checked);
                objPersonal.dFechaRegistro = dFechaSis;
                objPersonal.idUsuarioReg = Variables.gnCodUser;
                objPersonal.idZona = Convert.ToInt32(cboDistrito.SelectedValue);

                lcValidar = blobjPersonal.blGrabarPersonal(objPersonal, idTipoCon).Trim();
                fnLimpiarControles();
                fnHabilitarControles(false);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmEmpleado", "fnGuardarPersonal", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            String lcResultado = "";

            epControlOk.Clear();
            epUsuario.Clear();

            if (txtApePat.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtApePat, "");
                epUsuario.SetError(txtApePat, "Ingresar Apellido Paterno");
            }
            else
            {
                epUsuario.SetError(txtApePat, "");
                epControlOk.SetError(txtApePat, "Ingreso Correcto de Apellido Paterno");
            }
            if (txtApeMat.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtApeMat, "");
                epUsuario.SetError(txtApeMat, "Ingresar Apellido Materno");
            }
            else
            {
                epUsuario.SetError(txtApeMat, "");
                epControlOk.SetError(txtApeMat, "Ingreso Correcto de Apellido Materno");
            }

            if (txtdni.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtdni, "");
                epUsuario.SetError(txtdni, "Ingresar DNI");
            }
            else
            {
                epUsuario.SetError(txtdni, "");
                epControlOk.SetError(txtdni, "Ingreso Correcto de DNI");
            }

            if (cboDepartamento.SelectedValue == null)
            {
                epControlOk.SetError(cboDepartamento, "");
                epUsuario.SetError(cboDepartamento, "Elegir Departamento");
            }
            else
            {
                epUsuario.SetError(cboDepartamento, "");
                epControlOk.SetError(cboDepartamento, "Eligio Departamento Correcto");
            }
            if (cboProvincia.SelectedValue == null)
            {
                epControlOk.SetError(cboProvincia, "");
                epUsuario.SetError(cboProvincia, "Elegir Provincia");
            }
            else
            {
                epUsuario.SetError(cboProvincia, "");
                epControlOk.SetError(cboProvincia, "Eligio Provincia Correcta");
            }
            if (cboDistrito.SelectedValue == null)
            {
                epControlOk.SetError(cboDistrito, "");
                epUsuario.SetError(cboDistrito, "Elegir Distrito");
            }
            else
            {
                epUsuario.SetError(cboDistrito, "");
                epControlOk.SetError(cboDistrito, "Eligio Distrito Correcto");
            }

            if (cboCargo.SelectedValue == null)
            {
                epControlOk.SetError(cboCargo, "");
                epUsuario.SetError(cboCargo, "Elegir Cargo");
            }
            else
            {
                epUsuario.SetError(cboCargo, "");
                epControlOk.SetError(cboCargo, "Eligio Cargo Correcto");
            }


            if (txtApePat.Text.Trim().Length > 0 && txtApeMat.Text.Trim().Length > 0 && txtdni.Text.Trim().Length > 0 && cboDepartamento.SelectedValue != null && cboProvincia.SelectedValue != null && cboDistrito.SelectedValue != null && cboCargo.SelectedValue != null)
            {
                lcResultado = fnGuardarPersonal(lnTipoCon);
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente Personal Trabajador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Grabar Personal Trabajador. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        private void siticoneTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lvempleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboPaginacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResul = false;
            bResul = fnBuscarEmpleado(Convert.ToInt32(cboPaginacion.Text), 0);
            
        }

        private void gunaLabel10_Click(object sender, EventArgs e)
        {

        }

        private void siticoneLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBuscarEmpleado_Click(object sender, EventArgs e)
        {

        }
    }
}



		