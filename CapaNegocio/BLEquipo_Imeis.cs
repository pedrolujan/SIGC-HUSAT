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
   public class BLEquipo_Imeis
    {
        DAEquipo_imeis daobjEquipoImeis; 
        public BLEquipo_Imeis()
        {
            daobjEquipoImeis= new DAEquipo_imeis();
        }

        public DataTable blValidarEquiposImei(List<Equipo_imeis> objEquipo, Int32 pnTipoCon)
        {

            try
            {
                return daobjEquipoImeis.daValidarEquipoImeis(objEquipo, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public bool blGrabarEquipoImeis(List<Equipo_imeis> objEquipo,Int32 pnTipoCon){
            
            try
            {
                return daobjEquipoImeis.daGuardarEquipoImeis(objEquipo, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<EstadoImeis> blDevolverEstadoImeis()
        {
            try
            {
                return daobjEquipoImeis.daDevolverEstadoImeis();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Equipo_imeis> blDevolverEquipo(Int32 idCategoria)
        {            
            try
            {
                return daobjEquipoImeis.daDevolverEquipo(idCategoria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Equipo_imeis>blDevolverPrecioxProducto(int pidProducto)
        {
            try
            {
                return daobjEquipoImeis.daDevolverPrecioxProducto(pidProducto);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarEquipoImeis(String pcBuscar, Int16 piTipoCon)
        {
            
            try
            {
                return daobjEquipoImeis.daBuscarEquipoImeisDatatable(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public DataTable blBuscarEquipo_imaisDatatable(Int32 lnIdRecibo)
        {
            try
            {
                return daobjEquipoImeis.daBuscarEquipo_ImeisDatatable(lnIdRecibo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blBuscarImeisDataTable(String estado, Int32 idMarca, Int32 idModelo,String pcBuscar, Int32 pagina,Int32 tipoCon, Int32 TipoLlamada)
        {
           
            try
            {
                return daobjEquipoImeis.daBuscarImeisDataTable(estado,idMarca, idModelo, pcBuscar, pagina, tipoCon,  TipoLlamada);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Equipo_imeis blListarImeiEspacifico(Int32 idImei, Int32 tipoCon)
        {

            try
            {
                return daobjEquipoImeis.daListarImeiEspecifico(idImei, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Equipo_imeis blObtenerPaginacionEquipos(String estado,Int32 idMarca, Int32 idModelo)
        {

            try
            {
                return daobjEquipoImeis.daObtenerPaginacionEquipos(estado, idMarca,  idModelo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Int32 blDevolverDatosExistentes(String txtPlaca, String dato2, Int32 pnTipoCon)
        {

            try
            {
                return daobjEquipoImeis.daDevolverDatosExistentes(txtPlaca,  dato2, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable blDevolverEquiposImeisDePlan(String busqueda,Int32 idPlan, Int32 tipoCon)
        {
            try
            {
                return daobjEquipoImeis.daDevolverEquipoImeisDePlan(busqueda, idPlan,tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blDevolverAccesorios(String busqueda, Int32 tipoCon)
        {
            try
            {
                return daobjEquipoImeis.daDevolverAccesorios(busqueda, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blDevolverAccesoriosEspecifico(Int32 idAccesorio, Int32 tipoCon)
        {
            try
            {
                return daobjEquipoImeis.daDevolverAccesoriosEspecifico(idAccesorio, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blDevolverStockImeis(Int32 tipoCon, Int32 idPlan)
        {
            try
            {
                return daobjEquipoImeis.daDevolverStockImeis(tipoCon,idPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Equipo_imeis> blDevolverStockEquipos(Int32 tipoCon, Int32 idPlan)
        {
            try
            {
                return daobjEquipoImeis.daDevolverStockEquipos(tipoCon, idPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
