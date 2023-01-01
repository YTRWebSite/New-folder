using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace T_Repository
{
    public class OrderRepository : IOrderRepository
    {
        ProductsContext _dbContext;
        public OrderRepository(ProductsContext _dbContext)
        {
            this._dbContext = _dbContext;

        }
        public async Task<Order> Post(Order order)
        {

            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;


        }
    }
}
