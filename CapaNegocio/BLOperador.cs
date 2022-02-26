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
    public class BLOperador
    {
        public BLOperador() { }

        DAOperador daobjOperador;
        public SimCard blObtenerPaginacion(String Estado, Int32 tipoCon, String pcBuscar)
        {
            DAOperador daobjOperador = new DAOperador();
            try
            {
                return daobjOperador.daObtenerPaginacion(Estado, tipoCon, pcBuscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public String blGrabarChip(SimCard objOperador, Int32 pnTipoCon)
        {
            DAOperador daobjOperador = new DAOperador();
            try
            {
                return daobjOperador.daGrabarChip(objOperador, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<SimCard> blDevolverOperador(Int32 idOperador, Int32 condicion)
        {

            daobjOperador = new DAOperador();
            try
            {
                return daobjOperador.daDevolverOperadorCombo(idOperador, condicion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool blGrabarChips_Recibo(List<AsignarReciboAChips> objEquipo, Int32 pnTipoCon)
        {
            daobjOperador = new DAOperador();
            try
            {
                return daobjOperador.daGuardarChips_Recibo(objEquipo, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<SimCard> blBuscarOperador(String pcBuscar, Int16 piTipoCon)
        {
            DAOperador daobjOperador = new DAOperador();
            try
            {
                return daobjOperador.daBuscarOperador(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable blBuscarOperadorDatatable(String pcBuscar, Int16 piTipoCon, String valorComboBuscar, Int32 paginacion, Int32 tipoCon)
        {
            DAOperador daobjOperador = new DAOperador();
            try
            {
                return daobjOperador.daBuscarEquipoDatatable(pcBuscar, piTipoCon, valorComboBuscar, paginacion, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable blBuscarSimCardDatatable(String pcBuscar, String cboEstado, Int32 cboOperador, Int32 paginacion, Int32 tipoConPagina, Int32 tipoCon)
        {
            DAOperador daobjOperador = new DAOperador();
            try
            {
                return daobjOperador.daBuscarSimcardDatatable(pcBuscar, cboEstado, cboOperador, paginacion, tipoConPagina, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public SimCard blListarChip(Int32 idChip)
        {
            DAOperador daobjchip = new DAOperador();
            try
            {
                return daobjchip.daListarChipDatatable(idChip);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public SimCard blDevolverOperador(Boolean pbEstado)
        {
            DAOperador objOperador = new DAOperador();
            try
            {
                return objOperador.daDevolverOperador(pbEstado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<SimCard> blDevolverRecibo_Chip()
        {
            DAOperador objOperador = new DAOperador();
            try
            {
                return objOperador.daDevolverRecibo_Chip();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarChipDatatable(Int32 lnIdRecibo, Int32 tipoCon)
        {
            DAOperador daobjOperador = new DAOperador();
            try
            {
                return daobjOperador.daBuscarChipDatatable(lnIdRecibo, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarHistorialSimCard(String simcard, Boolean HabilitarFechas, DateTime dtfechaInicio, DateTime dtFechaFinal, Int32 pagina, Int32 tipoCon)
        {
            DAOperador daobjEquipo = new DAOperador();
            try
            {
                return daobjEquipo.daBuscarHistorialSimCard(simcard, HabilitarFechas, dtfechaInicio, dtFechaFinal, pagina, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public DataTable blBuscarDatosActualesMSimCard(String simcard)
        {
            DAOperador daobjEquipo = new DAOperador();
            try
            {
                return daobjEquipo.daBuscarDatosActualesMSimCard(simcard);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public DataTable blValidarSimCard(List<SimCard> lstSimCard, Int32 columna)
        {

            DAOperador daobjSimCard = new DAOperador();

            try
            {
                return daobjSimCard.daValidarSimCard(lstSimCard, columna);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean blGuardarSimCod(List<SimCard> lstSimCardGuardar, Int32 tipocon)
        {

            DAOperador daobjSimCod = new DAOperador();

            try
            {

                return daobjSimCod.daGuardarSimCod(lstSimCardGuardar, tipocon);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
        public DataTable blBuscarSimCard(String pcbuscar,String cboorden,String cboEstados, Int32 numPag, Int32 tipocon)
        {
            DAOperador objSimcard = new DAOperador();
            try
            {
                return objSimcard.daBuscarSimcard(pcbuscar, cboorden, cboEstados,  numPag, tipocon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
