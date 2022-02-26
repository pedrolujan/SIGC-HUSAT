using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaConexion;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using CapaUtil;

namespace CapaDato
{
    public class DAProveedor
    {

        public DAProveedor() { }

        private clsUtil objUtil = null;

        public List<Proveedor> daDevolverProveedor(String pcBuscar,Int16 pnTipoCon)
        {


            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Proveedor> lstProveedor = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar,50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarProveedor", pa);

                lstProveedor = new List<Proveedor>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstProveedor.Add(new Proveedor(Convert.ToInt32(drMenu["idProveedor"]), Convert.ToString(drMenu["cNomProveedor"]),
                           Convert.ToString(drMenu["cDocumento"]), Convert.ToString(drMenu["cDireccion"])));
                }

                return lstProveedor;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAProveedor.cs", "daDevolverProveedor", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstProveedor = null;
            }

        }

        public List<Proveedor> daListarProveedor(Int32 idProve)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Proveedor> lstProveedor = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidProveedor", SqlDbType.Int);
                pa[0].Value = idProve;



                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarProveedor", pa);

                lstProveedor = new List<Proveedor>();
                                
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstProveedor.Add(new Proveedor(
                        Convert.ToInt32(drMenu["idProveedor"]), 
                        Convert.ToString(drMenu["cNomProveedor"]),
                        Convert.ToString(drMenu["cDocumento"]), 
                        Convert.ToString(drMenu["cDireccion"])));
                }

                return lstProveedor;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAProveedor.cs", "daDevolverProveedor", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstProveedor = null;
            }

        }

        public String daGrabarProveedor(Proveedor objProveedor, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[13];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidProveedor", SqlDbType.Int);
                pa[0].Value = objProveedor.idProveedor;
                pa[1] = new SqlParameter("@pecNomProveedor", SqlDbType.NVarChar, 200);
                pa[1].Value = objProveedor.cNomProveedor;
                pa[2] = new SqlParameter("@pecDocumento", SqlDbType.NVarChar,15);
                pa[2].Value = objProveedor.cDocumento;
                pa[3] = new SqlParameter("@pecDireccion", SqlDbType.VarChar,100);
                pa[3].Value = objProveedor.cDireccion;
                pa[4] = new SqlParameter("@pecReferencia", SqlDbType.VarChar,100);
                pa[4].Value = objProveedor.cReferencia;
                pa[5] = new SqlParameter("@pecTelFijo", SqlDbType.NVarChar,15);
                pa[5].Value = objProveedor.cTelFijo;
                pa[6] = new SqlParameter("@pecTelCelular", SqlDbType.NVarChar,15);
                pa[6].Value = objProveedor.cTelCelular;
                pa[7] = new SqlParameter("@pedFechaCreacion", SqlDbType.DateTime);
                pa[7].Value = objProveedor.dFechaCreacion;
                pa[8] = new SqlParameter("@pebestado", SqlDbType.Bit);
                pa[8].Value = objProveedor.bEstado;
                pa[9] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[9].Value = objProveedor.dFechaReg;
                pa[10] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[10].Value = objProveedor.idUsuario;
                pa[11] = new SqlParameter("@peidZona", SqlDbType.Int);
                pa[11].Value = objProveedor.idZona;
                pa[12] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[12].Value = pnTipoCon;


                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarProveedor", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAProveedor.cs", "daGrabarProveedor", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
            }

        }

        public List<Proveedor> daListarProveedores(Boolean pbEstado,Boolean buscar,String codTipoOrden)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Proveedor> lstCliente = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[0].Value = pbEstado;

                pa[1] = new SqlParameter("@peCodTipoOrden", SqlDbType.NVarChar,10);
                pa[1].Value = codTipoOrden;



                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarProveedores", pa);

                lstCliente = new List<Proveedor>();
                lstCliente.Add(new Proveedor(
                    Convert.ToInt32("0"),
                    Convert.ToString(buscar ? "TODOS" : "Selecc. Proveedor")));
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstCliente.Add(new Proveedor(
                        Convert.ToInt32(drMenu["idProveedor"]),
                        Convert.ToString(drMenu["cNomProveedor"])));
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

    }
}
