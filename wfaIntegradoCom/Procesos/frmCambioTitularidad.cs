using CapaDato;
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

namespace wfaIntegradoCom.Procesos
{
    public partial class frmCambioTitularidad : Form
    {

        public frmCambioTitularidad() 
        {
            InitializeComponent();

        }
        static Int32 lnTipoCon = 0;
        //static cambioTitularidad ClsCambioTitularidad
        static List<Cliente> lstClientes = new List<Cliente>();
        static List<Vehiculo> lstvehiculo = new List<Vehiculo>();
        //static List<ClienteN> lstClientesN = new List<ClienteN>();
        //static List<VehiculoN> lstvehiculoN = new List<VehiculoN>();

        String msjCliente, msjdni, msjtelefono;
        Boolean estCliente, estdni, esttelefono;



        private void txtBusca_KeyPress(object sender, KeyPressEventArgs e)
        {

            lnTipoCon = 0;
            if (e.KeyChar == (Char)Keys.Enter)
            {
                
                
                fnBuscarDatosCliente(lnTipoCon);
            }
      
        
        }

        private void frmCambioTitularidad_Load(object sender, EventArgs e)
        {

            dgConsulta.Visible = false;
            dtFechaTitulacion.Value = Variables.gdFechaSis;
            FunValidaciones.fnColorBtnGuardar(btnGuardarCliente);

        }

      
        private void fnListarDatosCliente(int condicion, DataGridViewCellEventArgs e)
        {

            clsUtil objUtil = new clsUtil();
            DataTable datosclienteT = new DataTable();
            BLTitularidad  datTitularidad = new BLTitularidad();
            DataTable datResultado = new DataTable();
            try
            {
               
             
                datResultado= datTitularidad.BlBuscarTitularidadEspecificos(condicion, Convert.ToInt32(dgConsulta.Rows[e.RowIndex].Cells[0].Value));
                if (datResultado.Rows.Count > 0)
                {
                    lstClientes.Clear();
                    lstvehiculo.Clear();

                    foreach (DataRow drMenu in datResultado.Rows)
                    {

                        txtCliente.Text = Convert.ToString(drMenu["cNombre"]);
                        lstClientes.Add(new Cliente
                        {
                            idCliente = Convert.ToInt32(drMenu["idCliente"]),
                            cNombre = Convert.ToString(drMenu["NombreCliente"]),
                            cApePat = Convert.ToString(drMenu["cApePat"]),
                            cApeMat = Convert.ToString(drMenu["cApeMat"])

                        });
                        txtCliente.Text = lstClientes[0].cNombre + " " + lstClientes[0].cApePat + " " + lstClientes[0].cApeMat;


                        txtbni.Text = Convert.ToString(drMenu["cDocumento"]);
                        txtTelefono.Text = Convert.ToString(drMenu["cTelCelular"]);
                        txtCorreo.Text = Convert.ToString(drMenu["cCorreo"]);

                        





                    }

                }
            }
            catch (Exception exp)
            {

            }
        }

        private void BtnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            frmCambioTitularidad frmCambioTitularidad = new frmCambioTitularidad();
            //frmCambioTitularidad.Inicio();

            //*fnActivarCamposEquipo*(true, "");
            //txtclienteN.Text = Convert.ToString(lstclienteN[0].*imei*);
        }

        private void dgConsulta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            lnTipoCon = 1;

            fnListarDatosCliente(lnTipoCon, e);
            //fnActivarCamposEquipo(true)
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtCliente, lblCliente, pbcliente, true, true, true, 3, 50, 50, 50, "Complete el Nombre del cliente");
            estCliente = resultado.Item1;
            msjCliente = resultado.Item2;

        }

        private Boolean fnBuscarDatosCliente (Int32 cond)
        {
            BLTitularidad datCliente = new BLTitularidad();
            clsUtil objUtil = new clsUtil();
            DataTable datResultado = new DataTable();
            try
            {
                string BuscaDato = Convert.ToString(txtBusca.Text);
                datResultado = datCliente.BlBuscarTitularidad(cond, BuscaDato);

                dgConsulta.Visible = true;
                dgConsulta.Rows.Clear();

                foreach (DataRow drMenu in datResultado.Rows)
                {
                    dgConsulta.Rows.Add(
                        Convert.ToString(drMenu["idventageneral"]),
                       Convert.ToString(drMenu["cNombre"]),
                       Convert.ToString(drMenu["vPlaca"]));

                       
                }
                return true ; 
                {
                    return false;

                }

            }
            finally
            {

            }
        }

        private void txtbni_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtbni, lblDni, pbdni, true, true, true, 3, 50, 50, 50, "ingrese el numero de DNI");
            estdni = resultado.Item1;
            msjdni = resultado.Item2;

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtTelefono, lblTelefono, pbtelefono, true, true, true, 3, 50, 50, 50, "ingrese el numero de telefono");
            esttelefono = resultado.Item1;
            msjtelefono = resultado.Item2;


        }
}
}
