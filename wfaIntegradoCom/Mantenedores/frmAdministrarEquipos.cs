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
    public partial class frmAdministrarEquipos : Form
    {
        static String marca = "";
        static String Modelo = "";
        static Int32 pnIdSimCard = 0;
        static Int32 SimCard = 0;
        static Int32 lnTipoValor = 0;
        Int32 lnTipoLlamada = 0;
        Int32 lnTipoCon = 0;
        static Int32 tabInicio;
        static Boolean estPasoLoad;
        clsUtil objUtil = null;
        String msjEquipo,msjSimCard,msjPlataforma,msjEstado,msjFecha, msjObservaciones;
        Boolean estEquipo,estSimCard,estPlataforma,estEstado, estFecha, estObservaciones;

       static AdministrarEquipos clsChip = new AdministrarEquipos();
        public frmAdministrarEquipos()
        {
            InitializeComponent();
        }

       
        public class CargarCombo
        {
            public string Value { get; set; }
            public string Index { get; set; }
        }
        frmEquipoImeis frmImeis;
        public static void fnRecuperarSimcard(Int32 idSimCard, Int32 pcSimcard,int pnTipoValor = 0)
        {
            pnIdSimCard = idSimCard;
            SimCard = pcSimcard;
            lnTipoValor = pnTipoValor;
        }
        

        private void fnColorBotonEsp(SiticoneButton btnNuevo)
        {
            btnNuevo.FillColor = Color.White;
            btnNuevo.BorderColor = Variables.ColorEmpresa;
            btnNuevo.ForeColor = Variables.ColorEmpresa;
            btnNuevo.Image = Properties.Resources.nuevo_base;

            btnNuevo.HoveredState.FillColor = Variables.ColorEmpresa;
            btnNuevo.HoveredState.Image = Properties.Resources.nuevo_hover;
            btnNuevo.HoveredState.ForeColor = Color.White;
        }
        private void frmAdministrarEquipos_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;
            estPasoLoad = false;
            try
            {
                dtHfechaFinal.Value = Variables.gdFechaSis;
                DateTime fecha = dtHFechaInicio.Value;
                fecha = fecha.AddDays(-30);
                dtHFechaInicio.Value = fecha;

                FunValidaciones.fnColorBotones(btnNuevo, btnEditar, btnGuardar, btnSalir);
                fnColorBotonEsp(btnNuevoHistorial);
                frmImeis = new frmEquipoImeis();

                bResult = frmImeis.fnLLnenarMarcaxCategoria(1, 0, true, cboBuscarMarca);
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Marca", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }


                bResult = FunGeneral.fnLlenarTablaCod(cboEstado, "ESIM");
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar TablaCod - Tipo Estado Imei", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                bResult = FunGeneral.fnLlenarTablaCod(cboEstadoBuscar, "ESIM");
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar TablaCod - Tipo Estado Imei", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                bResult = FunGeneral.fnLlenarTablaCod(cboPlataForma, "PLTF");
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar TablaCod - Tipo Estado Imei", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "frmOrdenCompra_Load", ex.Message);
            }
            finally
            {
                objUtil = null;
                estPasoLoad = true;
            }
            
        }
        public Boolean fnLlenarModeloxMarca(Int32 idMarca, Int16 lnTipoCon, ComboBox combo, Boolean buscar)
        {
            BLCate_Mar_Mod objCate_Marca_Mod = new BLCate_Mar_Mod();
            clsUtil objUtil = new clsUtil();
            List<ModeloEquipo> lstModelo = new List<ModeloEquipo>();

            try
            {
                lstModelo = objCate_Marca_Mod.blDevolverModeloEquipo(idMarca, lnTipoCon, buscar);
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
        private void cboBuscarMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResult = false;

            Int32 idMarca = 0;
            bResult = fnLlenarModeloxMarca(Convert.ToInt32(cboBuscarMarca.SelectedValue), 1, cboBuscarModelo, true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Modelo", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            if (estPasoLoad)
            {
                bResult = fnBuscarTabla(txtBuscar.Text.Trim(), 0, -1, lnTipoLlamada);
                if (!bResult)
                {
                    MessageBox.Show("Error al buscar Imeis. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
               
        }

        public Boolean fnObtenerPaginacionEquipos(String estado, Int32 idMarca, Int32 idModelo)
        {
            clsUtil objUtil = new clsUtil();
            BLEquipo_Imeis objPaginacion = new BLEquipo_Imeis();
            Equipo_imeis lstPaginacion = new Equipo_imeis();
            DataTable dtEquipo = new DataTable();
            try
            {
                lstPaginacion = objPaginacion.blObtenerPaginacionEquipos(estado,idMarca, idModelo);

                if (Convert.ToInt32(lstPaginacion.cantPaginas) > 0)
                {
                    btnTotalRegistros.Text = Convert.ToString(Convert.ToInt32(lstPaginacion.totalRegistros));
                    btnTotalPaginas.Text = Convert.ToString(Convert.ToInt32(lstPaginacion.cantPaginas));


                    var Valores = new List<CargarCombo>();
                    for (int i = 1; i <= Convert.ToInt32(lstPaginacion.cantPaginas); i++)
                    {

                        Valores.Add(new CargarCombo() { Index = Convert.ToString(i), Value = Convert.ToString(i) });

                    }


                    cboPagina.DisplayMember = "Value";
                    cboPagina.ValueMember = "Index";
                    cboPagina.DataSource = Valores;
                }
                else
                {
                    btnTotalRegistros.Text = Convert.ToString(Convert.ToInt32(lstPaginacion.totalRegistros));
                    btnTotalPaginas.Text = Convert.ToString(Convert.ToInt32(lstPaginacion.cantPaginas));


                    var Valores = new List<CargarCombo>();
                    for (int i = 0; i <= Convert.ToInt32(lstPaginacion.cantPaginas); i++)
                    {

                        Valores.Add(new CargarCombo() { Index = Convert.ToString(i), Value = Convert.ToString(i) });

                    }


                    cboPagina.DisplayMember = "Value";
                    cboPagina.ValueMember = "Index";
                    cboPagina.DataSource = Valores;
                }


                dgEquipoAdmin.Visible = true;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;
            }
        }
        private Boolean fnBuscarTabla(String pcBuscar, Int32 pagina, Int32 tipoCon,Int32 TipoLlamada)
        {
            BLEquipo_Imeis objPlan = new BLEquipo_Imeis();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();
            Int32 filas = 20;

            try
            {
                datTipoPlan = objPlan.blBuscarImeisDataTable(
                Convert.ToString(cboEstadoBuscar.SelectedValue),
                Convert.ToInt32(cboBuscarMarca.SelectedValue.ToString()),
                Convert.ToInt32(cboBuscarModelo.SelectedValue.ToString()),
                pcBuscar,
                pagina, tipoCon,TipoLlamada);

                Int32 totalResultados = datTipoPlan.Rows.Count;

                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("EQUIPO");
                    dt.Columns.Add("IMEI");
                    dt.Columns.Add("SERIE");
                    dt.Columns.Add("SIMCARD");
                    dt.Columns.Add("DOC. VENTA");
                    dt.Columns.Add("ESTADO");

                    Int32 y;

                    if (tipoCon == -1)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (pagina - 1) * filas;
                        y = tabInicio;
                    }

                    for (int i = 0; i <= datTipoPlan.Rows.Count - 1; i++)
                    {
                        y++;
                        object[] row = { datTipoPlan.Rows[i][0], y, datTipoPlan.Rows[i][1], datTipoPlan.Rows[i][2], datTipoPlan.Rows[i][3], datTipoPlan.Rows[i][8], datTipoPlan.Rows[i][7], datTipoPlan.Rows[i][4] };
                        dt.Rows.Add(row);

                    }

                    dgEquipoAdmin.DataSource = dt;
                    dgEquipoAdmin.Visible = true;
                    dgEquipoAdmin.Columns[0].Visible=false;
                    dgEquipoAdmin.Columns[1].Width = 35;
                    dgEquipoAdmin.Columns[2].Width = 200;
                    dgEquipoAdmin.Columns[3].Width = 100;
                    dgEquipoAdmin.Columns[4].Width = 100;
                    dgEquipoAdmin.Columns[5].Width = 100;
                    dgEquipoAdmin.Columns[6].Width = 100;
                    //if (Convert.ToString(btnTotalRegistros.Text)!="0")
                    //{
                    //    btnNumFilas.Text = Convert.ToString(datTipoPlan.Rows.Count);
                    //}
                    //else
                    //{
                    //    btnNumFilas.Text = "0";
                    //}

                    if (tipoCon == -1)
                    {
                        cboPagina.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datTipoPlan.Rows[0][6]);
                        fnCalcularPaginacion(totalRegistros, filas, totalResultados);
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
                    dgEquipoAdmin.DataSource = dt;
                    dgEquipoAdmin.Visible = false;
                    btnNumFilas.Text = "0";
                    btnTotalPaginas.Text = "0";
                    btnTotalRegistros.Text = "0";
                    return true;
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private void fnCalcularPaginacion(Int32 totalRegistros, Int32 filas, Int32 totalResultados)
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

            cboPagina.Items.Clear();

            for (Int32 i = 1; i <= cantidadPaginas; i++)
            {
                cboPagina.Items.Add(i);

            }

            cboPagina.SelectedIndex = 0;
            btnTotalPaginas.Text = Convert.ToString(cantidadPaginas);
            btnNumFilas.Text = Convert.ToString(totalResultados);
            btnTotalRegistros.Text = Convert.ToString(totalRegistros);


        }
        //private void fnHabilitarControles(Boolean pbHabilitar)
        //{
        //    if (pbHabilitar == true)
        //    {
        //        gbDatosEquipo.BackColor = Color.Transparent;
        //        gbDatosEquipo.LineColor = Variables.ColorGroupBox;
        //        lblInfoGB.Visible = false;

        //        //FunValidaciones.fnValidarEstado(swEstado,txtestado);

        //        gbDatos_Chip.BackColor = Color.Transparent;
        //        gbDatos_Chip.LineColor = Variables.ColorGroupBox;

        //        dgImei_serie.ThemeStyle.BackColor = Variables.ColorDesactivado;
        //        dgImei_serie.ThemeStyle.RowsStyle.BackColor = Color.WhiteSmoke;
        //        dgImei_serie.ThemeStyle.HeaderStyle.BackColor = Variables.ColorGroupBox;

        //        cboEquipo.BackColor = Color.Transparent;
        //        //cboMarcaEquipo.BackColor = Color.Transparent;
        //        //cboModeloEquipo.BackColor = Color.Transparent;

        //        cboEquipo.BackColor = Color.Transparent;
        //        //cboMarcaEquipo.BackColor = Color.Transparent;
        //        //cboModeloEquipo.BackColor = Color.Transparent;
        //        lblCantRegistros.Visible = true;
        //        txtObservacion.BackColor = Color.White;
        //        txtObservacion.Enabled = pbHabilitar;
        //        //pbImeis.Image = Properties.Resources.error;
        //        //pbSeries.Image = Properties.Resources.error;


        //    }
        //    else
        //    {
        //        gbDatosEquipo.BackColor = Variables.ColorDesactivado;
        //        gbDatosEquipo.LineColor = Variables.ColorDescativadoFuerte;
        //        lblInfoGB.Visible = true;


        //        gbDatos_Chip.BackColor = Variables.ColorDesactivado;
        //        gbDatos_Chip.LineColor = Variables.ColorDesactivado;


        //        cboEquipo.BackColor = Variables.ColorDesactivado;
        //        dgImei_serie.ThemeStyle.BackColor = Variables.ColorDesactivado;
        //        dgImei_serie.ThemeStyle.RowsStyle.BackColor = Variables.ColorDesactivado;
        //        dgImei_serie.ThemeStyle.HeaderStyle.BackColor = Variables.ColorDescativadoFuerte;
        //        //cboMarcaEquipo.BackColor = Variables.ColorDesactivado;
        //        //cboModeloEquipo.BackColor = Variables.ColorDesactivado;

        //        //cboEquipo. = Variables.ColorDesactivado;
        //        //cboMarcaEquipo.BaseColor = Variables.ColorDesactivado;
        //        //cboModeloEquipo.BaseColor = Variables.ColorDesactivado;
        //        lblCantRegistros.Visible = false;
        //        txtObservacion.BackColor = Variables.ColorDesactivado;
        //        txtObservacion.Enabled = pbHabilitar;

        //    }
        //    gbDatosEquipo.Enabled = pbHabilitar;
        //    gbSimCard.Enabled = pbHabilitar;
        //    gbAsignAciones.Enabled = pbHabilitar;


        //    pbEquipoUnico.Visible = pbHabilitar;
        //    //pbOrigen.Visible = pbHabilitar;
        //    //pbPlataforma.Visible = pbHabilitar;
        //    pbImeis.Visible = pbHabilitar;
        //    pbSeries.Visible = pbHabilitar;
        //    pbObservacion.Visible = pbHabilitar;

        //    if (dgImei_serie.Rows.Count > 1)
        //    {
        //        dgImei_serie.CurrentCell = dgImei_serie.Rows[dgImei_serie.Rows.Count - 2].Cells[2];

        //        dgImei_serie.BeginEdit(true);
        //    }
        //    FunValidaciones.fnHabilitarBoton(btnGuardar, false);
        //}
        private Boolean fnListarImeisEspecificos(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            
            DateTime Dfecha = Variables.gdFechaSis;
            try
            {
                if (dgEquipoAdmin.Rows.Count > 0)
                {
                    BLAdministrarEquipos objChip = new BLAdministrarEquipos();
                    AdministrarEquipos lstChip = new AdministrarEquipos();
                    DataTable dtEquipo = new DataTable();
                    lstChip = objChip.blListarImeiEspacifico(Convert.ToInt32(dgEquipoAdmin.Rows[e.RowIndex].Cells[0].Value), 1);

                    if (lstChip.idEquipoImeis > 0)
                    {
                        txtIdEquipoImei.Text = Convert.ToString(lstChip.idEquipoImeis);
                        txtEquipoUnico.Text = Convert.ToString(lstChip.nombreEquipo);
                        txtIdSimCardExistente.Text = Convert.ToString(lstChip.idSimCardExistente);
                        txtidSimCard.Text = Convert.ToString(lstChip.idSimCardExistente);
                        txtSimcard.Text = Convert.ToString(lstChip.SimCard);
                        txtImei.Text = Convert.ToString(lstChip.imei);
                        txtSerie.Text = Convert.ToString(lstChip.serie);
                        cboEstado.SelectedValue= Convert.ToString(lstChip.idEstadoEquipo);
                        if (Convert.ToString(lstChip.idPlataformaEquipo) =="00000000")
                        {
                            cboPlataForma.SelectedValue = "0";
                        }
                        else
                        {
                            cboPlataForma.SelectedValue= Convert.ToString(lstChip.idPlataformaEquipo);
                        }
                        dtFecha.Value = lstChip.dFechaMovimiento;
                        clsChip = lstChip;
                        fnMostrarFechas("");
                        fnActivarLinkHistorial();
                        //txtSeries2.Text = Convert.ToString(lstChip.serie);
                        //dgImei_serie.Rows.Add(Convert.ToString(lstChip.idEquipoImeis), Convert.ToString(lstChip.imei), Convert.ToString(lstChip.serie));

                        //fnHabilitarControles(false);
                        FunValidaciones.fnHabilitarBoton(btnEditar, true);
                        FunValidaciones.fnHabilitarBoton(btnNuevo, true);

                        dgEquipoAdmin.Visible = false;
                        txtBuscar.Text = "";
                        lnTipoCon = 1;

                        if(txtSimcard.Text.Length>4){
                            fnMostrarBotonLiberar(true);
                        }
                        else{
                            fnMostrarBotonLiberar(false);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este imei no esta asignado a alguna orden de compra", "Aviso!!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        private void fnMostrarBotonLiberar( Boolean estado)
        {
            btnLiberarSimCard.Visible = estado;
        }
        private void fnActivarLinkHistorial()
        {
            if (txtImei.Text.Length > 10)
            {
                lblHistorial.Visible = true;
            }
            else
            {
                lblHistorial.Visible = false;
            }
        }
        private Boolean fnObtenerSimCard()
        {
            bool bResul = false;
            clsUtil objUtil = new clsUtil();
            try
            {
                //bResul = fnListarOperador(true);
                //if (bResul == false)
                //    return false;
                if (lnTipoValor == 0)
                {                    
                    pnIdSimCard = 0;
                    SimCard = 0;
                    txtSimcard.Text = "No seleccionó sim card";
                    txtidSimCard.Text = Convert.ToString(pnIdSimCard);
                }
                else
                {
                    txtidSimCard.Text = Convert.ToString(pnIdSimCard);
                    txtSimcard.Text = Convert.ToString(SimCard);
                    //txtOperador.Text = lcOperador;
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnObtenerCliente", ex.Message);
                return false;
            }
        }

        private String fnGuardarMovimientoImeis(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLAdministrarEquipos blobjEquipo = new BLAdministrarEquipos();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            AdministrarEquipos objEquipo = new AdministrarEquipos();
            try
            {
                objEquipo.idEquipoImeis = Convert.ToInt32(txtIdEquipoImei.Text.Trim());
                objEquipo.idPlataformaEquipo = Convert.ToString(cboPlataForma.SelectedValue);
                objEquipo.idEstadoEquipo = Convert.ToString(cboEstado.SelectedValue);
                objEquipo.idSimCard = Convert.ToInt32(txtidSimCard.Text.Trim());
                objEquipo.idSimCardExistente = Convert.ToInt32(txtIdSimCardExistente.Text.Trim());
                objEquipo.dFechaMovimiento = dFechaSis /*Convert.ToDateTime(dtFecha.Value)*/;
                objEquipo.dFecharegistro = dFechaSis;
                objEquipo.observacion = txtObservacion.Text;
                objEquipo.idUsuario = Convert.ToInt32(Variables.gnCodUser);
                //if (Convert.ToInt32(txtIdSimCardExistente.Text)==0)
                //{
                    lcValidar = blobjEquipo.blGrabarMovimientoImeis(objEquipo, idTipoCon);
                //}
                //else
                //{
                //    lcValidar = blobjEquipo.blGrabarChip(objEquipo, idTipoCon);
                //}

                //fnLimpiarControles();
                //fnHabilitarControles(false);
                //FunValidaciones.fnHabilitarBoton(btnGuardar, false);
                //FunValidaciones.fnHabilitarBoton(btnEditar, false);
                //FunValidaciones.fnHabilitarBoton(btnOperaciones, false);
                //FunValidaciones.fnHabilitarBoton(btnNuevo, true);
                lcValidar = "ok";
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnGuardarEquipo", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private void btnBuscarSimCard_Click(object sender, EventArgs e)
        {
            lnTipoValor = 0;
            frmSimCard frmCliente = new frmSimCard();

            frmCliente.Inicio(1);

            Boolean lbResul = false;
            lbResul = fnObtenerSimCard();
            if (!lbResul)
            {
                MessageBox.Show("Error al Agregar Cliente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtImei_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtImei, lblImei, pbImei, true, true, true, 15, 15, 15, 15, "Elija el equipo");
            estEquipo = resultado.Item1;
            msjEquipo = resultado.Item2;
        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtSerie, lblSerie, pbSerie, true, true, true, 15, 15,15, 15, "Elija el equipo");
            estEquipo = resultado.Item1;
            msjEquipo = resultado.Item2;
        }

        private void txtSimcard_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtSimcard, lblSimCard, pbSimCard, true, true, true, 9, 9, 9, 9, "Elija el Sim Card");
            estSimCard = resultado.Item1;
            msjSimCard = resultado.Item2;
        }

        private Tuple<Boolean, String> fnValidarCombobox(SiticoneComboBox cbo, Label lbl, PictureBox img)
        {
            String msj;
            Boolean estado;

            if (cbo.SelectedIndex == 0 || cbo.SelectedIndex == -1 || cbo.SelectedIndex == null)
            {
                img.Image = Properties.Resources.error;


                lbl.ForeColor = Variables.ColorError;

                msj = "Seleccione una opción";
                lbl.Text = msj;
                estado = false;
                //return Tuple.Create(false, msj);

            }
            else if (clsChip.idEstadoEquipo == Convert.ToString(cbo.SelectedValue))
            {
                img.Image = Properties.Resources.ok;

                lbl.ForeColor = Variables.ColorSuccess;
                msj = "";
                lbl.Text = msj;
                estado = true;
            }
            else
            {
                if (Convert.ToString(cbo.SelectedValue) == "ESIM0001")
                {
                    img.Image = Properties.Resources.error;


                    lbl.ForeColor = Variables.ColorError;

                    msj = "Elija un estado diferente";
                    lbl.Text = msj;
                    estado = false;
                    //return Tuple.Create(false, msj);

                }
                else if (Convert.ToString(cbo.SelectedValue) == "ESIM0002" || Convert.ToString(cbo.SelectedValue) == "ESIM0004" || Convert.ToString(cbo.SelectedValue) == "ESIM0006")
                {
                    img.Image = Properties.Resources.error;


                    lbl.ForeColor = Variables.ColorError;

                    msj = "Estado Restringido elija uno diferente";
                    lbl.Text = msj;
                    estado = false;
                    //return Tuple.Create(false, msj);

                }
                else
                {

                    img.Image = Properties.Resources.ok;

                    lbl.ForeColor = Variables.ColorSuccess;
                    msj = "";
                    lbl.Text = msj;
                    estado = true;
                    


                }
            }

            return Tuple.Create(estado, msj);
        }
        private void cboPlataForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboPlataForma,lblPlataforma,pbPlataforma);
            estPlataforma = result.Item1;
            msjPlataforma = result.Item2;
        }
        private Tuple<Boolean, String> fnValidarFecha(SiticoneDateTimePicker dtp, PictureBox img, Label lbl, String msj)
        {
                if ((dtp.Value > Variables.gdFechaSis.AddHours(2)))
                {
                    lbl.Text = msj;
                    lbl.ForeColor = Variables.ColorError;
                    dtp.HoveredState.BorderColor = Variables.ColorError;
                    img.Image = Properties.Resources.error;
                    return Tuple.Create(false, msj);
                }
                else
                {
                    msj = "";
                    lbl.Text = msj;
                    img.Image = Properties.Resources.ok;
                    lbl.ForeColor = Variables.ColorSuccess;
                    dtp.HoveredState.BorderColor = Variables.ColorSuccess;
                    return Tuple.Create(true, msj);
                }
           

        }

        private void txtObservacion_TextChanged(object sender, EventArgs e)
        {
            //if (Convert.ToString(cboEstado.SelectedValue) != "ESIM0003")
            //{
                var result = FunValidaciones.fnValidarTexboxs(txtObservacion, lblObservacion, pbObservacion, false, true, false, 0, 0, 0, 200, "Es observaciones");
                estObservaciones = result.Item1;
                msjObservaciones = result.Item2;
            //}
            //else
            //{
            //    var result = FunValidaciones.fnValidarTexboxs(txtObservacion, lblObservacion, pbObservacion, true, true, true, 5, 50, 50, 200, "Es observaciones"); ;
            //    estObservaciones = result.Item1;
            //    msjObservaciones = result.Item2;
            //}
            
        }
        private void fnLimpiarControles()
        {
            if (dgEquipoAdmin.Visible==true)
            {
                dgEquipoAdmin.Visible = false;
            }
            cboPlataForma.SelectedValue = "0";
            txtEquipoUnico.Text = "";
            txtImei.Text = "";
            txtSerie.Text="";
            dtFecha.Value = DateTime.Today;
            txtObservacion.Text = "";
            txtSimcard.Text="";
            txtidSimCard.Text = "";
            txtIdSimCardExistente.Text = "";
            txtIdEquipoImei.Text = "";
            cboEstado.SelectedValue = "0";

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnActivarLinkHistorial();
            fnMostrarBotonLiberar(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void cboPaginacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResult = false;
           
                bResult = fnBuscarTabla(txtBuscar.Text.Trim(), Convert.ToInt32(cboPagina.Text.ToString()),-2, lnTipoLlamada);
                if (!bResult)
                {
                    MessageBox.Show("Error al buscar Imeis. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
           
           
        }

        private void cboBuscarModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboBuscarMarca.SelectedValue)!=0)
            {
                Boolean bResult = false;
                if (estPasoLoad)
                {
                    bResult = fnBuscarTabla(txtBuscar.Text.Trim(), Convert.ToInt32(cboPagina.SelectedValue), -1, lnTipoLlamada);
                    if (!bResult)
                    {
                        MessageBox.Show("Error al buscar Imeis. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                
            }
            
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {
            //if (dgEquipo.Visible == true)
            //{
            //    dgEquipo.Visible = false;
            //}
        }

        private void gbDatosEquipo_Click(object sender, EventArgs e)
        {
            if (dgEquipoAdmin.Visible == true)
            {
                dgEquipoAdmin.Visible = false;
            }
        }

        private void cboBuscarMarca_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cboEstadoBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            if (estPasoLoad)
            {
                //fnObtenerPaginacionEquipos(Convert.ToString(cboEstadoBuscar.SelectedValue), Convert.ToInt32(cboBuscarMarca.SelectedValue), Convert.ToInt32(cboBuscarModelo.SelectedValue));
                Boolean result = false;
                result=fnBuscarTabla(txtBuscar.Text.Trim(), Convert.ToInt32(cboPagina.SelectedValue), -1, lnTipoLlamada);
                if (result==false)
                {
                    MessageBox.Show("Error");
                }
            }
            
        }
        private DateTime fnCalcularSoloFecha(DateTime fecha)
        {
            String TextSoloFecha = fecha.ToString("yyyy/MM/dd");
            DateTime dtFecha = Convert.ToDateTime(TextSoloFecha);
            return dtFecha;
        }
        private Boolean fnBuscarHistorialImeis()
        {
            BLAdministrarEquipos objEquipo = new BLAdministrarEquipos();
            clsUtil objUtil = new clsUtil();
            DataTable datEquipo = new DataTable();
            Boolean HabilitarFechas;
            try
            {
                DateTime fechaInicio=fnCalcularSoloFecha(dtHFechaInicio.Value);
                DateTime fechaFinal = fnCalcularSoloFecha(dtHfechaFinal.Value).AddDays(1);
                HabilitarFechas = Convert.ToBoolean(chkHabilitarFechas.Checked);

                dgHistorial.Rows.Clear();

                datEquipo = objEquipo.blBuscarHistorialImeis(txtBuscarXImei.Text.ToString(),
                                                            txtBuscarXSimCard.Text.ToString(), HabilitarFechas,
                                                            fechaInicio, fechaFinal);

                //FunValidaciones.fnMostrarCantidadBusquedas(btnContadorRegistros, lblCantRegistros, datEquipo.Rows.Count, true, "Cantidad de registros");
                if (datEquipo.Rows.Count>0)
                {
                    lblMsgHistorial.Text = "";
                    foreach (DataRow drMenu in datEquipo.Rows)
                    {
                        dgHistorial.Rows.Add(
                            Convert.ToString(drMenu["EquipoUnico"]),
                            Convert.ToString(drMenu["Imei"]),
                            Convert.ToString(drMenu["cSimCard"]),
                            Convert.ToString(drMenu["ESTADO"]),
                            Convert.ToString(drMenu["PLATAFORMA"]),
                            Convert.ToString(drMenu["dFechaMovimiento"]),
                            Convert.ToString(drMenu["Observacion"]),
                            Convert.ToString(drMenu["PERSONAL"]));
                    }
                    //fnActivarCargandoGif(pbiImei, false);
                    //fnActivarCargandoGif(pbiSimCard, false);
                }
                else
                {
                    dgHistorial.Rows.Clear();
                    //fnActivarCargandoGif(pbiImei, false);
                    //fnActivarCargandoGif(pbiSimCard, false);
                    lblMsgHistorial.Text = "No se encontraron resultados para la busqueda";
                }
                

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }
        private void txtBuscarXImei_TextChanged(object sender, EventArgs e)
        {

        }
        private void fnActivarCargandoGif(SiticoneProgressIndicator gifBuscar, Boolean estado)
        {
            gifBuscar.AutoStart = estado;
            gifBuscar.Visible = estado;
        }
        private void txtBuscarXImei_KeyPress(object sender, KeyPressEventArgs e)
        {
            //fnActivarCargandoGif(pbiImei,true);
            FunValidaciones.fnValidarTipografia(e,"NUMEROS",true);
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtBuscarXImei.Text.Length>14)
                {
                    lblMsgHistorial.Text = "";
                    fnBuscarHistorialImeis();

                }
                else
                {
                    dgHistorial.Rows.Clear();
                    lblMsgHistorial.Text = "Porfavor ingrese completamente el IMEI (15 dijitos)";
                }
            }
        }

        private void txtBuscarXSimCard_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBuscarXSimCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            //fnActivarCargandoGif(pbiSimCard, true);
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", true);
            if (e.KeyChar == (Char)Keys.Enter)
            {

                if (txtBuscarXSimCard.Text.Length==9)
                {                    
                    lblMsgHistorial.Text = "";
                    fnBuscarHistorialImeis();

                }
                else
                {
                    dgHistorial.Rows.Clear();
                    lblMsgHistorial.Text = "Porfavor ingrese SimCard correctamente (9 dijitos)";
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            txtBuscarXImei.Text = txtImei.Text;
            txtBuscarXSimCard.Text = txtSimcard.Text;
            tabControl.SelectedIndex = 1;
            fnBuscarHistorialImeis();
        }

        private void dtHFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (txtBuscarXImei.Text.Length == 15 || txtBuscarXSimCard.Text.Length == 8)
            {
                fnBuscarHistorialImeis();
            }
            else
            {
                lblMsgHistorial.Text = "Porfavor ingrese por lo menos un metodo de busqueda (IMEI ó SIMCARD)";
            }
        }

        private void dtHfechaFinal_ValueChanged(object sender, EventArgs e)
        {
            if (txtBuscarXImei.Text.Length==15 || txtBuscarXSimCard.Text.Length==8)
            {
                fnBuscarHistorialImeis();
            }
            else
            {
                lblMsgHistorial.Text = "PorFavor ingrese por lo menos un metodo de busqueda (IMEI ó SIMCARD)";
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnNuevoHistorial_Click(object sender, EventArgs e)
        {
            txtBuscarXImei.Text = "";
            txtBuscarXSimCard.Text = "";
            if (dgHistorial.Rows.Count>0)
            {
                dgHistorial.Rows.Clear();
            }
        }
        private Boolean fnListarProspectoPlanEspecifico(SiticoneDataGridView dgv, Int32 opc)
        {
            BLProspecto objAcc = new BLProspecto();
            ProspectosPlan lstPros = new ProspectosPlan();
            DataTable dtAccesorio = new DataTable();
            clsUtil objUtil = new clsUtil();
            String Imei = "";
            String Simcard = "";
            try
            {

                Imei = Convert.ToString(dgv.Rows[dgv.CurrentRow.Index].Cells[2].Value.ToString());
                Simcard = Convert.ToString(dgv.Rows[dgv.CurrentRow.Index].Cells[4].Value.ToString());
                txtBuscarXImei.Text = Imei;
                txtBuscarXSimCard.Text = Simcard;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;
            }
        }
        private void opcVerImies_Click(object sender, EventArgs e)
        {
            Boolean bResul = false;

            bResul = fnListarProspectoPlanEspecifico(dgEquipoAdmin, 1);
            fnBuscarHistorialImeis();
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar movimiento de imei Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            tabControl.SelectedIndex = 1;
            
        }

        private void chkHabilitarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechas.Checked== true)
            {
                dtHFechaInicio.Enabled = true;
                dtHfechaFinal.Enabled = true;
            }
            else
            {
                dtHFechaInicio.Enabled = false;
                dtHfechaFinal.Enabled = false;
            }
            fnBuscarHistorialImeis();
        }

        private void btnLiberarSimCard_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ Está Seguro que Desea Liberar este Simcard ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fnLiberarSimCard();
            }
        }
        private void fnLiberarSimCard()
        {
            BLAdministrarEquipos obImeis = new BLAdministrarEquipos();
            Boolean bResp = false;
            objUtil = new clsUtil();

            try
            {
                bResp=obImeis.blLiberarChip(
                    Convert.ToInt32(txtIdEquipoImei.Text), 
                    Convert.ToInt32(txtIdSimCardExistente.Text),
                    Variables.gdFechaSis,
                    Variables.gnCodUser,
                    Convert.ToString(txtObservacion.Text)
                    );
                if (bResp)
                {
                    MessageBox.Show("Se Liberó correctamente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fnLimpiarControles();
                    btnLiberarSimCard.Visible = false;
                }
                else
                {
                    MessageBox.Show("Error en la liberación", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnLiberarSimCard.Visible = true;
                }
                //return true;
            }catch(Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                //return false;
            }
           

        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(cboEstado.SelectedValue)== "ESIM0003" || Convert.ToString(cboEstado.SelectedValue) == "ESIM0003")
            {
               var Result= fnValidarFecha(dtFecha,pbFecha,lblFechaMovimiento,"la Fecha no puede ser mayor a la fecha actual");
                estFecha = Result.Item1;
                msjFecha = Result.Item2;
            }
            else
            {
                var Result = fnValidarFecha(dtFecha, pbFecha, lblFechaMovimiento, "la Fecha no puede ser mayor a la fecha actual");
                estFecha = Result.Item1;
                msjFecha = Result.Item2;
            }
        }

        private void txtObsevacion_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgEquipo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                bResul = fnListarImeisEspecificos(e);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Imei Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

            }
        }

        private void pbPlataforma_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            txtEquipoUnico_TextChanged(sender, e);
            txtImei_TextChanged(sender, e);
            txtSerie_TextChanged(sender, e);
            txtSimcard_TextChanged(sender, e);
            cboPlataForma_SelectedIndexChanged(sender,  e);
            cboEstado_SelectedIndexChanged(sender, e);
            dtFecha_ValueChanged(sender, e);
            txtObservacion_TextChanged(sender, e);
            Boolean estadoChip = (Convert.ToString(cboEstado.SelectedValue) == "ESIM0003") ? true : estSimCard;
            Boolean estadoPlataforma = (Convert.ToString(cboEstado.SelectedValue) == "ESIM0003") ? true : estPlataforma;
            String result = "";
            if (estEquipo==true && estadoChip==true && estadoPlataforma == true && estEstado==true && estObservaciones==true) {
                result = fnGuardarMovimientoImeis(0);
                if (result == "ok")
                {
                    MessageBox.Show("Asignacion guardada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fnLimpiarControles();
                }
                else
                {
                    MessageBox.Show("Error en el registro -> comunicar al administrador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            else
            {
                MessageBox.Show("Complete correctamente todo los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            fnActivarLinkHistorial();
        }
        private void fnMostrarFechas(String msj)
        {
            if (Convert.ToString(cboEstado.SelectedValue) == "ESIM0001")
            {
                lblFechaEstado.Text = "Fecha de disponibilidad";
                gbFechas.Enabled = false;
                dtFecha.Value = Variables.gdFechaSis;

            }
            else if (Convert.ToString(cboEstado.SelectedValue) == "ESIM0002")
            {
                lblFechaEstado.Text = "Fecha que se activo";
                gbFechas.Enabled = false;
            }
            else if (Convert.ToString(cboEstado.SelectedValue) == "ESIM0003")
            {
                lblFechaEstado.Text = "Fecha de baja";
                gbFechas.Enabled = true;
            }
            else if (Convert.ToString(cboEstado.SelectedValue) == "ESIM0004")
            {
                lblFechaEstado.Text = "Fecha de expiracion";
                gbFechas.Enabled = true;
            }
            else if (Convert.ToString(cboEstado.SelectedValue) == "ESIM0005")
            {
                lblFechaEstado.Text = "Fecha de disponibilidad";
                gbFechas.Enabled = true;
                dtFecha.Value = Variables.gdFechaSis;
            }
        }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnMostrarFechas("");
            var result = fnValidarCombobox(cboEstado, lblEstado, pbEstado);
            estEstado = result.Item1;
            msjEstado = result.Item2;

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Boolean bResult = false;
            //if (txtBuscar.Text.Length>2) {
            //    lblMsgBusquedas.Visible = false;
            //    lblMsgBusquedas.Text = "";
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    bResult = fnBuscarTabla(txtBuscar.Text.Trim(), 0,-1, lnTipoLlamada);
                    if (!bResult)
                    {
                        MessageBox.Show("Error al buscar Imeis. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            //}
            //else
            //{
            //    dgEquipo.DataSource = 0;
            //    btnNumFilas.Text = "0";
            //    dgEquipo.Visible = false;
            //    lblMsgBusquedas.Visible = true;
            //    lblMsgBusquedas.Text = "Ingrese minimo 3 digitos";
            //}
        }

        private void txtEquipoUnico_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtEquipoUnico, lblEquipo, pbEquipo, true, true, false, 9, 9, 9, 9, "Elija el equipo");
            estEquipo = resultado.Item1;
            msjEquipo = resultado.Item2;
        }
    }
}
