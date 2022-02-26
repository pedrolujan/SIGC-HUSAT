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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmRegistrarAccesorios : Form
    {
       
        public frmRegistrarAccesorios()
        {
            estPasoLoad = false;
            InitializeComponent();
            cboBuscar.SelectedIndex = 0;
            fnHabilitarGroupBoxs(false);
            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            FunValidaciones.fnColorBotones(btnNuevo, btnEditar, btnGuardar, btnSalir);
            fnLimpiarControles();
            tabRegistro.AutoScroll = false;
            estPasoLoad = true;
        }

        static Boolean estPasoLoad;
        Int16 lnTipoCon = 0;
        Int16 lnTipoLlamada = 0;
        static String lcAccesorio = "";
        static int lnTipoValor = 0;
        static Int32 tabInicio;
        Boolean estActualizar;

        Boolean estNombre, estPrecio, estDescripcion,estStock;
        String msjNombreAccesorio, msjPrecio, msjDescripcion,msjStock;
        public static void fnRecuperarAccesorio(String pcMarca, int pnTipoValor = 0)
        {
            lcAccesorio = pcMarca;
            lnTipoValor = pnTipoValor;
        }
       
        
        private String fnGuardarAccesorio(Int16 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLAccesorio objAttrV = new BLAccesorio();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Accesorios objAccesorio = new Accesorios();
            //Boolean bCargar = false;

            try
            {
                objAccesorio.idAccesorio = Convert.ToInt32(txtCodigo.Text);
                objAccesorio.cAccesorio= Convert.ToString(txtNombre.Text.Trim());               
                objAccesorio.bEstado = Convert.ToBoolean(chkEstado.Checked);
                objAccesorio.cPrecio = Convert.ToDouble(txtPrecio.Text.Trim());
                objAccesorio.cStock = Convert.ToInt32(txtSotck.Text.Trim());
                objAccesorio.cDescripcion = Convert.ToString(txtDescripcion.Text.Trim());
                objAccesorio.dFechaRegistro = dFechaSis;
                objAccesorio.idUsuario = Variables.gnCodUser;

                lcValidar = objAttrV.blGrabarAccesorio(objAccesorio, idTipoCon).Trim();
                
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarAccesorio", "fnGuardarAccesorio", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }
        private void fnLimpiarControles()
        {
            /////TEXBOXS/////
            txtCodigo.Text = "0";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtSotck.Text = "";
            txtDescripcion.Text = "";
            txtBuscar.Text = "";
            txtIdAccesorio.Visible = false;

            ////LABELS////
            erNombre.Text = "";
            erPrecio.Text = "";
            erStock.Text = "";
            erDescripcion.Text = "";
            lblVerID.Visible = false;
            

            ////PICTUREBOXS////
            imgNombre.Image = null;
            imgPrecio.Image = null;
            imgStock.Image = null;
            imgDescripcion.Image = null;

            ////CHEKSBOXS/////
            chkEstado.Checked = true;

            ////LISTBOXS/////
            dgAccesorios.Visible = false;
            
            txtBuscar.Focus();

        }

        private Boolean fnBuscarTablaHistorial( Int32 idHistorial)
        {
            BLAccesorio objAcc = new BLAccesorio();
            clsUtil objUtil = new clsUtil();
            DataTable datAcces = new DataTable();
            List<Accesorios> lstAcce = null;

            try
            {
                lstAcce = new List<Accesorios>();


                datAcces = objAcc.blBuscarAccesorioHistorial(idHistorial);

                Int32 totalResultados = datAcces.Rows.Count;

                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("FECHA CAMBIO");
                    dt.Columns.Add("NOMBRE");
                    dt.Columns.Add("PRECIO");
                    dt.Columns.Add("STOCK");
                    dt.Columns.Add("ESTADO");
                    dt.Columns.Add("DESCRIPCIÓN");


                    Int32 y = 0;

                    String estadoAcc;
                    for (int i = 0; i <= totalResultados - 1; i++)
                    {
                        y += 1;
                        if (Convert.ToBoolean(datAcces.Rows[i][5]) == true)
                        {
                            estadoAcc = "ACTIVO";
                        }
                        else
                        {
                            estadoAcc = "INACTIVO";
                        }
                        String precio = "S/ " + String.Format("{0:0.00}", Math.Round(Convert.ToDouble(datAcces.Rows[i][3])));
                        object[] row = {
                            datAcces.Rows[i][0],
                            y,
                            datAcces.Rows[i][1],
                            datAcces.Rows[i][2],
                            precio ,
                            datAcces.Rows[i][4],
                            estadoAcc,
                             datAcces.Rows[i][6],

                        };
                        dt.Rows.Add(row);

                    }

                    dgHistorialAccesorios.DataSource = dt;

                    dgHistorialAccesorios.Columns[0].Visible = false;
                    dgHistorialAccesorios.Columns[1].Width = 40;
                    dgHistorialAccesorios.Columns[2].Width = 150;
                    dgHistorialAccesorios.Columns[3].Width = 200;
                    dgHistorialAccesorios.Columns[4].Width = 50;
                    dgHistorialAccesorios.Columns[5].Width = 50;
                    dgHistorialAccesorios.Columns[6].Width = 70;
                    dgHistorialAccesorios.Columns[7].Width = 250;

                    dgHistorialAccesorios.Visible = true;
                    
                    return true;


                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    
                    dt.Columns.Add("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS");
                    dgHistorialAccesorios.DataSource = dt;
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private Boolean fnBuscarTabla(String pcBuscar,Int32 numPagina, Int32 tipoCon)
        {
            BLAccesorio objAcc = new BLAccesorio();
            clsUtil objUtil = new clsUtil();
            DataTable datAcces = new DataTable();
            List<Accesorios> lstAcce = null;
            String estado;
            Int32 filas = 10;

            try
            {
                lstAcce = new List<Accesorios>();

                if (cboBuscar.SelectedIndex == 2)
                {
                    estado = "0";
                }
                else if (cboBuscar.SelectedIndex == 1)
                {
                    estado = "1";
                }
                else
                {
                    estado = "";
                }

                datAcces = objAcc.blBuscarAccesorioDataTable(pcBuscar, estado,numPagina,tipoCon);

                Int32 totalResultados = datAcces.Rows.Count;

                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("NOMBRE");
                    dt.Columns.Add("PRECIO");
                    dt.Columns.Add("STOCK");
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

                    String estadoAcc;
                    for (int i = 0; i <= totalResultados - 1; i++)
                    {
                        y += 1;
                        if (Convert.ToBoolean(datAcces.Rows[i][4]) == true)
                        {
                            estadoAcc = "ACTIVO";
                        }
                        else
                        {
                            estadoAcc = "INACTIVO";
                        }
                        String precio = "S/ " + String.Format("{0:0.00}",Math.Round(Convert.ToDouble(datAcces.Rows[i][2])));
                        object[] row = { 
                            datAcces.Rows[i][0], 
                            y,
                            datAcces.Rows[i][1], 
                            precio , 
                            datAcces.Rows[i][3], 
                            estadoAcc 
                        };
                        dt.Rows.Add(row);

                    }
                    
                    dgAccesorios.DataSource = dt;

                    dgAccesorios.Columns[0].Visible = false;
                    dgAccesorios.Columns[1].Width = 40;
                    dgAccesorios.Columns[2].Width = 300;
                    dgAccesorios.Columns[3].Width = 100;
                    dgAccesorios.Columns[4].Width = 100;
                    dgAccesorios.Columns[5].Width = 150;
                    
                    dgAccesorios.Visible = true;
                   
                    if (tipoCon == -1)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datAcces.Rows[0][5]);
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
                    dgAccesorios.Visible = true;
                    dt.Columns.Add("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS");
                    dgAccesorios.DataSource = dt;
                    gbPaginacion.Visible = false;
                    return false;
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

        private Boolean fnRecuperarAccesorioEsp()
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                //if (lvAccesorio.Items.Count > 0)
                //{
                //    ListView.SelectedListViewItemCollection item = lvAccesorio.SelectedItems;
                //    if (item.Count > 0)
                //    {
                //        frmRegistrarAccesorios.fnRecuperarAccesorio(item[0].Text.Trim(), 1);
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
        
        private Boolean fnListarAccesorioEspecifico(DataGridView dgv)
        {
            
            clsUtil objUtil = new clsUtil();
            
            try
            {
                if (dgAccesorios.Rows.Count > 0)
                {
                    BLAccesorio objAcc = new BLAccesorio();
                    Accesorios lstAcce = new Accesorios();
                    DataTable dtAccesorio = new DataTable();

                    Int32 idAccesorio = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value.ToString());

                    lstAcce = objAcc.blListarAccesoriosDataGrid(idAccesorio,1);

                    if (lstAcce.idAccesorio > 0)
                    {
                        txtActualizar.Text = Convert.ToString(lstAcce.cAccesorio.ToString().Trim());
                        txtIdAccesorio.Text = Convert.ToString(lstAcce.idAccesorio.ToString().Trim());
                        txtCodigo.Text = Convert.ToString(lstAcce.idAccesorio.ToString().Trim());
                        txtNombre.Text = Convert.ToString(lstAcce.cAccesorio.ToString().Trim());
                        txtPrecio.Text = Convert.ToString(Math.Round(lstAcce.cPrecio,2));
                        txtSotck.Text = Convert.ToString(lstAcce.cStock.ToString());
                        txtDescripcion.Text = Convert.ToString(lstAcce.cDescripcion.ToString().Trim());

                        chkEstado.Checked = lstAcce.bEstado;

                        fnHabilitarGroupBoxs(false);
                        fnVerValidacion(false);
                        txtIdAccesorio.Visible = true;
                        lblVerID.Visible = true;
                        FunValidaciones.fnHabilitarBoton(btnNuevo, true);
                        FunValidaciones.fnHabilitarBoton(btnEditar, true);
                        FunValidaciones.fnHabilitarBoton(btnGuardar, false);
                        FunValidaciones.fnHabilitarBoton(btnSalir, true);
                        txtBuscar.Text = "";
                        lnTipoCon = 1;
                        tabControl.SelectedIndex = 0;
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

        private void fnVerValidacion(Boolean estado)
        {
            /////TEXBOXS/////
            erNombre.Visible = estado;
            erPrecio.Visible = estado;
            erStock.Visible = estado;
            erDescripcion.Visible = estado;
            /////PICTUREBOXS////
            imgNombre.Visible = estado;
            imgPrecio.Visible = estado;
            imgStock.Visible = estado;
            imgDescripcion.Visible = estado;

        }

       

        private Tuple<Boolean, String> fnValidarTexboxSQL(SiticoneTextBox txt, Label lbl, PictureBox img, Boolean maximo, Int32 num)
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
            else if (estActualizar == true)
            {

                if (txtActualizar.Text.Trim() == txt.Text.Trim())
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
                    bResul = fnBuscarNombreTipoPlan(txt.Text.Trim(), pnTipocon);
                    return Tuple.Create(bResul, msj);

                }

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                bResul = fnBuscarNombreTipoPlan(txt.Text.Trim(), pnTipocon);
                return Tuple.Create(bResul, msj);

            }


        }

        
        private Boolean fnBuscarNombreTipoPlan(String pcBuscar, Int16 pnTipoCon)
        {
            BLAccesorio objAcc = new BLAccesorio();
            clsUtil objUtil = new clsUtil();
            Int16 numResult = 0;

            try
            {

                numResult = objAcc.blBuscarNombreAccesorio(pcBuscar, pnTipoCon);

                if (numResult == 1)
                {
                    erNombre.Text = "Este nombre ya existe (Ingrese otro nombre)";
                    erNombre.ForeColor = Color.Red;
                    imgNombre.Image = Properties.Resources.error;
                    return false;
                }
                else if (numResult == 0)
                {
                    erNombre.Text = "";
                    imgNombre.Image = Properties.Resources.ok;
                    return true;
                }
                else
                {
                    erNombre.Text = "Ocurrió otro error";
                    erNombre.ForeColor = Color.Red;
                    imgNombre.Image = Properties.Resources.error;
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorio", "fnBuscarAccesorio", ex.Message);
                return false;
            }
            finally
            {

                objAcc = null;
                objUtil = null;
            }
        }

       

        private void rdbNombre_CheckedChanged(object sender, EventArgs e)
        {
            
            fnLimpiarControles();
            fnVerValidacion(false);
            fnHabilitarGroupBoxs(false);
        }

        private void fnHabilitarGroupBoxs(Boolean pbAccesorio)
        {
            gbFromAccesorios.Enabled = pbAccesorio;
        }

       

        private void btnEditar_Click(object sender, EventArgs e)
        {
            fnHabilitarGroupBoxs(true);
            fnVerValidacion(true);
            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, true);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String lcResultado;

            nombre_Changed(sender, e);
            precio_Changed(sender, e);
            descripcion_Changed(sender, e);
            txtSotck_TextChanged(sender, e);
            if (estNombre && estPrecio && estDescripcion)
            {
                lcResultado = fnGuardarAccesorio(lnTipoCon);
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Se Grabó Satisfactoriamente Accesorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    fnLimpiarControles();
                    fnHabilitarGroupBoxs(false);
                    FunValidaciones.fnHabilitarBoton(btnNuevo, true);
                    FunValidaciones.fnHabilitarBoton(btnEditar, false);
                    FunValidaciones.fnHabilitarBoton(btnGuardar, false);
                    FunValidaciones.fnHabilitarBoton(btnSalir, true);
                    

                }
                else
                {
                    MessageBox.Show("Error al Grabar Accesorio. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Complete correctamente los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (estPasoLoad)
                {
                    String busqueda = txtBuscar.Text.ToString().Trim();
                    fnBuscarTabla(busqueda,0,-1);
                }

            }
        }

        private void dgTipoPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            estActualizar = true;
            if (lnTipoLlamada == 0)
            {
                Boolean bResul = false;
                bResul = fnListarAccesorioEspecifico(dgAccesorios);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            else if (lnTipoLlamada == 1)
            {

                Boolean bResul = false;
                bResul = fnRecuperarAccesorioEsp();
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar Marca Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.Dispose();
                }
            }

           
            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, true);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            fnHabilitarGroupBoxs(false);

            fnVerValidacion(false);
            
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true,erNombre);
            
        }

        private void precio_Changed(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtPrecio, erPrecio, imgPrecio, true, false, true,1, 999999, 0,6, "Dato precio inválido");
            estPrecio = result.Item1;
            msjPrecio = result.Item2;

            
            

           
            
            

            //precio.ToString("0.00", CultureInfo.InvariantCulture);
        }

        private void txtSotck_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", false,erStock);
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnHabilitarGroupBoxs(true);
            fnVerValidacion(true);
            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, true);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            tabRegistro.AutoScroll = false;
        }

        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscar.Text.ToString().Trim();
                fnBuscarTabla(busqueda, 0, -1);
            }

        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            String busqueda = txtBuscar.Text.Trim().ToString();
            Int32 pagina = Convert.ToInt32(cboPagina.Text.ToString());

            fnBuscarTabla(busqueda, pagina, -2);
        }

        private void verHistorial_Click(object sender, EventArgs e)
        {
            
        }

       
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscar.Text.ToString().Trim();
                fnBuscarTabla(busqueda, 0, -1);
            }
        }

        private void opcEditar_Click(object sender, EventArgs e)
        {
            estActualizar = true;
            
            Boolean bResul = false;
            bResul = fnListarAccesorioEspecifico(dgAccesorios);
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            
            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, true);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);
            
            tabControl.SelectedIndex = 0;
            tabRegistro.AutoScroll = false;
            fnHabilitarGroupBoxs(false);
            fnVerValidacion(false);
        }

        private void opcMovimiento_Click(object sender, EventArgs e)
        {
            estActualizar = true;

            Boolean bResul = false;
            bResul = fnListarAccesorioEspecifico(dgAccesorios);
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            Int32 idbusqueda = Convert.ToInt32(txtIdAccesorio.Text.Trim());

            bResul = fnBuscarTablaHistorial(idbusqueda);

            if (!bResul)
            {
                MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            FunValidaciones.fnHabilitarBoton(btnEditar, true);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            FunValidaciones.fnHabilitarBoton(btnSalir, true);

            tabControl.SelectedIndex = 0;
            tabRegistro.AutoScroll = true;
            fnHabilitarGroupBoxs(false);
            fnVerValidacion(false);
        }

        private void rdbPrecio_CheckedChanged(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnVerValidacion(false);
            fnHabilitarGroupBoxs(false);
        }

        private void txtSotck_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtSotck, erStock, imgStock, true, false, true, 0, 999999, 0,5, "Ingrese correctamente el campo");
            estStock = result.Item1;
            msjStock = result.Item2;
        }

        private void nombre_Changed(object sender, EventArgs e)
        {
            var result = fnValidarTexboxSQL(txtNombre, erNombre, imgNombre, false, 0);
            estNombre = result.Item1;
            msjNombreAccesorio = result.Item2;
            txtNombre.MaxLength = 45;
        }

       

        private void precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "MONEDA", false,erPrecio);
            
        }

        private void descripcion_Changed(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtDescripcion, erDescripcion, imgDescripcion, false, true, true, 0, 0,3,200, "Complete correctamente el campo");
            estDescripcion = result.Item1;
            msjDescripcion = result.Item2;
        }

        private void descripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);
            e.KeyChar = char.ToUpper(e.KeyChar);

        }

        
    }
}
