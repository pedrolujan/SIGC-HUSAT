using CapaEntidad;
using CapaNegocio;
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
using wfaIntegradoCom.Mantenedores;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmControlCaja : Form
    {
        public frmControlCaja()
        {
            InitializeComponent();
        }
        BLControlCaja bl;
        static Int32 tabInicio=0;
        private void frmControlCaja_Load(object sender, EventArgs e)
        {
            try
            {
                dtFechaFin.Value = Variables.gdFechaSis;
                dtFechaInicio.Value = dtFechaFin.Value.AddDays(-(dtFechaFin.Value.Day - 1));

                FunGeneral.fnLlenarTablaCodTipoCon(cboMetodopago, "TIPA",true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboDocumentoVenta, "DOVE",true);
                frmBuscarVentas frmBV = new frmBuscarVentas();
                frmBV.fnlistarUsuario(cboUsuario, 2, true);

                frmRegistrarVenta frm = new frmRegistrarVenta();
                frm.fnLlenarTipoTarifa(0, cboTipoVenta, true);
                frm.fnLlenarTipoPlan(0, cboTipoPlanP, 0);
                fnListarTipoPago(cboTipoPago,0, "ESDOV", true);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void fnListarTipoPago(ComboBox cbo,Int32 idTipPlan,String id,Boolean estado)
        {
            bl = new BLControlCaja();
            List<ControlCaja> lstControl = new List<ControlCaja>();

            lstControl= bl.blFnLLenarTipoPago( idTipPlan,id, estado);

            cbo.DataSource = null;
            cbo.ValueMember = "codTipoPago";
            cbo.DisplayMember = "descripTipoPago";
            cbo.DataSource = lstControl;

        }

        private void cboMetodopago_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmTipoPago.fnLlenarCombobox(btnEntidadPago,cboMetodopago.SelectedValue.ToString(),0,true);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                fnBuscarVentasCaja(0,-1);
            }
        }
        private void fnBuscarVentasCaja(Int32 numPagina, Int32 tipoCon)
        {
            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();

            String fechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicio.Value,5);
            String fechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFin.Value,5);
            String metodPago = cboMetodopago.SelectedValue.ToString();
            Int32 entidadPago =Convert.ToInt32(btnEntidadPago.SelectedValue);
            String documentoVenta = cboDocumentoVenta.SelectedValue.ToString();
            Int32 TipoPlan = Convert.ToInt32(cboTipoPlanP.SelectedValue);
            Int32 tipotarifa = Convert.ToInt32(cboTipoVenta.SelectedValue);
            Int32 idUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
            String tipoPago = cboTipoPago.SelectedValue.ToString();
            String cBuscar = txtBuscar.Text.ToString();
            Boolean chkHabilitarFechas = chkHabilitarFechasBus.Checked;
            Boolean chkDiaEsp = chkDiaEspecifico.Checked;

            Int32 filas = 10;

            dtRes = bl.blfnBuscarVentasCaja(chkHabilitarFechas, chkDiaEsp, fechaIni, fechaFin, metodPago, entidadPago, documentoVenta, TipoPlan, tipotarifa, tipoPago, idUsuario, cBuscar, numPagina,  tipoCon);
            Int32 totalRows = dtRes.Rows.Count;
            dgvListaVentas.Rows.Clear();

            Int32 y = 0;

            if (totalRows>0)
            {
                if (numPagina == 0)
                {
                    y = 0;
                }
                else
                {
                    tabInicio = (numPagina - 1) * filas;
                    y = tabInicio;
                }
                foreach (DataRow dr in dtRes.Rows)
                {
                    dgvListaVentas.Rows.Add(
                        dr["idTrandiaria"].ToString(),
                        dr["idDocumentoVenta"].ToString(),
                        y+1,
                       FunGeneral.GetFechaHoraFormato(Convert.ToDateTime(dr["fechaPago"]), 1),
                       dr["cNombreOperacion"],
                       dr["metodopago"],
                       dr["cNombreEntidad"].ToString()== "CONTADO"?"": dr["cNombreEntidad"],
                       dr["cNumeroOperacion"],
                       dr["nomDocumentoVenta"],
                       dr["tipotarifa"],
                       dr["cUser"],
                       FunGeneral.fnFormatearPrecio(dr["cSimbolo"].ToString(), Convert.ToDouble(dr["TotalPago"]),1)
                        );
                    y += 1;
                }

                if (numPagina == 0)
                {
                    //cboPaginacion.Visible = true;
                    Int32 totalRegistros = Convert.ToInt32(dtRes.Rows[0][0]);
                    FunValidaciones.fnCalcularPaginacion(totalRegistros, filas,  totalRows, cboPagina,btnTotalPag,btnNumFilas,btnTotalReg);
                }

                btnMontoTotal.Text = FunGeneral.fnFormatearPrecio("S/.", Convert.ToDouble(dtRes.Rows[0][1]), 0);
                dgvListaVentas.Visible = true;
            }
            else
            {
                btnMontoTotal.Text = FunGeneral.fnFormatearPrecio("S/.", Convert.ToDouble(000), 0);
            }
            
        }

        private void siticoneLabel3_Click(object sender, EventArgs e)
        {

        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarVentasCaja(Convert.ToInt32(cboPagina.Text), -1);
        }

        private void cboTipoPlanP_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnListarTipoPago(cboTipoPago, Convert.ToInt32(cboTipoPlanP.SelectedValue), "ESDOV", true);
        }

        private void chkHabilitarFechasBus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechasBus.Checked == true)
            {
                gbFechasBusq.Enabled = true;
                chkDiaEspecifico.Visible = true;
            }
            else
            {
                gbFechasBusq.Enabled = false;
                chkDiaEspecifico.Visible = false;
                chkDiaEspecifico.Checked = false;
            }
        }

        private void chkDiaEspecifico_CheckedChanged(object sender, EventArgs e)
        {
            fnValidarBusquedaDia();
        }
        private void fnValidarBusquedaDia()
        {
            if (chkDiaEspecifico.Checked==true)
            {
                label22.Visible = false;
                dtFechaInicio.Visible = false;
                label35.Text = "Elija el dia para buscar:";
            }
            else
            {
                label22.Visible = true;
                dtFechaInicio.Visible = true;
                label35.Text = "Fecha Final:";
            }
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            fnBuscarVentasCaja(0, -1);
        }
    }
}
