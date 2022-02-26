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
   public class DAEquipo_imeis
    {
        public DAEquipo_imeis() { }
        private clsUtil objUtil = null;

        public DataTable daValidarEquipoImeis(List<Equipo_imeis> lstprecio, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            int intRowsAffected = 0;
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            string xmlData = clsUtil.Serialize(lstprecio);
            try
            {

                pa[0] = new SqlParameter("@xmlData", SqlDbType.Xml);
                pa[0].Value = xmlData;
                pa[1] = new SqlParameter("@peColumna", SqlDbType.Int);
                pa[1].Value = tipoCon;

                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspValidarEquipoImeis", pa);

                return dtEquipo;

            }
            catch (Exception ex)
            {               
                objUtil.gsLogAplicativo("DAPrecio.cs", "daGuardarPrecio", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }
        public bool daGuardarEquipoImeis(List<Equipo_imeis> lstprecio,Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            int intRowsAffected = 0;
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            string xmlData = clsUtil.Serialize(lstprecio);
            try     
            {

                pa[0] = new SqlParameter("@xmlData", SqlDbType.Xml);
                pa[0].Value = xmlData;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.Int);
                pa[1].Value = tipoCon;

                objCnx = new clsConexion("");
                intRowsAffected = objCnx.EjecutarProcedimiento("uspGuardarEquipoImeis", pa);

                return true;

            }
            catch (Exception ex)
            {
                //if(ex.HResult== -2146232060)
                //{
                //    return false;
                //}
                objUtil.gsLogAplicativo("DAPrecio.cs", "daGuardarPrecio", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }

        public List<Equipo_imeis> daDevolverPrecioxProducto(int pidProducto)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            
            try
            {
                pa[0] = new SqlParameter("@peIdProducto", SqlDbType.Int);
                pa[0].Value = pidProducto;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarPreciosxProductoxUM", pa);

                List<Equipo_imeis> lstPrecio = new List<Equipo_imeis>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPrecio.Add(new Equipo_imeis
                    {
                        //idPrecio = Convert.ToInt32(drMenu["idPrecio"]),
                        //intIdUnidaMedida = Convert.ToInt32(drMenu["idUnidadMedida"]),
                        //idProducto = Convert.ToInt32(drMenu["idProducto"]),
                        //strDescripcion = Convert.ToString(drMenu["cNombreProducto"]),
                        //precio = Convert.ToDecimal(drMenu["Precio"]),
                        //PrecioActual = Convert.ToDecimal(drMenu["PrecioActual"]),
                    });
                }

                return lstPrecio;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPrecio.cs", "daDevolverPrecioxProducto", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }

        public DataTable daBuscarEquipoImeisDatatable(String pcBuscar, Int16 pnTipoCon)
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
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarEquipoImeis", pa);

                return dtEquipo;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarEquipoImeisDatatable", ex.Message);
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
        
        public DataTable daBuscarImeisDataTable(String estado, Int32 idMarca,Int32 idModelo,String pcBuscar,Int32 numPaginacion, Int32 tipocon, Int32 TipoLlamada)
        {
            SqlParameter[] pa = new SqlParameter[7];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idEstado", SqlDbType.VarChar,8);
                pa[0].Value = estado;
                pa[1] = new SqlParameter("@idMarca", SqlDbType.Int);
                pa[1].Value = idMarca;
                pa[2] = new SqlParameter("@idModelo", SqlDbType.Int);
                pa[2].Value = idModelo;
                pa[3] = new SqlParameter("@peValorBuscar", SqlDbType.NVarChar,100);
                pa[3].Value = pcBuscar;
                pa[4] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[4].Value = numPaginacion;
                pa[5] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[5].Value = tipocon;
                pa[6] = new SqlParameter("@tipollamada", SqlDbType.Int);
                pa[6].Value = TipoLlamada;

                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspBuscarEquipoImeisPaginacion", pa);

                return dtOperador;
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
        public DataTable daBuscarEquipo_ImeisDatatable(Int32 lnIdRecibo)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            List<Equipo_imeis> lstOperador = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@IdEquipo", SqlDbType.TinyInt);
                pa[0].Value = lnIdRecibo;

                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspBuscarImeisEquipo", pa);

                return dtOperador;
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
                lstOperador = null;
            }

        }

        public List<Equipo_imeis> daDevolverEquipo(Int32 idCategoria)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<Equipo_imeis> lstEquipoImeis = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidEquipo", SqlDbType.Int);
                pa[0].Value = idCategoria;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspListarEquipoParaImeis", pa);

                lstEquipoImeis = new List<Equipo_imeis>();
                lstEquipoImeis.Add(new Equipo_imeis(
                Convert.ToInt32(0),
                        Convert.ToString("Selecc. Equipo"),
                        Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtEquipo.Rows)
                {
                    lstEquipoImeis.Add(new Equipo_imeis(
                        Convert.ToInt32(drMenu["idEquipo"]),
                        Convert.ToString(drMenu["Equipo"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstEquipoImeis;

            }
            catch (Exception ex)
            {
                lstEquipoImeis = null;
                objUtil.gsLogAplicativo("DAAEquipo_imeis.cs", "daDevolverEquipo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstEquipoImeis = null;
            }

        }

        public Equipo_imeis daListarImeiEspecifico(Int32 idImei, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            Equipo_imeis lstOperador = null;
            objUtil = new clsUtil();

            try
            {
                
                pa[0] = new SqlParameter("@peidImei", SqlDbType.Int);
                pa[0].Value = idImei;
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[1].Value = tipoCon;
                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspListarImeis", pa);

                lstOperador = new Equipo_imeis();
                foreach (DataRow drMenu in dtOperador.Rows)
                {
                    lstOperador.idEquipoImeis = Convert.ToInt32(drMenu["idEquipoImeis"]);
                    lstOperador.idEquipo = Convert.ToInt32(drMenu["idEquipo"]);
                    lstOperador.nomEquipo = Convert.ToString(drMenu["NombreEquipo"]);
                    lstOperador.idOrdenIngreso = Convert.ToInt32(drMenu["idDetalle"]);
                    lstOperador.bEstadoEquipo = Convert.ToString(drMenu["bEstado"]);
                    lstOperador.imei = Convert.ToString(drMenu["Imei"]);
                    lstOperador.serie = Convert.ToString(drMenu["nSerieEquipo"]);
                    lstOperador.totalRegistros = Convert.ToInt32(drMenu["cantidad"]);
                    lstOperador.Observacion = Convert.ToString(drMenu["Observaciones"]);
                    lstOperador.TipoIngreso = Convert.ToString(drMenu["tipoIngreso"]);
                    lstOperador.CodOrden= Convert.ToString(drMenu["cDocCompra"]);
                    lstOperador.precioEquipo = Convert.ToDouble(drMenu["cPrecio"]);
                    lstOperador.idMoneda = Convert.ToInt32(drMenu["idMoneda"]);
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
        public  List<EstadoImeis> daDevolverEstadoImeis()
        {
            SqlParameter[] pa = new SqlParameter[0];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<EstadoImeis> lstEquipoImeis = null;
            clsUtil objUtil = new clsUtil();

            try
            {               
                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspListarEstadosImeis", pa);

                lstEquipoImeis = new List<EstadoImeis>();
                lstEquipoImeis.Add(new EstadoImeis(
                Convert.ToString(0),
                        Convert.ToString("Selecc. estado")));

                foreach (DataRow drMenu in dtEquipo.Rows)
                {
                    lstEquipoImeis.Add(new EstadoImeis(
                        Convert.ToString(drMenu["cCodTab"]),
                        Convert.ToString(drMenu["cNomTab"])));
                }

                return lstEquipoImeis;

            }
            catch (Exception ex)
            {
                lstEquipoImeis = null;
                objUtil.gsLogAplicativo("DAAEquipo_imeis.cs", "daDevolverEquipo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstEquipoImeis = null;
            }

        }

        public Equipo_imeis daObtenerPaginacionEquipos(String estado, Int32 idMarca, Int32 idModelo)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            Equipo_imeis lstOperador = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idEstado", SqlDbType.VarChar,8);
                pa[0].Value = estado;
                pa[1] = new SqlParameter("@idMarca", SqlDbType.Int);
                pa[1].Value = idMarca;
                pa[2] = new SqlParameter("@idModelo", SqlDbType.Int);
                pa[2].Value = idModelo;
                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspObtenerPaginacionEquipoImeis", pa);

                lstOperador = new Equipo_imeis();
                foreach (DataRow drMenu in dtOperador.Rows)
                {
                    lstOperador.totalRegistros = Convert.ToInt32(drMenu["totalRegistros"]);
                    lstOperador.cantPaginas = Convert.ToString(drMenu["cantPaginas"]);

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

        public Int32 daDevolverDatosExistentes(String pcBuscar, String dato2, Int32 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtDatosDuplicados = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@pecValorBuscar2", SqlDbType.VarChar, 50);
                pa[1].Value = dato2;

                pa[2] = new SqlParameter("@pnColumna", SqlDbType.TinyInt);
                pa[2].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtDatosDuplicados = objCnx.EjecutarProcedimientoDT("uspValidarEquipoImeiExistente", pa);
                Int16 numFilas;
                if (dtDatosDuplicados.Rows.Count > 0)
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
        public DataTable daDevolverEquipoImeisDePlan(String busqueda, Int32 idPlan, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtOperador;
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peValorBusqueda", SqlDbType.NVarChar,20) { Value = busqueda};
                pa[1] = new SqlParameter("@peIdPlan", SqlDbType.Int) { Value = idPlan };
                pa[2] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = tipoCon };

                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspListarImeisDePlan", pa);

                return dtOperador;
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
        public DataTable daDevolverAccesorios(String busqueda,Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dttable;
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.NVarChar, 20) { Value = busqueda };
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.Int) { Value = tipoCon };
                pa[2] = new SqlParameter("@numPagina", SqlDbType.Int) { Value = 0 };
                pa[3] = new SqlParameter("@tipoCon", SqlDbType.Int) { Value = -3 };

                objCnx = new clsConexion("");
                dttable = objCnx.EjecutarProcedimientoDT("uspBuscarAccesorio", pa);

                return dttable;
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
        public DataTable daDevolverAccesoriosEspecifico(Int32 idAccesorio, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dttable;
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidAccesorio", SqlDbType.Int) { Value = idAccesorio };
                pa[1] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = tipoCon };

                objCnx = new clsConexion("");
                dttable = objCnx.EjecutarProcedimientoDT("uspListarAccesorio", pa);

                return dttable;
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
        public DataTable daDevolverStockImeis(Int32 tipoCon,Int32 tipOpcion)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dttable=new DataTable();
            clsConexion objCnx = null;
            Int64 Stock=0;
            objUtil = new clsUtil();

            try
            {
                
                pa[0] = new SqlParameter("@tipoCon", SqlDbType.Int) { Value = tipoCon };
                pa[1] = new SqlParameter("@tipOpcion", SqlDbType.Int) { Value = tipOpcion };
                objCnx = new clsConexion("");
                dttable = objCnx.EjecutarProcedimientoDT("uspObtenerStockOtrasVentas", pa);
                
                return dttable;
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
        public List<Equipo_imeis> daDevolverStockEquipos(Int32 idTipoPlan, Int32 idPlan)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dttable = new DataTable();
            clsConexion objCnx = null;
            Int64 Stock = 0;
            Equipo_imeis obgImeis = new Equipo_imeis();
            List<Equipo_imeis> lstEquipoImeis = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@idTipoPlan", SqlDbType.Int) { Value = idTipoPlan };
                pa[1] = new SqlParameter("@idPlan", SqlDbType.Int) { Value = idPlan };
                objCnx = new clsConexion("");
                dttable = objCnx.EjecutarProcedimientoDT("uspObtenerStockEquipos", pa);

                
                    
                lstEquipoImeis = new List<Equipo_imeis>();

                    foreach (DataRow drMenu in dttable.Rows)
                    {
                        lstEquipoImeis.Add(new Equipo_imeis(
                            Convert.ToInt32(drMenu["idEquipoImeis"]),
                            Convert.ToString(drMenu["imei"]),
                            Convert.ToInt32(drMenu["ROW_COUNT"])
                            ));
                    }

                    //else
                    //{
                    //    Nombre = Convert.ToString(drMenu["nombre"]);
                    //    Stock = Convert.ToInt64(drMenu["stock"]);
                    //}
                return lstEquipoImeis;
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
