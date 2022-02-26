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
   public class DAOperador
   {

        private clsUtil objUtil = null;

        public SimCard daObtenerPaginacion(String Estado, Int32 tipoCon,String pcBuscar)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            SimCard lstOperador = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@cboEstado", SqlDbType.VarChar,8);
                pa[0].Value = Estado;
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[1].Value = tipoCon;
                pa[2] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 20);
                pa[2].Value = pcBuscar;
                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspObtenerPaginacionSimCard", pa);

                lstOperador = new SimCard();
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
        public DataTable daValidarSimCard(List<SimCard> lstSimCard, Int32 columna)
        {
            SqlParameter[] pa = new SqlParameter[2];
      
            DataTable dtSimCard = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();
            string xmlData = clsUtil.Serialize(lstSimCard);
            try
            {

                pa[0] = new SqlParameter("@xmlValidar", SqlDbType.Xml);
                pa[0].Value = xmlData;
                pa[1] = new SqlParameter("@peColumna", SqlDbType.Int);
                pa[1].Value = columna;
                   
                objCnx = new clsConexion("");
                dtSimCard = objCnx.EjecutarProcedimientoDT("uspValidarSimCardYCodigo", pa);

                return dtSimCard;

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
                lstSimCard = null;
            }




        }
        public List<SimCard> daBuscarOperador(String pcBuscar, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            List<SimCard> lstOperador = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;


                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspBuscarEquipo", pa);

                lstOperador = new List<SimCard>();
                foreach (DataRow drMenu in dtOperador.Rows)
                {
                    lstOperador.Add(new SimCard(
                            Convert.ToInt32(drMenu["ID"]),
                            Convert.ToInt32(drMenu["nImeiEquipo"]),
                           Convert.ToString(drMenu["nImeiEquipo"]),
                           Convert.ToString(drMenu["cEstado"])));
                }

                return lstOperador;

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

        public DataTable daBuscarEquipoDatatable(String pcBuscar, Int16 pnTipoCon,string valorComboBuscar, Int32 paginacion, Int32 tipoBusqueda)
        {
            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            List<SimCard> lstOperador = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 20);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = pnTipoCon;
                pa[2] = new SqlParameter("@peValorCombo", SqlDbType.NVarChar,15);
                pa[2].Value = valorComboBuscar;
                pa[3] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[3].Value = paginacion;
                pa[4] = new SqlParameter("@peiTipoBusqueda", SqlDbType.Int);
                pa[4].Value = tipoBusqueda;
                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspBuscarChips", pa);

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

        public DataTable daBuscarSimcardDatatable(String pcBuscar, String cboEstado, Int32 cboOperador, Int32 paginacion, Int32 tipoConPagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[6];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            List<SimCard> lstOperador = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 20);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@cboEstado", SqlDbType.NVarChar,15);
                pa[1].Value = cboEstado;
                pa[2] = new SqlParameter("@cboOperador", SqlDbType.Int);
                pa[2].Value = cboOperador;
                pa[3] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[3].Value = paginacion;
                pa[4] = new SqlParameter("@tipoConPagina", SqlDbType.Int);
                pa[4].Value = tipoConPagina;
                pa[5] = new SqlParameter("@peiTipoBusqueda", SqlDbType.Int);
                pa[5].Value = tipoCon;
                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspBuscarSimCard", pa);

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

        public SimCard daListarChipDatatable(Int32 idChip)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            SimCard lstOperador = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidChip", SqlDbType.Int);
                pa[0].Value = idChip;

                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspListarChip", pa);

                lstOperador = new SimCard();
                foreach (DataRow drMenu in dtOperador.Rows)
                {
                    lstOperador.idChip= Convert.ToInt32(drMenu["idChip"]);
                    lstOperador.simCard = Convert.ToInt32(drMenu["cSimCard"]);
                    lstOperador.idOperador = Convert.ToInt32(drMenu["idOperador"]);
                    lstOperador.dFechaCompra = Convert.ToDateTime(drMenu["dFechaCompra"]);
                    if (drMenu["rNumeroDias"]==null)
                    {

                    }
                    else
                    {

                    lstOperador.rNumeroDias = Convert.ToInt32(drMenu["rNumeroDias"]);
                    }
                    lstOperador.observacion = Convert.ToString(drMenu["cObservacion"]);
                    lstOperador.idEstado = Convert.ToString(drMenu["cEstado"]);
                    lstOperador.dFechaSuspencion = Convert.ToString(drMenu["dFechaSuspencion"]);
                    lstOperador.dFechaReactivacion = Convert.ToString(drMenu["dFechaReactivacion"]);
                    lstOperador.dFechaBaja = Convert.ToString(drMenu["dFechaBaja"]);
                  
                    lstOperador.ImeiEquipo = Convert.ToString(drMenu["ImeiEquipo"]);

                    
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
        public List<SimCard> daDevolverEquipo(Int32 idEquipo)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<SimCard> lstEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidEquipo", SqlDbType.Int);
                pa[0].Value = idEquipo;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspListarEquipo", pa);

                lstEquipo = new List<SimCard>();
                foreach (DataRow drMenu in dtEquipo.Rows)
                {
                    lstEquipo.Add(new SimCard(Convert.ToInt32(drMenu["idEquipo"]),
                       Convert.ToInt32(drMenu["nImeiEquipo"]),
                       Convert.ToString(drMenu["nImeiEquipo"]),
                        Convert.ToString(drMenu["cEstado"])));
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

        public List<SimCard> daDevolverOperadorCombo(Int32 idEquipo, Int32 condicion)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<SimCard> lstEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peIdOperador", SqlDbType.Int);
                pa[0].Value = idEquipo;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspListarOperador", pa);

                lstEquipo = new List<SimCard>();
                String texto = (condicion == 0) ? "Selec. Operador" : "Todos";
                lstEquipo.Add(new SimCard(Convert.ToInt32(0),
                       Convert.ToString(texto),
                        Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtEquipo.Rows)
                {
                    lstEquipo.Add(new SimCard(Convert.ToInt32(drMenu["idOperador"]),
                       Convert.ToString(drMenu["cNombre"]),
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
        public String daGrabarChip(SimCard objChip, Int32 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[13];           
            clsConexion objCnx = null;           
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peIdChip", SqlDbType.Int);
                pa[0].Value = objChip.idChip;
                pa[1] = new SqlParameter("@peSimCard", SqlDbType.Int);
                pa[1].Value = objChip.simCard;
                pa[2] = new SqlParameter("@peIdOperador", SqlDbType.Int);
                pa[2].Value = objChip.idOperador;                
                pa[3] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[3].Value = objChip.dFechaReg;
                pa[4] = new SqlParameter("@pedFechaCompra", SqlDbType.Date);
                pa[4].Value = objChip.dFechaCompra;            
                pa[5] = new SqlParameter("@pedFechaSuspencion", SqlDbType.VarChar,50);
                pa[5].Value = objChip.dFechaSuspencion;
                pa[6] = new SqlParameter("@rNumeroDias", SqlDbType.Int);
                pa[6].Value = objChip.rNumeroDias;
                pa[7] = new SqlParameter("@pedFechaBaja", SqlDbType.VarChar, 50);
                pa[7].Value = objChip.dFechaBaja;
                pa[8] = new SqlParameter("@pedFechaReactivacion", SqlDbType.VarChar, 50);
                pa[8].Value = objChip.dFechaReactivacion;
                pa[9] = new SqlParameter("@pecObservacion", SqlDbType.NVarChar, 100);
                pa[9].Value = objChip.observacion;               
                pa[10] = new SqlParameter("@pebEstado", SqlDbType.NVarChar,8);
                pa[10].Value = objChip.idEstado;
                pa[11] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[11].Value = objChip.idUsuario;


                pa[12] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[12].Value = pnTipoCon;

                objCnx = new clsConexion("");
                //objCnx.EjecutarProcedimiento("uspGuardarChips", pa);
                objCnx.EjecutarProcedimiento("uspGuardarMoviminetoChips", pa);

                

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAEquipo.cs", "daGrabarEquipo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
                objChip = null;

            }

        }

        public SimCard daDevolverOperador(Boolean pbEstado)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            SimCard lstOperador = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[0].Value = pbEstado;

                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspListarOperadorActivo", pa);

                lstOperador = new SimCard();
                foreach (DataRow drMenu in dtOperador.Rows)
                {
                    lstOperador.idChip = Convert.ToInt32(drMenu["idOperador"]);
                    lstOperador.simCard = Convert.ToInt32(drMenu["cNombre"]);
                    lstOperador.idEstado = Convert.ToString(drMenu["bEstado"]);
                }

                return lstOperador;

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
                lstOperador = null;
            }

        }

        public List<SimCard> daDevolverRecibo_Chip()
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            List<SimCard> lstOperador = null;
            objUtil = new clsUtil();

            try
            {

                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspListarRecibo_Chip");

                lstOperador = new List<SimCard>();

                lstOperador.Add(new SimCard(
                Convert.ToInt32(0),
                        Convert.ToString("Selec. recibo")
                       ));

                foreach (DataRow drMenu in dtOperador.Rows)
                {
                    lstOperador.Add(new SimCard(
                        Convert.ToInt32(drMenu["idRecibo"]),
                        Convert.ToString(drMenu["numeroRecibo"])
                        ));
                }
                return lstOperador;
            }
            catch (Exception ex)
            {
                lstOperador = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverMarcaV", ex.Message);
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
        public DataTable daBuscarChipDatatable( Int32 lnIdRecibo,Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            List<SimCard> lstOperador = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@IdRecibo", SqlDbType.TinyInt);
                pa[0].Value = lnIdRecibo;
                pa[1] = new SqlParameter("@TipoCon", SqlDbType.Int);
                pa[1].Value = tipoCon;


                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspBuscarChipsPorRecibo", pa);

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

        public bool daGuardarChips_Recibo(List<AsignarReciboAChips> lstprecio, Int32 tipoCon)
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
                intRowsAffected = objCnx.EjecutarProcedimiento("uspGuardarChipsA_Recibo", pa);

                return true;

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
        public DataTable daBuscarHistorialSimCard(String simcard, Boolean HabilitarFechas, DateTime dtfechaInicio, DateTime dtFechaFinal, Int32 pagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[6];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<Equipo> lstEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@simcard", SqlDbType.VarChar, 20);
                pa[0].Value = simcard;
                pa[1] = new SqlParameter("@HabilitarFechas", SqlDbType.TinyInt);
                pa[1].Value = HabilitarFechas;
                pa[2] = new SqlParameter("@dtFechaInicio", SqlDbType.DateTime);
                pa[2].Value = dtfechaInicio;
                pa[3] = new SqlParameter("@dtFechaFinal", SqlDbType.DateTime);
                pa[3].Value = dtFechaFinal;
                pa[4] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[4].Value = pagina;
                pa[5] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[5].Value = tipoCon;
                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarHistorialSimCard", pa);

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

        public DataTable daBuscarDatosActualesMSimCard(String simcard)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dt = new DataTable();
            clsConexion objCnx = null;
            List<Equipo> lstEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@simcard", SqlDbType.VarChar, 20);
                pa[0].Value = simcard;
                
                objCnx = new clsConexion("");
                dt = objCnx.EjecutarProcedimientoDT("uspBuscarDatosActualesMSimCard", pa);

                return dt;
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
        public Boolean daGuardarSimCod(List<SimCard> lstSimCardGuardar, Int32 tipocon)
        {
            SqlParameter[] pa = new SqlParameter[5];
            DataTable dt = new DataTable();
            
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            string xmlDatasimcard = clsUtil.Serialize(lstSimCardGuardar);
           
            

            try
            {
                pa[0] = new SqlParameter("@xmlsimcard", SqlDbType.Xml);
                pa[0].Value = xmlDatasimcard;


                pa[1] = new SqlParameter("@tipocon", SqlDbType.Int);
                pa[1].Value = tipocon;

                pa[2] = new SqlParameter("@Estado", SqlDbType.NVarChar,10);
                pa[2].Value = lstSimCardGuardar[0].idEstado;

                pa[3] = new SqlParameter("@idUsuario", SqlDbType.Int);
                pa[3].Value = lstSimCardGuardar[0].idUsuario;

                pa[4] = new SqlParameter("@observacion", SqlDbType.NVarChar,500);
                pa[4].Value = lstSimCardGuardar[0].observacion;


                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarSimCod", pa);

                return true;
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
                lstSimCardGuardar = null;
             
            }

        }
        public DataTable daBuscarSimcard(String pcbuscar, String cboorden, String cboEstados, Int32 numPag, Int32 tipocon)
        {
            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtOrden = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
              
                pa[0] = new SqlParameter("@pecBuscar", SqlDbType.VarChar, 30);
                pa[0].Value = pcbuscar;

                pa[1] = new SqlParameter("@cboorden", SqlDbType.VarChar, 30);
                pa[1].Value = cboorden;

                pa[2] = new SqlParameter("@cboEstados", SqlDbType.VarChar, 30);
                pa[2].Value = cboEstados;

                pa[3] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[3].Value = numPag;

                pa[4] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[4].Value = tipocon;


                objCnx = new clsConexion("");
                dtOrden = objCnx.EjecutarProcedimientoDT("uspBuscarSimcardPorOrden", pa);

                return dtOrden;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarSimcard", ex.Message);
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
