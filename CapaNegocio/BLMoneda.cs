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
    public class BLMoneda
    {

        public List<Moneda> blDevolverMoneda(Int32 idMoneda, Boolean buscar)
        {

            DAMoneda daobjUsuario = new DAMoneda();
            try
            {
                return daobjUsuario.daDevolverMoneda(idMoneda, buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
        public CambioMonedaVenta blDevolverCambioMoneda(Int32 idMonedaReferencia,Double precioReferencia, Int32 idMonedaCambio)
        {
            DAMoneda daobjUsuario = new DAMoneda();
            try
            {
                return daobjUsuario.daDevolverCambioMoneda(idMonedaReferencia, precioReferencia, idMonedaCambio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}
