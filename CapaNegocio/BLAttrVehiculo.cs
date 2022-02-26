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
   public class BLAttrVehiculo
    {

        public List<ClaseVehiculo> blDevolverClaseV(Int32 Vehiculo)
        {
            DAAttrVehiculo objClaseV = new DAAttrVehiculo();
            try
            {
                return objClaseV.daDevolverClaseV(Vehiculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ClaseVehiculo blListarClaseEspecifica(Int32 idClase)
        {
            DAAttrVehiculo daobjchip = new DAAttrVehiculo();
            try
            {
                return daobjchip.daListarClaseEspecifica(idClase);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<DetalleVehiculoEspecial> blDevolverDetalleVehiculoEsp(Int32 idVehiculoEsp)
        {

            DAAttrVehiculo objVehiculoEsp = new DAAttrVehiculo();
            try
            {
                return objVehiculoEsp.daDevolverDetVehiculoEsp(idVehiculoEsp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<ClaseVehiculo> blDevolverClaseVehiculo(Int32 idClaseV,Boolean estado, Int32 lntipoCon)
        {

            DAAttrVehiculo objClaseV = new DAAttrVehiculo();
            try
            {
                return objClaseV.daDevolverClaseV(idClaseV, estado, lntipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<ModUsoVehiculo> blDevolverModUsoV(Int32 idClaseV)
        {

            DAAttrVehiculo objMarcaV = new DAAttrVehiculo();
            try
            {
                return objMarcaV.daDevolverModUsoV(idClaseV);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Int32 blDevolverValidarMarcaExistente(String txtMarca, String txtMarca2,Int16 idClase, Int16 pnTipoCon)
        {

            DAAttrVehiculo objMarcaV = new DAAttrVehiculo();
            try
            {
                return objMarcaV.daDevolverValidarMarcaExistente(txtMarca, txtMarca2,idClase, pnTipoCon);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Int32 blDevolverValidarUsoExistente(String txtUso, String txtUso2, Int16 idClase, Int16 pnTipoCon)
        {

            DAAttrVehiculo objUsoV = new DAAttrVehiculo();
            try
            {
                return objUsoV.daDevolverValidarUsoEspecifico(txtUso, txtUso2, idClase, pnTipoCon);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

           


            

        public Int32 blDevolverValidarModeloExistente(String txtModelo, String txtModelo2, Int16 idClase,Int16 idMarca, Int16 pnTipoCon)
        {

            DAAttrVehiculo objModeloV = new DAAttrVehiculo();
            try
            {
                return objModeloV.daDevolverValidarModeloExistente(txtModelo, txtModelo2, idClase, idMarca, pnTipoCon);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Int32 blDevolverValidarPlaca(String txtPlaca, String txtPlaca2, Int16 pnTipoCon)
        {

            DAAttrVehiculo objMarcaV = new DAAttrVehiculo();
            try
            {
                return objMarcaV.daDevolverValidarPlaca(txtPlaca, txtPlaca2, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<MarcaVehiculo> blDevolverMarcaV(Int32 idMarcaV)
        {

            DAAttrVehiculo objMarcaV = new DAAttrVehiculo();
            try
            {
                return objMarcaV.daDevolverMarcaV(idMarcaV);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<MarcaVehiculo> blDevolverMarcaVehiculo(Int32 idClase,Boolean estado,Int32 lntipoCon)
        {

            DAAttrVehiculo objMarcaV = new DAAttrVehiculo();
            try
            {
                return objMarcaV.daDevolverMarcaVehiculo(idClase, estado, lntipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Int32 blDevolverEstadoPlaca(Int32 idClase)
        {

            DAAttrVehiculo objMarcaV = new DAAttrVehiculo();
            try
            {
                return objMarcaV.daDevolverEstadoPlacaV(idClase);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<ModeloVehiculo> blDevolverModeloV(Int32 idMarcaV)
        {

            DAAttrVehiculo objModeloV = new DAAttrVehiculo();
            try
            {
                return objModeloV.daDevolverModeloV(idMarcaV);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Cliente> blDevolverClientesV(Int32 idCliente)
        {

            DACliente objCliente = new DACliente();
            try
            {
                return objCliente.daDevolverCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String blGrabarClase(ClaseVehiculo objClase, Int16 pnTipoCon)
        {
            DAAttrVehiculo objAttrV = new DAAttrVehiculo();
            try
            {
                return objAttrV.daGrabarClaseV(objClase, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String blGrabarMarca(MarcaVehiculo objMarca, Int16 pnTipoCon)
        {
            DAAttrVehiculo objAttrV = new DAAttrVehiculo();
            try
            {
                return objAttrV.daGrabarMarcaV(objMarca, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String blGrabarUso(ModUsoVehiculo objUso, Int16 pnTipoCon)
        {
            DAAttrVehiculo objAttrV = new DAAttrVehiculo();
            try
            {
                return objAttrV.daGrabarUso(objUso, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public String blGrabarModelo(ModeloVehiculo objModelo, Int16 pnTipoCon)
        {
            DAAttrVehiculo objAttrV = new DAAttrVehiculo();
            try
            {
                return objAttrV.daGrabarModeloV(objModelo, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable blBuscarDatosParadatatables(Int32 tabIndex, Int32 pnIdClase, Int32 pnIdMarca, String pcBuscar, Int32 pagina, Int32 tipoConPagina)
        {
            DAAttrVehiculo objUbigeo = new DAAttrVehiculo();
            try
            {
                return objUbigeo.daBuscarDatosParaDatatables(tabIndex,  pnIdClase,  pnIdMarca, pcBuscar, pagina, tipoConPagina);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable blBuscarMarcaV(Int32 idclase , String pcBuscar, Int32 pagina, Int32 tipoConPagina)
        {
            DAAttrVehiculo objUbigeo = new DAAttrVehiculo();
            try
            {
                return objUbigeo.daBuscarMarcaV(idclase, pcBuscar, pagina, tipoConPagina);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ModeloVehiculo> blBuscarModeloV(String pcBuscar, Int16 piTipoCon)
        {
            DAAttrVehiculo objUbigeo = new DAAttrVehiculo();
            try
            {
                return objUbigeo.daBuscarModeloV(pcBuscar, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public DataTable blListarMarcaEspecifica(Int32 idVehiulo)
        {
            DAAttrVehiculo objMarcaV = new DAAttrVehiculo();
            try
            {
                return objMarcaV.daListarMarcaEspecifica(idVehiulo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable blListarUsoEspecifico (Int32 idVehiculo)
        {
            DAAttrVehiculo objUsoV = new DAAttrVehiculo();
            try
            {
                return objUsoV.daListarUsoEspecifico(idVehiculo);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ModeloVehiculo> blListarModelo(Int32 idVehiulo)
        {
            DAAttrVehiculo objModeloV = new DAAttrVehiculo();
            try
            {
                return objModeloV.daListarModelo(idVehiulo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MarcaVehiculo> blListarMarcasV(Boolean pbEstado,Int32 idClase)
        {
            DAAttrVehiculo objMarca = new DAAttrVehiculo();
            try
            {
                return objMarca.daListarMarcas(pbEstado, idClase);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public List<ModeloVehiculo> blListarModelosV(Boolean pbEstado,Int32 idMarca)
        {
            DAAttrVehiculo objModelo = new DAAttrVehiculo();
            try
            {
                return objModelo.daListarModelos(pbEstado,idMarca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
