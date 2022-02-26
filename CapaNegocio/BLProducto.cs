using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidad;
using CapaDato;

namespace CapaNegocio
{
    public class BLProducto
    {
        public DataTable BLListarProducto()
        {

            DAProducto daobjUsuario = new DAProducto();
            try
            {
                return daobjUsuario.DAListarProducto();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Producto> BLGetDevolverProducto(Int32 pidProducto, Int16 piTipoCon, Int16 pidSucursal, Int16 lnTipo)
        {
            DAProducto daobjUsuario = new DAProducto();
            try
            {
                return daobjUsuario.DAGetDevolverProducto(pidProducto,piTipoCon,pidSucursal,lnTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable BLListarProductoOrdenCompra()
        {

            DAProducto daobjUsuario = new DAProducto();
            try
            {
                return daobjUsuario.DAListarProductoOrdeCompra();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public String BLRegistrarProducto(Int32 peiCodigoProducto, String pecNombreProducto, String pecDescripcionProducto, Int32 peiCodigoCategoria, Int32 peiCodigoUnidadMedida, Int32 peiCodigoMarcaProducto,Decimal StockMin, Int32 pebEstado, String pedFechaRegistro, Int32 peiIdUsuario)
        {
            DAProducto daobjUsuario = new DAProducto();
            try
            {
                return daobjUsuario.DARegistrarProducto( peiCodigoProducto,  pecNombreProducto,  pecDescripcionProducto,  peiCodigoCategoria,  peiCodigoUnidadMedida,peiCodigoMarcaProducto,StockMin, pebEstado,  pedFechaRegistro,  peiIdUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable BLListarLineaxProducto(Int32 peiCodigoCategoria)
        {

            DAProducto daobjUsuario = new DAProducto();
            try
            {
                return daobjUsuario.DAListarLineaXProducto(peiCodigoCategoria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable BLListarUnidadMedidaProducto()
        {

            DAProducto daobjUsuario = new DAProducto();
            try
            {
                return daobjUsuario.DAListarUnidadMedidaProducto();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable BLListarProductoUnidadMedida(Int32 peiCodigoUM)
        {
            DAProducto daobjUsuario = new DAProducto();
            try
            {
                return daobjUsuario.DAListarProductoUnidadMedida(peiCodigoUM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UnidadMedida> DADevolverUMxProducto(Int32 idProducto)
        {
            DAProducto daobjUsuario = new DAProducto();
            try
            {
                return daobjUsuario.DADevolverUMxProducto(idProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public List<UnidadMedida> BLDevolverValorUMB(Int32 pidProducto, decimal pnStock)
        {
            DAProducto daobjUsuario = new DAProducto();
            try
            {
                return daobjUsuario.DADevolverValorUMB(pidProducto,pnStock);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

    }
}
