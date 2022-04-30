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
    public class DATitularidad
    {
        private clsUtil objUtil;
        private object pcBuscar;

        public DataTable DABuscarTitularidad(Int32 TipoCon, String pcBuscar, Int32 idCliente)
        {
            DataTable dtResul = new DataTable();
            SqlParameter[] pa = new SqlParameter[3];

            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {

                pa[0] = new SqlParameter("@PCBuscar", SqlDbType.VarChar, 30);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@idCliente", SqlDbType.Int);
                pa[1].Value = idCliente;
                pa[2] = new SqlParameter("@TipoCon", SqlDbType.Int);
                pa[2].Value = TipoCon;
                objCnx = new clsConexion("");

                dtResul = objCnx.EjecutarProcedimientoDT("uspBuscarTitularidad", pa);
                return dtResul;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "DABuscarTitularidad", ex.Message);

                throw new Exception(ex.Message);

            }

            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;

            }

        }
        public DataTable daBuscarTilularidadEspecificos(Int32 condicion, Int32 idventageneral)
        {
            DATitularidad daobjEquipo = new DATitularidad();
            DataTable dtResul = new DataTable();
            SqlParameter[] pa = new SqlParameter[2];

            clsConexion objCnx = null;

            try
            {
                pa[0] = new SqlParameter("@pcBuscar", SqlDbType.VarChar);
                pa[0].Value = idventageneral;
                pa[1] = new SqlParameter("@TipoCon", SqlDbType.Int);
                pa[1].Value = condicion;

                objCnx = new clsConexion("");
                dtResul = objCnx.EjecutarProcedimientoDT("uspBuscarTitularidad", pa);
                return dtResul;


            }
            catch (Exception ex)
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

        public Int32 daGuardarClienteN(Titularidad clsTitu, Int32 tipocon , Int32 idUsuario ,Int32 idVenta)
        
        {
            SqlParameter[] pa = new SqlParameter[6];
            Int32 dt = 0;
        
            List<xmlDocumentoVentaGeneral> ListaDocumentoVentas = new List<xmlDocumentoVentaGeneral>();

            ListaDocumentoVentas.Add(new xmlDocumentoVentaGeneral
            {
                xmlDocumentoVenta = clsTitu.listaDocVenta,
                xmlDetalleVentas = clsTitu.listaDetalleV,
            }); 


            
            String xmlDV = clsUtil.Serialize(clsTitu.listaDetalleV);
            String xmlDocV = clsUtil.Serialize(ListaDocumentoVentas);

            clsConexion objCnx = null;
            objUtil = new clsUtil();
            try
            {

                pa[0] = new SqlParameter("@idClienteAntiguo", SqlDbType.Int);
                pa[0].Value = clsTitu.listaDocVenta[0].idCliente;
                pa[1] = new SqlParameter("@idVenta", SqlDbType.Int);
                pa[1].Value = idVenta;
                pa[2] = new SqlParameter("@FechaRegistro", SqlDbType.DateTime);
                pa[2].Value = clsTitu.FechaRegistroT;
                pa[3] = new SqlParameter("@FechaTitularidad ", SqlDbType.DateTime);
                pa[3].Value = clsTitu.FechaTitularidad;
                pa[4] = new SqlParameter("@idUsuario", SqlDbType.Int);
                pa[4].Value = idUsuario;
                pa[5] = new SqlParameter("@xmlDocumentoventa", SqlDbType.Xml);
                pa[5].Value = xmlDocV;
                

                objCnx = new clsConexion(""); 
                dt = objCnx.EjecutarProcedimiento("uspGuardarTitularidad", pa);

                return dt;

            }
            catch (Exception exp)
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
