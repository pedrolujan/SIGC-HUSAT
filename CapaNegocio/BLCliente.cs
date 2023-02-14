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


        public DataTable blBuscarBajaServicios(Int32 numPagina, String nplaca, Int32 estadoServ, Int32 tipoCon)
        {

            DACliente objCliente = new DACliente();
            try
            {
                return objCliente.daBuscarBajaServicios(numPagina, nplaca, estadoServ, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Boolean blGuardarServicios( Int32 idServ,String nomServ, DateTime FechaServ,Double precioServ,String descServ,Boolean estadoServ,Int32 idusuario,Int32 monedaServ, Int32 tipoCon)
        {

            DACliente objCliente = new DACliente();
            try
            {
                return objCliente.dtGuardarServicios( idServ,nomServ,FechaServ,precioServ, descServ, estadoServ, idusuario, monedaServ, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blBuscarServicios( Int32 numPagina, String snombre ,Int32 estadoServ, Int32 tipoCon)
        {

            DACliente objCliente = new DACliente();
            try
            {
                return objCliente.daBuscarServicios(  numPagina, snombre, estadoServ, tipoCon);
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
