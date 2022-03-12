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
    public class DAAdministrarEquipos
    {
        private clsUtil objUtil = null;

        public AdministrarEquipos daListarImeiEspecifico(Int32 idImei, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtOperador = new DataTable();
            clsConexion objCnx = null;
            AdministrarEquipos lstEquipo = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidImei", SqlDbType.Int);
                pa[0].Value = idImei;
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[1].Value = tipoCon;
                objCnx = new clsConexion("");
                dtOperador = objCnx.EjecutarProcedimientoDT("uspListarImeis", pa);

                lstEquipo = new AdministrarEquipos();
                foreach (DataRow drMenu in dtOperador.Rows)
                {
                    lstEquipo.idEquipoImeis = Convert.ToInt32(drMenu["idEquipoImeis"]);
                    lstEquipo.nombreEquipo = Convert.ToString(drMenu["NombreEquipo"]);
                    lstEquipo.idEstadoEquipo = Convert.ToString(drMenu["bEstado"]);
                    lstEquipo.idSimCardExistente = Convert.ToInt32(drMenu["idSimCard"]);
                    if (Convert.ToInt32(drMenu["idSimCard"]) == 0)
                    {
                        lstEquipo.SimCard = Convert.ToString(0);
                    }
                    else
                    {
                        lstEquipo.SimCard = Convert.ToString(drMenu["cSimCard"]);                    
                    }
                    //lstOperador.origenEquipo = Convert.ToString(drMenu["origen"]);
                    lstEquipo.imei = Convert.ToString(drMenu["Imei"]);
                    lstEquipo.serie = Convert.ToString(drMenu["nSerieEquipo"]);
                    lstEquipo.Observacion = Convert.ToString(drMenu["Observaciones"]);
                    lstEquipo.idPlataformaEquipo = Convert.ToString(drMenu["idPlataforma"]);
                    lstEquipo.dFechaMovimiento = Convert.ToDateTime(drMenu["dFechaMovimiento"]);

                    //lstEquipo.idSimCard = Convert.ToInt32(drMenu["idSimCard"]);
                    //if (Convert.ToInt32(drMenu["idSimCard"]) != 0)
                    //{
                        lstEquipo.dFechaMovimiento= Convert.ToDateTime(drMenu["dFechaMovimiento"]);
                    //}
                    //else
                    //{
                    //    lstEquipo.dFechaMovimiento = Convert.ToDateTime(DateTime.Now);
                    //}

                    //lstEquipo.dFechaBaja = Convert.ToString(drMenu["dFechaBaja"]);
                    //lstEquipo.dFechaExpiracion = Convert.ToString(drMenu["dFechaExpiracion"]);
                    //lstEquipo.dFechaActivo = Convert.ToString(drMenu["dFechaActivo"]);


                }

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
        public String daGrabarMovimientoImeis(AdministrarEquipos objChip, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[10];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peEquipoImei", SqlDbType.Int);
                pa[0].Value = objChip.idEquipoImeis;
                pa[1] = new SqlParameter("@peIdplataforma", SqlDbType.VarChar, 8);
                pa[1].Value = objChip.idPlataformaEquipo;
                pa[2] = new SqlParameter("@peIdEstadoEquipo", SqlDbType.VarChar, 8);
                pa[2].Value = objChip.idEstadoEquipo;
                pa[3] = new SqlParameter("@peIdSimcard", SqlDbType.Int);
                pa[3].Value = objChip.idSimCard;
                pa[4] = new SqlParameter("@peIdSimcardExistente", SqlDbType.Int);
                pa[4].Value = objChip.idSimCardExistente;
                pa[5] = new SqlParameter("@pedFechaMovimiento", SqlDbType.DateTime);
                pa[5].Value = objChip.dFechaMovimiento;
                pa[6] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[6].Value = objChip.dFecharegistro;
                pa[7] = new SqlParameter("@pecObservacion", SqlDbType.NVarChar, 200);
                pa[7].Value = objChip.observacion;
                pa[8] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[8].Value = objChip.idUsuario;


                pa[9] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[9].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarMovimientoEquipoAsignacion", pa);

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

        public DataTable daBuscarImeisDatatable(Int32 lnIdRecibo, String pcBuscar, Int32 numPagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtImeis = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@IdDocumento", SqlDbType.TinyInt);
                pa[0].Value = lnIdRecibo;
                pa[1] = new SqlParameter("@pcBuscar", SqlDbType.VarChar,15);
                pa[1].Value = pcBuscar;
                pa[2] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[2].Value = numPagina;
                pa[3] = new SqlParameter("@TipoCon", SqlDbType.Int);
                pa[3].Value = tipoCon;


                objCnx = new clsConexion("");
                dtImeis = objCnx.EjecutarProcedimientoDT("uspBuscarImeisParaDocumento", pa);

                return dtImeis;
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
        public bool daGuardarChips_Recibo(List<AsignarImeisADocumento> lstImeis, Int32 tipoCon, Int32 Stok, Int32 idOrden)
        {
            SqlParameter[] pa = new SqlParameter[4];
            int intRowsAffected = 0;
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            string xmlData = clsUtil.Serialize(lstImeis);
            try
            {

                pa[0] = new SqlParameter("@xmlData", SqlDbType.Xml);
                pa[0].Value = xmlData;
                pa[1] = new SqlParameter("@stokEntrante", SqlDbType.Int); 
                pa[1].Value = Stok;
                pa[2] = new SqlParameter("@idOrdenIngreso", SqlDbType.Int); 
                pa[2].Value = idOrden;
                pa[3] = new SqlParameter("@peiTipoCon", SqlDbType.Int);
                pa[3].Value = tipoCon;

                objCnx = new clsConexion("");
                intRowsAffected = objCnx.EjecutarProcedimiento("uspGuardarImeisA_DocumentoIngreso", pa);

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
        public DataTable daBuscarHistorialImeis(String imei, String simcard, Boolean HabilitarFechas, DateTime dtfechaInicio, DateTime dtFechaFinal)
        {
            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<Equipo> lstEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@imei", SqlDbType.VarChar, 20);
                pa[0].Value = imei;
                pa[1] = new SqlParameter("@simcard", SqlDbType.VarChar, 20);
                pa[1].Value = simcard;
                pa[2] = new SqlParameter("@HabilitarFechas", SqlDbType.Bit);
                pa[2].Value = HabilitarFechas;
                pa[3] = new SqlParameter("@dtFechaInicio", SqlDbType.DateTime);
                pa[3].Value = dtfechaInicio;
                pa[4] = new SqlParameter("@dtFechaFinal", SqlDbType.DateTime);
                pa[4].Value = dtFechaFinal;
                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarHistorialImeis", pa);

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

        public Boolean daLiberarImeis(Int32 idEquipo, Int32 idSimCard,DateTime fechaReg,Int32 idUsuario ,String pcObservacion)
        {
            SqlParameter[] pa = new SqlParameter[5];
            int intRowsAffected = 2;
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idEquipoImeis", SqlDbType.Int);
                pa[0].Value = idEquipo;
                pa[1] = new SqlParameter("@idSimCard", SqlDbType.Int);
                pa[1].Value = idSimCard;
                pa[2] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[2].Value = fechaReg;
                pa[3] = new SqlParameter("@peIdUsuario", SqlDbType.Int);
                pa[3].Value = idUsuario;
                pa[4] = new SqlParameter("@pecObservacion", SqlDbType.VarChar,500);
                pa[4].Value = pcObservacion;


                objCnx = new clsConexion("");
                intRowsAffected = objCnx.EjecutarProcedimiento("uspLiberacionEquipoImeis", pa);

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
    }
}
