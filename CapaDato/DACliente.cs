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

        public DataTable daBuscarCliente(String nroDocumento, String nombreCliente, Int32 idTipoPersona, Int32 idTipoDocumento, String estCliente, Int32 numPagina, Int32 tipoCon)
        {

            SqlParameter[] pa = new SqlParameter[7];
            DataTable dtCliente;
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peNroDocumento", SqlDbType.NVarChar, 15) { Value = nroDocumento };
                pa[1] = new SqlParameter("@peNombreCliente", SqlDbType.NVarChar, 45) { Value = nombreCliente };
                pa[2] = new SqlParameter("@peIdTipoPersona", SqlDbType.Int) { Value = idTipoPersona };
                pa[3] = new SqlParameter("@peIdTipoDocumento", SqlDbType.Int) { Value = idTipoDocumento };
                pa[4] = new SqlParameter("@peEstadoCliente", SqlDbType.NVarChar,1) { Value = estCliente };
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

                if(dtUsuario.Rows.Count > 0)
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

        public Cliente daListarCliente(Int32 idCliente,Int32 pnTipoCon)
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
                    lstCliente.ubigeo = Convert.ToString(drMenu["cDireccion"]+" "+drMenu["cNomDist"]+" "+ drMenu["cNomProv"] +" "+ drMenu["cNomDep"]);
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
            SqlParameter[] pa = new SqlParameter[22];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

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
                pa[15] = new SqlParameter("@pecContactoNom1", SqlDbType.NVarChar,150);
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
