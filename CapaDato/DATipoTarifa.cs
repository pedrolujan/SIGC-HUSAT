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
    public class DATipoTarifa
    {
        private clsUtil objUtil = null;

        public List<TipoTarifa> daListarTipoTarifa(Int32 idTipoTarifa, Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidTipoTarifa", SqlDbType.Int) { Value = idTipoTarifa };

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarTipoTarifa", pa);

                List<TipoTarifa> lstCargo = new List<TipoTarifa>();
                lstCargo.Add(new TipoTarifa(
                        Convert.ToInt32("0"),
                        Convert.ToString(buscar ? "TODOS" : "Selecc. opcion"),
                        Convert.ToBoolean(1)));

                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    //if (Convert.ToInt32(drMenu["idTipoTarifa"])!=2)
                    //{
                        lstCargo.Add(new TipoTarifa(
                       Convert.ToInt32(drMenu["idTipoTarifa"]),
                       Convert.ToString(drMenu["nombre"]),
                       Convert.ToBoolean(drMenu["estado"])));
                    //}
                   
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

        public Plan daListarTarifaDePlan(Int32 idPlan)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Plan clsPlan = new Plan();
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peIdPlan", SqlDbType.Int) { Value = idPlan };

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarTarifa", pa);
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    clsPlan.tarifas = Convert.ToString(drMenu["tarifas"]);  
                }
                return clsPlan;

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

        public Tarifa daListarPreciosTarifaDePlan(Int32 idPlan, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Tarifa clsTarifa = new Tarifa();
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peIdPlan", SqlDbType.Int) { Value = idPlan };
                pa[1] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = tipoCon };

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarTarifaDePlan", pa);
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    clsTarifa.IdTarifa = Convert.ToInt32(drMenu["idTarifa"]);
                    clsTarifa.IdTipoTarifa = Convert.ToInt32(drMenu["idTipoTarifa"]);
                    clsTarifa.IdMoneda = Convert.ToInt32(drMenu["idMoneda"]);
                    clsTarifa.PrecioEquipo = Convert.ToDouble(drMenu["precioEquipo"]);
                    clsTarifa.PrecioPlan = Convert.ToDouble(drMenu["precioPlan"]);
                    clsTarifa.PrecioReactivacion = Convert.ToDouble(drMenu["precioRenovaciones"]);
                }
                return clsTarifa;

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
        public Tarifa daListarPreciosTarifaDePlanPagosMensuales(Int32 idPlan, String CodVenta,Int32 idTipotarifa )
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Tarifa clsTarifa = new Tarifa();
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peIdPlan", SqlDbType.Int) { Value = idPlan };
                pa[1] = new SqlParameter("@CodVenta", SqlDbType.VarChar,15) { Value = CodVenta };
                pa[2] = new SqlParameter("@idTipotarifa", SqlDbType.Int) { Value = idTipotarifa };

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarTarifaDePlanPagoMensual", pa);
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    clsTarifa.IdTarifa = Convert.ToInt32(drMenu["idTarifa"]);
                    clsTarifa.IdTipoTarifa = Convert.ToInt32(drMenu["idTipoTarifa"]);
                    clsTarifa.IdMoneda = Convert.ToInt32(drMenu["idMoneda"]);
                    clsTarifa.PrecioEquipo = Convert.ToDouble(drMenu["precioEquipo"]);
                    clsTarifa.PrecioPlan = Convert.ToDouble(drMenu["precioPlan"]);
                    clsTarifa.PrecioReactivacion = Convert.ToDouble(drMenu["precioRenovaciones"]);
                }
                return clsTarifa;

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
