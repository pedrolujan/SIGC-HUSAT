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
    public class DAconsultas
    {
        private clsUtil objUtil = null;
        public DataTable daBuscarHistorialSimCard(String pcBuscar, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 30);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[1].Value = tipoCon;
                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarConsultas", pa);

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
            }

        }

        public DataTable daBuscarDatosEspecificos(Int32 dato, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dt = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pBuscar", SqlDbType.Int);
                pa[0].Value = dato;
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[1].Value = tipoCon;

                objCnx = new clsConexion("");
                dt = objCnx.EjecutarProcedimientoDT("uspBuscarDatosEspecificosConsultas", pa);

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
                
            }

        }
        
    }
}
