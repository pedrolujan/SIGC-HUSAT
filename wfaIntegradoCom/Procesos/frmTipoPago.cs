using System;
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
using Siticone.Desktop.UI.WinForms.Suite;
using Siticone.Desktop.UI.WinForms;
using TextBox = System.Windows.Forms.TextBox;
using CircularProgressBar;
using wfaIntegradoCom.Mantenedores;
using CapaDato;
using System.Web.Services.Description;

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
        static Int32 idTrandiaria = 0;
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
        static List<DetalleVenta> lsDetalleVentaAnticiposRecibidos = new List<DetalleVenta>();
        static Decimal restaPrecio = 0;
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
            clsPagosGeneral.importeRestante = lsDetVenta.Sum(i => i.importeRestante) + lsDocVenta[0].MontoRedondeo;
            clsPagosGeneral.importeAbonado = (clsPagosGeneral.cantAPagar-lsDetVenta.Sum(i => i.importeRestante))- lsDocVenta[0].MontoRedondeo;

            clsPagosGeneral.SimboloMoneda = sMoneda;
            codigoDocVenta= lsDocVenta[0].cCodDocumentoVenta;
            idTrandiaria = lsDocVenta[0].idVenta;
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
            if (clsPagosGeneral.importeRestante==0)
            {
                EstadoText = "ESPP0001";
            }
            else
            
            {
                EstadoText = "ESPP0002";
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
                
                cEstadoPP = EstadoText,
                idMoneda = clsPagosGeneral.idMoneda
            });

            //fnLlenarListBox();
        }

        private void rdbSi_CheckedChanged(object sender, EventArgs e)
        {
            lsDocumentoVenta[0].FormaPagoFactura = "CONT";
        }

        private void fnLlenarListBox()
        {
            dgvEntidades.Rows.Clear();
            //restaPrecio = lsDetalleVentaAnticiposRecibidos.Count>0? (clsPagosGeneral.cantAPagar - lstEntidades.Sum(i => i.PagaCon)+ lsDetalleVentaAnticiposRecibidos.Sum(i=>i.Importe) ): (clsPagosGeneral.cantAPagar - lstEntidades.Sum(i => i.PagaCon)-(clsPagosGeneral.cantAPagar - clsPagosGeneral.importeRestante));
            clsPagosGeneral.importeRestante = ((clsPagosGeneral.cantAPagar - lstEntidades.Sum(i => i.PagaCon)-clsPagosGeneral.importeAbonado) + lsDetalleVentaAnticiposRecibidos.Sum(i => i.Importe));
            restaPrecio = ((clsPagosGeneral.cantAPagar - lstEntidades.Sum(i => i.PagaCon) - clsPagosGeneral.importeAbonado) + lsDetalleVentaAnticiposRecibidos.Sum(i => i.Importe));
            txtImporteRestante.Text= FunGeneral.fnFormatearPrecioDC(clsPagosGeneral.SimboloMoneda, clsPagosGeneral.importeRestante, 1);

            String EstadoText;
            if (clsPagosGeneral.importeRestante == 0)
            {
                EstadoText = "ESPP0001";
            }
            else

            {
                EstadoText = "ESPP0002";
            }
            if (lstEntidades.Count>0)
            {
                lstEntidades[0].cEstadoPP = EstadoText;

            }
            Int32 y = 0;
            String entidadpagos = "";
            if (restaPrecio==0)
            {
                if (lnTipoLLamada == -4)
                {
                    BLDocumentoVenta bLDocumentoVenta = new BLDocumentoVenta();
                    lsDetalleVentaAnticiposRecibidos = bLDocumentoVenta.blBuscarDocVenta("", idTrandiaria);
                   
                }
            }
            foreach (DetalleVenta dv in lsDetalleVentaAnticiposRecibidos)
            {
                dgvEntidades.Rows.Add(dv.Descripcion + entidadpagos + " - " + FunGeneral.fnFormatearPrecioDC(clsPagosGeneral.SimboloMoneda, dv.Importe*1, 0));
            }
            foreach (Pagos pg in lstEntidades)
            {
                entidadpagos = pg.cDescripcionEstadoPP == pg.cDescripTipoPago ? "":" - "+ pg.cDescripcionEstadoPP;
                dgvEntidades.Rows.Add(pg.cDescripTipoPago + entidadpagos+ " - " + FunGeneral.fnFormatearPrecioDC(clsPagosGeneral.SimboloMoneda,pg.PagaCon,0));
            }
        }

        private void btnAnticipos_Click(object sender, EventArgs e)
        {
            frmBuscarAnticipos f  = new frmBuscarAnticipos();
            f.Inicio(idTrandiaria);
            fnLlenarListBox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String Estado;

            EstadoTipoPago = rdbSi.Checked;
            if(clsPagosGeneral.importeRestante ==0)
            {
                if (clsPagosGeneral.cantAPagar == clsPagosGeneral.importeRestante)
                {
                    fnAgregarEntidades();
                }
                else
                {
                    MessageBox.Show("inporte insuficiente para agregar entidades de págo", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else if(clsPagosGeneral.importeRestante>0)
            {
                    fnAgregarEntidades();
            }
            else
            {
                MessageBox.Show("inporte insuficiente para agregar entidades de págo","Aviso!!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void fnAgregarEntidades()
        {
            frmEntidadPagos frm = new frmEntidadPagos();
            clsPagosGeneral.PagaCon = (clsPagosGeneral.cantAPagar - lstEntidades.Sum(i => i.PagaCon) - clsPagosGeneral.importeAbonado);
            frm.Inicio(clsPagosGeneral, 0);
            fnLlenarListBox();

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
                lsDetalleVentaAnticiposRecibidos.Clear();
                FunValidaciones.fnColorAceptarCancelar(btnAceptar, btnCancelar);
                txtTotalAPagar.Text = FunGeneral.fnFormatearPrecioDC(clsPagosGeneral.SimboloMoneda,clsPagosGeneral.cantAPagar,1);
                txtImporteRestante.Text = FunGeneral.fnFormatearPrecioDC(clsPagosGeneral.SimboloMoneda,clsPagosGeneral.importeRestante, 1);
                txtImporteAbonado.Text= FunGeneral.fnFormatearPrecioDC(clsPagosGeneral.SimboloMoneda, clsPagosGeneral.importeAbonado, 1);
                //fnActivarAddAnticipos();
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

                if (lnTipoLLamada==-4)
                {
                    label6.Visible=true;
                    txtImporteAbonado.Visible=true;
                }
                else
                {
                    label6.Visible = false;
                    txtImporteAbonado.Visible = false;
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
                    SiticoneHtmlLabel1.Text = "Emitiendo documento a SUNAT";
                    break;
                case "DOVE0003":
                case "DOVE0004":
                    SiticoneHtmlLabel1.Text = "Guardando datos";
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
            lsDetalleVentaAnticipo.Clear();
            //lsDetalleVentaAnticipo = lsDetalleVenta;
            if (lsDocumentoVenta[0].cDescripEstadoPP == "CREDITO" || restaPrecio!=0)
            {
                //lsDetalleVentaAnticipo = lsDetalleVenta;
                Decimal importePagado = ((clsPagosGeneral.cantAPagar - restaPrecio)-clsPagosGeneral.importeAbonado)+ lsDetalleVentaAnticiposRecibidos.Sum(i=>i.Importe);
                Decimal importeRestantePorVehiculo = 0;
                Decimal importeAPagarPorVehiculo = 0;
                String cDescripcion = "";
                Int32 idOperacionItem = 0;
                int y = 0;
                if (lsDocumentoVenta[0].idTipoTarifa==1)
                {
                   
                        cDescripcion = "Servicio de monitoreo GPS"+ " *Anticipo*";
                        lsDetalleVentaAnticipo.Add(new DetalleVenta
                        {
                            Numeracion = y + 1,
                            Descripcion = cDescripcion,
                            idTipoTarifa = lsDetalleVenta[0].idTipoTarifa,
                            PrecioUni = importePagado,
                            Descuento = 0,
                            gananciaRedondeo = 0,
                            TotalTipoDescuento = 0,
                            IdTipoDescuento = 0,
                            Cantidad = 1,
                            Couta = 1,
                            Importe = importePagado,
                            cSimbolo = lsDetalleVenta[0].cSimbolo,

                            preciounitario = Convert.ToDecimal(clsPagosGeneral.cantAPagar- clsPagosGeneral.importeAbonado),
                            ImporteRow = (Convert.ToDecimal(importePagado) * 1),
                            mtoValorVentaItem = (Convert.ToDecimal(importePagado) * 1),
                            Unidad_de_medida = "ZZ",
                            idOperacionItem =  2 

                        });
                        y++;
                }
                else
                {
                    lsDetalleVentaAnticipo = lsDetalleVenta;
                    foreach (DetalleVenta dv in lsDetalleVenta)
                    {
                        Decimal valorImporte = (lsDetalleVenta[y].Importe + lsDetalleVenta[y].valorRedondeo);
                        if (valorImporte <= importePagado)
                        {
                            importeRestantePorVehiculo = lsDetalleVenta[y].Importe;
                            importeAPagarPorVehiculo= lsDetalleVenta[y].preciounitario;
                            importePagado = importePagado - (lsDetalleVenta[y].Importe + lsDetalleVenta[y].valorRedondeo);
                            cDescripcion = lsDetalleVenta[y].Descripcion;
                            idOperacionItem = 0;

                        }
                        else if (lsDetalleVenta[y].Importe > importePagado)
                        {
                            importeRestantePorVehiculo = importePagado;
                            importeAPagarPorVehiculo = importePagado;
                            importePagado = importePagado > 0 ? importePagado - importePagado : 0;
                            cDescripcion = lsDetalleVenta[y].Descripcion + " *Anticipo*";
                            idOperacionItem = 2;
                        }

                        lsDetalleVentaAnticipo[y].Numeracion = 1;
                        lsDetalleVentaAnticipo[y].IdDetalleVenta = lsDetalleVenta[y].IdDetalleVenta;
                        lsDetalleVentaAnticipo[y].Descripcion = cDescripcion;
                        lsDetalleVentaAnticipo[y].idTipoTarifa = lsDetalleVenta[y].idTipoTarifa;
                        lsDetalleVentaAnticipo[y].PrecioUni = lsDetalleVenta[y].preciounitario;
                        lsDetalleVentaAnticipo[y].Descuento = lsDetalleVenta[y].Descuento;
                        lsDetalleVentaAnticipo[y].gananciaRedondeo = lsDetalleVenta[y].gananciaRedondeo;
                        lsDetalleVentaAnticipo[y].TotalTipoDescuento = lsDetalleVenta[y].TotalTipoDescuento;
                        lsDetalleVentaAnticipo[y].IdTipoDescuento = lsDetalleVenta[y].IdTipoDescuento;
                        lsDetalleVentaAnticipo[y].Cantidad = lsDetalleVenta[y].Cantidad;
                        lsDetalleVentaAnticipo[y].Couta = lsDetalleVenta[y].Couta;

                        lsDetalleVentaAnticipo[y].Importe = importeRestantePorVehiculo;//lsDetalleVenta[y].Importe;
                        lsDetalleVentaAnticipo[y].importeRestante = (lsDetalleVenta[y].preciounitario - importeRestantePorVehiculo) - clsPagosGeneral.importeAbonado;//lsDetalleVenta[y].Importe;
                        lsDetalleVentaAnticipo[y].ImporteActicipo = importeRestantePorVehiculo;//lsDetalleVenta[y].Importe;
                        lsDetalleVentaAnticipo[y].cSimbolo = lsDetalleVenta[y].cSimbolo;

                        lsDetalleVentaAnticipo[y].preciounitario = lsDetalleVenta[y].preciounitario;//importeRestantePorVehiculo;
                        lsDetalleVentaAnticipo[y].ImporteRow = importeAPagarPorVehiculo; //importeRestantePorVehiculo;
                        lsDetalleVentaAnticipo[y].mtoValorVentaItem = importeRestantePorVehiculo;
                        lsDetalleVentaAnticipo[y].Unidad_de_medida = "ZZ";
                        lsDetalleVentaAnticipo[y].idOperacionItem = idOperacionItem;

                        y++;
                    }
                }
                

                PrecioALetras pal = new PrecioALetras();
                string RecioALetras2 = pal.Convertir((lsDetalleVentaAnticipo.Sum(i => i.ImporteRow) - Convert.ToDecimal(lsDetalleVentaAnticipo.Sum(i => i.TotalTipoDescuento))).ToString(), true, " SOLES");
                lsDocumentoVenta[0].PrecioEnLetras = RecioALetras2;

                lsDocumentoVenta[0].nMontoTotal = lstEntidades.Sum(i => i.PagaCon);
                lsDocumentoVenta[0].nSubtotal = (lstEntidades.Sum(i => i.PagaCon) / 1.18m);
                lsDocumentoVenta[0].MontoTotalAnticipos = lsDetalleVentaAnticiposRecibidos.Sum(i => i.Importe);
                lsDocumentoVenta[0].nIGV = (lsDocumentoVenta[0].nMontoTotal - lsDocumentoVenta[0].nSubtotal);
            }
            else
            {
                lsDetalleVentaAnticipo.Clear();
                if (lsDetalleVentaAnticiposRecibidos.Count > 0)
                {
                    Int32 y = 0;
                    foreach (DetalleVenta dv in lsDetalleVentaAnticiposRecibidos)
                    {

                        lsDetalleVentaAnticipo.Add(new DetalleVenta
                        {
                            Numeracion = y + 1,
                            Descripcion = dv.Descripcion,
                            idTipoTarifa = lsDetalleVenta[0].idTipoTarifa,
                            PrecioUni = dv.Importe,
                            Descuento = 0,
                            gananciaRedondeo = 0,
                            TotalTipoDescuento = 0,
                            IdTipoDescuento = 0,
                            Cantidad = 1,
                            Couta = 1,
                            Importe = dv.Importe,
                            cSimbolo = lsDetalleVenta[0].cSimbolo,

                            preciounitario = Convert.ToDecimal(dv.Importe),
                            ImporteRow = (Convert.ToDecimal(dv.Importe) * 1),
                            mtoValorVentaItem = (Convert.ToDecimal(dv.Importe) * 1),
                            Unidad_de_medida = "ZZ"

                        });
                        y++;
                    }
                    lsDocumentoVenta[0].idTipoTarifa = lsDetalleVentaAnticiposRecibidos.Count > 0 ? lsDetalleVentaAnticiposRecibidos[0].CodigoProducto== "ESDOV005"?0: lsDocumentoVenta[0].idTipoTarifa : 1;
                    if (lsDocumentoVenta[0].idTipoTarifa == 1 )
                    {
                        List<DetalleVenta> detVentas = new List<DetalleVenta>();
                        detVentas = FunGeneral.fnObtenerDetalleVenta(lsDocumentoVenta[0].idTrandiaria, lsDocumentoVenta[0].idTipoTarifa);
                        foreach (DetalleVenta dv in detVentas)
                        {
                            lsDetalleVentaAnticipo.Add(new DetalleVenta
                            {
                                Numeracion = y + 1,
                                Descripcion = dv.Descripcion,
                                idTipoTarifa = lsDetalleVenta[0].idTipoTarifa,
                                PrecioUni = dv.PrecioUni,
                                Descuento = 0,
                                gananciaRedondeo = 0,
                                TotalTipoDescuento = dv.TotalTipoDescuento,
                                IdTipoDescuento = 0,
                                Cantidad = 1,
                                Couta = 1,
                                Importe = dv.Importe,
                                cSimbolo = lsDetalleVenta[0].cSimbolo,

                                preciounitario = Convert.ToDecimal(dv.Importe),
                                ImporteRow = (Convert.ToDecimal(dv.Importe) * 1),
                                mtoValorVentaItem = (Convert.ToDecimal(dv.Importe) * 1),
                                Unidad_de_medida = "ZZ"

                            });
                            y++;
                        }
                    }
                    else
                    {
                        foreach (DetalleVenta dv in lsDetalleVenta)
                        {
                            lsDetalleVentaAnticipo.Add(new DetalleVenta
                            {
                                Numeracion = y + 1,
                                Descripcion = dv.Descripcion,
                                idTipoTarifa = lsDetalleVenta[0].idTipoTarifa,
                                PrecioUni = dv.Importe,
                                Descuento = 0,
                                gananciaRedondeo = 0,
                                TotalTipoDescuento = 0,
                                IdTipoDescuento = 0,
                                Cantidad = 1,
                                Couta = 1,
                                Importe = dv.Importe,
                                cSimbolo = lsDetalleVenta[0].cSimbolo,

                                preciounitario = Convert.ToDecimal(dv.Importe),
                                ImporteRow = (Convert.ToDecimal(dv.Importe) * 1),
                                mtoValorVentaItem = (Convert.ToDecimal(dv.Importe) * 1),
                                Unidad_de_medida = "ZZ"

                            });
                            y++;
                        }

                    }

                    

                    PrecioALetras pal = new PrecioALetras();
                    string RecioALetras2 = pal.Convertir((lsDetalleVentaAnticipo.Sum(i => i.ImporteRow) - Convert.ToDecimal(lsDetalleVentaAnticipo.Sum(i => i.TotalTipoDescuento))).ToString(), true, " SOLES");
                    RecioALetras2 = pal.Convertir(lstEntidades.Sum(i=>i.PagaCon).ToString(), true, " SOLES");
                    lsDocumentoVenta[0].PrecioEnLetras = RecioALetras2;
                    lsDocumentoVenta[0].nMontoTotal = lstEntidades.Sum(i => i.PagaCon);
                    lsDocumentoVenta[0].nSubtotal = (lstEntidades.Sum(i => i.PagaCon) / 1.18m);
                    lsDocumentoVenta[0].MontoTotalAnticipos = lsDetalleVentaAnticiposRecibidos.Sum(i => i.Importe);
                    lsDocumentoVenta[0].nIGV = (lsDocumentoVenta[0].nMontoTotal - lsDocumentoVenta[0].nSubtotal);
                }
                else
                {
                    lsDetalleVentaAnticipo = lsDetalleVenta;
                }

            }
        }

        public void fnRecibirAnticipos(DetalleVenta dv)
        {
            lsDetalleVentaAnticiposRecibidos.Add(dv);
            //fnLlenarListBox();
        }
        private void fnEnviarDatosLuegoDeAceptar()
        {
            lsDocumentoVenta[0].cDescripcionTipoPago = "";
            lsDocumentoVenta[0].cDescripEstadoPP= restaPrecio==0?"CONTADO":"CREDITO";
            foreach (Pagos ep in lstEntidades )
            {
                lsDocumentoVenta[0].cDescripcionTipoPago +=" "+ ep.cDescripTipoPago+"="+ lsDetalleVenta[0].cSimbolo +"."+ep.PagaCon+ "\n";
            }

            fnCrearItemAnticipos();
            Consultas.frmVPVenta frm = new Consultas.frmVPVenta();
            //lsDocumentoVenta[0].nMontoTotal = lsDetalleVentaAnticipo.Sum(x => x.Importe)+ lsDetalleVentaAnticipo.Sum(i=>i.valorRedondeo);
            //lsDocumentoVenta[0].MontoTotalAnticipos = lsDetalleVentaAnticiposRecibidos.Sum(x => x.Importe) * 1;
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
                    fr.fnCambiarEstadoVenta(true, lsDetalleVentaAnticipo);
                }
                else
                {
                    fr.fnCambiarEstadoVenta(false,new List<DetalleVenta>());
                }

            }
            // opcion para pagos mensuales
            else if (lnTipoLLamada == -1)
            {
                
                frmControlPagoVenta fr = new frmControlPagoVenta();
                if (bEstadoDocumento)
                {
                    
                    Procesos.frmControlPagoVenta.fnRecuperarTipoPago(lstEntidades);                    
                    fr.fnCambiarEstadoVenta(true, lsDetalleVentaAnticipo);
                }
                else
                {
                    fr.fnCambiarEstadoVenta(false,new List<DetalleVenta>());
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
                    fr.fnRecuperarTipoPago(lstEntidades, lsDetalleVentaAnticipo, lsDocumentoVenta, lsDetalleVenta);
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

            DialogResult resp = new DialogResult();
            if (lstEntidades.Count > 0)
            {
                if (restaPrecio > 0)
                {
                    resp = MessageBox.Show("En realidad deseá guardar el págo como págo pendiente?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (resp == DialogResult.Yes)
                    {
                        fnEnviarDatosLuegoDeAceptar();

                    }
                }
                else if (restaPrecio == 0)
                {

                    fnEnviarDatosLuegoDeAceptar();
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Por favor Ingrese el monto correcto. Agregue medios de págo ", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            //if (rdbSi.Checked == true)
            //{
            //    Decimal cantPagar = Convert.ToDecimal(string.Format("{0:0.00}", clsPagosGeneral.cantAPagar));
            //    Decimal PagaCOnEntidades = Convert.ToDecimal(string.Format("{0:0.00}", lstEntidades.Sum(i => i.PagaCon)- lsDetalleVentaAnticiposRecibidos.Sum(i=>i.Importe)));
            //    if (lstEntidades.Count>0 && cantPagar == PagaCOnEntidades)
            //    {
            //        fnEnviarDatosLuegoDeAceptar();
            //        this.Dispose();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Por favor Ingrese el monto correcto. Agregue entidades de págo ", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
            //else if (rdbNo.Checked == true)
            //{
            //    DialogResult resp = new DialogResult();
            //    resp = MessageBox.Show("En realidad deseá guardar el págo como págo pendiente?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            //    if (resp == DialogResult.Yes)
            //    {
            //        fnEnviarDatosLuegoDeAceptar();
            //        this.Dispose();
            //        ////opcion para venta general
            //        //if (lnTipoLLamada == 0)
            //        //{
            //        //    Consultas.frmVPVenta frm = new Consultas.frmVPVenta();
            //        //    //MessageBox.Show("Todo Correcto");
            //        //    Mantenedores.frmRegistrarVenta.fnRecuperarTipoPago(lstEntidades);
            //        //    frm.fnCambiarEstado(true);
            //        //    this.Close();
            //        //}
            //        //// opcion para pagos mensuales
            //        //else if (lnTipoLLamada == -1)
            //        //{
            //        //    Procesos.frmControlPagoVenta.fnRecuperarTipoPago(lstEntidades);
            //        //    frmControlPagoVenta frm = new frmControlPagoVenta();
            //        //    frm.fnCambiarEstadoVenta(true);
            //        //    this.Close();
            //        //}
            //        //// opcion para otrasVentas
            //        //else if (lnTipoLLamada == -2)
            //        //{
            //        //    frmOtrasVentas.fnRecuperarTipoPago(lstEntidades);
            //        //    frmOtrasVentas frm2 = new frmOtrasVentas();
            //        //    frm2.fnRecuperarEstadoGenVenta(true);
            //        //    this.Close();

            //        //}
            //        //else if (lnTipoLLamada == -3 || lnTipoLLamada == 3)
            //        //{
            //        //    frmRegistrarEgresos frm = new frmRegistrarEgresos();
            //        //    frm.fnRecuperarEstadoGenVenta(true);
            //        //    frm.fnRecuperarTipoPago(lstEntidades);
            //        //    this.Close();
            //        //}
            //        //else if (lnTipoLLamada == -4)
            //        //{
            //        //    frmPagosPendientes frm = new frmPagosPendientes();
            //        //    frm.fnRecuperarEstadoGenVenta(true);
            //        //    frm.fnRecuperarTipoPago(lstEntidades);
            //        //    this.Close();
            //        //}
            //        //else
            //        //{
            //        //    //frmDocumentoVenta.fnRecuperarTipoPago(cboTipoPago.SelectedValue.ToString(), Convert.ToDecimal(txtCanPagar.Text), cboTipoPago.Text);
            //        //    this.Close();
            //        //}
            //    }
            //}



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
                fmr.fnCambiarEstadoVenta(false,new List<DetalleVenta>());
            }

            if (lnTipoLLamada == -1)
            {
                frmControlPagoVenta frm1 = new frmControlPagoVenta();
                frm1.fnCambiarEstadoVenta(false, new List<DetalleVenta>());
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
