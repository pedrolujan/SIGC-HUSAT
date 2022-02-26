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
    public class DATipoCliente
    {
        public DATipoCliente() { }
        private clsUtil objUtil = null;

        ///comentario
        public List<TipoCliente> daDevolverTipoCliente(Int32 idTC, String tipoCon, Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable getDB;
            clsConexion objCnx = null;
            
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peidTipoCliente", SqlDbType.Int) { Value = idTC };
                pa[1] = new SqlParameter("@peEstado", SqlDbType.NVarChar,1) { Value = tipoCon };
                
                objCnx = new clsConexion("");
                getDB = objCnx.EjecutarProcedimientoDT("uspListarTipoCliente", pa);

                List<TipoCliente> lstTC = new List<TipoCliente>();
               
                lstTC.Add(new TipoCliente(
                    0,
                    buscar ? "TODOS" : "Selecc. Persona",
                    true
                    ));

                foreach (DataRow getrow in getDB.Rows)
                {
                    lstTC.Add(new TipoCliente(
                        Convert.ToInt32(getrow["idTipCliente"]), 
                        Convert.ToString(getrow["cNombre"]),
                        Convert.ToBoolean(getrow["bEstado"])
                        ));
                }

                return lstTC;
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
            }
        }

        public List<TipoDocumento> daDevolverDocumentoDeTipoCliente(Int32 idTD, String tipoCon,Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable getDB;
            clsConexion objCnx = null;
            TipoDocumento objTD = new TipoDocumento();
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peidTipoCliente", SqlDbType.Int) { Value = idTD };
                pa[1] = new SqlParameter("@peEstado", SqlDbType.NVarChar, 1) { Value = tipoCon };

                objCnx = new clsConexion("");
                getDB = objCnx.EjecutarProcedimientoDT("uspListarDocumentoDeTipoCliente", pa);

                List<TipoDocumento> lstTC = new List<TipoDocumento>();
                lstTC.Add(new TipoDocumento(
                    0, 
                    buscar ? "TODOS" : "Selecc. Documento",
                    0, 
                    true,
                    false,
                    ""));

                foreach (DataRow getrow in getDB.Rows)
                {
                    lstTC.Add(new TipoDocumento(
                        Convert.ToInt32(getrow["idTipDocumento"]),
                        Convert.ToString(getrow["cNombre"]),
                        Convert.ToInt32(getrow["iMaxCaracteres"]),
                        Convert.ToBoolean(getrow["bEstado"]),
                        Convert.ToBoolean(getrow["bObligatorio"]),
                        Convert.ToString(getrow["cCharObligatorio"])
                        ));
                }

                return lstTC;
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
            }
        }
    }
}
