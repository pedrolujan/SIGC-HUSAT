using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLTipoDescuento
    {
        public List<TipoDescuento> blTipoDescuento(Int32 idTipoDescuento,Boolean buscar)
        {
            DATipoDescuento objTipoDescuento = new DATipoDescuento();
            try
            {
                return objTipoDescuento.daDevolverTipDescuento(idTipoDescuento,buscar);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Int32 BLValidarDescuento(String usuario, String clave)
        {
            DATipoDescuento objDaTipoDescuento = new DATipoDescuento();
            try
            {
                return  objDaTipoDescuento.daValidarDescuento(usuario, clave);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Double BLCalcularDescuento(TipoDescuento objTD)
        {
            DATipoDescuento objDaTipoDescuento = new DATipoDescuento();
            try
            {
                return objDaTipoDescuento.daCalularDescuento(objTD);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
