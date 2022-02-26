using System;

namespace selferviceSIGC.Model.Business
{
    public class Pedido
    {
        public int intPedido { get; set; }
        public string Codigo { get; set; }
        public int intEstado { get; set; }
        public string xmlObject { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public int idUser { get; set; }
        public DateTime dFechaAct { get; set; }
        public int idUserAct { get; set; }
    }
}
