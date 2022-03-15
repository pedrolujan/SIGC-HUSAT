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

namespace wfaIntegradoCom.Procesos
{
    public partial class frmControlPagoVenta : Form
    {
        public frmControlPagoVenta()
        {
            InitializeComponent();
        }
        Boolean EstadoCarga = false;

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
        static Int32 CronogramaSeleccionado = 0;
        static Boolean estDescuento = false;
        Boolean estPagoCuota = false;
        static Int32 lnTipoCon = 0;
        static Int32 tabInicio;
        static Int32 diaCicloPago = 0;

        static DateTime dtFechaPagoCuota = Variables.gdFechaSis;
        Boolean estadoComprabanteP, estadoFechaPago, estadoDescuento, estadoMoneda;
        String msgComprabanteP, msgMoneda, msgDescuento;
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
            DateTime dtFIni = dtpFechaInicialBus.Value;
            DateTime dtFFin = dtpFechaFinalBus.Value;
            List<Cronograma> lstCrngr = new List<Cronograma>();
            String estadoPago = Convert.ToString(cboEstadopago.SelectedValue);
            dtResult =obControPagos.blBuscarCronograma(HabilitarFechas, dtFIni, dtFFin, pcBuscar, tipoCon,  TipConPaginacion,  numPagina, estadoPago);
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
                        estado= Convert.ToString(dtResult.Rows[i][5])
                    }) ;
                }

                cboCronograma.ValueMember = "idCronograma";
                cboCronograma.DisplayMember = "cDescripcion";
                cboCronograma.DataSource = lstCrngr;
                lstCronograma = lstCrngr;
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


            if (Indice == true)
            {
                String estadoCuota = lstDetalleCronograma[fila].estado == "CUOTA PAGADA" ? "✅ " + lstDetalleCronograma[fila].estado : "❗ " + lstDetalleCronograma[fila].estado;
                String strDescuento = "";
                if (lstDetalleCronograma[fila].strTipoDescuento == "PORCENTUAL" && lstDetalleCronograma[fila].descuento != 0)
                {
                    strDescuento = lstDetalleCronograma[fila].descuento + " % ";
                }
                else if (lstDetalleCronograma[fila].strTipoDescuento == "DECIMAL" && lstDetalleCronograma[fila].descuento != 0)
                {
                    strDescuento = clsMoneda.cSimbolo + " " + lstDetalleCronograma[fila].descuento;
                }
                Double DescuentoPrecio = fnConvertirATipoDescuento(lstDetalleCronograma[fila].precioUnitario, lstDetalleCronograma[fila].strTipoDescuento, lstDetalleCronograma[fila].descuento);
                lstDetalleCronograma[fila].descuentoPrecio = DescuentoPrecio;
                Double ImporteTotal = (lstDetalleCronograma[fila].precioUnitario - DescuentoPrecio);
                lstDetalleCronograma[fila].total = ImporteTotal;
                dgvCronograma.Rows[fila].Cells[0].Value = lstDetalleCronograma[fila].idDetalleCronograma;
                dgvCronograma.Rows[fila].Cells[1].Value = fila + 1;
                dgvCronograma.Rows[fila].Cells[2].Value = lstDetalleCronograma[fila].periodoInicio.ToString("dd/MM/yyyy");
                dgvCronograma.Rows[fila].Cells[3].Value = lstDetalleCronograma[fila].periodoFinal.ToString("dd/MM/yyyy");
                dgvCronograma.Rows[fila].Cells[4].Value = lstDetalleCronograma[fila].fechaEmision.ToString("dd/MM/yyyy");

                dgvCronograma.Rows[fila].Cells[5].Value = lstDetalleCronograma[fila].fechaVencimiento.ToString("dd/MM/yyyy");
                dgvCronograma.Rows[fila].Cells[6].Value = lstDetalleCronograma[fila].fechaPago.ToString("dd/MM/yyyy") == "01/01/1900" ? "" : lstDetalleCronograma[fila].fechaPago.ToString("dd/MM/yyyy");
                dgvCronograma.Rows[fila].Cells[7].Value = clsMoneda.cSimbolo + ' ' + string.Format("{0:0.00}", lstDetalleCronograma[fila].precioUnitario);
                dgvCronograma.Rows[fila].Cells[8].Value = strDescuento != "" ? strDescuento : "" + lstDetalleCronograma[fila].descuento;
                dgvCronograma.Rows[fila].Cells[9].Value = clsMoneda.cSimbolo + ' ' + string.Format("{0:0.00}", lstDetalleCronograma[fila].descuentoPrecio);
                dgvCronograma.Rows[fila].Cells[10].Value = clsMoneda.cSimbolo + ' ' + string.Format("{0:0.00}", lstDetalleCronograma[fila].total);
                dgvCronograma.Rows[fila].Cells[11].Value = estadoCuota;
               
            }
            else
            {
                Int32 cantDiasMes = 0;
                Int32 cantDiasSum = 0;

                dgvCronograma.Rows.Clear();
                for (Int32 i = 0; i < lstDetalleCronograma.Count; i++)
                {
                    
                    DateTime dtFechaTemp = lstDetalleCronograma[i].periodoInicio.AddMonths(1);
                    cantDiasMes = DateTime.DaysInMonth(lstDetalleCronograma[i].periodoInicio.Year, lstDetalleCronograma[i].periodoInicio.Month);
                    cantDiasSum = DateTime.DaysInMonth(dtFechaTemp.Year, dtFechaTemp.Month);
                    Int32 diasASumar = 0;
                    Int32 diaNuevaFecha = 0;
                    Int32 restarFinal = 0;
                    if (cantDiasSum <= 29 && dtFechaTemp.Month==2 && diaCicloPago!=15)
                    {
                        diasASumar = cantDiasSum;
                    }
                    else if(cantDiasMes<=29 && lstDetalleCronograma[i].periodoInicio.Month==2)
                    {
                        diasASumar = cantDiasSum>30?(30-1):cantDiasSum -1;

                    }
                    else
                    {
                        diasASumar = cantDiasMes - 1;

                    }

                    diaNuevaFecha = cantDiasMes < diaCicloPago ? cantDiasMes : diaCicloPago;

                    DateTime fechaInicio = Convert.ToDateTime(diaNuevaFecha + "/" +( lstDetalleCronograma[i].periodoInicio.Month)+"/"+ lstDetalleCronograma[i].periodoInicio.Year);
                    lstDetalleCronograma[i].periodoInicio = fechaInicio;
                    if (lstDetalleCronograma[i].periodoInicio.Month == 2 && diaCicloPago == 15)
                    {
                        restarFinal = 30 - cantDiasMes;
                    }
                    else
                    {
                        restarFinal = 0;
                    }
                    DateTime fechaFinal = fechaInicio.AddDays((diasASumar- restarFinal));
                    lstDetalleCronograma[i].periodoFinal = fechaFinal;
                    lstDetalleCronograma[i].fechaEmision = fechaFinal.AddDays(1);
                    DateTime fechaVencimiento = fechaFinal.AddDays(7);
                    lstDetalleCronograma[i].fechaVencimiento = fechaVencimiento;
                    

                    String strDescuento = "";
                    if (lstDetalleCronograma[i].strTipoDescuento == "PORCENTUAL" && lstDetalleCronograma[i].descuento != 0)
                    {
                        strDescuento = lstDetalleCronograma[i].descuento + " % ";
                    }
                    else if (lstDetalleCronograma[i].strTipoDescuento == "DECIMAL" && lstDetalleCronograma[i].descuento != 0)
                    {
                        strDescuento = clsMoneda.cSimbolo + " " + lstDetalleCronograma[i].descuento;
                    }

                    String estadoCuota = lstDetalleCronograma[i].estado == "CUOTA PAGADA" ? "✅ "+ lstDetalleCronograma[i].estado : "❗ "+ lstDetalleCronograma[i].estado;
                    Double DescuentoPrecio = fnConvertirATipoDescuento(lstDetalleCronograma[i].precioUnitario, lstDetalleCronograma[i].strTipoDescuento, lstDetalleCronograma[i].descuento);
                    lstDetalleCronograma[i].descuentoPrecio = DescuentoPrecio;
                    Double ImporteTotal = (lstDetalleCronograma[i].precioUnitario - DescuentoPrecio);
                    lstDetalleCronograma[i].total = ImporteTotal;
                    dgvCronograma.Rows.Add(
                       lstDetalleCronograma[i].idDetalleCronograma,
                       i + 1,
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
                }
            }           

          tabControl1.TabPages[1].AutoScrollPosition=new Point(0,342);
            //tabControl1.TabPages[1].AutoScroll = false;
            //dgvCronograma.Rows[0].Visible = false;
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
            Int32 filas = 10;
            if (dtt.Rows.Count>0)
            {
                Int32 y;


                if (TipConPaginacion == -1)
                {
                    y = 0;
                }
                else
                {
                    tabInicio = (numPagina - 1) * filas;
                    y = tabInicio;
                }

                dgv.Rows.Clear();
                Int32 totalResultados = dtt.Rows.Count;
                for (Int32 i=0;i< dtt.Rows.Count; i++)
                {
                    String estadoCuota = "";
                    String PasoDias = "";
                    Int32 faltaDias = 0;
                    Int32 restaAnio = 0;
                    Int32 restaMeses = 0;
                    Int32 diaNuevaFecha=0;
                    String cDias = "";
                    String tiempoTranscurrido = "";
                    
                    Int32 cicloPago = Convert.ToInt32(dtt.Rows[i][11]);
                    diaCicloPago = cicloPago;

                    DateTime dtFechActual = Convert.ToDateTime(Variables.gdFechaSis.ToString("dd/MM/yyyy"));
                    TimeSpan tiket = dtFechActual - dtFechActual.AddDays(-1);
                    Int32 cantDiasMesActual = DateTime.DaysInMonth(dtFechActual.Year, dtFechActual.Month);

                    DateTime dtFechaDePago = Convert.ToDateTime(Convert.ToDateTime(dtt.Rows[i][4].ToString()).ToString("dd/MM/yyyy"));
                    diaNuevaFecha = cantDiasMesActual < diaCicloPago ? cantDiasMesActual : diaCicloPago;

                    DateTime dtFechaPagoCronograma = Convert.ToDateTime(diaNuevaFecha + "/" +(dtFechaDePago.Month) +"/"+ dtFechaDePago.Year);

                    Int32 cantDiasMesPago = DateTime.DaysInMonth(dtFechaDePago.Year, dtFechaDePago.Month);
                    if (dtFechActual > dtFechaPagoCronograma)
                    {
                        tiket = dtFechActual - dtFechaPagoCronograma;
                    }
                    else
                    {
                         tiket = dtFechaPagoCronograma-dtFechActual ;
                    }

                    DateTime totalTime = new DateTime(tiket.Ticks);
                    restaAnio = totalTime.Year - 1;
                    restaMeses = totalTime.Month - 1;
                    faltaDias = Convert.ToInt32(totalTime.Day - 1);




                    Int32 numMesPago = Convert.ToInt32(Convert.ToDateTime(dtt.Rows[i][4].ToString()).ToString("MM"));
                    Int32 diaFechaPago = Convert.ToInt32(Convert.ToDateTime(dtt.Rows[i][4].ToString()).ToString("dd"));
                    Int32 numAñoPago = Convert.ToInt32(Convert.ToDateTime(dtt.Rows[i][4].ToString()).ToString("yyyy"));
                    TimeSpan age = dtFechActual - dtFechActual.AddDays(-1);
                    Int32 numDias = DateTime.DaysInMonth(numAñoPago, numMesPago);
                    Int32 NumDiasSumar = (Math.Abs(cicloPago - diaFechaPago));
                    cicloPago = numDias < cicloPago ? numDias : cicloPago;
                    Int32 numDiasrestar = 0;
                    Int32 numRestarADIAs = 0;
                    if (numDias<=29)
                    {
                         //numDiasrestar = cicloPago - NumDiasSumar;
                    }
                    else
                    {
                        numDiasrestar=0;
                    }
                 
                  
                    DateTime fechaPagoCiclo = dtFechaDePago.AddDays(Math.Abs(NumDiasSumar));

                    if (Convert.ToString(dtt.Rows[i][10])== "PAGO PENDIENTE")
                    {
                        
                        if (dtFechActual > fechaPagoCiclo)
                        {
                            age = dtFechActual - fechaPagoCiclo;
                            numRestarADIAs = 1;
                        }
                        else
                        {
                            age = fechaPagoCiclo - dtFechActual ;
                            numRestarADIAs= 1;
                            //numDiasrestar = 0;
                        }

                        TimeSpan Diff_dates = dtFechActual.Subtract(fechaPagoCiclo);

                        //DateTime totalTime = new DateTime(age.Ticks);                      
                        //restaAnio = totalTime.Year - 1;
                        //restaMeses = totalTime.Month - 1;
                        //faltaDias = Convert.ToInt32(totalTime.Day- numRestarADIAs);


                        cDias = faltaDias == 1 ? " Dia " : " Dias ";
                        if (dtFechaPagoCronograma < dtFechActual)
                        {
                            if (restaAnio>0)
                            {
                                tiempoTranscurrido = "\n❌ Retraso ( " + restaAnio + " años " + restaMeses + " Meses " + faltaDias+" )"+cDias;

                            }else if (restaMeses>0)
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
                                tiempoTranscurrido = "\n✅ Aun tienes ( " + restaMeses + " Meses " + faltaDias + " )" + cDias+ " para cobrar";

                            }
                            else if (faltaDias>10)
                            {
                                tiempoTranscurrido = "\n❗ Aun tienes ( " +faltaDias + " )" + cDias+ " para cobrar";

                            }
                            else
                            {
                                if (faltaDias==0)
                                {
                                    tiempoTranscurrido = "\n‼ El dia de pago es hoy "+ dtFechActual.ToString("dd/MMM");

                                }
                                else
                                {
                                    tiempoTranscurrido = "\n‼ Solo tienes ( " + faltaDias + " )" + cDias+ " para cobrar";

                                }
                            }

                        }
                            estadoCuota = FunGeneral.FormatearCadenaTitleCase(Convert.ToString(dtt.Rows[i][10])) + tiempoTranscurrido;

                    }
                    else
                    {
                        
                        tiempoTranscurrido = "\n✅ El ( " + Convert.ToDateTime(dtt.Rows[i][13]).ToString("dd/MMM/yyyy") + " )";
                        estadoCuota = FunGeneral.FormatearCadenaTitleCase(Convert.ToString(dtt.Rows[i][10])) + tiempoTranscurrido;

                    }


                    dgv.Rows.Add(
                        dtt.Rows[i][1],
                        dtt.Rows[i][2],
                        dtt.Rows[i][12],
                        dtFechaDePago.ToString("dd/MM/yyyy"),
                        dtt.Rows[i][5],
                        dtt.Rows[i][6],
                        dtt.Rows[i][7],
                        dtt.Rows[i][8],
                        Convert.ToInt32(dtt.Rows[i][11]),
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

                
                //tabControl1.TabPages[0].AutoScroll = false;
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
                EstadoCarga = false;
                Boolean bResult = false;
              
                dtFechaPago.Value = Variables.gdFechaSis;
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));
                gbBuscarListaVentas.Enabled = false;
                CronogramaSeleccionado = 0;
                frmRegistrarVenta frmRV = new frmRegistrarVenta();
                fnLLenarMoneda(cboMoneda, 0, false);
                bResult = frmRV.fnLlenarTipoDescuento(0, cboTipoDescuentoPrecios, false);
                FunGeneral.fnLlenarTablaCod(cboEstadopago, "ESPV");
                cboEstadopago.SelectedValue = "ESPV0001";
                //cboEstadopago.Enabled = false;
                if (!bResult)
                {
                    MessageBox.Show("Error al Tipo Descuento", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                estDescuento = false;
                fnHabilitarDescuento(false);
                cboCronograma.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboComprobanteP.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
                cboMoneda.MouseWheel += new MouseEventHandler(cboCronograma_MouseWheel);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                EstadoCarga = true;
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
            BLTipoTarifa objBlTipTarifa = new BLTipoTarifa();
            BLCiclo objCiclo = new BLCiclo();
            BLTipoCliente objTipoCliente = new BLTipoCliente();
            lstDetalleCronograma.Clear();
            clsVentaGeneral.codigoVenta = Convert.ToString(dtResult.Rows[0][24]);
            clsTarifa = objBlTipTarifa.blDevolverPreciosPagosMensuales(Convert.ToInt32(dtResult.Rows[0][1]), Convert.ToString(dtResult.Rows[0][24]), Convert.ToInt32(dtResult.Rows[0][33]));
            cboMoneda.SelectedValue = clsTarifa.IdMoneda;
            clsCiclo.IdCiclo = Convert.ToInt32(dtResult.Rows[0][17]);           
           
            lstCiclo = objCiclo.blDevolverCiclo(Convert.ToInt32(dtResult.Rows[0][17]), false);

            clsVehiculo.idVehiculo= Convert.ToInt32(dtResult.Rows[0][3]);
            clsVehiculo.vPlaca= Convert.ToString(dtResult.Rows[0][4]);
            clsVehiculo.Observaciones= Convert.ToString(dtResult.Rows[0][5]);

            clsCliente.cApePat = dtResult.Rows[0][6].ToString();
            clsCliente.cApeMat = dtResult.Rows[0][7].ToString();
            clsCliente.cNombre = dtResult.Rows[0][8].ToString();
            clsCliente.cDireccion = dtResult.Rows[0][9].ToString();
            clsCliente.cContactoNom1 = dtResult.Rows[0][10].ToString();
            clsCliente.cTiDo = Convert.ToInt32(dtResult.Rows[0][11]);
            clsCliente.cDocumento= Convert.ToString(dtResult.Rows[0][13]);

            Mantenedores.frmRegistrarVenta.fnLlenarComprobante(cboComprobanteP, "DOVE", clsCliente.cTiDo, 0);
            lstTD = objTipoCliente.blDevolverDocumentoDeTipoCliente(Convert.ToInt32(dtResult.Rows[0][12]),"1", false);

            txtDatosCliente.Text = Convert.ToString(clsCliente.cNombre+' '+ clsCliente.cApePat+' '+ clsCliente.cApeMat);
            txtPlacaVehiculo.Text = clsVehiculo.vPlaca;
            txtDatosVehiculo.Text = clsVehiculo.Observaciones;
            txtTarifa.Text = Convert.ToString(dtResult.Rows[0][14]);
            txtTipoventa.Text = Convert.ToString(dtResult.Rows[0][15]);
            txtPlan.Text = Convert.ToString(dtResult.Rows[0][16]);
            clsVentaGeneral.codigoVenta= Convert.ToString(dtResult.Rows[0][24]);

            txtfechaoriginal.Text = Convert.ToDateTime(dtResult.Rows[0][31]).ToString("dd/MM/yyyy");
            diaCicloPago = Convert.ToInt32(dtResult.Rows[0][27]);


            for (Int32 i=0; i< dtResult.Rows.Count;i++)
            {
                lstDetalleCronograma.Add(new DetalleCronograma
                {
                    idDetalleCronograma = Convert.ToInt32(dtResult.Rows[i][0]),
                    fechaRegistro = Convert.ToDateTime(dtResult.Rows[i][18]),
                    periodoInicio = Convert.ToDateTime(dtResult.Rows[i][19]),
                    periodoFinal = Convert.ToDateTime(dtResult.Rows[i][20]),
                    fechaVencimiento = Convert.ToDateTime(dtResult.Rows[i][21]),
                    fechaEmision = Convert.ToDateTime(dtResult.Rows[i][25]),
                    fechaPago = Convert.ToDateTime(dtResult.Rows[i][26]),
                    precioUnitario = clsTarifa.PrecioPlan,
                    descuento = Convert.ToDouble(dtResult.Rows[i][28]),
                    //descuentoCantidad = Convert.ToDouble(dtResult.Rows[i][28]),
                    descuentoPrecio = Convert.ToDouble(dtResult.Rows[i][29]),
                    total = Convert.ToInt32(dtResult.Rows[i][30]) == 0 ? clsTarifa.PrecioPlan : Convert.ToDouble(dtResult.Rows[i][30]),
                    estado = Convert.ToString(dtResult.Rows[i][23]),
                    idDetallePago=Convert.ToInt32(dtResult.Rows[i][32]),
                    strTipoDescuento = Convert.ToString(dtResult.Rows[i][34])

                }) ;


            }
            fnCargarTablaLista(false,0,0);
            
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
            String Placa = Convert.ToString(dgvListaVentas.CurrentRow.Cells[4].Value);

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
        private void dgvCronograma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCronograma.Columns["btnPagar"].Index && e.RowIndex >= 0)
            {
                if (dgvCronograma.Rows[e.RowIndex].Cells[e.ColumnIndex-1].Value.ToString().Contains("✅"))
                {
                    cmsPagoCuotas.Items[0].Visible = false;
                    cmsPagoCuotas.Items[1].Visible = true;
                }                
                else
                {
                    cmsPagoCuotas.Items[1].Visible = false;
                    cmsPagoCuotas.Items[0].Visible = true;
                }

                var mousePosition = dgvCronograma.PointToClient(Cursor.Position);
                cmsPagoCuotas.Show(dgvCronograma, (803), mousePosition.Y);
            }else if (e.ColumnIndex == dgvCronograma.Columns["btnImprimir"].Index && e.RowIndex >= 0)
            {
                if (lstDetalleCronograma[e.RowIndex].estado== "CUOTA PAGADA")
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
        private void fnPagarCuota()
        {
            Consultas.frmVPVenta frmVenta = new Consultas.frmVPVenta();
        }
        private Double fnConvertirATipoDescuento(Double precioOriginal, String tipodescuento, Double descuento)
        {
            Double precioDescuento;
            if (tipodescuento == "PORCENTUAL")
            {
                precioDescuento = (precioOriginal * descuento) / 100;
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

            double pagoPlan = clsTarifa.PrecioPlan;
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
                "Cuota "+lstDetalleCronograma[fila].fechaEmision.ToString("MMMM  yyyy")+" - Plan "+txtPlan.Text
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
                Importe = lstDetalleCronograma[fila].total,
                cSimbolo = clsMoneda.cSimbolo
            }) ;



            return lstDetV;
        }
        private DetalleVentaCabecera fnCalcularCabeceraDetalle(List<DetalleVenta> lstDV)
        {
            DetalleVentaCabecera clsDVC = new DetalleVentaCabecera();
            DetalleVenta dvMensual = new DetalleVenta();

            clsDVC.Total = lstDV.Sum(item => item.Importe);
            clsDVC.IGV = (clsDVC.Total * 0.18);
            clsDVC.SubTotal = clsDVC.Total - clsDVC.IGV;
            clsDVC.SimboloMoneda = clsMoneda.cSimbolo;
            clsDVC.NombreDocumento = Convert.ToString(cboComprobanteP.Text);
            clsDVC.CodDocumento = Convert.ToString(cboComprobanteP.SelectedValue);
            clsDVC.lstDetalleVenta = lstDV;
           
            return clsDVC;
        }
        public void fnCambiarEstadoVenta(bool estado)
        {
            estPagoCuota = estado;
            List<xmlDocumentoVentaGeneral> xmlDocumentoVenta = new List<xmlDocumentoVentaGeneral>();
            if (estPagoCuota == true)
            {
                clsCronograma = lstCronograma.Find(i =>i.idCronograma== CronogramaSeleccionado);
                lstPagosTrand[0].idMoneda = clsMoneda.idMoneda;
                claseControlPagos = new ControlPagos
                {
                    fechaRegistro = Variables.gdFechaSis,
                    fechaPago=dtFechaPagoCuota,
                    fechaVenta= clsDetCronogramaEspecifico.fechaRegistro,
                    claseCliente = clsCliente,
                    claseCronograma = clsCronograma,
                    listaDetalleCronograma = lstDetalleCronograma,
                    claseDetalleCronograma= clsDetCronogramaEspecifico,
                    claseVehiculo = clsVehiculo,
                    listaPagosTrandiaria = lstPagosTrand,
                    claseTarifa=clsTarifa,
                    listaDocumentoVenta=lstDocumentoVenta,
                    listaDetalleVenta=lstDetalleVenta,
                    idUsuario=Variables.gnCodUser,
                    idCiclo=1
                    

                };
                xmlDocumentoVenta.Add(new xmlDocumentoVentaGeneral
                {
                    xmlDocumentoVenta = lstDocumentoVenta,
                    xmlDetalleVentas = lstDetalleVenta,
                });
                fnGuardarPagoCuota(claseControlPagos, xmlDocumentoVenta, lnTipoCon);
                
            }
            else
            {
                //MessageBox.Show("Todo anulado no se generará el pago");
            }
        }
        private void fnGuardarPagoCuota(ControlPagos ctp,List<xmlDocumentoVentaGeneral> lstDV, Int32 tipoCon)
        {
            obControPagos = new BLControlPagos();
            Boolean bResult = false;
            bResult=obControPagos.blGuardarPagoCuota(ctp, lstDV, tipoCon);
            String strTipo = tipoCon == 0 ? "Guardado" : "Actualizado";
            if (bResult)
            {
                MessageBox.Show("Págo "+ strTipo + " Correctamente ✅", "Informacion ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                chkHabilitarDescuentoP.Checked = false;
            }
            else
            {
                MessageBox.Show("Error al "+ strTipo + " Págo ❌ \n -> Comunique al administrador", "Informacion ❌", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public static void fnRecuperarTipoPago(List<Pagos> lstEntidades)
        {
            lstPagosTrand = lstEntidades;
           
        }
        private List<DocumentoVenta> fnCargarDocumentoVenta(DetalleVentaCabecera lstdvc)
        {
            List<DocumentoVenta> lsDocVenta = new List<DocumentoVenta>();
            TipoTarifa lstTipoVenta = new TipoTarifa();
            frmRegistrarVenta frmRV = new frmRegistrarVenta();

            lsDocVenta.Add(new DocumentoVenta
            {
                idCliente = clsCliente.idCliente,
                cCliente = FunGeneral.FormatearCadenaTitleCase(clsCliente.cNombre + " " + clsCliente.cApePat + " " + clsCliente.cApeMat),
                cTipoDoc = fnDevolverTipoDocPersona(clsCliente.cTiDo),
                cDireccion = FunGeneral.FormatearCadenaTitleCase(clsCliente.cDireccion+' '+clsCliente.cContactoNom1),
                cDocumento = clsCliente.cDocumento,
                SimboloMoneda = clsMoneda.cSimbolo,
                cCodDocumentoVenta = Convert.ToString(cboComprobanteP.SelectedValue),
                NombreDocumento = Convert.ToString(cboComprobanteP.Text),
                dFechaVenta = Convert.ToDateTime(dtFechaPago.Value),
                idMoneda = clsMoneda.idMoneda,
                nSubtotal = lstdvc.SubTotal,
                nNroIGV = 18,
                nIGV = lstdvc.IGV,
                nMontoTotal = lstdvc.Total,
                cUsuario = frmRV.fnObtenerUsuarioActual(),
                cVehiculos = clsVehiculo.vPlaca,
                cDescripcionTipoPago = (lstPagosTrand.Count > 0) ? FunGeneral.FormatearCadenaTitleCase(lstPagosTrand[0].cDescripTipoPago) : "",
                cDescripEstadoPP = (lstPagosTrand.Count > 0) ? lstPagosTrand[0].cEstadoPP : "",
                cTipoVenta = lstTipoVenta.Nombre

            });
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
        private Double fnConvertirPrecioMoneda(Int32 idMonedaEntrada, Double precioEntrada, Int32 idMonedaSalida)
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
            DataGridViewColumn ColDescuentoPP = dgvCronograma.Columns[8];

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
                if (e.ColumnIndex == 8)
                {
                    DialogResult dResult;
                    Double PrecioADescontar = 0;
                    String PrecioADescontarStr = Convert.ToString(dgvCronograma.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    //Double PrecioADescontar = Convert.ToDouble(dgvCronograma.Rows[e.RowIndex+1].Cells[e.ColumnIndex].Value);
                    string patron = @"(?:- *)?\d+(?:\.\d+)?";
                    Regex regex = new Regex(patron);

                    foreach (Match m in regex.Matches(PrecioADescontarStr))
                    {
                        PrecioADescontar= Convert.ToDouble(m.Value);
                    }
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
            CronogramaSeleccionado = Convert.ToInt32(cboCronograma.SelectedValue);
            fnObtenerCronogramaEspecifico(Convert.ToInt32(cboCronograma.SelectedValue), 0);

            //MessageBox.Show("idContrato "+ Convert.ToInt32(cboCronograma.SelectedValue));
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
            MessageBox.Show("Proceso aun no disponible","Aviso.😕",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            
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
                if (Convert.ToDateTime(dtFechaPago.Value.ToString("dd/MM/yyyy")) > Convert.ToDateTime(Variables.gdFechaSis.ToString("dd/MM/yyyy")))
                {
                    bEstado = false;
                    msg = "la fecha de pago no puede ser mayor a la fecha actual";
                    img = Properties.Resources.error;
                }
                else if (Convert.ToDateTime(dtFechaPago.Value.ToString("dd/MM/yyyy")) < Convert.ToDateTime(dtFechaSistema.ToString("dd/MM/yyyy")))
                {
                    //bEstado = false;
                    //msg = "La fecha de pago no puede ser menor a: " + dtFechaSistema.ToString("dd/MM/yyyy");
                    //img = Properties.Resources.error;

                    bEstado = true;
                    msg = "";
                    img = Properties.Resources.ok;
                }
            }
            lbl.Text = msg;
            pb.Image = img;
            return bEstado;
        }
        private void dtFechaPago_ValueChanged(object sender, EventArgs e)
        {
            estadoFechaPago=fnValidarFecha(erFechaPago,pbFechaPago);
            dtFechaPagoCuota = Convert.ToDateTime(dtFechaPago.Value);
            
            
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
                    e.CellStyle.ForeColor = Color.Orange;
                }
                
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
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
            fnGenerarComprobantePago(filaSeleccionada, ColumnaSeleccionada);




        }

        private void fnGenerarComprobantePago(DataGridViewRow filaSeleccionada, DataGridViewCell ColumnaSeleccionada)
        {
            if (estadoComprabanteP==true && estadoFechaPago==true)
            {
                Cronograma clsCronomaEspecifico = new Cronograma();
                for (Int32 i=0;i< lstCronograma.Count;i++)
                {
                    if (i+1!= lstCronograma.Count)
                    {
                        if (lstCronograma[i].idCronograma == CronogramaSeleccionado)
                        {
                            clsCronomaEspecifico = lstCronograma[i + 1];
                            break;
                        }
                    }
                    else
                    {
                        clsCronomaEspecifico.estado = "ESPV0002";
                        break;
                    }
                    

                }
                //clsCronomaEspecifico= lstCronograma.Find(i => i.idCronograma == CronogramaSeleccionado);
                //if (clsCronomaEspecifico.estado== "ESPV0002")
                //{
                    if (filaSeleccionada.Index != 0)
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
                                lstDocumentoVenta = fnCargarDocumentoVenta(clsDetallecabecera);
                                Consultas.frmVPVenta frmVenta = new Consultas.frmVPVenta();

                                frmVenta.Inicio(lstDocumentoVenta, lstDetalleVenta, -1);
                                fnObtenerCronogramaEspecifico(CronogramaSeleccionado, 0);
                            }



                        }
                    }
                    else if (filaSeleccionada.Index == 0)
                    {
                        DialogResult EstadoDialog = MessageBox.Show("Es correcta la fecha de pago?\n\n" + dtFechaPago.Value.ToString(), "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (EstadoDialog == DialogResult.Yes)
                        {
                            lstDetalleVenta = fnGenerarPagoPrincipal(filaSeleccionada.Index, ColumnaSeleccionada.ColumnIndex);
                            clsDetallecabecera = fnCalcularCabeceraDetalle(lstDetalleVenta);
                            lstDocumentoVenta = fnCargarDocumentoVenta(clsDetallecabecera);
                            Consultas.frmVPVenta frmVenta = new Consultas.frmVPVenta();

                            frmVenta.Inicio(lstDocumentoVenta, lstDetalleVenta, -1);
                            fnObtenerCronogramaEspecifico(CronogramaSeleccionado, 0);
                        }



                    }
                //}
                //else
                //{
                //    MessageBox.Show("Aun no puede generar este pago ! \n porque falta las cuotas anterior !", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                

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
        }
    }
}
