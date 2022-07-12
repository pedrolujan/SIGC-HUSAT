using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Guna.UI.WinForms;
using Siticone.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmSeguimiento : Form
    {
        public frmSeguimiento()
        {
            InitializeComponent();
        }

        Boolean estNombre, estApellido, estEstadoCliente,
            estCelular1, estCelular2, estCorreo, estClase,
            estModoUso, estTipoPlan, estPlan, estCodProspecto,
            estTipoContacto, estObservaciones, estFechaVenida,
            estCodProsSegui,estObservacionSeguimiento,estfechaSeguimiento,estEstadoSeguimiento,estTarifa;
        static Int32 lnTipoConProspectos = 0;
        static Int32 lnTipoConOferta = 0;
        static Double precioPlan = 0;
        static Double precioEquipo = 0;
        static Double precioTotal = 0;
        static Double cantEquipos = 1;
        static Double rentaAdelantada = 0;
        static Boolean estPasoLoad;
        static Int32 tabInicio;
        static Int32 tabInicioPros;
        static List<Plan> lstPlan;
        static List<TipoPlan> lstTipoPlan;
        static Boolean estActualizar;
        static Int32 idProspectoTabla= 0;
        static Int32 stMesesTipoPlan;
        static Int32 stIdTarifa;
        String letraColor = "";

        String msjNombre, msjApellido, msjEstadoProspecto,
          msjCelular1, msjCelular2, msjCorreo, msjClase,
          msjModoUso, msjTipoPlan, msjPlan, msjCodProspecto,
          msjTipoContacto, msjObservaciones, msjFechaVenida, 
            msjCodProsSegui ,msjObservacionSeguimiento, msjfechaSeguimiento,msjEstadoSeguimiento,msjTarifa;

        private void fnLimpiarControlesVisita()
        {
            /////TEXBOXS
           
            txtIdVisita.Text = "0";
            txtCelular1.Text = "";
            txtCelular2.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtIdCliente.Text = "";
            txtCantEquipos.Text = "1";
            txtObservacion.Text = "";
            txtActualizar1.Text = "";
            txtActualizar2.Text = "";
            ////COMBOBOXS
            cboEstado.SelectedValue = "ESPR0001";
            cboClase.SelectedValue = 0;
            cboTipoContacto.SelectedValue = "0";
            dtpFechaVisita.Value = Variables.gdFechaSis;
            cboTipoPlan.SelectedValue = 0;
            lnTipoConOferta = 0;
            ////PICKTUREBOXS
            imgCelular1.Image = null;
            imgCelular2.Image = null;
            imgNombre.Image = null;
            imgApellido.Image = null;
            imgCorreo.Image = null;
            imgEstadoCliente.Image = null;
            imgClase.Image = null;
            imgUso.Image = null;
            imgTipoContacto.Image = null;
            imgObservacion.Image = null;
            imgPlan.Image = null;
            imgTipoPlan.Image = null;
            imgFechaVenida.Image = null;
            imgTarifas.Image = null;
            /////LABELS
            erCelular1.Text = "";
            erCelular2.Text = "";
            erNombre.Text = "";
            erApellido.Text = "";
            erCorreoElectronico.Text = "";
            erEstadoCliente.Text = "";

            erClase.Text = "";
            erModoUso.Text = "";
            erTipoContacto.Text = "";
            erObservacion.Text = "";
            erTipoPlan.Text = "";
            erPlan.Text = "";
            erFechaVenida.Text = "";
            lblUsuarioVisita.Text = "";
            erTarifas.Text = "";
            txtIdVisita.Visible = false;

            txtCelular1.ReadOnly = false;
            txtCelular2.Enabled = true;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtCorreo.Enabled = true;
            btnEstadoCliente.Visible = false;
            
            lblEstadoVisita.Visible = false;
            cboEstado.Enabled = false;
        }

        private void cboPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLPlan objEquipo = new BLPlan();
            BLTipoTarifa objTipTarifa = new BLTipoTarifa();
            Boolean bResult = false;
            Plan clsPlan = new Plan();
            precioEquipo = 0;
            Int32 idPlan = Convert.ToInt32(cboPlan.SelectedValue == null ? "0" : cboPlan.SelectedValue.ToString());
            if(idPlan == 0)
            {
                dgvTarifas.Enabled = false;
            }
            else
            {
                dgvTarifas.Enabled = true;
            }
            
            clsPlan = objTipTarifa.blDevolverTarifaDePlan(idPlan);
            bResult = fnListarTarifas(clsPlan.tarifas, lnTipoConOferta == 0 ? 0 : stIdTarifa);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Tarifas de Plan", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            var result = Funciones.FunValidaciones.fnValidarCombobox(cboPlan, erPlan, imgPlan);
            estPlan = result.Item1;
            msjPlan = result.Item2;

            precioPlan = fnRetornarPrecioPlan(lstPlan, idPlan);
        }

        private void fnInicializarTablaTarifas()
        {
            dgvTarifas.Rows.Clear();

            dgvTarifas.Rows.Add("0", "1", "NUEVO", null, "0.00", null, "0.00", null, "0.00", null, false);
            dgvTarifas.Rows.Add("0", "2", "RENOVACIÓN", null, "0.00", null, "0.00", null, "0.00", null, false);
            dgvTarifas.Rows.Add("0", "3", "PORTABILIDAD", null, "0.00", null, "0.00", null, "0.00", null, false);

            dgvTarifas.Columns[2].Width = 100;
            dgvTarifas.Columns[4].Width = 100;
            dgvTarifas.Columns[6].Width = 150;
            dgvTarifas.Columns[8].Width = 100;
            dgvTarifas.Columns[9].Width = 100;
            dgvTarifas.Columns[10].Width = 50;
        }

        private Boolean fnListarTarifas(String tarifas ,Int32 idTarifaChek)
        {
            clsUtil objUtil = new clsUtil();
            xmlTarifas.Items clsTarifas = new xmlTarifas.Items();
            try
            {
                fnInicializarTablaTarifas();
                if (tarifas == "" || tarifas == null)
                {
                    return true;
                }
                else
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(xmlTarifas.Items));
                    using (TextReader reader = new StringReader(tarifas))
                    {
                        clsTarifas = (xmlTarifas.Items)serializer.Deserialize(reader);
                    }
                    int i = 0;
                    foreach (DataGridViewRow fila in dgvTarifas.Rows)
                    {
                        fila.Cells[0].Value = clsTarifas.Item[i].IdTarifa;
                        fila.Cells[1].Value = clsTarifas.Item[i].IdTipoTarifa;
                        fila.Cells[3].Value = clsTarifas.Item[i].PrecioEquipo;
                        fila.Cells[4].Value = clsTarifas.Item[i].SimboloMoneda + " " + String.Format("{0:0.00}", clsTarifas.Item[i].PrecioEquipo);
                        fila.Cells[5].Value = clsTarifas.Item[i].PrecioPlan;
                        fila.Cells[6].Value = clsTarifas.Item[i].SimboloMoneda + " " + String.Format("{0:0.00}", clsTarifas.Item[i].PrecioPlan) + " x " + stMesesTipoPlan + (stMesesTipoPlan == 1 ? " Año" : " Meses");
                        fila.Cells[7].Value = clsTarifas.Item[i].PrecioRenovaciones;
                        fila.Cells[8].Value = clsTarifas.Item[i].SimboloMoneda + " " + String.Format("{0:0.00}", clsTarifas.Item[i].PrecioRenovaciones);
                        if(idTarifaChek == 0)
                        {
                            fila.Cells[10].Value = fila.Index == 0 ? true : false;
                        }
                        else
                        {
                            fila.Cells[10].Value = clsTarifas.Item[i].IdTarifa == idTarifaChek ? true : false;
                        }
                        i += 1;
                    }
                    return true;
                } 
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;
            }
        }

        private Double fnRetornarPrecioPlan(List<Plan> lista, Int32 idPlan)
        {
            Int32 TotalPlan = Convert.ToInt32(lista == null ? 0 : lista.Count);
            if(TotalPlan <= 1)
            {
                return 0;
            }
            else
            {
                for (int i = 0; i <= TotalPlan - 1; i++)
                {
                    if (lista[i].idPlan == idPlan)
                    {
                        return lista[i].precio;
                    }
                }
            }

            return 0;
        }

        private void txtCantEquipos_TextChanged(object sender, EventArgs e)
        {
            Int32 intEquipos;

            if (txtCantEquipos.Text == null || txtCantEquipos.Text.ToString() == "")
            {
                intEquipos = 1;
            }
            else
            {
                intEquipos = Convert.ToInt32(txtCantEquipos.Text.ToString());
            }

            cantEquipos = intEquipos;

            foreach( DataGridViewRow fila in dgvTarifas.Rows)
            {
                CalcularTotal(fila.Index);
            }
            
        }

        private void cboTipoContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = Funciones.FunValidaciones.fnValidarCombobox(cboTipoContacto, erTipoContacto, imgTipoContacto);
            estTipoContacto = result.Item1;
            msjTipoContacto = result.Item2;
        }

        private void txtObservacion_TextChanged(object sender, EventArgs e)
        {
            var result = Funciones.FunValidaciones.fnValidarTexboxs(txtObservacion, erObservacion, imgObservacion, false, true, false, 0, 5, 0, 1000, "Complete correctamente los campos");
            estObservaciones = result.Item1;
            msjObservaciones = result.Item2;
        }

        private void cboTipoPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResul = false;
            Int32 idcboTipoPlan = Convert.ToInt32(cboTipoPlan.SelectedValue ?? 0);
            if (idcboTipoPlan != 0)
            {
                bResul = fnLLenarPlanxTipoPlan(cboPlan, false, 0, idcboTipoPlan);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Plan", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cboPlan.Enabled = true;
            }
            else
            {
                bResul = fnLLenarPlanxTipoPlan(cboPlan, false, 0, idcboTipoPlan);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Plan", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cboPlan.Enabled = false;
            }
            var result = Funciones.FunValidaciones.fnValidarCombobox(cboTipoPlan, erTipoPlan, imgTipoPlan);
            estTipoPlan = result.Item1;
            msjTipoPlan = result.Item2;
            stMesesTipoPlan = fnObtenerMesesTipoPlan(idcboTipoPlan, lstTipoPlan);
        }

        private Int32 fnObtenerMesesTipoPlan(Int32 idTipoPlan, List<TipoPlan> TP)
        {
            if(TP != null)
            {
                foreach (TipoPlan item in TP)
                {
                    if (item.idTipoPlan == idTipoPlan)
                    {
                        Int32 numCuotas = 12 / (item.cMeses == 0 ? 1 : item.cMeses);
                        return numCuotas;
                    }
                }
            }
            return 0;
        }

        private void cboModUso_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = Funciones.FunValidaciones.fnValidarCombobox(cboModUso, erModoUso, imgUso);
            estModoUso = result.Item1;
            msjModoUso = result.Item2;
        }


        private void txtCorreoElectronico_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "CORREO", false, erCorreoElectronico);
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true, erNombre);
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true, erApellido);
        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private Int32 fnRetornarIdTarifa()
        {
            foreach (DataGridViewRow fila in dgvTarifas.Rows)
            {
                Boolean EstadoCheck = Convert.ToBoolean(fila.Cells[10].Value);
                if (EstadoCheck)
                {
                    Int32 idTarifa = Convert.ToInt32(fila.Cells[0].Value);
                    return idTarifa;
                }
            }
            return 0;
        }
        private void txtCantEquipos_Leave(object sender, EventArgs e)
        {
            if (txtCantEquipos.Text == null || txtCantEquipos.Text.ToString() == "")
            {
                txtCantEquipos.Text = Convert.ToString(1);
            }
        }

        private Tuple<Boolean, String> fnValidarCelularSQL(SiticoneTextBox txt, Label lbl, PictureBox img, Int32 numLength)
        {
            String msj;
            Boolean bResul;
            Int16 pnTipocon = 0;

            if (txt.Text == null || txt.Text.Trim() == "")
            {
                img.Image = Properties.Resources.error;
                msj = "Ingrese datos (campo obligatorio)";
                lbl.ForeColor = Variables.ColorError;
                lbl.Text = msj;

                return Tuple.Create(false, msj);
            }
            else if (txt.Text.Length == numLength)
            {
                img.Image = Properties.Resources.ok;
                msj = "";
                lbl.Text = msj;
                bResul = fnBuscarTelefonoProspecto(txt.Text.Trim(), pnTipocon, lbl, img);
                return Tuple.Create(bResul, msj);
            }
            else
            {
                img.Image = Properties.Resources.error;
                msj = "Ingrese el campo completo";
                lbl.ForeColor = Variables.ColorError;
                lbl.Text = msj;
                return Tuple.Create(false, msj);
            }
            


        }

        private Tuple<Boolean, String> fnValidarTexboxSQL(SiticoneTextBox txt, SiticoneTextBox txtActu, Label lbl, PictureBox img,Boolean obligatorio, Boolean maximo, Int32 num)
        {
            String msj;
            Boolean bResul;
            Int16 pnTipocon = 0;

            if (txt.Text == null || txt.Text.Trim() == "")
            {
                if (obligatorio)
                {
                    img.Image = Properties.Resources.error;
                    msj = "Ingrese datos (campo obligatorio)";
                    lbl.ForeColor = Variables.ColorError;
                    lbl.Text = msj;

                    return Tuple.Create(false, msj);
                }
                else
                {
                    
                    img.Image = Properties.Resources.ok;
                    msj = "campo no obligatorio";
                    lbl.ForeColor = Variables.ColorSuccess;
                    lbl.Text = msj;

                    return Tuple.Create(true, msj);
                }
                

            }
            else if (estActualizar)
            {

                if (txtActu.Text.Trim() == txt.Text.Trim())
                {
                    img.Image = Properties.Resources.ok;
                    msj = "";
                    lbl.Text = msj;

                    return Tuple.Create(true, msj);
                }
                else
                {
                    img.Image = Properties.Resources.ok;
                    msj = "";
                    lbl.Text = msj;
                    bResul = fnBuscarTelefonoProspecto(txt.Text.Trim(), pnTipocon,lbl,img);
                    return Tuple.Create(bResul, msj);

                }

            }
            else if (maximo)
            {
                if (txt.Text.Length == num)
                {
                    img.Image = Properties.Resources.ok;
                    msj = "";
                    lbl.Text = msj;
                    bResul = fnBuscarTelefonoProspecto(txt.Text.Trim(), pnTipocon, lbl, img);
                    return Tuple.Create(bResul, msj);
                }
                else
                {
                    img.Image = Properties.Resources.error;
                    msj = "Ingrese el campo completo";
                    lbl.ForeColor = Variables.ColorError;
                    lbl.Text = msj;
                    return Tuple.Create(false, msj);
                }
            }
            else
            {

                img.Image = Properties.Resources.error;
                msj = "";
                lbl.Text = msj;
                return Tuple.Create(true, msj);
              
            }


        }


        private Tuple<Boolean, String> fnValidarFechaProxima(GunaNumeric txt, Label lbl, PictureBox img)
        {
            String msj;
            DateTime solofechaProxSeguimiento =fnCalcularSoloFecha(Convert.ToDateTime(dtpFechaProximoSeguimiento.Value.ToString()));
            Int32 soloHoraFechSeg = Convert.ToInt32(txtHoraSigSeguimiento.Value.ToString());

            DateTime fechaProxSeguimiento = solofechaProxSeguimiento.AddHours(soloHoraFechSeg);
            DateTime fechaSistema = Variables.gdFechaSis;
            DateTime fecha1mes = fechaSistema.AddDays(15);

            if (fechaProxSeguimiento > fechaSistema && fechaProxSeguimiento < fecha1mes)
            {
                img.Image = Properties.Resources.ok;
                msj = "Fecha Correcta";
                lbl.ForeColor = Variables.ColorSuccess;
                lbl.Text = "La Próxima fecha = " + fechaProxSeguimiento.ToString() ;

                return Tuple.Create(true, msj);
            }
            else
            {
                img.Image = Properties.Resources.error;
                msj = "La Próxima fecha = " + fechaProxSeguimiento.ToString() +"\nNo puede ser menor a la Fecha y Hora Actual y Mayor a 1 Mes";
                lbl.ForeColor = Variables.ColorError;
                lbl.Text = msj;

                return Tuple.Create(false, msj);
            }
        }
        private Boolean fnBuscarTelefonoProspecto(String pcBuscar, Int16 pnTipoCon,Label lbl,PictureBox img)
        { 
            BLProspecto objAcc = new BLProspecto();
            clsUtil objUtil = new clsUtil();
            Int16 numResult = 0;

            try
            {

                numResult = objAcc.blBuscarTelefonoProspecto(pcBuscar, pnTipoCon);

                if (numResult == 1)
                {
                    lbl.Text = "Este teléfono ya existe (Ingrese otro Cliente)";
                    lbl.ForeColor = Variables.ColorError;
                    img.Image = Properties.Resources.error;
                    return false;
                }
                else if (numResult == 0)
                {
                    lbl.Text = "";
                    lbl.ForeColor = Variables.ColorSuccess;
                    img.Image = Properties.Resources.ok;
                    return true;
                }
                else
                {
                    lbl.Text = "Ocurrió otro error";
                    lbl.ForeColor = Variables.ColorError;
                    img.Image = Properties.Resources.error;
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorio", "fnBuscarAccesorio", ex.Message);
                return false;
            }
            finally
            {

                objAcc = null;
                objUtil = null;
            }
        }

        private Tuple<Boolean, String> fnBuscarPlanXTelefono( Int16 pnTipoCon, Label lbl, PictureBox img)
        {
            BLProspecto objAcc = new BLProspecto();
            clsUtil objUtil = new clsUtil();
            DataTable datAcces = null;
            String pcBuscar;
            String msj = "";
            Int32 totalResultados = 0;
            try
            {
                pcBuscar = txtCelular1.Text.ToString();
                Int32 numCaracteres = pcBuscar.Length;
                if(numCaracteres == 11)
                {
                    if (lnTipoConOferta == 1 || lnTipoConOferta == 2)
                    {
                        totalResultados = 0;
                    }
                    else
                    {
                        datAcces = objAcc.blBuscarPlanXTelefono(pcBuscar, pnTipoCon);
                        totalResultados = datAcces.Rows.Count;
                    }
                    

                    if (totalResultados > 0)
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        dt.Columns.Add("ID");
                        dt.Columns.Add("DETALLE");

                        for (int i = 0; i <= totalResultados - 1; i++)
                        {
                            String estadoVisita = datAcces.Rows[i][1].ToString();
                            if (estadoVisita == "ESPR0001")
                            {
                                object[] row =
                                {
                                    datAcces.Rows[i][0],
                                    datAcces.Rows[i][2],
                                };
                                dt.Rows.Add(row);
                            }
                            else
                            {

                            }
                            

                        }

                        dt.Rows.Add(new Object[] { "0", "NUEVA VISITA" });
                        dgPrediccionResultados.DataSource = dt;
                        dgPrediccionResultados.Columns[0].Visible = false;
                        dgPrediccionResultados.Columns[1].Width = 100;

                        dgPrediccionResultados.Visible = true;

                        img.Image = Properties.Resources.ok;
                        msj = "";
                        lbl.ForeColor = Variables.ColorSuccess;
                        lbl.Text = msj;

                        return Tuple.Create(true, "");


                    }
                    else
                    {
                        if (lnTipoConOferta == 1)
                        {
                            DataTable dt = new DataTable();
                            dt.Clear();
                            dgPrediccionResultados.Visible = false;

                            img.Image = Properties.Resources.ok;
                            msj = "";
                            lbl.ForeColor = Variables.ColorSuccess;
                            lbl.Text = msj;
                            return Tuple.Create(true, msj);
                        }
                        else
                        {
                            lnTipoConOferta = 0;
                            DataTable dt = new DataTable();
                            dt.Clear();
                            dgPrediccionResultados.Visible = false;

                            img.Image = Properties.Resources.ok;
                            msj = "";
                            lbl.ForeColor = Variables.ColorSuccess;
                            lbl.Text = msj;
                            return Tuple.Create(true, msj);
                        }
                        
                       
                        
                    }
                    
                }
                else
                {

                    DataTable dt = new DataTable();
                    dt.Clear();
                    dgPrediccionResultados.Visible = false;
                    img.Image = Properties.Resources.error;
                    msj = "Ingrese datos (campo obligatorio)";
                    lbl.ForeColor = Variables.ColorError;
                    lbl.Text = msj;

                    return Tuple.Create(false, msj);
                }
                

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorio", "fnBuscarAccesorio", ex.Message);
                msj = "Error al buscar telefono";
                return Tuple.Create(false, msj);
            }
            finally
            {

                objAcc = null;
                objUtil = null;
            }
        }

        private Boolean fnBuscarClienteXTelefono(Int16 pnTipoCon)
        {
            BLProspecto objAcc = new BLProspecto();
            clsUtil objUtil = new clsUtil();
            Prospecto objPros = null;
            String pcBuscar;
           
            try
            {
                pcBuscar = txtCelular1.Text.ToString();
                Int32 numCaracteres = pcBuscar.Length;
                if (numCaracteres == 11)
                {
                    objPros = objAcc.blBuscarClineteXTelefono(pcBuscar, pnTipoCon);
                    if (objPros.idProspecto == 0)
                    {
                        txtCelular1.ReadOnly = false;

                        txtIdCliente.Text = "0";
                        txtNombre.Text = "";
                        txtApellido.Text = "";
                        txtCelular2.Text = "";
                        txtCorreo.Text = "";
                        
                        dgPrediccionResultados.Visible = false;
                        return true;
                    }
                    else
                    {
                        estActualizar = true;
                        txtCelular1.Text = Convert.ToString(objPros.celular1.ToString().Trim());
                        txtActualizar2.Text = Convert.ToString(objPros.celular2.ToString().Trim());
                        txtIdCliente.Text = Convert.ToString(objPros.idProspecto.ToString());
                        txtNombre.Text = Convert.ToString(objPros.nombres.ToString());
                        txtApellido.Text = Convert.ToString(objPros.apellidos.ToString());
                        txtCelular2.Text = Convert.ToString(objPros.celular2.ToString());
                        txtCorreo.Text = Convert.ToString(objPros.correo.ToString());

                        txtCelular1.ReadOnly = true;
                        
                        
                        dgPrediccionResultados.Visible = false;
                        return true;
                    }
                }
                
                return true;
                


            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorio", "fnBuscarAccesorio", ex.Message);
                
                return false;
            }
            finally
            {

                objAcc = null;
                objUtil = null;
            }
        }
        private void siticoneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = Funciones.FunValidaciones.fnValidarCombobox(cboEstadoSeguimiento, erEstadoSeguimiento, imgEstadoSeguimiento);
            estEstadoCliente = result.Item1;
            msjEstadoProspecto = result.Item2;
        }

        private void txtBuscarNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (estPasoLoad)
                {
                    letraColor = "";
                    String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                    fnBuscarTablaProspectosPlan(busqueda, 0, -1, letraColor);
                }

            }
        }

       

        private void btnGuardarSeguimiento_Click(object sender, EventArgs e)
        {
            String lcResultado;
            
            txtObservacionSeguimiento_TextChanged(sender, e);
            txtHoraSigSeguimiento_ValueChanged(sender, e);
            var result1 = FunValidaciones.fnValidarCombobox(cboEstadoSeguimiento, erEstadoSeguimiento, imgEstadoSeguimiento);
            estEstadoSeguimiento = result1.Item1;
            msjEstadoSeguimiento = result1.Item2;

               
            if (estObservacionSeguimiento & estfechaSeguimiento & estEstadoSeguimiento && erFechaRegSeguimiento.Text.ToString().Trim()=="")
            {
                lcResultado = fnGuardarSeguimiento();
                if (lcResultado == "OK")
                {
                    fnLimpiarSeguimiento();
                    MessageBox.Show("Se Grabó Satisfactoriamente Accesorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    Int32 idProspectoPlan = Convert.ToInt32(txtIdVisita.Text.ToString());
                    fnBuscarTablaSeguimiento(idProspectoPlan,1,-1);
                   
                }
                else
                {
                    MessageBox.Show("Error al Grabar Accesorio. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Complete correctamente los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            String busqueda = txtBuscarNombreCliente.Text.Trim().ToString();
            Int32 pagina = Convert.ToInt32(cboPaginaProsPlan.Text.ToString());

            fnBuscarTablaProspectosPlan(busqueda, pagina, -2, letraColor) ;
        }

        

        private void cboBuscarEstadoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                letraColor = "";
                String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                fnBuscarTablaProspectosPlan(busqueda, 0, -1, letraColor);
            }
        }

        

        private void fnHabilitarGroupBoxsProspecto(Boolean est)
        {
            gbDatosClienteProspecto.Enabled = est;
            
        }

        private void cboBuscarTipoContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                letraColor = "";
                String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                fnBuscarTablaProspectosPlan(busqueda, 0, -1 , letraColor);
            }
        }

        private void txtNombreBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (estPasoLoad)
                {
                    //fnBuscarTablaProspectos(dgProspectos, 0, -1);
                }

            }
        }

        private void fnLimpiarControlesProspecto()
        {
            /////TEXBOXS
           
            txtCelular2.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
           
            ////COMBOBOXS

            lnTipoConProspectos = 0;
            ////PICKTUREBOXS
            imgNombre.Image = null;
            imgApellido.Image = null;
          
            imgCelular2.Image = null;
            imgCorreo.Image = null;
            

            /////LABELS
            erNombre.Text = "";
            erApellido.Text = "";
            
            erCelular2.Text = "";
            erCorreoElectronico.Text = "";

            estActualizar = false;
        }

        private void txtNumCelular1_TextChanged_1(object sender, EventArgs e)
        {
            //var result = fnValidarTexboxSQL(txtNumCelular1, txtActualizar, erCelular1, imgCelular1, true, true, 11);
            //estCelular1 = result.Item1;
            //msjCelular1 = result.Item2;
        }

        private void txtNumCelular2_Change(object sender, EventArgs e)
        {
            //var result = fnValidarTexboxSQL(txtNumCelular2, txtActualizar2, erCelular2, imgCelular2, false, true, 11);
            //estCelular2 = result.Item1;
            //msjCelular2 = result.Item2;
        }

        private void opcEditar_Click(object sender, EventArgs e)
        {
            Boolean bResul = false;
             
            bResul = fnListarProspectoPlanEspecifico(dgProspecto,1);
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

        }

        private void opcCrearPlan_Click(object sender, EventArgs e)
        {

            Boolean bResul = false;
           
            bResul = fnListarProspectoPlanEspecifico(dgProspecto, 1);
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            tabControl.SelectedIndex = 0;
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            Int32 idProspectoPlan = Convert.ToInt32(txtIdVisita.Text.ToString());
            tabRegistroVisitas.AutoScroll = true;
            fnLimpiarSeguimiento();
            fnBuscarTablaSeguimiento(idProspectoPlan, 1, -1);
            String idEstadoCliente = cboEstado.SelectedValue.ToString();
            fnHabilitarGroupBoxsSeguimiento(false);
            Int32 idCargo = Variables.gnCodUser;
            if(idEstadoCliente == "ESPR0001")
            {
                FunValidaciones.fnHabilitarBoton(btnNuevoSeguimiento, true);
                FunValidaciones.fnHabilitarBoton(btnGuardarSeguimiento, false);
            }
            else
            {
                FunValidaciones.fnHabilitarBoton(btnNuevoSeguimiento, false);
                FunValidaciones.fnHabilitarBoton(btnGuardarSeguimiento, false);
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
            //fnBuscarTablaProspectos(dgProspectos, 1, -1);
            //txtNombreBuscar.Focus();
        }

        
        private Tuple<Boolean, String> fnValidarCodigo(SiticoneTextBox txt,PictureBox img ,Label lbl)
        {
            String msj;
            

            if (txt.Text == null || txt.Text.Trim() == "")
            {
                msj = "Ingrese código";
                lbl.Text = msj;
                lbl.ForeColor = Color.Red;
                img.Image = Properties.Resources.error;
                return Tuple.Create(false, msj);

            }
            else
            {
                msj = "";
                lbl.Text = msj;
                lbl.ForeColor = Variables.ColorSuccess;
                img.Image = Properties.Resources.ok;
                return Tuple.Create(true, msj);

            }


        }

        private void dtpFechaVenida_ValueChanged(object sender, EventArgs e)
        {
            var result = fnValidarFecha(dtpFechaVisita, imgFechaVenida, erFechaVenida);
            estFechaVenida = result.Item1;
            msjFechaVenida = result.Item2;
        }
        private Tuple<Boolean, String> fnValidarFecha(SiticoneDateTimePicker dtp, PictureBox img, Label lbl)
        {
            String msj;
            String dateSelectText = dtp.Value.ToString("dd-MM-yyyy");
            String dateSistemText = DateTime.Today.ToString("dd-MM-yyyy");

            DateTime dateSelect = Convert.ToDateTime(dateSelectText);
            DateTime dateSistem = Convert.ToDateTime(dateSistemText);
            if ((dtp.Value.AddYears(10) <= DateTime.Today))
            {
                msj = "Fecha de visita no puede ser mayor a 10 años";
                lbl.Text = msj;
                lbl.ForeColor = Color.Red;
                img.Image = Properties.Resources.error;

                return Tuple.Create(false, msj);
            }
            else if (dateSelect > dateSistem)
            {
                msj = "Fecha de visita no puede ser mayor a hoy";
                lbl.Text = msj;
                lbl.ForeColor = Color.Red;
                img.Image = Properties.Resources.error;

                return Tuple.Create(false, msj);
            }
            else
            {
                msj = "";
                lbl.Text = msj;
                img.Image = Properties.Resources.ok;
                lbl.ForeColor = Color.Green;

                return Tuple.Create(true, msj);

            }

        }

        private Tuple<Boolean, String> fnValidarFechaSeguimiento(SiticoneDateTimePicker dtp, PictureBox img, Label lbl)
        {
            ///hola
            String msj;
            String dateSelectText = dtp.Value.ToString("dd-MM-yyyy");
            String dateSistemText = dtpFechaRegSeguimiento.Value.ToString("dd-MM-yyyy");
            DateTime dateSis = Convert.ToDateTime(dateSistemText);
            DateTime dateSelect = Convert.ToDateTime(dateSelectText);
            DateTime dateSistemMas1Mes = Convert.ToDateTime(dateSistemText).AddMonths(1);
            if ((dateSelect < dateSis.AddDays(1)))
            {
                msj = "Fecha próxima tiene que ser mayor a 1 día";
                lbl.Text = msj;
                lbl.ForeColor = Color.Red;
                img.Image = Properties.Resources.error;

                return Tuple.Create(false, msj);
            }
            else if (dateSelect > dateSistemMas1Mes)
            {
                msj = "Fecha próxima no puede ser mayor a 1 Mes";
                lbl.Text = msj;
                lbl.ForeColor = Color.Red;
                img.Image = Properties.Resources.error;

                return Tuple.Create(false, msj);
            }
            else
            {
                msj = "";
                lbl.Text = msj;
                img.Image = Properties.Resources.ok;
                lbl.ForeColor = Color.Green;

                return Tuple.Create(true, msj);

            }

        }

        private void btnBuscarOferta_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2;
            txtBuscarNombreCliente.Focus();
        }

        private void btnEditarProspecto_Click(object sender, EventArgs e)
        {
           
            fnHabilitarGroupBoxsProspecto(true);
        }

        private void btnSalirProspecto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombres_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true);
        }

        private void txtApellidos_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true);
        }

       
        private void txtCelular1Visita_TextChanged(object sender, EventArgs e)
        {
           
            var result = fnBuscarPlanXTelefono(1, erCelular1, imgCelular1);
            estCelular1 = result.Item1;
            msjCelular1 = result.Item2;
           
            
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            var result = Funciones.FunValidaciones.fnValidarTexboxs(txtApellido, erApellido, imgApellido, false, true, true, 5, 10, 0, 45, "Complete correctamente los campos");
            estApellido = result.Item1;
            msjApellido = result.Item2;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtNombre, erNombre, imgNombre, true, true, true, 3, 45, 0, 45, "Complete correctamente los campos");
            estNombre = result.Item1;
            msjNombre = result.Item2;

            //merge
        }

        private void txtNumCelular2_TextChanged(object sender, EventArgs e)
        {
            var result = fnValidarTexboxSQL(txtCelular2,txtActualizar2, erCelular2, imgCelular2, false,true,11);
            estCelular2 = result.Item1;
            msjCelular2 = result.Item2;

        }

        private void txtCorreoElectronico_TextChanged_1(object sender, EventArgs e)
        {
            txtCorreo.CharacterCasing = CharacterCasing.Lower;
            var result = Funciones.FunValidaciones.fnValidarTexboxs(txtCorreo, erCorreoElectronico, imgCorreo, false, true, false, 0, 5, 0, 45, "Complete correctamente los campos");
            estCorreo = result.Item1;
            msjCorreo = result.Item2;
        }

        private void txtCelular1Visita_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", false, erCelular1);
            FunValidaciones.fnFormatoCelular(e, txtCelular1);
        }

        private void txtNumCelular2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", false);
            FunValidaciones.fnFormatoCelular(e, txtCelular2);
        }

        private void txtCorreoElectronico_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "CORREO", false);
        }

        private void dgPrediccionResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean bResul = false;
            bResul = fnListarProspectoPlanEspecifico(dgPrediccionResultados,1);
            if (!bResul)
            {
                MessageBox.Show("Error al Cargar accesorio Especifico", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboEstado, erEstadoCliente, imgEstadoCliente);
            estEstadoCliente = result.Item1;
            msjEstadoProspecto = result.Item2;
        }

        private void dgProspecto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            String nombreCabecera = dgv.Columns[e.ColumnIndex].HeaderText;

            if ( nombreCabecera == "FECH. REGISTRO SEGUIMIENTO" || nombreCabecera == "FECH. PRÓXIMO SEGUIMIENTO")
            {
                
                if (e.Value.ToString().Contains("✔") )
                {
                    e.CellStyle.ForeColor = Variables.ColorSuccess;
                }
                else if (e.Value.ToString().Contains("🕑"))
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }
                else if(e.Value.ToString().Contains("❗"))
                {
                    e.CellStyle.ForeColor = Variables.ColorError;

                }else if (e.Value.ToString().Contains("🚫"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(85, 5, 166);
                }
                else if (e.Value.ToString().Contains("⭐"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(214, 166, 54);
                }
                else if (e.Value.ToString(). Contains("👁"))
                {
                    e.CellStyle.ForeColor = Variables.ColorError;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void btnBuscarSeguimiento_Click(object sender, EventArgs e)
        {
            //Int32 idVisita = Convert.ToInt32(txtIdVisita.Text.ToString());
            //fnBuscarTablaSeguimiento(idVisita, 1, -1);

            tabControl.SelectedIndex = 1;
            if (estPasoLoad)
            {
                String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                fnBuscarTablaProspectosPlan(busqueda, 0, -1 ,"" );
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true, erNombre);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "LETRAS", true, erApellido);
        }

        private void dtpFechaRegSeguimiento_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaRegSeguimiento.Value>Variables.gdFechaSis)
            {
                MessageBox.Show("La fecha de registro no puede ser mayor a la fecha actual\n "+ Variables.gdFechaSis.ToString("dd-MMM-yyyy hh:mm"),"Aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Warning) ;
                imgFechaRegSeguimiento.Image = Properties.Resources.error;
                erFechaRegSeguimiento.Text = "La fecha de registro no puede ser mayor a la fecha actual\n " + Variables.gdFechaSis.ToString("dd-MMM-yyyy hh:mm");
            }
            else if (dtpFechaRegSeguimiento.Value < Convert.ToDateTime(Variables.gdFechaSis.AddDays(-3).ToString("dd-MM-yyyy")))
            {
                MessageBox.Show("La fecha de registro no puede ser menor a la fecha: \n " + Variables.gdFechaSis.AddDays(-3).ToString("dd-MMM-yyyy hh:mm"), "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                imgFechaRegSeguimiento.Image = Properties.Resources.error;

                erFechaRegSeguimiento.Text = "La fecha de registro no puede ser Menor a la fecha:\n " + Variables.gdFechaSis.AddDays(-3).ToString("dd-MMM-yyyy hh:mm");

            }
            else
            {
                imgFechaRegSeguimiento.Image = Properties.Resources.ok;

                erFechaRegSeguimiento.Text = "";
            }
        }

        private void tabRegistroVisitas_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscarCelular_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                letraColor = "";
                String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                fnBuscarTablaProspectosPlan(busqueda, 0, -1,"");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                letraColor = "";
                String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                fnBuscarTablaProspectosPlan(busqueda, 0, -1,"");
            }
        }

        private void chkBuscarPorFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                Boolean chkBuscar = chkHabilitarFechas.Checked;
                if (chkBuscar)
                {
                    dtpFechaInicialBusqueda.Enabled = true;
                    dtpFechaFinalBusqueda.Enabled = true;

                 
                    String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                    fnBuscarTablaProspectosPlan(busqueda, 0, -1,"");
                    
                }
                else
                {
                    dtpFechaInicialBusqueda.Enabled = false;
                    dtpFechaFinalBusqueda.Enabled = false;
                  
                    String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                    fnBuscarTablaProspectosPlan(busqueda, 0, -1,"");
                    
                }
                
            }
        }

        private void txtCelular1Seguimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void cboClase_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void cboModUso_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtHoraSigSeguimiento_ValueChanged(object sender, EventArgs e)
        {
            var result = fnValidarFechaProxima(txtHoraSigSeguimiento, erFechaSigSeguimiento, imgFechaSigSeguimiento);
            estfechaSeguimiento = result.Item1;
            msjfechaSeguimiento = result.Item2;
        }

        private void cboEstadoSeguimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarCombobox(cboEstadoSeguimiento, erEstadoSeguimiento, imgEstadoSeguimiento);
            estEstadoSeguimiento = result.Item1;
            msjEstadoSeguimiento = result.Item2;


            String codEstadoCliente = cboEstadoSeguimiento.SelectedValue.ToString();
            if(codEstadoCliente == "ESPR0001" || codEstadoCliente == "0")
            {
                dtpFechaProximoSeguimiento.Enabled = true;
                dtpFechaProximoSeguimiento.Visible = true;
                lblFechaProxSeguimiento.Text = "Fecha de Próximo Seguimiento         -          Hora  (*)";
                imgFechaSigSeguimiento.Visible = true;
                erFechaSigSeguimiento.Visible = true;
                lblFechaProxSeguimiento.ForeColor = Color.Black;
                txtHoraSigSeguimiento.Visible = true;
                imgFechaRegSeguimiento.Image = Properties.Resources.ok;
                DateTime fechaRegistro = Convert.ToDateTime(dtpFechaRegSeguimiento.Value.ToString());
                DateTime fechaMas6dias = fechaRegistro.AddDays(6);
                dtpFechaProximoSeguimiento.Value = fechaMas6dias;
            }
            else
            {
                dtpFechaProximoSeguimiento.Enabled = false;
                dtpFechaProximoSeguimiento.Visible = false;
                imgFechaSigSeguimiento.Visible = false;
                erFechaSigSeguimiento.Visible = false;
                lblFechaProxSeguimiento.Text = "Si el Estado del Seguimiento cambia a: " + cboEstadoSeguimiento.Text + "\nYa no podrá hacerle un próximo seguimiento a este Cliente";
                lblFechaProxSeguimiento.ForeColor = Color.Orange;
                txtHoraSigSeguimiento.Visible = false;

                imgFechaRegSeguimiento.Image = Properties.Resources.ok;
                DateTime fechaRegistro = Convert.ToDateTime(dtpFechaRegSeguimiento.Value.ToString());
                dtpFechaProximoSeguimiento.Value = fechaRegistro.AddDays(1);
            }
        }

        private void cboUsuarioBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                letraColor = "";
                String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                fnBuscarTablaProspectosPlan(busqueda, 0, -1 ,"");
            }
        }

        private void gbDatosClienteProspecto_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevaVisita_Click(object sender, EventArgs e)
        {
            btnNuevo_Click(sender, e);
        }

        private void rdbFechaVisita_CheckedChanged_1(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                fnBuscarTablaProspectosPlan(busqueda, 0, -1,"");
            }
        }

        private void rdbFechaRegSeg_CheckedChanged_1(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                fnBuscarTablaProspectosPlan(busqueda, 0, -1,"");
            }
        }

        private void rdbFechaSigSeg_CheckedChanged_1(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                fnBuscarTablaProspectosPlan(busqueda, 0, -1 ,"");
            }
        }

        private void cboPaginaSeg_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 idProspectoPlan = Convert.ToInt32(txtIdVisita.Text.ToString());
            Int32 pagina = Convert.ToInt32(cboPaginaSeg.Text.ToString());
            fnBuscarTablaSeguimiento(idProspectoPlan, pagina, -2);
        }

        private void cboBuscarTipoPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResul;
            Int32 idcboBuscarTipoPlan = Convert.ToInt32(cboBuscarTipoPlan.SelectedValue ?? 0);
            if (idcboBuscarTipoPlan != 0)
            {
                letraColor = "";
                bResul = fnLLenarPlanxTipoPlan(cboBuscarPlan, true, 0, idcboBuscarTipoPlan);
                if (!bResul)
                {
                  
                    MessageBox.Show("Error al Cargar Plan", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cboBuscarPlan.Enabled = true;
            }
            else
            {
                bResul = fnLLenarPlanxTipoPlan(cboBuscarPlan, true, 0, idcboBuscarTipoPlan);
                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Plan", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cboBuscarPlan.Enabled = false;
              
            }

            if (estPasoLoad)
            {
                String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                fnBuscarTablaProspectosPlan(busqueda, 0, -1 , letraColor);
            }
        }

        private void cboBuscarPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                letraColor = "";
                String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                fnBuscarTablaProspectosPlan(busqueda, 0, -1 , letraColor);
            }
        }

        private void cboBuscarTipoTarifa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estPasoLoad)
            {
                letraColor = "";
                String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                fnBuscarTablaProspectosPlan(busqueda, 0, -1, letraColor) ;
            }
        }


        
      

        private void dgSeguimiento_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmPrevisualizar frmprev = new FrmPrevisualizar();
            String Dato = Convert.ToString(dgSeguimiento.Rows[dgSeguimiento.CurrentRow.Index].Cells[3].Value.ToString());
            frmprev.inicio(0, Dato);
        }

        private void dgProspecto_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
                    if (!clickedRow.Selected)
                    {
                        dgProspecto.CurrentCell = clickedRow.Cells[e.ColumnIndex];
                        //cmsMenuTablaProspectos.Show(cmsMenuTablaProspectos, mousePosition);

                    }
                    //else
                    //{
                    //    var mousePosition = dgProspecto.PointToClient(Cursor.Position);
                    //    cmsMenuTablaProspectos.Show(cmsMenuTablaProspectos, mousePosition);
                    //}

                }
            }
        }

        private void btnVerde_Click(object sender, EventArgs e)
        {
            letraColor = "V";
            String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
            fnBuscarTablaProspectosPlan(busqueda, 0, -1,letraColor);

            //MessageBox.Show(" TIENES " + btnVerde.Text + " PENDIENTES EN VERDE", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAmarillo_Click(object sender, EventArgs e)
        {
            letraColor = "A";
            String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
            fnBuscarTablaProspectosPlan(busqueda, 0, -1, letraColor);

            //MessageBox.Show(" TIENES " + btnAmarillo.Text + " PENDIENTES EN AMARILLO ", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txtBuscarNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRojo_Click(object sender, EventArgs e)
        {
            letraColor = "R";
            String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
            fnBuscarTablaProspectosPlan(busqueda, 0, -1, letraColor);

            //MessageBox.Show(" TIENES " + btnRojo.Text + " PENDIENTES  EN ROJO ", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void lblUsuarioRanking_Click(object sender, EventArgs e)
        {

        }

        private void dgvTarifas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 filaIndice = e.RowIndex == -1 ? 0 : e.RowIndex;
            if (dgvTarifas.Rows.Count > 0)
            {
                if (e.ColumnIndex >= 3 || e.ColumnIndex <= 5)
                {
                    CalcularTotal(filaIndice);
                }
            }
        }
        private void CalcularTotal(Int32 filaIndice)
        {
            Double precioEquipo = Convert.ToDouble(dgvTarifas.Rows[filaIndice].Cells[3].Value ?? 0);
            Double precioPlan = Convert.ToDouble(dgvTarifas.Rows[filaIndice].Cells[5].Value ?? 0);
            Double precioReactivacion = Convert.ToDouble(dgvTarifas.Rows[filaIndice].Cells[7].Value ?? 0);
            Double precioTotal = (precioEquipo + (precioPlan * stMesesTipoPlan) + precioReactivacion) * cantEquipos;
            String stringMoneda = Convert.ToString(dgvTarifas.Rows[filaIndice].Cells[8].Value);
            String simboloMoneda = stringMoneda.Substring(0, 2);
            dgvTarifas.Rows[filaIndice].Cells[9].Value = simboloMoneda + " " + precioTotal;
        }

        private void dgvTarifas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                foreach (DataGridViewRow fila in dgvTarifas.Rows)
                {
                    fila.Cells[10].Value = false;
                }
                dgvTarifas.Rows[e.RowIndex].Cells[10].Value = true;
                //CalcularTotal();
            }
        }

        private void txtBuscarCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", false, erCelular2);
            FunValidaciones.fnFormatoCelular(e, txtBuscarCelular);

            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (estPasoLoad)
                {
                    letraColor = "";
                    String busqueda = txtBuscarNombreCliente.Text.ToString().Trim();
                    fnBuscarTablaProspectosPlan(busqueda, 0, -1 ,"");
                }

            }
        }

        private void dtpFechaProximoSeguimiento_ValueChanged(object sender, EventArgs e)
        {
            var result = fnValidarFechaProxima(txtHoraSigSeguimiento, erFechaSigSeguimiento, imgFechaSigSeguimiento);
            estfechaSeguimiento = result.Item1;
            msjfechaSeguimiento = result.Item2;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            fnHabilitarGroupBoxsProspectoPlan(true);
            //FunValidaciones.fnHabilitarBoton(btnBuscarCliente, false);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, true);
        }

        private void btnNuevoSeguimiento_Click(object sender, EventArgs e)
        {
            fnLimpiarSeguimiento();
            fnHabilitarGroupBoxsSeguimiento(true);

            FunValidaciones.fnHabilitarBoton(btnNuevoSeguimiento, true);
            FunValidaciones.fnHabilitarBoton(btnGuardarSeguimiento, true);

        }

        private void fnHabilitarGroupBoxsSeguimiento(Boolean est)
        {

            gbSeguimiento.Enabled = est;
            
            
        }

        private void txtObservacionSeguimiento_TextChanged(object sender, EventArgs e)
        {
            var result = FunValidaciones.fnValidarTexboxs(txtObservacionSeguimiento, erObservacionSeguimiento, imgObservacionSeguimiento, true, true, true, 5, 1000, 1000, 1000, "Complete correctamente el campo");
            estObservacionSeguimiento = result.Item1;
            msjObservacionSeguimiento = result.Item2;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            fnLimpiarControlesVisita();
            
            fnHabilitarGroupBoxsProspectoPlan(true);
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, true);
            tabRegistroVisitas.AutoScroll = false;
        }

       
        private Boolean fnListarProspectoPlanEspecifico(SiticoneDataGridView dgv,Int32 opc)
        {
            BLProspecto objAcc = new BLProspecto();
            ProspectosPlan lstPros = new ProspectosPlan();
            DataTable dtAccesorio = new DataTable();
            clsUtil objUtil = new clsUtil();
            Int32 idProspectoPlan = 0;
            try
            {
               
                idProspectoPlan = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value.ToString());

                if (idProspectoPlan == 0)
                {
                    fnBuscarClienteXTelefono(1);
                    lnTipoConOferta = 2;
                }
                else
                {
                    lstPros = objAcc.blListarProspectoPlanDataGrid(idProspectoPlan, 1);
                    lnTipoConOferta = 1;
                    tabRegistroVisitas.AutoScroll = false;
                    if (lstPros.idProspecto > 0)
                    {
                        txtCelular1.ReadOnly = true;

                        lnTipoConOferta = 1;
                        estActualizar = true;
                        txtActualizar2.Text = Convert.ToString(lstPros.celular2.ToString().Trim());
                        txtIdCliente.Text = Convert.ToString(lstPros.idProspecto.ToString().Trim());
                        txtIdVisita.Text = Convert.ToString(lstPros.idProspectoPlan.ToString().Trim());
                        txtCelular1.Text = lstPros.celular1.ToString().Trim();
                        txtCelular2.Text = lstPros.celular2.ToString().Trim();
                        txtNombre.Text = lstPros.nombres.ToString().Trim();
                        txtApellido.Text = lstPros.apellidos.ToString().Trim();
                        txtCorreo.Text = lstPros.correo.ToString().Trim();
                        dtpFechaVisita.Value = lstPros.fechaVisita;
                        cboEstado.SelectedValue = lstPros.estadoCliente.ToString();
                        cboClase.SelectedValue = Convert.ToInt32(lstPros.idClase.ToString().Trim());
                        cboModUso.SelectedValue = Convert.ToInt32(lstPros.idModoUso.ToString().Trim());
                        cboTipoContacto.SelectedValue = Convert.ToString(lstPros.idTipoContacto.ToString().Trim());
                        txtObservacion.Text = Convert.ToString(lstPros.observaciones.ToString().Trim());
                        cboTipoPlan.SelectedValue = 0;
                        cboTipoPlan.SelectedValue = Convert.ToInt32(lstPros.idTipoPlan.ToString().Trim());
                        stIdTarifa = lstPros.idTarifa;
                        cboPlan.SelectedValue = Convert.ToInt32(lstPros.idPlan.ToString().Trim());

                        String nombreUsuario = lstPros.nombreUsuario == null ? "" : lstPros.nombreUsuario.ToString().Trim(); 
                        lblUsuarioVisita.Text = "Visita Registrada por: " + nombreUsuario;
                        txtCantEquipos.Text = Convert.ToString(lstPros.cantEquipos.ToString().Trim());
                        
                        
                        tabControl.SelectedIndex = 0;
                        
                        if(lstPros.estadoCliente == "ESPR0001")
                        {
                            FunValidaciones.fnHabilitarBoton(btnEditar, true);
                            
                            btnEstadoCliente.Visible = true;
                            lblEstadoVisita.Visible = true;
                            btnEstadoCliente.FillColor = Variables.ColorSuccess;
                            lblEstadoVisita.Text = "ESTADO DE VISITA: POTENCIAL";
                            lblEstadoVisita.ForeColor = Variables.ColorSuccess;
                            lblEstadoSeguimiento.Text = "ESTADO DE SEGUIMIENTO: POTENCIAL";
                            lblEstadoSeguimiento.ForeColor = Variables.ColorSuccess;
                        }
                        else if(lstPros.estadoCliente == "ESPR0002")
                        {
                            btnEstadoCliente.Visible = true;
                            lblEstadoVisita.Visible = true;
                            FunValidaciones.fnHabilitarBoton(btnEditar, false);
                            btnEstadoCliente.FillColor = Color.FromArgb(214, 166, 54);
                            lblEstadoVisita.Text = "⭐ ESTADO DE VISITA: COMPRADOR ⭐";
                            lblEstadoVisita.ForeColor = Color.FromArgb(214, 166, 54);
                            lblEstadoSeguimiento.Text = "⭐ NO SE PUEDE HACER MÁS SEGUIMIENTOS YA QUE SE CONVIRTIÓ EN: COMPRADOR ⭐";
                            lblEstadoSeguimiento.ForeColor = Color.FromArgb(214, 166, 54);
                        }
                        else
                        {
                            btnEstadoCliente.Visible = true;
                            lblEstadoVisita.Visible = true;
                            FunValidaciones.fnHabilitarBoton(btnEditar, false);
                            btnEstadoCliente.FillColor = Color.FromArgb(85, 5, 166);
                            lblEstadoVisita.Text = "🚫 ESTADO DE VISITA: RETIRADO";
                            lblEstadoVisita.ForeColor = Color.FromArgb(85, 5, 166);
                            lblEstadoSeguimiento.Text = "🚫 NO SE PUEDE HACER MÁS SEGUIMIENTOS YA QUE SE CONVIRTIÓ EN: RETIRADO";
                            lblEstadoSeguimiento.ForeColor = Color.FromArgb(85, 5, 166);
                        }
                        fnHabilitarGroupBoxsProspectoPlan(false);
                        
                        FunValidaciones.fnHabilitarBoton(btnGuardar, false);
                        
                        if(opc == 1)
                        {
                            if(dgv == dgProspecto)
                            {
                                dgv.Visible = true;
                            }
                            else
                            {
                                dgv.Visible = false;
                            }
                            
                        }

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

        private void frmSeguimiento_Load(object sender, EventArgs e)
        {
            estPasoLoad = false;
            tabRegistroVisitas.AutoScroll = false;
            Boolean bResult = false;
            FunValidaciones.fnColorTresBotones(btnNuevo, btnEditar, btnGuardar);
           
            FunValidaciones.fnColorBoton2(btnNuevoSeguimiento, btnGuardarSeguimiento);
            bResult = fnLLenarClaseVehiculo();
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Clase Vehiculo", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboEstadoSeguimiento, "ESPR", false);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Estado Cliente", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboEstado, "ESPR", false);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Estado Cliente", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboTipoContacto, "TICT", false);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Tipo Contacto", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboBuscarEstadoCliente, "ESPR", true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Estado Cliente", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = FunGeneral.fnLlenarTablaCodTipoCon(cboBuscarTipoContacto, "TICT", true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Estado Cliente", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            bResult = fnLLenarUsuario(cboUsuarioBuscar, 1, true);
            if (!bResult)
            {
                MessageBox.Show("Error al Cargar - Usuario", "Avise a Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            rdbFechaSigSeg.Checked = true;
            dtpFechaInicialBusqueda.Value = Variables.gdFechaSis.AddDays(-30);
            dtpFechaFinalBusqueda.Value = Variables.gdFechaSis;
            dtpFechaProximoSeguimiento.Value = Variables.gdFechaSis;
            cboBuscarEstadoCliente.SelectedValue = "ESPR0001";
            gbPaginacionProsPlan.Visible = false;
            gbPaginacionSeg.Visible = false;
            gbRanking.Visible = false;
            fnHabilitarGroupBoxsProspecto(false);
            fnHabilitarGroupBoxsProspectoPlan(false);
            fnHabilitarGroupBoxsSeguimiento(false);
            fnLlenarTipoPlan(-1, cboTipoPlan, 0);
            fnLlenarTipoPlan(-1, cboBuscarTipoPlan, 1);
            fnLlenarTipoTarifa(0, cboBuscarTipoTarifa, true);
            fnLimpiarControlesProspecto();
            fnLimpiarControlesVisita();
            fnInicializarTablaTarifas();
            FunValidaciones.fnHabilitarBoton(btnEditar, false);
            FunValidaciones.fnHabilitarBoton(btnGuardar, false);
            dgPrediccionResultados.Visible = false;
            dtpFechaInicialBusqueda.Enabled = false;
            dtpFechaFinalBusqueda.Enabled = false;
            estPasoLoad = true;
        }

        private DateTime fnCalcularSoloFecha(DateTime fecha)
        {
            String TextSoloFecha = fecha.ToString("yyyy/MM/dd");
            DateTime dtFecha = Convert.ToDateTime(TextSoloFecha);
            return dtFecha;
        }
        private Boolean fnLLenarClaseVehiculo()
        {
            BLAttrVehiculo objClaseV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();
            List<ClaseVehiculo> lstClase = new List<ClaseVehiculo>();

            try
            {
                lstClase = objClaseV.blDevolverClaseV(0);
                cboClase.ValueMember = "idClase";
                cboClase.DisplayMember = "cNomClase";
                cboClase.DataSource = lstClase;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarClaseVehiculo", ex.Message);
                return false;
            }
            finally
            {
                lstClase = null;
            }
        }

        private Boolean fnLLenarUsuario(SiticoneComboBox cbo,Int32 tipoCon,Boolean buscar)
        {
            BLUsuario objClaseV = new BLUsuario();
            clsUtil objUtil = new clsUtil();
            List<Usuario> lstClase = new List<Usuario>();

            try
            {
                lstClase = objClaseV.blDevolverSoloUsuario(tipoCon,buscar);
                cbo.ValueMember = "idUsuario";
                cbo.DisplayMember = "cUser";
                cbo.DataSource = lstClase;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarVehiculo", "fnLLenarClaseVehiculo", ex.Message);
                return false;
            }
            finally
            {
                lstClase = null;
            }
        }
        private Boolean fnLLenarUsoxClase(Int32 idClase)
        {
            BLAttrVehiculo objMarcaV = new BLAttrVehiculo();
            clsUtil objUtil = new clsUtil();

            List<ModUsoVehiculo> lstMarcaV = new List<ModUsoVehiculo>();

            try
            {

                lstMarcaV = objMarcaV.blDevolverModUsoV(idClase);
                cboModUso.DataSource = null;
                cboModUso.ValueMember = "idUso";
                cboModUso.DisplayMember = "cUso";
                cboModUso.DataSource = lstMarcaV;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLLnenarProvinciaxDepa", ex.Message);
                return false;
            }
            finally
            {
                lstMarcaV = null;
            }
        }
        private Boolean fnLLenarPlanxTipoPlan(SiticoneComboBox cbo, Boolean buscar, Int16 tipoCon, Int32 idTipoPlan)
        {
            BLPlan objMarcaV = new BLPlan();
            clsUtil objUtil = new clsUtil();
            List<Plan> lstMarcaV = new List<Plan>();
            try
            {

                lstMarcaV = objMarcaV.blDevolverPlanDeTipoPlan(idTipoPlan, buscar, tipoCon);
                lstPlan = lstMarcaV;
                cbo.DataSource = null;
                cbo.ValueMember = "idPlan";
                cbo.DisplayMember = "nombrePlan";
                cbo.DataSource = lstMarcaV;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLLnenarProvinciaxDepa", ex.Message);
                return false;
            }
            finally
            {
                lstMarcaV = null;
            }
        }
        private void cboClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResul = false;
            Int32 idClase = Convert.ToInt32(cboClase.SelectedValue == null ? "0" : cboClase.SelectedValue.ToString());
            if (idClase != 0)
            {
                bResul = fnLLenarUsoxClase(idClase);

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Provincias por Departamento", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cboModUso.Enabled = true;
            }
            else
            {
                bResul = fnLLenarUsoxClase(idClase);

                if (!bResul)
                {
                    MessageBox.Show("Error al Cargar Provincias por Departamento", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cboModUso.Enabled = false;
            }
            var result = Funciones.FunValidaciones.fnValidarCombobox(cboClase, erClase, imgClase);
            estClase = result.Item1;
            msjClase = result.Item2;
        }

        private Boolean fnLlenarTipoPlan(Int32 idTipoPlan, SiticoneComboBox cbo, Int32 tipBusqueda)
        {
            BLTipoPlan objTipPlan = new BLTipoPlan();
            clsUtil objUtil = new clsUtil();
            List<TipoPlan> lstTipPlan = new List<TipoPlan>();

            try
            {
                lstTipPlan = objTipPlan.blDevolverTipoPlan(idTipoPlan, tipBusqueda);

                cbo.ValueMember = "idTipoPlan";
                cbo.DisplayMember = "nombreTipoPlan";
                cbo.DataSource = lstTipPlan;
                lstTipoPlan = lstTipPlan;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }
        private Boolean fnLlenarTipoTarifa(Int32 idTipoPlan, SiticoneComboBox cbo, Boolean busqueda)
        {
            BLTipoTarifa objTipTarifa = new BLTipoTarifa();
            clsUtil objUtil = new clsUtil();
            List<TipoTarifa> lstTipTarifa = new List<TipoTarifa>();

            try
            {
                lstTipTarifa = objTipTarifa.blDevolverTipoTarifa(idTipoPlan, busqueda);

                cbo.ValueMember = "IdTipoTarifa";
                cbo.DisplayMember = "Nombre";
                cbo.DataSource = lstTipTarifa;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            var result = Funciones.FunValidaciones.fnValidarTexboxs(txtNombre, erNombre, imgNombre, true, true, false, 0, 0, 0, 45, "Complete correctamente el campo");
            estNombre = result.Item1;
            msjNombre = result.Item2;
        }

       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String lcResultado;
            
           
            txtNumCelular2_TextChanged(sender, e);
            txtNombre_TextChanged(sender, e);
            txtApellido_TextChanged(sender, e);
            txtCorreoElectronico_TextChanged_1(sender, e);
            
            dtpFechaVenida_ValueChanged(sender, e);
            txtObservacion_TextChanged(sender, e);
            var result1 = FunValidaciones.fnValidarCombobox(cboEstado, erEstadoCliente, imgEstadoCliente);
            estEstadoCliente = result1.Item1;
            msjEstadoProspecto = result1.Item2;

            var result2 = Funciones.FunValidaciones.fnValidarCombobox(cboClase, erClase, imgClase);
            estClase = result2.Item1;
            msjClase = result2.Item2;
            var result3 = Funciones.FunValidaciones.fnValidarCombobox(cboModUso, erModoUso, imgUso);
            estModoUso = result3.Item1;
            msjModoUso = result3.Item2;
            var result4 = Funciones.FunValidaciones.fnValidarCombobox(cboTipoContacto, erTipoContacto, imgTipoContacto);
            estTipoContacto = result4.Item1;
            msjTipoContacto = result4.Item2;
            var result5 = Funciones.FunValidaciones.fnValidarCombobox(cboTipoPlan, erTipoPlan, imgTipoPlan);
            estTipoPlan = result5.Item1;
            msjTipoPlan = result5.Item2;
            var result6 = Funciones.FunValidaciones.fnValidarCombobox(cboPlan, erPlan, imgPlan);
            estPlan = result6.Item1;
            msjPlan = result6.Item2;

            var result7 = fnValidarTarifas();
            estTarifa = result7.Item1;
            msjTarifa = result7.Item2;

            if (estCelular1 & estCelular2 & estNombre & estApellido & estCorreo & estEstadoCliente & estClase & estModoUso & estTipoContacto & estObservaciones & estTipoPlan & estPlan & estFechaVenida & estTarifa)
            {
                lcResultado = fnGuardarProspectoPlan();
                if (lcResultado == "OK")
                {
                    MessageBox.Show("Se Grabó Satisfactoriamente Accesorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    fnLimpiarControlesVisita();
                }
                else
                {
                    MessageBox.Show("Error al Grabar Accesorio. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Complete correctamente los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private String fnGuardarProspectoPlan()
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLProspecto objAttrV = new BLProspecto();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            ProspectosPlan objProspecto = new ProspectosPlan();
            //Boolean bCargar = false;

            try
            {
                Int32 tipoCon = lnTipoConOferta;
                String idProspecto = txtIdCliente.Text.ToString() == "" ? "0" : txtIdCliente.Text.ToString();
                objProspecto.idProspectoPlan = Convert.ToInt32(txtIdVisita.Text.Trim());
                objProspecto.idProspecto = Convert.ToInt32(idProspecto);
                objProspecto.celular1 = Convert.ToString(txtCelular1.Text.Trim());
                objProspecto.celular2 = Convert.ToString(txtCelular2.Text.Trim());
                objProspecto.nombres = Convert.ToString(txtNombre.Text.Trim());
                objProspecto.apellidos = Convert.ToString(txtApellido.Text.Trim());
                objProspecto.correo = Convert.ToString(txtCorreo.Text.Trim());
                objProspecto.estadoCliente = Convert.ToString(cboEstado.SelectedValue.ToString());
                objProspecto.idClase = Convert.ToInt32(cboClase.SelectedValue.ToString());
                objProspecto.idModoUso = Convert.ToInt32(cboModUso.SelectedValue.ToString());
                objProspecto.idTipoContacto = Convert.ToString(cboTipoContacto.SelectedValue.ToString());
                objProspecto.observaciones = Convert.ToString(txtObservacion.Text.Trim());
                objProspecto.idTipoPlan = Convert.ToInt32(cboTipoPlan.SelectedValue.ToString());
                objProspecto.idPlan = Convert.ToInt32(cboPlan.SelectedValue.ToString());
                objProspecto.idEquipo = 0;
                objProspecto.cantEquipos = Convert.ToInt32(txtCantEquipos.Text.Trim());
                objProspecto.idUsuario = Variables.gnCodUser;
                objProspecto.fechaVisita = Convert.ToDateTime(dtpFechaVisita.Value);
                objProspecto.fechaRegistro = Variables.gdFechaSis;
                objProspecto.idTarifa = fnRetornarIdTarifa();

                lcValidar = objAttrV.blGrabarProspectoPlan(objProspecto, tipoCon).Trim();

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarAccesorio", "fnGuardarAccesorio", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private Tuple<Boolean,String> fnValidarTarifas()
        {
            String msj = "";
            foreach (DataGridViewRow fila in dgvTarifas.Rows)
            {
                Boolean EstadoCheck = Convert.ToBoolean(fila.Cells[10].Value);
                if (EstadoCheck)
                {
                    imgTarifas.Image = Properties.Resources.ok;
                    erTarifas.ForeColor = Variables.ColorSuccess;
                    erTarifas.Text = msj;
                    return Tuple.Create(true, "");
                }
            }

            msj = "Seleccione una Tarifa";
            imgTarifas.Image = Properties.Resources.error;
            erTarifas.ForeColor = Variables.ColorError;
            erTarifas.Text = msj;
            return Tuple.Create(false, msj);
            
        }

        private String fnGuardarProspecto()
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLProspecto objAttrV = new BLProspecto();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Prospecto objProspecto = new Prospecto();
            //Boolean bCargar = false;

            try
            {
                Int32 tipoCon = lnTipoConProspectos;
                objProspecto.idProspecto = Convert.ToInt32(txtIdVisita.Text.Trim());
                objProspecto.nombres = Convert.ToString(txtNombre.Text.Trim());
                objProspecto.apellidos = Convert.ToString(txtApellido.Text.Trim());
                //objProspecto.celular1 = Convert.ToString(txtNumCelular1.Text.Trim());
                objProspecto.celular2 = Convert.ToString(txtCelular2.Text.Trim());
                objProspecto.idUsuario = Variables.gnCodUser;
                objProspecto.fechaRegistro = Variables.gdFechaSis;

                lcValidar = objAttrV.blGrabarProspecto(objProspecto, tipoCon).Trim();

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarAccesorio", "fnGuardarAccesorio", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private String fnGuardarSeguimiento()
        {
            DateTime dFechaSis = Variables.gdFechaSis;
            BLProspecto objAttrV = new BLProspecto();
            clsUtil objUtil = new clsUtil();
            String lcValidar = "";
            Seguimiento objProspecto = new Seguimiento();
            //Boolean bCargar = false;

            try
            {
                Int32 tipoCon = lnTipoConOferta;
                objProspecto.idSeguimiento = Convert.ToInt32(0);
                objProspecto.idProspectoPlan = Convert.ToInt32(txtIdVisita.Text.Trim());
                objProspecto.observacion = Convert.ToString(txtObservacionSeguimiento.Text.Trim());
                objProspecto.idUsuario = Variables.gnCodUser;
                DateTime fechSigSeg = Convert.ToDateTime(dtpFechaProximoSeguimiento.Value);
                DateTime soloFechaSigSeguimiento = fnCalcularSoloFecha(fechSigSeg);
                Int32 horasSigSeguimiento = Convert.ToInt32(txtHoraSigSeguimiento.Value.ToString());
                DateTime FechaConHoraSigSeguimiento = soloFechaSigSeguimiento.AddHours(horasSigSeguimiento);
                
                
                objProspecto.fechaProxSeguimiento = FechaConHoraSigSeguimiento;
                objProspecto.estadoCliente = Convert.ToString(cboEstadoSeguimiento.SelectedValue);
                objProspecto.fechaRegistro = Convert.ToDateTime(dtpFechaRegSeguimiento.Value);

                lcValidar = objAttrV.blGrabarSeguimiento(objProspecto, tipoCon).Trim();

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegitsrarAccesorio", "fnGuardarAccesorio", ex.Message);
                lcValidar = "NO";
            }

            return lcValidar;

        }

        private void fnLimpiarSeguimiento()
        {

            ////TEXBOX
            txtObservacionSeguimiento.Text = "";
            cboEstadoSeguimiento.SelectedValue = "0";
            txtHoraSigSeguimiento.Value = 0;
            ////DATATIMEPICKER
            dtpFechaProximoSeguimiento.Value = Variables.gdFechaSis;
            dtpFechaRegSeguimiento.Value = Variables.gdFechaSis;

            /////LABELS
            erObservacionSeguimiento.Text = "";
            erFechaSigSeguimiento.Text = "";
            erEstadoSeguimiento.Text = "";
            erFechaRegSeguimiento.Text = "";
            /////PICTUREBOXS
            imgObservacionSeguimiento.Image = null;
            imgFechaSigSeguimiento.Image = null;
            imgEstadoSeguimiento.Image = null;
            imgFechaRegSeguimiento.Image = null;
            //dtpFechaRegSeguimiento.Enabled = false;
           
        }
        private Boolean fnBuscarTablaProspectosPlan(String pcBuscar, Int32 numPagina, Int32 tipoCon, String lColor )
        {
            BLProspecto objAcc = new BLProspecto();
            clsUtil objUtil = new clsUtil();
            DataTable datAcces = new DataTable();
            totalRanking lstTotRan = new totalRanking();
            String estado, tipoContacto, celular;
            Int32 filas = 13;
            DateTime fechaInicial, fechaFinal, fechaActual;
            Boolean HabilitarFechas, estFechaVisita, estFechaRegSeg, estFechaProxSeg;
            Int32 idUsuario, idTipoPlan, idPlan, idTipoTarifa;
            try
            {
                estado = cboBuscarEstadoCliente.SelectedValue.ToString();
                tipoContacto = cboBuscarTipoContacto.SelectedValue.ToString();
                celular = txtBuscarCelular.Text.ToString();
                fechaInicial = fnCalcularSoloFecha(dtpFechaInicialBusqueda.Value);
                fechaFinal = fnCalcularSoloFecha(dtpFechaFinalBusqueda.Value);
                HabilitarFechas = Convert.ToBoolean(chkHabilitarFechas.Checked);
                estFechaVisita = Convert.ToBoolean(rdbFechaVisita.Checked);
                estFechaRegSeg = Convert.ToBoolean(rdbFechaRegSeg.Checked);
                estFechaProxSeg = Convert.ToBoolean(rdbFechaSigSeg.Checked);
                idUsuario = Convert.ToInt32(cboUsuarioBuscar.SelectedValue.ToString());
                fechaActual = Variables.gdFechaSis;
                idTipoPlan = Convert.ToInt32(cboBuscarTipoPlan.SelectedValue);
                idPlan = Convert.ToInt32(cboBuscarPlan.SelectedValue);
                idTipoTarifa = Convert.ToInt32(cboBuscarTipoTarifa.SelectedValue);

                DateTime DateFechActual = Convert.ToDateTime(fechaActual.ToString("dd/MM/yyyy HH:mm"));

                if (estado == "ESPR0001")
                {
                    lstTotRan = objAcc.blTotalesRankingSeguimiento(pcBuscar, celular, tipoContacto, fechaInicial, fechaFinal, HabilitarFechas, estFechaVisita, estFechaRegSeg, estFechaProxSeg, idUsuario, fechaActual, idTipoPlan, idPlan, idTipoTarifa);
                    btnVerde.Text = Convert.ToString(lstTotRan.totalVerdes);
                    btnAmarillo.Text = Convert.ToString(lstTotRan.totalAmarillos);
                    btnRojo.Text = Convert.ToString(lstTotRan.totalRojos);
                    lblUsuarioRanking.Text = Convert.ToString(cboUsuarioBuscar.Text) + " : ";
                    gbRanking.Visible = true;
                }
                else
                {
                    gbRanking.Visible = false;
                }

                datAcces = objAcc.blBuscarProspectoPlanDataTable(pcBuscar, celular, estado, numPagina, tipoCon, tipoContacto, fechaInicial, fechaFinal, HabilitarFechas, estFechaVisita, estFechaRegSeg, estFechaProxSeg, idUsuario, idTipoPlan, idPlan, idTipoTarifa, lColor, fechaActual);

                Int32 totalResultados = datAcces.Rows.Count;

                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("FECH. VISITA");
                    dt.Columns.Add("NOMBRES Y APELLIDOS");
                    dt.Columns.Add("TIP. PLAN");
                    dt.Columns.Add("PLAN");
                    dt.Columns.Add("TARIFA");
                    dt.Columns.Add("TIP. CONTACTO");
                    dt.Columns.Add("EST. CLIENTE");
                    dt.Columns.Add("CELULAR 1");
                    
                    if(rdbFechaVisita.Checked == true || rdbFechaRegSeg.Checked == true)
                    {
                        dt.Columns.Add("FECH. REGISTRO SEGUIMIENTO");
                    }
                    else
                    {
                        dt.Columns.Add("FECH. PRÓXIMO SEGUIMIENTO");
                    }
                    
                    dt.Columns.Add("USUARIO");
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
                        String ultimoSeg = "";
                        String EstadoVisita = datAcces.Rows[i][7].ToString().Trim();
                        if(EstadoVisita == "POTENCIAL")
                        {
                           
                            if (rdbFechaVisita.Checked == true || rdbFechaRegSeg.Checked == true)
                            {
                               
                                DateTime fechaultimaReg = Convert.ToDateTime(datAcces.Rows[i][9].ToString());
                                if (fechaultimaReg <= fechaActual)
                                {
                                    TimeSpan timDias = fechaActual - fechaultimaReg;
                                    Int32 numDias = timDias.Days;
                                    if (numDias >= 0 & numDias <= 2)
                                    {
                                        ultimoSeg = "✔ Hace " + numDias + " dias (" + fechaultimaReg + ")";

                                    }
                                    else if (numDias >= 3 & numDias <= 5)
                                    {
                                        ultimoSeg = "🕑 Hace " + numDias + " dias (" + fechaultimaReg + ")";
                                    }
                                    else
                                    {
                                        ultimoSeg = "❗ Hace " + numDias + " dias (" + fechaultimaReg + ")";
                                    }

                                }
                                else
                                {
                                    ultimoSeg = datAcces.Rows[i][9].ToString();
                                }
                            }
                            else
                            {
                                DateTime fechaAMostrar = DateFechActual;
                                DateTime fechaultimaSeg = Convert.ToDateTime(datAcces.Rows[i][9]);
                                DateTime DateUltimaSeg = Convert.ToDateTime(fechaultimaSeg.ToString("dd/MM/yyyy HH:mm"));
                                if (DateUltimaSeg >= DateFechActual)
                                {
                                    DateTime dtEdit = DateUltimaSeg.Hour==0? DateUltimaSeg.AddHours(-24): DateUltimaSeg;
                                    TimeSpan timDias = DateUltimaSeg - DateFechActual;
                                    TimeSpan timDiasHora =dtEdit - DateFechActual;
                                    if (DateUltimaSeg.Hour == 0 && dtEdit.Day == DateFechActual.Day)
                                    {

                                         fechaAMostrar = Convert.ToDateTime(DateFechActual.ToString("dd/MM/yyyy")).AddHours(Math.Abs(timDiasHora.Hours)).AddMinutes(Math.Abs(timDiasHora.Minutes));
                                    }
                                    else
                                    {
                                         fechaAMostrar = DateFechActual.AddHours(Math.Abs(timDiasHora.Hours)).AddMinutes(Math.Abs(timDiasHora.Minutes));
                                         

                                    }
                                    if (i==8)
                                    {

                                    }
                                    Int32 numDias = timDias.Days;
                                    String cDias = numDias==1?" dia ":" dias ";
                                    
                                    if (numDias == 0 && DateUltimaSeg.Day== DateFechActual.Day)
                                    {
                                        ultimoSeg = "❗ Llamar hoy  a las(" + fechaAMostrar.ToString("hh:mm tt")+")";
                                    }
                                    else if (numDias >= 1 && numDias <= 3)
                                    {
                                        ultimoSeg = "🕑 Llamar en " + (DateUltimaSeg.Day - DateFechActual.Day) + " Dias (" + DateUltimaSeg.ToString("dd, MMMM, yyyy hh:mm tt")+ ")";
                                    }else if ((DateUltimaSeg.Day - DateFechActual.Day)==1)
                                    {
                                        ultimoSeg = "🕑 Llamar en " + (DateUltimaSeg.Day - DateFechActual.Day) + " Dia "+ "(" + DateUltimaSeg.ToString("dd, MMMM, yyyy")+ ")";

                                    }
                                    else
                                    {
                                        ultimoSeg = "✔ Llamar en " + numDias + cDias + " (" + DateUltimaSeg.ToString("dd, MMMM, yyyy") + ")";

                                    }
                                }
                                else
                                {
                                    TimeSpan timDias = DateFechActual-DateUltimaSeg;
                                    TimeSpan timDiasHora = DateFechActual-DateUltimaSeg;
                                    if (DateUltimaSeg.Hour == 0)
                                    {

                                        fechaAMostrar = Convert.ToDateTime(DateFechActual.ToString("dd/MM/yyyy")).AddHours(Math.Abs(timDias.Hours)).AddMinutes(Math.Abs(timDias.Minutes));
                                    }
                                    else
                                    {
                                        fechaAMostrar = DateFechActual.AddHours(Math.Abs(timDias.Hours)).AddMinutes(Math.Abs(timDias.Minutes));

                                    }
                                    Int32 numDias = timDias.Days;
                                    String cDias = numDias == 1 ? " dia " : " dias ";
                                    if (numDias == 0)
                                    {
                                        ultimoSeg = "❗ Llamar hoy  a las(" + fechaAMostrar.ToString("hh:mm tt") + ")";
                                    }
                                    else
                                    {
                                        ultimoSeg = "❗ Retraso de llamada, pasó " + numDias + cDias + " (" + DateUltimaSeg.ToString("dd/MM/yyyy") + ") 👁 " ;
                                    }
                                }
                            }
                        }else if (EstadoVisita == "COMPRADOR")
                        {
                            if (rdbFechaVisita.Checked == true || rdbFechaRegSeg.Checked == true)
                            {
                                DateTime fechaultimaReg = Convert.ToDateTime(datAcces.Rows[i][9].ToString());
                                ultimoSeg = "⭐ (" + fechaultimaReg + ") ⭐";
                            }
                            else
                            {
                                ultimoSeg = "⭐Ya es COMPRADOR ⭐";
                            }
                        }
                        else
                        {
                            if (rdbFechaVisita.Checked == true || rdbFechaRegSeg.Checked == true)
                            {
                                DateTime fechaultimaReg = Convert.ToDateTime(datAcces.Rows[i][9].ToString());
                                ultimoSeg = "🚫 (" + fechaultimaReg + ")";
                            }
                            else
                            {
                                ultimoSeg = "🚫 Se RETIRÓ";
                            }
                        }
                        DateTime fechVisi = Convert.ToDateTime(datAcces.Rows[i][1]);
                        String fechaVisita = fechVisi.ToString("dd/MM/yyyy");
                        object[] row = {
                            datAcces.Rows[i][0],
                            y,
                            fechaVisita,
                            datAcces.Rows[i][2],
                            datAcces.Rows[i][3],
                            datAcces.Rows[i][4],
                            datAcces.Rows[i][5],
                            datAcces.Rows[i][6],
                            datAcces.Rows[i][7],
                            datAcces.Rows[i][8],
                            ultimoSeg,
                            datAcces.Rows[i][10]
                        };
                        dt.Rows.Add(row);

                    }
                    dgProspecto.DataSource = dt;
                    dgProspecto.Columns[0].Visible = false;
                    dgProspecto.Columns[1].Width = 15;
                    dgProspecto.Columns[2].Width = 50;
                    dgProspecto.Columns[3].Width = 100;
                    dgProspecto.Columns[4].Width = 40;
                    dgProspecto.Columns[5].Width = 35;
                    dgProspecto.Columns[6].Width = 50;
                    dgProspecto.Columns[7].Width = 48;
                    dgProspecto.Columns[8].Width = 48;
                    dgProspecto.Columns[9].Width = 48;
                    dgProspecto.Columns[10].Width = 165;
                    dgProspecto.Columns[11].Width = 65;
                    dgProspecto.Visible = true;

                    if (tipoCon == -1)
                    {
                        gbPaginacionProsPlan.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datAcces.Rows[0][11]);
                        fnCalcularPaginacion(totalRegistros, filas, totalResultados,cboPaginaProsPlan,btnTotalPagProsPlan,btnNumFilasProsPlan,btnTotalRegProsPlan);
                    }
                    else
                    {
                        btnNumFilasProsPlan.Text = Convert.ToString(totalResultados);
                    }
                    return true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dgProspecto.Visible = true;
                    dt.Columns.Add("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS");
                    dgProspecto.DataSource = dt;
                    gbPaginacionProsPlan.Visible = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private Boolean fnBuscarTablaProspectos(SiticoneDataGridView dgv, Int32 numPagina, Int32 tipoCon)
        {
            BLProspecto objAcc = new BLProspecto();
            clsUtil objUtil = new clsUtil();
            DataTable datAcces = new DataTable();
            List<Prospecto> lstAcce = null;
            Int32 filas = 10;

            try
            {
                lstAcce = new List<Prospecto>();

                //String numCelular = txtCelularBuscar.Text.ToString();
                //String nombreCliente = txtNombreBuscar.Text.ToString();
                //datAcces = objAcc.blBuscarProspectoDataTable( numCelular, nombreCliente, numPagina, tipoCon);
                datAcces = null;
                Int32 totalResultados = datAcces.Rows.Count;

                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("NOMBRES");
                    dt.Columns.Add("APELLIDOS");
                    dt.Columns.Add("N° CELULAR1");
                    dt.Columns.Add("N° CELULAR2");
                    dt.Columns.Add("FECHA REGISTRO");
                    dt.Columns.Add("USUARIO");

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


                        object[] row = {
                            datAcces.Rows[i][0],
                            y,
                            datAcces.Rows[i][1],
                            datAcces.Rows[i][2],
                            datAcces.Rows[i][3],
                            datAcces.Rows[i][4],
                            datAcces.Rows[i][5],
                            datAcces.Rows[i][6]
                        };
                        dt.Rows.Add(row);

                    }

                    dgv.DataSource = dt;

                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 40;
                    dgv.Columns[2].Width = 100;
                    dgv.Columns[3].Width = 100;
                    dgv.Columns[4].Width = 70;
                    dgv.Columns[5].Width = 70;
                    dgv.Columns[6].Width = 100;
                    dgv.Columns[7].Width = 100;
                    


                    dgv.Visible = true;

                    if (tipoCon == -1)
                    {
                        //gbPaginacionProspecto.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datAcces.Rows[0][7]);
                        //fnCalcularPaginacion(totalRegistros, filas, totalResultados,cboPagPros,btnPagTotalPros,btnNumfilasPros,btnTotalRegPros);
                    }
                    else
                    {
                        //btnNumfilasPros.Text = Convert.ToString(totalResultados);
                    }
                    return true;


                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dgv.Visible = true;
                    dt.Columns.Add("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS");
                    dgv.DataSource = dt;
                    //gbPaginacionProspecto.Visible = false;
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private Boolean fnBuscarTablaSeguimiento(Int32 idOferta, Int32 numPagina, Int32 tipoCon)
        {
            BLProspecto objAcc = new BLProspecto();
            clsUtil objUtil = new clsUtil();
            DataTable datAcces = new DataTable();
            Int32 filas = 15;

            try
            {

                datAcces = objAcc.blBuscarSeguimientoDataTable(idOferta, numPagina, tipoCon);

                Int32 totalResultados = datAcces.Rows.Count;

                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("FECH. REGISTRO");
                    dt.Columns.Add("OBSERVACION");
                    dt.Columns.Add("EST. CLIENTE");
                    dt.Columns.Add("USUARIO");
                    dt.Columns.Add("PROX. SEGUIMIENTO");

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
                        String EstadoCliente = datAcces.Rows[i][3].ToString();
                        String FechaSeg;
                        if(EstadoCliente == "POTENCIAL")
                        {
                            FechaSeg = datAcces.Rows[i][5].ToString();
                        }
                        else
                        {
                            FechaSeg = "NO TIENE";
                        }

                        object[] row = {
                            datAcces.Rows[i][0],
                            y,
                            datAcces.Rows[i][1],
                            datAcces.Rows[i][2],
                            datAcces.Rows[i][3],
                            datAcces.Rows[i][4],
                            FechaSeg
                        };
                        dt.Rows.Add(row);

                    }

                    dgSeguimiento.DataSource = dt;

                    dgSeguimiento.Columns[0].Visible = false;
                    dgSeguimiento.Columns[1].Width = 30;
                    dgSeguimiento.Columns[2].Width = 100;
                    dgSeguimiento.Columns[3].Width = 150;
                    dgSeguimiento.Columns[4].Width = 80;
                    dgSeguimiento.Columns[5].Width = 50;
                    dgSeguimiento.Columns[6].Width = 150;

                    dgSeguimiento.Visible = true;

                    if (tipoCon == -1)
                    {
                        gbPaginacionSeg.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(datAcces.Rows[0][6]);
                        fnCalcularPaginacionSeguimiento(totalRegistros, filas, totalResultados);
                    }
                    else
                    {
                        btnNumFilasProsPlan.Text = Convert.ToString(totalResultados);
                    }
                    return true;


                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dgSeguimiento.Visible = true;
                    dt.Columns.Add("AÚN NO HAY SEGUIMIENTOS PARA ESTE VISITA");
                    dgSeguimiento.DataSource = dt;
                    gbPaginacionSeg.Visible = false;
                    return false;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }
        private void fnCalcularPaginacion(Int32 totalRegistros, Int32 filas, Int32 totalResultados,ComboBox cboPag,SiticoneCircleButton btnTotPag, SiticoneCircleButton btnNumFil, SiticoneCircleButton btnTotReg)
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

            cboPag.Items.Clear();

            for (Int32 i = 1; i <= cantidadPaginas; i++)
            {
                cboPag.Items.Add(i);

            }

            cboPag.SelectedIndex = 0;
            btnTotPag.Text = Convert.ToString(cantidadPaginas);
            btnNumFil.Text = Convert.ToString(totalResultados);
            btnTotReg.Text = Convert.ToString(totalRegistros);

        }

        private void fnCalcularPaginacionSeguimiento(Int32 totalRegistros, Int32 filas, Int32 totalResultados)
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

            cboPaginaSeg.Items.Clear();

            for (Int32 i = 1; i <= cantidadPaginas; i++)
            {
                cboPaginaSeg.Items.Add(i);
            }

            cboPaginaSeg.SelectedIndex = 0;
            btnTotalPagiSeg.Text = Convert.ToString(cantidadPaginas);
            btnRegiSeg.Text = Convert.ToString(totalResultados);
            btnTotalSeg.Text = Convert.ToString(totalRegistros);


        }

        private void fnHabilitarGroupBoxsProspectoPlan(Boolean est)
        {
            gbDatosClienteProspecto.Enabled = est;
            gbVehiculo.Enabled = est;
            gbContacto.Enabled = est;
            gbPlan.Enabled = est;

        }
        private void fnVerValidacion(Boolean est)
        {


        }

        
    }
}
