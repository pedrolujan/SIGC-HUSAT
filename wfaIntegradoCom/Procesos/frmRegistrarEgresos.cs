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
        static Moneda clsMoneda = new Moneda();
        Boolean estArea, estUsuario, estMoneda, estImporte, estDescripcion;
        static Int32 lnTipoLlamada = 0;
        static List<Pagos> lstPagosTrandiaria = new List<Pagos>();
        static Boolean estadoGuardarEgreso = false;
        public void Inicio(Int32 tipoLlam)
        {
            lnTipoLlamada = tipoLlam;
            this.ShowDialog();
        }
        private void frmRegistrarEgresos_Load(object sender, EventArgs e)
        {
            try
            {
                FunGeneral.fnLlenarTablaCodTipoCon(cboArea, "PETR",false);
                lstMoneda=FunGeneral.fnLLenarMoneda(cboMoneda,0,false);

                cboArea.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);
                cboUsuario.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);
                cboMoneda.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);
                frmOtrasVentas.fnLlenarTablaCod(cboTipoDocEmitir, "DOVE", 1, 0);
                cboTipoDocEmitir.SelectedValue = "DOVE0003";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void fnRecuperarTipoPago(List<Pagos> lstEntidades)
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
            Double precioUnitario = Convert.ToDouble(txtImporte.Text.ToString());
            double importe = (precioUnitario * cantidad) - 0;
            lstDetV.Add(new DetalleVenta
            {
                Numeracion = 1,
                Descripcion = FunGeneral.FormatearCadenaTitleCase(txtDescripcion.Text.ToString()),
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
                cCliente = FunGeneral.FormatearCadenaTitleCase(clsPers.cPrimerNom + " " + clsPers.cApePat + " " + clsPers.cApeMat),
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
                cVehiculos = "Egresos",
                cDescripcionTipoPago = (lstPagosTrandiaria.Count > 0) ? FunGeneral.FormatearCadenaTitleCase(lstPagosTrandiaria[0].cDescripTipoPago) : "",
                cDescripEstadoPP = (lstPagosTrandiaria.Count > 0) ? lstPagosTrandiaria[0].cEstadoPP : "",
                cTipoVenta = "EGRESOS"

            });
            return lsDocVenta;


            //DocumentoVenta.cTipoDoc = Convert.ToString(cboTipoDocumento.Text);
            //DocumentoVenta.cVehiculos = lstvehiculo[0].vPlaca;
            //lstDocVenta.Add(DocumentoVenta);
        }
        private void fnGenerarDocumento()
        {
            Consultas.frmVPVenta frm = new Consultas.frmVPVenta();
            List<DetalleVenta> lstDetalleVenta = fnDetalleVenta();
            frm.Inicio(fnDocumentoVentaHeader(fnCalcularCabeceraDetalle(lstDetalleVenta)),/*lstOtrasVentas*/ lstDetalleVenta, -3);
        }
        private void btnGuardarEgreso_Click(object sender, EventArgs e)
        {
            frmTipoPago frmtp = new frmTipoPago();
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

                frmtp.Inicio(-3, Convert.ToDouble(txtImporte.Text.ToString()), clsMoneda.cSimbolo);
                }
            }
            else
            {
                MessageBox.Show("Complente Correctamente los campos","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void fnGuardarEgreso()
        {

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
