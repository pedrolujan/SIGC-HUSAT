using CapaNegocio;
using CapaUtil;
using Siticone.UI.WinForms;
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

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmConsultarInformacion : Form
    {
        public frmConsultarInformacion()
        {
            InitializeComponent();
        }
        private clsUtil objUtil = null;
        private Boolean fnBuscarConsultas(Int32 Condicion)
        {
            BLConsultas objSimCard = new BLConsultas();
            clsUtil objUtil = new clsUtil();
            DataTable datEquipo = new DataTable();
            Boolean HabilitarFechas;
            Int32 totalResultados;
            try
            {
                DateTime fechaInicio = fnCalcularSoloFecha(dtHFechaInicio.Value);
                DateTime fechaFinal = fnCalcularSoloFecha(dtHfechaFinal.Value).AddDays(1);
                HabilitarFechas = Convert.ToBoolean(chkHabilitarFechas.Checked);
                dgConsultas.Rows.Clear();
                datEquipo = objSimCard.blBuscarHistorialSimCard(txtBuscar.Text.ToString(), HabilitarFechas, fechaInicio, fechaFinal, Condicion);

                //FunValidaciones.fnMostrarCantidadBusquedas(btnContadorRegistros, lblCantRegistros, datEquipo.Rows.Count, true, "Cantidad de registros");
                totalResultados = Convert.ToInt32(datEquipo.Rows.Count);
                if (datEquipo.Rows.Count > 0)
                {
                   
                    dgConsultas.Visible = true;
                    foreach (DataRow drMenu in datEquipo.Rows)
                    {
                        dgConsultas.Rows.Add(
                            Convert.ToString(drMenu["id"]),
                            Convert.ToString(drMenu["nombre"])
                                            );
                    }

                   
                }
                else
                {

                    dgConsultas.Visible =false;
                    dgConsultas.Rows.Clear();

                    fnMostrarDatosImei(gbSimCard, false, lblSmsMSimCard, "No se encontraron resultados para la busqueda", true);
                    fnMostrarDatosImei(gbMEquipo, false, lblSmsMEquipoGps, "No se encontraron resultados para la busqueda", true);
                    fnMostrarDatosImei(gbMCliente, false, lblSmsMCliente, "No se encontraron resultados para la busqueda", true);
                    fnMostrarDatosImei(gbMVehiculo, false, lblSmsMVehiculo, "No se encontraron resultados para la busqueda", true);
                    fnMostrarDatosImei(gbPlan, false, lblsmsPlan, "No se encontraron resultados para la busqueda", true);

                    //lblMsgHistorial.Text = "No se encontraron resultados para la busqueda";
                }


                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private DateTime fnCalcularSoloFecha(DateTime fecha)
        {
            String TextSoloFecha = fecha.ToString("yyyy/MM/dd");
            DateTime dtFecha = Convert.ToDateTime(TextSoloFecha);
            return dtFecha;
        }
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Int32 Condicion = 0;
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (rbSimCard.Checked == true) { Condicion = 0; }else
                if (rbImei.Checked==true) { Condicion = 1; }else
                if (rbCliente.Checked==true) { Condicion = 2; }else
                if (rbVehiculo.Checked==true) { Condicion = 3; }

                fnBuscarConsultas(Condicion);

            }
        }
        private void fnMostrarDatosImei(SiticoneGroupBox gb, Boolean estado, Label lbl, String sms, Boolean estLabel)
        {
            gb.Visible = estado;
            lbl.Visible = estLabel;
            lbl.Text = sms;
        }
        private Boolean fnListarDatosEspecificos(DataGridViewCellEventArgs e,Int32 tipoCon)
        {
            BLConsultas objSimCard = new BLConsultas();
            clsUtil objUtil = new clsUtil();
            DataTable datosActualesSimCard = new DataTable();
            try
            {
                datosActualesSimCard = objSimCard.blBuscarDatosEspecificos(Convert.ToInt32(dgConsultas.Rows[e.RowIndex].Cells[0].Value),tipoCon);

                if (datosActualesSimCard.Rows.Count > 0)
                {
                    fnMostrarDatosImei(gbSimCard, true, lblSmsMSimCard, "", false);
                    fnMostrarDatosImei(gbPlan, true, lblsmsPlan, "", false);

                    dgConsultas.Visible = false;
                    gbSimCard.Visible = true;

                    foreach (DataRow drMenu in datosActualesSimCard.Rows)
                    {

                        lblMSimCard.Text = Convert.ToString(drMenu["cSimCard"]) != "" ? Convert.ToString(drMenu["cSimCard"]) : "SIN SINCAR";
                        lblMOperador.Text = Convert.ToString(drMenu["operador"]) != "" ? Convert.ToString(drMenu["operador"]) : "-------------";
                        lblMCuenta.Text = Convert.ToString(drMenu["numeroRecibo"]) != "" ? Convert.ToString(drMenu["numeroRecibo"]) : "-----------";
                        lblMEstadoSimCard.Text = Convert.ToString(drMenu["cNomTab"]) != "" ? Convert.ToString(drMenu["cNomTab"]) : "----------";

                        if (Convert.ToString(drMenu["cDocCompra"]) == "" || Convert.ToString(drMenu["cDocCompra"]) == null)
                        {
                            fnMostrarDatosImei(gbMEquipo, false, lblSmsMEquipoGps, "Aun no hay datos para esta opcion", true);
                        }
                        else   
                        {
                            fnMostrarDatosImei(gbMEquipo, true, lblSmsMEquipoGps, "", false);

                            lblMOrdenIEquipo.Text = Convert.ToString(drMenu["cDocCompra"]) != "" ? Convert.ToString(drMenu["cDocCompra"]) : "----------";
                            lblMNombreEquipo.Text = Convert.ToString(drMenu["NombreEquipo"]) != "" ? Convert.ToString(drMenu["NombreEquipo"]) : "--------";
                            lblMMarcaEquipo.Text = Convert.ToString(drMenu["cNombreMarca"]) != "" ? Convert.ToString(drMenu["cNombreMarca"]) : "----------";
                            lblMModeloEquipo.Text = Convert.ToString(drMenu["cNombreModelo"]) != "" ? Convert.ToString(drMenu["cNombreModelo"]) : "--------";
                            lblMImeiEquipo.Text = Convert.ToString(drMenu["Imei"]) != "" ? Convert.ToString(drMenu["Imei"]) : "----------";
                            lblMSerieEquipo.Text = Convert.ToString(drMenu["nSerieEquipo"]) != "" ? Convert.ToString(drMenu["nSerieEquipo"]) : "----------";
                            txtPlataformaEquipo.Text = Convert.ToString(drMenu["nombrePlataforma"]) != "" ? Convert.ToString(drMenu["nombrePlataforma"]) : "----------";

                        }
                        lblMNombreCliente.Text = Convert.ToString(drMenu["nombreCliente"]) != "" ? Convert.ToString(drMenu["nombreCliente"]) : "----------";
                        lblMApellidoCliente.Text = Convert.ToString(drMenu["cApePat"])!=""? Convert.ToString(drMenu["cApePat"]) + " " + Convert.ToString(drMenu["cApeMat"]):"EMPRESA-SIN APELLIDO";
                        lblMDocumentoCliente.Text = Convert.ToString(drMenu["cDocumento"]) != "" ? Convert.ToString(drMenu["cDocumento"]) : "----------";
                        lblMTelefono.Text = Convert.ToString(drMenu["cTelCelular"]) != "" ? Convert.ToString(drMenu["cTelCelular"]) :"---------------" ;
                        lblMContacto.Text = Convert.ToString(drMenu["cContactoNom1"]) != "" ? Convert.ToString(drMenu["cContactoNom1"]) : "----------";
                        
                        lblMContactoTelefono.Text = Convert.ToString(drMenu["cContactoCel1"]) != "" ? Convert.ToString(drMenu["cContactoCel1"]) : "----------";

                        lblMClaseV.Text = Convert.ToString(drMenu["cNombreClaseV"]) != "" ? Convert.ToString(drMenu["cNombreClaseV"]) : "----------";
                        lblMMarcaV.Text = Convert.ToString(drMenu["NombreMarcaV"]) != "" ? Convert.ToString(drMenu["NombreMarcaV"]) : "----------";
                        lblMModeloV.Text = Convert.ToString(drMenu["NombreModeloV"]) != "" ? Convert.ToString(drMenu["NombreModeloV"]) : "----------";
                        lblMModoUso.Text = Convert.ToString(drMenu["cUsoV"]) != "" ? Convert.ToString(drMenu["cUsoV"]) : "----------";
                        lblMPlacaV.Text = Convert.ToString(drMenu["vPlaca"]) != "" ? Convert.ToString(drMenu["vPlaca"]) : "----------";
                        lblMSerieV.Text = Convert.ToString(drMenu["vSerie"]) != "" ? Convert.ToString(drMenu["vSerie"]) : "----------";
                        lblAñoV.Text = Convert.ToString(drMenu["vAnio"]) != "" ? Convert.ToString(drMenu["vAnio"]) : "----------";
                        lbllblMColorV.Text = Convert.ToString(drMenu["vColor"]) != "" ? Convert.ToString(drMenu["vColor"]) : "----------";

                        txtTipoTarifa.Text = Convert.ToString(drMenu["TipoTarifa"]) != "" ? Convert.ToString(drMenu["TipoTarifa"]) : "----------";
                        txtContrato.Text = Convert.ToString(drMenu["contrato"]) != "" ? Convert.ToString(drMenu["contrato"]) : "----------";
                        txtPlan.Text = Convert.ToString(drMenu["nombrePlan"]) != "" ? Convert.ToString(drMenu["nombrePlan"]) : "----------"; ;
                        txtCicloPago.Text = Convert.ToString(drMenu["cDia"]) != "" ? Convert.ToString(drMenu["cDia"]) : "--------------"; ;


                        if (lblMNombreCliente.Text == "" || lblMNombreCliente.Text == null)
                        {
                            fnMostrarDatosImei(gbMCliente, false, lblSmsMCliente, "Aun no hay datos para esta opcion", true);
                            fnMostrarDatosImei(gbMVehiculo, false, lblSmsMVehiculo, "Aun no hay datos para esta opcion", true);
                        }
                        else
                        {
                            fnMostrarDatosImei(gbMCliente, true, lblSmsMCliente, "", false);
                            fnMostrarDatosImei(gbMVehiculo, true, lblSmsMVehiculo, "", false);
                        }


                    }
                }
                else
                {
                    dgConsultas.Visible = false;
                    gbSimCard.Visible = false;
                    gbMEquipo.Visible = false;
                    fnMostrarDatosImei(gbSimCard, false, lblSmsMSimCard, "No se encontraron datos para esta busqueda", true);
                    //lblMsgHistorial.Text = "No se encontraron resultados para la busqueda";
                }


                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }
        private void dgConsultas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 Condicion=0 ;
                if (rbSimCard.Checked == true) { Condicion = 0; }
                else
                if (rbImei.Checked == true) { Condicion = 1; }
                else
                if (rbCliente.Checked == true) { Condicion = 2; }
                else
                if (rbVehiculo.Checked == true) { Condicion = 3; }
          
            fnListarDatosEspecificos(e,Condicion);
        }

        private void DotNetDatosSimCard_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkHabilitarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechas.Checked==true) 
            {
                dtHFechaInicio.Enabled = true;
                dtHfechaFinal.Enabled = true;
            }
            else
            {
                dtHFechaInicio.Enabled = false;
                dtHfechaFinal.Enabled = false;
            }
        }

        private void frmConsultarInformacion_Load(object sender, EventArgs e)
        {
            FunValidaciones.fnColorBotonEspecifico(btnNuevoHistorial);
        }

        private void btnNuevoHistorial_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            fnMostrarDatosImei(gbSimCard, false, lblSmsMSimCard, "Busque algun dato", true);
            fnMostrarDatosImei(gbMEquipo, false, lblSmsMEquipoGps, "Busque algun dato", true);
            fnMostrarDatosImei(gbMCliente, false, lblSmsMCliente, "Busque algun dato", true);
            fnMostrarDatosImei(gbMVehiculo, false, lblSmsMVehiculo, "Busque algun dato", true);

        }

        private void linkSimCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSimCard obSimCard = new frmSimCard();
            obSimCard.Inicio(0);
        }

        private void linkOperador_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Link actualmente no disponible");
        }

        private void linkCuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Link actualmente no disponible");
        }

        private void linkOrdenCompra_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmOrdenCompraEquipos objOrden = new frmOrdenCompraEquipos();
            objOrden.Inicio(0);
        }

        private void linkEquipoUnico_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegistrarEquipo objEquipoUnico = new frmRegistrarEquipo();
            objEquipoUnico.Inicio(0);
        }

        private void linkMarcaEquipo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegistrar_Cate_Marc_Mod obCatMaMod = new frmRegistrar_Cate_Marc_Mod();
            obCatMaMod.Inicio(0);
        }

        private void linkModeloEquipo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegistrar_Cate_Marc_Mod obCatMaMod = new frmRegistrar_Cate_Marc_Mod();
            obCatMaMod.Inicio(0);
        }

        private void linkImeiEquipo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEquipoImeis objEquipoImeis = new frmEquipoImeis();
            objEquipoImeis.Inicio(0);
        }

        private void linkCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegistrarCliente objCliente = new frmRegistrarCliente();
            objCliente.Inicio(0);
        }

        private void linkClaseV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Link actualmente no disponible");
        }

        private void linkMarcaV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegistrarMarcaVehiculo objMarcaV = new frmRegistrarMarcaVehiculo();
            objMarcaV.Inicio(0);
        }

        private void linkModeloV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegistrarModeloVehiculo objModeloV = new frmRegistrarModeloVehiculo();
            objModeloV.Inicio(0);
        }

        private void linkModoUsoV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Link actualmente no disponible");
        }

        private void linkPlacaV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegistrarVehiculo objVehiculo = new frmRegistrarVehiculo();
            objVehiculo.Inicio(0);
        }

        private void siticoneMaterialTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegistrarTipoPlan objTipoPlan = new frmRegistrarTipoPlan();
            objTipoPlan.Inicio(0);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            frmRegistrarPlan objPlan = new frmRegistrarPlan();
            objPlan.Inicio(0);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmRegistrarPlan objPlan = new frmRegistrarPlan();
            objPlan.Inicio(0);
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lblMPlacaV_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAñoV_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void DotNetDatosSimCard_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lblMClaseV_TextChanged(object sender, EventArgs e)
        {

        }

        private void DatosActuales_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblMSimCard_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbSimCard_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void siticoneGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgConsultas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
