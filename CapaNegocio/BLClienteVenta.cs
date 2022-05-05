using CapaDato;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLClienteVenta
    {
        private object clienteV;
        public DataTable BlBuscarClienteV(Boolean habilitarfechas, DateTime fechaInical, DateTime fechaFinal, String placaVehiculo, String cEstadoInstal, Int32 numPagina, Int32 tipoLLamada, Int32 tipoCon, Int32 codTipoVenta, String estadoTipoContrato, Boolean habilitarRenovaciones, String valorRadio, Int32 estadoTipoPlan, Int32 estadoPlan, Int32 estadoUsuario)
        {
            DAClienteVenta objVenta = new DAClienteVenta();
            try
            {
                return objVenta.DAbuscarClienteV(habilitarfechas, fechaInical, fechaFinal, placaVehiculo, cEstadoInstal, numPagina, tipoLLamada, tipoCon, codTipoVenta, estadoTipoContrato, habilitarRenovaciones, valorRadio,estadoTipoPlan,estadoPlan, estadoUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
