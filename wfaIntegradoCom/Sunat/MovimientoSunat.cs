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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Funciones;

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
        private void pbBuscar_Click(object sender, EventArgs e)
        {
            fnBuscarDocumentos(0, cboPagina,"DOVE0002", -1);
        }
        private void fnBuscarDocumentos(Int32 pagina,ComboBox cbo,String CodDoc,Int32 tipocon)
        {
            BLDocumentoVenta blDoc=new BLDocumentoVenta();
            Boolean chkFechas = CodDoc== "DOVE0002" ? chkHabilitarFechasBus.Checked: CodDoc == "DOVE0001" ? siticoneCheckBox1.Checked : siticoneCheckBox1.Checked;
            String dtFechaIni = CodDoc == "DOVE0002" ? FunGeneral.GetFechaHoraFormato(dtpFechaInicialBus.Value,5): CodDoc == "DOVE0001" ? FunGeneral.GetFechaHoraFormato(siticoneDateTimePicker2.Value, 5): FunGeneral.GetFechaHoraFormato(siticoneDateTimePicker2.Value, 5);
            String dtFechaFin = CodDoc == "DOVE0002" ? FunGeneral.GetFechaHoraFormato(dtpFechaFinalBus.Value,5): CodDoc == "DOVE0001" ? FunGeneral.GetFechaHoraFormato(siticoneDateTimePicker1.Value, 5):FunGeneral.GetFechaHoraFormato(siticoneDateTimePicker1.Value, 5);
            String buscar = CodDoc == "DOVE0002"?txtBuscar.Text.ToString(): CodDoc=="DOVE0001" ? txtBuscarBoleta.Text.ToString(): txtBuscarBoleta.Text.ToString();
            


            lstDocumentos=blDoc.blBuscarDocumentoPorEmitir(chkFechas,dtFechaIni,dtFechaFin,buscar,  CodDoc, pagina,tipocon);
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

            btnTotalPag.Text = numPaginas.ToString();
            btnNumFilas.Text = numFilas.ToString();
            btnTotalReg.Text = numRegistros.ToString();
        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 pagActual = Convert.ToInt32(cboPagina.Text);
            numInicial = (pagActual * numFilas)-numFilas;
            NumFinal = (pagActual * numFilas);
            NumFinal = NumFinal > numRegistros ? numRegistros : NumFinal;
            fnCargarTabla(dgvListaVentas);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DateTime dtt = DateTime.Now;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveFileDialog1.Title = "Guardar archivo de Excel";
            saveFileDialog1.FileName = "REPORTE FACTURAS - " + dtt.ToString("ddMMyyyyHHmmss") + ".xlsx";
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
                MessageBox.Show("El archivo de Excel ha sido creado exitosamente.");
            }

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

                siticoneDateTimePicker1.Value = Variables.gdFechaSis;
                siticoneDateTimePicker2.Value = siticoneDateTimePicker1.Value.AddDays(-(siticoneDateTimePicker1.Value.Day - 1));

                FunGeneral.fnLlenarTablaCodTipoCon(siticoneComboBox1, "EEST",true);
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
            fnBuscarDocumentos(0, comboBox1, "DOVE0001", -1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 pagActual = Convert.ToInt32(comboBox1.Text);
            numInicial = (pagActual * numFilas) - numFilas;
            NumFinal = (pagActual * numFilas);
            NumFinal = NumFinal > numRegistros ? numRegistros : NumFinal;
            fnCargarTabla(siticoneDataGridView1);
        }

        private void txtBuscarBoleta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(Char)Keys.Enter)
            {
                fnBuscarDocumentos(0, comboBox1, "DOVE0001", -1);

            }
        }
    }
}
