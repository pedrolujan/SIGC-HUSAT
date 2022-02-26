using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Data.Common;

namespace CapaConexion
{
    public class clsConexion
    {
        public SqlConnection strConexion;
        //public IDbTransaction myTrans;
        public SqlTransaction myTrans;
        private SqlCommand cmdComando;
        private Boolean bActiva = false;
        private String lsCadena = "";
        private int nTimeOut;

        //Constructor
        public clsConexion( string psBaseDatos = "", int pnTimenOut = 7200)
        {
            LeerIni(psBaseDatos);
            strConexion = new SqlConnection(lsCadena);
            strConexion.Open();
            nTimeOut = pnTimenOut;
        }

        //Funcion que lee el archivo ini , donde obtiene la cadena de conección
        private Boolean LeerIni(string psBaseDatos)
        {
            Boolean bResult = false;
            String lsIni;
            try
            {
                lsIni = "SIGC.ini";
                lsCadena = LeerArchivo(psBaseDatos, lsIni);
                bResult = true;
            }
            catch (Exception)
            {
                bResult = false;
            }
            return bResult;
        }

        private String LeerArchivo( string psBaseDatos, string lsIni)
        {
            Encripta.Encrypt oEnc = new Encripta.Encrypt();
            int k = 0;
            String Pass = "";
            String Usuario = "";
            String BaseDatos = "";
            String lsCadenaCon = ""; String cArchivo = ""; String cClave1 = ""; String cClave2 = ""; String sLine = ""; String Source = "";
            try
            {
                cArchivo = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

                if (cArchivo.Substring(cArchivo.Length - 1, 1) == "\\")
                {
                    cArchivo = cArchivo + lsIni;
                }
                else
                {
                    cArchivo = cArchivo + @"\" + lsIni;
                }

                StreamReader objReader = new StreamReader(cArchivo, Encoding.Default);
                do
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {
                        k = sLine.IndexOf("=");
                        if (k > 0)
                        {
                            //cClave1 = oEnc.ConvertirClave(sLine.Substring(0, k), "", false);
                            //cClave2 = oEnc.ConvertirClave(sLine.Substring(k + 1, sLine.Length - (k + 1)), "", false);
                            cClave1 = sLine.Substring(0, k);
                            cClave2 = sLine.Substring(k + 1, sLine.Length - (k + 1));
                            if (cClave1 == "Server")
                            {
                                Source = cClave2;
                            }
                            else if (cClave1 == "DataBase")
                            {
                                if (psBaseDatos == "")
                                {
                                    psBaseDatos = cClave2;
                                }
                                //Sino le especifica la base de datos
                                //obtiene la base de datos del Ini
                                BaseDatos = psBaseDatos;
                            }
                            else if (cClave1 == "Password")
                            {
                                Pass = cClave2;
                            }
                            else if (cClave1 == "User")
                            {
                                Usuario = cClave2;
                            }
                        }
                    }
                }
                while (sLine != null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (Pass.Trim() == "" || Usuario.Trim() == "")
                lsCadena = "Integrated Security=True;INITIAL CATALOG=" + ((BaseDatos.Trim())) + ";DATA SOURCE=" + ((Source.Trim())) + "";
            else
                lsCadena = "User ID=" + ((Usuario.Trim())) + ";Password=" + ((Pass.Trim())) + ";INITIAL CATALOG=" + ((BaseDatos.Trim())) + ";DATA SOURCE=" + ((Source.Trim())) + "";

            lsCadenaCon = lsCadena;
            return lsCadenaCon;
        }

        public Int32 EjecutarProcedimiento(string storedProcedureName, params object[] parameterValues)
        {

            Int32 nRowsAfec = 0;
            try
            {
                if (bActiva == true)
                {
                    cmdComando = new SqlCommand(storedProcedureName, strConexion, myTrans);
                    cmdComando.CommandTimeout = nTimeOut;
                }
                else
                {
                    cmdComando = new SqlCommand(storedProcedureName, strConexion);
                    cmdComando.CommandTimeout = nTimeOut;
                }
                cmdComando.CommandType = CommandType.StoredProcedure;
                AssignParameterValues(cmdComando, parameterValues);

                nRowsAfec = cmdComando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            return nRowsAfec;
        }

        void AssignParameterValues(DbCommand command, object[] values)
        {
            foreach (IDataParameter parameter in values)
            {
                command.Parameters.Add(parameter);
            }

        }


        public DataSet EjecutarProcedimientoDS(string storedProcedureName, params object[] parameterValues)
        {
            DataSet dsResultado = new DataSet();
            SqlDataAdapter da;
            try
            {
                if (bActiva == true)
                {
                    cmdComando = new SqlCommand(storedProcedureName, strConexion, myTrans);
                    cmdComando.CommandTimeout = nTimeOut;

                }
                else
                {
                    cmdComando = new SqlCommand(storedProcedureName, strConexion);
                    cmdComando.CommandTimeout = nTimeOut;

                }
                cmdComando.CommandType = CommandType.StoredProcedure;
                AssignParameterValues(cmdComando, parameterValues);
                da = new SqlDataAdapter(cmdComando);
                da.Fill(dsResultado);
                return dsResultado;
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }

        }


        public DataTable EjecutarProcedimientoDT(string storedProcedureName, params object[] parameterValues)
        {
            DataTable dtResultado = new DataTable();
            SqlDataAdapter da;
            try
            {
                if (bActiva == true)
                {
                    cmdComando = new SqlCommand(storedProcedureName, strConexion, myTrans);
                    cmdComando.CommandTimeout = nTimeOut;

                }
                else
                {
                    cmdComando = new SqlCommand(storedProcedureName, strConexion);
                    cmdComando.CommandTimeout = nTimeOut;

                }
                cmdComando.CommandType = CommandType.StoredProcedure;
                if (parameterValues != null)
                {
                    AssignParameterValues(cmdComando, parameterValues);
                }

                da = new SqlDataAdapter(cmdComando);
                da.Fill(dtResultado);
                return dtResultado;
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }

        }

        public DataTable CargaDataTable(String sSQL)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                cmdComando = new SqlCommand(sSQL, strConexion, myTrans);
                cmdComando.CommandTimeout = nTimeOut;
                SqlDataAdapter da = new SqlDataAdapter(cmdComando);
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        public DataSet CargaDataSet(String sSQL)
        {
            DataSet ds = new DataSet();
            try
            {
                cmdComando = new SqlCommand(sSQL, strConexion, myTrans);
                cmdComando.CommandTimeout = nTimeOut;
                SqlDataAdapter da = new SqlDataAdapter(cmdComando);
                da.Fill(ds);
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }

        public Int32 Ejecutar(String sSQL)
        {
            Int32 nRowsAfec = 0;
            try
            {
                if (bActiva == true)
                {
                    cmdComando = new SqlCommand(sSQL, strConexion, myTrans);
                    cmdComando.CommandTimeout = nTimeOut;
                }
                else
                {
                    cmdComando = new SqlCommand(sSQL, strConexion);
                    cmdComando.CommandTimeout = nTimeOut;
                }

                nRowsAfec = cmdComando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            return nRowsAfec;
        }

        public void CierraConexion()
        {
            strConexion.Close();
            strConexion.Dispose();
        }

        public void BeginT()
        {
            myTrans = strConexion.BeginTransaction();
            bActiva = true;
        }

        public void Commit()
        {
            myTrans.Commit();
            bActiva = false;
        }

        public void RollBackT()
        {
            myTrans.Rollback();
            bActiva = false;
        }
    }


}
