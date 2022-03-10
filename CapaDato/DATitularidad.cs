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
                objUtil.gsLogAplicativo("DACliente.cs", "DABuscarTitularidad", ex.Message);

                throw new Exception(ex.Message);

            }

            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;

            }

        }
        public DataTable daBuscarTilularidadEspecificos(Int32 condicion, Int32 idventageneral)
        {
            DATitularidad daobjEquipo = new DATitularidad();
            DataTable dtResul = new DataTable();
            SqlParameter[] pa = new SqlParameter[2];

            clsConexion objCnx = null;

            try
            {
                pa[0] = new SqlParameter("@pcBuscar", SqlDbType.VarChar);
                pa[0].Value = idventageneral;
                pa[1] = new SqlParameter("@TipoCon", SqlDbType.Int);
                pa[1].Value = condicion;

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

        public Int32 daGuardarClienteN(Titularidad clsTitu, Int32 tipocon)
        {
            SqlParameter[] pa = new SqlParameter[4];
            Int32 dt = 0;
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {

                pa[0] = new SqlParameter("@idCliente", SqlDbType.Int);
                pa[0].Value = clsTitu.listaCliente[0].idCliente;
                pa[1] = new SqlParameter("@idVehiculo", SqlDbType.Int);
                pa[1].Value = clsTitu.listaVehiculo[0].idVehiculo;
                pa[2] = new SqlParameter("@TipoCon", SqlDbType.NVarChar, 15);
                pa[2].Value = tipocon;
                pa[3] = new SqlParameter("@idVentaGeneral", SqlDbType.Int);
                pa[3].Value = clsTitu.idVentaGeneral;
                objCnx = new clsConexion("");
                dt = objCnx.EjecutarProcedimiento("uspGuardarTitularidad", pa);

                return dt;

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);

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
