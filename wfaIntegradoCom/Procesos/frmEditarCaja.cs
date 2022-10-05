using CapaDato;
using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Siticone.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Mantenedores;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmEditarCaja : Form
    {

        public frmEditarCaja()
        {
            InitializeComponent();

        }

        List<Cargo> lstTipoProcesoCaja;
        List<Cargo> lstOpciones = new List<Cargo>();
        static Int32 intApeCierre = 0;
        static List<ReporteBloque> lstAperCierre = new List<ReporteBloque>();
        BLControlCaja bl;
        private void fnLlenarProcesos(DataGridView dgv, List<Cargo> lst)
        {
            dgv.Rows.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
                dgv.Rows.Add(
                            lst[i].cCodTab,
                            i+1,
                            lst[i].cNomTab
                            );
            }
           
        }
        private void frmEditarCaja_Load(object sender, EventArgs e)
        {
            lstTipoProcesoCaja = new List<Cargo>();
            try
            {

                lstTipoProcesoCaja = FunGeneral.fnLlenarTablaCodTipoConDT("TOAC00", true);
                fnLlenarProcesos(dgContenedor, lstTipoProcesoCaja);
                fnLlenarUsuariosConAccion(cboUsuario,dtFechaAccion,dtFechaAccion,false);
                dtFechaAccion.Value = Variables.gdFechaSis;
                cboUsuario.SelectedValue = Variables.gsCargoUsuario == "PETR0006" ? Variables.gnCodUser : 0;
                cboUsuario.Enabled = Variables.gsCargoUsuario == "PETR0006" ? false : true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgContenedor_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgContenedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String codOpcion = dgContenedor.Rows[e.RowIndex].Cells[0].Value.ToString();
            
            BLCaja blCaja = new BLCaja();
            lstOpciones=blCaja.blBuscarTipoOpciones(codOpcion,0);
            
            fnLlenarProcesos(dgvOpciones, lstOpciones);
            if (codOpcion == "TOAC0004")
            {
                intApeCierre = -2;
                fnBuscarAccionCajaUsuario(intApeCierre);

            }
            else if (codOpcion == "TOAC0001")
            {
                intApeCierre = -1;
                fnBuscarAccionCajaUsuario(intApeCierre);
            }
            else
            {
                intApeCierre = 0;

            }

        }

        private void fnLlenarUsuariosConAccion(SiticoneComboBox cbo, SiticoneDateTimePicker dtIni, SiticoneDateTimePicker dtFin, Boolean estado)
        {
            DAControlCaja dc = new DAControlCaja();
            List<Usuario> lstUsuario = new List<Usuario>();
            DataTable dt = new DataTable();
            String FI = FunGeneral.GetFechaHoraFormato(dtIni.Value, 5);
            String FF = FunGeneral.GetFechaHoraFormato(dtFin.Value, 5);
            Int32 tipCOn = -1;

            dt = dc.daDevolverSoloUsuario(true, FI, FF, tipCOn);

            lstUsuario.Add(new Usuario(
                Convert.ToInt32(0),
                Convert.ToString(estado ? "TODOS" : "Selecc. Usuario")
              ));

            foreach (DataRow drMenu in dt.Rows)
            {
                lstUsuario.Add(new Usuario(
                    Convert.ToInt32(drMenu["idUsuario"]),
                    Convert.ToString(drMenu["cUser"])
                    ));
            }
            cbo.ValueMember = "idUsuario";
            cbo.DisplayMember = "cUser";
            cbo.DataSource = lstUsuario;


        }

        private void dgvOpciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime dtFecha = dtFechaAccion.Value;
            String codigo=dgvOpciones.Rows[e.RowIndex].Cells[0].Value.ToString();
            

            Int32 tipoCon = -1;

            if (codigo== "TOACI001")
            {
                frmRegistrarVenta frm = new frmRegistrarVenta();
                frm.tipoApertura(dtFecha, tipoCon);
            }else if (codigo== "TOACI002")
            {
                frmControlPagoVenta frm = new frmControlPagoVenta();
                frm.tipoApertura(dtFecha, tipoCon);
            }else if (codigo == "TOACI003")
            {
                frmOtrasVentas frm = new frmOtrasVentas();
                frm.tipoApertura(dtFecha, tipoCon);
            }else if (codigo == "TOACI004")
            {
                frmRegistrarEgresos frm = new frmRegistrarEgresos();
                frm.tipoApertura(dtFecha, tipoCon);
            }else if (codigo == "TOACE001")
            {
                frmRegistrarEgresos frm = new frmRegistrarEgresos();
                frm.tipoApertura(dtFecha, -2);
            }else if (intApeCierre==-1)
            {
                ReporteBloque clsReporte = lstAperCierre.Find(i => i.Codigoreporte== codigo);
                
                frmAperturaCaja frm = new frmAperturaCaja();
                frm.tipoApertura(dtFecha, clsReporte.idAuxiliar, clsReporte.cUsuario, tipoCon,Convert.ToInt32(clsReporte.Codigoreporte));
            }
            else if (intApeCierre==-2)
            {
                ReporteBloque clsReporte = lstAperCierre.Find(i => i.Codigoreporte == codigo);
                frmMovimientoCaja frm = new frmMovimientoCaja();
                List<ReporteBloque> lstRepDetalleIngresos = new List<ReporteBloque>();
                //lstRepDetalleIngresos = fnBuscarDetalleParaCuadre();
                //frm.tipoApertura();
                frm.ShowDialog() ;
            }

            //Cargo clsOpciones = lstOpciones.Find(i => i.cCodTab == codigo);
            //fnDevolverForm(clsOpciones.nValor1).ShowDialog();
        }

        private void dgvOpciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private List<ReporteBloque> fnBuscarDetalleParaCuadreDashboard()
        //{
        //    List<ReporteBloque> lst = new List<ReporteBloque>();

        //    bl = new BLControlCaja();
        //    DataTable dtRes = new DataTable();
        //    Busquedas clsBusq = new Busquedas();
        //    clsBusq.chkActivarFechas = true;
        //    clsBusq.chkActivarDia = true;
        //    clsBusq.dtFechaIni = FunGeneral.GetFechaHoraFormato(dtFechaAccion.Value, 5);
        //    clsBusq.dtFechaFin = FunGeneral.GetFechaHoraFormato(dtFechaAccion.Value, 5);
        //    clsBusq.cod1 = cboTipoReporte.Items.Count == 0 ? "0" : cboTipoReporte.SelectedValue.ToString();
        //    clsBusq.cod2 = codOperacion;
        //    clsBusq.cod3 = cboOperacion.SelectedValue is null ? "" + Variables.gnCodUser : cboOperacion.SelectedValue.ToString();
        //    clsBusq.cod4 = "";
        //    clsBusq.cBuscar = txtBuscarRepGeneral.Text.ToString();
        //    clsBusq.tipoCon = 0;


        //    return bl.blDetalleParaCuadre(clsBusq, lsReporteBloqueGen);
        //}
        private Form fnDevolverForm(String pcNomForm)
        {
            Object obj = null;

            Assembly sm = Assembly.GetExecutingAssembly();

            foreach (Type Tipo in sm.GetTypes())
            {
                if (Tipo.Name.ToUpperInvariant() == pcNomForm.ToUpperInvariant())
                {
                    pcNomForm = Tipo.Namespace + '.' + Tipo.Name;
                    break;
                }
            }
            obj = sm.CreateInstance(pcNomForm);
            return (Form)obj;
        }

        private void dtFechaAccion_ValueChanged(object sender, EventArgs e)
        {
            fnLlenarUsuariosConAccion(cboUsuario, dtFechaAccion, dtFechaAccion, false);
            cboUsuario.SelectedValue = Variables.gsCargoUsuario == "PETR0006" ? Variables.gnCodUser : 0;
        }

        private void cboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ReporteBloque> lstApertura = new List<ReporteBloque>();
            fnBuscarAccionCajaUsuario(intApeCierre);
            //lstApertura
        }

        private void fnBuscarAccionCajaUsuario( Int32 tipoCon)
        {
            BLCaja blCaj = new BLCaja();
            String dt = FunGeneral.GetFechaHoraFormato(dtFechaAccion.Value,5);
            Int32 idUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
            List<ReporteBloque> lstRB = new List<ReporteBloque>();


            lstRB=blCaj.blBuscarAccionCaja(dt,idUsuario, tipoCon);

            fnLlenarProcesosRB(dgvOpciones, lstRB);

        }
        private void fnLlenarProcesosRB(DataGridView dgv, List<ReporteBloque> lst)
        {
            lstAperCierre.Clear();
            lstAperCierre = lst;
            dgv.Rows.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
                dgv.Rows.Add(
                            lst[i].Codigoreporte,
                            i + 1,
                            "ABRIR " + lst[i].Detallereporte + "-"+lst[i].cUsuario +"=> "+FunGeneral.fnFormatearPrecio(lst[i].SimboloMoneda, lst[i].ImporteRow,0)
                            );
            }

        }
    }
            
      

}
