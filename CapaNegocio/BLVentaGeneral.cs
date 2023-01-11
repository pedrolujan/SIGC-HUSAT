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
    public class BLVentaGeneral
    {
        public Boolean blGenerarVentaGeneral(VentaGeneral objVG, List<xmlDocumentoVentaGeneral> xmlDocumentoVenta,Int16 tipoCon)
        {
            DAVentaGeneral objDAVG = new DAVentaGeneral(); 
            try
            {
                return objDAVG.daGenerarVentaGeneral(objVG,xmlDocumentoVenta, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Boolean blActualizarEstadoContratoAutomatico(Int32 tipoCon)
        {

            DAVentaGeneral objAECA = new DAVentaGeneral();
            try
            {
                return objAECA.DAActualizarEstadoContratoAutomatico(tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable blBuscarVentaGeneral(Boolean habilitarfechas,String fechaInical, String fechaFinal,String fechaAct, String placaVehiculo,String cEstadoInstal, Int32 numPagina, Int32 tipoLLamada, Int32 tipoCon,Int32 codTipoVenta,String estadoTipoContrato,Boolean habilitarRenovaciones, String valorRadio)
        {
            DAVentaGeneral objVentaG = new DAVentaGeneral();
            try
            {
                return objVentaG.daBuscarVentaGeneral(habilitarfechas, fechaInical, fechaFinal, fechaAct, placaVehiculo, cEstadoInstal,numPagina, tipoLLamada, tipoCon, codTipoVenta, estadoTipoContrato, habilitarRenovaciones, valorRadio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable blBuscarVentaPagoPendientes(Boolean chk,String busq,String dfechaIni,String dfecha,Int32 numPagina,Int32 tipoCon)
        {
            DAVentaGeneral objVentaG = new DAVentaGeneral();
            try
            {
                return objVentaG.daBuscarVentaPagoPendiente( chk,  busq,  dfechaIni,  dfecha,  numPagina,  tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean blGuardarpagosPendientes(Int32 idTrandiaria, List<Pagos> lstTrand, List<xmlDocumentoVentaGeneral> lstXml, Int32 tipoCon)
        {
            DAVentaGeneral objVentaG = new DAVentaGeneral();
            try
            {
                return objVentaG.daGuardarpagosPendientes( idTrandiaria,lstTrand, lstXml,  tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<VentaGeneral> blDevolverVehiculoRenovacion(String cBuscar,String codVenta, Int32 idVehiculo,Int32 idContrato, List<Vehiculo> lstVehiculo)
        {
            DAVentaGeneral objVentaG = new DAVentaGeneral();
            try
            {
                return objVentaG.daDevolverVehiculoRenovacion(cBuscar,codVenta,  idVehiculo, idContrato,  lstVehiculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Personal blObtenerUsuarioActual(Int32 tipoCon)
        {
            DAVentaGeneral objVentaG = new DAVentaGeneral();
            try
            {
                return objVentaG.daDevolverUsuarioActual(tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String blBuscarVentaAImprimir(VentaGeneral objVG, Int16 tipoCon)
        {
            DAVentaGeneral objDAVG = new DAVentaGeneral();
            try
            {
                return objDAVG.daBuscarVentaAImprimir(objVG, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable blBuscarContrato(String codventa, String Placa,Int32 idContrato)
        {
            DAVentaGeneral objDAVG = new DAVentaGeneral();
            try
            {
                return objDAVG.daBuscarContrato( codventa,  Placa, idContrato);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public xmlInstalacion blBuscarActaInstalacion(String codventa, String Placa,Int32 idTipoVenta)
        {
            DAVentaGeneral objDAVG = new DAVentaGeneral();
            try
            {
                return objDAVG.daBuscarActaInstalacion( codventa,  Placa, idTipoVenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Boolean blBAnularVenta(String codventa)
        {
            DAVentaGeneral objDAVG = new DAVentaGeneral();
            try
            {
                return objDAVG.daAnularventa(codventa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }

}
