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
   public class DAValidarDatosExistentes
    {
        private clsUtil objUtil = null;
        public Int16 daDevolverDatosExistentes(String pcBuscar, String pcBuscar2, Int16 pnTipoCon,String Procedimiento)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtDatosDuplicados = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 100);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@pecValorBuscar2", SqlDbType.VarChar, 100);
                pa[1].Value = pcBuscar2;
                pa[2] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[2].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtDatosDuplicados = objCnx.EjecutarProcedimientoDT(Procedimiento, pa);
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
    }
}
