using CapaNegocio;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Mantenedores;
using CapaUtil;
using wfaIntegradoCom.Funciones;
using System.Text.RegularExpressions;
using Siticone.UI.WinForms;
using CapaDato;
using wfaIntegradoCom.Consultas;
using wfaIntegradoCom.Sunat;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmControlPagoVenta : Form
    {
        public frmControlPagoVenta()
        {
            InitializeComponent();
        }
        Boolean EstadoCarga = false;
        static List<Cargo> lstDocumentoVentaEmitir = new List<Cargo>();
        static Cargo clsDocumentoVenta = new Cargo();
        ControlPagos claseControlPagos = new ControlPagos();
        static List<DetalleCronograma> lstDetalleCronograma = new List<DetalleCronograma>();
        static DetalleCronograma clsDetCronogramaEspecifico = new DetalleCronograma();
        static Cronograma clsCronograma = new Cronograma();
        static List<Cronograma> lstCronograma = new List<Cronograma>();
        static Tarifa clsTarifa = new Tarifa();
        static Vehiculo clsVehiculo = new Vehiculo();
        
        static Cliente clsCliente = new Cliente();
        
        BLControlPagos obControPagos = null;
        private static List<Pagos> lstPagosTrand = new List<Pagos>();
        static List<Moneda> lstMon=new List<Moneda>();
        static Moneda clsMoneda = new Moneda();
        List<DetalleVenta> lstDetalleVDocumento = new List<DetalleVenta>();
        static Ciclo clsCiclo = new Ciclo();
        static List<Ciclo> lstCiclo = new List<Ciclo>();
        private static List<TipoDocumento> lstTD = new List<TipoDocumento>();
        static List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();
        static List<DocumentoVenta> lstDocumentoVenta = new List<DocumentoVenta>();
        static DetalleVentaCabecera clsDetallecabecera = new DetalleVentaCabecera();
        static VentaGeneral clsVentaGeneral = new VentaGeneral();

        static List<DetalleCronograma> lstCronoGramasParaDocumentoVenta = new List<DetalleCronograma>();
        static Int32 CronogramaSeleccionado = 0;
        static Boolean estDescuento = false;
        static List<Ciclo> lstC = new List<Ciclo>();
        Boolean estPagoCuota = false;
        static Int32 lnTipoCon = 0;
        static Int32 tabInicio;
        static Int32 diaCicloPago = 0;
        static DateTime dtFechapagoCronogramaGeneral = Variables.gdFechaSis;
        //listas para exportar las busquedas
        static List<Vehiculo> lstVehiculoBusq = new List<Vehiculo>();
        static List<Cliente> lstClientesBusq = new List<Cliente>();
        static List<Plan> lstPlanBusq = new List<Plan>();
        static List<TipoPlan> lstTipoPlanBusq = new List<TipoPlan>();
        static List<Ciclo> lstCicloBusq = new List<Ciclo>();
        static Int32 intRespuestaSunat = 0;
        static DateTime dtFechaPagoCuota = Variables.gdFechaSis;
        Boolean estadoComprabanteP, estadoFechaPago, estadoDescuento, estadoMoneda;
        String msgComprabanteP, msgMoneda, msgDescuento;
        static String codDocumentoVemta = "";
        Boolean estadoDeBoton = false;
        static DateTime dttFechaRecibida = Variables.gdFechaSis;
        static Int32 inTipoApertura = 0;
        public void tipoApertura(DateTime dtt, Int32 tipoApertura)
        {
            dttFechaRecibida = dtt;
            inTipoApertura = tipoApertura;
            ShowDialog();
        }
        private void pbBuscar_Click(object sender, EventArgs e)
        {
            if (EstadoCarga==true)
            {

                fnBuscarCronograma(0, txtBuscar.Text.ToString(),-1,0);
            }
            
        }
        private void fnBuscarCronograma(Int32 tipoCon,String pcBuscar,Int32 TipConPaginacion, Int32 numPagina)
        {
            obControPagos = new BLControlPagos();
            DataTable dtResult = new DataTable();
            Boolean HabilitarFechas = chkHabilitarFechasBus.Checked;
            Boolean chkIncump = chkIncumplimiento.Checked;
            String dtFIni =FunGeneral.GetFechaHoraFormato(dtpFechaInicialBus.Value,5);
            String dtFFin = FunGeneral.GetFechaHoraFormato(dtpFechaFinalBus.Value,5);
            Int32 idCiclo = Convert.ToInt32(cboCicloPago.SelectedValue);
            List<Cronograma> lstCrngr = new List<Cronograma>();
            String estadoPago = Convert.ToString(cboEstadopago.SelectedValue);
            dtResult =obControPagos.blBuscarCronograma(HabilitarFechas, chkIncump, dtFIni, dtFFin, pcBuscar, tipoCon,  TipConPaginacion,  numPagina, estadoPago, idCiclo);
            if (tipoCon==1)
            {
                for (Int32 i=0;i< dtResult.Rows.Count;i++)
                {
                    lstCrngr.Add(new Cronograma
                    {
                        idCronograma = Convert.ToInt32(dtResult.Rows[i][1]),
                        idContrato = Convert.ToInt32(dtResult.Rows[i][0]),
                        periodoInicio = Convert.ToDateTime(dtResult.Rows[i][2]),
                        periodoFinal= Convert.ToDateTime(dtResult.Rows[i][3]),
                        cDescripcion = "Periodo " + Convert.ToDateTime(dtResult.Rows[i][2]).ToString("dd/MMMM/yyyy") + " A " + Convert.ToDateTime(dtResult.Rows[i][3]).ToString("dd/MMMM/yyyy")+" - Contrato: "+FunGeneral.FormatearCadenaTitleCase(Convert.ToString(dtResult.Rows[i][4])),
                        estadoCronograma= Convert.ToString(dtResult.Rows[i][5]),
                        estado= Convert.ToString(dtResult.Rows[i][6])
                    }) ;
                }

                lstCronograma = lstCrngr;
                cboCronograma.ValueMember = "idCronograma";
                cboCronograma.DisplayMember = "cDescripcion";
                cboCronograma.DataSource = lstCrngr;
            }
            else
            {

                fnCargarTabla(dgvListaVentas, dtResult,TipConPaginacion,numPagina);
            }
        }
        private void fnCargarTablaLista(Boolean Indice,Int32 fila,Int32 columna)
        {
            //label11.Text = "Ciclo\n" + diaCicloPago;
            txtCiclo.Text = "" + diaCicloPago;
            String estadoCuota = "";

            if (Indice == true)
            {
                if (lstDetalleCronograma[fila].estado == "CUOTA PAGADA")
                {
                    estadoCuota = "✅ " + lstDetalleCronograma[fila].estado;
                }else if (lstDetalleCronograma[fila].estado == "PAGO PENDIENTE")
                {
                    estadoCuota = "❗ " + lstDetalleCronograma[fila].estado;
                }
                else if (lstDetalleCronograma[fila].estado == "VENCIDO")
                {
                    estadoCuota = "🚫 " + lstDetalleCronograma[fila].estado;
                }
                else if (lstDetalleCronograma[fila].estado == "CORTE")
                {
                    estadoCuota = "❌ " + lstDetalleCronograma[fila].estado;
                }

                String strDescuento = "";
                Color colorBg = new Color();
                if (lstDetalleCronograma[fila].strTipoDescuento == "PORCENTUAL" && lstDetalleCronograma[fila].descuento != 0)
                {
                    strDescuento = "" + lstDetalleCronograma[fila].descuento;
                }
                else if (lstDetalleCronograma[fila].strTipoDescuento == "DECIMAL" && lstDetalleCronograma[fila].descuento != 0)
                {
                    strDescuento = "" + lstDetalleCronograma[fila].descuento;
                }
                DetalleCronograma dtc = lstCronoGramasParaDocumentoVenta.Find(j => j.idDetalleCronograma == lstDetalleCronograma[fila].idDetalleCronograma);
                if (dtc is DetalleCronograma)
                {
                    colorBg =  Color.DarkGreen;
                }
                else
                {
                    colorBg =ColorThemas.BarraAccesoDirectos;
                }
                Decimal DescuentoPrecio = fnConvertirATipoDescuento(lstDetalleCronograma[fila].precioUnitario, lstDetalleCronograma[fila].strTipoDescuento, lstDetalleCronograma[fila].descuento);
                lstDetalleCronograma[fila].descuentoPrecio = DescuentoPrecio;
                Decimal ImporteTotal = (lstDetalleCronograma[fila].precioUnitario - DescuentoPrecio);
                lstDetalleCronograma[fila].total = ImporteTotal;
                dgvCronograma.Rows[fila].Cells[0].Value = lstDetalleCronograma[fila].idDetalleCronograma;
                dgvCronograma.Rows[fila].Cells[1].Value = fila + 1;
                dgvCronograma.Rows[fila].Cells[2].Value = Convert.ToInt32(lstDetalleCronograma[fila].estChk);
                dgvCronograma.Rows[fila].Cells[3].Value = lstDetalleCronograma[fila].periodoInicio.ToString("dd/MM/yyyy");
                dgvCronograma.Rows[fila].Cells[4].Value = lstDetalleCronograma[fila].periodoFinal.ToString("dd/MM/yyyy");
                dgvCronograma.Rows[fila].Cells[5].Value = lstDetalleCronograma[fila].fechaEmision.ToString("dd/MM/yyyy");

                dgvCronograma.Rows[fila].Cells[6].Value = lstDetalleCronograma[fila].fechaVencimiento.ToString("dd/MM/yyyy");
                dgvCronograma.Rows[fila].Cells[7].Value = lstDetalleCronograma[fila].fechaPago.ToString("dd/MM/yyyy") == "01/01/1900" ? "" : lstDetalleCronograma[fila].fechaPago.ToString("dd/MM/yyyy");
                dgvCronograma.Rows[fila].Cells[8].Value = clsMoneda.cSimbolo + ' ' + string.Format("{0:0.00}", lstDetalleCronograma[fila].precioUnitario);
                dgvCronograma.Rows[fila].Cells[9].Value = strDescuento != "" ? strDescuento : "" + lstDetalleCronograma[fila].descuento;
                dgvCronograma.Rows[fila].Cells[10].Value = clsMoneda.cSimbolo + ' ' + string.Format("{0:0.00}", lstDetalleCronograma[fila].descuentoPrecio);
                dgvCronograma.Rows[fila].Cells[11].Value = clsMoneda.cSimbolo + ' ' + string.Format("{0:0.00}", lstDetalleCronograma[fila].total);
                dgvCronograma.Rows[fila].Cells[12].Value = estadoCuota;


                dgvCronograma.Rows[fila].DefaultCellStyle.BackColor = colorBg;

                //dgvCronograma.Rows[fila].Cells[12].ReadOnly = true;
                //dgvCronograma.Rows[fila].Cells[12].Style.BackColor = Color.White;
                //dgvCronograma.Rows[fila].Cells[13].ReadOnly = true;
                dgvCronograma.Rows[fila].Cells[13].Style.BackColor = Color.White;
                //dgvCronograma.Rows[fila].Cells[14].ReadOnly = true;
                dgvCronograma.Rows[fila].Cells[14].Style.BackColor = Color.White;
            }
            else
            {
                Int32 cantDiasMes = 0;
                Int32 cantDiasSum = 0;

                dgvCronograma.Rows.Clear();
                for (Int32 i = 0; i < lstDetalleCronograma.Count; i++)
                {

                    //DateTime dtFechaTemp = lstDetalleCronograma[i].periodoInicio.AddMonths(1);
                    //cantDiasMes = DateTime.DaysInMonth(lstDetalleCronograma[i].periodoInicio.Year, lstDetalleCronograma[i].periodoInicio.Month);
                    //cantDiasSum = DateTime.DaysInMonth(dtFechaTemp.Year, dtFechaTemp.Month);
                    //Int32 diasASumar = 0;
                    //Int32 diaNuevaFecha = 0;
                    //Int32 restarFinal = 0;
                    //if (cantDiasSum <= 29 && dtFechaTemp.Month==2 && diaCicloPago!=15)
                    //{
                    //    diasASumar = cantDiasSum;
                    //}
                    //else if(cantDiasMes<=29 && lstDetalleCronograma[i].periodoInicio.Month==2)
                    //{
                    //    diasASumar = cantDiasSum>30?(30-1):cantDiasSum -1;
                    //}
                    //else
                    //{
                    //    diasASumar = cantDiasMes - 1;

                    //}

                    //diaNuevaFecha = cantDiasMes < diaCicloPago ? cantDiasMes : diaCicloPago;

                    //DateTime fechaInicio = Convert.ToDateTime(diaNuevaFecha + "/" +( lstDetalleCronograma[i].periodoInicio.Month)+"/"+ lstDetalleCronograma[i].periodoInicio.Year);
                    //lstDetalleCronograma[i].periodoInicio = fechaInicio;
                    //if (lstDetalleCronograma[i].periodoInicio.Month == 2 && diaCicloPago == 15)
                    //{
                    //    restarFinal = 30 - cantDiasMes;
                    //}
                    //else
                    //{
                    //    restarFinal = 0;
                    //}
                    //DateTime fechaFinal = fechaInicio.AddDays((diasASumar- restarFinal));
                    //var resulFechas = fnConvertirFechas(lstDetalleCronograma[i].periodoInicio);

                    //lstDetalleCronograma[i].periodoInicio = resulFechas.Item1;
                    //lstDetalleCronograma[i].periodoFinal = resulFechas.Item2;
                    //lstDetalleCronograma[i].fechaEmision = lstDetalleCronograma[i].periodoFinal.AddDays(1);
                    //DateTime fechaVencimiento = lstDetalleCronograma[i].periodoFinal.AddDays(5);
                    //lstDetalleCronograma[i].fechaVencimiento = fechaVencimiento;
                    

                    String strDescuento = "";
                    Int32 chk = 0;
                    Boolean estBloquear = false;
                    Color colorBg = ColorThemas.BarraAccesoDirectos;
                    if (lstDetalleCronograma[i].strTipoDescuento == "PORCENTUAL" && lstDetalleCronograma[i].descuento != 0)
                    {
                        strDescuento = lstDetalleCronograma[i].descuento + " % ";
                    }
                    else if (lstDetalleCronograma[i].strTipoDescuento == "DECIMAL" && lstDetalleCronograma[i].descuento != 0)
                    {
                        strDescuento = clsMoneda.cSimbolo + " " + lstDetalleCronograma[i].descuento;
                    }

                    chk = 0;
                    if (lstDetalleCronograma[i].codEstado == "ESPV0002")
                    {
                        estadoCuota = "✅ " + lstDetalleCronograma[i].estado;
                        lstDetalleCronograma[i].estChk = true;
                        estBloquear = true;
                        colorBg = ColorThemas.PanelPadre;
                    }
                    else if (lstDetalleCronograma[i].codEstado == "ESPV0001")
                    {
                        estadoCuota = "❗ " + lstDetalleCronograma[i].estado;
                    }
                    else if (lstDetalleCronograma[i].codEstado == "ESPV0003")
                    {
                        estadoCuota = "🚫 " + lstDetalleCronograma[i].estado;
                    }
                    else if (lstDetalleCronograma[i].codEstado == "ESPV0004")
                    {
                        estadoCuota = "❌ " + lstDetalleCronograma[i].estado;
                    }
                    else if (lstDetalleCronograma[i].codEstado == "ESPV0006")
                    {
                        estadoCuota = "🕖 " + lstDetalleCronograma[i].estado;
                        colorBg = Color.AliceBlue;
                    }
                    DetalleCronograma dtc = lstCronoGramasParaDocumentoVenta.Find(j => j.idDetalleCronograma == lstDetalleCronograma[i].idDetalleCronograma);
                    if (dtc is DetalleCronograma)
                    {
                        lstDetalleCronograma[i].estChk = true;
                        colorBg = Color.DarkGreen;
                    }
                    Decimal DescuentoPrecio = fnConvertirATipoDescuento(lstDetalleCronograma[i].precioUnitario, lstDetalleCronograma[i].strTipoDescuento, lstDetalleCronograma[i].descuento);
                    lstDetalleCronograma[i].descuentoPrecio = DescuentoPrecio;
                    Decimal ImporteTotal = (lstDetalleCronograma[i].total);
                    lstDetalleCronograma[i].total = ImporteTotal;
                    dgvCronograma.Rows.Add(
                       lstDetalleCronograma[i].idDetalleCronograma,
                       i + 1,
                       lstDetalleCronograma[i].estChk,
                      lstDetalleCronograma[i].periodoInicio.ToString("dd/MM/yyyy"),
                      lstDetalleCronograma[i].periodoFinal.ToString("dd/MM/yyyy"),
                      lstDetalleCronograma[i].fechaEmision.ToString("dd/MM/yyyy"),
                      lstDetalleCronograma[i].fechaVencimiento.ToString("dd/MM/yyyy"),
                      lstDetalleCronograma[i].fechaPago.ToString("dd/MM/yyyy")== "01/01/1900"?"": lstDetalleCronograma[i].fechaPago.ToString("dd/MM/yyyy"),
                      clsMoneda.cSimbolo + ' ' + string.Format("{0:0.00}", lstDetalleCronograma[i].precioUnitario),
                      strDescuento!=""? strDescuento: ""+lstDetalleCronograma[i].descuento,
                      clsMoneda.cSimbolo + ' ' + string.Format("{0:0.00}", lstDetalleCronograma[i].descuentoPrecio),
                      clsMoneda.cSimbolo + ' ' + string.Format("{0:0.00}", lstDetalleCronograma[i].total),
                      estadoCuota
                   );
                    dgvCronograma.Rows[i].DefaultCellStyle.BackColor = colorBg;
                    //dgvCronograma.Rows[i].ReadOnly = estBloquear;

                    dgvCronograma.Rows[i].Cells[12].ReadOnly = true;
                    //dgvCronograma.Rows[i].Cells[12].Style.BackColor = Color.White;
                    dgvCronograma.Rows[i].Cells[13].ReadOnly = true;
                    dgvCronograma.Rows[i].Cells[13].Style.BackColor = Color.White;
                    dgvCronograma.Rows[i].Cells[14].ReadOnly = true;
                    dgvCronograma.Rows[i].Cells[14].Style.BackColor = Color.White;

                }
            }
            cboComprobanteP.Focus();
            //tabControl1.TabPages[1].AutoScrollPosition=new Point(0,2350);
            // Obtener el control de desplazamiento vertical del TabPage
            var scrollBar = tabControl1.TabPages[1].VerticalScroll;

            // Posicionar el scroll al final
            scrollBar.Value = scrollBar.Maximum;

            tabControl1.TabPages[1].AutoScrollPosition = new Point(0, scrollBar.Maximum);
            //tabControl1.TabPages[1].AutoScroll = false;
            //dgvCronograma.Rows[0].Visible = false;

            //fnHabilitarDescuento(estadoDescuento);
        }

        private Tuple<Int32, Int32, Int32> DiferenciaFechas(DateTime newdt, DateTime olddt,String estado,Int32 ciclo)
        {
            Int32 anios;
            Int32 meses;
            Int32 dias=0;
            String str = "";
            String devolver = "";
            Int32 mesesCount = MonthDifference(newdt, olddt);

            Int32 numDias = DateTime.DaysInMonth(newdt.Year, newdt.Month);
            Int32 diaFechaPago = Convert.ToInt32(Convert.ToDateTime(olddt).ToString("dd"));
            Int32 diaFechaActual = Convert.ToInt32(newdt.ToString("dd"));
            ciclo = numDias < ciclo ? numDias : ciclo;

            if (estado=="MAYOR")
            {
                dias = ciclo;
            }
            else
            {
                olddt.AddDays(ciclo- diaFechaPago);
            }

           

            anios = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            
            //meses = mesesCount;
            if (meses <= 0)
            {
                anios -= 1;
                meses += 12;
            }
            if (dias < 0 || estado == "MAYOR")
            {
                meses -=  1;
                //Int32 temFecha= DateTime.DaysInMonth(newdt.Year, newdt.Month);
                dias += diaFechaActual;
            }
            else
            {
                if (estado == "MAYOR")
                {
                    meses -= 1;

                }
            }
            

            if (anios < 0)
            {
                //anios += 1;
                //meses = mesesCount-1;
            }
            if (anios > 0)
                str = str + anios.ToString() + " años ";
            if (meses > 0)
                str = str + meses.ToString() + " meses ";
            if (dias > 0)
                str = str + dias.ToString() + " dias ";
            
            return Tuple.Create(anios,meses, dias) ;
        }
        private void fnCargarTabla(DataGridView dgv,DataTable dtt, Int32 TipConPaginacion, Int32 numPagina)
        {
            lstClientesBusq.Clear();
            Int32 filas = 10;
            if (dtt.Rows.Count > 0)
            {
                btnExportarBusqueda.Visible = true;
                Int32 y;


                if (TipConPaginacion == -1 || TipConPaginacion==-3)
                {
                    y = 0;
                }
                else
                {
                    tabInicio = (numPagina - 1) * filas;
                    y = tabInicio;
                }

               
                Int32 totalResultados = dtt.Rows.Count;

                if (TipConPaginacion==-3)
                {
                    foreach (DataRow drMenu in dtt.Rows)
                    {
                        y+=1;
                        lstClientesBusq.Add(new Cliente
                        {
                            idCliente=y,
                            cNombre = Convert.ToString(drMenu["nombreCliente"]),
                            cApePat = Convert.ToString(drMenu["cApePat"]),
                            cApeMat = Convert.ToString(drMenu["cApeMat"]),
                            cCliente =FunGeneral.FormatearCadenaTitleCase(drMenu["nombreCliente"] + " " + drMenu["cApePat"] +" "+ drMenu["cApeMat"]),
                            cTelCelular = Convert.ToString(drMenu["cTelCelular"]),
                            dFecNac = dtFechapagoCronogramaGeneral.AddDays(1),
                            cContactoNom1 = FunGeneral.FormatearCadenaTitleCase(Convert.ToString(drMenu["cContactoNom1"])),
                            cContactoCel1 = Convert.ToString(drMenu["cContactoCel1"]),
                            codigoVentaGen = Convert.ToString(drMenu["vPlaca"]),
                            cEmpresa = FunGeneral.FormatearCadenaTitleCase(Convert.ToString(drMenu["cNombre"])),
                            cCorreo = "S/."+ string.Format("{0:0.00}", drMenu["precioPlan"]),
                            cContactoNom2 = FunGeneral.FormatearCadenaTitleCase(Convert.ToString(drMenu["cContactoNom2"])),
                            cContactoCel2= Convert.ToString(drMenu["cContactoCel2"]),
                            cTelFijo = Convert.ToString(drMenu["cNomTab"]),
                            cDireccion= dtFechapagoCronogramaGeneral.AddDays(1).ToString("dd/MMM/yyyy"),
                            ubigeo= FunGeneral.FormatearCadenaTitleCase(Convert.ToString(drMenu["cContactoNom2"])),
                            idReferencia= Convert.ToString(drMenu["cContactoCel2"]),

                        });
                    }

                }
                else
                {
                    dgv.Rows.Clear();
                    foreach (DataRow drMenu in dtt.Rows)
                    {
                        y += 1;
                        String estadoCuota = "";
                        String PasoDias = "";
                        Int32 faltaDias = 0;
                        Int32 restaAnio = 0;
                        Int32 restaMeses = 0;
                        Int32 diaNuevaFecha = 0;
                        String cDias = "";
                        String tiempoTranscurrido = "";
                        Int32 numDiasMesAdd = 0;
                        Int32 numDiasMespago = 0;
                        Int32 diasASumar = 0;
                        Int32 restarFinal = 0;

                        Int32 cicloPago = Convert.ToInt32(drMenu["cDia"]);
                        diaCicloPago = cicloPago;

                        DateTime dtFechActual = Convert.ToDateTime(Variables.gdFechaSis.ToString("dd/MM/yyyy"));
                        TimeSpan tiket = dtFechActual - dtFechActual.AddDays(-1);

                        DateTime dtFechaInicio = Convert.ToDateTime(Convert.ToDateTime(drMenu["periodoInicio"].ToString()).ToString("dd/MM/yyyy"));
                        DateTime dtFechaFinalCronograma = Convert.ToDateTime(Convert.ToDateTime(drMenu["periodoFinal"].ToString()).ToString("dd/MM/yyyy"));
                        DateTime dtFechaVencimientoCronograma = Convert.ToDateTime(Convert.ToDateTime(drMenu["fechaVencimiento"].ToString()).ToString("dd/MM/yyyy"));

                       

                        DateTime dtFechaTemp = Convert.ToDateTime(Convert.ToDateTime(drMenu["periodoInicio"].ToString()).ToString("dd/MM/yyyy")).AddMonths(1);
                        numDiasMespago = DateTime.DaysInMonth(dtFechaInicio.Year, dtFechaInicio.Month);
                        numDiasMesAdd = DateTime.DaysInMonth(dtFechaTemp.Year, dtFechaTemp.Month);

                        if (numDiasMesAdd <= 29 && dtFechaTemp.Month == 2 && diaCicloPago != 15)
                        {
                            diasASumar = numDiasMesAdd;
                        }
                        else if (numDiasMespago <= 29 && dtFechaInicio.Month == 2)
                        {
                            diasASumar = numDiasMesAdd > 30 ? (numDiasMesAdd - 1) : numDiasMesAdd - 1;

                        }
                        else
                        {
                            diasASumar = numDiasMespago - 1;

                        }

                        diaNuevaFecha = numDiasMespago < diaCicloPago ? numDiasMespago : diaCicloPago;

                        DateTime fechaInicio = Convert.ToDateTime(diaNuevaFecha + "/" + (dtFechaInicio.Month) + "/" + dtFechaInicio.Year);
                        //lstDetalleCronograma[i].periodoInicio = fechaInicio;
                        if (dtFechaInicio.Month == 2 && diaCicloPago == 15)
                        {
                            restarFinal = 30 - numDiasMespago;
                        }
                        else
                        {
                            restarFinal = 0;
                        }

                        //DateTime dtFechaPagoCronograma = fechaInicio.AddDays((diasASumar - restarFinal));
                        DateTime dtFechaPagoCronograma = Convert.ToDateTime(drMenu["FechaPago"].ToString());
                        var resulFechas = fnConvertirFechas(dtFechaInicio);

                        //Int32 cantDiasMesPago = DateTime.DaysInMonth(dtFechaDePago.Year, dtFechaDePago.Month);
                        if (dtFechActual > dtFechaPagoCronograma)
                        {
                            tiket = dtFechActual - dtFechaPagoCronograma;
                        }
                        else
                        {
                            tiket = dtFechaPagoCronograma - dtFechActual;
                        }

                        DateTime totalTime = new DateTime(tiket.Ticks);
                        restaAnio = totalTime.Year - 1;
                        restaMeses = totalTime.Month - 1;
                        faltaDias = Convert.ToInt32(totalTime.Day - 1);


                        //DateTime fechaPagoCiclo = dtFechaDePago.AddDays(Math.Abs(NumDiasSumar));

                        if (Convert.ToString(drMenu["cNomTab"]) == "PAGO PENDIENTE")
                        {
                            cDias = faltaDias == 1 ? " Dia " : " Dias ";
                            if (dtFechaPagoCronograma < dtFechActual)
                            {
                                if (restaAnio > 0)
                                {
                                    tiempoTranscurrido = "\n❌ Retraso ( " + restaAnio + " años " + restaMeses + " Meses " + faltaDias + " )" + cDias;

                                } else if (restaMeses > 0)
                                {
                                    tiempoTranscurrido = "\n❌ Retraso ( " + restaMeses + " Meses " + faltaDias + " )" + cDias;

                                }
                                else
                                {
                                    tiempoTranscurrido = "\n❌ Retraso ( " + faltaDias + " )" + cDias;
                                }
                            }
                            else
                            {
                                if (restaMeses > 0)
                                {
                                    tiempoTranscurrido = "\n✅ Aun tienes ( " + restaMeses + " Meses " + faltaDias + " )" + cDias + " para cobrar";

                                }
                                else if (faltaDias > 10)
                                {
                                    tiempoTranscurrido = "\n❗ Aun tienes ( " + faltaDias + " )" + cDias + " para cobrar";

                                }
                                else
                                {
                                    if (faltaDias == 0)
                                    {
                                        tiempoTranscurrido = "\n‼ El dia de pago es hoy " + dtFechActual.ToString("dd/MMM");

                                    }
                                    else
                                    {
                                        tiempoTranscurrido = "\n‼ Solo tienes ( " + faltaDias + " )" + cDias + " para cobrar";

                                    }
                                }

                            }
                            estadoCuota = FunGeneral.FormatearCadenaTitleCase(Convert.ToString(drMenu["cNomTab"])) + tiempoTranscurrido;

                        }
                        else if (Convert.ToString(drMenu["cNomTab"]) == "CUOTA PAGADA")
                        {
                            dtFechaPagoCronograma = Convert.ToDateTime(drMenu["dtFechaCorte"]);
                            tiempoTranscurrido = "\n✅ El ( " + Convert.ToDateTime(drMenu["dtFechaCorte"]).ToString("dd/MMM/yyyy") + " )";
                            estadoCuota = FunGeneral.FormatearCadenaTitleCase(Convert.ToString(drMenu["cNomTab"])) + tiempoTranscurrido;
                        }
                        else
                        {
                            if (Convert.ToString(drMenu["cNomTab"]) == "VENCIDO")
                            {
                                //dtFechaPagoCronograma = Convert.ToDateTime(drMenu["dtFechaCorte"]);
                                tiempoTranscurrido = "\n🚫 Desde ( " + dtFechaVencimientoCronograma.ToString("dd/MMM/yyyy") + " )";
                            }
                            else
                            {
                                tiempoTranscurrido = "\n❌ Desde ( " + Convert.ToDateTime(drMenu["dtFechaCorte"]).ToString("dd/MMM/yyyy") + " )";

                            }
                            estadoCuota = FunGeneral.FormatearCadenaTitleCase(Convert.ToString(drMenu["cNomTab"])) + tiempoTranscurrido;

                        }
                        if (Convert.ToString(drMenu["cNomTab"]) == "CREDITO")
                        {
                            tiempoTranscurrido = "\n🕖 Desde ( " + Convert.ToDateTime(drMenu["dtFechaCorte"]).ToString("dd/MMM/yyyy") + " )";
                            estadoCuota = FunGeneral.FormatearCadenaTitleCase(Convert.ToString(drMenu["cNomTab"])) + tiempoTranscurrido;
                        }
                        dtFechapagoCronogramaGeneral = dtFechaPagoCronograma;



                        dgv.Rows.Add(
                            drMenu["idCronograma"],
                            drMenu["idContrato"],
                            y,
                           drMenu["codContrato"],
                            dtFechapagoCronogramaGeneral.ToString("dd/MMM/yyyy"),
                            drMenu["vPlaca"],
                            drMenu["nombreCliente"] + " " + drMenu["cApePat"] +" "+ drMenu["cApeMat"],
                            drMenu["cNombre"],
                            drMenu["nombre"],
                            drMenu["cDia"],
                            estadoCuota
                            );
                    }
                    dgv.Visible = true;

                    if (TipConPaginacion == -1)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(dtt.Rows[0][0]);
                        FunValidaciones.fnCalcularPaginacion(
                            totalRegistros,
                            filas,
                            totalResultados,
                            cboPagina,
                            btnTotalPag,
                            btnNumFilas,
                            btnTotalReg
                        );
                    }
                    else
                    {
                        btnNumFilas.Text = Convert.ToString(totalResultados);
                    }

                }
                //tabControl1.TabPages[0].AutoScroll = false;
            }
            else
            {
                dgv.Rows.Clear();
                gbPaginacion.Visible = false;
                btnExportarBusqueda.Visible = false;
            }
        }
        public  int MonthDifference( DateTime Actual, DateTime Pago)
        {
            return Math.Abs((Actual.Month - Pago.Month) + 12 * (Actual.Year - Pago.Year));
        }

        private void frmControlPagoVenta_Load(object sender, EventArgs e)
        {
            try
            {

                lstCronoGramasParaDocumentoVenta.Clear();
                btnValidarEstados.Visible = false;
                EstadoCarga = false;
                Boolean bResult = false;
                lstC.Clear();
                dtFechaPago.Value = Variables.gdFechaSis;
                FunGeneral.fnValidarFechaPago(dtFechaPago, pbFechaPago, 0);
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
               
                //gbBuscarListaVentas.Enabled = false;
                CronogramaSeleccionado = 0;
                frmRegistrarVenta frmRV = new frmRegistrarVenta();
                fnLLenarMoneda(cboMoneda, 0, false);
                bResult = frmRV.fnLlenarTipoDescuento(0, cboTipoDescuentoPrecios, false);
                FunGeneral.fnLlenarTablaCodTipoCon(cboEstadopago, "ESPV",true);
                cboEstadopago.SelectedValue = "ESPV0001";
                //cboEstadopago.Enabled = false;
                if (!bResult)
                {
                    MessageBox.Show("Error al Tipo Descuento", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                estDescuento = false;
                fnHabilitarDescuento(false);
                fnLlenarCiclo(0, cboCicloPago,true);
                cboCronograma.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboComprobanteP.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboMoneda.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                FunGeneral.fnThemaAFormularios(siticonePanel1);
                if (Variables.gsCargoUsuario == "PETR0001" || Variables.gsCargoUsuario == "PETR0005" || Variables.gsCargoUsuario == "PETR0007")
                {
                    btnValidarEstados.Visible = true;
                    cmsPagoCuotas.Items[1].Visible = true;
                }
                else
                {
                    btnValidarEstados.Visible = false;
                    cmsPagoCuotas.Items[1].Visible = false;
                }
                if (inTipoApertura==0)
                {
                    dtFechaPago.Enabled = true;

                }
                else if (inTipoApertura==-1)
                {
                    dtFechaPago.Value = dttFechaRecibida;
                    dtFechaPago.Enabled = false;
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                EstadoCarga = true;
                Int32 numRows = 0;
                DateTime dtt = dtFechaPago.Value;
                String dtt1 = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 5);

                numRows =FunGeneral.fnBuscarAccionDiaria(0, dtt1);
                if (numRows==0)
                {
                    DateTime dttt= dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1)).AddMonths(-1);

                    fnBuscarCronogramaAutomatico(FunGeneral.GetFechaHoraFormato(dttt, 5), FunGeneral.GetFechaHoraFormato(dtpFechaFinalBus.Value,5), "ESPV0001", 0);
                    FunGeneral.fnRegistrarAccionDiaria("Actualizacion estados detalle cronograma",true,0, FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 3));
                }
                
            }
        }

        private void fnBuscarCronogramaAutomatico(String dtIni, String dtFin,String estado,Int32 tipoCon)
        {
            DAControlPagos dtCP = new DAControlPagos();
            List<DetalleCronograma> lstCronogramas = new List<DetalleCronograma>();
            List<DetalleCronograma> lstDetCronAutomatico = new List<DetalleCronograma>();
            List<DetalleCronograma> lstDetCronAutomaticoEsp = new List<DetalleCronograma>();
            List<DetalleCronograma> lstDetCronAutomaticoEspUnico = new List<DetalleCronograma>();
            ;
            //try
            try
            {
                lstDetCronAutomatico = dtCP.daBuscarCronogramaAutomatico(dtIni, dtFin, estado, lstDetCronAutomatico, tipoCon);
                String ArrIdsCronograma = "";
                Int32 contadorVencido = 0;
                Int32 contadorCorte = 0;
                Int32 stIdCronograma = 0;
                
                lstDetCronAutomaticoEsp = dtCP.daBuscarCronogramaAutomaticoEspecifico(dtIni, dtFin, "ESPV0001", lstDetCronAutomatico, 1);
                contadorVencido = 0;
                stIdCronograma = 0;
             
                
                for (Int32 i = 0; i < lstDetCronAutomatico.Count; i++)
                {
                    if (lstDetCronAutomatico[i].idCronograma== 23)
                    {

                    }
                    contadorVencido = 0;
                    List<DetalleCronograma> clsDetCro = new List<DetalleCronograma>();

                    clsDetCro = lstDetCronAutomaticoEsp.FindAll(r => r.idCronograma == lstDetCronAutomatico[i].idCronograma);
                    

                    for (Int32 j = 0; j < clsDetCro.Count; j++)
                    {
                        //if (lstDetCronAutomatico[i].idCronograma == lstDetCronAutomaticoEsp[j].idCronograma)
                        //{
                        diaCicloPago = Convert.ToInt32(clsDetCro[j].cDiaCiclo);
                        var resulFechas = fnConvertirFechas(clsDetCro[j].periodoInicio);
                        //clsDetCro[j].periodoInicio = resulFechas.Item1;
                        //clsDetCro[j].periodoFinal = resulFechas.Item2;
                        //clsDetCro[j].fechaEmision = clsDetCro[j].periodoFinal.AddDays(1);
                        //clsDetCro[j].fechaVencimiento = clsDetCro[j].periodoFinal.AddDays(5);

                            if (clsDetCro[j].fechaVencimiento < Variables.gdFechaSis)
                            {
                                //contadorVencido = dtCP.daContadorEstadosVencidos(lstDetCronAutomatico[i].idCronograma, "ESPV0003");

                                //if (contadorVencido <2)
                                //{
                                if (clsDetCro[j].estado != "ESPV0002")
                                {
                                    if (j > 0)
                                    {

                                        if (clsDetCro[j].estado == "ESPV0001" && clsDetCro[j - 1].estado == "ESPV0003")
                                        {
                                            dtCP.daActualizarEstados(clsDetCro[j].idDetalleCronograma, "ESPV0004", 1);
                                        }
                                        else if (clsDetCro[j].estado == "ESPV0003" && clsDetCro[j - 1].estado == "ESPV0003")
                                        {
                                        dtCP.daActualizarEstados(clsDetCro[j].idDetalleCronograma, "ESPV0004", 1);
                                        }
                                        else if (clsDetCro[j].estado == "ESPV0001" && clsDetCro[j - 1].estado == "ESPV0004")
                                        {
                                            dtCP.daActualizarEstados(clsDetCro[j].idDetalleCronograma, "ESPV0004", 1);
                                        }

                                    }
                                    else
                                    {
                                        if (clsDetCro[j].estado == "ESPV0001" || clsDetCro[j].estado == "ESPV0004")
                                        {
                                            dtCP.daActualizarEstados(clsDetCro[j].idDetalleCronograma, "ESPV0003", 1);
                                        }
                                    
                                    }
                                        //dtCP.daActualizarEstados(lstDetCronAutomaticoEsp[j].idDetalleCronograma, "ESPV0003", 1);
                                }
                            
                                //if(lstDetCronAutomaticoEsp[j].estado != "ESPV0002")
                                //{

                                //}
                                //if (contadorVencido == 2)
                                //{
                                //    contadorVencido += 1;
                                //}
                                //}
                                //else if (contadorVencido >= 2)
                                //{
                                //    dtCP.daActualizarEstados(lstDetCronAutomaticoEsp[j].idDetalleCronograma, "ESPV0004", 1);
                                //}
                            }
                            else
                            {
                                if (clsDetCro[j].estado == "ESPV0003" || clsDetCro[j].estado == "ESPV0004")
                                {
                                    dtCP.daActualizarEstados(lstDetCronAutomaticoEsp[j].idDetalleCronograma, "ESPV0001", 1);
                                }
                            }
                        //}
                    }

                }



            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

        }

        private Tuple<DateTime,DateTime> fnConvertirFechas(DateTime dtRecibido)
        {
            Int32 cantDiasMes = 0;
            Int32 cantDiasSum = 0;
            DateTime dtFechaTemp = dtRecibido.AddMonths(1);
            cantDiasMes = DateTime.DaysInMonth(dtRecibido.Year, dtRecibido.Month);
            cantDiasSum = DateTime.DaysInMonth(dtFechaTemp.Year, dtFechaTemp.Month);
            Int32 diasASumar = 0;
            Int32 diaNuevaFecha = 0;
            Int32 restarFinal = 0;
            if (cantDiasSum <= 29 && dtFechaTemp.Month == 2 && diaCicloPago != 15)
            {
                diasASumar = cantDiasSum;
            }
            else if (cantDiasMes <= 29 && dtRecibido.Month == 2)
            {
                diasASumar = cantDiasSum > 30 ? (30 - 1) : cantDiasSum - 1;
            }
            else
            {
                diasASumar = cantDiasMes - 1;

            }

            diaNuevaFecha = cantDiasMes < diaCicloPago ? cantDiasMes : diaCicloPago;

            DateTime fechaInicio = Convert.ToDateTime(diaNuevaFecha + "/" + (dtRecibido.Month) + "/" + dtRecibido.Year);
            //lstDetalleCronograma[i].periodoInicio = fechaInicio;
            if (fechaInicio.Month == 2 && diaCicloPago == 15)
            {
                restarFinal = 30 - cantDiasMes;
            }
            else
            {
                restarFinal = 0;
            }
            DateTime fechaFinal = fechaInicio.AddDays((diasASumar - restarFinal));

           return Tuple.Create(fechaInicio, fechaFinal);

        }
        private Boolean fnLlenarCiclo(Int32 idCiclo, SiticoneComboBox cbo, Boolean buscar)
        {
            BLCiclo objCiclo = new BLCiclo();
            clsUtil objUtil = new clsUtil();
            List<Ciclo> lstCiclo;

            try
            {
                lstCiclo = objCiclo.blDevolverCiclo(idCiclo, buscar);

                cbo.ValueMember = "IdCiclo";
                cbo.DisplayMember = "Dia";
                cbo.DataSource = lstCiclo;
                lstC = lstCiclo;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarCronograma(0, txtBuscar.Text.ToString(), -1, 0);
            }
        }

        private void fnObtenerCronogramaEspecifico(Int32 idCron,Int32 idCont)
        {
            obControPagos = new BLControlPagos();
            DataTable dtResult = new DataTable();
            dtResult = obControPagos.blBuscarCronogramaEspecifico(idCron, idCont,0);
            fnCargarDatos(dtResult);
        }
        private void fnCargarDatos(DataTable dtResult)
        {
            if (dtResult.Rows.Count > 0)
            {
                BLTipoTarifa objBlTipTarifa = new BLTipoTarifa();
                BLCiclo objCiclo = new BLCiclo();
                BLTipoCliente objTipoCliente = new BLTipoCliente();
                lstDetalleCronograma.Clear();
                clsVentaGeneral.codigoVenta = Convert.ToString(dtResult.Rows[0][24]);
                Tarifa trf = new Tarifa();
                clsTarifa = objBlTipTarifa.blDevolverPreciosPagosMensuales(Convert.ToInt32(dtResult.Rows[0][1]), Convert.ToString(dtResult.Rows[0][24]), Convert.ToInt32(dtResult.Rows[0][33]));
                trf = objBlTipTarifa.blDevolverPreciosPagosMensuales(Convert.ToInt32(dtResult.Rows[0][1]), Convert.ToString(dtResult.Rows[0][24]), Convert.ToInt32(dtResult.Rows[0][33]));
                cboMoneda.SelectedValue = clsTarifa.IdMoneda;
                clsCiclo.IdCiclo = Convert.ToInt32(dtResult.Rows[0][17]);

                lstCiclo = objCiclo.blDevolverCiclo(Convert.ToInt32(dtResult.Rows[0][17]), false);

                clsVehiculo.idVehiculo = Convert.ToInt32(dtResult.Rows[0][3]);
                clsVehiculo.vPlaca = Convert.ToString(dtResult.Rows[0][4]);
                clsVehiculo.Observaciones = Convert.ToString(dtResult.Rows[0][5]);

                Vehiculo clsvh = new Vehiculo();
                clsvh.idVehiculo = Convert.ToInt32(dtResult.Rows[0][3]);
                clsvh.vPlaca = Convert.ToString(dtResult.Rows[0][4]);
                clsvh.Observaciones = Convert.ToString(dtResult.Rows[0][5]);

                Cliente clsCli= new Cliente();
                clsCli.cApePat = dtResult.Rows[0][6].ToString();
                clsCli.cApeMat = dtResult.Rows[0][7].ToString();
                clsCli.cNombre = dtResult.Rows[0][8].ToString();
                clsCli.cDireccion = dtResult.Rows[0][9].ToString();
                clsCli.cContactoNom1 = dtResult.Rows[0][10].ToString();
                clsCli.cTiDo = Convert.ToInt32(dtResult.Rows[0][11]);
                clsCli.cDocumento = Convert.ToString(dtResult.Rows[0][13]);

                clsCliente.cApePat = dtResult.Rows[0][6].ToString();
                clsCliente.cApeMat = dtResult.Rows[0][7].ToString();
                clsCliente.cNombre = dtResult.Rows[0][8].ToString();
                clsCliente.cDireccion = dtResult.Rows[0][9].ToString();
                clsCliente.cContactoNom1 = dtResult.Rows[0][10].ToString();
                clsCliente.cTiDo = Convert.ToInt32(dtResult.Rows[0][11]);
                clsCliente.cDocumento = Convert.ToString(dtResult.Rows[0][13]);
                clsCliente.TiDocumentoSunat=dtResult.Rows[0][35].ToString();

                lstDocumentoVentaEmitir = Mantenedores.frmRegistrarVenta.fnLlenarComprobante(cboComprobanteP, "DOVE", clsCliente.cTiDo, 0);
                
                lstTD = objTipoCliente.blDevolverDocumentoDeTipoCliente(Convert.ToInt32(dtResult.Rows[0][12]), "1", false);

                txtDatosCliente.Text = Convert.ToString(clsCliente.cNombre + ' ' + clsCliente.cApePat + ' ' + clsCliente.cApeMat);
                txtPlacaVehiculo.Text = clsVehiculo.vPlaca;
                txtDatosVehiculo.Text = clsVehiculo.Observaciones;
                txtTarifa.Text = Convert.ToString(dtResult.Rows[0][14]);
                txtTipoventa.Text = Convert.ToString(dtResult.Rows[0][15]);
                txtPlan.Text = Convert.ToString(dtResult.Rows[0][16]);
                clsVentaGeneral.codigoVenta = Convert.ToString(dtResult.Rows[0][24]);

                txtfechaoriginal.Text = Convert.ToDateTime(dtResult.Rows[0][31]).ToString("dd/MM/yyyy");
                diaCicloPago = Convert.ToInt32(dtResult.Rows[0][27]);


                for (Int32 i = 0; i < dtResult.Rows.Count; i++)
                {
                    lstDetalleCronograma.Add(new DetalleCronograma
                    {
                        numItem = (i + 1),
                        idDetalleCronograma = Convert.ToInt32(dtResult.Rows[i][0]),
                        CodigoVenta = Convert.ToString(dtResult.Rows[0][24]),
                        idPlan = Convert.ToInt32(dtResult.Rows[0][1]),
                        fechaRegistro = Convert.ToDateTime(dtResult.Rows[i][18]),
                        periodoInicio = Convert.ToDateTime(dtResult.Rows[i][19]),
                        periodoFinal = Convert.ToDateTime(dtResult.Rows[i][20]),
                        fechaVencimiento = Convert.ToDateTime(dtResult.Rows[i][21]),
                        fechaEmision = Convert.ToDateTime(dtResult.Rows[i][25]),
                        fechaPago = Convert.ToDateTime(dtResult.Rows[i][26]),
                        precioUnitario = clsTarifa.PrecioPlan,
                        descuento = Convert.ToDecimal(dtResult.Rows[i][28]),
                        //descuentoCantidad = Convert.ToDouble(dtResult.Rows[i][28]),
                        descuentoPrecio = Convert.ToDecimal(dtResult.Rows[i][29]),
                        total = Convert.ToInt32(dtResult.Rows[i][30]) == 0 ? clsTarifa.PrecioPlan : Convert.ToDecimal(dtResult.Rows[i][30]),
                        codEstado = Convert.ToString(dtResult.Rows[i][22]),
                        estado = Convert.ToString(dtResult.Rows[i][23]),
                        idDetallePago = Convert.ToInt32(dtResult.Rows[i][32]),
                        strTipoDescuento = Convert.ToString(dtResult.Rows[i][34]),
                        idVehiculo = Convert.ToInt32(dtResult.Rows[0][3]),
                        PlacaVehiculo = Convert.ToString(dtResult.Rows[0][4]),
                        cCliente = dtResult.Rows[0][8].ToString() + " " + dtResult.Rows[0][6].ToString() + " " + dtResult.Rows[0][7].ToString(),
                        ClaseVehiculo = clsvh,
                        ClaseCliente = clsCli,
                        ClaseTarifa= trf

                    });


                }
                fnCargarTablaLista(false, 0, 0);
            }
            
            
        }
        private void dgvListaVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 idCronograma=Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[0].Value);
            Int32 idContrato=Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[1].Value);
            fnObtenerCronogramaEspecifico(idCronograma, idContrato);
            //dgvListaVentas.Visible = false;
            tabControl1.TabPages[0].AutoScroll = true;
        }

        private void iRACONTROLDEPAGOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            CronogramaSeleccionado = 0;
            Int32 idCronograma = Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[0].Value);
            Int32 idContrato = Convert.ToInt32(dgvListaVentas.CurrentRow.Cells[1].Value);
            String Placa = Convert.ToString(dgvListaVentas.CurrentRow.Cells[5].Value);

            fnBuscarCronograma(1, Placa, -1, 0);

            cboCronograma.SelectedIndex = 0;
            fnObtenerCronogramaEspecifico(Convert.ToInt32(cboCronograma.SelectedValue), idContrato);
        }

        private void dgvCronograma_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvCronograma.Columns[e.ColumnIndex].Name == "btnPagar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvCronograma.Rows[e.RowIndex].Cells["btnPagar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\pagar.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvCronograma.Rows[e.RowIndex].Height = 35;                
                this.dgvCronograma.Columns[e.ColumnIndex].Width = 45;


                e.Handled = true;

            }
            if (e.ColumnIndex >= 0 && this.dgvCronograma.Columns[e.ColumnIndex].Name == "btnImprimir" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvCronograma.Rows[e.RowIndex].Cells["btnImprimir"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\impresora.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvCronograma.Rows[e.RowIndex].Height = 35;                
                this.dgvCronograma.Columns[e.ColumnIndex].Width = 45;


                e.Handled = true;

            }
            
        }

        private void dgvCronograma_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                
        }
        private Boolean fnLLenarMoneda(ComboBox cbo, Int32 idMoneda, Boolean buscar)
        {
            BLMoneda objMoneda = new BLMoneda();
            clsUtil objUtil = new clsUtil();
            List<Moneda> lstMoneda;

            try
            {
                lstMoneda = objMoneda.blDevolverMoneda(idMoneda, buscar);
                cbo.ValueMember = "idMoneda";
                cbo.DisplayMember = "cNombre";
                cbo.DataSource = lstMoneda;

                lstMon = lstMoneda;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarClaseVehiculo", ex.Message);
                return false;
            }
            finally
            {
                lstMoneda = null;
            }
        }
        private void fnLimpiarSeleccion()
        {
            lstCronoGramasParaDocumentoVenta.Clear();
            dgvDatosDocumentosVenta.Rows.Clear();
            cboCronograma.SelectedValue = CronogramaSeleccionado;

        }
        private void obtenerNumeroDeItems()
        {
            SiticoneDataGridView dgv = dgvDatosDocumentosVenta;
            dgv.Rows.Clear();
            btnContadorItems.Text = ""+ lstCronoGramasParaDocumentoVenta.Count;
            Int32 totalRows= lstCronoGramasParaDocumentoVenta.Count;
            Int32 y = 0;
            foreach (DetalleCronograma dc in lstCronoGramasParaDocumentoVenta)
            {
                dgv.Rows.Add
                (
                    dc.idDetalleCronograma,
                    y + 1,
                    "Cuota " + dc.periodoFinal.ToString("MMMM  yyyy") + " - Placa " + dc.ClaseVehiculo.vPlaca,
                    FunGeneral.fnFormatearPrecioDC("S/.",dc.total,0)

                ); 
                y++;
            }
            dgv.Rows.Add("","","","");
            dgv.Rows.Add
                (
                    0,
                    "",
                    "IMPORTE TOTAL ",
                    FunGeneral.fnFormatearPrecioDC("S/.", lstCronoGramasParaDocumentoVenta.Sum(I=>I.total), 0)

                );
            dgv.Rows[y+1].DefaultCellStyle.BackColor = Color.Red;
            dgv.Rows[y+1].DefaultCellStyle.ForeColor = Color.White;
            dgv.Height= ((totalRows+3) *dgv.ThemeStyle.RowsStyle.Height);
            pnDocumentos.Height = dgv.Height + 50;
            Int32 x = ((dgv.Width / 2) / 2);
            btnAniadirADocumento.Location = new Point((x/2)+3, (dgv.Height+3));
            dgv.Columns[1].Width=5;
            dgv.Columns[2].Width=100;
            dgv.Columns[3].Width=60;


        }

        private Boolean fnAgregardatosACarrito(Int32 row)
        {
            Boolean estado = false;
            if (row==0)
            {
                Int32 indice = lstCronograma.IndexOf(lstCronograma.Find(i => i.idCronograma == CronogramaSeleccionado));
                if (lstCronograma[indice + 1].estado == "ESPV0002")
                {
                    lstDetalleCronograma[row].estChk = true;
                    lstDetalleCronograma[row].cPlan = FunGeneral.FormatearCadenaTitleCase(txtPlan.Text);
                    lstDetalleCronograma[row].idOperacion = 3;
                    lstDetalleCronograma[row].fechaPago = dtFechaPago.Value;
                    lstCronoGramasParaDocumentoVenta.Add(lstDetalleCronograma[row]);
                    estado = true;
                }else
                {

                    estado = false;
                    MessageBox.Show("Aun no puede generar este pago ! \n porque falta Completar los pagos del contrato anterior !", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                DetalleCronograma clsDetCron = lstDetalleCronograma.Find(i => i.estado == "VENCIDO");
                if (clsDetCron is DetalleCronograma)
                {
                    if (lstDetalleCronograma[row].estado == "VENCIDO")
                    {
                        lstDetalleCronograma[row].estChk = true;
                        lstDetalleCronograma[row].cPlan = FunGeneral.FormatearCadenaTitleCase(txtPlan.Text);
                        lstDetalleCronograma[row].idOperacion = 3;
                        lstDetalleCronograma[row].fechaPago = dtFechaPago.Value;
                        lstCronoGramasParaDocumentoVenta.Add(lstDetalleCronograma[row]);
                        estado = true;
                    }
                    else
                    {

                        if (lstDetalleCronograma[row - 1].estChk != false)
                        {
                            lstDetalleCronograma[row].estChk = true;
                            lstDetalleCronograma[row].cPlan = FunGeneral.FormatearCadenaTitleCase(txtPlan.Text);
                            lstDetalleCronograma[row].idOperacion = 3;
                            lstDetalleCronograma[row].fechaPago = dtFechaPago.Value;
                            lstCronoGramasParaDocumentoVenta.Add(lstDetalleCronograma[row]);
                            estado = true;
                        }
                        else
                        {
                            MessageBox.Show("Aun no puede generar este pago ! \n porque falta la cuota anterior !", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            estado = false;
                        }
                    }
                    
                }
                else
                {
                    if (lstDetalleCronograma[row - 1].estado== "CORTE" || lstDetalleCronograma[row - 1].estado == "CUOTA PAGADA")
                    {
                        if (lstDetalleCronograma[row].estado == "PAGO PENDIENTE")
                        {
                            lstDetalleCronograma[row].estChk = true;
                            lstDetalleCronograma[row].cPlan = FunGeneral.FormatearCadenaTitleCase(txtPlan.Text);
                            lstDetalleCronograma[row].idOperacion = 3;
                            lstDetalleCronograma[row].fechaPago = dtFechaPago.Value;
                            lstCronoGramasParaDocumentoVenta.Add(lstDetalleCronograma[row]);
                            estado = true;
                        }
                        else if(lstDetalleCronograma[row].estado == "CORTE")
                        {
                            DialogResult EstadoDialog = MessageBox.Show("En realidad desea pagar esta cuota en estado CORTE?", "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (EstadoDialog==DialogResult.Yes)
                            {
                                lstDetalleCronograma[row].estChk = true;
                                lstDetalleCronograma[row].cPlan = FunGeneral.FormatearCadenaTitleCase(txtPlan.Text);
                                lstDetalleCronograma[row].idOperacion = 3;
                                lstDetalleCronograma[row].fechaPago = dtFechaPago.Value;
                                lstCronoGramasParaDocumentoVenta.Add(lstDetalleCronograma[row]);
                                estado = true;
                            }
                            else
                            {
                                //MessageBox.Show("Aun no puede generar este pago ! \n porque falta la cuota anterior !", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                estado = false;
                            }
                           
                        }
                        else if (lstDetalleCronograma[row].codEstado== "ESPV0006")
                        {
                            estado = false;
                            DialogResult EstadoDialog = MessageBox.Show("Este págo debe realizarlo desde la ventana de págos pendientes", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (EstadoDialog==DialogResult.OK)
                            {
                                frmPagosPendientes frm = new frmPagosPendientes();
                                frm.Inicio(clsCliente.cDocumento);
                            }
                        }
                        
                    }
                    else
                    {
                        if (lstDetalleCronograma[row - 1].estChk != false)
                        {
                            lstDetalleCronograma[row].estChk = true;
                            lstDetalleCronograma[row].cPlan = FunGeneral.FormatearCadenaTitleCase(txtPlan.Text);
                            lstDetalleCronograma[row].idOperacion = 3;
                            lstDetalleCronograma[row].fechaPago = dtFechaPago.Value;
                            lstCronoGramasParaDocumentoVenta.Add(lstDetalleCronograma[row]);
                            estado = true;
                        }
                        else
                        {
                            MessageBox.Show("Aun no puede generar este pago ! \n porque falta la cuota anterior !", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            estado = false;
                        }
                    }
                    
                }
                
            }

            return estado;
        }
        private void dgvCronograma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean chkPasar = false;

            DataGridViewCell fila = dgvCronograma.Rows[e.RowIndex].Cells[e.ColumnIndex ];
            if (e.ColumnIndex==2 && lstDetalleCronograma[e.RowIndex].codEstado != "ESPV0002")
            {
                Int32 idDetalle = Convert.ToInt32(dgvCronograma.Rows[e.RowIndex].Cells[0].Value);
                DetalleCronograma dtc = lstCronoGramasParaDocumentoVenta.Find(i => i.idDetalleCronograma == idDetalle);
               
                if (dtc is DetalleCronograma)
                {
                    lstCronoGramasParaDocumentoVenta.Remove(dtc);
                    lstDetalleCronograma[e.RowIndex].estChk = false;
                }
                else
                {
                    if (e.RowIndex>0)
                    {
                        if (lstDetalleCronograma[e.RowIndex - 1].codEstado == "ESPV0001" && lstDetalleCronograma[e.RowIndex - 1].estChk == false)
                        {
                            MessageBox.Show("Aun no puede agregar este pago ! \n porque falta la cuota anterior !", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (lstCronoGramasParaDocumentoVenta.Count > 0)
                            {
                                DetalleCronograma dtc1 = lstCronoGramasParaDocumentoVenta.Find(i => i.ClaseCliente.cDocumento == lstDetalleCronograma[e.RowIndex].ClaseCliente.cDocumento);

                                if (dtc1 is DetalleCronograma)
                                {
                                    chkPasar=fnAgregardatosACarrito(e.RowIndex);
                                }
                                else
                                {
                                    MessageBox.Show("El Cliente no es el mismo a su seleccion anterior ", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                chkPasar=fnAgregardatosACarrito(e.RowIndex);
                            }
                        }
                    }
                    else
                    {
                        chkPasar=fnAgregardatosACarrito(e.RowIndex);
                    }
                         
                }

               
                fnCargarTablaLista(chkPasar, e.RowIndex, e.ColumnIndex);
              
                obtenerNumeroDeItems();


            }
            
            if (e.ColumnIndex == dgvCronograma.Columns["btnPagar"].Index && e.RowIndex >= 0)
            {
                if (dgvCronograma.Rows[e.RowIndex].Cells[e.ColumnIndex-1].Value.ToString().Contains("✅"))
                {
                    cmsPagoCuotas.Items[0].Visible = false;
                    //cmsPagoCuotas.Items[1].Visible = true;
                }                
                else
                {
                    if (dgvCronograma.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString().Contains("CREDITO"))
                    {
                        DialogResult EstadoDialog = MessageBox.Show("Este págo debe realizarlo desde la ventana de págos pendientes", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (EstadoDialog == DialogResult.OK)
                        {
                            frmPagosPendientes frm = new frmPagosPendientes();
                            frm.Inicio(clsCliente.cDocumento);
                        }
                    }
                    else
                    {
                        if (lstCronoGramasParaDocumentoVenta.Count <= 1)
                        {
                            cmsPagoCuotas.Items[0].Visible = true;

                        }
                        else
                        {
                            MessageBox.Show("Realise al pago por la modalidad págo multiple", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            fnOcultarDatosParaDocumentoVenta();
                            cmsPagoCuotas.Items[0].Visible = false;
                        }
                    }
                    
                    //cmsPagoCuotas.Items[1].Visible = false;
                }

                var mousePosition = dgvCronograma.PointToClient(Cursor.Position);
                cmsPagoCuotas.Show(dgvCronograma, (803), mousePosition.Y);
            }else if (e.ColumnIndex == dgvCronograma.Columns["btnImprimir"].Index && e.RowIndex >= 0)
            {
                if (lstDetalleCronograma[e.RowIndex].codEstado == "ESPV0002" || lstDetalleCronograma[e.RowIndex].codEstado == "ESPV0006")
                {
                    String cCodigoVenta = clsVentaGeneral.codigoVenta;
                    Int32 idTipoTarifa = clsTarifa.IdTipoTarifa;
                    Int32 idContrato = Convert.ToInt32(dgvCronograma.CurrentRow.Cells[0].Value);
                    fnBuscarDocumentoVenta(cCodigoVenta, 2, idTipoTarifa, idContrato);
                }
                else
                {
                    MessageBox.Show("Aun no disponible. por favor registre el pago de la cuota","Aviso 😟!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                
            }
        }
        private void fnBuscarDocumentoVenta(String cCodVenta,Int32 tipoCond, Int32 idTipoTarifa, Int32 idContrato)
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
                xmlDocVenta = objTipoVenta.blBuscarDocumentoVentaGeneral(cCodVenta, tipoCond, idTipoTarifa, idContrato);
                //xmlDocVenta.xmlDocumentoVenta[0].cDireccion = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cDireccion);
                xmlDocVenta.xmlDocumentoVenta[0].cCliente = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cCliente);
                xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago);
                xmlDocumentoVenta.Add(xmlDocVenta);

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
        private void fnPagarCuota()
        {
            Consultas.frmVPVenta frmVenta = new Consultas.frmVPVenta();
        }
        private Decimal fnConvertirATipoDescuento(Decimal precioOriginal, String tipodescuento, Decimal descuento)
        {
            Decimal precioDescuento;
            if (tipodescuento == "PORCENTUAL")
            {
                precioDescuento = Convert.ToDecimal(precioOriginal * descuento) / 100;
            }
            else
            {
                precioDescuento = descuento;
            }
            return precioDescuento;
        }
        private List<DetalleVenta> fnGenerarPagoPrincipal(Int32 fila,Int32 columna)
        {
            List<DetalleVenta> lstDetV = new List<DetalleVenta>();

            Int32 idCiclo = clsCiclo.IdCiclo;
            Int32 ciclo = Ciclo.fnObtenerCicloSeleccionado(idCiclo, lstCiclo).DiaNumber;
            //DateTime fechaActual = Convert.ToDateTime(dtpFechaRegistro.Value);
            Double rentaAdelantada = 0;
            Double prorrateo = 0;
            Double ganProrrateo = 0;
            Double calcularDescuento = 0;
            Double calcularDesRA = 0;
            Double calcularDesPR = 0;
            Double calcularDesReactivacion = 0;


            //prorrateo = DetalleVentaCabecera.fnCalcularProrrateo(rentaAdelantada, ciclo, fechaActual);


            //calcularDescuento = fnConvertirATipoDescuento(clsTarifa.PrecioPlan, cboTipoDescuentoPrecios.Text, clsTarifa.DescuentoRentaAdelantada);

            Decimal pagoPlan = clsTarifa.PrecioPlan;
            //clsTarifa.PrecioPlan -
            Double[] arrayPrecio = { };
            Double[] arrayDescuentoCantidad = { };
            Double[] arrayDescuentoPrecio = { };
            String[] arrayPrimerPago = { };
            Int32 cuota = 0;

           
            //arrayGananciaPro = new double[]
            //{
            //    0,
            //    0,
            //    ganProrrateo
            //};
            arrayPrimerPago = new string[]
            {
                "Cuota "+lstDetalleCronograma[fila].periodoFinal.ToString("MMMM  yyyy")+" - Plan "+FunGeneral.FormatearCadenaTitleCase(txtPlan.Text)
            };



            lstDetV.Add(new DetalleVenta
            {
                IdDetalleVenta = lstDetalleCronograma[fila].idDetallePago,
                Numeracion = 1,
                Descripcion = arrayPrimerPago[0],
                idTipoTarifa = clsTarifa.IdTarifa,
                PrecioUni = lstDetalleCronograma[fila].precioUnitario,
                Descuento = lstDetalleCronograma[fila].descuento,
                TotalTipoDescuento = lstDetalleCronograma[fila].descuentoPrecio,
                IdTipoDescuento = Convert.ToInt32(cboTipoDescuentoPrecios.SelectedValue),
                Cantidad = 1,
                Couta = cuota,
                importeRestante = lstDetalleCronograma[fila].total,
                Importe = lstDetalleCronograma[fila].total,
                cSimbolo = clsMoneda.cSimbolo,

                preciounitario = Convert.ToDecimal(lstDetalleCronograma[fila].precioUnitario),
                ImporteRow = (Convert.ToDecimal(lstDetalleCronograma[fila].total) * 1),
                mtoValorVentaItem= (Convert.ToDecimal(lstDetalleCronograma[fila].total) * 1),
                Unidad_de_medida = "ZZ"




            }) ;



            return lstDetV;
        }

        private List<DetalleVenta> fnGenerarPagoPrincipalBloque()
        {
            Boolean est = false;
            List<DetalleVenta> lstDetV = new List<DetalleVenta>();
            Int32 y = 0;
            String dato = "";

            for (int i = 0; i < lstCronoGramasParaDocumentoVenta.Count; i++)
            {
                DetalleCronograma dcr = lstCronoGramasParaDocumentoVenta[i];

                if (lstCronoGramasParaDocumentoVenta.Count>1)
                {
                    dato = " - Placa " + dcr.ClaseVehiculo.vPlaca;
                    //if (i>0)
                    //{
                    //    if (lstCronoGramasParaDocumentoVenta[i].ClaseVehiculo.vPlaca== lstCronoGramasParaDocumentoVenta[i-1].ClaseVehiculo.vPlaca)
                    //    {
                    //        dato = " - Plan " + dcr.cPlan;
                    //    }
                    //    else
                    //    {
                    //        dato = " - Placa " + dcr.ClaseVehiculo.vPlaca;
                    //    }
                    //}
                    //else
                    //{
                    //    if (dcr.ClaseVehiculo.idVehiculo==clsVehiculo.idVehiculo)
                    //    {
                    //        dato = " - Plan " + dcr.cPlan;
                    //    }
                    //    else
                    //    {
                    //        dato = " - Placa " + dcr.ClaseVehiculo.vPlaca;
                    //    }
                    //}
                }
                else
                {
                    dato = " - Plan " + dcr.cPlan;
                }
                

                lstDetV.Add(new DetalleVenta
                {
                    IdDetalleVenta = dcr.idDetalleCronograma,
                    Numeracion = 1 + y,
                    Descripcion = "Cuota " + dcr.periodoFinal.ToString("MMMM  yyyy") + dato,
                    idTipoTarifa = dcr.ClaseTarifa.IdTarifa,
                    PrecioUni = dcr.precioUnitario,
                    Descuento = dcr.descuento,
                    TotalTipoDescuento = dcr.descuentoPrecio,
                    IdTipoDescuento = Convert.ToInt32(cboTipoDescuentoPrecios.SelectedValue),
                    Cantidad = 1,
                    Couta = 0,
                    importeRestante= dcr.total,
                    Importe = dcr.total,
                    cSimbolo = clsMoneda.cSimbolo,
                    preciounitario = Convert.ToDecimal(dcr.precioUnitario),
                    ImporteRow = (Convert.ToDecimal(dcr.total) * 1),
                    mtoValorVentaItem = (Convert.ToDecimal(dcr.total) * 1),

                    Unidad_de_medida = "ZZ"
                });
                y++;

            }

            foreach (DetalleCronograma dcr in lstCronoGramasParaDocumentoVenta)
            {

                


                
            }

            



            return lstDetV;
        }
        private DetalleVentaCabecera fnCalcularCabeceraDetalle(List<DetalleVenta> lstDV)
        {
            DetalleVentaCabecera clsDVC = new DetalleVentaCabecera();
            DetalleVenta dvMensual = new DetalleVenta();

            clsDVC.ImporteTotal = lstDV.Sum(item => item.Importe);
            clsDVC.ValorVenta = (clsDVC.ImporteTotal / 1.18m);
            clsDVC.IGV = (clsDVC.ImporteTotal - clsDVC.ValorVenta);
            clsDVC.SimboloMoneda = clsMoneda.cSimbolo;
            clsDVC.NombreDocumento = Convert.ToString(cboComprobanteP.Text);
            clsDVC.CodDocumento = Convert.ToString(cboComprobanteP.SelectedValue);
            clsDVC.lstDetalleVenta = lstDV;
           
            return clsDVC;
        }
        public void fnCambiarEstadoVenta(bool estado, List<DetalleVenta> lstDetalleVnt)
        {
            estPagoCuota = estado;
            List<xmlDocumentoVentaGeneral> xmlDocumentoVenta = new List<xmlDocumentoVentaGeneral>();
            if (estPagoCuota == true)
            {
                if (lstCronoGramasParaDocumentoVenta.Count < 2)
                {
                    clsCronograma = lstCronograma.Find(i => i.idCronograma == CronogramaSeleccionado);
                    lstPagosTrand[0].idMoneda = clsMoneda.idMoneda;
                    lstPagosTrand[0].Unidades = 1;
                    byte[] btImage = fnEnviarFacturaASunat();
                    claseControlPagos = new ControlPagos
                    {
                        fechaRegistro = Variables.gdFechaSis,
                        fechaPago = FunGeneral.fnUpdateFechas(dtFechaPagoCuota),
                        fechaVenta = clsDetCronogramaEspecifico.fechaRegistro,
                        claseCliente = clsCliente,
                        claseCronograma = clsCronograma,
                        listaDetalleCronograma = lstDetalleCronograma,
                        claseDetalleCronograma = clsDetCronogramaEspecifico,
                        claseVehiculo = clsVehiculo,
                        listaPagosTrandiaria = lstPagosTrand,
                        claseTarifa = clsTarifa,
                        listaDocumentoVenta = lstDocumentoVenta,
                        listaDetalleVenta = lstDetalleVnt,//lstDetalleVenta,
                        idUsuario = Variables.gnCodUser,
                        idCiclo = 1,
                        byteQr = btImage,
                        CodCorrelativoFactura = clsDocumentoVenta.SerieDoc + "-" + FunGeneral.generarCorrelativoDocumento(Convert.ToInt32(clsDocumentoVenta.nValor2))

                    };
                    xmlDocumentoVenta.Add(new xmlDocumentoVentaGeneral
                    {
                        xmlDocumentoVenta = lstDocumentoVenta,
                        xmlDetalleVentas = lstDetalleVnt
                        //memoryStream = new MemoryStream(btImage)
                    }) ;
                    fnGuardarPagoCuota(claseControlPagos, xmlDocumentoVenta, lnTipoCon);
                }
                else
                {
                    String cCodigoVenta = "";
                    List<Pagos> lstPagosT = new List<Pagos>();
                    for (Int32 i=0;i<lstCronoGramasParaDocumentoVenta.Count;i++)
                    {
                        if (i+1== lstCronoGramasParaDocumentoVenta.Count)
                        {
                            cCodigoVenta += lstCronoGramasParaDocumentoVenta[i].CodigoVenta;
                        }
                        else
                        {
                            cCodigoVenta += lstCronoGramasParaDocumentoVenta[i].CodigoVenta+",";

                        }
                    }

                    byte[] btImage = fnEnviarFacturaASunat();
                    clsCronograma = lstCronograma.Find(i => i.idCronograma == CronogramaSeleccionado);
                    lstPagosTrand[0].idMoneda = clsMoneda.idMoneda;
                    lstPagosTrand[0].Unidades = lstCronoGramasParaDocumentoVenta.Count;
                    claseControlPagos = new ControlPagos
                    {
                        cCodVenta = cCodigoVenta,
                        fechaRegistro = Variables.gdFechaSis,
                        fechaPago = FunGeneral.fnUpdateFechas(dtFechaPagoCuota),
                        fechaVenta = clsDetCronogramaEspecifico.fechaRegistro,
                        claseCliente = clsCliente,
                        claseCronograma = clsCronograma,
                        listaDetalleCronograma = lstCronoGramasParaDocumentoVenta,
                        claseDetalleCronograma = clsDetCronogramaEspecifico,
                        claseVehiculo = clsVehiculo,
                        listaPagosTrandiaria = lstPagosTrand,
                        claseTarifa = clsTarifa,
                        listaDocumentoVenta = lstDocumentoVenta,
                        listaDetalleVenta = lstDetalleVnt,
                        idUsuario = Variables.gnCodUser,
                        idCiclo = 1,
                        byteQr = btImage,
                        CodCorrelativoFactura = clsDocumentoVenta.SerieDoc + "-" + FunGeneral.generarCorrelativoDocumento(Convert.ToInt32(clsDocumentoVenta.nValor2))


                    };
                    xmlDocumentoVenta.Add(new xmlDocumentoVentaGeneral
                    {
                        xmlDocumentoVenta = lstDocumentoVenta,
                        xmlDetalleVentas = lstDetalleVnt,
                        //memoryStream = new MemoryStream(btImage)
                    }) ;

                    fnGuardarPagoCuotaPorDocumento(claseControlPagos, xmlDocumentoVenta, lnTipoCon);
                }



            }
            else
            {
                //MessageBox.Show("Todo anulado no se generará el pago");
            }
        }

        private byte[] fnEnviarFacturaASunat()
        {
            //Cargo clsCargo1 = lstDocumentoVentaEmitir.Find(i => i.cCodTab == cboComprobanteP.SelectedValue.ToString());
            EmitirFactura emf = new EmitirFactura();
            String rutaArchivo = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR\";
            byte[] imageBytes = File.ReadAllBytes(rutaArchivo + "QR\\QrDefecto.png");
            if (clsDocumentoVenta.cCodTab== "DOVE0002" || clsDocumentoVenta.cCodTab == "DOVE0001")
            {
                intRespuestaSunat = 0;
                int resp =emf.EmitirFacturasContado(clsCliente, lstDetalleVenta, lstDocumentoVenta,clsDocumentoVenta);
                intRespuestaSunat = resp;
                if (resp == 1)
                {                    
                    String nombreQR = clsCliente.cDocumento + "-" + clsDocumentoVenta.nValor1 + "-" + clsDocumentoVenta.SerieDoc + "-" + FunGeneral.generarCorrelativoDocumento(Convert.ToInt32(clsDocumentoVenta.nValor2));
                    //bitmap.Save(rutaArchivo + "QR\\" + nombreQR + ".png");
                    imageBytes = File.ReadAllBytes(rutaArchivo + "QR\\" + nombreQR + ".png");
                }
            }
            else
            {
                intRespuestaSunat = 1;
            }
            
            
            return imageBytes;
        }
        private void fnGuardarPagoCuota(ControlPagos ctp,List<xmlDocumentoVentaGeneral> lstDV, Int32 tipoCon)
        {
            obControPagos = new BLControlPagos();
            Boolean bResult = false;
            if (intRespuestaSunat == 1)
            {
                bResult = obControPagos.blGuardarPagoCuota(ctp, lstDV, tipoCon);
                String strTipo = tipoCon == 0 ? "Guardado" : "Actualizado";
                if (bResult)
                {
                    MessageBox.Show("Págo " + strTipo + " Correctamente ✅", "Informacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkHabilitarDescuentoP.Checked = false;
                    fnLimpiarSeleccion();
                }
                else
                {
                    MessageBox.Show("Error al " + strTipo + " Págo ❌ \n -> Comunique al administrador", "Informacion ❌", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Error al emitir factura a la sunat Págo ❌ \n -> Comunique al administrador", "Informacion ❌", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void fnGuardarPagoCuotaPorDocumento(ControlPagos ctp,List<xmlDocumentoVentaGeneral> lstDV, Int32 tipoCon)
        {
            obControPagos = new BLControlPagos();
            Boolean bResult = false;
            if (intRespuestaSunat==1)
            {
                bResult = obControPagos.blGuardarPagoCuotasPorDocumento(ctp, lstDV, tipoCon);
                String strTipo = tipoCon == 0 ? "Guardado" : "Actualizado";
                if (bResult)
                {
                    MessageBox.Show("Págo " + strTipo + " Correctamente ✅", "Informacion ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkHabilitarDescuentoP.Checked = false;
                    fnLimpiarSeleccion();

                }
                else
                {
                    MessageBox.Show("Error al " + strTipo + " Págo ❌ \n -> Comunique al administrador", "Informacion ❌", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Error al emitir factura a la sunat Págo ❌ \n -> Comunique al administrador", "Informacion ❌", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           

        }
        public static void fnRecuperarTipoPago(List<Pagos> lstEntidades)
        {
            lstPagosTrand = lstEntidades;
           
        }
        public static string ConvertirPrecioEnLetras(decimal precio)
        {
            string[] unidades = { "", "UN ", "DOS ", "TRES ", "CUATRO ", "CINCO ", "SEIS ", "SIETE ", "OCHO ", "NUEVE " };
            string[] decenas = { "DIEZ ", "ONCE ", "DOCE ", "TRECE ", "CATORCE ", "QUINCE ", "DIECISÉIS ", "DIECISIETE ", "DIECIOCHO ", "DIECINUEVE ", "VEINTE ", "TREINTA ", "CUARENTA ", "CINCUENTA ", "SESENTA ", "SETENTA ", "OCHENTA ", "NOVENTA " };
            string[] centenas = { "", "CIENTO ", "DOSCIENTOS ", "TRESCIENTOS ", "CUATROCIENTOS ", "QUINIENTOS ", "SEISCIENTOS ", "SETECIENTOS ", "OCHOCIENTOS ", "NOVECIENTOS " };
            string[] miles = { "", "MIL ", "DOS MIL ", "TRES MIL ", "CUATRO MIL ", "CINCO MIL ", "SEIS MIL ", "SIETE MIL ", "OCHO MIL ", "NUEVE MIL " };
            string[] millones = { "", "UN MILLÓN ", "DOS MILLONES ", "TRES MILLONES ", "CUATRO MILLONES ", "CINCO MILLONES ", "SEIS MILLONES ", "SIETE MILLONES ", "OCHO MILLONES ", "NUEVE MILLONES " };

            int entero = (int)Math.Floor(precio);
            int decimales = (int)Math.Round((precio - entero) * 100);
            int millon = entero / 1000000;
            entero = entero % 1000000;
            int miles1 = entero / 1000;
            entero = entero % 1000;
            int centenas1 = entero / 100;
            entero = entero % 100;
            int decenas1 = entero / 10;
            int unidades1 = entero % 10;

            string letras = "";
            if (millon > 0)
            {
                letras += millones[millon];
            }
            if (miles1 > 0)
            {
                letras += miles[miles1];
            }
            if (centenas1 > 0)
            {
                if (centenas1 == 1 && decenas1 == 0 && unidades1 == 0)
                {
                    letras += "CIEN ";
                }
                else
                {
                    letras += centenas[centenas1];
                }
            }
            if (decenas1 > 0 || unidades1 > 0)
            {
                if (decenas1 == 0)
                {
                    letras += unidades[unidades1];
                }
                else if (decenas1 == 1 && unidades1 > 0)
                {
                    letras += decenas[decenas1 + 9];
                    letras += unidades[unidades1];
                }
                else
                {
                    letras += decenas[decenas1];
                    letras += unidades[unidades1];
                }
            }
            letras += "CON " + decimales.ToString("00") + "/100";

            return letras.ToUpper();
        }
        private List<DocumentoVenta> fnCargarDocumentoVenta(DetalleVentaCabecera lstdvc,Int32 tipCon)
        {
            List<DocumentoVenta> lsDocVenta = new List<DocumentoVenta>();
            TipoTarifa lstTipoVenta = new TipoTarifa();
            frmRegistrarVenta frmRV = new frmRegistrarVenta();
            Personal clsPersonal = FunGeneral.fnObtenerUsuarioActual();
            PrecioALetras pal = new PrecioALetras();
            //string RecioALetras = ConvertirPrecioEnLetras(Convert.ToDecimal(lstdvc.ImporteTotal));
            string RecioALetras2 = pal.Convertir(lstdvc.ImporteTotal.ToString(), true, " SOLES");


            if (tipCon==0)
            {
                lsDocVenta.Add(new DocumentoVenta
                {
                    idCliente = clsCliente.idCliente,
                    cCliente = FunGeneral.FormatearCadenaTitleCase(clsCliente.cNombre + " " + clsCliente.cApePat + " " + clsCliente.cApeMat),
                    cTipoDoc = fnDevolverTipoDocPersona(clsCliente.cTiDo),
                    cDireccion = /*cboComprobanteP.SelectedValue.ToString()!= "DOVE0002" ? */FunGeneral.FormatearCadenaTitleCase(clsCliente.cDireccion + ' ' + clsCliente.cContactoNom1)/*: FunGeneral.FormatearCadenaTitleCase(clsCliente.cDireccion)*/,
                    cDocumento = clsCliente.cDocumento,
                    SimboloMoneda = clsMoneda.cSimbolo,
                    cCodDocumentoVenta = Convert.ToString(cboComprobanteP.SelectedValue),
                    CodigoCorrelativo = clsDocumentoVenta.SerieDoc + "-" + FunGeneral.generarCorrelativoDocumento(Convert.ToInt32(clsDocumentoVenta.nValor2)),
                    NombreDocumento = Convert.ToString(cboComprobanteP.Text),
                    dFechaVenta = Convert.ToDateTime(dtFechaPago.Value),
                    idMoneda = clsMoneda.idMoneda,
                    nSubtotal = lstdvc.ValorVenta,
                    nNroIGV = 18,
                    nIGV = lstdvc.IGV,
                    nMontoTotal = lstdvc.ImporteTotal,
                    PrecioEnLetras= RecioALetras2,
                    cUsuario = clsPersonal.cPrimerNom + " " + clsPersonal.cApePat,
                    cVehiculos = clsVehiculo.vPlaca,
                    cDescripcionTipoPago = (lstPagosTrand.Count > 0) ? FunGeneral.FormatearCadenaTitleCase(lstPagosTrand[0].cDescripTipoPago) : "",
                    cDescripEstadoPP = (lstPagosTrand.Count > 0) ? lstPagosTrand[0].cEstadoPP : "",
                    cTipoVenta = lstTipoVenta.Nombre

                });
            }else if (tipCon==1)
            {
                String vPlacas = "";
                foreach (DetalleCronograma item in lstCronoGramasParaDocumentoVenta)
                {
                    if (item.ClaseVehiculo.idVehiculo!=clsVehiculo.idVehiculo && lstCronoGramasParaDocumentoVenta.Count>1)
                    {
                        vPlacas = "Varias";
                        break;
                    }
                    else if (item.ClaseVehiculo.idVehiculo == clsVehiculo.idVehiculo)
                    {
                        vPlacas = item.ClaseVehiculo.vPlaca;
                    }
                    else
                    {
                        vPlacas = item.ClaseVehiculo.vPlaca;
                    }
                }

                lsDocVenta.Add(new DocumentoVenta
                {
                    idCliente = clsCliente.idCliente,
                    cCliente = FunGeneral.FormatearCadenaTitleCase(lstCronoGramasParaDocumentoVenta[0].ClaseCliente.cNombre + " " + lstCronoGramasParaDocumentoVenta[0].ClaseCliente.cApePat + " " + lstCronoGramasParaDocumentoVenta[0].ClaseCliente.cApeMat),
                    cTipoDoc = fnDevolverTipoDocPersona(lstCronoGramasParaDocumentoVenta[0].ClaseCliente.cTiDo),
                    cDireccion = cboComprobanteP.SelectedValue.ToString() != "DOVE0002" ? FunGeneral.FormatearCadenaTitleCase(clsCliente.cDireccion + ' ' + clsCliente.cContactoNom1) : FunGeneral.FormatearCadenaTitleCase(clsCliente.cDireccion),
                    cDocumento = lstCronoGramasParaDocumentoVenta[0].ClaseCliente.cDocumento,
                    SimboloMoneda = clsMoneda.cSimbolo,
                    cCodDocumentoVenta = Convert.ToString(cboComprobanteP.SelectedValue),
                    CodigoCorrelativo = clsDocumentoVenta.SerieDoc+"-"+ FunGeneral.generarCorrelativoDocumento(Convert.ToInt32(clsDocumentoVenta.nValor2)),
                    NombreDocumento = Convert.ToString(cboComprobanteP.Text),
                    dFechaVenta = Convert.ToDateTime(dtFechaPago.Value),
                    idMoneda = clsMoneda.idMoneda,
                    nSubtotal = lstdvc.ValorVenta,
                    nNroIGV = 18,
                    nIGV = lstdvc.IGV,
                    nMontoTotal = lstdvc.ImporteTotal,
                    PrecioEnLetras = RecioALetras2,
                    cUsuario = clsPersonal.cPrimerNom + " " + clsPersonal.cApePat + " " + clsPersonal.cApeMat,
                    cVehiculos = vPlacas,
                    cDescripcionTipoPago = (lstPagosTrand.Count > 0) ? FunGeneral.FormatearCadenaTitleCase(lstPagosTrand[0].cDescripTipoPago) : "",
                    cDescripEstadoPP = (lstPagosTrand.Count > 0) ? lstPagosTrand[0].cEstadoPP : "",
                    cTipoVenta = lstTipoVenta.Nombre

                });
            }
           
            return lsDocVenta;
        }
        private String fnDevolverTipoDocPersona(Int32 tipoDoc)
        {
            String cDoc = "";
            foreach (TipoDocumento item in lstTD)
            {
                if (item.TDid == tipoDoc)
                {
                    cDoc = item.TDnombre;
                }
            }
            return cDoc;
        }
        private Decimal fnConvertirPrecioMoneda(Int32 idMonedaEntrada, Double precioEntrada, Int32 idMonedaSalida)
        {
            BLMoneda objMoneda = new BLMoneda();
            CambioMonedaVenta clsCambioMoneda;
           

            clsCambioMoneda = objMoneda.blDevolverCambioMoneda(idMonedaEntrada, precioEntrada, idMonedaSalida);
            string precioEntradaFormatedo = string.Format("{0:0.00}", precioEntrada);
            string simboloEntradaFormatedo = string.Format("{0:0.00}", clsCambioMoneda.PrecioSalida);
            string precioCambioMoneda = string.Format("{0:0.00}", clsCambioMoneda.PrecioCambio);

            
            return clsCambioMoneda.PrecioSalida;
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EstadoCarga==true)
            {
                clsMoneda = lstMon.Find(i => i.idMoneda == Convert.ToInt32(cboMoneda.SelectedValue));

            }
            var result = FunValidaciones.fnValidarCombobox(cboMoneda, erMoneda, imgMoneda);
            estadoMoneda = result.Item1;
            msgMoneda = result.Item2;


        }

        private void cboTipoDescuentoPrecios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EstadoCarga == true)
            {
                if (Convert.ToInt32(cboTipoDescuentoPrecios.SelectedValue) != 0)
                {
                    fnHabilitarDescuento(estDescuento);
                }
                else
                {
                    fnHabilitarDescuento(false);
                }

            }
        }

        private void fnHabilitarDescuento(Boolean estado)
        {
            DataGridViewColumn ColDescuentoPP = dgvCronograma.Columns[9];

            Color colorColumnaPP = estado ? Color.White : Variables.ColorDescativadoFuerte;
            ColDescuentoPP.DefaultCellStyle.BackColor = colorColumnaPP;
            ColDescuentoPP.ReadOnly = estado ? false : true;
        }
        public static void fnRespuestaValidacion(Boolean estado)
        {
            estDescuento = estado;
        }
        private void chkHabilitarDescuentoP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarDescuentoP.Checked == true)
            {
                Procesos.frmAccesoADescuento frmDescuento = new Procesos.frmAccesoADescuento();
                estDescuento = false;
                frmDescuento.Inicio(2);
                if (estDescuento == true)
                {
                    cboTipoDescuentoPrecios.Enabled = estDescuento;
                    chkHabilitarDescuentoP.Checked = estDescuento;
                }
                else
                {
                    cboTipoDescuentoPrecios.Enabled = estDescuento;
                    chkHabilitarDescuentoP.Checked = estDescuento;
                }
               

            }
            else
            {
                estDescuento = false;
                chkHabilitarDescuentoP.Checked = false;
                fnHabilitarDescuento(estDescuento);
                cboTipoDescuentoPrecios.SelectedIndex =0 ;
                cboTipoDescuentoPrecios.Enabled = estDescuento;
            }
        }
       
        private void dgvCronograma_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (EstadoCarga==true && e.ColumnIndex>0)
            {
                if (e.ColumnIndex == 9)
                {
                    DialogResult dResult;
                    Decimal PrecioADescontar = 0;
                    String texto = dgvCronograma.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    //string textoSinDosPrimeros = texto.Substring(2, texto.Length - 2);
                    PrecioADescontar = Convert.ToDecimal(texto);
                    //Double PrecioADescontar = Convert.ToDouble(dgvCronograma.Rows[e.RowIndex+1].Cells[e.ColumnIndex].Value);

                    Int32 idDescuento = Convert.ToInt32(cboTipoDescuentoPrecios.SelectedValue);
                    lstDetalleCronograma[e.RowIndex].strTipoDescuento = Convert.ToString(cboTipoDescuentoPrecios.Text);

                    if (idDescuento==1 )
                    {
                        if (PrecioADescontar >50 && PrecioADescontar<=100)
                        {
                            if (PrecioADescontar != lstDetalleCronograma[e.RowIndex].descuento)
                            {
                                dResult = MessageBox.Show("Esta seguro de aplicar un descuento muy alto?", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                if (dResult == DialogResult.OK)
                                {
                                    lstDetalleCronograma[e.RowIndex].descuento = PrecioADescontar;
                                    fnCargarTablaLista(true, e.RowIndex, e.ColumnIndex);
                                }
                            }
                            else
                            {
                                lstDetalleCronograma[e.RowIndex].descuento = PrecioADescontar;
                                fnCargarTablaLista(true, e.RowIndex, e.ColumnIndex);
                            }
                            
                        }else if (PrecioADescontar > 100)
                        {
                            MessageBox.Show("El descuento no puede ser mayor 100%.", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fnCargarTablaLista(true, e.RowIndex, e.ColumnIndex);
                        }
                        else if (PrecioADescontar < 0)
                        {
                            MessageBox.Show("El descuento no puede ser menor a CERO.", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fnCargarTablaLista(true, e.RowIndex, e.ColumnIndex);
                        }
                        else
                        {
                            lstDetalleCronograma[e.RowIndex].descuento = PrecioADescontar;
                            fnCargarTablaLista(true, e.RowIndex, e.ColumnIndex);
                        }

                    }
                    else if (idDescuento==2)
                    {
                        if (lstDetalleCronograma[e.RowIndex].precioUnitario < PrecioADescontar)
                        {
                            MessageBox.Show("El descuento no puede ser mayor al precio unitario.", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fnCargarTablaLista(true, e.RowIndex, e.ColumnIndex);
                        }
                        else if (PrecioADescontar < 0)
                        {
                            MessageBox.Show("El descuento no puede ser menor a CERO.", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fnCargarTablaLista(true, e.RowIndex, e.ColumnIndex);
                        }
                        else
                        {
                            lstDetalleCronograma[e.RowIndex].descuento = PrecioADescontar;
                            fnCargarTablaLista(true, e.RowIndex, e.ColumnIndex);
                        }
                    }



                }
                else if (e.ColumnIndex == 10)
                {
                    
                }
            }
            
        }

        private void ctmPagar_Opening(object sender, CancelEventArgs e)
        {

        }
        void cboCronograma_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cboCronograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            fnObtenerCronogramaEspecifico(Convert.ToInt32(cboCronograma.SelectedValue), 0);
            fnHabilitarDescuento(false);

            //MessageBox.Show("idContrato "+ Convert.ToInt32(cboCronograma.SelectedValue));
            CronogramaSeleccionado = Convert.ToInt32(cboCronograma.SelectedValue);
            if (lstCronograma.Count>0)
            {
                Cronograma dcr = lstCronograma.Find(i => i.idCronograma == CronogramaSeleccionado);
                if(dcr is Cronograma)
                {
                    if (dcr.estadoCronograma != "ESCR0004")
                    {
                        btnCambiarIncumplimiento.Text = "Pasar a Incumplimiento";
                    }
                    else if (dcr.estadoCronograma == "ESCR0004")
                    {
                        btnCambiarIncumplimiento.Text = "Activar Cronograma";
                    }
                }
                
            }
           
        }

        private void dgvListaVentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgview = sender as DataGridView;

            String nombreCabecera = dgview.Columns[e.ColumnIndex].Name;

            if (nombreCabecera == "Estado_lv")
            {

                if (e.Value.ToString().Contains("✅"))
                {
                    e.CellStyle.ForeColor = Variables.ColorSuccess;
                }
                else if (e.Value.ToString().Contains("❗"))
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }else if (e.Value.ToString().Contains("🚫"))
                {
                    e.CellStyle.ForeColor = Color.Purple;
                }
                else if (e.Value.ToString().Contains("🕖"))
                {
                    e.CellStyle.ForeColor = Color.OrangeRed;

                }
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarCronograma(0, txtBuscar.Text.ToString(), -2, Convert.ToInt32(cboPagina.Text));
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Proceso aun no disponible","Aviso.😕",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            frmVPCronograma frm= new frmVPCronograma();
            lstDetalleCronograma[0].cCliente =FunGeneral.FormatearCadenaTitleCase(clsCliente.cNombre+" "+clsCliente.cApePat+" "+clsCliente.cApeMat);
            lstDetalleCronograma[0].cVehiculo = FunGeneral.FormatearCadenaTitleCase(clsVehiculo.vPlaca+" "+ clsVehiculo.Observaciones);
            lstDetalleCronograma[0].cPlan = FunGeneral.FormatearCadenaTitleCase(txtTarifa.Text + " - " + txtPlan.Text);
            lstDetalleCronograma[0].cPeriodo = "" + lstDetalleCronograma[0].periodoInicio.ToString("dd/MM/yyyy") + " A " + lstDetalleCronograma[11].periodoFinal.ToString("dd/MM/yyyy");

            frm.Inicio(lstDetalleCronograma,0);
            
        }

        private void chkHabilitarFechasBus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechasBus.Checked==true)
            {
                gbBuscarListaVentas.Enabled = true;
            }
            else
            {
                gbBuscarListaVentas.Enabled = false;

            }
        }

        private void dgvListaVentas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
                    if (!clickedRow.Selected)
                    {
                        dgvListaVentas.CurrentCell = clickedRow.Cells[e.ColumnIndex];

                    }
                    else
                    {
                        var mousePosition = dgvListaVentas.PointToClient(Cursor.Position);
                        ctmPagar.Show(dgvListaVentas, mousePosition);
                    }

                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneGroupBox4_Click(object sender, EventArgs e)
        {

        }

        private void pbBuscar_Click_1(object sender, EventArgs e)
        {
            fnBuscarCronograma(0, txtBuscar.Text.ToString(), -1, 0);
        }

        private Boolean fnValidarFecha(Label lbl,PictureBox pb)
        {
            String msg = "";
            Boolean bEstado = false;
            PictureBox pbx = null;
            Image img = null;
            DateTime dtFechaSistema = Variables.gdFechaSis.AddDays(-2);
            if (Convert.ToDateTime(dtFechaPago.Value.ToString("dd/MM/yyyy")) >= Convert.ToDateTime(dtFechaSistema.ToString("dd/MM/yyyy")) && Convert.ToDateTime(dtFechaPago.Value.ToString("dd/MM/yyyy")) <= Convert.ToDateTime(Variables.gdFechaSis.ToString("dd/MM/yyyy")))
            {
                bEstado = true;
                msg = "";
                img = Properties.Resources.ok;
            }
            else
            {
                bEstado = true;
                msg = "";
                img = Properties.Resources.ok;

                //if (Convert.ToDateTime(dtFechaPago.Value.ToString("dd/MM/yyyy")) > Convert.ToDateTime(Variables.gdFechaSis.ToString("dd/MM/yyyy")))
                //{
                //    bEstado = false;
                //    msg = "La fecha de pago no puede ser mayor a la fecha actual";
                //    img = Properties.Resources.error;
                //}
                //else if (Convert.ToDateTime(dtFechaPago.Value.ToString("dd/MM/yyyy")) < Convert.ToDateTime(dtFechaSistema.ToString("dd/MM/yyyy")))
                //{
                //    bEstado = false;
                //    msg = "La fecha de pago no puede ser menor a: " + dtFechaSistema.ToString("dd/MM/yyyy");
                //    img = Properties.Resources.error;

                //}
            }
            lbl.Text = msg;
            pb.Image = img;
            return bEstado;
        }
        private void dtFechaPago_ValueChanged(object sender, EventArgs e)
        {
            dtFechaPagoCuota = Convert.ToDateTime(dtFechaPago.Value); 
            estadoFechaPago=fnValidarFecha(erFechaPago,pbFechaPago);
            var res=FunGeneral.fnValidarFechaPago(dtFechaPago, pbFechaPago, 1);
            estadoFechaPago = res.Item1;
            erFechaPago.Text = res.Item2;
            fnLlenadClaseDocumento();


        }

        private void msActializarPago_Click(object sender, EventArgs e)
        {
            lnTipoCon = 1;

            DataGridViewRow filaSeleccionada = dgvCronograma.CurrentRow;
            DataGridViewCell ColumnaSeleccionada = dgvCronograma.CurrentCell;

            Int32 idDetalleCronograma = Convert.ToInt32(filaSeleccionada.Cells[0].Value);

            //lstVehiculoSinRenovar.Add(lstVehiculo.Find(i => i.idVehiculo == idVehiculo));

            clsDetCronogramaEspecifico = lstDetalleCronograma.Find(i => i.idDetalleCronograma == idDetalleCronograma);

            lstDetalleVenta.Clear();
            lstDocumentoVenta.Clear();
            fnGenerarComprobantePago(filaSeleccionada, ColumnaSeleccionada);


        }

        private void tsPagoPendiente_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvCronograma.CurrentRow;
            DataGridViewCell ColumnaSeleccionada = dgvCronograma.CurrentCell;
            String opcion = "PENDIENTE";
            Int32 idDetalleCronograma = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
            DAControlPagos cntPago = new DAControlPagos();
            Boolean Resp = false;
            DialogResult EstadoDialog = MessageBox.Show("Esta seguro que desea realizar la actualización?", "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (EstadoDialog == DialogResult.Yes)
            {
                Resp = cntPago.daActualizarEstados(idDetalleCronograma, opcion,0);
                if (Resp == true)
                {
                    MessageBox.Show("Actualizacion Correcta", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fnObtenerCronogramaEspecifico(CronogramaSeleccionado, 0);
                }
                else
                {
                    MessageBox.Show("Error en el la actualizacion", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
                

        }

        private void tsPagoCorte_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvCronograma.CurrentRow;
            DataGridViewCell ColumnaSeleccionada = dgvCronograma.CurrentCell;
            String opcion = "CORTE";
            Int32 idDetalleCronograma = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
            DAControlPagos cntPago = new DAControlPagos();
            Boolean Resp = false;
            DialogResult EstadoDialog = MessageBox.Show("Esta seguro que desea realizar la actualización?", "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (EstadoDialog == DialogResult.Yes)
            {
                Resp = cntPago.daActualizarEstados(idDetalleCronograma, opcion,0);
                if (Resp == true)
                {
                    MessageBox.Show("Actualizacion Correcta", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fnObtenerCronogramaEspecifico(CronogramaSeleccionado, 0);
                }
                else
                {
                    MessageBox.Show("Error en el la actualizacion", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
                

        }

        private void tsPagovencido_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvCronograma.CurrentRow;
            DataGridViewCell ColumnaSeleccionada = dgvCronograma.CurrentCell;
            String opcion = "VENCIDO";
            Int32 idDetalleCronograma = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
            DAControlPagos cntPago = new DAControlPagos();
            Boolean Resp = false;

            DialogResult EstadoDialog = MessageBox.Show("Esta seguro que desea realizar la actualización?", "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (EstadoDialog == DialogResult.Yes)
            {
                Resp = cntPago.daActualizarEstados(idDetalleCronograma, opcion,0);
                if (Resp == true)
                {
                    MessageBox.Show("Actualizacion Correcta", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fnObtenerCronogramaEspecifico(CronogramaSeleccionado, 0);
                }
                else
                {
                    MessageBox.Show("Error en el la actualizacion", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
                
        }

        private void dgvCronograma_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
                    if (!clickedRow.Selected)
                    {
                        dgvCronograma.CurrentCell = clickedRow.Cells[e.ColumnIndex];

                    }
                    else
                    {
                        var mousePosition = dgvCronograma.PointToClient(Cursor.Position);
                        ctmPagar.Show(dgvCronograma, mousePosition);
                    }

                }
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            fnBuscarCronograma(0, txtBuscar.Text.ToString(), -3, 0);
            frmExportConsultasCronograma frmExport = new frmExportConsultasCronograma();
            frmExport.Inicio(lstClientesBusq,
                "Lista de vehiculos en estado: " 
                + cboEstadopago.Text+", Periodo: "+ lstClientesBusq[0].cDireccion+", Ciclo: "+lstClientesBusq[0].cContactoNom2, 0);
        }
        private void fnActualizarCronograma(DateTime dtIni, DateTime dtFin)
        {
            
            DAControlPagos dtCP = new DAControlPagos();
            List<DetalleCronograma> lstCronogramas = new List<DetalleCronograma>();
            List<DetalleCronograma> lstDetCronAutomatico = new List<DetalleCronograma>();
            List<DetalleCronograma> lstDetCronAutomaticoEsp = new List<DetalleCronograma>();
            try
            {
                String sdtIni = FunGeneral.GetFechaHoraFormato(dtIni, 5);
                String sdtFin = FunGeneral.GetFechaHoraFormato(dtFin, 5);

                lstDetCronAutomatico = dtCP.daBuscarCronogramaActualizarEstados(sdtIni, sdtFin, "ESPV0001", lstDetCronAutomatico, 0);
                String estadoCronograma = "";
                Int32 contadorCorte = 0;
                Int32 stIdCronograma = 0;

                lstDetCronAutomaticoEsp = dtCP.daBuscarCronogramaActualizarEstados(sdtIni, sdtFin, "ESPV0001", lstDetCronAutomatico, 1);
              
                stIdCronograma = 0;

                for (Int32 i = 0; i < lstDetCronAutomatico.Count; i++)
                {
                    contadorCorte = 0;
                    List<DetalleCronograma> clsDetCro = new List<DetalleCronograma>();

                    clsDetCro = lstDetCronAutomaticoEsp.FindAll(r => r.idCronograma == lstDetCronAutomatico[i].idCronograma);


                    for (Int32 j = 0; j < clsDetCro.Count; j++)
                    {
                        

                        //if (lstDetCronAutomatico[i].idCronograma == lstDetCronAutomaticoEsp[j].idCronograma)
                        //{
                        if (clsDetCro[j].estado!= "ESPV0002")
                        {
                            estadoCronograma = "ESPV0001";
                            dtCP.daActualizarEstados(clsDetCro[j].idCronograma, estadoCronograma, 2);

                            break;
                        }
                        else
                        {
                            contadorCorte += 1;
                        }

                    }
                    if (contadorCorte ==12)
                    {
                        estadoCronograma = "ESPV0002";
                        dtCP.daActualizarEstados(lstDetCronAutomatico[i].idCronograma, estadoCronograma, 2);

                    }

                }






            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void btnValidarEstados_Click(object sender, EventArgs e)
        {
            //fnActualizarCronograma(dtpFechaInicialBus.Value, dtpFechaFinalBus.Value);
            //fnBuscarCronogramaAutomatico(dtpFechaInicialBus.Value, dtpFechaFinalBus.Value, "ESPV0001", 0);

            fnBuscarCronogramaAutomatico(FunGeneral.GetFechaHoraFormato(dtpFechaInicialBus.Value, 5), FunGeneral.GetFechaHoraFormato(dtpFechaFinalBus.Value, 5), "ESPV0001", 0);
            MessageBox.Show("Actualizacion exitosa", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCambiarIncumplimiento_Click(object sender, EventArgs e)
        {
            DAControlPagos frm = new DAControlPagos();
            Boolean res = false;
            Boolean estadoActualizar = false;
            List<DetalleCronograma> lstDetCron=new List<DetalleCronograma>();

            for (Int32 i=0;i< lstDetalleCronograma.Count;i++)
            {
                if (lstDetalleCronograma[i].estado!= "CUOTA PAGADA")
                {
                    lstDetCron.Add(lstDetalleCronograma[i]);
                }
                
            }
            for (int i = 0; i < lstDetCron.Count; i++)
            {
                if (i>0)
                {
                    if ((lstDetCron[i].estado == "PAGO PENDIENTE" && lstDetCron[i - 1].estado == "CORTE") || (lstDetCron[i].estado == "CORTE" && lstDetCron[i - 1].estado == "CORTE") || (lstDetCron[i].estado == "CORTE" && lstDetCron[i - 1].estado == "VENCIDO"))
                    {
                        estadoActualizar = true;
                        break;
                    }
                }
                
            }
            Cronograma dcr = lstCronograma.Find(i => i.idCronograma == CronogramaSeleccionado);
            if (dcr.estadoCronograma!= "ESCR0004")
            {
                if (estadoActualizar)
                {
                    DialogResult EstadoDialog = MessageBox.Show("Esta seguro de realizar el cambio de estado!!!\n YA NO SE MOSTRARA EN LA BUSQUEDA DE CRONOGRAMA", "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (EstadoDialog == DialogResult.Yes)
                    {
                        res = frm.daCambiarEstadoCronograma(CronogramaSeleccionado, -1);
                        if (res)
                        {
                            MessageBox.Show("El contrato se actualizo correctamente", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("No se puede realizar la actualizacion -- Comuniquese con el administrador", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else if (dcr.estadoCronograma == "ESCR0004")
            {
                DialogResult EstadoDialog = MessageBox.Show("Esta seguro de realizar el cambio de estado!!!\n EL CRONOGRAMA SE MOSTRARÁ NUEVAMENTE EN LA BUSQUEDA", "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (EstadoDialog == DialogResult.Yes)
                {
                    res = frm.daCambiarEstadoCronograma(CronogramaSeleccionado, -2);
                    if (res)
                    {
                        MessageBox.Show("El contrato se actualizo correctamente", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            

        }

        private void siticoneButton1_Click_1(object sender, EventArgs e)
        {
            fnActualizarCronograma(dtpFechaInicialBus.Value,dtpFechaFinalBus.Value);
        }

        private void btnAniadirADocumento_Click(object sender, EventArgs e)
        {
           Int32 estadoApertura = FunGeneral.fnVerificarApertura(Variables.gnCodUser);
            //MessageBox.Show("Aun en desarrollo espere la proxima version","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            DateTime dtt = FunGeneral.fnUpdateFechas(dtFechaPagoCuota);
            if (estadoApertura==1)
            {
                if (estadoComprabanteP == true && estadoFechaPago == true)
                {
                    fnAniadirADocumento(lstCronoGramasParaDocumentoVenta, Variables.gnCodUser, 0);
                    
                }
                else
                {
                    MessageBox.Show("Por favor complete todo los datos", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else if(estadoApertura==0)
            {
                MessageBox.Show("Por favor Aperture caja para poder registrar ingreos", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                

            }
            else 
            {
                MessageBox.Show("Ya cerraste caja. Por favor Aperture caja para poder registrar ingreos", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }




        }

        private void fnAniadirADocumento(List<DetalleCronograma> dcr,Int32 idusuario,Int32 tipoCon)
        {
            BLControlPagos BL = new BLControlPagos();

            List<DetalleVenta> lstdv = new List<DetalleVenta>();
            DetalleVentaCabecera dcv = new DetalleVentaCabecera();
            List<DocumentoVenta> DocVenta = new List<DocumentoVenta>();
            lstDetalleVenta = fnGenerarPagoPrincipalBloque();

            dcv = fnCalcularCabeceraDetalle(lstDetalleVenta);
            lstDocumentoVenta = fnCargarDocumentoVenta(dcv,1);

            String rutaArchivo = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR\";
            byte[] imageBytes = File.ReadAllBytes(rutaArchivo + "QR\\QrDefecto.png");

            //MemoryStream ms = new MemoryStream(imageBytes);

            frmTipoPago fmr = new frmTipoPago();
            Decimal sumaPrimerPago = lstDetalleVenta.Sum(i => i.Importe);
            fmr.Inicio(-1, lstDocumentoVenta, lstDetalleVenta, "S/.");

            //Consultas.frmVPVenta frmVenta = new Consultas.frmVPVenta();
            //frmVenta.Inicio(lstDocumentoVenta, lstDetalleVenta, imageBytes, -1);


            Boolean resp = false;
            resp= BL.blAniadirADocumentoVenta(dcr, idusuario, tipoCon);
            
            cboCronograma.SelectedIndex = 0;
            cboCronograma.SelectedValue = CronogramaSeleccionado;
            //fnLimpiarSeleccion();
            obtenerNumeroDeItems();
            if (resp)
            {

            }

        }
        private void dgvCronograma_Click(object sender, EventArgs e)
        {
            //aca debe irCodigo
            //dgvCronograma.Rows[9].Cells[2].Value = 0;
        }

        private void lblNumDocumentos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void fnOcultarDatosParaDocumentoVenta()
        {
            if (pnDocumentos.Visible == true)
            {
                pnDocumentos.Visible = false;
                //lblNumDocumentos.Width = 161;
                //lblNumDocumentos.Location = new Point(877, (328 + tabControl1.TabPages[1].AutoScrollPosition.Y));
            }
            else
            {
                pnDocumentos.Visible = true;
                //lblNumDocumentos.Width = 396;
                pnDocumentos.Width = 300;
                dgvDatosDocumentosVenta.Width = 298;
                dgvDatosDocumentosVenta.Location = new Point(1, 1);
                //lblNumDocumentos.Location = new Point(642, (328 + tabControl1.TabPages[1].AutoScrollPosition.Y));
            }
            pnDocumentos.Location = new Point(727, (391 + tabControl1.TabPages[1].AutoScrollPosition.Y));
            pnDocumentos.BorderColor = Variables.ColorEmpresa;
            pnDocumentos.BorderThickness=1;

        }
        private void lblNumDocumentos_LinkClicked(object sender, EventArgs e)
        {
            fnOcultarDatosParaDocumentoVenta();
        }

        private void btnContadorItems_Click(object sender, EventArgs e)
        {
            fnOcultarDatosParaDocumentoVenta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsUtil cls = new clsUtil();
            cls.ObtenerQr("IHN001-000000587", "ACTA", "IHN001-000000587");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //EmitirFactura env = new EmitirFactura();
            //env.EmitirNotaCredito(clsCliente, lstDetalleVenta, clsDocumentoVenta);
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvCronograma_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            String nombreCabecera = dgv.Columns[e.ColumnIndex].HeaderText;

            if (nombreCabecera == "ESTADO")
            {

                if (e.Value.ToString().Contains("✅"))
                {
                    e.CellStyle.ForeColor = Variables.ColorSuccess;
                }
                else if (e.Value.ToString().Contains("❗"))
                {
                    e.CellStyle.ForeColor = Color.DarkOrange;
                }
                else if (e.Value.ToString().Contains("🚫"))
                {
                    e.CellStyle.ForeColor = Color.Purple;

                }
                else if (lstDetalleCronograma[e.RowIndex].codEstado== "ESPV0006")
                {
                    e.CellStyle.ForeColor = Color.OrangeRed;

                }
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
            if (dgv.Columns[e.ColumnIndex].Name == "dttFechapago" )
            {
                if (dgv.Rows[e.RowIndex].Cells[12].Value.ToString().Contains("✅"))
                {
                    e.CellStyle.BackColor = Variables.ColorSuccess;
                    e.CellStyle.ForeColor = Color.WhiteSmoke;
                }
                else if(dgv.Rows[e.RowIndex].Cells[12].Value.ToString().Contains("🕖"))
                {
                    e.CellStyle.BackColor = Color.Coral;
                    e.CellStyle.ForeColor = Color.WhiteSmoke;
                }
            }
        }

        private void msPagarCuota_Click(object sender, EventArgs e)
        {
            lnTipoCon = 0;
            DataGridViewRow filaSeleccionada = dgvCronograma.CurrentRow;
            DataGridViewCell ColumnaSeleccionada = dgvCronograma.CurrentCell;
            
            Int32 idDetalleCronograma = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
            //lstVehiculoSinRenovar.Add(lstVehiculo.Find(i => i.idVehiculo == idVehiculo));

            clsDetCronogramaEspecifico = lstDetalleCronograma.Find(i => i.idDetalleCronograma == idDetalleCronograma);

            lstDetalleVenta.Clear();
            lstDocumentoVenta.Clear();
            Int32 estadoApertura = FunGeneral.fnVerificarApertura(Variables.gnCodUser);
            if (estadoApertura==1)
            {
                fnGenerarComprobantePago(filaSeleccionada, ColumnaSeleccionada);
            }
            else if(estadoApertura==0)
            {
                MessageBox.Show("Por favor Aperture caja para poder registrar ingreos", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                //lstDetalleVenta = fnGenerarPagoPrincipal(filaSeleccionada.Index, ColumnaSeleccionada.ColumnIndex);

                //Cargo clsCargo1 = lstDocumentoVentaEmitir.Find(i => i.cCodTab == cboComprobanteP.SelectedValue.ToString());
                //EmitirFactura emf = new EmitirFactura();

                //emf.EmitirFacturasContado(clsCliente, lstDetalleVenta, clsCargo1);
                //String rutaArchivo = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR";
                //String nombreQR = clsCliente.cDocumento + "-" + clsCargo1.nValor1 + "-" + clsCargo1.SerieDoc + "-" + FunGeneral.generarCorrelativoDocumento(Convert.ToInt32(clsCargo1.nValor2));
                //bitmap.Save(rutaArchivo + "QR\\" + nombreQR + ".png");
                //byte[] imageBytes = File.ReadAllBytes(rutaArchivo + "\\QR\\" + nombreQR + ".png");

                //MemoryStream ms = new MemoryStream(imageBytes);

                //Consultas.frmVPVenta frmVenta = new Consultas.frmVPVenta();
                //frmVenta.Inicio(lstDocumentoVenta, lstDetalleVenta, ms, -1);
                lstDetalleVenta = fnGenerarPagoPrincipal(filaSeleccionada.Index, ColumnaSeleccionada.ColumnIndex);
            }
            else
            {
                MessageBox.Show("Ya  cerraste caja. Por favor Aperture caja para poder registrar ingreos", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }




        }

        private void fnGenerarComprobantePago(DataGridViewRow filaSeleccionada, DataGridViewCell ColumnaSeleccionada)
        {
            frmTipoPago frmTipoPago = new frmTipoPago();
            if (estadoComprabanteP==true && estadoFechaPago==true)
            {
                Cronograma clsCronomaEspecifico = new Cronograma();
                
                Int32 indice= lstCronograma.IndexOf(lstCronograma.Find(i => i.idCronograma == CronogramaSeleccionado));
               
               
                if (lstCronograma.Count > 1)
                {
                    if (filaSeleccionada.Index==0)
                    {
                        if (lstCronograma[indice+1].estado == "ESPV0002")
                        {
                            DialogResult EstadoDialog = MessageBox.Show("Es correcta la fecha de pago?\n\n" + dtFechaPago.Value.ToString(), "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (EstadoDialog == DialogResult.Yes)
                            {
                                lstDetalleVenta = fnGenerarPagoPrincipal(filaSeleccionada.Index, ColumnaSeleccionada.ColumnIndex);
                                clsDetallecabecera = fnCalcularCabeceraDetalle(lstDetalleVenta);
                                lstDocumentoVenta = fnCargarDocumentoVenta(clsDetallecabecera,0);

                                String rutaArchivo = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR\";
                                byte[] imageBytes = File.ReadAllBytes(rutaArchivo + "QR\\QrDefecto.png");

                                //MemoryStream ms = new MemoryStream(imageBytes);

                                //Consultas.frmVPVenta frmVenta = new Consultas.frmVPVenta();
                                //frmVenta.Inicio(lstDocumentoVenta, lstDetalleVenta, imageBytes, -1);
                                
                                frmTipoPago.Inicio(-1, lstDocumentoVenta, lstDetalleVenta, lstDetalleVenta[0].cSimbolo);

                                fnObtenerCronogramaEspecifico(CronogramaSeleccionado, 0);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Aun no puede generar este pago ! \n porque falta Completar los pagos del contrato anterior !", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        DetalleCronograma clsDetCron = lstDetalleCronograma.Find(i=>i.estado=="VENCIDO");
                        if (clsDetCron is DetalleCronograma && lstDetalleCronograma[filaSeleccionada.Index].estado != "VENCIDO")
                        {
                            MessageBox.Show("Aun no puede generar este pago ! \n porque tiene una cuota VENCIDA !", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (lstDetalleCronograma[filaSeleccionada.Index - 1].estado == "PAGO PENDIENTE")
                            {
                                MessageBox.Show("Aun no puede generar este pago ! \n porque falta la cuota anterior !", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                DialogResult EstadoDialog = MessageBox.Show("Es correcta la fecha de pago?\n\n" + dtFechaPago.Value.ToString(), "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (EstadoDialog == DialogResult.Yes)
                                {
                                    lstDetalleVenta = fnGenerarPagoPrincipal(filaSeleccionada.Index, ColumnaSeleccionada.ColumnIndex);
                                    clsDetallecabecera = fnCalcularCabeceraDetalle(lstDetalleVenta);
                                    lstDocumentoVenta = fnCargarDocumentoVenta(clsDetallecabecera, 0);

                                    String rutaArchivo = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR\";
                                    byte[] imageBytes = File.ReadAllBytes(rutaArchivo + "QR\\QrDefecto.png");

                                    //MemoryStream ms = new MemoryStream(imageBytes);

                                    //Consultas.frmVPVenta frmVenta = new Consultas.frmVPVenta();
                                    //frmVenta.Inicio(lstDocumentoVenta, lstDetalleVenta, imageBytes, -1);
                                    frmTipoPago.Inicio(-1, lstDocumentoVenta, lstDetalleVenta, lstDetalleVenta[0].cSimbolo);
                                    //frmTipoPago.Inicio(-1, lstDocumentoVenta, lstDetalleVenta, lstDetalleVenta[0].cSimbolo);

                                    fnObtenerCronogramaEspecifico(CronogramaSeleccionado, 0);
                                }



                            }
                        }
                        
                    }

                }
                else
                {
                    DialogResult EstadoDialog = MessageBox.Show("Es correcta la fecha de pago?\n\n" + dtFechaPago.Value.ToString(), "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (EstadoDialog == DialogResult.Yes)
                    {
                        lstDetalleVenta = fnGenerarPagoPrincipal(filaSeleccionada.Index, ColumnaSeleccionada.ColumnIndex);
                        clsDetallecabecera = fnCalcularCabeceraDetalle(lstDetalleVenta);
                        lstDocumentoVenta = fnCargarDocumentoVenta(clsDetallecabecera,0);

                        String rutaArchivo = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR\";
                        byte[] imageBytes = File.ReadAllBytes(rutaArchivo + "QR\\QrDefecto.png");

                        //MemoryStream ms = new MemoryStream(imageBytes);

                        //Consultas.frmVPVenta frmVenta = new Consultas.frmVPVenta();
                        //frmVenta.Inicio(lstDocumentoVenta, lstDetalleVenta, imageBytes, -1);
                        frmTipoPago.Inicio(-1, lstDocumentoVenta, lstDetalleVenta, lstDetalleVenta[0].cSimbolo);

                        fnObtenerCronogramaEspecifico(CronogramaSeleccionado, 0);
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Por favor complete todo los datos", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void cboComprobanteP_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboComprobanteP, erComprobanteP, imgComprobanteP);
            estadoComprabanteP = result.Item1;
            msgComprabanteP = result.Item2;
            if (estadoComprabanteP==true)
            {
                fnLlenadClaseDocumento();
            }
        }
        private void fnLlenadClaseDocumento()
        {
            Int32 j = 0;
            foreach (Cargo item in lstDocumentoVentaEmitir)
            {
                lstDocumentoVentaEmitir[j].dFechaPago = dtFechaPagoCuota;
                lstDocumentoVentaEmitir[j].dFechaVenta = dtFechaPagoCuota;
                j++;
            }
            if (cboComprobanteP.Items.Count > 0)
            {
                clsDocumentoVenta = lstDocumentoVentaEmitir.Find(i => i.cCodTab == cboComprobanteP.SelectedValue.ToString());
            }


        }
    }
}
