using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Plan
    {
        public Plan() { }

        public Int32 idPlan { get; set; }
        public String codPlan { get; set; }
        public Int32 idTipoPlan { get; set; }
        public String nombrePlan { get; set; }
        public Double precio { get; set; }
        public String equipos { get; set; }
        public String tarifas { get; set; }
        public String tiposPlan { get; set; } 
        public String descripcion { get; set; }
        public Boolean estado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public Int32 idUsuario { get; set; }
        public Int32 idPlanAccesorio { get; set; }
        public Int32 idAccesorio { get; set; }
        public Boolean bEstado { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public Boolean estadoAcc { get; set; }
        public Int32 idMoneda { get; set; }
        public Double PrecioEquipo { get; set; }
        public Double PrecioRenovacion { get; set; }
        public Double Descuento { get; set; }
        public String ContratoPlan { get; set; }
        public String cLetraPlan { get; set; }
        public Int32 CicloPlan { get; set; }
        public Int32 idTipoTarifa { get; set; }
        public List<Plan> lstPlan { get; set; }
        public TipoPlan clsTP { get; set; }
        public Moneda clsM { get; set; }
        public Plan(Int32 pidPlan,Int32 pidTipoPlan,String pcNombre,Double pcPrecio,String pcEquipos,String pcDescripcion,Boolean pcEstado)
        {
            idPlan = pidPlan;
            nombrePlan = pcNombre;
            precio = pcPrecio;
            equipos = pcEquipos;
            descripcion = pcDescripcion;
            estado = pcEstado;
        }

        public Plan(String pCodPlan,Int32 cTipoPlan, String pcNombre, Double pcPrecio, String pcEquipos, String pcDescripcion, Boolean pcEstado)
        {
            codPlan = pCodPlan;
            idTipoPlan = cTipoPlan;
            nombrePlan = pcNombre;
            precio = pcPrecio;
            equipos = pcEquipos;
            descripcion = pcDescripcion;
            estado = pcEstado;
        }

        public Plan(Int32 pidPlan, String pcNombre, Boolean pcEstado, Double pcPrecio, Int32 pnIdMoneda,Double doPrecioEquipo, Double doPrecioRenovacion)
        {
            idPlan = pidPlan;
            nombrePlan = pcNombre;
            estado = pcEstado;
            precio = pcPrecio;
            idMoneda = pnIdMoneda;
            PrecioEquipo = doPrecioEquipo;
            PrecioRenovacion = doPrecioRenovacion;
        }

        public Plan(Int32 pidPlan, String pcNombre, Boolean pcEstado,Double pcPrecio,Int32 pnIdMoneda)
        {
            idPlan = pidPlan;
            nombrePlan = pcNombre;
            estado = pcEstado;
            precio = pcPrecio;
            idMoneda = pnIdMoneda;
        }

        public Plan(Int32 pidPlan, String pcNombre, Boolean pcEstado, Double pcPrecio, Int32 pnIdMoneda,Int32 tipoPlan)
        {
            idPlan = pidPlan;
            nombrePlan = pcNombre;
            estado = pcEstado;
            precio = pcPrecio;
            idMoneda = pnIdMoneda;
            idTipoPlan = tipoPlan;
        }

        public static Plan fnObtenerPlanSeleccionado(Int32 idP, List<Plan> lstPlan)
        {
            foreach (Plan p in lstPlan)
            {
                if (p.idPlan == idP)
                {
                    //clsPlan
                    return p;
                }
            }
            return new Plan();
        }
    }
}
