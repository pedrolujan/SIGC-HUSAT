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
    public class BLTipoVenta
    {
        public BLTipoVenta() {  }
        DATipoVenta daObjTipoVenta = null;
        public DataTable blBuscarTipoventas(String pcBusqueda, List<TipoVenta> lsTipoVenta, Int32 numPaginacion, Int32 tipocon)
        {
            daObjTipoVenta = new DATipoVenta(); ;

            try
            {
                return daObjTipoVenta.daBuscarTipoVenta(pcBusqueda, lsTipoVenta,  numPaginacion,  tipocon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable blDevloverTipoventas(String tipoVenta, Int32 idObtVenta)
        {
            daObjTipoVenta = new DATipoVenta(); ;

            try
            {
                return daObjTipoVenta.daDevolverTipoVenta( tipoVenta, idObtVenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
}
        }
        
    }
}
