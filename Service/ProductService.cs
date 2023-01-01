using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Repository;
using Entities;
namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _IProductRepository;
        public ProductService(IProductRepository ProductRepository)
        {
            _IProductRepository =ProductRepository;
        }
       
        public async Task<Product[]> GetProduct(string? name, int? price_from, int? price_to, int?[] categoryIds, int start, int limit, string? direction = "ASC", string? orderBy = "price")
        {
            Product [] product = await _IProductRepository.GetProduct(name, price_from, price_to, categoryIds, start, limit, direction, orderBy);
            return product;
        }

    }
}
