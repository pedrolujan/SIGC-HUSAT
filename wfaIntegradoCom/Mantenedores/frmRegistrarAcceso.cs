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
    public partial class frmRegistrarAcceso : Form
    {
        public frmRegistrarAcceso()
        {
            InitializeComponent();
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool fnLlenarAplicacion(bool pbEstado)
        {
            BLUsuario objMesa = new BLUsuario();
            clsUtil objUtil = new clsUtil();
            DataTable dtAplicacion = new DataTable();
            try
            {
                dtAplicacion = objMesa.BLListarAplicacion(pbEstado);
                cboAplicacion.DataSource = null;
                cboAplicacion.DisplayMember = "cNomApli";
                cboAplicacion.ValueMember = "idAplicacion";
                cboAplicacion.DataSource = dtAplicacion;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAcceso", "fnLlenarAplicacion", ex.Message);
                return false;
            }
            finally
            {
                objMesa = null;
                dtAplicacion = null;
            }
        }

        private void frmRegistrarAcceso_Load(object sender, EventArgs e)
        {
            bool bResul = false;
            bResul=fnLlenarAplicacion(true);
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar Aplicaciones", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            
        }

        private bool fnLlenarCargooUsuario(bool pbEstado, Int16 piTipoCon)
        {
            BLUsuario objMesa = new BLUsuario();
            clsUtil objUtil = new clsUtil();
            List<Usuario> lstUsuario = new List<Usuario>();
            ListViewItem lstItem = null;
            try
            {
                lstUsuario = objMesa.BLListarCargooUsuario(pbEstado, piTipoCon);
                lvCargoUsu.Items.Clear();
                foreach (Usuario objUsu in lstUsuario)
                {
                    lstItem = lvCargoUsu.Items.Add(objUsu.cPersonal.ToString());
                    lstItem.SubItems.Add(objUsu.cUser.ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAcceso", "fnLlenarCargooUsuario", ex.Message);
                return false;
            }
            finally
            {
                objMesa = null;
                lstUsuario = null;
            }
        }

        private void cboAplicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void fnObtenerNodoHijo(TreeNode parentnode1, DataTable dtReporte)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                DataView viewItem = new DataView(dtReporte);
                viewItem.RowFilter = "cMenuPadre = " + parentnode1.Name;

                foreach (DataRowView childView in viewItem)
                {
                    TreeNode childnode1 = new TreeNode();
                    childnode1 = new TreeNode(childView["cMenuNombre"].ToString());
                    childnode1.Name = childView["cMenuCod"].ToString();
                    childnode1.ToolTipText = childView["idMenu"].ToString();
                    childnode1.Checked = Convert.ToBoolean(childView["Checkeo"].ToString());
                    parentnode1.Nodes.Add(childnode1);
                    parentnode1.ExpandAll();
                    fnObtenerNodoHijo(childnode1, dtReporte);
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAcceso", "fnObtenerNodoHijo", ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private void fnllenaTreeView(DataTable dtMenuHijo, String pcCodMenu)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                DataView viewItem = new DataView(dtMenuHijo);
                viewItem.RowFilter = "cMenuPadre = '" + pcCodMenu.ToString().Trim()+"'";
                tvMenu.Nodes.Clear();
                foreach (DataRowView childView in viewItem)
                {
                    TreeNode parentnode1 = new TreeNode();
                    parentnode1 = new TreeNode(childView["cMenuNombre"].ToString());
                    parentnode1.Name = childView["cMenuCod"].ToString();
                    parentnode1.ToolTipText = childView["idMenu"].ToString();
                    parentnode1.Checked = Convert.ToBoolean(childView["Checkeo"].ToString());
                    tvMenu.Nodes.Add(parentnode1);
                    fnObtenerNodoHijo(parentnode1, dtMenuHijo);
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAcceso", "fnllenaTreeView", ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private void lvCargoUsu_Click(object sender, EventArgs e)
        {
            int liAplicacion = 0;
            string liUsuario = "";
            clsUtil objUtil = new clsUtil();

            DataTable dtAcceso = new DataTable();
            BLAcceso objAcceso = new BLAcceso();

            try
            {
                liAplicacion = Convert.ToInt32(cboAplicacion.SelectedValue);
                ListView.SelectedListViewItemCollection item = lvCargoUsu.SelectedItems;
                liUsuario = Convert.ToString(item[0].SubItems[0].Text);
                dtAcceso = objAcceso.BLListarMenuAcceso(liAplicacion, liUsuario);
                if (dtAcceso.Rows.Count > 0)
                {
                    fnllenaTreeView(dtAcceso, "0");
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAcceso", "lvCargoUsu_SelectedIndexChanged", ex.Message);
                MessageBox.Show(ex.Message, "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lvCargoUsu_KeyPress(object sender, KeyPressEventArgs e)
        {
            int liAplicacion = 0;
            string liUsuario = "";
            clsUtil objUtil = new clsUtil();

            DataTable dtAcceso = new DataTable();
            BLAcceso objAcceso = new BLAcceso();

            try
            {
                liAplicacion = Convert.ToInt32(cboAplicacion.SelectedValue);
                ListView.SelectedListViewItemCollection item = lvCargoUsu.SelectedItems;
                liUsuario = Convert.ToString(item[0].SubItems[0].Text);
                dtAcceso = objAcceso.BLListarMenuAcceso(liAplicacion, liUsuario);
                if (dtAcceso.Rows.Count > 0)
                {
                    fnllenaTreeView(dtAcceso, "0");
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAcceso", "lvCargoUsu_SelectedIndexChanged", ex.Message);
                MessageBox.Show(ex.Message, "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void fnHijoAcceso(TreeNode tn, DataTable dtAcceso, string liUsuario, string lcFechaSistema)
        {
            DataRow drFila;
            foreach (TreeNode tchild in tn.Nodes)
            {
                if (tchild.Checked)
                {
                    drFila = dtAcceso.NewRow();
                    drFila["idMenu"] = tchild.ToolTipText;
                    drFila["idUsuario"] = liUsuario;
                    drFila["dFechaRegistro"] = lcFechaSistema;
                    drFila["cUsuario"] = Variables.gsCodUser;
                    dtAcceso.Rows.Add(drFila);
                    fnHijoAcceso(tchild, dtAcceso, liUsuario, lcFechaSistema);
                }
                
            }
        }
        private DataTable fnLlenarAcceso(string liUsuario)
        {
            DataTable dtAcceso = new DataTable();
            clsUtil objUtil = new clsUtil();
            string lcFechaSistema = "";
            DataRow drFila=null;
            try
            {

                dtAcceso.Columns.Add(new DataColumn("idMenu", typeof(Int32)));
                dtAcceso.Columns.Add(new DataColumn("idUsuario", typeof(string)));
                dtAcceso.Columns.Add(new DataColumn("dFechaRegistro", typeof(string)));
                dtAcceso.Columns.Add(new DataColumn("cUsuario", typeof(string)));
                
                lcFechaSistema = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 3);
                foreach (TreeNode tn in tvMenu.Nodes)
                {
                    if (tn.Checked == true)
                    {
                        drFila = dtAcceso.NewRow();
                        drFila["idMenu"] = tn.ToolTipText;
                        drFila["idUsuario"] = liUsuario;
                        drFila["dFechaRegistro"] = lcFechaSistema;
                        drFila["cUsuario"] = Variables.gsCodUser;
                        dtAcceso.Rows.Add(drFila);
                        fnHijoAcceso(tn, dtAcceso, liUsuario, lcFechaSistema);
                    }
                        
                    
                }

                return dtAcceso;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAcceso", "fnLlenarAcceso", ex.Message);
                return null;
            }
        }

        private Boolean fnGuardarAcceso()
        {
            DataTable dtAcceso = new DataTable();
            clsUtil objUtil = new clsUtil();
            BLAcceso objAcceso = new BLAcceso();
            string liUsuario = "";
            string lcResultado="";
            try
            {
                ListView.SelectedListViewItemCollection item = lvCargoUsu.SelectedItems;
                liUsuario = Convert.ToString(item[0].SubItems[0].Text);
                dtAcceso = fnLlenarAcceso(liUsuario);
                if (dtAcceso != null)
                {
                    lcResultado = objAcceso.BLGuardarAcceso(dtAcceso, liUsuario);
                        if (lcResultado != "OK")
                        {
                            this.saveToolStripButton.Enabled = false;
                            return false;
                        }
                        else return true;
                  
                }
                else { return false; }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAcceso", "fnGuardarAcceso", ex.Message);
                return false;
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            bool blResul = false;
            if (lvCargoUsu.SelectedItems != null)
            {
                blResul = fnGuardarAcceso();
               if (!blResul)
                {
                    MessageBox.Show("Error al Guardar Accesos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.saveToolStripButton.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Se guardaron accesos correctamente...", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Elegir Usuario antes de Guardar Accesos", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void fnMarcarLista(bool pbEstado, TreeNode NodoPadre)
        {
            if (NodoPadre.GetNodeCount(true) > 0)
            {
                foreach (TreeNode node in NodoPadre.Nodes)
                {
                    node.Checked = pbEstado;
                    fnMarcarLista(pbEstado, node);
                }
            }
        }

        private void fnVerificarHijo(TreeNode treeNode,Boolean nodeChecked)
        {
            int contador = 0;
            int ContadorEstado = 0;

            foreach (TreeNode node in treeNode.Nodes)
            {
                contador++;
            }

            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.Checked)
                {
                    node.Parent.Checked = true;
                    break;
                }
            }

            foreach (TreeNode node in treeNode.Nodes)
            {
                if (!node.Checked)
                {
                    ContadorEstado++;
                }
            }

            if (contador == ContadorEstado)
                treeNode.Checked = false;

            if (treeNode.Parent != null)
                fnVerificarHijo(treeNode.Parent, nodeChecked);
            
        }

        private void tvMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                    if (e.Node.Nodes.Count > 0)
                        fnMarcarLista(e.Node.Checked, e.Node);

                    if (e.Node.Parent != null)
                        fnVerificarHijo(e.Node.Parent, e.Node.Checked);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bResul = false;
            bResul = fnLlenarCargooUsuario(true, Convert.ToInt16(comboBox1.Text.Trim()=="Cargo"?2:1));
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar Usuarios", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }


    }
}
