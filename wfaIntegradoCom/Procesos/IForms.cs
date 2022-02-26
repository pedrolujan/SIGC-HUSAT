using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidad;

namespace wfaIntegradoCom.Procesos
{
    public interface IForms
    {
        void AgregarVenta(VentaMesa objVenta, String Cliente);
    }

}
