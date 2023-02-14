using CapaNegocio;
using CapaUtil;
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

namespace wfaIntegradoCom.Procesos
{
    public partial class frmBajadeServicio : Form
    {
        public frmBajadeServicio()
        {
            InitializeComponent();

        }
        static Boolean pasoLoad;
        static Int32 tabInicio = 0;

        private void fnCalcularPaginacion(Int32 totalRegistros, Int32 filas, Int32 totalResultados, ComboBox cboPag, SiticoneCircleButton btnTotPag, SiticoneCircleButton btnNumFil, SiticoneCircleButton btnTotReg)
        {
            Int32 residuo;
            Int32 cantidadPaginas;
            residuo = totalRegistros % filas;
            if (residuo == 0)
            {
                cantidadPaginas = (totalRegistros / filas);
            }
            else
            {
                cantidadPaginas = (totalRegistros / filas) + 1;
            }

            cboPag.Items.Clear();

            for (Int32 i = 1; i <= cantidadPaginas; i++)
            {
                cboPag.Items.Add(i);

            }

            cboPag.SelectedIndex = 0;
            btnTotPag.Text = Convert.ToString(cantidadPaginas);
            btnNumFil.Text = Convert.ToString(totalResultados);
            btnTotReg.Text = Convert.ToString(totalRegistros);

        }

        private Boolean fnBuscarBajaServicio(DataGridView dgv, Int32 numPagina, Int16 tipoCon)
        {
            
            BLCliente objCli = new BLCliente();
            clsUtil objUtil = new clsUtil();
            DataTable dtServicio = new DataTable();
            Int32 filas = 15;
            String nplaca = "";
            Boolean sestado;
            Int32 idservicios;
            Int32 idTipoDocumento;
            Int32 estServicios;
            Int32 estadoServ;
            String estado;
            try
            {
               
                    estadoServ = -1;             
                nplaca = Convert.ToString(txtBuscarPlaca.Text.ToString());
                dtServicio = objCli.blBuscarBajaServicios(numPagina, nplaca, estadoServ, tipoCon);

                Int32 totalResultados = dtServicio.Rows.Count;

                if (totalResultados > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("N°");
                    dt.Columns.Add("NOMBRE SERVICIOS");
                    dt.Columns.Add("FECHA DE REGISTRO");
                    dt.Columns.Add("DESCRIPCION");
                    dt.Columns.Add("ESTADO");

                    //Mod//

                    dt.Columns.Add("PRECIO");

                    Int32 y;

                    if (tipoCon == -1)
                    {
                        y = 0;
                    }
                    else
                    {
                        tabInicio = (numPagina - 1) * filas;
                        y = tabInicio;
                    }


                    for (int i = 0; i <= totalResultados - 1; i++)
                    {
                        y += 1;
                        if (dtServicio.Rows[i][5].ToString() == "1")
                        {
                            estado = "Activo";
                        }
                        else if (dtServicio.Rows[i][5].ToString() == "2")
                        {
                            estado = "Inactivo";
                        }
                        else
                        {
                            estado = "No tiene asignado ningun estado";
                        }

                        object[] row = {
                            dtServicio.Rows[i][1],
                            y,
                            dtServicio.Rows[i][2],
                            dtServicio.Rows[i][3],
                            dtServicio.Rows[i][4],
                            dtServicio.Rows[i][5],
                           
                            
                            
                            
                            //MOD//

                             FunGeneral.fnFormatearPrecio("S/.", Convert.ToDouble(dtServicio.Rows[i][6]), 1),

                        };
                        dt.Rows.Add(row);

                    }
                    dgv.DataSource = dt;

                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 40;
                    dgv.Columns[2].Width = 210;
                    dgv.Columns[3].Width = 90;
                    dgv.Columns[4].Width = 130;
                    dgv.Columns[5].Width = 30;
                    dgv.Columns[5].Width = 80;

                    //MOD
                    dgv.Visible = true;

                    if (tipoCon == -1)
                    {
                        gbPaginacion.Visible = true;
                        Int32 totalRegistros = Convert.ToInt32(dtServicio.Rows[0][0]);
                        fnCalcularPaginacion(
                            totalRegistros,
                            filas,
                            totalResultados,
                            cboPagina,
                            btnTotalPaginas,
                            btnNumFilas,
                            btnTotalReg
                            );
                    }
                    else
                    {
                        btnNumFilas.Text = Convert.ToString(totalResultados);
                    }

                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dgv.DataSource = dt;
                    dgv.Visible = true;
                    dt.Columns.Add("NO SE ENCONTRÓ NINGÚN RESULTADO CON ESTAS COINCIDENCIAS");
                    gbPaginacion.Visible = false;

                }
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarCliente", "fnBuscarCliente", ex.Message);
                return false;
            }
            finally
            {

                objCli = null;
                objUtil = null;
            }

        }

        private void btnBuscarBajaServicio_Click(object sender, EventArgs e)
        {
            Boolean bResul;
            if (pasoLoad)
            {
                bResul = fnBuscarBajaServicio(dgBajaServicios, 0, -1);
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar la Placa. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
