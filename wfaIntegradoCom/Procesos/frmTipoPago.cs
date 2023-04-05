﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;
using System.Globalization;
using CapaNegocio;
using CapaUtil;
using CapaEntidad;
using System.IO;
using Siticone.UI.WinForms.Suite;
using Siticone.UI.WinForms;
using TextBox = System.Windows.Forms.TextBox;
using CircularProgressBar;
using wfaIntegradoCom.Mantenedores;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmTipoPago : Form
    {
        public frmTipoPago()
        {
            InitializeComponent();
        }
        public static Boolean EstadoTipoPago=false;
        static Boolean bEstadoDocumento=false;
        Int32 lnTipoLLamada = 0;
        Decimal lnMontoPagar = 0;
        String SImboloMoneda = "";
        String codigoDocVenta = "";
        Boolean estTipoVenta, estEntidadVenta, estTotalAPagar, estPagaCon, estVuelto, estObservaciones,estNroOperacion;
        String lblTipoVentaa, lblEntidadVenta, lblTotalAPagar, lblPagaConn, lblVueltoo, lblObservacioneso, lblNroOperacion;
        static Pagos clsPagosGeneral = new Pagos();
        static List<Pagos> lstEntidades = new List<Pagos>();

        static List<DocumentoVenta> lsDocumentoVenta = new List<DocumentoVenta>();
        static List<DetalleVenta> lsDetalleVenta = new List<DetalleVenta>();
        static List<DetalleVenta> lsDetalleVentaAnticipo = new List<DetalleVenta>();

        public void Inicio(int pnTipo, Decimal pnMontoPagar,String sMoneda,String codigoDocV)
        {
            lnTipoLLamada = pnTipo;
            lnMontoPagar = pnMontoPagar;
            SImboloMoneda = sMoneda;
            clsPagosGeneral.cantAPagar = pnMontoPagar;
            clsPagosGeneral.SimboloMoneda = sMoneda;
            codigoDocVenta= codigoDocV;
            this.ShowDialog();
        }
        public void Inicio(int pnTipo, List<DocumentoVenta> lsDocVenta, List<DetalleVenta> lsDetVenta, String sMoneda)
        {
            //lsDocumentoVenta.Clear();
            //lsDetalleVenta.Clear();

            lnTipoLLamada = pnTipo;
            lsDocumentoVenta = lsDocVenta;
            lsDetalleVenta = lsDetVenta;
            lnMontoPagar = lsDetVenta.Sum(i => i.Importe);
            SImboloMoneda = sMoneda;
            clsPagosGeneral.cantAPagar = lsDetVenta.Sum(i => i.Importe) + lsDocVenta[0].MontoRedondeo;
            clsPagosGeneral.SimboloMoneda = sMoneda;
            codigoDocVenta= lsDocVenta[0].cCodDocumentoVenta;
            this.ShowDialog();
        }

       
        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            fnVolver();
        }

        private void txtObsevacion_TextChanged(object sender, EventArgs e)
        {
            var Resp = FunValidaciones.fnValidarTexboxs(txtObsevacion, lblObservaciones, pbOservacion,false, true, false, 0, 0, 5, 1000, "Ingrese descripcionCorrectamente");
            estObservaciones = Resp.Item1;
            lblObservacioneso = Resp.Item2;
        }

        private void lbEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Int32 index = lbEntidades.SelectedIndices[0];
        }

        private void dgvEntidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEntidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEntidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }
    

        private void dgvEntidades_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void elimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 index= dgvEntidades.CurrentRow.Index;
            Pagos clsTemporal = new Pagos();
            for (int i = 0; i < lstEntidades.Count; i++)
            {
                if (i == index)
                {
                    clsTemporal = lstEntidades[i];
                    break;
                }
            }
            lstEntidades.Remove(clsTemporal);
            fnLlenarListBox();
        }
        int currentFrame = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
           


        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void fnCambiarEstadoPago(Boolean est)
        {
            bEstadoDocumento = est;
        }
        public void fnRecibirEntidades(Pagos cls ,Int32 tipoCon)
        {

            // Boolean St =this.rdbSi.Checked;

            String EstadoText;
            if (EstadoTipoPago==true)
            {
                EstadoText = "Uno";
            }
            else
            
            {
                EstadoText = "Dos";
            }
            lstEntidades.Add(new Pagos
            {
                codTipoPago = cls.codTipoPago,
                cDescripTipoPago = cls.cDescripTipoPago,
                idEntidadPago = cls.idEntidadPago,
                cNumeroOperacion = cls.cNumeroOperacion,
                cDescripcionEstadoPP=cls.cDescripcionEstadoPP,
                cantAPagar = clsPagosGeneral.cantAPagar,
                PagaCon = cls.PagaCon,
                vuelto = cls.vuelto,
                cTipoVenta = Convert.ToString(cboTipoVenta.SelectedValue),
                Observaciones = Convert.ToString(txtObsevacion.Text),
                dFechaRegistro = Variables.gdFechaSis,
                dFechaPago = Variables.gdFechaSis,
                idUsario = Variables.gnCodUser,
                
                cEstadoPP = EstadoTipoPago? "ESPP0001" : "ESPP0002",
                idMoneda = clsPagosGeneral.idMoneda
            });

            fnLlenarListBox();
        }

        private void rdbSi_CheckedChanged(object sender, EventArgs e)
        {
            lsDocumentoVenta[0].FormaPagoFactura = "CONT";
        }

        private void fnLlenarListBox()
        {
            dgvEntidades.Rows.Clear();
            txtImporteRestante.Text= FunGeneral.fnFormatearPrecioDC(clsPagosGeneral.SimboloMoneda, (clsPagosGeneral.cantAPagar- lstEntidades.Sum(i=>i.PagaCon)), 1);
            Int32 y = 0;
            String entidadpagos = "";
            foreach (Pagos pg in lstEntidades)
            {
                entidadpagos = pg.cDescripcionEstadoPP == pg.cDescripTipoPago ? "":" - "+ pg.cDescripcionEstadoPP;
                dgvEntidades.Rows.Add(pg.cDescripTipoPago + entidadpagos+ " - " + FunGeneral.fnFormatearPrecioDC(clsPagosGeneral.SimboloMoneda,pg.PagaCon,0));
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            String Estado;

            EstadoTipoPago = rdbSi.Checked;
            
            if (clsPagosGeneral.cantAPagar > lstEntidades.Sum(i => i.PagaCon) || txtTotalAPagar.Text.ToString()==txtImporteRestante.Text.ToString())
            {
                frmEntidadPagos frm = new frmEntidadPagos();
                clsPagosGeneral.PagaCon = (clsPagosGeneral.cantAPagar - lstEntidades.Sum(i => i.PagaCon));
                frm.Inicio(clsPagosGeneral, 0);
                fnLlenarListBox();
            }
            else
            {
                MessageBox.Show("inporte insuficiente para agregar entidades de págo","Aviso!!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void rdbNo_CheckedChanged(object sender, EventArgs e)
        {
            lsDocumentoVenta[0].FormaPagoFactura = "CRED";
        }
        public static Boolean fnLlenarCombobox(SiticoneComboBox cboCombo, String cCodTab, Int32 lnTipoCon, Boolean estBusq)
        {
            BLTipoPagos objTablaCod = new BLTipoPagos();
            clsUtil objUtil = new clsUtil();
            List<EntidadesPago> lstTablaCod = new List<EntidadesPago>();

            try
            {
                lstTablaCod = objTablaCod.blDevolverEntidadPago(cCodTab, lnTipoCon, estBusq);
                cboCombo.DataSource = null;
                cboCombo.ValueMember = "cCodEntidad";
                cboCombo.DisplayMember = "nomEntidadPago";
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
      
        private void cboTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pbTipoVenta.Image = Properties.Resources.ok;
            estTipoVenta = true;
            lblTipoVentaa = "";
        }

        private void frmTipoPago_Load(object sender, EventArgs e)
        {
            try
            {
                bEstadoDocumento = false;
                lstEntidades.Clear();
                FunValidaciones.fnColorAceptarCancelar(btnAceptar, btnCancelar);
                txtTotalAPagar.Text = FunGeneral.fnFormatearPrecioDC(clsPagosGeneral.SimboloMoneda,clsPagosGeneral.cantAPagar,1);
                txtImporteRestante.Text = FunGeneral.fnFormatearPrecioDC(clsPagosGeneral.SimboloMoneda,clsPagosGeneral.cantAPagar,1);

                fnLlenarCombobox(cboTipoVenta, "TIVTR00" + lnTipoLLamada, 2, false);
                btnAdd.Focus();
                if (lnTipoLLamada == -3 || lnTipoLLamada == 3)
                {
                    btnAceptar.Text = "Guardar Movimiento";
                    btnAceptar.Width = btnAceptar.Width + 15;
                }
                if (lnTipoLLamada == -3)
                {
                    rdbNo.Enabled = false;
                    rdbNo.Visible=false;
                }

                
                // Agrega cada cuadro a la lista
               

                timer1.Start();
            }
            catch (Exception ex)
            {

                throw;
            }
            
           
        }

        public void fnMostrarCargando(Boolean estado)
        {
            switch (codigoDocVenta)
            {
                case "DOVE0002":
                case "DOVE0001":
                    siticoneLabel1.Text = "Emitiendo documento a SUNAT";
                    break;
                case "DOVE0003":
                case "DOVE0004":
                    siticoneLabel1.Text = "Guardando datos";
                    break;
                default:
                    break;
            }
            if (estado)
            {
                siticoneProgressIndicator1.Start();
                
            }
            else
            {
                siticoneProgressIndicator1.Stop();

            }
            pncargando.Visible = estado;
        }

        private void fnCrearItemAnticipos()
        {
            if (lsDocumentoVenta[0].FormaPagoFactura == "CRED")
            {
                lsDetalleVentaAnticipo.Clear();
                lsDetalleVentaAnticipo.Add(new DetalleVenta
                {
                    Numeracion = 1,
                    Descripcion = "PAGO GPS " + lsDocumentoVenta[0].cTipoVenta + " ****Pago Anticipado***",
                    idTipoTarifa = lsDetalleVenta[0].idTipoTarifa,
                    PrecioUni = lstEntidades.Sum(i => i.PagaCon),
                    Descuento = 0,
                    gananciaRedondeo = 0,
                    TotalTipoDescuento = 0,
                    IdTipoDescuento = 0,
                    Cantidad = 1,
                    Couta = 1,
                    Importe = lstEntidades.Sum(i => i.PagaCon),
                    cSimbolo = lsDetalleVenta[0].cSimbolo,

                    preciounitario = Convert.ToDecimal(lstEntidades.Sum(i => i.PagaCon)),
                    ImporteRow = (Convert.ToDecimal(lstEntidades.Sum(i => i.PagaCon)) * 1),
                    mtoValorVentaItem = (Convert.ToDecimal(lstEntidades.Sum(i => i.PagaCon)) * 1),
                    Unidad_de_medida = "ZZ"

                });
                PrecioALetras pal = new PrecioALetras();
                string RecioALetras2 = pal.Convertir((lsDetalleVentaAnticipo.Sum(i => i.ImporteRow) - Convert.ToDecimal(lsDetalleVentaAnticipo.Sum(i => i.TotalTipoDescuento))).ToString(), true, " SOLES");
                lsDocumentoVenta[0].PrecioEnLetras = RecioALetras2;

                lsDocumentoVenta[0].nMontoTotal = lstEntidades.Sum(i => i.PagaCon);
                lsDocumentoVenta[0].nSubtotal = (lstEntidades.Sum(i => i.PagaCon) / 1.18m);
                lsDocumentoVenta[0].nIGV = (lsDocumentoVenta[0].nMontoTotal - lsDocumentoVenta[0].nSubtotal);
            }
        }
        private void fnEnviarDatosLuegoDeAceptar()
        {
            lsDocumentoVenta[0].cDescripcionTipoPago = "";
            lsDocumentoVenta[0].cDescripEstadoPP= "CONTADO";
            foreach (Pagos ep in lstEntidades )
            {
                lsDocumentoVenta[0].cDescripcionTipoPago +=" "+ ep.cDescripTipoPago+"="+ lsDetalleVenta[0].cSimbolo +"."+ep.PagaCon+ "\n";
            }

            fnCrearItemAnticipos();
            Consultas.frmVPVenta frm = new Consultas.frmVPVenta();
            frm.Inicio(lsDocumentoVenta, lsDetalleVentaAnticipo.Count > 0 ? lsDetalleVentaAnticipo : lsDetalleVenta, lnTipoLLamada);

            //opcion para venta general
            if (lnTipoLLamada == 0)
            {
                //fnCrearItemAnticipos();
                //Consultas.frmVPVenta frm = new Consultas.frmVPVenta();
                //frm.Inicio(lsDocumentoVenta, lsDetalleVentaAnticipo.Count>0? lsDetalleVentaAnticipo : lsDetalleVenta, 0);
                frmRegistrarVenta fr = new frmRegistrarVenta();
                if (bEstadoDocumento)
                {
                    frmRegistrarVenta.fnRecuperarTipoPago(lstEntidades);
                    fr.fnCambiarEstadoVenta(true);
                }
                else
                {
                    fr.fnCambiarEstadoVenta(false);
                }

            }
            // opcion para pagos mensuales
            else if (lnTipoLLamada == -1)
            {
                
                frmControlPagoVenta fr = new frmControlPagoVenta();
                if (bEstadoDocumento)
                {
                    Procesos.frmControlPagoVenta.fnRecuperarTipoPago(lstEntidades);                    
                    fr.fnCambiarEstadoVenta(true);
                }
                else
                {
                    fr.fnCambiarEstadoVenta(false);
                }
                
                this.Close();
            }
            // opcion para otrasVentas
            else if (lnTipoLLamada == -2)
            {
                frmOtrasVentas frm2 = new frmOtrasVentas();
                if (bEstadoDocumento)
                {
                    frmOtrasVentas.fnRecuperarTipoPago(lstEntidades);
                    frm2.fnRecuperarEstadoGenVenta(true);
                }
                else
                {
                    frm2.fnRecuperarEstadoGenVenta(false);
                }
                
                
                
                this.Close();

            }
            else if (lnTipoLLamada == -3 || lnTipoLLamada == 3)
            {
                frmRegistrarEgresos fr = new frmRegistrarEgresos();
                if (bEstadoDocumento)
                {
                    fr.fnRecuperarEstadoGenVenta(true);
                    fr.fnRecuperarTipoPago(lstEntidades);
                }
                else
                {
                    fr.fnRecuperarEstadoGenVenta(false);

                }
                
                
                this.Close();
            }
            else if (lnTipoLLamada == -4)
            {
                frmPagosPendientes fr = new frmPagosPendientes();
                if (bEstadoDocumento)
                {
                    fr.fnRecuperarEstadoGenVenta(true);
                    fr.fnRecuperarTipoPago(lstEntidades);
                }
                else
                {
                    fr.fnRecuperarEstadoGenVenta(false);

                }
                
                this.Close();
            }
            else
            {
                //frmDocumentoVenta.fnRecuperarTipoPago(cboTipoPago.SelectedValue.ToString(), Convert.ToDecimal(txtCanPagar.Text), cboTipoPago.Text);
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            fnMostrarCargando(true);
            if (rdbSi.Checked == true)
            {
                Decimal cantPagar = Convert.ToDecimal(string.Format("{0:0.00}", clsPagosGeneral.cantAPagar));
                Decimal PagaCOnEntidades = Convert.ToDecimal(string.Format("{0:0.00}", lstEntidades.Sum(i => i.PagaCon)));
                if (lstEntidades.Count>0 && cantPagar == PagaCOnEntidades)
                {
                    fnEnviarDatosLuegoDeAceptar();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Por favor Ingrese el monto correcto. Agregue entidades de págo ", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (rdbNo.Checked == true)
            {
                DialogResult resp = new DialogResult();
                resp = MessageBox.Show("En realidad deseá guardar el págo como págo pendiente?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (resp == DialogResult.Yes)
                {
                    fnEnviarDatosLuegoDeAceptar();
                    this.Dispose();
                    ////opcion para venta general
                    //if (lnTipoLLamada == 0)
                    //{
                    //    Consultas.frmVPVenta frm = new Consultas.frmVPVenta();
                    //    //MessageBox.Show("Todo Correcto");
                    //    Mantenedores.frmRegistrarVenta.fnRecuperarTipoPago(lstEntidades);
                    //    frm.fnCambiarEstado(true);
                    //    this.Close();
                    //}
                    //// opcion para pagos mensuales
                    //else if (lnTipoLLamada == -1)
                    //{
                    //    Procesos.frmControlPagoVenta.fnRecuperarTipoPago(lstEntidades);
                    //    frmControlPagoVenta frm = new frmControlPagoVenta();
                    //    frm.fnCambiarEstadoVenta(true);
                    //    this.Close();
                    //}
                    //// opcion para otrasVentas
                    //else if (lnTipoLLamada == -2)
                    //{
                    //    frmOtrasVentas.fnRecuperarTipoPago(lstEntidades);
                    //    frmOtrasVentas frm2 = new frmOtrasVentas();
                    //    frm2.fnRecuperarEstadoGenVenta(true);
                    //    this.Close();

                    //}
                    //else if (lnTipoLLamada == -3 || lnTipoLLamada == 3)
                    //{
                    //    frmRegistrarEgresos frm = new frmRegistrarEgresos();
                    //    frm.fnRecuperarEstadoGenVenta(true);
                    //    frm.fnRecuperarTipoPago(lstEntidades);
                    //    this.Close();
                    //}
                    //else if (lnTipoLLamada == -4)
                    //{
                    //    frmPagosPendientes frm = new frmPagosPendientes();
                    //    frm.fnRecuperarEstadoGenVenta(true);
                    //    frm.fnRecuperarTipoPago(lstEntidades);
                    //    this.Close();
                    //}
                    //else
                    //{
                    //    //frmDocumentoVenta.fnRecuperarTipoPago(cboTipoPago.SelectedValue.ToString(), Convert.ToDecimal(txtCanPagar.Text), cboTipoPago.Text);
                    //    this.Close();
                    //}
                }
            }

            

            fnMostrarCargando(false);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {                  

            NumberFormatInfo nfi = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;

            char decSeperator;

            decSeperator = nfi.CurrencyDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar)
            | e.KeyChar == decSeperator))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == decSeperator
                && (sender as TextBox).Text.IndexOf(decSeperator) > -1)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (Char)Keys.Enter)
            {
                txtTotalAPagar.Focus();
            }
        }

        
        private void fnVolver()
        {
            if (lnTipoLLamada == 0)
            {
                Mantenedores.frmRegistrarVenta fmr = new Mantenedores.frmRegistrarVenta();
                fmr.fnCambiarEstadoVenta(false);
            }

            if (lnTipoLLamada == -1)
            {
                frmControlPagoVenta frm1 = new frmControlPagoVenta();
                frm1.fnCambiarEstadoVenta(false);
            }
            else if (lnTipoLLamada == -2)
            {
                frmOtrasVentas fr = new frmOtrasVentas();
                fr.fnRecuperarEstadoGenVenta(false);
                fr.fnCondicionProcesos(0);

            }
            else if (lnTipoLLamada == -3 || lnTipoLLamada == 3)
            {
                frmRegistrarEgresos frm = new frmRegistrarEgresos();
                frm.fnRecuperarEstadoGenVenta(false);

            }
            else if (lnTipoLLamada == -4)
            {
                frmPagosPendientes frm = new frmPagosPendientes();
                frm.fnRecuperarEstadoGenVenta(false);

            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            fnVolver();

            this.Dispose();
        }


       
    }
}
