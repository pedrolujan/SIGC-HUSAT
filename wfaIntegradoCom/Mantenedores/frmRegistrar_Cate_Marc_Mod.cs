using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Siticone.UI.WinForms;
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
    public partial class frmRegistrar_Cate_Marc_Mod : Form
    {
        public frmRegistrar_Cate_Marc_Mod()
        {
            InitializeComponent();
            FunValidaciones.fnColorBotones(btnNuevoCategoria, btnEditarCategoria, btnGuardarCategoria, btnSalirCategoria);
            FunValidaciones.fnColorBotones(btnNuevoMarca, btnEditarMarca, btnGuardarMarca, btnSalirMarca);
            FunValidaciones.fnColorBotones(btnNuevoModelo, btnEditarModelo, btnGuardarModelo, btnSalirModelo);
            cboEstadoCategoria.SelectedIndex = 0;
            fnLimpiarControles(1);
            fnHabilitarGroupBox(gbCategoriaEquipo, false);
            fnVerValidacion(true, 1);
            FunValidaciones.fnHabilitarBoton(btnNuevoCategoria, true);
            FunValidaciones.fnHabilitarBoton(btnEditarCategoria, false);
            FunValidaciones.fnHabilitarBoton(btnGuardarCategoria, true);
            FunValidaciones.fnHabilitarBoton(btnSalirCategoria, true);
        }
        Int16 lnTipoCon = 0;
        Int16 lnTipoLlamada = 0;
        Boolean estActualizarCategoria, estActualizarMarca, estActualizarModelo;
        Boolean estNombreCategoria, estObservacionCategoria;
        Boolean estCategoria_Marca, estNombreMarca, estObservacionMarca;
        Boolean estCategoria_Modelo, estMarca_Modelo, estNombre_Modelo, estObservaciones_Modelo;
        String msjNombreCategoria, msjObservacionCategoria;
        String msjCategoria_Marca, msjNombreMarca, msjObservacionMarca;
        String msjCategoria_Modelo, msjMarca_Modelo, msjNombre_Modelo, msjObservaciones_Modelo;

        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private String fnGuardarCategoria(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLCate_Mar_Mod objCate_Marc_Mod = new BLCate_Mar_Mod();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            CategoriaEquipo objCategoria = new CategoriaEquipo();
            //Boolean bCargar = false;

            try
            {
                objCategoria.idCategoria = Convert.ToInt32(txtCodCategoria.Text);
                objCategoria.cNomCategoria = Convert.ToString(txtCategoria.Text.Trim());
                objCategoria.cDescripCategoria = Convert.ToString(txtObservacionCategoria.Text.Trim());
                objCategoria.bEstado = Convert.ToBoolean(chkEstadoCategoria.Checked);
                objCategoria.dFechaReg = dFechaSis;
                objCategoria.idUsuario = Variables.gnCodUser;

                lcValidar = objCate_Marc_Mod.blGrabarCategoria(objCategoria, idTipoCon).Trim();
                fnLimpiarControles(1);
                fnHabilitarGroupBoxs(false, 1);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarAttrVehiculo", "fnGuardarMarca", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }
        private void fnHabilitarGroupBoxs(Boolean pbHabilitar, Int16 pnTipoTab)
        {
            if (pnTipoTab == 1)
            {
                gbCategoriaEquipo.Enabled = pbHabilitar;
                btnGuardarCategoria.Enabled = pbHabilitar;
            }
            else if (pnTipoTab == 2)
            {
                gbMarcaEquipo.Enabled = pbHabilitar;
                btnGuardarMarca.Enabled = pbHabilitar;

            }
            else if (pnTipoTab == 3)
            {
                gbModeloEquipo.Enabled = pbHabilitar;
                btnGuardarModelo.Enabled = pbHabilitar;

            }

        }
        private void fnLimpiarControles(Int16 pnTipoTab)
        {
            if (pnTipoTab == 1)
            {
                ////TEXTBOXS/////
                
                txtCodCategoria.Text = "0";
                txtCategoria.Text = "";
                txtObservacionCategoria.Text = "";
                txtBuscarCategoria.Text = "";
                ////LABELS//////
                erNumResultados.Text = "";
                erNombreCategoria.Text = "";
                erObservacionCategoria.Text = "";
                /////PICTUREBOX////
                
                imgNombreCategoria.Image = null;
                imgObservacionCategoria.Image = null;

                /////CHEKBOXS/////

                chkEstadoCategoria.Checked = true;

                /////DATAGRID/////
                
                dgCategoria.Visible = false;
                estActualizarMarca = false;
                txtBuscarCategoria.Focus();
                lnTipoCon = 0;
            }
            else if (pnTipoTab == 2)
            {
                ////COMBOBOX////
                cboCategoria_Marca.SelectedIndex = 0;

                ////TEXTBOXS/////

                txtCodMarca.Text = "0";
                txtMarca.Text = "";
                txtObservacionMarca.Text = "";
                txtBuscarMarca.Text = "";
                txtActualizarMarca.Text = "";

                ////LABELS//////
                erCategoria_Marca.Text = "";
                erNombreMarca.Text = "";
                erObservacionMarca.Text = "";
                numResultadosMarca.Text = "";

                /////PICTUREBOX////

                imgNombreMarca.Image = null;
                imgCategoria_Marca.Image = null;
                imgObservacionMarca.Image = null;

                /////CHEKBOXS/////

                chkEstadoMarca.Checked = true;

                /////DATAGRID/////
                dgMarca.Visible = false;

                txtBuscarMarca.Focus();
                lnTipoCon = 0;
            }
            else if (pnTipoTab == 3)
            {

                /////COMBOBOXS////
                cboCategoria_Modelo.SelectedIndex = 0;
                
                ////TEXTBOXS/////

                txtCodModelo.Text = "0";
                txtModelo.Text = "";
                txtObservacionModelo.Text = "";
                txtBuscarModelo.Text = "";
                txtActualizarModelo.Text = "";

                ////LABELS//////
                erCboCategoria_Modelo.Text = "";
                erCboMarca_Modelo.Text = "";
                erNombre_Modelo.Text = "";
                erObservacion_Modelo.Text = "";
                NumResultados_Modelo.Text = "";

                /////PICTUREBOX////

                imgCategoria_Modelo.Image = null;
                imgMarca_Modelo.Image = null;
                imgNombre_Modelo.Image = null;
                imgObservacion_Modelo.Image = null;
                /////CHEKBOXS/////

                chkEstadoModelo.Checked = true;

                /////DATAGRID/////
                dgModelo.Visible = false;

                txtBuscarModelo.Focus();
                lnTipoCon = 0;
            }
        }
        private String fnGuardarMarca(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLCate_Mar_Mod objCate_Marc_Mod = new BLCate_Mar_Mod();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            MarcaEquipo objmarca = new MarcaEquipo();
            //Boolean bCargar = false;

            try
            {
                objmarca.idMarca = Convert.ToInt32(txtCodMarca.Text);
                objmarca.cNomMarca = Convert.ToString(txtMarca.Text.Trim());
                objmarca.bEstado = Convert.ToBoolean(chkEstadoMarca.Checked);
                objmarca.dFechaReg = dFechaSis;
                objmarca.idUsuario = Variables.gnCodUser;
                objmarca.idCategoria = Convert.ToInt32(cboCategoria_Marca.SelectedValue);
                objmarca.cDescripMarca = Convert.ToString(txtObservacionMarca.Text.Trim());

                lcValidar = objCate_Marc_Mod.blGrabarMarca(objmarca, idTipoCon).Trim();
                fnLimpiarControles(2);
                fnHabilitarGroupBoxs(false, 2);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarAttrVehiculo", "fnGuardarMarca", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private String fnGuardarModelo(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLCate_Mar_Mod objCate_Marc_Mod = new BLCate_Mar_Mod();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            ModeloEquipo objModelo = new ModeloEquipo();
            //Boolean bCargar = false;

            try
            {
                objModelo.idModelo = Convert.ToInt32(txtCodModelo.Text.Trim());
                objModelo.idMarca = Convert.ToInt32(cboMarca_Modelo.SelectedValue.ToString());
                objModelo.cNomModelo = Convert.ToString(txtModelo.Text.Trim());
                objModelo.cDescripModelo = Convert.ToString(txtObservacionModelo.Text.Trim());
                objModelo.bEstado = Convert.ToBoolean(chkEstadoModelo.Checked);
                objModelo.dFechaReg = dFechaSis;
                objModelo.idUsuario = Variables.gnCodUser;

                lcValidar = objCate_Marc_Mod.blGrabarModelo(objModelo, idTipoCon).Trim();
                fnLimpiarControles(3);
                fnHabilitarGroupBoxs(true, 3);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarAttrVehiculo", "fnGuardarModelo", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {          
            epCat_Marc_Plan.Clear();

            if (txtModelo.Text.Trim().Length <= 0)
            {
                epControlOk.SetError(txtModelo, "");
                epCat_Marc_Plan.SetError(txtModelo, "Ingresar Modelo");
            }
            else
            {
                epCat_Marc_Plan.SetError(txtModelo, "");
                epControlOk.SetError(txtModelo, "Ingreso de Modelo Correcto");
            }
            if (txtModelo.Text.Trim().Length > 0)
            {
                String lcResult = "";
                lcResult = fnGuardarModelo(lnTipoCon);
                if (lcResult == "OK")
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente Modelo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Grabar Modelo. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void frmRegistrar_Cate_Marc_Mod_Load(object sender, EventArgs e)
        {
            fnHabilitarGroupBoxs(false, 1);
            fnHabilitarGroupBoxs(false, 2);
            fnHabilitarGroupBoxs(false, 3);
            
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            fnLimpiarControles(1);
            fnHabilitarGroupBoxs(true, 1);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }
        private Boolean fnBuscarTablaCategoria(String pcBuscar, Int16 pnTipoCon, Int32 idTipoPlan)
        {
            BLCategoria objPlan = new BLCategoria();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();
            
           

            try
            {
                
                datTipoPlan = objPlan.blBuscarPlanDataTable(pcBuscar, pnTipoCon, idTipoPlan);

                if (datTipoPlan.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("CATEGORIA");
                    dt.Columns.Add("ESTADO");

                    String estado = "";
                    for (int i = 0; i <= datTipoPlan.Rows.Count - 1; i++)
                    {

                        if (Convert.ToBoolean(datTipoPlan.Rows[i][2]) == true)
                        {
                            estado = "ACTIVO";
                        }
                        else
                        {
                            estado = "INACTIVO";
                        }
                      
                        object[] row = { datTipoPlan.Rows[i][0], datTipoPlan.Rows[i][1], estado };
                        dt.Rows.Add(row);

                    }
                    erNumResultados.Text = "Nr. de Resultados (" + datTipoPlan.Rows.Count + ")";
                    erNumResultados.ForeColor = Variables.ColorSuccess;
                    dgCategoria.DataSource = dt;

                    dgCategoria.Columns[0].Width = 100;
                    dgCategoria.Columns[1].Width = 300;
                    dgCategoria.Columns[2].Width = 100;

                    dgCategoria.Visible = true;
                    return true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dgCategoria.DataSource = dt;
                    dgCategoria.Visible = false;
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

        
        private Boolean fnBuscarTablaModelo(String pcBuscar, Int16 pnTipoCon, Int32 idCategoria,Int32 idMarca)
        {
            BLCate_Mar_Mod objPlan = new BLCate_Mar_Mod();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();

            String columAccesorio = "";

            try
            {

                datTipoPlan = objPlan.blBuscarPlanDataTable(pcBuscar, pnTipoCon, idCategoria,idMarca);

                if (datTipoPlan.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("CATEGORIA");
                    dt.Columns.Add("MARCA");
                    dt.Columns.Add("MODELO");
                    dt.Columns.Add("ESTADO");

                    String estado = "";
                    for (int i = 0; i <= datTipoPlan.Rows.Count - 1; i++)
                    {

                        if (Convert.ToBoolean(datTipoPlan.Rows[i][4]) == true)
                        {
                            estado = "ACTIVO";
                        }
                        else
                        {
                            estado = "INACTIVO";
                        }
                        
                        object[] row = { datTipoPlan.Rows[i][0], datTipoPlan.Rows[i][1], datTipoPlan.Rows[i][2], datTipoPlan.Rows[i][3], estado };
                        dt.Rows.Add(row);

                    }
                    NumResultados_Modelo.Text = "Nr. de Resultados (" + datTipoPlan.Rows.Count + ")";
                    NumResultados_Modelo.ForeColor = Variables.ColorSuccess;
                    dgModelo.DataSource = dt;

                    dgModelo.Columns[0].Width = 50;
                    dgModelo.Columns[1].Width = 120;
                    dgModelo.Columns[2].Width = 150;
                    dgModelo.Columns[3].Width = 300;
                    dgModelo.Columns[4].Width = 100;


                    dgModelo.Visible = true;
                    return true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dgModelo.DataSource = dt;
                    dgModelo.Visible = false;
                    NumResultados_Modelo.Text = "Nr. de Resultados (" + datTipoPlan.Rows.Count + ")";
                    NumResultados_Modelo.ForeColor = Variables.ColorError;
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }
        private Boolean fnListarEspecifico(DataGridViewCellEventArgs e , Int32 numVentana)
        {
            
            if (numVentana == 1)
            {
                clsUtil objUtil = new clsUtil();
                try
                {
                    if (dgCategoria.Rows.Count > 0)
                    {
                        BLCategoria objPlan = new BLCategoria();
                        CategoriaEquipo lstCate = new CategoriaEquipo();
                        DataTable dtAccesorio = new DataTable();

                        lstCate = objPlan.blListarPlanDataGrid(Convert.ToInt32(dgCategoria.Rows[e.RowIndex].Cells[0].Value));
                        lnTipoCon = 1;
                        estActualizarCategoria = true;
                        txtActualizarCategoria.Text = Convert.ToString(lstCate.cNomCategoria.ToString().Trim());
                        txtCodCategoria.Text = Convert.ToString(lstCate.idCategoria.ToString().Trim());
                        txtCategoria.Text = Convert.ToString(lstCate.cNomCategoria.ToString().Trim());
                        txtObservacionCategoria.Text = Convert.ToString(lstCate.cDescripCategoria.ToString().Trim());
                        chkEstadoCategoria.Checked = lstCate.bEstado;
                        dgCategoria.Visible = false;

                        fnVerValidacion(false,1);
                        fnHabilitarGroupBox(gbCategoriaEquipo, false);
                        FunValidaciones.fnHabilitarBoton(btnNuevoCategoria, true);
                        FunValidaciones.fnHabilitarBoton(btnEditarCategoria, true);
                        FunValidaciones.fnHabilitarBoton(btnGuardarCategoria, false);
                        FunValidaciones.fnHabilitarBoton(btnSalirCategoria, true);
                        txtBuscarCategoria.Text = "";
                        estActualizarMarca = true;
                        

                    }


                    return true;
                }
                catch (Exception ex)
                {

                    objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                    return false;


                }
            }else if (numVentana == 2)
            {
                clsUtil objUtil = new clsUtil();
                try
                {
                    if (dgMarca.Rows.Count > 0)
                    {
                        BLMarca objPlan = new BLMarca();
                        MarcaEquipo lstCate = new MarcaEquipo();
                        DataTable dtAccesorio = new DataTable();

                        lstCate = objPlan.blListarPlanDataGrid(Convert.ToInt32(dgMarca.Rows[e.RowIndex].Cells[0].Value));

                        lnTipoCon = 1;
                        fnLlenarCategoria(cboCategoria_Marca, lnTipoCon, false);
                        estActualizarMarca = true;

                        txtActualizarMarca.Text = Convert.ToString(lstCate.cNomMarca.Trim().ToString());
                        txtCodMarca.Text = Convert.ToString(lstCate.idMarca.ToString());
                        cboCategoria_Marca.SelectedValue = Convert.ToInt32(lstCate.idCategoria.ToString());
                        txtMarca.Text = Convert.ToString(lstCate.cNomMarca.Trim().ToString());
                        txtObservacionMarca.Text = Convert.ToString(lstCate.cDescripMarca.ToString().Trim());
                        chkEstadoMarca.Checked = lstCate.bEstado;
                        dgMarca.Visible = false;

                        fnVerValidacion(false,2);
                        fnHabilitarGroupBox(gbMarcaEquipo, false);
                        FunValidaciones.fnHabilitarBoton(btnNuevoMarca, true);
                        FunValidaciones.fnHabilitarBoton(btnEditarMarca, true);
                        FunValidaciones.fnHabilitarBoton(btnGuardarMarca, false);
                        FunValidaciones.fnHabilitarBoton(btnSalirMarca, true);
                        txtBuscarMarca.Text = "";
                       
                        

                    }


                    return true;
                }
                catch (Exception ex)
                {

                    objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                    return false;


                }
            }
            else if (numVentana == 3)
            {
                clsUtil objUtil = new clsUtil();
                try
                {
                    if (dgCategoria.Rows.Count > 0)
                    {
                        BLCate_Mar_Mod objPlan = new BLCate_Mar_Mod();
                        ModeloEquipo lstModelo = new ModeloEquipo();
                        DataTable dtAccesorio = new DataTable();

                        lstModelo = objPlan.blListarModeloDataGrid(Convert.ToInt32(dgModelo.Rows[e.RowIndex].Cells[0].Value));
                        lnTipoCon = 1;
                        fnLlenarCategoria(cboCategoria_Modelo, lnTipoCon, false);
                        estActualizarModelo = true;
                        txtActualizarModelo.Text = Convert.ToString(lstModelo.cNomModelo.ToString().Trim());
                        txtCodModelo.Text = Convert.ToString(lstModelo.idModelo.ToString().Trim());
                        cboCategoria_Modelo.SelectedValue =  Convert.ToInt32(lstModelo.idCategoria.ToString());
                        cboMarca_Modelo.SelectedValue = Convert.ToInt32(lstModelo.idMarca.ToString());
                        txtModelo.Text = Convert.ToString(lstModelo.cNomModelo.ToString().Trim());
                        txtObservacionModelo.Text = Convert.ToString(lstModelo.cDescripModelo.ToString().Trim());
                        chkEstadoModelo.Checked = lstModelo.bEstado;
                        dgModelo.Visible = false;

                        fnVerValidacion(false,3);
                        fnHabilitarGroupBox(gbModeloEquipo, false);
                        FunValidaciones.fnHabilitarBoton(btnNuevoModelo, true);
                        FunValidaciones.fnHabilitarBoton(btnEditarModelo, true);
                        FunValidaciones.fnHabilitarBoton(btnGuardarModelo, false);
                        FunValidaciones.fnHabilitarBoton(btnSalirModelo, true);
                        txtBuscarModelo.Text = "";
                       

                    }


                    return true;
                }
                catch (Exception ex)
                {

                    objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                    return false;


                }
            }
            else
            {
                return false;
            }
            
        }

        
        

        private Boolean fnLlenarCategoria(ComboBox Combo,Int32 TipoCon ,Boolean buscar)
        {
            BLCate_Mar_Mod objCate_Marca_Mod = new BLCate_Mar_Mod();
            clsUtil objUtil = new clsUtil();
            List<CategoriaEquipo> lstcategoria = new List<CategoriaEquipo>();

            try
            {
                lstcategoria = objCate_Marca_Mod.blDevolverCategoriaEquipo(TipoCon,buscar);
                Combo.ValueMember = "idcategoria";
                Combo.DisplayMember = "cNomCategoria";
                Combo.DataSource = lstcategoria;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarUbigeo", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }



        
        private void txtBuscarCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon = 0;

                //if (rbCodigoCategoria.Checked == true)
                //{

                //    pnTipocon = 0;
                //}
                //else
                //{
                //    pnTipocon = 1;
                //}

                fnBuscarTablaCategoria(txtBuscarCategoria.Text.Trim(), pnTipocon,1);
            }
        }

        private void txtBuscarMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon = 0;

                //if (rbCodigoMarca.Checked == true)
                //{

                //    pnTipocon = 0;
                //}
                //else
                //{
                //    pnTipocon = 1;
                //}

                fnBuscarTablaCategoria(txtBuscarCategoria.Text.Trim(), pnTipocon,1);
            }
        }

      

        private void tbCate_Marc_Cod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbCate_Marc_Cod.SelectedIndex == 0)
            {
                lnTipoCon = 0;
                cboEstadoCategoria.SelectedIndex = 0;
                btnNuevo_Click(sender, e);
                fnHabilitarGroupBox(gbCategoriaEquipo, false);
                btnGuardarCategoria.Enabled = false;
                btnEditarCategoria.Enabled = false;

            } else if (tbCate_Marc_Cod.SelectedIndex == 1)
            {
                lnTipoCon = 0;
                cboEstadoMarca.SelectedIndex = 0;
                Boolean bResult = false;
                bResult = fnLlenarCategoria(cboBuscarCategoria_Marca,1, true);
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Categoria", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                bResult = fnLlenarCategoria(cboCategoria_Marca,lnTipoCon, false);
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Categoria", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                btnNuevoMarca_Click(sender, e);
                fnHabilitarGroupBox(gbMarcaEquipo, false);
                btnGuardarMarca.Enabled = false;
                btnEditarMarca.Enabled = false;

            }
            else if (tbCate_Marc_Cod.SelectedIndex == 2)
            {
                lnTipoCon = 0;
                cboEstado_Modelo.SelectedIndex = 0;
                Boolean bResult = false;
                bResult = fnLlenarCategoria(cboBuscarCategoria_Modelo,1,true);
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Categoria", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                bResult = fnLlenarCategoria(cboCategoria_Modelo,lnTipoCon, false);
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Categoria", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                btnNuevoModelo_Click(sender, e);
                fnHabilitarGroupBox(gbModeloEquipo, false);
                btnGuardarModelo.Enabled = false;
                btnEditarModelo.Enabled = false;
            }
        }

       


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            fnLimpiarControles(1);
            fnHabilitarGroupBox(gbCategoriaEquipo, true);
            
            fnVerValidacion(true,1);
            FunValidaciones.fnHabilitarBoton(btnNuevoCategoria, true);
            FunValidaciones.fnHabilitarBoton(btnEditarCategoria, false);
            FunValidaciones.fnHabilitarBoton(btnGuardarCategoria, true);
            FunValidaciones.fnHabilitarBoton(btnSalirCategoria, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String lcResultado = "";
            txtCategoria_TextChanged(sender, e);
            txtCateObservacion_TextChanged(sender, e);


            if (estNombreCategoria && estObservacionCategoria)
            {
                lcResultado = fnGuardarCategoria(lnTipoCon);
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente Categoria", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Grabar Categoria. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

       

        private void btnNuevoMarca_Click(object sender, EventArgs e)
        {
            
            fnLimpiarControles(2);
            fnHabilitarGroupBoxs(true, 2);
            fnVerValidacion(true, 2);
            FunValidaciones.fnHabilitarBoton(btnNuevoCategoria, true);
            FunValidaciones.fnHabilitarBoton(btnEditarCategoria, false);
            FunValidaciones.fnHabilitarBoton(btnGuardarCategoria, true);
            FunValidaciones.fnHabilitarBoton(btnSalirCategoria, true);
        }

        private void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            String lcResultado = "";


            var result1 = FunValidaciones.fnValidarCombobox(cboCategoria_Marca, erCategoria_Marca, imgCategoria_Marca);
            estCategoria_Marca = result1.Item1;
            msjCategoria_Marca = result1.Item2;
            txtMarca_TextChanged(sender, e);
            txtObservacionMarca_TextChanged(sender, e);


            if (estCategoria_Marca && estNombreMarca && estObservacionMarca)
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
                MessageBox.Show("Complete correctamente los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void siticoneWinToggleSwith1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevoModelo_Click(object sender, EventArgs e)
        {
            fnLimpiarControles(3);
            fnHabilitarGroupBoxs(true, 3);
            fnVerValidacion(true, 3);
            FunValidaciones.fnHabilitarBoton(btnNuevoModelo, true);
            FunValidaciones.fnHabilitarBoton(btnEditarModelo, false);
            FunValidaciones.fnHabilitarBoton(btnGuardarModelo, true);
            FunValidaciones.fnHabilitarBoton(btnSalirModelo, true);
        }

        private void txtCateObservacion_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtObservacionCategoria, erObservacionCategoria, imgObservacionCategoria, false, true, true, 0, 0, 3, 200, "Complete Correctamente el campo");
            estObservacionCategoria = result.Item1;
            msjObservacionCategoria = result.Item2;
        }

        private void txtBuscarCategoria_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon = 0;

                if (cboEstadoCategoria.SelectedIndex == 2)
                {

                    pnTipocon = -2;
                }
                else if (cboEstadoCategoria.SelectedIndex == 1)
                {
                    pnTipocon = -1;
                }
                else
                {
                    pnTipocon = 0;
                }
                
                fnBuscarTablaCategoria(txtBuscarCategoria.Text.Trim(), pnTipocon, 1);
            }
        }
        private void fnHabilitarGroupBox(SiticoneGroupBox gbox, Boolean pbEstado)
        {
            gbox.Enabled = pbEstado;
        }
        private void fnVerValidacion(Boolean estado, Int32 numVentana)
        {
            if(numVentana == 1)
            {
                /////TEXBOXS/////
                erNombreCategoria.Visible = estado;
                erObservacionCategoria.Visible = estado;

                /////PICTUREBOXS////
                imgNombreCategoria.Visible = estado;
                imgObservacionCategoria.Visible = estado;

            }
            else if (numVentana ==2)
            {
                /////TEXBOXS/////
                erCategoria_Marca.Visible = estado;
                /////TEXBOXS/////
                erNombreMarca.Visible = estado;
                erObservacionMarca.Visible = estado;

                /////PICTUREBOXS////
                imgCategoria_Marca.Visible = estado;
                imgNombreMarca.Visible = estado;
                imgObservacionMarca.Visible = estado;


            }
            else if (numVentana == 3)
            {
                /////TEXBOXS/////
                erCboCategoria_Modelo.Visible = estado;
                erCboMarca_Modelo.Visible = estado;
                erNombre_Modelo.Visible = estado;
                erObservacion_Modelo.Visible = estado;

                /////PICTUREBOXS////
                imgCategoria_Modelo.Visible = estado;
                imgMarca_Modelo.Visible = estado;
                imgNombre_Modelo.Visible = estado;
                imgObservacion_Modelo.Visible = estado;

            }


        }

        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            fnHabilitarGroupBox(gbCategoriaEquipo, true);
            fnVerValidacion(true,1);
            FunValidaciones.fnHabilitarBoton(btnNuevoCategoria, true);
            FunValidaciones.fnHabilitarBoton(btnEditarCategoria, false);
            FunValidaciones.fnHabilitarBoton(btnGuardarCategoria, true);
            FunValidaciones.fnHabilitarBoton(btnSalirCategoria, true);
        }

        private void btnSalirCategoria_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e,"LETRAS", true,erNombreCategoria);
        }

        private void cboEstadoCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 pnTipocon = 0;

            if (cboEstadoCategoria.SelectedIndex == 2)
            {

                pnTipocon = -2;
            }
            else if (cboEstadoCategoria.SelectedIndex == 1)
            {
                pnTipocon = -1;
            }
            else
            {
                pnTipocon = 0;
            }

            fnBuscarTablaCategoria(txtBuscarCategoria.Text.Trim(), pnTipocon, 1);
        }

        private void txtActualizarMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditarMarca_Click(object sender, EventArgs e)
        {
            fnHabilitarGroupBox(gbMarcaEquipo, true);
            fnVerValidacion(true,2);
            FunValidaciones.fnHabilitarBoton(btnNuevoMarca, true);
            FunValidaciones.fnHabilitarBoton(btnEditarMarca, false);
            FunValidaciones.fnHabilitarBoton(btnGuardarMarca, true);
            FunValidaciones.fnHabilitarBoton(btnSalirMarca, true);
        }

        private void txtObservacionMarca_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtObservacionMarca, erObservacionMarca, imgObservacionMarca, false, true, true, 0, 0, 3, 200, "Complete correctamente el campo");
            estObservacionMarca = result.Item1;
            msjObservacionMarca = result.Item2;
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true,erNombreMarca);
        }

        private void dgMarca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //fnLlenarTipoPlan(-1, cboTipoPlan, 0);

            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                bResul = fnListarEspecifico(e,2);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
        }

        private void cboMarca_Modelo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            txtModelo.Text = "";
            if (cboMarca_Modelo.SelectedValue == null || cboMarca_Modelo.SelectedValue.ToString() == "0")
            {
                txtModelo.Enabled = false;
            }
            else
            {
                txtModelo.Enabled = true;
            }

            var result = FunValidaciones.fnValidarCombobox(cboMarca_Modelo, erCboMarca_Modelo, imgMarca_Modelo);
            estMarca_Modelo = result.Item1;
            msjMarca_Modelo = result.Item2;


        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexboxSQLModelo(txtModelo, erNombre_Modelo, imgNombre_Modelo, false, 0);
            estNombre_Modelo = result.Item1;
            msjNombre_Modelo = result.Item2;
        }

        private Tuple<Boolean, String> fnValidarTexboxSQLModelo(SiticoneTextBox txt, Label lbl, PictureBox img, Boolean maximo, Int32 num)
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
            else if (estActualizarModelo)
            {

                if (txtActualizarModelo.Text.Trim() == txt.Text.Trim())
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
                    bResul = fnBuscarNombreModelo(txt.Text.Trim(), pnTipocon);
                    return Tuple.Create(bResul, msj);

                }

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                bResul = fnBuscarNombreModelo(txt.Text.Trim(), pnTipocon);
                return Tuple.Create(bResul, msj);

            }


        }

        private Boolean fnBuscarNombreModelo(String pcBuscar, Int16 pnTipoCon)
        {
            BLCate_Mar_Mod objPlan = new BLCate_Mar_Mod();
            clsUtil objUtil = new clsUtil();
            Int16 numResult = 0;

            Int32 idCategoria = Convert.ToInt32(cboMarca_Modelo.SelectedValue.ToString());
            try
            {
                numResult = objPlan.blBuscarNombreModelo(pcBuscar, idCategoria);

                if (numResult == 1)
                {
                    erNombre_Modelo.Text = "Este nombre ya existe (Ingrese otro nombre)";
                    erNombre_Modelo.ForeColor = Color.Red;
                    imgNombre_Modelo.Image = Properties.Resources.error;
                    return false;
                }
                else if (numResult == 0)
                {
                    erNombre_Modelo.Text = "";
                    imgNombre_Modelo.Image = Properties.Resources.ok;
                    return true;
                }
                else
                {
                    erNombre_Modelo.Text = "Ocurrió otro error";
                    erNombre_Modelo.ForeColor = Color.Red;
                    imgNombre_Modelo.Image = Properties.Resources.error;
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

                objPlan = null;
                objUtil = null;
            }
        }

        private void txtObservacionModelo_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtObservacionModelo, erObservacion_Modelo,imgObservacion_Modelo, false, true, true, 0, 0, 3, 200, "Complete correctamente el campo");
            estObservaciones_Modelo = result.Item1;
            msjObservaciones_Modelo = result.Item2;
        }

        private void btnSalirModelo_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgModelo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                bResul = fnListarEspecifico(e, 3);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
        }

        private void txtBuscarModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon;

                if (cboEstado_Modelo.SelectedIndex == 2)
                {

                    pnTipocon = -2;
                }
                else if (cboEstado_Modelo.SelectedIndex == 1)
                {
                    pnTipocon = -1;
                }
                else
                {
                    pnTipocon = 0;
                }

                String txtBuscar = txtBuscarModelo.Text.Trim();

                Int32 idCategoria = Convert.ToInt32(cboBuscarCategoria_Modelo.SelectedValue == null ? "0" : cboBuscarCategoria_Modelo.SelectedValue.ToString());
                Int32 idMarca = Convert.ToInt32(cboBuscarMarca_Modelo.SelectedValue == null ? "0" : cboBuscarMarca_Modelo.SelectedValue.ToString());

                fnBuscarTablaModelo(txtBuscar, pnTipocon, idCategoria,idMarca);
            }
        }

        private void cboEstadoMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 pnTipocon;

            if (cboEstadoMarca.SelectedIndex == 2)
            {

                pnTipocon = -2;
            }
            else if (cboEstadoMarca.SelectedIndex == 1)
            {
                pnTipocon = -1;
            }
            else
            {
                pnTipocon = 0;
            }

            String txtBuscar = txtBuscarMarca.Text.Trim();
            Int32 idCategoria = Convert.ToInt32(cboBuscarCategoria_Marca.SelectedValue == null ? "0" : cboBuscarCategoria_Marca.SelectedValue.ToString());


            fnBuscarTablaMarca(txtBuscar, pnTipocon, idCategoria);
        }

        private void cboBuscarCategoria_Marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 pnTipocon;

            if (cboEstadoMarca.SelectedIndex == 2)
            {

                pnTipocon = -2;
            }
            else if (cboEstadoMarca.SelectedIndex == 1)
            {
                pnTipocon = -1;
            }
            else
            {
                pnTipocon = 0;
            }

            String txtBuscar = txtBuscarMarca.Text.Trim();
            Int32 idCategoria = Convert.ToInt32(cboBuscarCategoria_Marca.SelectedValue == null ? "0" : cboBuscarCategoria_Marca.SelectedValue.ToString());


            fnBuscarTablaMarca(txtBuscar, pnTipocon, idCategoria);
        }

        private void btnEditarModelo_Click(object sender, EventArgs e)
        {
            fnHabilitarGroupBox(gbModeloEquipo, true);
            fnVerValidacion(true, 3);
            FunValidaciones.fnHabilitarBoton(btnNuevoModelo, true);
            FunValidaciones.fnHabilitarBoton(btnEditarModelo, false);
            FunValidaciones.fnHabilitarBoton(btnGuardarModelo, true);
            FunValidaciones.fnHabilitarBoton(btnSalirModelo, true);
        }

        private void txtModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "DIRECCION", true,erNombre_Modelo);
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexboxSQLMarca(txtMarca, erNombreMarca, imgNombreMarca, false, 0);
            estNombreMarca = result.Item1;
            msjNombreMarca = result.Item2;
            txtMarca.MaxLength = 45;

        }

        private Tuple<Boolean, String> fnValidarTexboxSQLMarca(SiticoneTextBox txt, Label lbl, PictureBox img, Boolean maximo, Int32 num)
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
            else if (estActualizarMarca)
            {

                if (txtActualizarMarca.Text.Trim() == txt.Text.Trim())
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
                    bResul = fnBuscarNombreMarca(txt.Text.Trim(), pnTipocon);
                    return Tuple.Create(bResul, msj);

                }

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                bResul = fnBuscarNombreMarca(txt.Text.Trim(), pnTipocon);
                return Tuple.Create(bResul, msj);

            }


        }

        private void cboEstado_Modelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 pnTipocon;

            if (cboEstado_Modelo.SelectedIndex == 2)
            {

                pnTipocon = -2;
            }
            else if (cboEstado_Modelo.SelectedIndex == 1)
            {
                pnTipocon = -1;
            }
            else
            {
                pnTipocon = 0;
            }

            String txtBuscar = txtBuscarModelo.Text.Trim();

            Int32 idCategoria = Convert.ToInt32(cboBuscarCategoria_Modelo.SelectedValue == null ? "0" : cboBuscarCategoria_Modelo.SelectedValue.ToString());
            Int32 idMarca = Convert.ToInt32(cboBuscarMarca_Modelo.SelectedValue == null ? "0" : cboBuscarMarca_Modelo.SelectedValue.ToString());

            fnBuscarTablaModelo(txtBuscar, pnTipocon, idCategoria, idMarca);
        }

        private void cboBuscarMarca_Modelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 pnTipocon;

            if (cboEstado_Modelo.SelectedIndex == 2)
            {

                pnTipocon = -2;
            }
            else if (cboEstado_Modelo.SelectedIndex == 1)
            {
                pnTipocon = -1;
            }
            else
            {
                pnTipocon = 0;
            }

            String txtBuscar = txtBuscarModelo.Text.Trim();

            Int32 idCategoria = Convert.ToInt32(cboBuscarCategoria_Modelo.SelectedValue == null ? "0" : cboBuscarCategoria_Modelo.SelectedValue.ToString());
            Int32 idMarca = Convert.ToInt32(cboBuscarMarca_Modelo.SelectedValue == null ? "0" : cboBuscarMarca_Modelo.SelectedValue.ToString());

            fnBuscarTablaModelo(txtBuscar, pnTipocon, idCategoria, idMarca);
        }

        private Boolean fnBuscarNombreMarca(String pcBuscar, Int16 pnTipoCon)
        {
            BLMarca objPlan = new BLMarca();
            clsUtil objUtil = new clsUtil();
            Int16 numResult = 0;

            Int32 idCategoria = Convert.ToInt32(cboCategoria_Marca.SelectedValue.ToString());
            try
            {
                numResult = objPlan.blBuscarNombreMarca(pcBuscar, idCategoria);

                if (numResult == 1)
                {
                    erNombreMarca.Text = "Este nombre ya existe (Ingrese otro nombre)";
                    erNombreMarca.ForeColor = Color.Red;
                    imgNombreMarca.Image = Properties.Resources.error;
                    return false;
                }
                else if (numResult == 0)
                {
                    erNombreMarca.Text = "";
                    imgNombreMarca.Image = Properties.Resources.ok;
                    return true;
                }
                else
                {
                    erNombreMarca.Text = "Ocurrió otro error";
                    erNombreMarca.ForeColor = Color.Red;
                    imgNombreMarca.Image = Properties.Resources.error;
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

                objPlan = null;
                objUtil = null;
            }
        }

        private void cboBuscarCategoria_Modelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResult;


            if (cboBuscarCategoria_Modelo.SelectedValue == null || cboBuscarCategoria_Modelo.SelectedValue.ToString() == "0")
            {

                //cboBuscarCategoria_Modelo.Enabled = false;
                bResult = fnLLnenarMarcaxCategoria(Convert.ToInt32(cboBuscarCategoria_Modelo.SelectedValue), 1, true, cboBuscarMarca_Modelo);
                if (!bResult)
                {
                    MessageBox.Show("ERROR al Devolver la MARCA  DE TAL CATEGORIA", "cboCategoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                //cboBuscarCategoria_Modelo.Enabled = true;
                bResult = fnLLnenarMarcaxCategoria(Convert.ToInt32(cboBuscarCategoria_Modelo.SelectedValue), 1, true, cboBuscarMarca_Modelo);
                if (!bResult)
                {
                    MessageBox.Show("ERROR al Devolver la MARCA  DE TAL CATEGORIA", "cboCategoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            Int16 pnTipocon;

            if (cboEstado_Modelo.SelectedIndex == 2)
            {

                pnTipocon = -2;
            }
            else if (cboEstado_Modelo.SelectedIndex == 1)
            {
                pnTipocon = -1;
            }
            else
            {
                pnTipocon = 0;
            }

            String txtBuscar = txtBuscarModelo.Text.Trim();

            Int32 idCategoria = Convert.ToInt32(cboBuscarCategoria_Modelo.SelectedValue == null ? "0" : cboBuscarCategoria_Modelo.SelectedValue.ToString());
            Int32 idMarca = Convert.ToInt32(cboBuscarMarca_Modelo.SelectedValue == null ? "0" : cboBuscarMarca_Modelo.SelectedValue.ToString());

            fnBuscarTablaModelo(txtBuscar, pnTipocon, idCategoria, idMarca);
        }

        private Boolean fnLLnenarMarcaxCategoria(Int32 idCategoria, Int16 pnTipoCon, Boolean buscar, ComboBox combo)
        {
            BLCate_Mar_Mod objCate_Marca_Mod = new BLCate_Mar_Mod();
            clsUtil objUtil = new clsUtil();
            List<MarcaEquipo> lstMarca = new List<MarcaEquipo>();

            try
            {
                lstMarca = objCate_Marca_Mod.blDevolverMarcaEquipo(idCategoria, pnTipoCon, buscar);
                combo.ValueMember = "idMarca";
                combo.DisplayMember = "cNomMarca";
                combo.DataSource = lstMarca;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarEquipo", "fnLlenarMarca", ex.Message);
                return false;
            }

        }

        private void cboCategoria_Modelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResult;


            if (cboCategoria_Modelo.SelectedValue == null || cboCategoria_Modelo.SelectedValue.ToString() == "0")
            {

                //cboBuscarCategoria_Modelo.Enabled = false;
                bResult = fnLLnenarMarcaxCategoria(Convert.ToInt32(cboCategoria_Modelo.SelectedValue), lnTipoCon, false, cboMarca_Modelo);
                if (!bResult)
                {
                    MessageBox.Show("ERROR al Devolver la MARCA  DE TAL CATEGORIA", "cboCategoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                //cboBuscarCategoria_Modelo.Enabled = true;
                bResult = fnLLnenarMarcaxCategoria(Convert.ToInt32(cboCategoria_Modelo.SelectedValue), lnTipoCon, false, cboMarca_Modelo);
                if (!bResult)
                {
                    MessageBox.Show("ERROR al Devolver la MARCA  DE TAL CATEGORIA", "cboCategoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            var result = FunValidaciones.fnValidarCombobox(cboCategoria_Modelo, erCboCategoria_Modelo, imgCategoria_Modelo);
            estCategoria_Modelo = result.Item1;
            msjCategoria_Modelo = result.Item2;
        }

        private void btnSalirMarca_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtBuscarMarca_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Int16 pnTipocon;

                if (cboEstadoMarca.SelectedIndex == 2)
                {

                    pnTipocon = -2;
                }
                else if (cboEstadoMarca.SelectedIndex == 1)
                {
                    pnTipocon = -1;
                }
                else
                {
                    pnTipocon = 0;
                }

                String txtBuscar = txtBuscarMarca.Text.Trim();
                Int32 idCategoria= Convert.ToInt32(cboBuscarCategoria_Marca.SelectedValue == null ? "0" : cboBuscarCategoria_Marca.SelectedValue.ToString());
                

                fnBuscarTablaMarca(txtBuscar, pnTipocon, idCategoria);
            }
        }
        private Boolean fnBuscarTablaMarca(String pcBuscar, Int16 pnTipoCon, Int32 idCategoria)
        {
            BLMarca objPlan = new BLMarca();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();



            try
            {

                datTipoPlan = objPlan.blBuscarPlanDataTable(pcBuscar, pnTipoCon, idCategoria);

                if (datTipoPlan.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("CATEGORIA");
                    dt.Columns.Add("MARCA");
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
                    numResultadosMarca.Text = "Nr. de Resultados (" + datTipoPlan.Rows.Count + ")";
                    numResultadosMarca.ForeColor = Variables.ColorSuccess;
                    dgMarca.DataSource = dt;

                    dgMarca.Columns[0].Width = 100;
                    dgMarca.Columns[1].Width = 100;
                    dgMarca.Columns[2].Width = 300;
                    dgMarca.Columns[3].Width = 100;

                    dgMarca.Visible = true;
                    return true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dgMarca.DataSource = dt;
                    dgMarca.Visible = false;
                    numResultadosMarca.Text = "Nr. de Resultados (" + datTipoPlan.Rows.Count + ")";
                    numResultadosMarca.ForeColor = Variables.ColorError;
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        

        private void cboCategoria_Marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMarca.Text = "";
            if (cboCategoria_Marca.SelectedValue == null || cboCategoria_Marca.SelectedValue.ToString() == "0")
            {
                txtMarca.Enabled = false;
            }
            else
            {
                txtMarca.Enabled = true;
            }
            
            var result = FunValidaciones.fnValidarCombobox(cboCategoria_Marca, erCategoria_Marca, imgCategoria_Marca);
            estCategoria_Marca = result.Item1;
            msjCategoria_Marca = result.Item2;
        }

        private void dgCategoria_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            estActualizarCategoria = true;
            //fnLlenarTipoPlan(-1, cboTipoPlan, 0);
            
            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                bResul = fnListarEspecifico(e,1);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
        }

        private void btnGuardarModelo_Click(object sender, EventArgs e)
        {
            var result1 = FunValidaciones.fnValidarCombobox(cboCategoria_Modelo, erCboCategoria_Modelo, imgCategoria_Modelo);
            estCategoria_Modelo = result1.Item1;
            msjCategoria_Modelo = result1.Item2;
            var result2 = FunValidaciones.fnValidarCombobox(cboMarca_Modelo, erCboMarca_Modelo, imgMarca_Modelo);
            estMarca_Modelo = result2.Item1;
            msjMarca_Modelo = result2.Item2;
            txtModelo_TextChanged(sender, e);
            txtObservacionModelo_TextChanged(sender, e);


            if (estCategoria_Modelo && estMarca_Modelo && estNombre_Modelo && estObservaciones_Modelo)
            {
                String lcResult = "";
                lcResult = fnGuardarModelo(lnTipoCon);
                if (lcResult == "OK")
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
                MessageBox.Show("Complete correctamente los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexboxSQLCategoria(txtCategoria, erNombreCategoria, imgNombreCategoria, false, 0);
            estNombreCategoria = result.Item1;
            msjNombreCategoria = result.Item2;
        }
        private Boolean fnBuscarNombreCategoria(String pcBuscar)
        {
            BLCategoria objPlan = new BLCategoria();
            clsUtil objUtil = new clsUtil();
            Int16 numResult = 0;

            
            try
            {
                numResult = objPlan.blBuscarNombreCategoria(pcBuscar);

                if (numResult == 1)
                {
                    erNombreCategoria.Text = "Este nombre ya existe (Ingrese otro nombre)";
                    erNombreCategoria.ForeColor = Color.Red;
                    imgNombreCategoria.Image = Properties.Resources.error;
                    return false;
                }
                else if (numResult == 0)
                {
                    erNombreCategoria.Text = "";
                    imgNombreCategoria.Image = Properties.Resources.ok;
                    return true;
                }
                else
                {
                    erNombreCategoria.Text = "Ocurrió otro error";
                    erNombreCategoria.ForeColor = Color.Red;
                    imgNombreCategoria.Image = Properties.Resources.error;
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

                objPlan = null;
                objUtil = null;
            }
        }
        private Tuple<Boolean, String> fnValidarTexboxSQLCategoria(SiticoneTextBox txt, Label lbl, PictureBox img, Boolean maximo, Int32 num)
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
            else if (estActualizarCategoria)
            {

                if (txtActualizarCategoria.Text.Trim() == txt.Text.Trim())
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
                    bResul = fnBuscarNombreCategoria(txt.Text.Trim());
                    return Tuple.Create(bResul, msj);

                }

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                bResul = fnBuscarNombreCategoria(txt.Text.Trim());
                return Tuple.Create(bResul, msj);

            }


        }
    }
}
