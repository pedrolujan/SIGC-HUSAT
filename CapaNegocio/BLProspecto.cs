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
    public class BLProspecto
    {
        public String blGrabarProspectoPlan(ProspectosPlan objProspecto, Int32 pnTipoCon)
        {
            DAProspecto objAccsesor = new DAProspecto();
            try
            {
                return objAccsesor.daGrabarProspectoPlan(objProspecto, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable blBuscarProspectoDataTable(String numCelular, String nombreCliente, Int32 numPagina, Int32 tipoCon)
        {
            DAProspecto objEquipo = new DAProspecto();
            try
            {
                return objEquipo.daBuscarProspectoDataTable(numCelular, nombreCliente, numPagina, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarProspectoPlanDataTable(String pcBuscar,String celular, String estado, Int32 numPagina, Int32 tipoCon, String tipoContacto,DateTime fechaInicial,DateTime fechaFinal,Boolean habilitarFecha, Boolean fechaVisita, Boolean fechaRegistroSeg, Boolean fechaSigSeg,Int32 idUsuario,Int32 idTipoPlan, Int32 idPlan, Int32 idTarifa,String lColor,DateTime fechaActual)
        {
            DAProspecto objEquipo = new DAProspecto();
            try
            {
                return objEquipo.daBuscarProspectoPlanDataTable(pcBuscar, celular, estado, numPagina, tipoCon, tipoContacto, fechaInicial, fechaFinal, habilitarFecha, fechaVisita, fechaRegistroSeg, fechaSigSeg, idUsuario, idTipoPlan, idPlan, idTarifa, lColor, fechaActual);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProspectosPlan blListarProspectoPlanDataGrid(Int32 idPlan, Int32 pnTipoCon)
        {
            DAProspecto objPlan = new DAProspecto();
            try
            {
                return objPlan.daListarProspectoPlanDatatable(idPlan, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Prospecto blListarProspectoDataGrid(Int32 idPlan, Int32 pnTipoCon)
        {
            DAProspecto objPlan = new DAProspecto();
            try
            {
                return objPlan.daListarProspectoDatatable(idPlan, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public Int16 blBuscarTelefonoProspecto(String pcBuscar, Int16 pnTipoCon)
        {

            DAProspecto objAcc = new DAProspecto();
            try
            {
                return objAcc.daBuscarTelefonoProspecto(pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Prospecto blBuscarClineteXTelefono(String pcBuscar, Int16 pnTipoCon)
        {

            DAProspecto objAcc = new DAProspecto();
            try
            {
                return objAcc.daBuscarClienteXTelefono(pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable blBuscarPlanXTelefono(String pcBuscar, Int16 pnTipoCon)
        {

            DAProspecto objAcc = new DAProspecto();
            try
            {
                return objAcc.daBuscarPlanXTelefono(pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String blGrabarSeguimiento(Seguimiento objSeguimiento, Int32 pnTipoCon)
        {
            DAProspecto objAccsesor = new DAProspecto();
            try
            {
                return objAccsesor.daGrabarSeguimiento(objSeguimiento, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable blBuscarSeguimientoDataTable(Int32 idOferta, Int32 numPagina, Int32 tipoCon)
        {
            DAProspecto objEquipo = new DAProspecto();
            try
            {
                return objEquipo.daBuscarSeguimientoDataTable(idOferta,numPagina, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String blGrabarProspecto(Prospecto objProspecto, Int32 pnTipoCon)
        {
            DAProspecto objAccsesor = new DAProspecto();
            try
            {
                return objAccsesor.daGrabarProspecto(objProspecto, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Int16 blBuscarTelefonoXC(String pcBuscar, Int16 pnTipoCon)
        {

            DAProspecto objAcc = new DAProspecto();
            try
            {
                return objAcc.daBuscarTelefonoProspecto(pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public totalRanking blTotalesRankingSeguimiento(String pcBuscar, String celular, String tipoContacto, DateTime fechaInicial, DateTime fechaFinal, Boolean habilitarFecha, Boolean fechaVisita, Boolean fechaRegistroSeg, Boolean fechaSigSeg, Int32 idUsuario,DateTime fechaActual,Int32 idTipoPlan, Int32 idPlan, Int32 idTarifa)
        {
            DAProspecto objEquipo = new DAProspecto();
            try
            {
                return objEquipo.daTotalesRankingSeguimiento(pcBuscar, celular, tipoContacto, fechaInicial, fechaFinal, habilitarFecha, fechaVisita, fechaRegistroSeg, fechaSigSeg, idUsuario, fechaActual, idTipoPlan, idPlan, idTarifa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
