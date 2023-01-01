using Entities;

namespace Service
{
    public interface IProductService
    {
    
        Task<Product[]> GetProduct(string? name, int? price_from, int? price_to, int?[] categoryIds, int start, int limit, string? direction = "ASC", string? orderBy = "price");

    }
}