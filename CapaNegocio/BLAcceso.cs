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
    public class BLAcceso
    {
        DAAcceso obAcceso = null;


        public String BLValidarIngreso(DateTime pdFechasis, String pstrUsuario, String pstrClave, String pstrMaquina, String pstrVersion, Int32 pintApli, out Int32 pnidUsuario)
        {

            obAcceso = new DAAcceso();
            Int32 idUsuario = 0;
            String lcResultado = "";
            try
            {
                lcResultado = obAcceso.DAValidarIngreso(pdFechasis,pstrUsuario, pstrClave, pstrMaquina, pstrVersion, pintApli, out idUsuario).Trim();
                pnidUsuario = idUsuario;

                return lcResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                obAcceso = null;
            }
        }

        public Boolean DARegistrarLogueo(Int32 pstrUser, DateTime pdtmFechaIni, DateTime pdtmFechaFin, String pstrMaquina, String pstrVersion, Int32 pintApli)
        {
            obAcceso = new DAAcceso();
            try
            {
                return obAcceso.DARegistrarLogueo(pstrUser, pdtmFechaIni, pdtmFechaFin, pstrMaquina, pstrVersion, pintApli);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                obAcceso = null;
            }

        }

         public DataTable BLListarMenuAcceso(int pidAplicacion,string pidUsuario)
        {
            obAcceso = new DAAcceso();
            try
            {
                return obAcceso.DAListarMenuAcceso(pidAplicacion, pidUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                obAcceso = null;
            }

        }

         public String BLGuardarAcceso(DataTable dtAcceso, string pcCodigo)
         {
             obAcceso = new DAAcceso();
             try
             {
                 return obAcceso.DAGuardarAcceso(dtAcceso, pcCodigo);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
             finally
             {
                 obAcceso = null;
             }
         }
        public DataTable BLBuscarCargoUsuario(Int32 idUsuario)
         {
             obAcceso = new DAAcceso();
             try
             {
                 return obAcceso.DABuscarCargousuario(idUsuario);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
             finally
             {
                 obAcceso = null;
             }
         }

       
    }
}
