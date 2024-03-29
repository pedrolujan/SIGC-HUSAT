﻿using CapaEntidad;
using CapaEntidad.Generic;
using CapaNegocio;
using CapaUtil;
using Guna.UI.WinForms;
using Newtonsoft.Json;
using Siticone.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Serialization;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Funciones.Models;
using wfaIntegradoCom.Impresiones;
using wfaIntegradoCom.Mantenedores;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmOtrasVentas : Form
    {
        Boolean pnActivar = false;
        public frmOtrasVentas()
        {
            InitializeComponent();
            pnActivar = false;
        }
        private static List<Moneda> lstMon = new List<Moneda>();
        private static CambioMonedaVenta clsCMP = new CambioMonedaVenta();
        private static CambioMonedaVenta clsCUnico = new CambioMonedaVenta();
        //static  CambioPrecioOtrasVentas cPOtrasVentas = new CambioPrecioOtrasVentas();
        private static Moneda Mon = new Moneda();
        static Double dsPrecioEquipo;
        static Int32 idMonedaTraida;
        Boolean CargoForm = false;
        static Boolean estDescuento;

        static Int32 cellidTipoEquipo;
        static String cellNombreEquipo = "";
        static String cellSimboloMoneda = "";
        static Double cellPrecio = 0;
        static Int32 cellIdMoneda = 0;
        static Int32 cellIdTipoTraccion = 0;
        static Int32 tabInicio;
        Double SubTotal = 0;
        Int32 lnTipoCon = 0;
        static Double nIgvAplicar = 0;
        static Double SubTotalGeneralVenta = 0;
        static TotalPagosVenta TotVenta = new TotalPagosVenta();
        static DocumentoVenta DocumentoVenta = new DocumentoVenta();
        private static List<Pagos> lstPagosTrand = new List<Pagos>();
        static Boolean EstadoGenVenta = false;
        static Boolean EstadoLlenarObjetos = false;
        static String cTipoPago = string.Empty;
        static Double nMontoPagar = 0;
        static string cDescripcionTipoPago = string.Empty;
        static List<OtrasVentas> lstOtrasVentas = new List<OtrasVentas>();
        static List<StokAccesorios> lstAtokAccesorios = new List<StokAccesorios>();
       static Int32 IdObjetoExistente = 0;
        Boolean estadoTabla, estMoneda, estTipPersona, estTipDocumento,  estTipoDescuento,estCliente,estDocumentoEmitir;
        String lblMoneda, lblTipPersona, lblTipDocumento, lblTipoDescuento,lblCliente, lblDocumentoEmitir;
        public static void fnObtenerObjVentas(OtrasVentas clsOtrasVentas)
        {


            OtrasVentas valorRepetido = lstOtrasVentas.Find(i=>(i.idObjVenta== clsOtrasVentas.idObjVenta) && (i.idTipoTransaccion==clsOtrasVentas.idTipoTransaccion));
            if (valorRepetido==null)
            {

                if (IdObjetoExistente == 0)
                {
                    lstOtrasVentas.Add(clsOtrasVentas);
                }
                else
                {
                    Int32 indiceLista = lstOtrasVentas.FindIndex(i =>i.idObjVenta == IdObjetoExistente);
                    
                        lstOtrasVentas[indiceLista] = clsOtrasVentas;
                }
               

            }
            else
            {
                MessageBox.Show("Este Item ya Existe Ingrese uno Diferente","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            //if (cellidTipoEquipo==idObjeto && cellIdTipoTraccion==idTipoTransac)
            //{
            //    EstadoLlenarObjetos = false;
            //}
            //else
            //{
            //    EstadoLlenarObjetos = true;
            //}
            //cellidTipoEquipo = idObjeto;
            //cellNombreEquipo = nombreObjeto;
            //cellSimboloMoneda = simbolo;
            //cellPrecio = Precio;
            //cellIdMoneda = idMoneda;
            //cellIdTipoTraccion = idTipoTransac;

            //clsCMP.IdMonedaEntrada = cellIdMoneda;
            //clsCMP.PrecioEntrada = cellPrecio;

            //cPOtrasVentas.idObjeto = idObjeto;
            //cPOtrasVentas.precioNeto = Precio;
        }

        private void fnInsertarATable()
        {
            dgOtrasVentas.Rows.Clear();
            Int32 i = 0;
            Int32 indiceLista = lstOtrasVentas.FindIndex(j => j.idTipoTransaccion == 2);
            foreach (OtrasVentas item in lstOtrasVentas)
            {
                String PrecioUnicoMostrar = "";                
                
                item.unidades =(item.unidades==0)?1: item.unidades;
                item.descuentoCantidad = (item.descuentoCantidad == 0) ? 0 : item.descuentoCantidad;
                item.descuentoPrecio =  item.descuentoPrecio;
                
                item.precioNeto = fnCalcularPrecios(lblMostrarPrecioCambio, item.idMoneda,((item.precioUnico * item.unidades) - item.descuentoPrecio), Mon) ;
                if (Mon.idMoneda==2)
                {
                    item.precioUnicoCambio = fnCalcularPrecios(lblMostrarPrecioCambio, item.idMoneda, item.precioUnico, Mon);
                }
                else
                {
                    item.precioUnicoCambio = item.precioUnico;
                }

                String PrecioUnico = string.Format("{0:0.00}",item.precioUnico);
                String PrecioUnicoCambio = string.Format("{0:0.00}", item.precioUnicoCambio);
                String PrecioNeto = string.Format("{0:0.00}", item.precioNeto);

                dgOtrasVentas.Rows.Add(
                    item.idObjVenta,
                    i + 1,
                    item.DetalleVentas,
                    item.precioUnicoCambio != item.precioUnico ? $"{item.simbMoneda} {PrecioUnico} {" -> "} {Mon.cSimbolo} { PrecioUnicoCambio}" : $"{item.simbMoneda} { PrecioUnico}",
                item.unidades,
                    item.descuentoCantidad,
                  $"{Mon.cSimbolo} {PrecioNeto}",
                    null,
                    null,
                    item.idTipoTransaccion
                );
                i += 1;
                
                
            }
            if (indiceLista != -1)
            {
                dgOtrasVentas.Rows[indiceLista].Cells[4].ReadOnly = true;
                dgOtrasVentas.Rows[indiceLista].Cells[4].Style.BackColor = Variables.ColorDescativadoFuerte;
            }
            fnCalcularDescuento();
            fnCalcularTotalPrecios();
            
        }
        private String fnDevolverSimboloTipoDescuento()
        {
            BLTipoDescuento objTipoDescuento = new BLTipoDescuento();
            clsUtil objUtil = new clsUtil();
            List<TipoDescuento> lstTipoDescuento;
            String strDescuento = "";
            try
            {

                lstTipoDescuento = objTipoDescuento.blTipoDescuento(Convert.ToInt32(cboTipoDescuento.SelectedValue), true);
                if (Convert.ToString(lstTipoDescuento[1].Simbolo) != "%")
                {
                    strDescuento = Mon.cSimbolo;
                }
                else
                {
                    strDescuento = lstTipoDescuento[1].Simbolo;
                }
                return strDescuento;
            }
            catch (Exception ex)
            {
                return "Error";

            }
        }
        public Double fnDebolverIgv()
        {
            BLOtrasVenta ojOV = new BLOtrasVenta();
            Double Igv = 0;
            Igv = ojOV.blDevolverIgv("PIGV");
            return Igv;
        }
        private void fnCalcularTotalPrecios()
        {
            if (CargoForm == true)
            {
                Double TotalGeneral = 0;
                //Double TotalAPagar = 0;
                Double CalcIgv = 0;
                if (lstOtrasVentas.Count>0)
                {
                    TotalGeneral = lstOtrasVentas.Sum(i => i.precioNeto);
                    //TotVenta.Total = TotalGeneral;
                    DocumentoVenta.nMontoTotal = TotalGeneral;

                    txtTotal.Text = Mon.cSimbolo + " " + string.Format("{0:0.00}", DocumentoVenta.nMontoTotal);
                    CalcIgv = (TotVenta.Total * fnDebolverIgv()) / 100;

                    //TotVenta.Igv = CalcIgv;
                    DocumentoVenta.nIGV = CalcIgv;

                    lstOtrasVentas[0].IgvPorcentaje = fnDebolverIgv();
                    lstOtrasVentas[0].IgvPrecio = CalcIgv;
                    txtShowCalcIgv.Text = Mon.cSimbolo + " " + string.Format("{0:0.00}", DocumentoVenta.nIGV);

                    SubTotal = TotalGeneral - CalcIgv;
                    //TotVenta.Subtotal = SubTotal;
                    DocumentoVenta.nSubtotal = SubTotal;

                    txtSubTotal.Text = Mon.cSimbolo + " " + string.Format("{0:0.00}", DocumentoVenta.nSubtotal);
                    //TotVenta.SimboloMoneda = Mon.cSimbolo;
                    DocumentoVenta.SimboloMoneda= Mon.cSimbolo;
                    //TotVenta.idMoneda = Mon.idMoneda;
                    DocumentoVenta.idMoneda= Mon.idMoneda;

                    DocumentoVenta.cCodDocumentoVenta= Convert.ToString(cboTipoDocEmitir.SelectedValue);
                    //TotVenta.cCodDocumentoVenta = Convert.ToString(cboTipoDocEmitir.SelectedValue);
                    DocumentoVenta.NombreDocumento = Convert.ToString(cboTipoDocEmitir.Text);

                    //lstOtrasVentas[0].NombreDocumento = Convert.ToString(cboTipoDocEmitir.Text);
                }
                
            }
        }
        
        private Boolean fnLlenarTipoDescuento(Int32 idTipoDescuento, SiticoneComboBox cbo, Boolean buscar)
        {
            BLTipoDescuento objTipoDescuento = new BLTipoDescuento();
            clsUtil objUtil = new clsUtil();
            List<TipoDescuento> lstTipoDescuento;

            try
            {
                lstTipoDescuento = objTipoDescuento.blTipoDescuento(idTipoDescuento, buscar);
                cbo.ValueMember = "IdTipoDescuento";
                cbo.DisplayMember = "Nombre";
                cbo.DataSource = lstTipoDescuento;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }
        }
        private void fnActivarComboDescuento(Boolean estado)
        {
            cboTipoDescuento.Enabled = estado;
            chkAbilitarDescuento.Visible = estado;
            if (estado==false)
            {
                pbTipoDescuento.Visible = false;
            }
        }
        private void btnAplicarDescuento_Click(object sender, EventArgs e)
        {
            frmAccesoADescuento frmLogDescuento = new frmAccesoADescuento();
            frmLogDescuento.Inicio(2);

            fnActivarComboDescuento(estDescuento);

        }
        public static void fnRespuestaValidacion(Boolean estado)
        {
            estDescuento = estado;
        }
        private void fnCargarCombobox(Int32 tabIndex)
        {
            Boolean result = false;
            if (tabIndex == 0)
            {
                result = fnLlenarTipoDescuento(0, cboTipoDescuento, false);
                if (!result)
                {
                    MessageBox.Show("Error al cargar Tipo descuento", "Avise al administrador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                result = fnLLenarTipoPersona(cboTipoPersona, 0, "", false);
                if (!result)
                {
                    MessageBox.Show("Error al cargar Tipo descuento", "Avise al administrador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                result = fnLLenarMoneda(cboMoneda, 0, false);
                if (!result)
                {
                    MessageBox.Show("Error al Cargar Moneda", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                cboMoneda.SelectedValue = 1;
            }
            else if (tabIndex==1)
            {
                if (CargoForm == true)
                {
                    fnLlenarTablaCod(cboDocVentaBusq, "DOVE", -1, -1);
                }
            }


        }
        private void fnObtenerStok()
        {
            btnStockEquipos.Text = Convert.ToString(fnObtenerStockGeneral(0, 0));
            btnStockAccesorios.Text = Convert.ToString(fnObtenerStockGeneral(1, 0));
        }
        private void frmOtrasVentas_Load(object sender, EventArgs e)
        {
            pnActivar = false;
            CargoForm = false;
            FunValidaciones.fnColorBtnGuardar(btnGuardar);
            try
            {
                fnHabilitarControles(true);
                fnObtenerStok();
                fnCargarCombobox(0);
                cboMoneda.SelectedValue = 1;
                //fnHabilitarControles(true);
                //fnPintarCampos();
                fnHabilitarDescuento(false);
                lstOtrasVentas = new List<OtrasVentas>();
                estadoTabla=false;


            }
            catch (Exception ex)
            {

            }
            finally
            {
                CargoForm = true;
            }
            //this.reportViewer1.RefreshReport();
        }

        public static Boolean fnLlenarTablaCod(ComboBox cboCombo, String cCodTab,Int32 idTipoDocPers,Int32 Busqueda)
        {
            BLOtrasVenta objTablaCod = new BLOtrasVenta();
            clsUtil objUtil = new clsUtil();
            List<Cargo> lstTablaCod = new List<Cargo>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverTablaCod(cCodTab, idTipoDocPers, Busqueda);
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

        private void fnLimpiarGrilla()
        {
            dgOtrasVentas.Rows.Clear();
        }
        private  void fnLimpiarControles()
        {
            txtDocumento.Text="";
            txtClientesN_A.Text="";
            txtDireccion.Text="";
            txtTelefono.Text = "";
            cboTipoPersona.SelectedValue = 0;
            cboTipoDescuento.SelectedValue = 0;
            cboTipoDocEmitir.SelectedValue = "0";
            estDescuento = false;
            fnActivarComboDescuento(estDescuento);
            fnHabilitarDescuento(false);
            fnLimpiarGrilla();


        }
        private  void fnHabilitarControles(Boolean estado)
        {
            gbDatosCliente.Enabled = estado;
            gbDatosVenta.Enabled = estado;
            if (estado == false)
            {
                gbDatosCliente.CustomBorderColor = Variables.ColorGroupBoxDesactivado;
                gbDatosVenta.CustomBorderColor = Variables.ColorGroupBoxDesactivado;
                dgOtrasVentas.ColumnHeadersDefaultCellStyle.BackColor = Variables.ColorDescativadoFuerte;
            }
            else
            {
                gbDatosCliente.CustomBorderColor = Variables.ColorGroupBox;
                gbDatosVenta.CustomBorderColor = Variables.ColorGroupBox;

                dgOtrasVentas.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dgOtrasVentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                dgOtrasVentas.RowHeadersDefaultCellStyle.BackColor = Variables.ColorGroupBox;
            }
            dgOtrasVentas.EnableHeadersVisualStyles = false;

        }
        private void fnHabilitarDescuento(Boolean estado)
        {

            if (estado)
            {
                dgOtrasVentas.Columns[5].DefaultCellStyle.BackColor = Color.White;
                if (Convert.ToInt32(cboTipoDescuento.SelectedValue) != 0)
                {
                    dgOtrasVentas.Columns[5].ReadOnly = false;
                }
            }
            else
            {
                dgOtrasVentas.Columns[5].DefaultCellStyle.BackColor = Variables.ColorDescativadoFuerte;
                //if (Convert.ToInt32(cboTipoDescuento.SelectedValue) == 0)
                //{
                //}
                    dgOtrasVentas.Columns[5].ReadOnly = true;
            }



        }

        private void fnMostrarCantidadDescuento(Int32 index)
        {
            if (CargoForm == true)
            {
                if (index==0)
                {
                    for (Int32 i = 0; i < lstOtrasVentas.Count; i++)
                    {
                        lstOtrasVentas[i].descuentoCantidad = 0;
                        lstOtrasVentas[i].descuentoPrecio = 0;

                    }
                    //fnCalcularDescuento();
                    //fnInsertarATable();
                }
                

            }
        }

        private void cboTipoDescuento_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CargoForm==true)
            {
                
                if (Convert.ToInt32(cboTipoDescuento.SelectedValue)!=0)
                {

                    //fnCalcularTotalPrecios();
                    //for (Int32 i=0;i<lstOtrasVentas.Count;i++)
                    //{
                    //    lstOtrasVentas[i].descuentoCantidad = 0;
                    //    lstOtrasVentas[i].descuentoPrecio = 0;
                    //}
                    fnMostrarCantidadDescuento(0);
                    if (lstOtrasVentas.Count>0)
                    {
                        lstOtrasVentas[0].idTipoDescuento = Convert.ToInt32(cboTipoDescuento.SelectedValue);
                    }
                    if (cboTipoDescuento.Enabled == true)
                    {
                        var result = FunValidaciones.fnValidarCombobox(cboTipoDescuento, lblMsgTipoDescuento, pbTipoDescuento);
                        estTipoDescuento = result.Item1;
                        lblTipoDescuento = result.Item2;
                    }
                    fnHabilitarDescuento(true);
                    fnInsertarATable();
                    fnCalcularDescuento();
                }
                else
                {
                    fnInsertarATable();
                    fnHabilitarDescuento(false);
                }

                
                
            }


        }

        private void fnCalcularDescuento()
        {
            Int32 TotalFilas = lstOtrasVentas.Count;
            if (dgOtrasVentas.Columns[5].Name == "DESCUENTO")
            {
                for (Int32 i = 0; i < TotalFilas; i++)
                {
                    DataGridViewRow rowss = dgOtrasVentas.Rows[i];
                    
                    Double PrecioNetoItem = lstOtrasVentas[i].unidades * lstOtrasVentas[i].precioUnico;
                    if (Convert.ToInt32(cboTipoDescuento.SelectedValue) == 1)
                    {
                        lstOtrasVentas[i].descuentoPrecio = (lstOtrasVentas[i].descuentoCantidad * PrecioNetoItem) / 100;
                        lblIconDescuento.Text = "%";
                    }
                    else if (Convert.ToInt32(cboTipoDescuento.SelectedValue) == 2)
                    {
                        lstOtrasVentas[i].descuentoPrecio = Convert.ToInt32(rowss.Cells[5].Value);
                        lblIconDescuento.Text = Mon.cSimbolo+".";
                        if (lstOtrasVentas[i].descuentoCantidad>(lstOtrasVentas[i].precioUnico* lstOtrasVentas[i].unidades))
                        {
                            rowss.Cells[5].Style.BackColor = Color.Red;
                            estadoTabla = false;
                            return;
                        }
                        else
                        {
                            rowss.Cells[5].Style.BackColor = Color.White;
                            estadoTabla = true;
                        }
                    }
                    else
                    {
                        lblIconDescuento.Text = "";
                    }
                }
            }
            
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
                //lstTDC = lstTC;
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

        private void cboTipoClienteRP_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboTipoPersona, lblMsgTipoPersona, pbTipPersona);
            estTipPersona = result.Item1;
            lblTipPersona = result.Item2;

            Int32 idTipoRP = Convert.ToInt32(cboTipoPersona.SelectedValue ?? 0);
            fnLLenarDocumentoDeTipoPersona(cboTipoDocumento, idTipoRP, "", false);
            if (idTipoRP == 0)
            {
                cboTipoDocumento.Enabled = false;
            }
            else
            {
                cboTipoDocumento.Enabled = true;
            }
        }
        private Boolean fnBuscarCliente(SiticoneTextBox txt, Int32 Pagina, Int16 TipoConPagina, DataGridView dgv, ComboBox cboTC, ComboBox cboTD)
        {
            BLCliente objVehi = new BLCliente();
            DatosEnviarVehiculo objEnvio = new DatosEnviarVehiculo();
            clsUtil objUtil = new clsUtil();
            DataTable datCliente;
            Int32 totalResultados;

            try
            {

                String nroDocumento = txt.Text.Trim();
                String nombreCliente = "";
                Int32 idTipoPersona = Convert.ToInt32(cboTC.SelectedValue ?? 0);
                Int32 idTipoDocumento = Convert.ToInt32(cboTD.SelectedValue ?? 0);
                String estCliente = "1";

                datCliente = objVehi.blBuscarCliente(nroDocumento, nombreCliente, idTipoPersona, idTipoDocumento, estCliente, Pagina, TipoConPagina);
                totalResultados = datCliente.Rows.Count;

                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("DETALLE");

                    for (int i = 0; i <= totalResultados - 1; i++)
                    {
                        Boolean estadoVehiculo = Convert.ToBoolean(datCliente.Rows[i][6]);
                        if (estadoVehiculo)
                        {
                            object[] row =
                            {
                                    datCliente.Rows[i][0],
                                    datCliente.Rows[i][5]
                                };
                            dt.Rows.Add(row);
                        }

                    }

                    //dt.Rows.Add(new Object[] { "0", "NUEVO IMEI" });
                    dgv.DataSource = dt;
                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 100;

                    dgv.Visible = true;

                }
                else
                {
                    dgv.Visible = false;
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
        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            Int32 numCaracter = Convert.ToInt32(txtDocumento.TextLength);
            if (numCaracter >= 3)
            {
                Boolean bResul;

                bResul = fnBuscarCliente(txtDocumento, 0, -1, dgDocumento, cboTipoPersona, cboTipoDocumento);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }
        private Boolean fnListarClienteEspecifico
            (SiticoneDataGridView dgv, SiticoneTextBox txtDoc, SiticoneTextBox txtIdCliente,
              SiticoneTextBox txtClienteN_A, SiticoneTextBox txtDirrecion, SiticoneTextBox txtTelefono
            )
        {
            BLCliente objAcc = new BLCliente();
            Cliente lstPros;
            clsUtil objUtil = new clsUtil();
            Int32 idCliente;
            try
            {

                idCliente = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value.ToString());

                if (idCliente == 0)
                {
                    //fnBuscarClienteXTelefono(1);
                    //lnTipoConOferta = 2;
                }
                else
                {
                    lstPros = objAcc.blListarCliente(idCliente, 1);
                    //tabRegistroVisitas.AutoScroll = false;
                    if (lstPros.idCliente > 0) {
                        DocumentoVenta.idCliente = lstPros.idCliente;
                        DocumentoVenta.cCliente= $"{ lstPros.cNombre.Trim()} {lstPros.cApePat.Trim()} {lstPros.cApeMat.Trim()}";
                        DocumentoVenta.cDocumento = lstPros.cDocumento;
                        DocumentoVenta.cTiDocPersona = lstPros.cTiDo;
                        DocumentoVenta.cTiDocPersona = lstPros.cTipPers;
                        DocumentoVenta.cDireccion = lstPros.cDireccion;

                        txtDoc.Text = lstPros.cDocumento;
                        txtIdCliente.Text = lstPros.idCliente.ToString();
                        txtClienteN_A.Text = $"{ lstPros.cNombre.Trim()} {lstPros.cApePat.Trim()} {lstPros.cApeMat.Trim()}";
                        txtDirrecion.Text = lstPros.cDireccion;
                        txtTelefono.Text = lstPros.cTelCelular;
                        dgv.Visible = false;
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
        private void dgDocumento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean bResul = false;
            bResul = fnListarClienteEspecifico(dgDocumento, txtDocumento, txtIdCliente, txtClientesN_A, txtDireccion, txtTelefono);
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar Cliente Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }


        private Boolean fnBuscarEquipos_Accesorios(SiticoneTextBox txt, DataGridView dgv)
        {
            BLEquipo_Imeis objImeis = new BLEquipo_Imeis();
            clsUtil objUtil = new clsUtil();
            DataTable datResp = null;
            Int32 totalResultados;

            try
            {
                String busqueda = txt.Text.Trim();
                if (tabControl1.SelectedIndex == 1)
                {
                    datResp = objImeis.blDevolverEquiposImeisDePlan(busqueda, 0, -1);
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    datResp = objImeis.blDevolverAccesorios(busqueda, 1);
                }

                totalResultados = datResp.Rows.Count;

                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("DETALLE");
                    String detalle = "";

                    foreach (DataRow drMenu in datResp.Rows) {
                        detalle = (tabControl1.SelectedIndex == 1) ? Convert.ToString(drMenu["detalle"]) : drMenu["detalle"] + ": Stok= " + drMenu["cStock"];
                        object[] row =
                        {
                                drMenu["id"],
                               detalle
                            };
                        dt.Rows.Add(row);

                    }

                    //dt.Rows.Add(new Object[] { "0", "NUEVO EQUIPO" });
                    dgv.DataSource = dt;
                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 100;

                    dgv.Visible = true;

                }
                else
                {
                    dgv.Visible = false;
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
                objImeis = null;
                objUtil = null;
            }

        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                fnCargarCombobox(Convert.ToInt32(tabControl1.SelectedIndex));
            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }
        private Double fnCalcularPrecios(Label lbl, Int32 idMonedaEntrada, Double PrecioEntrada, Moneda m)
        {
            BLMoneda objMoneda = new BLMoneda();           

            CambioMonedaVenta clsCambioMoneda;            

            clsCambioMoneda = objMoneda.blDevolverCambioMoneda(idMonedaEntrada, PrecioEntrada, m.idMoneda);
            string precioEntradaFormatedo = string.Format("{0:0.00}", PrecioEntrada);
            string PrecioSalidaFormat = string.Format("{0:0.00}", clsCambioMoneda.PrecioSalida);
            string precioCambioMoneda = string.Format("{0:0.00}", clsCambioMoneda.PrecioCambio);

            if (idMonedaEntrada == m.idMoneda)
            {
                lbl.Text = "";
            }
            else
            {
                //lbl.Text = $" 1 {nombreMonedaTarifa} es igual a {precioCambioMoneda} {nombreMoneda}";
            }
            return clsCambioMoneda.PrecioSalida;
        }
        private void fnColoresBotonStock(Int64 Stock)
        {
            if (Stock > 10)
            {
                btnStockEquipos.FillColor = Variables.ColorSuccess;
                btnStockEquipos.BackColor = Variables.ColorSuccess;
                fnMostrarMensaje(lblMsgDgOtrasVentas ,false, "");
            }
            else if (Stock <= 10)
            {
                btnStockEquipos.FillColor = Variables.ColorWarning;
                btnStockEquipos.BackColor = Variables.ColorWarning;
                if (Stock < 10)
                {
                    fnMostrarMensaje(lblMsgDgOtrasVentas,true, "Advertencia: Stock Menor a 10 Unidades");
                }
            } else if (Stock <= 0)
            {
                btnStockEquipos.FillColor = Variables.ColorError;
                btnStockEquipos.BackColor = Variables.ColorError;
                fnMostrarMensaje(lblMsgDgOtrasVentas,true, "Advertencia: Stock Insuficiente para la Venta");
            }
        }
        private Int64 fnObtenerStockGeneral(Int32 tipoCon, Int32 tipOpcion)
        {
            BLEquipo_Imeis objImeis = new BLEquipo_Imeis();
            clsUtil objUtil = new clsUtil();
            DataTable dtResult = new DataTable();
            Int64 Stock = 0;
            String Nombre = "";
            try
            {
                dtResult = objImeis.blDevolverStockImeis(tipoCon, tipOpcion);

                foreach (DataRow drMenu in dtResult.Rows)
                {
                    if (tipOpcion == 0)
                    {
                        Stock = Convert.ToInt64(drMenu["stock"]);

                    }
                    //else
                    //{
                    //    Nombre = Convert.ToString(drMenu["nombre"]);
                    //    Stock = Convert.ToInt64(drMenu["stock"]);
                    //}
                }

                //btnStockEquipos.Text = Convert.ToString(Stock);
                //btnStockAccesorios.Text = Convert.ToString(Stock);
                //fnColoresBotonStock(Stock);
                return Stock;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnBuscarVehiculo", ex.Message);
                return 0;
            }
            finally
            {
                objImeis = null;
                objUtil = null;
            }

        }
        private Boolean fnObtenerStockDetalles(Int32 tipoCon, Int32 tipOpcion)
        {
            BLEquipo_Imeis objImeis = new BLEquipo_Imeis();
            clsUtil objUtil = new clsUtil();
            DataTable dtResult = new DataTable();
            Int64 Stock = 0;
            String Nombre = "";
            dgDetStock.Visible = false;
            try
            {

                dtResult = objImeis.blDevolverStockImeis(tipoCon, tipOpcion);
                if (tipoCon==1 && tipOpcion==1)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        foreach (DataRow drMenu in dtResult.Rows)
                        {
                            lstAtokAccesorios.Add(new StokAccesorios
                            {
                                IdAccesorio = Convert.ToInt32(drMenu["id"]),
                                StokAccesorio = Convert.ToInt32(drMenu["stock"]),
                                NombreAccesorio = Convert.ToString(drMenu["nombre"])
                            });
                        }
                    }
                }
                if (dtResult.Rows.Count > 0)
                {
                    dgDetStock.Rows.Clear();
                    foreach (DataRow drMenu in dtResult.Rows)
                    {
                        if (tipOpcion == 1)
                        {
                            dgDetStock.Rows.Add(
                            Nombre = Convert.ToString(drMenu["nombre"]),
                            Stock = Convert.ToInt64(drMenu["stock"]));

                        }
                    }
                    dgDetStock.Visible = true;
                }
                else
                {
                    dgDetStock.Visible = false;
                }



                //btnStockEquipos.Text = Convert.ToString(Stock);
                //btnStockAccesorios.Text = Convert.ToString(Stock);

                return true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnBuscarVehiculo", ex.Message);
                return false;
            }
            finally
            {
                objImeis = null;
                objUtil = null;
            }

        }

        private String fnObtenerSimboloMoneda(Int32 idM, List<Moneda> lstMoneda)
        {
            foreach (Moneda m in lstMoneda)
            {
                if (m.idMoneda == idM)
                {
                    return m.cSimbolo;
                }
            }
            return "";
        }

        private void dgOtrasVentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgOtrasVentas.Columns[e.ColumnIndex].Name == "dgbtnNuevo" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgOtrasVentas.Rows[e.RowIndex].Cells["dgbtnNuevo"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\search.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgOtrasVentas.Rows[e.RowIndex].Height = 30;
                this.dgOtrasVentas.Columns[e.ColumnIndex].Width = 30;


                e.Handled = true;


            }

            if (e.ColumnIndex >= 0 && this.dgOtrasVentas.Columns[e.ColumnIndex].Name == "dgbtnEliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celBoton2 = this.dgOtrasVentas.Rows[e.RowIndex].Cells["dgbtnEliminar"] as DataGridViewButtonCell;
                Icon icoAtomico2 = new Icon(Application.StartupPath + @"\delete.ico");

                e.Graphics.DrawIcon(icoAtomico2, e.CellBounds.Left + 2, e.CellBounds.Top + 2);

                this.dgOtrasVentas.Rows[e.RowIndex].Height = 30;
                this.dgOtrasVentas.Columns[e.ColumnIndex].Width = 30;

                e.Handled = true;
            }
        }
        private void fnMostrarPrecioUnitario(Int32 condicion)
        {
            //String precioUnicoConvert = fnCalcularPrecios(lblMostrar, cellIdMoneda, cellPrecio, Mon);
            


            for (Int32 i = 0; i < fnTotalRowsParaFor(); i++)
            {
                if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)
                {
                    dgOtrasVentas.Rows[i].Cells[3].Value = cellSimboloMoneda + " " + String.Format("{0:0.00}", Convert.ToDouble(dgOtrasVentas.Rows[i].Cells[4].Value)) + "  =>  " + fnCalcularPrecios(lblMostrarPrecioCambio, cellIdMoneda, Convert.ToDouble(dgOtrasVentas.Rows[i].Cells[4].Value), Mon);
                }
                else
                {

                    dgOtrasVentas.Rows[i].Cells[3].Value = cellSimboloMoneda + " " + String.Format("{0:0.00}", Convert.ToDouble(dgOtrasVentas.Rows[i].Cells[4].Value));
                }

            }


        }
        private void dgOtrasVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 numfilas = fnTotalRowsParaFor();
            Int32 posicionColumna = e.ColumnIndex;
            Int32 posicionFila = 0;
            if (e.RowIndex!=-1)
            {
                 posicionFila = e.RowIndex;
            }
            DataGridViewRow filaSeleccionada = dgOtrasVentas.Rows[posicionFila];

            if (posicionColumna == dgOtrasVentas.Columns["dgbtnNuevo"].Index && e.RowIndex >= 0)
            {
                if (cboTipoDescuento.Enabled==true)
                {
                    cboTipoDescuento.SelectedValue = 0;
                    fnActivarComboDescuento(false);
                    fnMostrarCantidadDescuento(0);
                    chkAbilitarDescuento.Checked = false;
                }
                IdObjetoExistente = Convert.ToInt32(filaSeleccionada.Cells[0].Value);

                frmListarTipoVentas frmEquipo = new frmListarTipoVentas();
                frmEquipo.Inicio(1);
                fnInsertarATable();
                fnHabilitarDescuento(false);
                estadoTabla = true;
                //fnCalcularTotalPrecios();

                //if (EstadoLlenarObjetos == true)
                //{
                //    contador = dgOtrasVentas.RowCount;

                //    dgOtrasVentas.Rows[e.RowIndex].Cells[0].Value = cellidTipoEquipo;
                //    dgOtrasVentas.Rows[e.RowIndex].Cells[1].Value = contador;
                //    dgOtrasVentas.Rows[e.RowIndex].Cells[2].Value = cellNombreEquipo;
                //    dgOtrasVentas.Rows[e.RowIndex].Cells[4].Value = cellPrecio;
                //    dgOtrasVentas.Rows[e.RowIndex].Cells[5].Value = 0;
                //    dgOtrasVentas.Rows[e.RowIndex].Cells[12].Value = cellIdTipoTraccion;

                //    fnMostrarPrecioUnitario(0);
                //    dgOtrasVentas.CurrentCell = dgOtrasVentas.Rows[dgOtrasVentas.Rows.Count - 1].Cells[5];
                //    dgOtrasVentas.BeginEdit(true);
                //    if (Convert.ToInt32(cboTipoDescuento.SelectedValue)!=0)
                //    {
                //        Int32 selectIndex = Convert.ToInt32(cboTipoDescuento.SelectedValue);
                //        //if (selectIndex==1)
                //        //{
                //        //    cboTipoDescuento.SelectedValue = 2;

                //        //}else if (selectIndex==2)
                //        //{
                //        //    cboTipoDescuento.SelectedValue = 1;
                //        //}
                //        cboTipoDescuento.SelectedValue = selectIndex;

                //    }

                //}
                //else
                //{
                //    MessageBox.Show("Porfavor elija otro item"," Aviso!!!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                //}
            }

            if (posicionColumna == dgOtrasVentas.Columns["dgbtnEliminar"].Index && e.RowIndex >= 0)
            {
                 Int32 idObJeto = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                if (posicionFila == 0 || posicionFila == numfilas)
                {
                    lstOtrasVentas.Remove(fnObtenerObjetoSeleccionado(idObJeto, lstOtrasVentas));
                    fnInsertarATable();
                }
                else
                {
                    lstOtrasVentas.Remove(fnObtenerObjetoSeleccionado(idObJeto, lstOtrasVentas));
                    fnInsertarATable();
                }
            }
        }

        public static OtrasVentas fnObtenerObjetoSeleccionado(Int32 idObJeto, List<OtrasVentas> lstV)
        {
            foreach (OtrasVentas item in lstV)
            {
                if (item.idObjVenta == idObJeto)
                {
                    return item;
                }
            }
            return new OtrasVentas();
        }
        //private Boolean fnCalcularTotal()
        //{
        //    clsUtil objUtil = new clsUtil();

        //    int i = 0;
        //    Double lnTotalTabla = 0;
        //    Double lnSubTotal = 0, lnEnvio, lnOtrosCargos;

        //    lnEnvio = Convert.ToDouble(txtEnvio.Text.ToString() == "" ? "0" : txtEnvio.Text.ToString());
        //    lnOtrosCargos = Convert.ToDouble(txtOtrosCargos.Text.ToString() == "" ? "0" : txtOtrosCargos.Text.ToString());
        //    try
        //    {
        //        String SimbMoneda = fnObtenerSimboloMoneda(cellIdMoneda, lstMon);
        //        for (i = 0; i <= dgOtrasVentas.Rows.Count - 1; i++)
        //        {
        //            lnTotalTabla = lnTotalTabla + Convert.ToDouble(dgOtrasVentas.Rows[i].Cells[7].Value);

        //        }
        //       String precioConvert= fnCalcularPrecios(lblMostrar, cellIdMoneda, lnTotalTabla, Mon);

        //        txtSubTotal.Text = precioConvert;/*SimbMoneda + " " + String.Format("{0:0.00}", Math.Round(lnTotalTabla, 2));*/
        //        lnSubTotal = lnTotalTabla + lnEnvio;

        //        //Double lnTotalIGV = (lnSubTotal * lnIGV);
        //        //txtIGV.Text = lnSimbolo + " " + String.Format("{0:0.00}", Math.Round(lnTotalIGV, 2));
        //        //txtTotal.Text = lnSimbolo + " " + String.Format("{0:0.00}", Math.Round((lnSubTotal + lnTotalIGV + lnOtrosCargos), 2));

        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("frmOrdenCompra", "fnCalcularTotal", ex.Message);
        //        return false;
        //    }
        //    finally
        //    {
        //        objUtil = null;
        //    }

        //}
        private Boolean fnValidarMsgDescuento(Int32 filaIndice,Double CalcTotItem)
        {
            Boolean returnEstado = false;
            if (CargoForm == true)
            {
                DataGridViewRow rowss = dgOtrasVentas.Rows[filaIndice];
                if (lblMsgForm.Text=="")
                {
                    if ((Convert.ToDouble(rowss.Cells[6].Value) < CalcTotItem) && rowss.Cells[6].ReadOnly == false)
                    {
                        fnMostrarMensaje(lblMsgForm, false, "");
                        rowss.Cells[6].Style.BackColor = Color.White;

                        returnEstado= true;
                    }
                    else if ((Convert.ToDouble(rowss.Cells[6].Value) > CalcTotItem) && rowss.Cells[6].ReadOnly == false)
                    {
                        fnMostrarMensaje(lblMsgForm, true, "El Descuento no Puede ser Mayor al Precio Neto");
                        rowss.Cells[6].Style.BackColor = Color.Red;
                        returnEstado= false;
                    }
                    
                }

            }
                return returnEstado;
        }
        private void dgOtrasVentas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Boolean lbResul = false;
            Double SubTotal = 0;
            Double Descuento = 0;
            Int32 filaIndice = e.RowIndex == -1 ? 0 : e.RowIndex;

            DataGridViewRow rowss = dgOtrasVentas.Rows[filaIndice];
            if (CargoForm==true)
            {
                if (dgOtrasVentas.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 4)
                    {
                        StokAccesorios StokAcc = lstAtokAccesorios.Find(i => (i.IdAccesorio == lstOtrasVentas[filaIndice].idObjVenta) && (lstOtrasVentas[filaIndice].idTipoTransaccion == 3));
                        if (StokAcc != null)
                        {
                            if (StokAcc.StokAccesorio < Convert.ToInt32(rowss.Cells[4].Value))
                            {
                                rowss.Cells[4].Style.BackColor = Color.Red;
                                fnMostrarMensaje(lblMsgDgOtrasVentas, true, "Stock Insuficiente..");
                                estadoTabla = false;
                                return;
                            }
                            else
                            {
                                fnMostrarMensaje(lblMsgDgOtrasVentas, false, "");
                                estadoTabla = true;
                                lstOtrasVentas[filaIndice].unidades = Convert.ToInt32(rowss.Cells[4].Value);
                            }
                        }
                        else
                        {
                            lstOtrasVentas[filaIndice].unidades = Convert.ToInt32(rowss.Cells[4].Value);

                        }
                        //lstOtrasVentas.FindIndex(i=>i.idObjVenta==)
                        //Int32 indiceLista = lstOtrasVentas.FindIndex(i => i.idObjVenta == IdObjetoExistente);
                        fnCalcularDescuento();
                        fnInsertarATable();

                    }
                    else if (e.ColumnIndex == 5)
                    {
                        if (Convert.ToInt32(rowss.Cells[5].Value)>0)
                        {
                            Double presioNeto = lstOtrasVentas[filaIndice].unidades * lstOtrasVentas[filaIndice].precioUnico;
                            if (Convert.ToInt32(cboTipoDescuento.SelectedValue) == 1)
                            {
                                if (Convert.ToInt32(rowss.Cells[5].Value) > 100)
                                {
                                    rowss.Cells[5].Style.BackColor = Color.Red;
                                    //lstOtrasVentas[filaIndice].precioNeto = presioNeto;
                                    fnMostrarMensaje(lblMsgDgOtrasVentas, true, "El Descuento no puede ser  mayor al 100% ");
                                    estadoTabla = false;
                                    return;
                                }
                                else
                                {
                                    lstOtrasVentas[filaIndice].descuentoCantidad = Convert.ToInt32(rowss.Cells[5].Value);
                                }
                            }
                            else if (Convert.ToInt32(cboTipoDescuento.SelectedValue) == 2)
                            {
                                if (presioNeto < Convert.ToInt32(rowss.Cells[5].Value))
                                {
                                    rowss.Cells[5].Style.BackColor = Color.Red;
                                    fnMostrarMensaje(lblMsgDgOtrasVentas, true, "El Descuento no puede ser mayor al Precio Neto ");
                                    //lstOtrasVentas[filaIndice].precioNeto = presioNeto;
                                    estadoTabla = false;
                                    return;
                                }
                                else
                                {
                                    lstOtrasVentas[filaIndice].descuentoCantidad = Convert.ToInt32(rowss.Cells[5].Value);
                                }
                            }

                        }
                        else
                        {
                            lstOtrasVentas[filaIndice].descuentoCantidad = Convert.ToInt32(rowss.Cells[5].Value);
                        }


                        fnCalcularDescuento();
                        fnInsertarATable();

                    }
                    
                }
            }
            

            //fnPintarCampos();
            //    fnCalcularTotales();
            //}
        }

        private void dgOtrasVentas_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (Convert.ToString(e.Row.Cells[0].Value) == "" || Convert.ToInt32(e.Row.Cells[0].Value) == 0)
            {

            }
            else
            {
                //e.Row.Cells[5].Value = "0";
            }
        }


        private void dgOtrasVentas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;
            if (dgOtrasVentas.CurrentCell.ColumnIndex == 5)
            {
                if (txt != null)
                {
                    txt.KeyPress += new KeyPressEventHandler(dText_KeyPress);
                }
                else
                {
                }

            }
            //else
            //{
            //    txt.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
            //    txt.KeyPress += new KeyPressEventHandler(dText_KeyPressMayusculas);
            //}


            if (dgOtrasVentas.CurrentCell.ColumnIndex == 6) //Desired Column
            {

                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo nfi = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;

            char decSeperator;

            decSeperator = nfi.CurrencyDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar) | e.KeyChar == decSeperator))
            {
                e.Handled = true;
            }
            // only allow one Double point
            if (e.KeyChar == decSeperator
                && (sender as TextBox).Text.IndexOf(decSeperator) > -1)
            {
                e.Handled = true;
            }
        }

        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboTipoDocumento, lblMsgTipoDocumento, pbTipDocumento);
            estTipDocumento = result.Item1;
            lblTipDocumento = result.Item2;
            if (CargoForm==true)
            {
                fnLlenarTablaCod(cboTipoDocEmitir, "DOVE", Convert.ToInt32(cboTipoDocumento.SelectedValue),0);
            }
        }

        private void txtClientesN_A_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtClientesN_A, lblMsgNombresRS, pbNombres_razonS,true,true,false,0,0,0,200,"Busque y Elija un Cliente");
            estCliente = result.Item1;
            lblCliente = result.Item2;
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtDireccion, lblMsgDireccion, pbDireccion,true, true, false, 0, 0, 0, 200, "Busque y Elija un Cliente");
            estCliente = result.Item1;
            lblCliente = result.Item2;
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtTelefono, lblMsgTelefono, pbTelefono,false, true, false, 0, 0, 0, 200, "Busque y Elija un Cliente");
            estCliente = result.Item1;
            lblCliente = result.Item2;
        }

        private void txtTotPrecio_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

        }

        private void txtTotPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        public static void fnRecuperarTipoPago(List<Pagos> lstPagos)
        {
            lstPagosTrand= lstPagos;
            if (lstPagosTrand.Count>0)
            {
                //fnLimpiarControles();
                fnRecuperarEstadoGenVenta(true);
            }
            else
            {
                frmOtrasVentas fr = new frmOtrasVentas();
                fr.fnHabilitarControles(false);
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Variables.bitActivePrintDirect = true;
            if (Variables.bitActivePrintDirect)
            {
                int idVenta = Convert.ToInt32("00001");
                BLDocumentoVenta objVenta = new BLDocumentoVenta();
                DocumentoVenta[] lstVenta = new DocumentoVenta[1];
                List<DetalleVenta> lstDetalleVen = new List<DetalleVenta>();
                DetalleVenta detVent =new DetalleVenta();

                lstVenta = objVenta.blListarDocVenta(idVenta).ToArray();
                lstDetalleVen = objVenta.blListarDetalleVenta(idVenta);
                //lstDetalleVen.Add(detVent);
                GenericMasterDetail<DocumentoVenta, DetalleVenta> genericMasterDetail = new GenericMasterDetail<DocumentoVenta, DetalleVenta>
                {
                    Header = lstVenta[0],
                    Detail = lstDetalleVen,
                    empresa = new Empresa
                    {
                        RazonSocial = Variables.gsEmpresa,
                        Ruc = Variables.gsRuc
                    },
                    sucursal = Variables.sucursal
                };

                GenericDocument<DocumentoVenta, DetalleVenta> document = new GenericDocument<DocumentoVenta, DetalleVenta>
                {
                    Document = genericMasterDetail
                };

                string jsonDocument = JsonConvert.SerializeObject(document);
                PrintRequest printRequest = new PrintRequest
                {
                    Identity = "",
                    OperatorId = "",
                    StringifiedDocumentData = jsonDocument,
                    NumberOfCopies = 1,
                    //TargetPrinterName = Variables.gsImpresora,
                    TargetPrinterName = "EPSON099E3E (L395 Series)",
                    TemplateName = "VentaHusat",
                    PaperWidth = 80
                };
                FunGeneral.fnImprimirVoucher(printRequest);
            }
            else
            {
                Int32 idVenta = 0;
                frmImpresion frmImpre = new frmImpresion();
                idVenta = Convert.ToInt32("0001");
                frmImpre.fnInicio(0, "Imprimir Documento de Venta", idVenta);
            }
        }

        private Int32 fnTotalRowsParaFor()
        {
            Int32 contador = 0;
            for (Int32 i = 0; i < dgOtrasVentas.RowCount; i++)
            { 
                contador = (Convert.ToString(dgOtrasVentas.Rows[i].Cells[0].Value)!="") ? dgOtrasVentas.RowCount : dgOtrasVentas.RowCount - 1;
            }
            return contador;
        }
        private String FormatearCadena(String nombre)
        {
            if (nombre != String.Empty)
            {
                String inicial;
                nombre = nombre.ToLower();
                inicial = nombre.Substring(0, 1);
                inicial = inicial.ToUpper();
                nombre = inicial + nombre.Remove(0, 1);
            }
            return nombre;
        }
        private List<OtrasVentas> fnGenerarDetalleOtrasVentas()
        {
            List<OtrasVentas> lstDC = new List<OtrasVentas>();
            
            for (Int32 i = 0; i < lstOtrasVentas.Count; i++)
            {
                DataGridViewRow rowss = dgOtrasVentas.Rows[i];
                lstDC.Add(
                new OtrasVentas
                {
                    idObjVenta = lstOtrasVentas[i].idObjVenta,
                    DetalleVentas = FormatearCadena(lstOtrasVentas[i].DetalleVentas),
                    precioUnico = lstOtrasVentas[i].precioUnico,
                    unidades = lstOtrasVentas[i].unidades,
                    descuentoPrecio = lstOtrasVentas[i].descuentoPrecio,
                    precioNeto = lstOtrasVentas[i].precioNeto,
                    NombreDocumento = Convert.ToString(cboTipoDocEmitir.Text),
                    cUsuario = Variables.gsCodUser
                }) ;

            }

            return lstDC;
        }

        private List<TotalPagosVenta> fnGenerarTotalesOtrasVentas()
        {
            List<TotalPagosVenta> lstDC = new List<TotalPagosVenta>();            
                lstDC.Add(TotVenta) ;        

            return lstDC;
        }
        private List<DocumentoVenta> fnlstDocumentoVenta()
        {
            List<DocumentoVenta> lstDocVenta = new List<DocumentoVenta>();
            lstDocVenta.Add(DocumentoVenta);

            return lstDocVenta;
        }

        private void cboTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public Boolean fnListarVentas(Int32 numPaginacion, Int32 tipoConPagina)
        {
            BLOtrasVenta objTipoVenta = new BLOtrasVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtResp = new DataTable();
            List<TipoVenta> lsTipoVenta = new List<TipoVenta>();
            Int32 filas = 20;

            try
            {

                dtResp = objTipoVenta.blListarVentas(
                    0,
                    txtBusq.Text.ToString(),
                    chkHabilitarFechas.Checked,
                    dtHFechaInicio.Value,
                    dtHfechaFinal.Value,
                    numPaginacion,
                    tipoConPagina
                    );
                Int32 totalResultados = dtResp.Rows.Count;
                Int32 y;
                if (tipoConPagina == -1)
                {
                    y = 0;
                }
                else
                {
                    tabInicio = (numPaginacion - 1) * filas;
                    y = tabInicio;
                }
                Int32 Totregistros = 0;
                foreach (DataRow dr in dtResp.Rows)
                {
                    y++;
                    Totregistros =Convert.ToInt32(dr["ROW_COUNT"]);
                    dgListaVentas.Rows.Add(y,dr["codigoVenta"],
                                           dr["Servicio"]+" "+dr["Equipo"]+" "+dr["Accesorio"],
                                           dr["dFechaRegistro"],
                                           dr["PrecioNeto"]);
                }
                dgListaVentas.Visible = true;
                if (tipoConPagina == -1)
                {
                    Int32 totalRegistros = Convert.ToInt32(Totregistros);
                    gbPaginacion.Visible = true;
                    fnCalcularPaginacion(totalRegistros, filas, totalResultados, cboPagina, btnTotalPaginas, btnRegistros, btnTotalRegistros);

                }


                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnListarProveedorActivo", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTipoVenta = null;
                lsTipoVenta = null;
            }
        }

        private void fnCalcularPaginacion(Int32 totalRegistros, Int32 filas, Int32 totalResultados, ComboBox cboPaginacion, SiticoneCircleButton btnNumPagina, SiticoneCircleButton btnRegistros, SiticoneCircleButton btnTotalRegistros)
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


            cboPaginacion.Items.Clear();

            for (Int32 i = 1; i <= cantidadPaginas; i++)
            {
                cboPaginacion.Items.Add(i);

            }

            btnNumPagina.Text = Convert.ToString(cantidadPaginas);
            btnRegistros.Text = Convert.ToString(totalResultados);
            btnTotalRegistros.Text = Convert.ToString(totalRegistros);
            cboPaginacion.SelectedIndex = 0;
        }

        private void txtBusq_KeyPress(object sender, KeyPressEventArgs e)
        {
            fnListarVentas(0, -1);
        }

        private void dgListaVentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgListaVentas.Columns[e.ColumnIndex].Name == "LvbtnImprimir" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgListaVentas.Rows[e.RowIndex].Cells["LvbtnImprimir"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\Impresora.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgListaVentas.Rows[e.RowIndex].Height = 40;
                this.dgListaVentas.Columns[e.ColumnIndex].Width = 40;


                e.Handled = true;

            }
        }

        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                fnMostrarMensaje(lblMsgDgOtrasVentas,false, "");

                
            }
            else
            {
                e.Handled = true;
                fnMostrarMensaje(lblMsgDgOtrasVentas,true, "Porfavor Ingrese Solo Numeros");
            }

        }




        //private void fnPintarCampos()
        //{
        //    for (Int32 i = 0; i < dgOtrasVentas.ColumnCount; i++)
        //    {

        //        if (dgOtrasVentas.Columns[i].Name == "DESCUENTO")
        //        {
        //            for (Int32 j = 0; j < dgOtrasVentas.RowCount; j++)
        //            {
        //                if (pnActivar == true)
        //                {
        //                    if (dgOtrasVentas.Rows[j].Cells[6].ReadOnly == true)
        //                    {
        //                        dgOtrasVentas.Rows[j].Cells[6].ReadOnly = false;
        //                        cboTipoDescuento.Enabled = true;
        //                    }
        //                    else
        //                    {
        //                        cboTipoDescuento.Enabled = false;
        //                    }
        //                }
        //                if (dgOtrasVentas.Rows[j].Cells[6].ReadOnly == true)
        //                {
        //                    dgOtrasVentas.Rows[j].Cells[6].Style.BackColor = Variables.ColorDescativadoFuerte;


        //                }
        //                else
        //                {
        //                    dgOtrasVentas.Rows[j].Cells[6].Style.BackColor = Color.White;
        //                }
        //            }

        //        }

        //    }
        //}

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result= FunValidaciones.fnValidarCombobox(cboMoneda, lblMsgMoneda, pbMoneda);
            estMoneda = result.Item1;
            lblMoneda = result.Item2;

            Int32 idMoneda = Convert.ToInt32(cboMoneda.SelectedValue ?? 0);

            Mon.cSimbolo = fnObtenerSimboloMoneda(idMoneda, lstMon);
            Mon.idMoneda = idMoneda;
            if (CargoForm == true)
            {
                //fnCalcularTotalAPagar(txtPrecioEquipo, txtCantidadEquipos, txtDescuentoEquipos, cboTipoDescuento1, txtTotalApagarEquipo, lblPrecioCambioEquipo);
                //txtTotPrecio.Text = fnCalcularPrecios(lblPrecioCambioEquipo, clsCMP.IdMonedaEntrada, clsCMP.PrecioEntrada, Mon);

                fnMostrarPrecioUnitario(1);
                if (Convert.ToInt32(cboMoneda.SelectedValue) == 0)
                {
                    //fnHabilitarControles(false);
                }
                else
                {
                    fnHabilitarControles(true);
                    fnInsertarATable();
                }
            }
        }

        private void dgOtrasVentas_SelectionChanged(object sender, EventArgs e)
        {
            //for (Int32 i=0;i<dgOtrasVentas.RowCount;i++)
            //{
            //for (Int32 j=0;j<dgOtrasVentas.ColumnCount;j++)
            //{
            if (Convert.ToInt32(dgOtrasVentas.CurrentRow.Cells[0].Value) != 0 )
            {
                if (Convert.ToInt32(dgOtrasVentas.CurrentRow.Cells[9].Value) != 2)
                {
                    dgOtrasVentas.CurrentRow.Cells[4].ReadOnly = false;

                }
                else
                {
                    dgOtrasVentas.CurrentRow.Cells[4].ReadOnly = true;
                }
                //dgOtrasVentas.CurrentRow.Cells[6].ReadOnly = false;
                if (lblMsgDgOtrasVentas.Visible != true  || estadoTabla==true)
                {
                    fnMostrarMensaje(lblMsgDgOtrasVentas,false, "");
                }
                return;
            }
            else
            {
                dgOtrasVentas.CurrentRow.Cells[4].ReadOnly = true;
                dgOtrasVentas.CurrentRow.Cells[5].ReadOnly = true;
                if (estadoTabla != false)
                {
                }
                if (lblMsgDgOtrasVentas.Visible != true)
                {
                    lblMsgForm.Visible = false;
                    fnMostrarMensaje(lblMsgDgOtrasVentas,true, "Para Poder Editar Debe Seleccionar un Item de Venta ⚠️      ");
                }
                return;
            }
            //}

            //}
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            fnLimpiarControles();
        }

        private void fnMostrarMensaje(Label lbl, Boolean visible, String msg)
        {
            lbl.BackColor = Variables.ColorWarning;
            lbl.Visible = visible;
            lbl.Text = msg;
        }

        private List<OtrasVentas> fnRecorrerGrilla()
        {
            OtrasVentas objOtrasVentas = new OtrasVentas();
            List<OtrasVentas> lstGuardarVenta = new List<OtrasVentas>();
            for (Int32 i=0;i<lstOtrasVentas.Count;i++)
            {
                objOtrasVentas = new OtrasVentas();
                objOtrasVentas.idObjVenta = lstOtrasVentas[i].idObjVenta;
                objOtrasVentas.precioUnico = lstOtrasVentas[i].precioUnicoCambio;
                objOtrasVentas.unidades = lstOtrasVentas[i].unidades;
                objOtrasVentas.descuentoCantidad = lstOtrasVentas[i].descuentoCantidad;
                objOtrasVentas.descuentoPrecio = lstOtrasVentas[i].descuentoPrecio;
                objOtrasVentas.dFechaRegistro = Variables.gdFechaSis;
                objOtrasVentas.iddUsuario = Variables.gnCodUser;
                objOtrasVentas.precioNeto = lstOtrasVentas[i].precioNeto;
                objOtrasVentas.idTipoDescuento = lstOtrasVentas[0].idTipoDescuento;
                objOtrasVentas.idTipoTransaccion = lstOtrasVentas[i].idTipoTransaccion;
                objOtrasVentas.idMoneda = lstOtrasVentas[i].idMoneda;
                objOtrasVentas.idCliente = Convert.ToInt32(txtIdCliente.Text);
                objOtrasVentas.IgvPorcentaje = lstOtrasVentas[0].IgvPorcentaje;
                objOtrasVentas.IgvPrecio = lstOtrasVentas[0].IgvPrecio;
                objOtrasVentas.TotalVenta = TotVenta.Total;

                lstGuardarVenta.Add(objOtrasVentas);
            }
            
            return lstGuardarVenta;
        }
        private Boolean fnValidarUnidadesDifCero()
       {
            Boolean estado = true;
            for(Int32 i=0;i<fnTotalRowsParaFor();i++)
            {
                if (Convert.ToInt32(dgOtrasVentas.Rows[i].Cells[4].Value) == 0 || Convert.ToString(dgOtrasVentas.Rows[i].Cells[4].Value)=="")
                {
                    estado = false;
                    return estado;
                }

            }
            return estado;
        }
        public static void fnRecuperarEstadoGenVenta(Boolean estado)
        {
            EstadoGenVenta = estado;
        }
        private Boolean fnMostrarVPDocumentoventa()
        {
            fnHabilitarControles(false);
            Consultas.frmVPOtrasVentas abrirFrmVPOtrasVentas = new Consultas.frmVPOtrasVentas();
            abrirFrmVPOtrasVentas.Inicio(fnlstDocumentoVenta(),/*lstOtrasVentas*/ fnGenerarDetalleOtrasVentas(),0);
            if (EstadoGenVenta == true)
            {
                EstadoGenVenta = false;
                 fnMostrarVentanaTipoPago();
            }
            else
            {
                fnHabilitarControles(true);
            }
            
            return EstadoGenVenta;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            

        }
        private void fnBuscarDocumentoVenta(String cCodVenta)
        {
            BLOtrasVenta objTipoVenta = new BLOtrasVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtResp = new DataTable();
            List<TipoVenta> lsTipoVenta = new List<TipoVenta>();
            Int32 filas = 20;
            List<xmlDocumentoVenta> xmlDocumentoVenta = new List<xmlDocumentoVenta>();
            xmlDocumentoVenta xmlDocVenta = new xmlDocumentoVenta();

            try
            {
                xmlDocVenta= objTipoVenta.blBuscarDocumentoVenta(cCodVenta);
                xmlDocumentoVenta.Add(xmlDocVenta);

                Consultas.frmVPOtrasVentas abrirFrmVPOtrasVentas = new Consultas.frmVPOtrasVentas();
                abrirFrmVPOtrasVentas.Inicio(xmlDocumentoVenta[0].xmlResponsablePago,xmlDocumentoVenta[0].xmlDetalleVentas,1);

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

        private void dgListaVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgListaVentas.Columns["LvbtnImprimir"].Index && e.RowIndex >= 0)
            {
                String cCodventa = Convert.ToString(dgListaVentas.Rows[e.RowIndex].Cells[1].Value);

                fnBuscarDocumentoVenta(cCodventa);
            }

        }

        //private Boolean fnListarEquipos(String equipos)
        //{
        //    clsUtil objUtil = new clsUtil();
        //    xmlDocumentoVenta objDocumento = new xmlDocumentoVenta();
        //    Int32 totalResultados;
        //    Int32 y = 0;
        //    DataTable dt = new DataTable();
        //    DataGridView tabla = new DataGridView();
        //    Double precio = 0;
        //    try
        //    {

        //            XmlSerializer serializer = new XmlSerializer(typeof(xmlDocumentoVenta));
        //            using (TextReader reader = new StringReader(equipos))
        //            {
        //            //de esta manera se deserializa
        //                objDocumento = (xmlDocumentoVenta)serializer.Deserialize(reader);
        //            }

        //            dt.Clear();
        //            dt.Columns.Add("ID");
        //            dt.Columns.Add("N°");
        //            dt.Columns.Add("EQUIPO");
        //            dt.Columns.Add("PRECIO");
        //            dt.Columns.Add("PRECIO NORMAL");
        //            dt.Columns.Add("ELEGIR", typeof(Boolean));
        //            Boolean estado = false;
        //            totalResultados = objDocumento.xmlDetalleVentas.Count;
        //            for (int i = 0; i <= totalResultados - 1; i++)
        //            {
        //                y += 1;
        //                if (objAcc.Item[i].BEstado)
        //                {

        //                    object[] row = {
        //                        objAcc.Item[i].IdPlanEquipo,
        //                        y,
        //                        objAcc.Item[i].Equipos,
        //                        "S/ " + String.Format("{0:0.00}", objAcc.Item[i].CPrecio),
        //                        Convert.ToDouble(objAcc.Item[i].CPrecio),
        //                        Convert.ToBoolean(false)
        //                    };
        //                    dt.Rows.Add(row);
        //                }

        //            }

        //            tabla.DataSource = dt;
        //            tabla.Rows[0].Cells[5].Value = true;
        //            tabla.Columns[0].Visible = false;
        //            tabla.Columns[1].Width = 20;
        //            tabla.Columns[2].Width = 200;
        //            tabla.Columns[3].Width = 50;
        //            tabla.Columns[4].Visible = false;
        //            tabla.Columns[5].Width = 50;


        //            return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
        //        return false;

        //    }



        //}







        private void fnMostrarVentanaTipoPago()
        {
            frmTipoPago frmTipo = new frmTipoPago();
            frmTipo.Inicio(2, Convert.ToDouble(TotVenta.Total),Mon.cSimbolo);
            //return EstadoGenVenta;
        }

        private void chkAbilitarDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAbilitarDescuento.Checked==true)
            {
                fnMostrarCantidadDescuento(0);
                cboTipoDescuento.SelectedValue = 0;
                fnActivarComboDescuento(false);
                chkAbilitarDescuento.Checked = false;

            }
        }

        private void cboTipoDocEmitir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CargoForm==true)
            {
                var result = FunValidaciones.fnValidarCombobox(cboTipoDocEmitir, lblMsgDocumentoEmitir, pbTipoDocumentoEmitir);
                estDocumentoEmitir = result.Item1;
                lblDocumentoEmitir = result.Item2;
                
            }
        }

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {

            estCliente = Convert.ToInt32(txtIdCliente.Text) == 0 ? false:true ;
        }

        private void fnValidarCamposCliente(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboTipoPersona, lblMsgTipoPersona, pbTipPersona);
            estTipPersona = result.Item1;
            lblTipPersona = result.Item2;
            var result1 = FunValidaciones.fnValidarCombobox(cboTipoDocumento, lblMsgTipoDocumento, pbTipDocumento);
            estTipDocumento = result1.Item1;
            lblTipDocumento = result1.Item2;
            txtClientesN_A_TextChanged(sender, e);
            txtDireccion_TextChanged(sender, e);
            txtIdCliente_TextChanged(sender, e);

        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Boolean blnResultado = false;
            BLOtrasVenta objOtrasVentas = new BLOtrasVenta();
            fnValidarCamposCliente(sender,e);

            List<OtrasVentas> lstDetalleVenta = fnRecorrerGrilla();
            if (estCliente == true && estTipDocumento==true && estTipPersona==true )
            {
                if (estDocumentoEmitir == true)
                {
                    if (lstDetalleVenta.Count > 0)
                    {
                        if (fnValidarUnidadesDifCero())
                        {
                            if (estadoTabla == true)
                            {


                                if (fnMostrarVPDocumentoventa())
                                {
                                    List<xmlDocumentoVenta> xmlDocumentoVenta = new List<xmlDocumentoVenta>();
                                    xmlDocumentoVenta.Add(new xmlDocumentoVenta
                                    {
                                       xmlResponsablePago= fnlstDocumentoVenta(),
                                       xmlDetalleVentas= fnGenerarDetalleOtrasVentas(),
                                       xmlTotalesVenta= fnGenerarTotalesOtrasVentas()
                                    });
                                    blnResultado = objOtrasVentas.blGuardarOtrasVentas(fnRecorrerGrilla(), lstPagosTrand, xmlDocumentoVenta, lnTipoCon);
                                    if (blnResultado)
                                    {
                                        //blnResultado = fnObtenerPreciosxProductoxUM(idEquipo);
                                        //if (!blnResultado)
                                        //    MessageBox.Show("No se ha cargado correctamente Listado de Precios por Producto y unidad de medida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        MessageBox.Show("Venta Generada Correctamente. ✔✔", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        FunValidaciones.fnHabilitarBoton(btnGuardar, false);
                                        fnLimpiarControles();
                                        fnHabilitarControles(true);
                                        //fnLimpiarControles();

                                    }
                                    else
                                    {
                                        MessageBox.Show("datos duplicados");
                                    }
                                }
                                else
                                {
                                    fnMostrarMensaje(lblMsgForm, true, "Seguir Editando...");
                                    fnHabilitarControles(true);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Verifique el descuento de su tabla");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La Columna Unidades no Pueden ser CERO", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Ud. no Seleccionó Algun Item de Venta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Porfavor elija Documento de Venta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Porfavor Complete los Datos del Cliente","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            //fnHabilitarControles(false);
            //fnLimpiarControles();
        }

        private void btnStockAccesorios_Click(object sender, EventArgs e)
        {
            fnMostrarDtgrid(1);
        }

        private void gbStock_Click(object sender, EventArgs e)
        {
            dgDetStock.Visible = false;
        }
        private void fnMostrarDtgrid(Int32 condicion)
        {
            if (dgDetStock.Visible==true)
            {
                dgDetStock.Visible = false;
            }
            else
            {
                fnObtenerStockDetalles(condicion, 1);
            }

        }
        private void btnStockEquipos_Click(object sender, EventArgs e)
        {
            fnMostrarDtgrid(0);
        }

        private void btnStockEquipos_DoubleClick(object sender, EventArgs e)
        {

        }

       
    }
}
