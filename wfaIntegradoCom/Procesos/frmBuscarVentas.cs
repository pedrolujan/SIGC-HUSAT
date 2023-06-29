using CapaDato;
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
using wfaIntegradoCom.Sunat;

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
        private static List<Cargo> lstTablaCod = new List<Cargo>();
        private static Cargo Cargo = new Cargo();
        static List<Cliente> lstClientes = new List<Cliente>();
        static List<validacion> lstValidacionPlan;
        private static List<TipoDocumento> lstTD = new List<TipoDocumento>();
        static Int16 lnTipoCon;
        static DateTime dtpFechaInicialB = Variables.gdFechaSis;
        //string TipoVenta clsTVenta = new TipoVenta();
        public static String cCodigoVenta = ""; 
        static List<TipoVenta> lstTVenta = new List<TipoVenta>();
        Boolean estadoFecha;
        static Int32 tabInicio;
        Boolean cargoFrom = false;
        Boolean dEstadoBusquedaPaginacion = false;
        private void frmBuscarVentas_Load(object sender, EventArgs e)
        {
            try
            {
              
                lnTipoCon = 0;
                cargoFrom = false;
              
                fnLlenarTipoTarifa(0, cbTipoVenta, true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboEstadoContrato, "TICN", true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboEstado, "ESVG", true);
               
                cboPlanV.SelectedValue = 0;
              
                Mantenedores.frmRegistrarVenta.fnLlenarComprobante(cboTipoDocumento, "DOVE", 2, -1);
               
                fnlistarUsuario(cboUsuario,2, true);

                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
                if (Variables.gsCargoUsuario == "PETR0001" || Variables.gsCargoUsuario == "PETR0005" || Variables.gsCargoUsuario == "PETR0007")
                {
                    pnMontoGanania.Visible = true;
                }
                else
                {
                    pnMontoGanania.Visible = false;
                }

                cboUsuario.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboEstadoContrato.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboEstado.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboTipoPlan.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboPlanV.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cbTipoVenta.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboTipoDocumento.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);


                fnValidarPlan();
                fnLlenarTipoTarifa(0, cbTipoVenta, true);
              
               cbTipoVenta.SelectedValue = 1;
                fnListarTipoPlan(0, cboTipoPlan, 0);
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
        private Boolean fnListarPlanDeTipoPlan(Int32 idTipoPlan, SiticoneComboBox cbo, Boolean tipBusqueda, Int16 tipoCon)
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
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        public Boolean fnlistarUsuario(SiticoneComboBox cbo, Int32 tipoCon, Boolean buscar)
        {
            BLUsuario objUsuario = new BLUsuario();
            clsUtil objUtil = new clsUtil();
            List<Usuario> lstClase = new List<Usuario>();
            try
            {
                lstClase = objUsuario.blDevolverSoloUsuario(tipoCon, buscar);
                cbo.ValueMember = "idUsuario";
                cbo.DisplayMember = "cUser";
                cbo.DataSource = lstClase;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarClaseVehiculo", ex.Message);
                return false;
            }

        }
       
        private void dtpFechaInicialBus_ValueChanged(object sender, EventArgs e)
        {
        }
        private void txtBuscarVentas_
            (object sender, EventArgs e)
        {
        }
        public Boolean fnListarDatosVenta(DataGridView dgv, Int32 numPagina, Int32 tipoLLamada, Int32 tipoCon)      
       
        {
            BLClienteVenta objVentaGeneral = new BLClienteVenta();
            clsUtil objUtil = new clsUtil();
            DataTable datVenta = new DataTable();
            String placaVehiculo = txtBuscarVentas.Text.Trim();
            
           
           String cEstadoInstal = "0";
            Int32 cEstadoTipoVenta = Convert.ToInt32(cbTipoVenta.SelectedValue);
            Boolean habilitarFechas = chkHabilitarFechasBus.Checked ? true : false;
            Boolean habilitarRenovaciones = chkHabilitarFechasBus.Checked ? true : false;
            DateTime fechaInicial = dtpFechaInicialBus.Value;
            DateTime fechaFinal = dtpFechaFinalBus.Value;
            String estadoTipoContrato = cboEstadoContrato.SelectedValue.ToString();
            String estadoContrato = cboEstado.SelectedValue.ToString();
            Int32 estadoTipoPlan = Convert.ToInt32(cboTipoPlan.SelectedValue);
            Int32 estadoPlan = Convert.ToInt32(cboPlanV.SelectedValue);
            Int32 estadoUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
            String Docventapago = cboTipoDocumento.SelectedValue.ToString();
            Int32 HorasIni = 0;
            Int32 HorasFin = 0;
            Int32 HorasRestarIni = 0;
            Int32 HorasRestarFin = 0;
            String TipoFiltro = "";
            Int32 TipoBusquedaFecha=rdbFVenta.Checked==true? 1:rdbFInicioContrato.Checked==true?2:0 ;
            HorasIni = Convert.ToInt32(fechaInicial.ToString("HH"));
            HorasRestarIni = 24 - HorasIni;
            fechaInicial = fechaInicial.AddHours(-HorasIni);
            HorasFin = Convert.ToInt32(fechaFinal.ToString("HH"));
            HorasRestarFin = 24 - HorasFin;
            fechaFinal = Convert.ToDateTime(fechaFinal.ToString("dd") + "/" + (fechaFinal.Month) + "/" + fechaFinal.Year + " 23:59:59");
            Int32 totalResultados = 0;
           
            Int32 filas = 10;
            Double TotalGanacia = 0;
            Boolean estadoReturn = false;
            
            try
            {
                datVenta = objVentaGeneral.BlBuscarClienteV(habilitarFechas, FunGeneral.GetFechaHoraFormato(fechaInicial,3), FunGeneral.GetFechaHoraFormato(fechaFinal,3), placaVehiculo, cEstadoInstal, numPagina,
                    tipoLLamada, tipoCon, cEstadoTipoVenta, estadoTipoContrato, habilitarRenovaciones, TipoFiltro, estadoTipoPlan, 
                    estadoPlan, estadoUsuario, estadoContrato , TipoBusquedaFecha, Docventapago);

                totalResultados = datVenta.Rows.Count;
                if (tipoCon == -4)
                {
                    if (totalResultados > 0)
                    {
                        for (int i = 0; i <= totalResultados - 1; i++)
                        {


                            TotalGanacia += Convert.ToDouble(datVenta.Rows[i][1]);

                        }
                        lblTotaGanancia.Text = $"{Convert.ToString(datVenta.Rows[0][0])} {String.Format("{0:#,##0.00}", TotalGanacia)}";
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


                        if (numPagina == 0)
                        {
                            y = 0;
                        }
                        else
                        {
                            tabInicio = (numPagina - 1) * filas;
                            y = tabInicio;
                        }

                        foreach (DataRow dr in datVenta.Rows)
                        {
                            y += 1;
                            Int32 restaAnio = 0;
                            Int32 restaMeses = 0;
                            Int32 faltaDias = 0;
                            String strEstado = "";
                            String desVehiculos = Convert.ToString(dr["descripcionVehiculo"]);
                            DateTime fecha = Convert.ToDateTime(Convert.ToDateTime(dr["FechaRegistro"]).ToString("dd/MM/yyyy"));
                            DateTime fechaPago = Convert.ToDateTime(Convert.ToDateTime(dr["fechaPago"]).ToString("dd/MM/yyyy"));
                            DateTime fechaInicioContrato = Convert.ToDateTime(Convert.ToDateTime(dr["periodoInicio"]).ToString("dd/MM/yyyy"));
                            DateTime fechaFinalContrato = Convert.ToDateTime(Convert.ToDateTime(dr["periodoFinal"]).ToString("dd/MM/yyyy"));
                          
                            TimeSpan tiket = Variables.gdFechaSis - Variables.gdFechaSis.AddDays(-1);

                            if (Variables.gdFechaSis > fechaFinalContrato)
                            {
                                tiket = Variables.gdFechaSis - fechaFinalContrato;
                            }
                            else
                            {
                                tiket = fechaFinalContrato - Variables.gdFechaSis;
                            }
                            DateTime totalTime = new DateTime(tiket.Ticks);
                            restaAnio = totalTime.Year - 1;
                            restaMeses = totalTime.Month - 1;
                            faltaDias = Convert.ToInt32(totalTime.Day);
                            if (Convert.ToString(dr["EstadoVenta"]) == "EXPIRADO" || Convert.ToString(dr["EstadoVenta"]) == "ANULADA")
                            {
                                strEstado = "❌ ANULADA";
                            }

                            dgv.Rows.Add(
                                dr["idCliente"],
                                y,
                                dr["codigoVenta"],
                                fechaPago.ToString("dd/MM/yyyy"),
                                fechaInicioContrato.ToString("dd/MM/yyyy"),
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

                                FunGeneral.FormatearCadenaTitleCase(dr["TipoDocumentoVenta"].ToString()),
                                "",
                                dr["idTipoTarifa"],
                                dr["idContrato"]
                            );

                            if (Convert.ToString(dr["EstadoVenta"]) == "EXPIRADO" || Convert.ToString(dr["EstadoVenta"]) == "ANULADA" )
                            {
                                dgv.Rows[contador].DefaultCellStyle.ForeColor = Color.Red;
                            }
                            else
                            if (Convert.ToString(dr["cCodTab"]) == "ESPP0002")
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
                        dgv.Columns[14].Width = 40;
                        dgv.Columns[15].Width = 60;

                        dgv.Visible = true;

                        if (numPagina == 0)
                        {
                            gbPaginacion.Visible = true;
                            Int32 totalRegistros = Convert.ToInt32(datVenta.Rows[0][0]);
                            FunValidaciones.fnCalcularPaginacion(totalRegistros, filas, totalResultados, cboPaginaV, btnTotalP, btnNumF, btnTotalR);

                            dEstadoBusquedaPaginacion = false;
                        }
                        else
                        {
                            btnNumF.Text = Convert.ToString(totalResultados);

                        }

                        estadoReturn = true;
                    }
                    else
                    {

                        MessageBox.Show("NO HAY DATOS QUE COINCIDAN", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                dEstadoBusquedaPaginacion = true;
                fnListarDatosVenta(dgvLVentas, 0, 0, -1);
            }
        }
        private void siticoneGroupBox1_Click(object sender, EventArgs e)
        {
        }
        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fila = Convert.ToInt32(cboPaginaV.Text);
            if (dEstadoBusquedaPaginacion==false)
            {
                fnListarDatosVenta(dgvLVentas, fila, 0, -1);

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
       
      
        private void pictureBox1_Click(object sender, EventArgs e)
        {  
                
            fnListarDatosVenta(dgvLVentas, 0, 0, -4);        
        }

        private void tlsDocumentoVenta_Click(object sender, EventArgs e)
        {
            cCodigoVenta = Convert.ToString(dgvLVentas.CurrentRow.Cells[2].Value);
            Int32 idTipoTarifa = Convert.ToInt32(dgvLVentas.CurrentRow.Cells[17].Value);
            Int32 idContrato = Convert.ToInt32(dgvLVentas.CurrentRow.Cells[18].Value);
            ////Mantenedores.frmRegistrarVenta frmrv = new Mantenedores.frmRegistrarVenta();
            fnBuscarDocumentoVent(cCodigoVenta, 1, idTipoTarifa, idContrato);
        }
        //private void ActaInstalacion_Click(object sender, EventArgs e)
        //{
        //    String CodVenta = Convert.ToString(dgvLVentas.CurrentRow.Cells[2].Value);
        //    Int32 idTipoVenta = Convert.ToInt32(dgvLVentas.CurrentRow.Cells[17].Value);
        //    Int32 idtipoPlan = Convert.ToInt32(dgvLVentas.CurrentRow.Cells[19].Value);
        //    Int32 idContrato = Convert.ToInt32(dgvLVentas.CurrentRow.Cells[18].Value);
        //    String RowVehiculos = Convert.ToString(dgvLVentas.CurrentRow.Cells[6].Value);
        //    String[] ArrayVehiculos = RowVehiculos.Split(';');
        //    List<Vehiculo> lstVehiculo = new List<Vehiculo>();

        //    frmTipoImpresion frmTImpre = new frmTipoImpresion();
        //    xmlInstalacion xmlInst = new xmlInstalacion();
        //    frmRptActa frmVPActa = new frmRptActa();
        //    if (ArrayVehiculos.Length - 1 == 1)
        //    {
        //        lstVehiculo = fnDebolverDatosVehi(RowVehiculos, ArrayVehiculos);
        //        Mantenedores.frmRegistrarVenta frmv = new Mantenedores.frmRegistrarVenta();
        //        xmlInst = frmv.fnBuscarActaInstalacion(CodVenta, lstVehiculo[0].vPlaca, idTipoVenta);
        //        if (xmlInst.clsInstalacion != null)
        //        {
        //            frmVPActa.Inicio(xmlInst.ListaCliente, xmlInst.ListaVehiculo, xmlInst.ListaEquipo, xmlInst.ListaPlan, xmlInst.ListaAccesorio, xmlInst.ListaServicio, xmlInst.observaciones, xmlInst.clsInstalacion, 1);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Por favor indique que se registre la instalacion para poder imprimir el acta.", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    else
        //    {
        //        frmTImpre.inicio(Convert.ToInt32(cbTipoVenta.SelectedValue), CodVenta, fnDebolverDatosVehi(RowVehiculos, ArrayVehiculos), "A", idContrato);
        //    }

        //}
        private List<Vehiculo> fnDebolverDatosVehi(String RowVehiculos, String[] ArrayVehiculos)
        {
            Int32 contad = ArrayVehiculos.Length - 1;
            string placa = "";
            string descripVehiculo = "";
            String[] ArrayDatos = RowVehiculos.Split('(');
            Int32 contadorDtos = ArrayDatos[0].Length;
            List<Vehiculo> lstVehi = new List<Vehiculo>();
            for (Int32 i = 0; i > contad; i++)
            {
                descripVehiculo = string.Format("{1}{0}", Environment.NewLine, ArrayVehiculos[i]);
                placa = (i == 0) ? ArrayVehiculos[i].Substring(6, contadorDtos - 6) : ArrayVehiculos[i].Substring(7, contadorDtos - 6);


                lstVehi.Add(new Vehiculo
                {
                    vPlaca = placa,
                    vModeloV = descripVehiculo

                });
            }
            return lstVehi;
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

        private void dgvLVentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvLVentas.Columns[e.ColumnIndex].Name == "lvBtnImprimir" && e.RowIndex >= 0)
            {


                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvLVentas.Rows[e.RowIndex].Cells["lvBtnImprimir"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\Impresora.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvLVentas.Rows[e.RowIndex].Height = 45;
                this.dgvLVentas.Columns[e.ColumnIndex].Width = 45;


                e.Handled = true;



            }
        }
        private void dgvLVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvLVentas.Columns["lvBtnImprimir"].Index && e.RowIndex >= 0)
            {
                Int32 idTipoVenta = Convert.ToInt32(dgvLVentas.CurrentRow.Cells[17].Value);
                if (idTipoVenta == 2)
                {
                    cmsImpresion.Items[2].Visible = false;

                }
                else
                {
                    cmsImpresion.Items[2].Visible = true;
                }
                var mousePosition = dgvLVentas.PointToClient(Cursor.Position);
                cmsImpresion.Show(dgvLVentas, 10000, mousePosition.Y);
            }
            else
            {
                //BLCliente objAcc = new BLCliente();
                //clsCliente = objAcc.blListarCliente(532, 1);
                //lstDocumentoVentaEmitir = Mantenedores.frmRegistrarVenta.fnLlenarComprobante(cboNotaCredit, "DOVE", 1, 1);
            }
            
        }
        private void dgvLVentas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
                    if (!clickedRow.Selected)
                    {
                        dgvLVentas.CurrentCell = clickedRow.Cells[e.ColumnIndex];
                    }
                }
            }
        }

        private void dgvLVentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
            DataGridView dgV = sender as DataGridView;
            


            if (dgV.Columns[e.ColumnIndex].Name == "EstadoContrato")
            {
                if (e.Value.ToString().Contains("Finalizado"))
                {
                    e.CellStyle.ForeColor = Color.OrangeRed;
                }
                else
                if (e.Value.ToString().Contains("Vigente"))
                {
                    e.CellStyle.ForeColor = Color.ForestGreen;
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
        private void fnValidarPlan()
        {
            lstValidacionPlan = new List<validacion>();
            lstValidacionPlan.Add(new validacion { estado = false, mensaje = "", combobox = cboTipoPlan });
            lstValidacionPlan.Add(new validacion { estado = false, mensaje = "", combobox = cboPlanV });

        }
        private void cboTipoPlan_SelectedIndexChanged(object sender, EventArgs e)

        {
            Int32 idTipoPlan = Convert.ToInt32(cboTipoPlan.SelectedValue ?? 0);
            Int32 idTipoventa = Convert.ToInt32(cbTipoVenta.SelectedValue);

                fnListarPlanDeTipoPlan(idTipoPlan, cboPlanV, true, 1);
        }

        private void cboPlanV_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (cargoFrom)
            {
                Int32 idPlan = FunValidaciones.fnObtenerIdDeComboBox(cboPlanV);
                clsPlan = Plan.fnObtenerPlanSeleccionado(idPlan, lstP);
            }
          

        }

        private void tlsDocumentoVenta_Click_1(object sender, EventArgs e)
        {

            cCodigoVenta = Convert.ToString(dgvLVentas.CurrentRow.Cells[2].Value);
            Int32 idTipoTarifa = Convert.ToInt32(dgvLVentas.CurrentRow.Cells[17].Value);
            Int32 idContrato = Convert.ToInt32(dgvLVentas.CurrentRow.Cells[18].Value);
            fnBuscarDocumentoVenta(cCodigoVenta, 1, idTipoTarifa, idContrato);
        }
        List<Cargo> lstDocumentoVentaEmitir = new List<Cargo>();
        Cargo clsDocumentoVentaEmitir = new Cargo();
        Cliente clsCliente = new Cliente();
        private void fnBuscarDocumentoVenta(String cCodVenta, Int32 tipCon, Int32 idTipoTarifa, Int32 idContrato)
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
                xmlDocVenta.xmlDocumentoVenta[0].cCliente = xmlDocVenta.xmlDocumentoVenta[0].cCliente;
                xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago);
                xmlDocumentoVenta.Add(xmlDocVenta);

                //if (checkBox1.Checked==true)
                //{         
                //    EmitirFactura env = new EmitirFactura();
                //    env.EmitirNotaCredito(clsCliente, xmlDocumentoVenta[0].xmlDetalleVentas, clsDocumentoVentaEmitir);

                //}

                Consultas.frmVPVenta abrirFrmVPOtrasVentas = new Consultas.frmVPVenta();

                abrirFrmVPOtrasVentas.Inicio(xmlDocumentoVenta[0].xmlDocumentoVenta, xmlDocumentoVenta[0].xmlDetalleVentas, xmlDocVenta.imgDocumento, 1);

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
       
        private void Contrato_Click(object sender, EventArgs e)
        {
            String CodVenta = Convert.ToString(dgvLVentas.CurrentRow.Cells[2].Value);

            String RowVehiculos = Convert.ToString(dgvLVentas.CurrentRow.Cells[6].Value);

            String[] ArrayVehiculos = RowVehiculos.Split(';');
            List<Vehiculo> lstVehiculo = new List<Vehiculo>();
            Int32 idContrato = Convert.ToInt32(dgvLVentas.CurrentRow.Cells[18].Value);
            frmTipoImpresion frmTImpre = new frmTipoImpresion();
            frmRptContrato frmVPContrato = new frmRptContrato();
            if (ArrayVehiculos.Length - 1 == 1)
            {
                lstVehiculo = fnDebolverDatVehiculo(RowVehiculos, ArrayVehiculos);
                Mantenedores.frmRegistrarVenta FRMregistrarV = new frmRegistrarVenta();
                var resutl = FRMregistrarV.fnBuscarContrato(CodVenta, lstVehiculo[0].vPlaca, idContrato);
                frmVPContrato.Inicio(resutl.Item1, resutl.Item2, resutl.Item3);
            }
            else
            {
                frmTImpre.inicio(0, CodVenta, fnDebolverDatVehiculo(RowVehiculos, ArrayVehiculos), "C", idContrato);

            }
        }
        private List<Vehiculo> fnDebolverDatVehiculo(String RowVehiculos, String[] ArrayVehiculos)
        {
            Int32 contador = ArrayVehiculos.Length - 1;
            String placa = "";
            String DescripVehiculo = "";
            String[] ArrayDatos = RowVehiculos.Split('(');
            Int32 contadorDtos = ArrayDatos[0].Length;

            List<Vehiculo> lstVehi = new List<Vehiculo>();

            for (Int32 i = 0; i < contador; i++)
            {
                DescripVehiculo = string.Format("{1}{0}", Environment.NewLine, ArrayVehiculos[i]);
                placa = (i == 0) ? ArrayVehiculos[i].Substring(6, contadorDtos - 6) : ArrayVehiculos[i].Substring(7, contadorDtos - 6);


                lstVehi.Add(new Vehiculo
                {
                    vPlaca = placa,
                    vModeloV = DescripVehiculo

                });
            }
            return lstVehi;
        }

        private void ActaInstalacion_Click_1(object sender, EventArgs e)
        {
            String CodVenta = Convert.ToString(dgvLVentas.CurrentRow.Cells[2].Value);
            Int32 idTipoVenta = Convert.ToInt32(dgvLVentas.CurrentRow.Cells[17].Value);
            Int32 idContrato = Convert.ToInt32(dgvLVentas.CurrentRow.Cells[18].Value);

            String RowVehiculos = Convert.ToString(dgvLVentas.CurrentRow.Cells[6].Value);
            String[] ArrayVehiculos = RowVehiculos.Split(';');
            List<Vehiculo> lstVehiculo = new List<Vehiculo>();
            frmTipoImpresion frmTImpre = new frmTipoImpresion();
            xmlInstalacion xmlInst = new xmlInstalacion();
            frmRptActa frmVPActa = new frmRptActa();
            if (ArrayVehiculos.Length - 1 == 1)
            {
                lstVehiculo = fnDebolverDatVehiculo(RowVehiculos, ArrayVehiculos);
                Mantenedores.frmRegistrarVenta FRMRegistrarV = new frmRegistrarVenta();
                xmlInst = FRMRegistrarV.fnBuscarActaInstalacion(CodVenta, lstVehiculo[0].vPlaca, idTipoVenta);
                xmlInst.ListaEquipo = xmlInst.ListaEquipo.Count==0 ? xmlInst.ListaEquipoActual : xmlInst.ListaEquipo;
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
                frmTImpre.inicio(Convert.ToInt32(cbTipoVenta.SelectedValue), CodVenta, fnDebolverDatVehiculo(RowVehiculos, ArrayVehiculos), "A", idContrato);

            }
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void gbBuscarListaVentas_Enter(object sender, EventArgs e)
        {

        }

       
        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            fnListarDatosVenta(dgvLVentas, 0, 0, -1);
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private String fnRecortarCadena(String cadena)
        {
            String[] valores = cadena.Split(';');
            String debolver = "";
            for (Int32 i = 0; i < valores.Length - 1; i++)
            {
                debolver += string.Format((i + 1) + " {1}{0}", Environment.NewLine, valores[i]);
            }
            return debolver;
        }
        private void dgvLVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmPrevisualizar frmPrev = new FrmPrevisualizar();
            string dato = "";

            if (e.ColumnIndex == dgvLVentas.Columns["Vehiculos_lv"].Index && e.RowIndex >= 0)
            {
                dato = fnRecortarCadena(Convert.ToString(dgvLVentas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                frmPrev.inicio(2, dato);
            }
            if (e.ColumnIndex == dgvLVentas.Columns["Ciente_Rs_lv"].Index && e.RowIndex >= 0)
            {
                dato = Convert.ToString(dgvLVentas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                frmPrev.inicio(2, dato);
            }
        }

    }
}

      




            






