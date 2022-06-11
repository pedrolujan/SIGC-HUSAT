using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Microsoft.Reporting.WinForms;
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
using wfaIntegradoCom.Procesos;

namespace wfaIntegradoCom.Consultas
{
    public partial class frmVPVenta : Form
    {
        List<DetalleVenta> lstDVenta;
        List<DocumentoVenta> lstCDocumento;
        VentaGeneral clsVentaGeneral;
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
            this.reportViewer1.RefreshReport();
            fnCargarReporte(lstCDocumento, lstDVenta);
        }
        private void fnCargarReporte(List<DocumentoVenta> lstC, List<DetalleVenta> lstDV)
        {
            ReportParameter[] parameters = new ReportParameter[6];
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            parameters[0] = new ReportParameter("rpRazonSocial", Variables.gsEmpresa);
            parameters[1] = new ReportParameter("rpRucEmpresa", Variables.gsRuc);
            parameters[2] = new ReportParameter("rpSucursal", Variables.gsSucursal);
            parameters[3] = new ReportParameter("rpEmpresaDir", Variables.gsEmpresaDir);
            parameters[4] = new ReportParameter("rpEmpresaUbigeo", Variables.gsSucursalUbigeo);
            parameters[5] = new ReportParameter("rpUsuario", Variables.gsCodUser);
            reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.rptComprobantePago.rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DocumentoVenta", lstC));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDetalleVenta", lstDV));
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }

        
        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (lnTipoCon == 0)
            {
                Mantenedores.frmRegistrarVenta fmr2 = new Mantenedores.frmRegistrarVenta();
                fmr2.fnCambiarEstadoVenta(false);
            

            }
            else if(lnTipoCon==1)
            {
                Mantenedores.frmRegistrarVenta fmr2 = new Mantenedores.frmRegistrarVenta();
                fmr2.fnActivarInprecion(false);
            }
            else if (lnTipoCon ==-1)
            {
                frmControlPagoVenta frmCVent = new frmControlPagoVenta();
                frmCVent.fnCambiarEstadoVenta(false);

            }else if (lnTipoCon == -2)
            {
                frmOtrasVentas fr = new frmOtrasVentas();
                fr.fnRecuperarEstadoGenVenta(false);
                fr.fnCondicionProcesos(0);
            }

            this.Close();
        }



        private void btnGenerarVenta_Click(object sender, EventArgs e)
        {
            //opcion para venta general
            if (lnTipoCon == 0)
            {
                List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();
                Procesos.frmTipoPago fmr = new Procesos.frmTipoPago();
                Double sumaPrimerPago = lstDVenta.Sum(i => i.Importe);
                fmr.Inicio(0, sumaPrimerPago, lstDVenta[0].cSimbolo);
                if (estVP)
                {
                    Mantenedores.frmRegistrarVenta fmr2 = new Mantenedores.frmRegistrarVenta();
                    fmr2.fnCambiarEstadoVenta(true);
                }
            } 
            //opcion para pagos mensuales
            else if (lnTipoCon==-1)
            {
                Procesos.frmTipoPago fmr = new Procesos.frmTipoPago();
                Double sumaPrimerPago = lstDVenta.Sum(i => i.Importe);
                fmr.Inicio(-1, sumaPrimerPago, lstDVenta[0].cSimbolo);              
               

            }
            // opcion para otras ventas
            else if(lnTipoCon == -2)
            {
                if (lnEstadosProcesos==0)
                {
                    Procesos.frmTipoPago fmr = new Procesos.frmTipoPago();
                    Double sumaPrimerPago = lstDVenta.Sum(i => i.Importe);
                    fmr.Inicio(-2, sumaPrimerPago, lstDVenta[0].cSimbolo);
                }else if (lnEstadosProcesos==-1)
                {
                    frmOtrasVentas fr = new frmOtrasVentas();
                    fr.fnCondicionProcesos(-1);
                }else if (lnEstadosProcesos == -2)
                {
                    frmOtrasVentas fr = new frmOtrasVentas();
                    fr.fnCondicionProcesos(-2);
                }
               



            }

            this.Close();
        }

        private void gunaControlBox4_Click(object sender, EventArgs e)
        {
            if (lnTipoCon == 0)
            {
                Mantenedores.frmRegistrarVenta fmr2 = new Mantenedores.frmRegistrarVenta();
                fmr2.fnCambiarEstadoVenta(false);


            }
            else if (lnTipoCon == 1)
            {
                Mantenedores.frmRegistrarVenta fmr2 = new Mantenedores.frmRegistrarVenta();
                fmr2.fnActivarInprecion(false);
            }
            else if (lnTipoCon == -1)
            {
                frmControlPagoVenta frmCVent = new frmControlPagoVenta();
                frmCVent.fnCambiarEstadoVenta(false);

            }
            else if (lnTipoCon==-2)
            {
                frmOtrasVentas fr = new frmOtrasVentas();
                fr.fnRecuperarEstadoGenVenta(false);
                fr.fnCondicionProcesos(0);
            }
        }
    }
}
