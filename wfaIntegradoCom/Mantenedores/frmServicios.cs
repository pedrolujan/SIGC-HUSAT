using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmServicios : Form
    {
        public frmServicios()
        {
            InitializeComponent();
        }
        static Boolean pasoLoad;
        static Int32 tabInicio = 0;


        //private Boolean fnBuscarServicios(DataGridView dgv, Int32 numPagina, Int16 tipoCon)
        //{
        //    BLCliente objCli = new BLCliente();
        //    clsUtil objUtil = new clsUtil();
        //    DataTable dtCliente = new DataTable();
        //    Int32 filas = 15;
        //    String nroDocumento = "";
        //    String bnombreCliente;

        //    Int32 idTipoPersona;
        //    Int32 idTipoDocumento;
        //    Int32 estCliente;
        //    String estado;
        //    try
        //    {


        //        bnombreCliente = Convert.ToString(txtBuscarServicios.Text.ToString());


        //        dtCliente = objCli.blBuscarServicios(bnombreCliente, estCliente, numPagina, tipoCon);

        //        Int32 totalResultados = dtCliente.Rows.Count;

        //        if (totalResultados > 0)
        //        {
        //            DataTable dt = new DataTable();
        //            dt.Clear();
        //            dt.Columns.Add("ID");
        //            dt.Columns.Add("N°");
        //            dt.Columns.Add("NOMBRE CLIENTE");
        //            //Mod//


        //            dt.Columns.Add("CELULAR");
        //            dt.Columns.Add("TIP. CLIENTE");
        //            dt.Columns.Add("TIP. DOCUMENTO");
        //            dt.Columns.Add("N° DOCUMENTO");
        //            dt.Columns.Add("ESTADO");

        //            Int32 y;

        //            if (tipoCon == -1)
        //            {
        //                y = 0;
        //            }
        //            else
        //            {
        //                tabInicio = (numPagina - 1) * filas;
        //                y = tabInicio;
        //            }


        //            for (int i = 0; i <= totalResultados - 1; i++)
        //            {
        //                y += 1;
        //                if (Convert.ToBoolean(dtCliente.Rows[i][7]) == true)
        //                {
        //                    estado = "ACTIVO";
        //                }
        //                else
        //                {
        //                    estado = "INACTIVO";
        //                }

        //                object[] row = {
        //                    dtCliente.Rows[i][0],
        //                    y,
        //                    dtCliente.Rows[i][1],
        //                    dtCliente.Rows[i][2], 
        //                    //MOD//

        //                    dtCliente.Rows[i][4],
        //                    dtCliente.Rows[i][5],
        //                    dtCliente.Rows[i][6],
        //                    estado

        //                };
        //                dt.Rows.Add(row);

        //            }
        //            dgv.DataSource = dt;

        //            dgv.Columns[0].Visible = false;
        //            dgv.Columns[1].Width = 25;
        //            dgv.Columns[2].Width = 340;
        //            //MOD
        //            dgv.Columns[3].Visible = false;


        //            dgv.Visible = true;

        //            if (tipoCon == -1)
        //            {
        //                gbPaginacion.Visible = true;
        //                Int32 totalRegistros = Convert.ToInt32(dtCliente.Rows[0][8]);
        //                fnCalcularPaginacion(
        //                    totalRegistros,
        //                    filas,
        //                    totalResultados,
        //                    cboPagina,
        //                    btnTotalPaginas,
        //                    btnNumFilas,
        //                    btnTotalReg
        //                    );
        //            }
        //            else
        //            {
        //                btnNumFilas.Text = Convert.ToString(totalResultados);
        //            }



        //        }
        //        else
        //        {
        //            DataTable dt = new DataTable();
        //            dt.Clear();
        //            dgv.DataSource = dt;
        //            dgv.Visible = true;
        //            dt.Columns.Add("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS");
        //            gbPaginacion.Visible = false;

        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("frmRegistrarCliente", "fnBuscarCliente", ex.Message);
        //        return false;
        //    }
        //    finally
        //    {

        //        objCli = null;
        //        objUtil = null;
        //    }

        //}

        private void btnBuscarServicios_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscarServicios_KeyPress(object sender, KeyPressEventArgs e)
        {
            Boolean bResul=false;
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (pasoLoad)
                {
                    //bResul = fnBuscarServicios(dgServicios, 0, -1);
                    if (!bResul)
                    {
                        MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }


            }
        }
    }
}
