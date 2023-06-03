using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLCaja
    {
        DACaja dcaja ;
        public List<ReporteBloque> blBuscarVentas(Busquedas clsBusq)
        {
            dcaja = new DACaja();
            try
            {
                return dcaja.daBuscarVentas( clsBusq);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }

        }

        public List<ReporteBloque> blBuscarOtrosIngresos(Busquedas clsBusq)
        {
            dcaja = new DACaja();
            try
            {
                return dcaja.daBuscarOtrosIngresos(clsBusq);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }

        }

        public List<ReporteBloque> blBuscarAccionCaja(String dt, Int32 idUsuario, Int32 TipoOpe)
        {
            dcaja = new DACaja();
            try
            {
                return dcaja.daBuscarAccionCaja(  dt,  idUsuario,  TipoOpe);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }

        }
        public List<Cargo> blBuscarTipoOpciones(String cod,Int32 tipoCon)
        {
            dcaja = new DACaja();
            try
            {
                return dcaja.daBuscarTipoOpciones( cod, tipoCon);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }

        }
        public Boolean blGuardarCierreCaja(List<xmlActaCierraCaja>xmlacta, List<CuadreCaja> lstApertura,Int32 tipoCon)
        {
            dcaja = new DACaja();
            try
            {
                return dcaja.daGuardarCierreCaja( xmlacta,lstApertura , tipoCon);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }

        }
    }
}
