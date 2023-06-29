using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Procesos;

namespace wfaIntegradoCom.Consultas
{
    public partial class frmVPVenta : Form
    {
        List<DetalleVenta> lstDVenta;
        List<DocumentoVenta> lstCDocumento;
        VentaGeneral clsVentaGeneral;
        Byte[] btImage;
        static Boolean estVP=false;
        static Int32 lnTipoCon = 0;
        static Int32 lnEstadosProcesos = 0;
        static List<Pagos> lstPagosTrand = new List<Pagos>();
        public frmVPVenta()
        {
            InitializeComponent();
        }
        public void Inicio(List<DocumentoVenta> lstDocV, List<DetalleVenta> lstDV,Int32 tipoCon)
        {
            lstCDocumento = new List<DocumentoVenta>();
            lstDVenta = new List<DetalleVenta>();
            clsVentaGeneral = new VentaGeneral();
            lstCDocumento = lstDocV;
            lstDVenta = lstDV;
            //clsVentaGeneral = clsVG;
            lnTipoCon = tipoCon;
            ShowDialog();
        }
        public void Inicio(List<DocumentoVenta> lstDocV, List<DetalleVenta> lstDV, Byte[] bt, Int32 tipoCon)
        {
            lstCDocumento = new List<DocumentoVenta>();
            lstDVenta = new List<DetalleVenta>();
            clsVentaGeneral = new VentaGeneral();
            //msImage = new MemoryStream();
            lstCDocumento = lstDocV;
            lstDVenta = lstDV;
            //clsVentaGeneral = clsVG;
            lnTipoCon = tipoCon;
            btImage = bt;
            ShowDialog();
        }
        public void fnCambiarEstado(Boolean estado)
        {
            estVP = estado;
        }
        public void fnEstadoProcesos(Int32 lnEp)
        {
            lnEstadosProcesos = lnEp;
        }
        private void fmrVPVenta_Load(object sender, EventArgs e)
        {
            this.reportViewer1.ShowPrintButton = true;
            FunValidaciones.fnColorAceptarCancelar(btnGenerarVenta, btnVolver);
            if (lnTipoCon == 1)
            {
                //this.reportViewer1.Height = 615;
                //this.reportViewer1.ShowPrintButton = true;
                //this.reportViewer1.ShowExportButton = true;
                this.label1.Visible = false;
                this.btnGenerarVenta.Text = "Imprimir";
                this.btnGenerarVenta.Visible=false;
                this.btnVolver.Visible=false;
            }
            else
            {
                //opcion para pagos mensuales
                if (lnTipoCon==-1)
                {
                    this.btnGenerarVenta.Text = "Generar Pago";
                }
                //this.reportViewer1.Height = 528;
                this.reportViewer1.ShowPrintButton = false;
                this.reportViewer1.ShowExportButton = false;

            }
            if (lnTipoCon==-3 || lnTipoCon == 3)
            {
                btnGenerarVenta.Text = "Guardar Movimiento";
                btnGenerarVenta.Width = btnGenerarVenta.Width + 15;
            }
            if (lnTipoCon == -4)
            {
                //label1.Text = "¿Desea Anular este Documento?";
                //btnGenerarVenta.Text = "Anular Documento";
                //btnGenerarVenta.Width = btnGenerarVenta.Width + 15;
                label1.Text = "¿Desea finalizar el pago de la cuota?";
                btnGenerarVenta.Text = "Finalizar pago";
                btnGenerarVenta.Width = btnGenerarVenta.Width + 15;
            }
            if (lnTipoCon == -5)
            {
                label1.Text = "¿Anular este documento?";
                btnGenerarVenta.Text = "Anular Documento";
                btnGenerarVenta.Width = btnGenerarVenta.Width + 15;
            }
            this.reportViewer1.RefreshReport();
            fnCargarReporte(lstCDocumento, lstDVenta,btImage);
        }

        private void fnCargarReporte(List<DocumentoVenta> lstC, List<DetalleVenta> lstDV,Byte[] bt)
        {
            reportViewer1.Reset();
            if (bt is null || bt.Length<2 )
            {
                String rutaArchivo = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR\";
                bt = File.ReadAllBytes(rutaArchivo + "QR\\QrDefecto.png");
                
            }
            MemoryStream ms = new MemoryStream(bt);
            ReportParameter[] parameters = new ReportParameter[7];
            
            lstC[0].cCliente= lstC[0].cCliente.Trim();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            parameters[0] = new ReportParameter("rpRazonSocial", Variables.gsEmpresa);
            parameters[1] = new ReportParameter("rpRucEmpresa", Variables.gsRuc);
            parameters[2] = new ReportParameter("rpSucursal", Variables.gsSucursal);
            parameters[3] = new ReportParameter("rpEmpresaDir", Variables.gsEmpresaDir);
            parameters[4] = new ReportParameter("rpEmpresaUbigeo", Variables.gsSucursalUbigeo);
            parameters[5] = new ReportParameter("rpUsuario", Variables.gsCodUser);
            parameters[6] = new ReportParameter("rpQR", Convert.ToBase64String(ms.ToArray()));

            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.rptComprobantePago.rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DocumentoVenta", lstC));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDetalleVenta", lstDV));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }

        private void fnVolver()
        {
            frmTipoPago frm = new frmTipoPago();
            if (lnTipoCon == 0)
            {
                //Mantenedores.frmRegistrarVenta fmr2 = new Mantenedores.frmRegistrarVenta();
                //fmr2.fnCambiarEstadoVenta(false);
                frm.fnCambiarEstadoPago(false);

            }
            else if (lnTipoCon == 1)
            {
                //Mantenedores.frmRegistrarVenta fmr2 = new Mantenedores.frmRegistrarVenta();
                //fmr2.fnActivarInprecion(false);
                frm.fnCambiarEstadoPago(false);
            }
            else if (lnTipoCon == -1)
            {
                //frmControlPagoVenta frmCVent = new frmControlPagoVenta();
                //frmCVent.fnCambiarEstadoVenta(false);
                frm.fnCambiarEstadoPago(false);

            }
            else if (lnTipoCon == -2)
            {
                frmOtrasVentas fr = new frmOtrasVentas();
                fr.fnRecuperarEstadoGenVenta(false);
                fr.fnCondicionProcesos(0);
                frm.fnCambiarEstadoPago(false);
            }
            else if (lnTipoCon == -3 || lnTipoCon == 3)
            {
                //frmRegistrarEgresos frm = new frmRegistrarEgresos();
                //frm.fnRecuperarEstadoGenVenta(false);
                frm.fnCambiarEstadoPago(false);
            }
            else if (lnTipoCon == -4)
            {
                //frmAnularVenta frm = new frmAnularVenta();
                //frm.fnEstadoAnulacion(false);
                frm.fnCambiarEstadoPago(false);
            }
            else if (lnTipoCon == -5)
            {
                //frmPagosPendientes frm = new frmPagosPendientes();
                //frm.fnRecuperarEstadoGenVenta(false);
                frm.fnCambiarEstadoPago(false);
            }

        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            fnVolver();

            this.Close();
        }



        private void btnGenerarVenta_Click(object sender, EventArgs e)
        {
            frmTipoPago frm = new frmTipoPago();
            //opcion para venta general
            if (lnTipoCon == 0)
            {
                //List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();
               
                frm.fnCambiarEstadoPago(true);
                ///venta general
            }
            //opcion para pagos mensuales
            else if (lnTipoCon==-1)
            {
                //Procesos.frmTipoPago fmr = new Procesos.frmTipoPago();
                //Decimal sumaPrimerPago = lstDVenta.Sum(i => i.Importe);
                //fmr.Inicio(-1, sumaPrimerPago, lstDVenta[0].cSimbolo, lstCDocumento[0].cCodDocumentoVenta);              
                
                frm.fnCambiarEstadoPago(true);

            }
            // opcion para otras ventas
            else if(lnTipoCon == -2)
            {
                if (lnEstadosProcesos==0)
                {
                    //Procesos.frmTipoPago fmr = new Procesos.frmTipoPago();
                    //Decimal sumaPrimerPago = lstDVenta.Sum(i => i.Importe);
                    //fmr.Inicio(-2, sumaPrimerPago, lstDVenta[0].cSimbolo, lstCDocumento[0].cCodDocumentoVenta);
                    frm.fnCambiarEstadoPago(true);
                }
                else if (lnEstadosProcesos==-1)
                {
                    frmOtrasVentas fr = new frmOtrasVentas();
                    fr.fnCondicionProcesos(-1);
                    frm.fnCambiarEstadoPago(true);
                }
                else if (lnEstadosProcesos == -2)
                {
                    frmOtrasVentas fr = new frmOtrasVentas();
                    fr.fnCondicionProcesos(-2);
                    frm.fnCambiarEstadoPago(true);
                }
                else if (lnEstadosProcesos == 3)
                {
                    frmOtrasVentas fr = new frmOtrasVentas();
                    fr.fnCondicionProcesos(3);
                    frm.fnCambiarEstadoPago(true);
                }
                if (lnEstadosProcesos == -7 || lnEstadosProcesos == -8)
                {
                    frmOtrasVentas fr = new frmOtrasVentas();
                    fr.fnCondicionProcesos(5);
                    frm.fnCambiarEstadoPago(true);
                }




            }
            else if (lnTipoCon == -3 || lnTipoCon==3)
            {
                //Procesos.frmTipoPago fmr = new Procesos.frmTipoPago();
                //Decimal sumaPrimerPago = lstDVenta.Sum(i => i.Importe);
                //fmr.Inicio(lnTipoCon, sumaPrimerPago, lstDVenta[0].cSimbolo, lstCDocumento[0].cCodDocumentoVenta);
                frm.fnCambiarEstadoPago(true);
            }
            else if (lnTipoCon == -4)
            {
                //frmAnularVenta frm = new frmAnularVenta();
                //frm.fnEstadoAnulacion(true);
                frm.fnCambiarEstadoPago(true);
            }
            else if (lnTipoCon == -5)
            {
                frmAnularVenta frmA = new frmAnularVenta();
                frmA.fnEstadoAnulacion(true);
            }

            this.Close();
        }

        private void gunaControlBox4_Click(object sender, EventArgs e)
        {
            fnVolver();
            //if (lnTipoCon == 0)
            //{
            //    Mantenedores.frmRegistrarVenta fmr2 = new Mantenedores.frmRegistrarVenta();
            //    fmr2.fnCambiarEstadoVenta(false);


            //}
            //else if (lnTipoCon == 1)
            //{
            //    Mantenedores.frmRegistrarVenta fmr2 = new Mantenedores.frmRegistrarVenta();
            //    fmr2.fnActivarInprecion(false);
            //}
            //else if (lnTipoCon == -1)
            //{
            //    frmControlPagoVenta frmCVent = new frmControlPagoVenta();
            //    frmCVent.fnCambiarEstadoVenta(false);

            //}
            //else if (lnTipoCon==-2)
            //{
            //    frmOtrasVentas fr = new frmOtrasVentas();
            //    fr.fnRecuperarEstadoGenVenta(false);
            //    fr.fnCondicionProcesos(0);
            //}
            //else if (lnTipoCon == -3 || lnTipoCon==3)
            //{
            //    frmRegistrarEgresos frm = new frmRegistrarEgresos();
            //    frm.fnRecuperarEstadoGenVenta(false);
            //}
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            string nombreArchivo = lstCDocumento[0].NombreDocumento+" "+ lstDVenta[0].Descripcion+" "+ lstCDocumento[0].cCliente; // Especificar el nombre deseado para el archivo

            // Modificar el nombre del archivo en la descarga
            ReportViewer viewer = (ReportViewer)sender;
            viewer.LocalReport.DisplayName = nombreArchivo;
        }
    }
}
