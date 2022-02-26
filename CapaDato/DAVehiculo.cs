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
    public class DAVehiculo
    {
        private clsUtil objUtil = null;

        public DAVehiculo() { }

        public DataTable daBuscarConsultas(String pcBuscar, Boolean HabilitarFechas, DateTime dtfechaInicio, DateTime dtFechaFinal, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 30);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@HabilitarFechas", SqlDbType.TinyInt);
                pa[1].Value = HabilitarFechas;
                pa[2] = new SqlParameter("@dtFechaInicio", SqlDbType.DateTime);
                pa[2].Value = dtfechaInicio;
                pa[3] = new SqlParameter("@dtFechaFinal", SqlDbType.DateTime);
                pa[3].Value = dtFechaFinal;
                pa[4] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[4].Value = tipoCon;
                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarConsultasVehiculoM", pa);

                return dtEquipo;
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
        public DataTable daBuscarMovimiento(Int32 pcBuscar, Int32 Pagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtEquipo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idVehiculo", SqlDbType.Int);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[1].Value = Pagina;
                pa[2] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[2].Value = tipoCon;
                objCnx = new clsConexion("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarMovimientoVehiculo", pa);

                return dtEquipo;
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
        public DataTable DaBuscarVehiculo(DatosEnviarVehiculo objEnvio, Int32 pagina, Int32 TipoConPagina)
        {
            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50) { Value = objEnvio.busqueda };
                pa[1] = new SqlParameter("@peEstserie", SqlDbType.TinyInt) { Value = objEnvio.estPropietario };
                pa[2] = new SqlParameter("@peEstPlaca", SqlDbType.TinyInt) { Value = objEnvio.estPlaca };
                pa[3] = new SqlParameter("@pePagina", SqlDbType.Int) { Value = pagina };
                pa[4] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = TipoConPagina };

                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspBuscarVehiculo", pa);

                return dtVehiculo;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAVehiculo.cs", "DaBuscarVehiculo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }

        }

        public Vehiculo daListarVehiculo(Int32 idVehiculo)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            Vehiculo lstVehiculo = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidVehiculo", SqlDbType.Int);
                pa[0].Value = idVehiculo;

                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarVehiculo", pa);

                lstVehiculo = new Vehiculo();
                foreach (DataRow drVehiculo in dtVehiculo.Rows)
                {
                    lstVehiculo.idVehiculo = Convert.ToInt32(drVehiculo["idVehiculo"]);
                    lstVehiculo.idClase = Convert.ToInt32(drVehiculo["idClaseV"]);
                    lstVehiculo.vPlaca = Convert.ToString(drVehiculo["vPlaca"]);
                    lstVehiculo.idMarcaV = Convert.ToInt32(drVehiculo["idMarcaV"]);
                    lstVehiculo.idModeloV = Convert.ToInt32(drVehiculo["idModeloV"]);
                    lstVehiculo.ModoUso = Convert.ToInt32(drVehiculo["idModoUso"]);
                    lstVehiculo.vSerie = Convert.ToString(drVehiculo["vSerie"]);
                    lstVehiculo.anio = Convert.ToInt32(drVehiculo["vAnio"]);
                    lstVehiculo.vColor = Convert.ToString(drVehiculo["vColor"]);
                    lstVehiculo.Observaciones = Convert.ToString(drVehiculo["vObservaciones"]);
                }

                return lstVehiculo;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAVehiculo.cs", "daListarVehiculo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstVehiculo = null;
            }

        }

        public String daGrabarvehiculo(Vehiculo objvehiculo, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[16];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@peidVehiculo", SqlDbType.Int);
                pa[0].Value = objvehiculo.idVehiculo;
                pa[1] = new SqlParameter("@pevidClase", SqlDbType.Int);
                pa[1].Value = objvehiculo.idClase;
                pa[2] = new SqlParameter("@pevPlaca", SqlDbType.NVarChar, 50);
                pa[2].Value = objvehiculo.vPlaca;
                pa[3] = new SqlParameter("@peidDescripVehiculoEsp", SqlDbType.Int);
                pa[3].Value = objvehiculo.idDescriVehiculoEsp;
                pa[4] = new SqlParameter("@peidMarcaV", SqlDbType.Int);
                pa[4].Value = objvehiculo.idMarcaV;
                pa[5] = new SqlParameter("@peidModeloV", SqlDbType.Int);
                pa[5].Value = objvehiculo.idModeloV;
                pa[6] = new SqlParameter("@pevSerie", SqlDbType.NVarChar, 17);
                pa[6].Value = objvehiculo.vSerie;
                pa[7] = new SqlParameter("@pevAnio", SqlDbType.Int);
                pa[7].Value = objvehiculo.anio;
                pa[8] = new SqlParameter("@pevColor", SqlDbType.VarChar, 50);
                pa[8].Value = objvehiculo.vColor;
                pa[9] = new SqlParameter("@peidModoUso", SqlDbType.Int);
                pa[9].Value = objvehiculo.ModoUso;
                pa[10] = new SqlParameter("@peidClienteV", SqlDbType.Int);
                pa[10].Value = objvehiculo.idCliente;               
                pa[11] = new SqlParameter("@pevObservaciones", SqlDbType.VarChar,100);
                pa[11].Value = objvehiculo.Observaciones;
                pa[12] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[12].Value = objvehiculo.bEstado;
                pa[13] = new SqlParameter("@pedFechaReg", SqlDbType.DateTime);
                pa[13].Value = objvehiculo.dFechaReg;
                pa[14] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[14].Value = objvehiculo.idUsuario;

                pa[15] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[15].Value = pnTipoCon;


                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarVehiculo", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAVehiculo.cs", "daGrabarVehiculo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
                objvehiculo = null;

            }

        }

        public List<Vehiculo> daListarVehiculos(Boolean idVehiculo)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<Vehiculo> lstVehiculo = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidVehiculo", SqlDbType.Int);
                pa[0].Value = idVehiculo;

                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarCliente", pa);

                lstVehiculo = new List<Vehiculo>();
                foreach (DataRow drVehiculo in dtVehiculo.Rows)
                {
                    lstVehiculo.Add(new Vehiculo(Convert.ToInt32(drVehiculo["idVehiculo"]),
                                                Convert.ToInt32(drVehiculo["idClaseV"]),
                                                Convert.ToString(drVehiculo["vPlaca"]),
                                                Convert.ToString(drVehiculo["idCliente"])));
                }

                return lstVehiculo;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAVehiculo.cs", "daListarVehiculos", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstVehiculo = null;
            }

        }


        public List<VehiculoYCliente> daObtenerVehiculosYClientes(Boolean idVehiculo)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVehiculo = new DataTable();
            clsConexion objCnx = null;
            List<VehiculoYCliente> lstVehiculo = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidVehiculo", SqlDbType.Int);
                pa[0].Value = idVehiculo;

                objCnx = new clsConexion("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarCliente", pa);

                

                lstVehiculo = new List<VehiculoYCliente>();
                foreach (DataRow drVehiculo in dtVehiculo.Rows)
                {
                    lstVehiculo.Add(new VehiculoYCliente(
                       Convert.ToInt32(drVehiculo["idVehiculo"]),
                       Convert.ToString(drVehiculo["idVehiculo"]),
                        Convert.ToString(drVehiculo["idClaseV"]),
                        Convert.ToString(drVehiculo["vPlaca"]),
                        Convert.ToString(drVehiculo["idCliente"]),
                        Convert.ToInt32(drVehiculo["idCliente"]),
                        Convert.ToInt32(drVehiculo["idCliente"]),
                        Convert.ToString(drVehiculo["idCliente"])));
                }
                

                return lstVehiculo;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAVehiculo.cs", "daListarVehiculos", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstVehiculo = null;
            }

        }
    }
}
