using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntidad;

namespace CapaNegocio
{
    public class BLPersonal
    {
        public List<Personal> blDevolverPersonal(Int32 idPersonal)
        {
            daPersonal objPersonal = new daPersonal();
            try
            {
                return objPersonal.daDevolverPersonal(idPersonal);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Personal> blBuscarPersonal(Int32 NumPagina ,String pcBuscar, Int32 pnTipoCon)
        {

            daPersonal objPersonal = new daPersonal();
            try
            {
                return objPersonal.daBuscarPersonal(NumPagina, pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Personal> blListarPersonal(Int32 idPersonal)
        {
            daPersonal objPersonal = new daPersonal();
            try
            {
                return objPersonal.daListarPersonal(idPersonal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String blGrabarPersonal(Personal objetoPersonal, Int16 pnTipoCon)
        {

            daPersonal objPersonal = new daPersonal();
            try
            {
                return objPersonal.daGrabarPersonal(objetoPersonal, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
