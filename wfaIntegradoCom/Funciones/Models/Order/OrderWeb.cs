using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfaIntegradoCom.Funciones.Models.Order
{
    /*
    public class OrderWeb<T>
    {
        public Order order { get; set; }
        public T obj { get; set; }
    }*/

    public class OrderWeb
    {
        public decimal Totalprice { get; set; }
        public int intEstado { get; set; }
        public OrderData orderData { get; set; }
        public List<Product> products { get; set; }
        public string userId { get;set; }
    }

    public class OrderData
    {

        public string Celular { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string name2 { get; set; }
        public string street { get; set; }

    }

    public class Product
    {
        public string Moneda { get; set; }
        public decimal cantidad { get; set; }
        public string foto { get; set; }
        public int idProducto { get; set; }
        public int idUnidadMedida { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
    }
}
