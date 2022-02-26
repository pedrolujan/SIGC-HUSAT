using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDato;
using System.Data;


namespace CapaNegocio
{
    public class BLOrdenCompra
    {
        public BLOrdenCompra() { }

        public List<OrdenCompra> blBuscarOrdenCompra(String pcBuscar, Int16 pnTipoCon)
        {
            DAOrdenCompra objDocVenta = new DAOrdenCompra();
            try
            {
                return objDocVenta.daBuscarOrdenCompra(pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<OrdenCompra> blListarOrden(Int32 pidVenta)
        {
            DAOrdenCompra objDocVenta = new DAOrdenCompra();
            try
            {
                return objDocVenta.daListarOrdenCompra(pidVenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<DetalleCompra> blListarDetalleCompra(Int32 pidVenta)
        {

            DAOrdenCompra objDocVenta = new DAOrdenCompra();
            try
            {
                return objDocVenta.daListarDetalleCompra(pidVenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String blGrabarCompra(List<TablaOrdenIngreso> lstOrdenIngreso,Operador clsOperador, String tipoordencompra, OrdenCompra objDoc, DataTable dtDetalleCompra, Int16 pnTipoCon, out Int32 pidOrden, out string pcLote)
        {

            DAOrdenCompra objDocVenta = new DAOrdenCompra();
            try
            {
                return objDocVenta.daGrabarOrden(lstOrdenIngreso, clsOperador, tipoordencompra,  objDoc,dtDetalleCompra,pnTipoCon, out pidOrden, out pcLote);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable BLListarOrdenxProveedor(Int32 pidProveedor, Int16 peidEstado)
        {
            
            DAOrdenCompra objDocVenta = new DAOrdenCompra();
            try
            {
                return objDocVenta.DAListarOrdenxProveedor(pidProveedor, peidEstado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String BLPagarDeuda(OrdenCompra pobjDocVenta, decimal pnSaldo)
        {
            DAOrdenCompra objDocVenta = new DAOrdenCompra();
            try
            {
                return objDocVenta.daPagarDeuda(pobjDocVenta, pnSaldo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable BLListarPagoDeudaOC(Int32 pidDocumento)
        {
            DAOrdenCompra objDocVenta = new DAOrdenCompra();
            try
            {
                return objDocVenta.DAListarPagoDeudaOC(pidDocumento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String blAnularPagoDeuda(int pidTrandiaria, int pidOrden, int pidUsuario, string pcFechaSis)
        {
            DAOrdenCompra objDocVenta = new DAOrdenCompra();
            try
            {
                return objDocVenta.daAnularPagoDeuda(pidTrandiaria, pidOrden, pidUsuario, pcFechaSis);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable BLListarLote(Int32 pidLote, Int16 piEstado, bool pbestado, bool pbEstadoRecepcion, Int16 pidSucursal, Int16 piTipoSucursal, Int16 pidAlmacen)
        {

            DAOrdenCompra objDocVenta = new DAOrdenCompra();
            try
            {
                return objDocVenta.DAListarLote(pidLote, piEstado, pbestado, pbEstadoRecepcion, pidSucursal, piTipoSucursal, pidAlmacen);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable DAListarLotexMesa(String pcCodMesa)
        {

            DAOrdenCompra objDocVenta = new DAOrdenCompra();
            try
            {
                return objDocVenta.DAListarLotexMesa(pcCodMesa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<DetalleCompra> BLBuscarLote(String pcBuscar, Int16 pidSucursal, Int16 pnTipoCon, Int16 piTipoSucursal, Int16 pidAlmacen)
        {
            DAOrdenCompra objDocVenta = new DAOrdenCompra();
            try
            {
                return objDocVenta.daBuscarLote(pcBuscar, pidSucursal, pnTipoCon, piTipoSucursal,pidAlmacen);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String BLImprimirLote(Int32 pidOrden)
        {
            DAOrdenCompra objDocVenta = new DAOrdenCompra();
            try
            {
                return objDocVenta.DAImprimirLote(pidOrden);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarOrdenDataTable(String pcBuscar, String pnTipoIngreso, String estPago, DateTime fechaInicial, DateTime fechaFinal, Int32 numPagina, Int32 tipoCon,Int32 idProveedor,Boolean habilitarFechas,String tipocompra)
        {
            DAOrdenCompra objPlan = new DAOrdenCompra();
            try
            {
                return objPlan.daBuscarOrdenDataTable(pcBuscar, pnTipoIngreso, estPago,fechaInicial,fechaFinal,numPagina,tipoCon,idProveedor,habilitarFechas, tipocompra);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarDetalleDataTable(String pcBuscar, String pnTipoIngreso, DateTime fechaInicial, DateTime fechaFinal, Int32 numPagina, Int32 tipoCon, String estIngresoImies, Boolean habilitarFechas,String cboEstadoIngreso, String CodTipoIngreso)
        {
            DAOrdenCompra objPlan = new DAOrdenCompra();
            try
            {
                return objPlan.daBuscarDetalleDataTable( pcBuscar, pnTipoIngreso, fechaInicial, fechaFinal, numPagina, tipoCon, estIngresoImies,habilitarFechas,cboEstadoIngreso,CodTipoIngreso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Int16 blBuscarDocumentoOrden(String pcBuscar, Int16 pnTipoCon)
        {

            DAOrdenCompra objAcc = new DAOrdenCompra();
            try
            {
                return objAcc.daBuscarDocumentoOrden(pcBuscar,pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public OrdenCompra blListarOrdenDataGrid(Int32 codPlan)
        {
            DAOrdenCompra objPlan = new DAOrdenCompra();
            try
            {
                return objPlan.daListarOrdenDatatable(codPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ordencompraSimCard blListarOrdenSimCardDGV(Int32 codPlan)
        {

            DAOrdenCompra objcodplan = new DAOrdenCompra();
            try
            {

                return objcodplan.daListarOrdenSimCard(codPlan);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable blBuscarHistorialDataTable(String pcBuscar,String ordencompra)
        {
            DAOrdenCompra objPlan = new DAOrdenCompra();
            try
            {
                return objPlan.daBuscarHistorialDataTable(pcBuscar, ordencompra);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarImiesDataTable(Int32 idDetalle, Int32 numPagina, Int32 tipo,String tipoIngreso)
        {
            DAOrdenCompra objPlan = new DAOrdenCompra();
            try
            {
                return objPlan.daBuscarImiesDataTable(idDetalle, numPagina, tipo,tipoIngreso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Cargo> blDevolverTablaCod(Int32 cCodTab)
        {

            DAOrdenCompra daobjUsuario = new DAOrdenCompra();
            try
            {
                return daobjUsuario.daDevolverTablaCod(cCodTab);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<TipoOrdenCompra> blDevolverTipoCompra(Int32 idTabcod)
        {
            DAOrdenCompra objOrdenCompra = new DAOrdenCompra();

            try
            {
                return objOrdenCompra.daDevolverTipoCompra(idTabcod);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blDevolverOperadores(Int32 idProveedor,String tipingreso)
        {
            DAOrdenCompra datOperador = new DAOrdenCompra();
            try
            {
                return datOperador.daMostrarOperadores(idProveedor, tipingreso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

    }
}
