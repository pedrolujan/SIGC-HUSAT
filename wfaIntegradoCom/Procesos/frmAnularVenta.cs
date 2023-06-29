using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaUtil;
using CapaDato;
using wfaIntegradoCom.Funciones;
using CapaEntidad;
using wfaIntegradoCom.Sunat;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmAnularVenta : Form
    {
        public frmAnularVenta()
        {
            InitializeComponent();
        }
        //MOD//
        static Int32 tabInicio;
        static Boolean EstadoAnulacion=false;
        Boolean estBusqueda=false;
        static String cDescripcion = "";
        static List<xmlDocumentoVentaGeneral> stXmlDocumentoVenta = new List<xmlDocumentoVentaGeneral>();
        static List<Cargo> lstDocumentoVentaEmitir = new List<Cargo>();
        static Cargo clsDocumentoVentaEmitir = new Cargo();
        static Cliente clsCliente = new Cliente();
        BLCliente objAcc = new BLCliente();

        static Cargo clsTipoAnulacion=new Cargo();
        private void  fnBuscarVentas(Int32 numPagina, Int32 tipoCon  )
        {
            BLDocumentoVenta objdocVenta = new BLDocumentoVenta();
           
            clsUtil objUtil = new clsUtil();
            DataTable dtcodventa = new DataTable();
            

            DataGridView dg = dgVentas;
            Int32 totalresult;
            Int32 filas = 10;
            try
            {
                Boolean chkHabFecha= cbFechas.Checked;
                String cbuscar = txtBuscar.Text.Trim();
                DateTime fechainicial = dtpFechaInicialBus.Value;
                DateTime fechafinal = dtpFechaFinalBus.Value;
                if (chkHabFecha == true)
                {
                    dtcodventa = objdocVenta.BLListarVentas(chkHabFecha,FunGeneral.GetFechaHoraFormato(fechainicial,3) , FunGeneral.GetFechaHoraFormato(fechafinal,3) , cbuscar, numPagina, tipoCon);

                }else if (cbuscar.Length>10)
                {
                    dtcodventa = objdocVenta.BLListarVentas(chkHabFecha,FunGeneral.GetFechaHoraFormato(fechainicial,3) , FunGeneral.GetFechaHoraFormato(fechafinal,3) , cbuscar, numPagina, tipoCon);
                }
                else
                {
                    MessageBox.Show("Ingrese mas dijitos del codigo de documento","Aviso!!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
           

                Int32 totalResultados = dtcodventa.Rows.Count;

                if (totalResultados > 0)
                {
                    dg.Columns.Clear();
                    dg.Rows.Clear();
                    dg.Columns.Add("id", "id");
                    dg.Columns.Add("id2", "id2");
                    dg.Columns.Add("idCliente", "idCliente");
                    dg.Columns.Add("N", "N°");
                    dg.Columns.Add("codigo", "Codigo Documento");
                    dg.Columns.Add("Fecha", "Fecha");
                    dg.Columns.Add("Cliente", "Cliente");
                    dg.Columns.Add("Vehiculo", "Vehiculo");
                    dg.Columns.Add("TipoOperacion", "Tipo Operación");
                    dg.Columns.Add("usuario", "Usuario");

                    Int32  y=0;
                    if (numPagina == 0)
                    {
                        y = 0;
                        estBusqueda = true;
                    }
                    else
                    {
                        tabInicio = (numPagina - 1) * filas;
                        y = tabInicio;
                        estBusqueda =false;
                    }
                    foreach (DataRow dr in dtcodventa.Rows)
                    {
                        y += 1;
                        dg.Rows.Add(
                            dr["idDocumentoVenta"], 
                            dr["idOperacion"],
                            dr["idcliente"],
                            y, 
                            dr["codDocumentoCorrelativo"],
                            Convert.ToDateTime(dr["dfecharegistro"]).ToString("dd MMM yyyy hh:mm tt"), 
                            dr["cliente"], 
                            dr["vehiculo"], 
                            dr["cNombreOperacion"],
                            dr["cUser"]
                                          );
                          
                    }

                    if (numPagina == 0)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(dtcodventa.Rows[0][0]);
                        FunValidaciones.fnCalcularPaginacion(
                            totalRegistros,
                            totalResultados,
                            totalResultados,
                            cboPagina,
                            btnTotalPag,
                            btnNumFilas,
                            btnTotalReg
                        );
                        estBusqueda = false;
                        //dEstadoBusquedaPaginacion = false;
                    }
                    //else
                    //{
                    //    btnNumFilas.Text = Convert.ToString(totalResultados);
                    //}

                    dg.Columns[0].Visible = false;
                    dg.Columns[1].Visible = false;
                    dg.Columns[2].Visible = false;
                    dg.Columns[3].Width = 15;
                    dg.Columns[4].Width = 45;
                    dg.Columns[5].Width = 58;
                    dg.Columns[6].Width = 100;
                    dg.Columns[7].Width = 50;
                    dg.Columns[8].Width = 50;
                    dg.Columns[9].Width = 65;
                }
                else
                {
                    dgVentas.Columns.Clear();
                    dgVentas.Rows.Clear();
                    dgVentas.Columns.Add("id", "No se encontró resultados");
                    dg.Columns[0].Width = 100;
                }



               


                dgVentas.Visible = true;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmAnularVentas", "fnBuscarVentas", ex.Message);
              

                
            }

        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

           

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
                fnBuscarVentas(0,-1);
           
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarVentas(0,-1);
            }
        }
        private void fnActivarFechas( Boolean est)
        {
            if (est == true)
            {
                gbBuscarListaVentas.Enabled = true;
            }
            else
            {
                gbBuscarListaVentas.Enabled = false;

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            fnActivarFechas(cbFechas.Checked);
        }
        public void fnRecibirDescripcion( String str, Cargo clsAnulacion)
        {
            cDescripcion = str;
            clsTipoAnulacion= clsAnulacion;
        }
        public void fnEstadoAnulacion(Boolean est)
        {
            EstadoAnulacion = est;
        }
        public void fnBuscarDocumentoVenta(String cCodVenta, Int32 tipCon, Int32 idTipoTarifa, Int32 idContrato)
        {
            BLOtrasVenta objTipoVenta = new BLOtrasVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtResp = new DataTable();
            List<TipoVenta> lsTipoVenta = new List<TipoVenta>();
            Int32 filas = 20;
            List<xmlDocumentoVentaGeneral> xmlDocumentoVenta = new List<xmlDocumentoVentaGeneral>();
            xmlDocumentoVentaGeneral xmlDocVenta = new xmlDocumentoVentaGeneral();

            try
            {
                xmlDocVenta = objTipoVenta.blBuscarDocumentoVentaGeneral(cCodVenta, -4, idTipoTarifa, idContrato);
                xmlDocVenta.xmlDocumentoVenta[0].cDireccion = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cDireccion);
                xmlDocVenta.xmlDocumentoVenta[0].cEstado = "ANULACIONES";
                xmlDocVenta.xmlDocumentoVenta[0].NombreDocumento = "NOTA DE CREDITO";
                xmlDocVenta.xmlDocumentoVenta[0].cCodDocumentoVenta = "FC01-00000002";
                xmlDocVenta.xmlDocumentoVenta[0].cDocumento = xmlDocVenta.xmlDocumentoVenta[0].cDocumento.ToString()==""? "00000000": xmlDocVenta.xmlDocumentoVenta[0].cDocumento;
                xmlDocVenta.xmlDocumentoVenta[0].est0 = false;
                xmlDocVenta.xmlDocumentoVenta[0].cVehiculos = FunGeneral.FormatearCadenaTitleCase(cDescripcion);
                xmlDocVenta.xmlDocumentoVenta[0].idUsuario = Variables.gnCodUser;
                xmlDocVenta.xmlDocumentoVenta[0].dFechaVenta =Convert.ToDateTime(FunGeneral.GetFechaHoraFormato(Variables.gdFechaSis,3));
                //xmlDocVenta.xmlDocumentoVenta[0].cCliente = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cCliente);
                xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago);
                xmlDocumentoVenta.Add(xmlDocVenta);
                stXmlDocumentoVenta = xmlDocumentoVenta;
                Consultas.frmVPVenta abrirFrmVPOtrasVentas = new Consultas.frmVPVenta();

                abrirFrmVPOtrasVentas.Inicio(xmlDocumentoVenta[0].xmlDocumentoVenta, xmlDocumentoVenta[0].xmlDetalleVentas, xmlDocumentoVenta[0].imgDocumento, tipCon);

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmAnularVenta", "fnBuscarDocumentoVenta", ex.Message);

            }
            finally
            {
                objUtil = null;
                objTipoVenta = null;
                lsTipoVenta = null;
            }
        }

        private void fnAnularDocumentoVenta(String codDocumento,Int32 idOperacion, Int32 tipoCon)
        {
            BLDocumentoVenta objdocVenta = new BLDocumentoVenta();
            Boolean estadoOpe = false;
            frmInput frm = new frmInput();
            frm.Inicio(tipoCon, "Describa la anulacion","Continuar","Cancelar");
            if (cDescripcion != "")
            {
                DialogResult resultDialog = MessageBox.Show("¿En realidad desea anular este Documento?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                if (resultDialog == DialogResult.Yes)
                {
                    fnBuscarDocumentoVenta(codDocumento, -5, 0, 0);
                    if (EstadoAnulacion == true)
                    {
                        String cresultado = codDocumento.Substring(0, 2);
                        if (cresultado=="FH" || cresultado == "BH")
                        {
                            EmitirFactura env = new EmitirFactura();
                            Cargo clsReferenciaDoc = new Cargo();

                            int indiceGuion = codDocumento.IndexOf("-");
                            string primeraParte = codDocumento.Substring(0, indiceGuion);
                            string segundaParte = codDocumento.Substring(indiceGuion + 1);

                            clsReferenciaDoc.Ref_Serie= primeraParte;
                            clsReferenciaDoc.Ref_Numero= segundaParte;
                            clsReferenciaDoc.Ref_TipoComprobante = cresultado == "FH" ? "01" : "03";
                            clsReferenciaDoc.Ref_Motivo = clsTipoAnulacion.cNomTab;
                            clsReferenciaDoc.CodigoTipoNotacredito = clsTipoAnulacion.cCodTab;
                            

                            Int32 intResulta= env.EmitirNotaCredito(clsCliente, stXmlDocumentoVenta[0].xmlDetalleVentas, clsDocumentoVentaEmitir, clsReferenciaDoc);
                            if (intResulta==1)
                            {
                                estadoOpe = objdocVenta.BLDAnularDocumentoVenta(codDocumento, idOperacion, stXmlDocumentoVenta, tipoCon);

                                if (estadoOpe == true)
                                {
                                    MessageBox.Show("Documento anulado correctamente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                else
                                {
                                    MessageBox.Show("Ocurrio un error al anular el Documento de Venta", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }

                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error al emitior nota de credito. intentelo nuevamente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            estadoOpe = objdocVenta.BLDAnularDocumentoVenta(codDocumento, idOperacion, stXmlDocumentoVenta, tipoCon);

                            if (estadoOpe == true)
                            {
                                MessageBox.Show("Documento anulado correctamente", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error al anular el Documento de Venta", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }


                        
                    }

                }
            }

            
           
        }
        private void eliminarRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 idDocumento = Convert.ToInt32(dgVentas.CurrentRow.Cells[0].Value);
            Int32 idOperacion = Convert.ToInt32(dgVentas.CurrentRow.Cells[1].Value);
            Int32 idCliente = Convert.ToInt32(dgVentas.CurrentRow.Cells[2].Value);
            String codDocVenta = Convert.ToString(dgVentas.CurrentRow.Cells[4].Value);


            clsCliente = objAcc.blListarCliente(idCliente, 1);
            
            fnAnularDocumentoVenta(codDocVenta, idOperacion, -1);  

        }

        private void fnLlenadClaseDocumento()
        {
            Int32 j = 0;
            foreach (Cargo item in lstDocumentoVentaEmitir)
            {
                lstDocumentoVentaEmitir[j].dFechaPago = dtpFechaFinalBus.Value;
                lstDocumentoVentaEmitir[j].dFechaVenta = dtpFechaFinalBus.Value;
                j++;
            }
            if (cboNotaCredit.Items.Count > 0)
            {
                clsDocumentoVentaEmitir = lstDocumentoVentaEmitir.Find(i => i.cCodTab == cboNotaCredit.SelectedValue.ToString());
            }


        }
        private void frmAnularVenta_Load(object sender, EventArgs e)
        {
            DateTime fechaactual = DateTime.Now;
            dtpFechaFinalBus.Value = fechaactual;
            dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-dtpFechaFinalBus.Value.AddDays(-1).Day);
            cbFechas.Checked=true;
            lstDocumentoVentaEmitir = Mantenedores.frmRegistrarVenta.fnLlenarComprobante(cboNotaCredit, "DOVE0004", 1, 1);
            cboNotaCredit.SelectedIndex = 1;
            fnActivarFechas(true);
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbR0.Checked == true)
            {
                txtBuscar.Text = cbR0.Text;

                cbF0.Checked = false;
                checkBox1.Checked = false;  
            }
          
        }

        private void cbF0_CheckedChanged(object sender, EventArgs e)
        {
            if (cbF0.Checked == true)
            {
                txtBuscar.Text = cbF0.Text;

                cbR0.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void eliminarContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String codDocVenta = Convert.ToString(dgVentas.CurrentRow.Cells[0].Value);
            Int32 idOperacion = Convert.ToInt32(dgVentas.CurrentRow.Cells[1].Value);
            fnAnularDocumentoVenta(codDocVenta, idOperacion, -2);
        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 numpagina = Convert.ToInt32(cboPagina.Text);
            if(estBusqueda == false)
            {
                fnBuscarVentas(numpagina, -1);

            }
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtBuscar.Text = checkBox1.Text;

                cbR0.Checked = false;
                cbF0.Checked = false;
            }
        }

        private void cboNotaCredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnLlenadClaseDocumento();
        }
    }
}
 
