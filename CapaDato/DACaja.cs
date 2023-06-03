using CapaConexion;
using CapaEntidad;
using CapaNegocio;
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
    public class DACaja
    {
        clsUtil objUtil;
        public List<ReporteBloque> daBuscarVentas(Busquedas clsBusq)
        {
            SqlParameter[] pa = new SqlParameter[11];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            List<ReporteBloque> lsRepBloque = new List<ReporteBloque>();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@dtFechaIni", SqlDbType.Date) { Value = clsBusq.dtFechaIni };
                pa[1] = new SqlParameter("@dtFechaFin", SqlDbType.Date) { Value = clsBusq.dtFechaFin };
                pa[2] = new SqlParameter("@codTipoReporte", SqlDbType.VarChar) { Value = clsBusq.cod1 };
                pa[3] = new SqlParameter("@codTipoOperacion", SqlDbType.VarChar) { Value = clsBusq.cod2 };
                pa[4] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsBusq.cod3 };
                pa[5] = new SqlParameter("@codSubConsulta", SqlDbType.VarChar) { Value = clsBusq.cod4 };
                pa[6] = new SqlParameter("@cBuscar", SqlDbType.VarChar) { Value = clsBusq.cBuscar };
                pa[7] = new SqlParameter("@numPagina", SqlDbType.VarChar) { Value = clsBusq.numPagina };
                pa[8] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = clsBusq.tipoCon };
                pa[9] = new SqlParameter("@chkHabilitarFecha", SqlDbType.TinyInt) { Value = clsBusq.chkActivarFechas };
                pa[10] = new SqlParameter("@chkDiaEspecifico", SqlDbType.TinyInt) { Value = clsBusq.chkActivarDia };

                objCnx = new clsConexion("");

                dt = objCnx.EjecutarProcedimientoDT("uspBuscarVentasCaja", pa);
                foreach (DataRow dr in dt.Rows)
                {
                    lsRepBloque.Add(new ReporteBloque
                    {
                        Codigoreporte = dr["id"].ToString(),
                        Detallereporte = dr["descripcion"].ToString(),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        idMoneda = Convert.ToInt32(dr["idMoneda"]),
                        SimboloMoneda = dr["cSimbolo"].ToString(),
                        ImporteTipoCambio = Convert.ToDecimal(dr["cTipoCambio"]),
                        ImporteRow = Convert.ToDecimal(dr["montoTotal"])
                    });
                }

                return lsRepBloque;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public List<ReporteBloque> daBuscarOtrosIngresos(Busquedas clsBusq)
        {
            SqlParameter[] pa = new SqlParameter[0];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            List<ReporteBloque> lsRepBloque = new List<ReporteBloque>();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                objCnx = new clsConexion("");

                dt = objCnx.EjecutarProcedimientoDT("uspBuscarOtrosIngresos", pa);
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    lsRepBloque.Add(new ReporteBloque
                    {
                        numero = i + 1,
                        Codigoreporte = dr["codigoTipoPago"].ToString(),
                        codAuxiliar = dr["codigoOperacion"].ToString(),
                        MasDetallereporte = dr["nomTipoPago"].ToString(),
                        Detallereporte = dr["nomOperacion"].ToString(),
                        Cantidad = Convert.ToInt32(dr["unidades"]),
                        idMoneda = Convert.ToInt32(dr["idMoneda"]),
                        SimboloMoneda = dr["simboloMoneda"].ToString(),
                        ImporteTipoCambio = Convert.ToDecimal(dr["importeCambio"]),
                        ImporteRow = Convert.ToDecimal(dr["importe"])
                    }) ;
                    i++;
                }

                return lsRepBloque;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public List<ReporteBloque> daBuscarAccionCaja(String  dtt, Int32 idUsuario, Int32 TipoOpe)
        {
            SqlParameter[] pa = new SqlParameter[3];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            List<ReporteBloque> lsRepBloque = new List<ReporteBloque>();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = idUsuario };
                pa[1] = new SqlParameter("@dtFecha", SqlDbType.Date) { Value = dtt };
                pa[2] = new SqlParameter("@tipoCon", SqlDbType.Int) { Value = TipoOpe };
                
                objCnx = new clsConexion("");

                dt = objCnx.EjecutarProcedimientoDT("uspAccioncajaActualizacion", pa);
                foreach (DataRow dr in dt.Rows)
                {
                    lsRepBloque.Add(new ReporteBloque
                    {
                        Codigoreporte = dr["id"].ToString(),
                        Detallereporte = dr["descripcion"].ToString(),
                        idAuxiliar =Convert.ToInt32(dr["IdUsuario"]),
                        cUsuario = dr["cUser"].ToString(),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        idMoneda = Convert.ToInt32(dr["idMoneda"]),
                        SimboloMoneda = dr["cSimbolo"].ToString(),
                        ImporteTipoCambio = Convert.ToDecimal(dr["cTipoCambio"]),
                        ImporteRow = Convert.ToDecimal(dr["montoTotal"])
                    });
                }

                return lsRepBloque;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public List<Cargo> daBuscarTipoOpciones(String cod, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            List<ReporteBloque> lsRepBloque = new List<ReporteBloque>();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                
                pa[0] = new SqlParameter("@codTipoOperacion", SqlDbType.VarChar) { Value = cod };                
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int) { Value = tipoCon };

                objCnx = new clsConexion("");

                dt = objCnx.EjecutarProcedimientoDT("uspBuscarTipoOperacionCaja", pa);
                List<Cargo> lstCargo = new List<Cargo>();

                foreach (DataRow drMenu in dt.Rows)
                {
                    lstCargo.Add(new Cargo(
                        Convert.ToString(drMenu["cCodTab"]),
                        Convert.ToString(drMenu["cNomTab"]),
                        Convert.ToString(drMenu["cValor"]),
                        Convert.ToString(drMenu["nValor1"])
                        
                        )
                        );
                }

                return lstCargo;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public Boolean daGuardarCierreCaja(List<xmlActaCierraCaja> xmlacta, List<CuadreCaja> lstApertura, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[7];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            List<ReporteBloque> lsRepBloque = new List<ReporteBloque>();
            objUtil = new clsUtil();
            clsConexion objCnx = null;
            //xmlacta[0].dtFechaRegistro = Convert.ToDateTime("18/11/2022 19:51:33");
            String xmlActaCierreCaja = clsUtil.Serialize(xmlacta);
            //String xmlApertura = clsUtil.Serialize(lstApertura);
            try
            {
                pa[0] = new SqlParameter("@dtFechaRegistro", SqlDbType.DateTime) { Value = xmlacta[0].dtFechaRegistro };                
                pa[1] = new SqlParameter("@xmlActaCierre", SqlDbType.Xml) { Value = xmlActaCierreCaja };
                pa[2] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = xmlacta[0].idUsuario };
                pa[3] = new SqlParameter("@idSucursal", SqlDbType.Int) { Value = xmlacta[0].idSucursal };
                pa[4] = new SqlParameter("@ImporteCierre", SqlDbType.Money) { Value = xmlacta[0].ListaCuadreCaja[0].importeSaldo };
                pa[5] = new SqlParameter("@idTranApertura", SqlDbType.Int) { Value = lstApertura[0].idTrandiaria };

                pa[6] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = tipoCon };

                objCnx = new clsConexion("");
                dt = objCnx.EjecutarProcedimientoDT("uspGuardarCierreCaja", pa);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
    }
}
