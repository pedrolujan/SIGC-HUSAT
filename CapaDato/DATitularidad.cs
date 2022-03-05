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
    public class DATitularidad
    {
        private clsUtil objUtil;
        private object pcBuscar;

        public DataTable DABuscarTitularidad(Int32 TipoCon, String pcBuscar)
        {
            DataTable dtResul = new DataTable();
            SqlParameter[] pa = new SqlParameter[2];

            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {

                pa[0] = new SqlParameter("@PCBuscar", SqlDbType.VarChar, 30);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@TipoCon", SqlDbType.Int);
                pa[1].Value = TipoCon;
                objCnx = new clsConexion("");
                
                dtResul = objCnx.EjecutarProcedimientoDT("uspBuscarTitularidad", pa);
                return dtResul;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;

            }
        }
        public DataTable daBuscarTilularidadEspecificos(Int32 condicion,Int32 idventageneral)
        {
            DATitularidad daobjEquipo = new DATitularidad();
            try
            {
                return daobjEquipo.daBuscarTilularidadEspecificos(condicion, idventageneral);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public DataTable BlBuscarTitularidad(int cond, string buscarDato)
        {
            throw new NotImplementedException();
        }
    }

}
