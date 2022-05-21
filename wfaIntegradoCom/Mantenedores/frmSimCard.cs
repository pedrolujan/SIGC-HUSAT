using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Guna.UI.WinForms;
using Siticone.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Procesos;
using static wfaIntegradoCom.Mantenedores.frmAdministrarEquipos;
using CColor = System.Drawing.Color;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmSimCard : Form
    {
        public frmSimCard()
        {
            InitializeComponent();

            FunGeneral.fnLlenarTablaCod(cboBuscarEstado, "ESCHI");
            fnLimpiarControles();

        }
        Int32 lnTipoCon = 0;
        Int16 lnTipoLlamada = 0;
        string pcTipoOperacion = "";
        static Int32 tabInicio;
        static Int32 lcSimcard = 0;
        static String lcOperador = "";
        static Int32 pnIdOperador = 0;
        static Int32 lnTipoValor = 0;
        Boolean cargoForm = false;
        Boolean estadoBusqPaginas = false;
        Boolean estDiasSuspencion, estSimCard, estOperador, estEstado, estFechaCompra, estFechaReactivacion, estFechaSuspencion, estPagoRealizado, estObservaciones;
        String msjDiasSuspencion, msjSimCard, msjOperador, msjEstado, msjFechaCompra, msjFechaReactivacion, msjFechaSuspencion, msjPagoRealizado, msjObservaciones;

        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();
        }



        void fnHabilitarBotones(Boolean estado)
        {
            btnNuevo.Visible = estado;
            btnEditar.Visible = estado;
            btnGuardar.Visible = estado;
            btnSalir.Enabled = estado;
            gbDatosChip.Visible = estado;
        }

        public void AddText(object sender, EventArgs e)
        {
            if (txtBuscarChip.Text != "")
            {
                txtBuscarChip.Text = "";

            }
            if (string.IsNullOrWhiteSpace(txtBuscarChip.Text))
            {
                txtBuscarChip.Text = "";
                txtBuscarChip.ForeColor = Color.Gray;
                pbSearch.Image = Properties.Resources.buscar_base;

            }
        }


        public void RemoveText(object sender, EventArgs e)
        {
            if (txtBuscarChip.Text.Length > 0)
            {
                txtBuscarChip.Text = "";
                txtBuscarChip.ForeColor = Color.Black;
            }
            pbSearch.Image = Properties.Resources.buscar_hover;

        }
        private void fnActivarCargandoGif(SiticoneProgressIndicator gifBuscar, Boolean estado)
        {
            gifBuscar.AutoStart = estado;
            gifBuscar.Visible = estado;
        }

        private void fnHabilitarControles(Boolean pbHabilitar)
        {
            if (pbHabilitar == true) {
                gbDatosChip.BaseColor = Color.White;
                gbDatosChip.LineColor = Variables.ColorGroupBox;

                gbEstadoChip.BaseColor = Color.White;
                gbEstadoChip.LineColor = Variables.ColorGroupBox;

                gbFechasChip.BaseColor = Color.White;
                gbFechasChip.LineColor = Variables.ColorGroupBox;



                //dtFechaCompra.BaseColor = Color.White;
                //dtFechaCompra.ForeColor = Variables.ColorGroupBox;

                //dtFechaPago.BaseColor = Color.White;
                //dtFechaPago.ForeColor = Variables.ColorGroupBox;

                //dtFechaSuspencion.BaseColor = Color.White;
                //dtFechaSuspencion.ForeColor = Variables.ColorGroupBox;

                pbSimCard.BackColor = Color.Transparent;
                pbOperador.BackColor = Color.Transparent;

            }
            else
            {

                gbDatosChip.BaseColor = Variables.ColorDesactivado;
                gbDatosChip.LineColor = Variables.ColorGroupBoxDesactivado;

                gbEstadoChip.BaseColor = Variables.ColorDesactivado;
                gbEstadoChip.LineColor = Variables.ColorGroupBoxDesactivado;

                gbFechasChip.BaseColor = Variables.ColorDesactivado;
                gbFechasChip.LineColor = Variables.ColorGroupBoxDesactivado;



                //dtFechaCompra.BaseColor = Color.FromArgb(226, 226, 226); 
                //dtFechaCompra.ForeColor = Variables.ColorGroupBox;

                //dtFechaPago.BaseColor = Color.FromArgb(226, 226, 226);
                //dtFechaPago.ForeColor = Variables.ColorGroupBox;

                //dtFechaSuspencion.BaseColor = Color.FromArgb(226, 226, 226);
                //dtFechaSuspencion.ForeColor = Variables.ColorGroupBox;

                pbSimCard.BackColor = Color.FromArgb(226, 226, 226);
                pbOperador.BackColor = Color.FromArgb(226, 226, 226);

            }
            gbDatosChip.Enabled = pbHabilitar;
            gbEstadoChip.Enabled = pbHabilitar;
            gbFechasChip.Enabled = pbHabilitar;
            txtObservacion.Enabled = pbHabilitar;
            dtFechaSuspencion.Enabled = pbHabilitar;
            dtFechaBaja.Enabled = pbHabilitar;

            pbSimCard.Visible = pbHabilitar;
            pbEstado.Visible = pbHabilitar;
            pbOperador.Visible = pbHabilitar;
            pbFechaCompra.Visible = pbHabilitar;
            pbObservacion.Visible = pbHabilitar;

            pbFechaSuspencion.Visible = pbHabilitar;


            pbDiasSuspencion.Visible = pbHabilitar;
            pbFechaReactivacion.Visible = pbHabilitar;
            if (txtCantDias.Visible == false)
            {
                pbDiasSuspencion.Visible = false;
                pbFechaReactivacion.Visible = false;
            }
            else
            {
                pbDiasSuspencion.Visible = pbHabilitar;
                pbFechaReactivacion.Visible = pbHabilitar;
            }
            if (dtFechaSuspencion.Visible == false && dtFechaBaja.Visible == false)
            {
                pbFechaSuspencion.Visible = false;
            }

            else
            {
                pbFechaSuspencion.Visible = pbHabilitar;
            }


            FunValidaciones.fnHabilitarBoton(btnGuardar, pbHabilitar);
        }
        private void fnLimpiarControles()
        {
            txtidChip.Text = "0";
            Int32 itemsEtado = cboEstado.Items.Count;
            if (itemsEtado == 0)
            {
                cboEstado.SelectedIndex = -1;
            }
            else
            {
                cboEstado.SelectedIndex = 0;
            }
            cboOperador.SelectedValue = 0;
            txtSimCard.Text = "";
            txtSimcard2.Text = "";
            lblCantRegistros.Text = "";
            dtFechaCompra.Value = DateTime.Today;
            dtFechaSuspencion.Value = DateTime.Today;
            txtObservacion.Text = "";
            dgChip.Visible = false;

        }


        private Tuple<Boolean, String> fnValidarFecha(SiticoneDateTimePicker dtp, PictureBox img, Label lbl, String msj)
        {
            if (dtp.Name != "dtFechaReactivacion")
            {
                if ((dtp.Value > Variables.gdFechaSis.AddHours(2)))
                {
                    lbl.Text = msj;
                    lbl.ForeColor = Variables.ColorError;
                    dtp.HoveredState.BorderColor = Variables.ColorError;
                    img.Image = Properties.Resources.error;
                    estFechaCompra = false;
                    return Tuple.Create(false, msj);
                }
                else
                {
                    msj = "";
                    lbl.Text = msj;
                    img.Image = Properties.Resources.ok;
                    lbl.ForeColor = Variables.ColorSuccess;
                    dtp.HoveredState.BorderColor = Variables.ColorSuccess;
                    return Tuple.Create(true, msj);
                }
            }
            else
            {
                if (txtCantDias.Text == "0" || txtCantDias.Text == "00" || txtCantDias.Text == "000")
                {

                    lbl.Text = msj;
                    img.Image = Properties.Resources.error;
                    lbl.ForeColor = Variables.ColorError;
                    dtp.HoveredState.BorderColor = Variables.ColorError;
                    return Tuple.Create(false, msj);
                }
                else
                {
                    msj = "";
                    lbl.Text = msj;
                    img.Image = Properties.Resources.ok;
                    lbl.ForeColor = Variables.ColorSuccess;
                    dtp.HoveredState.BorderColor = Variables.ColorSuccess;
                    return Tuple.Create(true, msj);
                }
            }

        }
        public Tuple<Boolean, String> fnValidaDatosDuplicados(TextBox txt, Label lbl, PictureBox img, Boolean Existencia)
        {
            Boolean estad;
            String msj;
            if (Existencia == true)
            {
                img.Image = Properties.Resources.error;
                msj = "Esta placa ya existe  (Ingrese otro vehiculo)";

                lbl.Text = msj;
                estad = false;
                return Tuple.Create(estad, msj);

            }
            else
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                estad = true;
                return Tuple.Create(estad, msj);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void dtFechaCompra_ValueChanged_1(object sender, EventArgs e)
        {

            //    DateTime nuevaFecha = Convert.ToDateTime("2016-02-25 13:30:15");
            //nuevaFecha = nuevaFecha.AddDays(10);

        }
        public static Tuple<Boolean, String> fnValidarComboboxChips(SiticoneComboBox cbo, Label lbl, PictureBox img, String estadoActual, String validar, Int32 lntipoCondicion)
        {
            String msj = "";
            String datoSeleccionado = Convert.ToString(cbo.SelectedValue);
            Boolean estado = false;
            if (cbo.SelectedIndex == 0 || cbo.SelectedIndex == -1)
            {
                img.Image = Properties.Resources.error;
                lbl.ForeColor = Variables.ColorError;
                msj = "Seleccione una opción";
                lbl.Text = msj;
                return Tuple.Create(false, msj);

            }
            else
            {
                if (estadoActual == "ESCHI001")
                {
                    if (datoSeleccionado == estadoActual)
                    {
                        img.Image = Properties.Resources.ok;

                        lbl.ForeColor = Variables.ColorSuccess;
                        msj = "";
                        lbl.Text = msj;
                        estado = true;
                    }
                    else
                    {
                        img.Image = Properties.Resources.error;
                        lbl.ForeColor = Variables.ColorError;

                        msj = "No se puede dar de " + FunGeneral.FormatearCadenaTitleCase(cbo.Text) + ": Porque ya está asignado al equipo " + validar;
                        lbl.Text = msj;
                        estado = false;
                    }
                } else if (estadoActual == "ESCHI002")
                {
                    if ((datoSeleccionado == estadoActual) || (datoSeleccionado == "ESCHI004") || (datoSeleccionado == "ESCHI005") || (datoSeleccionado == "ESCHI006"))
                    {
                        img.Image = Properties.Resources.ok;
                        lbl.ForeColor = Variables.ColorSuccess;
                        msj = "";
                        lbl.Text = msj;
                        estado = true;
                    }
                    else
                    {
                        img.Image = Properties.Resources.error;
                        lbl.ForeColor = Variables.ColorError;

                        msj = validar != "" ? "No se puede cambiar a " + FunGeneral.FormatearCadenaTitleCase(cbo.Text) + ": Porque ya está asignado al equipo " + validar : "Seleccione otra opción => ESTADO RESTRINGIDO";
                        lbl.Text = msj;
                        estado = false;
                    }
                } else if (estadoActual == "ESCHI003")
                {
                    if (datoSeleccionado == "ESCHI001")
                    {
                        img.Image = Properties.Resources.error;
                        lbl.ForeColor = Variables.ColorError;

                        msj = validar != "" ? "No se puede cambiar a " + FunGeneral.FormatearCadenaTitleCase(cbo.Text) + ": Porque ya está asignado al equipo " + validar : "Seleccione otra opción => ESTADO RESTRINGIDO";
                        lbl.Text = msj;
                        estado = false;

                    }
                    else
                    {
                        img.Image = Properties.Resources.ok;
                        lbl.ForeColor = Variables.ColorSuccess;
                        msj = "";
                        lbl.Text = msj;
                        estado = true;
                    }

                } else if (estadoActual == "ESCHI004")
                {
                    if (datoSeleccionado == "ESCHI001" || validar != "")
                    {
                        img.Image = Properties.Resources.error;
                        lbl.ForeColor = Variables.ColorError;

                        msj = validar != "" ? "No se puede cambiar a " + FunGeneral.FormatearCadenaTitleCase(cbo.Text) + ": Porque ya está asignado al equipo " + validar : "Seleccione otra opción => ESTADO RESTRINGIDO";
                        lbl.Text = msj;
                        estado = false;
                    }
                    else
                    {
                        img.Image = Properties.Resources.ok;
                        lbl.ForeColor = Variables.ColorSuccess;
                        msj = "";
                        lbl.Text = msj;
                        estado = true;
                    }

                } else if (estadoActual == "ESCHI005")
                {
                    if (datoSeleccionado == "ESCHI001" || validar != "")
                    {
                        img.Image = Properties.Resources.error;
                        lbl.ForeColor = Variables.ColorError;

                        msj = validar != "" ? "No se puede cambiar a " + FunGeneral.FormatearCadenaTitleCase(cbo.Text) + ": Porque ya está asignado al equipo " + validar : "Seleccione otra opción => ESTADO RESTRINGIDO";
                        lbl.Text = msj;
                        estado = false;
                    }
                    else
                    {
                        img.Image = Properties.Resources.ok;
                        lbl.ForeColor = Variables.ColorSuccess;
                        msj = "";
                        lbl.Text = msj;
                        estado = true;
                    }

                }
                else if (estadoActual == "ESCHI006")
                {
                    if (datoSeleccionado == estadoActual)
                    {
                        img.Image = Properties.Resources.ok;
                        lbl.ForeColor = Variables.ColorSuccess;
                        msj = "";
                        lbl.Text = msj;
                        estado = true;
                    }
                    else
                    {
                        img.Image = Properties.Resources.error;
                        lbl.ForeColor = Variables.ColorError;

                        msj = "Seleccione otra opción => ESTADO RESTRINGIDO";
                        lbl.Text = msj;
                        estado = false;
                    }

                }
                else
                {
                    img.Image = Properties.Resources.ok;

                    lbl.ForeColor = Variables.ColorSuccess;
                    msj = "";
                    lbl.Text = msj;
                    estado = true;

                }

                return Tuple.Create(estado, msj);
            }
        }

        private void fnMosatrarFechasPorEstado()
        {

            if (Convert.ToString(cboEstado.SelectedValue) == "ESCHI005")
            {
                //dtFechaSuspencion.Location = new Point(423, 370);
                dtFechaSuspencion.Enabled = true;
                dtFechaSuspencion.Visible = true;
                lblFehaPago_O_suapencion.Text = "Fecha de suspencion";

                lblFehaPago_O_suapencion.Visible = true;
                pbFechaSuspencion.Visible = true;

                dtFechaReactivacion.Enabled = false;
                dtFechaReactivacion.Visible = true;
                lblFechaReactivacion.Visible = true;


                txtCantDias.Enabled = true;
                txtCantDias.Visible = true;
                lblDiasSuspencion.Visible = true;

                pbDiasSuspencion.Visible = true;
                pbFechaReactivacion.Visible = true;


            }
            else if (Convert.ToString(cboEstado.SelectedValue) == "ESCHI002")
            {
                dtFechaBaja.Location = new Point(423, 370);
                dtFechaBaja.Enabled = true;
                dtFechaBaja.Visible = true;
                lblFehaPago_O_suapencion.Text = "Fecha de baja";
                lblFehaPago_O_suapencion.Visible = true;
                pbFechaSuspencion.Visible = true;

                pbDiasSuspencion.Visible = false;
                pbFechaReactivacion.Visible = false;

                dtFechaSuspencion.Enabled = false;
                dtFechaSuspencion.Visible = false;

                dtFechaReactivacion.Enabled = false;
                dtFechaReactivacion.Visible = false;
                lblFechaReactivacion.Visible = false;

                txtCantDias.Enabled = false;
                txtCantDias.Visible = false;
                lblDiasSuspencion.Visible = false;

            }
            else
            {
                dtFechaSuspencion.Enabled = false;
                dtFechaSuspencion.Visible = false;
                lblFehaPago_O_suapencion.Visible = false;
                pbFechaSuspencion.Visible = false;

                txtCantDias.Enabled = false;
                txtCantDias.Visible = false;
                lblDiasSuspencion.Visible = false;

                pbDiasSuspencion.Visible = false;
                pbFechaReactivacion.Visible = false;

                dtFechaReactivacion.Enabled = false;
                dtFechaReactivacion.Visible = false;
                lblFechaReactivacion.Visible = false;

                dtFechaBaja.Enabled = false;
                dtFechaBaja.Visible = false;
                lblFehaPago_O_suapencion.Visible = false;
                pbFechaSuspencion.Visible = false;

            }

        }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargoForm == true)
            {
                var result = fnValidarComboboxChips(cboEstado, lblEstado, pbEstado, Convert.ToString(txtEstadoActual.Text), Convert.ToString(txtImeiEquipo.Text), lnTipoCon);
                estEstado = result.Item1;
                msjEstado = result.Item2;
                fnMosatrarFechasPorEstado();
            }





        }


        private void txtNumeroRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", true);
        }


        private void txtSimCard_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtSimCard, lblSimcard, pbSimCard, true, true, true, 9, 9, 9, 9, "Complete el numero SimCar");
            estSimCard = resultado.Item1;
            msjSimCard = resultado.Item2;

            if (txtSimCard.Text.Length == 9)
            {
                Int32 result = 0;
                result = FunGeneral.fnValidarDatosExistentes(txtSimCard.Text.Trim(), txtSimcard2.Text.Trim(), 0, "uspValidarSimCard");
                if (result == 1)
                {
                    var res = FunValidaciones.fnValidarElementoExistente(txtSimCard, lblSimcard, pbSimCard, 9, 1, "El SimCard ya existe ingrese otro");
                    estSimCard = res.Item1;
                    msjSimCard = res.Item2;
                    MessageBox.Show("El numero de SimCard ya existe ingrese otro", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                else
                {
                    var res = FunValidaciones.fnValidarElementoExistente(txtSimCard, lblSimcard, pbSimCard, 9, 0, "");
                    estSimCard = res.Item1;
                    msjSimCard = res.Item2;
                }
            }





        }

        private void txtSimCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", true);
        }

        private void txtOperador_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true);

        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", false);
        }




        private void btnNuevo_Click(object sender, EventArgs e)
        {
            fnLimpiarControles();
            fnHabilitarControles(true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            pbFechaSuspencion.Visible = false;

            lnTipoCon = 0;

            cboOperador.SelectedIndex = 5;
            cboEstado.SelectedValue = "ESCHI003";

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            fnHabilitarControles(true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnNuevo, true);


        }

        private void gbFechasChip_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaCompra_Click(object sender, EventArgs e)
        {

        }




        private void txtSimcard2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboOperador, lblOperador, pbOperador);
            estOperador = result.Item1;
            msjOperador = result.Item2;
        }

        private void dtFechaCompra_ValueChanged(object sender, EventArgs e)
        {
            var result = fnValidarFecha(dtFechaCompra, pbFechaCompra, lblFechaCompra, "La fecha de compra no puede ser mayor a la fecha actual");
            estFechaCompra = result.Item1;
            msjFechaCompra = result.Item2;
        }

        private void dtFechaSuspencion_ValueChanged_1(object sender, EventArgs e)
        {
            var result = fnValidarFecha(dtFechaSuspencion, pbFechaSuspencion, lblFechaSuspencion, "La fecha de suspencion no puede ser mayor a la fecha actual");
            estFechaSuspencion = result.Item1;
            msjFechaSuspencion = result.Item2;

            fnSumarFechaActivacion();
        }

        private void pbFechaSuspencion_Click(object sender, EventArgs e)
        {

        }

        private void rbSimCard_CheckedChanged(object sender, EventArgs e)
        {
            Int16 pnTipocon = 0;
            String valorComboBuscar;

            if (rbSimCard.Checked == true)
            {
                pnTipocon = 0;

            }
            else if (rbRecibo.Checked == true)
            {
                pnTipocon = 1;
            }
            valorComboBuscar = cboBuscarEstado.SelectedValue.ToString();

            //else if (rbEstado.Checked==true)
            //{
            //    pnTipocon = 3;
            //}

            fnHabilitarControles(false);

        }

        private void rbCiclo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbRecibo_CheckedChanged(object sender, EventArgs e)
        {
            Int16 pnTipocon = 0;
            String valorComboBuscar;

            if (rbSimCard.Checked == true)
            {
                pnTipocon = 0;

            }
            else if (rbRecibo.Checked == true)
            {
                pnTipocon = 1;
            }

            valorComboBuscar = cboBuscarEstado.SelectedValue.ToString();

            //else if (rbEstado.Checked==true)
            //{
            //    pnTipocon = 3;
            //}

            fnHabilitarControles(false);

        }

        private void txtCantDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", true);
        }

        private void txtCantDias_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtCantDias, lblDiasSuspen, pbDiasSuspencion, true, true, true, 1, 3, 3, 3, "Complete el numero SimCar");
            estDiasSuspencion = resultado.Item1;
            msjDiasSuspencion = resultado.Item2;
            fnSumarFechaActivacion();


        }

        private void fnSumarFechaActivacion()
        {
            if (txtCantDias.Text.Length > 0)
            {
                DateTime fechaSuspencion = dtFechaSuspencion.Value.AddDays(Convert.ToInt32(txtCantDias.Text));
                dtFechaReactivacion.Value = fechaSuspencion;
            }

        }

        private void cboBuscarEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargoForm == true)
            {
                lnTipoCon = 0;

                fnBuscarEquipo(0, -1);
                fnHabilitarControles(false);
            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgChip_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].HeaderText == "FECHA DE REACTIVACIÓN")  //Si es la columna a evaluar
            {
                e.CellStyle.Font = new Font("Microsoft Sans Serif", 11);
                if (e.Value.ToString().Length > 44)   //Si el valor de la celda contiene la palabra hora
                {
                    e.CellStyle.ForeColor = Variables.ColorError;
                } else if (e.Value.ToString().Length > 37 && e.Value.ToString().Length < 42)
                {
                    e.CellStyle.ForeColor = Variables.ColorSuccess;

                }
                else if (e.Value.ToString().Length > 41 && e.Value.ToString().Length < 45)
                {
                    e.CellStyle.ForeColor = Color.Goldenrod;
                }
            }
        }


        private void btnOperaciones_Click(object sender, EventArgs e)
        {
            pcTipoOperacion = "PAGAR";

            fnHabilitarControles(false);

            FunValidaciones.fnHabilitarBoton(btnNuevo, false);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, true);
        }

        private void dtFechaReactivacion_ValueChanged(object sender, EventArgs e)
        {
            var result = fnValidarFecha(dtFechaReactivacion, pbFechaReactivacion, lblFechaReactivacionMsj, "Los dias de suspencion deben ser mayor a cero");
            estFechaReactivacion = result.Item1;
            msjFechaReactivacion = result.Item2;
            lblDiasSuspen.Text = result.Item2;
            lblDiasSuspen.ForeColor = Variables.ColorError;
        }

        private void btnChipsPagados_Click(object sender, EventArgs e)
        {
            Int16 pnTipocon = 4;
            String valorComboBuscar = cboBuscarEstado.SelectedValue.ToString();
            //fnBuscarEquipo(txtBuscarChip.Text.Trim(), pnTipocon,valorComboBuscar);
        }

        private void btnChipsPorPagar_Click(object sender, EventArgs e)
        {
            Int16 pnTipocon = 5;
            String valorComboBuscar = cboBuscarEstado.SelectedValue.ToString();
            //fnBuscarEquipo(txtBuscarChip.Text.Trim(), pnTipocon,valorComboBuscar);
        }

        private void cboPaginacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estadoBusqPaginas == true)
            {
                fnBuscarEquipo(Convert.ToInt32(cboPaginacion.Text), -2);
                fnHabilitarControles(false);
            }

        }
        private DateTime fnCalcularSoloFecha(DateTime fecha)
        {
            String TextSoloFecha = fecha.ToString("yyyy/MM/dd");
            DateTime dtFecha = Convert.ToDateTime(TextSoloFecha);
            return dtFecha;
        }
        private void fnMostrarDatosImei(SiticoneGroupBox gb, Boolean estado, Label lbl, String sms, Boolean estLabel)
        {
            gb.Visible = estado;
            lbl.Visible = estLabel;
            lbl.Text = sms;
        }

        private Boolean fnBuscarHistorialSimCard(Int32 pagina, Int32 tipoCon)
        {
            BLOperador objSimCard = new BLOperador();
            Boolean pbhabilitaLista = false;
            clsUtil objUtil = new clsUtil();
            DataTable datEquipo = new DataTable();
            ListViewItem lstItem = null;
            Boolean HabilitarFechas;
            Int32 totalResultados;
            Int32 filas = 15;
            try
            {
                DateTime fechaInicio = fnCalcularSoloFecha(dtHFechaInicio.Value);
                DateTime fechaFinal = fnCalcularSoloFecha(dtHfechaFinal.Value).AddDays(1);
                HabilitarFechas = Convert.ToBoolean(chkHabilitarFechas.Checked);
                dgHistorial.Rows.Clear();
                datEquipo = objSimCard.blBuscarHistorialSimCard(txtBuscarXSimCard.Text.ToString(), HabilitarFechas, fechaInicio, fechaFinal, pagina, tipoCon);

                //FunValidaciones.fnMostrarCantidadBusquedas(btnContadorRegistros, lblCantRegistros, datEquipo.Rows.Count, true, "Cantidad de registros");
                totalResultados = Convert.ToInt32(datEquipo.Rows.Count);
                if (datEquipo.Rows.Count > 0)
                {
                    String Cuenta = "";
                    String Imei = "";
                    String NumDias = "";
                    lblMsgHistorial.Text = "";

                    Int32 y;

                    if (tipoCon == -1)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (pagina - 1) * filas;
                        y = tabInicio;
                    }

                    foreach (DataRow drMenu in datEquipo.Rows)
                    {

                        String dateRegistro = Convert.ToString(drMenu["dFechaRegistro"]);
                        String dateCompra = Convert.ToString(drMenu["dFechaCompra"]);
                        String dateSuspecion = Convert.ToString(drMenu["dFechaSuspencion"]);
                        String dateReactivacion = Convert.ToString(drMenu["dFechaReactivacion"]);
                        String dateBaja = Convert.ToString(drMenu["dFechaBaja"]);

                        if (dateRegistro == "" || dateRegistro == null) { dateRegistro = ""; } else { DateTime fecha = Convert.ToDateTime(dateRegistro); dateRegistro = fecha.ToString("dd, MMM yyyy"); }
                        if (dateCompra == "" || dateCompra == null) { dateCompra = ""; } else { DateTime fechaC = Convert.ToDateTime(dateCompra); dateCompra = fechaC.ToString("dd, MMM yyyy"); }
                        if (dateSuspecion == "" || dateSuspecion == null) { dateSuspecion = ""; } else { DateTime fecha = Convert.ToDateTime(dateRegistro); dateRegistro = fecha.ToString("dd, MMM yyyy"); }
                        if (dateReactivacion == "" || dateReactivacion == null) { dateReactivacion = ""; } else { DateTime fecha = Convert.ToDateTime(dateReactivacion); dateReactivacion = fecha.ToString("dd, MMM yyyy"); }
                        if (dateBaja == "" || dateBaja == null) { dateBaja = ""; } else { DateTime fecha = Convert.ToDateTime(dateBaja); dateBaja = fecha.ToString("dd, MMM yyyy"); }

                        if (Convert.ToInt32(drMenu["numeroRecibo"]) == 0)
                        {
                            Cuenta = "Sin cuenta ⚠️";
                        }
                        else
                        {
                            Cuenta = Convert.ToString(drMenu["numeroRecibo"]) + " ✔";
                        }

                        if (Convert.ToString(drMenu["Imei"]) == "" || Convert.ToString(drMenu["Imei"]) == null)
                        {
                            Imei = "Sin Equipo ⚠️";
                        }
                        else
                        {
                            Imei = Convert.ToString(drMenu["Imei"]);
                        }

                        if (Convert.ToInt32(drMenu["numDias"]) == 0)
                        {
                            NumDias = "";
                        }
                        else
                        {
                            NumDias = Convert.ToString(drMenu["numDias"]);
                        }
                        dgHistorial.Rows.Add(
                            Convert.ToString(Imei),
                            Convert.ToString(drMenu["cNombre"]),
                            Convert.ToString(Cuenta),
                            Convert.ToString(drMenu["cNomTab"]),
                            Convert.ToString(drMenu["Observacion"]),
                            Convert.ToString(dateRegistro),
                            Convert.ToString(dateCompra),
                            Convert.ToString(dateSuspecion),
                            Convert.ToString(dateReactivacion),
                            Convert.ToString(dateBaja),
                            Convert.ToString(NumDias),
                            Convert.ToString(drMenu["PERSONAL"]));
                    }

                    if (tipoCon == -1)
                    {
                        cboPagina.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datEquipo.Rows[0][12]);
                        fnCalcularPaginacion(totalRegistros, filas, totalResultados);
                    }
                    else
                    {
                        btnNumFilas.Text = Convert.ToString(totalResultados);
                    }
                }
                else
                {
                    dgHistorial.Rows.Clear();

                    lblMsgHistorial.Text = "No se encontraron resultados para la busqueda";
                }


                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
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

            if (tabSimCard.SelectedIndex == 0)
            {
                cboPaginacion.Items.Clear();

                for (Int32 i = 1; i <= cantidadPaginas; i++)
                {
                    cboPaginacion.Items.Add(i);

                }

                btnTotalPaginas.Text = Convert.ToString(cantidadPaginas);
                btnCantRegistros.Text = Convert.ToString(totalResultados);
                btnCantTotalRegistros.Text = Convert.ToString(totalRegistros);
                cboPaginacion.SelectedIndex = 0;
            }
            else
            {
                cboPagina.Items.Clear();

                for (Int32 i = 1; i <= cantidadPaginas; i++)
                {
                    cboPagina.Items.Add(i);

                }

                cboPagina.SelectedIndex = 0;
                estadoBusqPaginas = false;
                btnCantPaginas.Text = Convert.ToString(cantidadPaginas);
                btnNumFilas.Text = Convert.ToString(totalResultados);
                btnTotalRegistros.Text = Convert.ToString(totalRegistros);
            }



        }
        private void txtBuscarXSimCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                string nobreTab = tbcDatos.SelectedTab.Name;

                if (txtBuscarXSimCard.Text.Length == 9)
                {
                    if (nobreTab == "DatosActuales".ToString())
                    {
                    }
                    else
                    {
                        fnBuscarHistorialSimCard(0, -1);
                    }
                }
                else
                {
                    if (dgHistorial.Rows.Count > 0)
                    {
                        dgHistorial.Rows.Clear();
                    }
                    lblMsgHistorial.Text = "Ingrese sim card correctamente => 9 dijitos";
                }
            }
        }

        private void txtBuscarXSimCard_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private String fnGuardarChip(Int32 idTipoCon)
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLOperador blobjEquipo = new BLOperador();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            SimCard objOperador = new SimCard();
            try
            {
                objOperador.idChip = Convert.ToInt32(txtidChip.Text.Trim());
                objOperador.simCard = Convert.ToInt32(txtSimCard.Text.Trim());
                objOperador.idOperador = Convert.ToInt32(cboOperador.SelectedValue);
                objOperador.idEstado = Convert.ToString(cboEstado.SelectedValue);
                objOperador.dFechaCompra = dtFechaCompra.Value;


                String feSuspencion = "";
                String feReactivacion = "";
                String feBaja = "";

                if (Convert.ToString(cboEstado.SelectedValue) == "ESCHI005")
                {
                    DateTime fechaSuspencion = Convert.ToDateTime(dtFechaSuspencion.Value);
                    feSuspencion = fechaSuspencion.ToString("yyyy-MM-dd");

                    DateTime fechaReactivacion = Convert.ToDateTime(dtFechaReactivacion.Value);
                    feReactivacion = fechaReactivacion.ToString("yyyy-MM-dd");

                    objOperador.dFechaSuspencion = Convert.ToString(feSuspencion);
                    objOperador.dFechaReactivacion = Convert.ToString(feReactivacion);

                    objOperador.dFechaBaja = "";

                    objOperador.rNumeroDias = Convert.ToInt32(txtCantDias.Text.Trim());

                } else if (Convert.ToString(cboEstado.SelectedValue) == "ESCHI002")
                {
                    DateTime fechaBaja = Convert.ToDateTime(dtFechaBaja.Value);
                    feBaja = fechaBaja.ToString("yyyy-MM-dd");
                    objOperador.dFechaBaja = Convert.ToString(feBaja);
                    objOperador.dFechaSuspencion = "";
                    objOperador.dFechaReactivacion = "";
                    objOperador.rNumeroDias = 0;
                }
                else
                {
                    objOperador.dFechaSuspencion = "";
                    objOperador.dFechaReactivacion = "";
                    objOperador.dFechaBaja = "";
                    objOperador.rNumeroDias = 0;
                }

                objOperador.observacion = Convert.ToString(txtObservacion.Text.Trim());
                objOperador.dFechaReg = dFechaSis;
                objOperador.idUsuario = Variables.gnCodUser;

                lcValidar = blobjEquipo.blGrabarChip(objOperador, idTipoCon).Trim();

                fnLimpiarControles();
                fnHabilitarControles(false);
                FunValidaciones.fnHabilitarBoton(btnGuardar, false);
                FunValidaciones.fnHabilitarBoton(btnEditar, false);
                FunValidaciones.fnHabilitarBoton(btnNuevo, true);
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnGuardarEquipo", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private void btnNuevoHistorial_Click(object sender, EventArgs e)
        {
            txtBuscarXSimCard.Text = "";
            dgHistorial.Rows.Clear();
        }

        private void txtBuscarXSimCard_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkHistorial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtBuscarXSimCard.Text = txtSimCard.Text;
            tabSimCard.SelectedIndex = 1;
            fnBuscarHistorialSimCard(0, -1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblClaseV_Click(object sender, EventArgs e)
        {

        }

        private void tbcDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nobreTab = tbcDatos.SelectedTab.Name;

            if (txtBuscarXSimCard.Text.Length == 9)
            {
                if (nobreTab == "DatosActuales".ToString())
                {
                    //fnBuscarDatosActualesMSimCard();
                }
                else
                {
                    fnBuscarHistorialSimCard(0, -1);
                }
            }
            else
            {
                if (dgHistorial.Rows.Count > 0)
                {
                    dgHistorial.Rows.Clear();
                }
                lblMsgHistorial.Text = "Ingrese sim card correctamente => 9 dijitos";
            }
        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarHistorialSimCard(Convert.ToInt32(cboPagina.Text), -2);
        }

        private void chkHabilitarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFechas.Checked == true)
            {
                dtHFechaInicio.Enabled = true;
                dtHfechaFinal.Enabled = true;
            }
            else
            {
                dtHFechaInicio.Enabled = false;
                dtHfechaFinal.Enabled = false;
            }
            fnBuscarHistorialSimCard(Convert.ToInt32(cboPagina.Text), -1);
        }

        private void dtHFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            //fnBuscarHistorialSimCard(Convert.ToInt32(cboPagina.Text), -1);
        }

        private void dtHfechaFinal_ValueChanged(object sender, EventArgs e)
        {
            //fnBuscarHistorialSimCard(Convert.ToInt32(cboPagina.Text), -1);
        }
        private Boolean fnListarHistorial(SiticoneDataGridView dgv)
        {
            BLProspecto objAcc = new BLProspecto();
            ProspectosPlan lstPros = new ProspectosPlan();
            DataTable dtAccesorio = new DataTable();
            clsUtil objUtil = new clsUtil();
            String Imei = "";
            String Simcard = "";
            try
            {

                Simcard = Convert.ToString(dgv.Rows[dgv.CurrentRow.Index].Cells[1].Value.ToString());
                txtBuscarXSimCard.Text = Simcard;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;
            }
        }
        private void opcHistorial_Click(object sender, EventArgs e)
        {
            fnListarHistorial(dgChip);
            tabSimCard.SelectedIndex = 1;
            fnBuscarHistorialSimCard(0, -1);
        }

        private void cboBusqOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargoForm == true)
            {
                lnTipoCon = 0;

                fnBuscarEquipo(0, -1);
                fnHabilitarControles(false);
            }


        }

        private void rbSimCard_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void txtObservacion_TextChanged_1(object sender, EventArgs e)
        {
            //if (lnTipoCon==1)
            //{
            //    var resultado = FunValidaciones.fnValidarTexboxs(txtObservacion, lblObservacion, pbObservacion, true, true,true, 15, 200, 200, 200, "Describa correctamente el/los cambios realizados");
            //    estObservaciones = resultado.Item1;
            //    msjObservaciones = resultado.Item2;
            //}
            //else
            //{
            var resultado = FunValidaciones.fnValidarTexboxs(txtObservacion, lblObservacion, pbObservacion, false, true, false, 0, 0, 0, 200, "Ingrese observacion valida");
            estObservaciones = resultado.Item1;
            msjObservaciones = resultado.Item2;
            //}

        }

        private void dgChip_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbRecibo_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private Boolean fnLlenarOperador(SiticoneComboBox combo, Int32 condicion)
        {
            BLOperador objCate_Marca_Mod = new BLOperador();
            clsUtil objUtil = new clsUtil();
            List<SimCard> lstcategoria = new List<SimCard>();

            try
            {
                lstcategoria = objCate_Marca_Mod.blDevolverOperador(0, condicion);
                combo.ValueMember = "idOperador";
                combo.DisplayMember = "cNomperador".Trim().ToString();
                combo.DataSource = lstcategoria;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
           // if (e.KeyChar == (Char)Keys.Enter)
           // {
                //fnObtenerPaginacionEquipos(valorComboBuscar,lnTipoCon , txtBuscarChip.Text);
                fnBuscarEquipo(0, -1);

               //fnHabilitarControles(false);
           // }
        }

        private void fnColorBotonEsp(SiticoneButton btnNuevo)
        {
            btnNuevo.FillColor = Color.White;
            btnNuevo.BorderColor = Variables.ColorEmpresa;
            btnNuevo.ForeColor = Variables.ColorEmpresa;
            btnNuevo.Image = Properties.Resources.nuevo_base;

            btnNuevo.HoveredState.FillColor = Variables.ColorEmpresa;
            btnNuevo.HoveredState.Image = Properties.Resources.nuevo_hover;
            btnNuevo.HoveredState.ForeColor = Color.White;
        }
        private void frmOperador_Load(object sender, EventArgs e)
        {
            Boolean bResult = false;
            cargoForm = false;
            try
            {
                dtFechaCompra.Value = Variables.gdFechaSis;
                dtFechaSuspencion.Value = Variables.gdFechaSis;

                dtHfechaFinal.Value = Variables.gdFechaSis;
                txtObservacion.MaxLength = 5;
                fnHabilitarControles(false);

                bResult = FunGeneral.fnLlenarTablaCod(cboEstado, "ESCHI");

                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar TablaCod - Estado de chips", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                bResult = fnLlenarOperador(cboBusqOperador, 1);
                if (!bResult)
                {
                    MessageBox.Show("Error al cargar buscar por operador", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                bResult = fnLlenarOperador(cboOperador, 0);
                if (!bResult)
                {
                    MessageBox.Show("Error al cargar operador", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                FunValidaciones.fnColorBotones(btnNuevo, btnEditar, btnGuardar, btnSalir);
                fnColorBotonEsp(btnNuevoHistorial);


                if (lnTipoLlamada == 1)
                {
                    fnOcultarDtosTipoLlamada();

                }
                else if (lnTipoLlamada == 2)
                {
                    fnOcultarDtosTipoLlamada();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cargoForm = true;
            }

        }

        private void fnOcultarDtosTipoLlamada()
        {

            fnHabilitarBotones(false);
            this.Text = "Buscar SimCard";
            this.Width = 1000;
            pnRegistrarChip.Width = 980;
            this.StartPosition = FormStartPosition.CenterScreen;
            rbRecibo.Visible = false;

            cboBuscarEstado.Enabled = false;
            cboBuscarEstado.Visible = false;
            lblEstadoTitle.Visible = false;

            rbOperador.Height = 74;
            rbOperador.Location = new Point(31, 10);

            gbPaginas.Location = new Point(460, 10);
            gbRegistros.Location = new Point(715, 10);


            txtBuscarChip.Location = new Point(17, 80);
            txtBuscarChip.Width = 935;

            pbSearch.Location = new Point(21, 85);


            gbDatosChip.Visible = false;
            gbFechasChip.Visible = false;

            gbEstadoChip.Visible = false;

            txtObservacion.Visible = false;
            lblDescrip.Visible = false;

            dgChip.Location = new Point(10, 121);
            dgChip.Height = 472;
            dgChip.Width = 950;
            btnSalir.Visible = false;

            dgHistorial.Height = 472;
            dgHistorial.Width = 950;

            //else if (rbEstado.Checked == true)
            //{
            //    pnTipocon = 3;
            //}
            String valorComboBuscar = "ESCHI003";
        }

        private void fnBuscarSimCardTipoLLamada(DataTable dTtable)
        {
            if (dTtable.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("SIMCARD");
                dt.Columns.Add("OPERADOR");
                dt.Columns.Add("ESTADO");

                for (int i = 0; i <= dTtable.Rows.Count - 1; i++)
                {
                    object[] row = { dTtable.Rows[i][0],
                                     dTtable.Rows[i][1],
                                     dTtable.Rows[i][2],
                                     dTtable.Rows[i][4] };
                    dt.Rows.Add(row);

                }
                dgChip.DataSource = dt;

                if (Convert.ToString(btnCantTotalRegistros.Text) != "0")
                {
                    btnCantRegistros.Text = Convert.ToString(dTtable.Rows.Count);
                }
                else
                {
                    btnCantRegistros.Text = "0";
                }
                dgChip.Columns[0].Width = 12;
                dgChip.Columns[1].Width = 100;
                dgChip.Columns[2].Width = 100;
                dgChip.Columns[3].Width = 200;
                dgChip.Visible = true;
                lblCantRegistros.Visible = true;

            }
            else
            {
                dgChip.Visible = false;
            }

        }
        Int32 tipoReactivacion = 0;
        public Boolean fnBuscarEquipo(Int32 pagina, Int32 tipoConPagina)
        {
            BLOperador objEquipo = new BLOperador();
            clsUtil objUtil = new clsUtil();
            DataTable datOperador = new DataTable();
            List<SimCard> lstEquipo = null;
            Int32 filas = 20;


            try
            {
                Int16 pnTipocon = 0;
                String ComboEstado = "";
                Int32 ComboOperador = 0;

                if (rbSimCard.Checked == true) { pnTipocon = 0; } else
                if (rbRecibo.Checked == true) { pnTipocon = 1; }

                if (lnTipoLlamada == 0)
                {
                    ComboEstado = cboBuscarEstado.SelectedValue.ToString();
                    ComboOperador = Convert.ToInt32(cboBusqOperador.SelectedValue);
                }
                else
                {
                    ComboEstado = "ESCHI003";
                    ComboOperador = Convert.ToInt32(cboBusqOperador.SelectedValue);
                }
                lstEquipo = new List<SimCard>();
                //lstEquipo = objEquipo.blBuscarEquipo(pcBuscar, pnTipoCon);
                if (lnTipoLlamada == 1)
                {
                    datOperador = objEquipo.blBuscarSimCardDatatable(txtBuscarChip.Text.Trim(), ComboEstado, ComboOperador, pagina, tipoConPagina, pnTipocon);

                    fnBuscarSimCardTipoLLamada(datOperador);
                    return true;
                }
                else
                {


                    datOperador = objEquipo.blBuscarSimCardDatatable(txtBuscarChip.Text.Trim(), ComboEstado, ComboOperador, pagina, tipoConPagina, pnTipocon);
                    //dgEquipo.DataSource = datEquipo;

                    Int32 totalResultados = datOperador.Rows.Count;
                    DataTable dt = new DataTable();
                    if (datOperador.Rows.Count > 0)
                    {
                        dt.Clear();
                        dt.Columns.Add("ID");
                        dt.Columns.Add("SIMCARD");
                        dt.Columns.Add("OPERADOR");
                        dt.Columns.Add("N° DE CUENTA");
                        dt.Columns.Add("FECHA DE REACTIVACIÓN");
                        dt.Columns.Add("ESTADO");

                        //DataGridViewButtonCell celBoton = this.dgChip.Rows[e.RowIndex].Cells["colBotones"] as DataGridViewButtonCell;
                        //Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"Atomico.ico");
                        //e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                        Int32 numDias = 0;

                        Int32 y;

                        if (tipoConPagina == -1)
                        {
                            y = 0;
                        }
                        else
                        {
                            tabInicio = (pagina - 1) * filas;
                            y = tabInicio;
                        }

                        String Cuenta = "";
                        for (int i = 0; i <= datOperador.Rows.Count - 1; i++)
                        {
                            if (Convert.ToInt32(datOperador.Rows[i][3]) == 0)
                            {
                                Cuenta = "Sin cuenta ⚠️";
                            }
                            else
                            {
                                Cuenta = Convert.ToString(datOperador.Rows[i][3]) + " ✔";
                            }

                            String date = Convert.ToString(datOperador.Rows[i][4]);
                            String diferenciaDias = "";
                            if (date == "" || date == null)
                            {
                                date = "";
                                diferenciaDias = "";
                            }
                            else
                            {

                                DateTime fecha = Convert.ToDateTime(date);
                                date = fecha.ToString("dd, MMM yyyy");

                                TimeSpan ts = fecha - Variables.gdFechaSis;

                                if (Convert.ToInt32(ts.Days) < 5 && Convert.ToInt32(ts.Days) > -1)
                                {
                                    tipoReactivacion = 1;
                                    diferenciaDias = " Activacion en ( " + Convert.ToString(ts.Days) + " ) dias ⚠️   ";

                                }
                                else if (fecha < Variables.gdFechaSis)
                                {
                                    tipoReactivacion = 2;
                                    TimeSpan tssuma = Variables.gdFechaSis - fecha;
                                    diferenciaDias = " Activacion retraso ( " + Convert.ToString(tssuma.Days) + " ) dias ❌";
                                }
                                else
                                {

                                    tipoReactivacion = 0;
                                    diferenciaDias = " Activacion en ( " + Convert.ToString(ts.Days) + " ) dias";


                                }



                            }

                            object[] row = { datOperador.Rows[i][0],
                                            datOperador.Rows[i][1],
                                            datOperador.Rows[i][2],
                                            Cuenta,
                                            date+diferenciaDias ,
                                            datOperador.Rows[i][5],

                                        };
                            dt.Rows.Add(row);

                        }
                        dgChip.DataSource = dt;

                        dgChip.Columns[0].Width = 12;
                        dgChip.Columns[1].Width = 30;
                        dgChip.Columns[2].Width = 30;
                        dgChip.Columns[3].Width = 35;
                        dgChip.Columns[4].Width = 35;
                        dgChip.Columns[5].Width = 100;

                        Int32 totalRegistros = Convert.ToInt32(datOperador.Rows[0][7]);
                        if (tipoConPagina == -1) {
                            cboPagina.Visible = true;
                            fnCalcularPaginacion(totalRegistros, filas, totalResultados);
                            estadoBusqPaginas = true;
                        }
                        else
                        {
                            if (tabSimCard.SelectedIndex == 0)
                            {
                                btnCantRegistros.Text = Convert.ToString(totalResultados);
                                btnCantTotalRegistros.Text = Convert.ToString(totalRegistros);

                            }
                            else
                            {
                                btnTotalRegistros.Text = Convert.ToString(totalRegistros);
                                btnNumFilas.Text = Convert.ToString(totalResultados);
                            }
                        }

                        dgChip.Visible = true;
                        lblCantRegistros.Visible = true;


                    }
                    else
                    {
                        dgChip.Visible = true;
                        dt.Clear();
                        dt.Columns.Add("NO SE ENCONTRARON DATOS PARA LA BUSQUEDA");
                        dgChip.DataSource = dt;

                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private void fnColores(DataGridViewCellFormattingEventArgs e)
        {

        }
        private Boolean fnRecuperarChipEsp(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {

                if (dgChip.Rows.Count > 0)
                {
                    //ListView.SelectedListViewItemCollection item = lvCliente.SelectedItems;

                    //frmDocumentoVenta.fnRecuperarCliente(item[0].Text.Trim(), item[0].SubItems[4].Text.ToString().Trim(), item[0].SubItems[3].Text.ToString().Trim(), item[0].SubItems[2].Text.ToString().Trim(), 1);
                    frmAdministrarEquipos.fnRecuperarSimcard(Convert.ToInt32(dgChip.Rows[e.RowIndex].Cells[0].Value), Convert.ToInt32(dgChip.Rows[e.RowIndex].Cells[1].Value), 1);
                }

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnRecuperarClienteEsp", ex.Message);
                return false;
            }
        }
        private Boolean fnRecuperaSimCardReac(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                if(dgChip.Rows.Count > 0)
                {
                    frmReactivaciones.fnRecuperarSimCard(Convert.ToInt32(dgChip.Rows[e.RowIndex].Cells[0].Value), Convert.ToInt32(dgChip.Rows[e.RowIndex].Cells[1].Value), 1);
                }
                return true;
            }
            catch(Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCLienes", "fnRecuperarSimCard", ex.Message);
                return false;
            }
        }



        private void btnAdministraChip_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAdministrarChips chips = new frmAdministrarChips();
            chips.ShowDialog();

        }

        private void pnRegistrarChip_Click(object sender, EventArgs e)
        {
            if (dgChip.Visible == true)
            {
                dgChip.Visible = false;
                lblCantRegistros.Visible = false;
            }
        }


       
        private Boolean fnListarChipEspcifico(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            try
            {
                if (dgChip.Rows.Count > 0)
                {
                    BLOperador objChip= new BLOperador();
                    SimCard lstChip = new SimCard();
                    DataTable dtEquipo = new DataTable();
                    lstChip = objChip.blListarChip(Convert.ToInt32(dgChip.Rows[e.RowIndex].Cells[0].Value));

                    if (lstChip.idChip > 0)
                    {
                        lnTipoCon = 1;

                        linkHistorial.Visible = true;
                        txtEstadoActual.Text = Convert.ToString(lstChip.idEstado);
                        txtidChip.Text = Convert.ToString(lstChip.idChip);
                        txtImeiEquipo.Text = Convert.ToString(lstChip.ImeiEquipo);
                        txtSimcard2.Text = Convert.ToString(lstChip.simCard);
                        txtSimCard.Text = Convert.ToString(lstChip.simCard);
                        cboOperador.SelectedValue = Convert.ToInt32(lstChip.idOperador);
                        cboEstado.SelectedValue = lstChip.idEstado;
                        dtFechaCompra.Value = lstChip.dFechaCompra;
                       

                        if (lstChip.dFechaSuspencion=="")
                        {
                            dtFechaSuspencion.Value = Variables.gdFechaSis;
                        }
                        else
                        {
                            txtCantDias.Text = Convert.ToString(lstChip.rNumeroDias);
                            dtFechaSuspencion.Value =Convert.ToDateTime(lstChip.dFechaSuspencion);
                            
                            dtFechaBaja.Visible = false;
                        }


                        if (lstChip.dFechaReactivacion=="")
                        {
                            dtFechaReactivacion.Value = Variables.gdFechaSis;
                        }
                        else
                        {
                            dtFechaReactivacion.Value = Convert.ToDateTime(lstChip.dFechaReactivacion);
                        }

                        if (lstChip.dFechaBaja == "" || lstChip.dFechaBaja==null)
                        {
                            dtFechaBaja.Value = Variables.gdFechaSis;
                        }
                        else
                        {
                            dtFechaBaja.Value = Convert.ToDateTime(lstChip.dFechaBaja);
                            dtFechaSuspencion.Visible = false;
                        }

                        txtObservacion.Text = Convert.ToString(lstChip.observacion);
                                               
                        //swEstado.Checked = lstChip.bEstado;

                        dgChip.Visible = false;
                        lblCantRegistros.Visible = false;
                        
                        fnHabilitarControles(false);                       
                        FunValidaciones.fnHabilitarBoton(btnEditar, true);
                        FunValidaciones.fnHabilitarBoton(btnNuevo, true);


                        txtBuscarChip.Text = "";
                    }
                    else
                    {
                        linkHistorial.Visible = false;
                    }
                }


                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;
            }
        }
       
        private void dgOperador1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lnTipoLlamada==0)
            {
                Boolean bResul = false;
                bResul = fnListarChipEspcifico(e);
                
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar chip Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //this.Close();
                }
            }else if (lnTipoLlamada == 1)
            {
                Boolean bResul = false;
                bResul = fnRecuperarChipEsp(e);
                if (!bResul)
                {
                    MessageBox.Show("Error al Recuperar Cliente Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.Dispose();
                }
                
            }
            else if (lnTipoLlamada == 2)
            {
                Boolean bResul = false;
                bResul =fnRecuperaSimCardReac(e);
                this.Dispose();
            }

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            txtBuscarChip.GotFocus += RemoveText;

        }

        private void txtBuscarChip1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                //fnObtenerPaginacionEquipos(valorComboBuscar,lnTipoCon , txtBuscarChip.Text);
                fnBuscarEquipo(0,-1);

                fnHabilitarControles(false);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String lcResultado = "";
            txtSimCard_TextChanged(sender, e);
            cboOperador_SelectedIndexChanged(sender, e);
            cboEstado_SelectedIndexChanged(sender, e);
            dtFechaCompra_ValueChanged(sender, e);
            dtFechaSuspencion_ValueChanged_1(sender, e);
            txtObservacion_TextChanged_1(sender, e);
            
            if (estSimCard==true && estOperador==true && estEstado==true && estFechaCompra==true && estFechaSuspencion==true && estObservaciones==true)
            {
                //MessageBox.Show("Todo Ok");
                lcResultado = fnGuardarChip(lnTipoCon);
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Se Grabo Satisfactoriamente Equipo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Grabar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Porfavor complete todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

    }
}
