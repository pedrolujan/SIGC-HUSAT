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
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Mantenedores;
using wfaIntegradoCom.Procesos;
using CapaUtil;
using System.Reflection;
using Microsoft.Win32;
using selferviceSIGC.Configuration;
using selferviceSIGC.Core;
using wfaIntegradoCom.Funciones.Helper;
using Newtonsoft.Json;
using wfaIntegradoCom.Funciones.Models;
using System.Xml;
using Microsoft.AspNet.SignalR.Client;
using System.Windows.Input;
using System.Windows.Controls;
using Newtonsoft.Json.Linq;
using wfaIntegradoCom.Funciones.Models.Order;

namespace wfaIntegradoCom
{
    public partial class MDIParent1 : Form, IDisposable
    {

        DataSet dtMenu = new DataSet();
        clsUtil objUtil = new clsUtil();
        ImageList imgList = new ImageList();
        String lcCodMenu = "";
        int lintIdCodigoGeneral = 0;
        List<int> llstRol = new List<int> {
            1
        };
        int lintIdTipoProceso = 1;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void fnLoadControlWPF()
        {
            lintIdCodigoGeneral = 1;
            List < WPF.CTRL.Colocaciones.DCPedido > lstDCPedidos = fnGetAllorEspecificOrder();
            ucOpcion1 = new WPF.CTRL.Colocaciones.ucOpcion(lintIdCodigoGeneral, lintIdTipoProceso, 1, llstRol, 1, 1, 1, false, 0, true, lstDCPedidos);
            ucOpcion1.acdPrincipal.MouseDoubleClick += acdPrincipal_MouseDoubleClick;
            //AddHandler ucListaOpcion.acdPrincipal.MouseDoubleClick, AddressOf acdPrincipal_MouseDoubleClick
            //AddHandler ucListaOpcion.acdPrincipal.KeyDown, AddressOf acdPrincipal_KeyDown
            elhAlert.Child = ucOpcion1;
            ucOpcion1.acdPrincipal.Focus();

        }

        private void acdPrincipal_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            fnAbrirFormularioDinamico(sender);
        }


        private void fnAbrirFormularioDinamico(object e)
        {
            string strNombreForm = string.Empty;
            TreeViewItem tviDinamico = null;

            if (ucOpcion1.acdPrincipal.SelectedItem != null)
            {
                AccordionItem accordionItem = ucOpcion1.acdPrincipal.SelectedItem as AccordionItem;
                System.Windows.Controls.TreeView tvwDinamico = (accordionItem).Content as System.Windows.Controls.TreeView;
                Grid grdItem = (accordionItem).Header as Grid;
                strNombreForm = grdItem.ColumnDefinitions[1].Name.Trim();
                if (tvwDinamico != null)
                {
                    if (tvwDinamico.SelectedItem != null)
                    {
                        tviDinamico = tvwDinamico.SelectedItem as TreeViewItem;
                        string codigo = tviDinamico.ToolTip.ToString();
                        frmProcesarPedido frmProceso = new frmProcesarPedido(codigo);
                        frmProceso.ShowDialog();
                    }
                }
            }
        }

        private List<WPF.CTRL.Colocaciones.DCPedido> fnGetAllorEspecificOrder()
        {
            GenericListResponse<Pedido> generic = FunGeneral.fnGeAllorEspecificOrder("");
            if (generic.Status == 200)
                return Format.FormatPedidotoDCPedido(generic.data);
            else
                return null;
        }

        private void fnOcultarObjetos()
        {
            DataView dvMenuPrincipal = new DataView(dtMenu.Tables[0]);
            foreach (DataRowView drFila in dvMenuPrincipal)
            {
                foreach (ToolStripButton ts in tsMenuPrincipal.Items)
                {
                    
                        ts.Enabled = false;
                   
                }
                foreach (ToolStripButton ts in tsAccesoRapido.Items)
                {
                    ts.Visible = false;
                }
            }
           
        }
        public void fnCargarMenuPrin()
        {
            DataTable dtMenuPrin = new DataTable();
            DataView dvMenuPrincipal = new DataView(dtMenu.Tables[0]);
            String lcItemMenu = "";
            int iNumMenu = 0;

            dvMenuPrincipal.RowFilter = "cMenuPadre = '0' ";
            iNumMenu = dvMenuPrincipal.Table.Rows.Count;

            if (iNumMenu > 0)
            {
                foreach (DataRowView drFila in dvMenuPrincipal)
                {
                    lcItemMenu = drFila["cMenuNombre"].ToString().Trim();
                    foreach (ToolStripButton ts in tsMenuPrincipal.Items)
                    {
                        if (ts.Text.Trim() == lcItemMenu)
                        {
                            ts.Enabled = true;
                        }
                        
                        

                    }
                }
             
            }         

        }
        public void fnRecibirDtMenu(DataSet dt)
        {
            dtMenu = dt;
        }
        public void fnCargarMenuAccesoRapido()
        {
            DataTable dtMenuPrin = new DataTable();
            DataView dvMenuPrincipal = new DataView(dtMenu.Tables[0]);
            String lcItemMenu = "";
            int iNumMenu = 0;

            dvMenuPrincipal.RowFilter = "cMenuPadre = '8888500000' ";
            iNumMenu = dvMenuPrincipal.Table.Rows.Count;

            if (iNumMenu > 0)
            {
                foreach (DataRowView drFila in dvMenuPrincipal)
                {
                    lcItemMenu = drFila["cMenuNombre"].ToString().Trim();
                    foreach (ToolStripButton ts in tsAccesoRapido.Items)
                    {
                        if (ts.Name.Trim() == lcItemMenu)
                        {
                            ts.ToolTipText = drFila["cNomFormulario"].ToString();
                            ts.Tag = Convert.ToInt32(drFila["intIdTipoLlamada"]);
                            ts.Visible = true;
                        }
                    }
                }

            }
        }
        
        public Boolean Loading() {
        frmUsuario login = new frmUsuario();
        Boolean bLoading=false;
        BLMenu objMenu = new BLMenu();

        try
        {
            if(login.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                bLoading = true;
                frmLoad frm = new frmLoad();
                dtMenu = objMenu.BLCargarMenu(Variables.gnCodUser, 1);
                fnCargarVariableGlobal();
                fnCargarVariableImpresion();

                frm.Inicio();
                fnCargarMenuPrin();
                fnCargarMenuAccesoRapido();
                lcCodMenu = "8888100000";
                imgList = ListaImagenes;
                fnCargarMenuGeneral(lcCodMenu);
                }          
            else
            {
                bLoading = false;
                
                this.Close();


            }

        }
        catch(Exception ex){
            bLoading = false;
            MessageBox.Show(ex.Message, "Avisar a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        return bLoading;
        }

        public void fnCargarVariableGlobal()
        {
            DataTable dt = new DataTable();
            BLMenu objMenu = new BLMenu();
            string lcCodTab = "";
            dt = objMenu.daCargarVariableSistema("PAVA");

            foreach (DataRow dr in dt.Rows)
            {
                lcCodTab=dr["cCodTab"].ToString().Trim();
                switch (lcCodTab)
                {
                    case "PAVA0001":
                        toolStripStatusLabel3.Text = toolStripStatusLabel3.Text + String.Format(Variables.gdFechaSis.ToShortDateString(), "dd/MM/yyyy");
                        break;
                    case "PAVA0002":
                        toolStripStatusLabel2.Text = toolStripStatusLabel2.Text + dr["cValor"].ToString();
                        break;
                    case "PAVA0003":
                        this.Text = "SISTEMA INTEGRADO DE GESTIÓN COMERCIAL - HUSAT";
                        Variables.gsSucursal = dr["cValor"].ToString();
                        Variables.gsEmpresa = dr["cNomTab"].ToString(); 
                        
                        //+ dr["cNomTab"].ToString() + " (" + Variables.gsSucursal + ") ";
                        break;
                    case "PAVA0004":
                        Variables.gsRuc = dr["cNomTab"].ToString();
                        break;
                    case "PAVA0005":
                        Variables.gsEmpresaDir =dr["cValor"].ToString();
                        Variables.gsSucursalUbigeo= dr["cNomTab"].ToString();
                        break;

                }

            }

            toolStripStatusLabel1.Text = "Usuario: " + Variables.gsCodUser;
            tsCerraSession.Text = "Usuario: " +FunGeneral.FormatearCadenaTitleCase(Variables.gsCodUser);

            toolStripStatusLabel4.Text = toolStripStatusLabel4.Text + Variables.gsVersion;

        }

        public void fnCargarVariableImpresion()
        {
            DataTable dt = new DataTable();
            BLMenu objMenu = new BLMenu();
            string lcCodTab = "";
            dt = objMenu.daCargarVariableSistema("PAI");

            foreach (DataRow dr in dt.Rows)
            {
                lcCodTab = dr["cCodTab"].ToString().Trim();
                switch (lcCodTab)
                {
                    case "PAI0001":
                        Variables.gsImpresora = dr.IsNull("cValor") ? Variables.gsImpresora : dr["cValor"].ToString();
                        break;
                    case "PAI0002":
                        Variables.template = dr.IsNull("cValor") ? Variables.template : dr["cValor"].ToString().Split(',').ToList();
                        break;
                    case "PAI0003":
                        Variables.bitActivePrintDirect = dr.IsNull("cValor") ? false : Convert.ToBoolean(dr["cValor"]);
                        
                        break;
                }

            }

            toolStripStatusLabel1.Text = "Usuario: " + Variables.gsCodUser;
            toolStripStatusLabel4.Text = toolStripStatusLabel4.Text + Variables.gsVersion;

        }

        private void fnCargarMenuGeneral(String pcCodMenu)
        { 
            DataView dvMenu = new DataView(dtMenu.Tables[0]);
            dvMenu.RowFilter = "cMenuPadre = " + pcCodMenu.ToString().Trim();
            tvOpes.Nodes.Clear();
            tvOpes.ImageList = imgList;
            foreach(DataRowView drv in dvMenu)
            {
                TreeNode nuevoNodo= new TreeNode();
                nuevoNodo.Name = drv["cMenuCod"].ToString().Trim();
                nuevoNodo.Text = drv["cMenuNombre"].ToString().Trim();
                nuevoNodo.Tag = Convert.ToInt32(drv["intIdTipoLlamada"]);
                nuevoNodo.ImageIndex = 1;
                tvOpes.Nodes.Add(nuevoNodo);
                nuevoNodo.Expand();
            }

        }

        private void fnllenaTreeView(DataTable dtMenuHijo, String pcCodMenu)
        {

            try
            {
                DataView viewItem = new DataView(dtMenuHijo);
                viewItem.RowFilter = "cMenuPadre = " + pcCodMenu.ToString().Trim();
                treeView1.Nodes.Clear();
                foreach (DataRowView childView in viewItem)
                {
                    TreeNode parentnode1 = new TreeNode();
                    parentnode1 = new TreeNode(childView["cMenuNombre"].ToString());
                    parentnode1.Name = childView["cMenuCod"].ToString();
                    parentnode1.ToolTipText = childView["cNomFormulario"].ToString();
                    parentnode1.Tag = Convert.ToInt32(childView["intIdTipoLlamada"]);
                    treeView1.Nodes.Add(parentnode1);
                    fnObtenerNodoHijo(parentnode1, dtMenuHijo);
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("MDIParent1", "fnllenaTreeView", ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private void fnObtenerNodoHijo(TreeNode parentnode1, DataTable dtReporte)
        {
            try
            {
                DataView viewItem = new DataView(dtReporte);
                viewItem.RowFilter = "cMenuPadre = " + parentnode1.Name;

                foreach (DataRowView childView in viewItem)
                {
                    TreeNode childnode1 = new TreeNode();
                    childnode1 = new TreeNode(childView["cMenuNombre"].ToString());
                    childnode1.Name = childView["cMenuCod"].ToString();
                    childnode1.ToolTipText = childView["cNomFormulario"].ToString();
                    childnode1.Tag = Convert.ToInt32(childView["intIdTipoLlamada"]);
                    parentnode1.Nodes.Add(childnode1);
                    fnObtenerNodoHijo(childnode1, dtReporte);
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("Web.Reportes", "fnObtenerNodoHijo", ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private void InitializeTimer()
        {
            Timer timer1 = new Timer
            {
                Interval = 1000
            };
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(OnTimerEvent);
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            //inicio de funciones de cargado de menus y formulario load
           
            try
            {
                Loading();
                SystemEvents.PowerModeChanged += OnPowerModeChange;
                InitializeTimer();
                SafelySubscribeToControllerEvents();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            
        }

        public void OnTimerEvent(object source, EventArgs e)
        {
            string strFechaIso = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 5);
            string strFechaHourIso = strFechaIso +" "+ (DateTime.Now.TimeOfDay.ToString()).Substring(0,12);
            Variables.gdFechaSis = Convert.ToDateTime(strFechaHourIso);
            toolStripStatusLabel3.Text = "Fecha del Sistema: " + Variables.gdFechaSis.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void OnPowerModeChange(object s, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Resume)
            {
                System.Threading.Thread.Sleep(1000);
                FunGeneral.fnVerificarFechaSistema(this.OwnedForms);
            }
        }
        private void tsbCaptaciones_Click(object sender, EventArgs e)
        {
            tslMenuIzquierdo.Text = "Ventas";
            treeView1.Nodes.Clear();
            lcCodMenu = "8888100000";
            fnCargarMenuGeneral(lcCodMenu);
            
        }

        private void tvOpes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String lcCodMenu="";
            lcCodMenu = tvOpes.SelectedNode.Name.Trim();
            fnllenaTreeView(dtMenu.Tables[0], lcCodMenu);
        }

        private void tsbRiesgos_Click(object sender, EventArgs e)
        {
            tslMenuIzquierdo.Text = "Compras";
            treeView1.Nodes.Clear();
            lcCodMenu = "8888200000";
            fnCargarMenuGeneral(lcCodMenu);
        }

        private void tsbContabilidad_Click(object sender, EventArgs e)
        {
            tslMenuIzquierdo.Text = "Almacén";
            treeView1.Nodes.Clear();
            lcCodMenu = "8888300000";
            fnCargarMenuGeneral(lcCodMenu);   
        }

        private Form fnMenuDinamico(String pcNomForm, int pnTipoLlamada)
        {
            Object obj = null;
            object[] pa=new object[1];
            try
            {

                Assembly sm = Assembly.GetExecutingAssembly();

                foreach (Type Tipo in sm.GetTypes())
                {
                    if (Tipo.Name.ToUpperInvariant() == pcNomForm.ToUpperInvariant())
                    {
                        pcNomForm = Tipo.Namespace + '.' + Tipo.Name;
                        break;
                    }
                }
                if (pnTipoLlamada == 0)
                {
                     obj = sm.CreateInstance(pcNomForm);
                }
                else
                {
                    if (pcNomForm == "wfaIntegradoCom.Mantenedores.frmRegistrarVenta")
                    {
                        obj = sm.CreateInstance(pcNomForm);
                    }
                    else
                    {
                        pa[0] = pnTipoLlamada;
                        obj = sm.CreateInstance(pcNomForm, false, BindingFlags.CreateInstance, null, pa, null, null);
                    }
                    
                }

                return (Form)obj;
            }
            catch(Exception ex)
            { return null;
            }
        }

        private void fnActivarFormulario(String pcNombreFormulario,int pintidTipoLlamada)
        {
            Form frmFormulario;

            if (String.IsNullOrEmpty(pcNombreFormulario) == false)
            {
                frmFormulario = fnMenuDinamico(pcNombreFormulario, pintidTipoLlamada);
                if (frmFormulario != null)
                {
                    if (frmFormulario.Name== "frmRegistrarVenta" && pintidTipoLlamada==1)
                    {
                        frmRegistrarVenta frmRegVenta = new frmRegistrarVenta();
                        frmRegVenta.Inicio(3);
                    }
                    else
                    {
                        
                        frmFormulario.ShowDialog();
                    }
                }
                else
                    MessageBox.Show("El nombre formulario asignado al menu del usuario no se encuentra en el Proyecto. Verificar en mantenedor de Menus.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);                 
            }

        }
        

        private void treeView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                fnActivarFormulario(treeView1.SelectedNode.ToolTipText.Trim(), Convert.ToInt32(treeView1.SelectedNode.Tag));
            }
            catch(Exception ex)
            {
                objUtil.gsLogAplicativo("MDIParent1", "treeView1_KeyPress", ex.Message);
                MessageBox.Show(ex.Message, "Avisar a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                fnActivarFormulario(treeView1.SelectedNode.ToolTipText.Trim(), Convert.ToInt32(treeView1.SelectedNode.Tag));
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("MDIParent1", "treeView1_DoubleClick", ex.Message);
                MessageBox.Show(ex.Message, "Avisar a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tsAccesoRapido_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name!= "tsCerraSession")
            {
                fnActivarFormulario(e.ClickedItem.ToolTipText.Trim(), Convert.ToInt32(e.ClickedItem.Tag));
            }
            else
            {

            }
            
        }

        #region Private members
        private static readonly object _mutex = new object();
        private static volatile bool _subscribedToControllerEvents = false;

        private static bool SubscribedToControllerEvents
        {
            get
            {
                lock (_mutex)
                {
                    return _subscribedToControllerEvents;
                }
            }
            set
            {
                lock (_mutex)
                {
                    _subscribedToControllerEvents = value;
                }
            }
        }
        #endregion Private members

        #region WebApi Startup
        private ISelfServiceModule _selfServiceModule;
        private SinglentonSelfService _baseSelfService;
        public static HubFirebaseClient hubClient;
        /// <summary>
        /// Starts the initialization process Tpv-Self-Service.    
        /// </summary>
        public bool InitializationSelfService()
        {
            bool result = false;
            hubClient = new HubFirebaseClient();
            try
            {
                objUtil.gsLogAplicativo("InitializationSelfService", "TRAZA StartInitializationSeflService", "Inicio de función");
                InstanceSelfService();
                //InitializeEvents();
                StartWebApi();
                fnLoadControlWPF();
                //StartSignalR();
                setTemplate();
                setSettings();
                /*
                hubClient.connectAsync();
                hubClient.changeStatusFirebase += async (s, e) => await StateChangedFirebase(s, e);
                hubClient.Hub_StateChanged += async (s, e) => await Hub_StateChanged(s, e);
                */
                result = true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("InitializationSelfService Exception: ", "TRAZA StartInitializationSeflService", ex.Message);
            }

            objUtil.gsLogAplicativo("InitializationSelfService", "TRAZA StartInitializationSeflService", "Salida de función");

            return result;
        }

        /// <summary>
        /// Instance Self service
        /// </summary>
        private void InstanceSelfService()
        {
            _selfServiceModule = new SelfServiceModule();
            _baseSelfService = new SinglentonSelfService();
            
        }
        ///
        #endregion Web Api Startup
        
        #region Private Methods
        /// <summary>
        /// Start Web Api and SignalR
        /// </summary>
        private void StartWebApi()
        {
            _selfServiceModule.CreateWebApiServer();
        }
        /// <summary>
        /// Stop Web Api and SignalR
        /// </summary>
        private void StopApi()
        {
            _selfServiceModule.Dispose();
        }

        /// <summary>
        /// Start SignalR
        /// </summary>
        private void StartSignalR()
        {
            _selfServiceModule.CreateSignalR();
        }

        private void setTemplate()
        {
            IList<string> template = Variables.template;
            IList<Funciones.Models.PrintingTemplate> printingTemplates = FunGeneral.GetPrintingTemplates(template);
            Funciones.Models.SetAvailableTemplatesRequest setAvailableTemplatesRequest = new Funciones.Models.SetAvailableTemplatesRequest
            {
                Templates = printingTemplates
            };
            var response = ApiHelper.Post<Funciones.Models.SetAvailableTemplatesRequest>("http://localhost:8085/api/Print/setTemplate", setAvailableTemplatesRequest, "Application/json", null, null);
        }

        private void setSettings()
        {
            IDictionary<string, string> requestSettings = new Dictionary<string, string>();
            string strLogo = FunGeneral.GetLogo("PrintingLogo.png");
            requestSettings.Add("PrintingLogo", strLogo);
            Funciones.Models.SetPrintingSettingsRequest setPrintingSettings = new Funciones.Models.SetPrintingSettingsRequest
            {
                PrintingSettings = requestSettings
            };
            var response = ApiHelper.Post<Funciones.Models.SetPrintingSettingsRequest>("http://localhost:8085/api/Print/SetPrintingSettings", setPrintingSettings, "Application/json", null, null);
        }

        //int contador = 0;
        private async Task StateChangedFirebase(object sender, GenericResponse<dynamic> e)
        {
            await Task.Run(() =>
            {
                try
                {

                    OrderEspecificResponse<dynamic> orderEspecific = null;
                    if (e != null && e.key.Trim() != "")
                    {
                        bool blnIsExistsObject = e.obj.ToString().Length >6 ? true : false;
                        int intResul = 0;
                        if (!blnIsExistsObject && e.evenType == 0)
                        {
                            orderEspecific = hubClient.fnGetOrderId(e.key).Result;
                            intResul = Convert.ToInt32(orderEspecific.Status);
                        }
                        else intResul =200;

                        if (intResul == 200)
                        {

                            OrderWeb order = JsonConvert.DeserializeObject<OrderWeb>((blnIsExistsObject ? e.obj.ToString() : orderEspecific.obj));
                            int intEstado = order.intEstado;

                            if (intEstado==0 || intEstado==1)
                            {
                                WPF.CTRL.Colocaciones.DCPedido pedido = new WPF.CTRL.Colocaciones.DCPedido();
                                pedido.Codigo = e.key;
                                pedido.EventType = e.evenType;
                                ucOpcion1.fnCargarAlertRealTime(1, pedido);
                            }

                            OrderResponse orderResponse = FunGeneral.fnGetOrderxCodigo(e.key);
                            if (orderResponse.Status == 201 && e.evenType == 0 && intEstado == 0)
                            {
                                Funciones.Models.OrderRequest orderRequest = new Funciones.Models.OrderRequest();
                                orderRequest.order.Codigo = e.key;
                                orderRequest.order.intEstado = 1;
                                orderRequest.order.idUser = Variables.gnCodUser;
                                orderRequest.order.dFechaRegistro = Variables.gdFechaSis;
                                orderRequest.order.idUserAct = Variables.gnCodUser;
                                orderRequest.order.dFechaAct = Variables.gdFechaSis;
                                orderRequest.order.xmlObject = (blnIsExistsObject ? e.obj.ToString() : orderEspecific.obj);
                                saveOrder(orderRequest);
                            }
                            else if(orderResponse.Status == 200 && e.evenType == 1)
                            {
                                Funciones.Models.OrderRequest orderRequest = new Funciones.Models.OrderRequest();
                                orderRequest.order.Codigo = e.key;
                                orderRequest.order.intEstado = 2;
                                orderRequest.order.idUser = Variables.gnCodUser;
                                orderRequest.order.dFechaRegistro = Variables.gdFechaSis;
                                orderRequest.order.idUserAct = Variables.gnCodUser;
                                orderRequest.order.dFechaAct = Variables.gdFechaSis;
                                orderRequest.order.xmlObject = "";
                                saveOrder(orderRequest, 1);
                            }
                          
                        }
                    }
                }
                catch (Exception ex) { }
            });
        }

        private async Task Hub_StateChanged(object s, StateChange e)
        {
            await Task.Run(() =>
            {
                try
                {
                    if (e.NewState == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
                    {
                        tsbSignalr.ToolTipText = "Conectado a Red - SignalR";
                        tsbSignalr.Text = "Conectado";
                        tsbSignalr.ForeColor = Color.Blue;
                    }
                    else if (e.NewState == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
                    {
                        tsbSignalr.ToolTipText = "Desconectado a Red";
                        tsbSignalr.Text = "Desconectado";
                        tsbSignalr.ForeColor = Color.Red;
                    }
                }
                catch (Exception) { }
            });
        }

        private void saveOrder(Funciones.Models.OrderRequest objOrder, int lnTipoLlamada = 0)
        {
            OrderResponse orden = new OrderResponse();
            bool blnResult = false;
            orden =FunGeneral.fnSaveOrder(objOrder);
            if(orden.Status == 200)
            {
                if (lnTipoLlamada == 0)
                {
                    System.Threading.Thread.Sleep(2000);
                    blnResult = hubClient.fnUpdateOrderId(objOrder.order.Codigo, 1);
                    if (!blnResult)
                        objUtil.gsLogAplicativo("MDIParent1.cs", "saveOrder", "No se ha actualizado el estado correctamente en el Firebase la orden:" + objOrder.order.Codigo);
                }
            }
        }

        #endregion Private Methods

        #region Auxiliar methods

        private void SafelySubscribeToControllerEvents()
        {
            if (!SubscribedToControllerEvents)
            {
                InitializationSelfService();
                SubscribedToControllerEvents = true;
            }
        }


        #endregion Auxiliar methods

        private void tsbVenta_Click(object sender, EventArgs e)
        {
            tslMenuIzquierdo.Text = "Ventas";
            tslMenuIzquierdo.Image = Properties.Resources.venta_blanco_32;
            treeView1.Nodes.Clear();
            lcCodMenu = "8888800000";
            fnCargarMenuGeneral(lcCodMenu);
        }

        private void tsbSistemas_Click(object sender, EventArgs e)
        {
            tslMenuIzquierdo.Text = "Configuración";
            tslMenuIzquierdo.Image = Properties.Resources.sistema_blanco_32;
            treeView1.Nodes.Clear();
            lcCodMenu = "8888700000";
            fnCargarMenuGeneral(lcCodMenu);
        }

        private void tsbLogistica_Click(object sender, EventArgs e)
        {
            tslMenuIzquierdo.Text = "Logística";
            tslMenuIzquierdo.Image = Properties.Resources.logistica_blanc_32;
            treeView1.Nodes.Clear();
            lcCodMenu = "8888600000";
            fnCargarMenuGeneral(lcCodMenu);
        }

        private void tsbComercial_Click(object sender, EventArgs e)
        {
            tslMenuIzquierdo.Text = "Comercial";
            tslMenuIzquierdo.Image = Properties.Resources.comercial_blanco_32;
            treeView1.Nodes.Clear();
            lcCodMenu = "8888900000";
            fnCargarMenuGeneral(lcCodMenu);
        }

        private void tsbCompra_Click(object sender, EventArgs e)
        {
            tslMenuIzquierdo.Text = "Compras";
            tslMenuIzquierdo.Image = Properties.Resources.compras_blanco_32;
            treeView1.Nodes.Clear();
            lcCodMenu = "8888400000";
            fnCargarMenuGeneral(lcCodMenu);
        }

        private void tsbSistemas_Click_1(object sender, EventArgs e)
        {
            tslMenuIzquierdo.Text = "Sistemas";
            tslMenuIzquierdo.Image = Properties.Resources.compu_ok_blanco_32;
            treeView1.Nodes.Clear();
            lcCodMenu = "8888300000";
            fnCargarMenuGeneral(lcCodMenu);
        }

        private void tsbRrHh_Click(object sender, EventArgs e)
        {
            tslMenuIzquierdo.Text = "RRHH";
            tslMenuIzquierdo.Image = Properties.Resources.rrHh_blanco_32;
            treeView1.Nodes.Clear();
            lcCodMenu = "8888200000";
            fnCargarMenuGeneral(lcCodMenu);
        }

        private void tsbSoporte_Click(object sender, EventArgs e)
        {
            tslMenuIzquierdo.Text = "Soporte";
            tslMenuIzquierdo.Image = Properties.Resources.rrHh_blanco_32;
            treeView1.Nodes.Clear();
            lcCodMenu = "8888400000";
            fnCargarMenuGeneral(lcCodMenu);
        }

        private void tsCerraSession_Click(object sender, EventArgs e)
        {
            fnOcultarPanelCerrarSession();
        }

        private void fnOcultarPanelCerrarSession()
        {
            if (pnlCerrarSession.Visible == true)
            {
                pnlCerrarSession.Visible = false;
            }
            else
            {
                pnlCerrarSession.Visible = true;
            }
        }
        private void tsCerrarSession_Click(object sender, EventArgs e)
        {
            //this.Close();
            pnlCerrarSession.Visible = false;
            fnOcultarObjetos();
            this.Loading();
        }

        private void tsbRecaudacion_Click(object sender, EventArgs e)
        {
            tslMenuIzquierdo.Text = "Recaudación";
            tslMenuIzquierdo.Image = Properties.Resources.recaudacion_Blanco;
            treeView1.Nodes.Clear();
            lcCodMenu = "8881000000";
            fnCargarMenuGeneral(lcCodMenu);
        }
    }
}
