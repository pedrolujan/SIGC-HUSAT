using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaUtil;
using CapaConexion;
using System.Data.SqlClient;
using System.Data;


namespace CapaDato
{
    public class DACliente
    {
        public DACliente() { }

        private clsUtil objUtil = null;

        public Boolean dtGuardarServicios(Int32 idServ, String nomServ, DateTime fechaServ, Double precioServ, String descServ, Boolean estadoServ, Int32 idusuario, Int32 monedaServ,/*Int32 idValida,*/ Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[9];

            clsConexion objCnx = null;
            objUtil = new clsUtil();
           
            try
            {
                pa[0] = new SqlParameter("@peIdServicios", SqlDbType.Int) { Value = idServ };
                pa[1] = new SqlParameter("@peNombreServicios", SqlDbType.VarChar) { Value = nomServ };
                pa[2] = new SqlParameter("@peFechaServicios", SqlDbType.DateTime) { Value = fechaServ };
                pa[3] = new SqlParameter("@pePrecioServicios", SqlDbType.Money) { Value = precioServ };
                pa[4] = new SqlParameter("@peDescripcionServicios", SqlDbType.VarChar) { Value = descServ };
                pa[5] = new SqlParameter("@peEstadoServ", SqlDbType.Int) { Value = estadoServ };
                pa[6] = new SqlParameter("@peUsuarioServ", SqlDbType.Int) { Value = idusuario };
                pa[7] = new SqlParameter("peIdMonedaServ", SqlDbType.Int) { Value = monedaServ };          
                pa[8] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = tipoCon };


                objCnx = new clsConexion("");

                
                objCnx.EjecutarProcedimiento("uspGuardarServicios", pa);
                return true;
            }
            catch (Exception ex)
            {

                objUtil.gsLogAplicativo("DACliente.cs", "dtGuardarServicios", ex.Message);
                throw new Exception(ex.Message);

            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;

            }
        }
        public DataTable daBuscarBajaServicios(Int32 numPagina, String nplaca, Int32 estadoServ, Int32 tipoCon)
        {

            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtCliente;
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peNumPagina", SqlDbType.Int) { Value = numPagina };

                pa[1] = new SqlParameter("@peNombreServicios", SqlDbType.VarChar, 50) { Value = nplaca };
                pa[2] = new SqlParameter("@peTipoCon", SqlDbType.Real) { Value = tipoCon };
                pa[3] = new SqlParameter("@peEstado", SqlDbType.Int) { Value = estadoServ };

                objCnx = new clsConexion("");
                dtCliente = objCnx.EjecutarProcedimientoDT("uspBuscarServicios", pa);

                return dtCliente;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarServicios", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtCliente = null;
            }

        }

        public DataTable daBuscarServicios(Int32 numPagina, String snombre, Int32 estadoServ, Int32 tipoCon)
        {

            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtCliente;
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peNumPagina", SqlDbType.Int) { Value = numPagina };

                pa[1] = new SqlParameter("@peNombreServicios", SqlDbType.VarChar, 50) { Value = snombre };
                pa[2] = new SqlParameter("@peTipoCon", SqlDbType.Real) { Value = tipoCon };
                pa[3] = new SqlParameter("@peEstado", SqlDbType.Int) { Value = estadoServ };

                objCnx = new clsConexion("");
                dtCliente = objCnx.EjecutarProcedimientoDT("uspBuscarServicios", pa);

                return dtCliente;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarServicios", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtCliente = null;
            }

        }

        public DataTable daBuscarCliente(String bnombreCliente, Int32 estCliente, Int32 numPagina, Int32 tipoCon)
        {

            SqlParameter[] pa = new SqlParameter[7];
            DataTable dtCliente;
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peNroDocumento", SqlDbType.NVarChar, 15) { Value = "" };
                pa[1] = new SqlParameter("@peNombreCliente", SqlDbType.NVarChar, 45) { Value = bnombreCliente };
                pa[2] = new SqlParameter("@peIdTipoPersona", SqlDbType.Int) { Value = 0 };
                pa[3] = new SqlParameter("@peIdTipoDocumento", SqlDbType.Int) { Value = 0 };
                pa[4] = new SqlParameter("@peEstadoCliente", SqlDbType.Int) { Value = estCliente };
                pa[5] = new SqlParameter("@peNumPagina", SqlDbType.Int) { Value = numPagina };
                pa[6] = new SqlParameter("@peTipoCon", SqlDbType.Real) { Value = tipoCon };

                objCnx = new clsConexion("");
                dtCliente = objCnx.EjecutarProcedimientoDT("uspBuscarCliente", pa);

                return dtCliente;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtCliente = null;
            }

        }

        public Int16 daBuscarNroDocumento(String pcBuscar, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarNroDocumento", pa);

                Int16 numFilas;

                if (dtUsuario.Rows.Count > 0)
                {
                    numFilas = 1;
                }
                else
                {
                    numFilas = 0;
                }

                return numFilas;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;

            }

        }

        public Cliente daListarCliente(Int32 idCliente, Int32 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario;
            clsConexion objCnx = null;
            Cliente lstCliente;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidCliente", SqlDbType.Int) { Value = idCliente };
                pa[1] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = pnTipoCon };

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarCliente", pa);

                lstCliente = new Cliente();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstCliente.idCliente = Convert.ToInt32(drMenu["idCliente"]);
                    lstCliente.cApePat = Convert.ToString(drMenu["cApePat"]);
                    lstCliente.cApeMat = Convert.ToString(drMenu["cApeMat"]);
                    lstCliente.cNombre = Convert.ToString(drMenu["cNombre"]);
                    lstCliente.cDireccion = Convert.ToString(drMenu["cDireccion"]);
                    lstCliente.dFecNac = Convert.ToDateTime(drMenu["dFecNac"]);
                    lstCliente.cTipPers = Convert.ToInt32(drMenu["cTipPers"]);
                    lstCliente.cTiDo = Convert.ToInt32(drMenu["cTiDo"]);
                    lstCliente.cTelFijo = Convert.ToString(drMenu["cTelFijo"]);
                    lstCliente.cTelCelular = Convert.ToString(drMenu["cTelCelular"]);
                    lstCliente.bEstado = Convert.ToBoolean(drMenu["bestado"]);
                    lstCliente.idDep = Convert.ToInt32(drMenu["idDepa"]);
                    lstCliente.idProv = Convert.ToInt32(drMenu["idProv"]);
                    lstCliente.idDist = Convert.ToInt32(drMenu["idDist"]);
                    lstCliente.cDocumento = Convert.ToString(drMenu["cDocumento"]);
                    lstCliente.cContactoNom1 = Convert.ToString(drMenu["cContactoNom1"]);
                    lstCliente.cContactoNom2 = Convert.ToString(drMenu["cContactoNom2"]);
                    lstCliente.cContactoCel1 = Convert.ToString(drMenu["cContactoCel1"]);
                    lstCliente.cContactoCel2 = Convert.ToString(drMenu["cContactoCel2"]);
                    lstCliente.cEmpresa = Convert.ToString(drMenu["cEmpresa"]);
                    lstCliente.cCorreo = Convert.ToString(drMenu["cCorreo"]);
                    lstCliente.ubigeo = Convert.ToString(drMenu["cDireccion"] + " " + drMenu["cNomDist"] + " " + drMenu["cNomProv"] + " " + drMenu["cNomDep"]);
                    //MOD REPRESENTANTE
                    lstCliente.idRepreLegal = Convert.ToInt32(drMenu["idRepreLegal"]);
                    if (lstCliente.idRepreLegal != 0)
                    {
                        lstCliente.idClienteRepre = Convert.ToInt32(drMenu["idCliente1"]);
                        lstCliente.cTiDoRepre = Convert.ToInt32(drMenu["cTiDo1"]);
                        lstCliente.cDocumentoRepre = Convert.ToString(drMenu["cDocumento1"]);
                        lstCliente.NombreRepreLegal = Convert.ToString(drMenu["Representante"]);
                        lstCliente.cCorreoRepre = Convert.ToString(drMenu["cCorreo1"]);
                        lstCliente.cTelCelularRepre = Convert.ToString(drMenu["cTelCelular1"]);
                        lstCliente.Cargo = Convert.ToString(drMenu["cargo"]);
                        lstCliente.cDireccionRepre = Convert.ToString(drMenu["cDireccion1"]);

                    }

                }

                return lstCliente;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daListarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstCliente = null;
            }

        }
        public List<Cliente> daDevolverCliente(Int32 idClienteV)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtCliente = new DataTable();
            clsConexion objCnx = null;
            List<Cliente> lstCliente = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidCliente", SqlDbType.Int);
                pa[0].Value = idClienteV;


                objCnx = new clsConexion("");
                dtCliente = objCnx.EjecutarProcedimientoDT("uspListarClienteV", pa);

                lstCliente = new List<Cliente>();
                foreach (DataRow drMenu in dtCliente.Rows)
                {
                    lstCliente.Add(new Cliente(Convert.ToInt32(drMenu["idCliente"]),
                        Convert.ToString(drMenu["cApePat"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstCliente;

            }
            catch (Exception ex)
            {
                lstCliente = null;
                objUtil.gsLogAplicativo("DACliente.cs", "daDevolverCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstCliente = null;
            }

        }
        public String daGrabarCliente(Cliente objCliente, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[34];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            string[] NombreRepre = objCliente.NombreRepreLegal.ToString().Split(' ');
            objCliente.NombreRepreLegal=NombreRepre[0] + " " + NombreRepre[1];
            objCliente.NombreRepreLegal = NombreRepre[2];
            objCliente.NombreRepreLegal = NombreRepre[3];


            try
            {
                pa[0] = new SqlParameter("@peidCliente", SqlDbType.Int);
                pa[0].Value = objCliente.idCliente;

                pa[1] = new SqlParameter("@pecApePat", SqlDbType.NVarChar, 50);
                pa[1].Value = objCliente.cApePat;

                pa[2] = new SqlParameter("@pecApeMat", SqlDbType.NVarChar, 50);
                pa[2].Value = objCliente.cApeMat;

                pa[3] = new SqlParameter("@pecNombre", SqlDbType.NVarChar, 150);
                pa[3].Value = objCliente.cNombre;
                pa[4] = new SqlParameter("@pecDocumento", SqlDbType.NVarChar, 15);
                pa[4].Value = objCliente.cDocumento;
                pa[5] = new SqlParameter("@pecDireccion", SqlDbType.VarChar, 100);
                pa[5].Value = objCliente.cDireccion;
                pa[6] = new SqlParameter("@pedFecNac", SqlDbType.DateTime);
                pa[6].Value = objCliente.dFecNac;
                pa[7] = new SqlParameter("@pecTipPers", SqlDbType.NVarChar, 8);
                pa[7].Value = objCliente.cTipPers;
                pa[8] = new SqlParameter("@pecTiDo", SqlDbType.NVarChar, 8);
                pa[8].Value = objCliente.cTiDo;
                pa[9] = new SqlParameter("@pecTelFijo", SqlDbType.NVarChar, 20);
                pa[9].Value = objCliente.cTelFijo;
                pa[10] = new SqlParameter("@pecTelCelular", SqlDbType.NVarChar, 20);
                pa[10].Value = objCliente.cTelCelular;
                pa[11] = new SqlParameter("@pebestado", SqlDbType.Bit);
                pa[11].Value = objCliente.bEstado;
                pa[12] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[12].Value = objCliente.dFechaRegistro;
                pa[13] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[13].Value = objCliente.idUsuario;
                pa[14] = new SqlParameter("@peidZona", SqlDbType.Int);
                pa[14].Value = objCliente.idZona;
                pa[15] = new SqlParameter("@pecContactoNom1", SqlDbType.NVarChar, 150);
                pa[15].Value = objCliente.cContactoNom1;
                pa[16] = new SqlParameter("@pecContactoNom2", SqlDbType.NVarChar, 150);
                pa[16].Value = objCliente.cContactoNom2;
                pa[17] = new SqlParameter("@pecContactoCel1", SqlDbType.NVarChar, 20);
                pa[17].Value = objCliente.cContactoCel1;
                pa[18] = new SqlParameter("@pecContactoCel2", SqlDbType.NVarChar, 20);
                pa[18].Value = objCliente.cContactoCel2;
                pa[19] = new SqlParameter("@pecEmpresa", SqlDbType.NVarChar, 150);
                pa[19].Value = objCliente.cEmpresa;
                pa[20] = new SqlParameter("@pecCorreo", SqlDbType.NVarChar, 150);
                pa[20].Value = objCliente.cCorreo;
                pa[21] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[21].Value = pnTipoCon;
                pa[22] = new SqlParameter("@idRepreLegal", SqlDbType.Int);
                pa[22].Value = objCliente.idRepreLegal;
                pa[23] = new SqlParameter("@tipoDocRepre", SqlDbType.Int);
                pa[23].Value = objCliente.cTiDoRepre;
                pa[24] = new SqlParameter("@DocRepre", SqlDbType.VarChar, 12);
                pa[24].Value = objCliente.cDocumentoRepre;

                pa[25] = new SqlParameter("@ApeMatRepre", SqlDbType.VarChar, 150);
                pa[25].Value = NombreRepre[2];
                pa[26] = new SqlParameter("@NomRepre", SqlDbType.VarChar, 150);
                pa[26].Value = NombreRepre[0] + " " + NombreRepre[1];
                
                pa[27] = new SqlParameter("@ApePatRepre", SqlDbType.VarChar, 150);
                pa[27].Value = NombreRepre[3];
                


                pa[28] = new SqlParameter("@CorreoRepre", SqlDbType.VarChar, 150);
                pa[28].Value = objCliente.cCorreoRepre;
                pa[29] = new SqlParameter("@telRepre", SqlDbType.VarChar, 20);
                pa[29].Value = objCliente.cTelCelularRepre;
                pa[30] = new SqlParameter("@Cargo", SqlDbType.VarChar, 50);
                pa[30].Value = objCliente.Cargo;
                pa[31] = new SqlParameter("@DireccionRepre", SqlDbType.VarChar, 150);
                pa[31].Value = objCliente.cDireccionRepre;
                pa[32] = new SqlParameter("@Estado", SqlDbType.Bit);
                pa[32].Value = objCliente.Estado;
                pa[33] = new SqlParameter("@NomCargo", SqlDbType.NVarChar, 100);
                pa[33].Value = objCliente.NomCargo;
                //pa[26] = new SqlParameter("@cCodTab", SqlDbType.NVarChar, 10);
                //pa[26].Value = objCliente.cCodTab;


                

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarCliente", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daGrabarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
                objCliente = null;

            }

        }

        public List<Cliente> daListarClientes(Boolean pbEstado)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Cliente> lstCliente = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[0].Value = pbEstado;



                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarClientesLLamados", pa);

                lstCliente = new List<Cliente>();
                lstCliente.Add(new Cliente(
                   Convert.ToInt32(0),
                       Convert.ToString("Seleccione Cliente")));

                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstCliente.Add(new Cliente(Convert.ToInt32(drMenu["idCliente"]),
                        Convert.ToString(drMenu["cCliente"])));
                }

                return lstCliente;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daListarClientes", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstCliente = null;
            }

        }

        public List<TipoCliente> daDevolverTipoCliente(Int32 idClienteV)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtCliente = new DataTable();
            clsConexion objCnx = null;
            List<TipoCliente> lstCliente = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidCliente", SqlDbType.Int);
                pa[0].Value = idClienteV;


                objCnx = new clsConexion("");
                dtCliente = objCnx.EjecutarProcedimientoDT("uspListarClienteV", pa);

                lstCliente = new List<TipoCliente>();
                foreach (DataRow drMenu in dtCliente.Rows)
                {
                    lstCliente.Add(new TipoCliente(Convert.ToInt32(drMenu["idCliente"]),
                        Convert.ToString(drMenu["cApePat"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstCliente;

            }
            catch (Exception ex)
            {
                lstCliente = null;
                objUtil.gsLogAplicativo("DACliente.cs", "daDevolverCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstCliente = null;
            }
        }
    }
}
