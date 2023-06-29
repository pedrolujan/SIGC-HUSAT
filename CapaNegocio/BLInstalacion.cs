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
    public class BLInstalacion
    {
        public String blGrabarInstalacion(Instalacion objInstal, Int16 pnTipoCon)
        {
            DAInstalacion objInstalacion = new DAInstalacion();
            try
            {
                return objInstalacion.daGrabarInstalacion(objInstal, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blLlEnarDatosIntalacion(String codVenta,String placa)
        {
            DAInstalacion objInstalacion = new DAInstalacion();
            try
            {
                return objInstalacion.DadevolverDatosIns(codVenta, placa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Boolean blGrabarInstalacionEquipo(List<xmlInstalacion> xmlInstal, Int32 idUsuario,DateTime FechaInstalacion)
        {
            DAInstalacion objInstalacion = new DAInstalacion();
            try
            {
                return objInstalacion.DaGuardarInstalacion(xmlInstal, idUsuario,FechaInstalacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Equipo_imeis blBuscarEquipo (Int32 idEquipo)
        {
            DAInstalacion objInstalacion = new DAInstalacion();
            try
            {
                return objInstalacion.daBuscarEquipo(idEquipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blAccesoriosPlan(String lnIdPlan)
        {
            DAInstalacion daobjOperador = new DAInstalacion();
            try
            {
                return daobjOperador.daAccesoriosEquipo(lnIdPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blServiciosPlan(String lnIdPlan)
        {
            DAInstalacion daobjOperador = new DAInstalacion();
            try
            {
                return daobjOperador.daServiciosEquipo(lnIdPlan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<UbicacionEquipoInstalacion> blDevolverUbicacionIns(Int32 idUbicacion)
        {
            DAInstalacion objUbicacionInst = new DAInstalacion();

            try
            {
                return objUbicacionInst.daDevolverUbicacionIns(idUbicacion);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blBuscarInstalaciones(Boolean habilitarfechas, String fechaInical, String fechaFinal, String placaVehiculo, String cEstadoInstal, Int32 numPagina, Int32 tipoCon, Int32 codTipoVenta,Int32 idUsuario)
        {
            DAInstalacion objVentaG = new DAInstalacion();
            try
            {
                return objVentaG.daBuscarInstalacion(habilitarfechas, fechaInical, fechaFinal, placaVehiculo, cEstadoInstal, numPagina, tipoCon, codTipoVenta ,idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
