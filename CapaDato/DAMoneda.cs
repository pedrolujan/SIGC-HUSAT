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
    public class DAMoneda
    {
        private clsUtil objUtil = null;

        public List<Moneda> daDevolverMoneda(Int32 idMoneda, Boolean buscar)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidMoneda", SqlDbType.Int) { Value = idMoneda };
              
                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarMoneda", pa);

                List<Moneda> lstCargo = new List<Moneda>();
                lstCargo.Add(new Moneda(
                        Convert.ToInt32("0"),
                        Convert.ToString(buscar ? "TODOS" : "Selecc. opcion"),
                        Convert.ToString(""),
                        Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstCargo.Add(new Moneda(
                        Convert.ToInt32(drMenu["idMoneda"]),
                        Convert.ToString(drMenu["cNombre"]),
                        Convert.ToString(drMenu["cSimbolo"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstCargo;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACargo.cs", "daDevolverTablaCod", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public CambioMonedaVenta daDevolverCambioMoneda(Int32 idMonedaReferencia, Double precioReferencia, Int32 idMonedaCambio)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtUsuario = new DataTable();
            CambioMonedaVenta clsCambioMoneda = null;
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@idMonedaReferencia", SqlDbType.Int) { Value = idMonedaReferencia };
                pa[1] = new SqlParameter("@precioReferencia", SqlDbType.Decimal) { Value = precioReferencia };
                pa[2] = new SqlParameter("@idMonedaCambio", SqlDbType.Int) { Value = idMonedaCambio };

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspConvertirPrecioVenta", pa);

                foreach (DataRow fila in dtUsuario.Rows)
                {
                    clsCambioMoneda = new CambioMonedaVenta(
                        Convert.ToDouble(fila["precioSalida"]), 
                        Convert.ToDouble(fila["precioCambio"])
                        );
                    
                }

                return clsCambioMoneda;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACargo.cs", "daDevolverTablaCod", ex.Message);
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
