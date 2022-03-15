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
using System.Reflection;
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

        Double IGV;
        Double SutTotal;
        Double total;
        Double precioUnit;
        Double descuento = 0;
        String CambioTitularidad = "";
        static Int32 lnTipoCon = 0;
        static Int32 idCliente= 0;
        static Int32 idModelo = 0;
        //string Int32 idVenta=0;
        //static CambioTitularidad ClsCambioTitularidad
        static List<Cliente> lstClientes = new List<Cliente>();
        static List<Vehiculo> lstvehiculo = new List<Vehiculo>();
        static List<ModeloVehiculo> lstModelo = new List<ModeloVehiculo>();
        static List<MarcaVehiculo> lstMarca = new List<MarcaVehiculo>();
        static List<DetalleVenta> lstDventa = new List<DetalleVenta>();
        static List<DocumentoVenta> lstdocumentoV = new List<DocumentoVenta>();

        static Titularidad ClsTitularidad;
        //static List<ClienteNuevo> lstClientesN = new List<ClienteNuevo>();
        //static List<VehiculoNuevo> lstvehiculoN = new List<VehiculoNuevo>();

        String msjCliente, msjdni, msjPlaca, msjCNuevo, msjDNuevo, msjTelNuevo, msjDireccionN;
        Boolean estCliente, estdni, estPlaca, estCNuevo, estDNuevo, estTelNuevo, estDireccionN;




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
            dgConsultaCliente.Visible = false;
            lstDventa.Clear();
            lstdocumentoV.Clear();
            dtFechaTitulacion.Value = Variables.gdFechaSis;
            FunValidaciones.fnColorBtnGuardar(btnGuardarCliente);

        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtPlaca, lblPlaca, pbplaca, true, true, true, 3, 50, 50, 50, "Complete el Placa");
            estPlaca = resultado.Item1;
            msjPlaca = resultado.Item2;
        }
        private void fnListarDatosClienteNuevo(int condicion, DataGridViewCellEventArgs e)
        //tabala nueva de cliente
        {

            clsUtil objUtil = new clsUtil();
            DataTable datosclienteT = new DataTable();
            BLTitularidad datTitularidad = new BLTitularidad();
            DataTable datResultado = new DataTable();
            try
            {


                
                datResultado = datTitularidad.BlBuscarTitularidadEspecificos(condicion, Convert.ToInt32(dgConsultaCliente.Rows[e.RowIndex].Cells[0].Value));
                if (datResultado.Rows.Count > 0)
                {
                    lstClientes.Clear();
                    dgConsultaCliente.Visible = false;
                    foreach (DataRow drMenu in datResultado.Rows)
                    {

                        txtClienteNuevo.Text = Convert.ToString(drMenu["cNombre"]);
                        
                        lstClientes.Add(new Cliente
                        {
                            idCliente = Convert.ToInt32(drMenu["idCliente"]),
                            cNombre = Convert.ToString(drMenu["cNombre"]),
                            cApePat = Convert.ToString(drMenu["cApePat"]),
                            cApeMat = Convert.ToString(drMenu["cApeMat"]),
                            cDocumento = Convert.ToString(drMenu["cDocumento"]),
                            cTelCelular = Convert.ToString(drMenu["cTelCelular"]),
                            cDireccion = Convert.ToString(drMenu["cDireccion"]),
                            cTipoDoc = Convert.ToString(drMenu["NomTdoc"])
                        });
                        txtClienteNuevo.Text = lstClientes[0].cNombre + " " + lstClientes[0].cApePat + " " + lstClientes[0].cApeMat;
                        txtTelefonoNuevo.Text = Convert.ToString(drMenu["cTelCelular"]);
                        txtDireccionNuevo.Text = Convert.ToString(drMenu["cDireccion"]) != "" ? Convert.ToString(drMenu["cDireccion"]) : "No registro su Direccion";
                        txtDniNuevo.Text = Convert.ToString(drMenu["cDocumento"]);

                    }

                }
            }
            catch (Exception exp)
            {

            }

        }

        private void fnListarDatosCliente(int condicion, DataGridViewCellEventArgs e)
        {
            clsUtil objUtil = new clsUtil();
            DataTable datosclienteT = new DataTable();
            BLTitularidad datTitularidad = new BLTitularidad();
            DataTable datResultado = new DataTable();
            try
            {


                datResultado = datTitularidad.BlBuscarTitularidadEspecificos(condicion, Convert.ToInt32(dgConsulta.Rows[e.RowIndex].Cells[0].Value));
                if (datResultado.Rows.Count > 0)
                {
                    lstClientes.Clear();
                    lstvehiculo.Clear();
                    lstModelo.Clear();
                    lstMarca.Clear();

                    Titularidad clsTitu = new Titularidad();
                    clsTitu.idModelo = 0;

                    dgConsulta.Visible = false;
                    foreach (DataRow drMenu in datResultado.Rows)
                    {

                        txtCliente.Text = Convert.ToString(drMenu["cNombre"]);
                        lstClientes.Add(new Cliente
                        {
                            idCliente = Convert.ToInt32(drMenu["idCliente"]),
                            cNombre = Convert.ToString(drMenu["cNombre"]),
                            cApePat = Convert.ToString(drMenu["cApePat"]),
                            cApeMat = Convert.ToString(drMenu["cApeMat"]),
                            cDocumento = Convert.ToString(drMenu["cDocumento"]),
                            cTelCelular = Convert.ToString(drMenu["cTelCelular"]),
                            cCorreo = Convert.ToString(drMenu["cCorreo"]),
                            cTipoDoc=Convert.ToString(drMenu["NomTdoc"])

                    });
                        txtCliente.Text = lstClientes[0].cNombre + " " + lstClientes[0].cApePat + " " + lstClientes[0].cApeMat;
                        txtdni.Text = Convert.ToString(drMenu["cDocumento"]);
                        txtTelefono.Text = Convert.ToString(drMenu["cTelCelular"]);
                        txtCorreo.Text = Convert.ToString(drMenu["cCorreo"]) != "" ? Convert.ToString(drMenu["cCorreo"]) : "SIN CORREO";
                       

                        txtPlaca.Text = Convert.ToString(drMenu["vPlaca"]);

                        txtSerie.Text = Convert.ToString(drMenu["vSerie"]);


                        lstvehiculo.Add(new Vehiculo
                        {
                            idVehiculo = Convert.ToInt32(drMenu["idVehiculo"]),
                            vPlaca = Convert.ToString(drMenu["vPlaca"]),
                            vSerie = Convert.ToString(drMenu["vSerie"]),

                        });

                       


                        txtMarca.Text = Convert.ToString(drMenu["nombreMarcaV"]);
                        lstMarca.Add(new MarcaVehiculo
                        {
                            idMarca = Convert.ToInt32(drMenu["idMarcaV"]),
                            cNomMarca = Convert.ToString(drMenu["nombreMarcaV"]),

                        });
                        //txtMarca.Text = lstMarca[0].cNomMarca;

                        txtModelo.Text = Convert.ToString(drMenu["nombreModeloV"]);
                        lstModelo.Add(new ModeloVehiculo
                        {
                            idModelo = Convert.ToInt32(drMenu["idModeloV"]),
                            cNomModelo = Convert.ToString(drMenu["nombreModeloV"])
                        });
                        //txtModelo.Text = lstModelo[0].cNomModelo;
                    }

                }
            }
            catch (Exception exp)
            {

            }

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            //    var resultado = FunValidaciones.fnValidarTexboxs(txtCorreo, lblcorreo, pbcorreo, true, true, true, 3, 50, 50, 50, "Complete el Nunero de Telefono");
            //    estCorreo = resultado.Item1;
            //    msjCorreo = resultado.Item2;
        }

        private void BtnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            frmCambioTitularidad frmCambioTitularidad = new frmCambioTitularidad();

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            //var resultado = FunValidaciones.fnValidarTexboxs(txtTelefono, lblTelefono, pbtelefono, true, true, true, 3, 20, 20, 20, "Complete el Nunero de Telefono");
            //estTelefono = resultado.Item1;
            //msjTelefono = resultado.Item2;

        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbni_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtdni, lblDni, pbdni, true, true, true, 3, 20, 20, 20, "Complete el Nunero de DNI");
            estdni = resultado.Item1;
            msjdni = resultado.Item2;
        }


        private Boolean fnGurdarNuevoCliente(Titularidad clsTitu, Int32 tipocon)
        {
            clsUtil objUtil = new clsUtil();
            DataTable datosTitularidad = new DataTable();
            BLTitularidad datTITULACION = new BLTitularidad();
            Int32 datResultado = 0;
            try
            {
                datResultado = datTITULACION.blGuardarClienteN(clsTitu, tipocon);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtImporte_KeyUp(object sender, KeyEventArgs e)                       
         {          

            lstDventa.Clear();
            lstdocumentoV.Clear();

            //total = Convert.ToDouble(txtTotal.Text);
            CambioTitularidad = "Cambio de Titularidad";
            precioUnit = Convert.ToDouble(txtImporte.Text);
            txtTotal.Text = Convert.ToString(precioUnit);
            total = precioUnit - descuento;
            IGV = total * 18 / 100;
            txtIGV.Text = Convert.ToString(IGV);
            SutTotal = total - IGV;
            TxtSubT.Text = Convert.ToString(SutTotal);
        }

        private void dgConsultaCliente_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void fnMuestraBoleta()
        {

            lstDventa.Add(new DetalleVenta
            {
                PrecioUni = precioUnit,
                Importe = total,
                Descuento = descuento,
                Descripcion = CambioTitularidad,
            });

            lstdocumentoV.Add(new DocumentoVenta
            {
                nSubtotal = SutTotal,
                nIGV = IGV,
                dFechaAct = Variables.gdFechaSis,
                nNroIGV = 18,
                dFechaRegistro = Variables.gdFechaSis,
                dFechaVenta = Convert.ToDateTime(dtFechaTitulacion.Value),
                idUsuario = Variables.gnCodUser,
                cCliente = lstClientes[0].cNombre + " " + lstClientes[0].cApePat + " " + lstClientes[0].cApePat,
                idCliente = lstClientes[0].idCliente,
                cDocumento = lstClientes[0].cDocumento,
                cTipoDoc = lstClientes[0].cTipoDoc,
                cDireccion = lstClientes[0].cDireccion,
                cVehiculos = lstvehiculo[0].vPlaca


            });
            Consultas.frmVPVenta frmVenta = new Consultas.frmVPVenta();
            frmVenta.Inicio(lstdocumentoV, lstDventa, -1);
        }
        private void btnBoleta_Click(object sender, EventArgs e)
        {
        }
       
        private void btnBoleta_CheckedChanged(object sender, EventArgs e)
        {
            fnMuestraBoleta();
        }

        private void dgConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lnTipoCon = 1;

            fnListarDatosCliente(lnTipoCon, e);
        }

        private void dgConsultaCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            lnTipoCon = 3;

            fnListarDatosClienteNuevo(lnTipoCon, e);
        }

        private Titularidad CargarTitularidad()
        {
            ClsTitularidad = new Titularidad
            {
                listaClientes = lstClientes,
                listaVehiculo = lstvehiculo,
                listaModeloV = lstModelo,
                listaMarcaM = lstMarca,
                listaDetalleV = lstDventa,
                listaDocVenta = lstdocumentoV,

                FechaTitularidad = Convert.ToDateTime(dtFechaTitulacion.Value),
                FechaRegistroT = Variables.gdFechaSis,
                idCliente = idCliente,
                idModelo = idModelo,

            };
            return ClsTitularidad;

        }
        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            Boolean Guardado;
            String lcResultado = "";
            txtClienteNuevo_TextChanged(sender, e);
            Titularidad clsTitu = new Titularidad();
            if (estCNuevo == true && estDireccionN == true && estDNuevo == true && estTelNuevo == true && estDNuevo == true)
            {
                clsTitu = CargarTitularidad();
                Guardado = fnGurdarNuevoCliente(clsTitu, 1);

                if (Guardado == true)
                {
                    MessageBox.Show("Correcto para guaradar", "PERFECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("No se pudo guaradar su cambio de Titularidad!!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }




            }
            else
            {
                MessageBox.Show("Aun faltan algunos datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }

        private void txtDireccionNuevo_TextChanged(object sender, EventArgs e)
        {

            var resultado = FunValidaciones.fnValidarTexboxs(txtDireccionNuevo, lblDireccionN, pbDireccionN ,true, true, true, 3, 90, 90, 90, "Completa la direccion");
            estDireccionN = resultado.Item1;
            msjDireccionN= resultado.Item2;
        }

        private void txtBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            lnTipoCon = 2;

            if (e.KeyChar == (Char)Keys.Enter)
            {
                fnBuscarDatosClienteNuevo(lnTipoCon);
            }

        }

        private void txtTelefonoNuevo_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtTelefonoNuevo, lblTelNuevo, pbTelNuevo, true, true, true, 3, 20, 20, 20, "Complete el Nunero de telefono");
            estTelNuevo = resultado.Item1;
            msjTelNuevo = resultado.Item2;
        }

        private void dgConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDniNuevo_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtDniNuevo, lblDniNuevo, pbDniNuevo, true, true, true, 3, 20, 20, 20, "Complete el Nunero de DNI");
            estDNuevo = resultado.Item1;
            msjDNuevo = resultado.Item2;
        }

        private void dgConsulta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void txtClienteNuevo_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtClienteNuevo, lblClienteNuevo, pbClienteNuevo, true, true, true, 3, 50, 50, 50, "Complete los Nombres y Apellidos del Cliente");
            estCNuevo = resultado.Item1;
            msjCNuevo = resultado.Item2;

        }




        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            var resultado = FunValidaciones.fnValidarTexboxs(txtCliente, lblCliente, pbcliente, true, true, true, 3, 50, 50, 50, "Complete el Nombre del cliente");
            estCliente = resultado.Item1;
            msjCliente = resultado.Item2;

        }
        private Boolean fnBuscarDatosClienteNuevo(Int32 cond)
        {
            BLTitularidad datCliente = new BLTitularidad();
            clsUtil objUtil = new clsUtil();
            DataTable datResultado = new DataTable();
            try
            {
                String BuscarDato = Convert.ToString(txtBuscarCliente.Text);
                datResultado=datCliente.BlBuscarTitularidad(cond, BuscarDato);
                dgConsultaCliente.Visible = true;
                dgConsultaCliente.Rows.Clear();

                foreach (DataRow drMenu in datResultado.Rows)
                {
                    dgConsultaCliente.Rows.Add(
                        Convert.ToString(drMenu["idcliente"]),
                       Convert.ToString(drMenu["cNombre"])
                       
                       );
                }
                return true;
            }
            catch (Exception Error)

            {
                return false;
            }
            finally
            {

            }

        }
     

        private Boolean fnBuscarDatosCliente(Int32 cond)
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
                       Convert.ToString(drMenu["vPlaca"])
                       );


                }
                return true;

            }
            catch (Exception Error)

            {
                return false;
            }
            finally
            {

            }
        }
        

        

    }
            
      

}
