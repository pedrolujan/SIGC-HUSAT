using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Moneda
    {
        public Moneda() { }

        public Int32 idMoneda { get; set; }
        public String cNombre { get; set; }
        public String cSimbolo { get; set; }
        public String cAbreviatura { get; set; }
        public Boolean bEstado { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public Double precio { get; set; }
        public CambioMonedaVenta ClsCammbioMoneda { get; set; }
        public List<Moneda> lstMoneda { get; set; }
    
        public Moneda(Int32 pnidMoneda,String pnNombre,String pnSimbolo,Boolean pnEstado)
        {
            idMoneda = pnidMoneda;
            cNombre = pnNombre;
            cSimbolo = pnSimbolo;
            bEstado = pnEstado;

        }
        public Moneda(Int32 pnidMoneda,String pnSimbolo)
        {
            idMoneda = pnidMoneda;
            cSimbolo = pnSimbolo;
        }
    }

   

    
}   
