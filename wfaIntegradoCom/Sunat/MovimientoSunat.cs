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

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            //fnBuscarDocumentos(0);
        }

        private void MovimientoSunat_Load(object sender, EventArgs e)
        {
            //var pages = dotNetBarTabControl1.Controls.OfType<TabPage>();
            //foreach (TabPage pg in pages)
            //{
                
            //}
        }

        private void fnBuscarDocumentos(Int32 pagina,Int32 tipoCon)
        {
            BLDocumentoVenta blDoc=new BLDocumentoVenta();
            Boolean chkActivaFecha = chkHabilitarFechasBus.Checked;
            //String dtFechaIni=FunGeneral.GetFechaHoraFormato();
            //String dtFechaFin=;
            //String pcBuscar=;
            //Int32 numPagina=;
            //Int32 pnTipoCon=;        
            //String  pBuscar=txtBuscar.Text.ToString();
            //DataTable dtResult = new DataTable();
            //dtResult= blDoc.blBuscarDocumentoPorEmitir(pBuscar, tipoCon);
        }
    }
}
