using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wfaIntegradoCom.Funciones.Models;

namespace wfaIntegradoCom.Funciones
{
    public class Format
    {

        /// <summary>
        /// Transforma un string de json en un diccionario
        /// </summary>
        /// <param name="stringifiedJson"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        internal static IDictionary<string, string> FormatPrintingServiceStringifiedJson(string stringifiedJson)
        {
            try
            {
                IDictionary<string, object> dictionaryObject = new Dictionary<string, object>();
                var converter = new Newtonsoft.Json.Converters.ExpandoObjectConverter();
                dynamic dynamicObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(stringifiedJson, converter);
                dictionaryObject = (IDictionary<string, object>)dynamicObject;
                IDictionary<string, string> dictionary = dictionaryObject.ToDictionary(k => k.Key, k => k.Value == null ? "" : k.Value.ToString());
                return dictionary;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static List<WPF.CTRL.Colocaciones.DCPedido> FormatPedidotoDCPedido(List<Pedido> lstPedido)
        {
            List<WPF.CTRL.Colocaciones.DCPedido> pedidos = null;
            WPF.CTRL.Colocaciones.DCPedido pedido = new WPF.CTRL.Colocaciones.DCPedido();
            try
            {
                pedidos = new List<WPF.CTRL.Colocaciones.DCPedido>();
                foreach (Pedido order in lstPedido)
                {
                    pedido = new WPF.CTRL.Colocaciones.DCPedido
                    {
                        intPedido = order.intPedido,
                        Codigo = order.Codigo,
                        EventType = 0,
                    };
                    pedidos.Add(pedido);
                };

                return pedidos;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
