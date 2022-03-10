using CapaEntidad;
using CapaNegocio;
using CapaUtil;
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
    public partial class frmReactivaciones : Form
    {
        static Int32 pnIdSimCard = 0;
        static Int32 SimCard = 0;
        static Int32 lnTipoValor = 0;

        public frmReactivaciones()
        {
            InitializeComponent();
        }
        static Int32 lnTipoCon = 0;

        static List<Equipo_imeis> lstEquipoAntiguo = new List<Equipo_imeis>();
        static List<Equipo_imeis> lstEquipoNuevo = new List<Equipo_imeis>();
        static List<SimCard> lstSimCardNuevo = new List<SimCard>();
        static List<SimCard> lstSimCardsAntiguo = new List<SimCard>();
        static List<Cliente> lstClientes = new List<Cliente>();
        static List<Vehiculo> lstVehiculo = new List<Vehiculo>();
        static List<Plan> lstPlan = new List<Plan>();

        static Int32 idVenta = 0 ;



        static Reactivaciones ClsReactivaciones;
        private object txtNuevoSimCard;
        
        String msjNuevoSimCard, msjEquipoNuevo, msjClienteE, msjVehiculoE, msjPlanE, msjEquipoE, msjClienteSc,msjVehiculoSc, msjPlanSc, msjEquipoSc, msjSimCardSc,msjObservacionesE, msjObservacionesSC;
        Boolean estSimCard, estEquipoNuevo, estClienteE, estVehiculoE, estPlanE, estEquipoE, estClienteSc, estVehiculoSc, estPlanSc, estEquipoSc, estSimCardSc,estObservacionesSC,estObservacionesE;
        private void frmReactivaciones_Load(object sender, EventArgs e)
        {
            dgConsultas.Visible = false;
            dtFechaReactivaciones.Value = Variables.gdFechaSis;
            dtFechaReactivacionesSC.Value = Variables.gdFechaSis;
            FunValidaciones.fnColorBtnGuardar(btnGuardarEquipo);
            FunValidaciones.fnColorBtnGuardar(btnGuardarSimCard);



            fnActivarCamposEquipo(true, "EQUIPO");
            fnActivarCamposEquipo(true, "SIMCARD");
            fnBorrarCampos("SIMCARD");
            fnBorrarCampos( "EQUIPO");
        }
        public void fnDatoEquipoNuevo(List<Equipo_imeis> lstEquipoImeis)
        {
            lstEquipoNuevo.Clear();
            lstEquipoNuevo = lstEquipoImeis;


            //DesEquipo = DescripcionE;
            //Eimail = Imail;
            //tipcon = tpcon;
        }
        public void fnDatoSimCardNuevo(List<Equipo_imeis> lstSimCard)
        {
            lstSimCardNuevo.Clear();
            lstSimCardNuevo = lstSimCardNuevo;

            //DesEquipo = DescripcionE;
            //Eimail = Imail;
            //tipcon = tpcon;
        }
        private void fnActivarCamposEquipo(Boolean estado, String condicion)
        {

            if (condicion == "EQUIPO")
            {
                txtEquipoNuevo.Visible = estado;
                lblENuevo.Visible = estado;
                txtEquipoNuevo.Text = "";
                txtEquipoNuevo.Visible = estado;
                pbEquipoNuevo.Visible = estado;
                lblEquipoNuevo.Visible = estado;
                siticoneSeparator11.Visible = estado;

                


            } else if (condicion == "SIMCARD")
            {
                txtSimCardNuevo.Visible = estado;
                lblSCardNuevo.Visible = estado;
                txtSimCardNuevo.Text ="";
                txtSimCardNuevo.Visible = estado;
                pbSimCardNuevo.Visible = estado;
                lblSimcardNuevo.Visible = estado;
                siticoneSeparator10.Visible = estado;

                

            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {
        }
        private void siticoneTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            lnTipoCon = 0;
            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarDatosReactivacion(lnTipoCon);
            }
        }

        private Boolean fnBuscarDatosReactivacion(Int32 condicion)
        
          {
            BLReactivaciones datReactivacion = new BLReactivaciones();
            clsUtil objUtil = new clsUtil();
            DataTable datResultado = new DataTable();
            try
            {
                string BuscarDato = Convert.ToString(txtBusca.Text);
                datResultado = datReactivacion.BlBuscarReactivacion(condicion, BuscarDato);
                dgConsultas.Visible = true;
                dgConsultas.Rows.Clear();


                //tipoCon = Convert.ToInt32(datResultado.Rows.Count);

                foreach (DataRow drMenu in datResultado.Rows)
                {
                    dgConsultas.Rows.Add(
                        Convert.ToString(drMenu["idContrato"]),                        
                        Convert.ToString(drMenu["vPlaca"]),
                        Convert.ToString(drMenu["imei"]),
                        Convert.ToString(drMenu["cSimCard"])


                                        );

                }


                return true;
            } catch (Exception Error)

            {
                return false;
            }
            finally
            {

            }

        }
        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtCliente, lblClienteE, pbCliente, true, true, true, 3, 50, 50, 50, "Complete el Nombre del cliente");
            estClienteE = resultado.Item1;
            msjClienteE = resultado.Item2;
        }
        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
        }
        private void dgConsultas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgConsultas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lnTipoCon = 1;

            fnListarReacctivacionesEspecificos(lnTipoCon, e);

            fnActivarCamposEquipo(true, "EQUIPO");
            fnActivarCamposEquipo(true, "SIMCARD");


        }

        private void fnListarReacctivacionesEspecificos(int condicion, DataGridViewCellEventArgs e)
        {

            
            clsUtil objUtil = new clsUtil();
            DataTable datosreactivacioSimCard = new DataTable();
            BLReactivaciones datReactivacion = new BLReactivaciones();
            DataTable datResultado = new DataTable();
            try
            {

                datResultado = datReactivacion.blBuscarReactivacionEspecifico(condicion, Convert.ToInt32(dgConsultas.Rows[e.RowIndex].Cells[0].Value));
                if (datResultado.Rows.Count > 0)
                {
                    
                    lstClientes.Clear();
                    lstVehiculo.Clear();
                    lstPlan.Clear();
                    lstEquipoNuevo.Clear();
                    lstEquipoAntiguo.Clear();
                    lstSimCardNuevo.Clear();
                    lstSimCardsAntiguo.Clear();
                  


                    dgConsultas.Visible = false;
                    foreach (DataRow drMenu in datResultado.Rows)
                    {
                        txtCliente.Text = Convert.ToString(drMenu["NombreCliente"]);
                        lstClientes.Add(new Cliente
                        {
                            idCliente = Convert.ToInt32(drMenu["idCliente"]),
                            cTipoDoc = Convert.ToString(drMenu["NombreCliente"]),
                            cApePat = Convert.ToString(drMenu["cApePat"]),
                            cApeMat = Convert.ToString(drMenu["cApeMat"])

                        });
                        txtCliente.Text = lstClientes[0].cTipoDoc + " " + lstClientes[0].cApePat+ " " +lstClientes[0].cApeMat;


                        txtVehiculo.Text = Convert.ToString(drMenu["vPlaca"]);
                        lstVehiculo.Add(new Vehiculo
                        {
                            idVehiculo = Convert.ToInt32(drMenu["idVehiculo"]),
                            vPlaca = Convert.ToString(drMenu["vPlaca"])
                        });
                        txtVehiculo.Text = lstVehiculo[0].vPlaca;
                        

                        txtPlan.Text = Convert.ToString(drMenu["cNombre"]);


                        lstPlan.Add(new Plan
                        {
                            idPlan = Convert.ToInt32(drMenu["idPlan"]),
                            nombrePlan = Convert.ToString(drMenu["nombreplan"]),
                            tiposPlan = Convert.ToString(drMenu["cNombre"])

                        });
                        txtPlan.Text = lstPlan[0].nombrePlan+"-" +lstPlan[0].tiposPlan;
                        idVenta = Convert.ToInt32(drMenu["idVentaGeneral"]);



                        lstEquipoAntiguo.Add(new Equipo_imeis
                        {
                            idEquipoImeis = Convert.ToInt32(drMenu["idEquipoImeis"]),
                            imei = Convert.ToString(drMenu["Imei"])

                        });

                        txtEquipo.Text = lstEquipoAntiguo[0].imei;

                        lstEquipoNuevo.Add(new Equipo_imeis
                        {
                            idEquipoImeis = 0,
                            imei = "0"
                        });

                        //txtclienteSimCard.Text = Convert.ToString(drMenu["NombreCliente"]);                     
                        txtclienteSimCard.Text = lstClientes[0].cTipoDoc + " " + lstClientes[0].cApePat + " " + lstClientes[0].cApeMat;
                        txtVehiculoSimCard.Text = Convert.ToString(drMenu["vPlaca"]) != "" ? Convert.ToString(drMenu["vPlaca"]) : "SIN Placa";
                        
                        //txtVehiculoSimCard.Text = lstVehiculo[0].vPlaca;

                        //txtPlanSimCard.Text = Convert.ToString(drMenu["nombreplan"]);
                        
                        txtPlanSimCard.Text = lstPlan[0].nombrePlan + "-" + lstPlan[0].tiposPlan;

                        //txtEquipoSimCard.Text = Convert.ToString(drMenu["Imei"]);                      
                        txtEquipoSimCard.Text = lstEquipoAntiguo[0].imei;

                        txtSimcard.Text = Convert.ToString(drMenu["cSimCard"]) != "" ? Convert.ToString(drMenu["cSimCard"]) : "SIN SIMCARD";
                        lstSimCardsAntiguo.Add(new SimCard
                        {
                            idChip = Convert.ToInt32(drMenu["idchip"]),
                            StrsimCard = Convert.ToString(drMenu["cSimCard"])
                        });

                        lstSimCardNuevo.Add(new SimCard
                        {
                            idChip = 0,
                            StrsimCard = "0"
                        });
                        txtSimcard.Text = lstSimCardsAntiguo[0].StrsimCard;

                    }

                }
            }
            catch (Exception exp)
            {
            }
        }
        private void Equuipo_Click(object sender, EventArgs e)
        {
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
        }
        private void BtnOrdenCompra_Click(object sender, EventArgs e)
        {
            frmEquipoImeis frmEquipoImei = new frmEquipoImeis();
            frmEquipoImei.Inicio(3);

            fnActivarCamposEquipo(true, "EQUIPO");
            txtEquipoNuevo.Text = Convert.ToString(lstEquipoNuevo[0].imei);



            //gbObservacionesInst.Enabled = true;
            //pbValObservacion.Visible = true;
            //lbltxtObservacionIns.Visible = true;
            //estObservacion = true;
            //cboSeleccionarUbicacionE.Enabled = true;
            //btnGuardarIns.Enabled = true;
            //gbUbicacion.Enabled = true;
            //txtNomMarModEquipo_TextChanged(sender, e);
            //gbUbicacion.Enabled = true;
        }

        private void lblPlanE_Click(object sender, EventArgs e)
        {

        }

        private void siticoneSeparator3_Click(object sender, EventArgs e)
        {

        }

        private void txtSimcard_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtSimcard, lblSimCardSc, pbSimCardSc, true, true, true, 9, 15, 15, 15, "Complete el número del SimCar");
            estSimCardSc = resultado.Item1;
            msjSimCardSc = resultado.Item2;
        }

        private void siticoneDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //gdFechasSis. Variables,

           


            //Console.WriteLine(dateTime.ToString( class="hljs-string">"d"));
            //txtEquipoNuevo.Text = Convert.ToString(;[0].imei);


        }

        private void pbSimCardNuevo_Click(object sender, EventArgs e)
        {

        }

        private void pbObsevacionesSC_Click(object sender, EventArgs e)
        {

        }
        private void fnBorrarCampos( String condicion)
        {
            if (condicion=="EQUIPO")
            {
                txtCliente.Text = "";
                txtEquipo.Text = "";
                txtEquipoNuevo.Text = "";
                txtObservacionesE.Text = "";
                txtPlan.Text = "";
                txtVehiculo.Text = "";
                lstClientes.Clear();
                lstEquipoAntiguo.Clear();
                lstEquipoNuevo.Clear();
                lstPlan.Clear();
                lstVehiculo.Clear();
               
            }else if (condicion == "SIMCARD")
            {
                txtVehiculoSimCard.Text = "";
                txtSimCardNuevo.Text = "";
                txtEquipoSimCard.Text = "";
                txtclienteSimCard.Text = "";
                txtObservacionesSC.Text = "";
                txtPlanSimCard.Text = "";
                txtSimcard.Text = "";
                lstClientes.Clear();
                lstEquipoAntiguo.Clear();
                lstEquipoNuevo.Clear();
                lstPlan.Clear();
                lstVehiculo.Clear();
                lstSimCardsAntiguo.Clear();
                lstSimCardNuevo.Clear();

            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            
                fnBorrarCampos("EQUIPO");
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fnBorrarCampos("SIMCARD");

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            fnBuscarDatosReactivacion(lnTipoCon);
        }

        private void dtFechaReactivaciones_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tbcDatos_KeyPress(object sender, KeyPressEventArgs e)
        {

        }   
        private void txtObservacionesE_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtObservacionesE, lblObservacionesE, pbObservacionesE, true, true, true, 5, 200, 200, 200, "Especifica las observaciones");
            estObservacionesE = resultado.Item1;
            msjObservacionesE = resultado.Item2;

        }

        private void txtObservacionesSC_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtObservacionesSC, lblOBservacionesSCard, pbObsevacionesSC, true, true, true, 5, 200, 200, 200, "Especifica las observaciones");
            estObservacionesSC = resultado.Item1;
            msjObservacionesSC = resultado.Item2;
        }

        private void lblObservacionesSC_Click(object sender, EventArgs e)
        {

        }

        private void txtEquipoSimCard_TextChanged(object sender, EventArgs e)

        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtEquipoSimCard, lblEquipoSc, pbEquipoSc, true, true, true, 9, 15, 15, 15, "Complete el número  del Equipo");
            estEquipoSc = resultado.Item1;
            msjEquipoE = resultado.Item2;
            
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

            frmSimCard frmbuscarSimCard = new frmSimCard();

            frmbuscarSimCard.Inicio(2);

            fnActivarCamposEquipo(true,"SIMCARD");

            txtSimCardNuevo.Text = Convert.ToString(lstSimCardNuevo[0].simCard);

        }

        private void txtPlanSimCard_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtPlanSimCard, lblPlanSc, pbPlanSc, true, true, true, 5, 25, 25, 25, "Complete el tipo de plan");
            estPlanSc = resultado.Item1;
            msjPlanSc = resultado.Item2;
         
        }

        private void txtSimCardNuevo_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtSimCardNuevo, lblSimcardNuevo, pbSimCardNuevo, true, true, true, 9, 9, 9, 9, "Complete el número del nuevo SimCar");
            estSimCard = resultado.Item1;
            msjNuevoSimCard = resultado.Item2;
            
        }

        private void txtVehiculoSimCard_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtVehiculoSimCard, lblVehiculoSc, pbVehiculoSc, true, true, true, 5, 7, 7, 7, "Complete el número del Equipo");
            estVehiculoSc = resultado.Item1;
            msjVehiculoSc = resultado.Item2;
            
        }

        private void btnGuardarSimCard_Click(object sender, EventArgs e)
        {
            Boolean Guardar;
                String lcResultado = "";
                txtSimCardNuevo_TextChanged(sender, e);
            Reactivaciones clsRenova = new Reactivaciones();
            if (estSimCard==true&& estClienteSc==true&& estVehiculoSc==true&&estPlanSc==true&& estEquipoSc==true&& estSimCardSc==true)
              
            {
                clsRenova = CargarClaseReactivaciones();
               Guardar = fnGuardarRenovacion(clsRenova, "SIMCARD");
                if (Guardar==true)
                {
                    MessageBox.Show("Se guardo corectamente la Reactivacion del NUEVO SINCARD!!!!", "PERFECTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fnBorrarCampos("EQUIPO");
                    fnBorrarCampos("SIMCARD");
                }
                else
                {
                    MessageBox.Show("¡¡¡¡Su Reactivacion del Nuevo SINCARD no se puede guardar", "¡¡¡ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
            else
            {
                MessageBox.Show("Aun faltan algunos datos", "¡¡¡¡¡¡ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
            }
        }

        private void txtclienteSimCard_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtclienteSimCard, lblClienteSc, pbClienteSc, true, true, true, 3, 50, 50, 50, "Complete el nombre del cliente");
            estClienteSc = resultado.Item1;
            msjClienteSc = resultado.Item2;
            
        }

        public static void fnRecuperarSimCard(Int32 idSimCard, Int32 pcSimcard, int pnTipoValor = 0)
        {
                lstSimCardNuevo.Clear();

                lstSimCardNuevo.Add(new SimCard
                {
                    idChip = idSimCard,
                    simCard = pcSimcard

                });
        }

        private void txtEquipo_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtEquipo, lblEquipoE, pbEquipo, true, true, true, 9, 15, 15, 15, "Complete el número  del Equipo");
            estEquipoE = resultado.Item1;
            msjEquipoE = resultado.Item2;
        }

        private void siticoneSeparator6_Click(object sender, EventArgs e)
        {
        }
        private void txtPlan_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtPlan, lblPlanE, pbPlan, true, true, true, 5, 25, 25, 25, "Complete el tipo de Plan");
            estPlanE = resultado.Item1;
            msjPlanE = resultado.Item2;
        }
        private void lblEquipoNuevo_Click(object sender, EventArgs e)
        {            
        }
        private void txtVehiculo_TextChanged(object sender, EventArgs e)
        {
           var resultado = FunValidaciones.fnValidarTexboxs(txtVehiculo, lblVehiculoE, pbVehiculo, true, true, true, 5,7,7,7, "Complete la placa del Vehiculo");
            estVehiculoE = resultado.Item1;
            msjVehiculoE = resultado.Item2;
        }
        private void pbEquipoNuevo_Click(object sender, EventArgs e)
        {
        }
        private void gunaCirclePictureBox8_Click(object sender, EventArgs e)
        {

        }
        private Reactivaciones CargarClaseReactivaciones()
        {
           
            lstSimCardsAntiguo = lstSimCardsAntiguo.Count == 0 ? lstSimCardNuevo : lstSimCardsAntiguo;

            ClsReactivaciones = new Reactivaciones
            {
                listaEquipoNuevo = lstEquipoNuevo,
                listaEquipoAntiguo = lstEquipoAntiguo,
                listaSimCardNuevo = lstSimCardNuevo,
                listaSimCardAntiguo= lstSimCardsAntiguo,

                listaCliente = lstClientes,
                listaVehiculo = lstVehiculo,
                listaPlan = lstPlan,
                
                FechaReactivacionesE = Convert.ToDateTime(dtFechaReactivaciones.Value),
                FechaRegistroSC = Variables.gdFechaSis,
                FechaReactivacionesSC = Convert.ToDateTime(dtFechaReactivacionesSC.Value),

                ObservacionesE = Convert.ToString(txtObservacionesE.Text),
                ObservacionesSC=Convert.ToString(txtObservacionesSC.Text),
                idVentaGeneral = idVenta,
            };
            return ClsReactivaciones;
        }

        private Boolean fnGuardarRenovacion(Reactivaciones clsReac ,String Condicion)
        {
            clsUtil objUtil = new clsUtil();
            DataTable datosreactivacioSimCard = new DataTable();
            BLReactivaciones datReactivacion = new BLReactivaciones();
            Int32 datResultado = 0;
            try
            {
                datResultado = datReactivacion.blGuardarReactivaciones(clsReac, Condicion);

                return true;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        private void btnGuardarEquipo_Click(object sender, EventArgs e)
        {
              Boolean Guardar;
                String lcResultado = "";
                txtEquipoNuevo_TextChanged(sender, e);
            Reactivaciones clsRenova = new Reactivaciones();
            if (estClienteE == true  && estEquipoNuevo == true && estVehiculoE == true && estPlanE == true && estEquipoE == true )
            {
                clsRenova= CargarClaseReactivaciones();
                Guardar = fnGuardarRenovacion(clsRenova,"EQUIPO");
                if (Guardar == true)
                {
                    MessageBox.Show("Se guardo corectamente la Reactivacion del NUEVO EQUIPO!!!!", "PERFECTO!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fnBorrarCampos("EQUIPO");
                    fnBorrarCampos("SIMCARD");
                }
                else
                {
                    MessageBox.Show("¡¡¡Su Reactivacion del NUEVO EQUIPO no se puede guardar", "¡¡¡¡ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Aun faltan algunos datos!!!!!","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }

        private void txtEquipoNuevo_TextChanged(object sender, EventArgs e)
        {
                var resultado = FunValidaciones.fnValidarTexboxs(txtEquipoNuevo, lblEquipoNuevo, pbEquipoNuevo, true, true, true, 9, 15,15,15, "Complete el número del nuevo de Equipo");;
                estEquipoNuevo = resultado.Item1;
                msjEquipoNuevo = resultado.Item2;
        }
    }
} 

