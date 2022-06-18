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
        public List<ControlCaja> daFnLlenarTipoPago(Int32 idTipPlan,String id, Boolean estado)
        {
            SqlParameter[] pa = new SqlParameter[2];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@codTipoPago", SqlDbType.VarChar) { Value = id };
                pa[1] = new SqlParameter("@idTipPlan", SqlDbType.Int) { Value =  idTipPlan };
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
        public DataTable daFnBuscarVentasCaja(Boolean chk,Boolean chkDiaEsp, String fini, String ffin, String mtPago, Int32 entPago, String doVenta, Int32 tipPlan, Int32 tipTarifa, String tipPago, Int32 idUsuario, String cBuscar,Int32 numPagina,Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[14];
            List<ControlCaja> lstControl = new List<ControlCaja>();
            DataTable dt = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@dtFechaIni", SqlDbType.Date) { Value = fini };
                pa[1] = new SqlParameter("@dtFechaFin", SqlDbType.Date) { Value = ffin };
                pa[2] = new SqlParameter("@codMetodPago", SqlDbType.VarChar) { Value = mtPago };
                pa[3] = new SqlParameter("@idEntidadPago", SqlDbType.Int) { Value = entPago };
                pa[4] = new SqlParameter("@codDocumentoVenta", SqlDbType.VarChar) { Value = doVenta };
                pa[5] = new SqlParameter("@idTipoPlan", SqlDbType.Int) { Value = tipPlan };
                pa[6] = new SqlParameter("@idTipoTarifa", SqlDbType.Int) { Value = tipTarifa };
                pa[7] = new SqlParameter("@codTipoPago", SqlDbType.VarChar) { Value = tipPago };
                pa[8] = new SqlParameter("@cBuscar", SqlDbType.VarChar) { Value = cBuscar }; 
                pa[9] = new SqlParameter("@numPagina", SqlDbType.VarChar) { Value = numPagina }; 
                pa[10] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = tipoCon }; 
                pa[11] = new SqlParameter("@chkHabilitarFecha", SqlDbType.TinyInt) { Value =  chk }; 
                pa[12] = new SqlParameter("@chkDiaEspecifico", SqlDbType.TinyInt) { Value = chkDiaEsp }; 
                pa[13] = new SqlParameter("@idUsuario", SqlDbType.TinyInt) { Value = idUsuario }; 

                 objCnx = new clsConexion("");

                return dt = objCnx.EjecutarProcedimientoDT("uspBuscarVentasCaja", pa);

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
