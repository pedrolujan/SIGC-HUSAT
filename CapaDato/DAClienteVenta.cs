using CapaConexion;
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
    public class DAClienteVenta
    {
        private clsUtil objUtil;
        private object pcBuscar;
       
        public DataTable DAbuscarClienteV(Boolean habilitarfechas, DateTime fechaInical, DateTime fechaFinal, String placaVehiculo, String cEstadoInstal, Int32 numPagina, Int32 tipoLLamada, Int32 tipoCon, Int32 codTipoVenta, String estadoTipoContrato, 
            Boolean habilitarRenovaciones, String valorRadio, Int32 estadoTipoPlan, Int32 estadoPlan, Int32 estadoUsuario, String estadoContrato,String Docventapago)
       {
            SqlParameter[] pa = new SqlParameter[17];
            DataTable dtVenta;
            clsConexion objCnx = null;

            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peHabilitarFechas", SqlDbType.TinyInt) { Value = habilitarfechas };
                pa[1] = new SqlParameter("@peFechaInical", SqlDbType.DateTime) { Value = fechaInical };
                pa[2] = new SqlParameter("@peFechaFinal", SqlDbType.DateTime) { Value = fechaFinal };
                pa[3] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 15) { Value = placaVehiculo };
                pa[4] = new SqlParameter("@pcEstadoInstal", SqlDbType.VarChar, 15) { Value = cEstadoInstal };
                pa[5] = new SqlParameter("@numPagina", SqlDbType.Int) { Value = numPagina };
                pa[6] = new SqlParameter("@tipoLLamada", SqlDbType.Int) { Value = tipoLLamada };
                pa[7] = new SqlParameter("@tipoCon", SqlDbType.Real) { Value = tipoCon };                
                pa[8] = new SqlParameter("@Usuario", SqlDbType.VarChar) { Value = estadoUsuario };
                pa[9] = new SqlParameter("@estadoTipoContrato", SqlDbType.NVarChar, 8) { Value = estadoTipoContrato };
                pa[10] = new SqlParameter("@pehabilitarRenovaciones", SqlDbType.TinyInt) { Value = habilitarRenovaciones };
                pa[11] = new SqlParameter("@valorRadio", SqlDbType.NVarChar) { Value = valorRadio };             
                pa[12] = new SqlParameter("@plan", SqlDbType.Int) { Value = estadoPlan };
                pa[13] = new SqlParameter("@TipoPlan", SqlDbType.Int) { Value = estadoTipoPlan };
                pa[14] = new SqlParameter("@codTipoVenta", SqlDbType.Int) { Value = codTipoVenta };
                pa[15]=new SqlParameter("@estadoTipoContratoVenta", SqlDbType.NVarChar, 8) { Value = estadoContrato };
                pa[16] = new SqlParameter("@estadoTipoDocVenta", SqlDbType.NVarChar, 8) { Value = Docventapago };



                objCnx = new clsConexion("");
                
                
                    dtVenta= objCnx.EjecutarProcedimientoDT("uspBuscarVentas", pa);
                

                return dtVenta;
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
