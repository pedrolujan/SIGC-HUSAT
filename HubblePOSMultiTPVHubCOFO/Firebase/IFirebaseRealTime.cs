using Firebase.Database.Streaming;
using HubFirebase.Models;
using System;
using System.Threading.Tasks;

namespace HubFirebase.Firebase
{
    public interface IFirebaseRealTime:IDisposable
    {

        event EventHandler<FirebaseEvent<dynamic>> StatusChangedFirebase;
        Task<OrderResponse<dynamic>> getOrderId(string codigo);
        Task<OrderResponse<dynamic>> updateOrderId(string codigo, int intEstado);

    }
}
