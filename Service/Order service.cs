using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using T_Repository;
namespace Service
{
    public class Order_service : IOrder_service
    {
        private readonly IOrderRepository _IOrderRepository;
        public Order_service(IOrderRepository _IOrderRepository)
        {
            this._IOrderRepository = _IOrderRepository;
        }
        public async Task<Order> Post(Order order)
        {
            return await _IOrderRepository.Post(order);
        }
    }
}
