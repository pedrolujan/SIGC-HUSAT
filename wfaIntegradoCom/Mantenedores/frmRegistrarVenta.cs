using CapaDato;
using CapaEntidad;
using CapaEntidad.Generic;
using CapaNegocio;
using CapaUtil;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using Siticone.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Consultas;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Funciones.Models;
using wfaIntegradoCom.Impresiones;
using wfaIntegradoCom.Procesos;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmRegistrarVenta : Form
    {
        public frmRegistrarVenta()
        {
            InitializeComponent();

        }
        public static class tipoCon {
            public static Int16 lnTipoConV { get; set; }
            public static Int16 lnTipoConC { get; set; }
            public static Int16 lnTipoConRP { get; set; }
        }


        private static VentaGeneral ClsVentaGeneral = new VentaGeneral();
        List<DetalleVenta> lstDetalleVDocumento = new List<DetalleVenta>();
        private static Cliente clsCliente = new Cliente();
        private static Cliente clsRespPago = new Cliente();
        private static Moneda clsMoneda = new Moneda();
        private static Plan clsPlan = new Plan();
        private static Moneda clsMonedaTarifa = new Moneda();
        private static Tarifa clsTarifa = new Tarifa();
        private static List<TipoTarifa> lstTipoTarifa = new List<TipoTarifa>();
        private static Ciclo clsCiclo = new Ciclo();
        private static List<DetalleVenta> lstTotalDetalle = new List<DetalleVenta>();
        private static TipoDescuento clsTD = new TipoDescuento();
        private static CambioMonedaVenta clsCMP = new CambioMonedaVenta();
        private static DetalleVentaCabecera clsDetalleCabecera = new DetalleVentaCabecera();
        private static List<TipoDocumento> lstTD = new List<TipoDocumento>();
        private static List<TipoPlan> lstTP = new List<TipoPlan>();
        private static List<Plan> lstP = new List<Plan>();
        private static List<Moneda> lstMon = new List<Moneda>();
        private static List<Vehiculo> lstVehiculo;
        private static List<Vehiculo> lstVehiculoSinRenovar=new List<Vehiculo>();
        private static List<Ciclo> lstC = new List<Ciclo>();
        private static List<DetalleVenta> lstPP = new List<DetalleVenta>();
        private static List<DetalleVenta> lstDV = new List<DetalleVenta>();
        private static List<DetalleVenta> lstDetalleVentaAnual = new List<DetalleVenta>();
        private static List<TipoDescuento> lstTDes = new List<TipoDescuento>();
        private static List<Pagos> lstPagosTrand = new List<Pagos>();
        private static List<DocumentoVenta> lsDocVenta = new List<DocumentoVenta>();

        static Equipo_imeis clsEquipo_imeis = new Equipo_imeis();
        static List<Equipo_imeis> lstEquipo_imeis = new List<Equipo_imeis>();

        static String cCodigoReferenciaInstalacion = "";
        static String cDescripcionReferenciaInstalacion = "";
        static DateTime dFechaDeInstalacion;
        Boolean bTipoTab = false;
        Boolean bActivarChecks = false;
        static Int16 lnTipoCon;
        static Int32 tabInicio;
        static Boolean estDescuento;
        static Int32 idEditar = 0;
        static List<validacion> lstValidacionCliente;
        static List<validacion> lstValidacionRespPago;
        static List<validacion> lstValidacionVehiculo;
        static List<validacion> lstValidacionPlan;
        static List<Cliente> lstClientesBusq = new List<Cliente>();
        public static String cCodigoVenta = "";
        static Double RestarDescuento = 0;
       
        Int32 idTipoPlanActual = 0;
        Int32 idPlanActual = 0;
        Int32 idCicloActual = 0;
        static Plan clsPlanActual = new Plan(); 

        static Boolean estGenrarVenta;
        static Boolean estActivarImprecion=false;
        static Int32 staticTipoTarifa = 0;
        Int32 lnTipoLlamada = 0;
        Boolean cargoFrom = false;

        static DateTime dttFechaRecibida = Variables.gdFechaSis;
        static Int32 inTipoApertura = 0;
        Boolean dEstadoBusquedaPaginacion = false;
        public void Inicio(Int16 pnTipoLlamada)
        {
            lnTipoLlamada = pnTipoLlamada;
            ShowDialog();

        }
        public void tipoApertura(DateTime dtt,Int32 tipoApertura)
        {
            dttFechaRecibida = dtt;
            inTipoApertura = tipoApertura;
            ShowDialog();
        }
        public static void fnRespuestaValidacion(Boolean estado)
        {
            estDescuento = estado;
        }
        private void fnValidarCliente()
        {
            lstValidacionCliente = new List<validacion>();

            //lstValidacionCliente.Add(new validacion { estado = false, mensaje = "", combobox = cboTipoClienteC });
            //lstValidacionCliente.Add(new validacion { estado = false, mensaje = "", combobox = cboTipoDocumentoC });
            lstValidacionCliente.Add(new validacion { estado = false, mensaje = "", textbox = txtDocumentoC });
        }
        private void fnValidarRespPago()
        {
            lstValidacionRespPago = new List<validacion>();
            //lstValidacionRespPago.Add(new validacion { estado = false, mensaje = "", combobox = cboTipoClienteRP });
            //lstValidacionRespPago.Add(new validacion { estado = false, mensaje = "", combobox = cboTipoDocumentoRP });
            lstValidacionRespPago.Add(new validacion { estado = false, mensaje = "", textbox = txtDocumentoRP });
        }
        private void fnValidarVehiculo()
        {
            lstValidacionVehiculo = new List<validacion>();
            lstValidacionVehiculo.Add(new validacion { estado = false, mensaje = "" });
        }

        private void fnValidarPlan()
        {
            lstValidacionPlan = new List<validacion>();
            lstValidacionPlan.Add(new validacion { estado = false, mensaje = "", combobox = cboTipoPlanP });
            lstValidacionPlan.Add(new validacion { estado = false, mensaje = "", combobox = cboPlanP });
            lstValidacionPlan.Add(new validacion { estado = false, mensaje = "", combobox = cboCicloP });
            lstValidacionPlan.Add(new validacion { estado = false, mensaje = "", combobox = cboComprobanteP });
        }
        private Boolean fnHabilitarDescuento(Boolean estado)
        {
            if (Convert.ToInt32(cboTipoPlanP.SelectedValue) == 2)
            {
                DataGridViewColumn ColDescuentoPP = dgvPrimerPago.Columns[6];

                Color colorColumnaPP = estado ? Color.White : Variables.ColorDescativadoFuerte;
                ColDescuentoPP.DefaultCellStyle.BackColor = colorColumnaPP;
                ColDescuentoPP.ReadOnly = estado ? false : true;

                if (dgvPrimerPago .Visible== false)
                {
                    DataGridViewColumn ColDescuentoTarifa = dgvPagoPlan.Columns[6];

                    Color colorColumna = estado ? Color.White : Variables.ColorDescativadoFuerte;
                    ColDescuentoTarifa.DefaultCellStyle.BackColor = colorColumna;
                    ColDescuentoTarifa.ReadOnly = estado ? false : true;
                }
                


            }
            else if (Convert.ToInt32(cboTipoPlanP.SelectedValue) == 1)
            {
                DataGridViewColumn ColDescuentoTarifa = dgvPagoPlan.Columns[6];

                Color colorColumna = estado ? Color.White : Variables.ColorDescativadoFuerte;
                ColDescuentoTarifa.DefaultCellStyle.BackColor = colorColumna;
                ColDescuentoTarifa.ReadOnly = estado ? false : true;

                DataGridViewColumn ColDescuentoPP = dgvPrimerPago.Columns[6];

                Color colorColumnaPP = estado ? Color.White : Variables.ColorDescativadoFuerte;
                ColDescuentoPP.DefaultCellStyle.BackColor = colorColumnaPP;
                ColDescuentoPP.ReadOnly = estado ? false : true;
            }
            else
            {
                DataGridViewColumn ColDescuentoPP = dgvPrimerPago.Columns[6];

                Color colorColumnaPP = estado ? Color.White : Variables.ColorDescativadoFuerte;
                ColDescuentoPP.DefaultCellStyle.BackColor = colorColumnaPP;
                ColDescuentoPP.ReadOnly = estado ? false : true;

                DataGridViewColumn ColDescuentoTarifa = dgvPagoPlan.Columns[6];

                Color colorColumna = estado ? Color.White : Variables.ColorDescativadoFuerte;
                ColDescuentoTarifa.DefaultCellStyle.BackColor = colorColumna;
                ColDescuentoTarifa.ReadOnly = estado ? false : true;
            }
            
            if (!estado)
            {
                cboTipoDescuentoPrecios.SelectedValue = 0;
                lstDV[0].Descuento = 0;
                //estDescuento = estado;
                return estado;
            }
            return estado;

        }
        public Boolean fnLlenarTipoPlan(Int32 idTipoPlan, SiticoneComboBox cbo, Int32 tipBusqueda)
        {
            BLTipoPlan objTipPlan = new BLTipoPlan();
            clsUtil objUtil = new clsUtil();
            List<TipoPlan> lstTipoPlan;

            try
            {
                lstTipoPlan = objTipPlan.blDevolverTipoPlan(idTipoPlan, tipBusqueda);
                cbo.ValueMember = "idTipoPlan";
                cbo.DisplayMember = "nombreTipoPlan";
                cbo.DataSource = lstTipoPlan;

                lstTP = lstTipoPlan;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }
        }

        private Boolean fnLlenarCiclo(Int32 idCiclo, SiticoneComboBox cbo, Boolean buscar)
        {
            BLCiclo objCiclo = new BLCiclo();
            clsUtil objUtil = new clsUtil();
            List<Ciclo> lstCiclo;

            try
            {
                lstCiclo = objCiclo.blDevolverCiclo(idCiclo, buscar);

                cbo.ValueMember = "IdCiclo";
                cbo.DisplayMember = "Dia";
                cbo.DataSource = lstCiclo;
                lstC = lstCiclo;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }
        }

        public Boolean fnLlenarTipoDescuento(Int32 idTipoDescuento, SiticoneComboBox cbo, Boolean buscar)
        {
            BLTipoDescuento objTipoDescuento = new BLTipoDescuento();
            clsUtil objUtil = new clsUtil();
            List<TipoDescuento> lstTipoDescuento;

            try
            {
                lstTipoDescuento = objTipoDescuento.blTipoDescuento(idTipoDescuento, buscar);
                cbo.ValueMember = "IdTipoDescuento";
                cbo.DisplayMember = "Nombre";
                cbo.DataSource = lstTipoDescuento;

                lstTDes = lstTipoDescuento;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }
        }

        private void cboTipoPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 idTipoPlan = Convert.ToInt32(cboTipoPlanP.SelectedValue ?? 0);
            Int32 idTipoventa = Convert.ToInt32(cboTipoVenta.SelectedValue);
            Boolean ocultarCiclo;
            chkHabilitarDescuentoP.Checked = false;
            estDescuento = false;
            fnHabilitarDescuento(estDescuento);
            var result = FunValidaciones.fnValidarCombobox(lstValidacionPlan[0].combobox, erTipoPlan, imgTipoPlanP);
            lstValidacionPlan[0].estado = result.Item1;
            lstValidacionPlan[0].mensaje = result.Item2;

            if(idTipoPlan == 1)
            {
                lstValidacionPlan[2].estado = true;
                lstValidacionPlan[2].mensaje = "";
                fnOcultarCiclo(false);

                fnOcultarParaRenovacion(dgvPrimerPago, lblPanelPrimerPago, true);

            }
            else
            {
                fnOcultarCiclo(true);
                if (idTipoPlan == 2 && Convert.ToInt32(cboTipoVenta.SelectedValue)==2)
                {
                    fnOcultarParaRenovacion(dgvPagoPlan, lblPagoPlan, false);
                }
            }
            if (cboTipoPlanP.SelectedValue.ToString() == "0" || cboTipoPlanP.SelectedValue == null)
            {
                cboPlanP.Enabled = false;
            }
            else
            {
                idTipoPlan = Convert.ToInt32(cboTipoPlanP.SelectedValue.ToString());
                cboPlanP.Enabled = true;
            }

            

            fnLlenarPlanDeTipoPlan(idTipoPlan, cboPlanP, false, lnTipoCon);
            ocultarCiclo = TipoPlan.fnObtenerTipoPlanSeleccionado(idTipoPlan, lstTP).conCiclo;
            cboCicloP.Visible = ocultarCiclo;
            lblCicloP.Visible = ocultarCiclo;
            int numMeses = TipoPlan.fnObtenerTipoPlanSeleccionado(idTipoPlan, lstTP).cMeses;
            lstDV[0].Couta = fnObtenerCuota(numMeses);
            fncalcularTotales(lstPP, lstDV);
        }
        
        private void fnOcultarParaRenovacion(DataGridView dgv,Label lbl,Boolean estado)
        {
            dgv.Visible = estado;
            lbl.Visible = estado;
            lbl.Text = "";
            if (Convert.ToInt32(cboTipoVenta.SelectedValue) == 2)
            {
                //lblPanelPrimerPago.Size = new Size(151, 49);
                lblPanelPrimerPago.Text = "PAGO RENOVACIÓN";
                lblPagoPlan.Text = "";
                lblPanelPrimerPago.Font = new Font("Calibri", 10, System.Drawing.FontStyle.Bold);
            }
            else
            {
                //lblPanelPrimerPago.Size = new Size(151, 92);
                lblPanelPrimerPago.Text = "PAGO INICAL";
                lblPanelPrimerPago.Font = new Font("Calibri", 12, System.Drawing.FontStyle.Bold);
            }

        }
        private void fnActivarDgvAnual(Boolean est)
        {
            dgvPagoPlan.Visible = est;
            lblPagoPlan.Visible = est;

        }
        private void fnOcultarCiclo(bool estado)
        {
            lblCicloP.Visible = estado;
            cboCicloP.Visible = estado;
            
            
            imgCicloP.Image = null;
            erCilcloP.Text = "";
        }
        private Boolean fnLlenarPlanDeTipoPlan(Int32 idTipoPlan, SiticoneComboBox cbo, Boolean tipBusqueda, Int16 tipoCon)
        {
            BLPlan objPlan = new BLPlan();
            clsUtil objUtil = new clsUtil();
            List<Plan> lstPlan;

            try
            {
                lstPlan = objPlan.blDevolverPlanDeTipoPlan(idTipoPlan, tipBusqueda, tipoCon);

                cbo.ValueMember = "idPlan";
                cbo.DisplayMember = "nombrePlan";
                cbo.DataSource = lstPlan;

                lstP = lstPlan;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        public static void fnRecuperarTipoPago(List<Pagos> lstEntidades)
        {
            lstPagosTrand = lstEntidades;
        }
        void cboCronograma_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void frmRegistrarVenta_Load(object sender, EventArgs e)
        { 
           
            try
            {
                lnTipoCon = 0;
                cargoFrom = false;
                bActivarChecks = false;
                bTipoTab = false;
                fnLlenarTipoTarifa(0, cboTipoVetaBusq, true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboEstadoContrato, "TICN", true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboTipoFiltro, "TFRV", true);
                cboTipoFiltro.SelectedValue = "TFRV0001";
                //cbPlanVentas.SelectedValue=
                cboTipoVetaBusq.SelectedValue = 0;
                dtpFechaRegistro.Value = Variables.gdFechaSis;
                dtFechaPago.Value = Variables.gdFechaSis;
                //FunGeneral.fnValidarFechaPago(dtFechaPago, pbFechaPago, 0);
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
                if (Variables.gsCargoUsuario == "PETR0001" || Variables.gsCargoUsuario == "PETR0005" || Variables.gsCargoUsuario == "PETR0007")
                {
                    pnMontoGanania.Visible = true;
                }
                else
                {
                    pnMontoGanania.Visible = false;
                }

                if (lnTipoLlamada == 0)
                {
                    btnStockEquipos.Text = Convert.ToString(fnObtenerStockEquipos());
                    Boolean bResult;

                    clsEquipo_imeis = new Equipo_imeis();
                    lstEquipo_imeis = new List<Equipo_imeis>();
                    //Inicializar Clases
                    ClsVentaGeneral = new VentaGeneral();
                    clsCliente = new Cliente();
                    clsRespPago = new Cliente();
                    clsMoneda = new Moneda();
                    clsMonedaTarifa = new Moneda();
                    clsTarifa = new Tarifa();
                    clsTD = new TipoDescuento();
                    clsCMP = new CambioMonedaVenta();
                    clsDetalleCabecera = new DetalleVentaCabecera();
                    lstDV = new List<DetalleVenta>();

                    //Inicializar Lista
                    lstVehiculo = new List<Vehiculo>();
                    lstTD = new List<TipoDocumento>();
                    lstPagosTrand = new List<Pagos>();
                    lstTP = new List<TipoPlan>();
                    lstP = new List<Plan>();
                    lstMon = new List<Moneda>();
                    lstC = new List<Ciclo>();
                    lstPP = new List<DetalleVenta>();
                    lstDV = new List<DetalleVenta>();
                    lstTDes = new List<TipoDescuento>();
                    //Inicializar Validaciones
                    fnValidarCliente();
                    fnValidarRespPago();
                    fnValidarVehiculo();
                    fnValidarPlan();
                    fnMostrarParaActualizar(true);

                    fnCargarTablaTarifa();
                    lstPP = fnCargarDatosPagoPrincipal();
                    
                    
                    tipoCon.lnTipoConV = 0;
                    tipoCon.lnTipoConC = 0;
                    tipoCon.lnTipoConRP = 0;
                    estDescuento = false;
                    //Cargar Combos
                    fnLlenarTipoTarifa(0, cboTipoVenta, false);
                    fnLlenarTipoPlan(0, cbPlanVentas, 0);
                    cboTipoVenta.SelectedValue = 1;
                    fnLlenarTipoPlan(0, cboTipoPlanP, 0);
                    bResult = fnLlenarCiclo(0, cboCicloP, false);
                    if (!bResult)
                    {
                        MessageBox.Show("Error al Cargar Ciclo", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    bResult = fnLlenarTipoDescuento(0, cboTipoDescuentoPrecios, false);
                    if (!bResult)
                    {
                        MessageBox.Show("Error al Tipo Descuento", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    bResult = fnLlenarTipoDescuento(0, cboTipoDescuentoPrecios, false);
                    if (!bResult)
                    {
                        MessageBox.Show("Error al Tipo Descuento", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }

                    //bResult = fnLLenarTipoPersona(cboTipoClienteC, 0, "", false);
                    //if (!bResult)
                    //{
                    //    MessageBox.Show("Error al Cargar Cliente", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    this.Close();
                    //}
                    //bResult = fnLLenarTipoPersona(cboTipoClienteRP, 0, "", false);
                    //if (!bResult)
                    //{
                    //    MessageBox.Show("Error al Cargar Responsable de Pago ", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    this.Close();
                    //}
                    bResult = fnLLenarMoneda(cboMonedaP, 0, false);
                    if (!bResult)
                    {
                        MessageBox.Show("Error al Cargar Moneda", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }


                    cboMonedaP.SelectedIndex = 1;
                    fnHabilitarDescuento(estDescuento);
                    fnLimpiarControles();
                    fnActivarImpresion(lblSWSi, false);

                    if (Variables.gsCargoUsuario == "PETR0001" || Variables.gsCargoUsuario == "PETR0005" || Variables.gsCargoUsuario == "PETR0007")
                    {
                        cmListaVentas.Items[0].Visible = true;
                        cmListaVentas.Items[2].Visible = false;
                    }
                    else
                    {
                        cmListaVentas.Items[0].Visible = false;
                        cmListaVentas.Items[2].Visible = false;
                    }
                    //ColorThemas.ElegirThema(Variables.clasePersonal.codTema);
                    FunGeneral.fnThemaAFormularios(siticonePanel1);
                    FunGeneral.fnThemaAFormularios(gbDinamico);
                }
                else if (lnTipoLlamada == 1)
                {

                }
                else if (lnTipoLlamada == 2)
                {

                }
                else if (lnTipoLlamada == 3)
                {
                    tabControl1.SelectedIndex = 1;
                    tabControl1.Controls.RemoveAt(0);                    
                }

                if (inTipoApertura==0)
                {
                    dtFechaPago.Enabled = true;
                    dtpFechaInicialBus.Enabled = true;
                    dtpFechaFinalBus.Enabled = true;
                }
                else if (inTipoApertura==-1)
                {
                    dtFechaPago.Value = dttFechaRecibida;
                    dtpFechaInicialBus.Value = dttFechaRecibida;
                    dtpFechaFinalBus.Value = dttFechaRecibida;
                    dtFechaPago.Enabled = false;
                    dtpFechaInicialBus.Enabled = false;
                    dtpFechaFinalBus.Enabled = false;

                }

                cboCicloP.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                //cboTipoClienteC.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboMonedaP.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                //cboTipoClienteRP.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboTipoDescuentoPrecios.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                //cboTipoDocumentoRP.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                //cboTipoDocumentoC.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboTipoVenta.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboTipoFiltro.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboTipoVetaBusq.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboComprobanteP.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboEstadoContrato.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboTipoPlanP.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboPlanP.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cargoFrom = true;
                Int32 numRows = 0;
                String dtt1 = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 5); ;
                numRows = FunGeneral.fnBuscarAccionDiaria(-1, dtt1);
                if (numRows == 0)
                {
                    fnActualizarEstadoContratoAutomatico();
                    FunGeneral.fnRegistrarAccionDiaria("Actualizacion estados Contrato", true, -1, FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 3));
                }
               
            }
            
        }
        private void fnActualizarEstadoContratoAutomatico()
        {
            clsUtil objUtil = new clsUtil();
            BLVentaGeneral blVentaGeneral = new BLVentaGeneral();
            Boolean bResult;

                bResult = blVentaGeneral.blActualizarEstadoContratoAutomatico(0);
            

        }


        private Tuple<bool,string> fnValidarTabla(List<Vehiculo> lstVehiculo)
        {
            int cantVehiculos = lstVehiculo.Count();
            if(cantVehiculos == 0)
            {
                imgTabla.Image = Properties.Resources.error;
                erTabla.Text = "Agregé minimo un Vehiculo  a la tabla";
                erTabla.BackColor = Color.White;
                erTabla.ForeColor = Color.Red;
                return Tuple.Create(false, "Agregé minimo un Vehiculo  a la tabla");
            }
            imgTabla.Image = Properties.Resources.ok;
            erTabla.Text = "";
            return Tuple.Create(true, "");
        }
        private Boolean fnLLenarTipoPersona(ComboBox cbo, Int32 idTipoCliente, String est, Boolean buscar)
        {
            BLTipoCliente objClaseV = new BLTipoCliente();
            clsUtil objUtil = new clsUtil();
            List<TipoCliente> lstTC;

            try
            {
                lstTC = objClaseV.blDevolverTipoCliente(idTipoCliente, est, buscar);
                cbo.ValueMember = "TCid";
                cbo.DisplayMember = "TCnombre";
                cbo.DataSource = lstTC;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarClaseVehiculo", ex.Message);
                return false;
            }
            finally
            {
                lstTC = null;
            }
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

                lstMon = lstMoneda;

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
        private Boolean fnLLenarDocumentoDeTipoPersona(ComboBox cbo, Int32 idDocumento, String est, Boolean buscar)
        {
            BLTipoCliente objClaseV = new BLTipoCliente();
            clsUtil objUtil = new clsUtil();
            List<TipoDocumento> lstTC = new List<TipoDocumento>();

            try
            {
                lstTC = objClaseV.blDevolverDocumentoDeTipoCliente(idDocumento, est, buscar);
                cbo.ValueMember = "TDid";
                cbo.DisplayMember = "TDnombre";
                cbo.DataSource = lstTC;
                lstTD = lstTC;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarClaseVehiculo", ex.Message);
                return false;
            }
            finally
            {
                lstTC = null;
            }
        }

        private void cboPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargoFrom)
            {
                if (Convert.ToInt32(cboPlanP.SelectedValue) != 0)
                {
                    fnCargarTablaTarifa();
                }

                Int32 idPlan = FunValidaciones.fnObtenerIdDeComboBox(cboPlanP);

                clsPlan = Plan.fnObtenerPlanSeleccionado(idPlan, lstP);
                var result = FunValidaciones.fnValidarCombobox(lstValidacionPlan[1].combobox, erPlanP, imgPlanP);
                lstValidacionPlan[1].estado = result.Item1;
                lstValidacionPlan[1].mensaje = result.Item2;
                if (idPlan == 0)
                {

                }
                else
                {
                }
                //if (ClsVentaGeneral.ClsTarifa is Tarifa)
                //{

                //    if (clsTarifa.IdTarifa != 0 && lnTipoCon != 0)
                //    {
                //        fnDevolverPrecioTarifa(idPlan, Convert.ToInt32(cboTipoVenta.SelectedValue), ClsVentaGeneral.codigoVenta, 1);
                //    }
                //    else
                //    {
                Boolean estChk = siticoneCheckBox1.Checked;
                fnDevolverPrecioTarifa(idPlan, Convert.ToInt32(cboTipoVenta.SelectedValue), ClsVentaGeneral.codigoVenta, lnTipoCon, estChk);
                        //ClsVentaGeneral.ClsTarifa = clsTarifa;
                //    }

                //}
                //else
                //{
                //    fnDevolverPrecioTarifa(idPlan, Convert.ToInt32(cboTipoVenta.SelectedValue), ClsVentaGeneral.codigoVenta, 1);
                //}
                //fnCargarTablaTarifa();
                lstDV[0].idTipoTarifa = clsTarifa.IdTarifa;
                fnCalcularTotalPago();
                lstPP = fnGenerarPagoPrincipal();

                fnCargaTablaDetalle(lstPP, dgvPrimerPago);
                fncalcularTotales(lstPP, lstDV);

                btnStockEquipos.Text = Convert.ToString(fnObtenerStockEquipos());
            }
            
            
        }
        private void fncalcularTotales( List<DetalleVenta> lstPP,List<DetalleVenta> lstDV)
        {
            List<DetalleVenta> lstT = new List<DetalleVenta>();
            Int32 idTipoVenta = Convert.ToInt32(cboTipoVenta.SelectedValue);
            Int32 idTipoPlan = Convert.ToInt32(cboTipoPlanP.SelectedValue);
            lstDV[0].Numeracion = lstPP.Count + 1;
            
            if (idTipoVenta == 1)
            {
                if (idTipoPlan==1)
                {
                    lstT = lstPP.Union(lstDV).ToList();
                    //if (lstT[0].Numeracion== lstT[1].Numeracion)
                    //{
                    //    lstT[1].Numeracion += 1;
                    //}
                    //else
                    //{
                    //    lstT[1].Numeracion = 1;
                    //}
                    //lstPP[1] = lstDV[0];
                    //lstPP[1].Numeracion = lstDV[0].Numeracion + 1;
                    //lstT = lstPP;

                }
                else if (idTipoPlan==2)
                {
                    lstT = lstPP.Union(lstDV).ToList();
                }

            }
            else if (idTipoVenta == 2)
            {
                
                if (idTipoPlan == 1)
                {
                    lstT = lstDV;
                    
                }
                else if (idTipoPlan == 2)
                {
                    lstT = lstPP.Count==0? lstDV: lstPP;
                    //lstT=lstPP.Union(lstDV).ToList();
                }
            }
            else if (idTipoVenta == 3)
            {
                if (idTipoPlan == 1)
                {
                    lstT = lstPP.Union(lstDV).ToList();
                }
                else if (idTipoPlan == 2)
                {
                    lstT = lstPP.Union(lstDV).ToList();
                }
            }
            //lstPP = lstT;
            //lstT = lstPP.Union(lstDV).ToList();
            lstTotalDetalle = lstT;
           fnCalcularCabeceraDetalle(lstT, true);
        }
        private Boolean fnDevolverPrecioTarifa(Int32 idPlan, Int32 peTipoTarifa, String codVenta,Int32 lnTipoCon,Boolean estChk)
        {
            BLTipoTarifa objBlTipTarifa = new  BLTipoTarifa();
            clsUtil objUtil = new clsUtil();
            Tarifa clsTipTarifa = new Tarifa();
            try
            {
                clsTipTarifa = objBlTipTarifa.blDevolverPrecios(idPlan, peTipoTarifa,  codVenta,  lnTipoCon, estChk);
                if (clsTipTarifa.IdTarifa>0)
                {
                    clsTarifa = clsTipTarifa;
                }
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarClaseVehiculo", ex.Message);
                return false;
            }
        }
       
        public Boolean fnLlenarTipoTarifa(Int32 idTipoPlan, SiticoneComboBox cbo, Boolean busqueda)
        {
            BLTipoTarifa objTipTarifa = new BLTipoTarifa();
            clsUtil objUtil = new clsUtil();
            List<TipoTarifa> lstTipTarifa = new List<TipoTarifa>();

            try
            {
                lstTipTarifa = objTipTarifa.blDevolverTipoTarifa(idTipoPlan, busqueda);

                cbo.ValueMember = "IdTipoTarifa";
                cbo.DisplayMember = "Nombre";
                cbo.DataSource = lstTipTarifa;
                if (busqueda!=true)
                {
                    lstTipoTarifa = lstTipTarifa;
                }
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }
        private void btnAbrirCronograma_Click(object sender, EventArgs e)
        {
            VentaGeneral clsVentaGeneral = new VentaGeneral();
            VentaGeneral clsVentaGenral = ClsVentaGeneral;
            List<Vehiculo> lstV = lstVehiculo;
            Plan clsPlan = new Plan();
            TipoPlan clsTPlan = new TipoPlan();
            int idComboTipoPlan = Convert.ToInt32(cboTipoPlanP.SelectedValue ?? 0);
            int idComboPlan = Convert.ToInt32(cboPlanP.SelectedValue ?? 0);
            clsPlan = Plan.fnObtenerPlanSeleccionado(idComboPlan,lstP);
            clsTPlan = TipoPlan.fnObtenerTipoPlanSeleccionado(idComboTipoPlan, lstTP);
            clsVentaGeneral.FechaRegistro = Convert.ToDateTime(dtpFechaRegistro.Value);

            Procesos.frmCronograma abrirFrmCronograma = new Procesos.frmCronograma();
            abrirFrmCronograma.Inicio(fnGenerarCronograma(dtpFechaRegistro.Value), lstV, lstPP, lstMon);
        }

        private void siticoneGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnIrACliente_Click(object sender, EventArgs e)
        {
            frmRegistrarCliente f = new frmRegistrarCliente();
            f.Show();
        }

        private void btnIrAVehículo_Click(object sender, EventArgs e)
        {
            frmRegistrarVehiculo f = new frmRegistrarVehiculo();
            f.Show();
        }
        private void fnHabilitarCboPlanes(Boolean estado)
        {
            
                cboTipoPlanP.Enabled = estado;
                cboPlanP.Enabled = estado;
                cboCicloP.Enabled = estado;
           
        }
        private void fnHabilitarBotonesC(Boolean estTipoCli,Boolean estTipoDoc, Boolean estDocumento, Boolean estNombre)
        {
            //cboTipoClienteC.Enabled = estTipoCli;
            //cboTipoDocumentoC.Enabled = estTipoDoc;
            txtDocumentoC.ReadOnly = !estDocumento;
            txtNombreC.ReadOnly = !estNombre;
            
        }
        private void fnHabilitarBotonesRP(Boolean estTipoCli, Boolean estTipoDoc, Boolean estDocumento, Boolean estNombre)
        {
            //cboTipoClienteRP.Enabled = estTipoCli;
            //cboTipoDocumentoRP.Enabled = estTipoDoc;
            txtDocumentoRP.ReadOnly = !estDocumento;
            txtNombreRP.ReadOnly = !estNombre;
        }

        private Boolean fnListarClienteEspecifico(SiticoneDataGridView dgv,Int32 opcTipoCli)
        {
            BLCliente objAcc = new BLCliente();
            Cliente lstPros;
            clsUtil objUtil = new clsUtil();
            Int32 idCliente;
            try
            {
                idCliente = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value.ToString());

                if (idCliente == 0)
                {
                }
                else
                {
                    lstPros = objAcc.blListarCliente(idCliente,1);
                    
                    if (lstPros.idCliente > 0)
                    {
                        if (opcTipoCli == 1)
                        {
                            clsCliente = lstPros;
                            tipoCon.lnTipoConC = 1;
                            fnHabilitarBotonesC(false, false, false, false);
                            txtDocumentoC.Text = lstPros.cDocumento.Trim();
                            txtNombreC.Text = $"{ lstPros.cNombre.Trim()} {lstPros.cApePat.Trim()} {lstPros.cApeMat.Trim()}";
                            txtCorreoC.Text = lstPros.cCorreo.Trim();
                            txtTelefonoFijoC.Text = lstPros.cTelFijo.Trim();
                            txtCelularC.Text = lstPros.cTelCelular.Trim();
                            txtDireccionC.Text = lstPros.cDireccion.Trim();
                            
                        }
                        else
                        {
                            clsRespPago = lstPros;
                            tipoCon.lnTipoConRP = 1;

                            fnHabilitarBotonesRP(false, false, false, false);
                            txtDocumentoRP.Text = lstPros.cDocumento.Trim();
                            txtNombreRP.Text = $"{ lstPros.cNombre.Trim()} {lstPros.cApePat.Trim()} {lstPros.cApeMat.Trim()}";
                            txtCorreoRP.Text = lstPros.cCorreo.Trim();
                            txtTelefonoFijoRP.Text = lstPros.cTelFijo.Trim();
                            txtCelularRP.Text = lstPros.cTelCelular.Trim();
                            txtDireccionRP.Text = lstPros.cDireccion.Trim();
                            fnLlenarComprobante(cboComprobanteP, "DOVE", clsRespPago.cTiDo, 0);
                        }
                        dgDocumentoC.Visible = false;
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

        
        //private void cboTipoClienteC_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Int32 idTipoCliente = Convert.ToInt32(cboTipoClienteC.SelectedValue ?? 0);
        //    fnLLenarDocumentoDeTipoPersona(cboTipoDocumentoC, idTipoCliente, "", false);
        //    var result = FunValidaciones.fnValidarCombobox(lstValidacionCliente[0].combobox, erTipoClienteC, imgTipoClienteC);
        //    lstValidacionCliente[0].estado = result.Item1;
        //    lstValidacionCliente[0].mensaje = result.Item2;

        //    if(idTipoCliente == 0)
        //    {
        //        cboTipoDocumentoC.Enabled = false;
        //    }
        //    else
        //    {
        //        cboTipoDocumentoC.Enabled = true;
        //    }
        //}

        private void txtDocumentoC_TextChanged(object sender, EventArgs e)
        {
            //Int32 idTipDocumento = Convert.ToInt32(cboTipoDocumentoC.SelectedValue ?? 0);         
            //Int32 maxCaracteres = TipoDocumento.fnObtenerTipoDocumentoSeleccionado(idTipDocumento, lstTD).TDmaxCaracteres;
            var result = FunValidaciones.fnValidarTexboxs(lstValidacionCliente[0].textbox, erDocumentoC, imgDocumentoC, true, true, true, 3,20 , 20, 20, "Ingrese correctamente");
            lstValidacionCliente[0].estado = true;
                //result.Item1;
            lstValidacionCliente[0].mensaje = result.Item2; 

            Int32 numCaracNroDocumento = txtDocumentoC.TextLength;

            if (numCaracNroDocumento >= 3)
            {
                Boolean bResul;
                if (Convert.ToInt32(cboTipoVenta.SelectedValue) == 2)
                {
                    bResul = fnBuscarCliente(txtDocumentoC, 0, -4, dgDocumentoC, tipoCon.lnTipoConC);
                }
                else
                {
                    bResul = fnBuscarCliente(txtDocumentoC, 0, -3, dgDocumentoC, tipoCon.lnTipoConC);
                }
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Vehiculo. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                dgDocumentoC.Visible = false;
            }
           

        }

        public Boolean fnBuscarCliente(SiticoneTextBox txt, Int32 Pagina, Int16 TipoConPagina, DataGridView dgv, Int32 tipcon)
        {
            BLCliente objVehi = new BLCliente();
            DatosEnviarVehiculo objEnvio = new DatosEnviarVehiculo();
            clsUtil objUtil = new clsUtil();
            DataTable datCliente;
            Int32 totalResultados;

            try
            {
                if (tipcon == 1)
                {
                    dgv.Visible = false;
                }
                else
                {
                    String nroDocumento = txt.Text.Trim();
                    String nombreCliente = "";

                    String Representante = "";
                  
                    Int32 estCliente = 1; 

                    datCliente = objVehi.blBuscarCliente(nroDocumento, estCliente, Pagina,TipoConPagina);
                    totalResultados = datCliente.Rows.Count;

                    if (totalResultados > 0)
                    {
                        if (Convert.ToInt32(cboTipoVenta.SelectedValue) == 2)
                        {
                            DataTable dt = new DataTable();
                            dt.Clear();
                            dt.Columns.Add("CodVenta");
                            dt.Columns.Add("idCliente");
                            dt.Columns.Add("DETALLE");
                            dt.Columns.Add("Placa");

                            for (int i = 0; i <= totalResultados - 1; i++)
                            {
                               
                                    object[] row =
                                    {
                                    datCliente.Rows[i][0],
                                    datCliente.Rows[i][1],
                                    datCliente.Rows[i][2],
                                    datCliente.Rows[i][3]
                                    };
                                    dt.Rows.Add(row);

                            }

                            dgv.DataSource = dt;
                            dgv.Columns[0].Visible = false;
                            dgv.Columns[1].Visible = false;
                            dgv.Columns[2].Width = 100;
                        }
                        else
                        {
                            DataTable dt = new DataTable();
                            dt.Clear();
                            dt.Columns.Add("ID");
                            dt.Columns.Add("DETALLE");

                            for (int i = 0; i <= totalResultados - 1; i++)
                            {
                                Boolean estadoVehiculo = TipoConPagina==-1? Convert.ToBoolean(datCliente.Rows[i][7]) : Convert.ToBoolean(datCliente.Rows[i][6]);
                                if (estadoVehiculo)
                                {
                                    object[] row =
                                    {
                                        datCliente.Rows[i][0],
                                        TipoConPagina==-1?datCliente.Rows[i][6]+" - "+ datCliente.Rows[i][1]:datCliente.Rows[i][5]+" - "+ datCliente.Rows[i][1]
                                    };
                                    dt.Rows.Add(row);
                                }

                            }

                            dgv.DataSource = dt;
                            dgv.Columns[0].Visible = false;
                            dgv.Columns[1].Width = 100;
                        }
                        

                        dgv.Visible = true;
                    }
                    else
                    {
                        dgv.Visible = false;
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnBuscarVehiculo", ex.Message);
                return false;
            }
            finally
            {
                objVehi = null;
                objUtil = null;
            }

        }

        public static Boolean fnLlenarComprobante(ComboBox cboCombo, String cCodTab, Int32 idTipoDocPers, Int32 Busqueda)
        {
            BLOtrasVenta objTablaCod = new BLOtrasVenta();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstComprobante = new List<Cargo>();

            try
            {
                lstComprobante = objTablaCod.blDevolverTablaCod(cCodTab, idTipoDocPers, Busqueda);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstComprobante;
                lsDocVenta.Add(new DocumentoVenta
                {
                    cTipoDoc=lstComprobante[1].cCodTab,
                    cDocVenta=lstComprobante[1].cNomTab
                });
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FunGeneral", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
            }

        }

        //private void cboTipoDocumentoC_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Int32 idTD = Convert.ToInt32(cboTipoDocumentoC.SelectedValue ?? 0);
        //    txtDocumentoC.Text = "";
        //    if (idTD == 0)
        //    {
        //        txtDocumentoC.Enabled = false;
        //    }
        //    else
        //    {
        //        txtDocumentoC.Enabled = true;
        //    }

        //    var result = FunValidaciones.fnValidarCombobox(lstValidacionCliente[1].combobox, erTipoDocumentoC, imgTipoDocumentoC);
        //    lstValidacionCliente[1].estado = result.Item1;
        //    lstValidacionCliente[1].mensaje = result.Item2;
        //    fnLlenarComprobante(cboComprobanteP, "DOVE", idTD, 0);
        //}

        private void txtDocumentoC_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", false);
        }

        private void dgDocumentoC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean bResul = false;
            lnTipoCon = 0;
            if (Convert.ToInt32(cboTipoVenta.SelectedValue)==2)
            {
                String codVt = Convert.ToString(dgDocumentoC.CurrentRow.Cells[0].Value);
                Int32 idCliente = Convert.ToInt32(dgDocumentoC.CurrentRow.Cells[1].Value);
                //Int32 idContrato = Convert.ToInt32(dgDocumentoC.CurrentRow.Cells[14].Value);
                fnDevolverVehiculoRenovacion(codVt, idCliente,"", idCliente);
                fnHabilitarBotonesC(false, false, false, false);
                fnHabilitarCboPlanes(false);
                if (Convert.ToInt32(cboTipoPlanP.SelectedValue) == 1)
                {

                }
            }
            else
            {
                bResul = fnListarClienteEspecifico(dgDocumentoC, 1);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            
        }

        private void btnLimpiarC_Click(object sender, EventArgs e)
        {
            //Grupo Cliente
            clsCliente = new Cliente();
            //cboTipoClienteC.SelectedValue = 0;
            //cboTipoClienteC.Enabled = true;
            txtNombreC.Text = "";
            txtCorreoC.Text = "";
            txtTelefonoFijoC.Text = "";
            txtCelularC.Text = "";
            txtDireccionC.Text = "";
            txtDocumentoC.ReadOnly = false;
            tipoCon.lnTipoConC = 0;

            //imgTipoClienteC.Image = null;
            //imgTipoDocumentoC.Image = null;
            imgDocumentoC.Image = null;
            //erTipoClienteC.Text = "";
            //erTipoDocumentoC.Text = "";
            erDocumentoC.Text = "";
        }

        private void fnLimpiarControles()
        {
            
            //Grupo Cliente
            clsCliente = new Cliente();
            //cboTipoClienteC.SelectedValue = 0;
            //cboTipoClienteC.Enabled = true;
            txtNombreC.Text = "";
            txtCorreoC.Text = "";
            txtTelefonoFijoC.Text = "";
            txtCelularC.Text = "";
            txtDireccionC.Text = "";
            txtDocumentoC.ReadOnly = false;
            tipoCon.lnTipoConC = 0;

            //imgTipoClienteC.Image = null;
            //imgTipoDocumentoC.Image = null;
            imgDocumentoC.Image = null;
            //erTipoClienteC.Text = "";
            //erTipoDocumentoC.Text = "";
            //erDocumentoC.Text = "";

            //Grupo Responsable Pago
            //cboTipoClienteRP.Enabled = true;
            //cboTipoDocumentoRP.SelectedValue = 0;
            txtDocumentoRP.ReadOnly = false;
            txtDocumentoRP.Text = "";
            txtNombreRP.Text = "";
            txtCorreoRP.Text = "";
            txtTelefonoFijoRP.Text = "";
            txtCelularRP.Text = "";
            txtDireccionRP.Text = "";
            tipoCon.lnTipoConRP = 0;
            clsRespPago = new Cliente();
            rdbNo.Checked = true;

            //imgTipoClienteRP.Image = null;
            //imgTipoDocumentoRP.Image = null;
            imgDocumentoRP.Image = null;
            //erTipoClienteRP.Text = "";
            //erTipoDocumentoRP.Text = "";
            erDocumentoRP.Text = "";

            //GrupoVehiculo
            imgTabla.Image = null;
            erTabla.Text = "";
            lstVehiculo = new List<Vehiculo>();
            dgvVehiculos.Rows.Clear();
            //Grupo Plan
            cboTipoPlanP.SelectedValue = 0;
            cboPlanP.SelectedValue = 0;
            cboComprobanteP.SelectedValue = 0;
            cboCicloP.SelectedValue = 0;

            imgTipoPlanP.Image = null;
            imgPlanP.Image = null;
            imgCicloP.Image = null;
            imgComprobanteP.Image = null;
            erTipoPlan.Text = "";
            erPlanP.Text = "";
            erCilcloP.Text = "";
            erComprobanteP.Text = "";
            clsPlan = new Plan();
            clsCiclo = new Ciclo();
            fnCalcularTotalPago();
         
            lstDV[0].Descuento = 0;
            fnCargaTablaDetalle(lstDV, dgvPagoPlan);
            fnOcultarCiclo(false);

            //instalacion

            //fnCargaTablaDetalle(lstDV, dgvPagoPlan);

        }

        private void btnLimpiarRP_Click(object sender, EventArgs e)
        {
            //Grupo Responsable Pago
            //cboTipoClienteRP.Enabled = true;
            //cboTipoDocumentoRP.SelectedValue = 0;
            txtDocumentoRP.ReadOnly = false;
            txtDocumentoRP.Text = "";
            txtNombreRP.Text = "";
            txtCorreoRP.Text = "";
            txtTelefonoFijoRP.Text = "";
            txtCelularRP.Text = "";
            txtDireccionRP.Text = "";
            tipoCon.lnTipoConRP = 0;
            clsRespPago = new Cliente();

            //imgTipoClienteRP.Image = null;
            //imgTipoDocumentoRP.Image = null;
            imgDocumentoRP.Image = null;
            //erTipoClienteRP.Text = "";
            //erTipoDocumentoRP.Text = "";
            erDocumentoRP.Text = "";
        }

        //private void cboTipoClienteRP_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Int32 idTipoRP = Convert.ToInt32(cboTipoClienteRP.SelectedValue ?? 0);
        //    fnLLenarDocumentoDeTipoPersona(cboTipoDocumentoRP, idTipoRP, "", false);
        //    var result = FunValidaciones.fnValidarCombobox(lstValidacionRespPago[0].combobox, erTipoClienteRP, imgTipoClienteRP);
        //    lstValidacionRespPago[0].estado = result.Item1;
        //    lstValidacionRespPago[0].mensaje = result.Item2;

        //    if (idTipoRP == 0)
        //    {
        //        cboTipoDocumentoRP.Enabled = false;
        //    }
        //    else
        //    {
        //        cboTipoDocumentoRP.Enabled = true;
        //    }
        //}

        //private void cboTipoDocumentoRP_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Int32 idTDRP = Convert.ToInt32(cboTipoDocumentoRP.SelectedValue ?? 0);
        //    txtDocumentoRP.Text = "";
        //    var result = FunValidaciones.fnValidarCombobox(lstValidacionRespPago[1].combobox, erTipoDocumentoRP, imgTipoDocumentoRP);
        //    lstValidacionRespPago[1].estado = result.Item1;
        //    lstValidacionRespPago[1].mensaje = result.Item2;

        //    if (idTDRP == 0)
        //    {
        //        txtDocumentoRP.Enabled = false;
        //    }
        //    else
        //    {
        //        txtDocumentoRP.Enabled = true;
        //    }
        //    fnLlenarComprobante(cboComprobanteP, "DOVE", idTDRP, 0);
        //}

        private void txtDocumentoRP_TextChanged(object sender, EventArgs e)
        {
            //Int32 idTipDocumentoRP = Convert.ToInt32(cboTipoDocumentoRP.SelectedValue ?? 0);
            //Int32 maxCaracteres = TipoDocumento.fnObtenerTipoDocumentoSeleccionado(idTipDocumentoRP, lstTD).TDmaxCaracteres;
            var result = FunValidaciones.fnValidarTexboxs(lstValidacionRespPago[0].textbox, erDocumentoRP, imgDocumentoRP, true, true, true, 3, 20, 20, 20, "Ingrese correctamente");
            lstValidacionRespPago[0].estado = result.Item1;
            lstValidacionRespPago[0].mensaje = result.Item2;
            Int32 numCaracNroDocumento = txtDocumentoRP.TextLength;
            if (numCaracNroDocumento >= 3)
            {
                Boolean bResul;

                bResul = fnBuscarCliente(txtDocumentoRP, 0, -1, dgDocumentoRP, tipoCon.lnTipoConRP);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Vehiculo. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                dgDocumentoRP.Visible = false;
            }

        }

        private void txtDocumentoRP_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", false);
        }

        private void dgDocumentoRP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean bResul = false;
            bResul = fnListarClienteEspecifico(dgDocumentoRP,2);
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void rdbSi_CheckedChanged(object sender, EventArgs e)
        {

            fnPreguntaQuienPaga(sender,e);
            clsRespPago = clsCliente;
            int idCliente = Convert.ToInt32(clsRespPago.cTiDo);
            fnLlenarComprobante(cboComprobanteP, "DOVE", idCliente, 0);
            foreach(validacion item in lstValidacionRespPago)
            {
                item.estado = true;
            }
        }

        private Boolean fnPreguntaQuienPaga(object sender, EventArgs e)
        {
            
            btnLimpiarRP_Click(sender,e);
            if (rdbSi.Checked == true)
            {
                gbResponsablePago.Enabled = false;
                gbResponsablePago.Visible = false;
                gbDinamico.Location = gbResponsablePago.Location;
                //tabControl1.Height = 722 - 87;
            }
            else
            {
                gbResponsablePago.Enabled = true;
                gbResponsablePago.Visible = true;
                gbDinamico.Location = new Point(gbDinamico.Location.X, (gbResponsablePago.Location.Y+ gbResponsablePago.Height)+5);
                //tabControl1.Height = 722 + 87;
            }
            return true;
        }

        private void rdbNo_CheckedChanged(object sender, EventArgs e)
        {
            fnPreguntaQuienPaga(sender, e);
        }

        private void btnNuevoRP_Click(object sender, EventArgs e)
        {
            frmRegistrarCliente f = new frmRegistrarCliente();
            f.Show();
        }

        private void cboMonedaP_SelectedIndexChanged(object sender, EventArgs e)
        {
                Int32 idMoneda = Convert.ToInt32(cboMonedaP.SelectedValue ?? 0);
                clsMoneda = fnObtenerMonedaSeleccionada(idMoneda, lstMon);
                lstDV[0].cSimbolo = clsMoneda.cSimbolo;
                clsMoneda.idMoneda = idMoneda;
            if (cargoFrom)
            {
                lblTipoDescuento.Text = fnCambiarSimboloDescuento();
                lstPP = fnGenerarPagoPrincipal();
                fnCargaTablaDetalle(lstPP, dgvPrimerPago);
                fnCalcularTotalPago();
                fncalcularTotales(lstPP, lstDV);
            }
            
        }

        private Moneda fnObtenerMonedaSeleccionada(Int32 idM, List<Moneda> lstMoneda)
        {
            foreach (Moneda m in lstMoneda)
            {
                if (m.idMoneda == idM)
                {
                    return m;
                }
            }
            return new Moneda();
        }

        private Double fnConvertirPrecioMoneda(Int32 idMonedaEntrada, Double precioEntrada, Int32 idMonedaSalida)
        {
            BLMoneda objMoneda = new BLMoneda();
            CambioMonedaVenta clsCambioMoneda;
            String simboloTarifa = clsMonedaTarifa.cSimbolo ?? "";
            String nombreMonedaTarifa = clsMonedaTarifa.cNombre ?? "";
            String simboloMoneda = clsMoneda.cSimbolo ?? "";
            String nombreMoneda = clsMoneda.cNombre ?? "";

            clsCambioMoneda = objMoneda.blDevolverCambioMoneda(idMonedaEntrada, precioEntrada, idMonedaSalida);
            string precioEntradaFormatedo = string.Format("{0:0.00}", precioEntrada);
            string simboloEntradaFormatedo = string.Format("{0:0.00}", clsCambioMoneda.PrecioSalida);
            string precioCambioMoneda = string.Format("{0:0.00}", clsCambioMoneda.PrecioCambio);

            if(idMonedaEntrada == idMonedaSalida)
            {
                lblPrecioCambioMoneda.Text = "";
            }
            else
            {
                lblPrecioCambioMoneda.Text = $" 1 {nombreMonedaTarifa} es igual a {precioCambioMoneda} {nombreMoneda}";
            }
            return clsCambioMoneda.PrecioSalida;
        }
        
        private void fnCargarTablaTarifa()
        {
            lstDV.Clear();
            string[] nombreTarifas = new string[] { "Plan " + FunGeneral.FormatearCadenaTitleCase(Convert.ToString(cboPlanP.Text))+" - "+ FunGeneral.FormatearCadenaTitleCase(Convert.ToString(cboTipoVenta.Text))};
            int numNombreTarifas = nombreTarifas.Length - 1;
            for(int i = 0; i<= numNombreTarifas; i++)
            {
                lstDV.Add(new DetalleVenta()
                {
                    Numeracion = i + 1,                    
                    Descripcion = nombreTarifas[0],
                    PrecioUni = 0,
                    IdTipoDescuento = 0,
                    idTipoTarifa = staticTipoTarifa,
                    Descuento = 0,
                    Couta = 0,
                    Cantidad = 0,
                    Importe = 0
                });
            }

            Int32 idTipoPlan = Convert.ToInt32(cboTipoPlanP.SelectedValue ?? 0);
            int numMeses = TipoPlan.fnObtenerTipoPlanSeleccionado(idTipoPlan, lstTP).cMeses;
            lstDV[0].Couta = fnObtenerCuota(numMeses);

            fnCargaTablaDetalle(lstDV,dgvPagoPlan);
            lstDetalleVentaAnual = lstDV;
        }

        private Int32 fnObtenerCuota(Int32 numMeses)
        {
            return 12 / (numMeses == 0 ? 12 : numMeses);
        }
        public String fnDevolverSrtDescuento(Int32 idTipodescuento, Double Descuento)
        {
            String srtDescuento = "";
            if (idTipodescuento == 1 && Descuento!=0)
            {
                srtDescuento = Descuento + " %";
            }
            else if (idTipodescuento == 2 && Descuento != 0)
            {
                srtDescuento = clsMoneda.cSimbolo + " " + string.Format("{0:0.00}", Descuento);

            }else if (idTipodescuento == 0 && Descuento != 0)
            {
                
                srtDescuento = clsMoneda.cSimbolo + " " + string.Format("{0:0.00}", Descuento);
            }
            else
            {
                srtDescuento = clsMoneda.cSimbolo + " " + string.Format("{0:0.00}", Descuento);
            }
            return srtDescuento;
        }
        private void fnCargaTablaDetalle(List<DetalleVenta> lstDV, DataGridView dgv)
        {
           
            dgv.Rows.Clear();
            Int32 idTipodescuento = Convert.ToInt32(cboTipoDescuentoPrecios.SelectedValue);
            
           

            foreach (DetalleVenta item in lstDV)
            {
                
                dgv.Rows.Add(
                    item.IdDetalleVenta,
                    item.Numeracion,
                    item.Descripcion,
                    item.Cantidad,
                    fnDevolverSrtDescuento(0,item.PrecioUni),
                    item.Couta,
                    fnDevolverSrtDescuento(idTipodescuento,item.Descuento),
                    fnDevolverSrtDescuento(0,item.TotalTipoDescuento),
                    FunGeneral.fnFormatearPrecio(clsMoneda.cSimbolo,item.Importe,1)
                );
            }
            if (lstDV.Count>0)
            {
                Double totDescuento = 0;
                totDescuento = (Convert.ToInt32(cboTipoPlanP.SelectedValue) == 1 ? lstDV[0].TotalTipoDescuento : (lstDV[0].TotalTipoDescuento * lstDV[0].Couta));
                //txtTotalDescuento.Text = $"{clsMoneda.cSimbolo} {string.Format("{0:0.00}", totDescuento)}";
            }
            //if (Convert.ToInt32(cboTipoPlanP.SelectedValue) == 1 && dgv == dgvPrimerPago && dgv.Rows.Count > 0)
            //{
            //    dgv.Rows[1].Visible = false;

            //}

        }

        private Double fnConvertirATipoDescuento(Double precioOriginal, String tipodescuento,Double descuento)
        {
            Double precioDescuento;
            Int32 numero = dgvPagoPlan.Rows.Count;
            if (tipodescuento == "PORCENTUAL")
            {
                precioDescuento = (precioOriginal * descuento) / 100;
            }
            else
            {
                precioDescuento = descuento;
            }
            return precioDescuento;
        }

        private void fnCalcularTotalPago()
        {
            Double precioTotalFinal = 0;
            Tarifa clTarif = lnTipoCon ==0 ? clsTarifa : ClsVentaGeneral.ClsTarifa;
            int numFilas = 0;
            clsMonedaTarifa = fnObtenerMonedaSeleccionada(clsTarifa.IdMoneda, lstMon);
            clsMoneda = fnObtenerMonedaSeleccionada(clsMoneda.idMoneda, lstMon);

            for (int i = 0; i <= numFilas; i++)
            {
                lstDV[i].Couta = Convert.ToInt32(cboTipoVenta.SelectedValue) == 2 ? 1 : lstDV[i].Couta;
                lstDV[i].Cantidad = lnTipoCon==-1?ClsVentaGeneral.lstVehiculo.Count: lstVehiculo.Count;
                lstDV[i].PrecioUni = fnConvertirPrecioMoneda(clsTarifa.IdMoneda, clsTarifa.PrecioPlan, clsMoneda.idMoneda);
                precioTotalFinal = lstDV[i].PrecioUni * lstDV[i].Cantidad;
                lstDV[i].TotalTipoDescuento = fnConvertirATipoDescuento(precioTotalFinal, cboTipoDescuentoPrecios.Text, lstDV[i].Descuento);
                lstDV[i].TotalDescuento = (precioTotalFinal - lstDV[i].TotalTipoDescuento);
                lstDV[i].TotalPUCant = (lstDV[i].TotalDescuento/*lstDV[i].TotalDescuento * lstDV[i].Cantidad*/);
                //lstDV[i].Importe = (lstDV[i].TotalPUCant * lstDV[i].Couta);
                lstDV[i].Importe =  lstDV[i].TotalPUCant * lstDV[i].Couta;
            }
            //probar para que entrega
            //RestarDescuento= lstDV[0].Importe / 12;
            fnCargaTablaDetalle(lstDV, dgvPagoPlan);

        }
        private Boolean fnValidarDatosAEnviar(List<validacion> lstVali)
        {
            foreach (validacion item in lstVali)
            {
                if (!item.estado)
                {
                    return false;
                }
            }
            return true;
        }

        private List<DetalleCronograma> fnGenerarCronograma(DateTime fechaInicial)
        {
            List<DetalleCronograma> lstDC = new List<DetalleCronograma>();
            Int32 idTipoPlan = Convert.ToInt32(cboTipoPlanP.SelectedValue ?? 0);
            int j = 0;
            Int32 numMeses = TipoPlan.fnObtenerTipoPlanSeleccionado(idTipoPlan, lstTP).cMeses;
            Int32 numCuotas = 12 / numMeses;
            DateTime fechaSistema = fechaInicial;
            DateTime fechaActual = Variables.gdFechaSis;
            Int32 idUsuario = Variables.gnCodUser;
            Int32 numDiasMesInicial = 0;
            Int32 numDiasMesTemp = 0;
            Int32 diaNuevaFecha = 0;
            Int32 diaCicloPago = Convert.ToInt32(cboCicloP.SelectedValue)!=0?Convert.ToInt32(cboCicloP.Text):0;
            if (ClsVentaGeneral.lstDetalleCronograma is List<DetalleCronograma>)
            {
                for (Int32 i = 0; i < numCuotas; i++)
                {
                    j += 1;
                    Int32 resDias = 0;
                    DateTime PeriodoEstimadoInicial = fechaSistema.AddMonths(i);
                    if (PeriodoEstimadoInicial.Day > diaCicloPago && Convert.ToInt32(cboTipoPlanP.SelectedValue) == 2)
                    {
                        PeriodoEstimadoInicial = PeriodoEstimadoInicial.AddMonths(1);
                    }
                    DateTime dtFechaTemp = PeriodoEstimadoInicial.AddMonths(1);

                    numDiasMesInicial = DateTime.DaysInMonth(PeriodoEstimadoInicial.Year, PeriodoEstimadoInicial.Month);
                    numDiasMesTemp = DateTime.DaysInMonth(dtFechaTemp.Year, dtFechaTemp.Month);
                    if (diaCicloPago == 30 && PeriodoEstimadoInicial.Month == 2)
                    {
                        resDias = numDiasMesInicial > numDiasMesTemp ? (numDiasMesInicial - numDiasMesTemp) - 1 : (numDiasMesTemp - numDiasMesInicial) - 1;

                    }
                    else
                    {
                        resDias = 0;
                    }
                    if (Convert.ToInt32(cboTipoPlanP.SelectedValue) == 2)
                    {
                        diaNuevaFecha = numDiasMesInicial < diaCicloPago ? numDiasMesInicial : diaCicloPago;
                    }
                    else
                    {
                        diaNuevaFecha = PeriodoEstimadoInicial.Day;
                    }

                    DateTime PeriodoInicial = Convert.ToDateTime(diaNuevaFecha + "/" + (PeriodoEstimadoInicial.Month) + "/" + PeriodoEstimadoInicial.Year);
                    Int32 sumarMeses = numMeses;
                    DateTime PeriodoFinal = (PeriodoInicial.AddMonths(sumarMeses).AddDays((resDias - 1)));
                    DateTime fechaEmision = PeriodoFinal.AddDays(1);
                    DateTime fechaVencimiento = PeriodoFinal.AddDays(5);

                    //DateTime PeriodoEstimadoInicial = fechaSistema.AddMonths(i);

                    //numDiasMesInicial = DateTime.DaysInMonth(PeriodoEstimadoInicial.Year, PeriodoEstimadoInicial.Month);

                    //diaNuevaFecha = numDiasMesInicial < diaCicloPago ? numDiasMesInicial : diaCicloPago;
                    //DateTime PeriodoInicial = Convert.ToDateTime(diaNuevaFecha + "/" + (PeriodoEstimadoInicial.Month) + "/" + PeriodoEstimadoInicial.Year);

                    //DateTime PeriodoFinal = (fechaSistema.AddMonths(i + numMeses).AddDays(-1));
                    //DateTime fechaEmision = PeriodoFinal.AddDays(1);
                    //DateTime fechaVencimiento = PeriodoFinal.AddDays(7);

                    double precioUnitario = Convert.ToDouble(lstDV[0].PrecioUni);
                    double preciodescuento = Convert.ToDouble(lstDV[0].Descuento);
                    int cantVehiculos = lstVehiculo.Count;
                    double precioTotal = lstDV[0].TotalPUCant;

                        ClsVentaGeneral.lstDetalleCronograma[i].numeroCuota = j;
                        ClsVentaGeneral.lstDetalleCronograma[i].descripcion = "Plan";
                        ClsVentaGeneral.lstDetalleCronograma[i].periodoInicio = PeriodoInicial;
                        ClsVentaGeneral.lstDetalleCronograma[i].periodoFinal = PeriodoFinal;
                        ClsVentaGeneral.lstDetalleCronograma[i].fechaEmision = fechaEmision;
                        ClsVentaGeneral.lstDetalleCronograma[i].fechaVencimiento = fechaVencimiento;
                        ClsVentaGeneral.lstDetalleCronograma[i].precioUnitario = precioUnitario;
                        ClsVentaGeneral.lstDetalleCronograma[i].descuento = lstDV[0].Descuento;
                        ClsVentaGeneral.lstDetalleCronograma[i].sDescuento = clsTD.IdTipoDescuento == 1 ? $"{string.Format("{0:0}", preciodescuento)}{clsTD.Simbolo}" : $"{clsMoneda.cSimbolo} {string.Format("{0:0.00}", preciodescuento)}";
                        ClsVentaGeneral.lstDetalleCronograma[i].cantidad = cantVehiculos;
                        ClsVentaGeneral.lstDetalleCronograma[i].total = precioTotal;
                        ClsVentaGeneral.lstDetalleCronograma[i].estado = "ESPV0001";
                        ClsVentaGeneral.lstDetalleCronograma[i].fechaRegistro = fechaSistema;
                        ClsVentaGeneral.lstDetalleCronograma[i].idUsuario = idUsuario;
                        ClsVentaGeneral.lstDetalleCronograma[i].cSimbolo = clsMoneda.cSimbolo;
                  
                }
                lstDC = ClsVentaGeneral.lstDetalleCronograma;
            }
            else
            {
                for (Int32 i = 0; i < numCuotas; i++)
                {
                    j += 1;
                    Int32 resDias = 0;

                    //DateTime PeriodoInicial = fechaSistema.AddMonths(i);
                    
                    DateTime PeriodoEstimadoInicial = fechaSistema.AddMonths(i);
                    if (PeriodoEstimadoInicial.Day>diaCicloPago && Convert.ToInt32(cboTipoPlanP.SelectedValue)==2)
                    {
                        PeriodoEstimadoInicial = PeriodoEstimadoInicial.AddMonths(1);
                    }
                    DateTime dtFechaTemp = PeriodoEstimadoInicial.AddMonths(1);

                    numDiasMesInicial = DateTime.DaysInMonth(PeriodoEstimadoInicial.Year, PeriodoEstimadoInicial.Month);
                    numDiasMesTemp = DateTime.DaysInMonth(dtFechaTemp.Year, dtFechaTemp.Month);
                    if (diaCicloPago==30 && PeriodoEstimadoInicial.Month==2)
                    {
                        resDias = numDiasMesInicial > numDiasMesTemp ? (numDiasMesInicial - numDiasMesTemp)-1 : (numDiasMesTemp - numDiasMesInicial)-1;

                    }
                    else
                    {
                        resDias = 0;
                    }
                    if(Convert.ToInt32(cboTipoPlanP.SelectedValue) == 2)
                    {
                        diaNuevaFecha = numDiasMesInicial < diaCicloPago? numDiasMesInicial : diaCicloPago;
                    }
                    else
                    {
                        diaNuevaFecha = PeriodoEstimadoInicial.Day;
                    }

                    DateTime PeriodoInicial = Convert.ToDateTime(diaNuevaFecha + "/" + (PeriodoEstimadoInicial.Month) + "/" + PeriodoEstimadoInicial.Year);
                    if (diaCicloPago==30)
                    {
                        PeriodoInicial = PeriodoEstimadoInicial.AddDays(((numDiasMesInicial- fechaActual.Day)+1));
                    }
                    else
                    {
                        PeriodoInicial=PeriodoInicial.AddDays(1);
                    }
                    
                    Int32 sumarMeses= numMeses;
                    DateTime PeriodoFinal = (PeriodoInicial.AddMonths(sumarMeses).AddDays(-1));
                    DateTime fechaEmision = PeriodoFinal.AddDays(1);
                    DateTime fechaVencimiento = PeriodoFinal.AddDays(5);

                    double precioUnitario = Convert.ToDouble(lstDV[0].PrecioUni);
                    double preciodescuento = Convert.ToDouble(lstDV[0].Descuento);
                    int cantVehiculos = lstVehiculo.Count;
                    double precioTotal = lstDV[0].TotalPUCant;                    
                    lstDC.Add(
                    new DetalleCronograma
                    {
                        idDetalleCronograma = 0,
                        numeroCuota = j,
                        descripcion = "Plan",
                        periodoInicio = PeriodoInicial,
                        periodoFinal = PeriodoFinal,
                        fechaEmision = fechaEmision,
                        fechaVencimiento = fechaVencimiento,
                        precioUnitario = precioUnitario,
                        descuento = lstDV[0].Descuento,
                        sDescuento = clsTD.IdTipoDescuento == 1 ? $"{string.Format("{0:0}", preciodescuento)}{clsTD.Simbolo}" : $"- {clsMoneda.cSimbolo} {string.Format("{0:0.00}", preciodescuento)}",
                        cantidad = cantVehiculos,
                        total = precioTotal,
                        estado = "ESPV0001",
                        fechaRegistro = fechaSistema,
                        idUsuario = idUsuario,
                        cSimbolo = clsMoneda.cSimbolo
                    });

                }
            }
            

            
            return lstDC;
        }
        private List<DetalleVenta> fnCargarDatosPagoPrincipal()
        {
            List<DetalleVenta> lstDetV = new List<DetalleVenta>();
            String[] arrayPrimerPago = new string[]
            {
               "Equipo",
               "Renta Adelantada",
               "Prorrateo"
            };
            int cantVehiculos = lstVehiculo.Count;

            for (int i = 0; i <= arrayPrimerPago.Count() - 1; i++)
            {
                lstDetV.Add(new DetalleVenta
                {
                    Numeracion = i + 1,
                    Descripcion = arrayPrimerPago[i],
                    idTipoTarifa=staticTipoTarifa,
                    Cantidad = cantVehiculos,
                    cSimbolo = clsMoneda.cSimbolo
                });
            }

            return lstDetV;
        }

        private Tuple<String[],Double[], Double[], Double[], Double[],Int32> fnDevolverArraysPagos()
        {
            fnActivarDgvAnual(true);
            double pagoEquipo = clsTarifa.PrecioEquipo;
            double pagoPlan = clsTarifa.PrecioPlan;
            Int32 idTipoPlan = Convert.ToInt32(cboTipoPlanP.SelectedValue ?? 0);
            if (idTipoPlan==2)
            {
                fnActivarDgvAnual(false);
            }
            Int32 idTipoVenta = Convert.ToInt32(cboTipoVenta.SelectedValue);

            Int32 idCiclo = Convert.ToInt32(cboCicloP.SelectedValue ?? 0);
            Int32 ciclo = Ciclo.fnObtenerCicloSeleccionado(idCiclo, lstC).DiaNumber;
            DateTime fechaActual = Convert.ToDateTime(dtpFechaRegistro.Value);

            Double rentaAdelantada = 0;
            Double prorrateo = 0;
            Double ganProrrateo = 0;
            Double calcularDescuentoEquipo = 0;
            Double calcularDesRA = 0;
            Double calcularDesPR = 0;
            Double calcularDesReactivacion = 0;

            if (Convert.ToInt32(cboTipoVenta.SelectedValue) == 2 )
            {

                rentaAdelantada = clsPlanActual.idTipoPlan == clsPlan.idTipoPlan ? 0 : clsTarifa.PrecioPlan;
                if (ClsVentaGeneral.clsCronograma is Cronograma && ClsVentaGeneral.clsCronograma.periodoFinal < Variables.gdFechaSis.AddMonths(-2))
                {
                    rentaAdelantada =clsTarifa.PrecioPlan;
                }
                rentaAdelantada = clsTarifa.PrecioPlan;
            }
            else
            {
                rentaAdelantada = clsTarifa.PrecioPlan;

            }
            clsTarifa.PrecioRentaAdelantada = rentaAdelantada;

            prorrateo = DetalleVentaCabecera.fnCalcularProrrateo(rentaAdelantada, ciclo, fechaActual);
            //separamos los decimales del prorrateo
            Double SoloDecimales = Convert.ToDouble(string.Format("{0:0.00}", prorrateo - Math.Truncate(prorrateo)));
            //retornamos el decimal redondeado
            Double DecimalesRedondeado = DetalleVentaCabecera.fnRedondearDecimales(SoloDecimales);
            //separamos solo el entero
            Double SoloEntero = Math.Truncate(prorrateo);
            //prorrateo redondeado
            Double ProrrateoRedondeado = Convert.ToDouble(string.Format("{0:0.00}", SoloEntero + DecimalesRedondeado));
            //arrayGananciaPro despues del redondeo
            ganProrrateo = clsTarifa.DescuentoProrrateo == ProrrateoRedondeado ? 0 : Convert.ToDouble(string.Format("{0:0.00}", ProrrateoRedondeado - prorrateo));

            clsTarifa.PrecioProrrateo = ProrrateoRedondeado;

            calcularDescuentoEquipo = fnConvertirATipoDescuento((clsTarifa.PrecioEquipo * lstVehiculo.Count), cboTipoDescuentoPrecios.Text, clsTarifa.DescuentoEquipo);

            calcularDesRA = fnConvertirATipoDescuento((clsTarifa.PrecioPlan * lstVehiculo.Count), cboTipoDescuentoPrecios.Text, clsTarifa.DescuentoRentaAdelantada);
            calcularDesPR = fnConvertirATipoDescuento((prorrateo * lstVehiculo.Count), cboTipoDescuentoPrecios.Text, clsTarifa.DescuentoProrrateo);
            calcularDesReactivacion = fnConvertirATipoDescuento((clsTarifa.PrecioReactivacion * lstVehiculo.Count), cboTipoDescuentoPrecios.Text, clsTarifa.DescuentoReactivacion);

            //clsTarifa.PrecioPlan -
            Double[] arrayPrecio = { };
            Double[] arrayDescuentoCantidad = { };
            Double[] arrayDescuentoPrecio = { };
            Double[] arrayGananciaPro = { };
            String[] arrayPrimerPago = { };
            Int32 cuota = 0;

            switch (idTipoVenta)
            {
                case 1:
                    if (idTipoPlan == 1)
                    {
                        rentaAdelantada = 0;
                        prorrateo = 0;
                        arrayPrecio = new double[]
                        {
                        pagoEquipo
                        };

                        arrayDescuentoCantidad = new double[]
                        {
                        clsTarifa.DescuentoEquipo
                        };

                        arrayDescuentoPrecio = new double[]
                        {
                        calcularDescuentoEquipo

                        };
                        arrayGananciaPro = new double[]
                        {
                        0
                        };
                        arrayPrimerPago = new string[]
                        {
                        "Equipo"
                        };

                    }
                    else if (idTipoPlan == 2)
                    {
                        arrayPrecio = new double[]
                        {
                        pagoEquipo,
                        rentaAdelantada,
                        ProrrateoRedondeado
                        };

                        arrayDescuentoCantidad = new double[]
                        {
                        clsTarifa.DescuentoEquipo,
                        clsTarifa.DescuentoRentaAdelantada,
                        clsTarifa.DescuentoProrrateo
                        };

                        arrayDescuentoPrecio = new double[]
                        {
                        calcularDescuentoEquipo,
                        calcularDesRA,
                        calcularDesPR
                        };
                        arrayGananciaPro = new double[]
                        {
                        0,0,
                        ganProrrateo


                        };

                        arrayPrimerPago = new string[]
                        {
                        "Equipo",
                        "Renta Adelantada",
                        "Prorrateo"
                        };
                    }
                    break;
                case 2:
                    cuota = 1;
                    if (idTipoPlan == 1)
                    {
                        arrayPrecio = new double[]
                        {

                        };

                        arrayDescuentoCantidad = new double[]
                        {

                        };

                        arrayDescuentoPrecio = new double[]
                        {

                        };
                        arrayGananciaPro = new double[]
                        {

                        };
                        arrayPrimerPago = new string[]
                        {

                        };
                    }
                    else if (idTipoPlan == 2)
                    {
                        if (lnTipoCon == -2)
                        {
                            if (ClsVentaGeneral.clsCronograma is Cronograma && ClsVentaGeneral.clsCronograma.periodoFinal < Variables.gdFechaSis.AddMonths(-2))
                            {
                                arrayPrecio = new double[]
                                {
                                        clsTarifa.PrecioReactivacion,
                                        rentaAdelantada,
                                        ProrrateoRedondeado
                                };

                                arrayDescuentoCantidad = new double[]
                                {
                                            clsTarifa.DescuentoReactivacion,
                                            clsTarifa.DescuentoRentaAdelantada,

                                            clsTarifa.DescuentoProrrateo
                                };

                                arrayDescuentoPrecio = new double[]
                                {
                                            calcularDesReactivacion,
                                            calcularDesRA,
                                            calcularDesPR
                                };
                                arrayGananciaPro = new double[]
                                {
                                            0,
                                            0,
                                            ganProrrateo
                                };
                                arrayPrimerPago = new string[]
                                {

                                            "Reactivacion plan "+FunGeneral.FormatearCadenaTitleCase(Convert.ToString(cboPlanP.Text.ToString())),
                                            "Renta Adelantada Reactivacion",
                                            "Prorrateo"
                                };
                            }
                            else
                            if (clsPlanActual.idTipoPlan != clsPlan.idTipoPlan && clsPlan.idTipoPlan != 0)
                            {
                                //if (clsTarifa.PrecioPlan < 30)
                                //{
                                //    arrayPrecio = new double[]
                                //    {
                                //        clsTarifa.PrecioReactivacion
                                //    };

                                //    arrayDescuentoCantidad = new double[]
                                //    {
                                //        clsTarifa.DescuentoReactivacion
                                //    };

                                //    arrayDescuentoPrecio = new double[]
                                //    {
                                //        calcularDesRA
                                //    };
                                //    arrayGananciaPro = new double[]
                                //    {
                                //        0
                                //    };
                                //    arrayPrimerPago = new string[]
                                //    {

                                //        "Plan "+FunGeneral.FormatearCadenaTitleCase(Convert.ToString(cboPlanP.Text.ToString()))+" - "+ FunGeneral.FormatearCadenaTitleCase(Convert.ToString(cboTipoVenta.Text))

                                //    };
                                //}
                                //else
                                {
                                    arrayPrecio = new double[]
                                    {
                                        clsTarifa.PrecioReactivacion,
                                        rentaAdelantada,
                                        ProrrateoRedondeado
                                    };

                                    arrayDescuentoCantidad = new double[]
                                    {
                                        clsTarifa.DescuentoReactivacion,
                                        clsTarifa.DescuentoRentaAdelantada,
                                        clsTarifa.DescuentoProrrateo
                                    };

                                    arrayDescuentoPrecio = new double[]
                                    {
                                        calcularDesReactivacion,
                                        calcularDesRA,
                                        calcularDesPR
                                    };
                                    arrayGananciaPro = new double[]
                                    {
                                        0,
                                        0,
                                        ganProrrateo
                                    };
                                    arrayPrimerPago = new string[]
                                    {
                                        "Reactivacion plan "+FunGeneral.FormatearCadenaTitleCase(Convert.ToString(cboPlanP.Text.ToString())),
                                        "Renta Adelantada",
                                        "Prorrateo"
                                    };
                                }

                            }
                            else
                            {

                                if (clsTarifa.PrecioPlan < 30)
                                {
                                    arrayPrecio = new double[]
                                    {
                                        clsTarifa.PrecioReactivacion
                                    };

                                    arrayDescuentoCantidad = new double[]
                                    {
                                        clsTarifa.DescuentoReactivacion
                                    };

                                    arrayDescuentoPrecio = new double[]
                                    {
                                        calcularDesReactivacion
                                    };
                                    arrayGananciaPro = new double[]
                                    {
                                        0
                                    };
                                    arrayPrimerPago = new string[]
                                    {

                                        "Plan "+FunGeneral.FormatearCadenaTitleCase(Convert.ToString(cboPlanP.Text.ToString()))+" - "+ FunGeneral.FormatearCadenaTitleCase(Convert.ToString(cboTipoVenta.Text))

                                    };
                                }
                                else
                                {
                                        arrayPrecio = new double[]
                                        {
                                            clsTarifa.PrecioPlan,
                                        };

                                        arrayDescuentoCantidad = new double[]
                                        {
                                        clsTarifa.DescuentoRentaAdelantada,
                                        };

                                        arrayDescuentoPrecio = new double[]
                                        {
                                        calcularDesRA
                                        };
                                        arrayGananciaPro = new double[]
                                        {
                                        0
                                        };
                                        arrayPrimerPago = new string[]
                                        {

                                        "Plan "+FunGeneral.FormatearCadenaTitleCase(Convert.ToString(cboPlanP.Text.ToString()))+" - "+ FunGeneral.FormatearCadenaTitleCase(Convert.ToString(cboTipoVenta.Text))
                                        };
                                    
                                }
                            }
                        }
                        else if (lnTipoCon==-1)
                        {
                            if (lstPP.Count > 0 && clsPlanActual.idPlan==clsPlan.idPlan)
                            {
                                List<string> list = new List<string>();
                                List<double> listPrecio = new List<double>();


                                for (int i = 0; i < lstPP.Count; i++)
                                {
                                    list.Add(lstPP[i].Descripcion);
                                    listPrecio.Add(lstPP[i].Descripcion == "Prorrateo" ? ProrrateoRedondeado : lstPP[i].Importe);



                                    arrayDescuentoCantidad = new double[]
                                    {
                                                clsTarifa.DescuentoReactivacion,
                                                clsTarifa.DescuentoRentaAdelantada,
                                                clsTarifa.DescuentoProrrateo
                                    };

                                    arrayDescuentoPrecio = new double[]
                                    {
                                                calcularDesReactivacion,
                                                calcularDesRA,
                                                calcularDesPR
                                    };
                                    arrayGananciaPro = new double[]
                                    {
                                                0,
                                                0,
                                                0
                                    };

                                }

                                arrayPrimerPago = list.ToArray();
                                arrayPrecio = listPrecio.ToArray();
                            }
                        }
                    }
                    break;
                case 3:

                    if (idTipoPlan == 1)
                    {
                        arrayPrecio = new double[]
                        {
                        clsTarifa.PrecioReactivacion,
                        };

                        arrayDescuentoCantidad = new double[]
                        {
                        clsTarifa.DescuentoReactivacion,
                        };

                        arrayDescuentoPrecio = new double[]
                        {
                        calcularDesReactivacion,
                        };
                        arrayGananciaPro = new double[]
                        {
                        0,
                        };
                        arrayPrimerPago = new string[]
                        {
                        "Activacion",
                        };
                    }
                    else if (idTipoPlan == 2)
                    {
                        arrayPrecio = new double[]
                        {
                        clsTarifa.PrecioReactivacion,
                        rentaAdelantada,
                        prorrateo
                        };

                        arrayDescuentoCantidad = new double[]
                        {
                        clsTarifa.DescuentoReactivacion,
                        clsTarifa.DescuentoRentaAdelantada,
                        clsTarifa.DescuentoProrrateo
                        };

                        arrayDescuentoPrecio = new double[]
                        {
                        calcularDesReactivacion,
                        calcularDesRA,
                        calcularDesPR
                        };
                        arrayGananciaPro = new double[]
                        {
                        0,
                        0,
                        ganProrrateo
                        };
                        arrayPrimerPago = new string[]
                        {
                        "Activacion",
                        "Renta Adelantada",
                        "Prorrateo"
                        };
                    }
                    break;
            }

            return Tuple.Create(arrayPrimerPago, arrayPrecio, arrayDescuentoCantidad, arrayDescuentoPrecio, arrayGananciaPro,cuota);
        }

        private List<DetalleVenta> fnGenerarPagoPrincipal()
        {
            List<DetalleVenta> lstDetV = new List<DetalleVenta>();
            var result = fnDevolverArraysPagos();

            int cantVehiculos = lstVehiculo.Count;
            if (lnTipoCon==-1)
            {
                if (ClsVentaGeneral.clsDetalleVentaCabecera.lstDetalleVenta.Count > 0)
                {
                    lstDetV = lstPP;
                    if (lstPP.Count == result.Item1.Count())
                    {
                        for (int i = 0; i < lstPP.Count; i++)
                        {
                            double precioUnitario = fnConvertirPrecioMoneda(clsMonedaTarifa.idMoneda, result.Item2[i], clsMoneda.idMoneda);

                            double precioDescontado = fnConvertirPrecioMoneda(clsMonedaTarifa.idMoneda, result.Item4[i], clsMoneda.idMoneda);
                            int cantidad = lstVehiculo.Count;
                            double importe = (precioUnitario * cantidad) - precioDescontado;

                            lstDetV[i].Numeracion = i + 1;
                            lstDetV[i].Descripcion = result.Item1[i];
                            lstDetV[i].idTipoTarifa = clsTarifa.IdTarifa;
                            lstDetV[i].PrecioUni = precioUnitario;
                            lstDetV[i].Descuento = result.Item3[i];
                            lstDetV[i].gananciaRedondeo = result.Item5[i];
                            lstDetV[i].TotalTipoDescuento = precioDescontado;
                            lstDetV[i].IdTipoDescuento = lstDV[0].IdTipoDescuento;
                            lstDetV[i].Cantidad = cantVehiculos;
                            lstDetV[i].Couta = result.Item6;
                            lstDetV[i].Importe = importe;
                            lstDetV[i].cSimbolo = clsMoneda.cSimbolo;
                        }
                    }
                }

                lstDetV[0].idTipoTarifa = clsTarifa.IdTarifa;
            }
            else
            {
                for (int i = 0; i <= result.Item1.Count() - 1; i++)
                {
                    double precioUnitario = fnConvertirPrecioMoneda(clsMonedaTarifa.idMoneda, result.Item2[i], clsMoneda.idMoneda);

                    double precioDescontado = fnConvertirPrecioMoneda(clsMonedaTarifa.idMoneda, result.Item4[i], clsMoneda.idMoneda);
                    int cantidad = lstVehiculo.Count;
                    double importe = (precioUnitario * cantidad) - precioDescontado;
                    lstDetV.Add(new DetalleVenta
                    {
                        Numeracion = i + 1,
                        Descripcion = result.Item1[i],
                        idTipoTarifa = clsTarifa.IdTarifa,
                        PrecioUni = precioUnitario,
                        Descuento = result.Item3[i],
                        gananciaRedondeo = result.Item5[i],
                        TotalTipoDescuento = precioDescontado,
                        IdTipoDescuento = lstDV[0].IdTipoDescuento,
                        Cantidad = cantVehiculos,
                        Couta = result.Item6,
                        Importe = importe,
                        cSimbolo = clsMoneda.cSimbolo
                    });
                }
            }

            return lstDetV;
        }
        private void txtNombreBus_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private Boolean fnBuscarListaVentas(DataGridView dgv, Int32 numPagina, Int32 tipoLLamada, Int32 tipoCon)
        {
            BLVentaGeneral objVentaGeneral = new BLVentaGeneral();
            clsUtil objUtil = new clsUtil();
            DataTable datVentaG = new DataTable();
            String placaVehiculo = txtBuscarVentas.Text.Trim();
            String cEstadoInstal = "0";
            Int32 cEstadoTipoVenta = Convert.ToInt32(cboTipoVetaBusq.SelectedValue);
            Boolean habilitarFechas = chkHabilitarFechasBus.Checked ? true : false;
            Boolean habilitarRenovaciones = chkRenovaciones.Checked ? true : false;
            DateTime fechaInicial = dtpFechaInicialBus.Value;
            DateTime fechaFinal = dtpFechaFinalBus.Value;
            String fechaAct=FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis,3);
            String estadoTipoContrato = cboEstadoContrato.SelectedValue.ToString();
            Int32 HorasIni = 0;
            Int32 HorasFin = 0;
            Int32 HorasRestarIni = 0;
            Int32 HorasRestarFin = 0;
            Int32 IdTipoPlan=Convert.ToInt32(cbPlanVentas.SelectedValue);
            String TipoFiltro = "";
            DateTime fechaActual = Convert.ToDateTime(Variables.gdFechaSis.ToString("dd/MM/yyyy"));
            //if (fechaInicial== fechaFinal)
            //{
            HorasIni = Convert.ToInt32(fechaInicial.ToString("HH"));
            HorasRestarIni = 24 - HorasIni;
            fechaInicial = fechaInicial.AddHours(-HorasIni);

            HorasFin = Convert.ToInt32(fechaFinal.ToString("HH"));
            HorasRestarFin = 24 - HorasFin;
            fechaFinal  = Convert.ToDateTime(fechaFinal.ToString("dd") + "/" + (fechaFinal.Month) + "/" + fechaFinal.Year+" 23:59:59");
            TipoFiltro = cboTipoFiltro.SelectedValue.ToString();
       
            
            Int32 filas = 10;
            Double TotalGanacia = 0;
            Boolean estadoReturn = false;
            try
            {
                

                datVentaG = objVentaGeneral.blBuscarVentaGeneral(habilitarFechas,FunGeneral.GetFechaHoraFormato(fechaInicial,3) , FunGeneral.GetFechaHoraFormato(fechaFinal,3), fechaAct, placaVehiculo, cEstadoInstal, numPagina, tipoLLamada, tipoCon, cEstadoTipoVenta, estadoTipoContrato, habilitarRenovaciones, IdTipoPlan, TipoFiltro);

                Int32 totalResultados = datVentaG.Rows.Count;

                if (tipoCon==-4)
                {
                    if (totalResultados>0)
                    {
                        for (int i = 0; i <= totalResultados - 1; i++)
                        {


                            TotalGanacia += Convert.ToDouble(datVentaG.Rows[i][1]);

                        }
                        lblTotaGanancia.Text = $"{Convert.ToString(datVentaG.Rows[0][0])} {String.Format("{0:#,##0.00}", TotalGanacia)}";
                    }
                    else
                    {
                        lblTotaGanancia.Text = $"{"S/"} {String.Format("{0:#,##0.00}", totalResultados)}";
                    }
                    
                    estadoReturn = true;
                }
                else if (tipoCon==-5)
                {
                    lstClientesBusq.Clear();
                    Int32 y=0;
                    foreach (DataRow dr in datVentaG.Rows)
                    {
                        
                        Int32 restaAnio = 0;
                        Int32 restaMeses = 0;
                        Int32 faltaDias = 0;
                        String strEstado = "";
                        DateTime fechaFinalContrato = Convert.ToDateTime(Convert.ToDateTime(dr["periodoFinal"]).ToString("dd/MM/yyyy"));

                        TimeSpan tiket = Variables.gdFechaSis - Variables.gdFechaSis.AddDays(-1);

                        //Int32 cantDiasMesPago = DateTime.DaysInMonth(dtFechaDePago.Year, dtFechaDePago.Month);
                        if (fechaActual > fechaFinalContrato)
                        {
                            tiket = fechaActual - fechaFinalContrato;
                        }
                        else
                        {
                            tiket = fechaFinalContrato - fechaActual;
                        }
                        DateTime totalTime = new DateTime(tiket.Ticks);
                        restaAnio = totalTime.Year - 1;
                        restaMeses = totalTime.Month - 1;
                        faltaDias = Convert.ToInt32(totalTime.Day);
                        if (Convert.ToString(dr["EstadoVenta"]) == "EXPIRADO" || Convert.ToString(dr["EstadoVenta"]) == "ANULADA")
                        {
                            strEstado = "❌ ANULADA";
                        }
                        else
                        {
                            strEstado = fnMostrarEstadoRenovacion(fechaActual, fechaFinalContrato, restaAnio, restaMeses, faltaDias);
                        }

                        y += 1;
                        lstClientesBusq.Add(new Cliente
                        {
                            idCliente = y,
                            cNombre = Convert.ToString(dr["nombreCliente"]),
                            cApePat = Convert.ToString(dr["cApePat"]),
                            cApeMat = Convert.ToString(dr["cApeMat"]),
                            cCliente = FunGeneral.FormatearCadenaTitleCase(dr["nombreCliente"] + " " + dr["cApePat"] + " " + dr["cApeMat"]),
                            cTelCelular = Convert.ToString(dr["cTelCelular"]),
                            dFecNac = fechaFinalContrato,
                            cContactoNom1 = FunGeneral.FormatearCadenaTitleCase(Convert.ToString(dr["cContactoNom1"])),
                            cContactoCel1 = Convert.ToString(dr["cContactoCel1"]),
                            codigoVentaGen = Convert.ToString(dr["descripcionVehiculo"]),
                            cEmpresa = FunGeneral.FormatearCadenaTitleCase(Convert.ToString(dr["plan"])),
                            cCorreo = Convert.ToInt64(dr["TotalPago"]) < 50 ? "S/." + string.Format("{0:0.00}", 0): "S/." + string.Format("{0:0.00}", dr["TotalPago"]),
                            cContactoNom2 = Convert.ToString(dr["plan"]),
                            cTelFijo = strEstado,
                            cDireccion = fechaFinalContrato.ToString("dd/MMM/yyyy")


                        });
                    }
                }
                else
                {
                    if (totalResultados > 0)
                    {
                        btnExportarBusqueda.Visible = true;
                        if (dgv.Rows.Count > 0)
                        {
                            dgv.Rows.Clear();

                        }
                       
                        Int32 y;
                        Int32 contador = 0;


                        if (numPagina == 0)
                        {
                            y = 0;
                        }
                        else
                        {
                            tabInicio = (numPagina - 1) * filas;
                            y = tabInicio;
                        }

                        foreach (DataRow dr in datVentaG.Rows)
                        {
                            y += 1;
                            Int32 restaAnio = 0;
                            Int32 restaMeses = 0;
                            Int32 faltaDias = 0;
                            String strEstado = "";
                            String desVehiculos = Convert.ToString(dr["descripcionVehiculo"]);
                            DateTime fecha = Convert.ToDateTime(Convert.ToDateTime(dr["FechaRegistro"]).ToString("dd/MM/yyyy"));
                            DateTime fechaPago = Convert.ToDateTime(Convert.ToDateTime(dr["fechaPago"]).ToString("dd/MM/yyyy"));
                            DateTime fechaFinalContrato = Convert.ToDateTime(Convert.ToDateTime(dr["periodoFinal"]).ToString("dd/MM/yyyy"));
                            var resf=fnRestasAnioMesDia(fechaActual, fechaFinalContrato);

                             //TimeSpan tiket = Variables.gdFechaSis - Variables.gdFechaSis.AddDays(-1);

                            //Int32 cantDiasMesPago = DateTime.DaysInMonth(dtFechaDePago.Year, dtFechaDePago.Month);
                            
                            //DateTime totalTime = new DateTime(tiket.Ticks);
                            restaAnio = resf.Item1;
                            restaMeses = resf.Item2;
                            faltaDias = resf.Item3;
                            if (Convert.ToString(dr["EstadoVenta"]) == "EXPIRADO" || Convert.ToString(dr["EstadoVenta"]) == "ANULADA")
                            {
                                strEstado = "❌ ANULADA";
                            }
                            else
                            {
                                strEstado = fnMostrarEstadoRenovacion(fechaActual, fechaFinalContrato, restaAnio, restaMeses, faltaDias);
                            }
                            dgv.Rows.Add(
                                dr["idCliente"],
                                y,
                                dr["codigoVenta"],
                                fechaPago.ToString("dd/MM/yyyy"),
                                fecha.ToString("dd/MM/yyyy"),
                                fechaFinalContrato.ToString("dd/MM/yyyy"),
                                desVehiculos,
                                FunGeneral.FormatearCadenaTitleCase(dr["descripcionCliente"].ToString()),
                                FunGeneral.FormatearCadenaTitleCase(dr["plan"].ToString()),
                                FunGeneral.FormatearCadenaTitleCase(dr["nombre"].ToString()),
                                FunGeneral.FormatearCadenaTitleCase(dr["EstadoVenta"].ToString()),
                                FunGeneral.FormatearCadenaTitleCase(dr["cNomTab"].ToString()),
                                FunGeneral.FormatearCadenaTitleCase(dr["cUser"].ToString()),
                                $"{dr["cSimbolo"]} {string.Format("{0:0.00}", dr["TotalPago"])}",
                                strEstado,
                                "",
                                dr["idTipoTarifa"],
                                dr["idContrato"]
                            );

                            if (Convert.ToString(dr["EstadoVenta"]) == "EXPIRADO" || Convert.ToString(dr["EstadoVenta"]) == "ANULADA")
                            {
                                dgv.Rows[contador].DefaultCellStyle.ForeColor = Color.Red;
                            }
                            else if (Convert.ToString(dr["cCodTab"]) == "ESPP0002")
                            {
                                dgv.Rows[contador].DefaultCellStyle.ForeColor = Color.DarkOrange;
                            }
                            contador += 1;
                        }
                        //for (int i = 0; i <= totalResultados - 1; i++)
                        //{

                        //    y += 1;
                        //    string desVehiculos = Convert.ToString(datVentaG.Rows[i][4]);
                        //    DateTime fecha = Convert.ToDateTime(datVentaG.Rows[i][3]);
                        //    DateTime fechaPago = Convert.ToDateTime(datVentaG.Rows[i][17]);
                        //    dgv.Rows.Add(
                        //        datVentaG.Rows[i][1],
                        //        y,
                        //        datVentaG.Rows[i][2],
                        //        fechaPago.ToString("dd/MM/yyyy"),
                        //        fecha.ToString("dd/MM/yyyy"),
                        //        desVehiculos,
                        //        datVentaG.Rows[i][5],
                        //        datVentaG.Rows[i][9],
                        //        datVentaG.Rows[i][11],
                        //        datVentaG.Rows[i][6],
                        //        datVentaG.Rows[i][7],
                        //        datVentaG.Rows[i][8],
                        //        $"{datVentaG.Rows[i][12]} {string.Format("{0:0.00}", datVentaG.Rows[i][13])}",
                        //        "",
                        //        datVentaG.Rows[i][10],
                        //        datVentaG.Rows[i][14]
                        //    );

                        //    if (Convert.ToString(datVentaG.Rows[i][6]) == "EXPIRADO" || Convert.ToString(datVentaG.Rows[i][6]) == "ANULADA")
                        //    {
                        //        dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        //    }
                        //    else if (Convert.ToString(datVentaG.Rows[i][16]) == "ESPP0002")
                        //    {
                        //        dgv.Rows[i].DefaultCellStyle.ForeColor = Color.DarkOrange;
                        //    }

                        //    //TotalGanacia += Convert.ToDouble(datVentaG.Rows[i][15]);

                        //}
                        //lblTotaGanancia.Text = $"{"S/"} {String.Format("{0:#,##0.00}", TotalGanacia)}";

                        dgv.Columns[0].Visible = false;
                        dgv.Columns[2].Visible = false;
                        dgv.Columns[1].Width = 20;
                        dgv.Columns[3].Width = 45;
                        dgv.Columns[4].Width = 50;
                        dgv.Columns[5].Width = 45;
                        dgv.Columns[6].Width = 75;
                        dgv.Columns[7].Width = 110;
                        dgv.Columns[8].Width = 45;
                        dgv.Columns[9].Width = 45;
                        dgv.Columns[10].Width = 50;
                        dgv.Columns[11].Width = 45;
                        dgv.Columns[12].Width = 40;
                        dgv.Columns[13].Width = 40;
                        dgv.Columns[14].Width = 100;
                        dgv.Columns[15].Width = 60;
                        //dgv.RowTemplate.Height = 100;
                        dgv.Visible = true;

                        if (numPagina == 0)
                        {
                            gbPaginacion.Visible = true;
                            Int32 totalRegistros = Convert.ToInt32(datVentaG.Rows[0][0]);
                            FunValidaciones.fnCalcularPaginacion(
                                totalRegistros,
                                filas,
                                totalResultados,
                                cboPagina,
                                btnTotalPag,
                                btnNumFilas,
                                btnTotalReg
                            );
                            dEstadoBusquedaPaginacion = false;
                        }
                        else
                        {
                            btnNumFilas.Text = Convert.ToString(totalResultados);
                        }

                        estadoReturn= true;
                    }
                    else
                    {
                        btnExportarBusqueda.Visible = false;
                        //MessageBox.Show("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS","Aviso!!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        dgv.Rows.Clear();
                        estadoReturn= false;
                    }
                }
              //  fnActualizarEstadoContratoAutomatico();

                return estadoReturn;
               

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }
        }

        private Tuple<Int32,Int32,Int32> fnRestasAnioMesDia(DateTime fecHaActual,DateTime fechaFinal)
        {
            Int32 restAnio = 0;
            Int32 restMes = 0;
            Int32 restDias = 0;

            TimeSpan tiket = new TimeSpan();

            //Int32 cantDiasMesPago = DateTime.DaysInMonth(dtFechaDePago.Year, dtFechaDePago.Month);
            if (fecHaActual > fechaFinal)
            {
                tiket = fecHaActual - fechaFinal;
            }
            else if(fecHaActual < fechaFinal)
            {
                tiket = fechaFinal - fecHaActual;
            }
            DateTime totalTime = new DateTime(tiket.Ticks);
            restAnio = totalTime.Year - 1;
            restMes = totalTime.Month - 1;
            restDias = totalTime.Day-1;
            //if (fecHaActual == fechaFinal)
            //{
            //    restDias = totalTime.Day - 1;
            //}
            
            return Tuple.Create(restAnio,restMes,restDias);
        }
        private String fnMostrarEstadoRenovacion(DateTime dtActual, DateTime dtFinal, Int32 restaAnio, Int32 restaMeses, Int32 faltaDias)
        {
            String strEstado = "";
            String strAnio = "";
            String strMes = "";
            String strDia = "";
            strAnio = restaAnio == 1 ? " Año " : " Años ";
            strMes = restaMeses == 1 ? " Mes y " : " Meses y ";
            strDia = faltaDias == 1 ? " Dia " : " Dias ";

            if (dtActual < dtFinal)
            {
                if (restaAnio > 0)
                {
                    strEstado = "✔ Aun falta " + restaAnio + strAnio + restaMeses + strMes + faltaDias + strDia;

                }
                else if (restaMeses > 0)
                {
                    strEstado = "✔ Aun falta " + restaMeses + strMes + faltaDias + strDia;

                }
                else
                {
                    if (restaMeses == 0 && faltaDias >= 15)
                    {
                        strEstado = "🕐 Aun falta " + faltaDias + strDia;

                    }
                    else if (restaMeses == 0 && faltaDias < 15 && faltaDias > 5)
                    {
                        strEstado = "👁‍ Solo falta " + faltaDias + strDia;
                    }
                    else if (restaMeses == 0 && faltaDias < 6 && faltaDias > 0)
                    {
                        strEstado = "❗ Solo falta " + faltaDias + strDia+" para la renovacion";

                    }
                    else if (restaMeses == 0 && faltaDias == 0)
                    {
                        strEstado = "🚫 El dia de revacion es hoy!!\n " + Variables.gdFechaSis.ToString("dd/MMM/yyyy");
                    }
                }
            }
            else if (dtActual > dtFinal)
            {
                if (restaAnio > 0)
                {
                    strEstado = "❌ Retraso " + restaAnio + strAnio + restaMeses + strMes + faltaDias + strDia;

                }
                else if (restaMeses > 0)
                {
                    strEstado = "❌ Retraso " + restaMeses + strMes + faltaDias + strDia;

                }
                else
                {
                    if (restaMeses == 0 && faltaDias >= 15)
                    {
                        strEstado = "❌ Retraso " + faltaDias + strDia;

                    }
                    else if (restaMeses == 0 && faltaDias < 15 && faltaDias > 5)
                    {
                        strEstado = "❌‍ Retraso " + faltaDias + strDia;
                    }
                    else if (restaMeses == 0 && faltaDias < 6 && faltaDias > 0)
                    {
                        strEstado = "❌ Retraso " + faltaDias + strDia;

                    }
                    else if (restaMeses == 0 && faltaDias == 0)
                    {
                        strEstado = "❌ El dia de revacion es hoy!!\n " + Variables.gdFechaSis.ToString("dd/MMM/yyyy");
                    }
                }

            }else if (dtActual == dtFinal)
            {
                strEstado = "🚫 El dia de revacion es hoy!!\n " + Variables.gdFechaSis.ToString("dd/MMM/yyyy");
                //strEstado = "❌ El dia de revacion es hoy!!\n " + Variables.gdFechaSis.ToString("dd/MMM/yyyy");

            }

            return strEstado;
        }
        private void cboTipoDescuentoP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargoFrom)
            {
                Int32 idTipoDescuento = Convert.ToInt32(cboTipoDescuentoPrecios.SelectedValue ?? 0);

                clsTD = TipoDescuento.fnObtnerTipoDescuentoSelecccionado(idTipoDescuento, lstTDes);
                lblTipoDescuento.Text = fnCambiarSimboloDescuento();
                if (Convert.ToInt32(cboTipoDescuentoPrecios.SelectedValue) != 0)
                {
                    fnHabilitarDescuento(estDescuento);
                }
                else
                {
                    fnHabilitarDescuento(false);
                }
                for (int i = 0; i < lstDV.Count; i++)
                {
                    lstDV[i].IdTipoDescuento = idTipoDescuento;
                }
                fnCalcularTotalPago();
                lstPP = fnGenerarPagoPrincipal();
                fnCargaTablaDetalle(lstPP, dgvPrimerPago);
                fncalcularTotales(lstPP, lstDV);
            }
        }

        private string fnCambiarSimboloDescuento()
        {
            return clsTD.IdTipoDescuento == 0 ? "" : $"EN {(clsTD.Simbolo == "" ? clsMoneda.cSimbolo : clsTD.Simbolo)}";
        }

        private void chkHabilitarDescuentoP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarDescuentoP.Checked == true)
            {
                Procesos.frmAccesoADescuento frmDescuento = new Procesos.frmAccesoADescuento();
                estDescuento = false;
                frmDescuento.Inicio(2);
                if (estDescuento==true)
                {
                    cboTipoDescuentoPrecios.Enabled = estDescuento;
                    chkHabilitarDescuentoP.Checked = estDescuento;
                }
                else
                {
                    cboTipoDescuentoPrecios.Enabled = estDescuento;
                    chkHabilitarDescuentoP.Checked = estDescuento;
                }
                
            }
            else
            {
                estDescuento = false;
                chkHabilitarDescuentoP.Checked = false;
                fnHabilitarDescuento(estDescuento);
                cboTipoDescuentoPrecios.Enabled = estDescuento;
            }
           
            
        }
        public void fnObtenerVehiculo(Vehiculo clsV)
        {
            Vehiculo repetido = lstVehiculo.Find(i => i.idVehiculo == clsV.idVehiculo);

            if(repetido == null)
            {
                if (idEditar == 0)
                {
                    lstVehiculo.Add(clsV);
                }
                else
                {
                    Int32 indiceLista = lstVehiculo.FindIndex(i => i.idVehiculo == idEditar);
                    lstVehiculo[indiceLista] = clsV;
                }
            }
            else
            {
                MessageBox.Show($"- El Vehículo con placa: {repetido.vPlaca} ya existe en la tabla\nPor favor Ingrese otro...", "AVISO - NO SE PERMITEN ELEMENTOS REPETIDOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmRegistrarVehiculo frmVehiculo = new frmRegistrarVehiculo();
                frmVehiculo.Inicio(5);
                
            }
            fnCalcularTotalPago();
            
        }

        private void dgVehiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 numfilas = (dgvVehiculos.Rows.Count) - 1;
            Int32 posicionColumna = e.ColumnIndex;
            Int32 posicionFila = e.RowIndex;
            DataGridViewRow filaSeleccionada = dgvVehiculos.Rows[posicionFila];
            if (posicionColumna == dgvVehiculos.Columns["colBuscar"].Index && posicionFila >= 0)
            {
                lnTipoCon = 0;
                frmRegistrarVehiculo frmVehiculo = new frmRegistrarVehiculo();
                idEditar = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                frmVehiculo.Inicio(5);
                fnCargarTablaVehiculo();
                lstPP = fnGenerarPagoPrincipal();
                fnCargaTablaDetalle(lstPP, dgvPrimerPago);
                fncalcularTotales(lstPP, lstDV);
            }

            if (posicionColumna == dgvVehiculos.Columns["colEliminar"].Index && posicionFila >= 0)
            {
                if (posicionFila == 0 || posicionFila == numfilas)
                {
                    Int32 idVehiculo = Convert.ToInt32(filaSeleccionada.Cells[0].Value);

                    //Vehiculo NoRenovar = lstVehiculo.Find(i => i.idVehiculo == idVehiculo);

                    lstVehiculo.Remove(Vehiculo.fnObtenerVehiculoSeleccionado(idVehiculo, lstVehiculo));
                    fnCargarTablaVehiculo();
                }
                else
                {
                    Int32 idVehiculo = Convert.ToInt32(filaSeleccionada.Cells[0].Value);    
                    if (Convert.ToInt32(cboTipoVenta.SelectedValue)==2)
                    {
                        lstVehiculoSinRenovar.Add(lstVehiculo.Find(i => i.idVehiculo == idVehiculo));
                    }

                    lstVehiculo.Remove(Vehiculo.fnObtenerVehiculoSeleccionado(idVehiculo, lstVehiculo));
                    fnCargarTablaVehiculo();
                }
                lstPP = fnGenerarPagoPrincipal();
                fnCargaTablaDetalle(lstPP, dgvPrimerPago);
                fncalcularTotales(lstPP, lstDV);
            }
            var resul = fnValidarTabla(lstVehiculo);
            lstValidacionVehiculo[0].estado = resul.Item1;
            lstValidacionVehiculo[0].mensaje = resul.Item2;
        }

        private void fnCargarTablaVehiculo()
        {
            dgvVehiculos.Rows.Clear();
            Int32 i = 0;
            foreach (Vehiculo item in lstVehiculo)
            {
                dgvVehiculos.Rows.Add(
                    item.idVehiculo,
                    i + 1,
                    item.vPlaca,
                    $"Clase: {item.vClase}, Marca: {item.vMarcaV}, Modelo: {item.vModeloV}",
                    item.vModUso,
                    null,
                    null
                );
                i += 1;
            }

            for(int j = 0; j <= lstDV.Count -1; j++)
            {
                lstDV[j].Cantidad = lstVehiculo.Count;
            }

            fnCalcularTotalPago();
        }

        
        private void dgvVehiculos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvVehiculos.Columns[e.ColumnIndex].Name == "colBuscar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                Icon icoAtomico = new Icon(Application.StartupPath + @"\search.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                this.dgvVehiculos.Rows[e.RowIndex].Height = 30;
                this.dgvVehiculos.Columns[e.ColumnIndex].Width = 30;

                e.Handled = true;
            }

            if (e.ColumnIndex >= 0 && this.dgvVehiculos.Columns[e.ColumnIndex].Name == "colEliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                Icon icoAtomico2 = new Icon(Application.StartupPath + @"\delete.ico");
                e.Graphics.DrawIcon(icoAtomico2, e.CellBounds.Left + 2, e.CellBounds.Top + 2);
                this.dgvVehiculos.Rows[e.RowIndex].Height = 30;
                this.dgvVehiculos.Columns[e.ColumnIndex].Width = 30;

                e.Handled = true;
            }
        }

        private void dgvTarifa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 filaIndice = e.RowIndex == -1 ? 0 : e.RowIndex;
            Int32 posicionColumna = e.ColumnIndex;
            Int32 numFilasTabla = dgvPagoPlan.Rows.Count;

            if (numFilasTabla > 0)
            {
                if (posicionColumna == 6)
                {
                    DataGridViewRow filaData = dgvPagoPlan.Rows[filaIndice];
                    fnValidarPrecioDescuento(dgvPagoPlan,filaData, filaIndice, posicionColumna);
                    //filaData.Cells[4].Style.BackColor = Color.Red;
                    //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                    
                }
                fnCalcularTotalPago();
                lstPP = fnGenerarPagoPrincipal();
                fnCargaTablaDetalle(lstPP, dgvPrimerPago);
                fncalcularTotales(lstPP, lstDV);
            }
        }

        private void fnValidarPrecioDescuento(DataGridView dgv, DataGridViewRow filaData,Int32 filaIndice,Int32 posicionColumna)
        {
            Int32 idTipoVenta = Convert.ToInt32(cboTipoVenta.SelectedValue);
            frmControlPagoVenta frm = new frmControlPagoVenta();
            Double PrecioADescontar = FunGeneral.fnLimpiarDescuentos(Convert.ToString(filaData.Cells[6].Value));
            if (Convert.ToInt32(cboTipoDescuentoPrecios.SelectedValue) == 0)
            {
                fnHabilitarDescuento(false);

            }
            else if (Convert.ToInt32(cboTipoDescuentoPrecios.SelectedValue) == 1)
            {
                if (dgv.Name== "dgvPrimerPago")
                {
                    switch (filaIndice)
                    {
                        case 0:
                            if (idTipoVenta==1)
                            {
                                if (Convert.ToInt32(filaData.Cells[6].Value) > 5 && Convert.ToInt32(filaData.Cells[6].Value) < 51)
                                {
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Variables.ColorWarning;

                                    System.Windows.Forms.DialogResult RespDescuento;
                                    RespDescuento = MessageBox.Show("¡ En realidad desea aplicar mas del 5% en descuento !", "Aviso !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (RespDescuento == DialogResult.Yes)
                                    {
                                        //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                        clsTarifa.DescuentoEquipo = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    }
                                    else
                                    {
                                        dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                        //lstDV[filaIndice].Descuento = 0;
                                        clsTarifa.DescuentoEquipo = 0;
                                    }
                                }
                                else if (Convert.ToInt32(filaData.Cells[6].Value) > 50)
                                {
                                    MessageBox.Show("¡ Error no puede aplicar un descuento muy alto ! \n ¡ Politicas de la empresa !", "Aviso !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                    //lstDV[filaIndice].Descuento = 0;
                                    clsTarifa.DescuentoEquipo = 0;
                                }
                                else
                                {
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                    //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    clsTarifa.DescuentoEquipo = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);

                                }
                            }
                            else if (idTipoVenta == 2)
                            {
                                if (PrecioADescontar > 5 && PrecioADescontar < 101)
                                {
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Variables.ColorWarning;

                                    System.Windows.Forms.DialogResult RespDescuento;
                                    RespDescuento = MessageBox.Show("¡ En realidad desea aplicar mas del 5% en descuento !", "Aviso !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (RespDescuento == DialogResult.Yes)
                                    {
                                        if (lnTipoCon == -2 && ClsVentaGeneral.clsCronograma.periodoFinal < Variables.gdFechaSis.AddMonths(-2))
                                        {                                            
                                            clsTarifa.DescuentoReactivacion = PrecioADescontar;
                                        }
                                        else
                                        {
                                            if (clsTarifa.PrecioPlan < 30)
                                            {
                                                clsTarifa.DescuentoReactivacion = PrecioADescontar;
                                            }
                                            else
                                            {
                                                clsTarifa.DescuentoRentaAdelantada = PrecioADescontar;

                                            }
                                        }
                                        //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    }
                                    else
                                    {
                                        dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                        //lstDV[filaIndice].Descuento = 0;
                                        clsTarifa.DescuentoRentaAdelantada = 0;
                                    }
                                }
                                else if (Convert.ToInt32(filaData.Cells[6].Value) > 100)
                                {
                                    MessageBox.Show("¡ Error no puede aplicar un descuento muy alto ! \n ¡ Politicas de la empresa !", "Aviso !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                    //lstDV[filaIndice].Descuento = 0;
                                    clsTarifa.DescuentoRentaAdelantada = 0;
                                }
                                else
                                {
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                    //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    clsTarifa.DescuentoRentaAdelantada = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);

                                }

                            }
                            else if (idTipoVenta == 3)
                            {
                                if (Convert.ToInt32(filaData.Cells[6].Value) > 5 && Convert.ToInt32(filaData.Cells[6].Value) < 51)
                                {
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Variables.ColorWarning;

                                    System.Windows.Forms.DialogResult RespDescuento;
                                    RespDescuento = MessageBox.Show("¡ En realidad desea aplicar mas del 5% en descuento !", "Aviso !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (RespDescuento == DialogResult.Yes)
                                    {
                                        //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                        clsTarifa.DescuentoReactivacion = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    }
                                    else
                                    {
                                        dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                        //lstDV[filaIndice].Descuento = 0;
                                        clsTarifa.DescuentoReactivacion = 0;
                                    }
                                }
                                else if (Convert.ToInt32(filaData.Cells[6].Value) > 100)
                                {
                                    MessageBox.Show("¡ Error no puede aplicar un descuento muy alto ! \n ¡ Politicas de la empresa !", "Aviso !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                    //lstDV[filaIndice].Descuento = 0;
                                    clsTarifa.DescuentoReactivacion = 0;
                                }
                                else
                                {
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                    //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    clsTarifa.DescuentoReactivacion = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);

                                }
                            }
                            

                            break;

                        case 1:
                            if (idTipoVenta==2)
                            {
                                if (PrecioADescontar > 5 && PrecioADescontar < 101)
                                {
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Variables.ColorWarning;

                                    System.Windows.Forms.DialogResult RespDescuento;
                                    RespDescuento = MessageBox.Show("¡ En realidad desea aplicar mas del 5% en descuento !", "Aviso !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (RespDescuento == DialogResult.Yes)
                                    {
                                        if (lnTipoCon == -2 && ClsVentaGeneral.clsCronograma.periodoFinal < Variables.gdFechaSis.AddMonths(-2))
                                        {
                                            clsTarifa.DescuentoRentaAdelantada = PrecioADescontar;
                                        }
                                        else
                                        {
                                            clsTarifa.DescuentoProrrateo = PrecioADescontar;
                                        }
                                        //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    }
                                    else
                                    {
                                        dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                        //lstDV[filaIndice].Descuento = 0;
                                        clsTarifa.DescuentoProrrateo = 0;
                                    }
                                }
                                else if (Convert.ToInt32(filaData.Cells[6].Value) > 100)
                                {
                                    MessageBox.Show("¡ Error no puede aplicar un descuento muy alto ! \n ¡ Politicas de la empresa !", "Aviso !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                    //lstDV[filaIndice].Descuento = 0;
                                    clsTarifa.DescuentoProrrateo = 0;
                                }
                                else
                                {
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                    //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    clsTarifa.DescuentoProrrateo = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);

                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(filaData.Cells[6].Value) > 5 && Convert.ToInt32(filaData.Cells[6].Value) < 101)
                                {
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Variables.ColorWarning;

                                    System.Windows.Forms.DialogResult RespDescuento;
                                    RespDescuento = MessageBox.Show("¡ En realidad desea aplicar mas del 5% en descuento !", "Aviso !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (RespDescuento == DialogResult.Yes)
                                    {
                                        //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                        clsTarifa.DescuentoRentaAdelantada = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    }
                                    else
                                    {
                                        dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                        //lstDV[filaIndice].Descuento = 0;
                                        clsTarifa.DescuentoRentaAdelantada = 0;
                                    }
                                }
                                else if (Convert.ToInt32(filaData.Cells[6].Value) > 100)
                                {
                                    MessageBox.Show("¡ Error no puede aplicar un descuento muy alto ! \n ¡ Politicas de la empresa !", "Aviso !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                    //lstDV[filaIndice].Descuento = 0;
                                    clsTarifa.DescuentoRentaAdelantada = 0;
                                }
                                else
                                {
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                    //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    clsTarifa.DescuentoRentaAdelantada = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);

                                }
                            }                            

                            break;

                        case 2:

                            if (Convert.ToInt32(filaData.Cells[6].Value) > 5 && Convert.ToInt32(filaData.Cells[6].Value) < 101)
                            {
                                dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Variables.ColorWarning;

                                System.Windows.Forms.DialogResult RespDescuento;
                                RespDescuento = MessageBox.Show("¡ En realidad desea aplicar mas del 5% en descuento !", "Aviso !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (RespDescuento == DialogResult.Yes)
                                {
                                    //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    clsTarifa.DescuentoProrrateo = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                }
                                else
                                {
                                    dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                    //lstDV[filaIndice].Descuento = 0;
                                    clsTarifa.DescuentoProrrateo = 0;
                                }
                            }
                            else if (Convert.ToInt32(filaData.Cells[6].Value) > 100)
                            {
                                MessageBox.Show("¡ Error no puede aplicar un descuento muy alto ! \n ¡ Politicas de la empresa !", "Aviso !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                //lstDV[filaIndice].Descuento = 0;
                                clsTarifa.DescuentoProrrateo = 0;
                            }
                            else
                            {
                                dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                                //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                clsTarifa.DescuentoProrrateo = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);

                            }
                            break;

                    }


                }
                else if (dgv.Name == "dgvPagoPlan")
                {
                    if (Convert.ToInt32(filaData.Cells[6].Value) > 5 && Convert.ToInt32(filaData.Cells[6].Value) < 51)
                    {
                        dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Variables.ColorWarning;

                        System.Windows.Forms.DialogResult RespDescuento;
                        RespDescuento = MessageBox.Show("¡ En realidad desea aplicar mas del 5% en descuento !", "Aviso !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (RespDescuento == DialogResult.Yes)
                        {
                            lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                        }
                        else
                        {
                            dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                            lstDV[filaIndice].Descuento = 0;
                        }
                    }
                    else if (Convert.ToInt32(filaData.Cells[6].Value) > 50)
                    {
                        MessageBox.Show("¡ Error no puede aplicar un descuento muy alto ! \n ¡ Politicas de la empresa !", "Aviso !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                        lstDV[filaIndice].Descuento = 0;
                    }
                    else
                    {
                        dgv.Columns[posicionColumna].DefaultCellStyle.BackColor = Color.White;
                        lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);

                    }
                }

                

            }
            else if(Convert.ToInt32(cboTipoDescuentoPrecios.SelectedValue) == 2)
            {
                if (dgv.Name == "dgvPrimerPago")
                {
                    switch (filaIndice)
                    {
                        case 0:
                            if (idTipoVenta == 1)
                            {
                                if (PrecioADescontar > (clsTarifa.PrecioEquipo * lstVehiculo.Count))
                                {
                                    MessageBox.Show("El descuento no puede ser  mayor al Importe", "Aviso !!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    //lstDV[filaIndice].Descuento = 0;
                                    clsTarifa.DescuentoEquipo = 0;
                                }
                                else
                                {
                                    //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    clsTarifa.DescuentoEquipo = PrecioADescontar;
                                }
                            }
                            else if (idTipoVenta==2)
                            {
                                if (lnTipoCon==-2 && ClsVentaGeneral.clsCronograma.periodoFinal < Variables.gdFechaSis.AddMonths(-2))
                                {
                                    if (PrecioADescontar > (clsTarifa.PrecioReactivacion * lstVehiculo.Count) * lstDV[0].Couta)
                                    {
                                        MessageBox.Show("El descuento no puede ser mayor al Importe", "Aviso !!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        clsTarifa.DescuentoReactivacion = 0;
                                    }
                                    else
                                    {
                                        clsTarifa.DescuentoReactivacion = PrecioADescontar;
                                    }
                                }
                                else
                                {
                                    //Double precioRegular = clsTarifa.PrecioPlan < 30 ? clsTarifa.PrecioReactivacion : clsTarifa.PrecioPlan;
                                    Double precioRegular = clsPlanActual.idTipoPlan != clsPlan.idTipoPlan && clsPlan.idTipoPlan != 0 ? clsTarifa.PrecioReactivacion : clsTarifa.PrecioPlan;

                                    if (PrecioADescontar > (precioRegular * lstVehiculo.Count) * lstDV[0].Couta)
                                    {
                                        MessageBox.Show("El descuento no puede ser mayor al Importe", "Aviso !!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        clsTarifa.DescuentoReactivacion = 0;
                                    }
                                    else
                                    {
                                        clsTarifa.DescuentoReactivacion = PrecioADescontar;
                                    }
                                }
                                
                                
                            }
                            else if (idTipoVenta ==3)
                            {
                                if (PrecioADescontar > (clsTarifa.PrecioReactivacion * lstVehiculo.Count))
                                {
                                    MessageBox.Show("El descuento no puede ser  mayor al Importe", "Aviso !!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    //lstDV[filaIndice].Descuento = 0;
                                    clsTarifa.DescuentoReactivacion = 0;
                                }
                                else
                                {
                                    //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    clsTarifa.DescuentoReactivacion = PrecioADescontar;
                                }
                            }


                            break;

                        case 1:
                            if (idTipoVenta == 2)
                            {
                                if (lnTipoCon == -2 && clsPlanActual.idTipoPlan != clsPlan.idTipoPlan && clsPlan.idTipoPlan != 0)
                                {
                                    if (PrecioADescontar > (clsTarifa.PrecioRentaAdelantada * lstVehiculo.Count) * lstDV[0].Couta)
                                    {
                                        MessageBox.Show("El descuento no puede ser mayor al Importe", "Aviso !!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        clsTarifa.DescuentoRentaAdelantada = 0;
                                    }
                                    else
                                    {
                                        clsTarifa.DescuentoRentaAdelantada = PrecioADescontar;
                                    }
                                }
                                else
                                if (PrecioADescontar > (clsTarifa.PrecioProrrateo * lstVehiculo.Count))
                                {
                                    MessageBox.Show("El descuento no puede ser mayor al Importe", "Aviso !!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    //lstDV[filaIndice].Descuento = 0;
                                    clsTarifa.DescuentoProrrateo = 0;
                                }
                                else
                                {
                                    //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    clsTarifa.DescuentoProrrateo = PrecioADescontar;
                                }

                            }
                            else 
                            {
                                if (PrecioADescontar > (clsTarifa.PrecioRentaAdelantada * lstVehiculo.Count))
                                {
                                    MessageBox.Show("El descuento no puede ser mayor al Importe", "Aviso !!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    //lstDV[filaIndice].Descuento = 0;
                                    clsTarifa.DescuentoRentaAdelantada = 0;
                                }
                                else
                                {
                                    //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                    clsTarifa.DescuentoRentaAdelantada = PrecioADescontar;
                                }
                            }


                            break;

                        case 2:

                            if (PrecioADescontar > (clsTarifa.PrecioProrrateo * lstVehiculo.Count))
                            {
                                MessageBox.Show("El descuento no puede ser mayor al Importe", "Aviso !!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                //lstDV[filaIndice].Descuento = 0;
                                clsTarifa.DescuentoProrrateo = 0;
                            }
                            else
                            {
                                //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                                clsTarifa.DescuentoProrrateo = PrecioADescontar;
                            }
                            break;

                    }


                }
                else if (dgv.Name == "dgvPagoPlan")
                {
                    if (PrecioADescontar > (clsTarifa.PrecioPlan * lstVehiculo.Count) *lstDV[0].Couta)
                    {
                        MessageBox.Show("El descuento no puede ser mayor al Importe", "Aviso !!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        lstDV[filaIndice].Descuento = 0;
                    }
                    else
                    {
                        lstDV[filaIndice].Descuento = PrecioADescontar;
                    }
                }

            }
        }
        private void dgvTarifa_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {        
        }

        private void dgvTarifa_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
           
               
        }

        private Boolean verifApertura()
        {
            Boolean est = false;
            Int32 estadoApertura = FunGeneral.fnVerificarApertura(Variables.gnCodUser);
            if (estadoApertura == 1)
            {
                est = true;
            }
            else if (estadoApertura == 0)
            {

                MessageBox.Show("Por favor Aperture caja para poder registrar ingreos", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                est = false;
            }
            else
            {
                MessageBox.Show("Ya cerraste caja. Por favor Aperture caja para poder registrar ingreos", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                est = false;
            }
            return est;
        }
        private void AbrirReporteVentas_Click(object sender, EventArgs e)
        {
            Boolean activarEnvio = false;
            List<validacion> lstVali = new List<validacion>();
            lstVali = fnCombinarListaValidacion(lstValidacionCliente, lstValidacionRespPago);
            lstVali = fnCombinarListaValidacion(lstVali, lstValidacionVehiculo);
            var resul = fnValidarTabla(lstVehiculo);
            lstVali = fnCombinarListaValidacion(lstVali, lstValidacionPlan);
            activarEnvio = fnValidarDatosAEnviar(lstVali);
            if (lnTipoCon==-1)
            {
                if (activarEnvio == true /*&& estaCboDirecInstal==true && estatxtDescDirecInsrtalacion==true*/)
                {
                    if (Convert.ToString(cboTipoVenta.SelectedValue) == "2" || lnTipoCon == -1)
                    {
                        System.Windows.Forms.DialogResult resultDialog = MessageBox.Show("¿La Fecha de Pago / Venta es la Correcta ? " + dtFechaPago.Value.ToString("dd/MM/yyyy") + "\n" +
                                                                                        "\n \n ¿La Fecha de Inicio del contrato es la Correcta ? " + dtpFechaRegistro.Value.ToString("dd/MM/yyyy"), "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                        if (resultDialog == DialogResult.Yes)
                        {
                            System.Windows.Forms.DialogResult resultDialogPlan = MessageBox.Show("¿El Tipo de Plan es el Correcto ? " + cboTipoPlanP.Text + "\n" +
                                                        "¿El Plan es el Correcto ? " + cboPlanP.Text + " ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                            if (resultDialogPlan == DialogResult.Yes)
                            {
                                fnMandarAVistaPrevia();
                            }
                        }
                    }
                    else
                    {
                        fnMandarAVistaPrevia();
                    }

                }
                else
                {
                    MessageBox.Show("Complete correctamente los Campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (verifApertura() == true)
                {
                    if (activarEnvio == true /*&& estaCboDirecInstal==true && estatxtDescDirecInsrtalacion==true*/)
                    {
                        if (Convert.ToString(cboTipoVenta.SelectedValue) == "2" || lnTipoCon == -1)
                        {
                            System.Windows.Forms.DialogResult resultDialog = MessageBox.Show("¿La Fecha de Pago / Venta es la Correcta ? " + dtFechaPago.Value.ToString("dd/MM/yyyy") + "\n" +
                                                                                            "\n \n ¿La Fecha de Inicio del contrato es la Correcta ? " + dtpFechaRegistro.Value.ToString("dd/MM/yyyy"), "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                            if (resultDialog == DialogResult.Yes)
                            {
                                System.Windows.Forms.DialogResult resultDialogPlan = MessageBox.Show("¿El Tipo de Plan es el Correcto ? " + cboTipoPlanP.Text + "\n" +
                                                            "¿El Plan es el Correcto ? " + cboPlanP.Text + " ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                                if (resultDialogPlan == DialogResult.Yes)
                                {
                                    fnMandarAVistaPrevia();
                                }
                            }
                        }
                        else
                        {
                            fnMandarAVistaPrevia();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Complete correctamente los Campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            
            
           
        }
        private List<validacion> fnCombinarListaValidacion(List<validacion> lstPrinci, List<validacion> lstUnion)
        {
            List<validacion> lstValidacion = new List<validacion>();
            lstValidacion = lstPrinci.Concat(lstUnion).ToList();
            return lstValidacion;
        }
        //private List<DetalleVenta> fnGenerarDetalleVentasAnual()
        //{
        //    List<DetalleVenta> lstDC = new List<DetalleVenta>();
            


        //        lstDC.Add(
        //        new DetalleVenta
        //        {
        //            IdDetalleVenta = clsTarifa.IdTarifa,
        //            Descripcion="Equipo",
        //            PrecioUni= clsTarifa.PrecioEquipo,
        //            Cantidad = lstVehiculo.Count
        //        }) ;
        //    lstDC.Add(
        //       new DetalleVenta
        //       {
        //           IdDetalleVenta = clsTarifa.IdTarifa,
        //           Descripcion = "Plan",
        //           PrecioUni = clsTarifa.PrecioPlan,
        //           Cantidad = lstVehiculo.Count
        //       }) ;

        //    return lstDC;
        //}
        private void fnMandarAVistaPrevia()
        {
            Consultas.frmVPVenta frmVenta = new Consultas.frmVPVenta();

            List<DetalleVentaCabecera> lstDVC = new List<DetalleVentaCabecera>();
            List<Cliente> lstCliente = new List<Cliente>();
            lstCliente.Add(clsRespPago);

            lstDetalleVDocumento = Convert.ToInt32(cboTipoPlanP.SelectedValue) == 1 ? lstTotalDetalle : lstPP;
            lstDVC.Add(fnCalcularCabeceraDetalle(lstDetalleVDocumento, false));
            List <xmlDocumentoVentaGeneral> xmlDocumentoVenta = new List<xmlDocumentoVentaGeneral>();


            //lstDetalleVDocumento = Convert.ToInt32(cboTipoPlanP.SelectedValue) == 1?lstTotalDetalle: lstPP;
            //fncalcularTotales(lstDetalleVDocumento, lstDVC);
            frmVenta.Inicio(fnCargarDocumentoVenta(lstDVC), lstDetalleVDocumento, 0);
            if (Convert.ToInt32(cboTipoVenta.SelectedValue)!=2)
            {
                if (estGenrarVenta == true)
                {
                    estGenrarVenta = false;
                    frmReferenciaInstalacion frmRefInstal = new frmReferenciaInstalacion();
                    frmRefInstal.Inicio(1, Convert.ToDateTime(dtpFechaRegistro.Value));

                }
            }
            
            if (estGenrarVenta == true)
            {
                cargarClaseVentaGeneral();



                xmlDocumentoVenta.Add(new xmlDocumentoVentaGeneral
                {
                    xmlDocumentoVenta = fnCargarDocumentoVenta(lstDVC),
                    xmlDetalleVentas = lstDetalleVDocumento,
                });
            }
            //cargarClaseVentaGeneral();
            fnActivarVenta(estGenrarVenta, xmlDocumentoVenta);

        }
        private String fnObtenerVehiculos()
        {
            String placa = "";
            for (Int32 i=0;i<lstVehiculo.Count;i++)
            {
                if ((i+1)== lstVehiculo.Count)
                {
                    placa += lstVehiculo[i].vPlaca;
                }
                else
                {
                    placa += lstVehiculo[i].vPlaca+" , ";
                }
                
            }
            return placa;
        }
        private List<DocumentoVenta> fnCargarDocumentoVenta(List<DetalleVentaCabecera> lstdvc)
        {
            List<DocumentoVenta> lsDocVenta = new List<DocumentoVenta>();
            TipoTarifa lstTipoVenta = new TipoTarifa();
            lstTipoVenta = lstTipoTarifa.First(s => s.IdTipoTarifa == Convert.ToInt32(cboTipoVenta.SelectedValue));
            String SolofechaV = dtFechaPago.Value.ToString("yyyy/MM/dd");
            DateTime fechaConHora = Convert.ToDateTime(SolofechaV).AddHours(Variables.gdFechaSis.Hour).AddMinutes(Variables.gdFechaSis.Minute);
            Personal clsPersonal = FunGeneral.fnObtenerUsuarioActual();
            lsDocVenta.Add(new DocumentoVenta
            {
                idCliente = clsRespPago.idCliente,
                cCliente = FunGeneral.FormatearCadenaTitleCase(clsRespPago.cNombre + " " + clsRespPago.cApePat + " " + clsRespPago.cApeMat),
                cTipoDoc = fnDevolverTipoDocPersona(clsRespPago.cTiDo),
                cDireccion = FunGeneral.FormatearCadenaTitleCase(clsRespPago.cDireccion),
                cDocumento = clsRespPago.cDocumento,
                SimboloMoneda = clsMoneda.cSimbolo,
                cCodDocumentoVenta = Convert.ToString(cboComprobanteP.SelectedValue),
                NombreDocumento = Convert.ToString(cboComprobanteP.Text),
                dFechaVenta = fechaConHora,
                idMoneda = clsMoneda.idMoneda,
                nSubtotal = lstdvc[0].SubTotal,
                nNroIGV = 18,
                nIGV = lstdvc[0].IGV,
                nMontoTotal = lstdvc[0].Total,
                cUsuario = clsPersonal.cPrimerNom + " " + clsPersonal.cApePat + " " + clsPersonal.cApeMat,
                cVehiculos = fnObtenerVehiculos(),
                cDescripcionTipoPago = (lstPagosTrand.Count > 0) ? FunGeneral.FormatearCadenaTitleCase(lstPagosTrand[0].cDescripTipoPago) : "",
                cDescripEstadoPP = (lstPagosTrand.Count > 0) ? lstPagosTrand[0].cEstadoPP : "",
                cTipoVenta= lstTipoVenta.Nombre,
                est1=false

            }) ;
            return lsDocVenta;
        }

        
        private String fnDevolverTipoDocPersona(Int32 tipoDoc)
        {
            String cDoc = "";
            foreach (TipoDocumento item in lstTD)
            {
                if (item.TDid== tipoDoc)
                {
                    cDoc= item.TDnombre;
                }
            }
            return cDoc;
        }
        private void cargarClaseVentaGeneral()
        {
            List<DetalleVentaCabecera> lstDVC = new List<DetalleVentaCabecera>();
            List<Cliente> lstCliente = new List<Cliente>();
            DetalleVentaCabecera clsDVentaCabecera = new DetalleVentaCabecera();
            lstCliente.Add(clsRespPago);
            lstDVC.Add(fnCalcularCabeceraDetalle(lstPP, false));

            //ClsVentaGeneral.clsDetalleVentaCabecera.lstDetalleVenta = lstTotalDetalle;
            ClsVentaGeneral = new VentaGeneral
            {
                IdVentaGeneral = 0,
                codigoVenta = ClsVentaGeneral.codigoVenta == null ? "" : ClsVentaGeneral.codigoVenta,
                FechaRegistro = Variables.gdFechaSis,
                FechaPago = Convert.ToDateTime(dtFechaPago.Value),
                FechaVenta = Convert.ToDateTime(dtpFechaRegistro.Value),
                IdUsuario = Variables.gnCodUser,
                Estado = "ESVG0001",
                cCodEstadoPP = lstPagosTrand[0].cEstadoPP,
                ClsCliente = clsCliente,
                ClsResponsablePago = clsRespPago,
                ClsPlan = clsPlan,
                ClsTarifa = clsTarifa,
                ClsMoneda = clsMoneda,
                ClsCiclo = clsCiclo,
                clsContrato=ClsVentaGeneral.clsContrato,
                clsDetalleVentaCabecera = fnCalcularCabeceraDetalle(lstDetalleVDocumento, false),
                lstDetalleCronograma = fnGenerarCronograma(dtpFechaRegistro.Value),
                lstVehiculo = lstVehiculo,
                lstVehiculoNRenov = lstVehiculoSinRenovar,
                codDireccionInstalacion = cCodigoReferenciaInstalacion,
                DescripDireccionInstalacion = cDescripcionReferenciaInstalacion,
                FechaDeInstalacion= cCodigoReferenciaInstalacion!=""?dFechaDeInstalacion:Variables.gdFechaSis,
                estFinalizacionContrato= finalizacionContrato.Checked==true?1:0

            };

        }

        public void fnObtenerDatosDeRefInstalacion(String cCodRefInstalacion ,String DescripRefInstalacion, SiticoneDateTimePicker dFechInstalacion,Boolean estado)
        {
            cCodigoReferenciaInstalacion = cCodRefInstalacion;
            cDescripcionReferenciaInstalacion = DescripRefInstalacion;
            dFechaDeInstalacion = Convert.ToDateTime(dFechInstalacion.Value);
            estGenrarVenta = estado;

        }
        public void fnCambiarEstadoVenta(bool estado)
        {
            estGenrarVenta = estado;
        }
        public void fnActivarInprecion(bool estado)
        {
            estActivarImprecion = estado;
            if (estActivarImprecion==true)
            {
                fnMandarAImprimirDocumento(cCodigoVenta, lnTipoCon);
            }

        }

        private void fnActivarVenta(bool estado, List<xmlDocumentoVentaGeneral> xmlDocumentoVenta)
        {
            Boolean bResult=false;
            if (estado)
            {
               
                    bResult = fnGenerarVenta(xmlDocumentoVenta);
                
                if (bResult)
                {
                    if (swEstadoImprimirDocumento.Checked==true)
                    {
                        bResult = false;
                        bResult=fnBuscarVentaAImprimir(-1);
                        if (bResult==true)
                        {
                            MessageBox.Show("La venta se Generó Exitosamente", "Mensaje Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fnLimpiarControles();
                            bTipoTab = false;
                            bActivarChecks = false;
                        }
                        else
                        {
                            MessageBox.Show("Error al Imprimir Comprobante de venta", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        MessageBox.Show("La venta se Generó Exitosamente", "Mensaje Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fnLimpiarControles();
                        bTipoTab = false;
                        bActivarChecks = false;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Error al generar la venta-Contacte al administrador", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public Boolean fnBuscarVentaAImprimir(Int16 tipoCon)
        {
            clsUtil objUtil = new clsUtil();
            BLVentaGeneral blVentaGeneral = new BLVentaGeneral();
            String cCodVenta = "";
            try
            {

                cCodVenta = blVentaGeneral.blBuscarVentaAImprimir(ClsVentaGeneral, tipoCon);
                if (cCodVenta != "")
                {
                    return fnMandarAImprimirDocumento(cCodVenta, lnTipoCon);
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnBuscarVehiculo", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
            }

        }

        public Boolean fnMandarAImprimirDocumento(String cCodVenta,Int16 lnTipoCon)
        {
            try
            {
                if (Variables.bitActivePrintDirect)
                {
                    int idVenta = Convert.ToInt32("00001");
                    BLDocumentoVenta objVenta = new BLDocumentoVenta();
                    DocumentoVenta[] lstVenta = new DocumentoVenta[1];
                    List<DetalleVenta> lstDetalleVen = new List<DetalleVenta>();
                    DetalleVenta detVent = new DetalleVenta();
                    BLOtrasVenta objTipoVenta = new BLOtrasVenta();

                    List<xmlDocumentoVentaGeneral> xmlDocumentoVenta = new List<xmlDocumentoVentaGeneral>();
                    xmlDocumentoVentaGeneral xmlDocVenta = new xmlDocumentoVentaGeneral();
                    //xmlDocVenta = objTipoVenta.blBuscarDocumentoVentaGeneral(cCodVenta,Convert.ToInt32(cboTipoVenta.SelectedValue));
                    xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago);
                    xmlDocVenta.xmlDocumentoVenta[0].cDescripEstadoPP = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cDescripEstadoPP);
                    xmlDocumentoVenta.Add(xmlDocVenta);

                    lstVenta = xmlDocumentoVenta[0].xmlDocumentoVenta.ToArray();
                    lstDetalleVen = xmlDocumentoVenta[0].xmlDetalleVentas;

                    GenericMasterDetail<DocumentoVenta, DetalleVenta> genericMasterDetail = new GenericMasterDetail<DocumentoVenta, DetalleVenta>
                    {
                        Header = lstVenta[0],
                        Detail = lstDetalleVen,
                        empresa = new Empresa
                        {
                            RazonSocial = Variables.gsEmpresa,
                            Ruc = Variables.gsRuc,
                            Direccion = Variables.gsEmpresaDir

                        },
                        sucursal = new Sucursal
                        {
                            Nombre = Variables.gsSucursal,
                            Direccion = Variables.gsEmpresaDir,
                            Ubigeo=Variables.gsSucursalUbigeo
                        }
                    };

                    GenericDocument<DocumentoVenta, DetalleVenta> document = new GenericDocument<DocumentoVenta, DetalleVenta>
                    {
                        Document = genericMasterDetail
                    };

                    string jsonDocument = JsonConvert.SerializeObject(document);
                    PrintRequest printRequest = new PrintRequest
                    {
                        Identity = "",
                        OperatorId = "",
                        StringifiedDocumentData = jsonDocument,
                        NumberOfCopies = 1,
                        //TargetPrinterName = Variables.gsImpresora,
                        TargetPrinterName = "EPSON099E3E (L395 Series)",
                        TemplateName = "Venta",
                        PaperWidth = 80,
                    };
                    FunGeneral.fnImprimirVoucher(printRequest);
                }
                else
                {
                    Int32 idVenta = 0;
                    frmImpresion frmImpre = new frmImpresion();
                    idVenta = Convert.ToInt32("0001");
                    frmImpre.fnInicio(0, "Imprimir Documento de Venta", idVenta);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }

            
        }
        private Boolean fnGenerarVenta(List<xmlDocumentoVentaGeneral> xmlDocumentoVenta)
        {
            clsUtil objUtil = new clsUtil();
            BLVentaGeneral blVentaGeneral = new BLVentaGeneral();
            Boolean bResult;
            try
            {
                lstPagosTrand[0].idMoneda = Convert.ToInt32(cboMonedaP.SelectedValue);
                lstPagosTrand[0].dFechaPago = Convert.ToDateTime(dtFechaPago.Value);
                ClsVentaGeneral.lstPagos = lstPagosTrand;
                ClsVentaGeneral.ClsEquipoImies = clsEquipo_imeis;
                bResult = blVentaGeneral.blGenerarVentaGeneral(ClsVentaGeneral, xmlDocumentoVenta, lnTipoCon);

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnBuscarVehiculo", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
            }

        }
        private DetalleVentaCabecera fnCalcularCabeceraDetalle(List<DetalleVenta> lstDV, Boolean total)
        {
            DetalleVentaCabecera clsDVC = new DetalleVentaCabecera();
            DetalleVenta dvMensual = new DetalleVenta();
            Double totalMensual = lstPP.Sum(item => item.Importe);

            clsDVC.Total = Convert.ToInt32(cboTipoPlanP.SelectedValue) == 1 ? lstDV.Sum(item => item.Importe) : totalMensual;
            clsDVC.SubTotal = (clsDVC.Total / 1.18);
            clsDVC.IGV = (clsDVC.Total - clsDVC.SubTotal);
            clsDVC.SimboloMoneda = clsMoneda.cSimbolo;
            clsDVC.NombreDocumento = Convert.ToString(cboComprobanteP.Text);
            clsDVC.CodDocumento = Convert.ToString(cboComprobanteP.SelectedValue);
            if (lstTotalDetalle.Count > 0)
            {

                lstTotalDetalle[0].cSimbolo = clsMoneda.cSimbolo;
            }
            clsDVC.lstDetalleVenta = lstTotalDetalle;
            if (total)
            {
                fnColocarTotales(clsDVC);
            }
            return clsDVC;
        }

        private void fnColocarTotales(DetalleVentaCabecera clsDVC)
        {          

            //txtTotalPrimerPago.Text = $"{clsDVC.SimboloMoneda} {string.Format("{0:0.00}", totalMensual)}";
            txtSubtotal.Text = $"{clsDVC.SimboloMoneda} {string.Format("{0:0.00}", clsDVC.SubTotal)}";
            txtIGV.Text = $"{clsDVC.SimboloMoneda} {string.Format("{0:0.00}", clsDVC.IGV)}";
            txtTotal.Text = $"{clsDVC.SimboloMoneda} {string.Format("{0:0.00}", clsDVC.Total)}";
        }
        

        private void cboCicloP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoPlanP.SelectedValue)==2)
            {
                var result = FunValidaciones.fnValidarCombobox(lstValidacionPlan[2].combobox, erCilcloP, imgCicloP);
                lstValidacionPlan[2].estado = result.Item1;
                lstValidacionPlan[2].mensaje = result.Item2;
            }
          

            Int32 idCiclo = Convert.ToInt32(cboCicloP.SelectedValue ?? 0);
            clsCiclo = Ciclo.fnObtenerCicloSeleccionado(idCiclo,lstC);
            
            lstPP = fnGenerarPagoPrincipal();
            fnCargaTablaDetalle(lstPP, dgvPrimerPago);
            fncalcularTotales(lstPP, lstDV);
        }

        private void btnLimpiarE_Click(object sender, EventArgs e)
        {
            //Grupo Plan
            cboPlanP.SelectedValue = 0;
            cboComprobanteP.SelectedValue = 0;
           
            imgTipoPlanP.Image = null;
            imgPlanP.Image = null;
            imgCicloP.Image = null;
            imgComprobanteP.Image = null;
            erTipoPlan.Text = "";
            erPlanP.Text = "";
            erCilcloP.Text = "";
            erComprobanteP.Text = "";
            clsPlan = new Plan();
            clsCiclo = new Ciclo();
        }

        private void cboComprobanteP_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(lstValidacionPlan[3].combobox, erComprobanteP, imgComprobanteP);
            lstValidacionPlan[3].estado = result.Item1;
            lstValidacionPlan[3].mensaje = result.Item2;
        }

        private void txtIdVG_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreBus_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPlacaBus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {

                dEstadoBusquedaPaginacion = true;
                fnBuscarListaVentas(dgvListaVentas, 0, 0, -1);
                if (btnBuscarMonto.Checked==true)
                {
                    fnBuscarListaVentas(dgvListaVentas, 0, 0, -4);
                }
                
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

           
            fnBuscarListaVentas(dgvListaVentas, 0, 0, -1);
            if (btnBuscarMonto.Checked == true)
            {
                fnBuscarListaVentas(dgvListaVentas, 0, 0, -4);
            }
        }

       
        private void chkHabilitarFechasBus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechasBus.Checked==true)
            {
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
                gbBuscarListaVentas.Enabled = true;
            }
            else
            {
                gbBuscarListaVentas.Enabled = false;
            }
            //if (cargoFrom == true)
            //{
            //    fnBuscarListaVentas(dgvListaVentas, 0,0, -1);

            //}
        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fila = Convert.ToInt32(cboPagina.Text);
            if (cargoFrom == true && dEstadoBusquedaPaginacion==false)
            {
                fnBuscarListaVentas(dgvListaVentas, fila,0, -1);

            }
        }

        private void dgvListaVentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvListaVentas.Columns[e.ColumnIndex].Name == "lvBtnImprimir" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvListaVentas.Rows[e.RowIndex].Cells["lvBtnImprimir"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\Impresora.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvListaVentas.Rows[e.RowIndex].Height = 45;
                this.dgvListaVentas.Columns[e.ColumnIndex].Width = 45;


                e.Handled = true;

            }
        }

        private void dgvListaVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvListaVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListaVentas.Columns["lvBtnImprimir"].Index && e.RowIndex >= 0)
            {
                Int32 idTipoVenta = Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[16].Value);
                if (idTipoVenta==2)
                {
                    cmsImpresiones.Items[2].Visible = false;

                }
                else
                {
                    cmsImpresiones.Items[2].Visible = true;
                }
                var mousePosition = dgvListaVentas.PointToClient(Cursor.Position);
                cmsImpresiones.Show(dgvListaVentas, 940 ,mousePosition.Y);
            }
        }
        public void fnBuscarDocumentoVenta(String cCodVenta,Int32 tipCon,Int32 idTipoTarifa,Int32 idContrato)
        {
            BLOtrasVenta objTipoVenta = new BLOtrasVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtResp = new DataTable();
            List<TipoVenta> lsTipoVenta = new List<TipoVenta>();
            Int32 filas = 20;
            List<xmlDocumentoVentaGeneral> xmlDocumentoVenta = new List<xmlDocumentoVentaGeneral>();
            xmlDocumentoVentaGeneral xmlDocVenta = new xmlDocumentoVentaGeneral();

            try
            {
                xmlDocVenta = objTipoVenta.blBuscarDocumentoVentaGeneral(cCodVenta, tipCon, idTipoTarifa, idContrato);
                xmlDocVenta.xmlDocumentoVenta[0].cDireccion = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cDireccion);
                //xmlDocVenta.xmlDocumentoVenta[0].cCliente = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cCliente);
                xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago);
                xmlDocumentoVenta.Add(xmlDocVenta);

                Consultas.frmVPVenta abrirFrmVPOtrasVentas = new Consultas.frmVPVenta();

                abrirFrmVPOtrasVentas.Inicio(xmlDocumentoVenta[0].xmlDocumentoVenta, xmlDocumentoVenta[0].xmlDetalleVentas, 1);

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnListarProveedorActivo", ex.Message);

            }
            finally
            {
                objUtil = null;
                objTipoVenta = null;
                lsTipoVenta = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fnLimpiarControles();
        }

        private Int64 fnObtenerStockEquipos()
        {
            BLEquipo_Imeis objImeis = new BLEquipo_Imeis();
            clsUtil objUtil = new clsUtil();
            DataTable dtResult = new DataTable();
            Equipo_imeis objEquipoImeis = new Equipo_imeis();
            List<Equipo_imeis> lstEquipos = new List<Equipo_imeis>();
            Int64 Stock = 0;
            String Nombre = "";
            try
            {
                Int32 idTipoPlan = Convert.ToInt32(cboTipoPlanP.SelectedValue);
                Int32 idPlan = Convert.ToInt32(cboPlanP.SelectedValue);
                lstEquipos = objImeis.blDevolverStockEquipos(idTipoPlan, idPlan);
                
                lstEquipo_imeis= lstEquipos;

               Int32 cantidad= lstEquipo_imeis.Count;

                //btnStockEquipos.Text = Convert.ToString(Stock);
                //btnStockAccesorios.Text = Convert.ToString(Stock);
                //fnColoresBotonStock(Stock);
                return lstEquipos[0].totalRegistros;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnBuscarVehiculo", ex.Message);
                return 0;
            }
            finally
            {
                objImeis = null;
                objUtil = null;
            }

        }

      

  
        private void txtDireccionDeInstalacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.KeyChar = char.ToUpper(e.KeyChar);
            FunValidaciones.fnValidarTipografia(e, "LETRAS", false);
        }

        private void dgvPrimerPago_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 filaIndice = e.RowIndex == -1 ? 0 : e.RowIndex;
            Int32 posicionColumna = e.ColumnIndex;
            Int32 numFilasTabla = dgvPagoPlan.Rows.Count;

            if (numFilasTabla > 0)
            {
                if (posicionColumna == 6)
                {
                    DataGridViewRow filaData = dgvPrimerPago.Rows[filaIndice];
                    fnValidarPrecioDescuento(dgvPrimerPago, filaData, filaIndice, posicionColumna);
                    //filaData.Cells[4].Style.BackColor = Color.Red;
                    //lstDV[filaIndice].Descuento = Convert.ToDouble(filaData.Cells[posicionColumna].Value ?? 0);
                   
                }
                fnCalcularTotalPago();
                lstPP = fnGenerarPagoPrincipal();
                fnCargaTablaDetalle(lstPP, dgvPrimerPago);
                fncalcularTotales(lstPP, lstDV);
            }
        }

        private void fnHabilitarPrimerPago(Boolean estado)
        {
            lblPanelPrimerPago.Visible = estado;
            dgvPrimerPago.Visible = estado;
        }
        private void cboTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bActivarChecks!=true)
            {
                fnNoEditarColumna(false);
            }
            else
            {
                fnNoEditarColumna(true);
            }
            //cboPlan_SelectedIndexChanged(sender, e);
            
        }

        private void txtPlacaVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void fnDevolverVehiculoRenovacion(String CodVenta,Int32 idVehiculo, String PlacaBuscada,Int32 idContrato)
        {
            BLVentaGeneral objVenta = new BLVentaGeneral();

            List<VentaGeneral> lstvgeneral = new List<VentaGeneral>();

            String RowVehiculos = Convert.ToString(dgvListaVentas.CurrentRow.Cells[5].Value);
            String[] ArrayVehiculos = RowVehiculos.Split(';');
            List<Vehiculo> lstVh = new List<Vehiculo>();
            //lstVehiculo = fnDebolverDatVehiculo(RowVehiculos, ArrayVehiculos);


            lstvgeneral = objVenta.blDevolverVehiculoRenovacion(PlacaBuscada, CodVenta, idVehiculo, idContrato, lstVh);

            
            if (PlacaBuscada!="")
            {
                lnTipoCon = -1;
                ClsVentaGeneral.lstDetalleCronograma = lstvgeneral[0].lstDetalleCronograma;
            }
            else
            {
                
                ClsVentaGeneral = new VentaGeneral();

                cboPlanP.SelectedValue = 0;
                //ClsVentaGeneral.clsDetalleVentaCabecera.lstDetalleVenta.Clear();
                siticoneCheckBox1.Checked = false;
                ClsVentaGeneral.ClsTarifa = lstvgeneral[0].ClsTarifa;
                cboMonedaP.SelectedValue = lstvgeneral[0].ClsMoneda.idMoneda;
                lstVehiculo = lstvgeneral[0].lstVehiculo;
                //ClsVentaGeneral.FechaRegistro = lstvgeneral[0].FechaRegistro;
                //ClsVentaGeneral.codigoVenta = lstvgeneral[0].codigoVenta;
                //ClsVentaGeneral.clsContrato = lstvgeneral[0].clsContrato;
                ClsVentaGeneral = lstvgeneral[0];
                //cboTipoVenta.SelectedValue = ClsVentaGeneral.ClsTarifa.IdTipoTarifa;
                
                dtpFechaRegistro.Value = bTipoTab == true ? ClsVentaGeneral.FechaVenta.AddMonths(12) : ClsVentaGeneral.FechaVenta;
                //dtFechaPago.Value = bTipoTab == true ? ClsVentaGeneral.FechaPago.AddMonths(12) : ClsVentaGeneral.FechaPago;
                dtFechaPago.Value = Variables.gdFechaSis;
                fnCargarTablaVehiculo();

                var resul = fnValidarTabla(lstVehiculo);
                lstValidacionVehiculo[0].estado = resul.Item1;
                lstValidacionVehiculo[0].mensaje = resul.Item2;

                clsCliente = lstvgeneral[0].ClsCliente;

                clsPlanActual.idTipoPlan = lstvgeneral[0].ClsPlan.idTipoPlan;
                clsPlanActual.idPlan = lstvgeneral[0].ClsPlan.idPlan;
                clsPlanActual.CicloPlan = lstvgeneral[0].ClsCiclo.IdCiclo;

                //cboTipoClienteC.SelectedValue = lstvgeneral[0].ClsCliente.cTipPers;
                //cboTipoDocumentoC.SelectedValue = lstvgeneral[0].ClsCliente.cTiDo;
                txtDocumentoC.Text = lstvgeneral[0].ClsCliente.cDocumento.Trim();
                txtNombreC.Text = $"{ lstvgeneral[0].ClsCliente.cNombre.Trim()} {lstvgeneral[0].ClsCliente.cApePat.Trim()} {lstvgeneral[0].ClsCliente.cApeMat.Trim()}";
                txtCorreoC.Text = lstvgeneral[0].ClsCliente.cCorreo.Trim();
                txtTelefonoFijoC.Text = lstvgeneral[0].ClsCliente.cTelFijo.Trim();
                txtCelularC.Text = lstvgeneral[0].ClsCliente.cTelCelular.Trim();
                txtDireccionC.Text = lstvgeneral[0].ClsCliente.cDireccion.Trim();

                //cboTipoPlanP.SelectedValue = clsPlanActual.idTipoPlan;
                //cboPlanP.SelectedValue = clsPlanActual.idPlan;
                //cboCicloP.SelectedValue = clsPlanActual.CicloPlan;
                rdbSi.Checked = true;
                //cboPlanP.SelectedValue = clsPlanActual.idPlan;
                dgDocumentoC.Visible = false;
                //clsPlan = lstvgeneral[0].ClsPlan;
                fnNoEditarColumna(true);
            }
           

            

        }

        public void fnNoEditarColumna(Boolean estado)
        {
            dgvVehiculos.Columns[5].Visible = !estado;
            siticoneCheckBox1.Visible = estado;
            finalizacionContrato.Visible = estado;
        }
       
        //private void dgvPlacasVehiculo_DoubleClick(object sender, EventArgs e)
        //{
        //    String codVenta = Convert.ToString(dgvPlacasVehiculo.Rows[dgvPlacasVehiculo.CurrentRow.Index].Cells[1].Value.ToString());
        //    Int32 idvehiculo = Convert.ToInt32(dgvPlacasVehiculo.Rows[dgvPlacasVehiculo.CurrentRow.Index].Cells[0].Value.ToString());
            
        //}

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //fnBuscarVentaAImprimir();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String Dato = "LUJAN MARCELO PEDRO JAVIER";
            MessageBox.Show("Sin Convertir: "+Dato+"\n Convertido: "+ FormatearCadenaTitleCase(Dato), "Conversiones",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public string FormatearCadenaTitleCase(string str)
        {
            String dat = str.ToLower();
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dat); ;
        }

        private void swEstadoImprimirDocumento_CheckedChanged(object sender, EventArgs e)
        {
            if (swEstadoImprimirDocumento.Checked==true)
            {
                fnActivarImpresion(lblSWSi,true);
                fnActivarImpresion(lblSWNo,false);
            }
            else
            {
                fnActivarImpresion(lblSWSi, false);
                fnActivarImpresion(lblSWNo, true);
            }
        }
        private void fnActivarImpresion(Label lbl,Boolean estado)
        {
            lbl.Visible=estado;
        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaInicialBus_ValueChanged(object sender, EventArgs e)
        {
            //if (cargoFrom==true)
            //{
            //    fnBuscarListaVentas(dgvListaVentas, 0,0, -1);
            //}
        }

        private void dtpFechaFinalBus_ValueChanged(object sender, EventArgs e)
        {
            //dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
            
            //if (cargoFrom == true)
            //{
            //    fnBuscarListaVentas(dgvListaVentas, 0,0, -1);

            //}
        }

        private void dgvListaVentas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
                    if (!clickedRow.Selected)
                    {
                        dgvListaVentas.CurrentCell = clickedRow.Cells[e.ColumnIndex];

                    }
                    else
                    {
                        var mousePosition = dgvListaVentas.PointToClient(Cursor.Position);
                        cmListaVentas.Show(dgvListaVentas, mousePosition);
                    }

                }
            }
        }

        private void dgvListaVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmPrevisualizar frmPrev = new FrmPrevisualizar();
            string dato = "";
            
            if (e.ColumnIndex == dgvListaVentas.Columns["Vehiculos_lv"].Index && e.RowIndex >= 0)
            {
                dato = fnRecortarCadena(Convert.ToString(dgvListaVentas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                frmPrev.inicio(2, dato);
            }if (e.ColumnIndex == dgvListaVentas.Columns["Ciente_Rs_lv"].Index && e.RowIndex >= 0)
            {
                dato = Convert.ToString(dgvListaVentas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                frmPrev.inicio(2, dato);
            }
        }
        private String fnRecortarCadena(String cadena)
        {
            String[] valores = cadena.Split(';') ;
            String debolver = "";
            for (Int32 i=0;i< valores.Length-1; i++)
            {
                debolver +=  string.Format((i+1) + " {1}{0}", Environment.NewLine, valores[i]);
            }
            return debolver;
        }

        private void Contrato_Click(object sender, EventArgs e)
        {
            String CodVenta = Convert.ToString(dgvListaVentas.CurrentRow.Cells[2].Value);

            String RowVehiculos = Convert.ToString(dgvListaVentas.CurrentRow.Cells[6].Value);

            String[] ArrayVehiculos = RowVehiculos.Split(';');
            List<Vehiculo> lstVehiculo = new List<Vehiculo>();
            Int32 idContrato = Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[17].Value);
            frmTipoImpresion frmTImpre = new frmTipoImpresion();
            frmRptContrato frmVPContrato = new frmRptContrato();
            if (ArrayVehiculos.Length-1==1)
            {
                lstVehiculo = fnDebolverDatVehiculo(RowVehiculos, ArrayVehiculos);
                var resutl=fnBuscarContrato(CodVenta, lstVehiculo[0].vPlaca, idContrato);
                frmVPContrato.Inicio(resutl.Item1,resutl.Item2, resutl.Item3);
            }
            else
            {
                frmTImpre.inicio(0, CodVenta, fnDebolverDatVehiculo(RowVehiculos, ArrayVehiculos),"C", idContrato);

            }
            //if ()
        }

        public xmlInstalacion fnBuscarActaInstalacion(String codVenta,String vPlaca,Int32 TipoVenta)
        {
            xmlInstalacion xmlInstalacion = new xmlInstalacion();
            String Observacion = "";
            String cUsuario = "";
            BLVentaGeneral blventa = new BLVentaGeneral();
            DataTable dtRespuesta = new DataTable();
            xmlInstalacion = blventa.blBuscarActaInstalacion(codVenta, vPlaca, TipoVenta);


            //return Tuple.Create(xmlInstalacion.ListaCliente, xmlInstalacion.ListaVehiculo, xmlInstalacion.ListaEquipo, xmlInstalacion.ListaPlan, xmlInstalacion.ListaAccesorio, xmlInstalacion.ListaServicio, xmlInstalacion.clsInstalacion);
            return xmlInstalacion;
        }
        public Tuple<List<Cliente>,List<Vehiculo>,List<Contrato>> fnBuscarContrato(String codVenta,String PlacaV,Int32 idContrato)
        {
            List<Cliente> lstCliente = new List<Cliente>();
            List<Vehiculo> lstVehiculo = new List<Vehiculo>();
            List<Contrato> lstContrato = new List<Contrato>();
            BLVentaGeneral blventa = new BLVentaGeneral();
            DataTable dtRespuesta = new DataTable();
            
            dtRespuesta = blventa.blBuscarContrato(codVenta, PlacaV, idContrato);
            foreach (DataRow dr in dtRespuesta.Rows)
            {
                lstCliente.Add(new Cliente
                {
                    cContactoNom2= Convert.ToString(dr["tipoDocumento"]),
                    cNombre = Convert.ToString(dr["cNombre"]),
                    cApePat = Convert.ToString(dr["cApePat"]),
                    cApeMat = Convert.ToString(dr["cApeMat"]),
                    cDocumento = Convert.ToString(dr["cDocumento"]),
                    cDireccion = Convert.ToString(dr["cDireccion"]),
                    dFecNac = Convert.ToDateTime(dr["dFechaRegistro"])
                }) ;

                lstVehiculo.Add(new Vehiculo
                {
                    vPlaca = Convert.ToString(dr["vPlaca"]),
                    vSerie = Convert.ToString(dr["vSerie"]),
                    vColor = Convert.ToString(dr["vColor"]),
                    vMarcaV = Convert.ToString(dr["nombreMarcaV"]),
                    vModeloV = Convert.ToString(dr["nombreModeloV"])
                }) ;
                lstContrato.Add(new Contrato
                {
                    codContrato = Convert.ToString(dr["codContrato"])
                }) ;
            }
            return Tuple.Create(lstCliente, lstVehiculo, lstContrato);
        }
        private List<Vehiculo> fnDebolverDatVehiculo(String RowVehiculos,String[] ArrayVehiculos)
        {
            Int32 contador = ArrayVehiculos.Length - 1;
            String placa = "";
            String DescripVehiculo = "";
            String[] ArrayDatos = RowVehiculos.Split('(');
            Int32 contadorDtos = ArrayDatos[0].Length;

            List<Vehiculo> lstVehi = new List<Vehiculo>();

            for (Int32 i = 0; i < contador; i++)
            {
                DescripVehiculo = string.Format("{1}{0}", Environment.NewLine, ArrayVehiculos[i]);
                placa = (i == 0)? ArrayVehiculos[i].Substring(6, contadorDtos - 6): ArrayVehiculos[i].Substring(7, contadorDtos - 6);
               
                 
                lstVehi.Add(new Vehiculo
                {
                    vPlaca = placa,
                    vModeloV = DescripVehiculo

                });
            }
            return lstVehi;
        }

        private void tlsDocumentoVenta_Click(object sender, EventArgs e)
        {

            cCodigoVenta = Convert.ToString(dgvListaVentas.CurrentRow.Cells[2].Value);
            Int32 idTipoTarifa = Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[16].Value);
            Int32 idContrato = Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[17].Value);
            fnBuscarDocumentoVenta(cCodigoVenta,1, idTipoTarifa, idContrato);
        }

        private void anularVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bTipoTab = false;
            BLVentaGeneral objVenta = new BLVentaGeneral();
            Boolean estadoOpe = false;
            String codVent= Convert.ToString(dgvListaVentas.CurrentRow.Cells[2].Value);
            System.Windows.Forms.DialogResult resultDialog = MessageBox.Show("¿En realidad desea anular esta venta?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2,MessageBoxOptions.RightAlign);
           
            if (resultDialog== DialogResult.Yes)
            {
                estadoOpe = objVenta.blBAnularVenta(codVent);
                if (estadoOpe == true)
                {
                    MessageBox.Show("Venta anulada correctamente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fnBuscarListaVentas(dgvListaVentas, 0, 0, -1);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al anular la venta", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            
        }

        private void ActaInstalacion_Click(object sender, EventArgs e)
        {
            String CodVenta = Convert.ToString(dgvListaVentas.CurrentRow.Cells[2].Value);
            Int32 idTipoVenta = Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[16].Value);
            Int32 idContrato = Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[17].Value);

            String RowVehiculos = Convert.ToString(dgvListaVentas.CurrentRow.Cells[6].Value);
            String[] ArrayVehiculos = RowVehiculos.Split(';');
            List<Vehiculo> lstVehiculo = new List<Vehiculo>();
            frmTipoImpresion frmTImpre = new frmTipoImpresion();
            xmlInstalacion xmlInst = new xmlInstalacion();
            frmRptActa frmVPActa = new frmRptActa();
            if (ArrayVehiculos.Length - 1 == 1)
            {
                lstVehiculo = fnDebolverDatVehiculo(RowVehiculos, ArrayVehiculos);
                xmlInst=fnBuscarActaInstalacion(CodVenta,lstVehiculo[0].vPlaca, idTipoVenta);
                if (xmlInst.clsInstalacion!=null)
                {
                    frmVPActa.Inicio(xmlInst.ListaCliente, xmlInst.ListaVehiculo, xmlInst.ListaEquipo, xmlInst.ListaPlan, xmlInst.ListaAccesorio, xmlInst.ListaServicio,xmlInst.observaciones,xmlInst.clsInstalacion,1);
                }
                else
                {
                    MessageBox.Show("Por favor indique que se registre la instalacion para poder imprimir el acta.","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else
            {
                frmTImpre.inicio(Convert.ToInt32(cboTipoVetaBusq.SelectedValue), CodVenta, fnDebolverDatVehiculo(RowVehiculos, ArrayVehiculos),"A", idContrato);

            }
        }

        private void cboTipoVetaBusq_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cargoFrom==true)
            //{
            //    fnBuscarListaVentas(dgvListaVentas, 1, 0, -1);
            //}
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedIndex==1)
            //{
            //    fnBuscarListaVentas(dgvListaVentas, 1, 0, -1);
            //}
        }

        private void cmsImpresiones_Opening(object sender, CancelEventArgs e)
        {

        }
        
        private void siticoneCheckBox1_CheckedChanged(object sender, EventArgs e)
        {           

            if (siticoneCheckBox1.Checked==true)
            {
                idTipoPlanActual = Convert.ToInt32(cboTipoPlanP.SelectedValue);
                idPlanActual = Convert.ToInt32(cboPlanP.SelectedValue);
                idCicloActual = Convert.ToInt32(cboCicloP.SelectedValue);
                fnHabilitarCboPlanes(true);
            }
            else
            {
                cboTipoPlanP.SelectedValue = clsPlanActual.idTipoPlan;
                cboPlanP.SelectedValue = clsPlanActual.idPlan;
                cboCicloP.SelectedValue = clsPlanActual.CicloPlan;
                dgvPagoPlan.Visible = true;
                fnHabilitarCboPlanes(false);
            }
        }

        private void irAInstalacion_Click(object sender, EventArgs e)
        {
            dtFechaPago.Value = Variables.gdFechaSis;
            FunGeneral.fnValidarFechaPago(dtFechaPago, pbFechaPago, 0);

            bTipoTab = true;
            bActivarChecks = true;
            DAVentaGeneral objVentaG = new DAVentaGeneral();
            String codigoVenta = Convert.ToString(dgvListaVentas.CurrentRow.Cells[2].Value);
            Int32 idCliente = Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[0].Value);
            String strEstadoContrato = Convert.ToString(dgvListaVentas.CurrentRow.Cells[11].Value);
            Int32 idContrato = Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[17].Value);
            Int32 idContratoValido = objVentaG.daValidarContratoReciente(idContrato);
            if (idContratoValido == idContrato)
            {
                lnTipoCon = -2;
                siticoneCheckBox1.Checked = false;
                finalizacionContrato.Checked = false;
                cboTipoVenta.SelectedValue = 2;
                fnDevolverVehiculoRenovacion(codigoVenta, idCliente,"", idContrato);
                tabControl1.SelectedIndex = 0;
                cboTipoPlanP.SelectedValue = clsPlanActual.idTipoPlan;
                cboPlanP.SelectedValue = clsPlanActual.idPlan;
                cboCicloP.SelectedValue = clsPlanActual.CicloPlan;

                fnHabilitarBotonesC(false, false, false, false);
                fnHabilitarCboPlanes(false);
                fnMostrarParaActualizar(true);
            }
            else
            {
                MessageBox.Show("Por favor eliga un contrato vigente ó el mas reciente","Aviso!!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
            
        }

        private void fnMostrarParaActualizar(Boolean estado)
        {
            gbVehiculo.Enabled = estado;
            dgvPrimerPago.Enabled = estado;
            dgvPagoPlan.Enabled = estado;
        }
        private void irActualizar_Click(object sender, EventArgs e)
        {
            Int32 anioActual = Variables.gdFechaSis.Year;
            dtFechaPago.MinDate = Variables.gdFechaSis.AddYears(-(anioActual-2018));
            dtFechaPago.MaxDate = Variables.gdFechaSis.AddMinutes(5);

            bTipoTab = false;
            bActivarChecks = true;
            fnLimpiarControles();
            //fnLlenarTipoPlan(0, cboTipoPlanP, 0);
            //Inicializar Lista
            //cboPlanP.SelectedValue = 0;
            
            String codigoVenta = Convert.ToString(dgvListaVentas.CurrentRow.Cells[2].Value);
            Int32 idCliente = Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[0].Value);
            Int32 idContrato = Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[17].Value);

            fnDevolverVehiculoRenovacion(codigoVenta, idCliente, "", idContrato);
            //fnMostrarParaActualizar(false);
           
            siticoneCheckBox1.Checked = false;
            finalizacionContrato.Checked = false;
            cboTipoVenta.SelectedValue = ClsVentaGeneral.ClsTarifa.IdTipoTarifa;
            

            cboTipoPlanP.SelectedValue = clsPlanActual.idTipoPlan;
            cboPlanP.SelectedValue = clsPlanActual.idPlan;
            cboCicloP.SelectedValue = clsPlanActual.CicloPlan;
            if (ClsVentaGeneral.clsDetalleVentaCabecera.lstDetalleVenta[0].IdTipoDescuento!=0)
            {
                estDescuento = true;
                cboTipoDescuentoPrecios.SelectedValue = ClsVentaGeneral.clsDetalleVentaCabecera.lstDetalleVenta[0].IdTipoDescuento;
            }

            fnDevolverVehiculoRenovacion(codigoVenta, idCliente, idContrato.ToString(), idContrato);

            
            lstPP = ClsVentaGeneral.clsDetalleVentaCabecera.lstDetalleVenta;

            
            for (Int32 i = 0; i < lstPP.Count; i++)
            {
                if (ClsVentaGeneral.clsDetalleVentaCabecera.lstDetalleVenta.Count>1)
                {
                    String CadenaRecortada = lstDV[0].Descripcion.Substring(0, 4);
                    String[] ArrayVehiculos = lstDV[0].Descripcion.Split('-');
                    Int32 contadorDtos = ArrayVehiculos[0].Length;
                    String CadenaRecortadaTipoPlan = lstDV[0].Descripcion.Substring(0, contadorDtos-1);
                    if ((lstPP[i].Descripcion == lstDV[0].Descripcion))
                    {
                        lstDV[0].IdDetalleVenta = lstPP[i].IdDetalleVenta;
                        lstDV[0].Descuento = lstPP[i].Descuento;
                        lstDV[0].TotalTipoDescuento = lstPP[i].TotalTipoDescuento;
                        lstDV[0].Importe = lstPP[i].Importe;
                        lstDV[0].PrecioUni = lstPP[i].PrecioUni;
                        lstDV[0].idTipoTarifa = lstPP[i].idTipoTarifa;
                        lstPP.Remove(lstPP[i]);
                    }else if ((lstPP[i].Descripcion == CadenaRecortada) || (lstPP[i].Descripcion == CadenaRecortadaTipoPlan))
                    {
                        lstDV[0].IdDetalleVenta = lstPP[i].IdDetalleVenta;
                        lstDV[0].Descuento = lstPP[i].Descuento;
                        lstDV[0].TotalTipoDescuento = lstPP[i].TotalTipoDescuento;
                        lstDV[0].Importe = lstPP[i].Importe;
                        lstDV[0].PrecioUni = lstPP[i].PrecioUni;
                        lstDV[0].idTipoTarifa = lstPP[i].idTipoTarifa;
                        lstPP.Remove(lstPP[i]);
                    }
                }
                else if (ClsVentaGeneral.clsDetalleVentaCabecera.lstDetalleVenta.Count == 1 && Convert.ToInt32(cboTipoPlanP.SelectedValue)==1)
                {
                    if ((lstPP[i].Descripcion == lstDV[0].Descripcion))
                    {
                        lstDV[0].IdDetalleVenta = lstPP[i].IdDetalleVenta;
                        lstDV[0].Descuento = lstPP[i].Descuento;
                        lstDV[0].TotalTipoDescuento = lstPP[i].TotalTipoDescuento;
                        lstDV[0].Importe = lstPP[i].Importe;
                        lstDV[0].PrecioUni = lstPP[i].PrecioUni;
                        lstDV[0].idTipoTarifa = lstPP[i].idTipoTarifa;
                        lstPP.Remove(lstPP[i]);
                    }
                }

            }
           
                fnCalcularTotalPago();
            
            fnCargaTablaDetalle(lstPP.Count()==0? lstDV: lstPP, dgvPrimerPago);
            fncalcularTotales(lstPP, lstDV);

            tabControl1.SelectedIndex = 0;
            fnHabilitarBotonesC(false, false, false, false);
            fnHabilitarCboPlanes(false);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            fnBuscarListaVentas(dgvListaVentas, 0, 0, -4);
        }

        private void btnBuscarMonto_CheckedChanged(object sender, EventArgs e)
        {
            if (btnBuscarMonto.Checked == true)
            {
                fnBuscarListaVentas(dgvListaVentas, 0, 0, -4);
            }
        }

        private void dgvListaVentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgview = sender as DataGridView;

            String nombreCabecera = dgview.Columns[e.ColumnIndex].Name;


            if (nombreCabecera == "txtEstado")
            {

                if (e.Value.ToString().Contains("✔"))
                {
                    e.CellStyle.ForeColor = Variables.ColorSuccess;
                }
                else if (e.Value.ToString().Contains("🕐"))
                {
                    e.CellStyle.ForeColor = Color.YellowGreen;
                }
                else if (e.Value.ToString().Contains("👁"))
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }
                else if (e.Value.ToString().Contains("❗"))
                {
                    e.CellStyle.ForeColor = Color.OrangeRed;

                }else if (e.Value.ToString().Contains("🚫"))
                {
                    e.CellStyle.ForeColor = Color.Purple;
                }
                else if (e.Value.ToString().Contains("❌"))
                {
                    e.CellStyle.ForeColor = Color.Red;

                }
            }
        }

        private void chkRenovaciones_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbCheck_Click(object sender, EventArgs e)
        {
            
        }

        private void cbRelog_Click(object sender, EventArgs e)
        {
           
        }

        private void cbOjo_Click(object sender, EventArgs e)
        {
            
        }

        private void cbAdmiracion_Click(object sender, EventArgs e)
        {
            
        }

        private void cbCirculo_Click(object sender, EventArgs e)
        {
            
        }

        private void cbX_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExportarBusqueda_Click(object sender, EventArgs e)
        {
            fnBuscarListaVentas(dgvListaVentas, 0, 0, -5);
            frmExportConsultasCronograma frmExport = new frmExportConsultasCronograma();
            frmExport.Inicio(lstClientesBusq,"Lista de vehiculos para renovación. ", 1);
        }

        private void dtFechaPago_ValueChanged(object sender, EventArgs e)
        {
            //FunGeneral.fnValidarFechaPago(dtFechaPago, pbFechaPago, 1);
        }
    }
}
