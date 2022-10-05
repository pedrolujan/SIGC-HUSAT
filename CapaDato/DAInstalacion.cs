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
    public class DAInstalacion
    {

        clsUtil objUtil;
        public String daGrabarInstalacion(Instalacion objInstal, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[4];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidInstalacion", SqlDbType.Int);
                pa[0].Value = objInstal.idInstalacion;
                pa[1] = new SqlParameter("@peidEquipo", SqlDbType.Int);
                pa[1].Value = objInstal.idEquipo;
                pa[2] = new SqlParameter("@peidAccesorio", SqlDbType.Int);
                pa[2].Value = objInstal.idAccesorio;
                pa[3] = new SqlParameter("@peidPlan", SqlDbType.Int);
                pa[3].Value = objInstal.idPlan;
                pa[4] = new SqlParameter("@peidCliente", SqlDbType.Int);
                pa[4].Value = objInstal.idCliente;
                pa[5] = new SqlParameter("@pdfechaInicio", SqlDbType.DateTime);
                pa[5].Value = objInstal.dFecInicio;
                pa[6] = new SqlParameter("@pdFechaFinal", SqlDbType.DateTime);
                pa[6].Value = objInstal.dFecFinal;
                pa[7] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[7].Value = objInstal.bEstado;
              
                pa[8] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[8].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarInstalacion", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAInstalacion.cs", "daGrabarInstalacion", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
            }
        }

        public DataTable DadevolverDatosIns(String codVenta,String placa)
        {
            SqlParameter[] pa = new SqlParameter[2];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            DataTable dtResp = new DataTable();

            try
            {
                pa[0] = new SqlParameter("@pecodVenta", SqlDbType.VarChar,50);
                pa[0].Value = codVenta;

                pa[1] = new SqlParameter("@peplaca", SqlDbType.VarChar, 50);
                pa[1].Value = placa;



                objCnx = new clsConexion("");
                dtResp = objCnx.EjecutarProcedimientoDT("uspDevolverDatosInstalacion", pa);

                return dtResp;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAInstalacion.cs", "daGrabarInstalacion", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
            }
        }

        public Boolean DaGuardarInstalacion(List<xmlInstalacion> xmlInstal,  Int32 idUsuario, DateTime FechaInstalacion)
        {
            SqlParameter[] pa = new SqlParameter[15];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            DataTable dtResp = new DataTable();
            List<Instalacion> lstInstal = new List<Instalacion>();
            String xmlInstalacion = clsUtil.Serialize(xmlInstal);
            try
            {
                pa[0] = new SqlParameter("@peCodigoVenta", SqlDbType.NVarChar, 20);
                pa[0].Value = xmlInstal[0].ListaCliente[0].codigoVentaGen;

                pa[1] = new SqlParameter("@peXmlInstalacion", SqlDbType.Xml);
                pa[1].Value = xmlInstalacion;

                pa[2] = new SqlParameter("@peidVehiculo", SqlDbType.Int);
                pa[2].Value = xmlInstal[0].ListaVehiculo[0].idVehiculo;

                pa[3] = new SqlParameter("@peidEquipo", SqlDbType.Int);
                pa[3].Value = xmlInstal[0].ListaEquipo.Count>0? xmlInstal[0].ListaEquipo[0].idEquipo: xmlInstal[0].ListaEquipoActual[0].idEquipo;

                pa[4] = new SqlParameter("@peidReferencia", SqlDbType.Int);                                                                    
                pa[4].Value = xmlInstal[0].ListaCliente[0].idReferencia;

                pa[5] = new SqlParameter("@peidTipoTarifa", SqlDbType.Int);
                pa[5].Value = xmlInstal[0].ListaPlan[0].idTipoTarifa;

                pa[6] = new SqlParameter("@peObservacion", SqlDbType.NVarChar,500);
                pa[6].Value = xmlInstal[0].observaciones;

                pa[7] = new SqlParameter("@peIdUsuario", SqlDbType.Int);
                pa[7].Value = idUsuario;

                pa[8] = new SqlParameter("@peFechaInstalacion", SqlDbType.DateTime);
                pa[8].Value = FechaInstalacion;

                pa[9] = new SqlParameter("@peidUbicacionEquipo", SqlDbType.Int);
                pa[9].Value = xmlInstal[0].ListaUbicacionEquipo[0].idUbicacionEquipo;

                pa[10] = new SqlParameter("@peNUbicacionEquipo", SqlDbType.NVarChar,50);
                pa[10].Value = xmlInstal[0].ListaUbicacionEquipo[0].NUbicacionEquipo;

                pa[11] = new SqlParameter("@idVentaGeneral", SqlDbType.Int);
                pa[11].Value = xmlInstal[0].ListaCliente[0].idVentaGen;

                pa[12] = new SqlParameter("@idInstalacion", SqlDbType.Int);
                pa[12].Value = xmlInstal[0].clsInstalacion.idInstalacion;

                pa[13] = new SqlParameter("@codInstalacion", SqlDbType.NVarChar,20);
                pa[13].Value = xmlInstal[0].clsInstalacion.codigoInstalacion;

                pa[14] = new SqlParameter("@peidEquipoActual", SqlDbType.Int);
                pa[14].Value = xmlInstal[0].ListaEquipoActual[0].idEquipo;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarInstalacion", pa);

                return true;


            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAInstalacion.cs", "daGrabarInstalacion", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
            }
        }
        public Equipo_imeis daBuscarEquipo(Int32 idEquipo)
        {
            SqlParameter[] pa = new SqlParameter[1];
            clsConexion objCnx = null;
            objUtil = new clsUtil();
            DataTable dtResp = new DataTable ();
            Equipo_imeis clsEquipos = new Equipo_imeis();

            try
            {
                pa[0] = new SqlParameter("@peidEquipo", SqlDbType.Int);
                pa[0].Value = idEquipo;

                
                objCnx = new clsConexion("");
                dtResp = objCnx.EjecutarProcedimientoDT("uspDevolverDatosEquipo", pa);

                foreach (DataRow DR in dtResp.Rows) 
                {
                    
                    clsEquipos.idEquipo = Convert.ToInt32(DR["idEquipoImeis"]);
                    clsEquipos.idEquipoImeis = Convert.ToInt32(DR["idEquipoImeis"]);
                    clsEquipos.ModeloEquipo = Convert.ToString(DR["cNombreModelo"]);
                    clsEquipos.nomEquipo = Convert.ToString(DR["NombreEquipo"]);
                    clsEquipos.MarcaEquipo = Convert.ToString(DR["cNombreMarca"]);
                    clsEquipos.imei = Convert.ToString(DR["Imei"]);
                    clsEquipos.SimCardEquipo = Convert.ToString(DR["cSimCard"]);
                    clsEquipos.OperadorEquipo = Convert.ToString(DR["cNombre"]);
                }

                return clsEquipos;


            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAInstalacion.cs", "daGrabarInstalacion", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
            }
        }
        public DataTable daAccesoriosEquipo(String lnIdPlan)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtEqPLan = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@lnIdPlan", SqlDbType.NVarChar,20);
                pa[0].Value = lnIdPlan;
            
                objCnx = new clsConexion("");
                dtEqPLan = objCnx.EjecutarProcedimientoDT("uspDevolverAccesoriosE", pa);

                return dtEqPLan;
            }

            catch (Exception ex)
            {

                objUtil.gsLogAplicativo("DAInstalacion.cs", "daGrabarInstalacion", ex.Message);
                throw new Exception(ex.Message);

            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtEqPLan = null;
            }

        }
        public DataTable daServiciosEquipo(String lnIdPlan)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtEqPLan = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@lnIdPlan", SqlDbType.NVarChar,20);
                pa[0].Value = lnIdPlan;

                objCnx = new clsConexion("");
                dtEqPLan = objCnx.EjecutarProcedimientoDT("uspDevolverServiciosE", pa);

                return dtEqPLan;
            }

            catch (Exception ex)
            {

                objUtil.gsLogAplicativo("DAInstalacion.cs", "daGrabarInstalacion", ex.Message);
                throw new Exception(ex.Message);

            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                dtEqPLan = null;
            }

        }
        public List<UbicacionEquipoInstalacion> daDevolverUbicacionIns(Int32 idUbicacion)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUbicacion = new DataTable();
            clsConexion objCnx = null;
            List<UbicacionEquipoInstalacion> lstUbicacion = null;
            Boolean estado = false;
            objUtil = new clsUtil();


            try
            {
                pa[0] = new SqlParameter("@lnIdUbicacion", SqlDbType.Int);
                pa[0].Value = idUbicacion;

                objCnx = new clsConexion("");

                dtUbicacion = objCnx.EjecutarProcedimientoDT("DevolverUbicacionInstalacion", pa);

                lstUbicacion = new List<UbicacionEquipoInstalacion>();

                String Itemcero = (estado == true) ? "Seleccione Ubicacion" : "Seleccione Ubicacion";
                //String otro = (estado == true) ? "Otro" : "otro";

                lstUbicacion.Add(new UbicacionEquipoInstalacion(
                    Convert.ToInt32(0),
                    Convert.ToString(Itemcero)));
                    //Convert.ToString(otro)));



                foreach (DataRow drMenu in dtUbicacion.Rows)
                {
                    lstUbicacion.Add(new UbicacionEquipoInstalacion(Convert.ToInt32(drMenu["idUbicacion"]),
                        Convert.ToString(drMenu["Ubicacion_Equipo"])));
                      
                }

                lstUbicacion.Add(new UbicacionEquipoInstalacion(
                    Convert.ToInt32(-3),
                    Convert.ToString("Otro")));

                return lstUbicacion;


            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAInstalacion.cs", "daGrabarInstalacion", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
            }


        }

        public DataTable daBuscarInstalacion(Boolean habilitarfechas, String fechaInical, String fechaFinal, String placaVehiculo, String cEstadoInstal, Int32 numPagina, Int32 tipoCon, Int32 codTipoVenta, Int32 idUsuario)
        {
            SqlParameter[] pa = new SqlParameter[9];
            DataTable dtVentaG;
            clsConexion objCnx = null;

            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peHabilitarFechas", SqlDbType.TinyInt) { Value = habilitarfechas };
                pa[1] = new SqlParameter("@peFechaInical", SqlDbType.Date) { Value = fechaInical };
                pa[2] = new SqlParameter("@peFechaFinal", SqlDbType.Date) { Value = fechaFinal };
                pa[3] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 15) { Value = placaVehiculo };
                pa[4] = new SqlParameter("@pcEstadoInstal", SqlDbType.VarChar, 15) { Value = cEstadoInstal };
                pa[5] = new SqlParameter("@numPagina", SqlDbType.Int) { Value = numPagina };
                pa[6] = new SqlParameter("@tipoCon", SqlDbType.Real) { Value = tipoCon };
                pa[7] = new SqlParameter("@codTipoVenta", SqlDbType.Int) { Value = codTipoVenta };
                pa[8] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = idUsuario };

                objCnx = new clsConexion("");
               
                dtVentaG = objCnx.EjecutarProcedimientoDT("uspBuscarInstalaciones", pa);
                

                return dtVentaG;
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


    }
}
