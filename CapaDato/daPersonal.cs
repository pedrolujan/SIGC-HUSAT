using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaUtil;
using CapaConexion;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace CapaDato
{
    public class daPersonal
    {
        public daPersonal() { }

        private clsUtil objUtil = null;

        public List<Personal> daDevolverPersonal(Int32 idUsuario)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            clsUtil objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peiidPersonal", SqlDbType.Int);
                pa[0].Value = idUsuario;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarPersonal", pa);

                List<Personal> lstPersonal = new List<Personal>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {

                    lstPersonal.Add(new Personal(Convert.ToInt32(drMenu["idPersonal"]), Convert.ToString(drMenu["cPersonal"])));
                }

                return lstPersonal;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPersonal.cs", "daDevolverPersonal", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
            }
        }

        public List<Personal> daBuscarPersonal(Int32 NumPagina, String pcBuscar, Int32 pnTipoCon)
        {


            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Personal> lstPersonal = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@pecValorBuscar", SqlDbType.VarChar, 50);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@peiTipoCon", SqlDbType.Int);
                pa[1].Value = pnTipoCon;
                pa[2] = new SqlParameter("@pePagina", SqlDbType.Int);
                pa[2].Value = NumPagina;


                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspBuscarEmpleado", pa);

                lstPersonal = new List<Personal>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstPersonal.Add(new Personal(

                        Convert.ToInt32(drMenu["idPersonal"]), 
                        Convert.ToString(drMenu["cPersonal"]),
                        Convert.ToString(drMenu["cDocumento"]),
                        Convert.ToInt32(drMenu["ROW_COUNT"])
                        
                        ));
                }

                return lstPersonal;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DaPersonal.cs", "daBuscarPersonal", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstPersonal = null;
            }

        }

        public List<Personal> daListarPersonal(Int32 idProve)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            clsConexion objCnx = null;
            List<Personal> lstPersonal = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidPersonal", SqlDbType.Int);
                pa[0].Value = idProve;



                objCnx = new clsConexion("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarEmpleado", pa);

                lstPersonal = new List<Personal>();
                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    if (drMenu["Perfil"].ToString() =="")
                    {
                        lstPersonal.Add(new Personal(

                          Convert.ToInt32(drMenu["idPersonal"]), Convert.ToString(drMenu["cApePat"]),
                          Convert.ToString(drMenu["cApeMat"]), Convert.ToString(drMenu["cPrimerNom"]),
                          Convert.ToString(drMenu["cSegundoNom"]), Convert.ToString(drMenu["cDocumento"]),
                          Convert.ToString(drMenu["cDireccion"]), Convert.ToDateTime(drMenu["dFecNac"]),
                          Convert.ToString(drMenu["cTipoCargo"]), Convert.ToString(drMenu["cTelefono"]),
                          Convert.ToBoolean(drMenu["bestado"]), Convert.ToString(drMenu["idDepa"]),
                          Convert.ToString(drMenu["idProv"]), Convert.ToString(drMenu["idDist"])));
                    }
                    else
                    {
                    byte[] b = (Byte[])drMenu["Perfil"];
                    MemoryStream ms = new MemoryStream(b);


                    lstPersonal.Add(new Personal(

                           Convert.ToInt32(drMenu["idPersonal"]), Convert.ToString(drMenu["cApePat"]),
                           Convert.ToString(drMenu["cApeMat"]), Convert.ToString(drMenu["cPrimerNom"]),
                           Convert.ToString(drMenu["cSegundoNom"]), Convert.ToString(drMenu["cDocumento"]),
                           Convert.ToString(drMenu["cDireccion"]), Convert.ToDateTime(drMenu["dFecNac"]),
                           Convert.ToString(drMenu["cTipoCargo"]), Convert.ToString(drMenu["cTelefono"]),
                           Convert.ToBoolean(drMenu["bestado"]), Convert.ToString(drMenu["idDepa"]),
                           Convert.ToString(drMenu["idProv"]), Convert.ToString(drMenu["idDist"]),
                          ms, 
                          Convert.ToString(drMenu["Name_ImgPerfil"])

                           ));

                    }
                    //lstPersonal.Add(new Personal
                    //{
                    //    idPersonal = Convert.ToInt32(drMenu["idPersonal"]),
                    //    strPerfil = Convert.ToString(drMenu["Perfil"])
                    //});
                }

                return lstPersonal;

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DaPersonal.cs", "daListarPersonal", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                lstPersonal = null;
            }

        }

        public String daGrabarPersonal(Personal objPersonal, Int16 pnTipoCon)
        {
            SqlParameter[] pa = new SqlParameter[17];
            clsConexion objCnx = null;
            objUtil = new clsUtil();

            try
            {

                pa[0] = new SqlParameter("@peidPersonal", SqlDbType.Int);
                pa[0].Value = objPersonal.idPersonal;
                pa[1] = new SqlParameter("@pecApePat", SqlDbType.NVarChar, 50);
                pa[1].Value = objPersonal.cApePat;
                pa[2] = new SqlParameter("@pecApeMat", SqlDbType.NVarChar, 50);
                pa[2].Value = objPersonal.cApeMat;
                pa[3] = new SqlParameter("@pecPrimerNom", SqlDbType.NVarChar, 50);
                pa[3].Value = objPersonal.cPrimerNom;
                pa[4] = new SqlParameter("@pecSegundoNom", SqlDbType.NVarChar, 50);
                pa[4].Value = objPersonal.cSegundoNom;
                pa[5] = new SqlParameter("@pecDocumento", SqlDbType.NVarChar, 15);
                pa[5].Value = objPersonal.cDocumento;
                pa[6] = new SqlParameter("@pecDireccion", SqlDbType.VarChar, 100);
                pa[6].Value = objPersonal.cDireccion;
                pa[7] = new SqlParameter("@pedFecNac", SqlDbType.DateTime);
                pa[7].Value = objPersonal.dFecNac;
                pa[8] = new SqlParameter("@pecTipoCargo", SqlDbType.NVarChar,8);
                pa[8].Value = objPersonal.cTipoCargo;
                pa[9] = new SqlParameter("@pecTelefono", SqlDbType.NVarChar, 20);
                pa[9].Value = objPersonal.cTelefono;
                pa[10] = new SqlParameter("@pebestado", SqlDbType.Bit);
                pa[10].Value = objPersonal.bEstado;
                pa[11] = new SqlParameter("@pedFechaRegistro", SqlDbType.DateTime);
                pa[11].Value = objPersonal.dFechaRegistro;
                pa[12] = new SqlParameter("@peidUsuario", SqlDbType.Int);
                pa[12].Value = objPersonal.idUsuarioReg;
                pa[13] = new SqlParameter("@peidZona", SqlDbType.Int);
                pa[13].Value = objPersonal.idZona;
                pa[14] = new SqlParameter("@peiTipoCon", SqlDbType.SmallInt);
                pa[14].Value = pnTipoCon;
                pa[15] = new SqlParameter("@Perfil", SqlDbType.Image);
                pa[15].Value = objPersonal.Perfil;
                pa[16] = new SqlParameter("@Name_ImgPerfil", SqlDbType.VarChar);
                pa[16].Value = objPersonal.Name_ImgPerfil;

                objCnx = new clsConexion("");
                objCnx.EjecutarProcedimiento("uspGuardarPersonal", pa);

                return "OK";

            }
            catch (Exception ex)
            {
                objUtil.gsLogAplicativo("DAPersonal.cs", "daGrabarPersonal", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CierraConexion();
                objCnx = null;
                objUtil = null;
                objPersonal = null ;
                
            }

        }

    }
}
