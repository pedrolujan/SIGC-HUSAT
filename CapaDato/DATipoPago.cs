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
    public class DATipoPago
    {
        clsUtil objUtil;
        public List<EntidadesPago> daDevolverEntidadPago(String cCodTab, Int32 lnTipoCon, Boolean estBusq)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@cCodTipoPago", SqlDbType.NVarChar, 8);
                pa[0].Value = cCodTab;
                pa[1] = new SqlParameter("@lnTipoCon", SqlDbType.Int);
                pa[1].Value = lnTipoCon;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarEntidadesPago", pa);

                List<EntidadesPago> lstEntidades = new List<EntidadesPago>();
                if (lnTipoCon == 0)
                {
                    lstEntidades.Add(new EntidadesPago(
                        Convert.ToString(-1),
                        estBusq==true?"TODOS": "Seleccione Opcion"));;
                } 
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstEntidades.Add(new EntidadesPago(
                        Convert.ToString(drMenu["id"]),
                        Convert.ToString(drMenu["nomb"])));
                }
                
                return lstEntidades;

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
