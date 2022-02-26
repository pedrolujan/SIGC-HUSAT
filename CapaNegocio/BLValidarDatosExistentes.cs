using CapaDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
   public class BLValidarDatosExistentes
    {
        public Int32 blDevolverDatosExistentes(String txtPlaca, String txtPlaca2, Int16 pnTipoCon,String Procedimiento)
        {

            DAValidarDatosExistentes obDatos = new DAValidarDatosExistentes();
            try
            {
                return obDatos.daDevolverDatosExistentes(txtPlaca, txtPlaca2, pnTipoCon, Procedimiento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
