using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion;
using System.Data;
using CapaUtil;
using System.Data.SqlClient;

namespace CapaDato
{
   public class DAMenu
    {

       private clsUtil objUtil = null;

       public DataTable daCargarVariableSistema(String pcCodTab)
       {
           SqlParameter[] pa = new SqlParameter[1];
           clsConexion objCon = null;
           DataTable dtb = null;
           objUtil = new clsUtil();
           try
           {
               objCon = new clsConexion("");
               pa[0] = new SqlParameter("@pecCodTab", SqlDbType.VarChar,4);
               pa[0].Value = pcCodTab;


               dtb = objCon.EjecutarProcedimientoDT("uspCargarVariableSistema", pa);

               return dtb;

           }
           catch (Exception ex)
           {
               objUtil.gsLogAplicativo("DAMenu.cs", "daCargarVariableSistema", ex.Message);
               throw new Exception(ex.Message);
           }
           finally
           {
               if (objCon != null)
                   objCon.CierraConexion();
               objCon = null;
               dtb = null;
           }


       }

       public DataSet DACargarMenu(Int32 pstrUsuario, Int32 pintAplicacion )
       {
           SqlParameter[] pa = new SqlParameter[2];
           clsConexion objCon = null;
           DataSet dtb = null;
           objUtil = new clsUtil();
           try
           {
               objCon = new clsConexion("");
               pa[0] = new SqlParameter("@peiUsuario", SqlDbType.Int);
               pa[0].Value = pstrUsuario;
               pa[1] = new SqlParameter("@peiAplicacion", SqlDbType.Int);
               pa[1].Value = pintAplicacion;

               dtb = objCon.EjecutarProcedimientoDS("uspObtenerMenu", pa);

               return dtb;

           }
           catch (Exception ex)
           {
               objUtil.gsLogAplicativo("DAMenu.cs", "DACargarMenu", ex.Message);
               throw new Exception(ex.Message);
           }
           finally
           {
               if (objCon != null)
                   objCon.CierraConexion();
               objCon = null;
               dtb = null;
           }

       
       }
    }



}
