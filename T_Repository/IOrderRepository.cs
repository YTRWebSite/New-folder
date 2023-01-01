using Entities;

namespace T_Repository
{
    public interface IOrderRepository
    {
        Task<Order> Post(Order order);
    }
}