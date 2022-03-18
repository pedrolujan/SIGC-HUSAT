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
    public class DAControlPagos
    {
        clsUtil objUtil = null;
        public DataTable daBuscarCronograma(Boolean habilitarfechas, DateTime dtFechaIni, DateTime dFechaFin, String pcBuscar,Int32 tipoCon, Int32 TipConPaginacion, Int32 numPagina,String estadoPago,Int32 idCiclo)
        {
            SqlParameter[] pa = new SqlParameter[9];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peHabilitarFechas", SqlDbType.TinyInt) { Value = habilitarfechas };
                pa[1] = new SqlParameter("@peFechaInical", SqlDbType.DateTime) { Value = dtFechaIni };
                pa[2] = new SqlParameter("@peFechaFinal", SqlDbType.DateTime) { Value = dFechaFin };
                pa[3] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 15) { Value = pcBuscar };
                pa[4] = new SqlParameter("@idCiclo", SqlDbType.Int) { Value = idCiclo };
                pa[5] = new SqlParameter("@estadoDetCronograma", SqlDbType.VarChar, 8) { Value = estadoPago };
                pa[6] = new SqlParameter("@TipoCon", SqlDbType.Int) { Value = tipoCon };
                pa[7] = new SqlParameter("@numPagina", SqlDbType.Int) { Value = numPagina };
                pa[8] = new SqlParameter("@TipoConPagina", SqlDbType.Int) { Value = TipConPaginacion };
                objCnx = new clsConexion("");
                //dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronogramaPagosMensuales", pa);
                dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronograma", pa);


                return dtResult;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public DataTable daBuscarCronogramaEspecifico(Int32 idCron, Int32 idCont, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idCronograma", SqlDbType.Int) { Value = idCron };
                pa[1] = new SqlParameter("@idContrato", SqlDbType.Int) { Value = idCont };
                pa[2] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = tipoCon };
                objCnx = new clsConexion("");
                dtResult = objCnx.EjecutarProcedimientoDT("uspBuscarCronogramaEspecifico", pa);


                return dtResult;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }
        public Boolean daGuardarPagoCuotas(ControlPagos clsCPC, List<xmlDocumentoVentaGeneral> lstDV, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[20];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            Int32 numRows = 0;

            String xmlTrandiaria = clsUtil.Serialize(clsCPC.listaPagosTrandiaria);
            String xmlDetalleVenta = clsUtil.Serialize(clsCPC.listaDetalleVenta);
            String xmlDocumentoVenta = clsUtil.Serialize(lstDV);
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idCronograma", SqlDbType.Int) { Value = clsCPC.claseCronograma.idCronograma };
                pa[1] = new SqlParameter("@idContrato", SqlDbType.Int) { Value = clsCPC.claseCronograma.idContrato };
                pa[2] = new SqlParameter("@idDetalleCronograma", SqlDbType.Int) { Value = clsCPC.claseDetalleCronograma.idDetalleCronograma };
                pa[3] = new SqlParameter("@dFechaRegistro", SqlDbType.DateTime) { Value = clsCPC.fechaRegistro };
                pa[4] = new SqlParameter("@dFechaVenta", SqlDbType.DateTime) { Value = clsCPC.fechaVenta };
                pa[5] = new SqlParameter("@dFechaPago", SqlDbType.DateTime) { Value = clsCPC.fechaPago };
                pa[6] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsCPC.idUsuario };
                pa[7] = new SqlParameter("@xmlDocumentoVenta", SqlDbType.Xml) { Value = xmlDocumentoVenta };
                pa[8] = new SqlParameter("@xmlDetalleVenta", SqlDbType.Xml) { Value = xmlDetalleVenta };
                pa[9] = new SqlParameter("@xmlTrandiaria", SqlDbType.Xml) { Value = xmlTrandiaria };
                pa[10] = new SqlParameter("@TotalCuota", SqlDbType.Money) { Value = clsCPC.listaPagosTrandiaria[0].cantAPagar };
                pa[11] = new SqlParameter("@idMoneda", SqlDbType.Int) { Value = clsCPC.listaPagosTrandiaria[0].idMoneda };
                pa[12] = new SqlParameter("@idCiclo", SqlDbType.Int) { Value = clsCPC.idCiclo };
                pa[13] = new SqlParameter("@IGVPrecio", SqlDbType.Money) { Value = lstDV[0].xmlDocumentoVenta[0].nIGV };
                pa[14] = new SqlParameter("@IdTarifa", SqlDbType.Int) { Value = clsCPC.claseTarifa.IdTarifa };

                pa[15] = new SqlParameter("@dPeriodoInicio", SqlDbType.DateTime) { Value = clsCPC.claseDetalleCronograma.periodoInicio };
                pa[16] = new SqlParameter("@dPeriodoFinal", SqlDbType.DateTime) { Value = clsCPC.claseDetalleCronograma.periodoFinal };
                pa[17] = new SqlParameter("@dFechaVencimiento", SqlDbType.DateTime) { Value = clsCPC.claseDetalleCronograma.fechaVencimiento };
                pa[18] = new SqlParameter("@dFechaEmision", SqlDbType.DateTime) { Value = clsCPC.claseDetalleCronograma.fechaEmision };

                pa[19] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = tipoCon };
                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarPagoCuotas", pa);
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                //if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
                clsCPC = null;
                lstDV = null;
                tipoCon = 0;
            }
        }


        public Boolean daActualizarEstados(Int32 idDetCronograma,String estado)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtResult = new DataTable();
            clsConexion objCnx = null;
            Int32 numRows = 0;

            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@idDetCronograma", SqlDbType.Int) { Value = idDetCronograma };
                pa[1] = new SqlParameter("@estado", SqlDbType.VarChar) { Value = estado };
               
                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarActualizacionEstados", pa);
                return true;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                //if (objCnx != null)
                objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
            }
        }
    }
}
