using CapaConexion;
using selferviceSIGC.Model.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace selferviceSIGC.Core.Business
{
    public class OrderService : IOrderService
    {
        public string fnGetOrderxCodigo(string Codigo)
        {
            SqlParameter[] pa = new SqlParameter[1];
            clsConexion objCnx = null;
            //objUtil = new clsUtil();
            DataTable dt = null;
            int intExiste = 0;

            try
            {

                pa[0] = new SqlParameter("@peCodigo", SqlDbType.VarChar, 30);
                pa[0].Value = Codigo;
                objCnx = new clsConexion("");
                dt = objCnx.EjecutarProcedimientoDT("uspGetPedidoxCodigo", pa);
                objCnx.CierraConexion();
                if (dt != null && dt.Rows.Count > 0)
                    intExiste = Convert.ToInt32(dt.Rows[0]["ExisteReg"]);

                return intExiste == 1 ? "SI": intExiste==-1 ? "Error en Procedimiento Almacenado":"NO";

            }
            catch (Exception ex)
            {
                //objUtil.gsLogAplicativo("DAAcceso.cs", "DAGuardarAcceso", ex.Message);
                return "Error Interno en método. Comunicar a Sistemas";
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                pa = null;
            }
        }

        public bool fnSaveOrder(Pedido objPedido)
        {
                SqlParameter[] pa = new SqlParameter[7];
                clsConexion objCnx = null;
                //objUtil = new clsUtil();

                try
                {

                    pa[0] = new SqlParameter("@peCodigo", SqlDbType.VarChar,30);
                    pa[0].Value = objPedido.Codigo;
                    pa[1] = new SqlParameter("@peEstado", SqlDbType.Int);
                    pa[1].Value = objPedido.intEstado;
                    pa[2] = new SqlParameter("@xmlData", SqlDbType.Xml);
                    pa[2].Value = objPedido.xmlObject;
                    pa[3] = new SqlParameter("@peIdUser", SqlDbType.Int);
                    pa[3].Value = objPedido.idUser;
                    pa[4] = new SqlParameter("@peFechaReg", SqlDbType.DateTime);
                    pa[4].Value = objPedido.dFechaRegistro;
                    pa[5] = new SqlParameter("@peIdUserAct", SqlDbType.Int);
                    pa[5].Value = objPedido.idUserAct;
                    pa[6] = new SqlParameter("@peFechaAct", SqlDbType.DateTime);
                    pa[6].Value = objPedido.dFechaAct;
                    objCnx = new clsConexion("");
                    objCnx.EjecutarProcedimiento("uspGuardarPedido", pa);
                    objCnx.CierraConexion();

                    return true;

                }
                catch (Exception ex)
                {
                    //objUtil.gsLogAplicativo("DAAcceso.cs", "DAGuardarAcceso", ex.Message);
                    return false;
                }
                finally
                {
                    if (objCnx != null)
                        objCnx.CierraConexion();
                    objCnx = null;
                    pa = null;
                }
        }

        public List<Pedido> fnGeAllorEspecificOrder(string Codigo)
        {
            SqlParameter[] pa = new SqlParameter[1];
            clsConexion objCnx = null;
            //objUtil = new clsUtil();
            Pedido objPedido = null;
            List<Pedido> lstPedido = new List<Pedido>();
            DataTable dt = null;

            try
            {

                pa[0] = new SqlParameter("@peCodigo", SqlDbType.VarChar, 30);
                pa[0].Value = Codigo;
                objCnx = new clsConexion("");
                dt = objCnx.EjecutarProcedimientoDT("uspGetAllorEspecificOrder", pa);
                objCnx.CierraConexion();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row  in dt.Rows)
                    {
                        objPedido = new Pedido()
                        {
                            intPedido = Convert.ToInt32(row["idPedido"]),
                            Codigo = Convert.ToString(row["Codigo"]),
                            intEstado = Convert.ToInt32(row["intEstado"]),
                            xmlObject = Convert.ToString(row["object"]),
                            dFechaRegistro = Convert.ToDateTime(row["dFechaRegistro"])
                        };

                        lstPedido.Add(objPedido);
                    }
                }

                return lstPedido;

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
                pa = null;
            }
        }

    }
}
