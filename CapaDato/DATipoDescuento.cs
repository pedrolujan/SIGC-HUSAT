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
    public class DATipoDescuento
    {
        private clsUtil objUtil = null;

        public List<TipoDescuento> daDevolverTipDescuento(Int32 idTipoDescuento,Boolean buscar)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;
            List<TipoDescuento> lstTipoDescuento = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peIdTipoDescuento", SqlDbType.Int);
                pa[0].Value = idTipoDescuento;


                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspListarTipoDescuento", pa);

                lstTipoDescuento = new List<TipoDescuento>();

                lstTipoDescuento.Add(new TipoDescuento(
                       Convert.ToInt32("0"),
                       Convert.ToString(buscar ? "TODOS" : "Selecc. Tipo Descuento"),
                       Convert.ToInt32(0),
                       Convert.ToString("")
                       ));
                foreach (DataRow drMenu in dtAccesorio.Rows)
                {
                    lstTipoDescuento.Add(new TipoDescuento(
                        Convert.ToInt32(drMenu["idTipoDescuento"]),
                        Convert.ToString(drMenu["nombre"]),
                        Convert.ToInt32(drMenu["cantidad"]),
                        Convert.ToString(drMenu["simbolo"])
                        ));
                }

                return lstTipoDescuento;

            }
            catch (Exception ex)
            {
                lstTipoDescuento = null;
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daDevolverAccesorio", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstTipoDescuento = null;
            }

        }

        public Int32 daValidarDescuento(String usuario, String clave)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            Int32 valorAcceso = 0;

            try
            {
                pa[0] = new SqlParameter("@pecUsuario", SqlDbType.NVarChar, 15) { Value = usuario };
                pa[1] = new SqlParameter("@pecClave", SqlDbType.NVarChar, 15) { Value = clave };

                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspValidarAccesoDescuento", pa);

                Int32 numfilas = dtAccesorio.Rows.Count;
                foreach (DataRow drMenu in dtAccesorio.Rows)
                {
                    valorAcceso = Convert.ToInt32(drMenu["valorAcceso"]);
                }

                return valorAcceso;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daDevolverAccesorio", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public Double daCalularDescuento(TipoDescuento clsTipoDescuento)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            Double precioTotal = 0;

            try
            {
                pa[0] = new SqlParameter("@idTipoDescuento", SqlDbType.Int) { Value = clsTipoDescuento.IdTipoDescuento };
                pa[1] = new SqlParameter("@costo", SqlDbType.Money) { Value = clsTipoDescuento.Precio };
                pa[2] = new SqlParameter("@descuento", SqlDbType.Money) { Value = clsTipoDescuento.Descuento };

                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspCalcularPrecioDescuento", pa);

                foreach (DataRow drMenu in dtAccesorio.Rows)
                {
                    precioTotal = Convert.ToInt32(drMenu["precioDescuento"]);
                }

                return precioTotal;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daDevolverAccesorio", ex.Message);
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
