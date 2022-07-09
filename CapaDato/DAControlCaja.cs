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
    public class DAControlCaja
    {
        public DAControlCaja() { }
        clsUtil objUtil;
        public List<ControlCaja> daFnLlenarTipoPago(Int32 idTipPlan,String id, Boolean estado)
        {
            SqlParameter[] pa = new SqlParameter[2];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@codTipoPago", SqlDbType.VarChar) { Value = id };
                pa[1] = new SqlParameter("@idTipPlan", SqlDbType.Int) { Value =  idTipPlan };
                objCnx = new clsConexion("");

                dt = objCnx.EjecutarProcedimientoDT("uspListarTipoPaPago", pa);

                lstControl.Add(new ControlCaja
                {
                    codTipoPago = "0",
                    descripTipoPago =Convert.ToString(estado == true ? "TODOS" : "Selec. Opcion"),
                    estado=false

                }); 

                foreach (DataRow d in dt.Rows)
                {
                    lstControl.Add(new ControlCaja
                    {
                        codTipoPago=d["cCodTab"].ToString(),
                        descripTipoPago=d["cNomTab"].ToString(),
                        estado=Convert.ToBoolean(d["bEstado"])
                    });

                }
                return lstControl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public DataTable daFnBuscarVentasCaja(Busquedas clsBus)
        {
            SqlParameter[] pa = new SqlParameter[12];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@chkHabilitarFecha", SqlDbType.TinyInt) { Value = clsBus.chkActivarFechas }; 
                pa[1] = new SqlParameter("@chkDiaEspecifico", SqlDbType.TinyInt) { Value = clsBus.chkActivarDia }; 
                pa[2] = new SqlParameter("@dtFechaIni", SqlDbType.Date) { Value = clsBus.dtFechaIni };
                pa[3] = new SqlParameter("@dtFechaFin", SqlDbType.Date) { Value = clsBus.dtFechaFin };
                pa[4] = new SqlParameter("@codTipoReporte", SqlDbType.VarChar) { Value = clsBus.cod1 };
                pa[5] = new SqlParameter("@codTipoOperacion", SqlDbType.VarChar) { Value = clsBus.cod2 };
                pa[6] = new SqlParameter("@codTipoPago", SqlDbType.VarChar) { Value = clsBus.cod3 };
                pa[7] = new SqlParameter("@idEntidadPago", SqlDbType.Int) { Value = clsBus.cod4 };
                pa[8] = new SqlParameter("@cBuscar", SqlDbType.VarChar) { Value = clsBus.cBuscar }; 
                pa[9] = new SqlParameter("@numPagina", SqlDbType.VarChar) { Value = clsBus.numPagina }; 
                pa[10] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = clsBus.tipoCon }; 
                pa[11] = new SqlParameter("@idUsuario", SqlDbType.TinyInt) { Value = clsBus.idUsuario }; 

                 objCnx = new clsConexion("");

                return dt = objCnx.EjecutarProcedimientoDT("uspBuscarDetalleReporteVentas", pa);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public List<ReporteBloque> daBuscarReporteGeneralVentas(Busquedas clsBusq)
        {
            SqlParameter[] pa = new SqlParameter[12];
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
                pa[6] = new SqlParameter("@idTipoTarifa", SqlDbType.Int) { Value = 0 };
                pa[7] = new SqlParameter("@cBuscar", SqlDbType.VarChar) { Value = clsBusq.cBuscar }; 
                pa[8] = new SqlParameter("@numPagina", SqlDbType.VarChar) { Value = clsBusq.numPagina }; 
                pa[9] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = clsBusq.tipoCon }; 
                pa[10] = new SqlParameter("@chkHabilitarFecha", SqlDbType.TinyInt) { Value = clsBusq.chkActivarFechas }; 
                pa[11] = new SqlParameter("@chkDiaEspecifico", SqlDbType.TinyInt) { Value = clsBusq.chkActivarDia }; 

                 objCnx = new clsConexion("");

                dt = objCnx.EjecutarProcedimientoDT("uspBuscarReporteGeneralVentas", pa);
                foreach (DataRow dr in dt.Rows)
                {
                    lsRepBloque.Add(new ReporteBloque
                    {
                        Codigoreporte=dr["id"].ToString(),
                        Detallereporte=dr["descripcion"].ToString(),
                        Cantidad=Convert.ToInt32(dr["cantidad"]),
                        idMoneda=Convert.ToInt32(dr["idMoneda"]),
                        SimboloMoneda=dr["cSimbolo"].ToString(),
                        ImporteTipoCambio=Convert.ToDouble(dr["cTipoCambio"]),
                        ImporteRow=Convert.ToDouble(dr["montoTotal"])
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

        public DataTable daDevolverSoloUsuario(Boolean chk, String dtI, String dtFin)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<Usuario> lstUsuario = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@dtInicio", SqlDbType.Date);
                pa[0].Value = dtI;
                pa[1] = new SqlParameter("@dtFin", SqlDbType.Date);
                pa[1].Value = dtFin;
                pa[2] = new SqlParameter("@chk", SqlDbType.Bit);
                pa[2].Value = chk;


                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarUsuariosConTrandiarias", pa);

                

                return dtVehiculo;

            }
            catch (Exception ex)
            {
                lstUsuario = null;
                objUtil.gsLogAplicativo("DAAttrVehiculo.cs", "daDevolverClaseV", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstUsuario = null;
            }

        }
    }
}
