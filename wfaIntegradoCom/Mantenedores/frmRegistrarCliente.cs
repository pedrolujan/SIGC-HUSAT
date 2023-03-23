﻿using System;
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
        ConsultaClienteAPI ConsultasApi = new ConsultaClienteAPI();
        static List<Departamento> lstDepartCliente = new List<Departamento>();
        static List<Departamento> lstDepartEmpresa = new List<Departamento>();
        static List<Provincia> lstProvCliente = new List<Provincia>();
        static List<Provincia> lstProvEmpresa = new List<Provincia>();
        static List<Distrito> lstDistCliente = new List<Distrito>();
        static List<Distrito> lstDistEmpresa = new List<Distrito>();

        public frmRegistrarCliente()
        {
            InitializeComponent();

        }
        static List<validacion> lstValidacionRepre;
        static Boolean pasoLoad;
        private void fnValidarRepre()
        {
            lstValidacionRepre = new List<validacion>();
            lstValidacionRepre.Add(new validacion { estado = false, mensaje = "", combobox = cboTipoClienteRepre });
            lstValidacionRepre.Add(new validacion { estado = false, mensaje = "", combobox = cboTipoDocRepre });
            lstValidacionRepre.Add(new validacion { estado = false, mensaje = "", textbox = txtDocRepre });
        }

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
            estCorreo, estFechaNacimiento, estNombreContacto1, estNombreContacto2,
            estCelularContacto1, estCelularContacto2, estEmpresa, estEstado,
            estCargo;
        ////VARAIBLES PARA LOS MENSAJES DE ERROR
        String msjTipoCliente, msjNombre, msjApellidoMaterno,
            msjApellidoPaterno, msjTipoDocumento, msjNroDocumento,
            msjTelefonoFijo, msjTelefonoCelular, msjCorreo, msjFechaNaciemiento,
            msjDepartamento, msjProvincia, msjDistrito, msjDireccion, msjNombreContacto1,
            msjNombreContacto2, msjCelularContacto1, msjCelularContacto2, msjEmpresa, msjEstado,
            msjCargo;

        static Int32 tabInicio = 0;
        private Tuple<Boolean, String> fnValidarTexbox(SiticoneTextBox txt, Label lbl, PictureBox img, Boolean maximo, Int32 num)
        {
            String msj;

            if (txt.Text == null || txt.Text.Trim() == "")
            {
                img.Image = Properties.Resources.error;
                msj = "Ingrese datos (campo obligatorio)";
                lbl.Text = msj;

                return Tuple.Create(false, msj);

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

        private Tuple<Boolean, String> fnValidarTexboxDocumentoSQL(SiticoneTextBox txt, Label lbl, PictureBox img, Int32 num, Boolean caracObli, String caracter)
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
        private Boolean fnBuscarNrDocumento(String pcBuscar, Int16 pnTipoCon)
        {
            BLCliente objCli = new BLCliente();
            clsUtil objUtil = new clsUtil();
            Int16 numResult = 0;

            try
            {

                numResult = objCli.blBuscarNroDocumento(pcBuscar, pnTipoCon);

                if (numResult == 1)
                {
                    erNrDocumento.Text = "Este documento ya existe (Ingrese otro cliente)";
                    erNrDocumento.ForeColor = Color.Red;
                    imgNroDocumento.Image = Properties.Resources.error;
                    return true;
                    //return false;
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
        public static class tipoCon
        {
            public static Int16 lnTipoConV { get; set; }
            public static Int16 lnTipoConC { get; set; }
            public static Int16 lnTipoConRP { get; set; }
        }

        public Boolean fnBuscarCliRepre(SiticoneTextBox txt, Int32 Pagina, Int16 TipoConPagina, DataGridView dgv, Int32 tipcon, ComboBox cboTC, ComboBox cboTD)
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


                    Int32 idTipoPersona = Convert.ToInt32(cboTC.SelectedValue ?? 0);
                    Int32 idTipoDocumento = Convert.ToInt32(cboTD.SelectedValue ?? 0);
                    Int32 estCliente = 1;

                    datCliente = objVehi.blBuscarCliente(nombreCliente, estCliente, Pagina, TipoConPagina);
                    totalResultados = datCliente.Rows.Count;

                    if (totalResultados > 0)
                    {
                        if (Convert.ToInt32(cboEstadoBuscar.SelectedValue) == 2)
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
                                Boolean estadoVehiculo = Convert.ToBoolean(datCliente.Rows[i][7]);
                                if (estadoVehiculo)
                                {
                                    object[] row =
                                    {
                                        datCliente.Rows[i][0],
                                        datCliente.Rows[i][6]
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





        private Boolean fnBuscarCliente(DataGridView dgv, Int32 numPagina, Int32 tipoCon)
        {
            BLCliente objCli = new BLCliente();
            clsUtil objUtil = new clsUtil();
            DataTable dtCliente = new DataTable();
            Int32 filas = 15;
            String nroDocumento = "";
            String bnombreCliente;

            Int32 idTipoPersona;
            Int32 idTipoDocumento;
            Int32 estCliente;
            String estado;
            try
            {
                if (cboEstadoBuscar.SelectedIndex == 1)
                {
                    estCliente = 1;
                }
                else if (cboEstadoBuscar.SelectedIndex == 2)
                {
                    estCliente = 0;
                }
                else
                {
                    estCliente = -1;
                }

                bnombreCliente = Convert.ToString(txtNombreBuscar.Text.ToString());


                dtCliente = objCli.blBuscarCliente(bnombreCliente, estCliente, numPagina, tipoCon);

                Int32 totalResultados = dtCliente.Rows.Count;

                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("NOMBRE CLIENTE");
                    //Mod//


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
                        if (Convert.ToBoolean(dtCliente.Rows[i][7]) == true)
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
                            //MOD//

                            dtCliente.Rows[i][4],
                            dtCliente.Rows[i][5],
                            dtCliente.Rows[i][6],
                            estado

                        };
                        dt.Rows.Add(row);

                    }
                    dgv.DataSource = dt;

                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 25;
                    dgv.Columns[2].Width = 340;
                    //MOD
                    dgv.Columns[3].Visible = false;


                    dgv.Visible = true;

                    if (tipoCon == -1)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(dtCliente.Rows[0][8]);
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

        private Boolean fnListarRepresentante(SiticoneDataGridView dgv, Int32 opc)
        {

            clsUtil objUtil = new clsUtil();
            BLCliente objCli = new BLCliente();
            Cliente lstCliente;
            Int32 idCliente;

            try
            {
                idCliente = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value.ToString());
                lstCliente = objCli.blListarCliente(idCliente, opc);

                if (lstCliente.idCliente > 0)
                {
                    estActualizar = true;
                    txtValidarDocumento.Text = Convert.ToString(lstCliente.cDocumento.Trim());
                    txtidRepreLegal.Text = Convert.ToString(lstCliente.idCliente);
                    cboTipoClienteRepre.SelectedValue = Convert.ToInt32(lstCliente.cTipPers);
                    cboTipoDocRepre.SelectedValue = Convert.ToInt32(lstCliente.cTiDo);

                    txtDocRepre.Text = Convert.ToString(lstCliente.cDocumento.Trim());

                    txtNombreRepre.Text = Convert.ToString(lstCliente.cNombre) + ' ' + Convert.ToString(lstCliente.cApePat) + ' ' + Convert.ToString(lstCliente.cApeMat);
                    //mod//
                    //txtApePat.Text = Convert.ToString(lstCliente.cApePat);
                    //txtApeMat.Text = Convert.ToString(lstCliente.cApeMat);

                    txtDireccionRepre.Text = Convert.ToString(lstCliente.cDireccion);
                    txtTelefonoFijoRepre.Text = Convert.ToString(lstCliente.cTelCelular);
                    txtCorreoRepre.Text = Convert.ToString(lstCliente.cCorreo.Trim());
                    if (txtCorreoRepre.Text == "")
                    {
                        lblInfoCorreo.Text = "-Cliente sin Correo-";
                        lblInfoCorreo.ForeColor = Color.FromArgb(206, 123, 77);
                    }
                    else
                    {
                        lblInfoCorreo.Text = "";
                    }


                    gboDatosRepres.Visible = true;
                }


                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnListarClienteEspecifico", ex.Message);
                return false;
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
                lstCliente = objCli.blListarCliente(idCliente, opc);

                if (lstCliente.idCliente > 0)
                {
                    estActualizar = true;
                    txtValidarDocumento.Text = Convert.ToString(lstCliente.cDocumento.Trim());
                    txtIdCliente.Text = Convert.ToString(lstCliente.idCliente);
                    cboTipoCliente.SelectedValue = Convert.ToInt32(lstCliente.cTipPers);
                    cboTipoDoc.SelectedValue = Convert.ToInt32(lstCliente.cTiDo);

                    txtNrDocumento.Text = Convert.ToString(lstCliente.cDocumento.Trim());

                    txtNombre.Text = Convert.ToString(lstCliente.cNombre);
                    txtApePat.Text = Convert.ToString(lstCliente.cApePat);
                    txtApeMat.Text = Convert.ToString(lstCliente.cApeMat);

                    //Int32 idTipoCliente = Convert.ToInt32(cboTipoCliente.SelectedValue == null ? "0" : cboTipoCliente.SelectedValue.ToString());
                    Int32 idTipoCliente = Convert.ToInt32(lstCliente.cTipPers);


                    ocultarGroupBoxes(idTipoCliente);
                    //MOD REPRESENTANTE
                    if (lstCliente.idRepreLegal > 0)
                    {

                        txtidRepreLegal.Text = Convert.ToString(lstCliente.idRepreLegal);
                        txtidRepreLegal.Text = Convert.ToString(lstCliente.idClienteRepre);

                        cboTipoDocRepre.SelectedValue = Convert.ToInt32(lstCliente.cTiDoRepre);
                        txtDocRepre.Text = Convert.ToString(lstCliente.cDocumentoRepre);
                        txtNombreRepre.Text = Convert.ToString(lstCliente.NombreRepreLegal);
                        txtCorreoRepre.Text = Convert.ToString(lstCliente.cCorreoRepre);
                        if (txtCorreoRepre.Text == "")
                        {
                            lblInfoCorreo.Text = "-Cliente sin Correo-";
                            lblInfoCorreo.ForeColor = Color.FromArgb(206, 123, 77);

                        }
                        txtTelefonoFijoRepre.Text = Convert.ToString(lstCliente.cTelCelularRepre);
                        dgDocumentoRP.Visible = false;
                        cboCargoRepre.SelectedValue = Convert.ToString(lstCliente.Cargo);
                        txtDireccionRepre.Text = Convert.ToString(lstCliente.cDireccionRepre);
                    }
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
            gboDatosRepres.Enabled = pbHabilitar;
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

            /////REPRESENTANTE /////
            cboTipoDocRepre.SelectedValue = 0;
            cboCargoRepre.SelectedValue = 0;
            txtDocRepre.ReadOnly = false;
            txtDocRepre.Text = "";
            txtNombreRepre.Text = "";
            txtCorreoRepre.Text = "";
            txtTelefonoFijoRepre.Text = "";
            txtDireccionRepre.Text = "";
            tipoCon.lnTipoConRP = 0;
            imgTipoClienteRepre.Image = null;
            imgTipoDocRepre.Image = null;
            imgDocumentoRP.Image = null;
            erTipoClienteRepre.Text = "";
            erTipoDocRepre.Text = "";
            erDocumentoRP.Text = "";
            lblInfoCorreo.Text = "";

            ////TEXBOXS/////
            txtNombreBuscar.Text = "";
            txtIdCliente.Text = "0";
            txtidRepreLegal.Text = "0";
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
            cboEstado.SelectedIndex = 1;
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
                else
                {
                    this.Dispose();
                }
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

                objCliente.idCliente = Convert.ToInt32(txtIdCliente.Text.Trim());

                objCliente.cTipPers = Convert.ToInt32(cboTipoCliente.SelectedValue.ToString());
                objCliente.bEstado = Convert.ToBoolean(cboEstado.SelectedIndex == 1 ? 1 : 0);
                objCliente.cTiDo = Convert.ToInt32(cboTipoDoc.SelectedValue.ToString());
                objCliente.cDocumento = Convert.ToString(txtNrDocumento.Text.Trim());
                objCliente.cNombre = Convert.ToString(txtNombre.Text.Trim());
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


                //MOD REPRESENTANTE//
                // objCliente.idCliente = Convert.ToInt32(txtidCliente.Text.Trim());

                //Representante
                objCliente.idRepreLegal = Convert.ToInt32(txtidRepreLegal.Text.Trim());
                objCliente.cTiDoRepre = Convert.ToInt32(cboTipoDocRepre.SelectedValue);
                objCliente.cDocumentoRepre = Convert.ToString(txtDocRepre.Text.Trim());
                objCliente.NombreRepreLegal = Convert.ToString(txtNombreRepre.Text);
                objCliente.cCorreoRepre= Convert.ToString(txtCorreoRepre.Text.Trim());
                objCliente.cTelCelularRepre = Convert.ToString(txtTelefonoFijoRepre.Text.Trim());
                objCliente.Cargo = Convert.ToString(cboCargoRepre.SelectedValue);
                objCliente.cDireccionRepre = Convert.ToString(txtDireccionRepre.Text.Trim());
                objCliente.Estado = Convert.ToBoolean(cboEstado.SelectedIndex == 1 ? 1 : 0);
                //objCliente.cCodTab = Convert.ToString("CCRE000");
                objCliente.NomCargo = Convert.ToString(txtAddCargo.Text.Trim());

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
                lstProvCliente = lstProv;

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
                lstDistCliente = lstDist;

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

                lstDepartCliente = lstDepart;
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
            if (lnTipo == 1 || lnTipo == 3 || lnTipo == 4)
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
            pbTraerClientes.Value = 0;
            pbTraerClientes.Maximum = 100;
            pbTraerClientes.Minimum = 0;
            pbTraerClientes.Visible = false;
            pbRepresentante.Visible = false;

            pasoLoad = false;
            Boolean bResult;
            fnHabilitarControles(false);
            estActualizar = false;
            cboEstadoBuscar.SelectedIndex = 0;
            bResult = fnLLenarTipoPersona(cboTipoCliente, 0, "1", false);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar el Cliente", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            fnValidarRadioButons();

            // bResult = fnLLenarTipoPersona(cboTipoClienteBuscar, 0, "", true);

            if (!bResult)
            {
                MessageBox.Show("Error al Cargar el Cliente", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            fnLimpiarValidacion(false);
            fnLimpiarControles();
            fnValidarRepre();
            FunValidaciones.fnColorTresBotones(btnNuevo, btnEditar, btnGuardar);
            pasoLoad = true;
            cboTipoDoc.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);
            cboTipoDocRepre.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);
            cboDepartamento.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);
            cboProvincia.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);
            cboDistrito.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);

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


            if (cboProvincia.SelectedValue == null)
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
            var result = fnValidarCombobox(cboProvincia, erProvincia, imgProvincia);
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
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", false);
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
            var result = fnValidarTexbox(txtNombreContacto2, erNombreContacto2, imgNombreContacto2, true, 10);
            estNombreContacto2 = result.Item1;
            msjNombreContacto2 = result.Item2;
        }

        private void txtCelularContacto2_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexbox(txtCelularContacto2, erCelularContacto2, imgCelularContacto2, true, 11);

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

            //cboCargoRepre_SelectedIndexChanged(sender, e);
            if (Convert.ToInt32(cboTipoCliente.SelectedValue) != 1)
            {
                var result = fnValidarCombobox(cboCargoRepre, erCargoRP, imgCargoRP);

                estCargo = result.Item1;
                msjCargo = result.Item2;
            }
            else
            {
                estCargo = true;
            }


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
                && (estCelularContacto2 == true) && (estEmpresa == true)
                && (estCargo == true))
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
                && (estCelularContacto2 == true) && (estEmpresa == true)
                && (estCargo == true))
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
            //Int32 idTipoCliente = Convert.ToInt32(cboTipoClienteBuscar.SelectedValue == null ? "0" : cboTipoClienteBuscar.SelectedValue.ToString());

            //fnLLenarDocumentoDeTipoPersona(cboTipoDocumentoBuscar, idTipoCliente, "", true);
            //Boolean bResul;
            //txtNroDocumentoBuscar.Text = "";
            //if (pasoLoad)
            //{
            //    bResul = fnBuscarCliente(dgCliente, 0, -1);
            //    if (!bResul)
            //    {
            //        MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}

            //if(idTipoCliente == 0)
            //{
            //    cboTipoDocumentoBuscar.Enabled = false;
            //}
            //else
            //{
            //    cboTipoDocumentoBuscar.Enabled = true;
            //}
        }

        private void cboTipoDocumentoBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Boolean bResul;
            //txtNroDocumentoBuscar.Text = "";
            //Int32 idTipoDocumento = Convert.ToInt32(cboTipoDocumentoBuscar.SelectedValue == null ? "0" : cboTipoDocumentoBuscar.SelectedValue.ToString());

            //if(idTipoDocumento == 0)
            //{
            //    txtNroDocumentoBuscar.Enabled = false;
            //}
            //else
            //{
            //    txtNroDocumentoBuscar.Enabled = true;
            //}

            //if (pasoLoad)
            //{
            //    bResul = fnBuscarCliente(dgCliente, 0, -1);
            //    if (!bResul)
            //    {
            //        MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}
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

        private void siticoneGroupBox1_Click(object sender, EventArgs e)
        {
            gboDatosRepres.Size = new Size(1201, 125);
        }

        private void cboTipoClienteRP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTipoDocumentoRP_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 idTD = Convert.ToInt32(cboTipoDoc.SelectedValue == null ? "0" : cboTipoDoc.SelectedValue.ToString());
            txtDocRepre.Text = "";
            txtidRepreLegal.Visible = true;
            if (idTD == 0)
            {
                txtNrDocumento.Enabled = false;

            }
            else
            {

                txtNrDocumento.Enabled = true;
            }

            var result = fnValidarCombobox(cboTipoDocRepre, erTipoDocRepre, imgTipoDocRepre);

            estTipoDocumento = result.Item1;
            msjTipoDocumento = result.Item2;
        }

        private void txtDocumentoRP_TextChanged(object sender, EventArgs e)
        {
            //Int32 idTipDocumento = Convert.ToInt32(cboTipoDocRepre.SelectedValue == null ? "0" : cboTipoDocRepre.SelectedValue.ToString());

            //var bResult = fnObtenerDatosDocumento(idTipDocumento, lstTD);

            //var result = fnValidarTexboxDocumentoSQL(txtNrDocumento, erNrDocumento, imgNroDocumento, bResult.Item1, bResult.Item2, bResult.Item3);
            //estNroDocumento = result.Item1;
            //msjNroDocumento = result.Item2;

            Int32 idTipDocumentoRP = Convert.ToInt32(cboTipoDocRepre.SelectedValue ?? 0);
            Int32 maxCaracteres = TipoDocumento.fnObtenerTipoDocumentoSeleccionado(idTipDocumentoRP, lstTD).TDmaxCaracteres;
            var result = FunValidaciones.fnValidarTexboxs(lstValidacionRepre[2].textbox, erDocumentoRP, imgDocumentoRP, true, true, true, maxCaracteres, maxCaracteres, maxCaracteres, maxCaracteres, "Ingrese correctamente");
            lstValidacionRepre[2].estado = result.Item1;
            lstValidacionRepre[2].mensaje = result.Item2;
            Int32 numCaracNroDocumento = txtDocRepre.TextLength;
            if (numCaracNroDocumento >= 3)
            {
                Boolean bResul;

                bResul = fnBuscarCliRepre(txtDocRepre, 0, -1, dgDocumentoRP, tipoCon.lnTipoConRP, cboTipoClienteRepre, cboTipoDocRepre);
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

        private void txtDocRepre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", false);
        }

        private void dgDocumentoRP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean bResul = false;
            bResul = fnListarRepresentante(dgDocumentoRP, 2);

            dgDocumentoRP.Visible = false;
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNombreBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        


    private void fnconsultarCliente()
     {

            string token = "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImdwdGZyYW5jaXNjbzJvMjNAZ21haWwuY29tIn0.cJJq3oGT5gzFvfFlV3e5gHJCYZrLlKGjumQlsJZfwD8";


            try
            {
                //Compara la cantidad de caracteres, si tiene 11 entonces busca el ruc
                if (Convert.ToInt32(cboTipoDoc.SelectedValue) == 1)
                {
                    //token
                    dynamic respuesta = ConsultasApi.Get("https://dniruc.apisperu.com/api/v1/dni/" + txtNrDocumento.Text + token);
                    txtNombre.Text = respuesta.nombres.ToString();
                    txtApePat.Text = respuesta.apellidoPaterno.ToString();
                    txtApeMat.Text = respuesta.apellidoMaterno.ToString();
                    pbTraerClientes.Visible = false;
                }

                //sino busca el ruc
                else if (Convert.ToInt32(cboTipoDoc.SelectedValue) == 2 || Convert.ToInt32(cboTipoDoc.SelectedValue) == 4)
                {
                    //cambia el numero por defecto por el textbox
                    dynamic respuesta = ConsultasApi.Get("https://dniruc.apisperu.com/api/v1/ruc/" + txtNrDocumento.Text + token);
                    // recibe la respuesta de la consulta en los respectivos textbox
                    txtNombre.Text = respuesta.razonSocial.ToString();
                    txtDireccion.Text = respuesta.direccion.ToString();
                    string[] str = respuesta.razonSocial.ToString().Split(' ');

                    if (Convert.ToInt32(cboTipoDoc.SelectedValue) == 2)
                    {
                        txtNombre.Text = str[2] + " " + str[3];
                        txtApePat.Text = str[0];
                        txtApeMat.Text = str[1];
                    }
                    


                    Departamento Depa = lstDepartCliente.Find(i => i.cNomDep.ToLower() == respuesta.departamento.ToString().ToLower());
                    cboDepartamento.SelectedValue = Depa is Departamento? Depa.idDepa:0;

                    Provincia Prov = lstProvCliente.Find(i => i.cNomProv.Trim().ToUpper() == respuesta.provincia.ToString().ToUpper());
                    cboProvincia.SelectedValue = Prov is Provincia ? Prov.idProv : 0;

                    Distrito Dist = lstDistCliente.Find(i => i.cNomDist.ToLower() == respuesta.distrito.ToString().ToLower());
                    cboDistrito.SelectedValue =Dist is Distrito? Dist.idDist:0;

                    pbTraerClientes.Visible = false;

                }
                else
                {
                    //si ingresa mas caracteres. me saldraun error.
                    MessageBox.Show("Ingrese un número de documento válido.", "Documento inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(" catch Ingrese un número de documento válido." + ex, "Documento inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            pbTraerClientes.Refresh();

            
        }
      

        private void tmLlamasDatosCliente_Tick(object sender, EventArgs e)
        {
            //tmLlamasDatosCliente.Start();
            //if (pbLlamasDatosCliente.Value == 50)
            //{
            //    fnconsultarCliente();
            //}

            if (pbTraerClientes.Value < 90)
            {
                pbTraerClientes.Value += 10;
            }
            else if (pbTraerClientes.Value == 90)
            {
                pbTraerClientes.Value += 1;
                fnconsultarCliente();
            }
            else if (pbTraerClientes.Value > 90 && pbTraerClientes.Value < 100)
            {

                pbTraerClientes.Value += 1;
                pbTraerClientes.Value = 100;

                
            }
            else
            {
                if (pbTraerClientes.Value >= 100)
                {
                    tmLlamasDatosCliente.Stop();

                }

            }
        }
        private void resetProgressBar()
        {
            pbTraerClientes.Value = 0;
            pbRepresentante.Value = 0;
        }

        private void updateProgressBar()
        {
            if (pbTraerClientes.Value < 100)
            {
                pbTraerClientes.Value++;
            }
            else
            {
                resetProgressBar();
            }
        }

        

        private void btnTraerNombreCliente_Click(object sender, EventArgs e)
        {
            
            pbTraerClientes.Visible = true;
            pbTraerClientes.Value = 0;
            if (pbTraerClientes.Value == 0)
            {
                tmLlamasDatosCliente.Start();
            }
            else
            {
                resetProgressBar();
            }

            
            //

        }

        public void fnTrarDatosRepresentante()
        {
           
            string token = "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImdwdGZyYW5jaXNjbzJvMjNAZ21haWwuY29tIn0.cJJq3oGT5gzFvfFlV3e5gHJCYZrLlKGjumQlsJZfwD8";


            try
            {
                //Compara la cantidad de caracteres, si tiene 11 entonces busca el ruc
                if (Convert.ToInt32(cboTipoDocRepre.SelectedValue) == 1)
                {
                    //token
                    dynamic respuesta = ConsultasApi.Get("https://dniruc.apisperu.com/api/v1/dni/" + txtDocRepre.Text + token);
                    txtNombreRepre.Text = respuesta.nombres.ToString() + " " + respuesta.apellidoPaterno.ToString() + " " + respuesta.apellidoMaterno.ToString();
                    pbRepresentante.Visible = false;
                }


                //sino busca el ruc
                else if (Convert.ToInt32(cboTipoDocRepre.SelectedValue) == 2 )
                {
                    //cambia el numero por defecto por el textbox
                    dynamic respuesta = ConsultasApi.Get("https://dniruc.apisperu.com/api/v1/ruc/" + txtDocRepre.Text + token);
                    // recibe la respuesta de la consulta en los respectivos textbox
                    txtNombreRepre.Text = respuesta.razonSocial.ToString();
                    //txtDireccionRepre.Text = respuesta.direccion.ToString();
                    pbRepresentante.Visible = false;

                }
                else
                {
                    //si ingresa mas caracteres. me saldraun error.
                    MessageBox.Show("Ingrese un número de documento válido.", "Documento inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(" catch Ingrese un número de documento válido." + ex, "Documento inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            pbTraerClientes.Refresh();
        }

        private void btnTrarDatosRepresentante_Click(object sender, EventArgs e)
        {
            dgDocumentoRP.Visible = false;
            pbRepresentante.Visible = true;
            pbRepresentante.Value = 0;
            if (pbRepresentante.Value == 0)
            {
                tmLlamarDatosRepresentante.Start();
            }
            else
            {
                resetProgressBar();
            }
            
               
        }

        private void tmLlamarDatosRepresentante_Tick(object sender, EventArgs e)
        {
            if (pbRepresentante.Value < 90)
            {
                pbRepresentante.Value += 10;
            }
            else if (pbRepresentante.Value == 90)
            {
                pbRepresentante.Value += 1;
                fnTrarDatosRepresentante();
                
            }
            else if (pbRepresentante.Value > 90 && pbRepresentante.Value < 100)
            {

                pbRepresentante.Value += 1;
                pbRepresentante.Value = 100;
            }
            else
            {
                if (pbRepresentante.Value >= 100)
                {
                    tmLlamarDatosRepresentante.Stop();

                }

            }
        }

        private void btnLimpiarRepre_Click(object sender, EventArgs e)
        {


            //Grupo Responsable Pago

            cboTipoDocRepre.SelectedValue = 0;
            cboCargoRepre.SelectedValue = 0;
            txtidRepreLegal.Text = "0";
            txtDocRepre.ReadOnly = false;
            txtDocRepre.Text = "";
            txtNombreRepre.Text = "";
            txtCorreoRepre.Text = "";
            txtTelefonoFijoRepre.Text = "";

            txtDireccionRepre.Text = "";
            tipoCon.lnTipoConRP = 0;
            //clsRespPago = new Cliente();

            imgTipoClienteRepre.Image = null;
            imgTipoDocRepre.Image = null;
            imgDocumentoRP.Image = null;
            erTipoClienteRepre.Text = "";
            erTipoDocRepre.Text = "";
            erDocumentoRP.Text = "";
            lblInfoCorreo.Text = "";

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

        private void cboCargoRepre_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Int32 idTD = Convert.ToInt32(cboCargoRepre.SelectedValue == null ? "0" : cboCargoRepre.SelectedValue.ToString());

            if (cboCargoRepre.Text.ToString() == "OTROS")
            {
                txtAddCargo.Enabled = true;
                //txtAddCargo.Text = "";
            }
            else
            {

                txtAddCargo.Enabled = false;
                txtAddCargo.Text = "";
            }

            var result = fnValidarCombobox(cboCargoRepre, erCargoRP, imgCargoRP);

            estCargo = result.Item1;
            msjCargo = result.Item2;
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
            Int32 idTipoDocumento = Convert.ToInt32(cboTipoDoc.SelectedValue);
            Int32 numKey = e.KeyChar;
            if (idTipoDocumento == 5)
            {
                if (Char.IsDigit(e.KeyChar) || (Char.IsControl(e.KeyChar)) || (Char.IsLetter(e.KeyChar)))
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
                if (Char.IsDigit(e.KeyChar) || (Char.IsControl(e.KeyChar)))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
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

        private void ocultarGroupBoxes(Int32 idTipoCliente)
        {
            if (idTipoCliente == 2)
            {

                gboDatosRepres.Enabled = true;
                gboDatosRepres.Visible = true;
                gboDatosRepres.Location = new Point(15, gbUbicacion.Location.Y + gbUbicacion.Size.Height + 20);
                gboSecun.Location = new Point(15, gboPrinci.Location.Y + gboPrinci.Size.Height + 20);
                gbUbicacion.Location = new Point(15, gboSecun.Location.Y + gboSecun.Size.Height + 20);
                gboContacto.Location = new Point(15, gboDatosRepres.Location.Y + gboDatosRepres.Size.Height + 20);
            }
            else
            {

                gboDatosRepres.Enabled = false;
                gboDatosRepres.Visible = false;
                gboSecun.Location = new Point(15, gboPrinci.Location.Y + gboPrinci.Size.Height + 20);
                gbUbicacion.Location = new Point(15, gboSecun.Location.Y + gboSecun.Size.Height + 20);
                gboContacto.Location = new Point(15, gbUbicacion.Location.Y + gbUbicacion.Size.Height + 20);

            }
        }
        private void cboTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCliente.SelectedValue != "0")
            {
                gboPrinci.Enabled = true;
            }

            Boolean bResult;
            Int32 idTipoCliente = Convert.ToInt32(cboTipoCliente.SelectedValue == null ? "0" : cboTipoCliente.SelectedValue.ToString());

            ocultarGroupBoxes(idTipoCliente);

            fnLLenarDocumentoDeTipoPersona(cboTipoDoc, idTipoCliente, "1", false);
            fnLLenarDocumentoDeTipoPersona(cboTipoDocRepre, 1, "1", false);
            FunGeneral.fnLlenarTablaCodTipoCon(cboCargoRepre, "CCRE", false);



            if (idTipoCliente == 0)
            {
                cboTipoDoc.Enabled = false;
                txtidRepreLegal.Text = "0";

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
            var result = fnValidarCombobox(cboTipoCliente, erTipoCliente, imgTipoCliente);
            var resultRepre = fnValidarCombobox(cboTipoClienteRepre, erTipoClienteRepre, imgTipoClienteRepre);
            String msj;
            imgTipoClienteRepre.Image = Properties.Resources.ok;
            msj = "";
            erTipoClienteRepre.Text = msj;


            estTipoCliente = result.Item1;
            msjTipoCliente = result.Item2;

            estTipoCliente = resultRepre.Item1;
            msjTipoCliente = resultRepre.Item2;

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
                if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar)) || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (num == 4)
            {

                if ((Char.IsWhiteSpace(e.KeyChar)) || (Char.IsLetter(e.KeyChar))
                    || (Char.IsNumber(e.KeyChar)) || (Char.IsControl(e.KeyChar))
                    || (e.KeyChar == '@') || (e.KeyChar == '_') || (e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (num == 5)
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
                lbl.Text = msj;
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
            var result = fnValidarTexbox(txtNombre, erNombre, imgNombre, true, 3);

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

            var result = fnValidarTexboxDocumentoSQL(txtNrDocumento, erNrDocumento, imgNroDocumento, bResult.Item1, bResult.Item2, bResult.Item3);
            estNroDocumento = result.Item1;
            msjNroDocumento = result.Item2;
        }

        private Tuple<Int32, Boolean, String> fnObtenerDatosDocumento(Int32 idTD, List<TipoDocumento> lstTD)
        {
            foreach (TipoDocumento doc in lstTD)
            {
                if (doc.TDid == idTD)
                {
                    return Tuple.Create(doc.TDmaxCaracteres, doc.TDcarcObligatorio, doc.TDcaracter);
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
                lbl.Text = msj;
                lbl.ForeColor = Color.Green;
                return Tuple.Create(true, msj);
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
        private Tuple<Boolean, String> fnValidarEmail(SiticoneTextBox txt, Label lbl, PictureBox img, Int32 max)
        {
            String msj = "";
            if (txt.Text == null || txt.Text.Trim() == "")
            {
                img.Image = null;
                msj = "vacio (campo no obligatorio)";
                lbl.Text = msj;
                lbl.ForeColor = Color.Green;
                return Tuple.Create(true, msj);

            }
            else if (txt.Text.Length > 0)
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
            else
            {
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

            if (fechaActualMenos100anios > fechaNacimiento)
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
