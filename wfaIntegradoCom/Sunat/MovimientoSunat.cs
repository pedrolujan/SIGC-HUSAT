using CapaEntidad;
using CapaNegocio;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
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
        static Int32 numFilas = 3;
        static Int32 numPaginas = 3;
        static Int32 numRegistros = 0;
        static Int32 numInicial = 0;
        static Int32 NumFinal = 0;
        private void pbBuscar_Click(object sender, EventArgs e)
        {
            fnBuscarDocumentos(0,-1);
        }
        private void fnBuscarDocumentos(Int32 pagina,Int32 tipocon)
        {
            BLDocumentoVenta blDoc=new BLDocumentoVenta();
            Boolean chkFechas = chkHabilitarFechasBus.Checked;
            String dtFechaIni = FunGeneral.GetFechaHoraFormato(dtpFechaInicialBus.Value,5);
            String dtFechaFin = FunGeneral.GetFechaHoraFormato(dtpFechaFinalBus.Value,5);
            String buscar=txtBuscar.Text.ToString();
            


            lstDocumentos=blDoc.blBuscarDocumentoPorEmitir(chkFechas,dtFechaIni,dtFechaFin,buscar,pagina,tipocon);
            fnLlenarPaginacion();
        }

        private void fnCargarTabla()
        {
            dgvListaVentas.Rows.Clear();
            for (int i = numInicial; i < NumFinal; i++)
            {
                dgvListaVentas.Rows.Add(
                    lstDocumentos[i].idVenta,
                    lstDocumentos[i].numero,
                    lstDocumentos[i].CodigoCorrelativo,
                    lstDocumentos[i].dFechaRegistro.ToString("dd-MM-yyyy"),
                    lstDocumentos[i].cVehiculos,
                    lstDocumentos[i].cCliente,
                    "Emitido",
                    ""

                    );
            }
            dgvListaVentas.Visible = true;
        }
        private void fnLlenarPaginacion()
        {
            Int32 residuo = 0;
            cboPagina.Items.Clear();
            numRegistros = lstDocumentos.Count;
            residuo = numRegistros % numFilas;
            numPaginas = residuo == 0 ? (numRegistros / numFilas) : (numRegistros / numFilas) + 1;
            for (int i = 0; i < numPaginas; i++)
            {
                cboPagina.Items.Add(i+1);
            }
            cboPagina.SelectedIndex = 0;

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
            fnCargarTabla();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            // Crea un nuevo archivo de Excel
            SpreadsheetDocument documento = SpreadsheetDocument.Create("mi_archiv122.xlsx", SpreadsheetDocumentType.Workbook);

            // Crea una hoja de cálculo dentro del archivo
            WorkbookPart libroParte = documento.AddWorkbookPart();
            libroParte.Workbook = new Workbook();
            WorksheetPart hojaParte = libroParte.AddNewPart<WorksheetPart>();
            hojaParte.Worksheet = new Worksheet(new SheetData());
            Sheets hojas = documento.WorkbookPart.Workbook.AppendChild(new Sheets());
            Sheet hoja = new Sheet() { Id = documento.WorkbookPart.GetIdOfPart(hojaParte), SheetId = 1, Name = "Datos" };
            hojas.Append(hoja);

            // Obtiene los datos del DataGridView
            //DataGridViewColumn filaEncabezado = dgvListaVentas.Columns;
            int numColumnas = dgvListaVentas.Columns.Count;
            int numFilas = dgvListaVentas.Rows.Count;

            // Agrega los datos a la hoja de cálculo
            SheetData datosHoja = hojaParte.Worksheet.GetFirstChild<SheetData>();
            datosHoja.AppendChild(new Row());

            // Agrega los encabezados de columna
            for (int i = 1; i < numColumnas; i++)
            {
                Cell celda = CreaCelda(i + 1, 1, dgvListaVentas.Columns[i].HeaderText.ToString());
                datosHoja.LastChild.AppendChild(celda);
            }

            // Agrega los datos de las filas
            for (int i = 0; i < numFilas; i++)
            {
                DataGridViewRow filaDatos = dgvListaVentas.Rows[i];
                datosHoja.AppendChild(new Row());
                for (int j = 1; j < numColumnas; j++)
                {
                    Cell celda = CreaCelda(j, i + 1, filaDatos.Cells[j].Value.ToString());
                    datosHoja.LastChild.AppendChild(celda);
                }
            }

            // Cierra el archivo de Excel
            documento.Close();

            MessageBox.Show("El archivo de Excel ha sido creado exitosamente.");
        }

        private Cell CreaCelda(int columna, int fila, string valor)
        {
            Cell celda = new Cell();
            celda.DataType = CellValues.String;
            celda.CellReference = GetColumnaLetra(columna) + fila.ToString();
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

    }
}
