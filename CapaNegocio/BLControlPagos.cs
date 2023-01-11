using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CapaDato;
using CapaEntidad;

namespace CapaNegocio
{
    public class BLControlPagos
    {
        public BLControlPagos() { }
        DAControlPagos objControlPagos= null;
        public DataTable blBuscarCronograma(Boolean habilitarfechas,Boolean chkIncump, String dtFechaIni, String dFechaFin,String pcBuscar,Int32 tipoCon, Int32 TipConPaginacion, Int32 numPagina,String estadoPago,Int32 idCiclo)
        {
            objControlPagos = new DAControlPagos();
            try
            {
                return objControlPagos.daBuscarCronograma( habilitarfechas, chkIncump,  dtFechaIni,  dFechaFin,  pcBuscar, tipoCon,  TipConPaginacion,  numPagina, estadoPago, idCiclo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Reporte> blBuscarReporte(Busquedas cls)
        {
            objControlPagos = new DAControlPagos();
            try
            {
                return objControlPagos.daBuscarReporte(cls);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Reporte> blBuscarReporteRenovaciones(Busquedas cls)
        {
            objControlPagos = new DAControlPagos();
            try
            {
                return objControlPagos.daBuscarReporteRenovaciones(cls);
            }
            catch (Exception ex)
            {
                return new List<Reporte> { };
            }
        }
        public List<Reporte> blBuscarReporteVentas(Busquedas cls)
        {
            objControlPagos = new DAControlPagos();
            try
            {
                return objControlPagos.daBuscarReporteVentas(cls);
            }
            catch (Exception ex)
            {
                return new List<Reporte> { };
            }
        }
        public DataTable blBuscarCronogramaEspecifico(Int32 idCron, Int32 idCont, Int32 tipoCon)
        {
            objControlPagos = new DAControlPagos();
            try
            {
                return objControlPagos.daBuscarCronogramaEspecifico( idCron,  idCont,  tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Boolean blGuardarPagoCuota(ControlPagos clsCPC, List<xmlDocumentoVentaGeneral> lstDV, Int32 tipoCon)
        {
            objControlPagos = new DAControlPagos();
            try
            {
                return objControlPagos.daGuardarPagoCuotas(clsCPC, lstDV, tipoCon);
            }
            catch ( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Boolean blGuardarPagoCuotasPorDocumento(ControlPagos clsCPC, List<xmlDocumentoVentaGeneral> lstDV, Int32 tipoCon)
        {
            objControlPagos = new DAControlPagos();
            try
            {
                return objControlPagos.daGuardarPagoCuotasPorDocumento(clsCPC, lstDV, tipoCon);
            }
            catch ( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Boolean blAniadirADocumentoVenta(List<DetalleCronograma> clsCPC,Int32 idusuario, Int32 tipoCon)
        {
            objControlPagos = new DAControlPagos();
            try
            {
                //return objControlPagos.daAniadirADocumentoVenta(clsCPC, idusuario, tipoCon);
                return false;
            }
            catch ( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
