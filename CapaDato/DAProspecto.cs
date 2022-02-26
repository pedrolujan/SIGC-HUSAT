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
    public class DAProspecto
    {
        private clsUtil objUtil = null;
        public String daGrabarProspectoPlan(ProspectosPlan objProspecto, Int32 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[20];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idProspectoPlan", SqlDbType.Int) { Value = objProspecto.idProspectoPlan };
                pa[1] = new SqlParameter("@idPropectos", SqlDbType.Int) { Value = objProspecto.idProspecto };
                pa[2] = new SqlParameter("@cNroCelular", SqlDbType.NVarChar, 15) { Value = objProspecto.celular1 };
                pa[3] = new SqlParameter("@cNroCelular2", SqlDbType.NVarChar, 15) { Value = objProspecto.celular2 };
                pa[4] = new SqlParameter("@cNombre", SqlDbType.NVarChar, 45) { Value = objProspecto.nombres };
                pa[5] = new SqlParameter("@cApellido", SqlDbType.NVarChar, 45) { Value = objProspecto.apellidos };
                pa[6] = new SqlParameter("@cCorreo", SqlDbType.NVarChar, 45) { Value = objProspecto.correo };
                pa[7] = new SqlParameter("@idUso", SqlDbType.Int) { Value = objProspecto.idModoUso };
                pa[8] = new SqlParameter("@cTipoContacto", SqlDbType.NVarChar, 15) { Value = objProspecto.idTipoContacto };
                pa[9] = new SqlParameter("@cObservacion", SqlDbType.NVarChar, 1000) { Value = objProspecto.observaciones };
                pa[10] = new SqlParameter("@idEquipo_Plan", SqlDbType.Int) { Value = objProspecto.idEquipo };
                pa[11] = new SqlParameter("@cCantidadEquipos", SqlDbType.Int) { Value = objProspecto.cantEquipos };
                pa[12] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = objProspecto.idUsuario };
                pa[13] = new SqlParameter("@dFechaRegistro", SqlDbType.DateTime) { Value = objProspecto.fechaRegistro };
                pa[14] = new SqlParameter("@peiTipoCon", SqlDbType.Int) { Value = pnTipoCon };
                pa[15] = new SqlParameter("@bEstado", SqlDbType.NVarChar, 15) { Value = objProspecto.estadoCliente };
                pa[16] = new SqlParameter("@idTipoPlan", SqlDbType.Int) { Value = objProspecto.idTipoPlan };
                pa[17] = new SqlParameter("@idPlan", SqlDbType.Int) { Value = objProspecto.idPlan };
                pa[18] = new SqlParameter("@fechaVisita", SqlDbType.DateTime) { Value = objProspecto.fechaVisita };
                pa[19] = new SqlParameter("@idTarifa", SqlDbType.Int) { Value = objProspecto.idTarifa };

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarProspectoPlan", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daGrabarAccesorio", ex.Message);
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

        public DataTable daBuscarProspectoPlanDataTable(String pcBuscar,String celular, String estado, Int32 numPagina, Int32 tipoCon,String tipoContacto,DateTime fechaInicial,DateTime fechaFinal, Boolean habilitarFecha, Boolean fechaVisita, Boolean fechaRegistroSeg, Boolean fechaSigSeg,Int32 idUsuario,Int32 idTipoPlan,Int32 idPlan, Int32 idTarifa,String lColor , DateTime fechaActual)
        {
            SqlParameter[] pa = new SqlParameter[18];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peBuscar", SqlDbType.VarChar, 45) { Value = pcBuscar };
                pa[1] = new SqlParameter("@peEstado", SqlDbType.NVarChar, 15) { Value = estado };
                pa[2] = new SqlParameter("@cTipoContacto", SqlDbType.NVarChar, 15) { Value = tipoContacto };
                pa[3] = new SqlParameter("@numPagina", SqlDbType.Int) { Value = numPagina };
                pa[4] = new SqlParameter("@tipoCon", SqlDbType.Real) { Value = tipoCon };
                pa[5] = new SqlParameter("@numCelular", SqlDbType.VarChar, 15) { Value = celular };
                pa[6] = new SqlParameter("@fechaInicial", SqlDbType.DateTime) { Value = fechaInicial };
                pa[7] = new SqlParameter("@fechaFinal", SqlDbType.DateTime) { Value = fechaFinal };
                pa[8] = new SqlParameter("@habilitarFecha", SqlDbType.TinyInt) { Value = habilitarFecha };
                pa[9] = new SqlParameter("@fechaVisita", SqlDbType.TinyInt) { Value = fechaVisita };
                pa[10] = new SqlParameter("@fechaRegSeg", SqlDbType.TinyInt) { Value = fechaRegistroSeg };
                pa[11] = new SqlParameter("@fechaSigSeg", SqlDbType.TinyInt) { Value = fechaSigSeg };
                pa[12] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = idUsuario };
                pa[13] = new SqlParameter("@idTipoPlan", SqlDbType.Int) { Value = idTipoPlan };
                pa[14] = new SqlParameter("@idPlan", SqlDbType.Int) { Value = idPlan };
                pa[15] = new SqlParameter("@idTipoTarifa", SqlDbType.Int) { Value = idTarifa };
                pa[16] = new SqlParameter("@LetraColor", SqlDbType.VarChar) { Value = lColor };
                pa[17] = new SqlParameter("@dFechaActual", SqlDbType.DateTime) { Value =fechaActual  };

                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspBuscarProspectoPlan", pa);

                return dtAccesorio;
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
        public DataTable daBuscarProspectoDataTable(String numCelular, String nombreCliente, Int32 numPagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@nombreCliente", SqlDbType.VarChar, 45);
                pa[0].Value = nombreCliente;
                pa[1] = new SqlParameter("@numCelular", SqlDbType.NVarChar, 15);
                pa[1].Value = numCelular;
                pa[2] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[2].Value = numPagina;
                pa[3] = new SqlParameter("@tipoCon", SqlDbType.Real);
                pa[3].Value = tipoCon;
                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspBuscarProspectoEspecifico", pa);

                return dtAccesorio;
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

        public ProspectosPlan daListarProspectoPlanDatatable(Int32 idCliente, Int32 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            ProspectosPlan lstProsp = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peIdProspecto", SqlDbType.Int);
                pa[0].Value = idCliente;
                pa[1] = new SqlParameter("@peTipoCon", SqlDbType.Int);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarProspectoPlan", pa);

                lstProsp = new ProspectosPlan();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstProsp.idProspectoPlan = Convert.ToInt32(drMenu["idProspectoPlan"]);
                    lstProsp.idProspecto = Convert.ToInt32(drMenu["idProspecto"]);
                    lstProsp.nombres = Convert.ToString(drMenu["cNombre"]);
                    lstProsp.apellidos = Convert.ToString(drMenu["cApellido"]);
                    lstProsp.celular1 = Convert.ToString(drMenu["cNroCelular1"]);
                    lstProsp.celular2 = Convert.ToString(drMenu["cNroCelular2"]);
                    lstProsp.estadoCliente = Convert.ToString(drMenu["bEstadoCliente"]);
                    lstProsp.correo = Convert.ToString(drMenu["cCorreo"]);
                    lstProsp.idClase = Convert.ToInt32(drMenu["idClaseV"]);
                    lstProsp.idModoUso = Convert.ToInt32(drMenu["idUso"]);
                    lstProsp.idTipoContacto = Convert.ToString(drMenu["cTipoContacto"]);
                    lstProsp.observaciones = Convert.ToString(drMenu["cObservacion"]);
                    lstProsp.idTipoPlan = Convert.ToInt32(drMenu["idTipoPlan"]);
                    lstProsp.idPlan = Convert.ToInt32(drMenu["idPlan"]);
                    lstProsp.idEquipo = Convert.ToInt32(drMenu["idEquipoPlan"]);
                    lstProsp.cantEquipos = Convert.ToInt32(drMenu["cCanEquipos"]);
                    lstProsp.fechaVisita = Convert.ToDateTime(drMenu["dFechaVisita"]);
                    lstProsp.nombreUsuario = Convert.ToString(drMenu["cUser"]);
                    lstProsp.idTarifa = Convert.ToInt32(drMenu["idTarifa"]);
                }

                return lstProsp;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daListarEquipo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstProsp = null;
            }
        }
        public Prospecto daListarProspectoDatatable(Int32 idCliente, Int32 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Prospecto lstProsp = null;
            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peIdProspecto", SqlDbType.Int);
                pa[0].Value = idCliente;
                pa[1] = new SqlParameter("@peTipoCon", SqlDbType.Int);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarProspectoEspecifico", pa);

                lstProsp = new Prospecto();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstProsp.idProspecto = Convert.ToInt32(drMenu["idProspecto"]);
                    lstProsp.nombres = Convert.ToString(drMenu["cNombre"]);
                    lstProsp.apellidos = Convert.ToString(drMenu["cApellido"]);
                    lstProsp.celular1 = Convert.ToString(drMenu["cNroCelular1"]);
                    lstProsp.celular2 = Convert.ToString(drMenu["cNroCelular2"]);
                    lstProsp.correo = Convert.ToString(drMenu["cCorreo"]);
                }

                return lstProsp;
            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DACliente.cs", "daListarEquipo", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstProsp = null;
            }
        }

        public Int16 daBuscarTelefonoProspecto(String pcBuscar, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 15);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.Int);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarTelefonoProspecto", pa);

                Int16 numFilas;

                if (dtUsuario.Rows.Count > 0)
                {
                    numFilas = 1;
                }
                else
                {
                    numFilas = 0;
                }

                return numFilas;

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

        public Prospecto daBuscarClienteXTelefono(String pcBuscar, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            Prospecto lstProsp = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 15);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.Int);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarClienteXTelefono", pa);

                lstProsp = new Prospecto();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstProsp.idProspecto = Convert.ToInt32(drMenu["idProspecto"]);
                    lstProsp.nombres = Convert.ToString(drMenu["cNombre"]);
                    lstProsp.apellidos = Convert.ToString(drMenu["cApellido"]);
                    lstProsp.celular1 = Convert.ToString(drMenu["cNroCelular1"]);
                    lstProsp.celular2 = Convert.ToString(drMenu["cNroCelular2"]);
                    lstProsp.correo = Convert.ToString(drMenu["cCorreo"]);


                }

                return lstProsp;

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
        public DataTable daBuscarPlanXTelefono(String pcBuscar, Int16 pnTipoCon)
        {

            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 15);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.Int);
                pa[1].Value = pnTipoCon;

                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarPlanesXTelefono", pa);

                return dtUsuario;

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
        public String daGrabarSeguimiento(Seguimiento objProspecto, Int32 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[8];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idSeguimiento", SqlDbType.Int);
                pa[0].Value = objProspecto.idSeguimiento;
                pa[1] = new SqlParameter("@idProspectoPlan", SqlDbType.Int);
                pa[1].Value = objProspecto.idProspectoPlan;
                pa[2] = new SqlParameter("@cObservacion", SqlDbType.NVarChar, 1000);
                pa[2].Value = objProspecto.observacion;
                pa[3] = new SqlParameter("@cFechaSigSegimiento", SqlDbType.DateTime);
                pa[3].Value = objProspecto.fechaProxSeguimiento;
                pa[4] = new SqlParameter("@dFechaRegistro", SqlDbType.DateTime );
                pa[4].Value = objProspecto.fechaRegistro;
                pa[5] = new SqlParameter("@idUsuario", SqlDbType.Int);
                pa[5].Value = objProspecto.idUsuario;
                pa[6] = new SqlParameter("@peTipoCon", SqlDbType.Int);
                pa[6].Value = pnTipoCon;
                pa[7] = new SqlParameter("@estadoCliente", SqlDbType.NVarChar,15);
                pa[7].Value = objProspecto.estadoCliente;


                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarSeguimiento", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daGrabarAccesorio", ex.Message);
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

        public DataTable daBuscarSeguimientoDataTable(Int32 idOferta, Int32 numPagina, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtAccesorio = new DataTable();
            clsConexion objCnx = null;

            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idProspectoPlan", SqlDbType.Int);
                pa[0].Value = idOferta;
                pa[1] = new SqlParameter("@numPagina", SqlDbType.Int);
                pa[1].Value = numPagina;
                pa[2] = new SqlParameter("@tipoCon", SqlDbType.Real);
                pa[2].Value = tipoCon;
                objCnx = new clsConexion("");
                dtAccesorio = objCnx.EjecutarProcedimientoDT("uspBuscarSeguimientoEspecifico", pa);

                return dtAccesorio;
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


        public String daGrabarProspecto(Prospecto objProspecto, Int32 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[9];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {
                pa[0] = new SqlParameter("@idPropectos", SqlDbType.Int);
                pa[0].Value = objProspecto.idProspecto;
                pa[1] = new SqlParameter("@cNombre", SqlDbType.NVarChar, 45);
                pa[1].Value = objProspecto.nombres;
                pa[2] = new SqlParameter("@cApellido", SqlDbType.NVarChar, 45);
                pa[2].Value = objProspecto.apellidos;
                pa[3] = new SqlParameter("@cNroCelular", SqlDbType.NVarChar, 15);
                pa[3].Value = objProspecto.celular1;
                pa[4] = new SqlParameter("@cNroCelular2", SqlDbType.NVarChar, 15);
                pa[4].Value = objProspecto.celular2;
                pa[5] = new SqlParameter("@cCorreo", SqlDbType.NVarChar, 45);
                pa[5].Value = objProspecto.correo;
                pa[6] = new SqlParameter("@idUsuario", SqlDbType.Int);
                pa[6].Value = objProspecto.idUsuario;
                pa[7] = new SqlParameter("@dFechaRegistro", SqlDbType.DateTime);
                pa[7].Value = objProspecto.fechaRegistro;
                pa[8] = new SqlParameter("@peiTipoCon", SqlDbType.Int);
                pa[8].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarProspectos", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAAccesorios.cs", "daGrabarAccesorio", ex.Message);
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


        public totalRanking daTotalesRankingSeguimiento(String pcBuscar, String celular, String tipoContacto, DateTime fechaInicial, DateTime fechaFinal, Boolean habilitarFecha, Boolean fechaVisita, Boolean fechaRegistroSeg, Boolean fechaSigSeg, Int32 idUsuario,DateTime fechaActual,Int32 idTipoPlan, Int32 idPlan,Int32 idTipoTarifa)
        {
            SqlParameter[] pa = new SqlParameter[14];
            DataTable dtUsuario = new DataTable();
            totalRanking lstTotRank ;
            clsConexion objCnx = null;

            objUtil = new clsUtil();
            try
            {
                pa[0] = new SqlParameter("@peBuscar", SqlDbType.VarChar, 45) { Value = pcBuscar };
                pa[1] = new SqlParameter("@cTipoContacto", SqlDbType.NVarChar, 15) { Value = tipoContacto };
                pa[2] = new SqlParameter("@numCelular", SqlDbType.VarChar, 15) { Value = celular };
                pa[3] = new SqlParameter("@fechaInicial", SqlDbType.DateTime) { Value = fechaInicial };
                pa[4] = new SqlParameter("@fechaFinal", SqlDbType.DateTime) { Value = fechaFinal };
                pa[5] = new SqlParameter("@habilitarFecha", SqlDbType.TinyInt) { Value = habilitarFecha };
                pa[6] = new SqlParameter("@fechaVisita", SqlDbType.TinyInt) { Value = fechaVisita };
                pa[7] = new SqlParameter("@fechaRegistro", SqlDbType.TinyInt) { Value = fechaRegistroSeg };
                pa[8] = new SqlParameter("@fechaProxSeg", SqlDbType.TinyInt) { Value = fechaSigSeg };
                pa[9] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = idUsuario };
                pa[10] = new SqlParameter("@fechaActual", SqlDbType.DateTime) { Value = fechaActual };
                pa[11] = new SqlParameter("@idTipoPlan", SqlDbType.Int) { Value = idTipoPlan };
                pa[12] = new SqlParameter("@idPlan", SqlDbType.Int) { Value = idPlan };
                pa[13] = new SqlParameter("@idTipoTarifa", SqlDbType.Int) { Value = idTipoTarifa };
                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarColoresSeguimiento", pa);

                lstTotRank = new totalRanking();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstTotRank.totalVerdes = Convert.ToInt32(drMenu["CANTVERDE"]);
                    lstTotRank.totalAmarillos = Convert.ToInt32(drMenu["CANTAMARILLO"]);
                    lstTotRank.totalRojos = Convert.ToInt32(drMenu["CANTROJOS"]);
                }
                return lstTotRank;
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
