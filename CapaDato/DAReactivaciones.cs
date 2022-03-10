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
    public class DAReactivaciones
    {
        private clsUtil objUtil;
        private object pcBuscar;
       

        public DataTable DABuscarReactivacion(Int32 TipoCon , String pcBuscar)
        { 
        
            DataTable dtResul = new DataTable();
            SqlParameter[] pa = new SqlParameter[2];

            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@PCBuscar", SqlDbType.VarChar, 30);
                pa[0].Value = pcBuscar; 
                pa[1] = new SqlParameter("@TipoCon", SqlDbType.Int);
                pa[1].Value = TipoCon;
                objCnx = new clsConexion("");
                dtResul = objCnx.EjecutarProcedimientoDT("uspBuscarDatoReactivacion", pa);
                return dtResul; 
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarEquipoImeisDatatable", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;

            }

            
        
        }
       
        public DataTable daBuscarReactivacionEspecificos(Int32 condicion, Int32 idContrato)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dt = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@pcBuscar", SqlDbType.VarChar);
                pa[0].Value = idContrato;
                pa[1] = new SqlParameter("@TipoCon", SqlDbType.Int);
                pa[1].Value = condicion;

                objCnx = new clsConexion("");
                dt = objCnx.EjecutarProcedimientoDT("uspBuscarDatoReactivacion", pa);
                return dt;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }
        public Int32 daGuardarReactivaciones(Titularidad clsReac, String Condicion)
        {
            SqlParameter[] pa = new SqlParameter[14];
            Int32 dt = 0;
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idEquipoImeisNuevo", SqlDbType.Int);
                pa[0].Value = clsReac.listaEquipoNuevo[0].idEquipoImeis;
                pa[1] = new SqlParameter("@idEquipoImeisAntiguo", SqlDbType.Int);
                pa[1].Value = clsReac.listaEquipoAntiguo[0].idEquipoImeis;
                pa[2] = new SqlParameter("@idChipNuevo", SqlDbType.Int);
                pa[2].Value = clsReac.listaSimCardNuevo.Count==0?0: clsReac.listaSimCardNuevo[0].idChip;
                pa[3] = new SqlParameter("@idChipAntiguo", SqlDbType.Int);
                pa[3].Value = clsReac.listaSimCardAntiguo.Count == 0 ? 0 : clsReac.listaSimCardAntiguo[0].idChip;
                pa[4] = new SqlParameter("@idCliente", SqlDbType.Int);
                pa[4].Value = clsReac.listaCliente[0].idCliente;
                pa[5] = new SqlParameter("@idVehiculo", SqlDbType.Int);
                pa[5].Value = clsReac.listaVehiculo[0].idVehiculo;
                pa[6] = new SqlParameter("@idplan", SqlDbType.Int);
                pa[6].Value = clsReac.listaPlan[0].idPlan;
                pa[7] = new SqlParameter("@observacionesE", SqlDbType.NVarChar,500);
                pa[7].Value = clsReac.ObservacionesE;
                pa[8] = new SqlParameter("@observacionesSC", SqlDbType.NVarChar,500);
                pa[8].Value = clsReac.ObservacionesSC;                
                pa[9] = new SqlParameter("@FechaReactivacionE", SqlDbType.DateTime);
                pa[9].Value = clsReac.FechaReactivacionesE;
                pa[10] = new SqlParameter("@FechaRegistroSC", SqlDbType.DateTime);
                pa[10].Value = clsReac.FechaRegistroSC;
                pa[11] = new SqlParameter("@FechaReactivacionSC", SqlDbType.DateTime);
                pa[11].Value = clsReac.FechaReactivacionesSC;
                pa[12] = new SqlParameter("@TipoCon", SqlDbType.NVarChar,15);
                pa[12].Value = Condicion;
                pa[13] = new SqlParameter("@idVentaGeneral", SqlDbType.Int);
                pa[13].Value = clsReac.idVentaGeneral;
                objCnx = new clsConexion("");
                dt = objCnx.EjecutarProcedimiento("uspGuardarReacctivaciones", pa);

                return dt;

            }
            catch(Exception exp)
            {
                throw new Exception(exp.Message);

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
