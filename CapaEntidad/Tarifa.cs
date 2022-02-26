using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Tarifa
    {
        public Tarifa() { }
        public Int32 IdTarifa { get; set; }
        public Int32 IdTipoTarifa { get; set; }
        public Double PrecioEquipo { get; set; }
        public Double PrecioPlan { get; set; }
        public Double PrecioRentaAdelantada { get; set; }
        public Double PrecioProrrateo { get; set; }
        public Double PrecioReactivacion { get; set; }
        public Double PrecioTotal { get; set; }
        public Int32 IdMoneda { get; set; }

        public Double RedondeoProrrateo { get; set; }
        public Double DescuentoEquipo { get; set; }
        public Double DescuentoProrrateo{ get; set; }
        public Double DescuentoRentaAdelantada { get; set; }
        public Double DescuentoReactivacion { get; set; }

        public Tarifa(Int32 paIdTarifa,Int32 paIdTipoTarifa,Double paPrecioEquipo, Double paPrecioPlan,Double paPrecioReact)
        {
            IdTarifa = paIdTarifa;
            IdTipoTarifa = paIdTipoTarifa;
            PrecioEquipo = paPrecioEquipo;
            PrecioPlan = paPrecioPlan;
            PrecioReactivacion = paPrecioReact;
        }
    }
    public class TipoTarifa
    {
        public TipoTarifa() { }

        public Int32 IdTipoTarifa { get; set; }
        public String Nombre { get; set; } 
        public Boolean Estado { get; set; }
        public DateTime FechaReistro { get; set; }
        public Int32 IdUsuario { get; set; }

        public TipoTarifa(Int32 idtipotarifa,String nombre,Boolean estado)
        {
            IdTipoTarifa = idtipotarifa;
            Nombre = nombre;
            Estado = estado;
        }

    }

}
