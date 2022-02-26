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
    public class BLEquivalencia
    {
        public DataTable BLListarEquivalencia()
        {

            DAEquivalencia daobjUsuario = new DAEquivalencia();
            try
            {
                return daobjUsuario.DAListarEquivalencia();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String BLRegistrarEquivalencia(Int32 peiCodigoEquiv, Int32 peiCodigoUMOrigen, Int32 peiCodigoUMDestino, Decimal pemValorUMOrigen, Decimal pemValorUMDestino, Int32 pebEstado, String pecFecha, Int32 peiIdUsuario, Int32 peiTipo)
        {
            DAEquivalencia daobjUsuario = new DAEquivalencia();
            try
            {
                return daobjUsuario.DARegistrarEquivalencia(peiCodigoEquiv, peiCodigoUMOrigen, peiCodigoUMDestino,pemValorUMOrigen,pemValorUMDestino ,pebEstado, pecFecha, peiIdUsuario, peiTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
