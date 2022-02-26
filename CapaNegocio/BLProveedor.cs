using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDato;

namespace CapaNegocio
{
    public class BLProveedor
    {
        public BLProveedor() { }

        public List<Proveedor> blDevolverProveedor(String pcBuscar, Int16 pnTipoCon)
        {

            DAProveedor objProveedor = new DAProveedor();
            try
            {
                return objProveedor.daDevolverProveedor(pcBuscar,pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Proveedor> blListarProveedor(Int32 idProve)
        {                       
            DAProveedor objProveedor = new DAProveedor();
            try
            {
                return objProveedor.daListarProveedor(idProve);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String blGrabarProveedor(Proveedor objetoProveedor, Int16 pnTipoCon)
        {

            DAProveedor objProveedor = new DAProveedor();
            try
            {
                return objProveedor.daGrabarProveedor(objetoProveedor, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Proveedor> blListarProveedores(Boolean pbEstado, Boolean buscar, String codTipoOrden)
        {
            DAProveedor objProveedor = new DAProveedor();
            try
            {
                return objProveedor.daListarProveedores(pbEstado,buscar, codTipoOrden);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
