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
    public class BLControlCaja
    {
        public BLControlCaja() { }
        DAControlCaja dc ;
        public List<ControlCaja> blFnLLenarTipoPago(Int32 idTipPlan,String id,Boolean estado)
        {
            dc = new DAControlCaja();
            try
            {
                return dc.daFnLlenarTipoPago( idTipPlan,id, estado);

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
        public DataTable blfnBuscarVentasCaja(Boolean chk,Boolean chkDiaEsp, String fini, String ffin, String mtPago, Int32 entPago, String doVenta, Int32 tipPlan, Int32 tipTarifa, String tipPago,Int32 idUsuario, String cBuscar,Int32 numPagina, Int32 tipoCon)
        {
            dc = new DAControlCaja();
            try
            {
                return dc.daFnBuscarVentasCaja( chk, chkDiaEsp, fini,  ffin,  mtPago,  entPago,  doVenta,  tipPlan,  tipTarifa,  tipPago,  idUsuario,  cBuscar, numPagina,  tipoCon);

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
        public List<ReporteBloque> BuscarReporteGeneralVentas(Boolean chk,Boolean chkDiaEsp, String fini, String ffin, String codTipoReporte, String codTipoOprecacion,  Int32 tipPlan, Int32 tipTarifa, String cBuscar,Int32 numPagina, Int32 tipoCon)
        {
            dc = new DAControlCaja();
            try
            {
                return dc.daBuscarReporteGeneralVentas( chk,  chkDiaEsp,  fini,  ffin,  codTipoReporte,  codTipoOprecacion,  tipPlan,  tipTarifa,  cBuscar,  numPagina,  tipoCon);

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }
}
