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

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmAsignacionADocumento : Form
    {
        public frmAsignacionADocumento()
        {
            InitializeComponent();
        }

        static Int32 pnIdOrdenCompra = 0;
        static Int32 StokOrden = 0;
        static String pcTipoIngreso = "";
        static String pcCodOrden = "";
        static String pcEquipoUnico = "";
        static Int32 lnTipoValor = 0;

        Int32 lnTipoCon = 0;

        Boolean estNumDocumento;
        String msjNumDocumento;

        static Int32 tabInicio;
        public static void fnRecuperarOredenCompra(Int32 idOrden, String tipoIngreso, String codOrden, Int32 stokOrden, String EquipoUnico, int pnTipoValor = 0)
        {
            pnIdOrdenCompra = idOrden;
            pcTipoIngreso = tipoIngreso;
            pcCodOrden = codOrden;
            StokOrden = stokOrden;
            pcEquipoUnico = EquipoUnico;
            lnTipoValor = pnTipoValor;
        }

        private void BtnOrdenCompra_Click(object sender, EventArgs e)
        {
            frmDetalleIngresoEquipo frmOrdenCompra = new frmDetalleIngresoEquipo();

            frmOrdenCompra.Inicio(2);

            Boolean lbResul = false;
            lbResul = fnObtenerEquipo();
            if (!lbResul)
            {
                MessageBox.Show("Error al Agregar Cliente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private Boolean fnObtenerEquipo()
        {
            bool bResul = false;
            clsUtil objUtil = new clsUtil();
            try
            {
                //bResul = fnListarOperador(true);
                //if (bResul == false)
                //    return false;
                if (lnTipoValor == 0)
                {
                    //txtTipoIngreso.Text = "no hay datos";
                }
                else
                {
                    //dgImei_serie.Rows.Clear();

                    txtIdOrdenIngreso.Text = Convert.ToString(pnIdOrdenCompra);
                    txtTipoIngreso.Text = pcTipoIngreso;
                    txtDocumento.Text = pcCodOrden;
                    txtEquipoUnico.Text = pcEquipoUnico;
                    txtStokImeis.Text = Convert.ToString(StokOrden);
                    //pnIdEquipo = 0;
                    //txtSimCard.Text = Convert.ToString(lcSimcard);
                    //txtOperador.Text = lcOperador;
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarVehiculo", "fnObtenerCliente", ex.Message);
                return false;
            }
        }

        private void fnCalcularPaginacion(Int32 totalRegistros, Int32 filas, Int32 totalResultados)
        {
            Int32 residuo;
            Int32 cantidadPaginas;
            residuo = totalRegistros % filas;
            if (residuo == 0)
            {
                cantidadPaginas = (totalRegistros / filas);
            }
            else
            {
                cantidadPaginas = (totalRegistros / filas) + 1;
            }

            cboPagina.Items.Clear();

            for (Int32 i = 1; i <= cantidadPaginas; i++)
            {
                cboPagina.Items.Add(i);

            }

            cboPagina.SelectedIndex = 0;
            btnTotalPaginas.Text = Convert.ToString(cantidadPaginas);
            btnNumFilas.Text = Convert.ToString(totalResultados);
            btnTotalRegistros.Text = Convert.ToString(totalRegistros);


        }
        public Boolean fnBuscarChips(Int32 lnIdRecibo,Int32 numPagina, Int32 tipoCon)
        {
            BLAdministrarEquipos objEquipo = new BLAdministrarEquipos();
            clsUtil objUtil = new clsUtil();
            DataTable datOperador = new DataTable();
            List<Equipo_imeis> lstEquipo = null;
            Int32 filas = 20;

            try
            {
                lstEquipo = new List<Equipo_imeis>();
                //lstEquipo = objEquipo.blBuscarEquipo(pcBuscar, pnTipoCon);
                dgImeis.Columns.Clear();
                datOperador = objEquipo.blBuscarImeisDatatable(lnIdRecibo,Convert.ToString(txtBuscar.Text.ToString()), numPagina, tipoCon);

                DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                dgvCmb.ValueType = typeof(bool);
                dgvCmb.Name = "Chk";
                dgvCmb.HeaderText = "Seleccionar";
                dgImeis.Columns.Add(dgvCmb);

                DataTable dtEmp = new DataTable();
                dtEmp.Columns.Add("ID", typeof(int));
                dtEmp.Columns.Add("IMEI", typeof(string));
                dtEmp.Columns.Add("ESTADO", typeof(string));


                if (lnTipoCon == 0)
                {
                    Int32 totalResultados = datOperador.Rows.Count;
                    int y;
                    if (tipoCon == 0)
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
                        dtEmp.Rows.Add(datOperador.Rows[i][0],
                            datOperador.Rows[i][1],
                            datOperador.Rows[i][2]
                            );
                    }
                    dgImeis.DataSource = dtEmp;
                    dgImeis.Columns[0].Width = 50;
                    dgImeis.Columns[1].Visible=false;

                    if (tipoCon == 0)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datOperador.Rows[0][3]);
                        fnCalcularPaginacion(totalRegistros, filas, totalResultados);
                    }
                    else
                    {
                        btnNumFilas.Text = Convert.ToString(totalResultados);
                    }
                    //fnActivarCargandoGif(pIBusar, false);
                }
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }
        }

        private void frmAsignacionADocumento_Load(object sender, EventArgs e)
        {
            FunValidaciones.fnColorBotones(btnNuevo, btnEditar, btnGuardar, btnSalir);
            fnBuscarChips(0,1, 0);

        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 pagina = Convert.ToInt32(cboPagina.Text.ToString());
            //if (cboPagina.SelectedIndex!=0)
            //{

             fnBuscarChips(0, pagina, 1);
            //}
            
        }
        private List<AsignarImeisADocumento> fnRecorrerGrilla()
        {
            AsignarImeisADocumento objImeis;
            List<AsignarImeisADocumento> lstEquipo = new List<AsignarImeisADocumento>();
            if (lnTipoCon == 0)
            {
                foreach (DataGridViewRow row in dgImeis.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        objImeis = new AsignarImeisADocumento();
                        objImeis.idDocumento = Convert.ToInt32(txtIdOrdenIngreso.Text.ToString());
                        objImeis.idEquipoImeis = Convert.ToInt32(row.Cells[1].Value);
                        objImeis.dFecharegistro = Variables.gdFechaSis;
                        objImeis.dFechaMovimiento = Variables.gdFechaSis;
                        objImeis.idUsuario = Variables.gnCodUser;
                        lstEquipo.Add(objImeis);
                    }
                }
            }
            else if (lnTipoCon == 1)
            {
                foreach (DataGridViewRow row in dgImeis.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == false)
                    {
                        objImeis = new AsignarImeisADocumento();
                        objImeis.idDocumento = Convert.ToInt32(txtIdOrdenIngreso.Text.ToString());
                        objImeis.idEquipoImeis = Convert.ToInt32(row.Cells[1].Value);
                        objImeis.dFecharegistro = Variables.gdFechaSis;
                        objImeis.idUsuario = Variables.gnCodUser;
                        lstEquipo.Add(objImeis);
                    }
                }
            }


            return lstEquipo;


        }

        private void fnLimiarCampos()
        {
            txtBuscar.Text = "";
            txtDocumento.Text = "";
            txtEquipoUnico.Text = "";
            txtIdOrdenIngreso.Text="";
            txtStokImeis.Text = "";
            txtTipoIngreso.Text = "";

             StokOrden = 0;
             pcTipoIngreso = "";
             pcCodOrden = "";
            pcEquipoUnico = "";

        }
        Int32 contador = 0;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool blnResultado = false;
            BLAdministrarEquipos objEquipoImeis = new BLAdministrarEquipos();
            if (estNumDocumento == true)
            {
                List<AsignarImeisADocumento> lstImeis= fnRecorrerGrilla();
                if (lstImeis.Count > 0)
                {
                    if (lnTipoCon == 0)
                    {
                        if (MessageBox.Show("¿Desea asignar " + lstImeis.Count + " Imeis a la orden " + txtDocumento.Text.ToString() + "? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            blnResultado = objEquipoImeis.blGrabarChips_Recibo(fnRecorrerGrilla(), lnTipoCon, Convert.ToInt32(txtStokImeis.Text), Convert.ToInt32(txtIdOrdenIngreso.Text));
                            if (blnResultado)
                            {
                                //blnResultado = fnObtenerPreciosxProductoxUM(idEquipo);
                                //if (!blnResultado)
                                //    MessageBox.Show("No se ha cargado correctamente Listado de Precios por Producto y unidad de medida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show("Imeis asignados correctamente a oreden de ingreso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //contador += 1;
                                //if (contador== Convert.ToInt32(txtStokImeis.Text))
                                //{
                                //    contador = 0;
                                    fnLimiarCampos();
                                    
                                //}
                                fnBuscarChips(0,Convert.ToInt32(cboPagina.Text), 1);
                                
                            }
                        }
                    }
                    else if (lnTipoCon == 1)
                    {
                        //if (MessageBox.Show("¿Desea remover " + lstPrecio.Count + " chips del recibo " + cboNumRecibo.Text.ToString() + "? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        //    blnResultado = objEquipoImeis.blGrabarChips_Recibo(fnRecorrerGrilla(), lnTipoCon);
                        //    if (blnResultado)
                        //    {
                        //        MessageBox.Show("Chips removidos correctamente del recibo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        if (lnTipoCon == 1)
                        //        {
                        //            lnTipoCon = 0;
                        //            chkBuscar.Checked = false;
                        //            cboNumRecibo.SelectedValue = 0;
                        //        }
                        //        fnBuscarChips(0, lnTipoCon);
                        //    }
                        //}
                    }
                }
                else
                {
                    MessageBox.Show("No se ha Asigno algun imei marque  las casillas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Porfavor elegir y/o completar todo los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtIdOrdenIngreso_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            var resul = FunValidaciones.fnValidarTexboxs(txtDocumento, lblOrdenIngreso, pbOrdenCompra, true, true, false, 3, 12, 12, 12, "Porfavor elija documento de ingreso"); ;
            estNumDocumento = resul.Item1;
            msjNumDocumento = resul.Item2;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                //foreach (DataGridViewRow row in dgImeis.Rows)
                //{
                //    if (Convert.ToString(Convert.ToString(row.Cells[2].Value).StartsWith(txtBuscar.Text))
                //    {

                //    }

                //}
                fnBuscarChips(0, Convert.ToInt32(cboPagina.Text), 0);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            fnLimiarCampos();
        }

        private void siticonePanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgImeis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
