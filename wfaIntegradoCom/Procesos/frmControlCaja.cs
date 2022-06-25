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
                dtFechaFinG.Value = Variables.gdFechaSis;
                dtFechaInicioG.Value = dtFechaFinG.Value.AddDays(-(dtFechaFinG.Value.Day - 1));

                //FunGeneral.fnLlenarTablaCodTipoCon(cboMetodopago, "TIPA",true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboTipoReporte, "TRPT", false);
                //FunGeneral.fnLlenarTablaCodTipoCon(cboDocumentoVenta, "DOVE",true);
                frmBuscarVentas frmBV = new frmBuscarVentas();
                //frmBV.fnlistarUsuario(cboUsuario, 2, true);

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

        //private void cboMetodopago_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    frmTipoPago.fnLlenarCombobox(btnEntidadPago,cboMetodopago.SelectedValue.ToString(),0,true);
        //}

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                fnBuscarVentasCaja("",0,-1);
            }
        }
        private void fnBuscarVentasCaja(String codOperacion, Int32 numPagina, Int32 tipoCon)
        {
            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();

            String fechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value,5);
            String fechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value,5);
            Int32 entidadPago =Convert.ToInt32(btnEntidadPago.SelectedValue);
            String codTipoReporte = cboTipoReporte.SelectedValue.ToString();
            Int32 TipoPlan = Convert.ToInt32(cboTipoPlanP.SelectedValue);
            Int32 tipotarifa = Convert.ToInt32(cboTipoVenta.SelectedValue);
            Int32 idUsuario = 0;
            String tipoPago = cboTipoPago.SelectedValue.ToString();
            String cBuscar = txtBuscarRepGeneral.Text.ToString();
            Boolean chkHabilitarFechas = chkHabilitarFechasBusG.Checked;
            Boolean chkDiaEsp = chkDiaEspecificoG.Checked;

            Int32 filas = 10;

            dtRes = bl.blfnBuscarVentasCaja(chkHabilitarFechas, chkDiaEsp, fechaIni, fechaFin, codTipoReporte , entidadPago, codOperacion, TipoPlan, tipotarifa, tipoPago, idUsuario, cBuscar, numPagina,  tipoCon);
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
                        //dr["idDocumentoVenta"].ToString(),
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
                    //FunValidaciones.fnCalcularPaginacion(totalRegistros, filas,  totalRows, cboPagina,btnTotalPag,btnNumFilas,btnTotalReg);
                }

                //btnMontoTotal.Text = FunGeneral.fnFormatearPrecio("S/.", Convert.ToDouble(dtRes.Rows[0][1]), 0);
                dgvListaVentas.Visible = true;
            }
            else
            {
                //btnMontoTotal.Text = FunGeneral.fnFormatearPrecio("S/.", Convert.ToDouble(000), 0);
            }
            
        }
        private void fnBuscarReporteGeneralVentas(Int32 numPagina, Int32 tipoCon)
        {
            bl = new BLControlCaja();
            DataTable dtRes = new DataTable();
            List<ReporteBloque> lsReporteBloque = new List<ReporteBloque>();

            String fechaIni = FunGeneral.GetFechaHoraFormato(dtFechaInicioG.Value,5);
            String fechaFin = FunGeneral.GetFechaHoraFormato(dtFechaFinG.Value,5);

            String codTipoReporte = cboTipoReporte.SelectedValue.ToString();
            String codTipoOperacion = "";

            Int32 TipoPlan = Convert.ToInt32(cboTipoPlanP.SelectedValue);
            Int32 tipotarifa = Convert.ToInt32(cboTipoVenta.SelectedValue);

            String cBuscar = txtBuscarRepGeneral.Text.ToString();
            Boolean chkHabilitarFechas = chkHabilitarFechasBusG.Checked;
            Boolean chkDiaEsp = chkDiaEspecificoG.Checked;

            Int32 filas = 10;

            lsReporteBloque = bl.BuscarReporteGeneralVentas(chkHabilitarFechas, chkDiaEsp, fechaIni, fechaFin, codTipoReporte, codTipoOperacion, TipoPlan, tipotarifa, cBuscar, numPagina,  tipoCon);
            Int32 totalRows = lsReporteBloque.Count;
            dgvListaPorBloque.Columns.Clear();
            dgvListaPorBloque.Rows.Clear();

            Int32 y = 0;

            if (totalRows>0)
            {
                dgvListaPorBloque.Columns.Add("id", "id");
                dgvListaPorBloque.Columns.Add("num", "N°");
                dgvListaPorBloque.Columns.Add("detalle", "Detalle");
                dgvListaPorBloque.Columns.Add("cantidad", "Cantidad");
                dgvListaPorBloque.Columns.Add("Importe", "Importe");
                this.dgvListaPorBloque.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                if (numPagina == 0)
                {
                    y = 0;
                }
                else
                {
                    tabInicio = (numPagina - 1) * filas;
                    y = tabInicio;
                }

                for(Int32 i=0; i < totalRows; i++)
                {
                    ReporteBloque clsRep = lsReporteBloque[i];
                    dgvListaPorBloque.Rows.Add(
                        clsRep.Codigoreporte,
                        y + 1,
                        clsRep.Detallereporte,
                        clsRep.Cantidad,
                        FunGeneral.fnFormatearPrecio(clsRep.SimboloMoneda, clsRep.ImporteRow, 0)                        
                        );
                    y += 1;
                    dgvListaPorBloque.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvListaPorBloque.Rows[i].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                dgvListaPorBloque.Columns[0].Visible = false;
                dgvListaPorBloque.Columns[1].Width = 10;
                dgvListaPorBloque.Columns[2].Width = 100;
                dgvListaPorBloque.Columns[3].Width = 20;
                dgvListaPorBloque.Columns[4].Width = 100;
                //this.dgvListaPorBloque.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;




                //if (numPagina == 0)
                //{
                //    //cboPaginacion.Visible = true;
                //    Int32 totalRegistros = Convert.ToInt32(dtRes.Rows[0][0]);
                //    FunValidaciones.fnCalcularPaginacion(totalRegistros, filas,  totalRows, cboPagina,btnTotalPag,btnNumFilas,btnTotalReg);
                //}

                lblMontoTotalRepBloque.Text = FunGeneral.fnFormatearPrecio("S/.", lsReporteBloque.Sum(i=>i.ImporteRow), 0);
            
            }
            else
            {
                dgvListaPorBloque.Columns.Add("id", "NO SE ENCONTRARON RESULTADOS PARA LA BUSQUEDA");
                lblMontoTotalRepBloque.Text = FunGeneral.fnFormatearPrecio("S/.", Convert.ToDouble(000), 0);
            }
            
        }

        private void siticoneLabel3_Click(object sender, EventArgs e)
        {

        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarVentasCaja("",0, -1);
        }

        private void cboTipoPlanP_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnListarTipoPago(cboTipoPago, Convert.ToInt32(cboTipoPlanP.SelectedValue), "ESDOV", true);
        }

        private void chkHabilitarFechasBus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechasBusG.Checked == true)
            {
                gbHabilitarBusqFechas.Enabled = true;
                chkDiaEspecificoG.Visible = true;
            }
            else
            {
                gbHabilitarBusqFechas.Enabled = false;
                chkDiaEspecificoG.Visible = false;
                chkDiaEspecificoG.Checked = false;
            }
        }

        private void chkDiaEspecifico_CheckedChanged(object sender, EventArgs e)
        {
            fnValidarBusquedaDia();
        }
        private void fnValidarBusquedaDia()
        {
            if (chkDiaEspecificoG.Checked==true)
            {
                label2.Visible = false;
                dtFechaFinG.Visible = false;
                label1.Text = "Elija el dia para buscar:";
            }
            else
            {
                label2.Visible = true;
                dtFechaFinG.Visible = true;
                label1.Text = "Fecha Final:";
            }
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            fnBuscarVentasCaja("",0, -1);
        }

        private void cboTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            siticonePanel2.Visible = false;
            String CodOperacion = cboTipoReporte.SelectedValue.ToString();
            if (CodOperacion== "TRPT0001")
            {
                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboOperacion, "idOperacion", "cNombreOperacion", "OperacionHusat", "estValida", "1", false);
            }
            else if (CodOperacion == "TRPT0002")
            {
                siticonePanel2.Visible = true;
                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboOperacion, "cCodTab", "cNomTab", "TablaCod", "cCodTab", "TIPA", false);

            }
            else if (CodOperacion == "TRPT0003")
            {
                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboOperacion, "idUsuario", "cUser", "Usuario", "estValida", "1", false);

            }
            else if (CodOperacion == "TRPT0004")
            {
                FunGeneral.fnLlenarCboSegunTablaTipoCon(cboOperacion, "cCodTab", "cNomTab", "TablaCod", "cCodTab", "DOVE", false);


            }
        }

        private void txtBuscarRepGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                fnBuscarReporteGeneralVentas(0,-1);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvListaPorBloque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String codOperacion = dgvListaPorBloque.Rows[e.RowIndex].Cells[0].Value.ToString();
            fnBuscarVentasCaja(codOperacion, 0, -1);

        }

        private void dgvListaPorBloque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String codTipoReporte = cboTipoReporte.SelectedValue.ToString();
            String codOperacion = dgvListaPorBloque.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (codTipoReporte== "TRPT0001")
            {
                if (codOperacion == "4")
                {
                    cboTipoPlanP.SelectedValue=2; ;
                    cboTipoPlanP.Enabled=false ;

                }else if (codOperacion == "3")
                {
                    cboTipoPlanP.Items.Remove(2);
                }
            }
            frmTipoPago.fnLlenarCombobox(btnEntidadPago, codOperacion, 0, true);

        }
    }
}
