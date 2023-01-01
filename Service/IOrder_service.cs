using Entities;

namespace Service
{
    public interface IOrder_service
    {
        Task<Order> Post(Order order);
    }
}