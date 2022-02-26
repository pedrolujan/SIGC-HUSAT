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
    public class BLTraslado
    {
        public BLTraslado() { }

        public List<Traslado> blBuscarTraslado(String pcBuscar, Int16 pnTipoCon)
        {
            DATraslado objDocVenta = new DATraslado();
            try
            {
                return objDocVenta.daBuscarTraslado(pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String BLGrabarTraslado(Traslado objTraslado, DataTable dtDetalle, out int pidTraslado)
        {
            DATraslado objDocVenta = new DATraslado();
            try
            {
                return objDocVenta.daGrabarTraslado(objTraslado, dtDetalle, out pidTraslado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
    

        }

        public List<Almacen> BLListarAlmacen(bool pbEstado, int pidSucursal = 0)
        {
            DATraslado objDocVenta = new DATraslado();
            try
            {
                return objDocVenta.daListarAlmacen(pbEstado, pidSucursal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DetalleTraslado> BLListarDetalleTraslado(int pidTraslado,bool pbEstado)
        {
            DATraslado objDocVenta = new DATraslado();
            try
            {
                return objDocVenta.daListarDetalleTraslado(pidTraslado,pbEstado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
