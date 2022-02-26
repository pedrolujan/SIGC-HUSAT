using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDato;
using System.Data;

namespace CapaNegocio
{
    public class BLUsuario
    {

        public List<Usuario> daDevolverUsuario(Int32 idUsuario)
        {
            DAUsuario daobjUsuario = new DAUsuario();
            try
            {
                return daobjUsuario.daDevolverUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public String daGrabarUsuario(Usuario objUsuario, Int16 pnTipoCon)
        {

            DAUsuario daobjUsuario = new DAUsuario();
            try
            {
                return daobjUsuario.daGrabarUsuario(objUsuario, pnTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable BLListarAplicacion(bool pbestado)
        {
            DAUsuario daobjUsuario = new DAUsuario();
            try
            {
                return daobjUsuario.DAListarAplicacion(pbestado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Usuario> BLListarCargooUsuario(bool pbestado, Int16 piTipoCon)
        {
            DAUsuario daobjUsuario = new DAUsuario();
            try
            {
                return daobjUsuario.DAListarCargooUsuario(pbestado, piTipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Usuario> blDevolverSoloUsuario(Int32 idClaseV,Boolean buscar)
        {

            DAUsuario objClaseV = new DAUsuario();
            try
            {
                return objClaseV.daDevolverSoloUsuario(idClaseV,buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
