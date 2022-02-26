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
    public class BLVehiculo
    {
      public BLVehiculo() {}
        public DataTable blBuscarConsultas(String datoBusq, Boolean HabilitarFechas, DateTime dtfechaInicio, DateTime dtFechaFinal, Int32 tipoCon)
        {
            DAVehiculo objVehiculo = new DAVehiculo();
            try
            {
                return objVehiculo.daBuscarConsultas(datoBusq, HabilitarFechas, dtfechaInicio, dtFechaFinal, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public DataTable blBuscarMovimientoVH(Int32 datoBusq,Int32 Pagina, Int32 tipoCon)
        {
            DAVehiculo objVehiculo = new DAVehiculo();
            try
            {
                return objVehiculo.daBuscarMovimiento(datoBusq,Pagina, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public DataTable blBuscarVehiculo(DatosEnviarVehiculo objEnvio, Int32 pagina, Int32 TipoConPagina)
        {

            DAVehiculo objVehiculo = new DAVehiculo();
            try
            {
                return objVehiculo.DaBuscarVehiculo(objEnvio,  pagina,  TipoConPagina);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Vehiculo blListarVehiculo(Int32 idVehiulo)
        {
            DAVehiculo objVehiculo = new DAVehiculo();
            try
            {
                return objVehiculo.daListarVehiculo(idVehiulo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Vehiculo> blListarVehiculos(Boolean pbEstado)
        {
            DAVehiculo objVehiculo = new DAVehiculo();
            try
            {
                return objVehiculo.daListarVehiculos(pbEstado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<VehiculoYCliente> blListarVehiculosYCliente(Boolean pbEstado)
        {
            DAVehiculo objVehiculo = new DAVehiculo();
            try
            {
                return objVehiculo.daObtenerVehiculosYClientes(pbEstado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String blGrabarVehiculo(Vehiculo objVehiculo, Int16 pnTipoCon)
        {

            DAVehiculo daobjCliente = new DAVehiculo();
            try
            {
                return daobjCliente.daGrabarvehiculo(objVehiculo, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
