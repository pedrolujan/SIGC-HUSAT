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
    public class DACiclo
    {
        clsUtil objUtil;
        public List<Ciclo> daDevolverCiclo(Int32 idCiclo, Boolean tipBusqueda)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtTipoPlan = new DataTable();
            clsConexion objCnx = null;
            List<Ciclo> lstTipoPlan = null;
            Ciclo clsCiclo;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peIdCiclo", SqlDbType.Int) { Value = idCiclo };

                objCnx = new clsConexion("");
                dtTipoPlan = objCnx.EjecutarProcedimientoDT("uspListarCiclo", pa);

                lstTipoPlan = new List<Ciclo>();
                clsCiclo = new Ciclo
                {
                    IdCiclo = 0,
                    Dia = tipBusqueda ? "TODOS" : "Selecc. Ciclo",
                    DiaNumber = 0,
                    Estado = Convert.ToBoolean(1)
                };
                lstTipoPlan.Add(clsCiclo);
                foreach (DataRow drMenu in dtTipoPlan.Rows)
                {
                    clsCiclo = new Ciclo
                    {
                        IdCiclo = Convert.ToInt32(drMenu["idCiclo"]),
                        Dia = Convert.ToString(drMenu["cDia"]),
                        DiaNumber = Convert.ToInt32(drMenu["cDia"]),
                        Estado = Convert.ToBoolean(drMenu["bEstado"])
                    };               
                        
                    lstTipoPlan.Add(clsCiclo);
                }

                return lstTipoPlan;

            }
            catch (Exception ex)
            {
                lstTipoPlan = null;
                objUtil.gsLogAplicativo("DAPlanes.cs", "daDevolverPlan", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstTipoPlan = null;
            }

        }
    }
}
