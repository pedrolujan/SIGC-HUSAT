using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLTipoTarifa
    {
        public List<TipoTarifa> blDevolverTipoTarifa(Int32 idTipoTarifa,Boolean buscar)
        {
            DATipoTarifa objAccesorio = new DATipoTarifa();
            try
            {
                return objAccesorio.daListarTipoTarifa(idTipoTarifa, buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Plan blDevolverTarifaDePlan(Int32 idPlan)
        {
            DATipoTarifa objAccesorio = new DATipoTarifa();
            try
            {
                return objAccesorio.daListarTarifaDePlan(idPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Tarifa blDevolverPrecios(Int32 idPlan, Int32 peTipoTarifa, String codVenta, Int32 lnTipoCon)
        {
            DATipoTarifa objAccesorio = new DATipoTarifa();
            try
            {
                return objAccesorio.daListarPreciosTarifaDePlan(idPlan, peTipoTarifa,  codVenta,  lnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Tarifa blDevolverPreciosPagosMensuales(Int32 idPlan,String codVenta, Int32 tipoCon)
        {
            DATipoTarifa objAccesorio = new DATipoTarifa();
            try
            {
                return objAccesorio.daListarPreciosTarifaDePlanPagosMensuales(idPlan,codVenta, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
