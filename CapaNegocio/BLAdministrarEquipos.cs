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
    public class BLAdministrarEquipos
    {
        DAAdministrarEquipos daobjEquipo;
        public BLAdministrarEquipos() { }
        public AdministrarEquipos blListarImeiEspacifico(Int32 idImei, Int32 tipoCon)
        {
            daobjEquipo = new DAAdministrarEquipos();
            try
            {
                return daobjEquipo.daListarImeiEspecifico(idImei, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public String blGrabarMovimientoImeis(AdministrarEquipos objOperador, Int16 pnTipoCon)
        {
            daobjEquipo = new DAAdministrarEquipos();
            try
            {
                return daobjEquipo.daGrabarMovimientoImeis(objOperador, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Boolean blLiberarChip(Int32 idEquipo, Int32 idSimCard,DateTime fechaReg, Int32 idUsuario, String pcObservacion)
        {
            daobjEquipo = new DAAdministrarEquipos();
            try
            {
                return daobjEquipo.daLiberarImeis(idEquipo, idSimCard,  fechaReg,  idUsuario,pcObservacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blBuscarImeisDatatable(Int32 lnIdRecibo,String pcBuscar, Int32 numPagina, Int32 tipoCon)
        {
            daobjEquipo = new DAAdministrarEquipos();
            try
            {
                return daobjEquipo.daBuscarImeisDatatable(lnIdRecibo,  pcBuscar, numPagina, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool blGrabarChips_Recibo(List<AsignarImeisADocumento> objEquipo, Int32 pnTipoCon,Int32 Stok,Int32 idOrden)
        {
            daobjEquipo = new DAAdministrarEquipos();
            try
            {
                return daobjEquipo.daGuardarChips_Recibo(objEquipo, pnTipoCon, Stok, idOrden);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blBuscarHistorialImeis(String imei, String simcard,Boolean HabilitarFechas, DateTime dtfechaInicio,DateTime dtFechaFinal)
        {
            daobjEquipo = new DAAdministrarEquipos();
            try
            {
                return daobjEquipo.daBuscarHistorialImeis(imei, simcard,HabilitarFechas, dtfechaInicio, dtFechaFinal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
