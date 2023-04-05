using CapaEntidad;
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
using wfaIntegradoCom.Mantenedores;

namespace wfaIntegradoCom.Procesos
{
    public partial class frmListarTipoVentas : Form
    {
        public frmListarTipoVentas()
        {
            BLOtrasVenta tipVenta = new BLOtrasVenta(); ;
            InitializeComponent();
        }
        static Int32 lnTipoLlamada = 0;
        static Int32 tabInicio;
        frmEquipoImeis frmImeis;
        frmAdministrarEquipos frmAdminEquipos;

        Boolean cargoForm = false;
        public void Inicio(Int16 pnTipoLlamda)
        {
            lnTipoLlamada = pnTipoLlamda;
            ShowDialog();

        }

        private void fnAgregarDatosDeBusqueda(Int32 tipoConPagina, Int32 pagina, Int32 filas, DataTable dtDatosResp, Int32 totalResultados, Int32 idTipoventa)
        {
           
            Int32 y;
            
            if (pagina == 0)
            {
                y = 0;
            }
            else
            {
                tabInicio = (pagina - 1) * filas;
                y = tabInicio;
            }

            
            if(idTipoventa == 2)
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("N°");
                dt.Columns.Add("EQUIPO");
                dt.Columns.Add("IMEI");
                dt.Columns.Add("PRECIO");
                foreach (DataRow dr in dtDatosResp.Rows)
                {
                    y++;
                    object[] dRow = {dr["idEquipoImeis"],
                                        y,
                                        dr["equipoUnico"],
                                        dr["Imei"],
                                        dr["cSimbolo"]+" "+string.Format("{0:0.00}",dr["cPrecio"])};

                    dt.Rows.Add(dRow);
                }
                dgOtrasVentas.DataSource = dt; dgOtrasVentas.Visible = true; gbPaginacion.Visible = true;
            }
            else if (idTipoventa == 3)
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("N°");
                dt.Columns.Add("ACCESORIO");
                dt.Columns.Add("PRECIO");
                dt.Columns.Add("STOCK");
                foreach (DataRow dr in dtDatosResp.Rows)
                {
                    y++;
                    object[] dRow = {dr["idAccesorio"],
                                        y,
                                        dr["cNombre"]+" "+dr["cDescripcion"],
                                        dr["cSimbolo"]+" "+string.Format("{0:0.00}",dr["cPrecio"]),
                                        dr["cStock"]};

                    dt.Rows.Add(dRow);
                }
                dgOtrasVentas.DataSource = dt; dgOtrasVentas.Visible = true; gbPaginacion.Visible = true;
            }else if (idTipoventa == 4)
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("N°");
                dt.Columns.Add("NOMBRE");
                dt.Columns.Add("PRECIO");
                foreach (DataRow dr in dtDatosResp.Rows)
                {
                    y++;
                    object[] dRow = {dr["idServicio"],
                                        y,
                                        dr["cNombre"]+" "+dr["cDescripcion"],
                                        dr["cSimbolo"]+" "+string.Format("{0:0.00}",dr["cPrecio"])};

                    dt.Rows.Add(dRow);
                }
                dgOtrasVentas.DataSource = dt; dgOtrasVentas.Visible = true; gbPaginacion.Visible = true;
            }


            dgOtrasVentas.Columns[0].Visible = false;
            dgOtrasVentas.Columns[1].Width = 30;

            if (pagina == 0)
            {
                Int32 totalRegistros = Convert.ToInt32(dtDatosResp.Rows[0][0]);
                gbPaginacion.Visible = true;
                fnCalcularPaginacion(totalRegistros, filas, totalResultados, cboPagina, btnTotalPaginas, btnRegistros, btnTotalRegistros);

            }

        }

        
        
        public Boolean fnBuscarTipoVenta(String pcBuscar, Int32 numPaginacion, Int32 tipoCon)
        {
            BLOtrasVenta objTipoVenta = new BLOtrasVenta();
            clsUtil objUtil = new clsUtil();
            DataTable dtResp = new DataTable();
            List<TipoVenta> lsTipoVenta = new List<TipoVenta>();
            Int32 filas = 20;

            try
            {
                lsTipoVenta.Add(new TipoVenta
                {
                    idTipoVenta = Convert.ToInt32(cboTipoVenta.SelectedValue),
                    idMarca=Convert.ToInt32(cboMarca.SelectedValue),
                    idModelo=Convert.ToInt32(cboModelo.SelectedValue)

                });
                dtResp = objTipoVenta.blBuscarTipoventas(pcBuscar, lsTipoVenta,  numPaginacion, tipoCon);
                DataTable dt = new DataTable();
                fnAgregarDatosDeBusqueda(tipoCon, numPaginacion,filas,dtResp, dtResp.Rows.Count,Convert.ToInt32(cboTipoVenta.SelectedValue)) ;
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmOrdenCompra", "fnListarProveedorActivo", ex.Message);
                return false;
            }
            finally
            {
                objUtil = null;
                objTipoVenta = null;
                lsTipoVenta = null;
            }
        }

        private void fnCalcularPaginacion(Int32 totalRegistros, Int32 filas, Int32 totalResultados, ComboBox cboPaginacion, SiticoneCircleButton btnNumPagina, SiticoneCircleButton btnRegistros, SiticoneCircleButton btnTotalRegistros)
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


            cboPaginacion.Items.Clear();

            for (Int32 i = 1; i <= cantidadPaginas; i++)
            {
                cboPaginacion.Items.Add(i);

            }

            btnNumPagina.Text = Convert.ToString(cantidadPaginas);
            btnRegistros.Text = Convert.ToString(totalResultados);
            btnTotalRegistros.Text = Convert.ToString(totalRegistros);
            cboPaginacion.SelectedIndex = 0;
        }
        public Boolean fnLLnenarMarcaxCategoria(Int32 idCategoria, Int16 pnTipoCon, Boolean buscar, ComboBox combo)
        {
            BLCate_Mar_Mod objCate_Marca_Mod = new BLCate_Mar_Mod();
            clsUtil objUtil = new clsUtil();
            List<MarcaEquipo> lstMarca = new List<MarcaEquipo>();

            try
            {
                lstMarca = objCate_Marca_Mod.blDevolverMarcaEquipo(idCategoria, pnTipoCon, buscar);
                combo.ValueMember = "idMarca";
                combo.DisplayMember = "cNomMarca";
                combo.DataSource = lstMarca;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarEquipo", "fnLlenarMarca", ex.Message);
                return false;
            }

        }
        private void frmListarTipoVentas_Load(object sender, EventArgs e)
        {
            cargoForm = false;
            try
            {
                Boolean bResult = false;
                if (lnTipoLlamada==1)
                {
                    bResult = fnLLnenarMarcaxCategoria(1, 0, true, cboMarca);
                    if (!bResult)
                    {
                        MessageBox.Show("Error al Cargar Marca", "Avise al Administrador de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    //FunGeneral.fnLlenarTablaCod(cboTipoVenta,"TVNT");
                    FunGeneral.fnLlenarCboSegunTablaTipoCon(cboTipoVenta, "idTipoTransaccion", "nombre", "TipoTransaccion", "estado", "1", false);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cargoForm = true;
            }
        }

        private void txtBuscarXSimCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarTipoVenta(txtBuscar.Text.ToString(),0,-1);
            }
        }

        private void cboPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBuscarTipoVenta(txtBuscar.Text.ToString(), Convert.ToInt32(cboPagina.Text), -2);
        }

        private void dgOtrasVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fnRecuperarObjetos(e);
            this.Dispose();
        }

        private Boolean fnRecuperarObjetos(DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            BLOtrasVenta obtTVenta = new BLOtrasVenta();
            DataTable dtResp = new DataTable();
            
            try
            {
                OtrasVentas clsOtrasVentas = new OtrasVentas();

                Int32 idObjetoVenta = Convert.ToInt32(dgOtrasVentas.Rows[e.RowIndex].Cells[0].Value);
                dtResp = obtTVenta.blDevloverTipoventas(Convert.ToInt32(cboTipoVenta.SelectedValue), idObjetoVenta);

                if (dtResp.Rows.Count>0)
                {
                    foreach (DataRow dr in dtResp.Rows)
                    {
                        clsOtrasVentas.idObjVenta = Convert.ToInt32(dr["id"]);
                        clsOtrasVentas.DetalleVentas= Convert.ToString(dr["nombre"]);
                        clsOtrasVentas.simbMoneda = Convert.ToString(dr["cSimbolo"]);
                        clsOtrasVentas.precioUnico= Convert.ToDecimal(dr["cPrecio"].ToString());
                        clsOtrasVentas.idMoneda= Convert.ToInt32(dr["idMoneda"]);
                        clsOtrasVentas.idTipoTransaccion= Convert.ToInt32(dr["idTipoTransaccion"]);
                        clsOtrasVentas.idValida = Convert.ToInt32(dr["idValida"]);
                        clsOtrasVentas.idOperacion = Convert.ToInt32(dr["idOperacion"]);
                    }

                }

                frmOtrasVentas fr = new frmOtrasVentas();
                fr.fnObtenerObjVentas(clsOtrasVentas);

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarProveedor", "fnRecuperarProveedorEsp", ex.Message);
                return false;
            }
            
        }

        private void fnCambiarPosisionObt(SiticoneGroupBox gb, Int32 x,Int32 y)
        {
            gb.Location = new Point(x, y);      
            
        }
        private void cboTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cargoForm==true) 
            {
                if (Convert.ToString(cboTipoVenta.SelectedValue) == "TVNT0002")
                {
                    gbBusqMarcaModelo.Visible = true;
                    fnCambiarPosisionObt(gbCajaDeTexto, 1010, 40);
                    fnCambiarPosisionObt(gbBusqMarcaModelo, 318, 20);
                   
                }
                else 
                {
                    fnCambiarPosisionObt(gbCajaDeTexto, 318, 40);
                    fnCambiarPosisionObt(gbBusqMarcaModelo, 578, 20);
                    gbBusqMarcaModelo.Visible = false;
                }

                fnBuscarTipoVenta(txtBuscar.Text.ToString(), 0, -1);
            }
        }

        public Boolean fnLlenarModeloxMarca(Int32 idMarca, Int16 lnTipoCon, ComboBox combo, Boolean buscar)
        {
            BLCate_Mar_Mod objCate_Marca_Mod = new BLCate_Mar_Mod();
            clsUtil objUtil = new clsUtil();
            List<ModeloEquipo> lstModelo = new List<ModeloEquipo>();

            try
            {
                lstModelo = objCate_Marca_Mod.blDevolverModeloEquipo(idMarca, lnTipoCon, buscar);
                combo.ValueMember = "idModelo";
                combo.DisplayMember = "cNomModelo";
                combo.DataSource = lstModelo;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }
        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargoForm==true)
            {
                fnLlenarModeloxMarca(Convert.ToInt32(cboMarca.SelectedValue), 1, cboModelo, true);
            }
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
