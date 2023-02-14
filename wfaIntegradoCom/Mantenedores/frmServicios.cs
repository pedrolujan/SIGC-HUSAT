using CapaNegocio;
using CapaUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siticone.UI.WinForms;
using wfaIntegradoCom.Funciones;
using System.Text.RegularExpressions;

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
        Boolean estActualizar;
        Int32 tipocondicion = 0;




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
        private Boolean fnGuardarServicios(Int32 tipoCon)
        {
            string price = txtPrecioServicio.Text;
            double precioServ;
            if (double.TryParse(Regex.Match(price, @"\d+\.\d+").Value, out precioServ))
            {
                //Console.WriteLine(precioServ);
            }
            else
            {
                //Console.WriteLine("No se pudo convertir el precio a un número");
            }



            BLCliente objCli = new BLCliente();
            clsUtil objUtil = new clsUtil();
            Int32 idServ = txtIDServicio.Text == "" ? 0 : Convert.ToInt32(txtIDServicio.Text.ToString());
            String nomServ = txtNombreServicio.Text.ToString();
            DateTime fechaServ = DtFechaRS.Value;
            String descServ = txtDescripcionServ.Text.ToString();
            Boolean estadoServ = chkEstadoServ.Checked;
            Int32 idusuario = Variables.gnCodUser;
            Int32 monedaServ = Convert.ToInt32(cboMonedaServ.SelectedValue);

            if (txtNombreServicio.Text.Length == 0)
            {
                MessageBox.Show("Falta llenar campos", "Titulo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return objCli.blGuardarServicios(idServ, nomServ, fechaServ, precioServ, descServ, estadoServ, idusuario, monedaServ, /*idValida,*/ tipoCon);
        }
        private Boolean fnBuscarServicios(DataGridView dgv, Int32 numPagina, Int16 tipoCon)
        {
            BLCliente objCli = new BLCliente();
            clsUtil objUtil = new clsUtil();
            DataTable dtServicio = new DataTable();
            Int32 filas = 15;
            String snombre = "";
            Boolean sestado;
            Int32 idservicios;
            Int32 idTipoDocumento;
            Int32 estServicios;
            Int32 estadoServ;
            String estado;
            try
            {
                if (cboEstadoBuscar.SelectedIndex == 1)
                {
                    estadoServ = 1;

                }

                else if (cboEstadoBuscar.SelectedIndex == 2)
                {
                    estadoServ = 0;
                }
                else
                {
                    estadoServ = -1;
                }




                snombre = Convert.ToString(txtBuscarServicios.Text.ToString());
                dtServicio = objCli.blBuscarServicios(numPagina, snombre, estadoServ, tipoCon);

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

        private void btnBuscarServicios_Click(object sender, EventArgs e)
        {
            Boolean bResul;

            if (pasoLoad)
            {
                bResul = fnBuscarServicios(dgServicios, 0, -1);
                gbActualizarServicios.Visible = false;
                btnActualizarServicios.Visible = false;
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar los Servicios. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }



        }

        private void txtBuscarServicios_KeyPress(object sender, KeyPressEventArgs e)
        {

            Boolean bResul;
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (pasoLoad)
                {
                    bResul = fnBuscarServicios(dgServicios, 0, -1);
                    gbActualizarServicios.Visible = false;
                    if (!bResul)
                    {
                        MessageBox.Show("Error al Buscar los Servicios. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }


            }
        }


        private void fnvalidarEstadoServicio()
        {
            if (chkEstadoServ.Checked)
            {
                chkEstadoServ.Text = "Activo";
            }
            else
            {
                chkEstadoServ.Text = "Inactivo";
            }
        }
        private void frmServicios_Load(object sender, EventArgs e)
        {


            pasoLoad = false;
            Boolean bResult;
            estActualizar = false;
            pasoLoad = true;
            gbActualizarServicios.Visible = true;
            cboEstadoBuscar.SelectedIndex = 0;
            DtFechaRS.Value = DateTime.Today;
            fnvalidarEstadoServicio();




            FunGeneral.fnLLenarMoneda(cboMonedaServ, 0, false);
            cboMonedaServ.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);
            cboMonedaServ.SelectedValue = 1;

            if (tipocondicion == 0)
            {
                btnActualizarServicios.Text = "Agregar Servicio";
            }



        }

        private void cboPagina_KeyPress(object sender, KeyPressEventArgs e)
        {
            Boolean bResul;
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (pasoLoad)
                {
                    bResul = fnBuscarServicios(dgServicios, 0, -1);
                    if (!bResul)
                    {
                        MessageBox.Show("Error al Buscar Cliente. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        private void dgServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnActualizarServicios.Visible = true;
            tipocondicion = 1;
            if (tipocondicion == 1)
            {
                btnActualizarServicios.Text = "Actualizar Servicio";
            }
            

            dgServicios.Visible = false;
            gbActualizarServicios.Visible = true;
           
            txtIDServicio.Text = dgServicios.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombreServicio.Text = dgServicios.Rows[e.RowIndex].Cells[2].Value.ToString();
            DtFechaRS.Text = dgServicios.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (dgServicios.Rows[e.RowIndex].Cells[5].Value.ToString() == "Activo")
            {
                chkEstadoServ.Checked = true;
                fnvalidarEstadoServicio();
            }
            else
            {
                chkEstadoServ.Checked = false;
                fnvalidarEstadoServicio();
            }
            txtPrecioServicio.Text = dgServicios.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtDescripcionServ.Text = dgServicios.Rows[e.RowIndex].Cells[4].Value.ToString();

            
        }

        private void fnLimpiarCampos()
        {
            txtNombreServicio.Text = "";
            txtIDServicio.Text = "";
            DtFechaRS.Value = DateTime.Today;
            txtPrecioServicio.Text = "";
            txtDescripcionServ.Text = "";
            txtNombreServicio.Focus();

        }
        private void btnActualizarServicios_Click_1(object sender, EventArgs e)
        {

            Boolean bResul;

            btnActualizarServicios.Text = "Agregar Servicio";
            if (btnActualizarServicios.Text == "Agregar Servicio")
            {
                bResul = fnGuardarServicios(tipocondicion);
            }

            if (txtNombreServicio.Text.Length == 0 &&  txtPrecioServicio.Text.Length == 0)
            {
                MessageBox.Show("Faltan llenar campos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                pasoLoad = true;
                bResul = fnGuardarServicios(tipocondicion);
                gbActualizarServicios.Visible = false;
                if (!bResul)
                {
                    MessageBox.Show("Error al Buscar los Servicios. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else

                    MessageBox.Show("Servicio Actualizado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            chkEstadoServ.Checked = false;
            fnvalidarEstadoServicio();
            dgServicios.Visible = false;
            gbActualizarServicios.Visible = true;
            
           

            fnLimpiarCampos();
            

            txtNombreServicio.Focus();
        }
        private void txtBuscarServicios_TextChanged(object sender, EventArgs e)
        {
            Boolean bResul;
            if (txtNombreServicio.Text.Length == 0 && txtPrecioServicio.Text.Length == 0 && txtDescripcionServ.Text.Length == 0)
            {
                MessageBox.Show("Faltan llenar campos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtNombreServicio.Text.Length == 1 && txtPrecioServicio.Text.Length == 1 && txtDescripcionServ.Text.Length == 1)
            {
                if (pasoLoad)
                {
                    bResul = fnGuardarServicios(tipocondicion);
                    gbActualizarServicios.Visible = false;
                    FunGeneral.fnLLenarMoneda(cboMonedaServ, 0, false);
                    cboMonedaServ.MouseWheel += new MouseEventHandler(FunGeneral.cbo_MouseWheel);
                    cboMonedaServ.SelectedValue = 1;
                    if (!bResul)
                    {
                        MessageBox.Show("Error al Buscar los Servicios. Comunicar a Administrador de Sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else

                        MessageBox.Show("Servicio Actualizado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    fnLimpiarCampos();
                    if (btnActualizarServicios.Text == "Agregar Servicio")
                    {
                        bResul = fnGuardarServicios(tipocondicion);
                    }


                }


            }
            else
            {
                txtNombreServicio.Focus();
            }
        }

        private void chkEstadoServ_CheckedChanged(object sender, EventArgs e)
        {
            fnvalidarEstadoServicio();
        }

        private void dgServicios_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex];
                    if (!clickedRow.Selected)
                    {
                        dgServicios.CurrentCell = clickedRow.Cells[e.ColumnIndex];

                    }
                    else
                    {
                        var mousePosition = dgServicios.PointToClient(Cursor.Position);
                        
                    }

                }
            }
        }
    }

}
