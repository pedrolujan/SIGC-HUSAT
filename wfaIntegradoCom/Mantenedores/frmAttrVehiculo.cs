using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Guna.UI.WinForms;
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
    public partial class frmAttrVehiculo : Form
    {
        public frmAttrVehiculo()
        {
            InitializeComponent();
        }
        static Int32 tabInicio;
        Int16 lnTipoCon = 0;
        Int16 lnTipoLlamada = 0;
        static Boolean CargoForm = false;
        Boolean estTxtClase, estClaseMarc, estMarca, estClaseMod, estMarcaMod, estModelo, estConPlaca, estCboClaseMarc,estCboClaseUso, estSerie, estAnio, estColor, estUso, estPropietario,estUs;
        String msgTxtClase,msjMarca, msjClaseMod, msjMarcaMod, msjModelo, msjCboClaseMarc,msjCboClaseUso, msjUso, msjPropietario;

        public class ComboExistenciaMarca
        {
            public string Value { get; set; }
            public string Index { get; set; }
        }
        private void txtBuscarMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);
            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarDatosParaDatatables(0, -1);
            }
        }

        private void fnActivarDtG_GrB(DataGridView dgv,SiticoneGroupBox gb,Boolean estado)
        {
            dgv.Visible = estado;
            gb.Visible = estado;
        }

        private Boolean fnListarMarcaEspcifica(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                if (dgMarca.Rows.Count > 0)
                {
                    BLAttrVehiculo objChip = new BLAttrVehiculo();
                    DataTable mrcVehiculo=new DataTable();

                    DataTable dtEquipo = new DataTable();

                    mrcVehiculo = objChip.blListarMarcaEspecifica(Convert.ToInt32(dgMarca.Rows[e.RowIndex].Cells[0].Value));
                    lnTipoCon = 1;
                    foreach (DataRow drVehiculo in mrcVehiculo.Rows)
                    {
                        txtCodMarca.Text = Convert.ToString(drVehiculo["idMarcaV"]);

                        cboClaseV.SelectedValue = Convert.ToInt32(drVehiculo["idClaseV"]);
                        txtMarca2.Text = Convert.ToString(drVehiculo["nombreMarcaV"]);
                        txtMarca.Text = Convert.ToString(drVehiculo["nombreMarcaV"]);
                        swEstadoMarca.Checked = Convert.ToBoolean(drVehiculo["bEstado"]);
                    }

                    fnActivarDtG_GrB(dgMarca, gbPaginacionMarc,false);
                    fnActivarControles(gbInfoMarca, false);
                    FunValidaciones.fnHabilitarBoton(btnEditarMarc, true);
                    FunValidaciones.fnHabilitarBoton(btnNuevoMarc, true);
                    if (estMarca == true) { FunValidaciones.fnHabilitarBoton(btnGuardarMarc, true); } else { FunValidaciones.fnHabilitarBoton(btnGuardarMarc, false); }

                }


                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;
            }
        }
        private Boolean fnListarModeloEspcifico(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            BLAttrVehiculo objModelo = new BLAttrVehiculo();
            List<ModeloVehiculo> lstModelo = new List<ModeloVehiculo>();
            try
            {
                if (dgModelo.RowCount > 0)
                {
                    lstModelo = objModelo.blListarModelo(Convert.ToInt32(dgModelo.Rows[e.RowIndex].Cells[0].Value));

                    if (lstModelo.Count > 0)
                    {
                        lnTipoCon = 1;
                        txtCodModelo.Text = Convert.ToString(lstModelo[0].idModelo);
                        txtModelo2.Text = Convert.ToString(lstModelo[0].cNomModelo);
                        txtModelo.Text = Convert.ToString(lstModelo[0].cNomModelo);
                        swEstadoMadelo.Checked = lstModelo[0].bEstado;
                        cboClaseMod.SelectedValue = lstModelo[0].idClase;
                        cboMarcaMod.SelectedValue = lstModelo[0].idMarca;
                        fnActivarDtG_GrB(dgModelo,gbPaginacioMod,false);
                        txtBuscarModelo.Text = "";
                        fnActivarControles(gbInfoModelo, false);
                        FunValidaciones.fnHabilitarBoton(btnEditarMod, true);
                        FunValidaciones.fnHabilitarBoton(btnNuevoMod, true);

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
        private void dgMarca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                bResul = fnListarMarcaEspcifica(e);               

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar chip Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //this.Close();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResult = false;
            if (tabControl1.SelectedIndex == 0)
            {

                dgClase.Visible = false;
                gbPaginasC.Visible = false;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                bResult = fnLLenarClaseVehiculo(cboBuscarXCLaseMarc, true);
                bResult = fnLLenarClaseVehiculo(cboClaseV, false);
                pbClaseVMarc.Image = null;
                lblCboClaseMarc.Text = "";
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Clase Vehiculo", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                dgMarca.Visible = false;
                gbPaginacionMarc.Visible = true;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                bResult = fnLLenarClaseVehiculo(cboBuscarXClase_Mod, true);
                bResult = fnLLenarClaseVehiculo(cboClaseMod, false);
                //bResult = fnLLenarClaseVehiculo(cboClaseMod, false);

                //pbClaseVMarc.Image = null;
                //lblCboClaseMarc.Text = "";
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Clase Vehiculo", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                dgModelo.Visible = false;
                gbPaginacioMod.Visible = false;

            }
            else if (tabControl1.SelectedIndex == 3)
            {

                //fnActivarControlesUso(gbInfoUso, false);
                FunValidaciones.fnHabilitarBoton(btnEditarU, false);
                FunValidaciones.fnHabilitarBoton(btnGuardarU, false);

                bResult = fnLLenarClaseVehiculo(cboBuscarXclaseUSO, true);
                bResult = fnLLenarClaseVehiculo(cboBuscarClaseV, false);
                pbCboClaseUso.Image = null;
                lblCboClaseUso.Text = "";
                pbUsoVUso.Image = null;
                lblUsoVUso.Text = "";
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Clase Vehiculo", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();

                }
                dgvUso.Visible = false;
                gbPaginacionUso.Visible = false;
                
            }
           
        }
        private Boolean fnLLenarMarcaxClase(SiticoneComboBox cbo, SiticoneComboBox CboPadre, Boolean estado)
        {

            BLAttrVehiculo objMarcaV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            List<MarcaVehiculo> lstMarcaV = new List<MarcaVehiculo>();

            try
            {
                Int32 idClase = Convert.ToInt32(CboPadre.SelectedValue);

                lstMarcaV = objMarcaV.blDevolverMarcaVehiculo(idClase,estado,lnTipoCon);
                cbo.DataSource = null;
                cbo.ValueMember = "idMarca";
                cbo.DisplayMember = "cNomMarca";
                cbo.DataSource = lstMarcaV;

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
        private void cboClaseMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnLLenarMarcaxClase(cboMarcaMod,cboClaseMod,false);
            var Result = FunValidaciones.fnValidarCombobox(cboClaseMod,lblMsgClaseMod,pbClaseMod);
            estClaseMod = Result.Item1;
            msjClaseMod = Result.Item2;

            txtModelo_TextChanged( sender,  e);
        }

        private void cboBuscarXClase_Mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CargoForm == true)
            {
                fnBuscarDatosParaDatatables(0, -1);
                fnLLenarMarcaxClase(cboBuscarXMarca_Mod,cboBuscarXClase_Mod,true);
            }
        }

        private void txtBuscarClase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarDatosParaDatatables(0, -1);
            }
        }

        private void fnAgregarDatosDeBusqueda(Int32 tipoConPagina,Int32 pagina,Int32 filas, DataTable dtDatosResp,DataTable dt,Int32 totalResultados,Int32 tabIndex)
        {
            Int32 y;
            if (tipoConPagina == -1)
            {
                y = 0;
            }
            else
            {
                tabInicio = (pagina - 1) * filas;
                y = tabInicio;
            }


            if (tabIndex != 2)
            {
                for (int i = 0; i <= totalResultados - 1; i++)
                {
                    y++;
                    object[] dRow = {dtDatosResp.Rows[i][0],
                                        y,
                                        dtDatosResp.Rows[i][1],
                                        dtDatosResp.Rows[i][2],
                                        dtDatosResp.Rows[i][3]};

                    dt.Rows.Add(dRow);
                }
            }
            else
            {
                for (int i = 0; i <= totalResultados - 1; i++)
                {
                    y++;
                    object[] dRow = {dtDatosResp.Rows[i][0],
                                        y,
                                        dtDatosResp.Rows[i][1],
                                        dtDatosResp.Rows[i][2],
                                        dtDatosResp.Rows[i][3],
                                        dtDatosResp.Rows[i][5]};

                    dt.Rows.Add(dRow);
                }
            }

            if (tabIndex == 0) { dgClase.DataSource = dt; dgClase.Visible = true; gbPaginasC.Visible = true; } else if (tabIndex == 1) { dgMarca.DataSource = dt; dgMarca.Visible = true; gbPaginacionMarc.Visible = true; } else if (tabIndex == 2) { dgModelo.DataSource = dt; dgModelo.Visible = true; gbPaginacioMod.Visible = true; } else if(tabIndex==3) { dgvUso.DataSource = dt; dgvUso.Visible = true; gbPaginacionUso.Visible = true;}

            if (tipoConPagina == -1)
            {
                Int32 totalRegistros = Convert.ToInt32(dtDatosResp.Rows[0][4]);
                gbPaginacionMarc.Visible = true;
                if (tabIndex==0)
                {
                    fnCalcularPaginacion(totalRegistros, filas, totalResultados, cboPaginacion, btnTotalPaginas, btnCantRegistros, btnCantTotalRegistros);
                }else if (tabIndex == 1)
                {
                    fnCalcularPaginacion(totalRegistros, filas, totalResultados, cboPaginacionMarc, btnTotalPaginasMarc, btnRegistrosMarc, btnTotalRegistrosMarc);
                }else if (tabIndex == 2)
                {
                    fnCalcularPaginacion(totalRegistros, filas, totalResultados, cboPaginacionMod, btnTotalPaginasMod, btnRegistrosMod, btnTotalRegistrosMod);
                }
                else if (tabIndex==3)
                {
                    fnCalcularPaginacion(totalRegistros, filas, totalResultados, cboPaginacionUso, btnTotalPaginasUso, btnRegistrosUso, btnTotalRegistrosUso);
                }
            }

        }

        private void fnswitches(SiticoneToggleSwitch sw, Int32 tipoSW,Label lbl)
        {
            if (tipoSW==0)
            {
                lbl.Text = (sw.Checked == true) ? "Si" : "No";

            }
            else
            {
                lbl.Text = (sw.Checked == true) ? "Activo" : "Inactivo";
            }
        }
        private void swConPlaca_CheckedChanged(object sender, EventArgs e)
        {
            fnswitches(swConPlaca,0,msgVconPlaca);
        }

        private void swEstadoClase_CheckedChanged(object sender, EventArgs e)
        {
            fnswitches(swEstadoClase, 1, msgEstadoClase);
        }

        private void txtBuscarModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);
            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarDatosParaDatatables(0, -1);
            }
        }

        private void cboBuscarXClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CargoForm == true)
            {
                fnBuscarDatosParaDatatables(0, -1);
            }
        }

        private void cboBuscarXMarca_Mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CargoForm == true)
            {
              fnBuscarDatosParaDatatables(0, -1);
            }
        }

        private void cboPaginacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarDatosParaDatatables(Convert.ToInt32(cboPaginacion.Text), -2);
        }

        private void cboPaginacionMarc_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarDatosParaDatatables(Convert.ToInt32(cboPaginacionMarc.Text), -2);
        }

        private void cboPaginacionMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarDatosParaDatatables(Convert.ToInt32(cboPaginacionMod.Text), -2);
        }
        private void cboPaginacionUso_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarDatosParaDatatables(Convert.ToInt32(cboPaginacion.Text), -2);
        }




        private Boolean fnBuscarDatosParaDatatables(Int32 pagina, Int32 tipoConPagina)
        {
            BLAttrVehiculo objAttrV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            DataTable dtResultados = new DataTable();
            Boolean conPlaca = false;
            Int32 filas = 15;
            Int32 pnIdClase = 0;
            Int32 pnIdMarca = 0;
            String pcBuscar = "";
            Int32 tabIndex = 0;
            try
            {
                tabIndex = Convert.ToInt32(tabControl1.SelectedIndex);

                if (tabIndex==0)
                {
                    
                    pnIdClase = Convert.ToInt32(cboBuscarXClase.SelectedValue);
                    pnIdMarca = 0;
                    pcBuscar = Convert.ToString(txtBuscarClase.Text);
                }
                else
                if(tabIndex == 1)
                {
                    pnIdClase = Convert.ToInt32(cboBuscarXCLaseMarc.SelectedValue);
                    pnIdMarca = 0;
                    pcBuscar = Convert.ToString(txtBuscarMarca.Text);
                }
                else 
                if (tabIndex==2)
                {
                    pnIdClase = Convert.ToInt32(cboBuscarXClase_Mod.SelectedValue);
                    pnIdMarca = Convert.ToInt32(cboBuscarXMarca_Mod.SelectedValue);
                    pcBuscar = Convert.ToString(txtBuscarModelo.Text);
                }
                else if (tabIndex==3)
                {
                    pnIdClase = Convert.ToInt32(cboBuscarXclaseUSO.SelectedValue);
                    pnIdMarca = 0;
                    pcBuscar = Convert.ToString(txtbuscarU.Text);
                }


                dtResultados = objAttrV.blBuscarDatosParadatatables(tabIndex,pnIdClase,pnIdMarca, pcBuscar, pagina, tipoConPagina);
                //dgMarca.Rows.Clear();
                DataTable dt = new DataTable();
                Int32 totalResultados = dtResultados.Rows.Count;
                if (totalResultados > 0)
                {
                    if (tabIndex==0)
                    {
                        dt.Clear();
                        dt.Columns.Add("ID");
                        dt.Columns.Add("N°");
                        dt.Columns.Add("CLASE");
                        dt.Columns.Add("ESTADO");
                        dt.Columns.Add("C/S-PLACA");

                    }else if (tabIndex == 1)
                    {
                        dt.Clear();
                        dt.Columns.Add("ID");
                        dt.Columns.Add("N°");
                        dt.Columns.Add("CLASE");
                        dt.Columns.Add("MARCA");
                        dt.Columns.Add("ESTADO");
                    }
                    else if (tabIndex == 2)
                    {
                        dt.Clear();
                        dt.Columns.Add("ID");
                        dt.Columns.Add("N°");
                        dt.Columns.Add("CLASE");
                        dt.Columns.Add("MARCA");
                        dt.Columns.Add("MODELO");
                        dt.Columns.Add("ESTADO");
                    }
                    else if (tabIndex == 3)
                    {
                        dt.Clear();
                        dt.Columns.Add("ID");
                        dt.Columns.Add("N°");
                        dt.Columns.Add("CLASE");
                        dt.Columns.Add("USO");
                        dt.Columns.Add("ESTADO");
                    }
                    fnAgregarDatosDeBusqueda(tipoConPagina,pagina, filas, dtResultados,dt,totalResultados, tabIndex);
                    if (tabIndex == 0) 
                    { 
                        dgClase.Columns[0].Visible = false;
                    } else if (tabIndex == 1) 
                    { 
                        dgMarca.Columns[0].Visible = false; 
                    } else if (tabIndex == 2) 
                    { 
                        dgModelo.Columns[0].Visible = false; 
                    }
                    else if (tabIndex == 3)
                    {
                        dgvUso.Columns[0].Visible = false;
                        //fnActivarDtG_GrB(dgvUso, gbPaginacionUso, true);
                    }



                }
                else
                {
                    dt.Clear();
                    dt.Columns.Add("NO SE ENCONTRARON DATOS PARA LA BUSQUEDA");
                    if (tabIndex == 0) { dgClase.Visible = true;dgClase.DataSource = dt; gbPaginasC.Visible = false; } else if (tabIndex == 1) { dgMarca.Visible = true; dgMarca.DataSource = dt; gbPaginacionMarc.Visible = false; } else if (tabIndex == 2) { dgModelo.Visible = true; dgModelo.DataSource = dt; gbPaginacioMod.Visible = false; } else if (tabIndex==3) { dgvUso.Visible = true;dgvUso.DataSource = dt;gbPaginacionUso.Visible = false; }
                    
                    
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAttrVehiculo", "fnBuscarMarcaV", ex.Message);
                return false;
            }

        }
        private Boolean fnListarClaseEspecifica(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                if (dgClase.Rows.Count > 0)
                {
                    BLAttrVehiculo objChip = new BLAttrVehiculo();
                    ClaseVehiculo lstClase = new ClaseVehiculo();
                    DataTable dtEquipo = new DataTable();
                    lstClase = objChip.blListarClaseEspecifica(Convert.ToInt32(dgClase.Rows[e.RowIndex].Cells[0].Value));

                    if (lstClase.idClase > 0)
                    {
                        lnTipoCon = 1;
                        txtCodClase.Text = Convert.ToString(lstClase.idClase);
                        txtClase2.Text= Convert.ToString(lstClase.cNomClase);
                        txtClase.Text = Convert.ToString(lstClase.cNomClase);
                        swEstadoClase.Checked = Convert.ToBoolean(lstClase.bEstado);
                        swConPlaca.Checked = Convert.ToBoolean(lstClase.bConPlaca);

                        dgClase.Visible = false;
                        gbPaginasC.Visible = false;

                        fnActivarControles(gbInfoClase, false);
                        FunValidaciones.fnHabilitarBoton(btnEditar, true);
                        FunValidaciones.fnHabilitarBoton(btnNuevo, true);
                        

                        txtBuscarClase.Text = "";
                       
                    }
                    else 
                    {
                        
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
        private void dgClase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fnListarClaseEspecifica(e);
        }

        private void dgModelo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fnListarModeloEspcifico(e);
        }

        private void fnActivarControles( GunaGroupBox SgroupBox,Boolean estado)
        {
            SgroupBox.Enabled = estado;
        }

        private void fnActivarControlesUso(SiticoneGroupBox sGroupBox , Boolean estado)
        {
            sGroupBox.Enabled = estado;
        }


        private void fnLimpiarControles()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                txtBuscarClase.Text = "";
                swEstadoClase.Checked = true;
                swConPlaca.Checked = true;
                txtCodClase.Text = "0";
                txtClase.Text = "";
                fnActivarDtG_GrB(dgClase, gbPaginasC, false);

            }
            else if (tabControl1.SelectedIndex == 1)
            {
                txtBuscarMarca.Text = "";
                cboClaseV.SelectedValue = 0;
                txtMarca.Text = "";
                txtMarca2.Text = "";
                swEstadoMarca.Checked = true;
                txtCodMarca.Text = "0";
                fnActivarDtG_GrB(dgMarca, gbPaginacionMarc, false);

            }
            else if (tabControl1.SelectedIndex == 2)
            {
                txtBuscarModelo.Text = "";
                cboBuscarXMarca_Mod.SelectedValue = 0;
                cboClaseMod.SelectedValue = 0;
                cboMarcaMod.SelectedValue = 0;
                txtModelo.Text = "";
                txtModelo2.Text = "";
                txtCodModelo.Text = "0";
                swEstadoMadelo.Checked = true;
                fnActivarDtG_GrB(dgModelo, gbPaginacioMod, false);
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                txtbuscarU.Text = "";
                cboBuscarClaseV.SelectedValue = 0;
                txtUso.Text = "";
                txtUso2.Text = "";
                swEstadoUso.Checked = true;
                txtCodU.Text = "0";
                fnActivarDtG_GrB(dgvUso, gbPaginacionUso, false);
            }

            lnTipoCon = 0;
        }
        private void btnEditarMod_Click(object sender, EventArgs e)
        {
            fnActivarControles(gbInfoModelo, true);
            FunValidaciones.fnHabilitarBoton(btnEditarMod,false);
        }

        private void btnEditarMarc_Click(object sender, EventArgs e)
        {
            fnActivarControles(gbInfoMarca, true);
            FunValidaciones.fnHabilitarBoton(btnEditarMarc, false);          
        
        }

      

        private void btnEditar_Click(object sender, EventArgs e)
        {
            fnActivarControles(gbInfoClase, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
        }

        private void btnNuevoMod_Click(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnActivarControles(gbInfoModelo, true);
        }

        private void cboClaseV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            var result = FunValidaciones.fnValidarCombobox(cboClaseV,lblCboClaseMarc,pbClaseVMarc);
            estCboClaseMarc = result.Item1;
            msjCboClaseMarc = result.Item2;

            txtMarca_TextChanged(sender, e);
            if (estMarca == true) { FunValidaciones.fnHabilitarBoton(btnGuardarMarc, true); } else { FunValidaciones.fnHabilitarBoton(btnGuardarMarc, false); }
        }

        private void cboMarcaMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Result = FunValidaciones.fnValidarCombobox(cboMarcaMod, lblMsgMarcaMod, pbMarcaMod);
            estMarcaMod = Result.Item1;
            msjMarcaMod = Result.Item2;
            txtModelo_TextChanged( sender,  e);
        }

        private String fnGuardarClase(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLAttrVehiculo objAttrV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            ClaseVehiculo objClase = new ClaseVehiculo();
            //Boolean bCargar = false;

            try
            {
                objClase.idClase = Convert.ToInt32(txtCodClase.Text);
                objClase.cNomClase = Convert.ToString(txtClase.Text.Trim());
                //objClase.idClase = Convert.ToInt32(cboClaseV.SelectedValue);
                objClase.bEstado = Convert.ToBoolean(swEstadoClase.Checked);
                objClase.bConPlaca = Convert.ToBoolean(swConPlaca.Checked);
                objClase.dFechaReg = dFechaSis;
                objClase.idUsuario = Variables.gnCodUser;

                lcValidar = objAttrV.blGrabarClase(objClase, idTipoCon).Trim();
                fnLimpiarControles();
                fnHabilitarControles(false, 0);
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
            BLAttrVehiculo objAttrV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            ModeloVehiculo objModelo = new ModeloVehiculo();
            //Boolean bCargar = false;
            try
            {
                objModelo.idModelo = Convert.ToInt32(txtCodModelo.Text);
                objModelo.cNomModelo = Convert.ToString(txtModelo.Text.Trim());
                objModelo.bEstado = Convert.ToBoolean(swEstadoMadelo.Checked);
                objModelo.idMarca = Convert.ToInt32(cboMarcaMod.SelectedValue);
                objModelo.dFechaReg = dFechaSis;
                objModelo.idUsuario = Variables.gnCodUser;

                lcValidar = objAttrV.blGrabarModelo(objModelo, idTipoCon).Trim();
                fnLimpiarControles();
                fnActivarControles(gbInfoModelo,false);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarAttrVehiculo", "fnGuardarModelo", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }
        private void btnGuardarMod_Click(object sender, EventArgs e)
        {
            String lcResultado = "";
            var Result1 = FunValidaciones.fnValidarCombobox(cboClaseMod, lblMsgClaseMod, pbClaseMod);
            estClaseMod = Result1.Item1;
            msjClaseMod = Result1.Item2;
            var Result2 = FunValidaciones.fnValidarCombobox(cboMarcaMod, lblMsgMarcaMod, pbMarcaMod);
            estMarcaMod = Result2.Item1;
            msjMarcaMod = Result2.Item2;
            txtModelo_TextChanged(sender, e);

            if (estClaseMod == true && estMarcaMod == true && estModelo == true)
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
                MessageBox.Show("Complete todos los campos Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        public Tuple<Boolean, String> fnValidaDatosDuplicados(SiticoneTextBox txt, Label lbl, PictureBox img, String msj)
        {
            
                img.Image = Properties.Resources.error;
                lbl.Text = msj;
                lbl.ForeColor = Variables.ColorError;
                txt.FocusedState.BorderColor = Variables.ColorError;
                return Tuple.Create(false, msj);

        }

        private void dgClase_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {

        }

        private void txtModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);
        }

        private void txtClase_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);
        }

        private void siticoneGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneLabel1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneLabel2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {

            Int32 ValidarUso = fnValidarUsoExistente(txtUso.Text.Trim(), txtUso2.Text.Trim(), Convert.ToInt16(cboBuscarClaseV.SelectedValue), lnTipoCon);

            if (ValidarUso == 1)
            {
                var resultExistencia = fnValidaDatosDuplicados(txtUso, lblUsoVUso, pbUsoVUso, "Esta marca ya existe\nverifique su clase ó ingrese otra Marca");
                estUso = resultExistencia.Item1;
                msjUso = resultExistencia.Item2;
                MessageBox.Show("Esta marca ya existe verifique su clase ó ingrese otra Marca", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                var Result = FunValidaciones.fnValidarTexboxs(txtUso, lblUsoVUso, pbUsoVUso, true, true, true, 3, 50, 50, 50, "LLENE TODOS LOS CAMPOS");
                estUso = Result.Item1;
                msjUso = Result.Item2;
            }

            if (estUso == true) { FunValidaciones.fnHabilitarBoton(btnGuardarU, true); } else { FunValidaciones.fnHabilitarBoton(btnGuardarU, false); }


        }
        

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            //cboBuscarClaseV_selectIndexChanged (sender, e)
            //txtUso_textchanged (sender,e)
            siticoneTextBox1_TextChanged(sender, e);
            string lcresultado = "";
            estCboClaseUso = true;
            estUs = true;
            if (estCboClaseUso == true && estUs == true)
            {
                lcresultado = fnGrabarUso(lnTipoCon);
                if (lcresultado == "ok")
                {
                    if (lnTipoCon == 0)
                    {
                        MessageBox.Show("SE REGISTRO CORRECTAMENTE", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("SE ACTUALIZO CORRECTAMENTE", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (lnTipoCon == 0)
                    {
                        MessageBox.Show("NO SE REGISTRO", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    else
                    {
                        MessageBox.Show("NO SE PUDO REGISTRAR", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        private String fnGrabarUso(Int16 lnTipoCon)
        {
           

            DateTime dfechaSis = Variables.gdFechaSis;
            BLAttrVehiculo objAttrV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            string lcValidar = "";
            ModUsoVehiculo objUso = new ModUsoVehiculo();

            try
            {
                objUso.idUso = Convert.ToInt32(txtCodU.Text);
                objUso.cUso = Convert.ToString(txtUso.Text.Trim());
                objUso.bEstado = Convert.ToBoolean(swEstadoUso.Checked);
                objUso.idUsuario = Variables.gnCodUser;
                objUso.idClase = Convert.ToInt32(cboBuscarClaseV.SelectedValue);

                lcValidar = objAttrV.blGrabarUso( objUso, lnTipoCon);

                return "ok";

            }
            catch (Exception ex)
            {
                return "";
            }
           





        }
        private void siticoneLabel8_Click(object sender, EventArgs e)
        {

        }

        private void siticoneLabel9_Click(object sender, EventArgs e)
        {

        }

        private void siticoneGradientCircleButton3_Click(object sender, EventArgs e)
        {

        }

        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneCirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void cboBuscarC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CargoForm == true)
            {
                fnBuscarDatosParaDatatables(0, -1);
            }
        }

        private void siticoneCircleButton1_Click(object sender, EventArgs e)
        {
            if (CargoForm == true)
            {
                fnBuscarDatosParaDatatables(0, -1);
            }
        }

        private void siticoneGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtbuscarU_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);
            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarDatosParaDatatables(0, -1);
            }
        }

     
        private void dgvUso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lnTipoLlamada == 0)
            {
                Boolean bresul = false;

                bresul = fnListarUsoEspecifico(e);
                FunValidaciones.fnHabilitarBoton(btnGuardarU, false);
            }
          
        }

        private Boolean fnListarUsoEspecifico(DataGridViewCellEventArgs dtRows)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                if (dgvUso.Rows.Count > 0)
                {
                   
                    BLAttrVehiculo objUso = new BLAttrVehiculo();
                    DataTable mrcVehiculo = new DataTable();
                    DataTable dtUso = new DataTable();

                    mrcVehiculo = objUso.blListarUsoEspecifico(Convert.ToInt32(dgvUso.Rows[dtRows.RowIndex].Cells[0].Value));


                    lnTipoCon = 1;
                    foreach (DataRow dr in mrcVehiculo.Rows)
                    {
                        txtCodU.Text = Convert.ToString(dr["idUsoV"]);
                        txtUso.Text = Convert.ToString(dr["cUsoV"]);
                        txtUso2.Text = Convert.ToString(dr["cUsoV"]);
                        cboBuscarClaseV.SelectedValue = Convert.ToInt32(dr["idClaseV"]);
                        swEstadoUso.Checked = Convert.ToBoolean(dr["bEstado"]);

                    }
                    fnActivarDtG_GrB(dgvUso, gbPaginacionUso, false);
                    fnActivarControlesUso(gbInfoUso, false);


                    FunValidaciones.fnHabilitarBoton(btnEditarU, true);
                    FunValidaciones.fnHabilitarBoton(btnNuevoU, true);


                    if (estUso == true)
                    {
                        FunValidaciones.fnHabilitarBoton(btnGuardarU, true);
                    }
                    else
                    {
                        FunValidaciones.fnHabilitarBoton(btnGuardarU, false);
                        
                    }    

                }

                return true;

            }catch(Exception ex)
            {
                return false;
            }



                }

        private void lblMarcaVMarc_Click(object sender, EventArgs e)
        {

        }

        private void pbClaseVMarc_Click(object sender, EventArgs e)
        {

        }

        private void swEstadoMarca_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtUso_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);
        }





        private void btnNuevoU_CLick(object sender, EventArgs e)
        {

            fnLimpiarControles();
            fnActivarControlesUso(gbInfoUso, true);



        }

        private void swEstadoUso_CheckedChanged(object sender, EventArgs e)
        {

        }

       

        private void btnTotalPaginasMarc_Click(object sender, EventArgs e)
        {

        }

        private void dgMarca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscarMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void gbInfoMarca_Click(object sender, EventArgs e)
        {

        }

        private void btnEditarU_Click_1(object sender, EventArgs e)
        {
            fnActivarControlesUso(gbInfoUso, true);
            FunValidaciones.fnHabilitarBoton(btnEditarU, false);
            FunValidaciones.fnHabilitarBoton(btnGuardarU, true);


        }

        private void lblUsoVUso_Click(object sender, EventArgs e)
        {

        }

        private void txtbuscarU_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboBuscarClaseV_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboBuscarClaseV, lblCboClaseUso, pbCboClaseUso);
            estCboClaseUso = result.Item1;
            msjCboClaseUso = result.Item2;

            siticoneTextBox1_TextChanged(sender, e);
            if (estUso == true) { FunValidaciones.fnHabilitarBoton(btnGuardarU, true); } else { FunValidaciones.fnHabilitarBoton(btnGuardarU, false);  }
               
        




    }

        private Int32 fnValidarModeloExistente(String txtModelo, String txtModelo2, Int16 idClase, Int16 idMarca, Int16 pnTipoCon)
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
        private void txtModelo_TextChanged(object sender, EventArgs e)
       {
          
                Int32 ValidaModelo = fnValidarModeloExistente(txtModelo.Text.Trim(), txtModelo2.Text.Trim(), Convert.ToInt16(cboClaseMod.SelectedValue), Convert.ToInt16(cboMarcaMod.SelectedValue), lnTipoCon);

                if (ValidaModelo == 1)
                {
                    var resultExistencia = fnValidaDatosDuplicados(txtModelo, lblMsgModelo, pbModeloV, "Este modelo ya existe ( Verifique Clase Ó Marca )\n de lo contario ingrese otro Modelo");
                    estModelo = resultExistencia.Item1;
                    msjModelo = resultExistencia.Item2;
                    MessageBox.Show("Esta Modelo ya existe ( Verifique Clase Ó Marca )\n de lo contario ingrese otro Modelo", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    var result = FunValidaciones.fnValidarTexboxs(txtModelo, lblMsgModelo, pbModeloV,true,true,true,2,100,100,100,"Ingrese correctamente Modelo" );
                    estModelo = result.Item1;
                    msjModelo = result.Item2;
                }
            if (estModelo == true) { FunValidaciones.fnHabilitarBoton(btnGuardarMod, true); } else { FunValidaciones.fnHabilitarBoton(btnGuardarMod, false); }
        }

        private void txtClase_TextChanged(object sender, EventArgs e)
        {
            Int32 Existencia = FunGeneral.fnValidarDatosExistentes(txtClase.Text, txtClase.Text, lnTipoCon, "uspValidarClaseV");
            if (Existencia == 1)
            {
                var result = fnValidaDatosDuplicados(txtClase,lblMsgTxtClase, pbTxtClase,"Esta clase ya existe =>Ingrese una distinta");
                estTxtClase = result.Item1;
                msgTxtClase = result.Item2;
            }
            else { 
               var result= FunValidaciones.fnValidarTexboxs(txtClase, lblMsgTxtClase,pbTxtClase,true,true,true,3,100,100,100,"Ingrese correctamente la clase:") ;
                estTxtClase = result.Item1;
                msgTxtClase = result.Item2;
            }

            if (estTxtClase==true){FunValidaciones.fnHabilitarBoton(btnGuardar, true);}else{FunValidaciones.fnHabilitarBoton(btnGuardar, false);}
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            txtClase_TextChanged(sender, e);
            if (estTxtClase == true)
            {
                if (Convert.ToBoolean(swEstadoClase.Checked) == false)
                {
                    MessageBox.Show("Esta guardando la clase en estado INACTIVO", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                String result = "";
                result=fnGuardarClase(lnTipoCon);
                if (result=="OK")
                {
                    MessageBox.Show("Clase Gruardada Correctamente", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error en el registro -> comunique al administrador", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            else
            {
                MessageBox.Show("Porfavor complete todo los campos!", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnActivarControles(gbInfoClase, true);
        }

        private Boolean fnBuscarMarcaV(Int32 pagina, Int32 tipoConPagina)
        {
            BLAttrVehiculo objAttrV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            DataTable dtMarcaV = new DataTable();
            Int32 filas = 15;
            try
            {

                Int32 pnIdClase = Convert.ToInt32(cboBuscarXCLaseMarc.SelectedValue);

                String pcBuscar = Convert.ToString(txtBuscarMarca.Text);

                dtMarcaV = objAttrV.blBuscarMarcaV(pnIdClase, pcBuscar, pagina,tipoConPagina);
                //dgMarca.Rows.Clear();
                DataTable dt = new DataTable();
                Int32 totalResultados = dtMarcaV.Rows.Count;
                if (totalResultados > 0)
                {
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("SIMCARD");
                    dt.Columns.Add("OPERADOR");
                    dt.Columns.Add("N° DE CUENTA");

                    Int32 y;
                    if (tipoConPagina == -1)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (pagina - 1) * filas;
                        y = tabInicio;
                    }

                    for (int i = 0; i <= totalResultados - 1; i++)
                    {
                        
                       object[] dRow = {dtMarcaV.Rows[i][0],
                                        dtMarcaV.Rows[i][1],
                                        dtMarcaV.Rows[i][2],
                                        dtMarcaV.Rows[i][3],};

                        dt.Rows.Add(dRow);
                    }
                    dgMarca.DataSource = dt;
                    dgMarca.Visible = true;
                    if (tipoConPagina == -1)
                    {
                        Int32 totalRegistros = Convert.ToInt32(dtMarcaV.Rows[0][4]);
                        gbPaginacionMarc.Visible = true;
                        fnCalcularPaginacion(totalRegistros, filas, totalResultados,cboPaginacionMarc, btnTotalPaginasMarc, btnRegistrosMarc,btnTotalRegistrosMarc);
                    }
                }
                else
                {
                    gbPaginacionMarc.Visible = false;
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAttrVehiculo", "fnBuscarMarcaV", ex.Message);
                return false;
            }
        }

        private void fnCalcularPaginacion(Int32 totalRegistros, Int32 filas, Int32 totalResultados,SiticoneComboBox cboPaginacion,SiticoneCircleButton btnNumPagina, SiticoneCircleButton btnRegistros, SiticoneCircleButton btnTotalRegistros)
        {
            Int32 residuo;
            Int32 cantidadPaginas;
            residuo = totalRegistros % filas;
            if (residuo == 0)
            {
                cantidadPaginas = (totalRegistros / filas);
            }
            else
            {
                cantidadPaginas = (totalRegistros / filas) + 1;
            }

           
                cboPaginacion.Items.Clear();

                for (Int32 i = 1; i <= cantidadPaginas; i++)
                {
                    cboPaginacion.Items.Add(i);

                }

                btnNumPagina.Text = Convert.ToString(cantidadPaginas);
                btnRegistros.Text = Convert.ToString(totalResultados);
                btnTotalRegistros.Text = Convert.ToString(totalRegistros);
                cboPaginacion.SelectedIndex = 0;
        }
        private void btnNuevoMarc_Click(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnActivarControles(gbInfoMarca, true);
        }

        
        private void cboClaseV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CargoForm == true)
            {
                fnBuscarDatosParaDatatables(0, -1);
            }
            //FunValidaciones.fnValidarCombobox(cboClaseV, lblCboClaseMarc, pbClaseVMarc);
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);
        }

        
        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            
                Int32 ValidaMarca = fnValidarMarcaExistente(txtMarca.Text.Trim(), txtMarca2.Text.Trim(), Convert.ToInt16(cboClaseV.SelectedValue), lnTipoCon);

                if (ValidaMarca == 1)
                {
                    var resultExistencia = fnValidaDatosDuplicados(txtMarca, lblMarcaVMarc, pbMarcaVMarc, "Esta marca ya existe\nverifique su clase ó ingrese otra Marca");
                    estMarca = resultExistencia.Item1;
                    msjMarca = resultExistencia.Item2;
                    MessageBox.Show("Esta marca ya existe verifique su clase ó ingrese otra Marca", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    var result = fnValidarTexbox(txtMarca, lblMarcaVMarc, pbMarcaVMarc, false, 0, true);
                    estMarca = result.Item1;
                    msjMarca = result.Item2;
                }
            if (estMarca == true) { FunValidaciones.fnHabilitarBoton(btnGuardarMarc, true); } else { FunValidaciones.fnHabilitarBoton(btnGuardarMarc, false); }
        }

       
        //public Tuple<Boolean, String> fnValidaDatosDuplicados(SiticoneTextBox txt, Label lbl, PictureBox img, Boolean Obligatorio, Boolean Existencia)
        //{
        //    Boolean estad;
        //    String msj;
        //    if (Existencia == true)
        //    {
        //        img.Image = Properties.Resources.error;
        //        msj = "Esta marca ya existe\n( Verifique su clase ó ingrese otra Marca )";

        //        lbl.Text = msj;
        //        estad = false;
        //        return Tuple.Create(estad, msj);

        //    }
        //    else
        //    {
        //        img.Image = Properties.Resources.ok;
        //        msj = "";
        //        lbl.Text = msj;
        //        estad = true;
        //        return Tuple.Create(estad, msj);
        //    }
        //}

        private Tuple<Boolean, String> fnValidarTexbox(SiticoneTextBox txt, Label lbl, PictureBox img, Boolean maximo, Int32 num, Boolean Obligatorio)
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
        private void fnCargarComboBusqXPlaca()
        {
            var Valores = new List<ComboExistenciaMarca>();
            Valores.Add(new ComboExistenciaMarca() { Index = "-1", Value = "Todos" });
            Valores.Add(new ComboExistenciaMarca() { Index = "1", Value = "VEHICULOS CON PLACA" });
            Valores.Add(new ComboExistenciaMarca() { Index = "0", Value = "VEHICULOS SIN PLACA" });

            cboBuscarXClase.DataSource = Valores;
            cboBuscarXClase.DisplayMember = "Value";
            cboBuscarXClase.ValueMember = "Index";
        }
        private void frmAttrVehiculo_Load(object sender, EventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            CargoForm = false;
            try
            {
                FunValidaciones.fnColorTresBotones(btnNuevo,btnEditar,btnGuardar);
                FunValidaciones.fnColorTresBotones(btnNuevoMarc, btnEditarMarc, btnGuardarMarc);
                FunValidaciones.fnColorTresBotones(btnNuevoMod, btnEditarMod, btnGuardarMod);
                FunValidaciones.fnColorTresBotones(btnNuevoU, btnEditarU, btnGuardarU);

                fnActivarControles(gbInfoClase, false);
                fnActivarControles(gbInfoMarca, false);
                fnActivarControles(gbInfoModelo, false);
                fnActivarControlesUso(gbInfoUso, false);

                FunValidaciones.fnHabilitarBoton(btnGuardar,false);
                FunValidaciones.fnHabilitarBoton(btnGuardarMarc, false);
                FunValidaciones.fnHabilitarBoton(btnGuardarMod, false);

                FunValidaciones.fnHabilitarBoton(btnEditar, false);
                FunValidaciones.fnHabilitarBoton(btnEditarMarc, false);
                FunValidaciones.fnHabilitarBoton(btnEditarMod, false);
                fnCargarComboBusqXPlaca();

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarClaseVehiculo", ex.Message);
                //return false;
            }
            finally
            {
                CargoForm = true;
                //lstClase = null;
            }
        }
        private Boolean fnLLenarClaseVehiculo(SiticoneComboBox cbo, Boolean estado)
        {
            BLAttrVehiculo objClaseV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            List<ClaseVehiculo> lstClase = new List<ClaseVehiculo>();

            try
            {
                lstClase = objClaseV.blDevolverClaseVehiculo(0, estado, lnTipoCon);
                cbo.ValueMember = "idClase";
                cbo.DisplayMember = "cNomClase";
                cbo.DataSource = lstClase;

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

        private Int32 fnValidarUsoExistente(String txtUso, String txtUso2, Int16 idClase, Int16 pnTipoCon)
        {
            BLAttrVehiculo objUsoV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            Int32 validarUso = 0;

            try
            {
                validarUso = objUsoV.blDevolverValidarUsoExistente(txtUso, txtUso2, idClase, pnTipoCon);

                return validarUso;

            }
            catch(Exception ex)
            {

                return 0;
            }
            finally
            {
            }
        }
        
        private void fnHabilitarControles(Boolean pbHabilitar, Int16 pnTipoTab)
        {
            if (pnTipoTab == 1)
            {
                gbInfoMarca.Enabled = pbHabilitar;
                btnGuardarMarc.Enabled = pbHabilitar;
            }
            else if (pnTipoTab == 2)
            {
                gbInfoMarca.Enabled = pbHabilitar;
                btnGuardarMarc.Enabled = pbHabilitar;

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
                objMarca.bEstado = Convert.ToBoolean(swEstadoMarca.Checked);
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

        private void btnGuardarMarc_Click(object sender, EventArgs e)
        {
            cboClaseV_SelectedIndexChanged_1( sender,  e);
            txtMarca_TextChanged( sender,  e);
            String lcResultado = "";

            if (estCboClaseMarc == true && estMarca == true)
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
    }
}
