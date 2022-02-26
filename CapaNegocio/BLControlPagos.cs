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
        public DataTable blBuscarCronograma(Boolean habilitarfechas,DateTime dtFechaIni, DateTime dFechaFin,String pcBuscar,Int32 tipoCon, Int32 TipConPaginacion, Int32 numPagina,String estadoPago)
        {
            objControlPagos = new DAControlPagos();
            try
            {
                return objControlPagos.daBuscarCronograma( habilitarfechas,  dtFechaIni,  dFechaFin,  pcBuscar, tipoCon,  TipConPaginacion,  numPagina, estadoPago);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
    }
}
