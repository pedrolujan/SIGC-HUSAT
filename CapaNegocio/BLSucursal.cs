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
    public class BLSucursal
    {
        public DataTable BLListarSucursal()
        {

            DASucursal daSucursal = new DASucursal();
            try
            {
                return daSucursal.DAListarSucursal();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Sucursal DAListarSucursalxID(int pIdSucursal = 0)
        {
            DASucursal daSucursal = new DASucursal();
            try {
                return daSucursal.DAListarSucursalxID(pIdSucursal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public String BLRegistrarSucursal(Int32 peiCodigoSucursal, String pecNombreSucursal, Int32 peiCodigoDistrito, String pecDireccion, Int32 pebEstado, String pecFecha, Int32 peiIdUsuario, Int32 peiTipo)
        {
            DASucursal daSucursal = new DASucursal();
            try
            {
                return daSucursal.DARegistrarSucursal( peiCodigoSucursal,  pecNombreSucursal,  peiCodigoDistrito,  pecDireccion,  pebEstado,  pecFecha,  peiIdUsuario,  peiTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
