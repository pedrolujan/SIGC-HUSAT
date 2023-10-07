using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

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
using Siticone.Desktop.UI.WinForms;
using FontAwesome.Sharp;
using CapaEntidad;
using CapaDato;
using MouseEventHandler = System.Windows.Forms.MouseEventHandler;
using wfaIntegradoCom.Consultas;
using System.Drawing.Drawing2D;
using Xceed.Wpf.Toolkit;
using IconButton = FontAwesome.Sharp.IconButton;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Windows.Documents;
using System.Reactive.Joins;
using wfaIntegradoCom.Reportes;
using wfaIntegradoCom.Sunat;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using iTextSharp.text;
using Font = System.Drawing.Font;
using ListBox = System.Windows.Controls.ListBox;
using Label = System.Windows.Forms.Label;
using System.IO;
using DocumentFormat.OpenXml.Bibliography;
using System.Web.Services.Description;
using Siticone.Desktop.UI.WinForms.Suite;
using Rectangle = System.Drawing.Rectangle;
using System.Reflection.Emit;
using DocumentFormat.OpenXml.Office2016.Drawing.Charts;

namespace wfaIntegradoCom

{
    public partial class MDIParent1 : Form, IDisposable
    {


        //Field (Campos)
        static DataSet dtMenu = new DataSet();
        clsUtil objUtil = new clsUtil();
        ImageList imgList = new ImageList();
        String lcCodMenu = "";
        int lintIdCodigoGeneral = 0;
        List<int> llstRol = new List<int> {
            1
        };
        int lintIdTipoProceso = 1;
        static Boolean LoadCarga = false;
        static Boolean estadoTema = false;

        private IconButton BtnActual;
        private System.Windows.Forms.Panel LeftBordeBtn;
        BLControlCaja bl;
        //pading botones temporales de submenus 
        Padding PaddingbtnSubMenu = new Padding(10, 0, 0, 0);

        static Int32 tabInicio = 0;
        static List<ReporteBloque> lstCajaChica = new List<ReporteBloque>();
        List<ReporteBloque> lsReporteBloque = new List<ReporteBloque>();
        List<ReporteBloque> lsReporteBloqueDetalleEgresos = new List<ReporteBloque>();
        List<ReporteBloque> lsReporteBloqueEgresos = new List<ReporteBloque>();
        List<ReporteBloque> lsReporteBloqueEgresosMontoEnCaja = new List<ReporteBloque>();
        List<ReporteBloque> lstRepDetalleIngresos = new List<ReporteBloque>();
        List<ReporteBloque> lstRepDetalleIngresosAlContado = new List<ReporteBloque>();
        static List<ReporteBloque> lstRepDetalleIngresosDAshboard = new List<ReporteBloque>();
        List<ReporteBloque> lsReporteBloqueGen = new List<ReporteBloque>();

        List<ReporteBloque> lstMasDetalleReporte = new List<ReporteBloque>();
        String codOperacion = "";
        String codTipoReporte = "";
        static Boolean estAperturaCaja = false;
        totalRanking lstTotRan = new totalRanking();
        BLProspecto objAcc = new BLProspecto();

        String[] datosMessage = new String[] { };

        private Timer timer;
        private int contador;
        private Color colorOriginalFuente;
        private Color colorParpadeoFuente;
        private Color colorOriginalBg;
        private Color colorParpadeoBg;
        private Color colorOriginalIcono;
        private Color colorParpadeoIcono;

        SiticoneHtmlLabel stlabelBG=new SiticoneHtmlLabel();
        SiticonePanel stPn1=new SiticonePanel();
        SiticonePanel stPn2=new SiticonePanel();
        SiticonePanel stPn3=new SiticonePanel();
        IconPictureBox IconoG = new IconPictureBox();

        public void fnLoadCarga(Boolean Load)
        {
            LoadCarga = Load;
            if (this.treeView1.Controls.Count > 0)
                this.treeView1.Controls.RemoveAt(0);


        }
        public void fnPruebaa()
        {
            if (LoadCarga==true)
            {
                //Frm_FormClosed();
            }
        }
        //Constructor
        public MDIParent1()
        {
            InitializeComponent();
            SubmenusOcultos();

            LeftBordeBtn = new System.Windows.Forms.Panel();
            LeftBordeBtn.Size = new Size(15, 55);

            this.DoubleBuffered = true;

        }

        private void fnCargarFormAPanel(object frm)
        {
            if (this.treeView1.Controls.Count > 0)
                this.treeView1.Controls.Clear();
            Form fn = frm as Form;
            fn.TopLevel = false;
            fn.Width = this.treeView1.Width;
            var gbControl = fn.Controls.OfType<SiticoneGroupBox>();

            //foreach (SiticoneGroupBox sgb in gbControl)
            //{

            //    var gb = sgb.Controls.OfType<System.Windows.Forms.GroupBox>();

            //    foreach (System.Windows.Forms.Control c in gb)
            //    {
            //        string val = "";

            //        if (c is System.Windows.Forms.GroupBox)
            //        {
            //            //c.Width = 300;

            //            foreach (System.Windows.Forms.Control item in c.Controls)
            //            {
            //                if (item is SiticoneDateTimePicker)
            //                {
            //                    item.Height = 20;
            //                    item.Width = 140;

            //                }
            //            }
            //        }

            //    }

            //}
            fn.Dock = DockStyle.Fill;
            this.treeView1.Controls.Add(fn);
            this.treeView1.Tag = fn;

            fn.Show();
        }
        private Boolean AbrirFrmLoad(object frmload)
        {
            if (this.treeView1.Controls.Count > 0)
                this.treeView1.Controls.RemoveAt(0);
            Form fn = frmload as Form;
            fn.TopLevel = false;
            fn.Dock = DockStyle.Fill;
            this.treeView1.Controls.Add(fn);
            this.treeView1.Tag = fn;
            fn.Show();


            return true;


        }
        private void fnLoadControlWPF()
        {
            lintIdCodigoGeneral = 1;
            List<WPF.CTRL.Colocaciones.DCPedido> lstDCPedidos = fnGetAllorEspecificOrder();
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

        private void InicializarParpadeo(SiticoneHtmlLabel st, SiticonePanel stp1, IconPictureBox icn)
        {
            // Configurar el temporizador
            timer = new Timer();
            timer.Interval = 800; // Intervalo de 500 milisegundos (0.5 segundos)
            timer.Tick += Timer_Tick;

            // Configurar los colores de fondo
            colorOriginalFuente = st.ForeColor; // Color de fondo original del panel
            colorOriginalBg = stp1.BackColor;
            colorOriginalIcono = icn.ForeColor;

            stlabelBG = st;
            stPn1 = stp1;
            IconoG = icn;

            colorParpadeoFuente = Color.Yellow; // Color de fondo para el parpadeo
            colorParpadeoBg = Color.Yellow;
            colorParpadeoIcono = Color.Yellow;

            contador = 0;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Cambiar el color de fondo del panel
            if (contador % 2 == 0)
            {
                stlabelBG.ForeColor = colorParpadeoFuente;
                stPn1.BackColor = colorParpadeoBg;
                IconoG.ForeColor = colorParpadeoIcono;

            }
            else
            {
                stlabelBG.ForeColor = colorOriginalFuente;
                stPn1.BackColor = colorOriginalBg;
                IconoG.ForeColor = colorOriginalIcono;
            }

            contador++;

            // Detener el parpadeo después de 5 segundos (10 intervalos de 0.5 segundos)
            if (contador >= 10)
            {
                timer.Stop();
                stlabelBG.ForeColor = colorOriginalFuente; // Restaurar el color de fondo original
                stPn1.BackColor = colorOriginalBg; // Restaurar el color de fondo original
                IconoG.ForeColor = colorOriginalIcono; // Restaurar el color de fondo original
            }
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
        private void fnObtenerIconButonDePanel(SiticonePanel pn, Color bg, Color icon, Color fuente)
        {
            var ts = pn.Controls.OfType<IconButton>();
            foreach (IconButton ib in ts)
            {
                ib.BackColor = bg;
                ib.IconColor = icon;
                ib.ForeColor = fuente;
            }
        }
        private void fnColoresHecader(Color bg, Color icon, Color fuente)
        {
            var ControlesAccesoDirecto = LayoutPanelAccesoRapido.Controls.OfType<IconButton>();

            var controlPanel = LayoutPanelAccesoRapido.Controls.OfType<SiticonePanel>();

            foreach (IconButton ib in ControlesAccesoDirecto)
            {
                ib.BackColor = bg;
                ib.IconColor = icon;
                ib.ForeColor = fuente;
            }
            foreach (SiticonePanel sp in controlPanel)
            {
                sp.BackColor = bg;
                sp.ForeColor = fuente;
                fnObtenerIconButonDePanel(sp, bg, icon, fuente);
            }
            tsMiCaja.BackColor = bg;
            tsMiCaja.IconColor = icon;
            tsMiCaja.ForeColor = fuente;

            panelPerfil.BackColor =bg;
            tsCerraSession.ForeColor = fuente;
            tsCerraSession.BackColor = bg;
            tsCerraSession.IconColor = icon;
            tsCerraSession.BackColor = bg;

        }

        private void fnOcultarObjetos()
        {

            var ControlesAccesoDirecto = LayoutPanelAccesoRapido.Controls.OfType<IconButton>();

            var controlPanel = LayoutPanelAccesoRapido.Controls.OfType<SiticonePanel>();

          
            foreach (SiticonePanel stp in controlPanel)
            {
               stp.Visible = false;
                            
            }


            foreach (IconButton btn in ControlesAccesoDirecto)
            {

                btn.Visible = false;

            }
            var Controles = panelMenuPrincipal.Controls.OfType<IconButton>();
            foreach (IconButton btn in Controles)
            {

                btn.Enabled = false;

            }

        }
        public void fnCargarMenuPrinBotones()
        {
            DataTable dtMenuPrin = new DataTable();
            DataView dvMenuPrincipal = new DataView(dtMenu.Tables[0]);
            String lcItemMenu = "";
            int iNumMenu = 0;

            dvMenuPrincipal.RowFilter = "cMenuPadre = '0' ";
            iNumMenu = dvMenuPrincipal.Table.Rows.Count;

            var Controles = panelMenuPrincipal.Controls.OfType<IconButton>();




            if (iNumMenu > 0)
            {
                foreach (DataRowView drFila in dvMenuPrincipal)
                {
                    lcItemMenu = drFila["cMenuNombre"].ToString().Trim();


                    foreach (IconButton btn in Controles)
                    {
                        if (btn.Text == lcItemMenu)
                        {
                            btn.Enabled = true;
                        }

                    }
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
                    //tsMenuPrincipal
                    //foreach (ToolStripButton ts in tsMenuPrincipal.Items)
                    //{
                    //    if (ts.Text.Trim() == lcItemMenu)
                    //    {
                    //        ts.Enabled = true;

                    //    }



                    //}
                }

            }

        }
        public void fnRecibirDtMenu(DataSet dt)
        {
            dtMenu = dt;
        }

        public void fnCargarMenuAccesoRapidoBtn()
        {
            DataTable dtMenuPrin = new DataTable();
            DataView dvMenuPrincipal = new DataView(dtMenu.Tables[0]);
            String lcItemMenu = "";
            int iNumMenu = 0;

            dvMenuPrincipal.RowFilter = "cMenuPadre = '8888500000' ";
            iNumMenu = dvMenuPrincipal.Table.Rows.Count;

            var controlBtn = LayoutPanelAccesoRapido.Controls.OfType<IconButton>();
            var controlPanel = LayoutPanelAccesoRapido.Controls.OfType<SiticonePanel>();

            if (iNumMenu > 0)
            {
                foreach (DataRowView drFila in dvMenuPrincipal)
                {
                    lcItemMenu = drFila["cMenuNombre"].ToString().Trim();

                    foreach (SiticonePanel stp in controlPanel)
                    {
                        if (stp.Tag.ToString()== lcItemMenu)
                        {
                            stp.Visible = true;
                            var controlBtnIN = stp.Controls.OfType<IconButton>();

                            foreach (IconButton ts in controlBtnIN)
                            {
                                if (ts.Tag.ToString() == lcItemMenu)
                                {
                                    ts.Name = drFila["cNomFormulario"].ToString();
                                    //ts.Tag = Convert.ToInt32(drFila["intIdTipoLlamada"]);
                                    ts.Visible = true;
                                }
                            }

                        }
                    }

                    foreach (IconButton ts in controlBtn)
                    {
                        if (ts.Tag.ToString() == lcItemMenu)
                        {
                            ts.Name = drFila["cNomFormulario"].ToString();
                            //ts.Tag = Convert.ToInt32(drFila["intIdTipoLlamada"]);
                            ts.Visible = true;
                        }
                    }

                    //foreach (SiticonePanel ts in controlBtn)
                    //{
                    //    if (ts.Tag.ToString() == lcItemMenu)
                    //    {
                    //        ts.Name = drFila["cNomFormulario"].ToString();
                    //        //ts.Tag = Convert.ToInt32(drFila["intIdTipoLlamada"]);
                    //        ts.Visible = true;
                    //    }
                    //}
                }

            }
        }

        public void login()
        {

            Boolean bLoading = false;
            frmUsuario login = new frmUsuario();

            BLMenu objMenu = new BLMenu();
            if (login.ShowDialog() == DialogResult.OK)
            {
                bLoading = true;
                frmLoad frm = new frmLoad();
                dtMenu = objMenu.BLCargarMenu(Variables.gnCodUser, 1);


                fnCargarVariableGlobal();
                fnCargarVariableImpresion();
                cboxSelecThema.SelectedValue = Variables.clasePersonal.codTema;
                fnCambiartemas(Variables.clasePersonal.codTema);
                if (dtMenu.Tables.Count > 0)
                {
                    if (AbrirFrmLoad(new frmLoad()) && LoadCarga == true)
                    {


                        //Frm_FormClosed();
                    }

                }



                //frm.Inicio();

            }
            else
            {
                bLoading = false;

                this.Close();


            }
            fnValidarusuarioEnSession();
        }
        public void Loading()
        {

            

            try
            {
                login();
                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboFiltraIngresos, "idOperacion", "cNombreOperacion", "OperacionHusat", "cTipoOpe", "4", true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboTipoPago, "TIPA", true);
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Avisar a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                fnValidarusuarioEnSession();
                fnBuscarReporteGeneralVentas(dgvListaPorBloque, 0, -1);
                //pnlParaDashboard.Visible = Variables.gsCargoUsuario == "PETR0008" ? false : true;
                
                //treeView1.Controls.Add(pnlParaDashboard);
                //fnMostrarDashboard();
            }
        }
        void cbos_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void Frm_FormClosed()
        {
            fnCargarMenuPrin();
            fnCargarMenuPrinBotones();

            fnCargarMenuAccesoRapidoBtn();
            lcCodMenu = "8888100000";
            imgList = ListaImagenes;
            //if (pnlParaDashboard.Visible==false)
            //{
                fnActivarDashBoard(FunGeneral.fnVerificarApertura(Variables.gnCodUser)==1?true:false);
            //}
            //treeView1.Nodes.Clear();

        }

        public void fnCargarVariableGlobal()
        {
            toolStripStatusLabel4.Text = "Versión: ";
            DataTable dt = new DataTable();
            BLMenu objMenu = new BLMenu();
            string lcCodTab = "";
            dt = objMenu.daCargarVariableSistema("PAVA");

            foreach (DataRow dr in dt.Rows)
            {
                lcCodTab = dr["cCodTab"].ToString().Trim();
                switch (lcCodTab)
                {
                    case "PAVA0001":
                        toolStripStatusLabel3.Text = toolStripStatusLabel3.Text + String.Format(Variables.gdFechaSis.ToShortDateString(), "dd/MM/yyyy");
                        break;
                    case "PAVA0002":
                        toolStripStatusLabel2.Text = "Servidor: " + dr["cValor"].ToString();
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
                        Variables.gsEmpresaDir = dr["cValor"].ToString();
                        Variables.gsSucursalUbigeo = dr["cNomTab"].ToString();
                        break;

                }

            }

            dt = objMenu.daCargarVariableSistema("PGEM");
            Empresa clsEmpresa = new Empresa();
            foreach (DataRow dr in dt.Rows)
            {
                lcCodTab = dr["cCodTab"].ToString().Trim();
                
                switch (lcCodTab)
                {
                    case "PGEM0001":
                        clsEmpresa.Ruc= dr["cValor"].ToString();
                        break;
                    case "PGEM0002":
                        clsEmpresa.RazonSocial= dr["cValor"].ToString();
                        break;
                    case "PGEM0003":
                        clsEmpresa.Direccion= dr["cValor"].ToString();
                        break;
                    case "PGEM0004":
                        clsEmpresa.NomDepartamento = dr["cNomTab"].ToString();
                        clsEmpresa.CodDepartamento = dr["cValor"].ToString();
                        break;
                    case "PGEM0005":
                        clsEmpresa.NomProvincia = dr["cNomTab"].ToString();
                        clsEmpresa.CodProvincia = dr["cValor"].ToString();
                        break;
                    case "PGEM0006":
                        clsEmpresa.NomDistrito = dr["cNomTab"].ToString();
                        clsEmpresa.CodDistrito = dr["cValor"].ToString();
                        break;

                }

            }

            Variables.claseEmpresa = clsEmpresa;
            //toolStripStatusLabel1.Text = "Usuario: " + FunGeneral.FormatearCadenaTitleCase(Variables.gsCodUser);
            tsCerraSession.Text = " " + FunGeneral.FormatearCadenaTitleCase(Variables.clasePersonal.cPrimerNom);

            //ImgPerfil.Image = Image.FromStream(lstPers[0].strPerfil);
            if (Variables.clasePersonal.strPerfil == null)
            {

            }
            else
            {
                ImgPerfil.Image = System.Drawing.Image.FromStream(Variables.clasePersonal.strPerfil);

            }

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

            //toolStripStatusLabel1.Text = "Usuario: " + Variables.gsCodUser;
            //toolStripStatusLabel4.Text = toolStripStatusLabel4.Text + Variables.gsVersion;

        }

        private void fnCargarMenuGeneral(String pcCodMenu)
        {
            //DataView dvMenu = new DataView(dtMenu.Tables[0]);
            //dvMenu.RowFilter = "cMenuPadre = " + pcCodMenu.ToString().Trim();
            //tvOpes.Nodes.Clear();
            //tvOpes.ImageList = imgList;
            ////subMenuVentas.Controls.Add(dvMenu);
            //foreach (DataRowView drv in dvMenu)
            //{
            //    TreeNode nuevoNodo = new TreeNode();
            //    nuevoNodo.Name = drv["cMenuCod"].ToString().Trim();
            //    nuevoNodo.Text = drv["cMenuNombre"].ToString().Trim();
            //    nuevoNodo.Tag = Convert.ToInt32(drv["intIdTipoLlamada"]);
            //    nuevoNodo.ImageIndex = 1;
            //    tvOpes.Nodes.Add(nuevoNodo);
            //    nuevoNodo.Expand();
            //}
        }
        #region Cargar submenus a los botones 

        private void fnCargarSubMenuVentas(String pcCodMenu)
        {
            DataView dvMenu = new DataView(dtMenu.Tables[0]);
            dvMenu.RowFilter = "cMenuPadre = " + pcCodMenu.ToString().Trim();

            y = 0;
            int posX, posY;
            int alto, ancho;
            ancho = (subMenuVentas.Width / 4);
            alto = (subMenuVentas.Height / 3);
            posX = 0;
            posY = 0;
            title = new System.Windows.Forms.Label();
            this.subMenuVentas.Controls.Clear();

            foreach (DataRowView drv in dvMenu)
            {
                System.Windows.Forms.Button temp = new System.Windows.Forms.Button();

                temp.Height = 35;
                temp.Width = 200;

                temp.Name = drv["cMenuCod"].ToString().Trim();
                temp.Text = drv["cMenuNombre"].ToString().Trim();
                temp.Tag = Convert.ToInt32(drv["intIdTipoLlamada"]);

                temp.Dock = DockStyle.Top;
                temp.ForeColor = Variables.ColorForeColorSubMenus;
                temp.BackColor = Variables.ColorBackColorSubMenus;
                temp.FlatAppearance.BorderSize = 0;
                temp.Cursor = System.Windows.Forms.Cursors.Hand;
                temp.FlatStyle = FlatStyle.Flat;
                temp.TextAlign = ContentAlignment.MiddleLeft;
                temp.Padding = new Padding(10, 0, 0, 0);

                temp.Click += subMenuVentas_Click;
                temp.Location = new Point(10, (y + 5));
                y += temp.Height;

                if (subMenuVentas.Controls.Count > 0)
                {
                    posX = posX + ancho;
                }
                this.subMenuVentas.Controls.Add(temp);


            }
        }
        private int y = 0;
        private int conteo = 0;
        System.Windows.Forms.Label title = new System.Windows.Forms.Label();
        private void fnCargarSubMenuRecaudacion(String pcCodMenu)
        {
            DataView dvMenu = new DataView(dtMenu.Tables[0]);
            dvMenu.RowFilter = "cMenuPadre = " + pcCodMenu.ToString().Trim();

            y = 0;

            int posX, posY;
            int alto, ancho;
            ancho = (subMenuRecaudacion.Width / 4);
            alto = (subMenuRecaudacion.Height / 3);
            posX = 0;
            posY = 0;
            title = new System.Windows.Forms.Label();
            this.subMenuRecaudacion.Controls.Clear();

            foreach (DataRowView drv in dvMenu)
            {
                //TreeNode nuevoNodo = new TreeNode();

                System.Windows.Forms.Button temp = new System.Windows.Forms.Button();

                temp.Height = 35;
                temp.Width = 200;

                temp.Name = drv["cMenuCod"].ToString().Trim();
                temp.Text = drv["cMenuNombre"].ToString().Trim();
                temp.Tag = Convert.ToInt32(drv["intIdTipoLlamada"]);

                temp.Dock = DockStyle.Top;
                temp.ForeColor = Variables.ColorForeColorSubMenus;
                temp.BackColor = Variables.ColorBackColorSubMenus;
                temp.FlatAppearance.BorderSize = 0;
                temp.Cursor = System.Windows.Forms.Cursors.Hand;
                temp.FlatStyle = FlatStyle.Flat;
                temp.TextAlign = ContentAlignment.MiddleLeft;
                temp.Padding = new Padding(10, 0, 0, 0);

                temp.Click += subMenuRecaudacion_Click;
                temp.Location = new Point(10, (y + 5));
                y += temp.Height;

                if (subMenuRecaudacion.Controls.Count > 0)
                {
                    posX = posX + ancho;
                }
                this.subMenuRecaudacion.Controls.Add(temp);


            }
        }


        private void fnCargarSubMenuComercial(String pcCodMenu)
        {
            DataView dvMenu = new DataView(dtMenu.Tables[0]);
            dvMenu.RowFilter = "cMenuPadre = " + pcCodMenu.ToString().Trim();

            y = 0;
            int posX, posY;
            int alto, ancho;
            ancho = (subMenuComercial.Width / 4);
            alto = (subMenuComercial.Height / 3);
            posX = 0;
            posY = 0;
            title = new System.Windows.Forms.Label();
            this.subMenuComercial.Controls.Clear();

            foreach (DataRowView drv in dvMenu)
            {
                //TreeNode nuevoNodo = new TreeNode();

                System.Windows.Forms.Button temp = new System.Windows.Forms.Button();

                temp.Height = 35;
                temp.Width = 200;

                temp.Name = drv["cMenuCod"].ToString().Trim();
                temp.Text = drv["cMenuNombre"].ToString().Trim();
                temp.Tag = Convert.ToInt32(drv["intIdTipoLlamada"]);

                temp.Dock = DockStyle.Top;
                temp.ForeColor = Variables.ColorForeColorSubMenus;
                temp.BackColor = Variables.ColorBackColorSubMenus;
                temp.FlatAppearance.BorderSize = 0;
                temp.Cursor = System.Windows.Forms.Cursors.Hand;
                temp.FlatStyle = FlatStyle.Flat;
                temp.TextAlign = ContentAlignment.MiddleLeft;
                temp.Padding = new Padding(10, 0, 0, 0);

                temp.Click += subMenuComercial_Click;
                temp.Location = new Point(10, (y + 5));
                y += temp.Height;

                if (subMenuComercial.Controls.Count > 0)
                {
                    posX = posX + ancho;
                }
                this.subMenuComercial.Controls.Add(temp);

            }

        }

        private void fnCargarSubMenuLogistica(String pcCodMenu)
        {
            DataView dvMenu = new DataView(dtMenu.Tables[0]);
            dvMenu.RowFilter = "cMenuPadre = " + pcCodMenu.ToString().Trim();

            y = 0;
            int posX, posY;
            int alto, ancho;
            ancho = (subMenuLogistica.Width / 4);
            alto = (subMenuLogistica.Height / 3);
            posX = 0;
            posY = 0;
            title = new System.Windows.Forms.Label();
            this.subMenuLogistica.Controls.Clear();

            foreach (DataRowView drv in dvMenu)
            {

                System.Windows.Forms.Button temp = new System.Windows.Forms.Button();

                temp.Height = 35;
                temp.Width = 200;

                temp.Name = drv["cMenuCod"].ToString().Trim();
                temp.Text = drv["cMenuNombre"].ToString().Trim();
                temp.Tag = Convert.ToInt32(drv["intIdTipoLlamada"]);

                temp.Dock = DockStyle.Top;
                temp.ForeColor = Variables.ColorForeColorSubMenus;
                temp.BackColor = Variables.ColorBackColorSubMenus;
                temp.FlatAppearance.BorderSize = 0;
                temp.Cursor = System.Windows.Forms.Cursors.Hand;
                temp.FlatStyle = FlatStyle.Flat;
                temp.TextAlign = ContentAlignment.MiddleLeft;
                temp.Padding = new Padding(10, 0, 0, 0);

                temp.Click += subMenuLogistica_Click;
                temp.Location = new Point(10, (y + 5));
                y += temp.Height;


                if (subMenuLogistica.Controls.Count > 0)
                {
                    posX = posX + ancho;
                }

                this.subMenuLogistica.Controls.Add(temp);
            }
        }

        private void fnCargarSubMenuSistemas(String pcCodMenu)
        {
            DataView dvMenu = new DataView(dtMenu.Tables[0]);
            dvMenu.RowFilter = "cMenuPadre = " + pcCodMenu.ToString().Trim();

            y = 0;
            int posX, posY;
            int alto, ancho;
            ancho = (subMenuSistemas.Width / 4);
            alto = (subMenuSistemas.Height / 3);
            posX = 0;
            posY = 0;
            title = new System.Windows.Forms.Label();
            this.subMenuSistemas.Controls.Clear();

            foreach (DataRowView drv in dvMenu)
            {
                //TreeNode nuevoNodo = new TreeNode();

                System.Windows.Forms.Button temp = new System.Windows.Forms.Button();

                temp.Height = 35;
                temp.Width = 200;

                temp.Name = drv["cMenuCod"].ToString().Trim();
                temp.Text = drv["cMenuNombre"].ToString().Trim();
                temp.Tag = Convert.ToInt32(drv["intIdTipoLlamada"]);

                temp.Dock = DockStyle.Top;
                temp.ForeColor = Variables.ColorForeColorSubMenus;
                temp.BackColor = Variables.ColorBackColorSubMenus;
                temp.FlatAppearance.BorderSize = 0;
                temp.Cursor = System.Windows.Forms.Cursors.Hand;
                temp.FlatStyle = FlatStyle.Flat;
                temp.TextAlign = ContentAlignment.MiddleLeft;
                temp.Padding = new Padding(10, 0, 0, 0);

                temp.Click += subMenuSistemas_Click;
                temp.Location = new Point(10, (y + 5));
                y += temp.Height;

                if (subMenuSistemas.Controls.Count > 0)
                {
                    posX = posX + ancho;
                }
                this.subMenuSistemas.Controls.Add(temp);

            }
        }

        private void fnCargarSubMenuRrhh(String pcCodMenu)
        {
            DataView dvMenu = new DataView(dtMenu.Tables[0]);
            dvMenu.RowFilter = "cMenuPadre = " + pcCodMenu.ToString().Trim();

            y = 0;
            int posX, posY;
            int alto, ancho;
            ancho = (subMenuRrhh.Width / 4);
            alto = (subMenuRrhh.Height / 3);
            posX = 0;
            posY = 0;
            title = new System.Windows.Forms.Label();
            this.subMenuRrhh.Controls.Clear();

            foreach (DataRowView drv in dvMenu)
            {
                //TreeNode nuevoNodo = new TreeNode();

                System.Windows.Forms.Button temp = new System.Windows.Forms.Button();

                temp.Height = 35;
                temp.Width = 200;

                temp.Name = drv["cMenuCod"].ToString().Trim();
                temp.Text = drv["cMenuNombre"].ToString().Trim();
                temp.Tag = Convert.ToInt32(drv["intIdTipoLlamada"]);

                temp.Dock = DockStyle.Top;
                temp.ForeColor = Variables.ColorForeColorSubMenus;
                temp.BackColor = Variables.ColorBackColorSubMenus;
                temp.FlatAppearance.BorderSize = 0;
                temp.Cursor = System.Windows.Forms.Cursors.Hand;
                temp.FlatStyle = FlatStyle.Flat;
                temp.TextAlign = ContentAlignment.MiddleLeft;
                temp.Padding = new Padding(10, 0, 0, 0);

                temp.Click += subMenuRrhh_Click;
                temp.Location = new Point(10, (y + 5));
                y += temp.Height;

                if (subMenuRrhh.Controls.Count > 0)
                {
                    posX = posX + ancho;
                }
                this.subMenuRrhh.Controls.Add(temp);


            }
        }
        private void fnCargarSubMenuSoporte(String pcCodMenu)
        {
            DataView dvMenu = new DataView(dtMenu.Tables[0]);
            dvMenu.RowFilter = "cMenuPadre = " + pcCodMenu.ToString().Trim();

            y = 0;
            int posX, posY;
            int alto, ancho;
            ancho = (subMenuSoporte.Width / 4);
            alto = (subMenuSoporte.Height / 3);
            posX = 0;
            posY = 0;
            title = new System.Windows.Forms.Label();
            this.subMenuSoporte.Controls.Clear();

            foreach (DataRowView drv in dvMenu)
            {
                //TreeNode nuevoNodo = new TreeNode();

                System.Windows.Forms.Button temp = new System.Windows.Forms.Button();

                temp.Height = 35;
                temp.Width = 200;

                temp.Name = drv["cMenuCod"].ToString().Trim();
                temp.Text = drv["cMenuNombre"].ToString().Trim();
                temp.Tag = Convert.ToInt32(drv["intIdTipoLlamada"]);

                temp.Dock = DockStyle.Top;
                temp.ForeColor = Variables.ColorForeColorSubMenus;
                temp.BackColor = Variables.ColorBackColorSubMenus;
                temp.FlatAppearance.BorderSize = 0;
                temp.Cursor = System.Windows.Forms.Cursors.Hand;
                temp.FlatStyle = FlatStyle.Flat;
                temp.TextAlign = ContentAlignment.MiddleLeft;
                temp.Padding = new Padding(10, 0, 0, 0);

                temp.Click += subMenuSoporte_Click;
                temp.Location = new Point(10, (y + 5));
                y += temp.Height;

                if (subMenuSistemas.Controls.Count > 0)
                {
                    posX = posX + ancho;
                }
                this.subMenuSoporte.Controls.Add(temp);

            }
        }
        private void fnCargarSubMenuReportes(String pcCodMenu)
        {
            DataView dvMenu = new DataView(dtMenu.Tables[0]);
            dvMenu.RowFilter = "cMenuPadre = " + pcCodMenu.ToString().Trim();

            y = 0;
            int posX, posY;
            int alto, ancho;
            ancho = (subMenuReportes.Width / 4);
            alto = (subMenuReportes.Height / 3);
            posX = 0;
            posY = 0;
            title = new System.Windows.Forms.Label();
            this.subMenuReportes.Controls.Clear();

            foreach (DataRowView drv in dvMenu)
            {
                //TreeNode nuevoNodo = new TreeNode();

                System.Windows.Forms.Button temp = new System.Windows.Forms.Button();

                temp.Height = 35;
                temp.Width = 200;

                temp.Name = drv["cMenuCod"].ToString().Trim();
                temp.Text = drv["cMenuNombre"].ToString().Trim();
                temp.Tag = Convert.ToInt32(drv["intIdTipoLlamada"]);

                temp.Dock = DockStyle.Top;
                temp.ForeColor = Variables.ColorForeColorSubMenus;
                temp.BackColor = Variables.ColorBackColorSubMenus;
                temp.FlatAppearance.BorderSize = 0;
                temp.Cursor = System.Windows.Forms.Cursors.Hand;
                temp.FlatStyle = FlatStyle.Flat;
                temp.TextAlign = ContentAlignment.MiddleLeft;
                temp.Padding = new Padding(10, 0, 0, 0);

                temp.Click += subMenuReportes_Click;
                temp.Location = new Point(10, (y + 5));
                y += temp.Height;

                if (subMenuReportes.Controls.Count > 0)
                {
                    posX = posX + ancho;
                }
                this.subMenuReportes.Controls.Add(temp);

            }
        }

        private void fnCargarSubMenuConfiguracion(String pcCodMenu)
        {
            DataView dvMenu = new DataView(dtMenu.Tables[0]);
            dvMenu.RowFilter = "cMenuPadre = " + pcCodMenu.ToString().Trim();

            y = 0;
            int posX, posY;
            int alto, ancho;
            ancho = (subMenuConfiguracion.Width / 4);
            alto = (subMenuConfiguracion.Height / 3);
            posX = 0;
            posY = 0;
            title = new System.Windows.Forms.Label();
            this.subMenuConfiguracion.Controls.Clear();

            foreach (DataRowView drv in dvMenu)
            {
                //TreeNode nuevoNodo = new TreeNode();

                System.Windows.Forms.Button temp = new System.Windows.Forms.Button();

                temp.Height = 35;
                temp.Width = 200;

                temp.Name = drv["cMenuCod"].ToString().Trim();
                temp.Text = drv["cMenuNombre"].ToString().Trim();
                temp.Tag = Convert.ToInt32(drv["intIdTipoLlamada"]);

                temp.Dock = DockStyle.Top;
                temp.ForeColor = Variables.ColorForeColorSubMenus;
                temp.BackColor = Variables.ColorBackColorSubMenus;
                temp.FlatAppearance.BorderSize = 0;
                temp.Cursor = System.Windows.Forms.Cursors.Hand;
                temp.FlatStyle = FlatStyle.Flat;
                temp.TextAlign = ContentAlignment.MiddleLeft;
                temp.Padding = new Padding(10, 0, 0, 0);

                temp.Click += subMenuConfiguracion_Click;
                temp.Location = new Point(10, (y + 5));
                y += temp.Height;

                if (subMenuConfiguracion.Controls.Count > 0)
                {
                    posX = posX + ancho;
                }
                this.subMenuConfiguracion.Controls.Add(temp);

            }
        }
        #endregion

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



                    //parentnode1.BackColor = Color.FromArgb(66, 66, 66);
                    //parentnode1.
                    //parentnode1.Mar = ;
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

        private void fnCambiartemas(String codTema)
        {
            ColorThemas.ElegirThema(codTema);
            SubmenusOcultos();
            reset();

            Img_Husat_Blanco.Visible = true;
            siticoneGroupBox1.FillColor = ColorThemas.BarraAccesoDirectos;
            gbHabilitarBusqFechas.FillColor = ColorThemas.BarraAccesoDirectos;
            fnObtenerLabels(siticoneGroupBox1);
            fnObtenerLabels(gbHabilitarBusqFechas);
            fnColoresDatagridView(dgvListaPorBloque);
            fnColoresDatagridView(siticoneDataGridView1);
            fnColoresDatagridView(dgvEmergente);
            fnColoresDatagridView(dgvEgresos);

            lblIngresos.BackColor = ColorThemas.BarraAccesoDirectos;
            lblEgresos.BackColor = ColorThemas.BarraAccesoDirectos;
            lblIngresos.ForeColor = ColorThemas.FuenteBotones;
            lblEgresos.ForeColor = ColorThemas.FuenteBotones;
            lblBuscar.ForeColor = ColorThemas.FuenteBotones;

            iconChildForm.IconColor = ColorThemas.IconoBotones;
            lblChilForm.ForeColor = ColorThemas.FuenteBotones;
            treeView1.ForeColor = Color.White;

            btnOpciones.IconColor = Color.White;
            btnOpciones.ForeColor = Color.White;
            btnPersonalizacion.ForeColor = Color.White;
            btnPersonalizacion.IconColor = Color.White;

            if (codTema == "CTHT0001")
            {
                treeView1.ForeColor = Color.Black;
                Img_Husat_Naranja.Visible = true;
                Img_Husat_Blanco.Visible = false;

                btnOpciones.ForeColor = Color.FromArgb(71, 71, 71);
                btnOpciones.IconColor = Color.FromArgb(71, 71, 71);
                btnPersonalizacion.ForeColor = Color.FromArgb(71, 71, 71);
                btnPersonalizacion.IconColor = Color.FromArgb(71, 71, 71);


                btnOpciones.ForeColor = Color.FromArgb(71, 71, 71);
                btnOpciones.IconColor = Color.FromArgb(71, 71, 71);
                btnPersonalizacion.ForeColor = Color.FromArgb(71, 71, 71);
                btnPersonalizacion.IconColor = Color.FromArgb(71, 71, 71);
                var pnMenuBtn0 = panelMenuPrincipal.Controls.OfType<IconButton>();

                foreach (IconButton bt in pnMenuBtn0)
                {
                    bt.ForeColor= ColorThemas.FuenteBotones;
                    bt.IconColor = ColorThemas.IconoBotones;
                }
                

                btnOpciones.IconColor = ColorThemas.IconoBotones;
                btnOpciones.ForeColor = ColorThemas.FuenteBotones;
                btnPersonalizacion.IconColor = ColorThemas.IconoBotones;
                btnPersonalizacion.ForeColor = ColorThemas.FuenteBotones;

                //iconChildForm.IconColor = ColorThemas.Fuente_Iconos;
                //lblChilForm.ForeColor = ColorThemas.Fuente_Iconos;
                btnOpciones.BackColor = ColorThemas.PanelPadre;
                btnPersonalizacion.BackColor = ColorThemas.PanelPadre;

                btnOpciones.ForeColor = Color.FromArgb(71, 71, 71);
                btnOpciones.IconColor = Color.FromArgb(71, 71, 71);
                btnPersonalizacion.ForeColor = Color.FromArgb(71, 71, 71);
                btnPersonalizacion.IconColor = Color.FromArgb(71, 71, 71);

            }



            //Color a las letra he iconos de los botones
            var pnMenuBtn = panelMenuPrincipal.Controls.OfType<IconButton>();

            foreach (IconButton bt in pnMenuBtn)
            {
                bt.BackColor = ColorThemas.PanelBotones;
                bt.ForeColor = ColorThemas.FuenteBotones;
                bt.IconColor = ColorThemas.IconoBotones;
            }

            treeView1.BackColor = ColorThemas.PanelPadre;
            panelIzquierdo.BackColor = ColorThemas.PanelBotones;

            PanelEncavezadoFondo1.BackColor = ColorThemas.BarraAccesoDirectos;
            btnOpciones.BackColor = ColorThemas.PanelPadre;
            btnPersonalizacion.BackColor = ColorThemas.PanelPadre;
            panelEspaciado.BackColor = ColorThemas.PanelPadre;
            //Botones del panel de acceso Directo

            tsConfiguracion.BackColor = ColorThemas.BarraAccesoDirectos;
            tsConfiguracion.ForeColor = ColorThemas.FuenteBotones;
            tsConfiguracion.IconColor = ColorThemas.IconoBotones;

            tsUsuarios.BackColor = ColorThemas.BarraAccesoDirectos;
            tsUsuarios.ForeColor = ColorThemas.FuenteBotones;
            tsUsuarios.IconColor = ColorThemas.IconoBotones;

            tsVenta.BackColor = ColorThemas.BarraAccesoDirectos;
            tsVenta.ForeColor = ColorThemas.FuenteBotones;
            tsVenta.IconColor = ColorThemas.IconoBotones;


            pntsSeguimiento.BackColor = ColorThemas.BarraAccesoDirectos;
            pntsSeguimiento.ForeColor = ColorThemas.FuenteBotones;
            
            tsSeguimiento.BackColor = ColorThemas.BarraAccesoDirectos;
            tsSeguimiento.ForeColor = ColorThemas.FuenteBotones;
            tsSeguimiento.IconColor = ColorThemas.IconoBotones;            

            tsCaja.BackColor = ColorThemas.BarraAccesoDirectos;
            tsCaja.ForeColor = ColorThemas.FuenteBotones;
            tsCaja.IconColor = ColorThemas.IconoBotones;

            //tsCompra.BackColor = ColorThemas.BarraAccesoDirectos;
            //tsCompra.ForeColor = ColorThemas.FuenteBotones;
            //tsCompra.IconColor = ColorThemas.IconoBotones;

            tsConsulta.BackColor = ColorThemas.BarraAccesoDirectos;
            tsConsulta.ForeColor = ColorThemas.FuenteBotones;
            tsConsulta.IconColor = ColorThemas.IconoBotones;

            tsMiCaja.BackColor = ColorThemas.BarraAccesoDirectos;
            tsMiCaja.ForeColor = ColorThemas.FuenteBotones;
            tsMiCaja.IconColor = ColorThemas.IconoBotones;

            tsCerraSession.BackColor = ColorThemas.BarraAccesoDirectos;

            panelPerfil.BackColor = ColorThemas.BarraAccesoDirectos;
            tsCerraSession.ForeColor = ColorThemas.FuenteBotones;
            tsCerraSession.IconColor = ColorThemas.IconoBotones;

            //if (codTema == "CTHT0004")
            //{
            //    treeView1.ForeColor = Color.Black;
            //    btnOpciones.ForeColor = Color.FromArgb(71, 71, 71);
            //    btnOpciones.IconColor = Color.FromArgb(71, 71, 71);
            //    btnPersonalizacion.ForeColor = Color.FromArgb(71, 71, 71);
            //    btnPersonalizacion.IconColor = Color.FromArgb(71, 71, 71);
            //}

        }
        private void fnValidarusuarioEnSession()
        {
            if (Variables.gsCargoUsuario == "PETR0006")
            {
                cboTipoReporte.SelectedValue = "TRPT0002";
                cboTipoReporte.Visible = false;
                txtBuscarRepGeneral.Location = new Point(659, 55);
                txtBuscarRepGeneral.Width = 440;
                SiticoneHtmlLabel11.Visible = false;
                SiticoneHtmlLabel13.Visible = false;
                chkDiaEspecificoG.Checked = true;
                dtFechaInicioG.Value = Variables.gdFechaSis;
                chkDiaEspecificoG.Enabled=false;
                chkHabilitarFechasBusG.Enabled=false;
                cboUsuario.SelectedValue = Variables.gnCodUser;
                cboUsuario.Visible = false;

            }
            else
            {
                chkDiaEspecificoG.Enabled = true;
                chkHabilitarFechasBusG.Enabled = true;
                dtFechaInicioG.Value = dtFechaFinG.Value.AddDays(-(dtFechaFinG.Value.Day - 1));
                chkDiaEspecificoG.Checked = false;
                cboTipoReporte.SelectedValue = "0";
                cboTipoReporte.Visible = true;
                cboUsuario.SelectedValue = 0;
                cboUsuario.Visible = true;
                txtBuscarRepGeneral.Location = new Point((cboUsuario.Location.X + cboUsuario.Width) + 5, 55);
                txtBuscarRepGeneral.Width = 130;
                SiticoneHtmlLabel11.Visible = true;
                SiticoneHtmlLabel13.Visible = true;


            }
            lblBuscar.Location = new Point(txtBuscarRepGeneral.Location.X, (txtBuscarRepGeneral.Location.Y - lblBuscar.Height));
            //lblBuscar.ForeColor = Color.Black;
            //pictureBox1.Location = new Point(pictureBox1.Location.X, 49 + (txtBuscarRepGeneral.Height / 4));
            pictureBox1.Location = new Point((txtBuscarRepGeneral.Location.X + txtBuscarRepGeneral.Width)-30, pictureBox1.Location.Y);

        }
        public void fnMostrarAlertaSeguimiento()
        {
            
            lstTotRan = objAcc.blTotalesRankingSeguimiento("", "", "0", FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis.AddDays(-(Variables.gdFechaSis.Day - 1)),5),FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis,5), false, true, false, false, 0,FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis,5), 0, 0, 0);

            btnAlertaSeguimiento.Text = "" + lstTotRan.totalRojos;
        }
        public void fnValidarServidor()
        {
            String lsIni = "SIGC.ini";
            String sLine = "";
            String cClave1 = "";
            String cClave2 = "";
            int k = 0;

            String cArchivo = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

            if (cArchivo.Substring(cArchivo.Length - 1, 1) == "\\")
            {
                cArchivo = cArchivo + lsIni;
            }
            else
            {
                cArchivo = cArchivo + @"\" + lsIni;
            }

            StreamReader objReader = new StreamReader(cArchivo, Encoding.Default);
            do
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    k = sLine.IndexOf("=");
                    if (k > 0)
                    {
                        //cClave1 = oEnc.ConvertirClave(sLine.Substring(0, k), "", false);
                        //cClave2 = oEnc.ConvertirClave(sLine.Substring(k + 1, sLine.Length - (k + 1)), "", false);
                        cClave1 = sLine.Substring(0, k);
                        cClave2 = sLine.Substring(k + 1, sLine.Length - (k + 1));
                        if (cClave1 == "Server")
                        {
                            Variables.cNombreServidor = cClave2;

                        }
                    }
                }
            }
            while (sLine != null);
        }
        private void MDIParent1_Load(object sender, EventArgs e)
        {
            stpnMensajes.Visible = false;
            //lblIngresos.Padding = new Padding(15, 0, 0, 0);
            //lblEgresos.Padding = lblIngresos.Padding;
            dtFechaFinG.Value = Variables.gdFechaSis;
            dtFechaInicioG.Value = dtFechaFinG.Value.AddDays(-(dtFechaFinG.Value.Day - 1));
            fnCambiartemas("CTHT0001");
            pnlParaDashboard.Visible = false;
            //treeView1.Controls.Clear();
            bl = new BLControlCaja();
            flowLayoutPanel1.Controls.Clear();
            ToggleBotonesAnchos.CheckState = CheckState.Unchecked;
            //inicio de funciones de cargado de menus y formulario load
            fnValidarServidor();
            try
            {
                //cboxSelecThema.SelectedIndex = 2;
                
                fnOcultarObjetos();
                SystemEvents.PowerModeChanged += OnPowerModeChange;
                InitializeTimer();

                SafelySubscribeToControllerEvents();
                
                FunGeneral.fnLlenarTablaCodTipoCon(cboTipoReporte, "TRPT", false);
                FunGeneral.fnLlenarTablaCod(cboxSelecThema, "CTHT");
                cboxSelecThema.SelectedIndex = 1;
                
               
                Loading();
                cboTipoReporte.MouseWheel += new MouseEventHandler(cbos_MouseWheel);
                cboUsuario.MouseWheel += new MouseEventHandler(cbos_MouseWheel);
                cboxSelecThema.MouseWheel += new MouseEventHandler(cbos_MouseWheel);
                cboFiltraIngresos.MouseWheel += new MouseEventHandler(cbos_MouseWheel);
                cboTipoPago.MouseWheel += new MouseEventHandler(cbos_MouseWheel);

                
                flowLayoutPanel1.Location = new Point(flowLayoutPanel1.Location.X, FWpnCajaChicaCopias.Height + (pnlParaDashboard.AutoScrollPosition.Y));
                siticoneGroupBox1.Location = new Point(siticoneGroupBox1.Location.X, flowLayoutPanel1.Location.Y + flowLayoutPanel1.Height);

                if (Variables.gsCargoUsuario == "PETR0006")
                {
                    tsMiCaja.Text = "Mi Caja";
                }
                else
                {
                    tsMiCaja.Text = "Consultas Caja";
                }

                fnMostrarAlertaSeguimiento();


                FunGeneral.fnLlenarTablaCodTipoCon(cboCargoMessage, "PETR", true);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                //pnlParaDashboard.Visible = Variables.gsCargoUsuario == "PETR0008" ? false : true;
                //treeView1.Controls.Add(pnlParaDashboard);
                pnlParaDashboard.Size = treeView1.Size;
                var gbx = pnlParaDashboard.Controls.OfType<SiticoneGroupBox>();
                var pn = pnlParaDashboard.Controls.OfType<SiticonePanel>();
                //flowLayoutPanel1.Width = pnlParaDashboard.Size.Width - 20;
                //flowLayoutPanel1.Location = new Point(10, flowLayoutPanel1.Location.Y);
                foreach (SiticoneGroupBox gb in gbx)
                {
                    gb.Width = pnlParaDashboard.Size.Width - 20;
                    gb.Location = new Point(5, gb.Location.Y);
                }
                foreach (SiticonePanel pnn in pn)
                {
                    pnn.Width = pnlParaDashboard.Size.Width - 20;
                    pnn.Location = new Point(5, pnn.Location.Y);
                }
               
                

                if (Variables.gsCargoUsuario == "PETR0006")
                {
                    cboUsuario.SelectedValue = Variables.gnCodUser;
                    dtFechaInicioG.Value = Variables.gdFechaSis;
                    
                }
                else
                {
                    cboUsuario.SelectedValue = 0;
                }
                fnValidarusuarioEnSession();
                fnLocationElementos();
                fnPosicionDeCajas();
                fnEscucharMansages();
                fnEscucharAlertasDasboard() ;

            }

        }

        public void OnTimerEvent(object source, EventArgs e)
        {
            if (LoadCarga == true)
            {
                Frm_FormClosed();
                LoadCarga = false;
                estadoTema = true;
                
            }
            string strFechaIso = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 5);
            string strFechaHourIso = strFechaIso + " " + (DateTime.Now.TimeOfDay.ToString()).Substring(0, 12);
            Variables.gdFechaSis = Convert.ToDateTime(strFechaHourIso);
            toolStripStatusLabel3.Text = "Fecha del Sistema: " + Variables.gdFechaSis.ToString("dd/MM/yyyy HH:mm:ss");
            //fnEscucharMansages();
        }

        private void OnPowerModeChange(object s, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Resume)
            {
                System.Threading.Thread.Sleep(1000);
                FunGeneral.fnVerificarFechaSistema(this.OwnedForms);
            }
        }



        private Form fnMenuDinamico(String pcNomForm, int pnTipoLlamada)
        {
            Object obj = null;
            object[] pa = new object[1];
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
            catch (Exception ex)
            { return null;
            }
        }

        private void fnActivarFormularioConBoton(string pcNomreFormulario, int pintidTipoLlamada)
        {
            Form frmFormulario;


        }

        private void fnActivarFormulario(String pcNombreFormulario, int pintidTipoLlamada)
        {
            Form frmFormulario;

            if (String.IsNullOrEmpty(pcNombreFormulario) == false)
            {
                frmFormulario = fnMenuDinamico(pcNombreFormulario, 0);
                if (frmFormulario != null)
                {                   

                    if (frmFormulario.Name == "frmRegistrarVenta" && pintidTipoLlamada == 1)
                    {
                        frmRegistrarVenta frmRegVenta = new frmRegistrarVenta();
                        frmRegVenta.Inicio(3);
                    }
                    else
                    {
                        if (frmFormulario.Name == "frmReportes")
                        {
                            frmReportes frm = new frmReportes();
                            frm.Inicio(pintidTipoLlamada);
                        }
                        else
                        {
                            frmFormulario.Show();
                        }
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
            catch (Exception ex)
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
            if (e.ClickedItem.Name == "tsCerraSession")
            {

            }
            else if (e.ClickedItem.Name == "tsMiCaja")
            {
                // frmCaja frmCaja = new frmCaja();
                //fnCargarFormAPanel(new frmCaja());
                //frmCaja.Show();
            }
            else
            {

                fnActivarFormulario(e.ClickedItem.ToolTipText.Trim(), Convert.ToInt32(e.ClickedItem.Tag));

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
                //ImgPerfil.Padding = new Padding(15,15,15,15);
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
        


        private void saveOrder(Funciones.Models.OrderRequest objOrder, int lnTipoLlamada = 0)
        {
            OrderResponse orden = new OrderResponse();
            bool blnResult = false;
            orden = FunGeneral.fnSaveOrder(objOrder);
            if (orden.Status == 200)
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


        private void tsCerraSession_Click(object sender, EventArgs e)
        {
            fnOcultarPanelCerrarSession();
        }

        private void fnOcultarPanelCerrarSession()
        {
            if (panelCerrarSession.Visible == true)
            {
                panelCerrarSession.Visible = false;
            }
            else
            {
                panelCerrarSession.Visible = true;
            }
        }
        private void tsCerrarSession_Click(object sender, EventArgs e)
        {
            //this.Close();
            pnlParaDashboard.Visible = false;
            iconChildForm.IconChar = IconChar.Home;
            lblChilForm.Text = "Home";
            ImgPerfil.BackgroundImage = null;
            ImgPerfil.Image = null;
            SubmenusOcultos();
            reset();

            panelCerrarSession.Visible = false;
            LoadCarga = false;
            fnOcultarObjetos();
            login();



        }



        private Boolean PruebaLoad_Click(object frmload)
        {

            if (this.treeView1.Controls.Count > 0)
                this.treeView1.Controls.RemoveAt(0);
            Form fn = frmload as Form;
            fn.TopLevel = false;
            fn.Dock = DockStyle.Fill;
            this.treeView1.Controls.Add(fn);
            this.treeView1.Tag = fn;
            fn.Show();


            return true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Img_Husat_Naranja.Visible = false;
            //Img_Husat_Blanco.Visible = true;

            //iconChildForm.IconChar =IconChar.Home;
            //lblChilForm.Text = "Home";
            //SubmenusOcultos();
            //reset();

            //treeView1.Nodes.Clear();
            pictureBox5_Click_(sender, e);
        }

        private void pictureBox5_Click_(object sender, EventArgs e)
        {
            //Img_Husat_Blanco.Visible = false;
            //Img_Husat_Naranja.Visible = true;
            iconChildForm.IconChar = IconChar.Home;
            lblChilForm.Text = "Home";
            SubmenusOcultos();
            reset();
            fnActivarDashBoard(FunGeneral.fnVerificarApertura(Variables.gnCodUser)==1?true:false);
            fnBuscarReporteGeneralVentas(dgvListaPorBloque, 0, -1);
            

        }


        private void fnBotonActivo(object senderBtn, Color color)
        {
            ColorThemas.ElegirThema(Variables.clasePersonal.codTema);

            if (senderBtn != null)
            {
                //desactivamos el Boton
                fnBotoninactivo();
                //Personalizando Boton
                BtnActual = (IconButton)senderBtn;//asigna el boton actual con el Boton remitente
                BtnActual.BackColor = ColorThemas.FondoBotones;
                //BtnActual.ForeColor = color;

                //BtnActual.ForeColor = ColorThemas.PanelBotones;
                BtnActual.ForeColor = panelIzquierdo.BackColor;

                BtnActual.TextAlign = ContentAlignment.MiddleCenter;
                //BtnActual.IconColor = color;


                BtnActual.IconColor = ColorThemas.IconoBotones;

                BtnActual.IconColor = panelIzquierdo.BackColor;
                if (Variables.clasePersonal.codTema == "CTHT0002")
                {
                    BtnActual.IconColor = Color.FromArgb(255, 72, 31);

                    BtnActual.ForeColor = Color.FromArgb(255, 72, 31);
                }

                BtnActual.TextImageRelation = TextImageRelation.TextBeforeImage;
                BtnActual.ImageAlign = ContentAlignment.MiddleRight;
                //BtnActual.FlatAppearance.MouseOverBackColor = color;

                //borde Izquierdo del boton
                LeftBordeBtn.BackColor = Color.Black;
                LeftBordeBtn.Location = new Point(0, BtnActual.Location.Y);
                LeftBordeBtn.Visible = true;
                LeftBordeBtn.BringToFront();
                //iconChildForm seleccion icono y nombre en la cabezera 
                iconChildForm.IconChar = BtnActual.IconChar;
                lblChilForm.Text = BtnActual.Text;

                //BtnActual.FlatAppearance.MouseOverBackColor = Color.FromArgb(244, 96, 63);
                //BtnActual.FlatAppearance.text

            }

        }

        private void fnBotoninactivo()
        {

            if (BtnActual != null)
            {
                BtnActual.BackColor = ColorThemas.PanelBotones;
                BtnActual.ForeColor = ColorThemas.FuenteBotones;
                BtnActual.TextAlign = ContentAlignment.MiddleLeft;
                BtnActual.IconColor = ColorThemas.IconoBotones;
                BtnActual.TextImageRelation = TextImageRelation.ImageBeforeText;
                BtnActual.ImageAlign = ContentAlignment.MiddleLeft;
                //BtnActual.BackColor = panelIzquierdo.BackColor;
                //BtnActual.ForeColor = Color.White;
                //BtnActual.TextAlign = ContentAlignment.MiddleLeft;
                //BtnActual.IconColor = Color.White;
                //BtnActual.TextImageRelation = TextImageRelation.ImageBeforeText;
                //BtnActual.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        //resetear los botones
        private void reset()
        {
            fnBotoninactivo();
            LeftBordeBtn.Visible = false;
        }






        //private void fnCambiarMenu()
        //{
        //    if (SwitchMenus.Checked == true)
        //    {
        //        panelToosStrip.Visible = false;
        //        panelToosStrip.Dock = DockStyle.None;
        //        panelBotones.Visible = true;
        //        panelBotones.Dock = DockStyle.Fill;
        //        btnPanel2.Visible = false;
        //        btnPanel1.Visible = true;

        //        treeView1.Nodes.Clear();
        //        tvOpes.Nodes.Clear();

        //        SplitIzquierdo.SplitterDistance = 40;


        //        OcultarSubMenu();
        //        FnColorwhiteselectBtns();

        //    }
        //    else
        //    {
        //        panelBotones.Visible = false;
        //        panelBotones.Dock = DockStyle.None;
        //        panelToosStrip.Visible = true;
        //        panelToosStrip.Dock = DockStyle.Fill;
        //        btnPanel1.Visible = false;
        //        btnPanel2.Visible = true;

        //        treeView1.Nodes.Clear();
        //        tvOpes.Nodes.Clear();

        //        SplitIzquierdo.SplitterDistance = 233;
        //      fnselectslMenuIzquierdo();
        //    }
        //}


        private void SubmenusOcultos()
        {
            subMenuVentas.Visible = false;
            subMenuRecaudacion.Visible = false;
            subMenuComercial.Visible = false;
            subMenuLogistica.Visible = false;
            subMenuSistemas.Visible = false;
            subMenuRrhh.Visible = false;
            subMenuConfiguracion.Visible = false;
            subMenuSoporte.Visible = false;
            subMenuReportes.Visible = false;

        }
        private void OcultarSubMenu()
        {
            if (subMenuVentas.Visible == true)
                subMenuVentas.Visible = false;
            if (subMenuRecaudacion.Visible == true)
                subMenuRecaudacion.Visible = false;
            if (subMenuComercial.Visible == true)
                subMenuComercial.Visible = false;
            if (subMenuLogistica.Visible == true)
                subMenuLogistica.Visible = false;
            if (subMenuSistemas.Visible == true)
                subMenuSistemas.Visible = false;
            if (subMenuRrhh.Visible == true)
                subMenuRrhh.Visible = false;
            if (subMenuConfiguracion.Visible == true)
                subMenuConfiguracion.Visible = false;
            if (subMenuSoporte.Visible == true)
                subMenuSoporte.Visible = false;
            if (subMenuReportes.Visible == true)
                subMenuReportes.Visible = false;

        }
        private void MostrarSubMenu(System.Windows.Forms.Panel subMenu)
        {
            this.treeView1.Controls.Clear();
            if (subMenu.Visible == false)
            {
                OcultarSubMenu();
                subMenu.Visible = true;

            }
            else
                subMenu.Visible = false;
        }


        #region Click Botones Menu Principal
        private void btnVenta_Click(object sender, EventArgs e)
        {

            LoadCarga = false;

            //fnBotonActivo(sender, Variables.ColorEmpresa);
            fnBotonActivo(sender, Variables.ColorEmpresa);
            MostrarSubMenu(subMenuVentas);

            treeView1.Nodes.Clear();
            lcCodMenu = "8888800000";

            fnCargarSubMenuVentas(lcCodMenu);
        }

        private void btnRecaudacion_Click(object sender, EventArgs e)
        {

            LoadCarga = false;

            fnBotonActivo(sender, Variables.ColorEmpresa);

            MostrarSubMenu(subMenuRecaudacion);

            treeView1.Nodes.Clear();
            lcCodMenu = "8881000000";
            fnCargarSubMenuRecaudacion(lcCodMenu);

        }

        private void btnComercial_Click(object sender, EventArgs e)
        {
            LoadCarga = false;

            fnBotonActivo(sender, Variables.ColorEmpresa);

            MostrarSubMenu(subMenuComercial);

            treeView1.Nodes.Clear();
            lcCodMenu = "8888900000";
            fnCargarSubMenuComercial(lcCodMenu);
        }

        private void btnLogistica_Click(object sender, EventArgs e)
        {
            LoadCarga = false;

            fnBotonActivo(sender, Variables.ColorEmpresa);

            MostrarSubMenu(subMenuLogistica);

            treeView1.Nodes.Clear();
            lcCodMenu = "8888600000";
            fnCargarSubMenuLogistica(lcCodMenu);
        }

        private void btnSistemas_Click(object sender, EventArgs e)
        {
            LoadCarga = false;

            fnBotonActivo(sender, Variables.ColorEmpresa);

            MostrarSubMenu(subMenuSistemas);

            treeView1.Nodes.Clear();
            lcCodMenu = "8888300000";
            fnCargarSubMenuSistemas(lcCodMenu);
        }

        private void btnRrhh_Click(object sender, EventArgs e)
        {
            LoadCarga = false;

            fnBotonActivo(sender, Variables.ColorEmpresa);

            MostrarSubMenu(subMenuRrhh);

            treeView1.Nodes.Clear();
            lcCodMenu = "8888200000";
            fnCargarSubMenuRrhh(lcCodMenu);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            LoadCarga = false;

            fnBotonActivo(sender, Variables.ColorEmpresa);

            MostrarSubMenu(subMenuConfiguracion);

            treeView1.Nodes.Clear();
            lcCodMenu = "8888700000";
            fnCargarSubMenuConfiguracion(lcCodMenu);
        }

        private void btnSoporte_Click(object sender, EventArgs e)
        {
            LoadCarga = false;

            fnBotonActivo(sender, Variables.ColorEmpresa);

            MostrarSubMenu(subMenuSoporte);


            treeView1.Nodes.Clear();
            lcCodMenu = "8888400000";
            fnCargarSubMenuSoporte(lcCodMenu);
        }
        #endregion Click Botones Menu Principal

        private void panelBotones_Click(object sender, EventArgs e)
        {
            LoadCarga = false;
        }

        private System.Windows.Forms.Button fnObtenerBotonEsp(object sender, SiticonePanel panel)
        {
            var Controles = panel.Controls.OfType<System.Windows.Forms.Button>();
            System.Windows.Forms.Button temp = new System.Windows.Forms.Button();
            String Cadena = sender.ToString();
            String[] array = Cadena.Split(':');
            String item = array[1].ToString().Trim();
            foreach (System.Windows.Forms.Button btn in Controles)
            {
                btn.BackColor = Variables.ColorBackColorSubMenus;
                if (btn.Text == item)
                {
                    temp = btn;
                    //break;
                }

            }
            return temp;
        }
        private void subMenuVentas_Click(object sender, EventArgs e)
        {
            String lcCodMenu = "";

            lcCodMenu = fnObtenerBotonEsp(sender, subMenuVentas).Name;

            fnObtenerBotonEsp(sender, subMenuVentas).BackColor = Variables.ColorSelectSubMenus;

            fnllenaTreeView(dtMenu.Tables[0], lcCodMenu);
        }

        private void subMenuRecaudacion_Click(object sender, EventArgs e)
        {
            String lcCodMenu = "";

            lcCodMenu = fnObtenerBotonEsp(sender, subMenuRecaudacion).Name;

            fnObtenerBotonEsp(sender, subMenuRecaudacion).BackColor = Variables.ColorSelectSubMenus;

            fnllenaTreeView(dtMenu.Tables[0], lcCodMenu);

        }
        private void subMenuComercial_Click(object sender, EventArgs e)
        {
            String lcCodMenu = "";


            lcCodMenu = fnObtenerBotonEsp(sender, subMenuComercial).Name;

            fnObtenerBotonEsp(sender, subMenuComercial).BackColor = Variables.ColorSelectSubMenus;

            fnllenaTreeView(dtMenu.Tables[0], lcCodMenu);
        }

        private void subMenuLogistica_Click(object sender, EventArgs e)
        {
            String lcCodMenu = "";

            lcCodMenu = fnObtenerBotonEsp(sender, subMenuLogistica).Name;

            fnObtenerBotonEsp(sender, subMenuLogistica).BackColor = Variables.ColorSelectSubMenus;

            fnllenaTreeView(dtMenu.Tables[0], lcCodMenu);
        }

        private void subMenuSistemas_Click(object sender, EventArgs e)
        {
            String lcCodMenu = "";

            lcCodMenu = fnObtenerBotonEsp(sender, subMenuSistemas).Name;

            fnObtenerBotonEsp(sender, subMenuSistemas).BackColor = Variables.ColorSelectSubMenus;

            fnllenaTreeView(dtMenu.Tables[0], lcCodMenu);
        }

        private void subMenuRrhh_Click(object sender, EventArgs e)
        {
            String lcCodMenu = "";

            lcCodMenu = fnObtenerBotonEsp(sender, subMenuRrhh).Name;

            fnObtenerBotonEsp(sender, subMenuRrhh).BackColor = Variables.ColorSelectSubMenus;

            fnllenaTreeView(dtMenu.Tables[0], lcCodMenu);
        }

        private void subMenuConfiguracion_Click(object sender, EventArgs e)
        {
            String lcCodMenu = "";

            lcCodMenu = fnObtenerBotonEsp(sender, subMenuConfiguracion).Name;

            fnObtenerBotonEsp(sender, subMenuConfiguracion).BackColor = Variables.ColorSelectSubMenus;

            fnllenaTreeView(dtMenu.Tables[0], lcCodMenu);
        }

        private void subMenuSoporte_Click(object sender, EventArgs e)
        {
            String lcCodMenu = "";

            lcCodMenu = fnObtenerBotonEsp(sender, subMenuSoporte).Name;

            fnObtenerBotonEsp(sender, subMenuSoporte).BackColor = Variables.ColorSelectSubMenus;

            fnllenaTreeView(dtMenu.Tables[0], lcCodMenu);
        }


        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            IconButton btn = new IconButton();
            btn = fnObtenerBotonEspIconButton(sender, LayoutPanelAccesoRapido);
            fnActivarFormulario(btn.Name, 0);

        }
        private IconButton fnObtenerBotonEspIconButton(object sender, FlowLayoutPanel panel)
        {
            var Controles = panel.Controls.OfType<IconButton>();
            var ControlesPN = panel.Controls.OfType<SiticonePanel>();
            var ctBtn= panel.Controls.OfType<IconButton>();
            IconButton temp = new IconButton();
            String Cadena = sender.ToString();
            String[] array = Cadena.Split(':');
            String item = array[1].ToString().Trim();

            foreach (SiticonePanel st in ControlesPN)
            {
                 ctBtn= st.Controls.OfType<IconButton>();

            }

            Int32 cont = 0;
            foreach (IconButton btn in Controles)
            {
                //btn.BackColor = Variables.ColorBackColorSubMenus;
                if (btn.Text == item)
                {
                    temp = btn;
                    break;
                }
                else
                {
                    foreach (IconButton bt in ctBtn)
                    {
                        if (bt.Text== item)
                        {
                            temp = bt;
                            cont = 1;
                            break;
                        }
                    }
                    if (cont==1)
                    {
                        break;
                    }
                }

            }
            return temp;
        }

        private void tsSistemas_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1_Click(sender, e);
        }

        private void tsAccesos_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1_Click(sender, e);
        }
        private void tsVenta_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1_Click(sender, e);
        }
        private void tsCaja_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1_Click(sender, e);
        }
        private void tsCompra_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1_Click(sender, e);
        }


        private void btnCerrarSesion_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            btnCerrarSesion.IconChar = IconChar.PersonWalkingDashedLineArrowRight;
            btnPerfil.IconFont = IconFont.Regular;
        }

        private void btnPerfil_MouseMove(object sender, EventArgs e)
        {
            btnPerfil.IconFont = IconFont.Solid;
            btnCerrarSesion.IconChar = IconChar.PersonWalkingArrowRight;
        }

        private void fnObtenerLabels(SiticoneGroupBox gb)
        {
            var lbl = gb.Controls.OfType<SiticoneHtmlLabel>();
            foreach (SiticoneHtmlLabel llb in lbl)
            {
                llb.ForeColor = ColorThemas.FuenteBotones;
            }
        }

        private void fnColoresDatagridView(SiticoneDataGridView dg)
        {
            dg.BackgroundColor = ColorThemas.contenidoDasboard;
            dg.ThemeStyle.RowsStyle.BackColor= ColorThemas.BarraAccesoDirectos;
            //dg.DefaultCellStyle.BackColor = ColorThemas.BarraAccesoDirectos;
            dg.RowsDefaultCellStyle.BackColor = ColorThemas.BarraAccesoDirectos;
            //dg.ThemeStyle.BackColor= ColorThemas.BarraAccesoDirectos;
            dg.ThemeStyle.AlternatingRowsStyle.BackColor= ColorThemas.BarraAccesoDirectos;
            dg.ThemeStyle.RowsStyle.ForeColor= ColorThemas.FuenteBotones;
        }
        private void siticoneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DAVentaGeneral dav = new DAVentaGeneral();
            String codThema = cboxSelecThema.SelectedValue is null?"0": cboxSelecThema.SelectedValue.ToString();
            //fnCambiartemas();
            if (estadoTema == true && cboxSelecThema.SelectedValue.ToString()!="0")
            {
                Variables.clasePersonal.codTema = codThema;
                dav.daActualizarTemaUsuario(Variables.gnCodUser, codThema);

                fnCambiartemas(Variables.clasePersonal.codTema);
            }

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

            if (cboxSelecThema.Visible == false)
            {
               
                btnOpciones.IconChar = IconChar.Gear;

            }
            else
            {
               
                btnOpciones.IconChar = IconChar.Sliders;
            }
        }

        private void treeView1_MouseEnter(object sender, EventArgs e)
        {
            panelOpciones.Visible = false;
            panelPersonalizarColores.Visible = false;
            btnOpciones.IconChar = IconChar.Sliders;
        }

        private void btnOpciones_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            panelOpciones.Visible = true;
            btnOpciones.IconChar = IconChar.Gear;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Sets the initial color select to the current text color.
            MyDialog.Color = panelColorMenuPrincipal.BackColor;
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            MyDialog.Color = Color.FromArgb(255, 128, 0);

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                panelColorMenuPrincipal.BackColor = MyDialog.Color;
        }



        private void panelColorAccesoDirecto_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.Color = panelColorAccesoDirecto.BackColor;
            MyDialog.AllowFullOpen = true;
            MyDialog.ShowHelp = true;
            MyDialog.Color = Color.FromArgb(255, 128, 0);
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                panelColorAccesoDirecto.BackColor = MyDialog.Color;
                PanelEncavezadoFondo1.BackColor = MyDialog.Color;
                PanelEncavezadoFondo1.BackColor = MyDialog.Color;
                fnColoresHecader(MyDialog.Color,Color.White,Color.WhiteSmoke);




            }


        }

        private void panelColorPanelCentral_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.Color = panelColorPanelCentral.BackColor;
            MyDialog.AllowFullOpen = true;
            MyDialog.ShowHelp = true;
            MyDialog.Color = Color.FromArgb(255, 128, 0);
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                panelColorPanelCentral.BackColor = MyDialog.Color;
               treeView1.BackColor = MyDialog.Color;

                btnPersonalizacion.BackColor = MyDialog.Color;
                btnOpciones.BackColor = MyDialog.Color;

            }
        //    ColorThemas.ElegirThema(cboxSelecThema.Text);

        }

        private void panelColorMenuPrincipal_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.Color = panelColorMenuPrincipal.BackColor;
            MyDialog.AllowFullOpen = true;
            MyDialog.ShowHelp = true;
            MyDialog.Color = Color.FromArgb(255, 128, 0);
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                panelColorMenuPrincipal.BackColor = MyDialog.Color;
                panelIzquierdo.BackColor = MyDialog.Color;
               
                btnVenta.BackColor = MyDialog.Color;
                btnRecaudacion.BackColor = MyDialog.Color;
                btnComercial.BackColor = MyDialog.Color;
                btnLogistica.BackColor = MyDialog.Color;
                btnSistemas.BackColor = MyDialog.Color;
                btnRrhh.BackColor = MyDialog.Color;
                btnConfiguracion.BackColor = MyDialog.Color;
                btnSoporte.BackColor = MyDialog.Color;

                iconChildForm.IconChar = IconChar.Home;
                lblChilForm.Text = "Home";
                SubmenusOcultos();
                reset();

            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            panelPersonalizarColores.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ToggleBotonesAnchos_CheckedChanged(object sender, EventArgs e)
        {
            if (ToggleBotonesAnchos.Checked == false)
            {
                int sizebtn = 25;
               
                var pnMenuBtn = panelMenuPrincipal.Controls.OfType<IconButton>();

                foreach (IconButton bt in pnMenuBtn)
                {
                    bt.Size = new Size(222, 35);
                    bt.IconSize = sizebtn;
                }
            }
            else
            {
               int sizebtn = 32;
                var pnMenuBtn = panelMenuPrincipal.Controls.OfType<IconButton>();

                foreach (IconButton bt in pnMenuBtn)
                {
                    bt.Size = new Size(222, 35);
                    bt.IconSize = sizebtn;
                }
            }

        }

        private void ToggleTextoNegrita_CheckedChanged(object sender, EventArgs e)
        {
            if (ToggleTextoNegrita.Checked == false)
            {
               
                btnVenta.Font = new Font(btnVenta.Font, FontStyle.Regular);
                btnComercial.Font = new Font(btnComercial.Font, FontStyle.Regular);
                btnConfiguracion.Font = new Font(btnConfiguracion.Font, FontStyle.Regular);
                btnLogistica.Font = new Font(btnLogistica.Font, FontStyle.Regular);
                btnSistemas.Font = new Font(btnSistemas.Font, FontStyle.Regular);
                btnRrhh.Font = new Font(btnRrhh.Font, FontStyle.Regular);
                btnRecaudacion.Font = new Font(btnRecaudacion.Font, FontStyle.Regular);
                btnSoporte.Font = new Font(btnSoporte.Font, FontStyle.Regular);

                tsConfiguracion.Font = new Font(tsConfiguracion.Font, FontStyle.Regular);
                tsUsuarios.Font = new Font(tsUsuarios.Font, FontStyle.Regular);
                tsVenta.Font = new Font(tsVenta.Font, FontStyle.Regular);
                tsCaja.Font = new Font(tsCaja.Font, FontStyle.Regular);
                //tsCompra.Font = new Font(tsCompra.Font, FontStyle.Regular);
                tsConsulta.Font = new Font(tsConsulta.Font, FontStyle.Regular);
                tsMiCaja.Font = new Font(tsMiCaja.Font, FontStyle.Regular);


            }
            else
            {
               
                btnVenta.Font = new Font(btnVenta.Font, FontStyle.Bold);
                btnVenta.Font = new Font(btnVenta.Font, FontStyle.Bold);
                btnComercial.Font = new Font(btnComercial.Font, FontStyle.Bold);
                btnConfiguracion.Font = new Font(btnConfiguracion.Font, FontStyle.Bold);
                btnLogistica.Font = new Font(btnLogistica.Font, FontStyle.Bold);
                btnSistemas.Font = new Font(btnSistemas.Font, FontStyle.Bold);
                btnRrhh.Font = new Font(btnRrhh.Font, FontStyle.Bold);
                btnRecaudacion.Font = new Font(btnRecaudacion.Font, FontStyle.Bold);
                btnSoporte.Font = new Font(btnSoporte.Font, FontStyle.Bold);

                tsConfiguracion.Font = new Font(tsConfiguracion.Font, FontStyle.Bold);
                tsUsuarios.Font = new Font(tsUsuarios.Font, FontStyle.Bold);
                tsVenta.Font = new Font(tsVenta.Font, FontStyle.Bold);
                tsCaja.Font = new Font(tsCaja.Font, FontStyle.Bold);
                //tsCompra.Font = new Font(tsCompra.Font, FontStyle.Bold);
                tsConsulta.Font = new Font(tsConsulta.Font, FontStyle.Bold);
                tsMiCaja.Font = new Font(tsMiCaja.Font, FontStyle.Bold);




            }

        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            frmEmpleado emp = new frmEmpleado();
            emp.Inicio(Variables.clasePersonal.idPersonal);
            

        }

        private void tsConsulta_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1_Click(sender, e);
        }

        public void fnDatosCajaChica()
        {

        }

        public List<ReporteBloque> fnBuscarEgresos(Int32 tipoCon,Int32 numPagina)
        {

            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();
            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBusq.chkActivarDia = chkDiaEspecificoG.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value, 5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value, 5);
            clsBusq.cod1 = cboTipoReporte.Items.Count == 0 ? "0" : cboTipoReporte.SelectedValue.ToString();
            clsBusq.cod2 =  "0";
            clsBusq.cod3 = cboUsuario.SelectedValue is null ? "" + Variables.gnCodUser : cboUsuario.SelectedValue.ToString();
            clsBusq.cod4 = Convert.ToString(cboTipoPago.SelectedValue);
            clsBusq.cBuscar = txtBuscarRepGeneral.Text.ToString();
            clsBusq.numPagina = numPagina;
            clsBusq.tipoCon = tipoCon;
            if (Variables.gsCargoUsuario != "PETR0006" && verifApertura())
            {
                clsBusq.cod3 = "" + Variables.gnCodUser;
            }

            String cBuscar = txtBuscarRepGeneral.Text.ToString();
            Boolean chkHabilitarFechas = chkHabilitarFechasBusG.Checked;
            Boolean chkDiaEsp = chkDiaEspecificoG.Checked;

            Int32 filas = 10;
            return bl.blBuscarEgresos(clsBusq);
        }
        public void fnBuscardetalleEgresos(Int32 tipoCon, String CodRow,String codRowAux)
        {

            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();
            Busquedas clsBusq = new Busquedas();

            List<ReporteBloque> lstDetalle = new List<ReporteBloque>();
            clsBusq.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBusq.chkActivarDia = chkDiaEspecificoG.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value, 5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value, 5);
            clsBusq.cod1 = codRowAux;
            clsBusq.cod2 = CodRow;
            clsBusq.cod3 = cboUsuario.SelectedValue is null ? "" + Variables.gnCodUser : cboUsuario.SelectedValue.ToString();
            clsBusq.cod4 = Convert.ToString(cboTipoPago.SelectedValue);
            clsBusq.cBuscar = txtBuscarRepGeneral.Text.ToString();
            clsBusq.numPagina = 0;
            clsBusq.tipoCon = tipoCon;


            String cBuscar = txtBuscarRepGeneral.Text.ToString();
            Boolean chkHabilitarFechas = chkHabilitarFechasBusG.Checked;
            Boolean chkDiaEsp = chkDiaEspecificoG.Checked;

            Int32 filas = 10;
            lstDetalle =bl.blBuscarEgresos(clsBusq);
            if (tipoCon==1)
            {
                fnLlenarTablasEgresos( lstDetalle, dgvEgresos2);
            }else if (tipoCon==2)
            {
                lstMasDetalleReporte.Clear();
                fnLlenarTablasEgresos(lstDetalle, dgvEgresos3);
            }
        }

        private void fnLlenarTablasEgresos(List<ReporteBloque> lst, SiticoneDataGridView dgv)
        {
            lstMasDetalleReporte=lst;   
            dgv.Rows.Clear();
            
            
            Int32 y = 0;
            Int32 totalRows = lst.Count;
            if (dgv.Name== "dgvEgresos2")
            {
                dgv.Columns.Clear();
                dgv.Columns.Add("id", "id");
                dgv.Columns.Add("num", "N°");
                dgv.Columns.Add("detalle", "Detalle");
                dgv.Columns.Add("cantidad", "Cantidad");
                dgv.Columns.Add("Importe", "Importe");
                dgv.Columns.Add("codAux", "codAux");

                foreach (ReporteBloque item in lst)
                {
                    dgv.Rows.Add(item.Codigoreporte, y + 1, item.Detallereporte, item.Cantidad, FunGeneral.fnFormatearPrecioDC("S/", item.ImporteRow, 1),item.codAuxiliar1);
                    dgv.Rows[y].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv.Rows[y].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    y++;
                }
                dgv.Rows.Add("", "", "", "", "");
                dgv.Rows.Add("TOTAL", "", "IMPORTE TOTAL", "", FunGeneral.fnFormatearPrecioDC("S/.", lst.Sum(i => i.idMoneda == 2 ? (i.ImporteTipoCambio * i.ImporteRow) : i.ImporteRow), 0));
                dgv.Rows[y + 1].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Rows[y + 1].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv.Columns[0].Visible = false;
                dgv.Columns[5].Visible=false;
                dgv.Columns[1].Width = 10;
                dgv.Columns[2].Width = 100;
                dgv.Columns[3].Width = 20;
                dgv.Columns[4].Width = 100;
                dgv.Height = ((totalRows + 3) * (dgv.ThemeStyle.RowsStyle.Height + 2));
                dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                dgv.Rows[y + 1].DefaultCellStyle.ForeColor = Color.White;
                dgv.Rows[y + 1].DefaultCellStyle.BackColor = Color.FromArgb(192, 64, 0);
                dgv.Rows[y + 1].DefaultCellStyle.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
            }else if (dgv.Name == "dgvEgresos3")
            {
                dgv.Columns.Clear();
                dgv.Columns.Add("id", "id");
                dgv.Columns.Add("num", "N°");
                dgv.Columns.Add("Fuente", "Fuente");
                dgv.Columns.Add("detalle", "Detalle");
                dgv.Columns.Add("cantidad", "Cantidad");
                dgv.Columns.Add("Importe", "Importe");
                foreach (ReporteBloque item in lst)
                {
                    dgv.Rows.Add(item.Codigoreporte, y + 1,item.codAuxiliar, item.Detallereporte, item.Cantidad, FunGeneral.fnFormatearPrecioDC("S/", item.ImporteRow, 1), item.codAuxiliar1);
                    dgv.Rows[y].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv.Rows[y].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv.Rows[y].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    y++;
                }
                dgv.Rows.Add("", "","", "", "", "");
                dgv.Rows.Add("TOTAL", "", "IMPORTE", "TOTAL", "", FunGeneral.fnFormatearPrecioDC("S/.", lst.Sum(i => i.idMoneda == 2 ? (i.ImporteTipoCambio * i.ImporteRow) : i.ImporteRow), 0));
                dgv.Rows[y + 1].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Rows[y + 1].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Rows[y + 1].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Width = 10;
                dgv.Columns[2].Width = 40;
                dgv.Columns[3].Width = 100;
                dgv.Columns[4].Width = 20;
                dgv.Columns[5].Width = 100;
                dgv.Height = ((totalRows + 3) * (dgv.ThemeStyle.RowsStyle.Height + 2));
                dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                dgv.Rows[y + 1].DefaultCellStyle.ForeColor = Color.White;
                dgv.Rows[y + 1].DefaultCellStyle.BackColor = Color.FromArgb(192, 64, 0);
                dgv.Rows[y + 1].DefaultCellStyle.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
                //dgv.ThemeStyle.RowsStyle.Height = 40;
            }
            
            dgv.Visible = true;
        }
        public void fnBuscarReporteGeneralVentas(SiticoneDataGridView dgv, Int32 numPagina, Int32 tipoCon)
        {
            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();
            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBusq.chkActivarDia = chkDiaEspecificoG.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value, 5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value, 5);
            clsBusq.cod1 = cboTipoReporte.Items.Count == 0 ? "0" : cboTipoReporte.SelectedValue.ToString();
            clsBusq.cod2 = tipoCon == -1 ? cboFiltraIngresos.SelectedValue.ToString() : codOperacion;
            clsBusq.cod3 = cboUsuario.SelectedValue is null?""+Variables.gnCodUser: cboUsuario.SelectedValue.ToString();
            clsBusq.cod4 = cboFiltraIngresos.SelectedValue.ToString();
            clsBusq.cBuscar = txtBuscarRepGeneral.Text.ToString();
            clsBusq.numPagina = numPagina;
            clsBusq.tipoCon = tipoCon;

            String codTipoOperacion = "";

            Int32 TipoPlan = 0;
            Int32 tipotarifa = 0;

            String cBuscar = txtBuscarRepGeneral.Text.ToString();
            Boolean chkHabilitarFechas = chkHabilitarFechasBusG.Checked;
            Boolean chkDiaEsp = chkDiaEspecificoG.Checked;

            Int32 filas = 10;

            var result = bl.blBuscarDashBoard(clsBusq);
            lsReporteBloque = result.Item1;
            lsReporteBloqueEgresos = fnBuscarEgresos(0,0);
            
            lstCajaChica = result.Item2;
            fnGenerarPanelsIndividuales(lstCajaChica, FWpnCajaChicaCopias, "pnCCh");
            fnPosicionarAlCentrocajas(FWpnCajaChicaCopias, siticonePanel3);
            fnGenerarPaneles(FunGeneral.fnBuscarCajasDashboard(-1));
            


            fnDatosPNEspaciador();

            Int32 totalRows = lsReporteBloque.Count;

            siticoneDataGridView1.Visible = false;
            lblHeaderDetalle.Visible = false;
            dgvEmergente.Visible = false;

            Int32 y = 0;

            if (tipoCon == -1)
            {
                lsReporteBloqueGen = lsReporteBloque;
                fnGenerarTabla(dgv, lsReporteBloque.Count, lsReporteBloque);
                dgvEgresos3.Visible = false;
                dgvEgresos2.Visible = false;
                fnGenerarTabla(dgvEgresos, lsReporteBloqueEgresos.Count, lsReporteBloqueEgresos);

                if (chkDiaEsp == true)
                {
                    lstRepDetalleIngresosDAshboard.Clear();
                    lsReporteBloqueEgresosMontoEnCaja = fnBuscarEgresos(-1, 0);
                    //lsReporteBloqueEgresosMontoEnCaja.Clear();
                    lstRepDetalleIngresosDAshboard = fnBuscarDetalleParaCuadreDashboard();

                    Decimal MontoIngresos = lstRepDetalleIngresosDAshboard.Sum(i => i.ImporteRow);
                    Decimal MontoEgresos = lsReporteBloqueEgresosMontoEnCaja.Sum(i => i.ImporteRow);
                    Variables.lstCuardreCaja = FunGeneral.fnVerificarAperturaAnterior(Convert.ToDateTime(dtFechaInicioG.Value), Convert.ToInt32(cboUsuario.SelectedValue));

                    CuadreCaja lstApertura = Variables.lstCuardreCaja.Find(i => i.idOperacion == 1) is null ? new CuadreCaja() : Variables.lstCuardreCaja.Find(i => i.idOperacion == 1);

                    DAControlCaja dcc = new DAControlCaja();
                    List<CajaChica> lstCajaChic = new List<CajaChica>();
                    lstCajaChic= dcc.daObtenerImporteCaja(FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value, 5), FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 5), Convert.ToInt32(clsBusq.cod3));
                    btnMontoEnCaja.Text = "Importe en Caja: " + FunGeneral.fnFormatearPrecioDC("S/", lstCajaChic.Sum(i=>i.importe), 0);
                }
                

                //lblMontoTotalRepBloque.Text = FunGeneral.fnFormatearPrecioDC("S/.", lsReporteBloque.Sum(i => i.idMoneda == 2 ? (i.ImporteTipoCambio * i.ImporteRow) : i.ImporteRow), 0);

            }
            else if (tipoCon == -2)
            {
                ReporteBloque clsReporte = lsReporteBloqueGen.Find(i => i.Codigoreporte == codOperacion);
                dgv.Columns.Clear();
                dgv.Rows.Clear();
                dgv.Columns.Add("id", "id");
                dgv.Columns.Add("detalle", "Detalle de " + clsReporte.Detallereporte);
                dgv.Columns.Add("cantidad", "Cantidad");
                dgv.Columns.Add("Importe", "Importe");
                dgv.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                lblHeaderDetalle.Text = "Detalle de " + clsReporte.Detallereporte;
                lblHeaderDetalle.Visible = true;
                for (Int32 i = 0; i < totalRows; i++)
                {
                    ReporteBloque clsRep = lsReporteBloque[i];
                    dgv.Rows.Add(
                        clsRep.Codigoreporte,
                        clsRep.Detallereporte,
                        clsRep.Cantidad,
                        FunGeneral.fnFormatearPrecioDC(clsRep.SimboloMoneda, clsRep.ImporteRow, 0)
                        );
                    y += 1;
                    dgv.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv.Rows[i].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                dgv.Visible = true;


               
                dgv.Rows.Add("", "", "", "");
                dgv.Rows.Add("TOTAL", "IMPORTE TOTAL", "", FunGeneral.fnFormatearPrecioDC("S/.", lsReporteBloque.Sum(i => i.idMoneda == 2 ? (i.ImporteTipoCambio * i.ImporteRow) : i.ImporteRow), 0));
                dgv.Rows[y + 1].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Rows[y + 1].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Width = 100;
                dgv.Columns[2].Width = 20;
                dgv.Columns[3].Width = 100;
                dgv.ColumnHeadersVisible = false;


                dgv.Height = ((totalRows + 2) * (dgv.ThemeStyle.RowsStyle.Height + 2));
                dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                dgv.Rows[y + 1].DefaultCellStyle.ForeColor = Color.White;
                dgv.Rows[y + 1].DefaultCellStyle.BackColor = Color.Red;
                dgv.Rows[y + 1].DefaultCellStyle.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
            }


            //this.dgvListaPorBloque.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            fnLocationElementos();

        }

        private void fnGenerarTabla(SiticoneDataGridView dgv,Int32 totalRows,List<ReporteBloque>lstRep)
        {
            dgv.Columns.Clear();
            dgv.Rows.Clear();
            if (totalRows > 0)
            {
                dgv.Columns.Add("id", "id");
                dgv.Columns.Add("num", "N°");
                dgv.Columns.Add("detalle", "Detalle");
                dgv.Columns.Add("cantidad", "Cantidad");
                dgv.Columns.Add("Importe", "Importe");

                Int32 y = 0;

                for (Int32 i = 0; i < totalRows; i++)
                {
                    lstRep[i].numero = y + 1;
                    ReporteBloque clsRep = lstRep[i];
                    dgv.Rows.Add(
                        clsRep.Codigoreporte,
                        y + 1,
                        clsRep.Detallereporte,
                        clsRep.Cantidad,
                        FunGeneral.fnFormatearPrecioDC(clsRep.SimboloMoneda, clsRep.ImporteRow, 0)
                        );
                    y += 1;
                    dgv.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv.Rows[i].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                dgv.Rows.Add("", "", "", "", "");
                dgv.Rows.Add("TOTAL", "", "IMPORTE TOTAL", "", FunGeneral.fnFormatearPrecioDC("S/.", lstRep.Sum(i => i.idMoneda == 2 ? (i.ImporteTipoCambio * i.ImporteRow) : i.ImporteRow), 0));
                dgv.Rows[y + 1].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Rows[y + 1].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Width = 10;
                dgv.Columns[2].Width = 100;
                dgv.Columns[3].Width = 20;
                dgv.Columns[4].Width = 100;
                dgv.Height = ((totalRows + 3) * (dgv.ThemeStyle.RowsStyle.Height + 2));
                dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                dgv.Rows[y + 1].DefaultCellStyle.ForeColor = Color.White;
                dgv.Rows[y + 1].DefaultCellStyle.BackColor = Color.FromArgb(192, 64, 0);
                dgv.Rows[y + 1].DefaultCellStyle.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);

            }
            else
            {
                dgv.Columns.Clear();
                dgv.Columns.Add("id", "NO SE ENCONTRARON RESULTADOS PARA LA BUSQUEDA");
            }
        }
        private void fnLocationElementos()
        {
            Int32 espacios = 15;
            Int32 espaciosPequenos = 5;
            Int32 comparaAltoTablas = 0;
            Int32 comparaAltoTablasEgresos = 0;

            flowLayoutPanel1.Location= new Point(flowLayoutPanel1.Location.X, (FWpnCajaChicaCopias.Location.Y+ FWpnCajaChicaCopias.Height + espacios));
            siticoneGroupBox1.Location = new Point(siticoneGroupBox1.Location.X,(flowLayoutPanel1.Location.Y+ flowLayoutPanel1.Height)+espacios);
            siticonePanel3.Location = new Point(siticoneGroupBox1.Location.X, (siticoneGroupBox1.Location.Y + siticoneGroupBox1.Height) + espacios);

            lblIngresos.Size = new Size(siticonePanel3.Width - 20, 40);
            lblEgresos.Size = lblIngresos.Size;

            dgvListaPorBloque.Location = new Point(lblIngresos.Location.X, (lblIngresos.Location.Y+lblIngresos.Height )+ espacios);
            lblHeaderDetalle.Location = new Point(lblHeaderDetalle.Location.X, (lblIngresos.Location.Y+lblIngresos.Height) + espacios);
            siticoneDataGridView1.Location = new Point(siticoneDataGridView1.Location.X, (lblHeaderDetalle.Location.Y+lblHeaderDetalle.Height) + 5);
            comparaAltoTablas = dgvListaPorBloque.Height > (siticoneDataGridView1.Height+ lblHeaderDetalle.Height) ? dgvListaPorBloque.Height : (siticoneDataGridView1.Height+lblHeaderDetalle.Height);
            lblEgresos.Location = new Point(lblIngresos.Location.X, (dgvListaPorBloque.Location.Y+ comparaAltoTablas) +espacios);
            dgvEgresos.Location = new Point(lblIngresos.Location.X, (lblEgresos.Location.Y+ lblEgresos.Height)+ espacios);
            dgvEgresos2.Location = new Point(lblHeaderDetalle.Location.X, dgvEgresos.Location.Y);

            //btnRegistrarEgresos.Location = new Point(lblIngresos.Location.X, (dgvEgresos.Location.Y+ dgvEgresos.Height)+espacios);

            //btnMontoEnCaja.Location = new Point(btnMontoEnCaja.Location.X, btnRegistrarEgresos.Location.Y);
            comparaAltoTablasEgresos=dgvEgresos.Height>dgvEgresos2.Height?dgvEgresos.Height:dgvEgresos2.Height;    
            pnBotonera.Location = new Point(lblIngresos.Location.X,(dgvEgresos.Location.Y+ comparaAltoTablasEgresos)+espacios);

            siticonePanel3.Height = (dgvListaPorBloque.Height + dgvEmergente.Height+ lblEgresos.Height+ lblIngresos.Height+ comparaAltoTablasEgresos + pnBotonera.Height+dgvEgresos3.Height);
            


        }
        private IconPictureBox fngenerarIconos(ReporteBloque rpt)
        {
            IconPictureBox icono = new IconPictureBox();
            if (rpt.Codigoreporte == "00000001")
            {
                icono.IconChar = IconChar.LocationDot;
            }
            else if (rpt.Codigoreporte== "00000002")
            {
                icono.IconChar = IconChar.BoxesPacking;
            }
            else if (rpt.Codigoreporte == "00000003")
            {
                icono.IconChar = IconChar.RotateLeft;
            }
            else if (rpt.Codigoreporte== "00000004")
            {
                icono.IconChar = IconChar.ClockFour;

            }else if (rpt.Codigoreporte== "00000005")
            {
                icono.IconChar = IconChar.Viber;

            }else if (rpt.Codigoreporte  == "TEGR0002")
            {
                icono.IconChar = IconChar.FileClipboard;
            }else if (rpt.Codigoreporte == "TEGR0003")
            {
                icono.IconChar = IconChar.Vault;
            }
            return icono;
        }
        private void fnPosicionDeCajas()
        {
            flowLayoutPanel1.Location = new Point(((treeView1.Width / 2) - (flowLayoutPanel1.Width / 2)), FWpnCajaChicaCopias.Height + (pnlParaDashboard.AutoScrollPosition.Y));
        }
        private void fnPosicionarAlCentrocajas(FlowLayoutPanel pn, SiticonePanel pnPadre)
        {
            pn.Location = new Point(((pnPadre.Width / 2) - (pn.Width / 2)), pn.Location.Y);
        }
        private void fnGenerarPanelsIndividuales(List<ReporteBloque> lstBusq, FlowLayoutPanel stPanel ,String nombPn)
        {
            Color colorFondo = new Color();
            Color colorHeaderFooter = new Color();
            Color colorLetraHF = new Color();
            Color colorLetraBody = new Color();
            Color colorLetraIcono = new Color();
            FWpnCajaChicaCopias.Controls.Clear(); //Formulario 
            Int32 pnfW = 180;
            Int32 pnfH = 100;
            Int32 borderRadius = 10;
            Int32 tamLetraHF = 12;
            Int32 tamLetrasMensajes = 21;
            Double rextWFlow = 0.2;

            String strNomMensaje = "Versión de Pruebas";
            colorLetraHF = Color.Gainsboro;
            String tipoLetra = "Roboto";
            colorLetraBody = Color.Gainsboro;
            colorLetraIcono = fnDevolVerColorTransparente(85, Color.Black);
            colorHeaderFooter = fnDevolVerColorTransparente(150, Color.Black);
            //FWpnCajaChicaCopias.Width = pnlParaDashboard.Width;


            Label stLabel = new Label();
            stLabel.Text = strNomMensaje;
            stLabel.Font = new Font(tipoLetra, tamLetrasMensajes, GraphicsUnit.Pixel);
            stLabel.AutoSize = true;
            stLabel.ForeColor = Variables.ColorEmpresa;
            stLabel.BackColor = Color.Yellow;
            stLabel.Padding = new Padding(10);

           

            if (Variables.cNombreServidor!= "365.database.windows.net")
            {
                stpnMensajes.Controls.Clear();
                stpnMensajes.BackColor = ColorThemas.PanelPadre;
                stPanel.Controls.Add(stLabel);

                int ly = 7;
                for (int i = 0; i < 4; i++)
                {
                    Label stLabel1 = new Label();
                    stLabel1.Name = "lbln" + i;
                    stLabel1.Text = strNomMensaje;
                    stLabel1.Font = new Font(tipoLetra, tamLetrasMensajes, GraphicsUnit.Pixel);
                    stLabel1.AutoSize = true;
                    stLabel1.ForeColor = Variables.ColorEmpresa;
                    stLabel1.BackColor = Color.Yellow;
                    stLabel1.Padding = new Padding(10);
                   
                    stLabel1.Location = new Point(stLabel1.Location.X,ly);
                    stpnMensajes.Controls.Add(stLabel1);
                    ly +=stLabel1.Height+ 10;
                }
                stpnMensajes.Visible = true;
                stpnMensajes.Dock =  DockStyle.Fill;
            }
            //stPanel.Controls.Add(stLabel);

            for (int i = 0; i < lstBusq.Count; i++)
            {
                ReporteBloque rpt = lstBusq[i];
                if (lstBusq[i].Codigoreporte == "TEGR0002")
                {
                    colorFondo = Color.FromArgb(105, 105, 105);
                }
                else if (lstBusq[i].Codigoreporte == "TEGR0003")
                {
                    colorFondo = Color.FromArgb(38, 95, 102);
                }

                //Panel princilal
                SiticonePanel panelFondo = new SiticonePanel();
                panelFondo.Name = "panel" + i;
                panelFondo.Size = new Size(pnfW, pnfH);
                //panelFondo.BorderRadius =borderRadius;
                panelFondo.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                panelFondo.BackColor = Color.Transparent;
                panelFondo.FillColor = colorFondo;



                // Establece la región del control utilizando el objeto GraphicsPath
                panelFondo.Region = new System.Drawing.Region(fnRedondearBordes(panelFondo.Width, panelFondo.Height, borderRadius));



                SiticonePanel panel = new SiticonePanel();
                panel.Name = "panel" + i;
                //panel.Size = new Size(panelFondo.Width, panelFondo.Height);
                panel.Size = new Size(pnfW + 1, pnfH);
                ////panel.BorderRadius = borderRadius;
                panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                panel.BackColor = Color.Transparent;
                panel.FillColor = colorHeaderFooter;
                panel.Location = new Point(0, 0);
                panelFondo.Controls.Add(panel);

                // panel Header
                SiticonePanel pnHead = new SiticonePanel();
                pnHead.Name = "pnHead" + i;
                pnHead.Size = new Size(panel.Width, (panel.Height / 2) / 2);
                pnHead.BackColor = Color.Transparent;
                pnHead.FillColor = colorFondo;
                pnHead.Location = new Point(0, 0);
                //pnHead.Padding = new Padding(0, 0, 0, 0);
                //pnHead.BorderRadius = borderRadius;


                SiticoneHtmlLabel lblH = new SiticoneHtmlLabel();
                lblH.Name = "lblHeader" + i;
                lblH.AutoSize = false;
                lblH.Size = new Size(pnHead.Width, pnHead.Height);
                //lblH.BackColor = Color.Red;
                lblH.Location = new Point(0, 1);
                lblH.Text = "Tipo Concepto";
                lblH.TextAlignment = ContentAlignment.MiddleCenter;
                lblH.Font = new Font(tipoLetra, tamLetraHF, GraphicsUnit.Pixel);
                //lblH.Font = new Font(lblH.Font, FontStyle.Bold);

                lblH.ForeColor = Color.Gainsboro;
                pnHead.Controls.Add(lblH);
                panel.Controls.Add(pnHead);

                //Panel Izquierdo
                SiticonePanel pnIzquierdo = new SiticonePanel();
                pnIzquierdo.Name = "pnIzquierdo" + i;
                pnIzquierdo.Size = new Size(panel.Width / 2, panel.Height - (pnHead.Height * 2));
                pnIzquierdo.Location = new Point(0, pnHead.Height);
                pnIzquierdo.FillColor = colorFondo;

                SiticoneHtmlLabel lblIzq = new SiticoneHtmlLabel();
                lblIzq.Name = "lblIzquierdo" + i;
                lblIzq.AutoSize = false;
                lblIzq.Size = pnIzquierdo.Size;
                lblIzq.Location = new Point(0, 0);
                lblIzq.Text = FunGeneral.FormatearCadenaTitleCase(lstBusq[i].Detallereporte);
                lblIzq.TextAlignment = ContentAlignment.MiddleCenter;
                lblIzq.Font = new Font(tipoLetra, 10F);
                lblIzq.ForeColor = colorLetraBody;
                lblIzq.Tag = lstBusq[i].Codigoreporte;
                lblIzq.Font = new Font(lblIzq.Font, FontStyle.Bold);
                pnIzquierdo.Controls.Add(lblIzq);

                panel.Controls.Add(pnIzquierdo);
                //Panel Derecho
                SiticonePanel pnDerecho = new SiticonePanel();
                pnDerecho.Name = "pnDerecho" + i;
                pnDerecho.BackColor = colorFondo;
                pnDerecho.Size = pnIzquierdo.Size;
                pnDerecho.Location = new Point(panel.Width / 2, pnHead.Height);
                pnDerecho.Tag = lstBusq[i].Codigoreporte;

                IconPictureBox icon = fngenerarIconos(rpt);
                icon.Size = new Size(pnDerecho.Width - 18, pnDerecho.Height - 18);
                icon.Location = new Point((pnDerecho.Width / 3), 1);
                icon.ForeColor = colorLetraIcono;
                icon.Dock = DockStyle.Fill;
                //icon.SizeMode = PictureBoxSizeMode.AutoSize;
                icon.Padding = new Padding(icon.Width / 3, 0, 0, 0);
                pnDerecho.Controls.Add(icon);

                panel.Controls.Add(pnDerecho);

                //Panel Footer
                SiticonePanel pnFooter = new SiticonePanel();
                pnFooter.Name = "pnFooter" + i;
                //pnFooter.BackColor = colorHeader;
                pnFooter.Size = new Size(panel.Width, (panel.Height / 2) / 2);
                pnFooter.Location = new Point(0, pnDerecho.Height + pnHead.Height);
                pnFooter.Tag = lstBusq[i].Codigoreporte;
                pnFooter.Cursor = System.Windows.Forms.Cursors.Hand;

                SiticoneHtmlLabel lblF = new SiticoneHtmlLabel();
                lblF.Name = "lblFooter" + i;
                lblF.AutoSize = false;
                lblF.Size = pnFooter.Size;
                lblF.Location = new Point(0, 0);
                lblF.Text = "Importe: " + FunGeneral.fnFormatearPrecioDC("S/.", lstBusq[i].ImporteRow, 0);
                lblF.Tag = lstBusq[i].Codigoreporte;
                //lblF.BackColor = "Dark"+ color;
                lblF.TextAlignment = ContentAlignment.MiddleCenter;
                lblF.Font = new Font(tipoLetra, tamLetraHF, GraphicsUnit.Pixel);

                lblF.ForeColor = colorLetraHF;
                lblF.Cursor = System.Windows.Forms.Cursors.Hand;
                pnFooter.Controls.Add(lblF);

                panelFondo.Click += MiBoton_Click;
                pnHead.Click += MiBoton_Click;
                lblH.Click += MiBoton_Click;
                pnIzquierdo.Click += MiBoton_Click;
                lblIzq.Click += MiBoton_Click;
                pnDerecho.Click += MiBoton_Click;
                icon.Click += MiBoton_Click;
                pnFooter.Click += MiBoton_Click;
                lblF.Click += MiBoton_Click;
                panel.Click += MiBoton_Click;
                panel.Controls.Add(pnFooter);

                stPanel.Controls.Add(panelFondo);
                stPanel.Padding = new Padding(0, 0, 0, 0);
            }

            Label stLabel2 = new Label();
            stLabel2.Text = strNomMensaje;
            stLabel2.Font = new Font(tipoLetra, tamLetrasMensajes, GraphicsUnit.Pixel);
            stLabel2.AutoSize = true;
            stLabel2.ForeColor = Variables.ColorEmpresa;
            stLabel2.BackColor = Color.Yellow;
            stLabel2.Padding = new Padding(10);

            if (Variables.cNombreServidor != "365.database.windows.net")
            {
                stPanel.Controls.Add(stLabel2);
            }

            FWpnCajaChicaCopias.BorderStyle = System.Windows.Forms.BorderStyle.None;

            int totalWidth = 0;
            int totalHeight = 0;
            foreach (System.Windows.Forms.Control control in FWpnCajaChicaCopias.Controls)
            {
                totalWidth += control.Width;
                if (totalHeight < control.Height)
                {
                    totalHeight = control.Height;
                }
            }
            stPanel.Padding = new Padding(0, 0, 0, 0);
            if (stPanel.VerticalScroll.Visible == true)
            {
                stPanel.Width = totalWidth + 30;
            }
            else
            {
                stPanel.Width = totalWidth + 15;

            }
            stPanel.Height = totalHeight + 20;




        }

        private void MiBoton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
            String nombre = "";
            if (control != null)
            {
                Type controlType = control.GetType();
                if (controlType == typeof(SiticoneHtmlLabel))
                {
                    SiticoneHtmlLabel label = (SiticoneHtmlLabel) control;
                    nombre=label.Tag.ToString();
                    // Código a ejecutar cuando se hace clic en un SiticoneHtmlLabel
                }
                else if (controlType == typeof(IconPictureBox))
                {
                    FontAwesome.Sharp.IconPictureBox iconChar = (FontAwesome.Sharp.IconPictureBox)control;
                    nombre = iconChar.Tag.ToString();
                    // Código a ejecutar cuando se hace clic en un Button
                }
                else if (controlType == typeof(SiticonePanel))
                {
                    SiticonePanel panel = (SiticonePanel)control;
                    nombre = panel.Tag.ToString();
                    // Código a ejecutar cuando se hace clic en un Panel
                }

                fnAbrirFormularios(nombre);


            }

        }
        private void fnAbrirFormularios(string codigo)
        {
            
            if (codigo== "00000001")
            {
                frmInstalacionEquipo frm=new frmInstalacionEquipo();
                frm.Show();
            }else if (codigo == "00000002")
            {
                if (Variables.gsCargoUsuario== "PETR0007" || Variables.gsCargoUsuario== "PETR0005")
                {
                    frmEquipoImeis frm =new frmEquipoImeis();
                    frm.Show();
                }

            }else if (codigo == "00000003")
            {
                frmRegistrarVenta frm = new frmRegistrarVenta();
                frm.Show();
            }
            else if (codigo == "00000004")
            {
                frmPagosPendientes frm = new frmPagosPendientes();
                frm.Show();
            }else if (codigo == "00000005")
            {
                frmSeguimiento frm = new frmSeguimiento();
                frm.Inicio(1);
            }
        }

        private System.Drawing.Drawing2D.GraphicsPath fnRedondearBordes(Int32 width, Int32 height, Int32 borderRadius)
        {
            int borderWidth = 1;

            // Calcula el tamaño y la posición del rectángulo interno
            Rectangle innerRect = new Rectangle(borderWidth, borderWidth, width - 2 * borderWidth, height - 2 * borderWidth);

            // Crea el objeto GraphicsPath para la forma redondeada
            System.Drawing.Drawing2D.GraphicsPath roundedPath = new System.Drawing.Drawing2D.GraphicsPath();
            roundedPath.AddArc(innerRect.X, innerRect.Y, borderRadius, borderRadius, 180, 90); // Esquina superior izquierda
            roundedPath.AddArc(innerRect.Right - borderRadius, innerRect.Y, borderRadius, borderRadius, 270, 90); // Esquina superior derecha
            roundedPath.AddArc(innerRect.Right - borderRadius, innerRect.Bottom - borderRadius, borderRadius, borderRadius, 0, 90); // Esquina inferior derecha
            roundedPath.AddArc(innerRect.X, innerRect.Bottom - borderRadius, borderRadius, borderRadius, 90, 90); // Esquina inferior izquierda
            roundedPath.CloseFigure();
            return roundedPath;

        }
        private void fnGenerarPaneles(List<ReporteBloque> lstBusq)
        {
            Color colorFondo = new Color();
            Color colorHeaderFooter = new Color();
            Color colorLetraHF = new Color();
            Color colorLetraBody = new Color();
            Color colorLetraIcono = new Color();
            flowLayoutPanel1.Controls.Clear();
            Int32 pnfW = 180;
            Int32 pnfH = 110;
            Int32 borderRadius = 10;
            Int32 tamLetraHF = 12;
            Double rextWFlow = 0.2;
            colorLetraHF = Color.Gainsboro;
            String tipoLetra = "Roboto";
            colorLetraBody = Color.Gainsboro;
            colorLetraIcono = fnDevolVerColorTransparente(85, Color.Black);
            colorHeaderFooter = fnDevolVerColorTransparente(110, Color.Black);
            pnlParaDashboard.Location = new Point(pnlParaDashboard.Location.X,0); ;
            flowLayoutPanel1.AutoScroll = false;
            if (lstBusq.Count<=6)
            {
                flowLayoutPanel1.Width= (int)((lstBusq.Count+ rextWFlow) * pnfW);
            }
            else
            {
                flowLayoutPanel1.Width = pnlParaDashboard.Size.Width - 17;
            }
            fnPosicionDeCajas();
            siticoneGroupBox1.Width = pnlParaDashboard.Size.Width - 30;           

            Int32 residuo;
            Int32 cantidadPaginas;
            Int32 filas=6;
            Int32 totalRegistros = lstBusq.Count;
            residuo = totalRegistros % filas;
            if (residuo == 0)
            {
                cantidadPaginas = (totalRegistros / filas);
            }
            else
            {
                cantidadPaginas = (totalRegistros / filas) + 1;
            }

            flowLayoutPanel1.Height = (int)((cantidadPaginas+ rextWFlow) * pnfH );
            siticoneGroupBox1.Location = new Point(siticoneGroupBox1.Location.X, flowLayoutPanel1.Location.Y + flowLayoutPanel1.Height);
            //siticoneGroupBox1.Location = new Point(siticoneGroupBox1.Location.X, flowLayoutPanel1.Height+20);
            siticonePanel3.Location = new Point(siticonePanel3.Location.X, (siticoneGroupBox1.Height+ siticoneGroupBox1.Location.Y));

            for (Int32 i = 0; i < lstBusq.Count; i++)
            {
                ReporteBloque rpt = lstBusq[i];
                if (lstBusq[i].Codigoreporte == "00000003")
                {
                    colorFondo = Color.FromArgb(161, 20, 1);
                }
                else if (lstBusq[i].Codigoreporte == "00000002")
                {
                    colorFondo = Color.FromArgb(0, 126, 63);
                }
                else if (lstBusq[i].Codigoreporte == "00000001")
                {
                    colorFondo = Color.FromArgb(131, 56, 236);
                }
                else if (lstBusq[i].Codigoreporte == "00000004")
                {
                    colorFondo = Color.FromArgb(173, 115, 17);
                }else if (lstBusq[i].Codigoreporte == "00000005")
                {
                    colorFondo = Color.FromArgb(134, 27, 45);
                }
                else 
                { 
                    
                    if (lstBusq[i].Cantidad <= 1)
                    {
                        colorFondo = Color.FromArgb(161, 20, 1);
                    }
                    else if (lstBusq[i].Cantidad >= 1 && lstBusq[i].Cantidad < 5)
                    {
                        colorFondo = Color.FromArgb(228, 163, 0);
                    }
                    else if (lstBusq[i].Cantidad >= 5 && lstBusq[i].Cantidad < 8)
                    {

                        colorFondo = Color.FromArgb(173, 115, 17);
                    }
                    else if (lstBusq[i].Cantidad >= 8 && lstBusq[i].Cantidad < 12)
                    {
                        colorFondo = Color.FromArgb(1, 139, 211);
                    }
                    else if (lstBusq[i].Cantidad >= 12)
                    {
                        colorFondo = Color.FromArgb(0, 126, 63);
                    }
                }
                
                
                //Panel princilal
                SiticonePanel panelFondo = new SiticonePanel();
                panelFondo.Name = "panel" + i;
                panelFondo.Size = new Size(pnfW, pnfH);
                //panelFondo.BorderRadius =borderRadius;
                panelFondo.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                panelFondo.BackColor = Color.Transparent;
                panelFondo.FillColor = colorFondo;
                panelFondo.Tag = lstBusq[i].Codigoreporte;



                // Establece la región del control utilizando el objeto GraphicsPath
                panelFondo.Region = new System.Drawing.Region(fnRedondearBordes(panelFondo.Width, panelFondo.Height,borderRadius));



                SiticonePanel panel = new SiticonePanel();
                panel.Name = "panel" + i;
                //panel.Size = new Size(panelFondo.Width, panelFondo.Height);
                panel.Size = new Size(pnfW+1, pnfH);
                ////panel.BorderRadius = borderRadius;
                panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                panel.BackColor = Color.Transparent;
                panel.FillColor = colorHeaderFooter;
                panel.Location = new Point(0, 0);
                panel.Tag = lstBusq[i].Codigoreporte;
                panelFondo.Controls.Add(panel);

                // panel Header
                SiticonePanel pnHead = new SiticonePanel();
                pnHead.Name = "pnHead" + i;
                pnHead.Size = new Size(panel.Width, (panel.Height/2)/2);
                pnHead.BackColor = Color.Transparent;
                pnHead.FillColor = colorFondo;
                pnHead.Location = new Point(0, 0);
                pnHead.Tag = lstBusq[i].Codigoreporte;
                //pnHead.Padding = new Padding(0, 0, 0, 0);
                //pnHead.BorderRadius = borderRadius;


                SiticoneHtmlLabel lblH = new SiticoneHtmlLabel();
                lblH.Name = "lblHeader" + i;
                lblH.AutoSize = false;
                lblH.Size = new Size(pnHead.Width, pnHead.Height);
                //lblH.BackColor = Color.Red;
                lblH.Location = new Point(0, 1);
                lblH.Text = FunGeneral.FormatearCadenaTitleCase(lstBusq[i].Detallereporte);
                lblH.TextAlignment = ContentAlignment.MiddleCenter;
                lblH.Tag = lstBusq[i].Codigoreporte;
                lblH.Font = new Font(tipoLetra, tamLetraHF, GraphicsUnit.Pixel);
                //lblH.Font = new Font(lblH.Font, FontStyle.Bold);

                lblH.ForeColor = Color.Gainsboro;
                pnHead.Controls.Add(lblH);
                panel.Controls.Add(pnHead);

                //Panel Izquierdo
                SiticonePanel pnIzquierdo = new SiticonePanel();
                pnIzquierdo.Name = "pnIzquierdo" + i;
                pnIzquierdo.Size = new Size(panel.Width/2, panel.Height- (pnHead.Height * 2));
                pnIzquierdo.Location = new Point(0, pnHead.Height);
                pnIzquierdo.FillColor = colorFondo;
                pnIzquierdo.Tag = lstBusq[i].Codigoreporte;


                SiticoneHtmlLabel lblIzq = new SiticoneHtmlLabel();
                lblIzq.Name = "lbl" + lstBusq[i].Codigoreporte;
                lblIzq.AutoSize = false;
                lblIzq.Size = pnIzquierdo.Size;
                lblIzq.Location = new Point(0, 0);
                lblIzq.Text = "" + lstBusq[i].Cantidad;
                lblIzq.TextAlignment = ContentAlignment.MiddleCenter;
                lblIzq.Font = new Font(tipoLetra, 18F);
                lblIzq.ForeColor = colorLetraBody;
                lblIzq.Tag = lstBusq[i].Codigoreporte;
                lblIzq.Font = new Font(lblIzq.Font, FontStyle.Bold);
                pnIzquierdo.Controls.Add(lblIzq);

                panel.Controls.Add(pnIzquierdo);
                //Panel Derecho
                SiticonePanel pnDerecho = new SiticonePanel();
                pnDerecho.Name = "pnDerecho" + i;
                pnDerecho.BackColor = colorFondo;
                pnDerecho.Size = pnIzquierdo.Size;
                pnDerecho.Location = new Point(panel.Width / 2, pnHead.Height);
                pnDerecho.Tag = lstBusq[i].Codigoreporte;

                IconPictureBox icon = fngenerarIconos(rpt);
                icon.Size = new Size(pnDerecho.Width-18, pnDerecho.Height-18);
                icon.Location = new Point((pnDerecho.Width/3), 1);
                //icon.BackColor = Color.Green;
                icon.ForeColor = colorLetraIcono;
                icon.Dock = DockStyle.Fill;
                icon.Tag = lstBusq[i].Codigoreporte;
                //icon.SizeMode = PictureBoxSizeMode.AutoSize;
                //icon.Padding = new Padding(icon.Width/3, 0, 0, 0);
                pnDerecho.Controls.Add(icon);

                panel.Controls.Add(pnDerecho);

                //Panel Footer
                SiticonePanel pnFooter = new SiticonePanel();
                pnFooter.Name = "pnFooter" + i;
                //pnFooter.BackColor = colorHeader;
                pnFooter.Size = new Size(panel.Width, (panel.Height / 2) / 2);
                pnFooter.Location = new Point(0, pnDerecho.Height+pnHead.Height);
                pnFooter.Tag = lstBusq[i].Codigoreporte;
                pnFooter.Cursor= System.Windows.Forms.Cursors.Hand;

                SiticoneHtmlLabel lblF = new SiticoneHtmlLabel();
                lblF.Name = "lblFooter" + i;
                lblF.AutoSize = false;
                lblF.Size = pnFooter.Size;
                lblF.Location = new Point(0, 0);
                lblF.Text = lstBusq[i].MasDetallereporte;
                lblF.Tag = lstBusq[i].Codigoreporte;
                //lblF.BackColor = "Dark"+ color;
                lblF.TextAlignment = ContentAlignment.MiddleCenter;
                lblF.Font = new Font(tipoLetra, tamLetraHF, GraphicsUnit.Pixel);
               
                lblF.ForeColor = colorLetraHF;
                lblF.Cursor = System.Windows.Forms.Cursors.Hand;
                pnFooter.Controls.Add(lblF);

                panelFondo.Click += MiBoton_Click;
                pnHead.Click += MiBoton_Click;
                lblH.Click += MiBoton_Click;
                pnIzquierdo.Click += MiBoton_Click;
                lblIzq.Click += MiBoton_Click;
                pnDerecho.Click += MiBoton_Click;
                icon.Click += MiBoton_Click;
                pnFooter.Click += MiBoton_Click;
                lblF.Click += MiBoton_Click;
                panel.Click += MiBoton_Click;
                panel.Controls.Add(pnFooter);
                panel.Controls.Add(pnFooter);

                flowLayoutPanel1.Controls.Add(panelFondo);
                flowLayoutPanel1.Padding = new Padding(0,10,0,0);
            }
        }

        private void dgvListaPorBloque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codTipoReporte = cboTipoReporte.SelectedValue.ToString();
            codOperacion = dgvListaPorBloque.CurrentRow.Cells[0].Value.ToString();

            dgvEmergente.Visible = false;
            if (codOperacion == "" || codOperacion == "TOTAL")
            {

            }
            else
            {
                if (codTipoReporte == "TRPT0001" || codTipoReporte == "TRPT0002")
                {
                    fnBuscarReporteGeneralVentas(siticoneDataGridView1, 0, -2);

                }
                else
                {
                    ReporteBloque clsReporte = lsReporteBloqueGen.Find(i => i.Codigoreporte == codOperacion);
                    lblHeaderDetalle.Text = "Detalle de " + clsReporte.Detallereporte;
                    lblHeaderDetalle.Visible = true;
                    fnBuscarDatosTablaEmergente(dgvEmergente, codOperacion);
                    dgvEmergente.Width = siticoneDataGridView1.Width;
                    dgvEmergente.Location = siticoneDataGridView1.Location;

                }
                //Int32 x = dgvListaPorBloque.GetCellDisplayRectangle(e.RowIndex==0?1: e.RowIndex, e.ColumnIndex, false).Right;
                Int32 y = dgvListaPorBloque.GetRowDisplayRectangle(e.RowIndex, false).Y;
                //siticoneDataGridView1.Location = new Point(dgvListaPorBloque.Right + 15, y + 2);
                pbIndica.Location = new Point(dgvListaPorBloque.Right + 15, y +60);
                pbIndica.Visible = true;
            }

        }

        private void fnBuscarDatosTablaEmergente(SiticoneDataGridView dgv, String codSubReporte)
        {

            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();
            Busquedas clsBus = new Busquedas();
            List<ReporteBloque> lstRep = new List<ReporteBloque>();

            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBusq.chkActivarDia = chkDiaEspecificoG.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value, 5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value, 5);
            clsBusq.cod1 = cboTipoReporte.Items.Count == 0 ? "0" : cboTipoReporte.SelectedValue.ToString();
            clsBusq.cod2 = codOperacion;
            clsBusq.cod3 = cboUsuario.SelectedValue.ToString();
            clsBusq.cod4 = codSubReporte;
            clsBusq.cBuscar = txtBuscarRepGeneral.Text.ToString();
            clsBusq.numPagina = Convert.ToInt32(cboFiltraIngresos.SelectedValue.ToString());
            clsBusq.tipoCon = -3;

            var result = bl.BuscarReporteGeneralVentas(clsBusq);
            lstRep = result.Item2;
            dgv.Visible = false;
            dgv.Columns.Clear();
            dgv.Rows.Clear();
            ReporteBloque clsReporte = lsReporteBloque.Find(i => i.Codigoreporte == codSubReporte);
            dgv.Columns.Add("id", "id");
            dgv.Columns.Add("detalle", "Detalle de ");
            dgv.Columns.Add("cantidad", "Cantidad");
            dgv.Columns.Add("Importe", "Importe");
            dgv.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.None;
            //lblHeaderDetalle.Text = "Detalle de " + clsReporte.Detallereporte;
            lblHeaderDetalle.Visible = true;
            Int32 y = 0;
            //if (clsBusq.numPagina == 0)
            //{
            //    y = 0;
            //}
            //else
            //{
            //    tabInicio = (clsBusq.numPagina - 1) * 20;
            //    y = tabInicio;
            //}
            for (Int32 i = 0; i < lstRep.Count; i++)
            {
                ReporteBloque clsRep = lstRep[i];
                dgv.Rows.Add(
                    clsRep.Codigoreporte,
                   clsRep.Detallereporte,
                    clsRep.Cantidad,
                    FunGeneral.fnFormatearPrecioDC(clsRep.SimboloMoneda, clsRep.ImporteRow, 0)
                    );
                y += 1;
                dgv.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Rows[i].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.Rows[i].Cells[1].Style.Padding = new Padding(30, 0, 0, 0);
            }
            dgv.Visible = true;

            dgv.Rows.Add("", "", "", "");
            dgv.Rows.Add("TOTAL", "IMPORTE TOTAL DE " + clsReporte.Detallereporte, "", FunGeneral.fnFormatearPrecioDC("S/.", lstRep.Sum(i => i.idMoneda == 2 ? (i.ImporteTipoCambio * i.ImporteRow) : i.ImporteRow), 0));
            dgv.Rows[y + 1].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Rows[y + 1].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].Width = 20;
            dgv.Columns[3].Width = 70;
            dgv.ColumnHeadersVisible = false;


            dgv.Height = ((lstRep.Count + 2) * (dgv.ThemeStyle.RowsStyle.Height + 1));
            dgv.Rows[y + 1].DefaultCellStyle.ForeColor = Color.White;
            dgv.Rows[y + 1].DefaultCellStyle.BackColor = Color.DarkRed;
            dgv.Rows[y + 1].Cells[1].Style.Padding = new Padding(30, 0, 0, 0);
            dgv.Rows[y + 1].DefaultCellStyle.Font = new Font("Roboto", 10F, GraphicsUnit.Pixel);

            fnLocationElementos();


        }
        private Color fnDevolVerColorTransparente(Int32 alfa, Color colr)
        {
            return Color.FromArgb(alfa, colr);
        }

        private void chkHabilitarFechasBusG_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechasBusG.Checked == true)
            {
                gbHabilitarBusqFechas.Enabled = true;
                chkDiaEspecificoG.Visible = true;
            }
            else
            {
                gbHabilitarBusqFechas.Enabled = false;
                chkDiaEspecificoG.Visible = false;
                chkDiaEspecificoG.Checked = false;
            }
        }

        private void chkDiaEspecificoG_CheckedChanged(object sender, EventArgs e)
        {
            fnValidarBusquedaDia();
        }
        private void fnValidarBusquedaDia()
        {
            if (chkDiaEspecificoG.Checked == true)
            {
                lblFechaFinal.Visible = false;
                dtFechaFinG.Visible = false;
                lblFechaInicial.Text = "Elija el dia para buscar:";
                btnMontoEnCaja.Visible = true;
                dtFechaInicioG.Value = Variables.gdFechaSis;
            }
            else
            {
                lblFechaFinal.Visible = true;
                dtFechaFinG.Visible = true;
                lblFechaInicial.Text = "Fecha Inicio:";
                btnMontoEnCaja.Visible = false;
                dtFechaInicioG.Value = dtFechaFinG.Value.AddDays(-(dtFechaFinG.Value.Day - 1));
            }
        }

        private void cboTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbIndica.Visible = false;
            String CodOperacion = cboTipoReporte.SelectedValue.ToString();
           
            //fnBuscarReporteGeneralVentas(dgvListaPorBloque, 0, -1);
        }

        public void fnLlenarUsuariosConAccion(SiticoneComboBox cbo, SiticoneDateTimePicker dtIni, SiticoneDateTimePicker dtFin, Boolean estado)
        {
            DAControlCaja dc = new DAControlCaja();
            List<Usuario> lstUsuario = new List<Usuario>();
            DataTable dt = new DataTable();
            String FI = FunGeneral.GetFechaHoraFormato(dtIni.Value, 5);
            String FF = FunGeneral.GetFechaHoraFormato(dtFin.Value, 5);
            Boolean chk = chkDiaEspecificoG.Checked;
            Int32 tipCOn = Variables.gsCargoUsuario != "PETR0006" ? 0 : Variables.gnCodUser;

            dt = dc.daDevolverSoloUsuario(chk, FI, FF, tipCOn);

            lstUsuario.Add(new Usuario(
                Convert.ToInt32(0),
                Convert.ToString(estado ? "TODOS" : "Selecc. Usuario")
              ));

            foreach (DataRow drMenu in dt.Rows)
            {
                lstUsuario.Add(new Usuario(
                    Convert.ToInt32(drMenu["idUsuario"]),
                    Convert.ToString(drMenu["cUser"])
                    ));
            }
            cbo.ValueMember = "idUsuario";
            cbo.DisplayMember = "cUser";
            cbo.DataSource = lstUsuario;
           cbo.SelectedValue = Variables.gsCargoUsuario != "PETR0006" ? 0 : Variables.gnCodUser;


        }

        private void dtFechaFinG_ValueChanged(object sender, EventArgs e)
        {
            fnLlenarUsuariosConAccion(cboUsuario, dtFechaInicioG, dtFechaFinG, true);
        }

        private void dtFechaInicioG_ValueChanged(object sender, EventArgs e)
        {
            fnLlenarUsuariosConAccion(cboUsuario, dtFechaInicioG, dtFechaFinG, true);
        }

        private void cboOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fnBuscarReporteGeneralVentas(dgvListaPorBloque, 0, -1);
        }

        private void txtBuscarRepGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                lsReporteBloqueEgresosMontoEnCaja.Clear();
                fnBuscarReporteGeneralVentas(dgvListaPorBloque, 0, -1);

               
                
            }
        }

        private void dgvListaPorBloque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvEmergente.Visible = false;
        }

        private void siticoneDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvEmergente.Visible = false;
        }

        private void siticoneDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String codSubReporte = siticoneDataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (codSubReporte == "" || codSubReporte == "TOTAL")
            {

            }
            else
            {
                Int32 x = siticoneDataGridView1.Left + 50;
                Int32 y = siticoneDataGridView1.GetRowDisplayRectangle(e.RowIndex, false).Y;
                dgvEmergente.Location = new Point(x, y + 120);
                dgvEmergente.Width = siticoneDataGridView1.Width - 50;
                fnBuscarDatosTablaEmergente(dgvEmergente, codSubReporte);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fnBuscarReporteGeneralVentas(dgvListaPorBloque, 0, -1);
           
        }
        static Boolean estadoActivarDashBoard = false;
        public void fnCambiarEstado(Boolean est)
        {
            estadoActivarDashBoard = est;
            
        }

        public static UdpClient IsUdpPortInUse(int port)
        {
            bool inUse = false;

            // Crear UdpClient con la dirección IP y el número de puerto
            UdpClient udpClient = new UdpClient() ;
            try
            {
                udpClient = new UdpClient(port);
                inUse = false;
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.AddressAlreadyInUse)
                {
                    int min = 49152;
                    int max = 65534;
                    Random random = new Random();
                    int randomNumber = random.Next(min, max + 1);
                    udpClient = new UdpClient(randomNumber);
                    inUse = true;
                }
            }
            finally
            {
                //if (udpClient != null)
                //{
                //    udpClient.Close();
                //}
            }

            return udpClient;
        }
        public void fnEscucharAlertasDasboard()
        {
            UdpClient udpClient = IsUdpPortInUse(1222);

            // Cree un objeto de extremo de red que represente la dirección de difusión de su red
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

            // Inicie un subproceso separado para escuchar los mensajes
            Thread receiveThread = new Thread(() =>
            {
                while (true)
                {
                    // Espere a recibir un mensaje
                    byte[] data = udpClient.Receive(ref endPoint);

                    // Convierta los datos en una cadena y muestre el mensaje
                    //string message = Encoding.ASCII.GetString(data);
                    string message = Encoding.UTF8.GetString(data);
                    string[] datos = message.Split(':');
                    bool enviadoPorMi = datos[0] == Variables.clasePersonal.cPrimerNom;
                    datosMessage = datos;
                    //if (datos[0].ToString()== "lbl00000005")
                    //{
                    //    btnAlertaSeguimiento.Text = datos[1];
                    //}
                    SiticonePanel siticonePanel = new SiticonePanel();

                    flowLayoutPanel1.Invoke((MethodInvoker)delegate {
                        SiticoneHtmlLabel lblPasar = new SiticoneHtmlLabel();
                        Boolean estado = false;
                        var ControlPanel = flowLayoutPanel1.Controls.OfType<SiticonePanel>();
                        foreach (SiticonePanel png in ControlPanel)
                        {
                            var pnh1 = png.Controls.OfType<SiticonePanel>();
                            foreach (SiticonePanel pnh in pnh1)
                            {
                                var paniz = pnh.Controls.OfType<SiticonePanel>();
                                foreach (SiticonePanel pni in paniz)
                                {
                                    var lbliz = pni.Controls.OfType<SiticoneHtmlLabel>();
                                    var lblIcon = pni.Controls.OfType<IconPictureBox>();
                                    
                                    foreach (SiticoneHtmlLabel lbl in lbliz)
                                    {
                                        if (lbl.Name.ToString() == "lbl" + datos[0].ToString())
                                        {
                                            lbl.Text = datos[1];
                                            btnAlertaSeguimiento.Text= datos[1];
                                            lblPasar = lbl;
                                            estado = true;
                                        }
                                    }
                                    if (estado)
                                    {
                                        foreach (IconPictureBox ic in lblIcon)
                                        {
                                            if (ic.Tag.ToString() == datos[0].ToString())
                                            {
                                                estado = true;
                                                InicializarParpadeo(lblPasar, pnh, ic);
                                                return;
                                            }

                                        }
                                    }
                                   



                                }
                            }
                        }
                    });

                }
            });

            receiveThread.IsBackground = true;
            receiveThread.Start();

            //// Espere a recibir un mensaje
            //byte[] data = udpClient.Receive(ref endPoint);

            // Convierta los datos en una cadena y muestre el mensaje
            //string message = Encoding.ASCII.GetString(data);

        }
        public void fnEscucharMansages()
        {


            UdpClient udpClient = IsUdpPortInUse(1221);

            // Cree un objeto de extremo de red que represente la dirección de difusión de su red
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

            // Inicie un subproceso separado para escuchar los mensajes
            Thread receiveThread = new Thread(() =>
            {
                while (true)
                {
                    // Espere a recibir un mensaje
                    byte[] data = udpClient.Receive(ref endPoint);
                    
                    // Convierta los datos en una cadena y muestre el mensaje
                    //string message = Encoding.ASCII.GetString(data);
                    string message = Encoding.UTF8.GetString(data);
                    string[] datos = message.Split(':');
                    bool enviadoPorMi = datos[0] == Variables.clasePersonal.cPrimerNom;
                    datosMessage = datos;

                    panelEspaciado.Invoke((MethodInvoker)delegate {
                  

                        foreach (SiticonePanel control in pnMostrarMensajes.Controls)
                        {
                            if (control.Tag != null && control.Tag.ToString() == "espacio")
                            {
                                pnMostrarMensajes.Controls.Remove(control);
                                //break;
                            }
                        }
                        
                        SiticonePanel pnS1 = new SiticonePanel();
                        //pnS1.Dock = DockStyle.Bottom;
                        pnS1.Height = 01;
                        pnS1.Tag = "espacio";

                        SiticoneCirclePictureBox pb = new SiticoneCirclePictureBox();

                        pb.Width = 25;
                        pb.Height = 25;

                        SiticonePanel pnS = new SiticonePanel();
                        pnS.Dock = DockStyle.Bottom;
                        pnS.Height = 5;
                        Font font = new Font("Segoe UI Emoji", 11);

                        SiticoneHtmlLabel stl = new SiticoneHtmlLabel();
                        
                        stl.Text = datos[3].ToString();
                        stl.AutoSize = true;
                        stl.MaximumSize = new Size((pnMostrarMensajes.Width/2)-(pb.Width+1), 1222);
                        //stl.BackColor = Color.Black;
                        stl.Font = font;

                        Label lb = new Label();
                        lb.UseCompatibleTextRendering = false;

                        lb.Text = datos[3].ToString();
                        lb.AutoSize = true;
                        lb.MaximumSize = new Size((pnMostrarMensajes.Width / 2) - (pb.Width + 1), 1222);
                        lb.Font = font;

                        SiticonePanel png = new SiticonePanel();
                        png.Width = pnMostrarMensajes.Width;
                        png.Dock = DockStyle.Bottom;
                        //png.FillColor = Color.Aquamarine;
                        png.Height = (stl.Height > pb.Height ? stl.Height : pb.Height) + 1;
                        png.Padding = new Padding(0,0,0,0);

                       


                        SiticonePanel pn = new SiticonePanel();
                        //pn.Dock=DockStyle.Bottom;
                        pn.Height = (stl.Height> pb.Height? stl.Height: pb.Height)+1;
                        pn.Width = (pnMostrarMensajes.Width / 2);
                        //pn.MinimumSize = new Size(50, 30);
                        pn.BorderRadius = 5;
                        //pn.Margin = new Padding(0, 0, 0, 0);


                        pb.Image = Properties.Resources.enojo;
                        pb.SizeMode = PictureBoxSizeMode.Zoom;

                        Personal clsPer = Variables.listaPersonal.Find(i=>i.idUsuario== Convert.ToInt32(datos[0]));


                        if (Convert.ToInt32(datos[0])== Variables.gnCodUser)
                        {
                            pb.Image = System.Drawing.Image.FromStream(Variables.clasePersonal.strPerfil);
                            pn.FillColor = Variables.ColorEmpresa;
                            lb.ForeColor = Color.White;
                            stl.ForeColor = Variables.ColorEmpresa;
                            //stl.TextAlignment = ContentAlignment.MiddleRight;
                            //pn.Anchor = AnchorStyles.Right;
                            fnPosicionarMensajes(png, pn);
                        }
                        else
                        {
                            pb.Image = System.Drawing.Image.FromStream(clsPer.strPerfil);
                            pn.FillColor = Variables.Colororangeclaro;
                            lb.ForeColor = Color.White;
                            stl.ForeColor = Variables.Colororangeclaro;
                            ////stl.TextAlignment = ContentAlignment.MiddleLeft;
                            //stl.Anchor = AnchorStyles.Top;
                            //stl.Anchor = AnchorStyles.Left;
                        }
                        
                        
                        
                        
                        pn.Controls.Add(pb);
                        stl.Location =new Point((pb.Location.X + pb.Width)+1 , stl.Location.Y);
                        lb.Location =new Point((pb.Location.X + pb.Width)+1 , stl.Location.Y);
                       
                        pn.Controls.Add(lb);
                        pn.Controls.Add(stl);

                        png.Controls.Add(pn);
                        // Agrega el mensaje al ListBox

                        if (datos[1].ToString()=="0")
                        {
                            pnMostrarMensajes.AutoScroll = true;
                            pnMostrarMensajes.Controls.Add(pnS1);
                            pnMostrarMensajes.Controls.Add(pnS);
                            pnMostrarMensajes.Controls.Add(png);
                            //pnMostrarMensajes.VerticalScroll.Value = pnMostrarMensajes.VerticalScroll.Maximum;
                            if (siticonePanel1.Visible == false) { siticonePanel1.Visible = true; }
                        }
                        else
                        {
                            siticonePanel1.Visible = false;
                            if (Convert.ToInt32(datos[0])==Variables.gnCodUser)
                            {
                                pnMostrarMensajes.AutoScroll = true;
                                pnMostrarMensajes.Controls.Add(pnS1);
                                pnMostrarMensajes.Controls.Add(pnS);
                                pnMostrarMensajes.Controls.Add(png);
                                //pnMostrarMensajes.VerticalScroll.Value = pnMostrarMensajes.VerticalScroll.Maximum;
                                if (siticonePanel1.Visible == false) { siticonePanel1.Visible = true; }
                            }
                            else
                            {
                                if (datos[1].ToString() == Variables.gsCargoUsuario)
                                {


                                    if (Convert.ToInt32(datos[2]) == 0 || Convert.ToInt32(datos[2]) == Variables.gnCodUser)
                                    {
                                        pnMostrarMensajes.AutoScroll = true;
                                        pnMostrarMensajes.Controls.Add(pnS1);
                                        pnMostrarMensajes.Controls.Add(pnS);
                                        pnMostrarMensajes.Controls.Add(png);
                                        //pnMostrarMensajes.VerticalScroll.Value = pnMostrarMensajes.VerticalScroll.Maximum;
                                        if (siticonePanel1.Visible == false) { siticonePanel1.Visible = true; }
                                    }
                                    else
                                    {
                                        siticonePanel1.Visible = false;
                                    }
                                }
                            }

                            if (Variables.gsCargoUsuario == "PETR0007")
                            {
                                pnMostrarMensajes.AutoScroll = true;
                                pnMostrarMensajes.Controls.Add(pnS1);
                                pnMostrarMensajes.Controls.Add(pnS);
                                pnMostrarMensajes.Controls.Add(png);
                                //pnMostrarMensajes.VerticalScroll.Value = pnMostrarMensajes.VerticalScroll.Maximum;
                                if(siticonePanel1.Visible == false) { siticonePanel1.Visible = true; }
                            }
                        }

                        pnMostrarMensajes.AutoScrollPosition = new Point(0, 9999); ;
                        //pnMostrarMensajes.AutoScroll = false;
                        //// Asegura que el ListBox muestre el último mensaje agregado
                        //listBox1.TopIndex = listBox1.Items.Count - 1;

                        //// Suscribe al evento DrawItem del ListBox
                        //listBox1.DrawItem += new DrawItemEventHandler(listBox1_DrawItem);
                    });
                   
                }
            });

            receiveThread.IsBackground = true;
            receiveThread.Start();

            //// Espere a recibir un mensaje
            //byte[] data = udpClient.Receive(ref endPoint);

            // Convierta los datos en una cadena y muestre el mensaje
            //string message = Encoding.ASCII.GetString(data);



        }
        private void fnPosicionarMensajes(SiticonePanel pnPadre,SiticonePanel pnHijo)
        {
            // Obtener las dimensiones del panel contenedor
            int containerWidth = pnPadre.Width;
            int containerHeight = pnPadre.Height;

            // Obtener las dimensiones del panel que se va a posicionar
            int panelWidth = pnHijo.Width;
            int panelHeight = pnHijo.Height;

            // Calcular la posición en X y Y para centrar el panel en el panel contenedor
            int xPos = (containerWidth) / 2;
            int yPos = (containerHeight - panelHeight) / 2;

            // Establecer la posición del panel
            pnHijo.Location = new Point(xPos, yPos);

            // Establecer el margen del panel para que se posicione a la derecha
            pnHijo.Margin = new Padding(0, 0, -10, 0);

            // Establecer la propiedad Anchor del panel para que se mantenga en su posición
            pnHijo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }
        private void fnDatosPNEspaciador()
        {
            panelEspaciado.Controls.Clear();
            SiticonePanel pnl = new SiticonePanel();
            pnl.Size = panelEspaciado.Size;
            pnl.BackColor = Color.Black;

            SiticoneHtmlLabel lbl = new SiticoneHtmlLabel();
            lbl.AutoSize = false;
            lbl.Size = panelEspaciado.Size;
            lbl.TextAlignment = ContentAlignment.MiddleCenter;
            lbl.BackColor = Color.Black;
            lbl.ForeColor = Variables.ColorWarning;
            lbl.Font = new Font("Roboto", 12);

            if (FunGeneral.fnVerificarApertura(Variables.gnCodUser) !=1)
            {
                if (Variables.lstCuardreCaja.Count == 0 || Variables.lstCuardreCaja[0].idOperacion==0)
                {
                    lbl.Text = "¡Por Favor debes APERTURAR CAJA Para poder registrar ingresos ó egresos!";

                }
                else
                {
                    lbl.Text = "YA CERRASTE CAJA CON EL MONTO DE: " + FunGeneral.fnFormatearPrecioDC("S/.", Variables.lstCuardreCaja.Find(i => i.idOperacion == 2).importeSaldo, 0);
                }
                pnl.Controls.Add(lbl);
            }
            else
            {
                lbl.Text = "No olvides cerrar caja antes de terminar tu turno";
                pnl.Controls.Add(lbl);
            }
            panelEspaciado.Controls.Add(pnl);
        }
        public void fnActivarDashBoard(Boolean est)
        {
            if (Variables.gsCargoUsuario == "PETR0008")
            {
                pnlParaDashboard.Visible = false;

            }
            else if (Variables.gsCargoUsuario== "PETR0005" || Variables.gsCargoUsuario == "PETR0007")
            {
                pnlParaDashboard.Visible = true;
            }
            else
            {
                pnlParaDashboard.Visible = est;
            }
            //pnlParaDashboard.Visible = true;
            fnDatosPNEspaciador();
            treeView1.Controls.Clear();
            treeView1.Controls.Add(pnlParaDashboard);

        }
        private void pnlParaDashboard_MouseEnter_1(object sender, EventArgs e)
        {
            treeView1_MouseEnter(sender, e);
        }

        private void siticonePanel3_MouseEnter(object sender, EventArgs e)
        {
            treeView1_MouseEnter(sender, e);
        }

       
  
        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Opcion aun no disponible");
            
        }
        private List<ReporteBloque> fnBuscarDetalleParaCuadre()
        {
            List<ReporteBloque> lst = new List<ReporteBloque>();

            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();
            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBusq.chkActivarDia = chkDiaEspecificoG.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value, 5);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value, 5);
            clsBusq.cod1 = cboTipoReporte.Items.Count == 0 ? "0" : cboTipoReporte.SelectedValue.ToString();
            clsBusq.cod2 = codOperacion;
            clsBusq.cod3 = ""+Variables.gnCodUser;
            //clsBusq.cod3 = cboUsuario.SelectedValue is null ? ""+Variables.gnCodUser : cboUsuario.SelectedValue.ToString();
            clsBusq.cod4 = "";
            clsBusq.cBuscar = txtBuscarRepGeneral.Text.ToString();
            clsBusq.tipoCon=-2;
            if (verifApertura())
            {
                clsBusq.cod3 = ""+Variables.gnCodUser;
            }


            return bl.blDetalleParaCuadre(clsBusq, lsReporteBloqueGen);
        }
        private List<ReporteBloque> fnBuscarDetalleParaCuadreDashboard()
        {
            List<ReporteBloque> lst = new List<ReporteBloque>();

            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();
            Busquedas clsBusq = new Busquedas();
            clsBusq.chkActivarFechas = chkHabilitarFechasBusG.Checked;
            clsBusq.chkActivarDia = chkDiaEspecificoG.Checked;
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value, 3);
            clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value, 5);
            clsBusq.cod1 = cboTipoReporte.Items.Count == 0 ? "0" : cboTipoReporte.SelectedValue.ToString();
            clsBusq.cod2 = codOperacion;
            clsBusq.cod3 = cboUsuario.SelectedValue is null ? ""+Variables.gnCodUser : cboUsuario.SelectedValue.ToString();
            clsBusq.cod4 = "";
            clsBusq.cBuscar = txtBuscarRepGeneral.Text.ToString();
            clsBusq.tipoCon=Variables.gsCargoUsuario== "PETR0006"? -1:0;

            //if (Variables.gsCargoUsuario != "PETR0006")
            //{
            //    clsBusq.cod3 = "" + Variables.gnCodUser;
            //    clsBusq.tipoCon =  -1 ;
            //}
            return bl.blDetalleParaCuadre(clsBusq, lsReporteBloqueGen);
        }
        private void fnValidarListasVecias()
        {
            if (lsReporteBloque.Count == 0)
            {
                lsReporteBloque.Add(new ReporteBloque
                {
                    numero = 1,
                    Cantidad=0,
                    Detallereporte = "No hubo ingresos en efectivo",
                    ImporteRow = 0,
                    codAuxiliar="",
                    MonImporteRow="S/."+ 0

                });
                lsReporteBloque[0].MonImporteSumado = "S/." + lsReporteBloque.Sum(i => i.ImporteRow);
            }
            if (lsReporteBloqueDetalleEgresos.Count == 0)
            {
                lsReporteBloqueDetalleEgresos.Add(new ReporteBloque
                {
                    numero = 1,
                    Cantidad = 0,
                    Detallereporte = "No hubo egresos",
                    codAuxiliar = "",
                    ImporteRow = 0,
                    SimboloMoneda = "S/.",
                    MonImporteRow = "S/." + 0

                }) ;
                lsReporteBloqueDetalleEgresos[0].MonImporteSumado =FunGeneral.fnFormatearPrecioDC("S/. ", lsReporteBloqueDetalleEgresos.Sum(i => i.ImporteRow),0) ;
            }
            if (lstRepDetalleIngresosAlContado.Count == 0)
            {
                lstRepDetalleIngresosAlContado.Add(new ReporteBloque
                {
                    numero = 1,
                    Cantidad = 0,
                    Detallereporte = "No hubo ingresos en efectivo",
                    codAuxiliar = "",
                    ImporteRow = 0,
                    MonImporteRow = "S/." + 0

                });
                lstRepDetalleIngresosAlContado[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC("S/. ", lstRepDetalleIngresosAlContado.Sum(i => i.ImporteRow), 0);
            }
            if (lstRepDetalleIngresos.Count == 0)
            {
                lstRepDetalleIngresos.Add(new ReporteBloque
                {
                    numero = 1,
                    Cantidad = 0,
                    Detallereporte = "No hubo ingresos",
                    codAuxiliar = "",
                    ImporteRow = 0,
                    MonImporteRow = "S/." + 0

                });
                lstRepDetalleIngresos[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC("S/. ", lstRepDetalleIngresos.Sum(i => i.ImporteRow), 0);
            }
        }

        public Tuple<List<ReporteBloque>, List<ReporteBloque>, List<ReporteBloque>> fnBuscarReporteDiario()
        {

            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();
            Busquedas clsBusq = new Busquedas();
            clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value, 5);
            clsBusq.tipoCon = 0;
            clsBusq.cod3 =""+Variables.gnCodUser;
           return bl.blBuscarReporteDiario(clsBusq);
        }
        private void tsMiCaja_Click(object sender, EventArgs e)
        {
            lstRepDetalleIngresosAlContado.Clear();
            //Busquedas bs=new Busquedas();
            lstCajaChica = FunGeneral.fnBuscarOtrosIngresos(new Busquedas());
            List<ReporteBloque> lstReportePorCategoria = new List<ReporteBloque>();
            List<ReporteBloque> lstReportePorOperacion = new List<ReporteBloque>();
            List<ReporteBloque> lstReportePorMedioPago = new List<ReporteBloque>();

            var dtResult= fnBuscarReporteDiario();
            lstReportePorCategoria = dtResult.Item1;
            lstReportePorOperacion=dtResult.Item2;
            lstReportePorMedioPago=dtResult.Item3;

            if (Variables.gsCargoUsuario=="PETR0006")
            {
                if (dtFechaInicioG.Value.ToString("yyyy-MM-dd") == Variables.gdFechaSis.ToString("yyyy-MM-dd"))
                {
                    lstRepDetalleIngresos = fnBuscarDetalleParaCuadre();
                    lsReporteBloqueDetalleEgresos = fnBuscarEgresos(-2,0);

                    var productosAgrupados = lstRepDetalleIngresos.GroupBy(i => i.codAuxiliar == "TIPA0001");
                    foreach (var grupo in productosAgrupados)
                    {
                        if (grupo.Key == true)
                        {
                            foreach (ReporteBloque item in grupo)
                            {
                                lstRepDetalleIngresosAlContado.Add(item);
                            }
                        }

                    }

                    for (int i = 0; i < lsReporteBloqueDetalleEgresos.Count; i++)
                    {
                        lsReporteBloqueDetalleEgresos[i].numero = i + 1;
                    }

                    fnValidarListasVecias();
                    frmMovimientoCaja frmMC = new frmMovimientoCaja();
                    lsReporteBloque[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lsReporteBloque[0].SimboloMoneda, lsReporteBloque.Sum(i => i.ImporteRow), 0);
                    if (lsReporteBloqueDetalleEgresos.Count>0)
                    {
                        lsReporteBloqueDetalleEgresos[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lsReporteBloqueDetalleEgresos[0].SimboloMoneda, lsReporteBloqueDetalleEgresos.Sum(i => i.ImporteRow), 0);
                    }

                    lstRepDetalleIngresos[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lstRepDetalleIngresos[0].SimboloMoneda, lstRepDetalleIngresos.Sum(i => i.ImporteRow), 0);
                    //Llamada 1
                    frmMC.Inicio(lstReportePorCategoria,lstReportePorOperacion,lstReportePorMedioPago, lstRepDetalleIngresosAlContado, lstRepDetalleIngresos, lsReporteBloqueDetalleEgresos, lstCajaChica, 0,1);
                    fnActivarDashBoard(estadoActivarDashBoard);
                }
                else
                {
                    MessageBox.Show("La fecha de busqueda debe ser igual a la fecha actual", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                if (verifApertura() != true)
                {
                    DialogResult resul = MessageBox.Show("¿DESEA APERTURAR CAJA?", "Importente!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resul == DialogResult.Yes)
                    {
                        if (dtFechaInicioG.Value.ToString("yyyy-MM-dd") == Variables.gdFechaSis.ToString("yyyy-MM-dd"))
                        {
                            lstRepDetalleIngresos = fnBuscarDetalleParaCuadre();
                            var productosAgrupados = lsReporteBloqueDetalleEgresos.GroupBy(i => i.codAuxiliar == "TIPA0001");
                            foreach (var grupo in productosAgrupados)
                            {
                                if (grupo.Key == true)
                                {
                                    foreach (ReporteBloque item in grupo)
                                    {
                                        lstRepDetalleIngresosAlContado.Add(item);
                                    }
                                }

                            }
                            fnValidarListasVecias();
                            frmMovimientoCaja frmMC = new frmMovimientoCaja();
                            lsReporteBloque[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lsReporteBloque[0].SimboloMoneda, lsReporteBloque.Sum(i => i.ImporteRow), 0);

                            lsReporteBloqueEgresos[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lsReporteBloqueEgresos[0].SimboloMoneda, lsReporteBloqueEgresos.Sum(i => i.ImporteRow), 0);

                            lstRepDetalleIngresos[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lstRepDetalleIngresos[0].SimboloMoneda, lstRepDetalleIngresos.Sum(i => i.ImporteRow), 0);
                            //Llamada 2
                            frmMC.Inicio(lstReportePorCategoria, lstReportePorOperacion, lstReportePorMedioPago, lstRepDetalleIngresosAlContado, lstRepDetalleIngresos, lsReporteBloqueEgresos,  lstCajaChica, 0, 1);
                            fnActivarDashBoard(estadoActivarDashBoard);
                        }
                        else
                        {
                            MessageBox.Show("La fecha de busqueda debe ser igual a la fecha actual", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        lstRepDetalleIngresos = fnBuscarDetalleParaCuadre();
                        var productosAgrupados = lsReporteBloqueDetalleEgresos.GroupBy(i => i.codAuxiliar == "TIPA0001");
                        foreach (var grupo in productosAgrupados)
                        {
                            if (grupo.Key == true)
                            {
                                foreach (ReporteBloque item in grupo)
                                {
                                    lstRepDetalleIngresosAlContado.Add(item);
                                }
                            }

                        }
                        fnValidarListasVecias();
                        frmMovimientoCaja frmMC = new frmMovimientoCaja();
                        lsReporteBloque[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lsReporteBloque[0].SimboloMoneda, lsReporteBloque.Sum(i => i.ImporteRow), 0);

                        lsReporteBloqueEgresos[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lsReporteBloqueEgresos[0].SimboloMoneda, lsReporteBloqueEgresos.Sum(i => i.ImporteRow), 0);

                        lstRepDetalleIngresos[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lstRepDetalleIngresos[0].SimboloMoneda, lstRepDetalleIngresos.Sum(i => i.ImporteRow), 0);

                        //Llamada 3
                        frmMC.Inicio(lstReportePorCategoria, lstReportePorOperacion, lstReportePorMedioPago, lstRepDetalleIngresosAlContado, lstRepDetalleIngresos, lsReporteBloqueEgresos,  lstCajaChica, -1, 0);
                        fnActivarDashBoard(estadoActivarDashBoard);
                    }
                }

                else if(verifApertura() == true)
                {
                    if (dtFechaInicioG.Value.ToString("yyyy-MM-dd") == Variables.gdFechaSis.ToString("yyyy-MM-dd"))
                    {
                        lstRepDetalleIngresos = fnBuscarDetalleParaCuadre();
                        fnValidarListasVecias();
                        frmMovimientoCaja frmMC = new frmMovimientoCaja();
                        lsReporteBloque[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lsReporteBloque[0].SimboloMoneda, lsReporteBloque.Sum(i => i.ImporteRow), 0);

                        lsReporteBloqueEgresos[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lsReporteBloqueEgresos[0].SimboloMoneda, lsReporteBloqueEgresos.Sum(i => i.ImporteRow), 0);

                        lstRepDetalleIngresos[0].MonImporteSumado = FunGeneral.fnFormatearPrecioDC(lstRepDetalleIngresos[0].SimboloMoneda, lstRepDetalleIngresos.Sum(i => i.ImporteRow), 0);

                        //Llamada 4
                        frmMC.Inicio(lstReportePorCategoria, lstReportePorOperacion, lstReportePorMedioPago, lstRepDetalleIngresosAlContado, lstRepDetalleIngresos, lsReporteBloqueEgresos, lstCajaChica, 0, 1);
                        fnActivarDashBoard(estadoActivarDashBoard);
                    }
                    else
                    {
                        MessageBox.Show("La fecha de busqueda debe ser igual a la fecha actual", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            if (Variables.gsCargoUsuario != "PETR0006" && verifApertura()==true)
            {
                fnLlenarUsuariosConAccion(cboUsuario, dtFechaInicioG, dtFechaFinG, true);
                cboUsuario.SelectedValue = Variables.gnCodUser;
            }

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

                //MessageBox.Show("Por favor Aperture caja para poder registrar ingreos", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                est = false;
            }
            else
            {
                //MessageBox.Show("Ya cerraste caja. Por favor Aperture caja para poder registrar ingreos", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                est = false;
            }
            return est;
        }
        private void btnRegistrarEgresos_Click(object sender, EventArgs e)
        {
            if (verifApertura()==true || Variables.gsCargoUsuario== "PETR0007")
            {
                frmRegistrarEgresos frmRE = new frmRegistrarEgresos();
                lsReporteBloqueDetalleEgresos = fnBuscarEgresos(-2, 0);
                frmRE.Inicio(0,lstCajaChica, lstRepDetalleIngresosDAshboard, lsReporteBloqueDetalleEgresos);
                fnBuscarReporteGeneralVentas(dgvListaPorBloque, 0, -1);
            }
            

        }

        private void cboFiltraIngresos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsReporteBloqueEgresos = fnBuscarEgresos(0, 0);
            fnGenerarTabla(dgvEgresos, lsReporteBloqueEgresos.Count, lsReporteBloqueEgresos);
        }

        private void dgvEgresos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String codRow= dgvEgresos.Rows[e.RowIndex].Cells[0].Value.ToString();
            dgvEgresos2.Visible = false;
            dgvEgresos3.Visible = false;
            fnBuscardetalleEgresos(1, codRow,"");
        }

        private void dgvEgresos2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvEgresos3.Visible = false;
        }

        private void dgvEgresos2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String codRow = dgvEgresos2.Rows[e.RowIndex].Cells[0].Value.ToString();
            String codRowAux = dgvEgresos2.Rows[e.RowIndex].Cells[5].Value.ToString();
            dgvEgresos3.Visible = false;
            Int32 x = dgvEgresos2.Left + 50;
            Int32 y = dgvEgresos2.GetRowDisplayRectangle(e.RowIndex, false).Y;
            dgvEgresos3.Location = new Point(x, (dgvEgresos2.Location.Y+y)+25);
            dgvEgresos3.Width = dgvEgresos2.Width - 50;
            fnBuscardetalleEgresos(2, codRow, codRowAux);
        }

        private void siticonePanel1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1_Click(sender, e);
        }

        private void tsSeguimiento_Click(object sender, EventArgs e)
        {
            frmSeguimiento frm = new frmSeguimiento();
            frm.Inicio(1);
        }

        private void btnAlertaSeguimiento_Click(object sender, EventArgs e)
        {
            //fnMostrarAlertaSeguimiento();

        }

        //public void fnCapturarContadorSeguimiento()
        //{
        //    // Cree un objeto Socket UDP
        //    UdpClient udpClient = new UdpClient();
        //    string message = "";
        //    Int32 contador = Convert.ToInt32(btnAlertaSeguimiento.Text) - 1;


        //     message = "00000005:" + contador;
        //    // Cree un objeto de extremo de red que represente la dirección de difusión de su red
        //    IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 1222);

        //    btnAlertaSeguimiento.Text = "" + contador;
        //    // Cree el mensaje que desea enviar

        //    //
        //    // Convierta el mensaje en bytes
        //    byte[] data = Encoding.UTF8.GetBytes(message);

        //    udpClient.Send(data, data.Length, endPoint);

        //}
        private void btnReportes_Click(object sender, EventArgs e)
        {
            LoadCarga = false;

            fnBotonActivo(sender, Variables.ColorEmpresa);

            MostrarSubMenu(subMenuReportes);


            treeView1.Nodes.Clear();
            lcCodMenu = "8881100000";
            fnCargarSubMenuReportes(lcCodMenu);
        }

        private void subMenuReportes_Click(object sender, EventArgs e)
        {
            String lcCodMenu = "";

            lcCodMenu = fnObtenerBotonEsp(sender, subMenuReportes).Name;

            fnObtenerBotonEsp(sender, subMenuReportes).BackColor = Variables.ColorSelectSubMenus;

            fnllenaTreeView(dtMenu.Tables[0], lcCodMenu);
        }

        private void txtBuscarRepGeneral_TextChanged(object sender, EventArgs e)
        {

        }

        private void tsCompra_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tsCompra_Click_1(object sender, EventArgs e)
        {
            //flowLayoutPanel1_Click(sender, e);
            MovimientoSunat frm = new MovimientoSunat();
            frm.ShowDialog();
        }

        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {
            MovimientoSunat frm = new MovimientoSunat();
            frm.Show();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtMensaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {            
                
                // Cree un objeto Socket UDP
                UdpClient udpClient = new UdpClient();

                // Cree un objeto de extremo de red que represente la dirección de difusión de su red
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 1221);

                // Cree el mensaje que desea enviar
                string message = Variables.gnCodUser + ":" + cboCargoMessage.SelectedValue.ToString()+":"+cboUsuarioMessage.SelectedValue.ToString() + ":" + txtMensaje.Text.ToString();
                //
                // Convierta el mensaje en bytes
                byte[] data = Encoding.UTF8.GetBytes(message);

                // Envíe el mensaje a través del socket UDP
                txtMensaje.Text = "";
                udpClient.Send(data, data.Length, endPoint);
            }
        }
        class Mensaje
        {
            public string Texto { get; set; }
            public bool EnviadoPorMi { get; set; }

            public Mensaje(string texto, bool enviadoPorMi)
            {
                Texto = texto;
                EnviadoPorMi = enviadoPorMi;
            }
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {

            //e.DrawBackground();

            //// Obtén el mensaje que se está dibujando
            //Mensaje mensaje = (Mensaje)listBox1.Items[e.Index];

            //// Define las coordenadas X y Y donde se dibujará el texto del mensaje
            //int x = e.Bounds.X + 5;
            //int y = e.Bounds.Y + 5;

            //// Define la fuente y el color del texto del mensaje
            //Font fuente = new Font("Arial", 10, FontStyle.Regular);
            //Color color = mensaje.EnviadoPorMi ? Color.Blue : Color.Black;

            //// Dibuja el texto del mensaje
            //e.Graphics.DrawString(mensaje.Texto, fuente, new SolidBrush(color), new PointF(x, y));

            //e.DrawFocusRectangle();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (siticonePanel1.Visible==false)
            {
                siticonePanel1.Visible = true;
            }
            else if(siticonePanel1.Visible == true)
            {
                siticonePanel1.Visible = false;
            }
        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            FunGeneral.fnLlenarUsuarioPorCargo(cboUsuarioMessage, cboCargoMessage.SelectedValue.ToString(), true);
        }

        private void SiticoneHtmlLabel8_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void FWpnCajaChicaCopias_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 2; // Grosor del borde
            Color borderColor = Variables.ColorEmpresa; // Color del borde

            // Obtener el área del FlowLayoutPanel
            Rectangle rect = FWpnCajaChicaCopias.ClientRectangle;

            // Dibujar el borde inferior
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawLine(pen, rect.Left, rect.Bottom - borderWidth, rect.Right, rect.Bottom - borderWidth);
            }
        }
    }

}
