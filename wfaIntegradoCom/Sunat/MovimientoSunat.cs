using CapaDato;
using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using FontAwesome.Sharp;
using iTextSharp.text.pdf.codec.wmf;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Mantenedores;
using static wfaIntegradoCom.Mantenedores.frmEquipoImeis;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;

namespace wfaIntegradoCom.Sunat
{
    public partial class MovimientoSunat : Form
    {
        public MovimientoSunat()
        {
            InitializeComponent();
        }
        static List<DocumentoVenta> lstDocumentos = new List<DocumentoVenta>();
        static Int32 numFilas = 8;
        static Int32 numPaginas = 0;
        static Int32 numRegistros = 0;
        static Int32 numInicial = 0;
        static Int32 NumFinal = 0;
        String strTextTab = "";
        private int progressBarValue=0;
        MultiThread _multithread = null;
        private void pbBuscar_Click(object sender, EventArgs e)
        {
            fnBuscarDocumentos(0, cboPagina,"DOVE0002", -1);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Actualiza el valor de la barra de progreso (círculo)


            ProgressBar1.Start();
            if (progressBarValue<98)
            {
                progressBarValue = (progressBarValue + 1) % 101;

            }
            fnMostrarStatus("Emitiendo...");
        }
        private void fnBuscarDocumentos(Int32 pagina,ComboBox cbo,String CodDoc,Int32 tipocon)
        {
            BLDocumentoVenta blDoc=new BLDocumentoVenta();
            Boolean chkFechas = CodDoc== "DOVE0002" ? chkHabilitarFechasBus.Checked: CodDoc == "DOVE0001" ? siticoneCheckBox1.Checked : chkHabilitaFechaNota.Checked;
            String dtFechaIni = CodDoc == "DOVE0002" ? FunGeneral.GetFechaHoraFormato(dtpFechaInicialBus.Value,5): CodDoc == "DOVE0001" ? FunGeneral.GetFechaHoraFormato(dtFechaIniBoletas.Value, 5): FunGeneral.GetFechaHoraFormato(dtFechaIniNota.Value, 5);
            String dtFechaFin = CodDoc == "DOVE0002" ? FunGeneral.GetFechaHoraFormato(dtpFechaFinalBus.Value,5): CodDoc == "DOVE0001" ? FunGeneral.GetFechaHoraFormato(dtFechaFinBoletas.Value, 5):FunGeneral.GetFechaHoraFormato(dtFechaFinNota.Value, 5);
            String buscar = CodDoc == "DOVE0002"?txtBuscar.Text.ToString(): CodDoc=="DOVE0001" ? txtBuscarBoleta.Text.ToString(): txtBuscarNotaCredito.Text.ToString();
            String estdoDocumento= CodDoc == "DOVE0002" ? cboEstadofactura.SelectedValue.ToString() : CodDoc == "DOVE0001" ? cboEstadosBoleta.SelectedValue.ToString() : cboEstadoNota.SelectedValue.ToString();
            lstDocumentos.Clear();

            try
            {
                lstDocumentos = blDoc.blBuscarDocumentoPorEmitir(chkFechas, dtFechaIni, dtFechaFin, buscar, CodDoc, estdoDocumento, pagina, tipocon);
               
            }catch (Exception ex) {
                MessageBox.Show("Error al buscar documentos\n" + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            fnLlenarPaginacion(cbo);
        }

        private void fnCargarTabla(SiticoneDataGridView dgv )
        {
            dgv.Rows.Clear();
            for (int i = numInicial; i < NumFinal; i++)
            {
                dgv.Rows.Add(
                    lstDocumentos[i].idVenta,
                    lstDocumentos[i].numero,
                    lstDocumentos[i].CodigoCorrelativo,
                    lstDocumentos[i].dFechaRegistro.ToString("dd-MM-yyyy"),
                    lstDocumentos[i].cCliente,
                    FunGeneral.fnFormatearPrecio("S/.",lstDocumentos[i].nMontoPagar,0),
                    lstDocumentos[i].cVehiculos,
                    lstDocumentos[i].cEstado,
                    "",""

                    );
            }
            dgv.Visible = true;
        }
        private void fnLlenarPaginacion(ComboBox cbo)
        {
            if (cbo.Name == "cboPagina")
            {
                dgvListaVentas.Rows.Clear();
            }
            else if (cbo.Name == "cboPaginaBoletas")
            {
                dgvBoletas.Rows.Clear();
            }
            else if (cbo.Name == "cboPaginaNota")
            {
                dgvNota.Rows.Clear();
            }
            Int32 residuo = 0;
            cbo.Items.Clear();
            numRegistros = lstDocumentos.Count;
            residuo = numRegistros % numFilas;
            numPaginas = residuo == 0 ? (numRegistros / numFilas) : (numRegistros / numFilas) + 1;
            for (int i = 0; i < numPaginas; i++)
            {
                cbo.Items.Add(i+1);
            }
            if (numPaginas>0)
            {
                cbo.SelectedIndex = 0;

            }

            if (cbo.Name== "cboPagina")
            {
                btnTotalPag.Text = numPaginas.ToString();
                btnNumFilas.Text = numFilas.ToString();
                btnTotalReg.Text = numRegistros.ToString();

            }
            else if(cbo.Name== "cboPaginaBoletas")
            {
                btnTotalPagBoletas.Text = numPaginas.ToString();
                btnNumFilasBoletas.Text = numFilas.ToString();
                btnTotalRegBoleta.Text = numRegistros.ToString();
            }
            else if(cbo.Name== "cboPaginaNota")
            {
                btnTotalPagNota.Text = numPaginas.ToString();
                btnNumFilasNota.Text = numFilas.ToString();
                btnTotalRegNota.Text = numRegistros.ToString();
            }

        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 pagActual = Convert.ToInt32(cboPagina.Text);
            numInicial = (pagActual * numFilas)-numFilas;
            NumFinal = (pagActual * numFilas);
            NumFinal = NumFinal > numRegistros ? numRegistros : NumFinal;
            fnCargarTabla(dgvListaVentas);
        }


        public void fnExportarAExcel()
        {
            DateTime dtt = DateTime.Now;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveFileDialog1.Title = "Guardar archivo de Excel";
            saveFileDialog1.FileName = "REPORTE "+ strTextTab + " - " + dtt.ToString("ddMMyyyyHHmmss") + ".xlsx";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                using (SpreadsheetDocument documento = SpreadsheetDocument.Create(saveFileDialog1.FileName, SpreadsheetDocumentType.Workbook))
                {
                    // Crea una hoja de trabajo dentro del archivo
                    WorkbookPart libroParte = documento.AddWorkbookPart();
                    libroParte.Workbook = new Workbook();
                    WorksheetPart hojaParte = libroParte.AddNewPart<WorksheetPart>();
                    hojaParte.Worksheet = new Worksheet(new SheetData());
                    Sheets hojas = documento.WorkbookPart.Workbook.AppendChild(new Sheets());
                    Sheet hoja = new Sheet() { Id = documento.WorkbookPart.GetIdOfPart(hojaParte), SheetId = 1, Name = "FACTURAS" };
                    hojas.Append(hoja);

                    // Agrega los encabezados de columna
                    SheetData datosHoja = hojaParte.Worksheet.GetFirstChild<SheetData>();
                    Row filaEncabezados = new Row();
                    filaEncabezados.Append(
                        CreaCelda("Numero"),
                        CreaCelda("Codigo"),
                        CreaCelda("Fecha Emision"),
                        CreaCelda("Cliente"),
                        CreaCelda("Importe"),
                        CreaCelda("Estado")
                        );


                    datosHoja.AppendChild(filaEncabezados);

                    // Agrega los datos de la lista
                    foreach (DocumentoVenta dv in lstDocumentos)
                    {
                        Row filaDatos = new Row();
                        filaDatos.Append(
                            CreaCelda(dv.numero.ToString()),
                            CreaCelda(dv.CodigoCorrelativo),
                            CreaCelda(dv.dFechaRegistro.ToString("dd-MM-yyyy")),
                            CreaCelda(dv.cCliente),
                            CreaCelda(dv.nMontoPagar.ToString()),
                            CreaCelda(dv.cEstado)

                            );
                        datosHoja.AppendChild(filaDatos);
                    }

                    // Cierra el archivo de Excel
                    documento.Close();

                }
                MessageBox.Show("REPORTE " + strTextTab+" EXPORTADO SATISFACTORIAMENTE","AVISO!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            fnExportarAExcel();
        }

        private Cell CreaCelda(string valor)
        {
            Cell celda = new Cell();
            celda.DataType = CellValues.String;
            celda.CellValue = new CellValue(valor);
            return celda;
        }

        private string GetColumnaLetra(int columna)
        {
            int letra = columna;
            string letraFinal = String.Empty;
            int modulo;
            while (letra > 0)
            {
                modulo = (letra - 1) % 26;
                letraFinal = Convert.ToChar(65 + modulo) + letraFinal;
                letra = (letra - modulo) / 26;
            }
            return letraFinal;
        }

        private void MovimientoSunat_Load(object sender, EventArgs e)
        {
            try
            {
                dtpFechaFinalBus.Value = Variables.gdFechaSis;
                dtpFechaInicialBus.Value = dtpFechaFinalBus.Value.AddDays(-(dtpFechaFinalBus.Value.Day - 1));

                dtFechaFinBoletas.Value = Variables.gdFechaSis;
                dtFechaIniBoletas.Value = dtFechaFinBoletas.Value.AddDays(-(dtFechaFinBoletas.Value.Day - 1));

                dtFechaFinNota.Value = Variables.gdFechaSis;
                dtFechaIniNota.Value = dtFechaFinNota.Value.AddDays(-(dtFechaFinNota.Value.Day - 1));

                FunGeneral.fnLlenarTablaCodTipoCon(cboEstadofactura, "EEST",true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboEstadosBoleta, "EEST", true);
                FunGeneral.fnLlenarTablaCodTipoCon(cboEstadoNota, "EEST", true);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                fnBuscarDocumentos(0, cboPagina, "DOVE0002", -1);
            }
        }

        private void dgvListaVentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            String nombreCabecera = dgv.Columns[e.ColumnIndex].HeaderText;

            if (nombreCabecera == "Estado")
            {
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Font = new System.Drawing.Font("Arial", 11, FontStyle.Regular);
                if (e.Value.ToString().Contains("✅"))
                {
                    e.CellStyle.BackColor = Variables.ColorSuccess;
                }
                else if (e.Value.ToString().Contains("❗"))
                {
                    e.CellStyle.BackColor = Color.DarkOrange;
                }
                else if (e.Value.ToString().Contains("🚫"))
                {
                    e.CellStyle.BackColor = Color.Red;

                }

            }

            if (this.dgvListaVentas.Columns[e.ColumnIndex].Name == "imgImprimir")
            {
                if (e.Value != null)
                {
                    IconPictureBox iconPictureBox = new IconPictureBox();
                    iconPictureBox.IconChar = IconChar.ArrowsToEye;
                    iconPictureBox.IconColor = System.Drawing.Color.Tomato;
                    iconPictureBox.Size = new Size(36, 36);

                    Bitmap bmp = new Bitmap(iconPictureBox.Width, iconPictureBox.Height);
                    iconPictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    e.Value = bmp;
                    this.dgvListaVentas.Columns[e.ColumnIndex].Width = 40;
                }
            }
            if (this.dgvListaVentas.Columns[e.ColumnIndex].Name == "ImgEnviarASunat")
            {
                if (e.Value != null)
                {
                    IconPictureBox iconPictureBox = new IconPictureBox();
                    iconPictureBox.IconChar = IconChar.Telegram;
                    iconPictureBox.IconColor = System.Drawing.Color.Tomato;
                    iconPictureBox.Size = new Size(36, 36);

                    Bitmap bmp = new Bitmap(iconPictureBox.Width, iconPictureBox.Height);
                    iconPictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    e.Value = bmp;
                    this.dgvListaVentas.Columns[e.ColumnIndex].Width = 40;
                }
            }
        }
        private async void dgvListaVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = dgvListaVentas;
            if (dg.Columns[e.ColumnIndex].Name== "imgImprimir")
            {
                Int32 idDocumento = Convert.ToInt32(dg.Rows[e.RowIndex].Cells[0].Value);
                fnBuscarDocumentoVenta(idDocumento,0,1);
            }
            if (dg.Columns[e.ColumnIndex].Name == "ImgEnviarASunat")
            {
                Int32 idDocumento = Convert.ToInt32(dg.Rows[e.RowIndex].Cells[0].Value);
                DocumentoVenta cls = lstDocumentos.Find(i => i.CodigoEstado == "EEST0001" && i.idDocumentoVenta== idDocumento);
                if (cls is DocumentoVenta)
                {
                    MessageBox.Show("Este Documento ya fue emitido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                 fnEnviarDocumentosASunat(idDocumento, 0,0);
                

            }

        }

        private void fnBuscarDocumentoVenta(Int32 idDocumentoVenta,Int32 tipCon,Int32 estPrevisualizacion)
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
                xmlDocVenta = objTipoVenta.blBuscarDocumentoVenta(idDocumentoVenta,tipCon);
                //xmlDocVenta.xmlDocumentoVenta[0].cDireccion = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cDireccion);
                //xmlDocVenta.xmlDocumentoVenta[0].cCliente = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cCliente);
                //xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago = FunGeneral.FormatearCadenaTitleCase(xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago);
                xmlDocumentoVenta.Add(xmlDocVenta);

                Consultas.frmVPVenta abrirFrmVPOtrasVentas = new Consultas.frmVPVenta();

                abrirFrmVPOtrasVentas.Inicio(xmlDocumentoVenta[0].xmlDocumentoVenta, xmlDocumentoVenta[0].xmlDetalleVentas, xmlDocVenta.imgDocumento, estPrevisualizacion);

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnListarProveedorActivo", ex.Message);

            }
            finally
            {
                objUtil = null;
                objTipoVenta = null;
                lsTipoVenta = null;
            }
        }
        

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            fnBuscarDocumentos(0, cboPaginaBoletas, "DOVE0001", -1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 pagActual = Convert.ToInt32(cboPaginaBoletas.Text);
            numInicial = (pagActual * numFilas) - numFilas;
            NumFinal = (pagActual * numFilas);
            NumFinal = NumFinal > numRegistros ? numRegistros : NumFinal;
            fnCargarTabla(dgvBoletas);
        }

        private void txtBuscarBoleta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(Char)Keys.Enter)
            {
                fnBuscarDocumentos(0, cboPaginaBoletas, "DOVE0001", -1);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String srtCadena = @"Data Source=DESKTOP-ROLGOA1\SQLEXPRESS; Initial Catalog=Husat;User ID=pruebas;Password=123456";
            SqlConnection sqlConnection = new SqlConnection(srtCadena);

            //fnEjecutarPreocedure(sqlConnection);
            fnEjecutarProcedimientoGuardar(sqlConnection);
        }
        private void fnEjecutarProcedimientoGuardar(SqlConnection sqlCon)
        {
            sqlCon.Open();
            DataTable dt = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("uspRegistroClientePrueba", sqlCon);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@idCategoria", 3));
            sqlCommand.Parameters.Add(new SqlParameter("@nombreCategoria", "Prueba"));
            sqlCommand.Parameters.Add(new SqlParameter("@idUsuario", 5));
            sqlCommand.Parameters.Add(new SqlParameter("@cObservacion","Descripcion"));
            int rows=sqlCommand.ExecuteNonQuery();
            sqlCon.Close();
        }
        private void fnEjecutarPreocedure(SqlConnection sqlCon)
        {
            sqlCon.Open();
            DataTable dt = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("uspListarCliente", sqlCon) ;
            sqlCommand.CommandType= CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@peTipoCon", 5));
            sqlCommand.Parameters.Add(new SqlParameter("@peidCliente", 123));
            SqlDataAdapter sqlDataReader = new SqlDataAdapter(sqlCommand);
            sqlDataReader.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                MessageBox.Show(dr["cNombre"].ToString());
            }
      



        }

        private void dgvBoletas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            String nombreCabecera = dgv.Columns[e.ColumnIndex].HeaderText;

            if (nombreCabecera == "Estado")
            {
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Font = new System.Drawing.Font("Arial", 11, FontStyle.Regular);
                if (e.Value.ToString().Contains("✅"))
                {
                    e.CellStyle.BackColor = Variables.ColorSuccess;
                }
                else if (e.Value.ToString().Contains("❗"))
                {
                    e.CellStyle.BackColor = Color.DarkOrange;
                }
                else if (e.Value.ToString().Contains("🚫"))
                {
                    e.CellStyle.BackColor = Color.Red;

                }

            }

            if (this.dgvBoletas.Columns[e.ColumnIndex].Name == "imgImprimirBoletas")
            {
                if (e.Value != null)
                {
                    IconPictureBox iconPictureBox = new IconPictureBox();
                    iconPictureBox.IconChar = IconChar.ArrowsToEye;
                    iconPictureBox.IconColor = System.Drawing.Color.Tomato;
                    iconPictureBox.Size = new Size(36, 36);

                    Bitmap bmp = new Bitmap(iconPictureBox.Width, iconPictureBox.Height);
                    iconPictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    e.Value = bmp;
                    this.dgvBoletas.Columns[e.ColumnIndex].Width = 40;
                }
            }
            if (this.dgvBoletas.Columns[e.ColumnIndex].Name == "ImgEnviarASunatBoletas")
            {
                if (e.Value != null)
                {
                    IconPictureBox iconPictureBox = new IconPictureBox();
                    iconPictureBox.IconChar = IconChar.Telegram;
                    iconPictureBox.IconColor = System.Drawing.Color.Tomato;
                    iconPictureBox.Size = new Size(36, 36);

                    Bitmap bmp = new Bitmap(iconPictureBox.Width, iconPictureBox.Height);
                    iconPictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    e.Value = bmp;
                    this.dgvBoletas.Columns[e.ColumnIndex].Width = 40;
                }
            }
        }

        private void dgvBoletas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = dgvBoletas;
            Int32 idDocumento = Convert.ToInt32(dg.Rows[e.RowIndex].Cells[0].Value);
            if (dg.Columns[e.ColumnIndex].Name == "imgImprimirBoletas")
            {
                fnBuscarDocumentoVenta(idDocumento, 0,1);
            }
            if (dg.Columns[e.ColumnIndex].Name == "ImgEnviarASunatBoletas")
            {
                DocumentoVenta cls = lstDocumentos.Find(i => i.CodigoEstado == "EEST0001" && i.idDocumentoVenta == idDocumento);
                if (cls is DocumentoVenta)
                {
                    MessageBox.Show("Este Documento ya fue emitido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                fnEnviarDocumentosASunat(idDocumento, 0,1);
            }
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            fnExportarAExcel();
        }

        private void dotNetBarTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            strTextTab= dotNetBarTabControl1.TabPages[dotNetBarTabControl1.SelectedIndex].Text;

            string name = dotNetBarTabControl1.TabPages[dotNetBarTabControl1.SelectedIndex].Name;
            if (name=="tabPage1")
            {
                fnBuscarDocumentos(0, cboPagina, "DOVE0002", -1);
            }
            else if (name == "tabPage3")
            {
                fnBuscarDocumentos(0, cboPaginaBoletas, "DOVE0001", -1);
            }
            else if (name == "tabPage2")
            {
                fnBuscarDocumentos(0, cboPaginaNota, "DOVE0004", -1);
            }
        }

        private void pbBuscarNotaCredito_Click(object sender, EventArgs e)
        {
            fnBuscarDocumentos(0, cboPaginaNota, "DOVE0004", -1);
        }

        private void cboPaginaNota_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 pagActual = Convert.ToInt32(cboPaginaNota.Text);
            numInicial = (pagActual * numFilas) - numFilas;
            NumFinal = (pagActual * numFilas);
            NumFinal = NumFinal > numRegistros ? numRegistros : NumFinal;
            fnCargarTabla(dgvNota);
        }

        private void dgvNota_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            String nombreCabecera = dgv.Columns[e.ColumnIndex].HeaderText;
            if (nombreCabecera == "Estado")
            {
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Font = new System.Drawing.Font("Arial", 11, FontStyle.Regular);
                if (e.Value.ToString().Contains("✅"))
                {
                    e.CellStyle.BackColor = Variables.ColorSuccess;
                }
                else if (e.Value.ToString().Contains("❗"))
                {
                    e.CellStyle.BackColor = Color.DarkOrange;
                }
                else if (e.Value.ToString().Contains("🚫"))
                {
                    e.CellStyle.BackColor = Color.Red;

                }

            }
            if (this.dgvNota.Columns[e.ColumnIndex].Name == "dataGridViewImageColumn1")
            {
                if (e.Value != null)
                {
                    IconPictureBox iconPictureBox = new IconPictureBox();
                    iconPictureBox.IconChar = IconChar.ArrowsToEye;
                    iconPictureBox.IconColor = System.Drawing.Color.Tomato;
                    iconPictureBox.Size = new Size(36, 36);

                    Bitmap bmp = new Bitmap(iconPictureBox.Width, iconPictureBox.Height);
                    iconPictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    e.Value = bmp;
                    this.dgvNota.Columns[e.ColumnIndex].Width = 40;
                }
            }
            if (this.dgvNota.Columns[e.ColumnIndex].Name == "ImgEnviarASunatNota")
            {
                if (e.Value != null)
                {
                    IconPictureBox iconPictureBox = new IconPictureBox();
                    iconPictureBox.IconChar = IconChar.Telegram;
                    iconPictureBox.IconColor = System.Drawing.Color.Tomato;
                    iconPictureBox.Size = new Size(36, 36);

                    Bitmap bmp = new Bitmap(iconPictureBox.Width, iconPictureBox.Height);
                    iconPictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    e.Value = bmp;
                    this.dgvNota.Columns[e.ColumnIndex].Width = 40;
                }
            }
        }

        private void dgvNota_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = dgvNota;
            if (dg.Columns[e.ColumnIndex].Name == "dataGridViewImageColumn1")
            {
                Int32 idDocumento = Convert.ToInt32(dg.Rows[e.RowIndex].Cells[0].Value);
                fnBuscarDocumentoVenta(idDocumento, 2,1);
            }
        }

        private void reenviarDocumentoASunatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscarNotaCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarDocumentos(0, cboPaginaNota, "DOVE0004", -1);

            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                List<Task> tasks = new List<Task>();

                for (int i = 0; i < 900; i++)
                {
                    tasks.Add(Task.Run(() => fnEnHilos(i)));
                }

                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fnEnHilos(int idx)
        {
            try
            {
                // Operaciones que no afectan la interfaz de usuario
                Console.WriteLine($"Hilo sin interumpir : {idx}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void fnMostrarStatus(string msg)
        {
            label14.Text = msg;
            lblStatus.Text = progressBarValue.ToString() + "%";
        }
        public  async void fnEnviarDocumentosASunat(int idDocumento, int tipoCon,int estado)
        {
            try
            {
                List<Task> tasks = new List<Task>();
                progressBarValue = 0;
                this.timer1.Start();

                tasks.Add(Task.Run(() => fnEnviarASunat(idDocumento, tipoCon)));
                await Task.WhenAll(tasks);
                if (estado == 0)
                {
                    fnBuscarDocumentos(0, cboPagina, "DOVE0002", -1);
                }
                else if (estado == 1)
                {
                    fnBuscarDocumentos(0, cboPaginaBoletas, "DOVE0001", -1);
                }
                timer1.Stop();
                progressBarValue = 100;
                fnMostrarStatus("Emision terminada");
                ProgressBar1.Stop();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        public async void fnEnviarDocumentosASunat(int idDocumento, int tipoCon)
        {
            try
            {
                List<Task> tasks = new List<Task>();
                tasks.Add(Task.Run(() => fnEnviarASunat(idDocumento, tipoCon)));
                await Task.WhenAll(tasks);
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        public  ResponseSunat fnEnviarASunat(Int32 idDocumentoVenta, Int32 tipCon)
        {
            BLOtrasVenta objTipoVenta = new BLOtrasVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtResp = new DataTable();
            Int32 filas = 20;
            List<DetalleVenta> lstDetalle = new List<DetalleVenta>();
            xmlDocumentoVentaGeneral xmlDocVenta = new xmlDocumentoVentaGeneral();
            EmitirFactura emf = new EmitirFactura();
            BLCliente objAcc = new BLCliente();
            Cargo clsDocumentoVenta = new Cargo();
            String rutaArchivo = FunGeneral.GetRootPathSunat();
            ResponseSunat clsResponseSunat = new ResponseSunat();

            String xmlDocventa = "";
            String codigoDocumento = "";
            String DescripEstadoPP = "";
            String MediosDePago = "";
            String DireccionCLiente = "";
            String UbigeoCLiente = "";
            int idUsuario = 0;
            byte[] imgQr = new byte[] { };
            try
            {
                dtResp = objTipoVenta.blBuscarDocumentoVentaParaEmitirASunat(idDocumentoVenta, tipCon);
                #region preparar datos
                foreach (DataRow drMenu in dtResp.Rows)
                {
                    DescripEstadoPP = Convert.ToString(drMenu["descripcionEstadoVenta"]).ToLower();
                    codigoDocumento = Convert.ToString(drMenu["codDocumentoCorrelativo"]);
                    xmlDocventa = Convert.ToString(drMenu["Documentoventa"]);
                    MediosDePago = Convert.ToString(drMenu["mediosDePago"]);
                    imgQr = (Byte[])drMenu["CodigoQr"];

                    clsDocumentoVenta = new Cargo
                    {
                        nValor1 = Convert.ToString(drMenu["TipoDocumentoEmitir"]),
                        SerieDoc = Convert.ToString(drMenu["SerieDocumento"]),
                        nValor2 = Convert.ToString(drMenu["NumeroDocumento"])
                    };
                    DireccionCLiente = Convert.ToString(drMenu["direccionCLinete"]);
                    UbigeoCLiente = Convert.ToString(drMenu["ubigeoCliente"]);
                    idUsuario = Convert.ToInt32(drMenu["idCliente"]);

                }
                if (imgQr.Length <= 0)
                {

                    imgQr = File.ReadAllBytes(rutaArchivo + @"\CDR\QR\\QrDefecto.png");

                }
                MemoryStream ms = new MemoryStream(imgQr);

                xmlDocVenta = clsUtil.Deserialize<xmlDocumentoVentaGeneral>(xmlDocventa);
                xmlDocVenta.xmlDocumentoVenta[0].cDescripEstadoPP = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(DescripEstadoPP);
                xmlDocVenta.xmlDocumentoVenta[0].cDireccion = DireccionCLiente + " " + UbigeoCLiente;
                xmlDocVenta.xmlDocumentoVenta[0].CodigoCorrelativo = codigoDocumento;
                xmlDocVenta.xmlDocumentoVenta[0].cDescripcionTipoPago = MediosDePago;
                xmlDocVenta.xmlDocumentoVenta[0].idUsuario = idUsuario;
                xmlDocVenta.xmlDocumentoVenta[0].idDocumentoVenta = idDocumentoVenta;

                clsDocumentoVenta.dFechaVenta = xmlDocVenta.xmlDocumentoVenta[0].dFechaVenta;
                clsDocumentoVenta.dFechaPago = xmlDocVenta.xmlDocumentoVenta[0].dFechaVenta;

                if (tipCon != 2)
                {
                    xmlDocVenta.imgDocumento = ms.ToArray();
                }
                #endregion
                //Obtenemos el detalle correcto para enviar a la sunat
                lstDetalle = xmlDocVenta.xmlDetalleVentas.Where(i => i.ImporteRow > 0).ToList();

                lstDetalle.ForEach(detalle => { if (detalle.importeRestante > 0 && detalle.importeRestante == detalle.preciounitario) detalle.importeRestante = 0; });

                //Obtenemos los datos de cliente para el Documento de venta
                Cliente clsCliente = objAcc.blListarCliente(xmlDocVenta.xmlDocumentoVenta[0].idUsuario, 1);

                clsResponseSunat = emf.EmitirFacturasContado(clsCliente, lstDetalle, xmlDocVenta.xmlDocumentoVenta, clsDocumentoVenta);
                Boolean estado = false;
                if (clsResponseSunat.isSuccesfull == true && clsResponseSunat.codeError.Trim() == "0")
                {
                    String nombreQR = clsCliente.cDocumento + "-" + clsDocumentoVenta.nValor1 + "-" + clsDocumentoVenta.SerieDoc + "-" + FunGeneral.generarCorrelativoDocumento(Convert.ToInt32(clsDocumentoVenta.nValor2));
                    //bitmap.Save(rutaArchivo + "QR\\" + nombreQR + ".png");
                    imgQr = File.ReadAllBytes(rutaArchivo + @"\CDR\QR\\" + nombreQR + ".png");
                    
                    estado = fnActualizarDocumentoVenta(xmlDocVenta, clsResponseSunat, imgQr);

                }
                else
                {
                    estado = fnActualizarDocumentoVenta(xmlDocVenta, clsResponseSunat, imgQr);
                }
                return clsResponseSunat;

            }
            catch (Exception ex)
            {
                return new ResponseSunat { isSuccesfull = false, message = "Error al enviar documento a la sunat" };

            }
            finally
            {
                objUtil = null;
                objTipoVenta = null;

            }
        }
        private  Boolean fnActualizarDocumentoVenta(xmlDocumentoVentaGeneral xmlDoc, ResponseSunat cls, byte[] imgQr)
        {
            BLOtrasVenta objTipoVenta = new BLOtrasVenta();
            return objTipoVenta.blActualizarDocumentoVenta(xmlDoc, cls, imgQr);

        }
        public  int fnObtenerIdDocumentoVenta(string correlativo)
        {

            BLOtrasVenta objTipoVenta = new BLOtrasVenta();
            return objTipoVenta.blObtenerIdDocumentoVenta(correlativo);
        }

        private async void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            if(lstDocumentos.Where(i => i.CodigoEstado.Contains("EEST0002") || i.CodigoEstado.Contains("EEST0005")).ToList().Count <= 0)
            {
                MessageBox.Show("Todos los documentos fueron EMITIDOS a la SUNAT", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<Task> tasks = new List<Task>();       
            foreach (DocumentoVenta cod in lstDocumentos.Where(i=>i.CodigoEstado.Contains("EEST0002") || i.CodigoEstado.Contains("EEST0005")).ToList())
            {
                progressBarValue = 0;
                this.timer1.Start();

                tasks = new List<Task>();
                tasks.Add(Task.Run(() => fnEnviarASunat(cod.idDocumentoVenta, 0)));
                await Task.WhenAll(tasks);

                timer1.Stop();
                progressBarValue = 100;
                fnMostrarStatus("Emision terminada");
                ProgressBar1.Stop();
            }

            fnBuscarDocumentos(0, cboPagina, "DOVE0002", -1);
            
        }

        private async void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            List<Task> tasks = new List<Task>();
            foreach (DocumentoVenta cod in lstDocumentos.Where(i => i.CodigoEstado.Contains("EEST0002") || i.CodigoEstado.Contains("EEST0005")).ToList())
            {
                progressBarValue = 0;
                this.timer1.Start();

                tasks = new List<Task>();
                tasks.Add(Task.Run(() => fnEnviarASunat(cod.idDocumentoVenta, 0)));
                await Task.WhenAll(tasks);

                timer1.Stop();
                progressBarValue = 100;
                fnMostrarStatus("Emision terminada");
                ProgressBar1.Stop();
            }
            fnBuscarDocumentos(0, cboPaginaBoletas, "DOVE0001", -1);
        }
    }
}
