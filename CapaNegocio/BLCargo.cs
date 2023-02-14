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
        public List<Cargo> blDevolverTablaCodTipoConReturnLista(String cCodTab,Boolean buscar)
        {

            DACargo daobjUsuario = new DACargo();
            try
            {
                return daobjUsuario.daDevolverTablaCodTipoConReturnLista(cCodTab,buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Cargo> blDevolverTablaCodTipoConDT(String cCodTab,Boolean buscar)
        {

            DACargo daobjUsuario = new DACargo();
            try
            {
                return daobjUsuario.daDevolverTablaCodTipoConDT(cCodTab,buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Cargo> blLlenarCboSegunTablaTipoCon(String nomCampoId, String nomCampoNombre, String nomTabla, String nomEstado, String condicionDeEstado, Boolean buscar)
        {

            DACargo daobjUsuario = new DACargo();
            try
            {
                return daobjUsuario.daLlenarCboSegunTablaTipoCon( nomCampoId,  nomCampoNombre,  nomTabla,  nomEstado,  condicionDeEstado,  buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Cargo> blDevolverUsuarioPorCargo(String cCodCargo,Boolean buscar)
        {

            DACargo daobjUsuario = new DACargo();
            try
            {
                return daobjUsuario.daDevolverUsuarioPorCargo(cCodCargo, buscar);
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
        public Int32 blBuscarAccionDiaria(Int32 idOperacion, string dtFechaOpe)
        {
            DACargo daobjUsuario = new DACargo();
            try
            {
                return daobjUsuario.daBusacarAccionDiaria( idOperacion,  dtFechaOpe);
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Boolean blRegistrarAccionDiaria(String descrip, Boolean estado, Int32 idOpera, String fechaOperacion)
        {
            DACargo daobjUsuario = new DACargo();
            try
            {
                return daobjUsuario.daRegistrarAccionDiaria( descrip,  estado,  idOpera,  fechaOperacion);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
