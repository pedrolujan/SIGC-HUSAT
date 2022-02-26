using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaConexion;
using CapaUtil;
using System.Data.SqlClient;

namespace CapaDato
{
    public class DAAcceso
    {
   
        private clsUtil objUtil = null;

        private Int16 fnAccederSistema(String pcUsuario, String pcClave, out Int32 pnIdUsuario)
        {

            SqlParameter[] pa = new SqlParameter[4];
            clsConexion objCon = null;
            Int16 idAccede = 0;
            objUtil = new clsUtil();
            try
            {

                objCon = new clsConexion("");

                pa[0] = new SqlParameter("@pecUsuario", SqlDbType.NVarChar,20);
                pa[0].Value = pcUsuario;
                pa[1] = new SqlParameter("@pecClave", SqlDbType.VarChar, 20);
                pa[1].Value = pcClave;
                pa[2] = new SqlParameter("@psbAcceder", SqlDbType.SmallInt);
                pa[2].Direction = ParameterDirection.Output;
                pa[3] = new SqlParameter("@psiIdUsuario", SqlDbType.Int);
                pa[3].Direction = ParameterDirection.Output;

                objUtil.gsLogAplicativo("DAAcceso.svc", "fnAccederSistema", "Antes de verificar usuario y clave" + pcUsuario);
                objCon.EjecutarProcedimientoDS("uspAccederSistema", pa);
                idAccede = Convert.ToInt16(pa[2].Value);
                pnIdUsuario = Convert.ToInt32(pa[3].Value);
                objUtil.gsLogAplicativo("DAAcceso.svc", "fnAccederSistema", "Despues de acceder verificar usuario y clave" + pcUsuario);
                return idAccede;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAcceso.svc", "fnAccederSistema", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCon != null)
                    objCon.CierraConexion();
                objCon = null;
            }
        
        }

        public String DAValidarIngreso(DateTime pdFechaSis,String pstrUsuario, String pstrClave, String pstrMaquina, String pstrVersion, Int32 pintApli,out Int32 pnidUsuario)
        {

            //clsValidaDomWin.valida objval = new clsValidaDomWin.valida();
            Int16 blnUsuario = 0;
            Int32 idUsuario = 0;
            SqlParameter[] pa = new SqlParameter[1];
            clsConexion objCon = null;
            DateTime dtmFecha;
            DataTable dtResp = new DataTable();
            objUtil = new clsUtil();
            try
            {
                dtmFecha = pdFechaSis;
                try
                {
                    objUtil.gsLogAplicativo("DAAcceso.svc", "DAValidarIngreso", "Antes de llamr - ValidaUsuarioClaveDominio ");
                    blnUsuario = fnAccederSistema(pstrUsuario, pstrClave, out idUsuario);
                    pnidUsuario = idUsuario;

                    
                }
                catch (Exception ex)
                {
                    pnidUsuario = 0;
                    objUtil.gsLogAplicativo("DAAcceso.svc", "DAValidarIngreso", "Error al validar en Dominio." + ex.Message);
                    return  "Error al validar en Dominio.";
                }

                
                if (blnUsuario == 1)
                {
                            try
                            {
                                objUtil.gsLogAplicativo("DAAcceso.svc", "DAValidarIngreso", "Antes de llamar metodo de registro de logeo");
                                if (DARegistrarLogueo(idUsuario, dtmFecha, dtmFecha, pstrMaquina, pstrVersion, pintApli) == true)
                                {
                                    objUtil.gsLogAplicativo("DAAcceso.svc", "DAValidarIngreso", "OK-correcto");
                                    return "OK";
                                }
                                else {
                                    objUtil.gsLogAplicativo("DAAcceso.svc", "DAValidarIngreso", "No se registro Logueo.");
                                    return  "No se registro Logueo."; }
                            }
                            catch (Exception ex)
                            {
                                objUtil.gsLogAplicativo("DAAcceso.svc", "DAValidarIngreso", "Error al Registrar Logueo. Comunicar a TI." + ex.Message);
                                return "Error al Registrar Logueo. Comunicar a TI.";
                            }
                }
                else if (blnUsuario == 0)
                {
                     objUtil.gsLogAplicativo("DAAcceso.svc", "DAValidarIngreso", "No se encuentra parametro de Logueo.");
                     return "No se encuentra parametro de Logueo"; 
                }
                else if (blnUsuario == 2)
                {
                    objUtil.gsLogAplicativo("DAAcceso.svc", "DAValidarIngreso", "Contraseña Inválida.");
                    return "Contraseña Inválida.";
                }
                else if (blnUsuario == 3)
                {
                    objUtil.gsLogAplicativo("DAAcceso.svc", "DAValidarIngreso", "Usuario no Registrado.");
                    return "Usuario no Registrado.";
                }
                else if (blnUsuario == 4)
                {
                    objUtil.gsLogAplicativo("DAAcceso.svc", "DAValidarIngreso", "Usuario Inactivo. Comunicar a Administrador de Sistema");
                    return "Usuario Inactivo. Comunicar a Administrador de Sistema";
                }
                else
                {
                    objUtil.gsLogAplicativo("DAAcceso.svc", "DAValidarIngresoMovil", "Ingrese usuario y clave nuevamente");
                    return "Ingrese usuario y clave nuevamente";
                }

            }
            catch (Exception ex)
            {
                pnidUsuario = 0;
                objUtil.gsLogAplicativo("DAAcceso.svc", "DAValidarIngresoMovil", "Error al obtener Fecha. Comunicar a TI." + ex.Message);
                return "Error al obtener Fecha. Comunicar a TI."; 
            }
        }

        public Boolean DARegistrarLogueo(Int32 pstrUser, DateTime  pdtmFechaIni, DateTime pdtmFechaFin, String pstrMaquina, String pstrVersion, Int32 pintApli)
        {
            SqlParameter[] pa = new SqlParameter[6];
            clsConexion objCon = null;
            Boolean blnResultado = false;
            objUtil = new clsUtil();
            try
            {

                objCon = new clsConexion("");

                pa[0] = new SqlParameter("@peiidUsuario", SqlDbType.Int);
                pa[0].Value = pstrUser;
                pa[1] = new SqlParameter("@pedFecIni", SqlDbType.DateTime);
                pa[1].Value = pdtmFechaIni;
                pa[2] = new SqlParameter("@pedFin", SqlDbType.DateTime);
                pa[2].Value = pdtmFechaFin;
                pa[3] = new SqlParameter("@pecMaquina", SqlDbType.VarChar, 100);
                pa[3].Value = pstrMaquina;
                pa[4] = new SqlParameter("@pecVersion", SqlDbType.VarChar, 20);
                pa[4].Value = pstrVersion;
                pa[5] = new SqlParameter("@peiAplicacion", SqlDbType.Int);
                pa[5].Value = pintApli;

                objUtil.gsLogAplicativo("DAAcceso.svc", "DARegistrarLogueo", "Antes de registrar login uspRegistrarLogueoMovil" + pstrUser);
                objCon.EjecutarProcedimientoDS("uspRegistrarLogueo", pa);
                objUtil.gsLogAplicativo("DAAcceso.svc", "DARegistrarLogueo", "Despues de registrar login uspRegistrarLogueoMovil" + pstrUser);

                blnResultado = true;
                return blnResultado;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAcceso.svc", "DARegistrarLogueo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCon != null)
                    objCon.CierraConexion();
                objCon = null;
            }

        }

        public DataTable DAListarMenuAcceso(int pidAplicacion,string pidUsuario)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtAplicacion = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidAplicacion", SqlDbType.Int);
                pa[0].Value = pidAplicacion;
                pa[1] = new SqlParameter("@peidUsuario", SqlDbType.VarChar,20);
                pa[1].Value = pidUsuario;


                objCnx = new clsConexion("");
                dtAplicacion = objCnx.EjecutarProcedimientoDT("uspListarAcceso", pa);
                objCnx.CierraConexion();

                return dtAplicacion;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAcceso.cs", "DAListarMenuAcceso", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtAplicacion = null;
            }
        }

        public String DAGuardarAcceso(DataTable dtAcceso, string pcCodigo)
        {
            SqlParameter[] pa = new SqlParameter[2];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@petbAcceso", SqlDbType.Structured);
                pa[0].Value = dtAcceso;
                pa[1] = new SqlParameter("@peidUsuario", SqlDbType.VarChar,20);
                pa[1].Value = pcCodigo;
                

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarAcceso", pa);
                objCnx.CierraConexion();

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAcceso.cs", "DAGuardarAcceso", ex.Message);
                return "XX";
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                pa = null;
            }
        }
        public DataTable DABuscarCargousuario(Int32 idUsuario)
        {
            SqlParameter[] pa = new SqlParameter[1];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            DataTable dtResp = new DataTable();

            try
            {

                

                pa[0] = new SqlParameter("@pecIdUsuario", SqlDbType.Int);
                pa[0].Value = idUsuario;               

                objCnx = new clsConexion("");
                dtResp=objCnx.EjecutarProcedimientoDT("uspBuscarCargoUsuario", pa);
                

                objCnx.CierraConexion();

                return dtResp;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAcceso.cs", "DAGuardarAcceso", ex.Message);
                return dtResp;
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                pa = null;
            }
        }

    }
}
