using CapaConexion;
using CapaEntidad;
using CapaUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class DAAccesorios
    {
        private clsUtil objUtil = null;
        public List<Accesorios> daDevolverAccesorio(Int32 idAccesorio)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;
            List<Accesorios> lstAccesorio = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidAccesorio", SqlDbType.Int);
                pa[0].Value = idAccesorio;


                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspListarAccesorio", pa);

                lstAccesorio = new List<Accesorios>();
                foreach (DataRow drMenu in dtAccesorio.Rows)
                {
                    lstAccesorio.Add(new Accesorios(
                        Convert.ToInt32(drMenu["idAccesorio"]),
                        Convert.ToString(drMenu["cNombre"]),
                        Convert.ToDouble(drMenu["cPrecio"]),
                        Convert.ToString(drMenu["cDescripcion"]),
                        Convert.ToBoolean(drMenu["bEstado"])
                        
                        ));
                }

                return lstAccesorio;

            }
            catch (Exception ex)
            {
                lstAccesorio = null;
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daDevolverAccesorio", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstAccesorio = null;
            }

        }

        public DataTable daBuscarAccesorioDataTable(String pcBuscar, String estado,Int32 numPagina,Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;
            
            objUtil = new clsUtil();



            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.NVarChar,1);
                pa[1].Value = estado;
                pa[2] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[2].Value = numPagina;
                pa[3] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[3].Value = tipoCon;
                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspBuscarAccesorio", pa);

                return dtAccesorio;
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
        public Accesorios daListarAccesoriosDatatable(Int32 idCliente,Int32 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Accesorios lstAcces = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peidAccesorio", SqlDbType.Int);
                pa[0].Value = idCliente;
                pa[1] = new SqlParameter("@peTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarAccesorio", pa);

                lstAcces = new Accesorios();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstAcces.idAccesorio = Convert.ToInt32(drMenu["idAccesorio"]);
                    lstAcces.cAccesorio = Convert.ToString(drMenu["cNombre"]);
                    lstAcces.cPrecio = Convert.ToDouble(drMenu["cPrecio"]);
                    lstAcces.cStock = Convert.ToInt32(drMenu["cStock"]);
                    lstAcces.cDescripcion = Convert.ToString(drMenu["cDescripcion"]);
                    lstAcces.bEstado = Convert.ToBoolean(drMenu["bEstado"]);
                }

                return lstAcces;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daListarEquipo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstAcces = null;
            }
        }
        public Int16 daBuscarNombreAccesorio(String pcBuscar, Int16 pnTipoCon)
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
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarNombreAccesorio", pa);

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

        public List<Accesorios> daDevolverAccesorio(String idAccesorio)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;
            List<Accesorios> lstAccesorio = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidAccesorio", SqlDbType.NVarChar,8);
                pa[0].Value = idAccesorio;


                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspListarAccesorio", pa);

                lstAccesorio = new List<Accesorios>();
                foreach (DataRow drMenu in dtAccesorio.Rows)
                {
                    lstAccesorio.Add(new Accesorios(
                        Convert.ToInt32(drMenu["idAccesorio"]),
                        Convert.ToString(drMenu["nombreAccesorio"]),
                        Convert.ToDouble(drMenu["cPrecio"]),
                        Convert.ToInt32(drMenu["cStock"]),
                        Convert.ToBoolean(drMenu["bEstado"]))); 
                }

                return lstAccesorio;

            }
            catch (Exception ex)
            {
                lstAccesorio = null;
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daDevolverAccesorio", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstAccesorio = null;
            }

        }

        public List<Accesorios> daDevolverEquipoGps(Int32 idAccesorio)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;
            List<Accesorios> lstAccesorio = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidTablaCod", SqlDbType.Int);
                pa[0].Value = idAccesorio;


                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspListarTablaC", pa);

                lstAccesorio = new List<Accesorios>();
                foreach (DataRow drMenu in dtAccesorio.Rows)
                {
                    lstAccesorio.Add(new Accesorios(Convert.ToString(drMenu["cCodTab"]),
                        Convert.ToString(drMenu["cNomTab"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstAccesorio;

            }
            catch (Exception ex)
            {
                lstAccesorio = null;
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daDevolverAccesorio", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstAccesorio = null;
            }

        }

        public String daGrabarAccesorio(Accesorios objAccesorio, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[9];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidAccesorio", SqlDbType.Int);
                pa[0].Value = objAccesorio.idAccesorio;
                pa[1] = new SqlParameter("@pecNomAccesorio", SqlDbType.NVarChar, 50);
                pa[1].Value = objAccesorio.cAccesorio;
                pa[2] = new SqlParameter("@pePrecio", SqlDbType.Money);
                pa[2].Value = objAccesorio.cPrecio;
                pa[3] = new SqlParameter("@peDescripcion", SqlDbType.NVarChar, 250);
                pa[3].Value = objAccesorio.cDescripcion;
                pa[4] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[4].Value = objAccesorio.bEstado;
                pa[5] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[5].Value = objAccesorio.dFechaRegistro;
                pa[6] = new SqlParameter("@peIdUsuario", SqlDbType.Int);
                pa[6].Value = objAccesorio.idUsuario;
                pa[7] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[7].Value = pnTipoCon;
                pa[8] = new SqlParameter("@peStock", SqlDbType.Int);
                pa[8].Value = objAccesorio.cStock;


                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarAccesorio", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daGrabarAccesorio", ex.Message);
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

        public List<Accesorios> daBuscarAccesorio(String pcBuscar, Int16 piTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;
            List<Accesorios> lstAccesorio = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 20);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = piTipoCon;

                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspListarAccesorio", pa);

                lstAccesorio = new List<Accesorios>();
                foreach (DataRow drMenu in dtAccesorio.Rows)
                {
                    lstAccesorio.Add(new Accesorios(
                        Convert.ToInt32(drMenu["idAccesorio"]),
                        Convert.ToString(drMenu["cNombre"])
                       ));
                }

                return lstAccesorio;

            }
            catch (Exception ex)
            {
                lstAccesorio = null;
                objUtil.gsLogAplicativo("DAAccesorio.cs", "daBuscarAccesorio", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstAccesorio = null;
            }
        }
     
        public List<Accesorios> daListarAccesorio(Int32 idAccesorio,Int32 peTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;
            List<Accesorios> lstVehiculo = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidAccesorio", SqlDbType.Int);
                pa[0].Value = idAccesorio;
                pa[1] = new SqlParameter("@peTipoCon", SqlDbType.Int);
                pa[1].Value = peTipoCon;

                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspListarAccesorio", pa);

                lstVehiculo = new List<Accesorios>();
                foreach (DataRow drMenu in dtAccesorio.Rows)
                {
                    lstVehiculo.Add(new Accesorios(
                        Convert.ToInt32(drMenu["idAccesorio"]),
                        Convert.ToString(drMenu["cNombre"]),
                        Convert.ToDouble(drMenu["cPrecio"]),
                        Convert.ToString(drMenu["cDescripcion"]),
                        Convert.ToBoolean(drMenu["bEstado"])
                        )) ;
                }

                return lstVehiculo;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAVehiculo.cs", "daListarMarca", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstVehiculo = null;
            }

        }

        public List<Accesorios> daListarAccesorios(Boolean pbEstado)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;
            List<Accesorios> lstAccesorio = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[0].Value = pbEstado;
                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspListarAccesorios", pa);

                lstAccesorio = new List<Accesorios>();
                foreach (DataRow drMenu in dtAccesorio.Rows)
                {
                    lstAccesorio.Add(new Accesorios(Convert.ToInt32(drMenu["idAccesorio"]),
                        Convert.ToString(drMenu["nombreAccesorio"])));
                }

                return lstAccesorio;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAttRVehiculo.cs", "daListarMarcas", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstAccesorio = null;
            }

        }
        public DataTable daBuscarAccesorioHistorial(Int32 idHistorial)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();



            try
            {
                pa[0] = new SqlParameter("@idAccesorio", SqlDbType.Int);
                pa[0].Value = idHistorial;
               
                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspBuscarHistorialAccesorio", pa);

                return dtAccesorio;
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
    }
}
