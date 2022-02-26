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
    public class BLAccesorio
    {

        public List<Accesorios> blDevolverAccesorio(Int32 idAccesorio)
        {
            DAAccesorios objAccesorio = new DAAccesorios();
            try
            {
                return objAccesorio.daDevolverAccesorio(idAccesorio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public DataTable blBuscarAccesorioDataTable(String pcBuscar, String estado, Int32 numPagina, Int32 tipoCon)
        {
            DAAccesorios objEquipo = new DAAccesorios();
            try
            {
                return objEquipo.daBuscarAccesorioDataTable(pcBuscar, estado,numPagina,tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Accesorios blListarAccesoriosDataGrid(Int32 idPlan, Int32 pnTipoCon)
        {
            DAAccesorios objPlan = new DAAccesorios();
            try
            {
                return objPlan.daListarAccesoriosDatatable(idPlan,pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public List<Accesorios> blDevolverAccesorio(String idAccesorio)
        //{

        //    DAAccesorios objAccesorio = new DAAccesorios();
        //    try
        //    {
        //        return objAccesorio.daDevolverAccesorio(idAccesorio);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}
        public List<Accesorios> blDevolverEquipoGps(Int32 idEquipo)
        {

            DAAccesorios objAccesorio = new DAAccesorios();
            try
            {
                return objAccesorio.daDevolverEquipoGps(idEquipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Int16 blBuscarNombreAccesorio(String pcBuscar, Int16 pnTipoCon)
        {

            DAAccesorios objAcc = new DAAccesorios();
            try
            {
                return objAcc.daBuscarNombreAccesorio(pcBuscar, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String blGrabarAccesorio(Accesorios objAccesorio, Int16 pnTipoCon)
        {
            DAAccesorios objAccsesor = new DAAccesorios();
            try
            {
                return objAccsesor.daGrabarAccesorio(objAccesorio, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Accesorios> blBuscarAccesorio(String pcBuscar, Int16 piTipoCon)
        {
            DAAccesorios objAccesorio = new DAAccesorios();
            try
            {
                return objAccesorio.daBuscarAccesorio(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Accesorios> blListarAccesorio(Int32 idAccesorio,Int32 peTipoCon)
        {
            DAAccesorios objAccesorio = new DAAccesorios();
            try
            {
                return objAccesorio.daListarAccesorio(idAccesorio, peTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Accesorios> blListarAccesorios(Boolean pbEstado)
        {
            DAAccesorios objAccesorio = new DAAccesorios();
            try
            {
                return objAccesorio.daListarAccesorios(pbEstado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarAccesorioHistorial( Int32 idHistorial)
        {
            DAAccesorios objEquipo = new DAAccesorios();
            try
            {
                return objEquipo.daBuscarAccesorioHistorial(idHistorial);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
