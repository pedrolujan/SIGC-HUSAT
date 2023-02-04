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
        public Boolean daGuardarEgresos(List<Pagos> lstTTrand, List<xmlDocumentoVentaGeneral> xmlDvg, Egresos clsEgresos)
        {
            SqlParameter[] pa = new SqlParameter[12];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            
            String xmlTrandiaria = clsUtil.Serialize(lstTTrand);
            String xmlDocumetoVenta = clsUtil.Serialize(xmlDvg);
            String xmlDetalelVenta = clsUtil.Serialize(xmlDvg[0].xmlDetalleVentas);
            try
            {
                pa[0] = new SqlParameter("@idEgreso", SqlDbType. Int) { Value = clsEgresos.idEgreso };
                pa[1] = new SqlParameter("@codCargoConcepto", SqlDbType.VarChar,12) { Value = clsEgresos.cargo };
                pa[2] = new SqlParameter("@dtFechaRegistro", SqlDbType.Date) { Value = lstTTrand[0].dFechaRegistro };
                pa[3] = new SqlParameter("@idUsuarioReceptor", SqlDbType.Int) { Value = clsEgresos.UsuarioReceptor };
                pa[4] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = lstTTrand[0] .idUsario};
                pa[5] = new SqlParameter("@idMoneda", SqlDbType.Int) { Value = lstTTrand[0] .idMoneda};
                pa[6] = new SqlParameter("@penMontoPagar", SqlDbType.Money) { Value = lstTTrand[0].cantAPagar};
                pa[7] = new SqlParameter("@xmlDocumentoVenta", SqlDbType.Xml) { Value = xmlDocumetoVenta };
                pa[8] = new SqlParameter("@xmlTrandiaria", SqlDbType.Xml) { Value = xmlTrandiaria };
                pa[9] = new SqlParameter("@xmlDetalleVenta", SqlDbType.Xml) { Value = xmlDetalelVenta };
                pa[10] = new SqlParameter("@lnTipoCon", SqlDbType.Int) { Value = clsEgresos.lnTipoCon };
                pa[11] = new SqlParameter("@CodAuxiliar", SqlDbType.VarChar,10) { Value = clsEgresos.codAuxiliar };
               

                objCnx = new clsConexion("");

                Int32 rows = objCnx.EjecutarProcedimiento("uspGuardarEgresos_Ingresos", pa);
                //Int32 rows = 0;
                if (rows>0)
                {
                    return true;

                }
                else
                {
                    return true;
                }

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
