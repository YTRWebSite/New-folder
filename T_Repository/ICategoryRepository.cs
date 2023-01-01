using Entities;

namespace T_Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Get();
    }
}