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
    public class DAAttrVehiculo
    {
        private clsUtil objUtil = null;

        public List<DetalleVehiculoEspecial> daDevolverDetVehiculoEsp(Int32 idVehiculoEsp)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<DetalleVehiculoEspecial> lstDetalleVE = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidVehiuloEsp", SqlDbType.Int);
                pa[0].Value = idVehiculoEsp;


                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarDetalleVehiculoEsp", pa);

                lstDetalleVE = new List<DetalleVehiculoEspecial>();

                lstDetalleVE.Add(new DetalleVehiculoEspecial(
                    Convert.ToInt32(0),
                    Convert.ToString("Seleccione. Detalle"),
                    Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtVehiculo.Rows)
                {
                    lstDetalleVE.Add(new DetalleVehiculoEspecial(
                        Convert.ToInt32(drMenu["idDatVE"]),
                        Convert.ToString(drMenu["nombreDatVE"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstDetalleVE;

            }
            catch (Exception ex)
            {
                lstDetalleVE = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverClaseV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstDetalleVE = null;
            }

        }
        public List<ClaseVehiculo> daDevolverClaseV(Int32 idClaseV,Boolean estado,Int32 lntipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<ClaseVehiculo> lstClaseV = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidClaseV", SqlDbType.Int);
                pa[0].Value = idClaseV;
                pa[1] = new SqlParameter("@lnTipoCon", SqlDbType.Int);
                pa[1].Value = lntipoCon;


                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarClaseVehiculo", pa);

                lstClaseV = new List<ClaseVehiculo>();

                String Itemcero = (estado == true) ? "Todo" : "Seleccione. Clase";

                lstClaseV.Add(new ClaseVehiculo(
                    Convert.ToInt32(0),
                    Convert.ToString(Itemcero),
                    Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtVehiculo.Rows)
                {
                    lstClaseV.Add(new ClaseVehiculo(Convert.ToInt32(drMenu["idClaseV"]),
                        Convert.ToString(drMenu["cNombreClaseV"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstClaseV;

            }
            catch (Exception ex)
            {
                lstClaseV = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverClaseV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstClaseV = null;
            }

        }

        public ClaseVehiculo daListarClaseEspecifica(Int32 idClase)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            ClaseVehiculo lstOperador = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidClaseV", SqlDbType.Int);
                pa[0].Value = idClase;

                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspListarClaseV", pa);

                lstOperador = new ClaseVehiculo();
                foreach (DataRow drMenu in dtOperador.Rows)
                {
                    lstOperador.idClase = Convert.ToInt32(drMenu["idClaseV"]);
                    lstOperador.cNomClase = Convert.ToString(drMenu["cNombreClaseV"]);
                    lstOperador.bEstado = Convert.ToBoolean(drMenu["bEstado"]);
                    lstOperador.bConPlaca = Convert.ToBoolean(drMenu["conplaca"]);
        
                }

                return lstOperador;

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
                lstOperador = null;
            }

        }
        public List<MarcaVehiculo> daDevolverMarcaV(Int32 idMarcaV)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<MarcaVehiculo> lstMarcaV = null;
             objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pnidClase", SqlDbType.Int);
                pa[0].Value = idMarcaV;


                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarMarcasV", pa);

                lstMarcaV = new List<MarcaVehiculo>();
                lstMarcaV.Add(new MarcaVehiculo(
                    Convert.ToInt32(0),
                    Convert.ToString("Seleccione Marca"),
                    Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtVehiculo.Rows)
                {
                    lstMarcaV.Add(new MarcaVehiculo(Convert.ToInt32(drMenu["idMarcaV"]),
                        Convert.ToString(drMenu["nombreMarcaV"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstMarcaV;

            }
            catch (Exception ex)
            {
                lstMarcaV = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverMarcaV", ex.Message);
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
        public List<MarcaVehiculo> daDevolverMarcaVehiculo(Int32 idClase, Boolean estado,Int32 lntipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<MarcaVehiculo> lstMarcaV = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pnidClase", SqlDbType.Int);
                pa[0].Value = idClase;
                pa[1] = new SqlParameter("@lnTipoCon", SqlDbType.Int);
                pa[1].Value = lntipoCon;



                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarMarXclase", pa);

                lstMarcaV = new List<MarcaVehiculo>();
                String ItemCero = (estado == true) ? "Todo" : "Selecc. Marca";
                lstMarcaV.Add(new MarcaVehiculo(
                    Convert.ToInt32(0),
                    Convert.ToString(ItemCero),
                    Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtVehiculo.Rows)
                {
                    lstMarcaV.Add(new MarcaVehiculo(Convert.ToInt32(drMenu["idMarcaV"]),
                        Convert.ToString(drMenu["nombreMarcaV"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstMarcaV;

            }
            catch (Exception ex)
            {
                lstMarcaV = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverMarcaV", ex.Message);
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
        public Int32 daDevolverEstadoPlacaV(Int32 idClase)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            Int32 estadoPlaca = 0;

            try
            {
                pa[0] = new SqlParameter("@peidClase", SqlDbType.Int);
                pa[0].Value = idClase;


                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarEstadoPlacaV", pa);
                foreach (DataRow drMenu in dtVehiculo.Rows)
                {
                    if (Convert.ToInt32(drMenu["conPlaca"])==1)
                    {
                        estadoPlaca = 1;
                    }
                    else
                    {
                        estadoPlaca = 0;
                    }
                }


                return estadoPlaca;

            }
            catch (Exception ex)
            {
                estadoPlaca = 0;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverMarcaV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public Int16 daDevolverValidarPlaca(String pcBuscar, String txtplaca2, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@pecPlac2", SqlDbType.VarChar, 50);
                pa[1].Value = txtplaca2;
                pa[2] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[2].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspValidarPlacaV", pa);

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
                objUtil.gsLogAplicativo("DACliente.cs", "daDevolverValidarPlaca", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }
        public Int16 daDevolverValidarMarcaExistente(String pcBuscar, String txtMarca2, Int16 idClase, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;

                pa[1] = new SqlParameter("@pecMarca2", SqlDbType.VarChar, 50);
                pa[1].Value = txtMarca2;

                pa[2] = new SqlParameter("@pnidClase", SqlDbType.Int);
                pa[2].Value = idClase;

                pa[3] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[3].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspValidarMarcaV", pa);

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
                objUtil.gsLogAplicativo("DACliente.cs", "daDevolverValidarMarcaExistente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;

            }
        }

        public Int16 daDevolverValidarUsoEspecifico(String pcBuscar, String txtUso2, Int16 idClase, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar,50);
                pa[0].Value = pcBuscar;

                pa[1] = new SqlParameter("@pecUso2", SqlDbType.VarChar, 50);
                pa[1].Value = txtUso2;

                pa[2] = new SqlParameter("@pnidclase", SqlDbType.Int);
                pa[2].Value = idClase;

                pa[3] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[3].Value = pnTipoCon;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspValidarUsoV", pa);

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
            catch(Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daDevolverValidarMarcaExistente", ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Int16 daDevolverValidarModeloExistente(String pcBuscar, String txtModelo2, Int16 idClase,Int16 idMarca, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtModelo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@pecModelo2", SqlDbType.VarChar, 50);
                pa[1].Value = txtModelo2;
                pa[2] = new SqlParameter("@pnidClase", SqlDbType.Int);
                pa[2].Value = idClase;
                pa[3] = new SqlParameter("@pnidMarca", SqlDbType.Int);
                pa[3].Value = idMarca;
                pa[4] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[4].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtModelo = objCnx.EjecutarProcedimientoDT("uspValidarModeloV", pa);

                Int16 numFilas;

                if (dtModelo.Rows.Count > 0)
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
                objUtil.gsLogAplicativo("DACliente.cs", "daDevolverValidarMarcaExistente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;

            }
        }
        public List<ModUsoVehiculo> daDevolverModUsoV(Int32 idMarcaV)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<ModUsoVehiculo> lstMarcaV = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidModUsoV", SqlDbType.Int);
                pa[0].Value = idMarcaV;


                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarModoUsoV", pa);

                lstMarcaV = new List<ModUsoVehiculo>();
                lstMarcaV.Add(new ModUsoVehiculo(
                    Convert.ToInt32(0),
                    Convert.ToString("Seleccione Uso"),
                    Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtVehiculo.Rows)
                {
                    lstMarcaV.Add(new ModUsoVehiculo(Convert.ToInt32(drMenu["idUsoV"]),
                        Convert.ToString(drMenu["cUsoV"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstMarcaV;

            }
            catch (Exception ex)
            {
                lstMarcaV = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverModoUsoV", ex.Message);
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

        public List<ModeloVehiculo> daDevolverModeloV(Int32 idMarcaV)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<ModeloVehiculo> lstModeloV = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidMarcaV", SqlDbType.Int);
                pa[0].Value = idMarcaV;


                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarModelosV", pa);

                lstModeloV = new List<ModeloVehiculo>();
                lstModeloV.Add(new ModeloVehiculo(
                    Convert.ToInt32(0), 
                    Convert.ToString("Seleccione Modelo"),
                    Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtVehiculo.Rows)
                {
                    lstModeloV.Add(new ModeloVehiculo(
                        Convert.ToInt32(drMenu["idModeloV"]), 
                        Convert.ToString(drMenu["nombreModeloV"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstModeloV;

            }
            catch (Exception ex)
            {
                lstModeloV = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverModeloV", ex.Message);
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
        public String daGrabarClaseV(ClaseVehiculo objClase, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[7];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidClase", SqlDbType.Int);
                pa[0].Value = objClase.idClase;
                pa[1] = new SqlParameter("@pecNomClase", SqlDbType.NVarChar, 50);
                pa[1].Value = objClase.cNomClase;
                pa[2] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[2].Value = objClase.bEstado;
                pa[3] = new SqlParameter("@pedFechaReg", SqlDbType.DateTime);
                pa[3].Value = objClase.dFechaReg;
                pa[4] = new SqlParameter("@pebConPlaca", SqlDbType.Bit);
                pa[4].Value = objClase.bConPlaca;
                pa[5] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[5].Value = objClase.idUsuario;
                pa[6] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[6].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarClaseV", pa);

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

        public String daGrabarMarcaV(MarcaVehiculo objMarca, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[7];
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
                pa[3] = new SqlParameter("@pedFechaReg", SqlDbType.DateTime);
                pa[3].Value = objMarca.dFechaReg;
                pa[4] = new SqlParameter("@peidClase", SqlDbType.Int);
                pa[4].Value = objMarca.idClase;
                pa[5] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[5].Value = objMarca.idUsuario;
                pa[6] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[6].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarMarcaV", pa);

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
        public String daGrabarUso(ModUsoVehiculo objUso, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[6];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idUso", SqlDbType.Int);
                pa[0].Value = objUso.idUso;

                pa[1] = new SqlParameter("@cNombreUso", SqlDbType.VarChar);
                pa[1].Value = objUso.cUso;

                pa[2] = new SqlParameter("@EstadoUso", SqlDbType.Bit);
                pa[2].Value = objUso.bEstado;

                pa[3] = new SqlParameter("@idUsuario", SqlDbType.Int);
                pa[3].Value = objUso.idUsuario;

                pa[4] = new SqlParameter("@idClaseUso", SqlDbType.Int);
                pa[4].Value = objUso.idClase;
                
                pa[5] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[5].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarUso", pa);

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

        public String daGrabarModeloV(ModeloVehiculo objModelo, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[7];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peidModelo", SqlDbType.Int);
                pa[0].Value = objModelo.idModelo;
                pa[1] = new SqlParameter("@pecNomModelo", SqlDbType.NVarChar, 50);
                pa[1].Value = objModelo.cNomModelo;
                pa[2] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[2].Value = objModelo.bEstado;
                pa[3] = new SqlParameter("@peidMarca", SqlDbType.Int);
                pa[3].Value = objModelo.idMarca;
                pa[4] = new SqlParameter("@pedFechaReg", SqlDbType.DateTime);
                pa[4].Value = objModelo.dFechaReg;
                pa[5] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[5].Value = objModelo.idUsuario;

                pa[6] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[6].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarModeloV", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAttrvehiculo.cs", "daGrabarModeloV", ex.Message);
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
        public DataTable daBuscarDatosParaDatatables(Int32 tabIndex, Int32 pnIdClase, Int32 pnIdMarca, String pcBuscar, Int32 pagina, Int32 tipoConPagina)
        {
            SqlParameter[] pa = new SqlParameter[6];
            DataTable dtMarcaV = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@penTabIndex", SqlDbType.Int);
                pa[0].Value = tabIndex;
                pa[1] = new SqlParameter("@penIdClase", SqlDbType.Int);
                pa[1].Value = pnIdClase;
                pa[2] = new SqlParameter("@penIdMarca", SqlDbType.Int);
                pa[2].Value = pnIdMarca;
                pa[3] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 20);
                pa[3].Value = pcBuscar;
                pa[4] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[4].Value = pagina;
                pa[5] = new SqlParameter("@peiTipoConPagima", SqlDbType.Int);
                pa[5].Value = tipoConPagina;


                objCnx = new clsConexion("");
                dtMarcaV = objCnx.EjecutarProcedimientoDT("uspBuscarDatosClaseMarcaModeloV", pa);

                return dtMarcaV;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daBuscarMarcaV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }
        public DataTable daBuscarMarcaV(Int32 idclase, String pcBuscar, Int32 pagina, Int32 tipoConPagina)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtMarcaV = new DataTable();
            clsConexion objCnx = null;
            List<MarcaVehiculo> lstMarcaV = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@penIdClase", SqlDbType.Int);
                pa[0].Value = idclase;
                pa[1] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 20);
                pa[1].Value = pcBuscar; 
                pa[2] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[2].Value = pagina;
                pa[3] = new SqlParameter("@peiTipoConPagima", SqlDbType.TinyInt);
                pa[3].Value = tipoConPagina;


                objCnx = new clsConexion("");
                dtMarcaV = objCnx.EjecutarProcedimientoDT("uspBuscarMarcaV", pa);

                //lstMarcaV = new List<MarcaVehiculo>();
                //foreach (DataRow drMenu in dtMarcaV.Rows)
                //{
                //    lstMarcaV.Add(new MarcaVehiculo(
                //        Convert.ToInt32(drMenu["idMarcav"]),
                //        Convert.ToString(drMenu["nombreMarcaV"]),
                //        Convert.ToString(drMenu["cNombreClaseV"]),
                //        Convert.ToBoolean(drMenu["bEstado"])));
                //}

                return dtMarcaV;

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
        public List<ModeloVehiculo> daBuscarModeloV(String pcBuscar, Int16 piTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtMarcaV = new DataTable();
            clsConexion objCnx = null;
            List<ModeloVehiculo> lstModeloV = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 20);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = piTipoCon;


                objCnx = new clsConexion("");
                dtMarcaV = objCnx.EjecutarProcedimientoDT("uspBuscarModeloV", pa);

                lstModeloV = new List<ModeloVehiculo>();
                foreach (DataRow drMenu in dtMarcaV.Rows)
                {
                    lstModeloV.Add(new ModeloVehiculo(
                        Convert.ToInt32(drMenu["idModeloV"]),
                        Convert.ToString(drMenu["nombreModeloV"]),
                        Convert.ToString(drMenu["cNombreClaseV"]),
                        Convert.ToString(drMenu["nombreMarcaV"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
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
                                                Convert.ToBoolean(drVehiculo["bEstado"]),
                                                Convert.ToInt32(drVehiculo["idClaseV"])));
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
        public DataTable daListarMarcaEspecifica(Int32 idVehiculo)
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

                //lstVehiculo = new List<MarcaVehiculo>();
                //foreach (DataRow drVehiculo in dtVehiculo.Rows)
                //{
                //    lstVehiculo.Add(new MarcaVehiculo(Convert.ToInt32(drVehiculo["idMarcaV"]),
                //                                Convert.ToString(drVehiculo["nombreMarcaV"]),
                //                                Convert.ToBoolean(drVehiculo["bEstado"]),
                //                                Convert.ToInt32(drVehiculo["idClaseV"])));
                //}

                return dtVehiculo;

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

        public DataTable daListarUsoEspecifico (Int32 idvehiculo)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<ModUsoVehiculo> lstVehiculo = null;
            objUtil = new clsUtil();

            try
            {

                pa[0]= new SqlParameter("@peidUsoV", SqlDbType.Int);
                pa[0].Value = idvehiculo;

                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarUsuoEspecifico" , pa);

                return dtVehiculo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }





        }









        public List<MarcaVehiculo> daListarMarcas(Boolean pbEstado,Int32 idClase)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtMarca = new DataTable();
            clsConexion objCnx = null;
            List<MarcaVehiculo> lstMarca = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[0].Value = pbEstado;
                pa[1] = new SqlParameter("@pnidClase", SqlDbType.Int);
                pa[1].Value = idClase;
                objCnx = new clsConexion("");
                dtMarca = objCnx.EjecutarProcedimientoDT("uspDebolverMarcasV", pa);

                lstMarca = new List<MarcaVehiculo>();
                lstMarca.Add(new MarcaVehiculo(
                    Convert.ToInt32(0),
                    Convert.ToString("Seleccione Marca")));

                foreach (DataRow drMenu in dtMarca.Rows)
                {
                    lstMarca.Add(new MarcaVehiculo(
                        Convert.ToInt32(drMenu["idMarcaV"]),
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

        public List<ModeloVehiculo> daListarModelos(Boolean pbEstado,Int32 idMarca)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtMarca = new DataTable();
            clsConexion objCnx = null;
            List<ModeloVehiculo> lstModelo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[0].Value = pbEstado;
                pa[1] = new SqlParameter("@pnidMarca", SqlDbType.Int);
                pa[1].Value = idMarca;

                objCnx = new clsConexion("");
                dtMarca = objCnx.EjecutarProcedimientoDT("uspListarDevolverModelV", pa);

                lstModelo = new List<ModeloVehiculo>();
                lstModelo.Add(new ModeloVehiculo(
                    Convert.ToInt32(0),
                    Convert.ToString("Seleccione Modelo")));
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
                                                    Convert.ToBoolean(drVehiculo["bEstado"]), 
                                                    Convert.ToInt32(drVehiculo["Marca"]),
                                                    Convert.ToInt32(drVehiculo["Clase"])));
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

        public List<ClaseVehiculo> daDevolverClaseV(Int32 idClaseV)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<ClaseVehiculo> lstClaseV = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidClaseV", SqlDbType.Int);
                pa[0].Value = idClaseV;
                
                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarClaseV", pa);

                lstClaseV = new List<ClaseVehiculo>();
                lstClaseV.Add(new ClaseVehiculo(
                    Convert.ToInt32(0),
                    Convert.ToString("Seleccione. Clase"),
                    Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtVehiculo.Rows)
                {
                    lstClaseV.Add(new ClaseVehiculo(Convert.ToInt32(drMenu["idClaseV"]),
                        Convert.ToString(drMenu["cNombreClaseV"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstClaseV;

            }
            catch (Exception ex)
            {
                lstClaseV = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverClaseV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstClaseV = null;
            }

        }
    }
}
