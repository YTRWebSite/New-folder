using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using T_Repository;
namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _ICategoryRepository;
        public CategoryService(ICategoryRepository _ICategoryRepository)
        {
            this._ICategoryRepository = _ICategoryRepository;
        }
        public async Task<IEnumerable<Category>> Get()
        {
            return await _ICategoryRepository.Get();
        }
    }
}
