using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmRegistrarEquipo : Form
    {
        public frmRegistrarEquipo()
        {
            pasoLoad = false;
            InitializeComponent();
            Boolean bResult = false;
            bResult = fnLlenarCategoria(1,cboBuscarCategoria, true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Categoria", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = fnLlenarCategoria(lnTipoCon,cboCategoria, false);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Categoria", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            fnHabilitarGroupBoxs(false);

            cboBuscarEstado.SelectedIndex = 0;
            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            FunValidaciones.fnColorBotones(btnNuevo, btnEditar, btnGuardar, btnSalir);
            fnLimpiarControles();
            fnVerAnadirAccesorio(false,false);
            pasoLoad = true;
        }

        Boolean pasoLoad;
        Int32 lnTipoLlamada = 0;
        Int16 lnTipoCon = 0;
        Boolean estActualizar;
        static Int32 tabInicio;
        Boolean estCategoria, estMarca, estModelo, estNombre, estPrecio, estAccesorios, estObservaciones;
        String msjCategoria, msjMarca, msjModelo, msjNombre, msjPrecio, msjAccesorios, msjObservaciones;

        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();
        }

        private void fnVerAnadirAccesorio(Boolean chkestado,Boolean btnEstado)
        {
            chkAnadir.Visible = chkestado;
            chkAnadir.Checked = false;
            btnAnadir.Visible = btnEstado;
        }
        private void fnVerValidacion(Boolean estado)
        {
            /////TEXBOXS/////
            erCategoria.Visible = estado;
            erMarca.Visible = estado;
            erModelo.Visible = estado;
            erNombre.Visible = estado;
            erPrecio.Visible = estado;
            erAccesorios.Visible = estado;
            erObservaciones.Visible = estado;
            /////PICTUREBOXS////
            imgCategoria.Visible = estado;
            imgMarca.Visible = estado;
            imgModelo.Visible = estado;
            imgNombre.Visible = estado;
            imgPrecio.Visible = estado;
            imgAccesorios.Visible = estado;
            imgObservaciones.Visible = estado;

        }

        private void fnHabilitarGroupBoxs(Boolean pbAccesorio)
        {
            gbEquipo.Enabled = pbAccesorio;
        }

        public void fnLimpiarListaChecks()
        {
            for (Int32 i = 0; i < chkListaAccesorios.Items.Count; i++)
            {
                chkListaAccesorios.SetItemChecked(i, false);
            }
        }

        private void fnLimpiarControles()
        {
            
            fnVerAnadirAccesorio(false, false);
            lnTipoCon = 0;
            fnLlenarCategoria(lnTipoCon, cboCategoria, false);
            

            /////TEXBOXS/////
            txtCodigo.Text = "0";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtObservaciones.Text = "";
            txtPrecio.Text = "";
            txtBuscar.Text = "";
            txtActualizar.Text = "";

            /////COMBOBOXS/////
            cboCategoria.SelectedValue = 1;
            cboMarca.SelectedValue = 0;
            cboModelo.SelectedValue = 0;

            ////LABELS//// 
            
            erCategoria.Text = "";
            erMarca.Text = "";
            erModelo.Text = "";
            erNombre.Text = "";
            erPrecio.Text = "";
            erAccesorios.Text = "";
            erObservaciones.Text = "";
            
            ////CHEKSBOXS/////
            chkEstado.Checked = true;
            chkSinAccesorios.Checked = false;

            ////PICTUREBOXS////
            imgCategoria.Image = null;
            imgMarca.Image = null;
            imgModelo.Image = null;
            imgNombre.Image = null;
            imgPrecio.Image = null;
            imgAccesorios.Image = null;
            imgObservaciones.Image = null;

     
            ////LISTBOXS/////
            dgEquipo.Visible = false;

           

            txtBuscar.Focus();
            lnTipoCon = 0;

        }

        private void cboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModelo.SelectedValue == null || cboModelo.SelectedValue.ToString() == "0")
            {

                txtNombre.Enabled = false;

                txtNombre.Text = "";

            }
            else
            {
                txtNombre.Enabled = true;
                txtNombre.Text = "";

            }
            var result = FunValidaciones.fnValidarCombobox(cboModelo, erModelo, imgModelo);
            estModelo = result.Item1;
            msjModelo = result.Item2;

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexboxSQL(txtNombre, erNombre, imgNombre, false, 0);
            estNombre = result.Item1;
            msjNombre = result.Item2;
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
            else if (estActualizar == true)
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
                    bResul = fnBuscarNombreEquipo(txt.Text.Trim(), pnTipocon);
                    return Tuple.Create(bResul, msj);

                }

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                bResul = fnBuscarNombreEquipo(txt.Text.Trim(), pnTipocon);
                return Tuple.Create(bResul, msj);

            }


        }

        private Boolean fnBuscarNombreEquipo(String pcBuscar, Int16 pnTipoCon)
        {
            BLEquipo objAcc = new BLEquipo();
            clsUtil objUtil = new clsUtil();
            Int16 numResult = 0;

            try
            {

                Int32 idCategoria = Convert.ToInt32(cboCategoria.SelectedValue.ToString());
                Int32 idMarca = Convert.ToInt32(cboMarca.SelectedValue.ToString());
                Int32 idModelo = Convert.ToInt32(cboModelo.SelectedValue.ToString());

                numResult = objAcc.blBuscarNombreEquipo(idCategoria,idMarca,idModelo, pcBuscar, pnTipoCon);

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

                objAcc = null;
                objUtil = null;
            }
        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtPrecio,erPrecio,imgPrecio,true,false,true,0,99999,0,6,"Ingrese un campo válido");
            estPrecio = result.Item1;
            msjPrecio = result.Item2;
        }

        private void txtObservaciones_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtObservaciones,erObservaciones,imgObservaciones,false,true,false,3,200,0,200,"Ingrese correctamente el campo");
            estObservaciones = result.Item1;
            msjObservaciones = result.Item2;
        }

        private void chkListaAccesorios_Click(object sender, EventArgs e)
        {
           
            if (lnTipoCon == 1)
            {
                Int32 index = chkListaAccesorios.SelectedIndex;
                CheckState estadoItem = chkListaAccesorios.GetItemCheckState(index);
                if (estadoItem == CheckState.Checked)
                {

                }
                else
                {
                    Boolean estado;
                    Int32 itemSelect = Convert.ToInt32(chkListaAccesorios.SelectedValue.ToString());

                    estado = fnValidarEquipoAccesorio(itemSelect, 0);

                    if (estado)
                    {

                    }
                    else
                    {
                        String AccesorioSelected = chkListaAccesorios.Text.ToString();
                        DialogResult pregunta = MessageBox.Show("Este ACCESORIO está DESACTIVADO\nPorfavor CAMBIAR el estado del ACCESORIO:\n" + AccesorioSelected, "VALIDACIÓN PLAN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (pregunta == DialogResult.OK)
                        {

                            chkListaAccesorios.SetItemChecked(index, false);
                        }

                    }



                }
            }
            

            
        }

        private Boolean fnValidarEquipoAccesorio(Int32 idPlanAccesorio,Int16 pnTipoCon)
        {
            
            clsUtil objUtil = new clsUtil();
            BLEquipo objPlan = new BLEquipo();
            Boolean estadoTipoPlan;
            try
            {
                estadoTipoPlan = objPlan.blValidarEquipoAccesorio(idPlanAccesorio,pnTipoCon);

                return estadoTipoPlan;
            }
            catch (Exception ex)
            {

                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;


            }
        }

        private void chkSinAccesorios_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSinAccesorios.Checked)
            {
                chkListaAccesorios.Enabled = false;
                fnLimpiarListaChecks();
                chkListaAccesorios_SelectedIndexChanged(sender, e);
            }
            else
            {
                chkListaAccesorios.Enabled = true;
                chkListaAccesorios_SelectedIndexChanged(sender, e);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "DIRECCION", true,erNombre);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "MONEDA", false,erPrecio);
        }

        private Boolean fnLlenarCategoria(Int32 idCategoria, ComboBox combo, Boolean buscar)
        {
            BLEquipo objCate = new BLEquipo();
            clsUtil objUtil = new clsUtil();
            List<CategoriaEquipo> lstcategoria = new List<CategoriaEquipo>();

            try
            {
                lstcategoria = objCate.blDevolverCategoriaEquipo(idCategoria, buscar);
                combo.ValueMember = "idcategoria";
                combo.DisplayMember = "cNomCategoria";
                combo.DataSource = lstcategoria;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        private Boolean fnLlenarMarca( Int32 idMarca, ComboBox combo, Boolean buscar)
        {
            BLEquipo objMarca = new BLEquipo();
            clsUtil objUtil = new clsUtil();
            List<MarcaEquipo> lstMarca = new List<MarcaEquipo>();

            try
            {
                lstMarca = objMarca.blDevolverMarcaEquipo(-1,idMarca, buscar);
                combo.ValueMember = "idMarca";
                combo.DisplayMember = "cNomMarca";
                combo.DataSource = lstMarca;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }
        private Boolean fnLlenarModelo(Int32 idModelo, ComboBox combo, Boolean buscar)
        {
            BLEquipo objMarca = new BLEquipo();
            clsUtil objUtil = new clsUtil();
            List<ModeloEquipo> lstMarca = new List<ModeloEquipo>();

            try
            {
                lstMarca = objMarca.blDevolverModeloEquipo(idModelo, buscar, -1);
                combo.ValueMember = "idModelo";
                combo.DisplayMember = "cNomModelo";
                combo.DataSource = lstMarca;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (pasoLoad)
                {
                    fnBuscarTabla(dgEquipo, 0, -1);
                }
            }
            
        }

        private Boolean fnBuscarTabla(DataGridView dgv, Int32 numPagina, Int32 tipoCon)
        {
            BLEquipo objPlan = new BLEquipo();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();
            List<Equipo> lstPlan = null;
            Int32 filas = 20;
            String columAccesorio = "";
            Int32 valorCategoria;
            Int32 valorMarca;
            Int32 valorModelo;
            String nombreModelo;
            String tipoBusqueda;
            Int32 totalResultados;
            try
            {

                if (cboBuscarEstado.SelectedIndex == 1)
                {
                    tipoBusqueda ="1";
                }
                else if (cboBuscarEstado.SelectedIndex == 2)
                {
                    tipoBusqueda = "0";
                }
                else
                {
                    tipoBusqueda = "";
                }
                nombreModelo = txtBuscar.Text.Trim();
                valorCategoria = Convert.ToInt32(cboBuscarCategoria.SelectedValue.ToString());
                valorMarca = Convert.ToInt32(cboBuscarMarca.SelectedValue.ToString());
                valorModelo = Convert.ToInt32(cboBuscarModelo.SelectedValue.ToString());
                lstPlan = new List<Equipo>();
                datTipoPlan = objPlan.blBuscarEquipoDataTable(nombreModelo,tipoBusqueda,valorCategoria,valorMarca,valorModelo,numPagina,tipoCon);

                totalResultados = datTipoPlan.Rows.Count;
                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("MARCA");
                    dt.Columns.Add("MODELO");
                    dt.Columns.Add("NOMBRE EQUIPO");
                    dt.Columns.Add("PRECIO");
                    dt.Columns.Add("ACCESORIOS");
                    dt.Columns.Add("ESTADO");

                    Int32 y;

                    if (tipoCon == -1)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (numPagina - 1) * filas;
                        y = tabInicio;
                    }

                    String estado = "";
                    for (int i = 0; i <= totalResultados - 1; i++)
                    {
                        y += 1;
                        String Marca = Convert.ToString(datTipoPlan.Rows[i][1]).Trim();
                        String Modelo = Convert.ToString(datTipoPlan.Rows[i][2]).Trim();

                        if (Convert.ToBoolean(datTipoPlan.Rows[i][6]) == true)
                        {
                            estado = "ACTIVO";
                        }
                        else
                        {
                            estado = "INACTIVO";
                        }
                        String ac = Convert.ToString(datTipoPlan.Rows[i][5]);

                        if (ac == "")
                        {
                            columAccesorio = "SIN ACCESORIOS";
                        }
                        else
                        {
                            columAccesorio = Convert.ToString(datTipoPlan.Rows[i][5]);
                        }

                        String precio = Convert.ToString(Math.Round(Convert.ToDecimal(datTipoPlan.Rows[i][4]), 2));
                        object[] row = { 
                            datTipoPlan.Rows[i][0],
                            y,
                            Marca, 
                            Modelo, 
                            datTipoPlan.Rows[i][3], 
                            precio, 
                            columAccesorio, 
                            estado 
                        };
                        dt.Rows.Add(row);

                    }

                    dgv.DataSource = dt;

                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 40;
                    dgv.Columns[2].Width = 100;
                    dgv.Columns[3].Width = 100;
                    dgv.Columns[4].Width = 100;
                    dgv.Columns[5].Width = 100;
                    dgv.Columns[6].Width = 200;
                    dgv.Columns[7].Width = 100;


                    dgv.Visible = true;

                    if (tipoCon == -1)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datTipoPlan.Rows[0][7]);
                        fnCalcularPaginacion(
                            totalRegistros,
                            filas,
                            totalResultados,
                            cboPagina,
                            btnTotalPaginas,
                            btnNumFilas,
                            btnTotalRegistros
                            );
                    }
                    else
                    {
                        btnNumFilas.Text = Convert.ToString(totalResultados);
                    }
                    return true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dgv.DataSource = dt;
                    dgv.Visible = true;
                    dt.Columns.Add("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS");
                    gbPaginacion.Visible = false;
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }


        private Boolean fnBuscarEquipoHistorial(DataGridView dgv, Int32 numPagina, Int32 tipoCon)
        {
            BLEquipo objPlan = new BLEquipo();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();
            List<Equipo> lstPlan = null;
            Int32 filas = 10;
            String columAccesorio;
            Int32 idEquipo;
            Int32 totalResultados;
           
            try
            {

                idEquipo = Convert.ToInt32(txtCodigo.Text.ToString());
                lstPlan = new List<Equipo>();
                datTipoPlan = objPlan.blBuscarEquipoHistorial(idEquipo, numPagina, tipoCon);

                totalResultados = datTipoPlan.Rows.Count;
                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("FECH. REGISTRO");
                    dt.Columns.Add("MARCA");
                    dt.Columns.Add("MODELO");
                    dt.Columns.Add("NOMBRE EQUIPO");
                    dt.Columns.Add("PRECIO");
                    dt.Columns.Add("ACCESORIOS");
                    dt.Columns.Add("OBSERVACIÓN");
                    dt.Columns.Add("ESTADO");
                    dt.Columns.Add("USUARIO");

                    Int32 y;

                    if (tipoCon == -1)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (numPagina - 1) * filas;
                        y = tabInicio;
                    }

                    String estado = "";
                    String precio;
                    for (int i = 0; i <= totalResultados - 1; i++)
                    {
                        y += 1;
                        precio = Convert.ToString(Math.Round(Convert.ToDecimal(datTipoPlan.Rows[i][5]), 2));
                        columAccesorio = Convert.ToString(datTipoPlan.Rows[i][6]) == "" ? "SIN ACCESORIOS" : Convert.ToString(datTipoPlan.Rows[i][6]);
                        estado = Convert.ToBoolean(datTipoPlan.Rows[i][8]) ? "ACTIVO" : "INACTIVO";

                        object[] row = {
                            datTipoPlan.Rows[i][0],
                            y,
                            datTipoPlan.Rows[i][1],
                            datTipoPlan.Rows[i][2],
                            datTipoPlan.Rows[i][3],
                            datTipoPlan.Rows[i][4],
                            precio,
                            columAccesorio,
                            datTipoPlan.Rows[i][7],
                            estado,
                            datTipoPlan.Rows[i][9]
                        };
                        dt.Rows.Add(row);

                    }
                    dgv.DataSource = dt;

                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 40;
                    dgv.Columns[2].Width = 100;
                    dgv.Columns[3].Width = 80;
                    dgv.Columns[4].Width = 80;
                    dgv.Columns[5].Width = 80;
                    dgv.Columns[6].Width = 70;
                    dgv.Columns[7].Width = 200;
                    dgv.Columns[8].Width = 200;
                    dgv.Columns[9].Width = 70;
                    dgv.Columns[10].Width = 70;

                    dgv.Visible = true;

                    if (tipoCon == -1)
                    {
                        gbPaginacionHistorial.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datTipoPlan.Rows[0][10]);
                        fnCalcularPaginacion(totalRegistros,filas,totalResultados,cboPaginaHistorial,btnTotalPaginasHistorial,btnRegistrosHistorial,btnTotalRegistrosHistorial);
                    }
                    else
                    {
                        btnTotalPaginasHistorial.Text = Convert.ToString(totalResultados);
                    }
                    return true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dgv.DataSource = dt;
                    dgv.Visible = true;
                    dt.Columns.Add("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS");
                    gbPaginacionHistorial.Visible = false;
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }
        private void fnCalcularPaginacion(Int32 totalRegistros, Int32 filas, Int32 totalResultados, ComboBox cboPag, SiticoneCircleButton btnTotPag, SiticoneCircleButton btnNumFil, SiticoneCircleButton btnTotReg)
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

            cboPag.Items.Clear();

            for (Int32 i = 1; i <= cantidadPaginas; i++)
            {
                cboPag.Items.Add(i);

            }

            cboPag.SelectedIndex = 0;
            btnTotPag.Text = Convert.ToString(cantidadPaginas);
            btnNumFil.Text = Convert.ToString(totalResultados);
            btnTotReg.Text = Convert.ToString(totalRegistros);

        }
        private void dgEquipo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        //private Boolean fnRecuperarEquipoEsoecifico(DataGridViewCellEventArgs e)
        //{
        //    clsUtil objUtil = new clsUtil();
        //    try
        //    {

        //        if (dgEquipo.Rows.Count > 0)
        //        {
        //            frmEquipoImeis.fnRecuperarChipEsp(Convert.ToInt32(dgEquipo.Rows[e.RowIndex].Cells[0].Value), Convert.ToString(dgEquipo.Rows[e.RowIndex].Cells[1].Value), Convert.ToString(dgEquipo.Rows[e.RowIndex].Cells[2].Value),1);

        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("frmRegistrarCliente", "fnRecuperarClienteEsp", ex.Message);
        //        return false;
        //    }
        //}

        private void dgEquipo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            estActualizar = true;
            
            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                bResul = fnListarEquipoEspecifico(dgEquipo);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            else if (lnTipoLlamada == 1)
            {

                //Boolean bResul = false;
                //bResul = fnRecuperarEquipoEsoecifico(e);
                //if (!bResul)
                //{
                //    MessageBox.Show("Error al Recuperar Equipo Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                //else
                //{
                //    this.Dispose();
                //}
            }else if (lnTipoLlamada == 3)
            {
                Boolean bResul = false;

                bResul = fnRecuperarEquipo(e);
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar Equipo Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else { 
                    this.Dispose(); 
                }
            }





            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, true);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            fnHabilitarGroupBoxs(false);

            fnVerValidacion(false);
            
        }
        private Boolean fnRecuperarEquipo(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                Int32 idEquipo = Convert.ToInt32(dgEquipo.Rows[e.RowIndex].Cells[0].Value);
                String marca = Convert.ToString(dgEquipo.Rows[e.RowIndex].Cells[2].Value);
                String modelo = Convert.ToString(dgEquipo.Rows[e.RowIndex].Cells[3].Value);
                String nombreEquipo = Convert.ToString(dgEquipo.Rows[e.RowIndex].Cells[4].Value);
                Procesos.frmOrdenCompraEquipos.fnObtenerEquipo(idEquipo, marca, modelo, nombreEquipo);
                
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarProveedor", "fnRecuperarProveedorEsp", ex.Message);
                return false;
            }
        }

        private Boolean fnListarEquipoEspecifico(DataGridView dgv)
        {
            Boolean bResult;
            clsUtil objUtil = new clsUtil();
            List<xmlAccesorio.Item> lstAcce = new List<xmlAccesorio.Item>();
            Int32 idEquipo;
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    BLEquipo objPlan = new BLEquipo();
                    Equipo lstEquipo = new Equipo();
                    DataTable dtAccesorio = new DataTable();
                    idEquipo = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value.ToString());

                    lstEquipo = objPlan.blListarPlanDataGrid(idEquipo);
                    lnTipoCon = 1;
                    fnLlenarCategoria(lnTipoCon, cboCategoria, false);
                    txtActualizar.Text = Convert.ToString(lstEquipo.cNombre.ToString().Trim());
                    txtCodigo.Text = Convert.ToString(lstEquipo.idEquipo.ToString().Trim());
                    cboCategoria.SelectedValue = lstEquipo.idCategoria;
                    cboMarca.SelectedValue = lstEquipo.idMarcaEquipo;
                    cboModelo.SelectedValue = lstEquipo.idModeloEquipo;
                    txtNombre.Text = Convert.ToString(lstEquipo.cNombre.ToString().Trim());
                    txtPrecio.Text = Convert.ToString(Math.Round(lstEquipo.cPrecio, 2));
                     

                    bResult = fnListarAccesorios(lstEquipo.accesorios);

                    if (!bResult)
                    {
                        MessageBox.Show("Error al listar Accesorios", "Accesorios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    Int32 numChek = chkListaAccesorios.CheckedItems.Count;

                    if (numChek == 0)
                    {
                        chkSinAccesorios.Checked = true;
                    }

                    txtObservaciones.Text = Convert.ToString(lstEquipo.cObservacion.ToString().Trim());
                    chkEstado.Checked = lstEquipo.bEstado;

                    
                    dgv.Visible = false;
                    fnHabilitarGroupBoxs(false);
                    fnVerValidacion(false);
                    FunValidaciones.fnHabilitarBoton(btnNuevo, true);
                    FunValidaciones.fnHabilitarBoton(btnEditar, true);
                    FunValidaciones.fnHabilitarBoton(btnGuardar, false);
                    FunValidaciones.fnHabilitarBoton(btnSalir, true);
                    txtBuscar.Text = "";
                    
                    fnVerAnadirAccesorio(true, false);
                }


                return true;
            }
            catch (Exception ex)
            {

                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;


            }
        }


        private Boolean fnListarAccesorios(String accesorios)
        {
            clsUtil objUtil = new clsUtil();
            xmlAccesorio.Items objAcc = new xmlAccesorio.Items();
            try
            {

                if (accesorios == "")
                {
                    chkListaAccesorios.DataSource = null;
                    return true;
                }
                else
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(xmlAccesorio.Items));
                    using (TextReader reader = new StringReader(accesorios))
                    {
                        //de esta manera se deserializa
                        objAcc = (xmlAccesorio.Items)serializer.Deserialize(reader);
                    }

                    chkListaAccesorios.DataSource = objAcc.Item;
                    chkListaAccesorios.ValueMember = "idEquipoAccesorio";
                    chkListaAccesorios.DisplayMember = "cNombre";

                    Int32 j = 0;
                    for (Int32 i = 0; i <= (objAcc.Item.Count - 1); i++)
                    {

                        chkListaAccesorios.SetSelected(i, true);

                        Boolean estadoItem = objAcc.Item[i].BEstado;
                        if (estadoItem)
                        {
                            chkListaAccesorios.SetItemChecked(i, true);
                            j += 1;
                        }
                        else
                        {

                        }

                    }
                    if(j == 0)
                    {
                        chkSinAccesorios.Checked = true;
                        chkListaAccesorios.Enabled = false;
                    }
                    else
                    {
                        chkSinAccesorios.Checked = false;
                        chkListaAccesorios.Enabled = true;
                    }
                   
                       
                    return true;
                }
                
            }
            catch(Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;
                
            }
           

            
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            fnVerValidacion(true);
            fnHabilitarGroupBoxs(true);
            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, true);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void chkAnadir_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnadir.Checked)
            {

                chkListaAccesorios.Enabled = true;
                chkAnadir.BackColor = Color.FromArgb(242, 68, 29);
                chkAnadir.ForeColor = Color.White;
                fnObtenerAccesorios(Convert.ToInt32(txtCodigo.Text.ToString()), -2);
                btnAnadir.Visible = true;
                chkSinAccesorios.Visible = false;
                FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            }
            else
            {
                chkAnadir.BackColor = Color.White;
                chkAnadir.ForeColor = Color.FromArgb(64, 64, 64);
                fnVerAnadirAccesorio(true, false);
                chkSinAccesorios.Visible = true;
                BLEquipo objEquipo = new BLEquipo();
                Equipo lstEquipo = new Equipo();
                Boolean bResult;

                
                Int32 idEquipo = Convert.ToInt32(txtCodigo.Text.Trim().ToString());
                lstEquipo = objEquipo.blListarPlanDataGrid(idEquipo);

                bResult = fnListarAccesorios(lstEquipo.accesorios);

                if (!bResult)
                {
                    MessageBox.Show("Error al listar Accesorios", "Accesorios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                FunValidaciones.fnHabilitarBoton(btnGuardar, true);
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            BLEquipo objEquipo = new BLEquipo();
            Equipo lstEquipo = new Equipo();
            Boolean bResult;
            Int32 idEquipo = Convert.ToInt32(txtCodigo.Text.Trim().ToString());

            if(chkListaAccesorios.Items.Count == 0 )
            {
                DialogResult resp;
                resp = MessageBox.Show("No tiene ningun accesorio por agregar...\n VOLVER", "frmEquipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(resp == DialogResult.OK)
                {
                    chkAnadir.Checked = false;
                    
                    lstEquipo = objEquipo.blListarPlanDataGrid(idEquipo);
                    
                    bResult = fnListarAccesorios(lstEquipo.accesorios);

                    if (!bResult)
                    {
                        MessageBox.Show("Error al listar Accesorios", "Accesorios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    fnVerAnadirAccesorio(true, false);
                }
            }else if (chkListaAccesorios.CheckedItems.Count == 0)
            {
                DialogResult resp;
                resp = MessageBox.Show("No seleccionó ningun ACCESORIO...\n¿Todavía desea agregar?", "frmEquipo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resp == DialogResult.Yes)
                {
                    chkListaAccesorios.Enabled = true;
                    fnLimpiarListaChecks();
                    fnObtenerAccesorios(Convert.ToInt32(txtCodigo.Text.ToString()), -2);
                    
                }
                else
                {
                    chkAnadir.Checked = false;
                   
                    lstEquipo = objEquipo.blListarPlanDataGrid(idEquipo);

                    bResult = fnListarAccesorios(lstEquipo.accesorios);

                    if (!bResult)
                    {
                        MessageBox.Show("Error al listar Accesorios", "Accesorios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    fnVerAnadirAccesorio(true, false);
                }
            }
            else
            {
                bResult = objEquipo.blGrabarAccesoriosNoAgregados(idEquipo, 0, fnRecorrerAccesorios(1));

                if (!bResult)
                {
                    MessageBox.Show("Error al guardar los Accesorios", "frmEquipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DialogResult resp;
                    resp = MessageBox.Show("Se añadieron los accesorios...\n¿Desea agregar más?", "frmEquipo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (resp == DialogResult.Yes)
                    {

                        chkListaAccesorios.Enabled = true;
                        fnLimpiarListaChecks();
                        fnObtenerAccesorios(Convert.ToInt32(txtCodigo.Text.ToString()), -2);

                    }
                    else if (resp == DialogResult.No)
                    {
                        chkAnadir.Checked = false;
                        lstEquipo = objEquipo.blListarPlanDataGrid(idEquipo);

                        bResult = fnListarAccesorios(lstEquipo.accesorios);

                        if (!bResult)
                        {
                            MessageBox.Show("Error al listar Accesorios", "Accesorios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        fnVerAnadirAccesorio(true, false);

                    }
                }
            }

           
            
        }

        private void txtObservaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void cboBuscarCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResult;

            if (cboCategoria.SelectedValue == null || cboCategoria.SelectedValue.ToString() == "0")
            {
                bResult = fnLLnenarMarcaxCategoria(Convert.ToInt32(cboBuscarCategoria.SelectedValue), 1, true, cboBuscarMarca);
                if (!bResult)
                {
                    MessageBox.Show("ERROR al Devolver la MARCA  DE TAL CATEGORIA", "cboCategoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                bResult = fnLLnenarMarcaxCategoria(Convert.ToInt32(cboBuscarCategoria.SelectedValue), 1, true, cboBuscarMarca);
                if (!bResult)
                {
                    MessageBox.Show("ERROR al Devolver la MARCA  DE TAL CATEGORIA", "cboCategoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (pasoLoad)
            {
                fnBuscarTabla(dgEquipo, 0, -1);
            }
        }

        private void cboBuscarMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResult;

            if (cboMarca.SelectedValue == null || cboMarca.SelectedValue.ToString() == "0")
            {
                bResult = fnLlenarModeloxMarca(Convert.ToInt32(cboBuscarMarca.SelectedValue), 1, cboBuscarModelo, true);
                if (!bResult)
                {
                    MessageBox.Show("ERROR al devolver los MODELOS DE TAL MARCA", "cboMarca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                bResult = fnLlenarModeloxMarca(Convert.ToInt32(cboBuscarMarca.SelectedValue), 1, cboBuscarModelo, true);
                if (!bResult)
                {
                    MessageBox.Show("ERROR al devolver los MODELOS DE TAL MARCA", "cboMarca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (pasoLoad)
            {
                fnBuscarTabla(dgEquipo, 0, -1);
            }
        }

        private void cboBuscarEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (pasoLoad)
            {
                fnBuscarTabla(dgEquipo, 0, -1);
            }

            
        }

        private void cboBuscarModelo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (pasoLoad)
            {
                fnBuscarTabla(dgEquipo, 0, -1);
            }
        }

        private void frmRegistrarEquipo_Load(object sender, EventArgs e)
        {
            if (lnTipoLlamada == 1)
            {
                this.Text = "Consultar Equipo";
                Height = 600;
                Width = 1231;
                cboBuscarEstado.SelectedValue = 1;
                gbBuscarPor.Height = 330;
                gbBuscarPor.Width = 248;

                txtBuscar.Location = new Point(292, 57);
                pbBuscar.Location = new Point(300, 66);
                dgEquipo.Location = new Point(292, 103);
                
                cboBuscarEstado.Width = 200;

                cboBuscarCategoria.Location=new Point(23, 128);
                cboBuscarCategoria.Width = 200;
                lblCategoria.Location = new Point(20, 110);

                cboBuscarMarca.Location = new Point(23, 188);
                cboBuscarMarca.Width = 200;
                lblMarca.Location = new Point(20, 170);

                cboBuscarModelo.Location = new Point(23, 248);
                cboBuscarModelo.Width = 200;
                lblModelo.Location = new Point(20, 230);
                //dgEquipo.Left = 12;
                //dgEquipo.Top = 60;
                dgEquipo.Height = 390;
                //dgEquipo.Width = 635;
                StartPosition = FormStartPosition.CenterScreen;
                fnOcultarObjeto(lnTipoLlamada);
                
            }
            else if (lnTipoLlamada == 3)
            {
                
                this.Text = "Consultar Equipo";
                
                tabControl1.SelectedIndex = 1;
                
                StartPosition = FormStartPosition.CenterScreen;
                tabControl1.TabPages.Remove(tabRegistro); 
                if (pasoLoad)
                {
                    fnBuscarTabla(dgEquipo, 0, -1);
                }

            }
            else
            {
                tabRegistro.AutoScroll = false;
            }
        }

        private void fnOcultarObjeto(Int32 lnTipo)
        {
            if (lnTipo == 1 || lnTipo == 3 || lnTipo == 4)
            {
                gbEquipo.Visible = false;
                btnNuevo.Visible = false;
                btnEditar.Visible = false;
                btnGuardar.Visible = false;
                btnSalir.Visible = false;
            }
            else if (lnTipo == 2)
            {
                //gbBuscar.Visible = false;
                //txtBuscarEquipo.Visible = false;
            }
        }

        private void opcEditar_Click(object sender, EventArgs e)
        {
            estActualizar = true;

            Boolean bResul = false;
            bResul = fnListarEquipoEspecifico(dgEquipo);
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
           
            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, true);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            fnHabilitarGroupBoxs(false);

            fnVerValidacion(false);
            tabControl1.SelectedIndex = 0;
            tabRegistro.AutoScroll = false;
        }

        private void opcHistorial_Click(object sender, EventArgs e)
        {
            estActualizar = true;

            Boolean bResul = false;
            bResul = fnListarEquipoEspecifico(dgEquipo);
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            bResul = fnBuscarEquipoHistorial(dgEquipoHistorial,0,-1);
            if (!bResul)
            {
                MessageBox.Show("Error al Listar Historial Equipo", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            fnHabilitarGroupBoxs(false);

            fnVerValidacion(false);
            tabControl1.SelectedIndex = 0;
            tabRegistro.AutoScroll = true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            if (pasoLoad)
            {
                fnBuscarTabla(dgEquipo, 0, -1);
            }
        }

        private Boolean fnLLnenarMarcaxCategoria(Int32 idCategoria,Int16 pnTipoCon,Boolean buscar, ComboBox combo)
        {
            BLCate_Mar_Mod objCate_Marca_Mod = new BLCate_Mar_Mod();
            clsUtil objUtil = new clsUtil();
            List<MarcaEquipo> lstMarca = new List<MarcaEquipo>();

            try
            {
                lstMarca = objCate_Marca_Mod.blDevolverMarcaEquipo(idCategoria,pnTipoCon,buscar);
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

        private Boolean fnLlenarModeloxMarca(Int32 idMarca,Int16 lnTipoCon,ComboBox combo,Boolean buscar)
        {
            BLCate_Mar_Mod objCate_Marca_Mod = new BLCate_Mar_Mod();
            clsUtil objUtil = new clsUtil();
            List<ModeloEquipo> lstModelo = new List<ModeloEquipo>();

            try
            {
                lstModelo = objCate_Marca_Mod.blDevolverModeloEquipo(idMarca,lnTipoCon,buscar);
                combo.ValueMember = "idModelo";
                combo.DisplayMember = "cNomModelo";
                combo.DataSource = lstModelo;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        private List<EquipoAccesorios> fnRecorrerAccesorios(Int32 opcion)
        {
            List<EquipoAccesorios> lstAccesorios = new List<EquipoAccesorios>();

            if (opcion == 0)
            {
                for (Int32 i = 0; i < chkListaAccesorios.Items.Count; i++)
                {
                    chkListaAccesorios.SetSelected(i, true);
                    lstAccesorios.Add(
                    new EquipoAccesorios
                    {
                        idEquipoAccesorios = Convert.ToInt32(chkListaAccesorios.SelectedValue.ToString()),
                        idEquipo = Convert.ToInt32(txtCodigo.Text.Trim().ToString()),
                        idAccesorio = Convert.ToInt32(chkListaAccesorios.SelectedValue.ToString()),
                        bEstado = chkListaAccesorios.GetItemCheckState(i) == CheckState.Checked ? Convert.ToBoolean(1) : Convert.ToBoolean(0),
                        dFechaRegistro = Variables.gdFechaSis,
                        idUsuario = Variables.gnCodUser

                    });

                }

                return lstAccesorios;
            }
            else
            {
                foreach (int itemChecked in chkListaAccesorios.CheckedIndices)
                {

                    chkListaAccesorios.SetSelected(itemChecked, true);
                    lstAccesorios.Add(
                    new EquipoAccesorios
                    {

                        idEquipoAccesorios = Convert.ToInt32(chkListaAccesorios.SelectedValue.ToString()),
                        idEquipo = Convert.ToInt32(txtCodigo.Text.Trim().ToString()),
                        idAccesorio = Convert.ToInt32(chkListaAccesorios.SelectedValue.ToString()),
                        bEstado = chkListaAccesorios.GetItemCheckState(itemChecked) == CheckState.Checked ? Convert.ToBoolean(1) : Convert.ToBoolean(0),
                        dFechaRegistro = Variables.gdFechaSis,
                        idUsuario = Variables.gnCodUser

                    });

                }
                return lstAccesorios;
            }
            

        }


        private bool fnGuardarEquipo(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLEquipo blEquipo = new BLEquipo();
            clsUtil objUtil = new clsUtil();
            bool lcValidar;
            Equipo objEquipo = new Equipo();
            try
            {
                objEquipo.idEquipo = Convert.ToInt32(txtCodigo.Text.Trim());
                objEquipo.idModeloEquipo = Convert.ToInt32(cboModelo.SelectedValue);
                objEquipo.cNombre = Convert.ToString(txtNombre.Text.Trim());             
                objEquipo.cObservacion = Convert.ToString(txtObservaciones.Text.Trim());
                objEquipo.cPrecio = Convert.ToDouble(txtPrecio.Text.Trim().ToString());
                objEquipo.dFechaRegistro = Variables.gdFechaSis;
                objEquipo.idUsuario = Variables.gnCodUser;
                objEquipo.bEstado = Convert.ToBoolean(chkEstado.Checked);

                Int32 opcion = lnTipoCon == 1 ?  0 : 1;

                lcValidar = blEquipo.blGrabarEquipo(objEquipo, idTipoCon, fnRecorrerAccesorios(opcion));


            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarTipoPlan", "fnGuardarTipoPlan", ex.Message);
                lcValidar = false;
            }

            return true;

        }

        private void cboCategoriaEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResult;
            

            if (cboCategoria.SelectedValue == null || cboCategoria.SelectedValue.ToString() == "0")
            {

                cboMarca.Enabled = false;
                bResult = fnLLnenarMarcaxCategoria(Convert.ToInt32(cboCategoria.SelectedValue),lnTipoCon,false, cboMarca);
                if (!bResult)
                {
                    MessageBox.Show("ERROR al Devolver la MARCA  DE TAL CATEGORIA", "cboCategoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                cboMarca.Enabled = true;
                bResult = fnLLnenarMarcaxCategoria(Convert.ToInt32(cboCategoria.SelectedValue), lnTipoCon, false, cboMarca);
                if (!bResult)
                {
                    MessageBox.Show("ERROR al Devolver la MARCA  DE TAL CATEGORIA", "cboCategoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            var result = FunValidaciones.fnValidarCombobox(cboCategoria, erCategoria, imgCategoria);
            estCategoria = result.Item1;
            msjCategoria = result.Item2;
            
        }

        private void cboMarcaEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResult;



            if (cboMarca.SelectedValue == null || cboMarca.SelectedValue.ToString() == "0")
            {

                cboModelo.Enabled = false;
                bResult = fnLlenarModeloxMarca(Convert.ToInt32(cboMarca.SelectedValue),lnTipoCon,cboModelo,false);
                if (!bResult)
                {
                    MessageBox.Show("Error al devolver las Marcas", "cboMarca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                cboModelo.Enabled = true;
                bResult = fnLlenarModeloxMarca(Convert.ToInt32(cboMarca.SelectedValue),lnTipoCon,cboModelo,false);
                if (!bResult)
                {
                    MessageBox.Show("Error al devolver las Marcas", "cboMarca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
            var result = FunValidaciones.fnValidarCombobox(cboMarca, erMarca, imgMarca);
            estMarca = result.Item1;
            msjMarca = result.Item2;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            var result1 = FunValidaciones.fnValidarCombobox(cboCategoria, erCategoria, imgCategoria);
            estCategoria = result1.Item1;
            msjCategoria = result1.Item2;

            var result2 = FunValidaciones.fnValidarCombobox(cboMarca, erMarca, imgMarca);
            estMarca = result2.Item1;
            msjMarca = result2.Item2;

            var result3 = FunValidaciones.fnValidarCombobox(cboModelo, erModelo, imgModelo);
            estModelo = result3.Item1;
            msjModelo = result3.Item2;
            
            txtNombre_TextChanged(sender, e);
            siticoneTextBox1_TextChanged(sender, e);
            txtObservaciones_TextChanged(sender, e);
            chkListaAccesorios_SelectedIndexChanged(sender, e);



            if (estCategoria && estMarca && estModelo && estNombre && estAccesorios && estPrecio && estObservaciones)
            {
                bool lcResultado;

                lcResultado = fnGuardarEquipo(lnTipoCon);
                if (lcResultado)
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente Equipo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnNuevo_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error al Grabar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Complete correctamente los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
            
        }

        private Tuple<Boolean, String> fnValidarCheckedListBox(CheckBox chk, CheckedListBox cklb, Label lbl, PictureBox img)
        {
            String msj;

            if (chk.Checked)
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;

                return Tuple.Create(true, msj);
            }
            else
            {
                if (cklb.CheckedItems.Count < 1)
                {
                    img.Image = Properties.Resources.error;
                    msj = "Seleccione por lo menos un accesorio (campo obligatorio)";
                    lbl.Text = msj;

                    return Tuple.Create(false, msj);

                }
                else
                {
                    img.Image = Properties.Resources.ok;
                    msj = "";
                    lbl.Text = msj;

                    return Tuple.Create(true, msj);

                }
            }



        }

        private Boolean fnObtenerAccesorios(Int32 idAccesorio, Int32 pnTipoCon)
        {
            BLAccesorio objAccesorios = new BLAccesorio();
            clsUtil objUtil = new clsUtil();
            List<Accesorios> lstAcces = new List<Accesorios>();

            try
            {

                lstAcces = objAccesorios.blListarAccesorio(idAccesorio, pnTipoCon);
                chkListaAccesorios.DataSource = lstAcces;
                chkListaAccesorios.ValueMember = "idAccesorio";
                chkListaAccesorios.DisplayMember = "cAccesorio";
               

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarAccesorio", ex.Message);
                return false;
            }


        }
        private void txtNombreEquipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkListaAccesorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = fnValidarCheckedListBox(chkSinAccesorios, chkListaAccesorios, erAccesorios, imgAccesorios);
            estAccesorios = result.Item1;
            msjAccesorios = result.Item2;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            fnVerValidacion(true);
            fnObtenerAccesorios(0, 0);
            fnLimpiarControles();
            fnHabilitarGroupBoxs(true);
            

            

            FunValidaciones.fnHabilitarBoton(btnNuevo,true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, true);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            tabRegistro.AutoScroll = false;
        }
        
    }
}
