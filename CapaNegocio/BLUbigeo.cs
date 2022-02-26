using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDato;


namespace CapaNegocio
{
    public class BLUbigeo
    {

        public List<Departamento> blDevolverDepartamento(Int32 idDepa)
        {
            DAUbigeo objUbigeo = new DAUbigeo();
            try
            {
                return objUbigeo.daDevolverDepartamento(idDepa);          
            }
            catch (Exception ex)
            {              
                throw new Exception(ex.Message);
            }

        }

        public List<Provincia> blDevolverProvincia(Int32 idProv)
        {

            DAUbigeo objUbigeo = new DAUbigeo();
            try
            {
                return objUbigeo.daDevolverProvincia(idProv);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         

        }

        public List<Distrito> blDevolverDistrito(Int32 idDist)
        {

            DAUbigeo objUbigeo = new DAUbigeo();
            try
            {
                return objUbigeo.daDevolverDistrito(idDist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         

        }

        public String blGrabarDepartamento(Departamento objDepa, Int16 pnTipoCon)
        {
            DAUbigeo objUbigeo = new DAUbigeo();
            try
            {
                return objUbigeo.daGrabarDepartamento(objDepa,pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         

        }

        public String blGrabarProvincia(Provincia objProv, Int16 pnTipoCon)
        {
            DAUbigeo objUbigeo = new DAUbigeo();
            try
            {
                return objUbigeo.daGrabarProvincia(objProv, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         
        }

        public String blGrabarDistrito(Distrito objDist, Int16 pnTipoCon)
        {
            DAUbigeo objUbigeo = new DAUbigeo();
            try
            {
                return objUbigeo.daGrabarDistrito(objDist, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         
        }

        public List<Departamento> blBuscarDepartamento(String pcBuscar, Int16 piTipoCon)
        {
            DAUbigeo objUbigeo = new DAUbigeo();
            try
            {
                return objUbigeo.daBuscarDepartamento(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         
        }

        public List<Provincia> blBuscarProvincia(String pcBuscar, Int16 piTipoCon)
        {
            DAUbigeo objUbigeo = new DAUbigeo();
            try
            {
                return objUbigeo.daBuscarProvincia(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         
        }

        public List<Distrito> blBuscarDistrito(String pcBuscar, Int16 piTipoCon)
        {

            DAUbigeo objUbigeo = new DAUbigeo();
            try
            {
                return objUbigeo.daBuscarDistrito(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }        

        }

        public List<Pais> blDevolverPais(Int32 idPais)
        {
            DAUbigeo objUbigeo = new DAUbigeo();
            try
            {
                return objUbigeo.daDevolverPais(idPais);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
