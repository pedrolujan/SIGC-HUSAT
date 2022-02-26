using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaUtil;
using System.Data.SqlClient;
using System.Data;
using CapaConexion;

namespace CapaDato
{
    public class DAVentaMesa
    {

        public DAVentaMesa() { }

        clsUtil objUtil = null;

        public String daGrabarVentaMesa(VentaMesa objDocVenta)
        {
            SqlParameter[] pa = new SqlParameter[11];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecCodMesa", SqlDbType.VarChar,8);
                pa[0].Value = objDocVenta.cCodTab;
                pa[1] = new SqlParameter("@peidCliente", SqlDbType.Int);
                pa[1].Value = objDocVenta.idCliente;
                pa[2] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[2].Value = objDocVenta.idSucursal;
                pa[3] = new SqlParameter("@penCantidad", SqlDbType.Decimal);
                pa[3].Value = objDocVenta.nCantidad;
                pa[4] = new SqlParameter("@pemPrecioVenta", SqlDbType.Money);
                pa[4].Value = objDocVenta.mPrecioVenta;
                pa[5] = new SqlParameter("@penMontoTotal", SqlDbType.Money);
                pa[5].Value = objDocVenta.mMontoTotal;
                pa[6] = new SqlParameter("@penMontoPagar", SqlDbType.Money);
                pa[6].Value = objDocVenta.mMontoPagar;
                pa[7] = new SqlParameter("@pecTipoPago", SqlDbType.VarChar,8);
                pa[7].Value = objDocVenta.cTipoPago;
                pa[8] = new SqlParameter("@pecEstado", SqlDbType.VarChar, 8);
                pa[8].Value = objDocVenta.cEstado;
                pa[9] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[9].Value = objDocVenta.idUsuario;
                pa[10] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[10].Value = objDocVenta.dFechaRegistro;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarVentaxMesa", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAVentaMesa.cs", "daGrabarVentaMesa", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
                objDocVenta = null;

            }

        }

        public String daGrabarVentaMesaMasiva(DataTable dtVenta,string pcTipoPago,decimal mMontoTotal, decimal mMontoPagar)
        {
            SqlParameter[] pa = new SqlParameter[4];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@tbVenta", SqlDbType.Structured);
                pa[0].Value = dtVenta;
                pa[1] = new SqlParameter("@pecTipoPago", SqlDbType.VarChar,8);
                pa[1].Value = pcTipoPago;
                pa[2] = new SqlParameter("@pemMontoTotal", SqlDbType.Money);
                pa[2].Value = mMontoTotal;
                pa[3] = new SqlParameter("@pemMontoPagar", SqlDbType.Money);
                pa[3].Value = mMontoPagar;
                

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuadarVentaMasiva", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAVentaMesa.cs", "daGrabarVentaMesaMasiva", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;

            }

        }

        public String daGrabarVentaxMayor(VentaMayor objDocVenta)
        {
            SqlParameter[] pa = new SqlParameter[13];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidVentaxMayor", SqlDbType.Int);
                pa[0].Value = objDocVenta.idVentaMayor;
                pa[1] = new SqlParameter("@peidLote", SqlDbType.Int);
                pa[1].Value = objDocVenta.idLote;
                pa[2] = new SqlParameter("@peidCliente", SqlDbType.Int);
                pa[2].Value = objDocVenta.idCliente;
                pa[3] = new SqlParameter("@peidSucursal", SqlDbType.SmallInt);
                pa[3].Value = objDocVenta.idSucursal;
                pa[4] = new SqlParameter("@penCantidad", SqlDbType.Decimal);
                pa[4].Value = objDocVenta.nCantidad;
                pa[5] = new SqlParameter("@penCantidadUM", SqlDbType.Decimal);
                pa[5].Value = objDocVenta.nCantidadUM;
                pa[6] = new SqlParameter("@pemPrecioVenta", SqlDbType.Money);
                pa[6].Value = objDocVenta.mPrecioVenta;
                pa[7] = new SqlParameter("@penMontoTotal", SqlDbType.Money);
                pa[7].Value = objDocVenta.mMontoTotal;
                pa[8] = new SqlParameter("@penMontoPagar", SqlDbType.Money);
                pa[8].Value = objDocVenta.mMontoPagar;
                pa[9] = new SqlParameter("@pecTipoPago", SqlDbType.VarChar, 8);
                pa[9].Value = objDocVenta.cTipoPago;
                pa[10] = new SqlParameter("@pecEstado", SqlDbType.VarChar, 8);
                pa[10].Value = objDocVenta.cEstado;
                pa[11] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[11].Value = objDocVenta.idUsuario;
                pa[12] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[12].Value = objDocVenta.dFechaRegistro;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarVentaxMayor", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAVentaMesa.cs", "daGrabarVentaxMayor", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
                objDocVenta = null;

            }

        }

    }
}
