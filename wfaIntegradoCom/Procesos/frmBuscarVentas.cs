using CapaEntidad;
using CapaNegocio;
using CapaUtil;
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
using wfaIntegradoCom.Consultas;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Mantenedores;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmBuscarVentas : Form
    {

        public frmBuscarVentas()
        {
            InitializeComponent();
        }

        private static List<TipoTarifa> lstTipoTarifa = new List<TipoTarifa>();
        private static Ciclo clsCiclo = new Ciclo();
        private static List<TipoPlan> lstTP = new List<TipoPlan>();
        private static List<Plan> lstP = new List<Plan>();
        private static Plan clsPlan = new Plan();
        static List<validacion> lstValidacionPlan;
        static Int32 lnTipoCon = 0;
        static DateTime dtpFechaInicialB = Variables.gdFechaSis;
        //string TipoVenta clsTVenta = new TipoVenta();
        public static String cCodigoVenta = "";
        static List<TipoVenta> lstTVenta = new List<TipoVenta>();
        Boolean estadoFecha;
        static Int32 tabInicio;
        Boolean cargoFrom = false;
        private void frmBuscarVentas_Load(object sender, EventArgs e)
        {
            try
            {

                //fnListarDatosVenta(dgDatosVenta, 0, 0, -1);
                fnLlenarTipoTarifa(0, cbTipoVenta, true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboEstadoContrato, "TICN", true);

                cbTipoVenta.SelectedValue = 1;
                fnListarTipoPlan(0, cboTipoPlan, 0);
                fnListarPlan(0, cboPlanV, false, 0);
                fnlistarUsuario(cboUsuario, 1, true);
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));

                cboUsuario.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboEstadoContrato.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboTipoPlan.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboPlanV.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cbTipoVenta.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                cargoFrom = true;
            }
            
        }
        void cboCronograma_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private Boolean fnListarTipoPlan(Int32 idTipoPlan, SiticoneComboBox cbo, Int32 tipBusqueda)
        {
            BLTipoPlan objTipPlan = new BLTipoPlan();
            clsUtil objUtil = new clsUtil();
            List<TipoPlan> lstTipoPlan;

            try
            {
                lstTipoPlan = objTipPlan.blDevolverTipoPlan(idTipoPlan, tipBusqueda);
                cbo.ValueMember = "idTipoPlan";
                cbo.DisplayMember = "nombreTipoPlan";
                cbo.DataSource = lstTipoPlan;

                lstTP = lstTipoPlan;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }
        }
        private Boolean fnListarPlan(Int32 idTipoPlan, SiticoneComboBox cbo, Boolean tipBusqueda, Int16 tipoCon)
        {
            BLPlan objPlan = new BLPlan();
            clsUtil objUtil = new clsUtil();
            List<Plan> lstPlan;
            try
            {
                lstPlan = objPlan.blDevolverPlanDeTipoPlan(idTipoPlan, tipBusqueda, tipoCon);
                cbo.ValueMember = "idPlan";
                cbo.DisplayMember = "nombrePlan";
                cbo.DataSource = lstPlan;
                lstP = lstPlan;
                return true;
            }
            catch(Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }
        }
        private Boolean fnlistarUsuario(SiticoneComboBox cbo, Int32 tipoCon, Boolean buscar)
        {
            BLUsuario objUsuario = new BLUsuario();
            clsUtil objUtil = new clsUtil();
            List<Usuario> lstClase = new List<Usuario>();
            try
            {
                lstClase = objUsuario.blDevolverSoloUsuario(tipoCon, buscar);
                cbo.ValueMember = "cUser";
                //cbo.ValueMember = "cUser";
                cbo.DataSource = lstClase; 
                return true;
            }
            catch(Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarClaseVehiculo", ex.Message);
                return false;
            }

        }
        //private Boolean fnValidaFechas(Label lbl, PictureBox pb)
        //{
        //    String msg = "";
        //    Boolean bEstado = false;
        //    PictureBox pbx = null;
        //    Image img = null;
        //    DateTime dtFechaSistema = Variables.gdFechaSis.AddDays(-2);
        //    if (Convert.ToDateTime(dtpFechaFinalBus.Value.ToString("dd/MM/yyyy")) >= Convert.ToDateTime(dtFechaSistema.ToString("dd/MM/yyyy")) && Convert.ToDateTime(dtpFechaFinalBus.Value.ToString("dd/MM/yyyy")) <= Convert.ToDateTime(Variables.gdFechaSis.ToString("dd/MM/yyyy")))
        //    {
        //        bEstado = true;
        //        msg = "";
        //        img = Properties.Resources.ok;
        //    }
        //    else
        //    {
        //        if (Convert.ToDateTime(dtpFechaFinalBus.Value.ToString("dd/MM/yyyy")) > Convert.ToDateTime(Variables.gdFechaSis.ToString("dd/MM/yyyy")))
        //        {
        //            bEstado = false;
        //            msg = "La fecha de pago no puede ser mayor a la fecha actual";
        //            img = Properties.Resources.error;

        //        }
        //        else if (Convert.ToDateTime(dtpFechaFinalBus.Value.ToString("dd/MM/yyyy")) < Convert.ToDateTime(dtFechaSistema.ToString("dd/MM/yyyy")))
        //        {
        //            //bEstado = false;
        //            //msg = "La fecha de pago no puede ser menor a: " + dtFechaSistema.ToString("dd/MM/yyyy");
        //            //img = Properties.Resources.error;

        //            bEstado = true;
        //            msg = "";
        //            img = Properties.Resources.ok;
        //        }
        //    }
        //    lbl.Text = msg;
        //    pb.Image = img;
        //    return bEstado;
        //}
        private void dtpFechaInicialBus_ValueChanged(object sender, EventArgs e)
        {
        }
        private void txtBuscarVentas_TextChanged(object sender, EventArgs e)
        {
        }
        public  Boolean fnListarDatosVenta(DataGridView dgv, Int32 numPagina, Int32 tipoLLamada, Int32 tipoCon)
        {

            BLClienteVenta objClienteV = new BLClienteVenta();
            clsUtil objUtil = new clsUtil();
            DataTable datClienteV = new DataTable();

           
            String cEstadoInstal = "0";
            Int32 cEstadoTipoVenta = Convert.ToInt32(cbTipoVenta.SelectedValue);
            Boolean habilitarFechas = chkHabilitarFechasBus.Checked ? true : false;
            Boolean habilitarRenovaciones = chkHabilitarFechasBus.Checked ? true : false;
            DateTime fechaInicial = dtpFechaInicialBus.Value;
            DateTime fechaFinal = dtpFechaFinalBus.Value;
            String estadoTipoContrato = cboEstadoContrato.SelectedValue.ToString();
            String estadoTipoPlan = cboTipoPlan.SelectedValue.ToString();
            String estadoPlan = cboPlanV.SelectedValue.ToString();
            String estadoUsuario = cboUsuario.SelectedValue.ToString();
            String placaVehiculo = txtBuscarVentas.Text.Trim();
            Int32 HorasIni = 0;
            Int32 HorasFin = 0;
            Int32 HorasRestarIni = 0;
            Int32 HorasRestarFin = 0;
            String TipoFiltro = "";
            HorasIni = Convert.ToInt32(fechaInicial.ToString("HH"));
            HorasRestarIni = 24 - HorasIni;
            fechaInicial = fechaInicial.AddHours(-HorasIni);
            HorasFin = Convert.ToInt32(fechaFinal.ToString("HH"));
            HorasRestarFin = 24 - HorasFin;
            fechaFinal = Convert.ToDateTime(fechaFinal.ToString("dd") + "/" + (fechaFinal.Month) + "/" + fechaFinal.Year + " 23:59:59");
           
            Int32 filas = 10;
            Double TotalGanacia = 0;
            Boolean estadoReturn = false;

            try
            {
                datClienteV = objClienteV.BlBuscarClienteV(habilitarFechas, fechaInicial, fechaFinal, placaVehiculo, cEstadoInstal, numPagina, tipoLLamada, tipoCon, cEstadoTipoVenta, estadoTipoContrato, habilitarRenovaciones, TipoFiltro,estadoTipoPlan,estadoPlan, estadoUsuario);
                Int32 totalResultados = datClienteV.Rows.Count;
                if (tipoCon == -4)
                {
                    if (totalResultados > 0)
                    {
                        for (int i = 0; i <= totalResultados - 1; i++)
                        {


                            TotalGanacia += Convert.ToDouble(datClienteV.Rows[i][1]);

                        }
                        lblTotaGanancia.Text = $"{Convert.ToString(datClienteV.Rows[0][0])} {String.Format("{0:#,##0.00}", TotalGanacia)}";
                    }
                    else
                    {
                        lblTotaGanancia.Text = $"{"S/"} {String.Format("{0:#,##0.00}", totalResultados)}";
                    }     
                    estadoReturn = true;
                }
                else
                {
                    if (totalResultados > 0)
                    {
                        if (dgv.Rows.Count > 0)
                        {
                            dgv.Rows.Clear();
                        }
                        Int32 y;
                        Int32 contador = 0;
                        if (tipoCon == -1)
                        {
                            y = 0;
                        }
                        else
                        {
                            tabInicio = (numPagina - 1) * filas;
                            y = tabInicio;
                        }
                        foreach (DataRow dr in datClienteV.Rows)
                        {
                            y += 1;
                            Int32 restaAnio = 0;
                            Int32 restaMeses = 0;
                            Int32 faltaDias = 0;
                            String strEstado = "";

                            String desVehiculos = Convert.ToString(dr["descripcionVehiculo"]);
                            DateTime fecha = Convert.ToDateTime(Convert.ToDateTime(dr["FechaRegistro"]).ToString("dd/MM/yyyy"));
                            DateTime fechaPago = Convert.ToDateTime(Convert.ToDateTime(dr["fechaPago"]).ToString("dd/MM/yyyy"));
                            DateTime fechaFinalContrato = Convert.ToDateTime(Convert.ToDateTime(dr["periodoFinal"]).ToString("dd/MM/yyyy"));

                            //TimeSpan tiket = Variables.gdFechaSis - Variables.gdFechaSis.AddDays(-1);

                            ////Int32 cantDiasMesPago = DateTime.DaysInMonth(dtFechaDePago.Year, dtFechaDePago.Month);
                            //if (Variables.gdFechaSis > fechaFinalContrato)
                            //{
                            //    tiket = Variables.gdFechaSis - fechaFinalContrato;
                            //}
                            //else
                            //{
                            //    tiket = fechaFinalContrato - Variables.gdFechaSis;
                            //}
                            //DateTime totalTime = new DateTime(tiket.Ticks);
                            //restaAnio = totalTime.Year - 1;
                            //restaMeses = totalTime.Month - 1;
                            //faltaDias = Convert.ToInt32(totalTime.Day);
                            //if (Convert.ToString(dr["EstadoVenta"]) == "EXPIRADO" || Convert.ToString(dr["EstadoVenta"]) == "ANULADA")
                            //{
                            //    strEstado = "❌ ANULADA";
                            //}
                            //else
                            //{
                            //    //strEstado = fnMostrarEstadoRenovacion(Variables.gdFechaSis, fechaFinalContrato, restaAnio, restaMeses, faltaDias);
                            //}
                            dgv.Rows.Add(

                                dr["idCliente"],                               
                                y,
                                 dr["codigoVenta"],
                                fechaPago.ToString("dd/MM/yyyy"),
                                fecha.ToString("dd/MM/yyyy"),
                                fechaFinalContrato.ToString("dd/MM/yyyy"),
                                desVehiculos,
                                FunGeneral.FormatearCadenaTitleCase(dr["descripcionCliente"].ToString()),
                                FunGeneral.FormatearCadenaTitleCase(dr["plan"].ToString()),
                                FunGeneral.FormatearCadenaTitleCase(dr["nombre"].ToString()),
                                FunGeneral.FormatearCadenaTitleCase(dr["EstadoVenta"].ToString()),
                                FunGeneral.FormatearCadenaTitleCase(dr["cNomTab"].ToString()),
                                FunGeneral.FormatearCadenaTitleCase(dr["cUser"].ToString()),
                                $"{dr["cSimbolo"]} {string.Format("{0:0.00}", dr["TotalPago"])}",
                                strEstado,
                                "",
                                dr["idTipoTarifa"],
                                dr["idContrato"]
                            );

                            if (Convert.ToString(dr["EstadoVenta"]) == "EXPIRADO" || Convert.ToString(dr["EstadoVenta"]) == "ANULADA")
                            {
                                dgv.Rows[contador].DefaultCellStyle.ForeColor = Color.Red;
                            }
                            else if (Convert.ToString(dr["cCodTab"]) == "ESPP0002")
                            {
                                dgv.Rows[contador].DefaultCellStyle.ForeColor = Color.DarkOrange;
                            }
                            contador += 1;
                        }
                        
                        dgv.Columns[0].Visible = false;
                        dgv.Columns[2].Visible = false;

                        dgv.Columns[1].Width = 20;
                        dgv.Columns[3].Width = 45;
                        dgv.Columns[4].Width = 50;
                        dgv.Columns[5].Width = 45;
                        dgv.Columns[6].Width = 75;
                        dgv.Columns[7].Width = 110;
                        dgv.Columns[8].Width = 45;
                        dgv.Columns[9].Width = 45;
                        dgv.Columns[10].Width = 50;
                        dgv.Columns[11].Width = 45;
                        dgv.Columns[12].Width = 40;
                        dgv.Columns[13].Width = 40;
                        dgv.Columns[14].Width = 100;
                        dgv.Columns[15].Width = 60;

                        //dgv.RowTemplate.Height = 100;
                        dgv.Visible = true;

                        if (tipoCon == -1)
                        {
                            gbPaginacion.Visible = true;
                            Int32 totalRegistros = Convert.ToInt32(datClienteV.Rows[0][0]);
                            FunValidaciones.fnCalcularPaginacion(
                                totalRegistros,
                                filas,
                                totalResultados,
                                cboPaginaV,
                                btnTotalPag,
                                btnNumFilas,
                                btnTotalReg
                            );
                        }
                        else
                        {
                            btnNumFilas.Text = Convert.ToString(totalResultados);
                        }

                        estadoReturn = true;
                    }
                    else
                    {

                        MessageBox.Show("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgv.Rows.Clear();
                        estadoReturn = false;
                    }
                }
                return estadoReturn;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
               return false;
            }
        }
        private void txtBuscarVentas_KeyPress(object sender, KeyPressEventArgs e)        

        {
            lnTipoCon = 0;
            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnListarDatosVenta(dgDatosVenta, 0, 0, -1);
            }
        }
      private void cboTipoVetaBusq_SelectedIndexChanged(object sender, EventArgs e)
      {
      }
     private void siticoneGroupBox1_Click(object sender, EventArgs e)
     {    
     }
      private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
         int fila = Convert.ToInt32(cboPaginaV.Text);
            if (cargoFrom == true)
            {
                fnListarDatosVenta (dgDatosVenta, fila, 0, -2);

            }
      }
      private void chkHabilitarFechasBus_CheckedChanged(object sender, EventArgs e)
      {
            if (chkHabilitarFechasBus.Checked == true)
            {
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
                gbBuscarListaVentas.Enabled = true;
            }
            else
            {
                gbBuscarListaVentas.Enabled = false;
            }
      }
      private void btnBuscarMonto_CheckedChanged(object sender, EventArgs e)
      {

            if (btnBuscarMonto.Checked == true)
            {
                fnListarDatosVenta(dgDatosVenta, 0, 0, -4);
            }

       }
      private void pictureBox4_Click(object sender, EventArgs e)
       {
            {
                fnListarDatosVenta(dgDatosVenta, 0, 0, -1);
                if (btnBuscarMonto.Checked == true)
                {
                    fnListarDatosVenta(dgDatosVenta, 0, 0, -4);
                }
            }
      }
       private void pictureBox1_Click(object sender, EventArgs e)
       {
            fnListarDatosVenta(dgDatosVenta, 0, 0, -4);
       }

        private void tlsDocumentoVenta_Click(object sender, EventArgs e)
        {
            cCodigoVenta = Convert.ToString(dgDatosVenta.CurrentRow.Cells[2].Value);
            Int32 idTipoTarifa = Convert.ToInt32(dgDatosVenta.CurrentRow.Cells[16].Value);
            Int32 idContrato = Convert.ToInt32(dgDatosVenta.CurrentRow.Cells[17].Value);
            ////Mantenedores.frmRegistrarVenta frmrv = new Mantenedores.frmRegistrarVenta();
            fnBuscarDocumentoVent(cCodigoVenta, 1, idTipoTarifa, idContrato);
        }
        private void ActaInstalacion_Click(object sender, EventArgs e)
        {
            String CodVenta = Convert.ToString(dgDatosVenta.CurrentRow.Cells[2].Value);
            Int32 idTipoVenta = Convert.ToInt32(dgDatosVenta.CurrentRow.Cells[16].Value);
            Int32 idtipoPlan = Convert.ToInt32(dgDatosVenta.CurrentRow.Cells[18].Value);
            Int32 idContrato = Convert.ToInt32(dgDatosVenta.CurrentRow.Cells[17].Value);
            String RowVehiculos = Convert.ToString(dgDatosVenta.CurrentRow.Cells[6].Value);
            String[] ArrayVehiculos = RowVehiculos.Split(';');
            List<Vehiculo> lstVehiculo = new List<Vehiculo>();

            frmTipoImpresion frmTImpre = new frmTipoImpresion();
            xmlInstalacion xmlInst = new xmlInstalacion();
            frmRptActa frmVPActa = new frmRptActa();
            if (ArrayVehiculos.Length - 1 == 1)
            {
                lstVehiculo = fnDebolverDatosVehi(RowVehiculos, ArrayVehiculos);
                Mantenedores.frmRegistrarVenta frmv = new Mantenedores.frmRegistrarVenta();
                xmlInst = frmv.fnBuscarActaInstalacion(CodVenta, lstVehiculo[0].vPlaca, idTipoVenta);
                if (xmlInst.clsInstalacion != null)
                {
                    frmVPActa.Inicio(xmlInst.ListaCliente, xmlInst.ListaVehiculo, xmlInst.ListaEquipo, xmlInst.ListaPlan, xmlInst.ListaAccesorio, xmlInst.ListaServicio, xmlInst.observaciones, xmlInst.clsInstalacion, 1);
                }
                else
                {
                    MessageBox.Show("Por favor indique que se registre la instalacion para poder imprimir el acta.", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {              
                frmTImpre.inicio(Convert.ToInt32(cbTipoVenta.SelectedValue), CodVenta, fnDebolverDatosVehi(RowVehiculos, ArrayVehiculos), "A", idContrato);
            }

        }
        private List<Vehiculo>  fnDebolverDatosVehi (String RowVehiculos, String[] ArrayVehiculos)
        {
            Int32 contad = ArrayVehiculos.Length - 1;
            string placa = "";
            string descripVehiculo="";
            String[] ArrayDatos = RowVehiculos.Split('(');
            Int32 contadorDtos = ArrayDatos[0].Length;
            List<Vehiculo> lstVehi = new List<Vehiculo>();
            for(Int32 i =0; i > contad ;  i++)
            {
                descripVehiculo = string.Format("{1}{0}", Environment.NewLine, ArrayVehiculos[i]);
                placa = (i == 0) ? ArrayVehiculos[i].Substring(6, contadorDtos - 6) : ArrayVehiculos[i].Substring(7, contadorDtos - 6);


                lstVehi.Add(new Vehiculo
                {
                    vPlaca = placa,
                    vModeloV = descripVehiculo

                });
            }
             return lstVehi ;         
        }
        private void fnBuscarDocumentoVent(String cCodVenta, Int32 tipCon, Int32 idTipoTarifa, Int32 idContrato)
        {
            BLOtrasVenta objTipoVenta = new BLOtrasVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtResp = new DataTable();
            List<TipoVenta> lsTipoVenta = new List<TipoVenta>();
            Int32 filas = 20;
            List<xmlDocumentoVentaGeneral> xmlDocumentoVenta = new List<xmlDocumentoVentaGeneral>();
            xmlDocumentoVentaGeneral xmlDocVenta = new xmlDocumentoVentaGeneral();

            try
            {
                xmlDocVenta = objTipoVenta.blBuscarDocumentoVentaGeneral(cCodVenta, tipCon, idTipoTarifa, idContrato);
                xmlDocVenta.xmlDocumentoVenta[0].cDireccion = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cDireccion);
                xmlDocVenta.xmlDocumentoVenta[0].cCliente = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cCliente);
                xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago);
                xmlDocumentoVenta.Add(xmlDocVenta);
                Consultas.frmVPVenta abrirFrmVPOtrasVentas = new Consultas.frmVPVenta();
                abrirFrmVPOtrasVentas.Inicio(xmlDocumentoVenta[0].xmlDocumentoVenta, xmlDocumentoVenta[0].xmlDetalleVentas, 1);

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnListarProveedorActivo", ex.Message);

            }
            finally
            {
                objUtil = null;
                objTipoVenta = null;
                lsTipoVenta = null;
            }
        }

        private void dgDatosVenta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgDatosVenta.Columns[e.ColumnIndex].Name == "lvBtnImprimir" && e.RowIndex >= 0)
            {
               
                
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    DataGridViewButtonCell celBoton = this.dgDatosVenta.Rows[e.RowIndex].Cells["lvBtnImprimir"] as DataGridViewButtonCell;
                    Icon icoAtomico = new Icon(Application.StartupPath + @"\Impresora.ico");
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                    this.dgDatosVenta.Rows[e.RowIndex].Height = 45;
                    this.dgDatosVenta.Columns[e.ColumnIndex].Width = 45;


                    e.Handled = true;

                

            }
        }
        private void dgDatosVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgDatosVenta.Columns["lvBtnImprimir"].Index && e.RowIndex >= 0)
            {
                Int32 idTipoVenta = Convert.ToInt32(dgDatosVenta.CurrentRow.Cells[16].Value);
                if (idTipoVenta == 2)
                {
                    cmsImpresion.Items[2].Visible = false;

                }
                else
                {
                    cmsImpresion.Items[2].Visible = true;
                }
                var mousePosition = dgDatosVenta.PointToClient(Cursor.Position);
                cmsImpresion.Show(dgDatosVenta, 940, mousePosition.Y);
            }
        }
        private void dgDatosVenta_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
                    if (!clickedRow.Selected)
                    {
                        dgDatosVenta.CurrentCell = clickedRow.Cells[e.ColumnIndex];
                    }
                }
            }
        }

        private void dgDatosVenta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgview = sender as DataGridView;

            String nombreCabecera = dgview.Columns[e.ColumnIndex].Name;

            if (nombreCabecera == "txtEstado")
            {

                if (e.Value.ToString().Contains("✔"))
                {
                    e.CellStyle.ForeColor = Variables.ColorSuccess;
                }
                else if (e.Value.ToString().Contains("🕐"))
                {
                    e.CellStyle.ForeColor = Color.YellowGreen;
                }
                else if (e.Value.ToString().Contains("👁"))
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }
                else if (e.Value.ToString().Contains("❗"))
                {
                    e.CellStyle.ForeColor = Color.OrangeRed;

                }
                else if (e.Value.ToString().Contains("🚫"))
                {
                    e.CellStyle.ForeColor = Color.Purple;
                }
                else if (e.Value.ToString().Contains("❌"))
                {
                    e.CellStyle.ForeColor = Color.Red;

                }
            }
        }
        private Boolean fnLlenarTipoTarifa(Int32 idTipoPlan, SiticoneComboBox cbo, Boolean busqueda) 
        {

            BLTipoTarifa objTipTarifa = new BLTipoTarifa();
            clsUtil objUtil = new clsUtil();
            List<TipoTarifa> lstTipTarifa = new List<TipoTarifa>();

            try
            {
                lstTipTarifa = objTipTarifa.blDevolverTipoTarifa(idTipoPlan, busqueda);

                cbo.ValueMember = "IdTipoTarifa";
                cbo.DisplayMember = "Nombre";
                cbo.DataSource = lstTipTarifa;
                if (busqueda != true)
                {
                    lstTipoTarifa = lstTipTarifa;
                }
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        private void cboTipoPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 idTipoPlan = Convert.ToInt32(cboTipoPlan.SelectedValue ?? 0);
            Int32 idTipoventa = Convert.ToInt32(cboPlanV.SelectedValue);

            //var result = FunValidaciones.fnValidarCombobox(lstValidacionPlan[0].combobox, erTipoPlan, imgTipoPlanP);
            //lstValidacionPlan[0].estado = result.Item1;
            //lstValidacionPlan[0].mensaje = result.Item2;
           
            if (cboTipoPlan.SelectedValue.ToString() == "0" || cboTipoPlan.SelectedValue == null)
            {
                cboPlanV.Enabled = false;
            }
            else
            {
                idTipoPlan = Convert.ToInt32(cboTipoPlan.SelectedValue.ToString());
                cboPlanV.Enabled = true;
            }
            fnListarPlan(0, cboPlanV, false, 0);
    
        }

        private void cboPlanV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cargoFrom)
            //{

            //    if ((Convert.ToInt32(cboPlanV.SelectedValue) != 0))
            //    {

            //        Int32 idPlan = FunValidaciones.fnObtenerIdDeComboBox(cboPlanV);

            //        clsPlan = Plan.fnObtenerPlanSeleccionado(idPlan, lstP);
            //        var result = FunValidaciones.fnValidarCombobox(lstValidacionPlan[1].combobox, erPlan, imgPlan);
            //        lstValidacionPlan[1].estado = result.Item1;
            //        lstValidacionPlan[1].mensaje = result.Item2;
            //        if (idPlan == 0)
            //        {

            //        }
            //    }
            //}

        }
    }
    
}

      




            






