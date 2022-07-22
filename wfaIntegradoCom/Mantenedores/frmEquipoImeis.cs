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
using wfaIntegradoCom.Procesos;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmEquipoImeis : Form
    {
        public frmEquipoImeis()
        {
            InitializeComponent();
        }
        Int16 lnTipoCon = 0;
        Boolean accion = false;
        Int16 lnTipoLlamada = 0;
        BLEquipo_Imeis objEquipoImeis = null;
        clsUtil objUtil=null;
        int idEquipo = 0;
        Boolean estadoSeries = false;
        static Boolean  estadoImeis = false;
        Boolean estadoSerieVacia = false;
        static Boolean estPasoLoad;
        Boolean estadoDijitosImeis = false;

        static String marca = "";
        static String Modelo = "";
        static Int32 pnIdEquipo = 0;
        static Int32 pnIdOrdenCompra = 0;
        static Int32 StokOrden = 0;
        static String pcTipoIngreso = "";
        static String pcCodOrden = "";
        static Int32 idEquipoUnico = 0;
        static String pcEquipoUnico = "";
        static Int32 lnTipoValor = 0;
        static Int32 tabInicio;
        Boolean estOrdenCompra,estImeis,estSeries,estOrigen,estPlataforma, estObservaciones;
        String msjOrdenCompra, msjImeis,msjSeries, msjOrigen, msjPlataforma, msjObservaciones;

        
        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();
        }
        public static void fnRecuperarOredenCompra(Int32 idOrden, String tipoIngreso,String codOrden, Int32 stokOrden,Int32 pIdequipo, String EquipoUnico, int pnTipoValor = 0)
        {
            pnIdOrdenCompra = idOrden;
            pcTipoIngreso = tipoIngreso;
            pcCodOrden = codOrden;
            StokOrden = stokOrden;
            idEquipoUnico = pIdequipo;
            pcEquipoUnico = EquipoUnico;
            lnTipoValor = pnTipoValor;
        }

      
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

        }
        //private String fnGuardarEquipo(Int16 idTipoCon)
        //{
        //    DateTime dFechaSis = Variables.gdFechaSis;
        //    BLEquipo_Imeis blobjEquipo = new BLEquipo_Imeis();
        //    clsUtil objUtil = new clsUtil();
        //    String lcValidar = "";
        //    Equipo_imeis objEquipo = new Equipo_imeis();
        //    try
        //    {
        //        objEquipo.idEquipoImeis = Convert.ToInt32(txtidEquipo.Text.Trim());
        //        objEquipo.imei = Convert.ToInt32(txtImeiE.Text.Trim());
        //        objEquipo.serie = Convert.ToString(txtSerieE.Text.Trim());
        //        objEquipo.idCategoria = Convert.ToInt32(cboEquipo.SelectedValue);
        //        //objEquipo.idMarcaEquipo = Convert.ToInt32(cboMarcaEquipo.SelectedValue);
        //        //objEquipo.idModeloEquipo = Convert.ToInt32(cboModeloEquipo.SelectedValue);
        //        objEquipo.idOperador = Convert.ToInt32(txtidOperador.Text.Trim());
        //        objEquipo.dFechaRegistro = dFechaSis;
        //        objEquipo.idUsuario = Variables.gnCodUser;
        //        objEquipo.bEstado = Convert.ToBoolean(swEstado.Checked);

        //        lcValidar = blobjEquipo.blGrabarEquipo(objEquipo, idTipoCon).Trim();
        //        fnLimpiarControles();
        //        fnHabilitarControles(false);
        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnGuardarEquipo", ex.Message);
        //        lcValidar = "NO";
        //    }

        //    return lcValidar;

        //}
        private List<Equipo_imeis> fnRecorrerGrilla()
        {
            Equipo_imeis objEquipoImeis;
            Int32 cant= dgImei_serie.RowCount;
            List<Equipo_imeis> lstEquipo = new List<Equipo_imeis>();
            foreach (DataGridViewRow row in dgImei_serie.Rows)
            {
                if (Convert.ToString(row.Cells[1].Value)!="" && Convert.ToString(row.Cells[2].Value)!="")
                {
                    objEquipoImeis = new Equipo_imeis();
                    objEquipoImeis.idEquipo= Convert.ToInt32(txtIdEquipoUnico.Text);
                    objEquipoImeis.idEquipoImeis = Convert.ToInt32(row.Cells[0].Value);
                    objEquipoImeis.imei = Convert.ToString(row.Cells[1].Value).Trim().ToString();
                    objEquipoImeis.serie = Convert.ToString(row.Cells[2].Value).Trim().ToString();
                    objEquipoImeis.dFechaRegistro = Variables.gdFechaSis;
                    objEquipoImeis.idUsuario = Variables.gnCodUser;
                    objEquipoImeis.bEstadoEquipo = "ESIM0001".Trim().ToString();
                    objEquipoImeis.origenEquipo = "00000000".Trim().ToString();
                    objEquipoImeis.idPlataformaEquipo = "00000000".Trim().ToString();
                    objEquipoImeis.idOrdenIngreso = Convert.ToInt32(txtIdOrdenCompra.Text);
                    objEquipoImeis.idSimCard = Convert.ToInt32(0);

                    objEquipoImeis.Observacion = Convert.ToString(txtObservacion.Text).Trim().ToString();

                    lstEquipo.Add(objEquipoImeis);
                }
                
            }
            return lstEquipo;
        }

       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        
        //private Boolean fnLlenarOperador()
        //{
        //    BLOperador objOp0erador = new BLOperador();
        //    clsUtil objUtil = new clsUtil();
        //    List<Operador> lstOperador = new List<Operador>();

        //    try
        //    {
        //        lstOperador = objOp0erador.blDevolverModeloEquipo(0);
        //        cboModeloE.ValueMember = "idOperador";
        //        cboModeloE.DisplayMember = "simCard";
        //        cboModeloE.DataSource = lstOperador;

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
        //        return false;
        //    }

        //}
        private void fnOcultarObjeto(Int16 lnTipo)
        {
            if (lnTipo == 1 || lnTipo == 3 || lnTipo == 4)
            {
                //gbDatosEquipo.Visible = false;
                //tsBotonera.Visible = false;
            }
            else if (lnTipo == 2)
            {
                //gbBuscar.Visible = false;
                //txtBuscarEquipo.Visible = false;
            }
        }

        public Boolean fnLLnenarMarcaxCategoria(Int32 idCategoria, Int16 pnTipoCon, Boolean buscar, ComboBox combo)
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


        private void frmRegistrarEquipo_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;
            String Mensaje = "Buscar Imei";
            //txtBuscar.PlaceholderText = "BUSCAR POR: Imei / SimCard";
            estPasoLoad = false;
            try
            {
                gbDatosEquipo.LineColor = Variables.ColorGroupBox;
                gbDatos_Chip.LineColor = Variables.ColorGroupBox;
                dgEquipo.Visible = false;
                FunValidaciones.fnHabilitarBoton(btnEditar, false);
                FunValidaciones.fnColorBotones(btnNuevo, btnEditar, btnGuardar, btnSalir);

                fnHabilitarControles(false);

                if (lnTipoLlamada == 0)
                {
                    bResult = fnLLnenarMarcaxCategoria(1, 0, true, cboBuscarMarca);
                    if (!bResult)
                    {
                        MessageBox.Show("Error al Cargar Marca", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }
                else if (lnTipoLlamada == 1)
                {
                    this.Text = "Consultar Cliente";
                    Height = 500;

                    fnOcultarObjeto(lnTipoLlamada);
                }
                else if (lnTipoLlamada == 2)
                {
                    fnOcultarDatosTipoLlamada();
                }
                else if (lnTipoLlamada == 3) 
                {
                    fnOcultarDatosTipoLlamada();
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
        
        private void fnOcultarDatosTipoLlamada()
        {
            Boolean bResult = false;
            this.Text = "Consultar Equipo";
            Width = 896;

            txtBuscar.Location = new Point(23, 162);
            //txtBuscar.Width = 868;

            pictureBox4.Location = new Point(858, 168);

            dgEquipo.Location = new Point(23, 200);
            gbPaginacion.Location = new Point(480, 632);

            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnGuardar.Visible = false;
            btnSalir.Visible = false;
            gbDatosEquipo.Visible = false;
            dgEquipo.Visible = true;

            bResult = fnLLnenarMarcaxCategoria(1, 0, true, cboBuscarMarca);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Marca", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }





        private Boolean fnBuscarEquipo_Imeis(String pcBuscar, Int16 pnTipoCon)
        {
            BLEquipo_Imeis objEquipo = new BLEquipo_Imeis();
            clsUtil objUtil = new clsUtil();
            DataTable datEquipo = new DataTable();
            List<Equipo_imeis> lstEquipo = null;
            try
            {
                lstEquipo = new List<Equipo_imeis>();
                //lstEquipo = objEquipo.blBuscarEquipo(pcBuscar, pnTipoCon);
                datEquipo = objEquipo.blBuscarEquipoImeis(pcBuscar,pnTipoCon);
                //dgEquipo.DataSource = datEquipo;

                
                DataTable dt = new DataTable();
                DataGridViewRow roww = new DataGridViewRow();
               
           
               String[]  datos = new String[datEquipo.Rows.Count];


                    foreach (DataRow drMenu in datEquipo.Rows)
                    {
                        dgImei_serie.Rows.Add(Convert.ToString(drMenu["idEquipoImeis"]), Convert.ToString(drMenu["Imei"]), Convert.ToString(drMenu["serie"]));
                        //cboOrigenEquipo.SelectedValue = Convert.ToString(drMenu["origen"]);
                        //cboPlataforma.SelectedValue = Convert.ToString(drMenu["plataforma"]);
                        txtObservacion.Text= Convert.ToString(drMenu["Observaciones"]);


                    }

                //for (int i = 0; i <= datEquipo.Rows.Count - 1; i++)
                //{
                //    dgImei_serie.Rows.Add(Convert.ToString(datEquipo.Rows[i][0]), Convert.ToString(datEquipo.Rows[i][2]), Convert.ToString(datEquipo.Rows[i][3]));
                //    //txtObservacion.Text = Convert.ToString(datEquipo.Rows[i][0]);
                //    cboOrigenEquipo.SelectedValue = Convert.ToString(datEquipo.Rows[i][4]);
                //}

                dgImei_serie.Columns[1].Width = 230;
                ((DataGridViewTextBoxColumn)dgImei_serie.Columns["IMEI"]).MaxInputLength = 15;
                ((DataGridViewTextBoxColumn)dgImei_serie.Columns["SERIE"]).MaxInputLength = 15;

                dgImei_serie.Columns[2].Width = 230;
                if (datEquipo.Rows.Count > 0)
                {                  
                    dgImei_serie.CurrentCell = dgImei_serie.Rows[dgImei_serie.Rows.Count - 2].Cells[1];
                    dgImei_serie.BeginEdit(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private void PasteClipboard()
        {
            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int iFail = 0, iRow = dgImei_serie.CurrentCell.RowIndex;
                int iCol = dgImei_serie.CurrentCell.ColumnIndex;
                DataGridViewCell oCell;
                foreach (string line in lines)
                {
                    if (iRow < dgImei_serie.RowCount && line.Length > 0)
                    {
                        string[] sCells = line.Split('\t');
                        for (int i = 0; i < sCells.GetLength(0); ++i)
                        {
                            if (iCol + i < this.dgImei_serie.ColumnCount)
                            {
                                oCell = dgImei_serie[iCol + i, iRow];
                                if (!oCell.ReadOnly)
                                {
                                    //if (oCell.Value.ToString() != sCells[i])
                                    //{
                                        oCell.Value = Convert.ChangeType(sCells[i], oCell.ValueType);
                                    
                                    //oCell.Style.BackColor = Color.Tomato;
                                    
                                    //}
                                    //else
                                    //iFail++;//only traps a fail if the data has changed and you are pasting into a read only cell
                                }
                            }
                            else
                            { break; }
                            //dgImei_serie.VirtualMode = true;
                        }
                        iRow++;
                    }
                    else
                    { break; }
                    if (iFail > 0)
                        MessageBox.Show(string.Format("{0} updates failed due to read only column setting", iFail));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("The data you pasted is in the wrong format for the cell");
                return;
            }
        }
        //private Boolean fnListarEquipoEspcifico(DataGridViewCellEventArgs e)
        //{
        //    clsUtil objUtil = new clsUtil();
        //    try
        //    {
        //        if (dgEquipo.Rows.Count > 0)
        //        {
        //            BLEquipo objEquipo = new BLEquipo();
        //            Equipo lstEquipo = new Equipo();
        //            DataTable dtEquipo = new DataTable();
        //            lstEquipo = objEquipo.blListarPlan(Convert.ToInt32(dgEquipo.Rows[e.RowIndex].Cells[0].Value));

        //            if (lstEquipo.idEquipo > 0)
        //            {                       
        //                cboEquipo.SelectedValue = Convert.ToInt32(lstEquipo.idCategoria.ToString());
        //                //cboMarcaEquipo.SelectedValue = Convert.ToInt32(lstEquipo.idMarcaEquipo.ToString());
        //                //cboModeloEquipo.SelectedValue = Convert.ToInt32(lstEquipo.idModeloEquipo.ToString());
        //                txtSimCard.Text = Convert.ToString(lstEquipo.SimCard);
        //                txtOperador.Text = Convert.ToString(lstEquipo.cOperador.Trim());
        //                txtidOperador.Text = Convert.ToString(lstEquipo.idOperador);
        //                //swEstado.Checked = lstEquipo.bEstado;

        //                fnHabilitarControles(false);
        //                FunValidaciones.fnHabilitarBoton(btnEditar, true);
        //                FunValidaciones.fnHabilitarBoton(btnNuevo, true);
        //                FunValidaciones.fnMostrarCantidadBusquedas(btnContadorRegistros, lblCantRegistros, dgEquipo.Rows.Count, false,"");

        //                lnTipoCon = 1;
        //            }
        //        }


        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
        //        return false;
        //    }
        //}
        private void fnHabilitarControles(Boolean pbHabilitar)
        {
            if (pbHabilitar==true)
            {
                gbDatosEquipo.BackColor = Color.Transparent;
                gbDatosEquipo.LineColor = Variables.ColorGroupBox;
                lblInfoGB.Visible = false;

                //FunValidaciones.fnValidarEstado(swEstado,txtestado);

                gbDatos_Chip.BackColor = Color.Transparent;
                gbDatos_Chip.LineColor = Variables.ColorGroupBox;

                dgImei_serie.ThemeStyle.BackColor = Variables.ColorDesactivado;
                dgImei_serie.ThemeStyle.RowsStyle.BackColor = Color.WhiteSmoke;
                dgImei_serie.ThemeStyle.HeaderStyle.BackColor = Variables.ColorGroupBox;

                //cboEquipo.BackColor = Color.Transparent;
                //cboMarcaEquipo.BackColor = Color.Transparent;
                //cboModeloEquipo.BackColor = Color.Transparent;

                //cboEquipo.BackColor = Color.Transparent;
                //cboMarcaEquipo.BackColor = Color.Transparent;
                //cboModeloEquipo.BackColor = Color.Transparent;
                txtObservacion.BackColor = Color.White;
                txtObservacion.Enabled = pbHabilitar;
                //pbImeis.Image = Properties.Resources.error;
                //pbSeries.Image = Properties.Resources.error;


            }
            else
            {
                gbDatosEquipo.BackColor = Variables.ColorDesactivado;
                gbDatosEquipo.LineColor = Variables.ColorDescativadoFuerte;
                lblInfoGB.Visible = true;


                gbDatos_Chip.BackColor = Variables.ColorDesactivado;
                gbDatos_Chip.LineColor = Variables.ColorDesactivado;


                //cboEquipo.BackColor = Variables.ColorDesactivado;
                dgImei_serie.ThemeStyle.BackColor = Variables.ColorDesactivado;
                dgImei_serie.ThemeStyle.RowsStyle.BackColor = Variables.ColorDesactivado;
                dgImei_serie.ThemeStyle.HeaderStyle.BackColor = Variables.ColorDescativadoFuerte;
                //cboMarcaEquipo.BackColor = Variables.ColorDesactivado;
                //cboModeloEquipo.BackColor = Variables.ColorDesactivado;

                //cboEquipo. = Variables.ColorDesactivado;
                //cboMarcaEquipo.BaseColor = Variables.ColorDesactivado;
                //cboModeloEquipo.BaseColor = Variables.ColorDesactivado;
                txtObservacion.BackColor = Variables.ColorDesactivado;
                txtObservacion.Enabled = pbHabilitar;

            }
            gbDatosEquipo.Enabled = pbHabilitar;
            gbDatos_Chip.Enabled = pbHabilitar;
            dgImei_serie.Enabled = pbHabilitar;

            fnActivarPB(pbHabilitar);



            if (dgImei_serie.Rows.Count >1)
            {
                dgImei_serie.CurrentCell = dgImei_serie.Rows[dgImei_serie.Rows.Count - 2].Cells[2];

                dgImei_serie.BeginEdit(true);
            }
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
        }
        private void fnActivarPB(Boolean pbHabilitar)
        {
            pbEquipoUnico.Visible = pbHabilitar;
            pbTipoOrden.Visible = pbHabilitar;
            pbCodOrden.Visible = pbHabilitar;
            pbOrdenCompra.Visible = pbHabilitar;
            pbImeis.Visible = pbHabilitar;
            pbSeries.Visible = pbHabilitar;
            pbObservacion.Visible = pbHabilitar;
        }
        private void fnLimpiarControles()
        {
            txtObservacion.Text = "";
            txtOperador.Text = "";
            lblMsgTabla.Text = "";
            lblSeries.Text = "";
            dgImei_serie.Rows.Clear();
            txtEquipoUnico.Text = "";
            txtIdEquipoUnico.Text = "";
            txtStokImeis.Text = "";
            txtCodigoOrdenCompra.Text = "";
            txtIdOrdenCompra.Text = "";
            txtTipoIngreso.Text = "";

            pnIdOrdenCompra = 0;
            pcTipoIngreso = "";
            pcCodOrden = "";
            StokOrden = 0;
            idEquipoUnico = 0;
            pcEquipoUnico = "";
            lnTipoValor = 0;

            lblEquipoUnico.Text = "";

           

        }
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmRegistrar_Cate_Marc_Mod Cat_Marc_Mod= new frmRegistrar_Cate_Marc_Mod();
            Cat_Marc_Mod.Inicio(1);
        }

       

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            //frmOperador frmCliente = new frmOperador();

            //frmCliente.Inicio(1);

            //Boolean lbResul = false;
            //lbResul = fnObtenerOperador();
            //if (!lbResul)
            //{
            //    MessageBox.Show("Error al Agregar Cliente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }
        private Boolean fnListarOperador(Boolean pbEstado)
        {
            BLOperador objCliente = new BLOperador();
            clsUtil objUtil = new clsUtil();
            SimCard lsCliente = new SimCard();

            try
            {
                lsCliente = objCliente.blDevolverOperador(pbEstado);
                //cboPropietario.DataSource = null;
                //cboPropietario.ValueMember = "idCliente";
                //cboPropietario.DisplayMember = "cCliente";
                //cboPropietario.DataSource = lsCliente;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnListarClientesActivo", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objCliente = null;
                lsCliente = null;
            }

        }
        //private Boolean fnObtenerOperador()
        //{
        //    bool bResul = false;
        //    clsUtil objUtil = new clsUtil();
        //    try
        //    {
        //        bResul = fnListarOperador(true);
        //        //if (bResul == false)
        //        //    return false;
        //        if (lnTipoValor == 0)
        //        {
        //            txtidOperador.Text = "no hay datos";
        //        }
        //        else
        //        {
        //            txtidOperador.Text = Convert.ToString(pnIdOperador);
        //            txtSimCard.Text = Convert.ToString(lcSimcard);
        //            txtOperador.Text = lcOperador;
        //        }               

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnObtenerCliente", ex.Message);
        //        return false;
        //    }
        //}

        private void dgEquipo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgEquipo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtSerieE_KeyPress(object sender, KeyPressEventArgs e)
        {
            fnValidarTipografia(e, 3, true);
        }
               
        private void txtSimCard_TextChanged(object sender, EventArgs e)
        {
            //var result = FunValidaciones.fnValidarTexboxs(txtSimCard, lblSimCard, pbSimCard, true, false, true, 2, 9, 9, "Complete todos los caractes");
            //estSimCard = result.Item1;
            //msjSimCard = result.Item2;
        }

        private void txtOperador_TextChanged(object sender, EventArgs e)
        {
            //var result =FunValidaciones.fnValidarTexboxs(txtOperador, lblOperador, pbOperador,true,true,true,2,15,15,"probando");
            //estOperador = result.Item1;
            //msjOperador = result.Item2;
        }

        private void cboModeloEquipo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //var result =FunValidaciones.fnValidarCombobox(cboModeloEquipo, lblModelo, pbModelo);
            //estModelo = result.Item1;
            //msjModelo = result.Item2;
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {

        }
        
        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            //FunValidaciones.fnValidarEstado(swEstado,txtestado);
        }

        private void gunaPanel2_Click(object sender, EventArgs e)
        {
            if (dgEquipo.Visible==true)
            {
                dgEquipo.Visible = false;

            }
        }

       
        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            fnHabilitarControles(true);
            fnLimpiarControles();
            pbImeis.Image = Properties.Resources.error;
            pbSeries.Image = Properties.Resources.error;
            gbDatosEquipo.BackColor = Color.Transparent;
            if (dgEquipo.Visible==true)
            {
                dgEquipo.Visible = false;
            }
            fnActivarPB(true);
            BtnOrdenCompra.Enabled = true;
            lnTipoCon = 0;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            //if (dgImei_serie.Rows.Count > 0)
            //{
            //    dgImei_serie.CurrentCell = dgImei_serie.Rows[dgImei_serie.Rows.Count - 2].Cells[2];
            //    dgImei_serie.BeginEdit(true);
            //}

            fnHabilitarControles(true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            fnActivarBotonGuardar();
            BtnOrdenCompra.Enabled = false;
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneDataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;
            if (dgImei_serie.CurrentCell.ColumnIndex == 1)
            {            
                if (txt != null)
                {                    
                    txt.KeyPress += new KeyPressEventHandler(dText_KeyPress);                    
                }
                else
                {                  
                }

            }
            else
            {
                txt.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
                txt.KeyPress += new KeyPressEventHandler(dText_KeyPressMayusculas);
            }
        }


        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        void dText_KeyPressMayusculas(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if ((Char.IsLetter(e.KeyChar) || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar))))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            //if (Char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsSeparator(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}

        }

        private void fnRecorrerGrillaValidar()
        {
            if (dgImei_serie.RowCount > 0)
            {
                // Primero averigua si el registro existe:
                bool existe = false;
                Int32 cont = 1;
                for (int i = 0; i < dgImei_serie.RowCount; i++)
                {
                    if (i == 0)
                    {

                    }
                    else
                    {

                        if (Convert.ToInt32(dgImei_serie.Rows[i].Cells[1].Value) == Convert.ToInt32(dgImei_serie.Rows[cont].Cells[1].Value))
                        {
                            MessageBox.Show("Duplicado " + Convert.ToInt32(dgImei_serie.Rows[i].Cells[1].Value));
                            //existe = true;
                            //break; // debes salirte del ciclo si encuentras el registro, no es necesario seguir dentro
                        }
                    }
                }
            }

                // Luego, ya fuera del ciclo, solo si no existe, realizas la insercion:
                //if (existe == false)
                //{
                //    dtg_Detalle.Rows.Add(id_prod, nombre, cant);
                //}

                
            
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboModeloEquipo_SelectedIndexChanged_2(object sender, EventArgs e)
        {
        }

        private void dgImei_serie_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gbDatosEquipo_Click(object sender, EventArgs e)
        {
            if (dgEquipo.Visible == true)
            {
                dgEquipo.Visible = false;

            }
        }

        
        private Boolean fnValidarImeisExistentesEnBD()
        {
            dgImei_serie.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            DataTable Imeis = new DataTable();
            DataTable Series = new DataTable();

            objEquipoImeis = new BLEquipo_Imeis();

            char[] MyChar = { '\r', ' ' };
            String datoss = "";
            Imeis = objEquipoImeis.blValidarEquiposImei(fnRecorrerGrilla(), 0);
            dgValidacionImeis.Rows.Clear();
            foreach (DataRow drMenu in Imeis.Rows)
            {
                dgValidacionImeis.Rows.Add(Convert.ToString(drMenu["Imei"]));

            }
            if (dgValidacionImeis.RowCount > 1)
            {               
                for (int i = 0; i < dgImei_serie.RowCount; i++)
                {
                    for (int j = 0; j < dgValidacionImeis.RowCount; j++)
                    {
                        if (Convert.ToString(dgImei_serie.Rows[i].Cells[1].Value) == Convert.ToString(dgValidacionImeis.Rows[j].Cells[0].Value))
                        {
                            dgImei_serie.Rows[i].Cells[1].Style.ForeColor = Color.Red;

                        }
                        
                    }
                }

                return false;
            }
            else
            {
                return true;
            }

        }
        private Boolean fnValidarSeriesExistentesEnBD()
        {
            dgImei_serie.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            DataTable Series = new DataTable();

            objEquipoImeis = new BLEquipo_Imeis();

            char[] MyChar = { '\r', ' ' };
            String datoss = "";
            Series = objEquipoImeis.blValidarEquiposImei(fnRecorrerGrilla(), 1);
            dgValidacionSeries.Rows.Clear();
            foreach (DataRow drMenu in Series.Rows)
            {
                dgValidacionSeries.Rows.Add(Convert.ToString(drMenu["nSerieEquipo"]));

            }
            if (dgValidacionSeries.RowCount > 1)
            {
                for (int i = 0; i < dgImei_serie.RowCount; i++)
                {
                    for (int j = 0; j < dgValidacionSeries.RowCount; j++)
                    {
                        datoss = Convert.ToString(dgImei_serie.Rows[i].Cells[2].Value).TrimEnd(MyChar);
                        //cortar = Convert.ToString(dgImei_serie.Rows[i].Cells[2].Value).Remove(15);
                        if (datoss == Convert.ToString(dgValidacionSeries.Rows[j].Cells[0].Value))
                        {
                            dgImei_serie.Rows[i].Cells[2].Style.ForeColor = Color.Red;

                        }
                    }
                }

                return false;
            }
            else
            {
                return true;
            }

        }

        private void fnMostarInfoValidacion(Label lbl, Boolean Resul,Int32 columna)
        {
            if (columna==0)
            {
                if (Resul == false)
                {
                    pbImeis.Image = Properties.Resources.error;
                    lbl.Text = "Intenta guardar imeis ya existes\n Ingrese otros ⚠️";
                  
                    estImeis = false;
                   
                }
                else
                {
                    if (Convert.ToString(dgImei_serie.Rows[0].Cells[1].Value)=="")
                    {
                        pbImeis.Image = Properties.Resources.error;
                    }
                    else
                    {
                        pbImeis.Image = Properties.Resources.ok;

                        lbl.Text = "";
                        estImeis = true;
                    }
                   
                }
            }
            else if(columna==1)
            {
                if (Resul == false)
                {
                    pbSeries.Image = Properties.Resources.error;

                    lbl.Text = "Intenta guardar series ya existes\n Ingrese otros ⚠️";
                    
                    estSeries = false;
                }
                else
                {
                    if (Convert.ToString(dgImei_serie.Rows[0].Cells[2].Value) == "")
                    {
                        pbSeries.Image = Properties.Resources.error;
                    }
                    else
                    {
                        pbSeries.Image = Properties.Resources.ok;

                        lbl.Text = "";

                        estSeries = true;
                    }

                   
                }

            }


            
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lnTipoCon == 0)
            {
                Boolean ResulImeis = false;
                Boolean ResulSeries = false;

                ResulImeis = fnValidarImeisExistentesEnBD();
                fnMostarInfoValidacion(lblMsgTabla, ResulImeis,0);

                ResulSeries = fnValidarSeriesExistentesEnBD();
                fnMostarInfoValidacion(lblSeries, ResulSeries, 1);
                fnActivarBotonGuardar();
            }
           

            gunaTextBox1_TextChanged_1(sender, e);
            //MessageBox.Show("Imeis "+estadoImeis+"\n series "+estadoSeries+"\n series Vacios "+estadoSerieVacia);
            if (estOrdenCompra == true && estImeis == true && estSeries == true)
            {
                bool blnResultado = false;
                objEquipoImeis = new BLEquipo_Imeis();
                List<Equipo_imeis> lstEquipoImeis = fnRecorrerGrilla();
                
                if (lstEquipoImeis.Count > 0)
                {
                    if (MessageBox.Show("¿Desea Guardar "+ lstEquipoImeis .Count+ " equipos al modelo \n"+Convert.ToString(txtCodigoOrdenCompra.Text).Trim().ToString()+" ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        blnResultado = objEquipoImeis.blGrabarEquipoImeis(fnRecorrerGrilla(), lnTipoCon);
                        if (blnResultado)
                        {
                            //blnResultado = fnObtenerPreciosxProductoxUM(idEquipo);
                            //if (!blnResultado)
                            //    MessageBox.Show("No se ha cargado correctamente Listado de Precios por Producto y unidad de medida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show("Se guardaron correctamente los equipos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
                            dgEquipo.Visible = false;
                            fnHabilitarControles(false);
                            fnLimpiarControles();
                            
                        }
                        else
                        {
                            MessageBox.Show("datos duplicados");
                        }
                    }
                }
                else
                    MessageBox.Show("Ud. no ingreso ningun equipo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fnHabilitarControles(false);
                fnLimpiarControles();
            }
            else
            {
                MessageBox.Show("Complete correctamente todo los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            fnRecorrerGrillaValidar();
            
        }

        private void dgImei_serie_EditModeChanged(object sender, EventArgs e)
        {
           
        }
       

        public static Tuple<Boolean, String> fnValidarDuplicidadImeis(SiticoneDataGridView dg, Label lbl, PictureBox img)
        {
            Int32 datoRepetidoImei = 0;
            Int32 datoRepetidoImei2 = 0;
            Boolean estadoImeisVacia = false;

            

            Boolean dijitosImei = false;
            Int32 MinimoDijitosImeis = 0;
            Int32 MaximoDijitos = 0;


            Int32 ImeiExistenteEnBD = 0;
            String msg = "";

            Int32 restar = 0;

            Int32 sumar_a_J = 0;
            Int32 datoExistente = 0;
            Int32 y = 0;

            Boolean estado = false;
            var pictureBox = new PictureBox();
            if (dg.RowCount > 0)
            {
                for (int i = 0; i < dg.RowCount; i++)
                {
                    if (dg.RowCount == 1)
                    {
                        restar = 0;
                    }
                    else
                    {
                        restar = 1;
                    }
                    for (int j = i; j < dg.RowCount - restar; j++)
                    {

                        if (dg.RowCount == 1)
                        {
                            y = j;
                            sumar_a_J = 0;
                        }
                        else
                        {
                            y = j + 1;
                            sumar_a_J = 1;
                        }

                       
                                if ((Convert.ToString(dg.Rows[i].Cells[1].Value) == "" || Convert.ToString(dg.Rows[i].Cells[1].Value) == null)
                                    || (Convert.ToString(dg.Rows[j+ sumar_a_J].Cells[1].Value) == "" || Convert.ToString(dg.Rows[j + sumar_a_J].Cells[1].Value) == null))
                                {
                                    msg = "Tiene campos Imei vacios \n complete los Datos ⚠️";
                                    //estadoSeries = true;
                                    estadoImeisVacia = true;
                                    img.Image = Properties.Resources.error;
                                    estado = false;
                                    lbl.Text = msg;
                                    return Tuple.Create(estado, msg);
                                    break;
                                }
                                else if (Convert.ToString(dg.Rows[i].Cells[1].Value).Length < 15 || Convert.ToString(dg.Rows[j].Cells[1].Value).Length < 15)
                                {
                                    msg = "Complete los datos\n minimo. 15 dijitos ⚠️";
                                    //estadoSeries = true;

                                    MinimoDijitosImeis = (Convert.ToString(dg.Rows[i].Cells[1].Value).Length < 15) ? i : j;
                                    dg.Rows[MinimoDijitosImeis].Cells[1].Style.ForeColor = Color.Red;

                                    dijitosImei = true;
                                    img.Image = Properties.Resources.error;
                                    estado = false;
                                    lbl.Text = msg;
                                    return Tuple.Create(estado, msg);
                                    break;
                                }
                                else
                                {
                                    if (Convert.ToString(dg.Rows[i].Cells[1].Value).Length > 15 || Convert.ToString(dg.Rows[j].Cells[1].Value).Length > 15)
                                    {
                                        MaximoDijitos = (Convert.ToString(dg.Rows[i].Cells[1].Value).Length > 15) ? i : j;
                                        dg.Rows[MaximoDijitos].Cells[1].Style.ForeColor = Color.Red;
                                        msg = "Verifique los datos\n maximo. 15 dijitos ⚠️";
                                        img.Image = Properties.Resources.error;
                                        estado = false;
                                        lbl.Text = msg;
                                        return Tuple.Create(estado, msg);
                                        break;
                                    }
                                    if ((Convert.ToString(dg.Rows[y].Cells[1].Value) == Convert.ToString(dg.Rows[i].Cells[1].Value))
                                        && (Convert.ToString(dg.Rows[y].Cells[1].Value) != "" || Convert.ToString(dg.Rows[i].Cells[1].Value) != null))
                                    {
                                        datoRepetidoImei = i;
                                        datoRepetidoImei2 = y;
                                        //dg.Rows[datoRepetidoImei2].Cells[1].Style.ForeColor = Color.Red;
                                        //dg.Rows[datoRepetidoImei].Cells[1].Style.ForeColor = Color.Red;


                                        //estadoSeries = true;
                                        if (dg.RowCount == 1)
                                        {
                                            msg = "";
                                            img.Image = Properties.Resources.ok;
                                            estado = true;

                                        }
                                        else
                                        {
                                            msg = "Imei duplicados\n revise los datos ingresados ⚠️";
                                            img.Image = Properties.Resources.error;
                                            estado = false;

                                        }

                                        lbl.Text = msg;
                                        return Tuple.Create(estado, msg);

                                        //picture.Image = Properties.Resources.error;

                                        break; // debes salirte del ciclo si encuentras el registro, no es necesario seguir dentro
                                    }
                                    else
                                    {
                                        if (datoRepetidoImei > 0 || datoRepetidoImei2 > 0)
                                        {
                                            if (Convert.ToString(dg.Rows[datoRepetidoImei2].Cells[1].Value) == Convert.ToString(dg.Rows[datoRepetidoImei].Cells[1].Value))
                                            {
                                                dg.Rows[datoRepetidoImei].Cells[1].Style.ForeColor = Color.Red;
                                                dg.Rows[datoRepetidoImei2].Cells[1].Style.ForeColor = Color.Red;
                                                //dgImei_serie.Rows[datoRepetido].Cells[1].Style.ForeColor = Color.Red;
                                                //estadoSeries = true;
                                                msg = "Imei duplicados\n revise los datos ingresados ⚠️";
                                                img.Image = Properties.Resources.error;
                                                estado = false;
                                                lbl.Text = msg;
                                                return Tuple.Create(estado, msg);
                                                break;


                                            }
                                            else
                                            {
                                                dg.Rows[datoRepetidoImei].Cells[1].Style.ForeColor = Color.Black;
                                                dg.Rows[datoRepetidoImei2].Cells[1].Style.ForeColor = Color.Black;
                                                datoRepetidoImei = 0;
                                                datoRepetidoImei2 = 0;
                                                msg = "";
                                                pictureBox.Image = Properties.Resources.ok;

                                                estadoImeisVacia = false;

                                                //estadoSeries = false;
                                                img.Image = Properties.Resources.ok;
                                                lbl.Text = msg;
                                                estado = true;

                                            }
                                        }
                                        else
                                        {
                                            if (estadoImeisVacia == true)
                                            {
                                                //estadoSeries = true;
                                                msg = "Tiene campos Imei vacios \n complete los Datos ⚠️";
                                                pictureBox.Image = Properties.Resources.error;

                                                img.Image = Properties.Resources.error;
                                                estado = false;
                                                lbl.Text = msg;
                                                return Tuple.Create(estado, msg);
                                            }
                                            else
                                            {
                                                if (dijitosImei == true)
                                                {
                                                    msg = "Complete los datos \n minimo. 15 dijitos ⚠️";

                                                    dg.Rows[MinimoDijitosImeis].Cells[1].Style.ForeColor = Color.Red;

                                                    //estadoSeries = true;
                                                    img.Image = Properties.Resources.error;
                                                    estado = false;
                                                    lbl.Text = msg;
                                                    return Tuple.Create(estado, msg);
                                                    break;
                                                }
                                                else
                                                {
                                                    dg.Rows[datoRepetidoImei].Cells[2].Style.ForeColor = Color.Black;
                                                    dg.Rows[y].Cells[1].Style.ForeColor = Color.Black;
                                                    dg.Rows[i].Cells[1].Style.ForeColor = Color.Black;

                                                    datoRepetidoImei = 0;
                                                    datoRepetidoImei2 = 0;

                                                    dg.Rows[MinimoDijitosImeis].Cells[1].Style.ForeColor = Color.Black;
                                                    MinimoDijitosImeis = 0;

                                                    //estadoSeries = false;

                                                    estadoImeisVacia = false;

                                                    msg = "";
                                                    lbl.Text = msg;
                                                    img.Image = Properties.Resources.ok;
                                                    estado = true;

                                                }
                                            }

                                        }

                                    }

                                }
                           
                    }
                }
            }
            lbl.Text = msg;
            return Tuple.Create(estado, msg);
        }
        public static Tuple<Boolean, String> fnValidarDuplicidadSeries(SiticoneDataGridView dg,Label lbl, PictureBox img)
        {
            Int32 datoRepetidoSerie = 0;
            Int32 datoRepetidoSerie2 = 0;

            Boolean estadoSeriesVacia = false;

            Int32 MinimoDijitosSeries = 0;

            Boolean dijitosSeries = false;

            Int32 cont2 = 0;

            Int32 cont = 0;
            String msg = "";
            Int32 y = 0;

            Int32 restar = 0;
            Int32 sumar_a_J = 0;
            Int32 datoExistente = 0;
            Int32 ImeiExistenteEnBD = 0;
            Boolean estado = false;

            var pictureBox = new PictureBox();

            if (dg.RowCount > 0)
            {
                for (int i = 0; i < dg.RowCount; i++)
                {
                    if (dg.RowCount == 1)
                    {
                        restar = 0;
                    }
                    else
                    {
                        restar = 1;
                    }
                    for (int j = i; j < dg.RowCount - restar; j++)
                    {

                        if (dg.RowCount == 1)
                        {
                            y = j;
                            sumar_a_J = 0;
                        }
                        else
                        {
                            y = j + 1;
                            sumar_a_J = 1;
                        }

                        //datoExistente = fnValidarEquipoImeisExixtentes(Convert.ToString(dg.Rows[i].Cells[2].Value).Trim().ToString(), datoValidar, 2);
                        //if (datoExistente == 1)
                        //{
                        //    ImeiExistenteEnBD = i;
                        //    dg.Rows[ImeiExistenteEnBD].Cells[2].Style.ForeColor = Color.Red;
                        //    msg = "Esta serie ya existe\n Ingrese otro ⚠️\n";
                        //    //estadoImeis = true;
                        //    img.Image = Properties.Resources.error;
                        //    estado = false;
                        //    lbl.Text = msg;
                        //    return Tuple.Create(estado, msg);
                        //    break;
                        //}
                        //else
                        //{
                        //    datoExistente = fnValidarEquipoImeisExixtentes(Convert.ToString(dg.Rows[y].Cells[2].Value), datoValidar, 2);
                        //    if (datoExistente == 1)
                        //    {
                        //        dg.Rows[y].Cells[2].Style.ForeColor = Color.Red;
                        //        msg = "Esta serie ya existe\n Ingrese otro ⚠️";
                        //        estadoImeis = true;
                        //        img.Image = Properties.Resources.error;
                        //        estado = false;
                        //        lbl.Text = msg;
                        //        return Tuple.Create(estado, msg);
                        //        break;
                        //    }
                        //    else
                        //    {
                                if ((Convert.ToString(dg.Rows[i].Cells[2].Value) == "" || Convert.ToString(dg.Rows[i].Cells[2].Value) == null) 
                                    || (Convert.ToString(dg.Rows[j+ sumar_a_J].Cells[2].Value) == "" || Convert.ToString(dg.Rows[j+ sumar_a_J].Cells[2].Value) == null))
                                {
                                    msg = "Tiene campos series vacios \n complete los Datos ⚠️";
                                    //estadoSeries = true;
                                    estadoSeriesVacia = true;
                                    img.Image = Properties.Resources.error;
                                    estado = false;
                                    lbl.Text = msg;
                                    return Tuple.Create(estado, msg);
                                    break;
                                }
                                else if (Convert.ToString(dg.Rows[i].Cells[2].Value).Length < 15 || Convert.ToString(dg.Rows[j].Cells[2].Value).Length < 15)
                                {
                                    msg = "Complete los datos\n minimo. 15 dijitos ⚠️";
                                    //estadoSeries = true;

                                    MinimoDijitosSeries = (Convert.ToString(dg.Rows[i].Cells[2].Value).Length < 15) ? i : j;
                                    dg.Rows[MinimoDijitosSeries].Cells[2].Style.ForeColor = Color.Red;

                                    dijitosSeries = true;
                                    img.Image = Properties.Resources.error;
                                    estado = false;
                                    lbl.Text = msg;
                                    return Tuple.Create(estado, msg);
                                    break;
                                }
                                else
                                {
                                    if ((Convert.ToString(dg.Rows[y].Cells[2].Value) == Convert.ToString(dg.Rows[i].Cells[2].Value))
                                        && (Convert.ToString(dg.Rows[y].Cells[2].Value) != "" || Convert.ToString(dg.Rows[i].Cells[2].Value) != null))
                                    {
                                        datoRepetidoSerie = i;
                                        datoRepetidoSerie2 = y;
                                        //dg.Rows[datoRepetidoSerie2].Cells[2].Style.ForeColor = Color.Red;
                                        //dg.Rows[datoRepetidoSerie].Cells[2].Style.ForeColor = Color.Red;


                                        //estadoSeries = true;
                                        if (dg.RowCount == 1)
                                        {
                                            msg = "";
                                            img.Image = Properties.Resources.ok;
                                            estado = true;

                                        }
                                        else
                                        {
                                            msg = "Series duplicadas\n revise los datos ingresados ⚠️";
                                            img.Image = Properties.Resources.error;
                                            estado = false;

                                        }

                                        lbl.Text = msg;
                                        return Tuple.Create(estado, msg);

                                        //picture.Image = Properties.Resources.error;

                                        break; // debes salirte del ciclo si encuentras el registro, no es necesario seguir dentro
                                    }
                                    else
                                    {
                                        if (datoRepetidoSerie > 0 || datoRepetidoSerie2 > 0)
                                        {
                                            if (Convert.ToString(dg.Rows[datoRepetidoSerie2].Cells[2].Value) == Convert.ToString(dg.Rows[datoRepetidoSerie].Cells[2].Value))
                                            {
                                                dg.Rows[datoRepetidoSerie].Cells[2].Style.ForeColor = Color.Red;
                                                dg.Rows[datoRepetidoSerie2].Cells[2].Style.ForeColor = Color.Red;
                                                //dgImei_serie.Rows[datoRepetido].Cells[1].Style.ForeColor = Color.Red;
                                                //estadoSeries = true;
                                                msg = "Series duplicadas\n revise los datos ingresados ⚠️";
                                                img.Image = Properties.Resources.error;
                                                estado = false;
                                                lbl.Text = msg;
                                                return Tuple.Create(estado, msg);
                                                break;


                                            }
                                            else
                                            {
                                                dg.Rows[datoRepetidoSerie].Cells[2].Style.ForeColor = Color.Black;
                                                dg.Rows[datoRepetidoSerie2].Cells[2].Style.ForeColor = Color.Black;
                                                datoRepetidoSerie = 0;
                                                datoRepetidoSerie2 = 0;
                                                msg = "";
                                                pictureBox.Image = Properties.Resources.ok;

                                                estadoSeriesVacia = false;

                                                //estadoSeries = false;
                                                img.Image = Properties.Resources.ok;
                                                lbl.Text = msg;
                                                estado = true;
                                        
                                            }
                                        }
                                        else
                                        {
                                            if (estadoSeriesVacia == true)
                                            {
                                                //estadoSeries = true;
                                                msg = "Tiene campos series vacios \n complete los Datos ⚠️";
                                                pictureBox.Image = Properties.Resources.error;

                                                img.Image = Properties.Resources.error;
                                                estado = false;
                                                lbl.Text = msg;
                                                return Tuple.Create(estado, msg);
                                            }
                                            else
                                            {
                                                if (dijitosSeries == true)
                                                {
                                                    msg = "Complete los datos \n minimo. 15 dijitos ⚠️";

                                                    dg.Rows[MinimoDijitosSeries].Cells[2].Style.ForeColor = Color.Red;

                                                    //estadoSeries = true;
                                                    img.Image = Properties.Resources.error;
                                                    estado = false;
                                                    lbl.Text = msg;
                                                    return Tuple.Create(estado, msg);
                                                    break;
                                                }
                                                else
                                                {
                                                    dg.Rows[datoRepetidoSerie].Cells[2].Style.ForeColor = Color.Black;
                                                    dg.Rows[y].Cells[2].Style.ForeColor = Color.Black;
                                                    dg.Rows[i].Cells[2].Style.ForeColor = Color.Black;

                                                    datoRepetidoSerie = 0;
                                                    datoRepetidoSerie2 = 0;

                                                    dg.Rows[MinimoDijitosSeries].Cells[2].Style.ForeColor = Color.Black;
                                                    MinimoDijitosSeries = 0;

                                                    //estadoSeries = false;

                                                    estadoSeriesVacia = false;

                                                    msg = "";
                                                    lbl.Text = msg;
                                                    img.Image = Properties.Resources.ok;
                                                    estado = true;

                                                }
                                            }

                                        }

                                    }

                                }
                        //    }
                        //}
                    }
                }
            }
                   
                    //lblSeries.Text = msg;
                    //pbSeries.Image = pictureBox.Image;
               
            lbl.Text = msg;
            return Tuple.Create(estado, msg);
        }


         private static Int32 fnValidarEquipoImeisExixtentes(String dato,String dato2,Int32 column)
        {
            BLEquipo_Imeis objPlan = new BLEquipo_Imeis();
            clsUtil objUtil = new clsUtil();
            
            Int32 validarDatos = 0;
            try
            {
                validarDatos = objPlan.blDevolverDatosExistentes(dato, dato2, column);
                return validarDatos;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLLnenarProvinciaxDepa", ex.Message);
                return validarDatos;
            }
            finally
            {
            }
        }
        private Boolean fnBuscarTabla(String pcBuscar, Int32 pagina,Int32 tipoCon,Int32 TipoLlamada)
        {
            BLEquipo_Imeis objPlan = new BLEquipo_Imeis();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();
            Int32 filas = 20;
            String bEstado = "";
            try
            {
                if (lnTipoLlamada==2)
                {
                    bEstado = "ESIM0005";
                }
                else if(lnTipoLlamada==3 )

                {
                    bEstado = "ESIM0005";
                }
                else
                {
                    bEstado = "0";
                }

                datTipoPlan = objPlan.blBuscarImeisDataTable(bEstado,
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
                    dt.Columns.Add("SIMCARD");
                    dt.Columns.Add("ORD. COMPRA");
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

                    Boolean ingresoImeis;

                    String estado = "";
                    for (int i = 0; i <= datTipoPlan.Rows.Count - 1; i++)
                    {
                        y++;
                        object[] row = { datTipoPlan.Rows[i][0],y, datTipoPlan.Rows[i][1], datTipoPlan.Rows[i][2], datTipoPlan.Rows[i][8], datTipoPlan.Rows[i][7], datTipoPlan.Rows[i][4] };
                        dt.Rows.Add(row);

                    }
                   
                    dgEquipo.DataSource = dt;
                    dgEquipo.Visible = true;
                    dgEquipo.Columns[0].Visible = false;
                    dgEquipo.Columns[1].Width = 40;
                    dgEquipo.Columns[2].Width = 200;
                    dgEquipo.Columns[3].Width = 100;
                    dgEquipo.Columns[4].Width = 100;
                    dgEquipo.Columns[5].Width = 100;
                    dgEquipo.Columns[6].Width = 150;
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
                        gbPaginacion.Visible = true;
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
                    dgEquipo.DataSource = dt;
                    dgEquipo.Visible = false;
                    btnNumFilas.Text = "0";
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
        private void dgImei_serie_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var result = fnValidarDuplicidadSeries(dgImei_serie, lblSeries, pbSeries/*, Convert.ToString(txtSeries2.Text).Trim().ToString()*/);
            estSeries = result.Item1;
            msjSeries = result.Item2;

            var resultImeis = fnValidarDuplicidadImeis(dgImei_serie, lblMsgTabla, pbImeis/*, Convert.ToString(txtImeis2.Text).Trim().ToString()*/);
            estImeis = resultImeis.Item1;
            msjImeis = resultImeis.Item2;

            dgImei_serie_CellValueChanged( sender,  e);
            fnActivarBotonGuardar();
        }
        private void fnActivarBotonGuardar()
        {
            if ((lblMsgTabla.Text == "" && lblSeries.Text == "") || (lblMsgTabla.Text == null && lblSeries.Text == null))
            {
                FunValidaciones.fnHabilitarBoton(btnGuardar, true);
            }
            else
            {
                FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgImei_serie_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            
        }

        private void dgImei_serie_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //for (int i=1;i<dgImei_serie.Columns.Count;i++)
            //{
          
            
            if (dgImei_serie.Rows.Count>1)
            {
                int i = dgImei_serie.Rows.Count - 1;
                for (int j = i; j < dgImei_serie.Rows.Count; j++)
                {

                    if (Convert.ToString(dgImei_serie.Rows[j-1].Cells[1].Value) == "")
                    {
                        dgImei_serie.Rows[j].Cells[1].ReadOnly = true;
                        dgImei_serie.Rows[j].Cells[2].ReadOnly = true;
                        dgImei_serie.Rows[j-1].Cells[2].ReadOnly = true;
                    }
                    else
                    {
                        if (Convert.ToString(dgImei_serie.Rows[j].Cells[1].Value) == "")
                        {
                            dgImei_serie.Rows[j].Cells[2].ReadOnly = false;
                            dgImei_serie.Rows[j-1].Cells[2].ReadOnly = false;
                        }
                        
                    }
                    if (Convert.ToString(dgImei_serie.Rows[j - 1].Cells[2].Value) == "")
                    {
                        dgImei_serie.Rows[j].Cells[1].ReadOnly = true;
                        dgImei_serie.Rows[j].Cells[2].ReadOnly = true;
                        estadoSerieVacia = true;
                        pbSeries.Image = Properties.Resources.error;
                    }
                    else if (estadoSeries == true || estadoImeis == true)
                    {
                        
                        dgImei_serie.Rows[j].Cells[1].ReadOnly = true;
                        dgImei_serie.Rows[j - 1].Cells[1].ReadOnly = false;
                        dgImei_serie.Rows[j].Cells[2].ReadOnly = true;
                        estadoSerieVacia = false;
                        break;
                    }
                    else
                    {
                        if(Convert.ToString(dgImei_serie.Rows[j].Cells[1].Value) == "")
                        {
                            dgImei_serie.Rows[j].Cells[2].ReadOnly = true;
                        }
                        else
                        {
                            dgImei_serie.Rows[j].Cells[2].ReadOnly = false;
                        }
                        dgImei_serie.Rows[j].Cells[1].ReadOnly = false;
                        estadoSerieVacia = false;
                    }
                }

            }
            else
            {
                for (int j = 0; j < dgImei_serie.Rows.Count; j++)
                {

                    
                        if (Convert.ToString(dgImei_serie.Rows[j].Cells[1].Value) == "")
                        {
                            dgImei_serie.Rows[j].Cells[2].ReadOnly = true;
                        }
                        else
                        {
                            dgImei_serie.Rows[j].Cells[2].ReadOnly = false;
                        }
                        //dgImei_serie.Rows[j].Cells[2].ReadOnly = false;
                        //dgImei_serie.Rows[j].Cells[1].ReadOnly = false;
                    
                }
            }
            //}
        }

        private void gunaTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtObservacion, lblObservacion, pbObservacion, false, true, false, 0, 0, 0,200, "Es observaciones");
            estObservaciones = result.Item1;
            msjObservaciones = result.Item2;
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtImeiE_TextChanged(object sender, EventArgs e)
        {

            //var result = FunValidaciones.fnValidarTexboxs(txtImeiE, lblImei, pbImei,true,false,true,9,12,9, "Complete los datos (Campos Obligatorio)");
            //estImei = result.Item1;
            //msjImei = result.Item2;
        }

        private void txtSerieE_TextChanged(object sender, EventArgs e)
        {
            //var result = FunValidaciones.fnValidarTexboxs(txtSerieE, lblSerie, pbSerie, true,true, true, 2, 9, 9, "Complete los datos (Campos Obligatorio)");
            //estSerie = result.Item1;
            //msjSerie = result.Item2;
        }

        private void rbImei_CheckedChanged(object sender, EventArgs e)
        {

        }

        
        int posX = 0;

       
        private void dgImei_serie_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
           if (Convert.ToString(e.Row.Cells[0].Value) == "" || e.Row.Cells[0].Value == null)
           {
                    e.Row.Cells[0].Value = "0";
                    
           }           
            
        }

        private void dgImei_serie_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            fnActivarBotonGuardar();
        }

        private void dgImei_serie_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (dgImei_serie.BeginEdit(true))
            //{
                //dgImei_serie.CurrentCell = dgImei_serie.Rows[dgImei_serie.Rows.Count - 2].Cells[2];
                //dgImei_serie.BeginEdit(true);
            //}

        }

        private void dgImei_serie_KeyDown(object sender, KeyEventArgs e)
        {
            //if ((e.Control && e.KeyCode == Keys.Delete) || (e.Shift && e.KeyCode == Keys.Delete))
            //{
            //    CopyClipboard();
            //}
            if ((e.Control && e.KeyCode == Keys.Insert) || (e.Shift && e.KeyCode == Keys.Insert))
            {
                PasteClipboard();
            }
        }
        
        private void gbChkBuscar_Click(object sender, EventArgs e)
        {

        }

        private void cboBuscarMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResult = false;
            Int32 idMarca = 0;
            
            if (Convert.ToInt32(cboBuscarMarca.SelectedIndex)==0)
            {
                dgEquipo.Visible = false;
                idMarca = 0;
            }
            else
            {
                dgEquipo.Visible = true;
                idMarca = Convert.ToInt32(cboBuscarMarca.SelectedValue);
            }
            bResult = fnLlenarModeloxMarca(Convert.ToInt32(cboBuscarMarca.SelectedValue), 1, cboBuscarModelo, true);

            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Modelo", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            if (estPasoLoad == true)
            {
                bResult = fnBuscarTabla(txtBuscar.Text.Trim(), Convert.ToInt32(cboPagina.SelectedValue), -1,2);
                if (!bResult)
                {
                    MessageBox.Show("Error al buscar Imeis. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
        }

        private void cboPaginacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResul = false;
            Int32 Paginacion = 0;
            if (cboPagina.SelectedValue==null)
            {
                Paginacion = 0;
            }
            else
            {
                Paginacion = Convert.ToInt32(cboPagina.SelectedValue);
            }
            bResul = fnBuscarTabla(txtBuscar.Text.Trim(), Paginacion,-2, lnTipoLlamada);
            if (!bResul)
            {
                MessageBox.Show("Error al Buscar Imeis. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (estPasoLoad==true)
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    Boolean bResul = false;

                    bResul = fnBuscarTabla(txtBuscar.Text.Trim(), 0, -1, lnTipoLlamada);
                    if (!bResul)
                    {
                        MessageBox.Show("Error al Buscar Imeis. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            
            
        }

       

        private void cboBuscarModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResult = false;
            
            if (estPasoLoad==true)
            {
                bResult = fnBuscarTabla(txtBuscar.Text.Trim(), Convert.ToInt32(cboPagina.SelectedValue), -1, lnTipoLlamada);
                if (!bResult)
                {
                    MessageBox.Show("Error al Buscar Imeis. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
            
        }

        private void btnBuscarEquipo_Click(object sender, EventArgs e)
        {
            frmRegistrarEquipo frmEquipo = new frmRegistrarEquipo();

            frmEquipo.Inicio(1);

            Boolean lbResul = false;
            lbResul = fnObtenerEquipo();
            if (!lbResul)
            {
                MessageBox.Show("Error al Equipo Cliente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        int posY = 0;

        private void dgEquipo_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                bResul = fnListarImeisEspecificos(e);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                
            }
            else if (lnTipoLlamada == 1)
            {
                //Boolean bResul = false;
                //bResul = fnRecuperarImeisEspecificos(e);
                //if (!bResul)
                //{
                //    MessageBox.Show("Error al Recuperar Equipo Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                //else
                //{
                //    this.Dispose();
                //}
            }
            else if (lnTipoLlamada == 2)
            {
                fnDatosEquipos(e);
                this.Close();
            }
            else if (lnTipoLlamada == 3)
            {
                fnDatosReacitivacion(e);
                    this.Close();
            }
        }
        private Boolean fnDatosEquipos(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (dgEquipo.Rows.Count > 0)
                {
                    frmInstalacionEquipo.fnDatoEquipo(fnLstEquipos(Convert.ToInt32(dgEquipo.Rows[e.RowIndex].Cells[0].Value)));
                    
                }

                return true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnRecuperarClienteEsp", ex.Message);
                return false;
            }
        }
        private Boolean fnDatosReacitivacion (DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                if (dgEquipo.Rows.Count > 0)
                {
                    frmReactivaciones frm = new frmReactivaciones();
                    frm.fnDatoEquipoNuevo(fnLstEquipos(Convert.ToInt32(dgEquipo.Rows[e.RowIndex].Cells[0].Value)));

                }
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }
        private List<Equipo_imeis> fnLstEquipos(Int32 idEquipo)
        {
            BLInstalacion objInstal = new BLInstalacion();
            List<Equipo_imeis> resp = new List<Equipo_imeis>();



            resp.Add(objInstal.blBuscarEquipo(idEquipo));


            return resp;
        }
        private void gunaPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }
        private Boolean fnObtenerEquipo()
        {
            bool bResul = false;
            clsUtil objUtil = new clsUtil();
            try
            {
                bResul = fnListarOperador(true);
                //if (bResul == false)
                //    return false;
                if (lnTipoValor == 0)
                {
                    txtEquipoUnico.Text = "Elegir orden de ingreso";
                    txtTipoIngreso.Text = "Elegir orden de ingreso";
                    
                }
                else
                {
                    dgImei_serie.Rows.Clear();

                    txtIdOrdenCompra.Text =Convert.ToString(pnIdOrdenCompra);
                    txtTipoIngreso.Text = pcTipoIngreso;
                    txtCodigoOrdenCompra.Text = pcCodOrden;
                    txtIdEquipoUnico.Text = Convert.ToString(idEquipoUnico);                  
                    txtEquipoUnico.Text = pcEquipoUnico;
                    txtStokImeis.Text = Convert.ToString(StokOrden);
                    pnIdEquipo = 0;
                    //txtSimCard.Text = Convert.ToString(lcSimcard);
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnOrdenCompra_Click(object sender, EventArgs e)
        {
            frmDetalleIngresoEquipo frmOrdenCompra = new frmDetalleIngresoEquipo();

            frmOrdenCompra.Inicio(1);

            Boolean lbResul = false;
            lbResul = fnObtenerEquipo();
            if (!lbResul)
            {
                MessageBox.Show("Error al Agregar Cliente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (txtStokImeis.Text!="")
            {
                for (Int32 i = 0; i < Convert.ToInt32(txtStokImeis.Text); i++)
                {
                    dgImei_serie.Rows.Add(new DataGridViewRow());
                }
            }
            else
            {
                pbEquipoUnico.Image = Properties.Resources.error;
                pbCodOrden.Image = Properties.Resources.error;
                pbTipoOrden.Image = Properties.Resources.error;
                pbOrdenCompra.Image = Properties.Resources.error;
                fnActivarPB(true);
            }


        }

        private void siticoneTextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtEquipoUnico_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStokImeis_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtStokImeis,lblEquipoUnico,pbOrdenCompra,true,false,false,0,10,2,4,"Error");
            estOrdenCompra = result.Item1;
            msjOrdenCompra = result.Item2;
            if (msjOrdenCompra=="")
            {
                pbEquipoUnico.Image = Properties.Resources.ok;
                pbCodOrden.Image = Properties.Resources.ok;
                pbTipoOrden.Image = Properties.Resources.ok;
            }
            else
            {
                pbEquipoUnico.Image = Properties.Resources.error;
                pbCodOrden.Image = Properties.Resources.error;
                pbTipoOrden.Image = Properties.Resources.error;

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Boolean bResul = fnBuscarTabla(txtBuscar.Text.Trim(), 0, -1, lnTipoLlamada);
            if (!bResul)
            {
                MessageBox.Show("Error al Buscar Imeis. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblMensajes_Click(object sender, EventArgs e)
        {

        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            String busqueda = txtBuscar.Text.Trim().ToString();
            Int32 pagina = Convert.ToInt32(cboPagina.Text.ToString());

            fnBuscarTabla(busqueda, pagina, -2, lnTipoLlamada);
        }

        public class Valor
        {
            public string Value { get; set; }
            public string Index { get; set; }
        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteClipboard();
            var result = fnValidarDuplicidadSeries(dgImei_serie, lblSeries, pbSeries);
            estSeries = result.Item1;
            msjSeries = result.Item2;

            var resultImeis = fnValidarDuplicidadImeis(dgImei_serie, lblMsgTabla, pbImeis);
            estImeis = resultImeis.Item1;
            msjImeis = resultImeis.Item2;


            fnActivarBotonGuardar();
        }

        private void cmsEquipoImeis_Opening(object sender, CancelEventArgs e)
        {

        }

        //private Boolean fnObtenerPaginacionEquipos(Int32 idMarca,Int32 idModelo)
        //{
        //    clsUtil objUtil = new clsUtil();
        //    BLEquipo_Imeis objPaginacion = new BLEquipo_Imeis();
        //    Equipo_imeis lstPaginacion = new Equipo_imeis();
        //    DataTable dtEquipo = new DataTable();
        //    try
        //    {
        //          lstPaginacion = objPaginacion.blObtenerPaginacionEquipos("0",idMarca, idModelo);

        //        if (Convert.ToInt32(lstPaginacion.cantPaginas) > 0)
        //        {
        //            Int32 cant = dgImei_serie.RowCount;
        //            btnTotalRegistros.Text= Convert.ToString(Convert.ToInt32(lstPaginacion.totalRegistros));
        //            btnTotalPaginas.Text =Convert.ToString(Convert.ToInt32(lstPaginacion.cantPaginas));


        //            var Valores = new List<Valor>();
        //            for (int i=1;i<= Convert.ToInt32(lstPaginacion.cantPaginas); i++){
                        
        //                Valores.Add(new Valor() { Index = Convert.ToString(i), Value = Convert.ToString(i) });
                      
        //            }
                                       
        //            cboPagina1.DisplayMember = "Value";
        //            cboPagina1.ValueMember = "Index";
        //            cboPagina1.DataSource = Valores;
        //        }


        //        dgEquipo.Visible = false;
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
        //        return false;
        //    }
        //}
        private Boolean fnListarImeisEspecificos(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                if (dgEquipo.Rows.Count > 0)
                {
                    BLEquipo_Imeis objChip = new BLEquipo_Imeis();
                    Equipo_imeis lstChip = new Equipo_imeis();
                    DataTable dtEquipo = new DataTable();
                    lstChip = objChip.blListarImeiEspacifico(Convert.ToInt32(dgEquipo.Rows[e.RowIndex].Cells[0].Value),1);

                    if (lstChip.idEquipoImeis > 0)
                    {
                         dgImei_serie.Rows.Clear();
                     
                        //cboEquipo.SelectedValue = Convert.ToInt32(lstChip.idEquipo);
                        txtObservacion.Text= Convert.ToString(lstChip.Observacion);
                        txtImeis2.Text = Convert.ToString(lstChip.imei);
                        txtSeries2.Text = Convert.ToString(lstChip.serie);
                        dgImei_serie.Rows.Add(Convert.ToString(lstChip.idEquipoImeis), Convert.ToString(lstChip.imei), Convert.ToString(lstChip.serie));
                        txtIdOrdenCompra.Text = Convert.ToString(lstChip.idOrdenIngreso);
                        txtIdEquipoUnico.Text = Convert.ToString(lstChip.idEquipo);
                        txtEquipoUnico.Text = Convert.ToString(lstChip.nomEquipo);
                        txtStokImeis.Text = Convert.ToString(lstChip.totalRegistros);
                        txtTipoIngreso.Text = Convert.ToString(lstChip.TipoIngreso);
                        txtCodigoOrdenCompra.Text = Convert.ToString(lstChip.CodOrden);


                        dgEquipo.Visible = false;
                        //FunValidaciones.fnMostrarCantidadBusquedas(btnContadorRegistros, lblCantRegistros, dgChip.Rows.Count, false, "");
                        if (dgImei_serie.Rows.Count > 0)
                        {
                            dgImei_serie.CurrentCell = dgImei_serie.Rows[dgImei_serie.Rows.Count - 1].Cells[1];
                            dgImei_serie.BeginEdit(true);
                        }
                        fnHabilitarControles(false);
                        FunValidaciones.fnHabilitarBoton(btnEditar, true);
                        FunValidaciones.fnHabilitarBoton(btnNuevo, true);


                        txtBuscar.Text = "";
                        lnTipoCon = 1;
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
        void fnValidarTipografia(KeyPressEventArgs e, Int32 num, Boolean mayusculas)
        {
            if (num == 1)
            {
                if (mayusculas)
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                    if ((Char.IsLetter(e.KeyChar)) || (Char.IsControl(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.KeyChar = char.ToLower(e.KeyChar);
                    if ((Char.IsLetter(e.KeyChar)) || (Char.IsControl(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (num == 2)
            {
                if ((Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (num == 3)
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
                if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar)) || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                if (Char.IsWhiteSpace(e.KeyChar) || Char.IsSymbol(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        public Tuple<Boolean, String> fnValidaDatosDuplicados(GunaTextBox txt, Label lbl, PictureBox img, Boolean Obligatorio, Boolean Existencia)
        {
            Boolean estad;
            String msj;
            if (Existencia == true)
            {
                img.Image = Properties.Resources.error;
                msj = "Este Imei ya existe  (Ingrese otro Equipo)";
                lbl.Text = msj;
                estad = false;
                txt.FocusedBorderColor = Variables.ColorEmpresa;
                return Tuple.Create(estad, msj);

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                txt.FocusedBorderColor = Color.Green;
                estad = true;
                return Tuple.Create(estad, msj);
            }
        }

        private void txtImeiE_KeyPress(object sender, KeyPressEventArgs e)
        {
            fnValidarTipografia(e,2,true);
        }
        public Boolean fnBuscarChips(Int32 lnIdRecibo)
        {
            BLEquipo_Imeis objEquipo = new BLEquipo_Imeis();
            Boolean pbhabilitaLista = false;
            clsUtil objUtil = new clsUtil();
            DataTable datOperador = new DataTable();
            List<Equipo_imeis> lstEquipo = null;
            ListViewItem lstItem = null;
            try
            {
                lstEquipo = new List<Equipo_imeis>();
                dgImei_serie.Columns.Clear();
                datOperador = objEquipo.blBuscarEquipo_imaisDatatable(lnIdRecibo);
                if (datOperador.Rows.Count > 0)
                {

                    DataTable dtEmp = new DataTable();
                    // agregar columna a la tabla de datos  
                   
                    //dtEmp.Columns.Add("ID", typeof(int));
                    //dtEmp.Columns.Add("N° SIMCARD", typeof(string));
                    //dtEmp.Columns.Add("OPERADOR", typeof(string));
                    for (int i = 0; i <= datOperador.Rows.Count - 1; i++)
                    {
                        dtEmp.Rows.Add(datOperador.Rows[i][0],
                            datOperador.Rows[i][1],
                            datOperador.Rows[i][2]
                            );
                    }

                    dgImei_serie.DataSource = dtEmp;
                    dgImei_serie.Columns[0].ReadOnly = false;
                    dgImei_serie.Columns[1].Visible = true;
                    dgImei_serie.Columns[1].ReadOnly = true;
                    dgImei_serie.Columns[2].ReadOnly = true;
                    dgImei_serie.Columns[3].ReadOnly = true;
                    dgImei_serie.Visible = true;
                    //fnActivarCargandoGif(pIBusar, false);
                }
                else
                {

                }
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

    }
}
