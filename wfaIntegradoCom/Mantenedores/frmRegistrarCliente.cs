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
using wfaIntegradoCom.Procesos;
using wfaIntegradoCom.Consultas;
using System.Net.Mail;
using Siticone.UI.WinForms;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmRegistrarCliente : Form
    {
        public frmRegistrarCliente()
        { 
            InitializeComponent();

        }

        static Boolean pasoLoad;

        public static List<TipoDocumento> lstTD = new List<TipoDocumento>();

        Int16 lnTipoCon = 0;
        Int16 lnTipoLlamada = 0;
        Boolean estActualizar;
        // CARGAR TODOS LOS CAMPOS CON ESTADO FALSE PARA VALIDAR
        Boolean estTipoCliente, estTipoDocumento,
            estDepartamento, estProvincia, estDistrito,
            estNombre, estApellidoPaterno,
            estApellidoMaterno, estNroDocumento,
            estTelefonoCelular, estDireccion, estTelefonoFijo,
            estCorreo, estFechaNacimiento, estNombreContacto1,estNombreContacto2,
            estCelularContacto1,estCelularContacto2,estEmpresa,estEstado;
        ////VARAIBLES PARA LOS MENSAJES DE ERROR
        String msjTipoCliente,msjNombre,msjApellidoMaterno,
            msjApellidoPaterno,msjTipoDocumento,msjNroDocumento,
            msjTelefonoFijo,msjTelefonoCelular,msjCorreo,msjFechaNaciemiento,
            msjDepartamento,msjProvincia,msjDistrito,msjDireccion,msjNombreContacto1,
            msjNombreContacto2,msjCelularContacto1,msjCelularContacto2,msjEmpresa,msjEstado;

        static Int32 tabInicio = 0;
        private Tuple<Boolean, String> fnValidarTexbox(SiticoneTextBox txt,Label lbl, PictureBox img, Boolean maximo, Int32 num)
        {
            String msj;
            
            if (txt.Text == null || txt.Text.Trim() == "")
            {
                img.Image = Properties.Resources.error;
                msj = "Ingrese datos (campo obligatorio)";
                lbl.Text = msj;
                
                return Tuple.Create(false,msj);

            }
            else if (maximo)
            {
                if (txt.Text.Length >= num)
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

        private Tuple<Boolean, String> fnValidarTexboxDocumentoSQL(SiticoneTextBox txt, Label lbl, PictureBox img,Int32 num,Boolean caracObli, String caracter)
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
            else
            {
                if (txt.Text.Length >= num)
                {
                    txt.MaxLength = num;
                    if (caracObli)
                    {
                        String validar = txt.Text;
                        String DosPrimerosdigitos = validar.Substring(0, 2);
                        if (DosPrimerosdigitos == caracter)
                        {
                            if (estActualizar)
                            {
                                if (txtValidarDocumento.Text.Trim() == txtNrDocumento.Text.Trim())
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
                                    bResul = fnBuscarNrDocumento(txt.Text.Trim(), pnTipocon);
                                    return Tuple.Create(bResul, msj);

                                }

                            }
                            else
                            {
                                img.Image = Properties.Resources.ok;
                                msj = "";
                                lbl.Text = msj;
                                bResul = fnBuscarNrDocumento(txt.Text.Trim(), pnTipocon);

                                return Tuple.Create(bResul, msj);
                            }
                        }
                        else
                        {
                            img.Image = Properties.Resources.error;
                            msj = $"El Nr. de Documento debe empezar con: {caracter}";
                            lbl.Text = msj;

                            return Tuple.Create(false, msj);
                        }
                    }
                    else
                    {
                        if (estActualizar)
                        {
                            if (txtValidarDocumento.Text.Trim() == txtNrDocumento.Text.Trim())
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
                                bResul = fnBuscarNrDocumento(txt.Text.Trim(), pnTipocon);
                                return Tuple.Create(bResul, msj);

                            }

                        }
                        else
                        {
                            img.Image = Properties.Resources.ok;
                            msj = "";
                            lbl.Text = msj;
                            bResul = fnBuscarNrDocumento(txt.Text.Trim(), pnTipocon);

                            return Tuple.Create(bResul, msj);
                        }
                    }
                }
                else
                {
                    img.Image = Properties.Resources.error;
                    msj = "Datos incompletos (campo obligatorio)";
                    lbl.Text = msj;

                    return Tuple.Create(false, msj);

                }
            }
            
        }
        void fnLimpiarValidacion(Boolean estado)
        {
             estTipoCliente = estado;
             estTipoDocumento = estado;
             estDepartamento = estado;
             estProvincia = estado;
             estDistrito = estado;

             estNombre = estado;
             estApellidoPaterno = estado;
             estApellidoMaterno = estado;
             estNroDocumento = estado;
             estTelefonoCelular = estado;
             estDireccion = estado;
             estTelefonoFijo = true;
             estCorreo = true;
             estFechaNacimiento = estado;
             estActualizar = false;
        }
        

        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();
        }
        private Boolean fnBuscarNrDocumento(String pcBuscar,Int16 pnTipoCon)
        {
            BLCliente objCli = new BLCliente();
            clsUtil objUtil = new clsUtil();
            Int16 numResult = 0;
            
            try
            {
                
                numResult = objCli.blBuscarNroDocumento(pcBuscar, pnTipoCon);

                if(numResult == 1)
                {
                    erNrDocumento.Text = "Este documento ya existe (Ingrese otro cliente)";
                    erNrDocumento.ForeColor = Color.Red;
                    imgNroDocumento.Image = Properties.Resources.error;
                    return false;
                }
                else if (numResult == 0)
                {
                    erNrDocumento.Text = "";
                    imgNroDocumento.Image = Properties.Resources.ok;
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnBuscarCliente", ex.Message);
                return false;
            }
            finally
            {
                
                objCli = null;
                objUtil = null;
            }
        }
        private Boolean fnBuscarCliente(DataGridView dgv,Int32 numPagina, Int16 tipoCon)
        {
            BLCliente objCli = new BLCliente();
            clsUtil objUtil = new clsUtil();
            
            DataTable dtCliente = new DataTable();
            Int32 filas = 15;
            String nroDocumento;
            String nombreCliente;
            Int32 idTipoPersona;
            Int32 idTipoDocumento;
            String estCliente;
            String estado;
            try
            {
                if(cboEstadoBuscar.SelectedIndex  == 1)
                {
                    estCliente = "1";
                }
                else if(cboEstadoBuscar.SelectedIndex == 2)
                {
                    estCliente = "0";
                }
                else
                {
                    estCliente = "";
                }
                nroDocumento = Convert.ToString(txtNroDocumentoBuscar.Text.ToString());
                nombreCliente = Convert.ToString(txtNombreBuscar.Text.ToString());
                idTipoPersona = Convert.ToInt32(cboTipoClienteBuscar.SelectedValue.ToString());
                idTipoDocumento = Convert.ToInt32(cboTipoDocumentoBuscar.SelectedValue.ToString());

                dtCliente = objCli.blBuscarCliente(nroDocumento, nombreCliente, idTipoPersona, idTipoDocumento, estCliente, numPagina, tipoCon);
             
                Int32 totalResultados = dtCliente.Rows.Count;
                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("NOMBRE CLIENTE");
                    dt.Columns.Add("CELULAR");
                    dt.Columns.Add("TIP. CLIENTE");
                    dt.Columns.Add("TIP. DOCUMENTO");
                    dt.Columns.Add("N° DOCUMENTO");
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

                   
                    for (int i = 0; i <= totalResultados - 1; i++)
                    {
                        y += 1;
                        if (Convert.ToBoolean(dtCliente.Rows[i][6]) == true)
                        {
                            estado = "ACTIVO";
                        }
                        else
                        {
                            estado = "INACTIVO";
                        }
                        

                        object[] row = {
                            dtCliente.Rows[i][0],
                            y,
                            dtCliente.Rows[i][1],
                            dtCliente.Rows[i][2],
                            dtCliente.Rows[i][3],
                            dtCliente.Rows[i][4],
                            dtCliente.Rows[i][5],
                            estado
                        };
                        dt.Rows.Add(row);

                    }

                    dgv.DataSource = dt;

                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 30;
                    dgv.Columns[2].Width = 150;
                    dgv.Columns[3].Width = 70;
                    dgv.Columns[4].Width = 70;
                    dgv.Columns[5].Width = 70;
                    dgv.Columns[6].Width = 70;
                    dgv.Columns[7].Width = 70;

                    dgv.Visible = true;

                    if (tipoCon == -1)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(dtCliente.Rows[0][7]);
                        fnCalcularPaginacion(
                            totalRegistros,
                            filas,
                            totalResultados,
                            cboPagina,
                            btnTotalPaginas,
                            btnNumFilas,
                            btnTotalReg
                            );
                    }
                    else
                    {
                        btnNumFilas.Text = Convert.ToString(totalResultados);
                    }


                    
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dgv.DataSource = dt;
                    dgv.Visible = true;
                    dt.Columns.Add("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS");
                    gbPaginacion.Visible = false;
                   
                }
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnBuscarCliente", ex.Message);
                return false;
            }
            finally
            {
                
                objCli = null;
                objUtil = null;
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
        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

            Boolean bResul;
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (pasoLoad)
                {
                    bResul = fnBuscarCliente(dgCliente, 0, -1);
                    if (!bResul)
                    {
                        MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

               
            }
        }

        private Boolean fnListarClienteEspecifico(SiticoneDataGridView dgv, Int32 opc)
        {
            clsUtil objUtil = new clsUtil();
            BLCliente objCli = new BLCliente();
            Cliente lstCliente;
            Int32 idCliente;

            try
            {
                idCliente = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value.ToString());
                lstCliente = objCli.blListarCliente(idCliente,opc);

                if (lstCliente.idCliente > 0)
                {
                    estActualizar = true;
                    txtValidarDocumento.Text = Convert.ToString(lstCliente.cDocumento.Trim());
                    txtIdPersonal.Text = Convert.ToString(lstCliente.idCliente);
                    cboTipoCliente.SelectedValue = Convert.ToInt32(lstCliente.cTipPers);
                    cboTipoDoc.SelectedValue =Convert.ToInt32(lstCliente.cTiDo);
                    
                    txtNrDocumento.Text = Convert.ToString(lstCliente.cDocumento.Trim());
                  
                    txtNombre.Text = Convert.ToString(lstCliente.cTipoDoc);
                    txtApePat.Text = Convert.ToString(lstCliente.cApePat);
                    txtApeMat.Text = Convert.ToString(lstCliente.cApeMat);
                    if (lstCliente.bEstado)
                    {
                        cboEstado.SelectedIndex = 1;
                    }
                    else
                    {
                        cboEstado.SelectedIndex = 2;
                    }
                    txtTelFijo.Text = Convert.ToString(lstCliente.cTelFijo);
                    txtTelCelular.Text = Convert.ToString(lstCliente.cTelCelular);
                    dtpFechaNac.Value = lstCliente.dFecNac;
                    txtDireccion.Text = Convert.ToString(lstCliente.cDireccion);
                    txtCorreo.Text = Convert.ToString(lstCliente.cCorreo.Trim());
                    cboDepartamento.SelectedValue = Convert.ToInt32(lstCliente.idDep);
                    cboProvincia.SelectedValue = Convert.ToInt32(lstCliente.idProv);
                    cboDistrito.SelectedValue = Convert.ToInt32(lstCliente.idDist);
                    txtNombreContacto1.Text = Convert.ToString(lstCliente.cContactoNom1.Trim());
                    txtNombreContacto2.Text = Convert.ToString(lstCliente.cContactoNom2.Trim());
                    txtCelularContacto1.Text = Convert.ToString(lstCliente.cContactoCel1.Trim());
                    txtCelularContacto2.Text = Convert.ToString(lstCliente.cContactoCel2.Trim());
                    txtEmpresa.Text = Convert.ToString(lstCliente.cEmpresa.Trim());
                    lnTipoCon = 1;
                }
                  

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnListarClienteEspecifico", ex.Message);
                return false;
            }
        }

        private Boolean fnRecuperarClienteEsp()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                //if (lvCliente.Items.Count > 0)
                //{
                //    ListView.SelectedListViewItemCollection item = lvCliente.SelectedItems;
                //    if (item.Count > 0)
                //    {
                //        frmDocumentoVenta.fnRecuperarCliente( item[0].Text.Trim(), item[0].SubItems[4].Text.ToString().Trim(), item[0].SubItems[3].Text.ToString().Trim(), item[0].SubItems[2].Text.ToString().Trim(), 1);                    
                //    }
                  
                //}

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnRecuperarClienteEsp", ex.Message);
                return false;
            }
        }

        private Boolean fnRecuperarClienteEspDeuda()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                //if (lvCliente.Items.Count > 0)
                //{
                //    ListView.SelectedListViewItemCollection item = lvCliente.SelectedItems;
                //    if (item.Count > 0)
                //    {
                //        frmBuscarDeudas.fnRecuperarCliente(item[0].SubItems[1].Text.ToString().Trim(), Convert.ToInt32(item[0].Text.Trim()));
                //    }
                //}

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnRecuperarClienteEspDeuda", ex.Message);
                return false;
            }
        }

        private Boolean fnRecuperarClienteEsprptVenta()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                //if (lvCliente.Items.Count > 0)
                //{
                //    ListView.SelectedListViewItemCollection item = lvCliente.SelectedItems;
                //    if (item.Count > 0)
                //    {
                //        frmReporteVenta.fnRecuperarCliente(item[0].SubItems[1].Text.ToString().Trim(), Convert.ToInt32(item[0].Text.Trim()));
                //    }
                //}

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnRecuperarClienteEsprptVenta", ex.Message);
                return false;
            }
        }

        private void fnHabilitarControles(Boolean pbHabilitar)
        {
            gboPrinci.Enabled = pbHabilitar;
            gbUbicacion.Enabled = pbHabilitar;
            gboSecun.Enabled = pbHabilitar;
            btnGuardar.Enabled = pbHabilitar;
            //txtNrDocumento.Enabled = pbHabilitar;
            gboContacto.Enabled = pbHabilitar;
            btnEditar.Enabled = pbHabilitar;
        }
        private void fnVerValidacion(Boolean pbVer)
        {
            ////LABELS/////
            erTipoCliente.Visible = pbVer;
            erNombre.Visible = pbVer;
            erApellidoPaterno.Visible = pbVer;
            erApellidoMaterno.Visible = pbVer;
            erTipoDocumento.Visible = pbVer;
            erNrDocumento.Visible = pbVer;
            erTelefonoFijo.Visible = pbVer;
            erTelefonoCelular.Visible = pbVer;
            erCorreo.Visible = pbVer;
            erFechaNacimiento.Visible = pbVer;
            erDepartemento.Visible = pbVer;
            erProvincia.Visible = pbVer;
            erDistrito.Visible = pbVer;
            erDireccion.Visible = pbVer;
            erEmpresa.Visible = pbVer;
            erNombreContacto1.Visible = pbVer;
            erNombreContacto2.Visible = pbVer;
            erCelularContacto1.Visible = pbVer;
            erCelularContacto2.Visible = pbVer;

            /////PICTUREBOX/////
            imgNombre.Visible = pbVer;
            imgApellidoMaterno.Visible = pbVer;
            imgApellidoPaterno.Visible = pbVer;
            imgNroDocumento.Visible = pbVer;
            imgTelefonoFijo.Visible = pbVer;
            imgTelefonoCelular.Visible = pbVer;
            imgCorreo.Visible = pbVer;
            imgDireccion.Visible = pbVer;
            imgTipoCliente.Visible = pbVer;
            imgTipoDocumento.Visible = pbVer;
            imgFechaNacimiento.Visible = pbVer;
            imgDepartemento.Visible = pbVer;
            imgProvincia.Visible = pbVer;
            imgDistrito.Visible = pbVer;
            imgEmpresa.Visible = pbVer;
            imgNombreContacto1.Visible = pbVer;
            imgNombreContacto2.Visible = pbVer;
            imgCelularContacto1.Visible = pbVer;
            imgCelularContacto2.Visible = pbVer;
        }

        private void fnLimpiarControles()
        {
            /////FECHAS /////

            dtpFechaNac.Value = DateTime.MinValue.AddYears(+1900);

            
            ////TEXBOXS/////
            txtNombreBuscar.Text = "";
            txtIdPersonal.Text = "0";
            txtNombre.Text = "";
            txtNrDocumento.Text = "";
            txtApePat.Text = "";
            txtApeMat.Text = "";
            txtNrDocumento.Text = "";
            txtTelFijo.Text = "";
            txtTelCelular.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtNombreContacto1.Text = "";
            txtNombreContacto2.Text = "";
            txtCelularContacto1.Text = "";
            txtCelularContacto2.Text = "";
            txtEmpresa.Text = "";
            txtValidarDocumento.Text = "";
           
            ////COMBOBOX ////
            cboTipoCliente.SelectedValue = 0;
            cboTipoDoc.SelectedValue = 0;
            cboDepartamento.SelectedValue = 0;
            cboProvincia.SelectedValue = 0;
            cboDistrito.SelectedValue = 0;
            cboEstado.SelectedIndex =1;
            ////LABELS/////
            erTipoCliente.Text = "";
            erNombre.Text = "";
            erApellidoPaterno.Text = "";
            erApellidoMaterno.Text = "";
            erTipoDocumento.Text = "";
            erNrDocumento.Text = "";
            erTelefonoFijo.Text = "";
            erTelefonoCelular.Text = "";
            erCorreo.Text = "";
            erFechaNacimiento.Text = "";
            erDepartemento.Text = "";
            erProvincia.Text = "";
            erDistrito.Text = "";
            erDireccion.Text = "";
            erEmpresa.Text = "";
            erNombreContacto1.Text = "";
            erNombreContacto2.Text = "";
            erCelularContacto1.Text = "";
            erCelularContacto2.Text = "";
            erEstado.Text = "";
          
            /////PICTUREBOX/////
            imgNombre.Image = null;
            imgApellidoMaterno.Image = null;
            imgApellidoPaterno.Image = null;
            imgNroDocumento.Image = null;
            imgTelefonoFijo.Image = null;
            imgTelefonoCelular.Image = null;
            imgCorreo.Image = null;
            imgDireccion.Image = null;
            imgTipoCliente.Image = null;
            imgTipoDocumento.Image = null;
            imgFechaNacimiento.Image = null;
            imgDepartemento.Image = null;
            imgProvincia.Image = null;
            imgDistrito.Image = null;
            imgEmpresa.Image = null;
            imgNombreContacto1.Image = null;
            imgNombreContacto2.Image = null;
            imgCelularContacto1.Image = null;
            imgCelularContacto2.Image = null;
           
            ////INICIAR EN TEXBOX BUSQUEDA////
            txtNombreBuscar.Focus();

            cboEstado.Enabled = false;
        }

        private void lvCliente_DoubleClick(object sender, EventArgs e)
        {

            
            fnValidarRadioButons();
            
            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                bResul = fnListarClienteEspecifico(dgCliente,1);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Cliente Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            else if (lnTipoLlamada == 1)
            {
                Boolean bResul = false;
                bResul = fnRecuperarClienteEsp();
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar Cliente Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else {
                    this.Dispose(); }
            }
            else if(lnTipoLlamada == 3)
            {
                Boolean bResul = false;
                bResul = fnRecuperarClienteEspDeuda();
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar Cliente Especifico en Deudas", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.Dispose();
                }
            }
            else if (lnTipoLlamada == 4)
            {
                Boolean bResul = false;
                bResul = fnRecuperarClienteEsprptVenta();
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar Cliente Especifico en Reporte de Ventas", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.Dispose();
                }
            }

            
            fnHabilitarControles(false);
           
            btnEditar.Enabled = true;
        }

        private String fnGuardarCliente(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLCliente blobjCliente = new BLCliente();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Cliente objCliente = new Cliente();
            try
            {
                
                objCliente.idCliente = Convert.ToInt32(txtIdPersonal.Text.Trim());

                objCliente.cTipPers = Convert.ToInt32(cboTipoCliente.SelectedValue.ToString());
                objCliente.bEstado = Convert.ToBoolean(cboEstado.SelectedIndex == 1 ? 1 : 0);
                objCliente.cTiDo = Convert.ToInt32(cboTipoDoc.SelectedValue.ToString());
                objCliente.cDocumento = Convert.ToString(txtNrDocumento.Text.Trim());
                objCliente.cTipoDoc = Convert.ToString(txtNombre.Text.Trim());
                objCliente.cApePat = Convert.ToString(txtApePat.Text.Trim());
                objCliente.cApeMat = Convert.ToString(txtApeMat.Text.Trim());
                objCliente.cTelFijo = Convert.ToString(txtTelFijo.Text.Trim());
                objCliente.cTelCelular = Convert.ToString(txtTelCelular.Text.Trim());
                objCliente.cCorreo = Convert.ToString(txtCorreo.Text.Trim());
                objCliente.dFecNac = Convert.ToDateTime(dtpFechaNac.Value);
                objCliente.idZona = Convert.ToInt32(cboDistrito.SelectedValue);
                objCliente.cEmpresa = Convert.ToString(txtEmpresa.Text.Trim());
                objCliente.cDireccion = Convert.ToString(txtDireccion.Text.Trim());

                objCliente.cContactoNom1 = Convert.ToString(txtNombreContacto1.Text.Trim());
                objCliente.cContactoCel1 = Convert.ToString(txtCelularContacto1.Text.Trim());
                objCliente.cContactoNom2 = Convert.ToString(txtNombreContacto2.Text.Trim());
                objCliente.cContactoCel2 = Convert.ToString(txtCelularContacto2.Text.Trim());



                objCliente.dFechaRegistro = dFechaSis;
                objCliente.idUsuario = Variables.gnCodUser;
                

                lcValidar = blobjCliente.blGrabarCliente(objCliente, idTipoCon).Trim();
                fnLimpiarControles();
                fnHabilitarControles(false);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnGuardarCliente", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

       

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private Boolean fnLLnenarProvinciaxDepa(Int32 idDepa)
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            List<Provincia> lstProv = new List<Provincia>();

            try
            {

                lstProv = objUbigeo.blDevolverProvincia(idDepa);
                cboProvincia.DataSource = null;
                cboProvincia.ValueMember = "idProv";
                cboProvincia.DisplayMember = "cNomProv";
                cboProvincia.DataSource = lstProv;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLLnenarProvinciaxDepa", ex.Message);
                return false;
            }
            finally
            { lstProv = null; }
        }

        private Boolean fnLLnenarDistritoxProvincia(Int32 idProv)
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            List<Distrito> lstDist = new List<Distrito>();

            try
            {

                lstDist = objUbigeo.blDevolverDistrito(idProv);
                cboDistrito.DataSource = null;
                cboDistrito.ValueMember = "idDist";
                cboDistrito.DisplayMember = "cNomDist";
                cboDistrito.DataSource = lstDist;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLLnenarProvinciaxDepa", ex.Message);
                return false;
            }
            finally
            { lstDist = null; }
        }

        private Boolean fnLlenarDepartamento()
        {
            BLUbigeo objUbigeo = new BLUbigeo();
            clsUtil objUtil = new clsUtil();
            List<Departamento> lstDepart = new List<Departamento>();

            try
            {
                lstDepart = objUbigeo.blDevolverDepartamento(1);
                cboDepartamento.ValueMember = "idDepa";
                cboDepartamento.DisplayMember = "cNomDep";
                cboDepartamento.DataSource = lstDepart;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        private Boolean fnLlenarTablaCod(ComboBox cboCombo, String cCodTab)
        {
            BLCargo objTablaCod = new BLCargo();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                cboCombo.DataSource = null;
                lstTablaCod = objTablaCod.blDevolverTablaCod(cCodTab);
                
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstTablaCod;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarTablaCod", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTablaCod = null;
                lstTablaCod = null;
            }

        }

        private void fnOcultarObjeto(Int16 lnTipo)
        {
            if (lnTipo==1 || lnTipo ==3 || lnTipo == 4)
            {
                gboPrinci.Visible = false;
                gbUbicacion.Visible = false;
                
            }
            else if (lnTipo == 2)
            {
                gbBuscar.Visible = false;
                txtNombreBuscar.Visible = false;
            }
        }

        private void fnValidarRadioButons()
        {
            if (lnTipoLlamada == 0)
            {
                Boolean bResult = false;

                bResult = fnLlenarDepartamento();
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Departamentos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                
                //fnHabilitarControles(true);
            }
            else if (lnTipoLlamada == 1)
            {
                this.Text = "Consultar Cliente";
                Height = 500;
                //lvCliente.Visible = true;
                //lvCliente.Left = 12;
                //lvCliente.Top = 60;
                //lvCliente.Height = 390;
                //lvCliente.Width = 635;
                ////fnOcultarObjeto(lnTipoLlamada);
            }
            else if (lnTipoLlamada == 2)
            {
                Boolean bResult = false;

                bResult = fnLlenarDepartamento();
                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Departamentos", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                
                //fnHabilitarControles(false);
                //fnOcultarObjeto(lnTipoLlamada);
            }
            else if (lnTipoLlamada == 3)
            {
                this.Text = "Consultar Cliente";
                Height = 500;
                //lvCliente.Visible = true;
                //lvCliente.Left = 12;
                //lvCliente.Top = 60;
                //lvCliente.Height = 390;
                //lvCliente.Width = 635;
                //fnOcultarObjeto(lnTipoLlamada);
            }
            else if (lnTipoLlamada == 4)
            {
                this.Text = "Consultar Cliente";
                Height = 500;
                //lvCliente.Visible = true;
                //lvCliente.Left = 12;
                //lvCliente.Top = 60;
                //lvCliente.Height = 390;
                //lvCliente.Width = 635;
                //fnOcultarObjeto(lnTipoLlamada);
            }
        }

        private void frmRegistrarCliente_Load(object sender, EventArgs e)
        {
            pasoLoad = false;
            Boolean bResult;
            fnHabilitarControles(false);
            estActualizar = false;
            cboEstadoBuscar.SelectedIndex = 0;
            bResult = fnLLenarTipoPersona(cboTipoCliente, 0, "1",false);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar el Cliente", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            fnValidarRadioButons();
           
            bResult = fnLLenarTipoPersona(cboTipoClienteBuscar, 0, "", true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar el Cliente", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            fnLimpiarValidacion(false);
            fnLimpiarControles();
            FunValidaciones.fnColorTresBotones(btnNuevo, btnEditar, btnGuardar);
            pasoLoad = true;
        }

        private Boolean fnLLenarTipoPersona(ComboBox cbo, Int32 idTipoCliente, String est,Boolean buscar)
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
        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cboDepartamento.SelectedValue != null)
            {
                Boolean bResul = false;
                bResul = fnLLnenarProvinciaxDepa(Convert.ToInt32(cboDepartamento.SelectedValue));

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Provincias por Departamento", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            Int16 cboSelect = Convert.ToInt16(cboDepartamento.SelectedValue);
            
            if (cboSelect == 0)
            {
                cboProvincia.Enabled = false;
                cboDistrito.Enabled = false;

            }
            else
            {
                cboProvincia.Enabled = true;
            }
            var result = fnValidarCombobox(cboDepartamento, erDepartemento, imgDepartemento);

            estDepartamento = result.Item1;
            msjDepartamento = result.Item2;
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboProvincia.SelectedValue != null)
            {
                Boolean bResul = false;
                bResul = fnLLnenarDistritoxProvincia(Convert.ToInt32(cboProvincia.SelectedValue));

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Provincias por Departamento", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            String valorSeleccionado;

            
            if(cboProvincia.SelectedValue == null)
            {
                valorSeleccionado = "0"; 
            }
            else
            {
                valorSeleccionado = cboProvincia.SelectedValue.ToString().Trim();
            }

            if (valorSeleccionado == "0")
            {
               
                cboDistrito.Enabled = false;

            }
            else
            {
                cboDistrito.Enabled = true;
            }
            var result =fnValidarCombobox(cboProvincia, erProvincia,imgProvincia);
            estProvincia = result.Item1;
            msjProvincia = result.Item2;
        }

       


        private void txtNombreContacto1_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true);
        }

        private void txtNombreContacto2_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true);
        }

        private void txtCelularContacto1_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", true);
            Int32 cursorPos = txtCelularContacto1.Text.Length;

            if (cursorPos == 3 && !(Char.IsControl(e.KeyChar)))
            {
                txtCelularContacto1.Text = txtCelularContacto1.Text.Insert(cursorPos, "-");
                txtCelularContacto1.Select((cursorPos + 1), 4);


            }
            else if (cursorPos == 7 && !(Char.IsControl(e.KeyChar)))
            {
                txtCelularContacto1.Text = txtCelularContacto1.Text.Insert(cursorPos, "-");
                txtCelularContacto1.Select((cursorPos + 1), 4);


            }
            else if (cursorPos == 11 && !(Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtCelularContacto1_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexbox(txtCelularContacto1, erCelularContacto1, imgCelularContacto1, true, 11);

            estCelularContacto1 = result.Item1;
            msjCelularContacto1 = result.Item2;
        }

        private void txtCelularContacto2_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS",false);
            Int32 cursorPos = txtCelularContacto2.Text.Length;

            if (cursorPos == 3 && !(Char.IsControl(e.KeyChar)))
            {
                txtCelularContacto2.Text = txtCelularContacto2.Text.Insert(cursorPos, "-");
                txtCelularContacto2.Select((cursorPos + 1), 4);


            }
            else if (cursorPos == 7 && !(Char.IsControl(e.KeyChar)))
            {
                txtCelularContacto2.Text = txtCelularContacto2.Text.Insert(cursorPos, "-");
                txtCelularContacto2.Select((cursorPos + 1), 4);


            }
            else if (cursorPos == 11 && !(Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtNombreContacto2_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexbox(txtNombreContacto2, erNombreContacto2, imgNombreContacto2,true,10);
            estNombreContacto2 = result.Item1;
            msjNombreContacto2 = result.Item2;
        }

        private void txtCelularContacto2_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexbox(txtCelularContacto2, erCelularContacto2, imgCelularContacto2,true, 11);

            estCelularContacto2 = result.Item1;
            msjCelularContacto2 = result.Item2;
        }

        
       

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            fnLimpiarValidacion(false);
            btnEditar.Enabled = false;
            fnLimpiarControles();
            
            gboPrinci.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            fnHabilitarControles(true);
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String lcResultado = "";
            
            var result1 = fnValidarCombobox(cboTipoCliente, erTipoCliente, imgTipoCliente);
            estTipoCliente = result1.Item1;
            msjTipoCliente = result1.Item2;

            var result2 = fnValidarCombobox(cboTipoDoc, erTipoDocumento, imgTipoDocumento);
            estTipoDocumento = result2.Item1;
            msjTipoDocumento = result2.Item2;

            txtdni_TextChanged(sender, e);
            txtPrimerNom_TextChanged(sender, e);
            txtApePat_TextChanged(sender, e);
            txtApeMat_TextChanged(sender, e);
            txtTelFijo_TextChanged(sender, e);
            txtTelCelular_TextChanged(sender, e);
            txtCorreo_TextChanged(sender, e);
            txtDireccion_TextChanged(sender, e);
            txtEmpresa_TextChanged(sender, e);
            txtNombreContacto1_TextChanged(sender, e);
            txtCelularContacto1_TextChanged(sender, e);
            txtNombreContacto2_TextChanged(sender, e);
            txtCelularContacto2_TextChanged(sender, e);


            var result3 = fnValidarFecha(dtpFechaNac, imgFechaNacimiento, erFechaNacimiento);

            estFechaNacimiento = result3.Item1;
            msjFechaNaciemiento = result3.Item2;

            var result4 = fnValidarCombobox(cboDepartamento, erDepartemento, imgDepartemento);
            estDepartamento = result4.Item1;
            msjDepartamento = result4.Item2;

            var result5 = fnValidarCombobox(cboProvincia, erProvincia, imgProvincia);
            estProvincia = result5.Item1;
            msjProvincia = result5.Item2;

            var result6 = fnValidarCombobox(cboDistrito, erDistrito, imgDistrito);
            estDistrito = result6.Item1;
            msjDistrito = result6.Item2;

            Int32 idTipoCliente = Convert.ToInt32(cboTipoCliente.SelectedValue == null ? "0" : cboTipoCliente.SelectedValue.ToString());

            if (idTipoCliente == 1)
            {
                if ((estTipoCliente == true) && (estNombre == true) && (estApellidoPaterno == true)
                && (estApellidoMaterno == true) && (estTipoDocumento == true)
                && (estNroDocumento == true) && (estTelefonoFijo == true)
                && (estTelefonoCelular == true) && (estCorreo == true)
                && (estFechaNacimiento == true) && (estDepartamento == true)
                && (estProvincia == true) && (estDistrito == true)
                && (estDireccion == true) && (estNombreContacto1 == true)
                && (estCelularContacto1 == true) && (estNombreContacto2 == true)
                && (estCelularContacto2 == true) && (estEmpresa == true))
                {

                    lcResultado = fnGuardarCliente(lnTipoCon);
                    if (lcResultado == "OK")
                    {
                        MessageBox.Show("Se Grabo Satisfactoriamente Cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        fnLimpiarValidacion(false);
                    }
                    else
                    {
                        MessageBox.Show("Error al Grabar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                }
                else
                {
                    MessageBox.Show("Complete correctamente los campos", "Mensaje Guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }



            }
            else if (idTipoCliente == 2)
            {
                if ((estTipoCliente == true) && (estNombre == true)
                && (estTipoDocumento == true)
                && (estNroDocumento == true) && (estTelefonoFijo == true)
                && (estTelefonoCelular == true) && (estCorreo == true)
                && (estDepartamento == true) && (estProvincia == true)
                && (estDistrito == true)
                && (estDireccion == true) && (estNombreContacto1 == true)
                && (estCelularContacto1 == true) && (estNombreContacto2 == true)
                && (estCelularContacto2 == true) && (estEmpresa == true))
                {

                    lcResultado = fnGuardarCliente(lnTipoCon);
                    if (lcResultado == "OK")
                    {
                        MessageBox.Show("Se Grabo Satisfactoriamente Cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        fnLimpiarValidacion(false);
                    }
                    else
                    {
                        MessageBox.Show("Error al Grabar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                }
                else
                {
                    MessageBox.Show("Complete correctamente los campos", "Mensaje Guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void cboTipoClienteBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 idTipoCliente = Convert.ToInt32(cboTipoClienteBuscar.SelectedValue == null ? "0" : cboTipoClienteBuscar.SelectedValue.ToString());
            fnLLenarDocumentoDeTipoPersona(cboTipoDocumentoBuscar, idTipoCliente, "", true);
            Boolean bResul;
            txtNroDocumentoBuscar.Text = "";
            if (pasoLoad)
            {
                bResul = fnBuscarCliente(dgCliente, 0, -1);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if(idTipoCliente == 0)
            {
                cboTipoDocumentoBuscar.Enabled = false;
            }
            else
            {
                cboTipoDocumentoBuscar.Enabled = true;
            }
        }

        private void cboTipoDocumentoBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResul;
            txtNroDocumentoBuscar.Text = "";
            Int32 idTipoDocumento = Convert.ToInt32(cboTipoDocumentoBuscar.SelectedValue == null ? "0" : cboTipoDocumentoBuscar.SelectedValue.ToString());
            
            if(idTipoDocumento == 0)
            {
                txtNroDocumentoBuscar.Enabled = false;
            }
            else
            {
                txtNroDocumentoBuscar.Enabled = true;
            }
            
            if (pasoLoad)
            {
                bResul = fnBuscarCliente(dgCliente, 0, -1);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cboEstadoBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResul;
            
            if (pasoLoad)
            {
                bResul = fnBuscarCliente(dgCliente, 0, -1);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txtNroDocumentoBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Boolean bResul;
            
            if (pasoLoad)
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    bResul = fnBuscarCliente(dgCliente, 0, -1);
                    if (!bResul)
                    {
                        MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", false);
        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResul;

            Int32 numPagina = Convert.ToInt32(cboPagina.Text.ToString());
            if (pasoLoad)
            {
                bResul = fnBuscarCliente(dgCliente, numPagina, -2);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Boolean bResul;
            if (pasoLoad)
            {
                bResul = fnBuscarCliente(dgCliente, 0, -1);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Boolean bResul;
            if (pasoLoad)
            {
                bResul = fnBuscarCliente(dgCliente, 0, -1);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

       
         
        private void opcEditar_Click(object sender, EventArgs e)
        {
            Boolean bResul = false;
            bResul = fnListarClienteEspecifico(dgCliente, 1);
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar Cliente Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            tabControl1.SelectedIndex = 0;

            /*nVerValidacion(false);*/
            fnHabilitarControles(false);

            btnEditar.Enabled = true;
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bResult = FunValidaciones.fnValidarCombobox(cboEstado, erEstado, imgEstado);
            estEstado = bResult.Item1;
            msjEstado = bResult.Item2;
        }

        private void txtEmpresa_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexboxNoObligatorios(txtEmpresa, erEmpresa, imgEmpresa, 5);

            estEmpresa = result.Item1;
            msjEmpresa = result.Item2;
        }

        private void txtEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }


        private void lvCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (lnTipoLlamada == 0)
                {
                    Boolean bResul = false;
                    bResul = fnListarClienteEspecifico(dgCliente, 1);
                    if (!bResul)
                    {
                        MessageBox.Show("Error al Cargar Cliente Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                }
                else if (lnTipoLlamada == 1)
                {
                    Boolean bResul = false;
                    bResul = fnRecuperarClienteEsp();
                    if (!bResul)
                    {
                        MessageBox.Show("Error al Recuperar Cliente Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else { this.Dispose(); }
                }
                else if (lnTipoLlamada == 3)
                {
                    Boolean bResul = false;
                    bResul = fnRecuperarClienteEspDeuda();
                    if (!bResul)
                    {
                        MessageBox.Show("Error al Recuperar Cliente Especifico en Deudas", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        this.Dispose();
                    }
                }
                else if (lnTipoLlamada == 4)
                {
                    Boolean bResul = false;
                    bResul = fnRecuperarClienteEsprptVenta();
                    if (!bResul)
                    {
                        MessageBox.Show("Error al Recuperar Cliente Especifico en Reporte Venta", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        this.Dispose();
                    }
                }
            }
        }

        private void txtdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (Char.IsDigit(e.KeyChar) || (Char.IsControl(e.KeyChar)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }
        private void fnvalidarComboCliente(Boolean estado)
        {
            txtNrDocumento.Enabled = estado;
            txtNombre.Enabled = estado;
            txtApeMat.Enabled = estado;
            txtApePat.Enabled = estado;
            txtNrDocumento.Enabled = estado;
            gboSecun.Enabled = estado;
            gbUbicacion.Enabled = estado;
            gboContacto.Enabled = estado;
        }
        private void cboTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResult;
            Int32 idTipoCliente = Convert.ToInt32(cboTipoCliente.SelectedValue == null ? "0" : cboTipoCliente.SelectedValue.ToString());
            fnLLenarDocumentoDeTipoPersona(cboTipoDoc, idTipoCliente, "1",false);

            if (idTipoCliente == 0)
            {
                cboTipoDoc.Enabled = false;

            }
            else
            {
                cboTipoDoc.Enabled = true;
            }

            bResult = fnOcultarControles(idTipoCliente);
            if (!bResult)
            {
                MessageBox.Show("Alerta", "Error en al ocultar Controles");
            }
            var result = fnValidarCombobox(cboTipoCliente, erTipoCliente,imgTipoCliente);

            estTipoCliente = result.Item1;
            msjTipoCliente = result.Item2;

        }


        private Boolean fnOcultarControles(Int32 idTipCliente)
        {
            if (idTipCliente == 1)
            {
                ////APELLIDO MATERNO/////
                txtApeMat.Visible = true;
                imgApellidoMaterno.Visible = true;
                erApellidoMaterno.Visible = true;
                lblApeMat.Visible = true;

                txtApeMat.Text = "";

                ////APELLIDO PATERNO//////
                txtApePat.Visible = true;
                imgApellidoPaterno.Visible = true;
                erApellidoPaterno.Visible = true;
                lblApePat.Visible = true;

                txtApePat.Text = "";

                ////FECHA NACIMIENTO//// 
                lblFechaNacimiento.Visible = true;
                imgFechaNacimiento.Visible = true;
                erFechaNacimiento.Visible = true;
                dtpFechaNac.Visible = true;
                dtpFechaNac.Value = DateTime.MinValue.AddYears(+1900);

                ////NRO. DOCUMENTO////
                txtNrDocumento.Text = "";
                ////NOMBRE/////
                lblNombre.Text = "Nombre (*) ";
                /////BOTON GUARDAR////
                btnGuardar.Enabled = true;

                fnvalidarComboCliente(true);

            }
            else if (idTipCliente == 2)
            {

                ////APELLIDO MATERNO/////
                txtApeMat.Visible = false;
                lblApeMat.Visible = false;
                erApellidoMaterno.Visible = false;
                imgApellidoMaterno.Visible = false;
                txtApeMat.Text = "";

                ////APELLIDO PATERNO////
                txtApePat.Visible = false;
                lblApePat.Visible = false;
                erApellidoPaterno.Visible = false;
                imgApellidoPaterno.Visible = false;
                txtApePat.Text = "";

                ////FECHA NACIMIENTO/////
                dtpFechaNac.Visible = false;
                imgFechaNacimiento.Visible = false;
                erFechaNacimiento.Visible = false;
                dtpFechaNac.Visible = false;
                lblFechaNacimiento.Visible = false;
                dtpFechaNac.Value = DateTime.MinValue.AddYears(+1900);

                ////NRO. DOCUMENTO////
                txtNrDocumento.Text = "";

                ////BOTON GUARDAR/////
                btnGuardar.Enabled = true;

                ////NOMBRE/////
                lblNombre.Text = "Razon Social (*) ";

                fnvalidarComboCliente(true);

            }
            else
            {
                ////APELLIDO MATERNO/////
                txtApeMat.Visible = true;
                imgApellidoMaterno.Visible = true;
                erApellidoMaterno.Visible = true;
                lblApeMat.Visible = true;

                ////APELLIDO PATERNO//////
                txtApePat.Visible = true;
                imgApellidoPaterno.Visible = true;
                erApellidoPaterno.Visible = true;
                lblApePat.Visible = true;

                ////FECHA NACIMIENTO//// 
                lblFechaNacimiento.Visible = true;
                imgFechaNacimiento.Visible = true;
                erFechaNacimiento.Visible = true;
                dtpFechaNac.Visible = true;

                ////NOMBRE/////
                lblNombre.Text = "Nombre (*) ";

                ////BOTON GUARDAR////
                btnGuardar.Enabled = false;

                cboTipoDoc.Enabled = false;
                fnvalidarComboCliente(false);
                fnLimpiarValidacion(false);
                fnLimpiarControles();

            }
            return true;
        }

        private Boolean fnLLenarDocumentoDeTipoPersona(ComboBox cbo, Int32 idDocumento, String est ,Boolean buscar)
        {
            BLTipoCliente objClaseV = new BLTipoCliente();
            clsUtil objUtil = new clsUtil();
            List<TipoDocumento> lstTC = new List<TipoDocumento>();

            try
            {
                lstTC = objClaseV.blDevolverDocumentoDeTipoCliente(idDocumento, est,buscar);
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
        void fnValidarTipografia(KeyPressEventArgs e,Int32 num,Boolean mayusculas)
        {
            if (num==1)
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
            else if(num==2)
            {
                if ((Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }else if (num == 3)
            {
                if ((Char.IsWhiteSpace(e.KeyChar))||(Char.IsLetter(e.KeyChar))||(Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }else if(num == 4)
            {
                
                if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar)) 
                    || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar))
                    || (e.KeyChar == '@')|| (e.KeyChar== '_')|| (e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }else if (num == 5)
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
                if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar))
                     || (Char.IsControl(e.KeyChar) || (e.KeyChar == '.')))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            
        }

        private void txtNombreContacto1_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexbox(txtNombreContacto1, erNombreContacto1, imgNombreContacto1, true, 10);
            estNombreContacto1 = result.Item1;
            msjNombreContacto1 = result.Item2;
        }

        private void txtApePat_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true); 
        }

        private void txtApeMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true);
        }

        private void txtPrimerNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true);
        }

        //private void txtSegundoNom_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    fnValidarTipografia(e, 1, true);
        //}

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "DIRECCION", true);
        }

        private void txtTelFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", true);
            Int32 cursorPos = txtTelFijo.Text.Length;
            if (cursorPos == 3 && !(Char.IsControl(e.KeyChar)))
            {
                txtTelFijo.Text = txtTelFijo.Text.Insert(cursorPos, "-");
                txtTelFijo.Select((cursorPos + 1), 4);

            }
            else if (cursorPos == 10 && !(Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtTelCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", false);
            Int32 cursorPos = txtTelCelular.Text.Length;

            if (cursorPos == 3 && !(Char.IsControl(e.KeyChar)))
            {
                txtTelCelular.Text = txtTelCelular.Text.Insert(cursorPos, "-");
                txtTelCelular.Select((cursorPos + 1), 4);


            }
            else if (cursorPos == 7 && !(Char.IsControl(e.KeyChar)))
            {
                txtTelCelular.Text = txtTelCelular.Text.Insert(cursorPos, "-");
                txtTelCelular.Select((cursorPos + 1), 4);


            }
            else if (cursorPos == 11 && !(Char.IsControl(e.KeyChar)))
            {
                    e.Handled = true;
            }
        }

        private void cboTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

            Int32 idTD = Convert.ToInt32(cboTipoDoc.SelectedValue == null ? "0" : cboTipoDoc.SelectedValue.ToString());
            txtNrDocumento.Text = "";
            if (idTD == 0)
            {
                txtNrDocumento.Enabled = false;

            }
            else
            {

                txtNrDocumento.Enabled = true;
            }

            var result = fnValidarCombobox(cboTipoDoc, erTipoDocumento, imgTipoDocumento);

            estTipoDocumento = result.Item1;
            msjTipoDocumento = result.Item2;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtApePat_TextChanged(object sender, EventArgs e)
        {
          
            var result = fnValidarTexbox(txtApePat, erApellidoPaterno, imgApellidoPaterno, true, 3);

            estApellidoPaterno = result.Item1;
            msjApellidoPaterno = result.Item2;
        }

        private Tuple<Boolean, String> fnValidarCombobox(ComboBox cbo, Label lbl, PictureBox img)
        {
            String msj;
            if (cbo.SelectedIndex == 0)
            {
                img.Image = Properties.Resources.error;
                msj = "Seleccione una opción";
                lbl.Text = msj;
                return Tuple.Create(false, msj);

            }
            else
            {

                img.Image = Properties.Resources.ok; 
                msj = "";
                lbl.Text =msj;
                return Tuple.Create(true, msj);


            }
        }

        private void cboTipoCliente_Leave(object sender, EventArgs e)
        {
           
        }

        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var result = fnValidarCombobox(cboDistrito, erDistrito, imgDistrito);

            estDistrito = result.Item1;
            msjDistrito = result.Item2;

        }

        
        //{
           
        //    if (txt.Text == null || txt.Text.Trim() == "")
        //    {
        //        img.Image = Properties.Resources.error;
        //        lbl.Text = "Ingrese datos (campo obligatorio)";
        //        return false;

        //    }
        //    else if (maximo)
        //    {
        //        if (txt.Text.Length == num)
        //        {
        //            img.Image = Properties.Resources.ok;
        //            lbl.Text = "";
        //            return true;
        //        }
        //        else
        //        {
        //            img.Image = Properties.Resources.error;
        //            lbl.Text = "Datos incompletos (campo obligatorio)";
        //            return  false;

        //        }
        //    }
        //    else
        //    {
        //        img.Image = Properties.Resources.ok;
        //        lbl.Text = "";
        //        return true;
        //    }
        //}


        private void txtPrimerNom_TextChanged(object sender, EventArgs e)
        {
           
            var result = fnValidarTexbox(txtNombre,erNombre, imgNombre, true, 3);
           
            estNombre = result.Item1;
            msjNombre = result.Item2;
        }

       

        private void txtApeMat_TextChanged(object sender, EventArgs e)
        {
          
            var result = fnValidarTexbox(txtApeMat, erApellidoMaterno, imgApellidoMaterno, true, 3);

            estApellidoMaterno = result.Item1;
            msjApellidoMaterno = result.Item2;
        }

        private void txtdni_TextChanged(object sender, EventArgs e)
        {
            Int32 idTipDocumento = Convert.ToInt32(cboTipoDoc.SelectedValue == null ? "0" : cboTipoDoc.SelectedValue.ToString());

            var bResult = fnObtenerDatosDocumento(idTipDocumento, lstTD);

            var result = fnValidarTexboxDocumentoSQL(txtNrDocumento, erNrDocumento, imgNroDocumento, bResult.Item1,bResult.Item2,bResult.Item3);
            estNroDocumento = result.Item1;
            msjNroDocumento = result.Item2;
        }

        private Tuple<Int32,Boolean, String> fnObtenerDatosDocumento(Int32 idTD, List<TipoDocumento> lstTD)
        {
            foreach (TipoDocumento doc in lstTD)
            {
                if (doc.TDid == idTD)
                {
                    return Tuple.Create(doc.TDmaxCaracteres,doc.TDcarcObligatorio, doc.TDcaracter);
                }
            }
            return Tuple.Create(0, false, "");
        }

        private void txtTelCelular_TextChanged(object sender, EventArgs e)
        {
          
            var result = fnValidarTexbox(txtTelCelular, erTelefonoCelular, imgTelefonoCelular, true, 11);

            estTelefonoCelular = result.Item1;
            msjTelefonoCelular = result.Item2;
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            
            var result = fnValidarTexbox(txtDireccion, erDireccion, imgDireccion, true, 10);

            estDireccion = result.Item1;
            msjDireccion = result.Item2;
        }

        private Tuple<Boolean, String> fnValidarTexboxNoObligatorios(SiticoneTextBox txt, Label lbl, PictureBox img, Int32 max)
        {
            String msj = "";
            if (txt.Text == null || txt.Text.Trim() == "")
            {
                img.Image = null;
                msj = "vacio (campo no obligatorio)";
                lbl.Text =msj ;
                lbl.ForeColor = Color.Green;
                return Tuple.Create(true,msj);
            }
            else if (txt.Text.Length > 0)
            {
                if (txt.Text.Length >= max)
                {
                    img.Image = Properties.Resources.ok;
                    msj = "";
                    lbl.Text = msj;
                    
                    return Tuple.Create(true, msj);

                }
                else
                {
                    img.Image = Properties.Resources.error;
                    msj = "Ingrese los datos completos";
                    lbl.Text = msj;
                    lbl.ForeColor = Color.Red;
                    return Tuple.Create(false, msj);
                }

            }
            else
            {
                img.Image = Properties.Resources.error;
                msj = "Ocurrió otro error";
                lbl.Text = msj;
                lbl.ForeColor = Color.Red;
                return Tuple.Create(false, msj);
            }
        }

        private void txtTelFijo_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexboxNoObligatorios(txtTelFijo, erTelefonoFijo, imgTelefonoFijo, 10);
            estTelefonoFijo = result.Item1;
            msjTelefonoFijo = result.Item2;
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            
            var result = fnValidarEmail(txtCorreo, erCorreo, imgCorreo, 50);
            estCorreo = result.Item1;
            msjCorreo = result.Item2;
            
        }
        private Tuple< Boolean,String> fnValidarEmail(SiticoneTextBox txt, Label lbl, PictureBox img,  Int32 max)
        {
            String msj = "";
            if (txt.Text == null || txt.Text.Trim() == "")
            {
                img.Image = null;
                msj = "vacio (campo no obligatorio)";
                lbl.Text = msj ;
                lbl.ForeColor = Color.Green;
                return Tuple.Create(true, msj);
                
            }else if (txt.Text.Length > 0)
            {
                if (validarEmail(txt.Text.Trim()) == true)
                {
                    img.Image = Properties.Resources.ok;
                    msj = "";
                    lbl.Text = msj;
                    lbl.ForeColor = Color.Green;
                  
                    return Tuple.Create(true, msj);

                }
                else
                {
                    img.Image = Properties.Resources.error;
                    msj = "correo incorrecto (no obligatorio)";
                    lbl.Text = msj;
                    lbl.ForeColor = Color.Red;
                   
                    return Tuple.Create(false, msj);
                }

            }
            else{
                img.Image = Properties.Resources.error;
                msj = "ocurrió otro error";
                lbl.Text = msj;
                lbl.ForeColor = Color.Red;
                return Tuple.Create(false, msj);
            }
        }

        static bool validarEmail(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "CORREO", true);
        }

        private void dtpFechaNac_ValueChanged(object sender, EventArgs e)
        {
            var result = fnValidarFecha(dtpFechaNac, imgFechaNacimiento, erFechaNacimiento);

            estFechaNacimiento = result.Item1;
            msjFechaNaciemiento = result.Item2;
        }

        private Tuple<Boolean, String> fnValidarFecha(SiticoneDateTimePicker dtp, PictureBox img, Label lbl)
        {
            String msj;
            DateTime fechaActual = Variables.gdFechaSis;
            DateTime fechaNacimiento = dtp.Value;
            DateTime fechaActualMenos100anios = fechaActual.AddYears(-100);
            DateTime fechaActualMenos18anios = fechaActual.AddYears(-18);
            
            if(fechaActualMenos100anios > fechaNacimiento)
            {
                msj = "Fecha incorrecta (la fecha no puede ser mayor a 100 años)";
                lbl.Text = msj;
                lbl.ForeColor = Color.Red;
                img.Image = Properties.Resources.error;
                estFechaNacimiento = false;
                return Tuple.Create(false, msj);
            }
            else if (fechaActualMenos18anios < fechaNacimiento)
            {
                msj = "Fecha incorrecta (la fecha no puede ser menor de 18 años)";
                lbl.Text = msj;
                lbl.ForeColor = Color.Red;
                img.Image = Properties.Resources.error;
                estFechaNacimiento = false;
                return Tuple.Create(false, msj);
            }
            else
            {
                msj = "";
                lbl.Text = msj;
                img.Image = Properties.Resources.ok;
                lbl.ForeColor = Color.Green;
                return Tuple.Create(true, msj);
            }

        }
    }
}
