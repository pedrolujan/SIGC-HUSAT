using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Reactivaciones
    {
        public List<Equipo_imeis> listaEquipoNuevo { get; set; }
        public List<Equipo_imeis> listaEquipoAntiguo { get; set; }
        public List<SimCard> listaSimCardNuevo { get; set; }
        public List<SimCard> listaSimCardAntiguo { get; set; }
        public List<Cliente> listaCliente { get; set; }
        public List<Vehiculo> listaVehiculo { get; set; }
        public List<Plan> listaPlan { get; set; }
        
        public DateTime FechaReactivacionesE{ get; set; }
        public DateTime FechaRegistroSC { get; set; }
        public DateTime FechaReactivacionesSC { get; set; }
        public String ObservacionesE { get; set; }
        public String ObservacionesSC { get; set; }


    }
}
