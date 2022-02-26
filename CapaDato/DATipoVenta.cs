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
    public class DATipoVenta
    {
        public DATipoVenta() { }

        private clsUtil objUtil = null;
        public DataTable daBuscarTipoVenta(String pcBuscar, List<TipoVenta> lsTipoVenta,Int32 numPaginacion,Int32 tipocon)
        {
            SqlParameter[] pa = new SqlParameter[7];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            List<Equipo> lstEquipo = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@idTipoVenta", SqlDbType.VarChar, 8);
                pa[1].Value = lsTipoVenta[0].idTipoVenta;
                pa[2] = new SqlParameter("@BuscarXFechas", SqlDbType.TinyInt);
                pa[2].Value = lsTipoVenta[0].BuscarXFechas;
                pa[3] = new SqlParameter("@dFechaInicio", SqlDbType.DateTime);
                pa[3].Value = lsTipoVenta[0].dFechaInicio;
                pa[4] = new SqlParameter("@dFechaFinal", SqlDbType.DateTime);
                pa[4].Value = lsTipoVenta[0].dFechaFinal;
                pa[5] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[5].Value = numPaginacion;
                pa[6] = new SqlParameter("@peiTipoConPagima", SqlDbType.Int);
                pa[6].Value = tipocon;


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarDatosTipoVenta", pa);


                return dtEquipo;

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
                lstEquipo = null;
            }

        }
        public DataTable daDevolverTipoVenta(String TipoVenta, Int32 idObjVenta)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idTipoVenta", SqlDbType.VarChar, 8);
                pa[0].Value = TipoVenta;
                pa[1] = new SqlParameter("@idObjVenta", SqlDbType.Int);
                pa[1].Value = idObjVenta;
                


                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspDevolverDatosTipoVenta", pa);


                return dtEquipo;

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
