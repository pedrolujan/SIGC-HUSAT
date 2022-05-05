using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaConexion;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using CapaUtil;

namespace CapaDato
{
    public class DACargo
    {
        public DACargo() { }
        private clsUtil objUtil = null;

        public List<Cargo> daDevolverCargo(String cCodTab)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecCodTab", SqlDbType.NVarChar,8);
                pa[0].Value = cCodTab;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarCargo", pa);

                List<Cargo> lstCargo = new List<Cargo>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstCargo.Add(new Cargo(Convert.ToString(drMenu["cCodTab"]), Convert.ToString(drMenu["cNomTab"]),
                           Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstCargo;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACargo.cs", "daDevolverCargo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public String daGrabarCargo(Cargo objCargo, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[6];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecCodTab", SqlDbType.NVarChar, 8);
                pa[0].Value = objCargo.cCodTab;
                pa[1] = new SqlParameter("@pecNomTab", SqlDbType.NVarChar, 200);
                pa[1].Value = objCargo.cNomTab;
                pa[2] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[2].Value = objCargo.bEstado;
                pa[3] = new SqlParameter("@pedFechaReg", SqlDbType.DateTime);
                pa[3].Value = objCargo.dFechaReg;
                pa[4] = new SqlParameter("@peiIdUsuario", SqlDbType.Int);
                pa[4].Value = objCargo.idUsuario;
                pa[5] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[5].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspRegistrarCargo", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACargo.cs", "daGrabarCargo", ex.Message);
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

        public List<Cargo> daDevolverTablaCod(String cCodTab)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecCodTab", SqlDbType.NVarChar, 8);
                pa[0].Value = cCodTab;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarTablaCod", pa);

                List<Cargo> lstCargo = new List<Cargo>();
                lstCargo.Add(new Cargo(
                        Convert.ToString("0"),
                        Convert.ToString("Seleccione opcion"),
                        Convert.ToString("1")));

                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstCargo.Add(new Cargo(
                        Convert.ToString(drMenu["cCodTab"]),
                        Convert.ToString(drMenu["cNomTab"]),
                        Convert.ToString(drMenu["cValor"])));
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

        public List<Cargo> daDevolverTablaCodTipoCon(String cCodTab,Boolean buscar)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecCodTab", SqlDbType.NVarChar, 8);
                pa[0].Value = cCodTab;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarTablaCod", pa);

                List<Cargo> lstCargo = new List<Cargo>();
                lstCargo.Add(new Cargo(
                        Convert.ToString("0"),
                        Convert.ToString(buscar ? "TODOS" : "Selecc. opcion"),
                        Convert.ToString("1")));

                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstCargo.Add(new Cargo(
                        Convert.ToString(drMenu["cCodTab"]),
                        Convert.ToString(drMenu["cNomTab"]),
                        Convert.ToString(drMenu["cValor"])));
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
        public List<Cargo> daDevolverUsuarioPorCargo(String cCodTab,Boolean buscar)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@codcargo", SqlDbType.NVarChar, 8);
                pa[0].Value = cCodTab;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspObtenerUsuarioPorTipoCargo", pa);

                List<Cargo> lstCargo = new List<Cargo>();
                lstCargo.Add(new Cargo(
                        Convert.ToString("0"),
                        Convert.ToString(buscar ? "TODOS" : "Selecc. opcion"),
                        Convert.ToString("1")));

                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstCargo.Add(new Cargo(
                        Convert.ToString(drMenu["idUsuario"]),
                        Convert.ToString(drMenu["personal"]),
                        Convert.ToString(drMenu["idUsuario"])));
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

        public String daDevolverCorrelativo(String cCodTab)
        {

            String lcCorrelativo = "";
            SqlParameter[] pa = new SqlParameter[2];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecCodDocVenta", SqlDbType.NVarChar, 8);
                pa[0].Value = cCodTab;
                pa[1] = new SqlParameter("@pecCodCorrela", SqlDbType.NVarChar, 20);
                pa[1].Direction = ParameterDirection.Output ;


                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspVerCorrelativo", pa);

                lcCorrelativo = pa[1].Value.ToString().Trim();

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACargo.cs", "daDevolverCorrelativo", ex.Message);
                lcCorrelativo = "XX";
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

            return lcCorrelativo;

        }

    }
}
