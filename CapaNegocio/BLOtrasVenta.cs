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
    public class BLOtrasVenta
    {
        public BLOtrasVenta() {  }
        DAOtrasVenta daObjTipoVenta = null;
        public DataTable blBuscarTipoventas(String pcBusqueda, List<TipoVenta> lsTipoVenta, Int32 numPaginacion, Int32 tipocon)
        {
            daObjTipoVenta = new DAOtrasVenta(); ;

            try
            {
                return daObjTipoVenta.daBuscarTipoVenta(pcBusqueda, lsTipoVenta,  numPaginacion,  tipocon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable blListarVentas(Int32 idDocumento, String pcBusqueda, Boolean activarFechas, DateTime fechaInicio, DateTime fechaFin, Int32 tipoVenta,String tipoDocVenta, Int32 idMarca,Int32 idModelo, Int32 pagInicio)
        {
            daObjTipoVenta = new DAOtrasVenta(); ;

            try
            {
                return daObjTipoVenta.daListarVentas(idDocumento,  pcBusqueda,  activarFechas,  fechaInicio,  fechaFin,  tipoVenta, tipoDocVenta,  idMarca,  idModelo, pagInicio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable blDevloverTipoventas(Int32 tipoVenta, Int32 idObtVenta)
        {
            daObjTipoVenta = new DAOtrasVenta(); ;

            try
            {
                return daObjTipoVenta.daDevolverTipoVenta( tipoVenta, idObtVenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Boolean blGuardarOtrasVentas(OtrasVentas clsOtrasVentas, List<xmlDocumentoVentaGeneral> xmlDocumentoVenta, Int32 tipCon)
        {
            daObjTipoVenta = new DAOtrasVenta();
            try
            {
                return daObjTipoVenta.daGuardarOtrasVenta(clsOtrasVentas,xmlDocumentoVenta, tipCon);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public xmlDocumentoVentaGeneral blBuscarDocumentoVenta(Int32 codVenta)
        {
            daObjTipoVenta = new DAOtrasVenta();
            try
            {
                return daObjTipoVenta.daBuscarDocumentoVenta(codVenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public xmlDocumentoVentaGeneral blBuscarDocumentoVentaGeneral(String codVenta,Int32 idTipoCon ,Int32 idTipoTarifa,Int32 idContrato)
        {
            daObjTipoVenta = new DAOtrasVenta();
            try
            {
                return daObjTipoVenta.daBuscarDocumentoVentaGeneral(codVenta, idTipoCon, idTipoTarifa, idContrato);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }


        public List<Cargo> blDevolverTablaCod(String cCodTab, Int32 idTipoDocPers, Int32 Busqueda)
        {

            daObjTipoVenta = new DAOtrasVenta();
            try
            {
                return daObjTipoVenta.daDevolverTablaCod(cCodTab, idTipoDocPers,  Busqueda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Double blDevolverIgv(String cCodTab)
        {

            daObjTipoVenta = new DAOtrasVenta();
            try
            {
                return daObjTipoVenta.daDevolverIgv(cCodTab);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blBuscarCliente(String nroDocumento, String estCliente, Int32 idVehiculo, Int32 tipoCon)
        {

            DAOtrasVenta objCliente = new DAOtrasVenta();
            try
            {
                return objCliente.daBuscarCliente(nroDocumento, estCliente, idVehiculo, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blListarClienteOtrasVentas(Int32 idPersonal, Int32 pnTipoCon)
        {
            DAOtrasVenta objCliente = new DAOtrasVenta();
            try
            {
                return objCliente.daListarClienteOtrasVentas(idPersonal, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
