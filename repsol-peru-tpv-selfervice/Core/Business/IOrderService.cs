using selferviceSIGC.Model.Business;
using System.Collections.Generic;

namespace selferviceSIGC.Core.Business
{
    public interface IOrderService
    {
        bool fnSaveOrder(Pedido objPedido);
        string fnGetOrderxCodigo(string Codigo);
        List<Pedido> fnGeAllorEspecificOrder(string Codigo);
    }
}
