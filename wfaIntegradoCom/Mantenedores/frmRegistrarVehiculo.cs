
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
using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Siticone.Desktop.UI.WinForms;

namespace wfaIntegradoCom.Mantenedores
{

    public partial class frmRegistrarVehiculo : Form
    {
        Int16 lnTipoLlamada = 0;

       
        public frmRegistrarVehiculo()
        {
            InitializeComponent();
            rbPlaca.Checked = true;
        }

        static Int32 tabInicio;
        Int16 lnTipoCon = 0;
        Int16 lnTipoAccion = 0;
        static String lcCliente = "";
        static String lcMarca = "";        
        static int lnTipoValor = 0;
        Boolean estClase,estMarca,estModelo,estPlaca,estSerie,estAnio,estColor,estUso,estPropietario,estObservaciones;
        String msjClase, msjMarca,msjModelo,msjPlaca,msjSerie,msjAnio,msjColor,msjUso,msjPropietario, msjObservaciones;

        public void Inicio(Int16 pnTipoLlamada)
        {
            lnTipoLlamada = pnTipoLlamada;
            ShowDialog();

        }
        public static void fnRecuperarCliente(String pcCliente, String pcDireccion, String pcTipoDoc, String pcNroDoc, int pnTipoValor = 0)
        {
            lcCliente = pcCliente;
            //lcDireccion = pcDireccion;
            //lcTipoDoc = pcTipoDoc;
            //lcNroDoc = pcNroDoc;
            lnTipoValor = pnTipoValor;
        }
        public static void fnRecuperarMarca(String pcMarca, int pnTipoValor = 0)
        {
            lcMarca = pcMarca;
            lnTipoValor = pnTipoValor;
        }
     
        private void fnLimpiarControles()
        {
            txtidVehiculo.Text = "0";
            cboClaseV.SelectedValue = 0;
            txtPlacaVh.Text = "";
            cboMarcaVh.SelectedValue = 0;
            cboModeloVh.SelectedValue = 0;
            cboPropietario.SelectedValue =0;
            txtSerieVh.Text = "";
            txtColorVh.Text = "";
            txtAnio.Text = "";
            txtObservaciones.Text = "";
            
            /////////vaciar mensajes//////
            lblCboClase.Text = "";
            lblCboMarca.Text = "";
            lblCboModelo.Text = "";
            lblCboModoUso.Text = "";
            lblCboPropietario.Text="";
            lblPlaca.Text = "";
            lblSerie.Text = "";
            lblColor.Text = "";
            lblAnio.Text = "";
            lblObservacion.Text = "";

            ////VACIAR LOS PICKCHUREBOX/////
            
            pbClase.Image = null;
            pbMarca.Image = null;
            pbModelo.Image = null;
            pbModoUso.Image = null;
            pbPlaca.Image = null;
            pbSerie.Image = null;
            pbColor.Image = null;
            pbAnio.Image = null;
            pbObsevacion.Image = null;
            
            
            epVehiculo.Clear();
            epControlOk.Clear();
            txtBuscarVehiculo.Focus();
        }
        private void fnHabilitarControles(Boolean pbHabilitar)
        {
            gbDatosVehiculo.Enabled = pbHabilitar;
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
                if (Char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }
        void fnActivarCombobox(Boolean estado,Int32 indice)
        {
            cboMarcaVh.Enabled = estado;

            cboModeloVh.Enabled = estado;

            cboModUso.Enabled = estado;

        }
        void fnActivarTexbox(Boolean estado)
        {
            txtSerieVh.Enabled = estado;
            txtAnio.Enabled = estado;
            txtColorVh.Enabled = estado;
            if (lnTipoCon==1)
            {
                txtPlacaVh.Enabled = false;
            }
            

        }
        public Tuple<Boolean, String> fnValidaDatosDuplicados(SiticoneTextBox txt, Label lbl, PictureBox img, Boolean Obligatorio,Boolean Existencia)
        {
            Boolean estad;
            String msj;
            if (Existencia==true)
            {
                img.Image = Properties.Resources.error;
                msj = "Esta placa ya existe  (Ingrese otro vehiculo)";

                lbl.Text = msj;
                estad = false;
                lbl.ForeColor = Variables.ColorError;
                txt.FocusedState.BorderColor = Variables.ColorError;
                return Tuple.Create(estad, msj);

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                estad = true;
                return Tuple.Create(estad, msj);
            }
        }
        private Tuple<Boolean, String> fnValidarTexbox(SiticoneTextBox txt, Label lbl, PictureBox img, Boolean maximo, Int32 num,Boolean Obligatorio)
         {
            String msj;

            if (txt.Text == null || txt.Text.Trim() == "" && Obligatorio==true)
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

        private Tuple<Boolean, String> fnValidarCombobox(ComboBox cbo, Label lbl, PictureBox img)
        {
            String msj;
            Boolean estado = false;
            if (cbo.SelectedIndex == 0 || cbo.SelectedIndex==-1)
            {
                img.Image = Properties.Resources.error;
                msj = "Seleccione una opción";
                lbl.Text = msj;
                estado = false;
                return Tuple.Create(estado, msj);

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                estado = true;
                return Tuple.Create(estado, msj);
            }
        }
        private String fnGuardarVehiculo(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLVehiculo blobjVehiculo = new BLVehiculo();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Vehiculo objVehiculo = new Vehiculo();
            try
            {
                objVehiculo.idVehiculo = Convert.ToInt32(txtidVehiculo.Text.Trim());
                objVehiculo.idClase = Convert.ToInt32(cboClaseV.SelectedValue);
                objVehiculo.vPlaca = Convert.ToString(txtPlacaVh.Text.Trim());
                objVehiculo.idMarcaV = Convert.ToInt32(cboMarcaVh.SelectedValue);
                objVehiculo.idModeloV = Convert.ToInt32(cboModeloVh.SelectedValue);
                objVehiculo.vSerie = Convert.ToString(txtSerieVh.Text.Trim());
                objVehiculo.anio = Convert.ToInt32(txtAnio.Text.Trim());
                objVehiculo.vColor = Convert.ToString(txtColorVh.Text.Trim());
                objVehiculo.ModoUso = Convert.ToInt32(cboModUso.SelectedValue);
                objVehiculo.idCliente = Convert.ToInt32(cboPropietario.SelectedValue);
                objVehiculo.Observaciones = Convert.ToString(txtObservaciones.Text.Trim());
                objVehiculo.bEstado = chkActivo.Checked;
                objVehiculo.dFechaReg = dFechaSis;
                objVehiculo.idUsuario = Variables.gnCodUser;

                lcValidar = blobjVehiculo.blGrabarVehiculo(objVehiculo, idTipoCon).Trim();
                fnLimpiarControles();
                fnHabilitarControles(false);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnGuardarVehiculo", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            String lcResultado = "";
            var resultCboClase = fnValidarCombobox(cboClaseV, lblCboClase, pbClase);
            if (resultCboClase.Item1 == false)
            {
                estClase = resultCboClase.Item1;
                msjClase = resultCboClase.Item2;

            }
            var resultCboMarca = fnValidarCombobox(cboMarcaVh, lblCboMarca, pbMarca);
            if (resultCboMarca.Item1 == false)
            {
                estMarca = resultCboMarca.Item1;
                msjMarca = resultCboMarca.Item2;

            }
            var resultCboModelo = fnValidarCombobox(cboModeloVh, lblCboModelo, pbModelo);
            if (resultCboModelo.Item1 == false)
            {
                estModelo = resultCboModelo.Item1;
                msjModelo = resultCboModelo.Item2;

            }
            var resultCboUso = fnValidarCombobox(cboModUso, lblCboModoUso, pbModoUso);
            if (resultCboUso.Item1 == false)
            {
                estUso = resultCboUso.Item1;
                msjUso = resultCboUso.Item2;

            }
           
            int placa = 0;
            //if (chkOtro.Checked == true && cboClaseV.SelectedIndex != 0 && cboClaseV.Text != "VEHICULOS ESPECIALES")
            //{
                //txtPlacaVh.MaxLength = 25;
                //var resultPlaca = fnValidarTexbox(txtPlacaVh, lblPlaca, pbPlaca, false, 0, true);
                //if (resultPlaca.Item1 == false)
                //{
                //    estPlaca = resultPlaca.Item1;
                //    msjPlaca = resultPlaca.Item2;
                //    placa = 1;

                //}

            //}
            //else if (chkOtro.Checked == false && cboClaseV.Text != "VEHICULOS ESPECIALES")
            //{
            //    var resultPlaca = fnValidarTexbox(txtPlacaVh, lblPlaca, pbPlaca, true, 7, true);
            //    if (resultPlaca.Item1 == false)
            //    {
            //        estPlaca = resultPlaca.Item1;
            //        msjPlaca = resultPlaca.Item2;
            //        placa = 1;

            //    }
            //}
            

            txtSerieVh_TextChanged( sender, e);
            txtColorVh_TextChanged( sender,  e);
            txtAnio_TextChanged(sender, e);
            txtObservaciones_TextChanged(sender,e);


            if (estPlaca == true && estClase ==true && estMarca==true && estModelo==true && estUso==true && estSerie==true && estAnio==true &&  estColor==true && estObservaciones==true)
            {

                if (chkActivo.Checked == false)
                {
                    MessageBox.Show("El vehiculo se Guardara en estado INACTIVO", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                lcResultado = fnGuardarVehiculo(lnTipoCon);

                if (lcResultado == "OK")
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente Vehiculo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (lnTipoLlamada == 2)
                    {
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Error al Grabar Vehiculo. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Todos los campos( Obligatorios ) deben estar con datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            lnTipoAccion = 0;
            dgVehiculo.Visible = false;
            
            fnHabilitarControles(true);
            fnLimpiarControles();
            fnActivarCombobox(false, 0);
            fnActivarTexbox(false);
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
                

        public void RemoveText(object sender, EventArgs e)
        {
            if (txtBuscarVehiculo.Text.Length>0)
            {
                txtBuscarVehiculo.Text = "";
                txtBuscarVehiculo.ForeColor = Color.Black;
            }
        }

       
        private void fnOcultarObjeto(Int16 lnTipo)
        {
            if (lnTipo == 1 || lnTipo == 3 || lnTipo == 4 || lnTipo == 5)
            {
                gbBuscar.Visible = true;
                gbDatosVehiculo.Visible = false;
            }
            else if (lnTipo == 2)
            {
                gbBuscar.Visible = true;
                txtBuscarVehiculo.Visible = false;
            }
        }
        private void frmRegistrarVehiculo_Load(object sender, EventArgs e)
        {
            

            fnHabilitarControles(false);
            fnActivarTexbox(false);
            FunValidaciones.fnColorTresBotones(btnNuevo,btnEditar,btnGuardar);
            FunValidaciones.fnColorBotonEspecifico(btnNuevoHistorial);

            if (lnTipoLlamada == 0)
            {
                Boolean bResult = false;

                fnObtenerCliente();

                bResult = fnLLenarClaseVehiculo();
                if (!bResult)
                {                    
                    MessageBox.Show("Error al Cargar Clase Vehiculo", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                

                //bResult = fnLLenarMarcaV();
                //if (!bResult)
                //{
                //    MessageBox.Show("Error al Cargar Marca Vehiculo", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.Close();
                //}
                //bResult = fnLLenarModeloV();
                //if (!bResult)
                //{
                //    MessageBox.Show("Error al Cargar Modelo Vehiculo", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.Close();
                //}
                
                fnHabilitarControles(false);
                fnLimpiarControles();
            }
            else if (lnTipoLlamada == 1)
            {
                this.Text = "Consultar Vehiculo";
                this.Height = 500;
               
                fnOcultarObjeto(lnTipoLlamada);
            }
            else if (lnTipoLlamada == 2)
            {
                this.Text = "Consultar Vehiculo";
                this.Height = 500;
               
                fnOcultarObjeto(lnTipoLlamada);
                
               
            }
            else if (lnTipoLlamada == 3)
            {
                this.Text = "Consultar Vehiculo";
                Height = 500;
               
                fnOcultarObjeto(lnTipoLlamada);
            }
            else if (lnTipoLlamada == 4)
            {
                this.Text = "Consultar Vehiculo";
                Height = 500;
               
                fnOcultarObjeto(lnTipoLlamada);
            }
            else if (lnTipoLlamada == 5)
            {
                
                this.Text = "Consultar Vehiculo";
                tabControl1.Controls.RemoveAt(1);
                fnOcultarObjeto(lnTipoLlamada);
            }
        }
     
        private void btnCargar_Click(object sender, EventArgs e)
        {

        }
        private Boolean fnObtenerCliente()
        {
            bool bResul = false;
            clsUtil objUtil = new clsUtil();
            try
            {
                bResul = fnListarClientesActivo(true);
                if (bResul == false)
                    return false;
                if (lnTipoValor == 0)
                    cboPropietario.SelectedValue = 0;
                else
                    cboPropietario.SelectedValue =Convert.ToInt32(lcCliente);
              
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnObtenerCliente", ex.Message);
                return false;
            }
        }
        Int32 idClase=0;
        private Boolean fnObtenerMarcaV()
        {
            bool bResul = false;
            clsUtil objUtil = new clsUtil();
            try
            {
                bResul = fnListarMarcaActiva(true,Convert.ToInt32(cboClaseV.SelectedValue));
                if (bResul == false)
                    return false;
                if (lnTipoValor == 0)
                {
                    cboMarcaVh.Text ="Selec Marca";
                   
                    
                }
                //else
                //    cboMarcaVh.SelectedValue = Convert.ToInt32(lcMarca);

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnObtenerMarcaV", ex.Message);
                return false;
            }
        }

        private Boolean fnObtenerModeloV()
        {
            bool bResul = false;
            clsUtil objUtil = new clsUtil();
            try
            {
                bResul = fnListarModeloActivo(true,Convert.ToInt32(cboMarcaVh.SelectedValue));
                if (bResul == false)
                    return false;
                if (lnTipoValor == 0)
                    cboModeloVh.Text = "Selec. Modelo";
                //else
                //    cboModeloVh.SelectedValue = Convert.ToInt32(lcMarca);

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnObtenerModeloV", ex.Message);
                return false;
            }
        }

        private Boolean fnListarClientesActivo(Boolean pbEstado)
        {
            BLCliente objCliente = new BLCliente();
            clsUtil objUtil = new clsUtil();
            List<Cliente> lsCliente = new List<Cliente>();

            try
            {
                lsCliente = objCliente.blListarClientes(pbEstado);
                cboPropietario.DataSource = null;
                cboPropietario.ValueMember = "idCliente";
                cboPropietario.DisplayMember = "cCliente";
                cboPropietario.DataSource = lsCliente;

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
        private Boolean fnListarMarcaActiva(Boolean pbEstado,Int32 idClase)
        {
            BLAttrVehiculo objMarca = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            List<MarcaVehiculo> lsMarca = new List<MarcaVehiculo>();

            try
            {
                lsMarca = objMarca.blListarMarcasV(pbEstado,idClase);
                cboMarcaVh.DataSource = null;
                cboMarcaVh.ValueMember = "idMarca";
                cboMarcaVh.DisplayMember = "cNomMarca";
                cboMarcaVh.DataSource = lsMarca;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnListarMarcaActiva", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objMarca = null;
                lsMarca = null;
            }

        }

        private Boolean fnListarModeloActivo(Boolean pbEstado,Int32 idMarca)
        {
            BLAttrVehiculo objModelo = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            List<ModeloVehiculo> lsModelo = new List<ModeloVehiculo>();

            try
            {
                lsModelo = objModelo.blListarModelosV(pbEstado,idMarca);
                cboModeloVh.DataSource = null;
                cboModeloVh.ValueMember = "idModelo";
                cboModeloVh.DisplayMember = "cNomModelo";
                cboModeloVh.DataSource = lsModelo;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnListarModeloActivo", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objModelo = null;
                lsModelo = null;
            }

        }

        private void txtBuscarVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbNombre.Checked == true)
            {
                //FunValidaciones.fnValidarTipografia(e, "LETRAS", true);
                fnValidarTipografia(e, 3, true);

            }
            else if (rbPlaca.Checked == true)
            {
                FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);

            }
            if (e.KeyChar == (Char)Keys.Enter)
            {
                
                Boolean bResul = false;
                
                bResul = fnBuscarVehiculo(0, -1);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Vehiculo. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

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

            if (tabControl1.SelectedIndex == 0)
            {
                cboPaginacion.Items.Clear();

                for (Int32 i = 1; i <= cantidadPaginas; i++)
                {
                    cboPaginacion.Items.Add(i);

                }

                cboPaginacion.SelectedIndex = 0;
                btnTotalPaginas.Text = Convert.ToString(cantidadPaginas);
                btnCantRegistros.Text = Convert.ToString(totalResultados);
                btnCantTotalRegistros.Text = Convert.ToString(totalRegistros);
            }
            else
            {
                cboPaginacionM.Items.Clear();

                for (Int32 i = 1; i <= cantidadPaginas; i++)
                {
                    cboPaginacionM.Items.Add(i);

                }

                cboPaginacionM.SelectedIndex = 0;
                btnTotalPaginasM.Text = Convert.ToString(cantidadPaginas);
                btnCantRegistrosM.Text = Convert.ToString(totalResultados);
                btnCantTotalRegistrosM.Text = Convert.ToString(totalRegistros);
            }
            


        }
        private Boolean fnBuscarVehiculo(Int32 Pagina, Int16 TipoConPagina)
        {
            BLVehiculo objVehi = new BLVehiculo();
            
            DatosEnviarVehiculo objEnvio = new DatosEnviarVehiculo();
            clsUtil objUtil = new clsUtil();
            DataTable datVehiculo = new DataTable();
            Int32 filas = 20;
            Int32 totalResultados = 0;
            bool pbhabilitaLista;
            try
            {

                objEnvio.busqueda = txtBuscarVehiculo.Text.ToString().Trim();
                objEnvio.estPropietario = rbNombre.Checked;
                objEnvio.estPlaca = rbPlaca.Checked;
                
                dgVehiculo.Rows.Clear();

                datVehiculo = objVehi.blBuscarVehiculo(objEnvio, Pagina,TipoConPagina);
                totalResultados = datVehiculo.Rows.Count;
                if (datVehiculo.Rows.Count > 0)
                {
                   
                    String estado = "";
                    Int32 y;
                    if (Pagina == 0)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (Pagina - 1) * filas;
                        y = tabInicio;
                    }
                   
                    foreach (DataRow drMenu in datVehiculo.Rows)
                    {
                        y++;
                        estado = (Convert.ToBoolean(drMenu["bEstado"]) == true) ? "ACTIVO" : "INACTIVO";
                        dgVehiculo.Rows.Add(
                                Convert.ToString(drMenu["idVehiculo"]),
                                y,
                                Convert.ToString(drMenu["vPlaca"]),
                                Convert.ToString(drMenu["vSerie"]),
                                Convert.ToString(drMenu["cNombreClaseV"]),
                                Convert.ToString(drMenu["nombreMarcaV"]),
                                Convert.ToString(drMenu["nombreModeloV"]),
                                Convert.ToString(drMenu["cUsoV"]),
                                Convert.ToString(estado)
                                                );
                        
                        //lstItem.SubItems.Add(objVehiculo.vModoUso);
                        pbhabilitaLista = true;
                    }
                    dgVehiculo.Columns[1].Width = 20;
                    dgVehiculo.Columns[2].Width = 35;
                    dgVehiculo.Columns[3].Width = 80;
                    dgVehiculo.Columns[4].Width = 150;
                    dgVehiculo.Columns[5].Width = 100;
                    dgVehiculo.Columns[6].Width = 70;
                    dgVehiculo.Columns[7].Width = 70;
                    dgVehiculo.Columns[8].Width = 70;

                    if (Pagina == 0)
                    {
                        //cboPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datVehiculo.Rows[0][10]);
                        fnCalcularPaginacion(totalRegistros, filas, totalResultados);
                    }
                    
                }
                else
                {
                    //DataTable dt = new DataTable();
                    //dt.Clear();
                    //dgVehiculo.Visible = true;
                    //dt.Columns.Add("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS");
                    //dgVehiculo.DataSource = dt;
                    //gbPaginas.Visible = false;

                }
                dgVehiculo.Visible = true;
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

        

        private Boolean fnListarVehiculoEspecifico(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                    BLVehiculo objVehiculo = new BLVehiculo();
                    Vehiculo lstVehiculo = new Vehiculo();

                    if (dgVehiculo.Rows.Count > 0)
                    {
                        lstVehiculo = objVehiculo.blListarVehiculo(Convert.ToInt32(dgVehiculo.Rows[e.RowIndex].Cells[0].Value));

                        if (lstVehiculo.idVehiculo > 0)
                        {
                        lnTipoCon = 1;
                            txtidVehiculo.Text = Convert.ToString(lstVehiculo.idVehiculo);
                            cboClaseV.SelectedValue = Convert.ToInt32(lstVehiculo.idClase.ToString());
                            txtPlaca2.Text = Convert.ToString(lstVehiculo.vPlaca);
                            if (lstVehiculo.vPlaca.Length!=7)
                            {
                                chkOtro.Checked = true;
                            }
                            txtPlacaVh.Text = Convert.ToString(lstVehiculo.vPlaca);                            
                            txtSerieVh.Text = Convert.ToString(lstVehiculo.vSerie);
                            cboMarcaVh.SelectedValue = Convert.ToInt32(lstVehiculo.idMarcaV.ToString());
                            cboModeloVh.SelectedValue = Convert.ToInt32(lstVehiculo.idModeloV.ToString());
                            txtSerieVh.Text = Convert.ToString(lstVehiculo.vSerie);
                            txtAnio.Text = Convert.ToString(lstVehiculo.anio);
                            txtColorVh.Text = Convert.ToString(lstVehiculo.vColor);
                            cboModUso.SelectedValue = Convert.ToInt32(lstVehiculo.ModoUso.ToString());
                            //cboPropietario.SelectedValue = Convert.ToInt32(lstVehiculo.idCliente.ToString());
                            txtObservaciones.Text = Convert.ToString(lstVehiculo.Observaciones);

                            dgVehiculo.Visible = false;
                            fnHabilitarControles(true);
                            txtBuscarVehiculo.Text = "";
                            fnActivarTexbox(true);
                            cboMarcaVh.Enabled = true;
                            cboPropietario.Enabled = true;
                            
                            
                        }
                    }
                

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnListarVehiculoEspecifico", ex.Message);
                return false;
            }
        }

       

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Boolean lbResul = false;
            frmRegistrarModeloVehiculo frModeloV = new frmRegistrarModeloVehiculo();
            frModeloV.Inicio(1);

            lbResul = fnObtenerModeloV();
            if (!lbResul)
            {
                MessageBox.Show("Error al Agregar Modelo", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //lbResul = fnObtenerModeloV();
            //if (!lbResul)
            //{
            //    MessageBox.Show("Error al Agregar Modelo", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }


        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Boolean lbResul = false;

            frmBuscarCliente frmCliente = new frmBuscarCliente();

            frmCliente.Inicio(2);

            lbResul = fnObtenerCliente();
            if (!lbResul)
            {
                MessageBox.Show("Error al Agregar Cliente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Boolean lbResul = false;
            frmRegistrarMarcaVehiculo frmMarcaVehiculo = new frmRegistrarMarcaVehiculo();
            frmMarcaVehiculo.Inicio(1);

            lbResul = fnObtenerMarcaV();           
            if (!lbResul)
            {
                MessageBox.Show("Error al Agregar Marca", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            fnValidarTipografia(e, 2, false);
           
        }

        private void cboModeloVh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMarcaVh.SelectedIndex!=0)
            {
                var result = fnValidarCombobox(cboModeloVh, lblCboModelo, pbModelo);
                estModelo = result.Item1;
                msjModelo = result.Item2;

            }
            if (cboModeloVh.SelectedIndex == 0)
            {
                //cboModUso.Enabled = false;
                pbModoUso.Image = null;
                lblCboModoUso.Text = "";
            }
            else
            {
                cboModUso.Enabled = true;
            }

        }

        private void txtAnio_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtAnio, lblAnio, pbAnio, true, true, true, 4, 4, 4, 4, "Ingrese correctamente el campo año de modelo");

            estAnio = result.Item1;
            msjAnio = result.Item2;
        }

        private void txtColorVh_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtColorVh, lblColor, pbColor,true, true, true, 3, 100, 100, 100, "Ingrese correctamente el campo color");
            estColor = result.Item1;
            msjColor = result.Item2;
        }

        private void txtColorVh_KeyPress(object sender, KeyPressEventArgs e)
        {
            fnValidarTipografia(e, 1, true);
        }

        private void cboModUso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClaseV.SelectedIndex!=0 && cboModeloVh.SelectedIndex!=0)
            {
                var result = fnValidarCombobox(cboModUso, lblCboModoUso, pbModoUso);
                estUso = result.Item1;
                msjUso = result.Item2;
            }
            
        }

        private void cboPropietario_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboPropietario.SelectedValue != null)
            //{
            //    //Boolean lbResult = false;
            //    //lbResult = fnObtenerClienteEspecifico();
            //    //if (!lbResult)
            //    //{
            //    //    cboPropietario.SelectedIndex = 0;
            //    //    MessageBox.Show("Error al Obtener Cliente Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    //}
            //}
            //var result = fnValidarCombobox(cboPropietario, lblCboPropietario, pbPropietario);
            //estPropietario = result.Item1;
            //msjPropietario = result.Item2;
        }

        private void txtObservaciones_TextChanged(object sender, EventArgs e)
        {
            //if (lnTipoCon == 1)
            //{
            //    var resultObservacion = FunValidaciones.fnValidarTexboxs(txtObservaciones, lblObservacion, pbObsevacion,true, true, true, 15, 200, 200, 200, "Describir correctamente el/los cambios realizados");
            //    estObservaciones = resultObservacion.Item1;
            //    msjObservaciones = resultObservacion.Item2;
            //}
            //else
            //{
                var resultObservacion = FunValidaciones.fnValidarTexboxs(txtObservaciones, lblObservacion, pbObsevacion, false,true,false,0, 0, 0, 200,"Ingrese una descripcion valida");
                estObservaciones = resultObservacion.Item1;
                msjObservaciones = resultObservacion.Item2;
            //}
            

          
        }

        private void txtObservaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }



        

        private void button1_Click(object sender, EventArgs e)
        {

            frmBuscarCliente frmCliente = new frmBuscarCliente();

            frmCliente.Inicio(1);

            Boolean lbResul = false;
            lbResul = fnObtenerCliente();
            if (!lbResul)
            {
                MessageBox.Show("Error al Agregar Cliente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void gbDatosVehiculo_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        void fnHabilitarPickchureBox(Boolean estado)
        {
            pbClase.Visible = estado;
            pbPlaca.Visible = estado;
            pbMarca.Visible = estado;
            pbModelo.Visible = estado;
            pbModoUso.Visible = estado;
            pbSerie.Visible = estado;
            pbAnio.Visible = estado;
            pbColor.Visible = estado;
            pbObsevacion.Visible = estado;
        }
      

        private bool fnMandarVehiculoYCliente()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                //if (lvVehiculo.Items.Count > 0)
                //{
                    BLVehiculo objVehiculo = new BLVehiculo();
                    VehiculoYCliente lstVehiculo = new VehiculoYCliente();

                    //ListView.SelectedListViewItemCollection item = lvVehiculo.SelectedItems;
                    //if (item.Count > 0)
                    //{
                    //    Int32 getIdTabla = Convert.ToInt32(item[0].SubItems[0].Text);

                    //    //lstVehiculo = objVehiculo.blListarVehiculo(getIdTabla);

                        
                    //}
                //}

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnListarVehiculoEspecifico", ex.Message);
                return false;
            }
        }
       
        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            fnHabilitarControles(true);
            fnActivarTexbox(true);
            fnHabilitarPickchureBox(true);
            btnEditar.Enabled = false;

        }

        

       
        

        private void dgVehiculo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                lnTipoAccion = 1;
                bResul = fnListarVehiculoEspecifico(e);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Vehiculo Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }else if (lnTipoLlamada == 1)
            {
                Boolean bResult = false;
                bResult = fnMandarVehiculoYCliente();
            }else if (lnTipoLlamada == 5)
            {
                Boolean bResult = false;
                bResult = fnSeleccionarVehiculoEnviarVenta(e);

                if (bResult)
                {
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Error", "No se pudo Cargar el Vehiculo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

            fnHabilitarControles(false);
            fnActivarTexbox(false);
            fnHabilitarPickchureBox(false);
            btnEditar.Enabled = true;
        }

        private bool fnSeleccionarVehiculoEnviarVenta(DataGridViewCellEventArgs e)
        {

            clsUtil objUtil = new clsUtil();
            frmRegistrarVenta frmVenta = new frmRegistrarVenta();
            Vehiculo clsVehiculo = new Vehiculo();
            try
            {
                DataGridViewRow posicion = dgVehiculo.Rows[e.RowIndex];

                clsVehiculo.idVehiculo = Convert.ToInt32($"{(posicion.Cells[0].Value)}");
                clsVehiculo.vPlaca = $"{(posicion.Cells[2].Value).ToString().Trim()}";
                clsVehiculo.vClase = $"{(posicion.Cells[4].Value).ToString().Trim()}";
                clsVehiculo.vMarcaV = $"{(posicion.Cells[5].Value).ToString().Trim()}";
                clsVehiculo.vModeloV = $"{(posicion.Cells[6].Value).ToString().Trim()}";
                clsVehiculo.vModUso = $"{(posicion.Cells[7].Value).ToString().Trim()}";
                frmVenta.fnObtenerVehiculo(clsVehiculo);

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarProveedor", "fnRecuperarProveedorEsp", ex.Message);
                return false;
            }
        }

      
        private void cboPaginacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResul = false;
            bResul = fnBuscarVehiculo(Convert.ToInt32(cboPaginacion.Text), -1);
            if (!bResul)
            {
                MessageBox.Show("Error al Buscar Vehiculo. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private DateTime fnCalcularSoloFecha(DateTime fecha)
        {
            String TextSoloFecha = fecha.ToString("yyyy/MM/dd");
            DateTime dtFecha = Convert.ToDateTime(TextSoloFecha);
            return dtFecha;
        }
        private Boolean fnBuscarConsultas(Int32 Condicion)
        {
            BLVehiculo objSimCard = new BLVehiculo();
            clsUtil objUtil = new clsUtil();
            DataTable datVehiculo = new DataTable();
            Boolean HabilitarFechas;
            Int32 totalResultados;
            try
            {
                DateTime fechaInicio = fnCalcularSoloFecha(dtHFechaInicio.Value);
                DateTime fechaFinal = fnCalcularSoloFecha(dtHfechaFinal.Value).AddDays(1);
                HabilitarFechas = Convert.ToBoolean(chkHabilitarFechas.Checked);
                dgConsultas.Rows.Clear();
                datVehiculo = objSimCard.blBuscarConsultas(txtBuscarVehiculoM.Text.ToString(), HabilitarFechas, fechaInicio, fechaFinal, Condicion);

                //FunValidaciones.fnMostrarCantidadBusquedas(btnContadorRegistros, lblCantRegistros, datEquipo.Rows.Count, true, "Cantidad de registros");
                totalResultados = Convert.ToInt32(datVehiculo.Rows.Count);
                if (datVehiculo.Rows.Count > 0)
                {
                    lblMsgMVehiculo.Visible = false;
                    dgConsultas.Visible = true;
                    foreach (DataRow drMenu in datVehiculo.Rows)
                    {
                        dgConsultas.Rows.Add(
                            Convert.ToString(drMenu["id"]),
                            Convert.ToString(drMenu["vPlaca"])+Convert.ToString(drMenu["nombre"]));
                    }
                }
                else
                {
                    dgConsultas.Visible = false;
                    dgConsultas.Rows.Clear();
                    dgMovimientoVH.Visible = false;
                    lblMsgMVehiculo.Visible = true;
                    lblMsgMVehiculo.Text = "No se encontraron resultados para la busqueda";
                }


                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }
        private void txtBuscarVehiculoM_KeyPress(object sender, KeyPressEventArgs e)
        {
            Int32 Condicion = 0;
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (rbVehiculo.Checked == true) { Condicion = 0; }
                else
                if (rbSerie.Checked == true) { Condicion = 1; }

                fnBuscarConsultas(Condicion);

            }
        }
        private Boolean fnListarDatosEspecificos(DataGridViewCellEventArgs e, Int32 Pagina, Int32 tipoCon)
        {
            BLVehiculo objVehiculo = new BLVehiculo();
            clsUtil objUtil = new clsUtil();
            DataTable datVehiculo = new DataTable();
            Boolean HabilitarFechas = false;
            Int32 filas = 20;
            try
            {
                DateTime fechaInicio = fnCalcularSoloFecha(dtHFechaInicio.Value);
                DateTime fechaFinal = fnCalcularSoloFecha(dtHfechaFinal.Value).AddDays(1);
                HabilitarFechas = Convert.ToBoolean(chkHabilitarFechas.Checked);
                
                datVehiculo = objVehiculo.blBuscarMovimientoVH(Convert.ToInt32(dgConsultas.Rows[e.RowIndex].Cells[0].Value),Pagina, tipoCon);
                Int32 totalResultadosM = Convert.ToInt32(datVehiculo.Rows.Count);

                if (datVehiculo.Rows.Count > 0)
                {          
                    dgConsultas.Visible = false;
                    lblMsgMVehiculo.Visible = false;
                    dgMovimientoVH.Rows.Clear();
                    dgMovimientoVH.Visible = true;
                    String Estado = "";
                    Int32 y;
                    if (tipoCon == -1)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (Pagina - 1) * filas;
                        y = tabInicio;
                    }
                    foreach (DataRow drMenu in datVehiculo.Rows)
                    {
                        y++;
                        if (Convert.ToBoolean(drMenu["M_bEstado"])==true)
                        {
                            Estado = "ACTIVO";
                        }
                        else
                        {
                            Estado = "INACTIVO";
                        }
                        dgMovimientoVH.Rows.Add(
                            y,
                            Convert.ToString(drMenu["M_vPlaca"]),
                            Convert.ToString(drMenu["M_vSerie"]),
                            Convert.ToString(drMenu["M_dFechaRegistro"]),
                            Convert.ToString(drMenu["cNombreClaseV"]),
                            Convert.ToString(drMenu["nombreMarcaV"]),
                            Convert.ToString(drMenu["nombreModeloV"]),
                            Convert.ToString(drMenu["cUsoV"]),
                            Convert.ToString(drMenu["M_vAnio"]),
                            Convert.ToString(drMenu["M_vColor"]),
                            Convert.ToString(drMenu["M_vObservaciones"]),
                            Estado,
                            Convert.ToString(drMenu["cUser"])

                            );
                    }
                    dgMovimientoVH.Columns[0].Width = 20;
                    dgMovimientoVH.Columns[1].Width = 50;
                    dgMovimientoVH.Columns[2].Width = 100;
                    dgMovimientoVH.Columns[3].Width = 100;
                    dgMovimientoVH.Columns[4].Width = 80;
                    dgMovimientoVH.Columns[5].Width = 50;
                    dgMovimientoVH.Columns[6].Width = 60;
                    dgMovimientoVH.Columns[7].Width = 60;
                    dgMovimientoVH.Columns[8].Width = 50;
                    dgMovimientoVH.Columns[9].Width = 50;
                    dgMovimientoVH.Columns[11].Width = 70;
                    dgMovimientoVH.Columns[12].Width = 70;

                    if (tipoCon == -1)
                    {
                        //cboPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datVehiculo.Rows[0][14]);
                        fnCalcularPaginacion(totalRegistros, filas, totalResultadosM);
                    }

                }
                else
                {
                    dgConsultas.Visible = false;
                    lblMsgMVehiculo.Text = "No se encontraron resultados";
                    lblMsgMVehiculo.Visible = true;
                    dgMovimientoVH.Visible = false;
                    //dgMovimientoVH.Rows.Add("No se encontraron resultados");
                    //lblMsgHistorial.Text = "No se encontraron resultados para la busqueda";
                }


                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private void chkHabilitarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechas.Checked==true)
            {
                dtHFechaInicio.Enabled = true;
                dtHfechaFinal.Enabled = true;
            }
            else
            {
                dtHFechaInicio.Enabled = false;
                dtHfechaFinal.Enabled = false;
            }
        }
        private Boolean fnListarHistorial(SiticoneDataGridView dgv)
        {
            BLProspecto objAcc = new BLProspecto();
            ProspectosPlan lstPros = new ProspectosPlan();
            DataTable dtAccesorio = new DataTable();
            clsUtil objUtil = new clsUtil();
            String Imei = "";
            String Placa = "";
            try
            {

                Placa = (Convert.ToString(dgv.Rows[dgv.CurrentRow.Index].Cells[2].Value.ToString())=="")?Convert.ToString(dgv.Rows[dgv.CurrentRow.Index].Cells[3].Value.ToString()): Convert.ToString(dgv.Rows[dgv.CurrentRow.Index].Cells[2].Value.ToString());
                if (Placa.Length!=7){ rbSerie.Checked = true; } else { rbVehiculo.Checked = true; }
                txtBuscarVehiculoM.Text = Placa;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;
            }
        }
        private void opcHistorial_Click(object sender, EventArgs e)
        {
            fnListarHistorial(dgVehiculo);
            tabControl1.SelectedIndex = 1;
            Int32 Condicion = 0;
            if (rbVehiculo.Checked == true) { Condicion = 0; }
            else
            if (rbSerie.Checked == true) { Condicion = 1; }

            fnBuscarConsultas(Condicion);
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {

                Boolean bResul = false;

                bResul = fnBuscarVehiculo(0, -1);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Vehiculo. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

        }

        private void dgConsultas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Int32 Condicion = 0;
            //if (rbVehiculo.Checked == true) { Condicion = 0; }
            //else
            //if (rbCliente.Checked == true) { Condicion = 1; }


            fnListarDatosEspecificos(e,0, -1);
            //fnListarDatosEspecificos(e, Condicion);
        }

        private void btnNuevoHistorial_Click(object sender, EventArgs e)
        {
            txtBuscarVehiculoM.Text = "";
            dgConsultas.Visible = false;
        }

        private Boolean fnLLenarClaseVehiculo()
        {
            BLAttrVehiculo objClaseV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            List<ClaseVehiculo> lstClase = new List<ClaseVehiculo>();

            try
            {
                lstClase = objClaseV.blDevolverClaseVehiculo(0,false,lnTipoCon);
                cboClaseV.ValueMember = "idClase";
                cboClaseV.DisplayMember = "cNomClase";
                cboClaseV.DataSource = lstClase;

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

        
        private Boolean fnLLenarClientes()
        {
            BLCliente objClaseV = new BLCliente();
            clsUtil objUtil = new clsUtil();
            List<Cliente> lstClase = new List<Cliente>();

            try
            {
                lstClase = objClaseV.blDevolverClientesV(0);
                cboPropietario.ValueMember = "idCliente";
                cboPropietario.DisplayMember = "cCliente";
                cboPropietario.DataSource = lstClase;

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
        private void fnActivarPlaca(Int32 EstadoPlaca)
        {
            if (EstadoPlaca == 0)
            {
                txtPlacaVh.Text = "";
                txtPlacaVh.Visible = false;
                txtPlacaVh.Enabled = false;
                lblPlaca.Visible = false;
                lblPlacaVehiculo.Visible = false;
                fnHabilitarControles(true);
                fnActivarCombobox(true, 0);
                fnActivarTexbox(true);
            }
            else
            {
                fnActivarCombobox(false, 0);
                lblPlacaVehiculo.Visible = true;
                fnActivarTexbox(false);
                lblPlaca.Visible = true;
                txtPlacaVh.Visible = true;
                txtPlacaVh.Enabled = true;
            }
            //fnActivarCombobox(true, 0);
        }
        private void fnLLenarEstadoPlaca(SiticoneTextBox txt)
        {

            BLAttrVehiculo objMarcaV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            Int32 EstadoPlaca = 0;

            try
            {
                
                EstadoPlaca = objMarcaV.blDevolverEstadoPlaca(Convert.ToInt32(cboClaseV.SelectedValue));
                fnActivarPlaca(EstadoPlaca);

                txt.Text = Convert.ToString(EstadoPlaca);

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLLnenarProvinciaxDepa", ex.Message);
                
            }
            finally
            {
            }
        }
        private Boolean fnLLenarMarcaxClase(Int32 idClase)
        {

            BLAttrVehiculo objMarcaV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            List<MarcaVehiculo> lstMarcaV = new List<MarcaVehiculo>();

            try
            {

                lstMarcaV = objMarcaV.blDevolverMarcaV(idClase);
                cboMarcaVh.DataSource = null;
                cboMarcaVh.ValueMember = "idMarca";
                cboMarcaVh.DisplayMember = "cNomMarca";
                cboMarcaVh.DataSource = lstMarcaV;

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

        private Int32 fnValidarPlaca(String txtPlaca,String txtPlaca2, Int16 pnTipoCon)
        {
            BLAttrVehiculo objMarcaV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            Int32 validarPlaca=0;
            try
            {
                validarPlaca = objMarcaV.blDevolverValidarPlaca(txtPlaca, txtPlaca2,pnTipoCon);  
                return validarPlaca;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLLnenarProvinciaxDepa", ex.Message);
                return validarPlaca;
            }
            finally
            {
            }
        }

        private Boolean fnLLenarUsoxClase(Int32 idClase)
        {
            BLAttrVehiculo objMarcaV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();

            List<ModUsoVehiculo> lstMarcaV = new List<ModUsoVehiculo>();

            try
            {

                lstMarcaV = objMarcaV.blDevolverModUsoV(idClase);
                cboModUso.DataSource = null;
                cboModUso.ValueMember = "idUso";
                cboModUso.DisplayMember = "cUso";
                cboModUso.DataSource = lstMarcaV;

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

        private Boolean fnLLenarModeloxMarca(Int32 idMarca)
        {
            BLAttrVehiculo objMarcaV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            List<ModeloVehiculo> lstMarca = new List<ModeloVehiculo>();

            try
            {
                lstMarca = objMarcaV.blDevolverModeloV(idMarca);
                cboModeloVh.ValueMember = "idModelo";
                cboModeloVh.DisplayMember = "cNomModelo";
                cboModeloVh.DataSource = lstMarca;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarModeloV", ex.Message);
                return false;
            }
            finally
            { lstMarca = null; }
        }
        private void cboClaseV_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkOtro.Checked = false;
            idClase =Convert.ToInt32(cboClaseV.SelectedValue);
            var result = fnValidarCombobox(cboClaseV, lblCboClase, pbClase);
            estClase = result.Item1;
            msjClase = result.Item2;
            if (cboClaseV.SelectedIndex == 0)
            {
                cboMarcaVh.Enabled = false;
                cboModeloVh.Enabled = false;
                cboModUso.Enabled = false;
                txtPlacaVh.Enabled = false;
                cboPropietario.Enabled = false;
                pbMarca.Image = null;

                fnActivarTexbox(false);
            }
            else
            {
                txtPlacaVh.Enabled = true;
                cboModUso.Enabled = true;

            }

            if (lnTipoCon==0 && txtPlacaVh.Text.Trim()!="")
            {
                txtPlacaVh.Text = " ".Trim();

            }
            

            if (Convert.ToInt32(cboClaseV.SelectedValue) != 0)
            {
                fnLLenarEstadoPlaca(txtConPlaca);
                Boolean bResul = false;
                bResul = fnLLenarMarcaxClase(Convert.ToInt32(cboClaseV.SelectedValue));

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Provincias por Departamento", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                bResul = fnLLenarUsoxClase(Convert.ToInt32(cboClaseV.SelectedValue));

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Provincias por Departamento", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void cboMarcaVh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClaseV.SelectedValue != null && cboMarcaVh.SelectedValue != null)
            {
                Boolean bResul = false;
                bResul = fnLLenarModeloxMarca(Convert.ToInt32(cboMarcaVh.SelectedValue));

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Modelos por Marca", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (estPlaca==true)
            {
                var result = fnValidarCombobox(cboMarcaVh, lblCboMarca, pbMarca);
                estMarca = result.Item1;
                msjMarca = result.Item2;
            }
            else
            {
                lblCboMarca.Text = "";
                pbMarca.Image = null;
            }
            
            if (cboMarcaVh.SelectedIndex == 0)
            {
                cboModeloVh.Enabled = false;
                pbModelo.Image = null;
                lblCboModelo.Text = "";
            }
            else
            {
                cboModeloVh.Enabled = true;
            }
            
        }

        private void txtSerieVh_KeyPress(object sender, KeyPressEventArgs e)
        {
            fnValidarTipografia(e,3,true);
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (chkOtro.Checked==true)
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            else 
            {
                fnValidarTipografia(e, 3, true);

                Int32 cursorPos = txtPlacaVh.Text.Length;
                if (cboClaseV.Text == "VEHICULO MENOR" || cboClaseV.Text == "MOTOTAXI")
                {
                    if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '-')
                    {
                        if (cursorPos < 4)
                        {

                        }
                        else if (cursorPos == 4 && e.KeyChar != '-')
                        {

                            txtPlacaVh.Text = txtPlacaVh.Text.Insert(cursorPos, "-");
                            txtPlacaVh.Select((cursorPos + 1), 4);



                            if (!Char.IsDigit(e.KeyChar))
                            {
                                e.Handled = true;
                            }
                        }

                        else if (cursorPos == 7)
                        {
                            e.Handled = true;
                        }
                    }

                }
                else
                {

                    if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '-')
                    {
                        if (cursorPos < 3)
                        {

                        }
                        else if (cursorPos == 3 && e.KeyChar != '-')
                        {

                            txtPlacaVh.Text = txtPlacaVh.Text.Insert(cursorPos, "-");
                            txtPlacaVh.Select((cursorPos + 1), 4);



                            if (!Char.IsDigit(e.KeyChar))
                            {
                                e.Handled = true;
                            }
                        }

                        else if (cursorPos == 7)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void txtPlacaVh_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtConPlaca.Text) == 0)
            {
                var result = FunValidaciones.fnValidarTexboxs(txtPlacaVh, lblPlaca, pbPlaca, false, true, false, 0, 0,0, 0, "");
                estPlaca = result.Item1;
                msjPlaca = result.Item2;
            }
            else
            {
                if (chkOtro.Checked == true)
                {
                    txtPlacaVh.MaxLength = 25;
                    //var result = fnValidarTexbox(txtPlacaVh, lblPlaca, pbPlaca, false,0,true);
                    var result = FunValidaciones.fnValidarTexboxs(txtPlacaVh, lblPlaca, pbPlaca, true, true, true, 4, 25, 25, 25, "Ingrese correctamente este campo");
                    estPlaca = result.Item1;
                    msjPlaca = result.Item2;

                }
                else
                {

                    //var result = fnValidarTexbox(txtPlacaVh, lblPlaca, pbPlaca, true, 7,true);
                    var result = FunValidaciones.fnValidarTexboxs(txtPlacaVh, lblPlaca, pbPlaca, true, true, true, 7, 7, 7, 7, "Ingrese placa correctamente");
                    estPlaca = result.Item1;
                    msjPlaca = result.Item2;
                    if (txtPlacaVh.Text.Length == 7 && lnTipoAccion == 0)
                    {
                        Int32 ValidaPlaca = fnValidarPlaca(txtPlacaVh.Text.Trim(), txtPlaca2.Text.Trim(), lnTipoCon);
                        if (ValidaPlaca == 1)
                        {
                            var resultExistencia = fnValidaDatosDuplicados(txtPlacaVh, lblPlaca, pbPlaca, true, true);
                            estPlaca = resultExistencia.Item1;
                            msjPlaca = resultExistencia.Item2;

                            MessageBox.Show(msjPlaca = resultExistencia.Item2, "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            fnActivarCombobox(false, 0);
                            fnActivarTexbox(false);
                            cboPropietario.Enabled = true;

                        }
                        //else if (ValidaPlaca != 0 || cboDescripVEspecial.SelectedIndex != 0)
                        //{
                        //    var resultExistencia = fnValidaDatosDuplicados(txtPlacaVh, lblPlaca, pbPlaca, true, false);
                        //    estPlaca = resultExistencia.Item1;
                        //    msjPlaca = resultExistencia.Item2;

                        //    cboMarcaVh.Enabled = true;
                        //    fnActivarTexbox(true);
                        //    cboPropietario.Enabled = true;
                        //}
                    }
                    else if ((txtPlacaVh.Text.Length == 7 && lnTipoAccion == 1))
                    {
                        Int32 ValidaPlaca = fnValidarPlaca(txtPlacaVh.Text.Trim(), txtPlaca2.Text.Trim(), lnTipoCon);

                        if (ValidaPlaca == 1)
                        {
                            var resultExistencia = fnValidaDatosDuplicados(txtPlacaVh, lblPlaca, pbPlaca, true, true);
                            estPlaca = resultExistencia.Item1;
                            msjPlaca = resultExistencia.Item2;
                            MessageBox.Show(msjPlaca = resultExistencia.Item2 + " ", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        cboMarcaVh.Enabled = true;
                        fnActivarTexbox(true);
                        cboPropietario.Enabled = true;
                    }
                    else if (txtPlacaVh.Text.Length < 3)
                    {
                        fnActivarCombobox(false, 0);
                        fnActivarTexbox(false);
                    }
                    else
                    {
                        fnActivarCombobox(true, 0);
                        fnActivarTexbox(true);
                    }
                }
            }

            //fnValidarTexbox(txtPlacaVh, lblPlaca,pbPlaca,true,true,7);
        }

        private void chkOtro_CheckedChanged(object sender, EventArgs e)
        {
            txtPlacaVh.Text = "";
            if (chkOtro.Checked==true)
            {
                txtPlacaVh.Width = 260;
                pbPlaca.Location = new Point(557, 68);
                fnActivarCombobox(true, 0);
                fnActivarTexbox(true);
            }
            else
            {
                txtPlacaVh.Width = 129;
                pbPlaca.Location = new Point(426, 67);
                fnActivarCombobox(false, 0);
                fnActivarTexbox(false);
            }
        }

        private void txtSerieVh_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtSerieVh, lblSerie, pbSerie, true, true,true, 5, 17, 17, 17, "Ingrese correctamente el campo serie");
            estSerie = result.Item1;
            msjSerie = result.Item2;
        }

        private Boolean fnObtenerClienteEspecifico()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (cboPropietario.SelectedValue != null)
                {
                    BLCliente objCli = new BLCliente();
                    Cliente lstCliente = new Cliente();

                    lstCliente = objCli.blListarCliente(0,1);

                    if (lstCliente.idCliente > 0)
                    {
                        txtColorVh.Text = Convert.ToString(lstCliente.cDireccion);
                        lblSerie.Text = Convert.ToString(lstCliente.cTiDo);
                        txtSerieVh.Text = Convert.ToString(lstCliente.cDocumento);
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmDocumentoVenta", "fnListarClienteEspecifico", ex.Message);
                return false;
            }
        }
       
    }

}
