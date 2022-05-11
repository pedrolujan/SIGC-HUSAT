using CapaEntidad;
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
//using System.Windows.Input;
using System.Xml.Serialization;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Funciones.Models;
using wfaIntegradoCom.Impresiones;
using wfaIntegradoCom.Mantenedores;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

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
        static Cliente clsClienteDocumentoV = new Cliente();
        static Cliente clsClienteAntecesor = new Cliente();
        static List<Vehiculo> lstvehiculo = new List<Vehiculo>();
        static List<ModeloVehiculo> lstModelo = new List<ModeloVehiculo>();
        static List<MarcaVehiculo> lstMarca = new List<MarcaVehiculo>();
        static List<DetalleVenta> lstDventa = new List<DetalleVenta>();
        static List<DocumentoVenta> lstdocumentoV = new List<DocumentoVenta>();
        //static  CambioPrecioOtrasVentas cPOtrasVentas = new CambioPrecioOtrasVentas();
        public static Moneda Mon = new Moneda();
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
        static Int32 lnTipoConCambio = 0;
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
        static OtrasVentas  clsObjetoEsxistente = new OtrasVentas();
        static List<StokAccesorios> lstAtokAccesorios = new List<StokAccesorios>();
        static OtrasVentas clsOtrasVentaGeneral = new OtrasVentas();
       static Int32 IdObjetoExistente = 0;
        static DateTime dtFechaTitularidad = Variables.gdFechaSis;
        String msgPLACA;
        static Boolean estMostrarGb = false;
        static Boolean estOcultarFila = false;
        Boolean estadoTabla, estMoneda, estTipPersona, estTipDocumento, estTipoDescuento, estPLACA, estadoFechaPago, estCliente, estDocumentoEmitir, estImporte;
        String lblMoneda, lblTipPersona, lblTipDocumento, lblTipoDescuento,lblCliente, lblDocumentoEmitir;
        public  void fnObtenerObjVentas(OtrasVentas clsOtrasVentas)
        {

            if ((lstOtrasVentas.Count==0 && clsOtrasVentas.idTipoTransaccion==4) || (lstOtrasVentas.Count == 1 && lstOtrasVentas[0].idTipoTransaccion==4 && clsOtrasVentas.idTipoTransaccion == 4))
            {
                estOcultarFila = false;
            }
            else if((lstOtrasVentas.Count == 1 && clsOtrasVentas.idTipoTransaccion == 4))
            {
                estOcultarFila = false;
            }
            else
            {
                estOcultarFila = true;

            }
            OtrasVentas valorRepetido = lstOtrasVentas.Find(i=>(i.idObjVenta== clsOtrasVentas.idObjVenta) && (i.idTipoTransaccion==clsOtrasVentas.idTipoTransaccion));
            OtrasVentas ifServicio = lstOtrasVentas.Find(i=>(i.idTipoTransaccion==4));
            //if (ifServicio != null)
            //{                
            //  MessageBox.Show("Opcion restringida-> no puedes seleccionar varios items", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}
            //else
            {
                //if(clsOtrasVentas.idTipoTransaccion==4 && lstOtrasVentas.Count > 0)
                //{
                //    MessageBox.Show("Opcion restringida-> no puedes mesclar productos con servicios", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //}
                //else
                {
                    if (valorRepetido == null)
                    {

                        if (IdObjetoExistente == 0)
                        {
                            if (ifServicio != null)
                            {
                                MessageBox.Show("Opcion restringida-> no puedes seleccionar varios items", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                            else
                            {
                                if (clsOtrasVentas.idTipoTransaccion == 4 && (clsObjetoEsxistente.idTipoTransaccion!=4 || lstOtrasVentas.Count>0))
                                {
                                    if (lstOtrasVentas.Count==0)
                                    {
                                        lstOtrasVentas.Add(clsOtrasVentas);
                                        estMostrarGb = fnActivarEstados(lstOtrasVentas[0].idTipoTransaccion, lstOtrasVentas[0].idObjVenta, 0);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Opcion restringida-> no puedes mesclar productos con servicios", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }

                                }
                                else
                                {
                                    lstOtrasVentas.Add(clsOtrasVentas);
                                    estMostrarGb = fnActivarEstados(lstOtrasVentas[0].idTipoTransaccion, lstOtrasVentas[0].idObjVenta, 0);

                                }

                            }
                        }
                        else
                        {

                            Int32 indiceLista = lstOtrasVentas.FindIndex(i => i.idObjVenta == IdObjetoExistente);

                            lstOtrasVentas[indiceLista] = clsOtrasVentas;
                            estMostrarGb = fnActivarEstados(lstOtrasVentas[0].idTipoTransaccion, lstOtrasVentas[0].idObjVenta, 0);

                        }



                    }
                    else
                    {
                        MessageBox.Show("Este Item ya Existe Ingrese uno Diferente", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
            }
            

            

            
        }

        private Boolean fnActivarEstados(Int32 idTransac,Int32 idObjetoV,Int32 tipoOpcion)
        {
            Boolean estad = false;
            if (tipoOpcion == 0)
            {
                if (idTransac == 4)
                {
                    estad = true;
                    if (idObjetoV==1)
                    {
                        lnTipoConCambio = -1;
                    }else if (idObjetoV==2)
                    {
                        lnTipoConCambio= -2;
                    }

                }
                else 
                {
                    estad = false;
                }
            }
            
            return estad;
        }
        private void fnCalcularPreciosTabla()
        {
            for (Int32 i=0;i< lstOtrasVentas.Count;i++)
            {

                OtrasVentas cls = lstOtrasVentas[i];
                cls.unidades = cls.unidades == 0 ? 1 : cls.unidades;
                cls.descuentoPrecio = fnConvertirATipoDescuento(cls.precioUnico,Convert.ToInt32(cboTipoDescuento.SelectedValue),cls.descuentoCantidad);
                Double pNeto= (cls.precioUnico * cls.unidades) - cls.descuentoPrecio;
                cls.precioNeto = fnCalcularPrecios(cls.idMoneda, pNeto, Mon);
                if (Mon.idMoneda == 2)
                {
                    cls.precioUnicoCambio = fnCalcularPrecios(cls.idMoneda, cls.precioUnico, Mon);
                }
                else
                {
                    cls.precioUnicoCambio = cls.precioUnico;
                }
                lstOtrasVentas[i] = cls;
            }
        }
        private void fnInsertarATable()
        {
            //siticoneGroupBox2.Visible = false;
            dgOtrasVentas.Rows.Clear();
            Int32 indiceLista = lstOtrasVentas.FindIndex(j => j.idTipoTransaccion == 2);
            for (Int32 i= 0; i < lstOtrasVentas.Count; i++)
            {
                OtrasVentas cls = lstOtrasVentas[i];
                String PrecioUnicoMostrar = "";
                
                String PrecioUnico = string.Format("{0:0.00}", cls.precioUnico);
                String PrecioUnicoCambio = string.Format("{0:0.00}", cls.precioUnicoCambio);
                String PrecioNeto = string.Format("{0:0.00}", cls.precioNeto);

                dgOtrasVentas.Rows.Add(
                    cls.idObjVenta,
                    i + 1,
                    cls.DetalleVentas,
                    cls.precioUnicoCambio != cls.precioUnico ? $"{cls.simbMoneda} {PrecioUnico} {" -> "} {Mon.cSimbolo} { PrecioUnicoCambio}" : $"{cls.simbMoneda} { PrecioUnico}",
                    cls.unidades,
                    cls.descuentoCantidad,
                  $"{Mon.cSimbolo} {PrecioNeto}",
                    null,
                    null,
                    cls.idTipoTransaccion
                );
                i += 1;
                
                
            }
            if (indiceLista != -1)
            {
                dgOtrasVentas.Rows[indiceLista].Cells[4].ReadOnly = true;
                dgOtrasVentas.Rows[indiceLista].Cells[4].Style.BackColor = Variables.ColorDescativadoFuerte;
            }
            
            //fnCalcularDescuento();
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
                    TotVenta.Total = TotalGeneral;
                    DocumentoVenta.nMontoTotal = TotalGeneral;

                    txtTotal.Text = Mon.cSimbolo + " " + string.Format("{0:0.00}", DocumentoVenta.nMontoTotal);
                    CalcIgv = (TotVenta.Total * fnDebolverIgv()) / 100;

                    TotVenta.Igv = CalcIgv;
                    DocumentoVenta.nIGV = CalcIgv;

                    lstOtrasVentas[0].IgvPorcentaje = fnDebolverIgv();
                    lstOtrasVentas[0].IgvPrecio = CalcIgv;
                    txtShowCalcIgv.Text = Mon.cSimbolo + " " + string.Format("{0:0.00}", DocumentoVenta.nIGV);

                    SubTotal = TotalGeneral - CalcIgv;
                    TotVenta.Subtotal = SubTotal;
                    DocumentoVenta.nSubtotal = SubTotal;

                    txtSubTotal.Text = Mon.cSimbolo + " " + string.Format("{0:0.00}", DocumentoVenta.nSubtotal);
                    TotVenta.SimboloMoneda = Mon.cSimbolo;
                    DocumentoVenta.SimboloMoneda= Mon.cSimbolo;
                    TotVenta.idMoneda = Mon.idMoneda;
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

            FunGeneral.fnLlenarTablaCodTipoCon(cboMotivo, "MOTI", false);
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
            gbDatosVehiculo.Visible = false;
            estMostrarGb = false;
            pnActivar = false;
            CargoForm = false;
            fncambiarPosicionGB(estMostrarGb);
            FunValidaciones.fnColorBtnGuardar(btnGuardar);
            clsOtrasVentaGeneral = new OtrasVentas();
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
                fnLimpiarDatosActecesor();
                dgConsulta.Visible = false;

                cboMoneda.MouseWheel +=  new MouseEventHandler(FunGeneral.cbo_MouseWheel);
                cboTipoPersona.MouseWheel +=  new MouseEventHandler(FunGeneral.cbo_MouseWheel);
                cboTipoDocumento.MouseWheel +=  new MouseEventHandler(FunGeneral.cbo_MouseWheel);
                cboTipoDescuento.MouseWheel +=  new MouseEventHandler(FunGeneral.cbo_MouseWheel);
                cboTipoDocEmitir.MouseWheel +=  new MouseEventHandler(FunGeneral.cbo_MouseWheel);
                cboMoneda.MouseWheel +=  new MouseEventHandler(FunGeneral.cbo_MouseWheel);
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
                    
                    fnCalcularPreciosTabla();
                    fnInsertarATable();
                }
                else
                {
                    fnInsertarATable();
                    fnHabilitarDescuento(false);
                }

                
                
            }


        }

        private Double fnConvertirATipoDescuento(Double precioOriginal, Int32 idTipoDescuento, Double descuento)
        {
            Double precioDescuento;
            if (idTipoDescuento == 1)
            {
                precioDescuento = (precioOriginal * descuento) / 100;
            }
            else
            {
                precioDescuento = descuento;
            }
            return precioDescuento;
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
                    clsClienteDocumentoV = lstPros;

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
        private Double fnCalcularPrecios(Int32 idMonedaEntrada, Double PrecioEntrada, Moneda m)
        {
            BLMoneda objMoneda = new BLMoneda();           

            CambioMonedaVenta clsCambioMoneda;            

            clsCambioMoneda = objMoneda.blDevolverCambioMoneda(idMonedaEntrada, PrecioEntrada, m.idMoneda);
            string precioEntradaFormatedo = string.Format("{0:0.00}", PrecioEntrada);
            string PrecioSalidaFormat = string.Format("{0:0.00}", clsCambioMoneda.PrecioSalida);
            string precioCambioMoneda = string.Format("{0:0.00}", clsCambioMoneda.PrecioCambio);
            
            return clsCambioMoneda.PrecioSalida;
        }
        private void fnColoresBotonStock(Int64 Stock)
        {
            if (Stock > 10)
            {
                btnStockEquipos.FillColor = Variables.ColorSuccess;
                btnStockEquipos.BackColor = Variables.ColorSuccess;
                //fnMostrarMensaje(lblMsgDgOtrasVentas ,false, "");
            }
            else if (Stock <= 10)
            {
                btnStockEquipos.FillColor = Variables.ColorWarning;
                btnStockEquipos.BackColor = Variables.ColorWarning;
                if (Stock < 10)
                {
                    //fnMostrarMensaje(lblMsgDgOtrasVentas,true, "Advertencia: Stock Menor a 10 Unidades");
                }
            } else if (Stock <= 0)
            {
                btnStockEquipos.FillColor = Variables.ColorError;
                btnStockEquipos.BackColor = Variables.ColorError;
                //fnMostrarMensaje(lblMsgDgOtrasVentas,true, "Advertencia: Stock Insuficiente para la Venta");
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
            


            //for (Int32 i = 0; i < fnTotalRowsParaFor(); i++)
            //{
            //    if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)
            //    {
            //        dgOtrasVentas.Rows[i].Cells[3].Value = cellSimboloMoneda + " " + String.Format("{0:0.00}", Convert.ToDouble(dgOtrasVentas.Rows[i].Cells[4].Value)) + "  =>  " + fnCalcularPrecios(lblMostrarPrecioCambio, cellIdMoneda, Convert.ToDouble(dgOtrasVentas.Rows[i].Cells[4].Value), Mon);
            //    }
            //    else
            //    {

            //        dgOtrasVentas.Rows[i].Cells[3].Value = cellSimboloMoneda + " " + String.Format("{0:0.00}", Convert.ToDouble(dgOtrasVentas.Rows[i].Cells[4].Value));
            //    }

            //}


        }
        private void dgOtrasVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 numfilas = fnTotalRowsParaFor();
            Int32 posicionColumna = e.ColumnIndex;
            Int32 posicionFila = 0;
            if (e.RowIndex!=-1)
            {
                 posicionFila = e.RowIndex;
                //siticoneGroupBox2.Visible = true;
            }
            DataGridViewRow filaSeleccionada = dgOtrasVentas.Rows[posicionFila];

            if (posicionColumna == dgOtrasVentas.Columns["dgbtnNuevo"].Index && e.RowIndex >= 0)
            {                
                fnProcesarDatos(filaSeleccionada);
                fnLimpiarDatosActecesor();
            }

            if (posicionColumna == dgOtrasVentas.Columns["dgbtnEliminar"].Index && e.RowIndex >= 0)
            {
                 Int32 idObJeto = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                OtrasVentas obj = fnObtenerObjetoSeleccionado(idObJeto, lstOtrasVentas);
                //if (obj.idTipoTransaccion==4)
                //{
                    estMostrarGb = false;
                //}
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
                gbDatosVehiculo.Visible = estMostrarGb;
                fncambiarPosicionGB(estMostrarGb);
            }
        }

        private void fnProcesarDatos(DataGridViewRow filaSeleccionada)
        {
            if (cboTipoDescuento.Enabled == true)
            {
                cboTipoDescuento.SelectedValue = 0;
                fnActivarComboDescuento(false);
                fnMostrarCantidadDescuento(0);
                chkAbilitarDescuento.Checked = false;
            }
            IdObjetoExistente = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
            clsObjetoEsxistente = IdObjetoExistente!=0?lstOtrasVentas[0]:new OtrasVentas();
            frmListarTipoVentas frmEquipo = new frmListarTipoVentas();
            frmEquipo.Inicio(1);
            fnCalcularPreciosTabla();
            fnInsertarATable();
            fnHabilitarDescuento(false);
            estadoTabla = true;

            gbDatosVehiculo.Visible = estMostrarGb;
            dgOtrasVentas.AllowUserToAddRows=estOcultarFila;
            fncambiarPosicionGB(estMostrarGb);
        }
        private void fncambiarPosicionGB(Boolean estado)
        {
            Int32 posScroll = tabControl1.TabPages[0].AutoScrollPosition.Y;
            if (estado)
            {
                gbDatosVehiculo.Visible = estado;
                gbPrecios.Location = new Point(3, (756 + posScroll));
            }
            else
            {
                gbDatosVehiculo.Visible = estado;
           
                gbPrecios.Location = new Point(4, (541 + posScroll));
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
                //if (lblMsgForm.Text=="")
                //{
                //    if ((Convert.ToDouble(rowss.Cells[6].Value) < CalcTotItem) && rowss.Cells[6].ReadOnly == false)
                //    {
                //        //fnMostrarMensaje(lblMsgForm, false, "");
                //        rowss.Cells[6].Style.BackColor = Color.White;

                //        returnEstado= true;
                //    }
                //    else if ((Convert.ToDouble(rowss.Cells[6].Value) > CalcTotItem) && rowss.Cells[6].ReadOnly == false)
                //    {
                //        fnMostrarMensaje(lblMsgForm, true, "El Descuento no Puede ser Mayor al Precio Neto");
                //        rowss.Cells[6].Style.BackColor = Color.Red;
                //        returnEstado= false;
                //    }
                    
                //}

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
            DataGridViewCell filaSeleccionada = rowss.Cells[e.ColumnIndex];
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
                                fnAlertas("Stock Insuficiente..", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                estadoTabla = false;
                                return;
                            }
                            else
                            {
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
                        fnCalcularPreciosTabla();
                        fnInsertarATable();

                    }
                    else if (e.ColumnIndex == 5)
                    {
                        Int32 idTipoDescuento = Convert.ToInt32(cboTipoDescuento.SelectedValue);
                        if (Convert.ToInt32(filaSeleccionada.Value)>0)
                        {
                            Double presioNeto = lstOtrasVentas[filaIndice].unidades * lstOtrasVentas[filaIndice].precioUnico;
                            if (idTipoDescuento == 1)
                            {
                                if (Convert.ToInt32(filaSeleccionada.Value) > 100)
                                {
                                    rowss.Cells[5].Style.BackColor = Color.Red;
                                    fnAlertas("Es descuento no puede ser mayor al 100%","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                    estadoTabla = false;
                                    //return;
                                }
                                else
                                {
                                    lstOtrasVentas[filaIndice].descuentoCantidad = Convert.ToDouble(rowss.Cells[5].Value);
                                    estadoTabla = true;
                                }
                            }
                            else if (idTipoDescuento == 2)
                            {
                                if (presioNeto < Convert.ToDouble(filaSeleccionada.Value))
                                {
                                    rowss.Cells[5].Style.BackColor = Color.Red;
                                    fnAlertas("El Descuento no puede ser mayor al Precio Neto ", "Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                    //lstOtrasVentas[filaIndice].precioNeto = presioNeto;
                                    estadoTabla = false;
                                    return;
                                }
                                else
                                {
                                    lstOtrasVentas[filaIndice].descuentoCantidad = Convert.ToDouble(rowss.Cells[5].Value);
                                    estadoTabla = true;
                                }
                            }

                        }
                        else
                        {
                            lstOtrasVentas[filaIndice].descuentoCantidad = Convert.ToInt32(rowss.Cells[5].Value);
                        }


                        fnCalcularPreciosTabla();
                        fnInsertarATable();

                    }
                    
                }
            }
            

            //fnPintarCampos();
            //    fnCalcularTotales();
            //}
        }
        private void fnAlertas(String texto,String titulo, MessageBoxButtons boton, MessageBoxIcon icono)
        {
            MessageBox.Show(texto,titulo, boton,icono);
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
                //fnRecuperarEstadoGenVenta(true);
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
        private List<DetalleVenta> fnGenerarDetalleOtrasVentas()
        {
            List<DetalleVenta> lstDC = new List<DetalleVenta>();
            
            for (Int32 i = 0; i < lstOtrasVentas.Count; i++)
            {
                DataGridViewRow rowss = dgOtrasVentas.Rows[i];
                lstDC.Add(
                new DetalleVenta
                {

                    Numeracion = i + 1,
                    Descripcion = FunGeneral.FormatearCadenaTitleCase(lstOtrasVentas[i].DetalleVentas),
                    idTipoTarifa = 0,
                    PrecioUni = lstOtrasVentas[i].precioUnico,
                    Descuento = lstOtrasVentas[i].descuentoPrecio,
                    gananciaRedondeo = 0,
                    TotalTipoDescuento = lstOtrasVentas[i].descuentoPrecio,
                    IdTipoDescuento = Convert.ToInt32(cboTipoDescuento.SelectedValue),
                    Cantidad = lstvehiculo.Count(),
                    Couta = 1,
                    Importe = lstOtrasVentas[i].precioNeto,
                    cSimbolo = Mon.cSimbolo
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
            DocumentoVenta.cTipoDoc = Convert.ToString(cboTipoDocumento.Text);
            DocumentoVenta.cVehiculos = lstvehiculo[0].vPlaca;
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
                //fnMostrarMensaje(lblMsgDgOtrasVentas,false, "");

                
            }
            else
            {
                e.Handled = true;
                //fnMostrarMensaje(lblMsgDgOtrasVentas,true, "Porfavor Ingrese Solo Numeros");
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

                //fnMostrarPrecioUnitario(1);
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
                //if (lblMsgDgOtrasVentas.Visible != true  || estadoTabla==true)
                //{
                //    fnMostrarMensaje(lblMsgDgOtrasVentas,false, "");
                //}
                return;
            }
            else
            {
                dgOtrasVentas.CurrentRow.Cells[4].ReadOnly = true;
                dgOtrasVentas.CurrentRow.Cells[5].ReadOnly = true;
                if (estadoTabla != false)
                {
                }
                //if (lblMsgDgOtrasVentas.Visible != true)
                //{
                //    lblMsgForm.Visible = false;
                //    fnMostrarMensaje(lblMsgDgOtrasVentas,true, "Para Poder Editar Debe Seleccionar un Item de Venta ⚠️      ");
                //}
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
        public  void fnRecuperarEstadoGenVenta(Boolean estado)
        {
            EstadoGenVenta = estado;
        }
        private Boolean fnMostrarVPDocumentoventa()
        {
            fnHabilitarControles(false);
            Consultas.frmVPVenta abrirFrmVPOtrasVentas = new Consultas.frmVPVenta();
            abrirFrmVPOtrasVentas.Inicio(fnlstDocumentoVenta(),/*lstOtrasVentas*/ fnGenerarDetalleOtrasVentas(),-2);

            Consultas.frmVPActaCambioTitularidad frmCT = new Consultas.frmVPActaCambioTitularidad();
            List<Cliente> lstCDV=new List<Cliente>();
            List<Cliente> lstCAN = new List<Cliente>();
            lstCDV.Add(clsOtrasVentaGeneral.clsClienteDocumentoVenta);
            lstCAN.Add(clsOtrasVentaGeneral.clsClienteAntecesor);

            frmCT.Inicio(lstCDV, lstCAN, lstvehiculo, 0);
            

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

        private void gbDatosVenta_Click(object sender, EventArgs e)
        {

        }

        private void txtBusca_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (Char)Keys.Enter)
            {


                fnBuscarDatosCliente(lnTipoConCambio, clsClienteDocumentoV.idCliente);
            }
        }
        private Boolean fnBuscarDatosCliente(Int32 cond,Int32 idCliente)
        {
            BLTitularidad datCliente = new BLTitularidad();
            clsUtil objUtil = new clsUtil();
            DataTable datResultado = new DataTable();
            try
            {
                string BuscaDato = Convert.ToString(txtBusca.Text);
                datResultado = datCliente.BlBuscarTitularidad(cond, BuscaDato,  idCliente);

                dgConsulta.Visible = true;
                dgConsulta.Rows.Clear();

                foreach (DataRow drMenu in datResultado.Rows)
                {
                    dgConsulta.Rows.Add(
                        Convert.ToString(drMenu["idventageneral"]),
                       Convert.ToString(drMenu["cNombre"]),
                       Convert.ToString(drMenu["vPlaca"])
                       );


                }
                return true;

            }
            catch (Exception Error)

            {
                return false;
            }
            finally
            {

            }
        }

        private void dgConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //lnTipoConCambio = 1;

            fnListarDatosCliente(1, e);
        }
       
        private void fnListarDatosCliente(int condicion, DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            DataTable datosclienteT = new DataTable();
            BLTitularidad datTitularidad = new BLTitularidad();
            DataTable datResultado = new DataTable();
            try
            {


                datResultado = datTitularidad.BlBuscarTitularidad(condicion, Convert.ToString(dgConsulta.Rows[e.RowIndex].Cells[0].Value), clsClienteDocumentoV.idCliente);
                if (datResultado.Rows.Count > 0)
                {
                    lstvehiculo.Clear();
                    lstModelo.Clear();
                    lstMarca.Clear();
                    fnLimpiarDatosActecesor();
                    Titularidad clsTitu = new Titularidad();
                    clsTitu.idModelo = 0;

                    dgConsulta.Visible = false;
                    foreach (DataRow drMenu in datResultado.Rows)
                    {
                        txtCliente.Text = Convert.ToString(drMenu["cNombre"]);
                        clsClienteAntecesor.idVentaGen = Convert.ToInt32(drMenu["idventageneral"]);
                        clsClienteAntecesor.idCliente = Convert.ToInt32(drMenu["idCliente"]);
                        clsClienteAntecesor.cNombre = Convert.ToString(drMenu["cNombre"]);
                        clsClienteAntecesor.cApePat = Convert.ToString(drMenu["cApePat"]);
                        clsClienteAntecesor.cApeMat = Convert.ToString(drMenu["cApeMat"]);
                        clsClienteAntecesor.cDocumento = Convert.ToString(drMenu["cDocumento"]);
                        clsClienteAntecesor.cTipoDoc= Convert.ToString(drMenu["NomTdoc"]);
                        clsClienteAntecesor.cTelCelular= Convert.ToString(drMenu["cTelCelular"]);
                        clsClienteAntecesor.cDireccion= Convert.ToString(drMenu["cDireccion"]);
                        clsClienteAntecesor.ubigeo= Convert.ToString(drMenu["cDireccion"]+" "+drMenu["cNomDist"] +" "+ drMenu["cNomProv"] +" "+drMenu["cNomDep"]);

                        clsClienteAntecesor.cContactoNom1= Convert.ToInt32(drMenu["cTipPers"])==2?"Rason social":"Nombre";

                        txtCliente.Text = clsClienteAntecesor.cNombre + " " + clsClienteAntecesor.cApePat + " " + clsClienteAntecesor.cApeMat;
                        //txtdni.Text = Convert.ToString(drMenu["cDocumento"]);
                        //txtTelefono.Text = Convert.ToString(drMenu["cTelCelular"]);
                        //txtCorreo.Text = Convert.ToString(drMenu["cCorreo"]) != "" ? Convert.ToString(drMenu["cCorreo"]) : "SIN CORREO";


                        txtPlacaT.Text = Convert.ToString(drMenu["vPlaca"]);

                        txtSerie.Text = Convert.ToString(drMenu["vSerie"]);


                        lstvehiculo.Add(new Vehiculo
                        {
                            idVehiculo = Convert.ToInt32(drMenu["idVehiculo"]),
                            vPlaca = Convert.ToString(drMenu["vPlaca"]),
                            vSerie = Convert.ToString(drMenu["vSerie"]),

                        });




                        txtMarca.Text = Convert.ToString(drMenu["nombreMarcaV"]);
                        lstMarca.Add(new MarcaVehiculo
                        {
                            idMarca = Convert.ToInt32(drMenu["idMarcaV"]),
                            cNomMarca = Convert.ToString(drMenu["nombreMarcaV"]),

                        });
                        //txtMarca.Text = lstMarca[0].cNomMarca;

                        txtModelo.Text = Convert.ToString(drMenu["nombreModeloV"]);
                        lstModelo.Add(new ModeloVehiculo
                        {
                            idModelo = Convert.ToInt32(drMenu["idModeloV"]),
                            cNomModelo = Convert.ToString(drMenu["nombreModeloV"])
                        });
                        //txtModelo.Text = lstModelo[0].cNomModelo;
                    }

                }
            }
            catch (Exception exp)
            {

            }

        }

        private void fnLimpiarDatosActecesor()
        {
            txtCliente.Text="";
            txtPlacaT.Text="";
            txtSerie.Text="";
            txtMarca.Text="";
            txtModelo.Text="";
            clsClienteAntecesor = new Cliente();
            lstvehiculo.Clear();
            lstMarca.Clear();
            lstModelo.Clear();


        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //fnBuscarDatosCliente(0);
        }
        private Boolean fnValidaFecha(Label lbl, PictureBox pb)
        {
            String msg = "";
            Boolean bEstado = false;
            PictureBox pbx = null;
            Image img = null;
            DateTime dtFechaSistema = Variables.gdFechaSis.AddDays(-2);
            if (Convert.ToDateTime(dtFechaTitu.Value.ToString("dd/MM/yyyy")) >= Convert.ToDateTime(dtFechaSistema.ToString("dd/MM/yyyy")) && Convert.ToDateTime(dtFechaTitu.Value.ToString("dd/MM/yyyy")) <= Convert.ToDateTime(Variables.gdFechaSis.ToString("dd/MM/yyyy")))
            {
                bEstado = true;
                msg = "";
                img = Properties.Resources.ok;

            }
            else
            {
                if (Convert.ToDateTime(dtFechaTitu.Value.ToString("dd/MM/yyyy")) > Convert.ToDateTime(Variables.gdFechaSis.ToString("dd/MM/yyyy")))
                {
                    bEstado = false;
                    msg = "La fecha de pago no puede ser mayor a la fecha actual";
                    img = Properties.Resources.error;
                   
                }
                else if (Convert.ToDateTime(dtFechaTitu.Value.ToString("dd/MM/yyyy")) < Convert.ToDateTime(dtFechaSistema.ToString("dd/MM/yyyy")))
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void gbDatosCliente_Click(object sender, EventArgs e)
        {

        }

        private void txtPlacaT_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtPlacaT, lblPlacaT, pbplacaT, true, true, true, 3, 20, 20, 20, "Complete los campos");
            estPLACA = result.Item1;
            msgPLACA = result.Item2;
        }

        private void siticoneGroupBox2_Click(object sender, EventArgs e)
        {
            //    siticoneGroupBox2.Visible = false;
        }
        private void dtFechaTitu_ValueChanged(object sender, EventArgs e)
        {

            estadoFechaPago = fnValidaFecha(lblFechaT, pbFechaT);

            dtFechaTitularidad = Convert.ToDateTime(dtFechaTitu.Value);
        }

        //private void fnActivarBotonGuardar()
        //{
        //    if (estadoFechaPago == true && estImporte == true)
        //    {
        //        btnGuardar.Enabled = true;

        //    }
        //    else
        //    {
        //        btnGuardar.Enabled = false;
        //    }

        //}
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
            txtPlacaT_TextChanged(sender, e);
        }
        
        private void fnCargarClasePrincipal()
        {
            lstvehiculo[0].dFechaReg = dtFechaTitu.Value;
            lstvehiculo[0].Propietario = cboMotivo.SelectedValue.ToString();
            clsClienteDocumentoV.cContactoNom1 = Convert.ToInt32(cboTipoPersona.SelectedValue) == 2 ? "Rason social" : "Nombre";
            clsClienteDocumentoV.cTipoDoc = Convert.ToString(cboTipoDocumento.Text);
            clsOtrasVentaGeneral = new OtrasVentas
            {
                lstOtrasVenta = lstOtrasVentas,
                clsClienteDocumentoVenta = clsClienteDocumentoV,
                clsClienteAntecesor = clsClienteAntecesor,
                clsVehiculo = lstvehiculo[0],
                lstTrandiaria = lstPagosTrand,
                lstDetalleVenta = fnGenerarDetalleOtrasVentas(),
                dFechaOperacion = dtFechaTitu.Value,
                dFechaRegistro = Variables.gdFechaSis,
                CodDocumento = cboTipoDocEmitir.SelectedValue.ToString(),
                iddUsuario=Variables.gnCodUser,
                idMoneda=Mon.idMoneda

            } ;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Boolean blnResultado = false;
            BLOtrasVenta objOtrasVentas = new BLOtrasVenta();
            fnValidarCamposCliente(sender,e);
           

            List<OtrasVentas> lstDetalleVenta = fnRecorrerGrilla();
            if (estCliente == true && estTipDocumento==true && estTipPersona==true&& estPLACA==true )
            {
                if (estDocumentoEmitir == true)
                {
                    if (fnGenerarDetalleOtrasVentas().Count > 0)
                    {
                        if (fnValidarUnidadesDifCero())
                        {
                            if (estadoTabla == true)
                            {

                                fnCargarClasePrincipal();
                                if (fnMostrarVPDocumentoventa())
                                {
                                    List<xmlDocumentoVentaGeneral> xmlDocumentoVenta = new List<xmlDocumentoVentaGeneral>();
                                    xmlDocumentoVenta.Add(new xmlDocumentoVentaGeneral
                                    {
                                       xmlDocumentoVenta= fnlstDocumentoVenta(),
                                       xmlDetalleVentas= fnGenerarDetalleOtrasVentas()
                                    });
                                    fnCargarClasePrincipal();
                                    blnResultado = objOtrasVentas.blGuardarOtrasVentas(clsOtrasVentaGeneral, xmlDocumentoVenta, lnTipoCon);
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
                                    //fnMostrarMensaje(lblMsgForm, true, "Seguir Editando...");
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
