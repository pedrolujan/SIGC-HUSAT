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
    public class DACate_Mar_Mod
    {
        private clsUtil objUtil = null;
       
        public List<CategoriaEquipo> daDevolverCategoriaEquipo(Int32 idCategoria,Boolean buscar)
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
                buscar ? Convert.ToString("TODO") : Convert.ToString("Selecc. Categoria"),
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
        public List<MarcaEquipo> daDevolverMarcaEquipo(Int32 idCategoria, Int16 pnTipoCon,Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<MarcaEquipo> lstMarcaEquipo = null;
             objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidCategoria", SqlDbType.Int);
                pa[0].Value = idCategoria;
                pa[1] = new SqlParameter("@pnTipoCon", SqlDbType.Real);
                pa[1].Value = pnTipoCon;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspListarMarcaDeCategoriaEquipo", pa);

                lstMarcaEquipo = new List<MarcaEquipo>();

                lstMarcaEquipo.Add(new MarcaEquipo(
                        Convert.ToInt32(0),
                        buscar ? Convert.ToString("TODOS") : Convert.ToString("Selecc. Marca"),
                        Convert.ToBoolean(1)));
                foreach (DataRow drMenu in dtEquipo.Rows)
                {
                    lstMarcaEquipo.Add(new MarcaEquipo(
                        Convert.ToInt32(drMenu["idMarcaEquipo"]),
                        Convert.ToString(drMenu["cNombreMarca"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstMarcaEquipo;

            }
            catch (Exception ex)
            {
                lstMarcaEquipo = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverMarcaV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstMarcaEquipo = null;
            }

        }


        public List<ModeloEquipo> daDevolverModeloEquipo(Int32 idModeloE,Int16 pnTipoCon,Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<ModeloEquipo> lstModeloE = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidMarca", SqlDbType.Int);
                pa[0].Value = idModeloE;
                pa[1] = new SqlParameter("@pnTipoCon", SqlDbType.Real);
                pa[1].Value = pnTipoCon;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspListarModeloDeMarcaEquipo", pa);

                lstModeloE = new List<ModeloEquipo>();
                lstModeloE.Add(new ModeloEquipo(
                        Convert.ToInt32(0),
                        buscar ? Convert.ToString("TODOS") : Convert.ToString("Selecc. Modelo"),
                        Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtEquipo.Rows)
                {
                    lstModeloE.Add(new ModeloEquipo(
                        Convert.ToInt32(drMenu["idModelo"]),
                        Convert.ToString(drMenu["cNombreModelo"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstModeloE;

            }
            catch (Exception ex)
            {
                lstModeloE = null;
                objUtil.gsLogAplicativo("DACate_Mar_Mod.cs", "daDevolverModeloEquipo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstModeloE = null;
            }

        }



        public String daGrabarCategoriaEquipo(CategoriaEquipo objCategoria, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[7];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidCategoria", SqlDbType.Int);
                pa[0].Value = objCategoria.idCategoria;
                pa[1] = new SqlParameter("@pecNomCategoria", SqlDbType.NVarChar, 50);
                pa[1].Value = objCategoria.cNomCategoria;
                pa[2] = new SqlParameter("@pecDescripcion", SqlDbType.NVarChar, 50);
                pa[2].Value = objCategoria.cDescripCategoria;
                pa[3] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[3].Value = objCategoria.bEstado;
                pa[4] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[4].Value = objCategoria.dFechaReg;
                pa[5] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[5].Value = objCategoria.idUsuario;
                pa[6] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[6].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarCategoria", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAttrvehiculo.cs", "daGrabarMarcaV", ex.Message);
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
        public String daGrabarMarcaEquipo(MarcaEquipo objMarca, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[8];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidMarca", SqlDbType.Int);
                pa[0].Value = objMarca.idMarca;
                pa[1] = new SqlParameter("@pecNomMarca", SqlDbType.NVarChar, 50);
                pa[1].Value = objMarca.cNomMarca;               
                pa[2] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[2].Value = objMarca.bEstado;
                pa[3] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[3].Value = objMarca.dFechaReg;
                pa[4] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[4].Value = objMarca.idUsuario;
                pa[5] = new SqlParameter("@peidCategoria", SqlDbType.Int);
                pa[5].Value = objMarca.idCategoria;
                pa[6] = new SqlParameter("@peObservaciones", SqlDbType.NVarChar,200);
                pa[6].Value = objMarca.cDescripMarca;


                pa[7] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[7].Value = pnTipoCon;


                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarMarcaE", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAttrvehiculo.cs", "daGrabarMarcaEquipo", ex.Message);
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

        public String daGrabarModeloEquipo(ModeloEquipo objModelo, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[8];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidModelo", SqlDbType.Int);
                pa[0].Value = objModelo.idModelo;
                pa[1] = new SqlParameter("@pecNomModelo", SqlDbType.NVarChar, 45);
                pa[1].Value = objModelo.cNomModelo;
                pa[2] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[2].Value = objModelo.bEstado;
                pa[3] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[3].Value = objModelo.dFechaReg;
                pa[4] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[4].Value = objModelo.idUsuario;
                pa[5] = new SqlParameter("@peidMarca", SqlDbType.Int);
                pa[5].Value = objModelo.idMarca;
                pa[6] = new SqlParameter("@peObservacion", SqlDbType.NVarChar,200);
                pa[6].Value = objModelo.cDescripModelo;

                pa[7] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[7].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarModeloE", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAttrvehiculo.cs", "daGrabarMarcaEquipo", ex.Message);
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

        public List<CategoriaEquipo>daBuscarCategoriaE(String pcBuscar, Int16 piTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtMarcaV = new DataTable();
            clsConexion objCnx = null;
            List<CategoriaEquipo> lstMarcaV = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 20);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = piTipoCon;


                objCnx = new clsConexion("");
                dtMarcaV = objCnx.EjecutarProcedimientoDT("uspBuscarCategoriaE", pa);

                lstMarcaV = new List<CategoriaEquipo>();
                foreach (DataRow drMenu in dtMarcaV.Rows)
                {
                    lstMarcaV.Add(new CategoriaEquipo(
                        Convert.ToInt32(drMenu["idCategoria"]),
                        Convert.ToString(drMenu["cNombre"]),
                        Convert.ToString(drMenu["cObservacion"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstMarcaV;

            }
            catch (Exception ex)
            {
                lstMarcaV = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daBuscarMarcaV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstMarcaV = null;
            }
        }
        public List<MarcaEquipo> daBuscarMarcaE(String pcBuscar, Int16 piTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtMarcaV = new DataTable();
            clsConexion objCnx = null;
            List<MarcaEquipo> lstModeloV = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 20);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = piTipoCon;


                objCnx = new clsConexion("");
                dtMarcaV = objCnx.EjecutarProcedimientoDT("uspBuscarMarcaE", pa);

                lstModeloV = new List<MarcaEquipo>();
                foreach (DataRow drMenu in dtMarcaV.Rows)
                {
                    lstModeloV.Add(new MarcaEquipo(Convert.ToInt32(drMenu["idMarcaEquipo"]),
                        Convert.ToString(drMenu["cNombreMarca"]), Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstModeloV;

            }
            catch (Exception ex)
            {
                lstModeloV = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daBuscarMarcaV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstModeloV = null;
            }
        }

        public List<ModeloEquipo> daBuscarModeloE(String pcBuscar, Int16 piTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtMarcaV = new DataTable();
            clsConexion objCnx = null;
            List<ModeloEquipo> lstModeloV = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 20);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = piTipoCon;


                objCnx = new clsConexion("");
                dtMarcaV = objCnx.EjecutarProcedimientoDT("uspBuscarModeloE", pa);

                lstModeloV = new List<ModeloEquipo>();
                foreach (DataRow drMenu in dtMarcaV.Rows)
                {
                    lstModeloV.Add(new ModeloEquipo(Convert.ToInt32(drMenu["idModelo"]),
                        Convert.ToString(drMenu["cNombreModelo"]), Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstModeloV;

            }
            catch (Exception ex)
            {
                lstModeloV = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daBuscarMarcaV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstModeloV = null;
            }
        }

        public List<MarcaVehiculo> daListarMarca(Int32 idVehiculo)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<MarcaVehiculo> lstVehiculo = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidMarcaV", SqlDbType.Int);
                pa[0].Value = idVehiculo;

                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarMarcaV", pa);

                lstVehiculo = new List<MarcaVehiculo>();
                foreach (DataRow drVehiculo in dtVehiculo.Rows)
                {
                    lstVehiculo.Add(new MarcaVehiculo(Convert.ToInt32(drVehiculo["idMarcaV"]),
                                                Convert.ToString(drVehiculo["nombreMarcaV"]),
                                                Convert.ToBoolean(drVehiculo["bEstado"])));
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

        public List<MarcaVehiculo> daListarMarcas(Boolean pbEstado)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtMarca = new DataTable();
            clsConexion objCnx = null;
            List<MarcaVehiculo> lstMarca = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[0].Value = pbEstado;
                objCnx = new clsConexion("");
                dtMarca = objCnx.EjecutarProcedimientoDT("uspListarMarcasV", pa);

                lstMarca = new List<MarcaVehiculo>();
                foreach (DataRow drMenu in dtMarca.Rows)
                {
                    lstMarca.Add(new MarcaVehiculo(Convert.ToInt32(drMenu["idMarcaV"]),
                        Convert.ToString(drMenu["nombreMarcaV"])));
                }

                return lstMarca;

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
                lstMarca = null;
            }

        }

        public List<ModeloVehiculo> daListarModelos(Boolean pbEstado)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtMarca = new DataTable();
            clsConexion objCnx = null;
            List<ModeloVehiculo> lstModelo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[0].Value = pbEstado;
                objCnx = new clsConexion("");
                dtMarca = objCnx.EjecutarProcedimientoDT("uspListarModelosV", pa);

                lstModelo = new List<ModeloVehiculo>();
                foreach (DataRow drMenu in dtMarca.Rows)
                {
                    lstModelo.Add(new ModeloVehiculo(Convert.ToInt32(drMenu["idModeloV"]),
                        Convert.ToString(drMenu["nombreModeloV"])));
                }

                return lstModelo;

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
                lstModelo = null;
            }

        }

        public List<ModeloVehiculo> daListarModelo(Int32 idModelo)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtModeloV = new DataTable();
            clsConexion objCnx = null;
            List<ModeloVehiculo> lstModelo = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidModeloV", SqlDbType.Int);
                pa[0].Value = idModelo;

                objCnx = new clsConexion("");
                dtModeloV = objCnx.EjecutarProcedimientoDT("uspListarModeloV", pa);

                lstModelo = new List<ModeloVehiculo>();
                foreach (DataRow drVehiculo in dtModeloV.Rows)
                {
                    lstModelo.Add(new ModeloVehiculo(Convert.ToInt32(drVehiculo["idModeloV"]),
                                                Convert.ToString(drVehiculo["nombreModeloV"]),
                                                Convert.ToBoolean(drVehiculo["bEstado"])));
                }

                return lstModelo;

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
                lstModelo = null;
            }

        }

        public ModeloEquipo daListarModeloDatatable(Int32 codPlan)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            ModeloEquipo lstPlan = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peidModeloE", SqlDbType.Int);
                pa[0].Value = codPlan;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarModeloEquipo", pa);

                lstPlan = new ModeloEquipo();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPlan.idModelo = Convert.ToInt32(drMenu["idModelo"]);
                    lstPlan.idCategoria = Convert.ToInt32(drMenu["idCategoria"]);
                    lstPlan.idMarca = Convert.ToInt32(drMenu["idMarcaEquipo"]);
                    lstPlan.cNomModelo = Convert.ToString(drMenu["cNombreModelo"]);
                    lstPlan.cDescripModelo = Convert.ToString(drMenu["cObservacion"]);
                    lstPlan.bEstado = Convert.ToBoolean(drMenu["bEstado"]);

                }

                return lstPlan;
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

        public DataTable daBuscarModeloDataTable(String pcBuscar, Int16 pnTipoCon, Int32 idCategoria, Int32 idMarca)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();



            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peIdCategoria", SqlDbType.Int);
                pa[1].Value = idCategoria;
                pa[2] = new SqlParameter("@peIdMarca", SqlDbType.Int);
                pa[2].Value = idMarca;
                pa[3] = new SqlParameter("@peiTipoCon", SqlDbType.Real);
                pa[3].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarModeloE", pa);

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

        public Int16 daBuscarNombreModelo(String pcBuscar, Int32 pcidCategoria)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peidMarca", SqlDbType.Int);
                pa[1].Value = pcidCategoria;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarNombreModelo", pa);

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
    }
}
