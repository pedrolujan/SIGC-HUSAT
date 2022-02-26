
namespace HubFirebase.Models
{
    public class OrderResponse<T>:BaseResponse
    {
        public T obj { get; set; }
    }
}
