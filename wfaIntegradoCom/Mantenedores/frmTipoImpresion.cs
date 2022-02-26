using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaIntegradoCom.Consultas;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmTipoImpresion : Form
    {
        public frmTipoImpresion()
        {
            InitializeComponent();
        }
        Int32 lnTipoLLamada = 0;
        Int32 lnTipoVenta = 0;
        String cCodVenta = "";
        String cTipoCon = "";
        Int32 idContrato = 0;
        static List<Vehiculo> lstVehiculos = new List<Vehiculo>();
        public void inicio(Int32 tll,String codV,List<Vehiculo> lstV,string TipoCOn,Int32 idCT)
        {
            lnTipoLLamada = tll;
            lnTipoVenta = tll;
            cCodVenta = codV;
            lstVehiculos = lstV;
            cTipoCon = TipoCOn;
            idContrato = idCT;
            this.ShowDialog();
        }

        private void frmTipoImpresion_Load(object sender, EventArgs e)
        {
            if (lnTipoLLamada==0)
            {
                int i = 1;
                foreach (Vehiculo vh in lstVehiculos)
                {
                    dgvListaVehiculos.Rows.Add(cCodVenta,vh.vPlaca, i, vh.vModeloV);
                    i++;
                }
                

            }
        }

        private void dgvListaVehiculos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvListaVehiculos.Columns[e.ColumnIndex].Name == "lvBtnImprimir" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvListaVehiculos.Rows[e.RowIndex].Cells["lvBtnImprimir"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\Impresora.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvListaVehiculos.Rows[e.RowIndex].Height = 40;
                this.dgvListaVehiculos.Columns[e.ColumnIndex].Width = 40;


                e.Handled = true;

            }
        }

        private void dgvListaVehiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListaVehiculos.Columns["lvBtnImprimir"].Index && e.RowIndex >= 0)
            {
                String cCodigoVenta = Convert.ToString(dgvListaVehiculos.Rows[e.RowIndex].Cells[0].Value);
                String Placa = Convert.ToString(dgvListaVehiculos.Rows[e.RowIndex].Cells[1].Value);
                //Int32 idContrato = Convert.ToInt32(dgvListaVehiculos.Rows[e.RowIndex].Cells[15].Value);
                xmlInstalacion xmlInst = new xmlInstalacion();
                frmRegistrarVenta frmV = new frmRegistrarVenta();
                if (cTipoCon=="C")
                {
                    frmRptContrato frmVPContrato = new frmRptContrato();
                    var resutl = frmV.fnBuscarContrato(cCodigoVenta, Placa, idContrato);
                    frmVPContrato.Inicio(resutl.Item1, resutl.Item2, resutl.Item3);
                }else if (cTipoCon == "A")
                {
                    frmRptActa frmVPActa = new frmRptActa();
                    xmlInst = frmV.fnBuscarActaInstalacion(cCodigoVenta, Placa, lnTipoVenta);
                    frmVPActa.Inicio(xmlInst.ListaCliente, xmlInst.ListaVehiculo, xmlInst.ListaEquipo, xmlInst.ListaPlan, xmlInst.ListaAccesorio, xmlInst.ListaServicio, xmlInst.observaciones, xmlInst.clsInstalacion,1);

                }
                    
                    //fnMandarAImprimirDocumento(cCodigoVenta,  lnTipoCon);
            }
        }
    }
}
