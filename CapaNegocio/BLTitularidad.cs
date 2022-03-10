using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLTitularidad
    {
        private object cliente;
        public DataTable BlBuscarTitularidad(Int32 condicion, String dato)
        {
            DATitularidad daobjCliente = new DATitularidad();
            try
            {
                return (daobjCliente.DABuscarTitularidad(condicion, dato));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public DataTable BlBuscarTitularidadEspecificos(Int32 condicion, Int32 idventageneral)
        {
            DATitularidad daobjCliente = new DATitularidad();
            try
            {
                return (daobjCliente.daBuscarTilularidadEspecificos(condicion, idventageneral));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public Int32 blGuardarClienteN(Titularidad clsTitu, Int32 tipocon)
        {
            DATitularidad daobjEquipo = new DATitularidad();
            try
            {
                return daobjEquipo.daGuardarClienteN(clsTitu, tipocon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }


        }

       
    }
}
