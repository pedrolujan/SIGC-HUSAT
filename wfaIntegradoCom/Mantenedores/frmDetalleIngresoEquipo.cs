using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Siticone.Desktop.UI.WinForms;
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
    public partial class frmDetalleIngresoEquipo : Form
    {
        public frmDetalleIngresoEquipo()
        {
            InitializeComponent();
        }
        static OrdenSimCard ClsOrdenSC = new OrdenSimCard();

        Int16 lnTipoLlamada;
        static Boolean estPasoLoad;
        static Int32 tabInicio;
        static Int32 idOrdenCompra;
        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();
        }
        private void fnCargarCombobox()
        {
            Boolean bResult = false;

            
            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboTipoIngresoBuscar, "TIOI", true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Tipo de Orden de Ingreso Buscar", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboTipoOrdenImies, "TIOI", false);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Tipo de Orden de Ingreso Buscar", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            } 
            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboTipoOrdenIngreso, "TIOC", true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Tipo de Orden de Ingreso Buscar", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }



            cboEstIngresoImeis.SelectedIndex = 0;
        }
        public  Boolean fnLlenarEstadoIngreso(ComboBox cboCombo)
        {
            BLOrdenCompra objTablaCod = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                
                lstTablaCod = objTablaCod.blDevolverTablaCod(lnTipoLlamada);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodTab";
                cboCombo.DisplayMember = "cNomTab";
                cboCombo.DataSource = lstTablaCod;

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
                lstTablaCod = null;
            }

        }
        private void frmDetalleIngresoEquipo_Load(object sender, EventArgs e)
        {
            estPasoLoad = false;
            Boolean bResult = false;
            Cargo[] arrParametro2 = new Cargo[1];
            clsUtil objUtil = new clsUtil();

            try
            {

                DateTime fechaInicial = Variables.gdFechaSis.AddDays(-30);
                DateTime fechaFinal = Variables.gdFechaSis;
                dtpFechaInicio.Value = fechaInicial;
                dtpFechaFinal.Value = fechaFinal;
                fnCargarCombobox();
                fnLlenarEstadoIngreso(cboEstadoIngreso);
                cboTipoOrdenIngreso.SelectedIndex = 1;

                if (lnTipoLlamada == 0)
                {
                    
                }
                else if (lnTipoLlamada == 1 || lnTipoLlamada==2)
                {
                    
                    cboEstadoIngreso.SelectedIndex = 1;
                    cboEstIngresoImeis.SelectedIndex = 2;
                    cboEstIngresoImeis.Enabled = false;
                }
                
                gbPaginacion.Visible = false;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "frmOrdenCompra_Load", ex.Message);
            }
            finally
            {
                objUtil = null;
                arrParametro2 = null;
                estPasoLoad = true;
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {


                String busqueda = txtBuscar.Text.Trim().ToString();

                fnBuscarTabla(busqueda, 0, -1);
            }
        }

        private Boolean fnBuscarTabla(String pcBuscar, Int32 numPagina, Int32 tipoCon)
        {
            BLOrdenCompra objPlan = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();
            List<OrdenCompra> lstPlan = null;
            Int32 filas = 10;
            String estIngresoImeis;
            try
            {
                lstPlan = new List<OrdenCompra>();

                String pnTipoIngreso = cboTipoIngresoBuscar.SelectedValue == null ? "0" : cboTipoIngresoBuscar.SelectedValue.ToString();

                DateTime fechaInicial = fnCalcularSoloFecha(dtpFechaInicio.Value);
                DateTime fechaFinal = (fnCalcularSoloFecha(dtpFechaFinal.Value)).AddDays(1);

                Boolean HabilitarFechas = Convert.ToBoolean(chkHabilitarFechas.Checked);

                String CodTipoIngreso = "";

                if (cboEstIngresoImeis.SelectedIndex == 1)
                {
                    estIngresoImeis = "1";
                }
                else if (cboEstIngresoImeis.SelectedIndex == 2)
                {
                    estIngresoImeis = "0";
                }
                else
                {
                    estIngresoImeis = "";
                }
                if (lnTipoLlamada == 3)
                {
                    CodTipoIngreso = "TIOC0002";
                }
                else if (lnTipoLlamada == 1)
                {
                    CodTipoIngreso = "TIOC0001";
                }
                else
                {
                    CodTipoIngreso = cboTipoOrdenIngreso.SelectedValue.ToString(); ;
                }

                datTipoPlan = objPlan.blBuscarDetalleDataTable(pcBuscar, pnTipoIngreso, fechaInicial, fechaFinal, numPagina, tipoCon, estIngresoImeis, HabilitarFechas, Convert.ToString(cboEstadoIngreso.SelectedValue), CodTipoIngreso);

                Int32 totalResultados = datTipoPlan.Rows.Count;


                DataTable dt = new DataTable();
             
                if (totalResultados > 0 && CodTipoIngreso == "TIOC0001")
                {
                  

                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("TIP. ORDEN");
                    dt.Columns.Add("COD. INGRESO");
                    dt.Columns.Add("CANT. EQUIPOS");
                    dt.Columns.Add("FECH. INGRESO");
                    dt.Columns.Add("INGRESO IMEIS");
                    dt.Columns.Add("EST. ORDEN");
                    dt.Columns.Add("IDEQUIPOUNICO");
                    dt.Columns.Add("EQUIPO");
                }


                if (totalResultados > 0 && CodTipoIngreso == "TIOC0002")
                {
                   

                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("TIP. ORDEN");
                    dt.Columns.Add("NUM. RECIBO");
                    dt.Columns.Add("STOCK");
                    dt.Columns.Add("FECHA. COMPRA");
                    dt.Columns.Add("INGRESO SIMCARD");
                    dt.Columns.Add("EST. ORDEN");
                    dt.Columns.Add("OPERADOR");
                    dt.Columns.Add("PROVEEDOR");
                }





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
                    Boolean ingresoImeis;
                    for (int i = 0; i <= totalResultados - 1; i++)
                    {
                        y += 1;
                        String fechaIngreso = "";
                        String est = "";
                        String estadoOrden = datTipoPlan.Rows[i][6].ToString().Trim();


                        //if (CodTipoIngreso == "TIOC0001")
                        //{
                            if (estadoOrden == "ANULADO")
                            {
                                est = "❌ NO INGRESAR";

                            }
                            else
                            {
                                ingresoImeis = Convert.ToBoolean(datTipoPlan.Rows[i][5]);
                                est = ingresoImeis ? "✔ INGRESADOS " : "⚠ NO INGRESADOS";

                            }
                        //}

                        if (CodTipoIngreso == "TIOC0001")
                        {

                            DateTime fechatabla = Convert.ToDateTime(datTipoPlan.Rows[i][4]);
                            fechaIngreso = fechatabla.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-ES"));

                            object[] row = {
                                datTipoPlan.Rows[i][0],
                                y,
                                datTipoPlan.Rows[i][1],
                                datTipoPlan.Rows[i][2],
                                datTipoPlan.Rows[i][3],
                                fechaIngreso,
                                est,
                                estadoOrden,
                                datTipoPlan.Rows[i][8],
                                datTipoPlan.Rows[i][9]

                            };

                            dt.Rows.Add(row);
                        }
                        else
                        {
                            DateTime fechatabla = Convert.ToDateTime(datTipoPlan.Rows[i][4]);
                            fechaIngreso = fechatabla.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-ES"));

                            object[] row = {
                                    datTipoPlan.Rows[i][0],
                                    y,
                                    datTipoPlan.Rows[i][1],
                                    datTipoPlan.Rows[i][2],
                                    datTipoPlan.Rows[i][3],
                                    fechaIngreso,
                                    est,
                                    estadoOrden,
                                    datTipoPlan.Rows[i][4],
                                    datTipoPlan.Rows[i][8]
                                    
                                };

                            dt.Rows.Add(row);

                        }
                 


                    }

                    dgOrdenIngreso.DataSource = dt;

                    dgOrdenIngreso.Columns[0].Visible = false;
                    dgOrdenIngreso.Columns[1].Width = 30;
                    dgOrdenIngreso.Columns[2].Width = 100;
                    dgOrdenIngreso.Columns[3].Width = 100;
                    dgOrdenIngreso.Columns[4].Width = 100;
                    dgOrdenIngreso.Columns[5].Width = 150;
                    dgOrdenIngreso.Columns[6].Width = 150;
                    dgOrdenIngreso.Columns[7].Width = 150;
                    dgOrdenIngreso.Columns[8].Visible = false;

                    dgOrdenIngreso.Columns[9].Visible = false;





                    dgOrdenIngreso.Visible = true;
                    if (tipoCon == -1)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datTipoPlan.Rows[0][7]);
                        fnCalcularPaginacion(totalRegistros, filas, totalResultados);
                    }
                    else
                    {
                        btnNumFilas.Text = Convert.ToString(totalResultados);
                    }


                    return true;
                //}
                //else
                //{
                //    DataTable dt = new DataTable();
                //    dt.Clear();
                //    dt.Columns.Add("NO SE ENCONTRÓ NINGÚN REGISTRO CON ESTAS COINCIDENCIAS");
                //    dgOrdenIngreso.DataSource = dt;
                //    gbPaginacion.Visible = false;
                //    return false;
                //}

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private DateTime fnCalcularSoloFecha(DateTime fecha)
        {
            String TextSoloFecha = fecha.ToString("yyyy/MM/dd");
            DateTime dtFecha = Convert.ToDateTime(TextSoloFecha);
            return dtFecha;
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

        private void fnCalcularPaginacionImeis(Int32 totalRegistros, Int32 filas, Int32 totalResultados)
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

            cboFilasImeis.Items.Clear();

            for (Int32 i = 1; i <= cantidadPaginas; i++)
            {
                cboFilasImeis.Items.Add(i);

            }

            cboFilasImeis.SelectedIndex = 0;
            btnTotalFilasImies.Text = Convert.ToString(cantidadPaginas);
            btnRegistrosMostradosImeis.Text = Convert.ToString(totalResultados);
            btnRegistrosTotalesImeis.Text = Convert.ToString(totalRegistros);


        }

        private void cboTipoIngresoBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscar.Text.Trim().ToString();

                fnBuscarTabla(busqueda, 0, -1);
            }
        }

        private void cboEstadoBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscar.Text.Trim().ToString();

                fnBuscarTabla(busqueda, 0, -1);
            }
        }

        private void cboEstIngresoImeis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscar.Text.Trim().ToString();

                fnBuscarTabla(busqueda, 0, -1);
            }
        }
        private void cboEstadoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscar.Text.Trim().ToString();

                fnBuscarTabla(busqueda, 0, -1);
            }
        }
        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            String busqueda = txtBuscar.Text.Trim().ToString();
            Int32 pagina = Convert.ToInt32(cboPagina.Text.ToString());
            
                fnBuscarTabla(busqueda, pagina, -2);
           
        }

        private void dgOrdenIngreso_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            String nombreCabecera = dgv.Columns[e.ColumnIndex].HeaderText.ToString();

            if (nombreCabecera == "INGRESO IMEIS")
            {
                if (e.Value.ToString().Contains("✔"))
                {
                    e.CellStyle.ForeColor = Variables.ColorSuccess;
                }
                else if (e.Value.ToString().Contains("⚠"))
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }
                else if (e.Value.ToString().Contains("❌"))
                {
                    e.CellStyle.ForeColor = Variables.ColorError;

                }

            }
        }
        private Boolean fnRecuperarOrdenEspecifica(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                if(lnTipoLlamada==1)
                {
                    if (dgOrdenIngreso.Rows.Count > 0)
                    {


                        frmEquipoImeis.fnRecuperarOredenCompra(Convert.ToInt32(dgOrdenIngreso.Rows[e.RowIndex].Cells[0].Value),
                                                               Convert.ToString(dgOrdenIngreso.Rows[e.RowIndex].Cells[2].Value),
                                                               Convert.ToString(dgOrdenIngreso.Rows[e.RowIndex].Cells[3].Value),
                                                               Convert.ToInt32(dgOrdenIngreso.Rows[e.RowIndex].Cells[4].Value),
                                                               Convert.ToInt32(dgOrdenIngreso.Rows[e.RowIndex].Cells[8].Value),
                                                               Convert.ToString(dgOrdenIngreso.Rows[e.RowIndex].Cells[9].Value), 1);
                    }
                }
                else if (lnTipoLlamada == 3)
                {


                        ClsOrdenSC.idDetalleSC = Convert.ToInt32(dgOrdenIngreso.Rows[e.RowIndex].Cells[0].Value);
                        ClsOrdenSC.TipoIngreso = Convert.ToString(dgOrdenIngreso.Rows[e.RowIndex].Cells[2].Value);
                        ClsOrdenSC.NumeroRecibo = Convert.ToString(dgOrdenIngreso.Rows[e.RowIndex].Cells[3].Value);
                        ClsOrdenSC.StockOrdenSC = Convert.ToInt32(dgOrdenIngreso.Rows[e.RowIndex].Cells[4].Value);
                        ClsOrdenSC.OperadorSC = Convert.ToString(dgOrdenIngreso.Rows[e.RowIndex].Cells[9].Value);

                    frmSimCardMasivo.fnRecuperarSimCard(ClsOrdenSC);

                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnRecuperarClienteEsp", ex.Message);
                return false;
            }
        }

        private Boolean fnRecuperarOrdenEspecificaAsig(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (dgOrdenIngreso.Rows.Count > 0)
                {
                    frmAsignacionADocumento.fnRecuperarOredenCompra(Convert.ToInt32(dgOrdenIngreso.Rows[e.RowIndex].Cells[0].Value), Convert.ToString(dgOrdenIngreso.Rows[e.RowIndex].Cells[2].Value), Convert.ToString(dgOrdenIngreso.Rows[e.RowIndex].Cells[3].Value), Convert.ToInt32(dgOrdenIngreso.Rows[e.RowIndex].Cells[4].Value), Convert.ToString(dgOrdenIngreso.Rows[e.RowIndex].Cells[7].Value), 1);

                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnRecuperarClienteEsp", ex.Message);
                return false;
            }
        }
        private void dgOrdenIngreso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Boolean bResul = false;
            if (lnTipoLlamada == 1)
            {
                bResul = fnRecuperarOrdenEspecifica(e);
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar orden de compra especifica", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.Dispose();
                }
            }else if (lnTipoLlamada==2)
            {
                bResul = fnRecuperarOrdenEspecificaAsig(e);
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar orden de compra especifica", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.Dispose();
                }

            }
            else if (lnTipoLlamada == 3)
            {
                bResul = fnRecuperarOrdenEspecifica(e);
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar orden de compra especifica", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    this.Dispose();
                }

            }


        }

        private void opcVerImies_Click(object sender, EventArgs e)
        {
            Boolean bResul = false;

            bResul = fnBuscarTablaImies(dgOrdenIngreso, 1,-1);
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private Boolean fnBuscarTablaImies(DataGridView dgv, Int32 numPagina, Int32 tipoCon)
        {
            BLOrdenCompra objPlan = new BLOrdenCompra();
            clsUtil objUtil = new clsUtil();
            DataTable datTipoPlan = new DataTable();
           
            Int32 filas = 10;
            Int32 idDetalle;
            try
            {

                idOrdenCompra = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value.ToString());
                String TipoIngreso = Convert.ToString(cboTipoOrdenIngreso.SelectedValue);
                datTipoPlan = objPlan.blBuscarImiesDataTable(idOrdenCompra, numPagina, tipoCon, TipoIngreso);

                Int32 totalResultados = datTipoPlan.Rows.Count;
                
                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    
                    dt.Columns.Add("N°");
                    dt.Columns.Add(TipoIngreso== "TIOC0001" ? "NÚMERO SERIE":"SIMCARD");
                    dt.Columns.Add(TipoIngreso == "TIOC0001"?"IMEI": "NÚMERO SERIE");

                    Int32 y ;
                    txtCodigoOrdenCompra.Text = Convert.ToString(datTipoPlan.Rows[0][0]);
                    String codTipoOrdenImeis = Convert.ToString(datTipoPlan.Rows[0][1].ToString());
                    cboTipoOrdenImies.SelectedValue = codTipoOrdenImeis;
                    String estadoOrden = Convert.ToString(datTipoPlan.Rows[0][2].ToString());
                    txtEstadoOrden.Text = estadoOrden;
                    Int32 cantidadImeis = Convert.ToInt32(datTipoPlan.Rows[0][3]);
                    txtCantImies.Text = cantidadImeis.ToString();
                    
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
                        String imie = datTipoPlan.Rows[i][4].ToString();
                        if (imie == "" || imie == null)
                        {

                        }
                        else
                        {
                            y += 1;
                            object[] row = {
                            y,
                            datTipoPlan.Rows[i][4],
                            datTipoPlan.Rows[i][5],

                            };

                            dt.Rows.Add(row);
                        }
                       

                    }
                    if (estadoOrden == "ANULADO")
                    {
                        lblEstadoIngreso.Text = "❌ ORDEN ANULADA NO INGRESE IMEIS";
                        lblEstadoIngreso.ForeColor = Variables.ColorError;
                        btnEstadoIngresoImeis.FillColor = Variables.ColorError;
                    }
                    else
                    {
                        if (Convert.ToInt32(txtCantImies.Text.ToString()) == y)
                        {
                            lblEstadoIngreso.Text = "✔ TODOS LOS IMEIS INGRESADOS";
                            lblEstadoIngreso.ForeColor = Variables.ColorSuccess;
                            btnEstadoIngresoImeis.FillColor = Variables.ColorSuccess;
                        }
                        else
                        {
                            lblEstadoIngreso.Text = "⚠ FALTAN " + (cantidadImeis - y) + " IMIES POR INGRESAR";
                            lblEstadoIngreso.ForeColor = Color.Orange;
                            btnEstadoIngresoImeis.FillColor = Color.Orange;
                        }
                    }
                    
                    if (y == 0)
                    {
                        DataTable dt2 = new DataTable();
                        dt2.Clear();
                        dt2.Columns.Add("NO SE ENCONTRÓ NINGÚN IMEI INGRESADO A ESTA ORDEN DE COMPRA");
                        dgImiesdeOrden.DataSource = dt2;
                        gbPaginacionImies.Visible = false;
                    }
                    else
                    {

                        dgImiesdeOrden.DataSource = dt;

                        dgImiesdeOrden.Columns[0].Width = 10;
                        dgImiesdeOrden.Columns[1].Width = 50;
                        dgImiesdeOrden.Columns[2].Width = 200;

                        dgImiesdeOrden.Visible = true;
                        if (tipoCon == -1)
                        {
                            gbPaginacionImies.Visible = true;
                            Int32 totalRegistros = Convert.ToInt32(datTipoPlan.Rows[0][6]);
                            fnCalcularPaginacionImeis(totalRegistros, filas, totalResultados);
                        }
                        else
                        {
                            btnTotalFilasImies.Text = Convert.ToString(totalResultados);
                        }
                    }
                    

                    
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("NO SE ENCONTRÓ NINGÚN IMEI INGRESADO A ESTA ORDEN DE COMPRA");
                    dgImiesdeOrden.DataSource = dt;
                    gbPaginacionImies.Visible = false;
                   
                }
                tabControl1.SelectedIndex = 1;
                return true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {

            String busqueda = txtBuscar.Text.Trim().ToString();

            fnBuscarTabla(busqueda, 0, -1);
        }

        private void cboFilasImeis_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarTablaImies(dgOrdenIngreso, Convert.ToInt32(cboFilasImeis.Text), -2);
        }

        private void txtCodigoOrdenCompra_TextChanged(object sender, EventArgs e)
        {
            //fnBuscarTablaImies(dgImiesdeOrden,Convert.ToInt32(cboFilasImeis.Text),-2);
        }
    }
    
}
