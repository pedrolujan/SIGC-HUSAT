using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntidad;

namespace CapaNegocio
{
    public class BLCliente
    {
        public BLCliente() { }

        public DataTable blBuscarServicios(String bnombreCliente, Int32 estCliente, Int32 numPagina, Int32 tipoCon)
        {

            DACliente objCliente = new DACliente();
            try
            {
                return objCliente.daBuscarServicios(bnombreCliente, estCliente, numPagina, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable blBuscarCliente( String bnombreCliente, Int32 estCliente,Int32 numPagina,Int32 tipoCon)
        {

            DACliente objCliente = new DACliente();
            try
            {
                return objCliente.daBuscarCliente(bnombreCliente , estCliente, numPagina, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    

        public Int16 blBuscarNroDocumento(String pcBuscar, Int16 pnTipoCon)
        {

            DACliente objCliente = new DACliente();
            try
            {
                return objCliente.daBuscarNroDocumento(pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Cliente blListarCliente(Int32 idPersonal,Int32 pnTipoCon)
        {
            DACliente objCliente = new DACliente();
            try
            {
                return objCliente.daListarCliente(idPersonal,pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Cliente> blListarClientes(Boolean pbEstado)
        {
            DACliente objCliente = new DACliente();
            try
            {
                return objCliente.daListarClientes(pbEstado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String blGrabarCliente(Cliente objCliente, Int16 pnTipoCon)
        {

            DACliente daobjCliente = new DACliente();
            try
            {
                return daobjCliente.daGrabarCliente(objCliente, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Cliente> blDevolverClientesV(Int32 idCliente)
        {

            DACliente objCliente = new DACliente();
            try
            {
                return objCliente.daDevolverCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<TipoCliente> blDevolverTipoCliente(Int32 idCliente)
        {

            DACliente objCliente = new DACliente();
            try
            {
                return objCliente.daDevolverTipoCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
