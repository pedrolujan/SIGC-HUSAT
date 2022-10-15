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
    public class BLDocumentoVenta
    {
        public BLDocumentoVenta() { }

        public List<DocumentoVenta> blBuscarDocVenta(String pcBuscar, Int16 pnTipoCon)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.daBuscarDocVenta(pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<DocumentoVenta> blListarDocVenta(Int32 pidVenta)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.daListarDocVenta(pidVenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<DetalleVenta> blListarDetalleVenta(Int32 pidVenta)
        {

            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.daListarDetalleVenta(pidVenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Decimal blDevolverUnidadDestino(Int32 pidUnidadMedida, Int32 pidUnidaDest)
        {

            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.DADevolverUnidadDestino(pidUnidadMedida,pidUnidaDest);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String blGrabarVenta(DocumentoVenta objDoc, DataTable dtDetalleVenta, out Int32 pidVenta, Int16 pnTipoCon)
        {

            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.daGrabarVenta(objDoc,dtDetalleVenta,out pidVenta,pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable BLListarVentaxCliente(Int32 pidCliente, String pcEstado, String pcEstadoVM)
        {

            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.DAListarVentaxCliente(pidCliente, pcEstado, pcEstadoVM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String BLPagarCobro(DocumentoVenta pobjDocVenta, decimal pnSaldo)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.daPagarCobro(pobjDocVenta, pnSaldo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable BLListarPagoCobroVenta(Int32 pidDocumento)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.DAListarPagoCobroVenta(pidDocumento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String blAnularPagoCobro(int pidTrandiaria, int pidVenta, int pidUsuario, string pcFechaSis,int iTipoOpe)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.daAnularPagoCobro(pidTrandiaria, pidVenta, pidUsuario, pcFechaSis, iTipoOpe);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String blAperturarCaja(Int16 pidSucursal, decimal pnMontoApertura, int pidUsuario, string dFechaRegistro, int pidOperacion,List<ReporteBloque> lstCierreAnterior)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.daAperturarCaja(pidSucursal, pnMontoApertura, pidUsuario, dFechaRegistro, pidOperacion, lstCierreAnterior);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<CuadreCaja> blVerificarApertura(String pcFechaSist, Int16 pidSucursal, Int32 idUsuario)
        {

            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.daVerificarApertura(pcFechaSist,pidSucursal,idUsuario);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ReporteBloque> blBuscarImporteCierreAnterior(String pcFechaSist, Int16 pidSucursal, Int32 idUsuario, Int32 tipoCon)
        {

            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.daBuscarImporteCierreAnterior(pcFechaSist,pidSucursal,idUsuario,  tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Cuadre> blListarCajaDia(string pcFecha, Int32 pidUsuario, Int16 pidSucursal, out decimal pnSaldo)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.DAListarCajaDia(pcFecha, pidUsuario, pidSucursal, out  pnSaldo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean blEliminarMovCaja(Int32 pidTrandiaria, int pidUsuario, string pcFechaSis)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.daEliminarMovCaja(pidTrandiaria,pidUsuario,pcFechaSis);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable BLListarConcepto(string pcTipoConcepto, string pcTipoOpe)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.DAListarConcepto(pcTipoConcepto, pcTipoOpe);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable BLListarExtorno(string pcFecha, string pcBuscar, Int16 pidSucursal, Int16 piTipoCon)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.DAListarExtorno(pcFecha, pcBuscar,pidSucursal,piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String blExtornarVenta(Int32 pidVenta, Int16 pidSucursal, Int32 pidUsuario, string pcFecha, Int16 piTipoVenta)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.daExtornarVenta(pidVenta, pidSucursal, pidUsuario, pcFecha,piTipoVenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DetalleVenta> BLReporteVenta(String pcFechaIni, String pcFechaFin)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {

                return objDocVenta.daReporteVenta(pcFechaIni,pcFechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<DetalleVenta> BLReporteVentaXLote(Int32 pidLote)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {

                return objDocVenta.daReporteVentaXLote(pidLote);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ReporteBloque> BLReporteVentaXCliente(Int32 pintIdCliente)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {

                return objDocVenta.daReporteVentaXCliente(pintIdCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DetalleVenta> BLConsultarDeudas(string pcFechaIni, string pcFechaFin, int pintIdLote = 0, Int16 pnTipoLlamada = 0)
        {
            DADocumentoVenta objDocVenta = new DADocumentoVenta();
            try
            {
                return objDocVenta.daConsultarDeudas(pcFechaIni, pcFechaFin, pintIdLote, pnTipoLlamada);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable BLListarVentas(DateTime fechainicial, DateTime fechafinal, string pcbuscar)
        {
            DADocumentoVenta objdocVenta = new DADocumentoVenta();

            try
            {
                return objdocVenta.daAnularVenta(fechainicial, fechafinal, pcbuscar);

            }
            catch( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Boolean BLDAnularDocumentoVenta(String codDocVenta)
        {
            DADocumentoVenta objdocVenta = new DADocumentoVenta();
            try
            {
                return objdocVenta.daAnularDocumentoVeta(codDocVenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
