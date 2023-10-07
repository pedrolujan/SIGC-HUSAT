using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmComparacionPlanes : Form
    {
        public frmComparacionPlanes()
        {
            InitializeComponent();
            
        }
        static Double precioPlanAnual = 0;
        static Double precioPlanMensual = 0;

        Double precioEquipoAnual = 0;
        Double precioEquipoMensual = 0;

        static Double precioTotal = 0;
        
        static Double cantEquiposAnual = 1;
        static Double  precioTotalContratoAnual = 0;
        static Double precioTotalContratoMensual = 0;
        static Double precioTotalContratoMensualPortabilidad = 0;

        static List<Plan> lstPlan;
        static List<Plan> lstPlanMensual;

        Boolean estPlan,estPlanMensual;
        String msjPlan,msjPlanMensual;

        private void frmComparacionPlanes_Load(object sender, EventArgs e)
        {
            fnLlenarTipoPlan(2, cboTipoPlanMensual, 0);
            cboTipoPlanMensual.SelectedValue = 2;

            fnLlenarTipoPlan(1, cboTipoPlanAnual, 0);
            cboTipoPlanAnual.SelectedValue = 1;
           
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


                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboTipoPlanAnual_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResul = false;
            bResul = fnLLenarPlanxTipoPlan(cboPlan, false, 0);

            if (!bResul)
            {
                MessageBox.Show("Error al Cargar Plan", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Boolean fnLLenarPlanxTipoPlan(SiticoneComboBox cbo, Boolean buscar, Int16 tipoCon)
        {
            BLPlan objMarcaV = new BLPlan();
            clsUtil objUtil = new clsUtil();
            List<Plan> lstMarcaV = new List<Plan>();
            Int32 idTipoPlan;
            try
            {
                idTipoPlan = Convert.ToInt32(cboTipoPlanAnual.SelectedValue == null ? "0" : cboTipoPlanAnual.SelectedValue.ToString());

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

        private Boolean fnLLenarPlanxTipoPlanMensual(SiticoneComboBox cbo, Boolean buscar, Int16 tipoCon)
        {
            BLPlan objMarcaV = new BLPlan();
            clsUtil objUtil = new clsUtil();
            List<Plan> lstMarcaV = new List<Plan>();
            Int32 idTipoPlan;
            try
            {
                idTipoPlan = Convert.ToInt32(cboTipoPlanMensual.SelectedValue == null ? "0" : cboTipoPlanMensual.SelectedValue.ToString());

                lstMarcaV = objMarcaV.blDevolverPlanDeTipoPlan(idTipoPlan, buscar, tipoCon);
                lstPlanMensual = lstMarcaV;
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

        private void fnCalcularAhorro()
        {
            Double totalAhorro = 0;
            if ((Convert.ToInt32(cboPlan.SelectedValue) != 0 && Convert.ToInt32(cboPlanMensual.SelectedValue) != 0) &&
                Convert.ToString(cboPlan.Text) == Convert.ToString(cboPlanMensual.Text))
            {
                if (precioTotalContratoAnual > precioTotalContratoMensual)
                {
                    totalAhorro = precioTotalContratoAnual - precioTotalContratoMensual;
                }
                else if (precioTotalContratoAnual < precioTotalContratoMensual)
                {
                    totalAhorro = precioTotalContratoMensual - precioTotalContratoAnual;
                }
                lblAhorro.Text = "S/ " + String.Format("{0:0.00}", totalAhorro);

            }
            else
            {
                gbDatosContratoMensual.Visible = false;
                lblAhorro.Text = "S/ " + String.Format("{0:0.00}", totalAhorro);
            }

        }
        private void cboTipoPlanMensual_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bResul = false;
            bResul = fnLLenarPlanxTipoPlanMensual(cboPlanMensual, false, 0);

            if (!bResul)
            {
                MessageBox.Show("Error al Cargar Plan", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private Boolean fnListarEquipos(String equipos,String periodo)
        {
            clsUtil objUtil = new clsUtil();
            XmlEquiposProspecto.Items objAcc = new XmlEquiposProspecto.Items();
            Int32 totalResultados;
            Int32 y = 0;
            DataTable dt = new DataTable();
            DataGridView tabla= new DataGridView();
            Double precio = 0;
            try
            {
                tabla = (periodo == "anual") ? dgEquiposPlan : dgEquiposPlanMensual;
                precio = (periodo == "anual") ? precioEquipoAnual : precioEquipoMensual;
                if (equipos == null || equipos == "")
                {
                    dt.Clear();
                    dt.Columns.Add("NO SE ENCONTRÓ EQUIPOS PARA ESE PLAN");
                    
                   
                    tabla.DataSource = dt;
                    precio = 0;

                    return true;
                }
                else
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(XmlEquiposProspecto.Items));
                    using (TextReader reader = new StringReader(equipos))
                    {
                        //de esta manera se deserializa
                        objAcc = (XmlEquiposProspecto.Items)serializer.Deserialize(reader);
                    }

                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("EQUIPO");
                    dt.Columns.Add("PRECIO");
                    dt.Columns.Add("PRECIO NORMAL");
                    dt.Columns.Add("ELEGIR", typeof(Boolean));
                    Boolean estado = false;
                    totalResultados = objAcc.Item.Count;
                    for (int i = 0; i <= totalResultados - 1; i++)
                    {
                        y += 1;
                        if (objAcc.Item[i].BEstado)
                        {
                            
                            object[] row = {
                                objAcc.Item[i].IdPlanEquipo,
                                y,
                                objAcc.Item[i].Equipos,
                                "S/ " + String.Format("{0:0.00}", objAcc.Item[i].CPrecio),
                                Convert.ToDouble(objAcc.Item[i].CPrecio),
                                Convert.ToBoolean(false)
                            };
                            dt.Rows.Add(row);
                        }

                    }

                    tabla.DataSource = dt;
                    tabla.Rows[0].Cells[5].Value = true;
                    tabla.Columns[0].Visible = false;
                    tabla.Columns[1].Width = 20;
                    tabla.Columns[2].Width = 200;
                    tabla.Columns[3].Width = 50;
                    tabla.Columns[4].Visible = false;
                    tabla.Columns[5].Width = 50;
                   

                    return true;
                }

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarEquipo", "fnListarEquipoEspcifico", ex.Message);
                return false;

            }



        }
        private void fnCalcularPrecioEquipoAnual()
        {
            foreach (DataGridViewRow dgvRenglon in dgEquiposPlan.Rows)
            {
                Boolean EstadoCheck = Convert.ToBoolean(dgvRenglon.Cells[5].Value);
                if (EstadoCheck)
                {
                    precioEquipoAnual = Convert.ToDouble(dgvRenglon.Cells[4].Value);
                }

            }
        }
        private void fnCalcularPrecioEquipoMensual()
        {
            foreach (DataGridViewRow dgvRenglon in dgEquiposPlanMensual.Rows)
            {
                Boolean EstadoCheck = Convert.ToBoolean(dgvRenglon.Cells[5].Value);
                if (EstadoCheck)
                {
                    precioEquipoMensual = Convert.ToDouble(dgvRenglon.Cells[4].Value);
                }

            }
        }
        private Double fnRetornarPrecioPlan(List<Plan> lista, Int32 idPlan)
        {
            Int32 TotalPlan = Convert.ToInt32(lista == null ? 0 : lista.Count);
            for (int i = 0; i <= TotalPlan - 1; i++)
            {
                if (lista[i].idPlan == idPlan)
                {
                    return lista[i].precio;
                }
            }
            return 0;
        }
        private void CalcularTotal(String Periodo)
        {
            //Int32 idTipoPlan = Convert.ToInt32(cboTipoPlanAnual.SelectedValue == null ? "0" : cboTipoPlanAnual.SelectedValue.ToString());
            if (Periodo =="anual")
            {
                fnCalcularPrecioEquipoAnual();
                Double precioPlanXCanEquipos = 0;
                Int32 cantidadEquiposAnual = 0;
                Double precioTotalAnual = 0;
                if (Convert.ToString(cboPlan.Text) == "PORTABILIDAD")
                {
                    txtCantEquiposAnual.Enabled = false;
                    label11.Enabled = false;
                }
                else
                {
                    txtCantEquiposAnual.Enabled = true;
                    label11.Enabled = true;
                }
                if (Convert.ToString(cboPlanMensual.Text) == "PORTABILIDAD")
                {
                    
                    gbPlanMensualPortabilidad.Visible = true;
                    gbDatosContratoMensual.Visible = false;
                   
                }
                else
                {

                    gbPlanMensualPortabilidad.Visible = false;
                    gbDatosContratoMensual.Visible = true;
                    if (Convert.ToInt32(txtCantEquiposAnual.Text.Length) > 0)
                    {
                        cantidadEquiposAnual = Convert.ToInt32(txtCantEquiposAnual.Text);
                    }
                    else
                    {
                        cantidadEquiposAnual = 1;
                    }
                    

                    //lblTotalAnual.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Strikeout, GraphicsUnit.Point);
                }
                precioTotalAnual = (precioEquipoAnual * cantidadEquiposAnual);

                precioPlanXCanEquipos =(Convert.ToString(cboPlan.Text) == "PORTABILIDAD")?precioPlanAnual:(precioPlanAnual * cantidadEquiposAnual);
                precioTotalContratoAnual = (precioTotalAnual + precioPlanXCanEquipos);


                //lblPrecioPlan.Text = "S/ " + String.Format("{0:0.00}", precioPlan);
                //lblPrecioEquipo.Text = "S/ " + String.Format("{0:0.00}", precioEquipos);
                lblTotalAnual.Text = "S/ " + String.Format("{0:0.00}", precioTotalContratoAnual);
                //lblTotalMensual.Text = "S/ " + String.Format("{0:0.00}", (precioTotal / 12));

            }
            else
            {
                fnCalcularPrecioEquipoMensual();
                Double precioEquipos = 0;
                Double PrecioPlanAnual = 0;
                Double precioPlanmensualVar = 0;
                Double precioServicio = 100;
                Double cantEquiposMensual = 1;
                Double pagoPrimerMes = 0;
                Double Precio11Meses = 0;
                Double PrecioTotalPortabiolidad = 0;


                if (Convert.ToString(cboPlanMensual.Text) == "PORTABILIDAD")
                {
                    gbPlanMensualPortabilidad.Visible = true;
                    gbDatosContratoMensual.Visible = false;

                    lblPrecioServicio.Text= "S/ " + String.Format("{0:0.00}", precioServicio);
                    lblRentaAdelantada.Text = "S/ " + String.Format("{0:0.00}", precioPlanMensual);
                    pagoPrimerMes = (precioServicio+ precioPlanMensual);
                    lblPagoPrimerMes.Text= "S/ " + String.Format("{0:0.00}", pagoPrimerMes);

                    lblPagoMensualPortabilidad.Text= "S/ " + String.Format("{0:0.00}", precioPlanMensual);
                    Precio11Meses = (precioPlanMensual*11);
                    lblPago11Meses.Text = "S/ " + String.Format("{0:0.00}", Precio11Meses);
                    precioTotalContratoMensual = (pagoPrimerMes+ Precio11Meses);
                    lblPagoTotalMensualPortabilidad.Text= "S/ " + String.Format("{0:0.00}", precioTotalContratoMensual);
                }
                else
                {
                    if (Convert.ToInt32(txtCantEquipoMensual.Text.Length) > 0)
                    {
                        cantEquiposMensual = Convert.ToInt32(txtCantEquipoMensual.Text);
                     
                    }
                    else
                    {
                        cantEquiposMensual = 1;
                    }

                    gbPlanMensualPortabilidad.Visible = false;
                    gbDatosContratoMensual.Visible = true;

                    precioEquipos = (cantEquiposMensual * precioEquipoMensual);
                    precioPlanmensualVar = precioPlanMensual * cantEquiposMensual;
                    PrecioPlanAnual = (precioPlanmensualVar * 12);

                    precioTotalContratoMensual = PrecioPlanAnual + precioEquipos;
                    lblContadorMeses.Text =Convert.ToString(cantEquiposMensual);

                    lblPrecioTotalEquipos.Text= "S/ " + String.Format("{0:0.00}", precioEquipos);
                    lblPagoMensual.Text = "S/ " + String.Format("{0:0.00}", precioPlanMensual);
                    lblPrecioEquipo.Text = "S/ " + String.Format("{0:0.00}", precioEquipoMensual);

                    lblTotalAnualContratoMensual.Text = "S/ " + String.Format("{0:0.00}", (precioPlanmensualVar+ precioTotalContratoMensual));
                }
               
            }

        }
        private void cboPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboPlan.SelectedValue)!=0)
            {
                cboPlanMensual.Enabled = true;
                pbPlanMensual.Visible = true;
                cboPlanMensual_SelectedIndexChanged(sender, e);
            }
            else
            {
                cboPlanMensual.Enabled = false;
                pbPlanMensual.Visible = false;
            }
            var result = FunValidaciones.fnValidarCombobox(cboPlan, lblPlanAnual, pbPlanAnual);
            estPlan = result.Item1;
            msjPlan = result.Item2;

            BLPlan objEquipo = new BLPlan();
            Boolean bResult = false;
            Plan lstEquipo = new Plan();
            precioEquipoAnual = 0;
            Int32 idPlan = Convert.ToInt32(cboPlan.SelectedValue == null ? "0" : cboPlan.SelectedValue.ToString());
            lstEquipo = objEquipo.blListarPlanProspecto(idPlan);

            bResult = fnListarEquipos(lstEquipo.equipos, "anual");

            if (!bResult)
            {
                MessageBox.Show("Error al Cargar Equipos de Plan", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            dgEquiposPlan.Enabled = true;


            precioPlanAnual = fnRetornarPrecioPlan(lstPlan, idPlan);

            CalcularTotal("anual");
            fnCalcularAhorro();
        }

        private void dgEquiposPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                foreach (DataGridViewRow dgvRenglon in dgEquiposPlan.Rows)
                {

                    dgvRenglon.Cells[5].Value = false;
                }
                precioEquipoAnual = Convert.ToDouble(dgEquiposPlan.Rows[e.RowIndex].Cells[4].Value);
                CalcularTotal("anual");
            }
        }

        public static Tuple<Boolean, String> fnValidarComboboxMensual(SiticoneComboBox cbo1, SiticoneComboBox cbo2, Label lbl, PictureBox img)
        {
            String msj;
            if (Convert.ToInt32(cbo1.SelectedValue) == 0)
            {
                img.Image = Properties.Resources.error;
                lbl.ForeColor = Variables.ColorError;

                msj = "Seleccione plan anual";
                lbl.Text = msj;
                return Tuple.Create(false, msj);
            }
            else
            {

                if (cbo2.SelectedIndex == 0 || cbo2.SelectedIndex == -1 || cbo2.SelectedIndex == null)
                {
                    img.Image = Properties.Resources.error;


                    lbl.ForeColor = Variables.ColorError;

                    msj = "Seleccione una opción";
                    lbl.Text = msj;
                    return Tuple.Create(false, msj);

                }
                else if(Convert.ToString(cbo1.Text)!= Convert.ToString(cbo2.Text))
                {

                    img.Image = Properties.Resources.error;

                    lbl.ForeColor = Variables.ColorError;
                    msj = "Porfabor seleccione el mismo plan del contrato anual";
                    lbl.Text = msj;
                    return Tuple.Create(false, msj);


                }
                else
                {
                    img.Image = Properties.Resources.ok;

                    lbl.ForeColor = Variables.ColorSuccess;
                    msj = "";
                    lbl.Text = msj;
                    return Tuple.Create(true, msj);
                }
            }
        }
        private void cboPlanMensual_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = fnValidarComboboxMensual(cboPlan,cboTipoPlanMensual, lblPlanMensual, pbPlanMensual);
            estPlanMensual = result.Item1;
            msjPlanMensual = result.Item2;
            if (Convert.ToString(cboPlan.Text) == Convert.ToString(cboPlanMensual.Text))
            {
                if(Convert.ToString(cboPlanMensual.Text).Trim()== "PORTABILIDAD")
                {
                    gbDatosContratoMensual.Visible = false;
                    gbPlanMensualPortabilidad.Visible = true;

                }
                else
                {
                    gbDatosContratoMensual.Visible = true;
                    gbPlanMensualPortabilidad.Visible = false;

                }
                BLPlan objEquipo = new BLPlan();
                Boolean bResult = false;
                Plan lstEquipo = new Plan();
                precioEquipoMensual = 0;
                Int32 idPlan = Convert.ToInt32(cboPlanMensual.SelectedValue == null ? "0" : cboPlanMensual.SelectedValue);
                lstEquipo = objEquipo.blListarPlanProspecto(idPlan);

                bResult = fnListarEquipos(lstEquipo.equipos, "mensual");

                if (!bResult)
                {
                    MessageBox.Show("Error al Cargar Equipos de Plan", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                dgEquiposPlan.Enabled = true;
                

                precioPlanMensual = fnRetornarPrecioPlan(lstPlanMensual, idPlan);

                CalcularTotal("mensual");
                fnCalcularAhorro();
                //fnCalcularAhorro();

                lblPlanMensual.Text = "";
                lblPlanAnual.Text = "";

                pbPlanAnual.Image = Properties.Resources.ok;
                pbPlanMensual.Image = Properties.Resources.ok;
            }
            else
            {
                gbDatosContratoMensual.Visible = false;
                gbPlanMensualPortabilidad.Visible = false;
            }
        }

        private void dgEquiposPlanMensual_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                foreach (DataGridViewRow dgvRenglon in dgEquiposPlanMensual.Rows)
                {

                    dgvRenglon.Cells[5].Value = false;
                }
                precioEquipoMensual = Convert.ToDouble(dgEquiposPlanMensual.Rows[e.RowIndex].Cells[4].Value);
                CalcularTotal("mensual");
            }
        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(txtCantEquipoMensual.Text.Length)>0)
            //{
            //    cantEquipos = Convert.ToInt32(txtCantEquipoMensual.Text);
            CalcularTotal("mensual");
            fnCalcularAhorro();
            //}
            //else
            //{
            //    cantEquipos = 1;
            //}
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidadEquipoMensualPortabilidad_TextChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(txtCantidadEquipoMensualPortabilidad.Text.Length) > 0)
            //{
            //    cantEquipos = Convert.ToInt32(txtCantidadEquipoMensualPortabilidad.Text);
            //    CalcularTotal("mensual");
            //    fnCalcularAhorro();
            //}
            //else
            //{
            //    cantEquipos = 1;
            //}

        }

        private void txtCantEquiposAnual_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e,"NUMEROS",true);
        }

        private void txtCantidadEquipoMensualPortabilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtCantEquipoMensual_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunValidaciones.fnValidarTipografia(e, "NUMEROS", true);
        }

        private void txtCantEquipos_TextChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(txtCantEquiposAnual.Text.Length) > 0)
            //{
            //    cantEquiposAnual = Convert.ToInt32(txtCantEquiposAnual.Text);
            CalcularTotal("anual");
            fnCalcularAhorro();
            //}
            //else
            //{
            //    cantEquiposAnual = 1;
            //}

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
