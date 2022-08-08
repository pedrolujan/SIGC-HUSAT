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
        public DataTable blfnBuscarVentasCaja(Busquedas clsBus)
        {
            dc = new DAControlCaja();
            try
            {
                return dc.daFnBuscarVentasCaja(clsBus);

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
        public Tuple<List<ReporteBloque>,List<ReporteBloque>> BuscarReporteGeneralVentas(Busquedas clsBusq)
        {
            dc = new DAControlCaja();
            try
            {
                return dc.daBuscarReporteGeneralVentas( clsBusq);

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
        public Tuple<List<ReporteBloque>,List<ReporteBloque>, List<ReporteBloque>> blBuscarDashBoard(Busquedas clsBusq)
        {
            dc = new DAControlCaja();
            try
            {
                return dc.daBuscarDashBoard( clsBusq);

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
        public List<ReporteBloque> blDetalleParaCuadre(Busquedas clsBusq, List<ReporteBloque> lstRep)
        {
            dc = new DAControlCaja();
            try
            {
                return dc.daDetalleParaCuadre( clsBusq,  lstRep);

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }
}
