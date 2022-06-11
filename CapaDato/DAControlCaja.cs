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
    public class DAControlCaja
    {
        public DAControlCaja() { }
        clsUtil objUtil;
        public List<ControlCaja> daFnLlenarTipoPago(String id, Boolean estado)
        {
            SqlParameter[] pa = new SqlParameter[1];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@codTipoPago", SqlDbType.VarChar) { Value = id };
                objCnx = new clsConexion("");

                dt = objCnx.EjecutarProcedimientoDT("uspListarTipoPaPago", pa);
                lstControl.Add(new ControlCaja
                {
                    codTipoPago = "0",
                    descripTipoPago =Convert.ToString(estado == true ? "TODOS" : "Selec. Opcion"),
                    estado=false

                }); 
                foreach (DataRow d in dt.Rows)
                {
                    lstControl.Add(new ControlCaja
                    {
                        codTipoPago=d["cCodTab"].ToString(),
                        descripTipoPago=d["cNomTab"].ToString(),
                        estado=Convert.ToBoolean(d["bEstado"])
                    });

                }
                return lstControl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
    }
}
