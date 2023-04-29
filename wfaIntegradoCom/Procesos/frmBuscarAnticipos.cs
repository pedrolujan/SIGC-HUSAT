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

namespace wfaIntegradoCom.Procesos
{
    public partial class frmBuscarAnticipos : Form
    {
        public frmBuscarAnticipos()
        {
            InitializeComponent();
        }
        static Int32 idTrandiaria = 0;
        static List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();
        public void Inicio(Int32 idTrand)
        {
            idTrandiaria=idTrand;
            this.ShowDialog();
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            fnBuscarAnticipos();
        }
        private void fnBuscarAnticipos()
        {
            BLDocumentoVenta bLDocumentoVenta = new BLDocumentoVenta();

            try
            {
                String codDocumento = txtBuscar.Text.ToString();
                lstDetalleVenta.Clear();
                lstDetalleVenta = bLDocumentoVenta.blBuscarDocVenta(codDocumento, idTrandiaria);
                dgvAnticipos.Columns.Clear();
                dgvAnticipos.Rows.Clear();

                if (lstDetalleVenta.Count>0)
                {
                    dgvAnticipos.Columns.Add("id", "id");
                    dgvAnticipos.Columns.Add("numero", "N°");
                    dgvAnticipos.Columns.Add("Codigo", "Codigo Documento");
                    dgvAnticipos.Columns.Add("fecha", "Fecha Registro");
                    dgvAnticipos.Columns.Add("Importe", "Importe");

                    Int32 y = 0;
                    foreach (DetalleVenta d in lstDetalleVenta)
                    {
                        y++;
                        dgvAnticipos.Rows.Add(
                            d.IdDetalleVenta,
                            y,
                            d.CodigoProducto,
                            FunGeneral.GetFechaHoraFormato(d.dtFechaRegistro, 5),
                            FunGeneral.fnFormatearPrecioDC("S/. ", d.Importe, 0)
                            );


                    }
                    dgvAnticipos.Columns[0].Visible = false;
                    dgvAnticipos.Visible = true;
                }
                else
                {
                    dgvAnticipos.Columns.Add("SinDatos", "No se encontraron datos");
                }
                

            }
            catch (Exception ex)
            {

              
            }
            


            
        }

        private void frmBuscarAnticipos_Load(object sender, EventArgs e)
        {

        }

        private void dgvAnticipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmTipoPago f = new frmTipoPago();
            Int32 idConcepto= Convert.ToInt32(dgvAnticipos.Rows[e.RowIndex].Cells[0].Value);
            DetalleVenta clsDetVanta=lstDetalleVenta.Find(i=>i.IdDetalleVenta==idConcepto);
            clsDetVanta.Importe = clsDetVanta.Importe * -1;
            f.fnRecibirAnticipos(clsDetVanta);
            this.Dispose();
        }
    }
}
