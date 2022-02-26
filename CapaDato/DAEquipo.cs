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
    public class DAEquipo
    {

        public DAEquipo() { }

        private clsUtil objUtil = null;

        public List<Equipo> daBuscarEquipo(String pcBuscar, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<Equipo> lstEquipo = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarEquipo", pa);

                lstEquipo = new List<Equipo>();
                foreach (DataRow drMenu in dtEquipo.Rows)
                {
                    lstEquipo.Add(new Equipo(
                            Convert.ToInt32(drMenu["ID"]),
                            Convert.ToInt32(drMenu["nImeiEquipo"]),
                           Convert.ToString(drMenu["nSerieEquipo"]),
                           Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstEquipo;

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
                lstEquipo = null;
            }

        }


        public Boolean daValidarEquipoAccesorio(Int32 idEquipoAccesorio, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Plan lstPlan = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peIdPlanAccesorio", SqlDbType.NVarChar, 20);
                pa[0].Value = idEquipoAccesorio;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt, 1);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspValidarEstadoAccesorio", pa);

                lstPlan = new Plan();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPlan.estado = Convert.ToBoolean(drMenu["bEstado"]);

                }

                return lstPlan.estado;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPlan.cs", "daListarPlan", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstPlan = null;
            }
        }
        public DataTable daBuscarEquipoDatatable(String pcBuscar, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<Equipo> lstEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;
                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarEquipo", pa);

                //lstEquipo = new List<Equipo>();
                //foreach (DataRow drMenu in dtEquipo.Rows)
                //{
                //    lstEquipo.Add(new Equipo(
                //            Convert.ToInt32(drMenu["idEquipo"]),
                //            Convert.ToInt32(drMenu["nImeiEquipo"]),
                //           Convert.ToString(drMenu["nSerieEquipo"]),
                //           Convert.ToBoolean(drMenu["bEstado"])));
                //}

                return dtEquipo;

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
                lstEquipo = null;
            }

        }
        public Equipo daListarEquipo(Int32 idCliente)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Equipo lstEquipo = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidEquipo", SqlDbType.Int);
                pa[0].Value = idCliente;



                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarEquipo", pa);

                lstEquipo = new Equipo();
                //foreach (DataRow drMenu in dtUsuario.Rows)
                //{
                //    lstEquipo.idEquipo(
                //           Convert.ToInt32(drMenu["idEquipo"]),
                //           Convert.ToInt32(drMenu["nImeiEquipo"]),
                //           Convert.ToString(drMenu["nSerieEquipo"]),
                //           Convert.ToInt32(drMenu["idCategoria"]),
                //           Convert.ToInt32(drMenu["idMarcaEquipo"]),
                //           Convert.ToInt32(drMenu["idModeloEquipo"]),
                //           Convert.ToInt32(drMenu["idOperadorEquipo"]),
                //           Convert.ToBoolean(drMenu["bEstado"])));
                //}

                return lstEquipo;

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
                lstEquipo = null;
            }

        }

        public List<Equipo> daDevolverEquipo(Int32 idEquipo)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<Equipo> lstEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidEquipo", SqlDbType.Int);
                pa[0].Value = idEquipo;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspListarEquipo", pa);

                lstEquipo = new List<Equipo>();
                foreach (DataRow drMenu in dtEquipo.Rows)
                {
                    lstEquipo.Add(new Equipo(Convert.ToInt32(drMenu["idEquipo"]),
                       Convert.ToInt32(drMenu["nImeiEquipo"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstEquipo;

            }
            catch (Exception ex)
            {
                lstEquipo = null;
                objUtil.gsLogAplicativo("DACliente.cs", "daDevolverCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstEquipo = null;
            }

        }

        public bool daGrabarEquipo(Equipo objEquipo, Int16 pnTipoCon, List<EquipoAccesorios> lstAccesorios)
        {
            SqlParameter[] pa = new SqlParameter[10];


            objUtil = new clsUtil();
            int intRowsAffected = 0;
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            string xmlData = clsUtil.Serialize(lstAccesorios);

            try
            {

                pa[0] = new SqlParameter("@peidEquipo", SqlDbType.Int);
                pa[0].Value = objEquipo.idEquipo;
                pa[1] = new SqlParameter("@peNombre", SqlDbType.NVarChar, 45);
                pa[1].Value = objEquipo.cNombre;
                pa[2] = new SqlParameter("@pePrecio", SqlDbType.Money);
                pa[2].Value = objEquipo.cPrecio;
                pa[3] = new SqlParameter("@peObservacion", SqlDbType.NVarChar, 200);
                pa[3].Value = objEquipo.cObservacion;
                pa[4] = new SqlParameter("@peIdUsuario", SqlDbType.Int);
                pa[4].Value = objEquipo.idUsuario;
                pa[5] = new SqlParameter("@pefechaRegistro", SqlDbType.DateTime);
                pa[5].Value = objEquipo.dFechaRegistro;
                pa[6] = new SqlParameter("@peEstado", SqlDbType.Bit, 1);
                pa[6].Value = objEquipo.bEstado;
                pa[7] = new SqlParameter("@peIdModelo", SqlDbType.Int);
                pa[7].Value = objEquipo.idModeloEquipo;
                pa[8] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[8].Value = pnTipoCon;
                pa[9] = new SqlParameter("@xmlData", SqlDbType.Xml);
                pa[9].Value = xmlData;



                objCnx = new clsConexion("");
                intRowsAffected = objCnx.EjecutarProcedimiento("uspGuardarEquipoUnico", pa);

                return true;

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
                objEquipo = null;
            }
        }

        public bool daGrabarAccesoriosNoAgregados(Int32 idEquipo, Int16 pnTipoCon, List<EquipoAccesorios> lstAccesorios)
        {
            SqlParameter[] pa = new SqlParameter[3];


            objUtil = new clsUtil();
            int intRowsAffected = 0;
            clsConexion objCnx = null;

            string xmlData = clsUtil.Serialize(lstAccesorios);

            try
            {

                pa[0] = new SqlParameter("@peIdEquipo", SqlDbType.Int);
                pa[0].Value = idEquipo;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;
                pa[2] = new SqlParameter("@xmlData", SqlDbType.Xml);
                pa[2].Value = xmlData;



                objCnx = new clsConexion("");
                intRowsAffected = objCnx.EjecutarProcedimiento("uspGuardarAcceriosNoAgregados", pa);

                return true;

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
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarClientes", pa);

                lstCliente = new List<Cliente>();
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

        public DataTable daBuscarEquipoDataTable(String pcBuscar, String estBusqueda, Int32 idCategoria,Int32 idMarca,Int32 idModelo,Int32 numPagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[7];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peEstadoBusqueda", SqlDbType.NVarChar,1);
                pa[1].Value = estBusqueda;
                pa[2] = new SqlParameter("@peidCategoria", SqlDbType.Int);
                pa[2].Value = idCategoria;
                pa[3] = new SqlParameter("@peidMarca", SqlDbType.Int);
                pa[3].Value = idMarca;
                pa[4] = new SqlParameter("@peidModelo", SqlDbType.Int);
                pa[4].Value = idModelo;
                pa[5] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[5].Value = numPagina;
                pa[6] = new SqlParameter("@tipoCon", SqlDbType.Real);
                pa[6].Value = tipoCon;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarEquipoUnico", pa);

                return dtEquipo;



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

        public Equipo daListarEquipoDatatable(Int32 codPlan)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Equipo lstEquipo = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peidEquipo", SqlDbType.Int);
                pa[0].Value = codPlan;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarEquipoUnico", pa);

                lstEquipo = new Equipo();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstEquipo.idEquipo = Convert.ToInt32(drMenu["idEquipo"]);
                    lstEquipo.idCategoria = Convert.ToInt32(drMenu["idCategoria"]);
                    lstEquipo.idMarcaEquipo = Convert.ToInt32(drMenu["idMarca"]);
                    lstEquipo.idModeloEquipo = Convert.ToInt32(drMenu["idModeloE"]);
                    lstEquipo.cNombre = Convert.ToString(drMenu["nombreEquipo"]);
                    lstEquipo.cPrecio = Convert.ToDouble(drMenu["cPrecio"]);
                    lstEquipo.accesorios = Convert.ToString(drMenu["Accesorios"]);
                    lstEquipo.cObservacion = Convert.ToString(drMenu["Observaciones"]);
                    lstEquipo.bEstado = Convert.ToBoolean(drMenu["bEstado"]);
                }

                return lstEquipo;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPlan.cs", "daListarPlan", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstEquipo = null;
            }
        }

        public Int16 daBuscarNombreEquipo(Int32 idCategoria, Int32 idMarca, Int32 idModelo, String pcBuscar, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idCategoria", SqlDbType.TinyInt);
                pa[0].Value = idCategoria;
                pa[1] = new SqlParameter("@idMarca", SqlDbType.TinyInt);
                pa[1].Value = idMarca;
                pa[2] = new SqlParameter("@idModelo", SqlDbType.TinyInt);
                pa[2].Value = idModelo;
                pa[3] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[3].Value = pcBuscar;
                pa[4] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[4].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarNombreEquipoUnico", pa);

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

        public List<Equipo> daListarEquipo(Int32 idAccesorio, Int32 peTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;
            List<Equipo> lstVehiculo = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidEquipo", SqlDbType.Int);
                pa[0].Value = idAccesorio;
                pa[1] = new SqlParameter("@peTipoCon", SqlDbType.Int);
                pa[1].Value = peTipoCon;

                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspListarEquipoUni", pa);

                lstVehiculo = new List<Equipo>();
                foreach (DataRow drMenu in dtAccesorio.Rows)
                {
                    lstVehiculo.Add(new Equipo(
                        Convert.ToInt32(drMenu["idEquipo"]),
                        Convert.ToString(drMenu["nombre"]),
                        Convert.ToDouble(drMenu["cPrecio"]),
                        Convert.ToBoolean(drMenu["bEstado"])
                        ));
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

        public List<CategoriaEquipo> daDevolverCategoriaEquipo(Int32 idCategoria, Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<CategoriaEquipo> lstCategoriaEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pnTipoCon", SqlDbType.Int);
                pa[0].Value = idCategoria;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspListarCategoriaCombo", pa);

                lstCategoriaEquipo = new List<CategoriaEquipo>();

                lstCategoriaEquipo.Add(new CategoriaEquipo(
                Convert.ToInt32(0),
                buscar ? Convert.ToString("TODOS") : Convert.ToString("Selecc. Categoria"),
                Convert.ToString(""),
                Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtEquipo.Rows)
                {
                    lstCategoriaEquipo.Add(new CategoriaEquipo(
                        Convert.ToInt32(drMenu["idCategoria"]),
                        Convert.ToString(drMenu["cNombre"]),
                        Convert.ToString(drMenu["cObservacion"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstCategoriaEquipo;

            }
            catch (Exception ex)
            {
                lstCategoriaEquipo = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverMarcaV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstCategoriaEquipo = null;
            }

        }
        public List<MarcaEquipo> daDevolverMarcaEquipo(Int32 pnTipoCon, Int32 idMarca, Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<MarcaEquipo> lstCategoriaEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidMarcaE", SqlDbType.Int);
                pa[0].Value = idMarca;
                pa[1] = new SqlParameter("@peidCategoria", SqlDbType.Int);
                pa[1].Value = pnTipoCon;
                pa[2] = new SqlParameter("@peidCategoria", SqlDbType.Int);
                pa[2].Value = pnTipoCon;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspListarMarcaEquipo", pa);

                lstCategoriaEquipo = new List<MarcaEquipo>();

                lstCategoriaEquipo.Add(new MarcaEquipo(
                Convert.ToInt32(0),
                buscar ? Convert.ToString("TODOS") : Convert.ToString("Selecc. Categoria"),
                Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtEquipo.Rows)
                {
                    lstCategoriaEquipo.Add(new MarcaEquipo(
                        Convert.ToInt32(drMenu["idMarcaEquipo"]),
                        Convert.ToString(drMenu["cNombreMarca"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstCategoriaEquipo;

            }
            catch (Exception ex)
            {
                lstCategoriaEquipo = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverMarcaV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstCategoriaEquipo = null;
            }

        }
        public List<ModeloEquipo> daDevolverModeloEquipo(Int32 idModelo, Boolean buscar,Int16 pntipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<ModeloEquipo> lstCategoriaEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidModeloE", SqlDbType.Int);
                pa[0].Value = idModelo;
                pa[1] = new SqlParameter("@peTipoCon", SqlDbType.Int);
                pa[1].Value = pntipoCon;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspListarModeloEquipo", pa);

                lstCategoriaEquipo = new List<ModeloEquipo>();

                lstCategoriaEquipo.Add(new ModeloEquipo(
                Convert.ToInt32(0),
                buscar ? Convert.ToString("TODOS") : Convert.ToString("Selecc. Categoria"),
                Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtEquipo.Rows)
                {
                    lstCategoriaEquipo.Add(new ModeloEquipo(
                        Convert.ToInt32(drMenu["idModelo"]),
                        Convert.ToString(drMenu["cNombreModelo"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstCategoriaEquipo;

            }
            catch (Exception ex)
            {
                lstCategoriaEquipo = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverMarcaV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstCategoriaEquipo = null;
            }

        }

        public DataTable daBuscarEquipoHistorial(Int32 idEquipo, Int32 numPagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidEquipo", SqlDbType.Int);
                pa[0].Value = idEquipo;
                pa[1] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[1].Value = numPagina;
                pa[2] = new SqlParameter("@tipoCon", SqlDbType.Real);
                pa[2].Value = tipoCon;

                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspListarHistorialEquipoUnico", pa);

                return dtEquipo;
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
