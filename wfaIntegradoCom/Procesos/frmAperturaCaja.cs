using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmAperturaCaja : Form
    {
        public frmAperturaCaja()
        {
            InitializeComponent();
        }
        List<ReporteBloque> lstCierreCajaAnterior = new List<ReporteBloque>();
        ReporteBloque clsrb = new ReporteBloque();

        static Int32 idUsuarioST = 0;
        static String Nomusuario = "";
        static Int32 idApertura = 0;
        static Int32 intTipoApertura = 0;
        static DateTime dtFechaApertura = Variables.gdFechaSis;
        
        public void tipoApertura(DateTime dt,  Int32 idUsuario,String cUsuario, Int32 tipoCon, Int32 idApe)
        {
            idUsuarioST = idUsuario;
            Nomusuario = cUsuario;
            idApertura = idApe;
            intTipoApertura = tipoCon;
            dtFechaApertura = dt;
            this.ShowDialog();

        }
        public void Inicio()
        {

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegistrar.Focus();
                e.SuppressKeyPress = true;
            }
        }


        private String fnAperturarCaja(decimal lnMonto)
        { 
            String lcResultado="";
            BLDocumentoVenta obj = new BLDocumentoVenta();
            clsUtil objUtil= new clsUtil();
            try
            {

                lcResultado = obj.blAperturarCaja(Variables.idSucursal, lnMonto, Variables.gnCodUser, FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 3),1,lstCierreCajaAnterior);
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Aperturó su caja exitosamente","Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                this.Dispose();
                return lcResultado;

            }
            catch(Exception ex)
            {
                lcResultado = "XX";
                objUtil.gsLogAplicativo("frmAperturaCaja", "fnAperturarCaja", ex.Message);
                return lcResultado;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string lcResultado = "";
            decimal lnMonto = 0;
            epUsuario.Clear();
            lnMonto = Convert.ToDecimal(txtMonto.Text.Trim() == "" ? "0" : txtMonto.Text.Trim());
            if (lnMonto>=0)
            {
                if (lstCierreCajaAnterior.Count==0)
                {
                    if (lnMonto == 0)
                    {
                        DialogResult mr = MessageBox.Show("En realidad desea aperturar caja en Cero ?", "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (mr == DialogResult.Yes)
                        {
                            lcResultado = fnAperturarCaja(lnMonto);
                            if (lcResultado != "OK")
                            {
                                MessageBox.Show("Error al Aperturar Caja. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }

                    }
                    else
                    {
                        lcResultado = fnAperturarCaja(lnMonto);
                        if (lcResultado != "OK")
                        {
                            MessageBox.Show("Error al Aperturar Caja. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    if (lnMonto == Convert.ToDecimal(clsrb.ImporteTotal))
                    {
                        if (lnMonto == 0)
                        {
                            DialogResult mr = MessageBox.Show("En realidad desea aperturar caja en Cero ?", "Aviso!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (mr == DialogResult.Yes)
                            {
                                lcResultado = fnAperturarCaja(lnMonto);
                                if (lcResultado != "OK")
                                {
                                    MessageBox.Show("Error al Aperturar Caja. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }

                        }
                        else
                        {
                            lcResultado = fnAperturarCaja(lnMonto);
                            if (lcResultado != "OK")
                            {
                                MessageBox.Show("Error al Aperturar Caja. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Revise su caja e ingrese en monto correcto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                

            }
            else
            {
                MessageBox.Show("El Monto no puede ser Menor a cero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }    

        private void frmAperturaCaja_Load(object sender, EventArgs e)
        {

            if (intTipoApertura != -1)
            {
                idUsuarioST = Variables.gnCodUser;
                dtFechaApertura = Variables.gdFechaSis;

                if (!(FunGeneral.fnVerificarApertura(idUsuarioST) == 1 ? true : false))
                {
                    lstCierreCajaAnterior = FunGeneral.fnBuscarImporteCierreAnterior(idUsuarioST,-1);

                    clsrb = lstCierreCajaAnterior.Count > 0 ? lstCierreCajaAnterior[0] : new ReporteBloque();
                    if (clsrb is ReporteBloque)
                    {
                        lblMostraCierreAnterior.Text = "En tu caja debes tener: " + FunGeneral.fnFormatearPrecio(clsrb.SimboloMoneda, clsrb.ImporteTotal, 1);

                    }
                    else
                    {
                        clsrb.ImporteTotal = 0;
                        clsrb.SimboloMoneda = "S/."; ;
                        lblMostraCierreAnterior.Text = "En tu caja debes tener: " + FunGeneral.fnFormatearPrecio(clsrb.SimboloMoneda, clsrb.ImporteTotal, 1);
                    }
                    txtFecha.Text = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 6);
                    txtUsuario.Text = Variables.gsCodUser;
                    txtMonto.Focus();
                }
                else
                {
                    Double ImporteDeApertura = 0;
                    foreach (CuadreCaja item in Variables.lstCuardreCaja)
                    {
                        if (item.idOperacion == 1)
                        {
                            ImporteDeApertura = item.importeSaldo;
                        }
                    }
                    lblMostraCierreAnterior.Text = "Ya as aperturado Caja Con el Monto de: " + FunGeneral.fnFormatearPrecio(Variables.lstCuardreCaja[0].SimbloMon, ImporteDeApertura, 1);
                    this.Text = "Aperturar Caja - Ya se ha aperturado caja en el día";
                    txtFecha.Text = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 6);
                    txtUsuario.Text = Variables.gsCodUser;
                    txtMonto.Enabled = false;
                    btnRegistrar.Enabled = false;
                }
            }
            else
            {
                Int32 numHora = 0;
                if (idUsuarioST==4)
                {
                    numHora = 11;
                    String dt = dtFechaApertura.ToString("yyyy/MM/dd");
                    //dtFechaApertura=Convert.ToDateTime(dt).AddHours
                    dtFechaApertura.AddHours(10);
                    dtFechaApertura.AddHours(10);
                }
                else
                {

                }
                lstCierreCajaAnterior = FunGeneral.fnBuscarImporteCierreAnterior(idUsuarioST,-2);
                txtFecha.Text = FunGeneral.GetFechaHoraFormato(dtFechaApertura, 6);
                txtUsuario.Text = Nomusuario;
            }
        }

        private void btnRegistrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string lcResultado = "";
                decimal lnMonto = 0;
                lnMonto = Convert.ToDecimal(txtMonto.Text.Trim() == "" ? "0" : txtMonto.Text.Trim());
                epUsuario.Clear();
                if (lnMonto > 0)
                {
                    lcResultado = fnAperturarCaja(lnMonto);
                    if (lcResultado != "OK")
                    {
                        MessageBox.Show("Error al Aperturar Caja. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else { epUsuario.SetError(txtMonto, "Ingresar un monto de Apertura de Caja"); }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
