using CapaEntidad;
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
using wfaIntegradoCom.Funciones;

namespace wfaIntegradoCom.Mantenedores
{
    public partial class frmAdministrarChips : Form
    {
        public frmAdministrarChips()
        {
            InitializeComponent();
        }
        Int32 lnTipoCon = 0;

        Boolean estNumCuenta;
        String msjNumCuenta;
        public class chipsDGV
        {
            public bool id { get; set; }
            public int Chip { get; set; }
            public string Operador { get; set; }
        }
        private void fnValidarTipoDeBusqueda(DataTable datOperador)
        {
            
            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "Chk";
            dgvCmb.HeaderText = "Seleccionar";
            dgChips.Columns.Add(dgvCmb);

            DataTable dtEmp = new DataTable();
            dtEmp.Columns.Add("ID", typeof(int));
            dtEmp.Columns.Add("N° SIMCARD", typeof(string));
            dtEmp.Columns.Add("ESTADO", typeof(string));

            
            if (lnTipoCon == 0)
            {
                if (datOperador.Rows.Count > 0)
                {
                    FunValidaciones.fnNewMostrarCantidadBusquedas(btnContadorRegistros, lblCantRegistros, datOperador.Rows.Count, true, "Estos son los chips sin cuenta");
                }
                else
                {
                    FunValidaciones.fnNewMostrarCantidadBusquedas(btnContadorRegistros, lblCantRegistros, datOperador.Rows.Count, true, "No hay chips disponibles para agregar a cuentas");
                }

                for (int i = 0; i <= datOperador.Rows.Count - 1; i++)
                {
                    dtEmp.Rows.Add(datOperador.Rows[i][0],
                        datOperador.Rows[i][1],
                        datOperador.Rows[i][2]
                        );
                }
                dgChips.DataSource = dtEmp;


                //fnActivarCargandoGif(pIBusar, false);
            }
            else
            {
                for (int i = 0; i <= datOperador.Rows.Count - 1; i++)
                {
                    dtEmp.Rows.Add(datOperador.Rows[i][0],
                        datOperador.Rows[i][1],
                        datOperador.Rows[i][2]
                        );
                }
                dgChips.DataSource = dtEmp;
                if (datOperador.Rows.Count > 0)
                {
                    if (chkBuscar.Checked == true && Convert.ToInt32(cboNumRecibo.SelectedValue) != 0)
                    {
                        FunValidaciones.fnNewMostrarCantidadBusquedas(btnContadorRegistros, lblCantRegistros, datOperador.Rows.Count, true, "Estos son los chips para la Cuenta [ " + cboNumRecibo.Text.ToString() + " ]");
                        btnContadorRegistros.BaseColor = Variables.ColorEmpresa;                      

                        foreach (DataGridViewRow row in dgChips.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value) == false)
                            {

                                row.Cells[0].Value = true;
                            }

                        }
                    }else if(chkBuscar.Checked == true && Convert.ToInt32(cboNumRecibo.SelectedValue) == 0)
                    {
                        dgChips.DataSource = dtEmp;
                    }


                }
                else
                {
                    FunValidaciones.fnNewMostrarCantidadBusquedas(btnContadorRegistros, lblCantRegistros, datOperador.Rows.Count, true, "Sin registros => elija otro numero de cuenta");
                    btnContadorRegistros.BaseColor = Variables.ColorEmpresa;
                }
            }


           
            dgChips.Columns[0].ReadOnly = false;
            dgChips.Columns[1].Visible = true;
            dgChips.Columns[1].ReadOnly = true;
            dgChips.Columns[2].ReadOnly = true;
            dgChips.Columns[3].ReadOnly = true;
            dgChips.Visible = true;

            dgChips.Columns[1].Visible = false;
        }
        private List<AsignarReciboAChips> fnRecorrerGrilla()
        {
            AsignarReciboAChips objchips;
            List<AsignarReciboAChips> lstEquipo = new List<AsignarReciboAChips>();
            if (lnTipoCon==0)
            {
                foreach (DataGridViewRow row in dgChips.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        objchips = new AsignarReciboAChips();
                        objchips.idRecibo = Convert.ToInt32(cboNumRecibo.SelectedValue);
                        objchips.idChip = Convert.ToInt32(row.Cells[1].Value);
                        objchips.dFechaReg = Variables.gdFechaSis;
                        objchips.idUsuario = Variables.gnCodUser;
                        lstEquipo.Add(objchips);
                    }
                }
            }else if (lnTipoCon==1)
            {
                foreach (DataGridViewRow row in dgChips.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == false)
                    {
                        objchips = new AsignarReciboAChips();
                        objchips.idRecibo = Convert.ToInt32(cboNumRecibo.SelectedValue);
                        objchips.idChip = Convert.ToInt32(row.Cells[1].Value);
                        objchips.dFechaReg = Variables.gdFechaSis;
                        objchips.idUsuario = Variables.gnCodUser;
                        lstEquipo.Add(objchips);
                    }
                }
            }
           

            return lstEquipo;


        }


        public Boolean fnBuscarChips(Int32 lnIdRecibo,Int32 tipoCon)
        {
            BLOperador objEquipo = new BLOperador();
            clsUtil objUtil = new clsUtil();
            DataTable datOperador = new DataTable();
            List<SimCard> lstEquipo = null;
            ListViewItem lstItem = null;

            try
            {
                lstEquipo = new List<SimCard>();
                //lstEquipo = objEquipo.blBuscarEquipo(pcBuscar, pnTipoCon);
                dgChips.Columns.Clear();
                datOperador = objEquipo.blBuscarChipDatatable(lnIdRecibo,tipoCon);
                fnValidarTipoDeBusqueda(datOperador);


                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("frmRegistrarAccesorios", "fnBuscarEquipo", ex.Message);
                return false;
            }

        }

        private Boolean fnLlenarRecibo()
        {
            BLOperador objCate_Marca_Mod = new BLOperador();
            clsUtil objUtil = new clsUtil();
            List<SimCard> lstcategoria = new List<SimCard>();

            try
            {
                lstcategoria = objCate_Marca_Mod.blDevolverRecibo_Chip();
                cboNumRecibo.ValueMember = "idRecibo";
                cboNumRecibo.DisplayMember = "cNumRecibo".Trim().ToString();
                cboNumRecibo.DataSource = lstcategoria;

                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("FrmRegistrarCliente", "fnLlenarDepartamento", ex.Message);
                return false;
            }

        }

        private void btnRegistraChip_Click(object sender, EventArgs e)
        {
            this.Close();
            frmSimCard operador = new frmSimCard();
            operador.ShowDialog();
            
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {

        }

        private void frmAdministrarChips_Load(object sender, EventArgs e)
        {
            Int32 lnIdRecibo = 0;
            fnBuscarChips(lnIdRecibo,lnTipoCon);
            FunValidaciones.fnNewColorBotones(btnNuevo, btnEditar, btnGuardar, btnSalir);
            fnLlenarRecibo();
            dgChips.ThemeStyle.HeaderStyle.BackColor = Variables.ColorGroupBox;
            lblCantRegistros.BackColor = Color.DimGray;
            lblCantRegistros.ForeColor = Color.White;
            gbChkBuscar.BackColor = Variables.ColorGroupBox;
            chkBuscar.BackColor = Variables.ColorGroupBox;


        }

        private void dgChips_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var resul = FunValidaciones.fnNewValidarCombobox(cboNumRecibo, lblNumRecibo, pbNumRecibo);
            estNumCuenta = resul.Item1;
            msjNumCuenta = resul.Item2;

            bool blnResultado = false;
            BLOperador objEquipoImeis = new BLOperador();
            if (estNumCuenta==true)
            {                
                List<AsignarReciboAChips> lstPrecio = fnRecorrerGrilla();
                if (lstPrecio.Count > 0)
                {
                    if (lnTipoCon == 0)
                    {
                        if (MessageBox.Show("¿Desea asignar " + lstPrecio.Count + " chips al recibo " + cboNumRecibo.Text.ToString() + "? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            blnResultado = objEquipoImeis.blGrabarChips_Recibo(fnRecorrerGrilla(), lnTipoCon);
                            if (blnResultado)
                            {
                                //blnResultado = fnObtenerPreciosxProductoxUM(idEquipo);
                                //if (!blnResultado)
                                //    MessageBox.Show("No se ha cargado correctamente Listado de Precios por Producto y unidad de medida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show("Chips asignados correctamente al numero de cuenta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                fnBuscarChips(0,lnTipoCon);
                            }
                        }
                    }else if (lnTipoCon == 1)
                    {
                        if (MessageBox.Show("¿Desea remover " + lstPrecio.Count + " chips del recibo " + cboNumRecibo.Text.ToString() + "? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            blnResultado = objEquipoImeis.blGrabarChips_Recibo(fnRecorrerGrilla(), lnTipoCon);
                            if (blnResultado)
                            {
                                //blnResultado = fnObtenerPreciosxProductoxUM(idEquipo);
                                //if (!blnResultado)
                                //    MessageBox.Show("No se ha cargado correctamente Listado de Precios por Producto y unidad de medida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show("Chips removidos correctamente del recibo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (lnTipoCon == 1)
                                {
                                    lnTipoCon = 0;
                                    chkBuscar.Checked = false;
                                    cboNumRecibo.SelectedValue = 0;
                                }
                                fnBuscarChips(0,lnTipoCon);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha modificado algun Chip marque o desmarque las casillas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Porfavor elegir y/o completar todo los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void cboNumRecibo_SelectedIndexChanged(object sender, EventArgs e)
        {
           var resul= FunValidaciones.fnNewValidarCombobox(cboNumRecibo,lblNumRecibo,pbNumRecibo);
            estNumCuenta = resul.Item1;
            msjNumCuenta = resul.Item2;
            
            if (chkBuscar.Checked==true )
            {
                fnBuscarChips(Convert.ToInt32(cboNumRecibo.SelectedValue),lnTipoCon);
            }
            else
            {
                //if (lnTipoCon == 0)
                //{
                //    fnBuscarChips(0);
                //}
                //else
                //{
                //    fnBuscarChips(-1);
                //}
            }
           
        }
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            fnBuscarChips(0,lnTipoCon);
            cboNumRecibo.SelectedValue = 0;
            chkBuscar.Checked = false;
            
        }

        private void chkBuscar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBuscar.Checked == true)
            {
                btnContadorRegistros.Text = "0";
               
                lnTipoCon = 1;
                if (Convert.ToInt32(cboNumRecibo.SelectedValue)!=0)
                {
                    fnBuscarChips(Convert.ToInt32(cboNumRecibo.SelectedValue), lnTipoCon);
                }
                else
                {
                    fnBuscarChips(0, lnTipoCon);

                    lblCantRegistros.Text = "Buscar chips seleccione una cuenta";
                }
                btnContadorRegistros.BaseColor = Variables.ColorEmpresa;
                btnContadorRegistros.BackColor = Color.DimGray;
                
                dgChips.ThemeStyle.HeaderStyle.BackColor = Variables.ColorEmpresa;
                dgChips.ThemeStyle.BackColor = Variables.ColorDesactivado;

                gbChkBuscar.BackColor = Variables.ColorEmpresa;
                chkBuscar.BackColor = Variables.ColorEmpresa;


            }
            else
            {
               
                lnTipoCon = 0;
                fnBuscarChips(0,lnTipoCon);
                lblCantRegistros.Text = "Estos son los chips sin numero de cuenta";
                btnContadorRegistros.BaseColor = Variables.ColorGroupBox;
                cboNumRecibo.SelectedValue = 0;      
                
                dgChips.ThemeStyle.HeaderStyle.BackColor = Variables.ColorGroupBox;
                gbChkBuscar.BackColor = Variables.ColorGroupBox;
                chkBuscar.BackColor = Variables.ColorGroupBox;
            }
        }

        private void lblCantRegistros_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
