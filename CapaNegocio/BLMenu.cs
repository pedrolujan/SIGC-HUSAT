using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntidad;
using System.Data;

namespace CapaNegocio
{
    public class BLMenu
    {
        DAMenu objMenu = null;

        public DataTable daCargarVariableSistema(String pcCodTab)
        {
            objMenu = new DAMenu();
            try
            {
                return objMenu.daCargarVariableSistema(pcCodTab);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objMenu = null;
            }
        }

        public DataSet BLCargarMenu(Int32 pstrUsuario, Int32 pintAplicacion)
        {
            objMenu = new DAMenu();
            try
            {
                return objMenu.DACargarMenu(pstrUsuario, pintAplicacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objMenu = null;
            }            
        }

    }
}
