using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDato;

namespace CapaNegocio
{
    public class BLCargo
    {

        public List<Cargo> blDevolverCargo(String cCodTab)
        {

            DACargo daobjUsuario = new DACargo();
            try
            {
                return daobjUsuario.daDevolverCargo(cCodTab);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String blGrabarCargo(Cargo objCargo, Int16 pnTipoCon)
        {
            DACargo daobjUsuario = new DACargo();
            try
            {
                return daobjUsuario.daGrabarCargo(objCargo, pnTipoCon);             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Cargo> blDevolverTablaCod(String cCodTab)
        {

            DACargo daobjUsuario = new DACargo();
            try
            {
                return daobjUsuario.daDevolverTablaCod(cCodTab);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Cargo> blDevolverTablaCodTipoCon(String cCodTab,Boolean buscar)
        {

            DACargo daobjUsuario = new DACargo();
            try
            {
                return daobjUsuario.daDevolverTablaCodTipoCon(cCodTab,buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String blDevolverCorrelativo(String cCodTab)
        {
            DACargo daobjUsuario = new DACargo();
            try
            {
                return daobjUsuario.daDevolverCorrelativo(cCodTab);
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
