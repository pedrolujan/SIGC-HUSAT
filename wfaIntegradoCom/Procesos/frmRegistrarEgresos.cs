using CapaEntidad;
using CapaNegocio;
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

namespace wfaIntegradoCom.Procesos
{
    public partial class frmRegistrarEgresos : Form
    {
        public frmRegistrarEgresos()
        {
            InitializeComponent();
        }
        static List<Moneda> lstMoneda = new List<Moneda>();
        static List<Moneda> lstMoneda2 = new List<Moneda>();
        static Moneda clsMoneda = new Moneda();
        Boolean estArea, estUsuario, estMoneda, estImporte, estDescripcion, estFuente;
        Boolean estArea2, estUsuario2, estMoneda2, estImporte2, estDescripcion2, estConcepto;
        static Int32 lnTipoLlamada = 0;
        static List<Pagos> lstPagosTrandiaria = new List<Pagos>();
        static List<DocumentoVenta> lstDocumentoVenta = new List<DocumentoVenta>();
        static List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();
        static Boolean estadoGuardarEgreso = false;
        Int32 tabIndex = 0;
        public void Inicio(Int32 tipoLlam)
        {
            lnTipoLlamada = tipoLlam;
            this.ShowDialog();
        }
        private void frmRegistrarEgresos_Load(object sender, EventArgs e)
        {
            try
            {
                dtFechaInicioG.Value = Variables.gdFechaSis;

                FunGeneral.fnLlenarTablaCodTipoCon(cboArea, "PETR",false);
                FunGeneral.fnLlenarTablaCodTipoCon(cboFuenteEgreso, "TEGR",false);

                lstMoneda=FunGeneral.fnLLenarMoneda(cboMoneda,0,false);
                lstMoneda2 =FunGeneral.fnLLenarMoneda(cboMoneda2, 0,false);

                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboTipoConcepto, "idOperacion", "cNombreOperacion", "OperacionHusat", "cGrupoOpe", "GOPE0004", false);

                cboArea.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);
                cboUsuario.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);
                cboMoneda.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);

                cboMoneda2.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);
                cboTipoConcepto.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);

                frmOtrasVentas.fnLlenarTablaCod(cboTipoDocEmitir, "DOVE", 1, 0);
                cboTipoDocEmitir.SelectedValue = "DOVE0003";
                frmOtrasVentas.fnLlenarTablaCod(cboTipoDocEmitir2, "DOVE", 1, 0);
                cboTipoDocEmitir2.SelectedValue = "DOVE0003";
                cboMoneda.SelectedValue = 1;
                cboMoneda2.SelectedValue = 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  void fnRecuperarTipoPago(List<Pagos> lstEntidades)
        {
            lstPagosTrandiaria = lstEntidades;

        }
        public void fnRecuperarEstadoGenVenta(Boolean estado)
        {
            estadoGuardarEgreso = estado;
        }
        private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            estArea=FunValidaciones.fnValidarCombobox(cboArea,lblArea,pbArea).Item1;

           FunGeneral.fnLlenarUsuarioPorCargo(cboUsuario, cboArea.SelectedValue.ToString(), false);
            
        }

        private void txtPlacaVehiculo_TextChanged(object sender, EventArgs e)
        {
            estImporte= fnValidarTexbox(txtImporte, lblImporte, pbImporte);


        }
        private Boolean fnValidarTexbox(SiticoneTextBox txt,Label lbl,PictureBox pb)
        {
            String str= txt.Text.ToString();
            Boolean estado = false;
            if (str == "" || str=="0" || Convert.ToDouble(str)+1==1)
            {
                lbl.Text = "Ingrese Correctamente el importe";
                pb.Image = Properties.Resources.error;
                txt.BorderColor = Variables.ColorError;
                estado = false;

            }
            else 
            {
                lbl.Text = "";
                pb.Image = Properties.Resources.ok;
                txt.BorderColor = Variables.ColorSuccess;
                estado = true;
            }
            return estado;
        }

        private void txtPlacaVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo nfi = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;

            char decSeperator;

            decSeperator = nfi.CurrencyDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !(char.IsDigit(e.KeyChar) | e.KeyChar == decSeperator))
            {
                e.Handled = true;
            }
        }

        private void txtPlacaVehiculo_Leave(object sender, EventArgs e)
        {
            txtImporte.Text = FunGeneral.fnFormatearPrecio("", txtImporte.Text.ToString() == "" ? 0 : Convert.ToDouble(txtImporte.Text.ToString()), -1);

        }

        private List<DetalleVenta> fnDetalleVenta()
        {
            List<DetalleVenta> lstDetV = new List<DetalleVenta>();
            Int32 cantidad = 1;
            Double precioUnitario = 0;
            double importe = 0;
            String descripcion = "";
            if (tabIndex==0)
            {
                precioUnitario = Convert.ToDouble(txtImporte.Text.ToString());
                importe = (precioUnitario * cantidad) - 0;
                descripcion = FunGeneral.FormatearCadenaTitleCase(txtDescripcion.Text.ToString());
            }
            else
            {
                precioUnitario = Convert.ToDouble(txtImporte2.Text.ToString());
                importe = (precioUnitario * cantidad) - 0;
                descripcion = FunGeneral.FormatearCadenaTitleCase(txtDescripcion2.Text.ToString());
            }
          
            lstDetV.Add(new DetalleVenta
            {
                Numeracion = 1,
                Descripcion = descripcion,
                idTipoTarifa = 0,
                PrecioUni = precioUnitario,
                Descuento = 0,
                gananciaRedondeo = 0,
                TotalTipoDescuento = 0,
                IdTipoDescuento = 0,
                Cantidad = 1,
                Couta = 0,
                Importe = importe,
                cSimbolo = clsMoneda.cSimbolo
            });

            return lstDetV;
        }
        private DetalleVentaCabecera fnCalcularCabeceraDetalle(List<DetalleVenta> lstDV)
        {
            DetalleVentaCabecera clsDVC = new DetalleVentaCabecera();
            DetalleVenta dvMensual = new DetalleVenta();
            clsDVC.IGV = 0;
            clsDVC.Total = lstDV.Sum(item => item.Importe);
            clsDVC.IGV = clsDVC.IGV;
            clsDVC.SubTotal = clsDVC.Total - clsDVC.IGV;
            clsDVC.SimboloMoneda = clsMoneda.cSimbolo;
            clsDVC.NombreDocumento = Convert.ToString(cboTipoDocEmitir.Text);
            clsDVC.CodDocumento = Convert.ToString(cboTipoDocEmitir.SelectedValue);
           
            return clsDVC;
        }
        private List<DocumentoVenta> fnDocumentoVentaHeader(DetalleVentaCabecera dvc )
        {

            List<DocumentoVenta> lsDocVenta = new List<DocumentoVenta>();
            TipoTarifa lstTipoVenta = new TipoTarifa();
            BLVentaGeneral blVG = new BLVentaGeneral();
            //lstTipoVenta = lstTipoTarifa.First(s => s.IdTipoTarifa == Convert.ToInt32(cboTipoVenta.SelectedValue));
            Personal clsUsuario = Variables.clasePersonal;
            Personal clsPers = blVG.blObtenerUsuarioActual(Convert.ToInt32(cboUsuario.SelectedValue));
            lsDocVenta.Add(new DocumentoVenta
            {
                idCliente = clsPers.idPersonal,
                cCliente = tabIndex == 0?FunGeneral.FormatearCadenaTitleCase(clsPers.cPrimerNom + " " + clsPers.cApePat + " " + clsPers.cApeMat): FunGeneral.FormatearCadenaTitleCase(cboTipoConcepto.Text.ToString()),
                cTipoDoc = "DNI",
                cDireccion = FunGeneral.FormatearCadenaTitleCase(cboArea.Text.ToString()),
                cDocumento = clsPers.cDocumento,
                SimboloMoneda = clsMoneda.cSimbolo,
                cCodDocumentoVenta = Convert.ToString(cboTipoDocEmitir.SelectedValue),
                NombreDocumento = Convert.ToString(cboTipoDocEmitir.Text),
                dFechaVenta = Convert.ToDateTime(Variables.gdFechaSis),
                idMoneda = clsMoneda.idMoneda,
                nSubtotal = dvc.SubTotal,
                nNroIGV = 18,
                nIGV = dvc.IGV,
                nMontoTotal = dvc.Total,
                cUsuario = clsUsuario.cPrimerNom + " " + clsUsuario.cApePat + " " + clsUsuario.cApeMat,
                cVehiculos = tabIndex==0?"Egreso":"Ingresos",
                cDescripcionTipoPago = (lstPagosTrandiaria.Count > 0) ? FunGeneral.FormatearCadenaTitleCase(lstPagosTrandiaria[0].cDescripTipoPago) : "",
                cDescripEstadoPP = (lstPagosTrandiaria.Count > 0) ? lstPagosTrandiaria[0].cEstadoPP : "",
                cTipoVenta = tabIndex == 0? "EGRESOS":"INGRESOS",
                cEstado="MOVIMIENTOCAJA",
                est0= tabIndex == 0?false:true,
                est1=true

            });
            return lsDocVenta;


            //DocumentoVenta.cTipoDoc = Convert.ToString(cboTipoDocumento.Text);
            //DocumentoVenta.cVehiculos = lstvehiculo[0].vPlaca;
            //lstDocVenta.Add(DocumentoVenta);
        }

        private void siticoneTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            estImporte2 = fnValidarTexbox(txtImporte2, lblImporte2, pbImporte2);
        }

        private void siticoneTextBox2_TextChanged(object sender, EventArgs e)
        {
            estDescripcion2 = FunValidaciones.fnValidarTexboxs(txtDescripcion2, lblDescripcion2, pbDescripcion2, true, true, true, 10, 1000, 1000, 1000, "Por favor describa correctamente la operación").Item1;

        }

        private void fnLimpiarCampos()
        {
            cboMoneda.SelectedValue = 1;
            cboMoneda2.SelectedValue = 1;
            cboArea.SelectedValue = "0";
            cboTipoConcepto.SelectedValue = 0;
            cboUsuario.SelectedValue = 0;
            txtImporte.Text = "";
            txtImporte2.Text = "";
            txtDescripcion.Text = "";
            txtDescripcion2.Text = "";

        }
        private void btnGuardarIngresos_Click(object sender, EventArgs e)
        {
            cboMoneda2_SelectedIndexChanged(sender, e);
            cboTipoConcepto_SelectedIndexChanged(sender, e);
            siticoneTextBox1_TextChanged_1( sender,  e);
            siticoneTextBox2_TextChanged( sender,  e);
            if (estMoneda2 && estConcepto && estImporte2 && estDescripcion2)
            {
                fnGenerarDocumento();
                if (estadoGuardarEgreso)
                {
                    fnGuardarIngresos();
                   

                }
            }
            else
            {
                MessageBox.Show("Complente Correctamente los campos", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabIndex = tabControl1.SelectedIndex;
        }

        private void cboTipoConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            estConcepto=FunValidaciones.fnValidarCombobox(cboTipoConcepto,lblConsepto,pbConcepto).Item1;
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboFuenteEgreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            estFuente= FunValidaciones.fnValidarCombobox(cboFuenteEgreso, lblFuente, pbFuente).Item1;
        }

        private void fnGenerarDocumento()
        {
            Consultas.frmVPVenta frm = new Consultas.frmVPVenta();
            lstDetalleVenta = fnDetalleVenta();
            lstDocumentoVenta = fnDocumentoVentaHeader(fnCalcularCabeceraDetalle(lstDetalleVenta));
            frm.Inicio(lstDocumentoVenta,lstDetalleVenta, -3);
        }
       
        private void btnGuardarEgreso_Click(object sender, EventArgs e)
        {
            estArea = FunValidaciones.fnValidarCombobox(cboArea, lblArea, pbArea).Item1;
            cboUsuario_SelectedIndexChanged(sender, e);
            estMoneda = FunValidaciones.fnValidarCombobox(cboMoneda, lblMoneda, pbMoneda).Item1;
            txtPlacaVehiculo_TextChanged( sender,  e);
            siticoneTextBox1_TextChanged( sender,  e);
            if (estArea && estUsuario && estMoneda && estImporte && estDescripcion)
            {
                fnGenerarDocumento();
                if (estadoGuardarEgreso)
                {
                    fnGuardarEgreso();
                }
            }
            else
            {
                MessageBox.Show("Complente Correctamente los campos","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cboMoneda2_SelectedIndexChanged(object sender, EventArgs e)
        {
            estMoneda2 = FunValidaciones.fnValidarCombobox(cboMoneda2, lblMoneda2, pbMoneda2).Item1;
            clsMoneda = lstMoneda.Find(i => i.idMoneda == Convert.ToInt32(cboMoneda2.SelectedValue));
        }

        private void fnGuardarEgreso()
        {
            BLEgresos blE = new BLEgresos();
            Egresos clsEgresos = new Egresos();
            clsEgresos.idEgreso = 0;
            clsEgresos.codAuxiliar = cboFuenteEgreso.SelectedValue.ToString();
            clsEgresos.cargo = cboArea.SelectedValue.ToString();
            clsEgresos.UsuarioReceptor = Convert.ToInt32(cboUsuario.SelectedValue);
            clsEgresos.importe = Convert.ToDouble(txtImporte.Text.ToString());
            clsEgresos.DetalleEgreso = txtDescripcion.Text.ToString();
            clsEgresos.lnTipoCon = -1;
            lstPagosTrandiaria[0].idMoneda = clsMoneda.idMoneda;
            List<xmlDocumentoVentaGeneral> xmlDVG = new List<xmlDocumentoVentaGeneral>();
            xmlDVG.Add(new xmlDocumentoVentaGeneral
            {
                xmlDocumentoVenta = lstDocumentoVenta,
                xmlDetalleVentas = lstDetalleVenta
            });

            Boolean estado= blE.blGuardarEgresos(lstPagosTrandiaria,xmlDVG, clsEgresos);
            if (estado)
            {
                MessageBox.Show("Egreso Guardado exitosamente","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                fnLimpiarCampos();
            }
            else
            {

                MessageBox.Show("Error al guardar egreso --Comunique al administrador", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void fnGuardarIngresos()
        {
            BLEgresos blE = new BLEgresos();
            Egresos clsEgresos = new Egresos();
            clsEgresos.idEgreso = 0;
            clsEgresos.cargo = cboTipoConcepto.SelectedValue.ToString();
            clsEgresos.UsuarioReceptor = tabIndex==1?0:Convert.ToInt32(cboUsuario.SelectedValue);
            clsEgresos.importe = Convert.ToDouble(txtImporte2.Text.ToString());
            clsEgresos.DetalleEgreso = txtDescripcion2.Text.ToString();
            clsEgresos.lnTipoCon = -2;
            lstPagosTrandiaria[0].idMoneda = clsMoneda.idMoneda;
            List<xmlDocumentoVentaGeneral> xmlDVG = new List<xmlDocumentoVentaGeneral>();
            xmlDVG.Add(new xmlDocumentoVentaGeneral
            {
                xmlDocumentoVenta = lstDocumentoVenta,
                xmlDetalleVentas = lstDetalleVenta
            });

            Boolean estado = blE.blGuardarEgresos(lstPagosTrandiaria, xmlDVG, clsEgresos);
            if (estado)
            {
                MessageBox.Show("Ingreso Guardado exitosamente", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fnLimpiarCampos();
            }
            else
            {

                MessageBox.Show("Error al guardar ingreso --Comunique al administrador", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
           estMoneda= FunValidaciones.fnValidarCombobox(cboMoneda, lblMoneda, pbMoneda).Item1;
            clsMoneda = lstMoneda.Find(i => i.idMoneda == Convert.ToInt32(cboMoneda.SelectedValue));
        }

        private void cboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            estUsuario= FunValidaciones.fnValidarCombobox(cboUsuario, lblUsuario, pbUsuario).Item1;
        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {
            estDescripcion=FunValidaciones.fnValidarTexboxs(txtDescripcion,lblDescripcion , pbDescripcion,true,true,true,15,1000,1000,1000,"Por favor describa correctamente la operación").Item1;

        }
    }
}
