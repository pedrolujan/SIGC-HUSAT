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
    public class DAEgresos
    {
        public DAEgresos() { }
        clsUtil objUtil;
        public Boolean daGuardarEgresos(List<Pagos> lstTTrand)
        {
            SqlParameter[] pa = new SqlParameter[11];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            List<ReporteBloque> lsRepBloque = new List<ReporteBloque>();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            String xmlTrandiaria = clsUtil.Serialize(lstTTrand);
            try
            {
                //pa[0] = new SqlParameter("@dtFechaIni", SqlDbType.Date) { Value = clsBusq.dtFechaIni };
                //pa[1] = new SqlParameter("@dtFechaFin", SqlDbType.Date) { Value = clsBusq.dtFechaFin };
                //pa[2] = new SqlParameter("@codTipoReporte", SqlDbType.VarChar) { Value = clsBusq.cod1 };
                //pa[3] = new SqlParameter("@codTipoOperacion", SqlDbType.VarChar) { Value = clsBusq.cod2 };
                //pa[4] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsBusq.cod3 };
                //pa[5] = new SqlParameter("@codSubConsulta", SqlDbType.VarChar) { Value = clsBusq.cod4 };
                //pa[6] = new SqlParameter("@cBuscar", SqlDbType.VarChar) { Value = clsBusq.cBuscar };
                //pa[7] = new SqlParameter("@numPagina", SqlDbType.VarChar) { Value = clsBusq.numPagina };
                //pa[8] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = clsBusq.tipoCon };
                //pa[9] = new SqlParameter("@chkHabilitarFecha", SqlDbType.TinyInt) { Value = clsBusq.chkActivarFechas };
                //pa[10] = new SqlParameter("@chkDiaEspecifico", SqlDbType.TinyInt) { Value = clsBusq.chkActivarDia };

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
                        ImporteTipoCambio = Convert.ToDouble(dr["cTipoCambio"]),
                        ImporteRow = Convert.ToDouble(dr["montoTotal"])
                    });
                }

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
