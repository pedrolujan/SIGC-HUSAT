using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Ciclo
    {
        public Ciclo() { }

        public Int32 IdCiclo { get; set; }
        public String Dia { get; set; }
        public Int32 DiaNumber { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Int32 idUsuario { get; set; }
        public Boolean Estado { get; set; }

        public Ciclo(Ciclo Add)
        {
            this.IdCiclo = Add.IdCiclo;
            this.Dia = Add.Dia;
            this.Estado = Add.Estado;
        }

        public static Ciclo fnObtenerCicloSeleccionado(Int32 idCiclo, List<Ciclo> lstC)
        {
            foreach (Ciclo item in lstC)
            {
                if (item.IdCiclo == idCiclo)
                {
                    return item;
                }
            }
            return new Ciclo();
        }
    }
}
