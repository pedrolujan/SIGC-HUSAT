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
using Siticone.UI.WinForms;
using FontAwesome.Sharp;


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

        private IconButton BtnActual;
        private System.Windows.Forms.Panel LeftBordeBtn;

        //pading botones temporales de submenus 
         Padding PaddingbtnSubMenu = new Padding(10,0,0,0);
       

        public void fnLoadCarga ( Boolean Load)
        {
            LoadCarga = Load;
            if (this.treeView1.Controls.Count > 0)
                this.treeView1.Controls.RemoveAt(0);


        }
        //Constructor
        public MDIParent1()
        {
            InitializeComponent();
            SubmenusOcultos();

            LeftBordeBtn = new System.Windows.Forms.Panel();
            LeftBordeBtn.Size = new Size(15,55);

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
            var ControlesAccesoDirecto = LayoutPanelAccesoRapido.Controls.OfType<IconButton>();
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
                             btn.Enabled=true;
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

            var controlPanel = LayoutPanelAccesoRapido.Controls.OfType<IconButton>();

            if (iNumMenu > 0)
            {
                foreach (DataRowView drFila in dvMenuPrincipal)
                {
                    lcItemMenu = drFila["cMenuNombre"].ToString().Trim();
                    foreach (IconButton ts in controlPanel)
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
        }
        
        public Boolean Loading()
        {

            frmUsuario login = new frmUsuario();
            Boolean bLoading=false;
            BLMenu objMenu = new BLMenu();

            try
            {
                if(login.ShowDialog() == DialogResult.OK )
                {
                    bLoading = true;
                    frmLoad frm = new frmLoad();
                    dtMenu = objMenu.BLCargarMenu(Variables.gnCodUser, 1);


                    fnCargarVariableGlobal();
                    fnCargarVariableImpresion();
                    if (dtMenu.Tables.Count > 0)
                    {
                        if(AbrirFrmLoad(new frmLoad()))
                        {
                          


                        }

                    }
                    


                    //frm.Inicio();

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

        private void Frm_FormClosed()
        {
            fnCargarMenuPrin();
            fnCargarMenuPrinBotones();
         
            fnCargarMenuAccesoRapidoBtn();
            lcCodMenu = "8888100000";
            imgList = ListaImagenes;
            treeView1.Nodes.Clear();
           
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
                temp.Padding = new Padding(10,0,0,0);

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
        private int BorderSize = 0;
       
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

            //Aplicando Themas a los paneles
            ColorThemas.ElegirThema(cboxSelecThema.Text);
            treeView1.BackColor = ColorThemas.PanelPadre;
            panelIzquierdo.BackColor = ColorThemas.PanelBotones;
            PanelEncavezadoFondo.BackColor = ColorThemas.BarraAccesoDirectos;
            PanelEncavezadoFondo.BackColor = ColorThemas.BarraAccesoDirectos;
            //colores inicio a los botones de panel botones
            btnVenta.BackColor = ColorThemas.PanelBotones;
            btnRecaudacion.BackColor = ColorThemas.PanelBotones;
            btnComercial.BackColor = ColorThemas.PanelBotones;
            btnLogistica.BackColor = ColorThemas.PanelBotones;
            btnSistemas.BackColor = ColorThemas.PanelBotones;
            btnRrhh.BackColor = ColorThemas.PanelBotones;
            btnConfiguracion.BackColor = ColorThemas.PanelBotones;
            btnSoporte.BackColor = ColorThemas.PanelBotones;


            //inicio de funciones de cargado de menus y formulario load

            try
            {
                fnOcultarObjetos();
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
            if (LoadCarga == true)
            {
                Frm_FormClosed();
            }
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

        private void fnActivarFormularioConBoton(string pcNomreFormulario , int pintidTipoLlamada)
        {
            Form frmFormulario;


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
                        frmFormulario.Show();
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
            if (e.ClickedItem.Name== "tsCerraSession")
            {

            }
            else if (e.ClickedItem.Name=="tsMiCaja")
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
            panelCerrarSession.Visible = false;
            LoadCarga = false;
            fnOcultarObjetos();
            this.Loading();


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
            Img_Husat_Negro.Visible = false;
            Img_Husat_Blanco.Visible = true;

            iconChildForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            lblChilForm.Text = "Home";
            SubmenusOcultos();
            reset();
        }

        private void pictureBox5_Click_(object sender, EventArgs e)
        {
            Img_Husat_Blanco.Visible = false;
            Img_Husat_Negro.Visible = true;
            iconChildForm.IconChar = IconChar.Home;
            lblChilForm.Text = "Home";
            SubmenusOcultos();
            reset();
        }

        private void fnBotonActivo(object senderBtn, Color color)
        {
            ColorThemas.ElegirThema(cboxSelecThema.Text);

            if (senderBtn != null)
            {   
                //desactivamos el Boton
                fnBotoninactivo();
                //Personalizando Boton
                BtnActual = (IconButton)senderBtn;//asigna el boton actual con el Boton remitente
                BtnActual.BackColor = Color.White;
                //BtnActual.ForeColor = color;

                //BtnActual.ForeColor = ColorThemas.PanelBotones;
                BtnActual.ForeColor =panelIzquierdo.BackColor ;

                BtnActual.TextAlign = ContentAlignment.MiddleCenter;
                //BtnActual.IconColor = color;

                BtnActual.IconColor = ColorThemas.PanelBotones; 
                BtnActual.IconColor = panelIzquierdo.BackColor;

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
                BtnActual.BackColor =panelIzquierdo.BackColor ;
                BtnActual.ForeColor = Color.White ;
                BtnActual.TextAlign = ContentAlignment.MiddleLeft;
                BtnActual.IconColor = Color.White;
                BtnActual.TextImageRelation = TextImageRelation.ImageBeforeText;
                BtnActual.ImageAlign = ContentAlignment.MiddleLeft;
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

        }
        private void OcultarSubMenu ()
        {
            if (subMenuVentas.Visible == true)
                subMenuVentas.Visible = false;
            if (subMenuRecaudacion.Visible == true)
                subMenuRecaudacion.Visible = false;
            if (subMenuComercial.Visible ==true)
                subMenuComercial.Visible = false;
            if(subMenuLogistica.Visible == true)
                subMenuLogistica.Visible = false;
            if (subMenuSistemas.Visible == true)
                subMenuSistemas.Visible = false;
            if (subMenuRrhh.Visible == true)
                subMenuRrhh.Visible = false;
            if (subMenuConfiguracion.Visible == true)
                subMenuConfiguracion.Visible = false;
            if (subMenuSoporte.Visible ==true)
                subMenuSoporte.Visible = false;

        }
        private void MostrarSubMenu(System.Windows.Forms.Panel subMenu )
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

        private System.Windows.Forms.Button fnObtenerBotonEsp(object sender , SiticonePanel panel)
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
            fnActivarFormulario(btn.Name,0);

        }
        private IconButton fnObtenerBotonEspIconButton(object sender, FlowLayoutPanel panel)
        {
            var Controles = panel.Controls.OfType<IconButton>();
            IconButton temp = new IconButton();
            String Cadena = sender.ToString();
            String[] array = Cadena.Split(':');
            String item = array[1].ToString().Trim();
            foreach (IconButton btn in Controles)
            {
                //btn.BackColor = Variables.ColorBackColorSubMenus;
                if (btn.Text == item)
                {
                    temp = btn;
                    //break;
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
            btnCerrarSesion.IconChar =IconChar.PersonWalkingDashedLineArrowRight;
            btnPerfil.IconFont = IconFont.Regular;
        }

        private void btnPerfil_MouseMove(object sender, EventArgs e)
        {
            btnPerfil.IconFont =IconFont.Solid;
            btnCerrarSesion.IconChar = IconChar.PersonWalkingArrowRight;
        }

        private void siticoneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ColorThemas.ElegirThema(cboxSelecThema.Text);
            SubmenusOcultos();
            reset();

            treeView1.BackColor = ColorThemas.PanelPadre;
            panelIzquierdo.BackColor = ColorThemas.PanelBotones;
            //Botones del Menu Principal
            btnVenta.BackColor = ColorThemas.PanelBotones;
            btnRecaudacion.BackColor = ColorThemas.PanelBotones;
            btnComercial.BackColor = ColorThemas.PanelBotones;
            btnLogistica.BackColor = ColorThemas.PanelBotones;
            btnSistemas.BackColor = ColorThemas.PanelBotones;
            btnRrhh.BackColor = ColorThemas.PanelBotones;
            btnConfiguracion.BackColor = ColorThemas.PanelBotones;
            btnSoporte.BackColor = ColorThemas.PanelBotones;
            PanelEncavezadoFondo.BackColor = ColorThemas.BarraAccesoDirectos;
            btnOpciones.BackColor = ColorThemas.PanelPadre;

            if (cboxSelecThema.Text == "Pink")
            {
                treeView1.ForeColor = Color.Black;
                btnOpciones.ForeColor = Color.FromArgb(71, 71, 71);
                btnOpciones.IconColor = Color.FromArgb(71, 71, 71);
                btnPersonalizacion.ForeColor = Color.FromArgb(71, 71, 71);
                btnPersonalizacion.IconColor = Color.FromArgb(71, 71, 71);
              


            }
            else 
            {
                treeView1.ForeColor = Color.White;
                btnOpciones.IconColor = Color.White;
                btnOpciones.ForeColor = Color.White;
                btnPersonalizacion.ForeColor = Color.White;
                btnPersonalizacion.IconColor = Color.White;
            }

        }


        private void iconButton2_Click(object sender, EventArgs e)
        {

            if (cboxSelecThema.Visible == false)
            {
                cboxSelecThema.Visible = true;
                btnOpciones.IconChar = IconChar.Gear;

            }
            else
            {
                cboxSelecThema.Visible = false;
                btnOpciones.IconChar = IconChar.Sliders;
            }
        }

        private void treeView1_MouseEnter(object sender, EventArgs e)
        {
            cboxSelecThema.Visible = false;
            panelPersonalizarColores.Visible = false;
            btnOpciones.IconChar = IconChar.Sliders;
        }

        private void btnOpciones_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            cboxSelecThema.Visible = true;
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
                PanelEncavezadoFondo.BackColor = MyDialog.Color;
                PanelEncavezadoFondo.BackColor = MyDialog.Color;

               

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
    }

}
