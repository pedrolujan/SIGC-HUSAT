using CapaEntidad;
using CapaNegocio;
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
    }
}
