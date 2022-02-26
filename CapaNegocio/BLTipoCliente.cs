using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLTipoCliente
    {

        public List<TipoCliente> blDevolverTipoCliente(Int32 idTC, String tipoCon,Boolean buscar)
        {
            DATipoCliente daobjUsuario = new DATipoCliente();
            try
            {
                return daobjUsuario.daDevolverTipoCliente(idTC, tipoCon,buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<TipoDocumento> blDevolverDocumentoDeTipoCliente(Int32 idTD, String tipoCon,Boolean buscar)
        {
            DATipoCliente daobjUsuario = new DATipoCliente();
            try
            {
                return daobjUsuario.daDevolverDocumentoDeTipoCliente(idTD, tipoCon,buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
