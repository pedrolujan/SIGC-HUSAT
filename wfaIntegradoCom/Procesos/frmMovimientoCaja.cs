using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;
using CapaUtil;
using wfaIntegradoCom.Funciones;
using Siticone.UI.WinForms;
using wfaIntegradoCom.Consultas;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmMovimientoCaja : Form
    {

        Int32 intTipoLlamada = 0;

        public frmMovimientoCaja()
        {
            InitializeComponent();
        }


        public frmMovimientoCaja(int pintTipoLllamada)
        {
            InitializeComponent();
            intTipoLlamada = pintTipoLllamada;
        }
        static List<ReporteBloque> lstReporteIngresos = new List<ReporteBloque>();
        static List<ReporteBloque> lstReporteEgresos = new List<ReporteBloque>();
        static List<ReporteBloque> lstDetalleIngresos = new List<ReporteBloque>();

        static Int32 estadoApertura = 0;
        CuadreCaja clsCuadreCaja = new CuadreCaja();
        static Int32 lnTipoCon = 0;
        public void Inicio(List<ReporteBloque> lstIngresos, List<ReporteBloque> lstEgresos, List<ReporteBloque> lstDetIngresos, Int32 tipoCon)
        {
            lstReporteIngresos = lstIngresos;
            lstReporteEgresos = lstEgresos;
            lstDetalleIngresos = lstDetIngresos;
            intTipoLlamada = tipoCon;
            this.ShowDialog();
        }


        public Boolean fnCargarUsuario()
        {
            BLUsuario objUsuario = new BLUsuario();
            clsUtil objUtil = new clsUtil();
            List<Usuario> lstUsuario = new List<Usuario>();
            try
            {
                lstUsuario = objUsuario.BLListarCargooUsuario(true, 1);

                cboUsuario.DisplayMember = "cUser";
                cboUsuario.ValueMember = "cPersonal";
                cboUsuario.DataSource = lstUsuario;
                
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmMovimientoCaja", "fnCargarUsuario", ex.Message);
                return false;
            }
            finally
            {
                objUsuario = null;
                lstUsuario = null;
            }

           
        }

        static decimal lnMontoArqueo=0;

        public static void fnObtenerMontoArqueo(decimal pnArqueo)
        {
            lnMontoArqueo=pnArqueo;
        }

        private Boolean fnListarCajaDia(String pcFecha,Int32 pidUsuario, out decimal pnSaldo)
        {
            BLDocumentoVenta objOrden = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            List<Cuadre> lstCaja = null;

            try
            {
                lstCaja = new List<Cuadre>();
                lstCaja = objOrden.blListarCajaDia(pcFecha, pidUsuario, Variables.idSucursal, out pnSaldo);
                dgvIngresos.DataSource = lstCaja;
                return true;
            }
            catch (Exception ex)
            {
                pnSaldo = 0;
                objUtil.gsLogAplicativo("frmMovimientoCaja", "fnListarCajaDia", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objOrden = null;
                lstCaja = null;
            }
        }

        string pcFecha = "";
        private void fnActivarSegunApertura()
        {
            if (estadoApertura==1)
            {
                btnAperturarCaja.Enabled = false;
                btnCerrar.Enabled = true;
            }
            else
            {
               
                btnAperturarCaja.Enabled = true;
                btnCerrar.Enabled = false;
                lstReporteIngresos.Clear();
                lstReporteEgresos.Clear();
            }
        }
        private void frmMovimientoCaja_Load(object sender, EventArgs e)
        {
            bool bResult = false;
            decimal nSaldo = 0;
            int intUsuario = 0;
           
            estadoApertura = FunGeneral.fnVerificarApertura(Variables.gnCodUser);

            if (intTipoLlamada==0)
            {
                fnActivarSegunApertura();
                fnLlenarTablas(lstReporteIngresos, dgvIngresos, txtTotalIngresos);
                fnLlenarTablas(lstReporteEgresos, dgvEgresos, txtTotalEgresos);

                CuadreCaja clcCaja = Variables.lstCuardreCaja.Find(i => i.idOperacion == 1);
                Double importe = 0;
                if (clcCaja is CuadreCaja)
                {
                    importe = clcCaja.importeSaldo;
                    lblMontoDeAperturaCaja.Text = "IMPORTE DE: "+ FunGeneral.FormatearCadenaTitleCase(clcCaja.Detalle)+" "+FunGeneral.fnFormatearPrecio(clcCaja.SimbloMon, clcCaja.importeSaldo,1);
                }
                else
                {
                    importe = 0;
                    lblMontoDeAperturaCaja.Text = "";

                }

                clsCuadreCaja.importeTotalIngresos = lstReporteIngresos.Sum(i => i.ImporteRow);
                clsCuadreCaja.importeTotalEgresos = lstReporteEgresos.Sum(i => i.ImporteRow);

                clsCuadreCaja.Detalle = "Cierre de caja de - " + FunGeneral.FormatearCadenaTitleCase(Variables.gsCodUser);

                clsCuadreCaja.importeSaldo = (clsCuadreCaja.importeTotalIngresos + (clsCuadreCaja.importeTotalEgresos * -1)+ importe);
                
                clsCuadreCaja.SimbloMon = "S/.";

                clsCuadreCaja.MonImporteSaldo= FunGeneral.fnFormatearPrecio("S/.", clsCuadreCaja.importeSaldo, 0);
                txtTotalCerrarCaja.Text= FunGeneral.fnFormatearPrecio("S/.", clsCuadreCaja.importeSaldo, 0); 
            }

            //if (intTipoLlamada == 0)
            //{
            //    paBusqueda.Visible = true;
            //    bResult = fnCargarUsuario();
            //    pcFecha = FunGeneral.GetFechaHoraFormato(dateTimePicker1.Value, 5);
            //    intUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
            //    //paBusqueda.Visible = false;
            //    //pcFecha = FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 5);
            //    //intUsuario = Variables.gnCodUser;

            //}
            //else
            //{
            //    paBusqueda.Visible = true;
            //    bResult = fnCargarUsuario();
            //    pcFecha = FunGeneral.GetFechaHoraFormato(dateTimePicker1.Value, 5);
            //    intUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
            //}
            //bResult = fnListarCajaDia(pcFecha, intUsuario, out nSaldo);
            //if (!bResult)
            //{
            //    MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.Close();
            //}
            textBox1.Text = nSaldo.ToString();
        }

        private void fnLlenarTablas(List<ReporteBloque> lst,DataGridView dgv,SiticoneTextBox txt)
        {
            Int32 TotCantidad = 0;
            Double TotImporte = 0;
            Int32 y = 0;
            foreach (ReporteBloque rp in lst)
            {

                TotImporte += rp.ImporteRow;
                TotCantidad += rp.Cantidad;
                dgv.Rows.Add(rp.Codigoreporte, rp.numero, FunGeneral.FormatearCadenaTitleCase(rp.Detallereporte), rp.Cantidad, FunGeneral.fnFormatearPrecio("S/.", rp.ImporteRow, 0));
                y++;
            }
            txt.Text = FunGeneral.fnFormatearPrecio("S/.", TotImporte, 0);
           
            //dgv.Rows.Add("", "", "", "", "");
            //dgv.Rows.Add("TOTAL", "", "IMPORTE TOTAL INGRESOS", TotCantidad, FunGeneral.fnFormatearPrecio("S/.", TotImporte, 0));
            //dgv.Rows[y + 1].DefaultCellStyle.BackColor = Color.Red;
            //dgv.Rows[y + 1].DefaultCellStyle.ForeColor = Color.White;
        }
        Int32 lidTrandiaria = 0;

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            lidTrandiaria = 0;
            //Boolean bFilaSele = false;
            if (dgvIngresos.RowCount > 0)
            {
                //lidTrandiaria = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
        }

        private Boolean fnEliminarMovCaja(Int32 pidTrandiaria, int pidUsuario, string pcFechaSis)
        {
            BLDocumentoVenta objOrden = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtOrden = new DataTable();
            bool lbResul = false;

            try
            {
                lbResul = objOrden.blEliminarMovCaja(pidTrandiaria,pidUsuario,pcFechaSis);
                return lbResul;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmMovimientoCaja", "fnEliminarMovCaja", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objOrden = null;
                dtOrden = null;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool lbResul = false;
            decimal  lnSaldo = 0;
                    if (dgvIngresos.Rows.Count > 0)
                    {
                        if (lidTrandiaria > 0)
                        {
                            if (MessageBox.Show("Desea eliminar el Movimiento de Caja Seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                lbResul=fnEliminarMovCaja(lidTrandiaria,Variables.gnCodUser,FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis,3));
                                if (!lbResul)
                                    MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                else
                                {
                                    lbResul = fnListarCajaDia(pcFecha, Funciones.Variables.gnCodUser, out lnSaldo);
                                    if (!lbResul)
                                    {
                                        MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.Close();
                                    }
                                    textBox1.Text = lnSaldo.ToString();
                                }
                            }
                        }
                    }
            
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool lbResul = false;
            decimal lnSaldo = 0;

            if (dgvIngresos.Rows.Count > 0)
            {
                lidTrandiaria = Convert.ToInt32(dgvIngresos.CurrentRow.Cells[0].Value);
                if (lidTrandiaria > 0)
                {
                    if (MessageBox.Show("Desea eliminar el Movimiento de Caja Seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        lbResul = fnEliminarMovCaja(lidTrandiaria, Variables.gnCodUser, FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 3));
                        if (!lbResul)
                            MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        else
                        {
                            lbResul = fnListarCajaDia(pcFecha, Funciones.Variables.gnCodUser, out lnSaldo);
                            if (!lbResul)
                            {
                                MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();
                            }
                            textBox1.Text = lnSaldo.ToString();
                        }
                    }
                }
            }
        }

        private String fnCerrarCaja(decimal lnMonto)
        {
            String lcResultado = "";
            BLDocumentoVenta obj = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            try
            {

                //lcResultado = obj.blAperturarCaja(Variables.idSucursal, lnMonto, Variables.gnCodUser, FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis, 3), 11);
                if (lcResultado == "OK")
                    this.Dispose();
                return lcResultado;

            }
            catch (Exception ex)
            {
                lcResultado = "XX";
                objUtil.gsLogAplicativo("frmMovimientoCaja", "fnCerrarCaja", ex.Message);
                return lcResultado;
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            String lcResultado = "";
            decimal lnMontoSaldo=0;
            decimal lnMontoArqueo=0;
            List<CuadreCaja> lstCuadreCaja = new List<CuadreCaja>();
            
            lstCuadreCaja.Add(clsCuadreCaja);
            List<xmlActaCierraCaja> xmlActaCierre = new List<xmlActaCierraCaja>();
            frmActaCierreCaja frmCierreC = new frmActaCierreCaja();
            Personal clt = Variables.clasePersonal;
            xmlActaCierre.Add(new xmlActaCierraCaja
            {
                ListaReporteIngresos = lstReporteIngresos,
                ListaReporteDetalleIngresos = lstDetalleIngresos,
                ListaReporteEgresos = lstReporteEgresos,
                ListaCuadreCaja = lstCuadreCaja,
                dtFechaRegistro=Variables.gdFechaSis,
                cNomSucursal=Variables.gsSucursal,
                idSucursal=Variables.idSucursal,
                idUsuario=Variables.gnCodUser,
                cUsuario=Variables.gsCodUser,
                nomPersonal= clt.cPrimerNom + " " + clt.cApePat + " " + clt.cApeMat,
                turno= Variables.gdFechaSis.Hour < 15 ? " Mañana" : " Tarde",
            });

            frmCierreC.Inicio(xmlActaCierre, 1);
            
            //if (FunGeneral.fnVerificarApertura())
            //{
            //    lnMontoSaldo=Convert.ToDecimal(textBox1.Text.Trim() == "" ? "0" : textBox1.Text.Trim());
            //    lnMontoArqueo=Convert.ToDecimal(txtMontoArqueo.Text.Trim() == "" ? "0" : txtMontoArqueo.Text.Trim());
            //    if (lnMontoArqueo >= lnMontoSaldo)
            //    {
            //        lcResultado = fnCerrarCaja(lnMontoArqueo);
            //        if (lcResultado != "OK")
            //        {
            //            btnCerrar.Enabled = false;
            //            MessageBox.Show("Error al Cerrar Caja. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        }
            //    }
            //    else {
            //        MessageBox.Show("Verificar su caja tiene un descuadre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //else {
            //    MessageBox.Show("Debe Aperturar Caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void btnArqueo_Click(object sender, EventArgs e)
        {
            frmArquearCaja frmArqueo = new frmArquearCaja();
            frmArqueo.ShowDialog();
            txtMontoArqueo.Text = lnMontoArqueo.ToString();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Impresiones.frmImpresion frmImpre = new Impresiones.frmImpresion();
            frmImpre.fnInicio(3, "Imprimir Cuadre de Caja", 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool lbResul = false;
            decimal lnSaldo = 0;
            frmAperturaCaja frmCaja = new frmAperturaCaja();
            frmCaja.ShowDialog();
            lbResul = fnListarCajaDia(pcFecha, Funciones.Variables.gnCodUser, out lnSaldo);
            if (!lbResul)
            {
                MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            textBox1.Text = lnSaldo.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            decimal nSaldo = 0;
            int intUsuario = 0;

            pcFecha = FunGeneral.GetFechaHoraFormato(dateTimePicker1.Value, 5);
            intUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
        
            bResult = fnListarCajaDia(pcFecha, intUsuario, out nSaldo);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Movimientos en Caja", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            textBox1.Text = nSaldo.ToString();
        }

        private void btnAperturarCaja_Click(object sender, EventArgs e)
        {
            Boolean estAperturaCaja=false;
            Int32 num= FunGeneral.fnVerificarApertura(Variables.gnCodUser);
            estAperturaCaja = num == 1 ? true : false;
            if (estAperturaCaja == false)
            {

                frmAperturaCaja frmAp = new frmAperturaCaja();
                frmAp.ShowDialog();
            }
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            MDIParent1 frm = new MDIParent1();
            Int32 num = FunGeneral.fnVerificarApertura(Variables.gnCodUser);
            frm.fnCambiarEstado(num==1?true:false);
            //frm.fnMostrarDashboard();
        
        }

     
    }
}
