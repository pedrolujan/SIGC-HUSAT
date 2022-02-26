using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaConexion;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using CapaUtil;

namespace CapaDato
{
    public class DAUbigeo
    {

        private clsUtil objUtil = null;

        public List<Departamento> daDevolverDepartamento(Int32 idDepa)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Departamento> lstDepa = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidDepa", SqlDbType.Int);
                pa[0].Value = idDepa;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarDepartamento", pa);

                lstDepa = new List<Departamento>();
                lstDepa.Add(new Departamento(
                    Convert.ToInt32(0), 
                    Convert.ToString("Selecc. Dep"),
                          Convert.ToBoolean(1)));
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstDepa.Add(new Departamento(
                        Convert.ToInt32(drMenu["idDepa"]),
                        Convert.ToString(drMenu["cNomDep"]),
                           Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstDepa;

            }
            catch (Exception ex)
            {
                lstDepa = null;
                objUtil.gsLogAplicativo("DAUbigeo.cs", "daDevolverDepartamento", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstDepa = null;
            }

        }
        
        public List<Provincia> daDevolverProvincia(Int32 idProv)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Provincia> lstProv = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidProv", SqlDbType.Int);
                pa[0].Value = idProv;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarProvincia", pa);

                lstProv = new List<Provincia>();
                lstProv.Add(new Provincia(
                    Convert.ToInt32(0),
                    Convert.ToString("Selec. Provincia"),
                           Convert.ToString(""), 
                           Convert.ToBoolean(1)));
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstProv.Add(new Provincia(Convert.ToInt32(drMenu["idProv"]), Convert.ToString(drMenu["cNomProv"]),
                           Convert.ToString(drMenu["cNomDep"]),Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstProv;

            }
            catch (Exception ex)
            {
                lstProv = null;
                objUtil.gsLogAplicativo("DAUbigeo.cs", "daDevolverProvincia", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstProv = null;
            }

        }

        public List<Distrito> daDevolverDistrito(Int32 idDist)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Distrito> lstDist = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidDist", SqlDbType.Int);
                pa[0].Value = idDist;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarDistrito", pa);

                lstDist = new List<Distrito>();
                lstDist.Add(new Distrito(
                    Convert.ToInt32(0),
                    Convert.ToString("Selec. Distrito"),
                            Convert.ToBoolean(1)));
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstDist.Add(new Distrito(Convert.ToInt32(drMenu["idDist"]), Convert.ToString(drMenu["cNomDist"]),
                            Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstDist;

            }
            catch (Exception ex)
            {
                lstDist = null;
                objUtil.gsLogAplicativo("DAUbigeo.cs", "daDevolverDistrito", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstDist = null;
            }

        }

        public String daGrabarDepartamento(Departamento objDepa, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[6];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidDepa", SqlDbType.Int);
                pa[0].Value = objDepa.idDepa;
                pa[1] = new SqlParameter("@pecNomDepa", SqlDbType.NVarChar, 50);
                pa[1].Value = objDepa.cNomDep;
                pa[2] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[2].Value = objDepa.bEstado;
                pa[3] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[3].Value = objDepa.idUsuario;
                pa[4] = new SqlParameter("@pedFechaReg", SqlDbType.DateTime);
                pa[4].Value = objDepa.dFechaReg;
                pa[5] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[5].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarDepartamento", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAUbigeo.cs", "daGrabarDepartamento", ex.Message);
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

        public String daGrabarProvincia(Provincia objProv, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[7];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidProv", SqlDbType.Int);
                pa[0].Value = objProv.idProv;
                pa[1] = new SqlParameter("@peidDepa", SqlDbType.Int);
                pa[1].Value = objProv.idDepa;
                pa[2] = new SqlParameter("@pecNomProv", SqlDbType.NVarChar, 50);
                pa[2].Value = objProv.cNomProv;
                pa[3] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[3].Value = objProv.bEstado;
                pa[4] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[4].Value = objProv.idUsuario;
                pa[5] = new SqlParameter("@pedFechaReg", SqlDbType.DateTime);
                pa[5].Value = objProv.dFechaReg;
                pa[6] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[6].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarProvincia", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAUbigeo.cs", "daGrabarProvincia", ex.Message);
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

        public String daGrabarDistrito(Distrito objDist , Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[7];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidDist", SqlDbType.Int);
                pa[0].Value = objDist.idDist;
                pa[1] = new SqlParameter("@peidProv", SqlDbType.Int);
                pa[1].Value = objDist.idProv;
                pa[2] = new SqlParameter("@pecNomDist", SqlDbType.NVarChar, 50);
                pa[2].Value = objDist.cNomDist;
                pa[3] = new SqlParameter("@pebEstado", SqlDbType.Bit);
                pa[3].Value = objDist.bEstado;
                pa[4] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[4].Value = objDist.idUsuario;
                pa[5] = new SqlParameter("@pedFechaReg", SqlDbType.DateTime);
                pa[5].Value = objDist.dFechaReg;
                pa[6] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[6].Value = pnTipoCon;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarDistrito", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAUbigeo.cs", "daGrabarDistrito", ex.Message);
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

        public List<Departamento> daBuscarDepartamento(String pcBuscar, Int16 piTipoCon)
        {


            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Departamento> lstDepa = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar,20);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = piTipoCon;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarDepa", pa);

                lstDepa = new List<Departamento>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstDepa.Add(new Departamento(Convert.ToInt32(drMenu["idDepa"]),
                        Convert.ToString(drMenu["cNomDep"]), Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstDepa;

            }
            catch (Exception ex)
            {
                lstDepa = null;
                objUtil.gsLogAplicativo("DAUbigeo.cs", "daBuscarDepartamento", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstDepa = null;
            }
        }

        public List<Provincia> daBuscarProvincia(String pcBuscar, Int16 piTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Provincia> lstProv = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 20);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = piTipoCon;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarProvincia", pa);

                lstProv = new List<Provincia>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstProv.Add(new Provincia(Convert.ToInt32(drMenu["idProv"]),
                        Convert.ToString(drMenu["cNomProv"]), Convert.ToString(drMenu["cNomDep"]),
                        Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstProv;

            }
            catch (Exception ex)
            {
                lstProv = null;
                objUtil.gsLogAplicativo("DAUbigeo.cs", "daBuscarProvincia", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstProv = null;
            }
        }

        public List<Distrito> daBuscarDistrito(String pcBuscar, Int16 piTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Distrito> lstDist = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 20);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.TinyInt);
                pa[1].Value = piTipoCon;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarDistrito", pa);

                lstDist = new List<Distrito>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstDist.Add(new Distrito(Convert.ToInt32(drMenu["idDist"]),
                        Convert.ToString(drMenu["cNomDist"]),Convert.ToString(drMenu["cNomProv"]), 
                        Convert.ToString(drMenu["cNomDep"]),Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstDist;

            }
            catch (Exception ex)
            {
                lstDist = null;
                objUtil.gsLogAplicativo("DAUbigeo.cs", "daBuscarDistrito", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstDist = null;
            }
        }

        public List<Pais> daDevolverPais(Int32 idPais)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Pais> lstPais = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidPais", SqlDbType.Int);
                pa[0].Value = idPais;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarPais", pa);

                lstPais = new List<Pais>();
                lstPais.Add(new Pais(
                    Convert.ToInt32(0),
                    Convert.ToString("Selecc. Pais"),
                          Convert.ToBoolean(1)));
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPais.Add(new Pais(
                        Convert.ToInt32(drMenu["idPais"]),
                        Convert.ToString(drMenu["cNombre"]),
                           Convert.ToBoolean(drMenu["bEstado"])));
                }

                return lstPais;

            }
            catch (Exception ex)
            {
                lstPais = null;
                objUtil.gsLogAplicativo("DAUbigeo.cs", "daDevolverDepartamento", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstPais = null;
            }

        }

    }
}
