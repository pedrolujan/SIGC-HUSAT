using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Microsoft.Reporting.WinForms;
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Impresiones
{
    public partial class frmImpresion : Form
    {
        public frmImpresion()
        {
            InitializeComponent();
        }

        Int16 lnTipoLlamada = 0;
        String lcNomForm = "";
        Int32 lnDocuGeneral = 0;

        public void fnInicio(Int16 pnTiLlamada, String pcNomForm,Int32 pidDocuGeneral)
        {
            lnTipoLlamada = pnTiLlamada;
            lcNomForm = pcNomForm;
            lnDocuGeneral = pidDocuGeneral;
            this.ShowDialog();
        }

        private String fnImprimir(Int32 piDocuGeneral)
        {
            BLDocumentoVenta objVenta = new BLDocumentoVenta();
            DocumentoVenta[] lstVenta = new DocumentoVenta[1];
            List<DetalleVenta> lstDetalleVen = new List<DetalleVenta>();
            clsUtil objUtil = new clsUtil();
            ReportParameter[] parameters = new ReportParameter[1];
            try
            {
                lstVenta = objVenta.blListarDocVenta(piDocuGeneral).ToArray();
                lstDetalleVen = objVenta.blListarDetalleVenta(piDocuGeneral);

                reportViewer1.Reset();
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                parameters[0] = new ReportParameter("rpEmpresa", Variables.gsEmpresa);
                reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Impresiones.Report1.rdlc";
                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsVenta",lstVenta));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDetalleVenta", lstDetalleVen));
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();

                return "OK";
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmImpresion", "fnImprimir", ex.Message);
                return "NO";
            }
            finally {
                objUtil = null;
                lstDetalleVen = null;
                lstVenta = null;
            }
        }

        private String fnImprimirOrden(Int32 pidOrden)
        {
            BLOrdenCompra objOrden = new BLOrdenCompra();
            OrdenCompra[] lstOrden = new OrdenCompra[1];
            List<DetalleCompra> lstDetalleCompra = new List<DetalleCompra>();
            clsUtil objUtil = new clsUtil();
            ReportParameter[] parameters = new ReportParameter[1];
            try
            {
                lstOrden = objOrden.blListarOrden(pidOrden).ToArray();
                lstDetalleCompra = objOrden.blListarDetalleCompra(pidOrden);
                reportViewer1.Reset();
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                parameters[0] = new ReportParameter("rpEmpresa", Variables.gsEmpresa);
                reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Impresiones.rptImprimeOrden.rdlc";
                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsOrden", lstOrden));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDetalleCompra", lstDetalleCompra));
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();

                return "OK";
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmImpresion", "fnImprimirOrden", ex.Message);
                return "NO";
            }
            finally
            {
                objUtil = null;
                lstDetalleCompra = null;
                lstOrden = null;
            }
        }

        private String fnImprimirTraslado(Int32 pidTraslado)
        {
            BLTraslado objOrden = new BLTraslado();
            Traslado[] lstOrden = new Traslado[1];
            List<DetalleTraslado> lstDetalleCompra = new List<DetalleTraslado>();
            clsUtil objUtil = new clsUtil();
            ReportParameter[] parameters = new ReportParameter[1];
            try
            {
                lstOrden = objOrden.blBuscarTraslado(pidTraslado.ToString(),0).ToArray();
                lstDetalleCompra = objOrden.BLListarDetalleTraslado(pidTraslado,true);
                reportViewer1.Reset();
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                parameters[0] = new ReportParameter("rpEmpresa", Variables.gsEmpresa);
                reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Impresiones.rptImprimeTraslado.rdlc";
                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsTraslado", lstOrden));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDetalleTraslado", lstDetalleCompra));
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();

                return "OK";
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmImpresion", "fnImprimirOrden", ex.Message);
                return "NO";
            }
            finally
            {
                objUtil = null;
                lstDetalleCompra = null;
                lstOrden = null;
            }
        }

        private String fnListarCajaDia(String pcFecha, Int32 pidUsuario, out decimal pnSaldo)
        {
            BLDocumentoVenta objOrden = new BLDocumentoVenta();
            clsUtil objUtil = new clsUtil();
            ReportParameter[] parameters = new ReportParameter[2];
            List<Cuadre> lstCaja = null;

            try
            {
                lstCaja = new List<Cuadre>();
                lstCaja = objOrden.blListarCajaDia(pcFecha, pidUsuario, Variables.idSucursal, out pnSaldo);
                reportViewer1.Reset();
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                parameters[0] = new ReportParameter("rpFecha", Variables.gdFechaSis.ToString());
                parameters[1] = new ReportParameter("rpUsuario", Variables.gsCodUser);
                reportViewer1.LocalReport.ReportEmbeddedResource = "wfaIntegradoCom.Consultas.rptCuadreCaja.rdlc";
                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCuadre", lstCaja));
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.RefreshReport();

                return "OK";
            }
            catch (Exception ex)
            {
                pnSaldo = 0;
                objUtil.gsLogAplicativo("frmImpresion", "fnListarCajaDia", ex.Message);
                return "NO";
            }
            finally
            {
                objUtil = null;
                objOrden = null;
                lstCaja = null;
            }
        }
     
        private void frmImpresion_Load(object sender, EventArgs e)
        {
            string lcResultado = "";
            decimal Saldo=0;
            this.Text = lcNomForm.Trim();
            if (lnTipoLlamada == 0)
                lcResultado = fnImprimir(lnDocuGeneral).Trim();
            else if (lnTipoLlamada == 1)
                lcResultado = fnImprimirOrden(lnDocuGeneral).Trim();
            else if (lnTipoLlamada == 2)
                lcResultado = fnImprimirTraslado(lnDocuGeneral).Trim();
            else
                lcResultado = fnListarCajaDia(FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis,5), Variables.gnCodUser, out Saldo);

            if (lcResultado != "OK")
                reportViewer1.Enabled = false;
            
        }

    }
}
