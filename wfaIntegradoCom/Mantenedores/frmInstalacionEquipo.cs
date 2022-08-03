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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Consultas;
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmInstalacionEquipo : Form
    {
        public frmInstalacionEquipo()
        {
            InitializeComponent();
        }
        Boolean estCliente, estEquipo, estObservacion, estUbicacion;
        String msjCliente, msjEquipo, msjObservacion, msjUbicacion;

        static List<Cliente> lstCliente = new List<Cliente>();
        static List<Vehiculo> lstVehiculo = new List<Vehiculo>();
        static List<Equipo_imeis> lstEquipo = new List<Equipo_imeis>();
        static List<Equipo_imeis> lstEquipoActual = new List<Equipo_imeis>();
        static List<Plan> lstPlan = new List<Plan>();
        static Instalacion instalacion = new Instalacion();
        static List<AccesoriosEquipo> lstAccesorios = new List<AccesoriosEquipo>();
        static List<ServicioEquipo> lstServicios = new List<ServicioEquipo>();

        static List<UbicacionEquipoInstalacion> lstUbicacionEquipo = new List<UbicacionEquipoInstalacion>();
        static Boolean EstadoInstalacion = false;
        static Int32 tabInicio;
        static Int32 lnTipoCondicion = 0;

        private void btnBuscarVentas_Click(object sender, EventArgs e)
        {
            frmRegistrarVenta frmVentaGeneral = new frmRegistrarVenta();
            frmVentaGeneral.Inicio(3);
        }

        private void frmInstalacionEquipo_Load(object sender, EventArgs e)
        {

            FunGeneral.fnLlenarTablaCodTipoCon(cboEstadosInst, "ESVG", true);
            FunGeneral.fnLlenarUsuarioPorCargo(cboUsuario, "PETR0008", true);



            dtpFechaFinalBusIns.Value = Variables.gdFechaSis;
            dtpFechaInicialIns.Value = Variables.gdFechaSis.AddDays(-30);
            dtpFechaFinalBusIns.Value = Variables.gdFechaSis;
            dtpFechaInicialIns.Value = dtpFechaFinalBusIns.Value.AddDays(-(dtpFechaFinalBusIns.Value.Day - 1));

            gbDatosPersona.Enabled = false;
            gbDatosVehiculo.Enabled = false;
            txtNomMarModEquipo.Enabled = false;
            //txtEmailEquipo.Enabled = false;

            gbObservacionesInst.Enabled = false;
            btnGuardarIns.Enabled = false;
            btnBuscarEquipos.Enabled = false;
            //fnBuscarListaVentas(dgvListaInstalaciones, "ESVG0001", btnTRegistros, 0, 1, -3);
            pbValObservacion.Visible = false;

            String lnIdPlan = "";
            dgvAccesorios.Visible = false;
            dgvServicios.Visible = false;
            fnAccesorios(lnIdPlan);
            fnServisios(lnIdPlan);



            //pbSubir.Visible = false;
            //pbBajar.Visible = false;



            //gbUbicacion.Enabled = true;
            //gbUbicacion.Visible = true;

            //txtOtraUbicacion.Visible = true;
            //txtOtraUbicacion.Enabled = true;

            //txtObserInst.Visible = true;

            //txtObserInst.Enabled= false;
            fnActivarCamposActualizacion(false);

            fnLlenarCboUbicacionIns(0);
            dtpFechaRegistro.Value = Variables.gdFechaSis;

            FunValidaciones.fnHabilitarBoton(btnGuardarIns, false);

          
            fnActivarCamposInst(0, true);
            dtpFechaRegistro.Enabled = true;

        }

        private void txtBuscarIns_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarListaVentas(dgvListaInstalaciones, Convert.ToString(cboEstadosInst.SelectedValue), btnTotalRegistrosIns, 0, 1, -1);



            }

        }

        private Boolean fnBuscarListaVentas(DataGridView dgv, String ValueCBO, SiticoneCircleButton btnTotReg, Int32 numPagina, Int32 tipoLLamada, Int32 tipoCon)
        {
            BLInstalacion objVentaGeneral = new BLInstalacion();
            clsUtil objUtil = new clsUtil();
            DataTable datVentaG = new DataTable();
            String datoBuscar = txtBuscarIns.Text.Trim();
            String datoEstado = ValueCBO;
            Boolean habilitarFechas = chkHabilitarFechasI.Checked ? true : false;
            String fechaInicial = FunGeneral.GetFechaHoraFormato(dtpFechaInicialIns.Value,5);
            String fechaFinal = FunGeneral.GetFechaHoraFormato(dtpFechaFinalBusIns.Value,5);
            Int32 filas = 10;
            String estadoTipoContrato = "0";
            Int32 idUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
            //3 fecha de registro 2 cod venta 4 descripcion vehiculo 5 cliente 6 estado

            try
            {
                datVentaG = objVentaGeneral.blBuscarInstalaciones(habilitarFechas, fechaInicial, fechaFinal, datoBuscar, datoEstado, numPagina, tipoCon, 1, idUsuario);

                Int32 totalResultados = datVentaG.Rows.Count;
                if (totalResultados > 0)
                 {
                    if (dgv.Rows.Count > 0)

                    {
                        dgv.Rows.Clear();

                    }

                    Int32 y;

                    if (tipoCon == -1)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (numPagina - 1) * filas;
                        y = tabInicio;
                    }

                    for (int i = 0; i <= totalResultados - 1; i++)
                    {
                        y += 1;
                        string desVehiculos = Convert.ToString(datVentaG.Rows[i][4]);
                        DateTime fecha = Convert.ToDateTime(datVentaG.Rows[i][3]);
                        dgv.Rows.Add(
                            datVentaG.Rows[i][2],
                            y,
                            fecha.ToString("dd/MM/yyyy"),
                            datVentaG.Rows[i][5],
                            datVentaG.Rows[i][9],
                            desVehiculos,
                            datVentaG.Rows[i][6],
                            datVentaG.Rows[i][7],
                            datVentaG.Rows[i][11],
                            datVentaG.Rows[i][12]
                            //datVentaG.Rows[i][12]


                        );//3 fechade registro 2 cod venta 4 descripcion vehiculo 5 cliente 6 estado

                    }

                    //3 fechade registro 2 cod venta 4 descripcion vehiculo 5 cliente 6 estado
                    dgv.Columns[0].Width = 10;
                    dgv.Columns[1].Width = 10;
                    dgv.Columns[2].Width = 25;
                    dgv.Columns[3].Width = 80;
                    dgv.Columns[4].Width = 100;
                    dgv.Columns[5].Width = 80;
                    dgv.Columns[6].Width = 40;
                    dgv.Columns[7].Width = 40;
                    dgv.Columns[8].Width = 40;

                    //dgv.RowTemplate.Height = 70;
                    dgv.Visible = true;

                    if (tipoCon == -1 || tipoCon == -3)
                    {
                        gbPaginacionInst.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datVentaG.Rows[0][0]);
                        FunValidaciones.fnCalcularPaginacion(
                            totalRegistros,
                            filas,
                            totalResultados,
                            cboPagIns,
                            btnTotalPaginaIns,
                            btnNumFila,
                            btnTotReg

                        );
                    }
                    else
                    {
                        btnNumFila.Text = Convert.ToString(totalResultados);
                    }

                    return true;
                }
                else
                {

                    //MessageBox.Show("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgv.Rows.Clear();
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }
  
        private void dgvListaInstalaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmPrevisualizar frmPrev = new FrmPrevisualizar();
            String dato = "";
            if (e.ColumnIndex == dgvListaInstalaciones.Columns["Cliente"].Index && e.RowIndex >= 0)
            {
                dato = Convert.ToString(dgvListaInstalaciones.Rows[e.RowIndex].Cells[3].Value);
                frmPrev.inicio(1, dato);
            }
            if (e.ColumnIndex == dgvListaInstalaciones.Columns["Direccion"].Index && e.RowIndex >= 0)
            {
                dato = Convert.ToString(dgvListaInstalaciones.Rows[e.RowIndex].Cells[4].Value);
                frmPrev.inicio(1, dato);
            }
            if (e.ColumnIndex == dgvListaInstalaciones.Columns["Vehiculo"].Index && e.RowIndex >= 0)
            {
                dato = Convert.ToString(dgvListaInstalaciones.Rows[e.RowIndex].Cells[5].Value);
                frmPrev.inicio(1, dato);
            }
            if (e.ColumnIndex == dgvListaInstalaciones.Columns["Estado"].Index && e.RowIndex >= 0)
            {
                dato = Convert.ToString(dgvListaInstalaciones.Rows[e.RowIndex].Cells[6].Value);
                frmPrev.inicio(1, dato);
            }
            if (e.ColumnIndex == dgvListaInstalaciones.Columns["UbicacionEquipo"].Index && e.RowIndex >= 0)
            {
                dato = Convert.ToString(dgvListaInstalaciones.Rows[e.RowIndex].Cells[12].Value);
                frmPrev.inicio(1, dato);
            }
        }

        private void cboEstadosInst_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fnBuscarListaVentas(dgvListaInstalaciones, Convert.ToString(cboEstadosInst.SelectedValue), btnTotalRegistrosIns, 0, 1, -1);
            
            if (Convert.ToString(cboEstadosInst.SelectedValue) == "ESVG0001")
            {
                cmsMenuSeleccion.Items[0].Visible = true;
                cmsMenuSeleccion.Items[1].Visible = false;
                cmsMenuSeleccion.Items[2].Visible = false;
               

            }
            else if (Convert.ToString(cboEstadosInst.SelectedValue) == "ESVG0002")
            {
                cmsMenuSeleccion.Items[0].Visible = false;
                cmsMenuSeleccion.Items[1].Visible = true;
                cmsMenuSeleccion.Items[2].Visible = true;

            }
            
            else
            {
                cmsMenuSeleccion.Items[0].Visible = false;
                cmsMenuSeleccion.Items[1].Visible = false;
                cmsMenuSeleccion.Items[2].Visible = false;
            }
        }

        private void chkHabilitarFechasI_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechasI.Checked == true)
            {
                siticoneGroupBox2.Enabled = true;
            }
            else
            {
                siticoneGroupBox2.Enabled = false;
            }

            //fnBuscarListaVentas(dgvListaInstalaciones, Convert.ToString(cboEstadosInst.SelectedValue), btnTotalRegistrosIns, 0, 1, -1);

        }



        private void dtpFechaFinalBusIns_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaInicialIns.Value = dtpFechaFinalBusIns.Value.AddDays(-(dtpFechaFinalBusIns.Value.Day - 1));
            //fnBuscarListaVentas(dgvListaInstalaciones, Convert.ToString(cboEstadosInst.SelectedValue), btnTotalRegistrosIns, 0, 1, -1);
        }

        private void dtpFechaInicialIns_ValueChanged(object sender, EventArgs e)
        {
            //fnBuscarListaVentas(dgvListaInstalaciones, Convert.ToString(cboEstadosInst.SelectedValue), btnTotalRegistrosIns, 0, 1, -1);
        }

        private void cboPagIns_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 Num = Convert.ToInt32(cboPagIns.Text);
            fnBuscarListaVentas(dgvListaInstalaciones, Convert.ToString(cboEstadosInst.SelectedValue), btnTotalRegistrosIns, Num, 1, -2);

        }

        private void dgvAccesorios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // if(e.ColumnIndex==dgvAccesorios.Columns["Seleccionar"])

            //VALIDACION DEL DGV ACCESORIO Y SERVICIOS- ACTIVO EN ACCESORIO -ACTIVA AUTOMATICAMENTE EL CHECK DE SERVICIOS Y VICEBERSA

            Int32 dato = Convert.ToInt32(dgvAccesorios.Rows[3].Cells[2].Value);
            fnActivarChecks(e.RowIndex, dgvAccesorios);
            //if (e.ColumnIndex == dgvAccesorios.Columns["Chk"].Index)
            //{
            //    if (e.RowIndex==3 && Convert.ToBoolean(dgvServicios.Rows[3].Cells[2].Value) == true)
            //    {
            //        dgvServicios.Rows[3].Cells[2].Value = false;
            //    }
            //    else if(e.RowIndex == 3 && Convert.ToBoolean(dgvServicios.Rows[3].Cells[2].Value) == false)
            //    {
            //        dgvServicios.Rows[3].Cells[2].Value = true;
            //    }

            //    if (e.RowIndex == 1 && Convert.ToBoolean(dgvServicios.Rows[1].Cells[2].Value) == true)
            //    {
            //        dgvServicios.Rows[1].Cells[2].Value = false;
            //    }
            //    else if (e.RowIndex == 1 && Convert.ToBoolean(dgvServicios.Rows[1].Cells[2].Value) == false)
            //    {
            //        dgvServicios.Rows[1].Cells[2].Value = true;
            //    }

            //    if (e.RowIndex == 1 && Convert.ToBoolean(dgvServicios.Rows[1].Cells[2].Value) == true)
            //    {
            //        dgvServicios.Rows[1].Cells[2].Value = false;
            //    }
            //    else if (e.RowIndex == 1 && Convert.ToBoolean(dgvServicios.Rows[1].Cells[2].Value) == false)
            //    {
            //        dgvServicios.Rows[1].Cells[2].Value = true;
            //    }

            //    //if (Convert.ToBoolean(dgvAccesorios.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
            //    //{
            //    //    dgvServicios.Rows[3].Cells[2].Value = true;

            //    //}
            //    //else
            //    //{
            //    //    dgvServicios.Rows[3].Cells[2].Value = true;
            //    //}


            //    //dato = Convert.ToString(dgvServicios.Rows[e.RowIndex].Cells[3].Value);
            //    //dgvServicios.Rows[0].Cells[2].Value = true

            //}



            //if(e.ColumnIndex == dgvAccesorios.Columns["Cliente"]e.RowIndex >= 0)
        }

        private void fnActivarChecks(Int32 index, SiticoneDataGridView dgvAcciones)
        {
            if (dgvAcciones.Columns["Chk"].Index == 2)
            {
                if (index < 4)
                {
                    if (dgvAcciones.Name == "dgvAccesorios")
                    {
                        if (Convert.ToBoolean(dgvServicios.Rows[index].Cells[2].Value) == true)
                        {
                            dgvServicios.Rows[index].Cells[2].Value = false;
                        }
                        else if (Convert.ToBoolean(dgvServicios.Rows[index].Cells[2].Value) == false)
                        {
                            dgvServicios.Rows[index].Cells[2].Value = true;
                        }


                    }
                    else if (dgvAcciones.Name == "dgvServicios")
                    {
                        if (Convert.ToBoolean(dgvAccesorios.Rows[index].Cells[2].Value) == true)
                        {
                            dgvAccesorios.Rows[index].Cells[2].Value = false;
                        }
                        else if (Convert.ToBoolean(dgvAccesorios.Rows[index].Cells[2].Value) == false)
                        {
                            dgvAccesorios.Rows[index].Cells[2].Value = true;

                        }

                    }

                }

            }

        }

        private void fnBusquedaAccesorios(DataTable datAcce)
        {
            DataTable dtEmp = new DataTable();
            dtEmp.Columns.Add("ID", typeof(int));
            dtEmp.Columns.Add("Accesorios", typeof(string));

            DataGridViewCheckBoxColumn dgvAccE = new DataGridViewCheckBoxColumn();
            dgvAccE.ValueType = typeof(bool);
            dgvAccE.Name = "Chk";
            dgvAccE.HeaderText = "Seleccionar";

            //dgvAccesorios.Columns.Add(dgvAccE);




            for (int i = 0; i <= datAcce.Rows.Count - 1; i++)
            {

                dtEmp.Rows.Add(
                    datAcce.Rows[i][0],
                    datAcce.Rows[i][1]

                );
            }

            dgvAccesorios.DataSource = dtEmp;

            dgvAccesorios.Columns.Add(dgvAccE);

            dgvAccesorios.Columns[1].Width = 130;

            dgvAccesorios.Rows[0].Cells[2].Value = true;

            dgvAccesorios.Columns[0].Visible = false;

            //for (int i = 0; i < dgvAccesorios.RowCount; i++)
            //{
            //    dgvAccesorios.Columns["Chk"].cursor = Cursors.Hand;
            //}

            //dgvAccesorios.Columns["Chk"].Index.cursor = Cursors.Hand;
            //dgvAccesorios.Cursor = Cursors.Hand;

        }

        private void fnBusquedaServicios(DataTable datServ)
        {
            DataTable dtEmp = new DataTable();
            dtEmp.Columns.Add("ID", typeof(int));
            dtEmp.Columns.Add("Servicios", typeof(string));

            DataGridViewCheckBoxColumn dgvAccE = new DataGridViewCheckBoxColumn();
            dgvAccE.ValueType = typeof(bool);
            dgvAccE.Name = "Chk";
            dgvAccE.HeaderText = "Seleccionar";

            //dgvAccesorios .Columns.Add(dgvAccE);




            for (int i = 0; i <= datServ.Rows.Count - 1; i++)
            {

                dtEmp.Rows.Add(
                    datServ.Rows[i][0],
                    datServ.Rows[i][1]

                );
            }


            dgvServicios.DataSource = dtEmp;

            dgvServicios.Columns.Add(dgvAccE);

            dgvServicios.Columns[1].Width = 130;

            dgvServicios.Rows[0].Cells[2].Value = true;
            //dgvServicios.Rows[1].Cells[2].Value = true;
            dgvServicios.Rows[5].Cells[2].Value = true;
            dgvServicios.Rows[6].Cells[2].Value = true;


            dgvServicios.Columns[0].Visible = false;



        }



        public Boolean fnAccesorios(String lnIdPlan)
        {
            BLInstalacion objEquipo = new BLInstalacion();
            clsUtil objUtil = new clsUtil();
            DataTable datAcce = new DataTable();

            DataTable dtRespAccesorios = new DataTable();
            try
            {

                //lstEquipo = objEquipo.blBuscarEquipo(pcBuscar, pnTipoCon);
                dgvAccesorios.Columns.Clear();
                datAcce = objEquipo.blAccesoriosPlan(lnIdPlan);


                foreach (DataRow dr in datAcce.Rows)
                {

                    lstAccesorios.Add(new AccesoriosEquipo
                    {
                        idAccesorios = Convert.ToInt32(dr["idAccesorioGps"]),
                        NombreAccesorio = Convert.ToString(dr["accesorio"]),
                    });

                }

                fnBusquedaAccesorios(datAcce);
                dtRespAccesorios = objEquipo.blAccesoriosPlan(instalacion.codigoInstalacion);
                fnActivarChecksTablas(lstAccesorios, lstServicios, dtRespAccesorios, dgvAccesorios);

                return true;

            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public Boolean fnServisios(String lnIdPlan)
        {
            BLInstalacion objServE = new BLInstalacion();
            clsUtil clsUtil = new clsUtil();
            DataTable datServ = new DataTable();
            DataTable dtRespServicios = new DataTable();

            try
            {
                dgvServicios.Columns.Clear();
                datServ = objServE.blServiciosPlan(lnIdPlan);


                foreach (DataRow dr in datServ.Rows)
                {

                    lstServicios.Add(new ServicioEquipo
                    {
                        idServicios = Convert.ToInt32(dr["idServicioGps"]),
                        NombreServicio = Convert.ToString(dr["Servicio"]),
                    });

                }

                fnBusquedaServicios(datServ);

                dtRespServicios = objServE.blServiciosPlan(instalacion.codigoInstalacion);
                fnActivarChecksTablas(lstAccesorios, lstServicios, dtRespServicios, dgvServicios);




                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }





        private void seleccionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lnTipoCondicion = 0;
            fnLimpiarListas();
            lstServicios.Clear();
            lstAccesorios.Clear();
            String codVenta = "";
            codVenta = Convert.ToString(dgvListaInstalaciones.CurrentRow.Cells[0].Value);

            String RowVehiculos = Convert.ToString(dgvListaInstalaciones.CurrentRow.Cells[5].Value);
            String[] ArrayVehiculos = RowVehiculos.Split(';');
            List<Vehiculo> lstVehiculo = new List<Vehiculo>();

            lstVehiculo = fnDebolverDatVehiculo(RowVehiculos, ArrayVehiculos);

            fnLlamarDatosInstalacion(codVenta, lstVehiculo[0].vPlaca);

            tabControl1.SelectedIndex = 0;
            String lnIdPlan = "";

            fnAccesorios(lnIdPlan);
            fnServisios(lnIdPlan);
            
            //dgvAccesorios.Visible = true;
            //dgvServicios.Visible = true;

            //siticonePanel2.Visible = true;
            //lblSeleccionar.Visible = false;
            //lblGuardarAccYServ.Visible = true;
            //pbSubir.Visible = true;
            //pbBajar.Visible = false;
            
            fnActivarCamposActualizacion(true);
            fnActivarCamposInst(1, true);
            fnMostrtarTablas();
        }
        private void fnLlamarDatosInstalacion(String codVenta, String placa)
        {

            BLInstalacion objLlamarDatos = new BLInstalacion();
            clsUtil objUtil = new clsUtil();
            DataTable dtResp = new DataTable();
            try
            {
                lstEquipoActual.Clear();
                dtResp = objLlamarDatos.blLlEnarDatosIntalacion(codVenta, placa);

                foreach (DataRow dr in dtResp.Rows)
                {
                    if (Convert.ToString(dr["vPlaca"]) == "")
                    {
                        txtPlacaVInst.Visible = false;
                        lblplaca.Visible = false;

                        lblSerieVInstalacion.Location = new Point(557, 27);
                        txtSerieVInst.Location = new Point(555, 48);

                    }
                    else
                    {
                        txtPlacaVInst.Visible = true;
                        lblplaca.Visible = true;

                        lblSerieVInstalacion.Location = new Point(799, 28);
                        txtSerieVInst.Location = new Point(802, 48);
                    }


                    lstCliente.Add(new Cliente
                    {
                        idVentaGen = Convert.ToInt32(dr["idVentaGeneral"]),
                        codigoVentaGen = Convert.ToString(dr["codigoVenta"]),
                        idReferencia = Convert.ToString(dr["idReferencia"]),
                        cNombre = Convert.ToString(dr["cNombre"] + " " + dr["cApePat"] + " " + dr["cApeMat"]),
                        cTelCelular = Convert.ToString(dr["cTelCelular"]),
                        cCorreo = Convert.ToString(dr["cCorreo"]),
                        cDireccion = Convert.ToString(dr["cDireccion"]),
                        ubigeo = Convert.ToString(dr["cNomDist"] + " / " + dr["cNomProv"] + " / " + dr["cNomDep"]),
                        cContactoNom1 = Convert.ToString(dr["cContactoNom1"]),
                        dFechaRegistro = Convert.ToDateTime(dr["dFechaRefInstalacion"]),
                        cDocumento = Convert.ToString(dr["cDocumento"]),
                        cContactoNom2 = Convert.ToString(dr["tipoDocumento"])
                    });

                    lstVehiculo.Add(new Vehiculo
                    {
                        idVehiculo = Convert.ToInt32(dr["idVehiculo"]),
                        vClase = Convert.ToString(dr["cNombreClaseV"] + " / " + dr["nombreMarcaV"] + " / " + dr["nombreModeloV"] + " / " + dr["cUsoV"]),
                        vMarcaV = Convert.ToString(dr["nombreMarcaV"]),
                        vModeloV = Convert.ToString(dr["nombreModeloV"]),
                        vPlaca = Convert.ToString(dr["vPlaca"]),
                        vSerie = Convert.ToString(dr["vSerie"]),
                        vColor = Convert.ToString(dr["vColor"]),

                    });


                    lstPlan.Add(new Plan
                    {
                        tarifas = Convert.ToString(dr["nombreTipoTarifa"]),
                        cLetraPlan = Convert.ToString(dr["cLetraContrato"]),
                        nombrePlan = Convert.ToString(dr["nombrePlan"]),
                        ContratoPlan = Convert.ToString(dr["nombreTipoPlan"]),
                        CicloPlan = Convert.ToInt32(dr["cDia"]),
                        idPlan = Convert.ToInt32(dr["idPlan"]),
                        idTipoTarifa = Convert.ToInt32(dr["idTipoTarifa"])
                    });

                    lstEquipoActual.Add(objLlamarDatos.blBuscarEquipo(Convert.ToInt32(dr["idEquipoImei"])));
                    instalacion.idInstalacion = Convert.ToInt32(dr["idInstalacion"]);
                    instalacion.codigoInstalacion = Convert.ToString(dr["CodigoInstalacion"]);

                    cboSeleccionarUbicacionE.SelectedValue = Convert.ToInt32(dtResp.Rows[0][35]);
                    txtOtraUbicacion.Text = Convert.ToString(dr["DescripUbicacion"]);
                    txtObserInst.Text = Convert.ToString(dr["Descripcion"]);







                }
                foreach (Cliente drc in lstCliente)
                {
                    txtCodVenta.Text = drc.codigoVentaGen;
                    txtNomPerInst.Text = drc.cNombre + " " + drc.cApePat + " " + drc.cApeMat;
                    txtCelularPerInst.Text = drc.cTelCelular;
                    txtCorreoPerInst.Text = drc.cCorreo;
                    txtDireccPerInst.Text = drc.cDireccion;
                    txtDisProDepPerInst.Text = drc.ubigeo;
                    txtParenPropieV.Text = drc.cContactoNom1;
                    dtpFechaRegistro.Value = drc.dFechaRegistro;


                }
                foreach (Vehiculo drv in lstVehiculo)
                {
                    txtCMMUvehiculo.Text = drv.vClase;
                    txtPlacaVInst.Text = drv.vPlaca;
                    txtSerieVInst.Text = drv.vSerie;

                }

                fnPintarDatosEquipo(lstEquipoActual);




                btnBuscarEquipos.Enabled = true;
            }
            catch (Exception ex)
            {

            }

        }

        private void fnActivarChecksTablas(List<AccesoriosEquipo> lstAcc, List<ServicioEquipo> lstServ, DataTable td, DataGridView dgv)
        {
            if (dgv.Name == "dgvAccesorios")
            {
                for (Int32 i = 0; i < td.Rows.Count; i++)
                {
                    if (Convert.ToInt32(td.Rows[i][0]) == lstAcc[i].idAccesorios)
                    {
                        dgv.Rows[i].Cells[2].Value = true;
                    }
                    else
                    {
                        dgv.Rows[i].Cells[2].Value = false;
                    }
                }
            }
            else if (dgv.Name == "dgvServicios")
            {
                for (Int32 i = 0; i < td.Rows.Count; i++)
                {
                    if (Convert.ToInt32(td.Rows[i][0]) == lstServ[i].idServicios)
                    {
                        dgv.Rows[i].Cells[2].Value = true;
                    }
                    else
                    {
                        dgv.Rows[i].Cells[2].Value = false;
                    }
                }
            }

        }
        //static String DesEquipo = "";
        //static Int32 idEquipos = 0;
        //static String Eimail = "";
        //static Int32 tipcon = 0;


        public static void fnDatoEquipo(List<Equipo_imeis> lstEquipoImeis)
        {
            lstEquipo.Clear();
            lstEquipo = lstEquipoImeis;

            //DesEquipo = DescripcionE;
            //Eimail = Imail;
            //tipcon = tpcon;
        }

        private void fnPintarDatosEquipo(List<Equipo_imeis> lstEquipImei)
        {
            foreach (Equipo_imeis dr in lstEquipImei)
            {
                txtNomMarModEquipo.Text = dr.nomEquipo + " / " + dr.MarcaEquipo + " / " + dr.ModeloEquipo;
                txtEmailEquipo.Text = dr.imei;
                TxtsimCard.Text = dr.SimCardEquipo;

            }
        }
        private void btnBuscarEquipos_Click(object sender, EventArgs e)
        {

            frmEquipoImeis frmEquipoImei = new frmEquipoImeis();
            frmEquipoImei.Inicio(2);
            fnPintarDatosEquipo(lstEquipo);



            //txtNomMarModEquipo.Text = Convert.ToString(DesEquipo);
            //txtEmailEquipo.Text = Convert.ToString(Eimail);
            //txtCodEquipo.Text = Convert.ToString(idEquipos);

            gbObservacionesInst.Enabled = true;
            pbValObservacion.Visible = true;
            lbltxtObservacionIns.Visible = true;
            estObservacion = true;
            cboSeleccionarUbicacionE.Enabled = true;
            //btnGuardarIns.Enabled=true;
            gbUbicacion.Enabled = true;
            txtNomMarModEquipo_TextChanged(sender, e);

            fnActivarCamposInst(2, true);
            //btnGuardarIns.Enabled = true;
            //txtCelularPerInst.Text = Convert.ToString(dr["cTelCelular"]);
        }



        private List<Equipo_imeis> fnLstEquipos(Int32 idEquipo)
        {
            BLInstalacion objInstal = new BLInstalacion();
            List<Equipo_imeis> resp = new List<Equipo_imeis>();


            resp.Add(objInstal.blBuscarEquipo(idEquipo));


            return resp;

        }



        private void fnLimpiarControlesInstalacion()
        {
            txtNomPerInst.Text = "";
            txtCelularPerInst.Text = "";
            txtCorreoPerInst.Text = "";
            txtDireccPerInst.Text = "";
            txtDisProDepPerInst.Text = "";
            txtParenPropieV.Text = "";

            txtCMMUvehiculo.Text = "";
            txtPlacaVInst.Text = "";
            txtSerieVInst.Text = "";

            txtNomMarModEquipo.Text = "";
            txtEmailEquipo.Text = "";
            TxtsimCard.Text = "";

            txtObserInst.Text = "";

            txtCodVenta.Text = "0";
            txtCodVehiculo.Text = "0";
            txtCodEquipo.Text = "0";
            txtidRefInstalacion.Text = "0";

            btnBuscarEquipos.Enabled = false;

            gbObservacionesInst.Enabled = false;
            pbValObservacion.Visible = false;

            txtPlacaVInst.Visible = true;
            lblplaca.Visible = true;

            lblSerieVInstalacion.Location = new Point(799, 28);
            txtSerieVInst.Location = new Point(802, 48);
            cboSeleccionarUbicacionE.SelectedValue = 0;
            cboSeleccionarUbicacionE.Enabled = true;


            fnLimpiarListas();
            lstEquipo.Clear();

        }

        private void fnLimpiarListas()
        {
            lstCliente.Clear();
            lstVehiculo.Clear();
            lstPlan.Clear();

        }
        private void fnActivarCamposActualizacion(Boolean maria)
        {
            txtOtraUbicacion.Enabled = maria;
            cboSeleccionarUbicacionE.Enabled = maria;
            txtObserInst.Enabled = maria;
            gbObservacionesInst.Enabled = maria;


        }
        private void btnNuevoInst_Click(object sender, EventArgs e)
        {

            estCliente = false;
            estEquipo = false;

            btnGuardarIns.Enabled = false;

            fnLimpiarControlesInstalacion();
            fnActivarCamposInst(1, true);


        }

        private void txtObserInst_TextChanged(object sender, EventArgs e)
        {


            var Result = FunValidaciones.fnValidarTexboxs(txtObserInst, lbltxtObservacionIns, pbValObservacion, true, true, true, 0, 500, 500, 500, "LLENE TODOS LOS CAMPOS");
            estObservacion = Result.Item1;
            msjObservacion = Result.Item2;

            if (estObservacion == false)
            {
                FunValidaciones.fnHabilitarBoton(btnGuardarIns, true);
            }
            else
            { FunValidaciones.fnHabilitarBoton(btnGuardarIns, true); }


        }

        private void txtObserInst_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);


        }


        private void txtNomPerInst_TextChanged(object sender, EventArgs e)
        {
            var Result = FunValidaciones.fnValidarTexboxs(txtNomPerInst, lbltextcliente, pbtextcliente, true, true, true, 5, 200, 200, 200, "LLENE TODOS LOS CAMPOS");
            estCliente = Result.Item1;
            msjCliente = Result.Item2;

            if (estCliente == true)
            { FunValidaciones.fnHabilitarBoton(btnGuardarIns, true); }
            else
            { FunValidaciones.fnHabilitarBoton(btnGuardarIns, false); }

        }

        private void txtNomMarModEquipo_TextChanged(object sender, EventArgs e)
        {
            var Result = FunValidaciones.fnValidarTexboxs(txtNomMarModEquipo, lbltextequipo, pbtextequipo, true, true, true, 5, 50, 50, 70, "LLENE TODOS LOS CAMPOS");
            estEquipo = Result.Item1;
            msjEquipo = Result.Item2;
        }

 

        private void dgvListaInstalaciones_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
                    if (!clickedRow.Selected)
                    {
                        dgvListaInstalaciones.CurrentCell = clickedRow.Cells[e.ColumnIndex];

                    }
                    else
                    {
                        var mousePosition = dgvListaInstalaciones.PointToClient(Cursor.Position);
                        //cmsMenuSeleccion.Show(dgvListaInstalaciones, mousePosition);

                    }

                }
            }
        }

        private Boolean fnConfirmacionVistaPreviaG(List<xmlInstalacion> xmlInstal)
        {
            //FUNCION DE CONFIRMACION DE VISTA PREVIA

            BLInstalacion objTipoVenta = new BLInstalacion();
            clsUtil objUtil = new clsUtil();
            DataTable dtResp = new DataTable();
            //List<TipoVenta> lsTipoVenta = new List<TipoVenta>();
            //Int32 filas = 20;


            //xmlDocVenta = objTipoVenta.blConfirmacionVistaPGuardar(codigoVenta);

            Consultas.frmRptActa abrirFrmRptActa = new Consultas.frmRptActa();


            abrirFrmRptActa.Inicio(xmlInstal[0].ListaCliente, xmlInstal[0].ListaVehiculo, xmlInstal[0].ListaEquipo.Count> 0?xmlInstal[0].ListaEquipo:xmlInstal[0].ListaEquipoActual, xmlInstal[0].ListaPlan, xmlInstal[0].ListaAccesorio, xmlInstal[0].ListaServicio, xmlInstal[0].observaciones, xmlInstal[0].clsInstalacion, 0);

            return true;


        }

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fnActivarChecks(e.RowIndex, dgvServicios);
            //Int32 dato = Convert.ToInt32(dgvAccesorios.Rows[3].Cells[2].Value);
            //if (e.ColumnIndex == dgvAccesorios.Columns["Chk"].Index)
            //{
            //    if (e.RowIndex == 3 && Convert.ToBoolean(dgvAccesorios.Rows[3].Cells[2].Value) == true)
            //    {
            //        dgvAccesorios.Rows[3].Cells[2].Value = false;
            //    }
            //    else if (e.RowIndex == 3 && Convert.ToBoolean(dgvAccesorios.Rows[3].Cells[2].Value) == false)
            //    {
            //        dgvAccesorios.Rows[3].Cells[2].Value = true;
            //    }
            //    //if (Convert.ToBoolean(dgvAccesorios.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
            //    //{
            //    //    dgvServicios.Rows[3].Cells[2].Value = true;

            //    //}
            //    //else
            //    //{
            //    //    dgvServicios.Rows[3].Cells[2].Value = true;
            //    //}


            //    //dato = Convert.ToString(dgvServicios.Rows[e.RowIndex].Cells[3].Value);
            //    //dgvServicios.Rows[0].Cells[2].Value = true

            //}
        }

        private void siticonePictureBox2_Click(object sender, EventArgs e)
        {
            dgvAccesorios.Visible = false;
            dgvServicios.Visible = false;
            pbSubir.Visible = false;
            pbBajar.Visible = true;
            lblSeleccionar.Visible = true;
            lblGuardarAccYServ.Visible = false;
        }

        private void pbBajar_Click(object sender, EventArgs e)
        {
            dgvAccesorios.Visible = true;
            dgvServicios.Visible = true;
            pbSubir.Visible = true;
            pbBajar.Visible = false;
            lblSeleccionar.Visible = false;
            lblGuardarAccYServ.Visible = true;
        }

        private void fnMostrtarTablas()
        {
            if (dgvAccesorios.Visible == true && dgvServicios.Visible == true)
            {
                dgvAccesorios.Visible = false;
                dgvServicios.Visible = false;
                pbSubir.Visible = false;
                pbBajar.Visible = true;
                lblSeleccionar.Visible = true;
                lblGuardarAccYServ.Visible = false;




            }
            else
            {
                dgvAccesorios.Visible = true;
                dgvServicios.Visible = true;
                pbSubir.Visible = true;
                pbBajar.Visible = false;
                lblSeleccionar.Visible = false;
                lblGuardarAccYServ.Visible = true;
            }
        }
        private void siticonePanel2_Click(object sender, EventArgs e)
        {
            fnMostrtarTablas();
        }
        //devolver datos del dgv de acc y ser
        private Tuple<List<AccesoriosEquipo>, List<ServicioEquipo>> fnObtenerListaAccesorios()
        {

            List<AccesoriosEquipo> objAccesorios = new List<AccesoriosEquipo>(); ;
            List<ServicioEquipo> objServicio = new List<ServicioEquipo>();

            AccesoriosEquipo clsAccesorio;
            ServicioEquipo clsServicio;

            objAccesorios.Clear();
            objServicio.Clear();

            foreach (DataGridViewRow row in dgvAccesorios.Rows)
            {
                clsAccesorio = new AccesoriosEquipo();

                clsAccesorio.idAccesorios = Convert.ToInt32(row.Cells[0].Value);
                clsAccesorio.NombreAccesorio = Convert.ToString(row.Cells[1].Value);
                clsAccesorio.checkAccesorio = Convert.ToBoolean(row.Cells[2].Value) == true ? Convert.ToBoolean(row.Cells[2].Value) : false;
                objAccesorios.Add(clsAccesorio);

            }



            foreach (DataGridViewRow row in dgvServicios.Rows)
            {
                clsServicio = new ServicioEquipo();

                clsServicio.idServicios = Convert.ToInt32(row.Cells[0].Value);
                clsServicio.NombreServicio = Convert.ToString(row.Cells[1].Value);
                clsServicio.checkServicio = Convert.ToBoolean(row.Cells[2].Value) == true ? Convert.ToBoolean(row.Cells[2].Value) : false;


                objServicio.Add(clsServicio);

            }



            return Tuple.Create(objAccesorios, objServicio);
        }
        private void dgvAccesorios_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvAccesorios.Columns["Chk"].Index)
            {
                dgvAccesorios.Cursor = Cursors.Hand;
            }
            else
            {
                dgvAccesorios.Cursor = Cursors.Arrow;
            }
        }

        private void dgvServicios_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvServicios.Columns["Chk"].Index)
            {
                dgvServicios.Cursor = Cursors.Hand;
            }
            else
            {
                dgvServicios.Cursor = Cursors.Arrow;
            }
        }

        private void siticonePanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void fnValidarEstado(Boolean Estado)
        {
            EstadoInstalacion = Estado;
        }

        private void siticoneComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneGroupBox3_Click(object sender, EventArgs e)
        {
            //cboSeleccionarUbicacionE.Visible = true;
            //
            //
            //.Visible = true;

        }

        private void txtOtraUbicacion_TextChanged(object sender, EventArgs e)
        {
            var Result = FunValidaciones.fnValidarTexboxs(txtOtraUbicacion, lblUbicacionEquipo, pbubicacion, true, true, true, 4, 50, 50, 50, "LLENE TODOS LOS CAMPOS");
            estUbicacion = Result.Item1;
            msjUbicacion = Result.Item2;

            if (estUbicacion == true)
            { FunValidaciones.fnHabilitarBoton(btnGuardarIns, true); }
            else
            { FunValidaciones.fnHabilitarBoton(btnGuardarIns, false); }

        }

        private void txtOtraUbicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LENUMCARAC", true);
           
        }

        private void lblSeleccionar_Click(object sender, EventArgs e)
        {
            fnMostrtarTablas();
        }

        private void lblGuardarAccYServ_Click(object sender, EventArgs e)
        {
            fnMostrtarTablas();
        }

        private void dgvListaInstalaciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvListaInstalaciones.Columns[e.ColumnIndex].Name == "btImprimir" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvListaInstalaciones.Rows[e.RowIndex].Cells["btImprimir"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\Impresora.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvListaInstalaciones.Rows[e.RowIndex].Height = 45;
                this.dgvListaInstalaciones.Columns[e.ColumnIndex].Width = 45;


                e.Handled = true;

            }
        }

        private void dgvListaInstalaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                xmlInstalacion xmlInst = new xmlInstalacion();
                String codVenta = "";
                Int32 TipoVenta = 0;
                codVenta = Convert.ToString(dgvListaInstalaciones.Rows[e.RowIndex].Cells[0].Value);
                TipoVenta = Convert.ToInt32(dgvListaInstalaciones.Rows[e.RowIndex].Cells[8].Value);

                String RowVehiculos = Convert.ToString(dgvListaInstalaciones.CurrentRow.Cells[5].Value);
                String[] ArrayVehiculos = RowVehiculos.Split(';');
                List<Vehiculo> lstVehiculo = new List<Vehiculo>();

                lstVehiculo = fnDebolverDatVehiculo(RowVehiculos, ArrayVehiculos);
                frmRegistrarVenta frmRegVenta = new frmRegistrarVenta();
                frmRptActa frmVPActa = new frmRptActa();
                xmlInst = frmRegVenta.fnBuscarActaInstalacion(codVenta, lstVehiculo[0].vPlaca, TipoVenta);
                if (xmlInst.clsInstalacion != null)
                {
                    frmVPActa.Inicio(xmlInst.ListaCliente, xmlInst.ListaVehiculo, xmlInst.ListaEquipo, xmlInst.ListaPlan, xmlInst.ListaAccesorio, xmlInst.ListaServicio, xmlInst.observaciones, xmlInst.clsInstalacion, 1);
                }
                else
                {
                    MessageBox.Show("Por favor registre la instalacion para imprimir el acta", "Aviso 🤨!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }



        private void actualizarInstalacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lnTipoCondicion = 1;

            fnLimpiarListas();
            lstServicios.Clear();
            lstAccesorios.Clear();

            String codVenta = "";
            codVenta = Convert.ToString(dgvListaInstalaciones.CurrentRow.Cells[0].Value);

            String RowVehiculos = Convert.ToString(dgvListaInstalaciones.CurrentRow.Cells[5].Value);
            String[] ArrayVehiculos = RowVehiculos.Split(';');
            List<Vehiculo> lstVehiculo = new List<Vehiculo>();

            lstVehiculo = fnDebolverDatVehiculo(RowVehiculos, ArrayVehiculos);

            fnLlamarDatosInstalacion(codVenta, lstVehiculo[0].vPlaca);

            tabControl1.SelectedIndex = 0;
            String lnIdPlan = "";

            fnAccesorios(lnIdPlan);
            fnServisios(lnIdPlan);

            //dgvAccesorios.Visible = true;
            //dgvServicios.Visible = true;

            siticonePanel2.Visible = true;
            lblSeleccionar.Visible = false;
            lblGuardarAccYServ.Visible = true;
            pbSubir.Visible = true;
            pbBajar.Visible = false;

            fnActivarCamposActualizacion(true);
            fnMostrtarTablas();

        }

        private void mostrarUbicacionDeInstalacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (UbicacionEquipo.Visible == true)
            {
                
            mostrarUbicacionDeInstalacionToolStripMenuItem.Text = "Mostrar ubicacion de Instalacion";
               UbicacionEquipo.Visible = false;
            }
            else if (UbicacionEquipo.Visible == false)
            {

                mostrarUbicacionDeInstalacionToolStripMenuItem.Text = "Ocultar ubicacion de Instalacion";
                UbicacionEquipo.Visible = true;
                     
            }

        }

        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {
            fnBuscarListaVentas(dgvListaInstalaciones, Convert.ToString(cboEstadosInst.SelectedValue), btnTotalRegistrosIns, 0, 1, -1);
        }

        private void txtEmailEquipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtsimCard_TextChanged(object sender, EventArgs e)
        {

        }

        private void gbDatosEquipo_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(btnNuevoInst.TabIndex) == -3)
            //{
            //    txtEmailEquipo.Enabled = true;
            //    TxtsimCard.Enabled = true;
            //    btnGuardarIns.Enabled = false;
            //    pbtextequipo.Visible = true;

            //}
            //else
            //{

            //    txtEmailEquipo.Enabled = false;
            //    TxtsimCard.Enabled = false;
            //    TxtsimCard.Text ="";
            //    txtOtraUbicacion.Text ="";
            //    if (estCliente == true && estEquipo == true && Convert.ToInt32(btnNuevoInst.TabIndex) != 0)
            //    {
            //        btnGuardarIns.Enabled = false;

            //    }
            //    pbtextequipo.Visible = false;


            //}

        }

        private Boolean fnLlenarCboUbicacionIns(Int32 idUbicacion)
        {
            BLInstalacion objUbicacion = new BLInstalacion();
            clsUtil objUtil = new clsUtil();
            DataTable dtResultados = new DataTable();
            List<UbicacionEquipoInstalacion> lstubicacion = new List<UbicacionEquipoInstalacion>();
            try
            {
                lstubicacion = objUbicacion.blDevolverUbicacionIns(idUbicacion);



                cboSeleccionarUbicacionE.ValueMember = "idUbicacionEquipo";
                cboSeleccionarUbicacionE.DisplayMember = "NUbicacionEquipo";
                cboSeleccionarUbicacionE.DataSource = lstubicacion;

                //lstUbicacionEquipo = lstubicacion;

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                lstubicacion = null;
            }
        }

        private void vIsualizarUbicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrevisualizar frmPrev = new FrmPrevisualizar();
            String dato = "";
            dato = Convert.ToString(dgvListaInstalaciones.CurrentRow.Cells[9].Value);

            frmPrev.inicio(1, dato);
        }

        private void txtBuscarIns_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboSeleccionarUbicacionE_SelectedIndexChanged(object sender, EventArgs e)
       
        {


            //Int32 idUbicacion = 1;
            //fnLlenarCboUbicacionIns(idUbicacion);
            //cboClaseV.ValueMember = "idClase";
            //cboClaseV.DisplayMember = "cNomClase";
            //cboClaseV.DataSource = lstClase;
            fnActivarCamposInst(3, true);

        }

        private void btnGuardarIns_Click(object sender, EventArgs e)
        {
            String codigoVenta = txtCodVenta.Text.ToString();
            //Int32 idEquipo = Convert.ToInt32(txtCodEquipo.Text.ToString());
            //Int32 idVehiculo = Convert.ToInt32(txtCodVehiculo.Text.ToString());
            //Int32 idReferencia = Convert.ToInt32(txtidRefInstalacion.Text.ToString()); 
            String Observacion = txtObserInst.Text.ToString();
            DateTime FechaInstalacion = dtpFechaRegistro.Value;
            Boolean respuesta = false;
            Boolean resul = false;
            Personal clsPersonal = FunGeneral.fnObtenerUsuarioActual(); 


            frmRegistrarVenta fntecnico = new frmRegistrarVenta();
            instalacion.cUsuario = clsPersonal.cPrimerNom + " " + clsPersonal.cApePat + " " + clsPersonal.cApeMat;
            instalacion.dFechaIntal = Convert.ToDateTime(dtpFechaRegistro.Value);
            lstUbicacionEquipo.Clear();
            lstUbicacionEquipo.Add(new UbicacionEquipoInstalacion {

                idUbicacionEquipo = (Convert.ToInt32(cboSeleccionarUbicacionE.SelectedValue)),
                //cboSeleccionarUbicacionE.SelectedIndex,
                NUbicacionEquipo = txtOtraUbicacion.Text.ToString()

            });
            List<xmlInstalacion> xmlInstal = new List<xmlInstalacion>();
            var resultado = fnObtenerListaAccesorios();

            xmlInstal.Add(new xmlInstalacion
            {
                ListaCliente = lstCliente,
                ListaVehiculo = lstVehiculo,
                ListaAccesorio = resultado.Item1,
                ListaServicio = resultado.Item2,
                ListaEquipo = lstEquipo,
                ListaEquipoActual = lstEquipoActual,
                ListaPlan = lstPlan,
                ListaUbicacionEquipo = lstUbicacionEquipo,
                observaciones = txtObserInst.Text.ToString() == "" ? "Sin Observacion" : txtObserInst.Text.ToString(),
                clsInstalacion = instalacion
            });


            if (estCliente == true && estEquipo == true /*&& estObservacion==true*/ && xmlInstal[0].ListaUbicacionEquipo[0].idUbicacionEquipo != 0)
            {

                //FUNCION DE CONFIRMACION DE VISTA PREVIA

                fnConfirmacionVistaPreviaG(xmlInstal);



                if (EstadoInstalacion == true)
                {


                    respuesta = FnGuardarInstalacionEquipo(xmlInstal, Variables.gnCodUser, FechaInstalacion);

                    if (respuesta == true)
                    {
                        MessageBox.Show("Se registro correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fnBuscarListaVentas(dgvListaInstalaciones, "ESVG0001", btnTRegistros, 0, 1, -3);
                        fnLimpiarControlesInstalacion();

                    }
                    else
                    {
                        MessageBox.Show("NO SE PUDO REGISTRAR", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("COMPLETA TODOS LOS CAMPOS", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            fnActivarCamposInst(0, true);

        }
        //falta las texboxs ocultos para las id agregar a los campos qeu se envia 
        private Boolean FnGuardarInstalacionEquipo(List<xmlInstalacion> xmlInstal, Int32 idUsuario, DateTime FechaInstalacion)
        {
            DateTime dfechaSis = Variables.gdFechaSis;
            BLInstalacion objGuardarInst = new BLInstalacion();
            clsUtil objUtil = new clsUtil();
            Boolean respuesta = false;



            try
            {
                return respuesta = objGuardarInst.blGrabarInstalacionEquipo(xmlInstal, idUsuario, FechaInstalacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Vehiculo> fnDebolverDatVehiculo(String RowVehiculos, String[] ArrayVehiculos)
        {
            Int32 contador = ArrayVehiculos.Length - 1;
            String placa = "";
            String DescripVehiculo = "";
            String[] ArrayDatos = RowVehiculos.Split('(');
            Int32 contadorDtos = ArrayDatos[0].Length;

            List<Vehiculo> lstVehi = new List<Vehiculo>();

            for (Int32 i = 0; i < contador; i++)
            {
                DescripVehiculo = string.Format("{1}{0}", Environment.NewLine, ArrayVehiculos[i]);
                placa = (i == 0) ? ArrayVehiculos[i].Substring(6, contadorDtos - 6) : ArrayVehiculos[i].Substring(7, contadorDtos - 6);


                lstVehi.Add(new Vehiculo
                {
                    vPlaca = placa,
                    vModeloV = DescripVehiculo

                });
            }
            return lstVehi;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                fnBuscarListaVentas(dgvListaInstalaciones, "ESVG0001", btnTRegistros, 0, 1, -3);
                //fnBuscarListaVentas(dgvListaInstalaciones, "ESVG0001", btnTRegistros, 0, 1, -1);
            }
            else
            {
                cboEstadosInst.SelectedValue = "ESVG0001";
                fnBuscarListaVentas(dgvListaInstalaciones, Convert.ToString(cboEstadosInst.SelectedValue), btnTotalRegistrosIns, 0, 1, -1);
                //fnBuscarListaVentas(dgvListaInstalaciones, "ESVG0001", btnTotalRegistrosIns, 0, 1, -1);
            }
        }
        private void fnActivarCamposInst(Int32 condicion, Boolean estado)
        {
            if (condicion == 0)
            {
                cboSeleccionarUbicacionE.Enabled = !estado;
                txtOtraUbicacion.Enabled = !estado;
                gbObservacionesInst.Enabled = !estado;
                btnGuardarIns.Enabled = !estado;
                btnBuscarEquipos.Enabled = !estado;
            }
            else if (condicion == 1)
            {
                btnBuscarEquipos.Enabled = estado;
                cboSeleccionarUbicacionE.Enabled = !estado;
                txtOtraUbicacion.Enabled = !estado;
                gbObservacionesInst.Enabled = !estado;
                btnGuardarIns.Enabled = !estado;
                cboSeleccionarUbicacionE.Enabled = !estado;

               
            }
            else if (condicion == 2)

            {
                cboSeleccionarUbicacionE.Enabled = estado;


                if (Convert.ToInt32(cboSeleccionarUbicacionE.SelectedValue) == -3)
                {
                    txtOtraUbicacion.Enabled = estado;
                    gbObservacionesInst.Enabled = estado;
                    btnGuardarIns.Enabled = estado;

                }

                else if (Convert.ToInt32(cboSeleccionarUbicacionE.SelectedValue)  != 0 && lnTipoCondicion == 0)
                {
                    txtOtraUbicacion.Enabled = !estado;

                    gbObservacionesInst.Enabled = estado;
                    btnGuardarIns.Enabled = estado;
                }


            }
            else if (condicion==3)
            {
                cboSeleccionarUbicacionE.Enabled = estado;


                if (Convert.ToInt32(cboSeleccionarUbicacionE.SelectedValue) == -3)
                {
                    txtOtraUbicacion.Enabled = estado;
                    txtOtraUbicacion.Text = "";
                    gbObservacionesInst.Enabled = estado;
                    btnGuardarIns.Enabled = !estado;

                }

                else if (Convert.ToInt32(cboSeleccionarUbicacionE.SelectedValue) != 0)
                {
                    txtOtraUbicacion.Enabled = !estado;
                   
                    gbObservacionesInst.Enabled = estado;
                    btnGuardarIns.Enabled = estado;
                }
            }

            

        }
           



            

    }


    
}

