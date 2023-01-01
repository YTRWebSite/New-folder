using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Repository
{
    public class ProductRepository : IProductRepository
    {
        ProductsContext _dbContext;
        public ProductRepository(ProductsContext _dbContext)
        {
            this._dbContext = _dbContext;

        }
       



        public async Task<Product[]> GetProduct(string? name, int? price_from, int? price_to, int?[] categoryIds, int start, int limit, string? direction = "ASC", string? orderBy = "price")
        {

            {
                var query = _dbContext.Products.Where(product => (name == null ? (true) : (product.Name.Contains(name)))
                  && ((price_from == null) ? (true) : (product.Price >= price_from))
                   && ((price_to == null) ? (true) : (product.Price <= price_to))

                 && (categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))
                  && ((price_to == null) ? (true) : (product.Price <= price_to))).OrderBy(product => orderBy);
                Console.WriteLine(query);

                List<Product> products = query.ToList();
                return products.ToArray();

            }
        }
    }
}
