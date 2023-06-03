using CapaEntidad;
using CapaNegocio;
using CapaUtil;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using FontAwesome.Sharp;
using Siticone.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.Mantenedores;

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
        private void pbBuscar_Click(object sender, EventArgs e)
        {
            fnBuscarDocumentos(0, cboPagina,"DOVE0002", -1);
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


            lstDocumentos =blDoc.blBuscarDocumentoPorEmitir(chkFechas,dtFechaIni,dtFechaFin,buscar,  CodDoc, pagina,tipocon);
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
                    ""

                    );
            }
            dgv.Visible = true;
        }
        private void fnLlenarPaginacion(ComboBox cbo)
        {
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
                fnBuscarDocumentos(0, cboPagina,"DOVE0002", -1);
            }
        }

        private void dgvListaVentas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvListaVentas.Columns[e.ColumnIndex].Name == "imgImprimir")
            {
                if (e.Value != null)
                {
                    IconPictureBox iconPictureBox = new IconPictureBox();
                    iconPictureBox.IconChar = IconChar.FileArrowDown;
                    iconPictureBox.IconColor = System.Drawing.Color.Tomato;
                    iconPictureBox.Size = new Size(36, 36);

                    Bitmap bmp = new Bitmap(iconPictureBox.Width, iconPictureBox.Height);
                    iconPictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    e.Value = bmp;
                    this.dgvListaVentas.Columns[e.ColumnIndex].Width = 40;
                }
            }
        }
        private void dgvListaVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = dgvListaVentas;
            if (dg.Columns[e.ColumnIndex].Name== "imgImprimir")
            {
                Int32 idDocumento = Convert.ToInt32(dg.Rows[e.RowIndex].Cells[0].Value);
                fnBuscarDocumentoVenta(idDocumento,0);
            }

        }

        private void fnBuscarDocumentoVenta(Int32 idDocumentoVenta,Int32 tipCon)
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

                abrirFrmVPOtrasVentas.Inicio(xmlDocumentoVenta[0].xmlDocumentoVenta, xmlDocumentoVenta[0].xmlDetalleVentas, xmlDocVenta.imgDocumento, 1);

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
            if (this.dgvBoletas.Columns[e.ColumnIndex].Name == "imgImprimirBoletas")
            {
                if (e.Value != null)
                {
                    IconPictureBox iconPictureBox = new IconPictureBox();
                    iconPictureBox.IconChar = IconChar.FileArrowDown;
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
            if (dg.Columns[e.ColumnIndex].Name == "imgImprimirBoletas")
            {
                Int32 idDocumento = Convert.ToInt32(dg.Rows[e.RowIndex].Cells[0].Value);
                fnBuscarDocumentoVenta(idDocumento, 0);
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            fnExportarAExcel();
        }

        private void dotNetBarTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            strTextTab= dotNetBarTabControl1.TabPages[dotNetBarTabControl1.SelectedIndex].Text;
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
    }
}
