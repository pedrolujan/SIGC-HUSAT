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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml.Serialization;
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmRegistrarPlan : Form
    {
        public frmRegistrarPlan()
        {
           
            InitializeComponent();
            
        }
        static Boolean pasoLoad;
        Boolean SinAccesorios = false;
        Int16 lnTipoCon = 0, lnTipoLlamada = 0,lnTipoAniadir = 0;
        static Int32 tabInicio = 0;
        Int32 CantAccesorios = 0;
        Boolean estActualizar;
        Boolean estTipoPlan, estNombre, estAccesorios, estDescripcion, estMoneda,estTablaTarifas;
        String msjTipoPlan, msjNombre, msjAccesorios, msjDescripcion, msjMoneda,msjTablaTarifas;
        static List<Moneda> lstStMoneda = new List<Moneda>();
        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();
        }
        private void fnHabilitarGroupBoxs(Boolean pbAccesorio)
        {
            gbFormPlan.Enabled = pbAccesorio;
            gbTarifas.Enabled = pbAccesorio;
            gbEquipos.Enabled = pbAccesorio;
            gbObservaciones.Enabled = pbAccesorio;
        }
        private void fnLimpiarControles()
        {
            lnTipoCon = 0;
            fnInicializarTabla();
            fnLimpiarListaChecks();
            fnVerAnadirEquipo(false, false);

            /////TEXBOXS/////
            txtIdPlan.Text = "0";
            txtNombre.Text = "";
            txtObservacion.Text = "";
            txtBuscar.Text = "";
            txtActualizar.Text = "";
            txtIdPlan.Visible = false;

            /////COMBOBOXS/////
            cboTipoPlan.SelectedValue = 0;
            cboMoneda.SelectedValue = 0;

            ////LABELS////
            erTipoPlan.Text = "";
            erNombre.Text = "";
            erEquipos.Text = "";
            erMoneda.Text = "";
            erDescripcion.Text = "";
            erTablaTarifas.Text = "";
            lblVerID.Visible = false;
            
            ////PICTUREBOXS////
            imgTipoPlan.Image = null;
            imgNombre.Image = null;
            imgAccesorios.Image = null;
            imgObservacion.Image = null;
            imgMoneda.Image = null;
            imgTablaTarifas.Image = null;

            ////CHEKSBOXS/////
            chkEstado.Checked = true;
            chkSinEquipos.Checked = false;

            ////LISTBOXS/////
            dgPlan.Visible = false;

            txtBuscar.Focus();
            lnTipoCon = 0;
        }

        public void fnLimpiarListaChecks()
        {
            for (Int32 i = 0; i < chkListaEquipos.Items.Count; i++)
            {
                chkListaEquipos.SetItemChecked(i, false);
            }
        }
        private void fnHabilitarBotones(Boolean pbNuevo, Boolean pbEditar, Boolean pbGuardar, Boolean pbSalir)
        {
            btnNuevo.Enabled = pbNuevo;
            btnEditar.Enabled = pbEditar;
            btnGuardar.Enabled = pbGuardar;
            btnSalir.Enabled = pbSalir;
        }
        
        private Tuple<Boolean,String> fnValidarTablaTarifas()
        {
            String msj = "";
            foreach (DataGridViewRow fila in dgvTarifas.Rows)
            {
                if (fila.Index < 2)
                {
                    Double totalPreciofila = Convert.ToDouble(fila.Cells[7].Value ?? 0);
                    if (totalPreciofila == 0)
                    {
                        msj = "Totales no pueden ser 0";
                        imgTablaTarifas.Image = Properties.Resources.error;
                        erTablaTarifas.ForeColor = Variables.ColorError;
                        erTablaTarifas.Text = msj;
                        return Tuple.Create(false, msj);
                    }
                }
                
            }

            imgTablaTarifas.Image = Properties.Resources.ok;
            erTablaTarifas.ForeColor = Variables.ColorSuccess;
            erTablaTarifas.Text = msj;
            return Tuple.Create(true,msj);
        }
        private Boolean fnLlenarTipoPlan(Int32 idTipoPlan,SiticoneComboBox cbo, Int32 tipBusqueda)
        {
            BLTipoPlan objTipPlan = new BLTipoPlan();
            clsUtil objUtil = new clsUtil();
            List<TipoPlan> lstTipPlan = new List<TipoPlan>();

            try
            {
                lstTipPlan = objTipPlan.blDevolverTipoPlan(idTipoPlan,tipBusqueda);
                cbo.DataSource = lstTipPlan;
                cbo.ValueMember = "idTipoPlan";
                cbo.DisplayMember = "nombreTipoPlan";
               

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            fnLlenarTipoPlan(0,cboTipoPlan,0);
            fnObtenerEquipos(0,0);
            fnLimpiarControles();
            fnHabilitarGroupBoxs(true);
            fnVerValidacion(true);
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;
            btnSalir.Enabled = true;
            tabRegistro.AutoScroll = false;
            cboMoneda.SelectedValue = 1;
        }

        private void cboTipoPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTipoPlan.SelectedValue == null || cboTipoPlan.SelectedValue.ToString() == "0")
            {
                txtNombre.Text = "";
                txtNombre.Enabled = false;
            }
            else
            {
                txtNombre.Text = "";
                txtNombre.Enabled = true;
            }
            
            
            var result = FunValidaciones.fnValidarCombobox(cboTipoPlan, erTipoPlan, imgTipoPlan);
            estTipoPlan = result.Item1;
            msjTipoPlan = result.Item2;

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "DIRECCION", true,erNombre);
           
        }

        private void fnValidarTarifas()
        {
            

        }

        private void fnCargarContenidoTarifa()
        {
            fnInicializarTabla();
        }

        private void fnInicializarTabla()
        {
            dgvTarifas.Rows.Clear();

            dgvTarifas.Rows.Add("0", "1", "NUEVO", null, null, null, "", null);
            dgvTarifas.Rows.Add("0", "2", "RENOVACIÓN", null, null, null, "", null);
            dgvTarifas.Rows.Add("0", "3", "PORTABILIDAD", null, null, null, "", null);

            dgvTarifas.Columns[2].Width = 100;
            dgvTarifas.Columns[3].Width = 100;
            dgvTarifas.Columns[4].Width = 100;
            dgvTarifas.Columns[5].Width = 100;
            dgvTarifas.Columns[6].Width = 20;
            dgvTarifas.Columns[7].Width = 100;
        }
        private void fnCalcularTotalesTarifa()
        {

        }
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);
            e.KeyChar = char.ToUpper(e.KeyChar);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool lcResultado;

            var result1 = FunValidaciones.fnValidarCombobox(cboTipoPlan, erTipoPlan, imgTipoPlan);
            estTipoPlan = result1.Item1;
            msjTipoPlan = result1.Item2;
            var result2 = FunValidaciones.fnValidarCombobox(cboMoneda, erMoneda, imgMoneda);
            estMoneda = result2.Item1;
            msjMoneda = result2.Item2;
            txtNombre_TextChanged(sender, e);
            chkListaAccesorios_SelectedIndexChanged(sender, e);
            txtDescripcion_TextChanged(sender, e);

            var result = fnValidarTablaTarifas();
            estTablaTarifas = result.Item1;
            msjTablaTarifas = result.Item2;

            if (estTipoPlan && estNombre && estAccesorios && estDescripcion && estMoneda && estTablaTarifas)
            {

                lcResultado = fnGuardarPlan(lnTipoCon);
                if (lcResultado)
                {

                    MessageBox.Show("Se Guardó Satisfactoriamente Tipo Plan", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnNuevo_Click(sender, e);

                }
                else
                {
                    MessageBox.Show("Error en Tipo Plan. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Complete los campos correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private String fnObtenerSimboloMoneda(Int32 idM, List<Moneda> lstMoneda)
        {
            foreach (Moneda m in lstMoneda)
            {
                if (m.idMoneda == idM)
                {
                    return m.cSimbolo;
                }
            }
            return "";
        }
        private Boolean fnLLenarMoneda(ComboBox cbo, Int32 idMoneda, Boolean buscar)
        {
            BLMoneda objMoneda = new BLMoneda();
            clsUtil objUtil = new clsUtil();
            List<Moneda> lstMoneda;

            try
            {
                lstMoneda = objMoneda.blDevolverMoneda(idMoneda, buscar);
                cbo.ValueMember = "idMoneda";
                cbo.DisplayMember = "cNombre";
                cbo.DataSource = lstMoneda;

                lstStMoneda = lstMoneda;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarClaseVehiculo", ex.Message);
                return false;
            }
            finally
            {
                lstMoneda = null;
            }
        }
        private bool fnGuardarPlan(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLPlan blTipoPlan = new BLPlan();
            clsUtil objUtil = new clsUtil();
            bool lcValidar;
            Plan objPlan = new Plan();
            try
            {

                objPlan.idPlan = Convert.ToInt32(txtIdPlan.Text.ToString().Trim());
                objPlan.idTipoPlan = Convert.ToInt32(cboTipoPlan.SelectedValue);
                objPlan.nombrePlan = Convert.ToString(txtNombre.Text.Trim());
                objPlan.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                //objPlan.precio = Convert.ToDouble(txtPrecio.Text.Trim());
                //objPlan.PrecioEquipo = Convert.ToDouble(txtPrecioEquipo.Text.Trim());
                //objPlan.PrecioRenovacion = Convert.ToDouble(txtPrecioRenovación.Text.Trim());
                objPlan.descripcion = Convert.ToString(txtObservacion.Text.Trim());
                objPlan.fechaRegistro = dFechaSis;
                objPlan.idUsuario = Variables.gnCodUser;
                objPlan.estado = Convert.ToBoolean(chkEstado.Checked);

                Int32 opcion = lnTipoCon == 1 ? 0 : 1;

                lcValidar = blTipoPlan.blGrabarPlan(objPlan, idTipoCon,fnRecorrerEquipos(opcion), fnRecorrerTarifas());

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarTipoPlan", "fnGuardarTipoPlan", ex.Message);
                lcValidar = false;
            }

            return lcValidar;

        }

        
        private void fnSimboloMoneda(List<Moneda> lm)
        {

        }

        private Boolean fnObtenerEquipos(Int32 idAccesorio, Int16 pnTipoCon)
        {
            BLEquipo objEquipo = new BLEquipo();
            clsUtil objUtil = new clsUtil();
            List<Equipo> lstEquipo = new List<Equipo>();
          
            try
            {
                
                lstEquipo = objEquipo.blListarEquipo(idAccesorio, pnTipoCon);
                
                chkListaEquipos.DataSource = lstEquipo;
                chkListaEquipos.ValueMember = "idEquipo";
                chkListaEquipos.DisplayMember = "cNombre";

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarAccesorio", ex.Message);
                return false;
            }


        }

        private Tuple<Boolean, String> fnValidarCheckedListBox(CheckBox chk ,CheckedListBox cklb, Label lbl, PictureBox img)
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

        private void chkListaAccesorios_Leave(object sender, EventArgs e)
        {
            
        }

        private void chkListaAccesorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = fnValidarCheckedListBox(chkSinEquipos,chkListaEquipos, erEquipos, imgAccesorios);
            estAccesorios = result.Item1;
            msjAccesorios = result.Item2;

            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
            //Cerrar ventana
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarTabla(1,-1);
            }
        }

        private Boolean fnBuscarTabla(Int32 numPagina, Int32 tipoCon)
        {
            BLPlan objPlan = new BLPlan();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();
            List<Plan> lstPlan = null;
            String columAccesorio = "";
            String pcBuscar = txtBuscar.Text.Trim();
            String pnTipocon;
            Int32 filas = 10;
            Int32 idTipoPlan = Convert.ToInt32(cboBuscarTipoPlan.SelectedValue.ToString());

            if (cboBuscar.SelectedIndex == 1)
            {
                pnTipocon = "1";
            }
            else if (cboBuscar.SelectedIndex == 2)
            {
                pnTipocon = "0";
            }
            else
            {
                pnTipocon = "";
            }

            try
            {
                lstPlan = new List<Plan>();
                datTipoPlan = objPlan.blBuscarPlanDataTable(pcBuscar, pnTipocon, idTipoPlan, numPagina,tipoCon);

                Int32 totalResultados = datTipoPlan.Rows.Count;
                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("TIPO PLAN");
                    dt.Columns.Add("PLAN");
                    dt.Columns.Add("PRECIO NUEVO");
                    dt.Columns.Add("PRECIO RENOVACIÓN");
                    dt.Columns.Add("PRECIO PORTABILIDAD");
                    dt.Columns.Add("EQUIPOS");
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

                        String precioNuevo = "";
                        String precioRenov = "";
                        String preciosPorta = "";
                        String tarifas = Convert.ToString(datTipoPlan.Rows[i][3]);
                        var result = fnObtenerTotalesTarifa(tarifas);

                        precioNuevo = result.Item1;
                        precioRenov = result.Item2;
                        preciosPorta = result.Item3;

                        if (Convert.ToBoolean(datTipoPlan.Rows[i][5]) == true)
                        {
                            estado = "ACTIVO";
                        }
                        else
                        {
                            estado = "INACTIVO";
                        }
                        String ac = Convert.ToString(datTipoPlan.Rows[i][4]);

                        if (ac == "")
                        {
                            columAccesorio = "SIN EQUIPOS";
                        }
                        else
                        {
                            columAccesorio = Convert.ToString(datTipoPlan.Rows[i][4]);
                        }

                        object[] row = { 
                            datTipoPlan.Rows[i][0],
                            y,
                            datTipoPlan.Rows[i][1], 
                            datTipoPlan.Rows[i][2],
                            precioNuevo,
                            precioRenov,
                            preciosPorta,
                            columAccesorio, 
                            estado 
                        };
                        dt.Rows.Add(row);

                    }
                   
                    dgPlan.DataSource = dt;

                    dgPlan.Columns[0].Visible = false;
                    dgPlan.Columns[1].Width = 40;
                    dgPlan.Columns[2].Width = 70;
                    dgPlan.Columns[3].Width = 70;
                    dgPlan.Columns[4].Width = 70;
                    dgPlan.Columns[5].Width = 70;
                    dgPlan.Columns[6].Width = 70;
                    dgPlan.Columns[7].Width = 300;
                    dgPlan.Columns[8].Width = 100;
                   

                    dgPlan.Visible = true;

                    if (tipoCon == -1)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datTipoPlan.Rows[0][6]);
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
                    dgPlan.DataSource = dt;
                    dgPlan.Visible = true;
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

        private Tuple<String,String,String> fnObtenerTotalesTarifa(String tarifas)
        {
            String precioNuevo = "";
            String precioRenov = "";
            String preciosPorta = "";

            if (tarifas != "")
            {
                Int32 numCarcateres = tarifas.Length;
                Int32 primeraComa = tarifas.IndexOf(",", 0, numCarcateres);
                Int32 segundaComa = tarifas.IndexOf(",", primeraComa + 1);

                precioNuevo = tarifas.Substring(0, primeraComa);
                precioRenov = tarifas.Substring(primeraComa + 1, segundaComa - primeraComa - 1);
                preciosPorta = tarifas.Substring(segundaComa + 1, numCarcateres - segundaComa - 1);
            }
            return Tuple.Create(precioNuevo,precioRenov,preciosPorta);
        }
        private Boolean fnBuscarHistorialPlan(Int32 numPagina, Int32 tipoCon)
        {
            BLPlan objPlan = new BLPlan();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();
            List<Plan> lstPlan = null;
            String columnEquipos = "";
            
            Int32 filas = 20;
            Int32 idPlan = Convert.ToInt32(txtIdPlan.Text.ToString());




            try
            {
                lstPlan = new List<Plan>();
                datTipoPlan = objPlan.blBuscarHitorialPlan(idPlan, numPagina, tipoCon);

                Int32 totalResultados = datTipoPlan.Rows.Count;
                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("FECH. REGISTRO");
                    dt.Columns.Add("TIP. PLAN");
                    dt.Columns.Add("PLAN");
                    dt.Columns.Add("PRECIO NUEVO");
                    dt.Columns.Add("PRECIO RENOV.");
                    dt.Columns.Add("PRECIO PORTA.");
                    dt.Columns.Add("EQUIPOS ASIG. AL PLAN");
                    dt.Columns.Add("DESCRIPCIÓN");
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
                    for (int i = 0; i <= totalResultados - 1; i++)
                    {
                        y += 1;
                        String precioNuevo = "";
                        String precioRenov = "";
                        String preciosPorta = "";
                        String tarifas = Convert.ToString(datTipoPlan.Rows[i][4]);
                        var result = fnObtenerTotalesTarifa(tarifas);

                        precioNuevo = result.Item1;
                        precioRenov = result.Item2;
                        preciosPorta = result.Item3;

                        if (Convert.ToBoolean(datTipoPlan.Rows[i][7]) == true)
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
                            columnEquipos = "SIN EQUIPOS";
                        }
                        else
                        {
                            columnEquipos = Convert.ToString(datTipoPlan.Rows[i][5]);
                        }

                      
                        object[] row = {
                            datTipoPlan.Rows[i][0],
                            y,
                            datTipoPlan.Rows[i][1],
                            datTipoPlan.Rows[i][2],
                            datTipoPlan.Rows[i][3],
                            precioNuevo,
                            precioRenov,
                            preciosPorta,
                            columnEquipos,
                            datTipoPlan.Rows[i][6],
                            estado,
                            datTipoPlan.Rows[i][8]
                        };
                        dt.Rows.Add(row);

                    }

                    dgHistorialPlan.DataSource = dt;

                    dgHistorialPlan.Columns[0].Visible = false;
                    dgHistorialPlan.Columns[1].Width = 40;
                    dgHistorialPlan.Columns[2].Width = 120;
                    dgHistorialPlan.Columns[3].Width = 60;
                    dgHistorialPlan.Columns[4].Width = 80;
                    dgHistorialPlan.Columns[5].Width = 70;
                    dgHistorialPlan.Columns[6].Width = 70;
                    dgHistorialPlan.Columns[7].Width = 70;
                    dgHistorialPlan.Columns[8].Width = 250;
                    dgHistorialPlan.Columns[9].Width = 250;
                    dgHistorialPlan.Columns[10].Width = 80;
                    dgHistorialPlan.Columns[11].Width = 80;

                    dgHistorialPlan.Visible = true;

                    if (tipoCon == -1)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datTipoPlan.Rows[0][9]);
                        fnCalcularPaginacion(
                            totalRegistros,
                            filas,
                            totalResultados,
                            cboPaginaHistorial,
                            btnTotalPaginasHistorial,
                            btnRegistrosHistorial,
                            btnTotalRegitrosHistorial
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
                    dgPlan.DataSource = dt;
                    dgPlan.Visible = true;
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
        private void dgPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
        private void fnVerValidacion(Boolean estado)
        {
            /////TEXBOXS/////
            erTipoPlan.Visible = estado;
            erNombre.Visible = estado;
            
            erEquipos.Visible = estado;
            erDescripcion.Visible = estado;
            /////PICTUREBOXS////
            imgTipoPlan.Visible = estado;            
            imgNombre.Visible = estado;
            
            imgAccesorios.Visible = estado;
            imgObservacion.Visible = estado;

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

        private void chkSinAccesorios_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSinEquipos.Checked)
            {
                chkListaEquipos.Enabled = false;
                fnLimpiarListaChecks();
                chkListaAccesorios_SelectedIndexChanged(sender, e);
            }
            else
            {
                chkListaEquipos.Enabled = true;
                chkListaAccesorios_SelectedIndexChanged(sender, e);
            }
            
        }

        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pasoLoad)
            {
                fnBuscarTabla(1, -1);
            }
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (lnTipoCon == 1)
            {
                if (chkEstado.Checked == false)
                {
                    
                }
                else
                {

                    Boolean estado = fnValidarTipoPlan(Convert.ToInt32(txtIdPlan.Text.Trim().ToString()));
                    if (estado)
                    {

                    }
                    else
                    {

                        String TipoPlanSelected = cboTipoPlan.Text.ToString();
                        MessageBox.Show("Este TIPO DE PLAN está DESACTIVADO\nPorfavor CAMBIAR el estado del Tipo de Plan:\n" + TipoPlanSelected, "VALIDACIÓN PLAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        chkEstado.Checked = false;
                    }
                }


            }
        }

        private Boolean fnValidarTipoPlan(Int32 idTipoPlan)
        {
            clsUtil objUtil = new clsUtil();
            BLPlan objPlan = new BLPlan();
            Boolean estadoTipoPlan;
            try
            {
                

                estadoTipoPlan = objPlan.blValidarTipoPlan(idTipoPlan);
              

                return estadoTipoPlan;
            }
            catch (Exception ex)
            {

                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;


            }
        }

        private Boolean fnValidarPlanEquipo(Int32 idPlanEquipo,Int16 pnTipoCon)
        {
            clsUtil objUtil = new clsUtil();
            BLPlan objPlan = new BLPlan();
            Boolean estadoTipoPlan;
            try
            {
                estadoTipoPlan = objPlan.blValidarPlanEquipo(idPlanEquipo,pnTipoCon);

                return estadoTipoPlan;
            }
            catch (Exception ex)
            {

                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;


            }
        }

        private void chkListaAccesorios_Click(object sender, EventArgs e)
        {
            if (lnTipoCon == 1)
            {

                Int32 index = chkListaEquipos.SelectedIndex;
                CheckState estadoItem = chkListaEquipos.GetItemCheckState(index);
                if (estadoItem == CheckState.Checked)
                {

                }
                else
                {
                    Boolean estado;
                    Int32 itemSelect = Convert.ToInt32(chkListaEquipos.SelectedValue.ToString());

                    estado = fnValidarPlanEquipo(itemSelect,lnTipoAniadir);

                    if (estado)
                    {

                    }
                    else
                    {
                        String AccesorioSelected = chkListaEquipos.Text.ToString();
                        DialogResult pregunta = MessageBox.Show("Este ACCESORIO está DESACTIVADO\nPorfavor CAMBIAR el estado del ACCESORIO:\n" + AccesorioSelected, "VALIDACIÓN PLAN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (pregunta == DialogResult.OK)
                        {

                            chkListaEquipos.SetItemChecked(index, false);
                        }

                    }



                }

            }
        }

        private void cboBuscarTipoPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pasoLoad)
            {
                fnBuscarTabla(1, -1);
            }
        }

        private List<PlanEquipo> fnRecorrerEquipos(Int32 opcion)
        {
            List<PlanEquipo> lstEquipos = new List<PlanEquipo>();


            if (opcion == 0)
            {
                for (Int32 i = 0; i < chkListaEquipos.Items.Count; i++)
                {
                    chkListaEquipos.SetSelected(i, true);
                    lstEquipos.Add(
                    new PlanEquipo
                    {

                        idPlanEquipo = Convert.ToInt32(chkListaEquipos.SelectedValue.ToString()),
                        idPlan = Convert.ToInt32(txtIdPlan.Text.Trim().ToString()),
                        idEquipo = Convert.ToInt32(chkListaEquipos.SelectedValue.ToString()),
                        bEstado = chkListaEquipos.GetItemCheckState(i) == CheckState.Checked ? Convert.ToBoolean(1) : Convert.ToBoolean(0),
                        dFechaRegistro = Variables.gdFechaSis,
                        idUsuario = Variables.gnCodUser

                    });

                }

                return lstEquipos;
            }
            else
            {

               
                foreach (int itemChecked in chkListaEquipos.CheckedIndices)
                {

                    chkListaEquipos.SetSelected(itemChecked, true);
                    lstEquipos.Add(
                    new PlanEquipo
                    {

                        idPlanEquipo = Convert.ToInt32(chkListaEquipos.SelectedValue.ToString()),
                        idPlan = Convert.ToInt32(txtIdPlan.Text.Trim().ToString()),
                        idEquipo = Convert.ToInt32(chkListaEquipos.SelectedValue.ToString()),
                        bEstado = chkListaEquipos.GetItemCheckState(itemChecked) == CheckState.Checked ? Convert.ToBoolean(1) : Convert.ToBoolean(0),
                        dFechaRegistro = Variables.gdFechaSis,
                        idUsuario = Variables.gnCodUser

                    });

                }
                return lstEquipos;

            }


        }

        private List<Tarifa> fnRecorrerTarifas()
        {
            List<Tarifa> lstTarifa = new List<Tarifa>();

            foreach (DataGridViewRow fila in dgvTarifas.Rows)
            {
                lstTarifa.Add(
                new Tarifa
                {
                    IdTarifa = Convert.ToInt32(fila.Cells[0].Value ?? "0"),
                    IdTipoTarifa = Convert.ToInt32(fila.Cells[1].Value ?? "0" ),
                    PrecioEquipo = Convert.ToDecimal(fila.Cells[3].Value ?? "0" ),
                    PrecioPlan = Convert.ToDecimal(fila.Cells[4].Value ?? "0" ),
                    PrecioReactivacion = Convert.ToDecimal(fila.Cells[5].Value ?? "0")
                });

            }
            return lstTarifa;


        }
        private Boolean fnListarEquiposXML(String equipos)
        {
            clsUtil objUtil = new clsUtil();
            xmlEquipos.Items objAcc = new xmlEquipos.Items();
            try
            {

                if (equipos == "")
                {
                    chkListaEquipos.DataSource = null;
                    return  true;
                }
                else
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(xmlEquipos.Items));
                    using (TextReader reader = new StringReader(equipos))
                    {
                        //de esta manera se deserializa
                        objAcc = (xmlEquipos.Items)serializer.Deserialize(reader);
                    }

                    chkListaEquipos.DataSource = objAcc.Item;
                    chkListaEquipos.ValueMember = "idPlanEquipo";
                    chkListaEquipos.DisplayMember = "Equipos";


                    for (Int32 i = 0; i <= (objAcc.Item.Count - 1); i++)
                    {

                        chkListaEquipos.SetSelected(i, true);

                        Boolean estadoItem = objAcc.Item[i].BEstado;
                        if (estadoItem)
                        {
                            chkListaEquipos.SetItemChecked(i, true);
                        }
                        else
                        {

                        }

                    }

                    return true;
                }
                
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;

            }



        }
        private void fnVerAnadirEquipo(Boolean chkestado, Boolean btnEstado)
        {
            chkAnadir.Visible = chkestado;
            chkAnadir.Checked = false;
            btnAnadir.Visible = btnEstado;
        }
        private void chkAnadir_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnadir.Checked)
            {
                lnTipoAniadir = 1;
                btnAnadir.Visible = true;
                chkListaEquipos.Enabled = true;
                
                chkAnadir.BackColor = Color.FromArgb(242, 68, 29);
                chkAnadir.ForeColor = Color.White;

                fnObtenerEquipos(Convert.ToInt32(txtIdPlan.Text.ToString()), -2);
                btnAnadir.Visible = true;
                chkSinEquipos.Visible = false;
                FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            }
            else
            {
               
                chkAnadir.BackColor = Color.White;
                chkAnadir.ForeColor = Color.FromArgb(64, 64, 64);
                lnTipoAniadir = 0;
                fnVerAnadirEquipo(true, false);
                chkSinEquipos.Visible = true;
                BLPlan objPlan = new BLPlan();
                Plan lstPlan = new Plan();
                Boolean bResult;


                Int32 idEquipo = Convert.ToInt32(txtIdPlan.Text.Trim().ToString());
                lstPlan = objPlan.blListarPlanDataGrid(idEquipo);

                bResult = fnListarEquiposXML(lstPlan.equipos);

                if (!bResult)
                {
                    MessageBox.Show("Error al listar Accesorios", "Accesorios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                FunValidaciones.fnHabilitarBoton(btnGuardar, true);
            }
        }

        //private Boolean fnObtenerEquipos(Int32 idAccesorio, Int32 pnTipoCon)
        //{
        //    BLPlan objAccesorios = new BLAccesorio();
        //    clsUtil objUtil = new clsUtil();
        //    List<PlanEquipo> lstAcces = new List<PlanEquipo>();

        //    try
        //    {

        //        lstAcces = objAccesorios.blListarAccesorio(idAccesorio, pnTipoCon);
        //        chkListaEquipos.DataSource = lstAcces;
        //        chkListaEquipos.ValueMember = "idAccesorio";
        //        chkListaEquipos.DisplayMember = "cAccesorio";


        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarAccesorio", ex.Message);
        //        return false;
        //    }


        //}

       

        private Boolean fnListarEquipos(String equipos)
        {
            clsUtil objUtil = new clsUtil();
            xmlEquipos.Items objAcc = new xmlEquipos.Items();
            try
            {
                if (equipos == "")
                {
                    chkListaEquipos.DataSource = null;
                    return true;
                }
                else
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(xmlEquipos.Items));
                    using (TextReader reader = new StringReader(equipos))
                    {
                        //de esta manera se deserializa
                        objAcc = (xmlEquipos.Items)serializer.Deserialize(reader);
                    }

                    chkListaEquipos.DataSource = objAcc.Item;
                    chkListaEquipos.ValueMember = "idPlanEquipo";
                    chkListaEquipos.DisplayMember = "Equipos";

                    Int32 j = 0;
                    for (Int32 i = 0; i <= (objAcc.Item.Count - 1); i++)
                    {

                        chkListaEquipos.SetSelected(i, true);

                        Boolean estadoItem = objAcc.Item[i].BEstado;
                        if (estadoItem)
                        {
                            chkListaEquipos.SetItemChecked(i, true);
                            j += 1;
                        }
                        else
                        {

                        }

                    }
                    if (j == 0)
                    {
                        chkSinEquipos.Checked = true;
                        chkListaEquipos.Enabled = false;
                    }
                    else
                    {
                        chkSinEquipos.Checked = false;
                        chkListaEquipos.Enabled = true;
                    }
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;

            }



        }

        private Boolean fnListarTarifas(String tarifas)
        {
            clsUtil objUtil = new clsUtil();
            xmlTarifas.Items clsTarifas = new xmlTarifas.Items();
            try
            {
                fnCargarContenidoTarifa();

                if (tarifas == "")
                {
                    return true;
                }
                else
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(xmlTarifas.Items));
                    using (TextReader reader = new StringReader(tarifas))
                    {
                        //de esta manera se deserializa
                        clsTarifas = (xmlTarifas.Items)serializer.Deserialize(reader);
                    }
                    int i = 0;
                    foreach (DataGridViewRow fila in dgvTarifas.Rows)
                    {
                        fila.Cells[0].Value = clsTarifas.Item[i].IdTarifa;
                        fila.Cells[1].Value = clsTarifas.Item[i].IdTipoTarifa;
                        fila.Cells[3].Value  = clsTarifas.Item[i].PrecioEquipo;
                        fila.Cells[4].Value = clsTarifas.Item[i].PrecioPlan;
                        fila.Cells[5].Value = clsTarifas.Item[i].PrecioRenovaciones;
                        i += 1;
                    }




                    return true;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;

            }



        }


        private void dgvTarifas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 filaIndice = e.RowIndex == -1 ? 0 : e.RowIndex;
            if (dgvTarifas.Rows.Count > 0)
            {
                
                if (e.ColumnIndex >=3 || e.ColumnIndex <= 5 )
                {
                    Double precioEquipo = Convert.ToDouble(dgvTarifas.Rows[filaIndice].Cells[3].Value ?? 0);
                    Double precioPlan = Convert.ToDouble(dgvTarifas.Rows[filaIndice].Cells[4].Value ?? 0);
                    Double precioReactivacion = Convert.ToDouble(dgvTarifas.Rows[filaIndice].Cells[5].Value ?? 0);
                    Double precioTotal = precioEquipo + precioPlan + precioReactivacion;
                    dgvTarifas.Rows[filaIndice].Cells[7].Value = precioTotal;
                    //dgvTarifas.Rows[filaIndice].Cells[6].Value = String.Format("{0:0.00}", Math.Round(precioTotal, 2));
                   

                }

            }
        }

        private void verHistorial_Click(object sender, EventArgs e)
        {
            Int32 idbusqueda = Convert.ToInt32(txtIdPlan.Text.Trim());

            //txtBuscarHistorial.Text = Convert.ToString(idbusqueda);
            tabControl.SelectedIndex = 2;
            
        }

        private void opcHistorial_Click(object sender, EventArgs e)
        {
            fnLlenarTipoPlan(-1, cboTipoPlan, 0);
            fnObtenerEquipos(0, 0);
            fnListarPlanEspecifico(dgPlan);
            fnBuscarHistorialPlan(0,-1);

            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            fnHabilitarGroupBoxs(false);

            fnVerValidacion(false);
            tabRegistro.AutoScroll = true;

        }

        private void opcEditar_Click(object sender, EventArgs e)
        {
            estActualizar = true;
            fnLlenarTipoPlan(-1, cboTipoPlan, 0);
            fnObtenerEquipos(0, 0);
            //fnLimpiarControles();
            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                bResul = fnListarPlanEspecifico(dgPlan);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                tabControl.SelectedIndex = 0;
            }
            else if (lnTipoLlamada == 1)
            {

                Boolean bResul = false;
                //bResul = fnRecuperarAccesorioEsp();
                //if (!bResul)
                //{
                //    MessageBox.Show("Error al Recuperar Marca Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                //else
                //{
                //    this.Dispose();
                //}
            }


            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, true);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            fnHabilitarGroupBoxs(false);

            fnVerValidacion(false);
            tabRegistro.AutoScroll = false;

        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 numPagina = Convert.ToInt32(cboPagina.Text.ToString());
            fnBuscarTabla(numPagina, -2);
            
        }

        private void dgvCronograma_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo nfi = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;

            char decSeperator;

            decSeperator = nfi.CurrencyDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar)
            | e.KeyChar == decSeperator))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == decSeperator
                && (sender as TextBox).Text.IndexOf(decSeperator) > -1)
            {
                e.Handled = true;
            }
        }
        private void dgvTarifas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            //e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);
        
            if (dgvTarifas.CurrentCell.ColumnIndex == 3) //Desired Column
            {

                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            else if (dgvTarifas.CurrentCell.ColumnIndex == 4) //Desired Column
            {

                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            else if (dgvTarifas.CurrentCell.ColumnIndex == 5) //Desired Column
            {

                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboMoneda, erMoneda, imgMoneda);
            estMoneda = result.Item1;
            msjMoneda = result.Item2;
            Int32 idMoneda = Convert.ToInt32(cboMoneda.SelectedValue == null ? "0" : cboMoneda.SelectedValue.ToString());

            String simboloMoneda = fnObtenerSimboloMoneda(idMoneda, lstStMoneda);
            if (pasoLoad)
            {
                for (int i = 0; i <= 2; i++)
                {
                    dgvTarifas.Rows[i].Cells[6].Value = simboloMoneda;
                }
            }
            
            

        }

        private void frmRegistrarPlan_Load(object sender, EventArgs e)
        {
            pasoLoad = false;
            fnHabilitarGroupBoxs(false);
            fnLlenarTipoPlan(-1, cboBuscarTipoPlan, 1);
            fnLLenarMoneda(cboMoneda, 0, false);
            fnCargarContenidoTarifa();
            cboBuscar.SelectedIndex = 0;
            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            FunValidaciones.fnColorBotones(btnNuevo, btnEditar, btnGuardar, btnSalir);
            fnLimpiarControles();
            fnVerAnadirEquipo(false, false);
            tabRegistro.AutoScroll = false;
            pasoLoad = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            fnBuscarTabla(1, -1);
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            BLPlan objEquipo = new BLPlan();
            Plan lstEquipo = new Plan();
            Boolean bResult;
            Int32 idEquipo = Convert.ToInt32(txtIdPlan.Text.Trim().ToString());

            if (chkListaEquipos.Items.Count == 0)
            {
                DialogResult resp;
                resp = MessageBox.Show("No tiene ningun accesorio por agregar...\n VOLVER", "frmEquipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (resp == DialogResult.OK)
                {
                    chkAnadir.Checked = false;

                    lstEquipo = objEquipo.blListarPlanDataGrid(idEquipo);

                    bResult = fnListarEquipos(lstEquipo.equipos);

                    if (!bResult)
                    {
                        MessageBox.Show("Error al listar Accesorios", "Accesorios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    fnVerAnadirEquipo(true, false);
                }
            }
            else if (chkListaEquipos.CheckedItems.Count == 0)
            {
                DialogResult resp;
                resp = MessageBox.Show("No seleccionó ningun ACCESORIO...\n¿Todavía desea agregar?", "frmEquipo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resp == DialogResult.Yes)
                {
                    chkListaEquipos.Enabled = true;
                    fnLimpiarListaChecks();
                    fnObtenerEquipos(Convert.ToInt32(txtIdPlan.Text.ToString()), -2);

                }
                else
                {
                    chkAnadir.Checked = false;

                    lstEquipo = objEquipo.blListarPlanDataGrid(idEquipo);

                    bResult = fnListarEquipos(lstEquipo.equipos);

                    if (!bResult)
                    {
                        MessageBox.Show("Error al listar Accesorios", "Accesorios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    fnVerAnadirEquipo(true, false);
                }
            }
            else
            {
                bResult = objEquipo.blGrabarEquiposNoAgregados(idEquipo, 0, fnRecorrerEquipos(1));

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

                        chkListaEquipos.Enabled = true;
                        fnLimpiarListaChecks();
                        fnObtenerEquipos(Convert.ToInt32(txtIdPlan.Text.ToString()), -2);

                    }
                    else if (resp == DialogResult.No)
                    {
                        chkAnadir.Checked = false;
                        lstEquipo = objEquipo.blListarPlanDataGrid(idEquipo);

                        bResult = fnListarEquipos(lstEquipo.equipos);

                        if (!bResult)
                        {
                            MessageBox.Show("Error al listar Accesorios", "Accesorios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        fnVerAnadirEquipo(true, false);

                    }
                }
            }
        }

        private Boolean fnListarPlanEspecifico(SiticoneDataGridView dgv)
        {

            clsUtil objUtil = new clsUtil();
            List<xmlAccesorios.Item> lstAcce = new List<xmlAccesorios.Item>();
            xmlAccesorios.Items objAcc = new xmlAccesorios.Items();
            bool bResult;
            Int32 idPlan;
            try
            {
                if (dgPlan.Rows.Count > 0)
                {
                    BLPlan objPlan = new BLPlan();
                    Plan lstPlan = new Plan();
                    DataTable dtAccesorio = new DataTable();

                    idPlan = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value.ToString());
                    lstPlan = objPlan.blListarPlanDataGrid(idPlan);
                    cboMoneda.SelectedValue = 0;
                    txtActualizar.Text = Convert.ToString(lstPlan.nombrePlan.ToString().Trim());
                    txtIdPlan.Text = Convert.ToString(lstPlan.idPlan.ToString().Trim());
                    cboTipoPlan.SelectedValue = lstPlan.idTipoPlan;
                    txtNombre.Text = Convert.ToString(lstPlan.nombrePlan.ToString().Trim());
                    
                    //txtPrecio.Text = Convert.ToString(Math.Round(lstPlan.precio, 2));
                    //txtPrecioEquipo.Text = Convert.ToString(Math.Round(lstPlan.PrecioEquipo, 2));
                    //txtPrecioRenovación.Text = Convert.ToString(Math.Round(lstPlan.PrecioRenovacion, 2));

                    bResult = fnListarEquipos(lstPlan.equipos);
                    if (!bResult)
                    {
                        MessageBox.Show("Error al listar Accesorios", "Contacte al Administardor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    bResult = fnListarTarifas(lstPlan.tarifas);

                    if (!bResult)
                    {
                        MessageBox.Show("Error al listar Tarifas", "Contacte al Administardor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    cboMoneda.SelectedValue = lstPlan.idMoneda;

                    Int32 numChek = chkListaEquipos.CheckedItems.Count;

                    if(numChek == 0)
                    {
                        chkSinEquipos.Checked = true;
                    }

                    txtObservacion.Text = Convert.ToString(lstPlan.descripcion.ToString().Trim());
                    chkEstado.Checked = lstPlan.estado;
                    //dgPlan.Visible = false;
                    fnHabilitarGroupBoxs(false);
                    fnVerValidacion(false);
                    FunValidaciones.fnHabilitarBoton(btnNuevo, true);
                    FunValidaciones.fnHabilitarBoton(btnEditar, true);
                    FunValidaciones.fnHabilitarBoton(btnGuardar, false);
                    FunValidaciones.fnHabilitarBoton(btnSalir, true);
                    txtBuscar.Text = "";
                    lnTipoCon = 1;
                    tabControl.SelectedIndex = 0;
                    txtIdPlan.Visible = true;
                    
                    lblVerID.Visible = true;
                    fnVerAnadirEquipo(true, false);
                }
               

                return true;
            }
            catch (Exception ex)
            {
                
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;

                
            }
        }
        

        private void chkListaAccesorios_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
            

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

        private void rdbPrecio_CheckedChanged(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnHabilitarGroupBoxs(false);
            
            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
           

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexboxSQL(txtNombre, erNombre, imgNombre, false, 0);
            estNombre = result.Item1;
            msjNombre = result.Item2;
            txtNombre.MaxLength = 45;
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
                    bResul = fnBuscarNombrePlan(txt.Text.Trim(), pnTipocon);
                    return Tuple.Create(bResul, msj);

                }

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                bResul = fnBuscarNombrePlan(txt.Text.Trim(), pnTipocon);
                return Tuple.Create(bResul, msj);

            }


        }
        private Boolean fnBuscarNombrePlan(String pcBuscar,  Int16 pnTipoCon)
        {
            BLPlan objPlan = new BLPlan();
            clsUtil objUtil = new clsUtil();
            Int16 numResult = 0;

            Boolean pcEstado = chkEstado.Checked;
            Int32 pcTipoPlan = Convert.ToInt32(cboTipoPlan.SelectedValue==null ? "0": cboTipoPlan.SelectedValue.ToString());
            try
            {
                numResult = objPlan.blBuscarNombrePlan(pcBuscar,pcEstado,pcTipoPlan, pnTipoCon);

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

                objPlan = null;
                objUtil = null;
            }
        }
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtObservacion, erDescripcion, imgObservacion, false, true, true, 0, 0, 3,200, "Ingrese los datos correctamente");
            estDescripcion = result.Item1;
            msjDescripcion = result.Item2;
        }

        
        
    }
}
