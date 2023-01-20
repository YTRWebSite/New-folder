using Entities;
using DTO;
namespace T_Repository
{
    public interface IOrderRepository
    {
        Task<Order> Post(Order  order);
    }
}