using HubFirebase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubFirebase
{
    public interface IFirebaseApi
    {
        /// <summary>
        /// Obtiene order cuando por primera vez de insercion el firebase no lo trae consigo.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<OrderResponse<dynamic>> getOrderId(string Codigo);
        Task<OrderResponse<dynamic>> updateOrderId(string Codigo, int intEstado);
    }
}
 