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
        //public DataTable DABuscarClienteV(Int32 TipoCon, String pcBuscar)
        //{
        //    DataTable dtResul = new DataTable();
        //    SqlParameter[] pa = new SqlParameter[2];

        //    clsConexion objCnx = null;
        //    objUtil = new clsUtil();
        //    try
        //    {

        //        pa[0] = new SqlParameter("@PCBuscar", SqlDbType.VarChar, 30);
        //        pa[0].Value = pcBuscar;
        //        pa[1] = new SqlParameter("@TipoCon", SqlDbType.Int);
        //        pa[1].Value = TipoCon;
        //        objCnx = new clsConexion("");

        //        dtResul = objCnx.EjecutarProcedimientoDT("uspBuscarVentas", pa);
        //        return dtResul;
        //    }
        //    catch (Exception ex)
        //    {
        //        objUtil.gsLogAplicativo("DACliente.cs", "DAClienteVenta", ex.Message);

        //        throw new Exception(ex.Message);

        //    }

        //    finally
        //    {
        //        if (objCnx != null)
        //            objCnx.CierraConexion();
        //        objCnx = null;

        //    }

        //}
        public DataTable DAbuscarClienteV(Boolean habilitarfechas, DateTime fechaInical, DateTime fechaFinal, String placaVehiculo, String cEstadoInstal, Int32 numPagina, Int32 tipoLLamada, Int32 tipoCon, Int32 codTipoVenta, String estadoTipoContrato, 
            Boolean habilitarRenovaciones, String valorRadio,String estadoTipoPlan, String estadoPlan,String estadoUsuario)
        {
            SqlParameter[] pa = new SqlParameter[15];
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
                pa[8] = new SqlParameter("@codTipoVenta", SqlDbType.Int) { Value = codTipoVenta };
                pa[9] = new SqlParameter("@estadoTipoContrato", SqlDbType.NVarChar, 8) { Value = estadoTipoContrato };
                pa[10] = new SqlParameter("@pehabilitarRenovaciones", SqlDbType.TinyInt) { Value = habilitarRenovaciones };
                pa[11] = new SqlParameter("@valorRadio", SqlDbType.NVarChar, 8) { Value = valorRadio };             
                pa[12] = new SqlParameter("@plan", SqlDbType.NVarChar, 15) { Value = estadoPlan };
                pa[13] = new SqlParameter("@estadoTipoContrato", SqlDbType.VarChar) { Value = estadoTipoPlan };
                pa[14] = new SqlParameter("@Usuario", SqlDbType.VarChar) { Value = estadoUsuario };
                

                objCnx = new clsConexion("");
                if (habilitarRenovaciones == false)
                {
                    dtVenta = objCnx.EjecutarProcedimientoDT("uspBuscarRenovaciones", pa);
                }
                else
                {
                    dtVenta= objCnx.EjecutarProcedimientoDT("uspBuscarVentas", pa);
                }

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
