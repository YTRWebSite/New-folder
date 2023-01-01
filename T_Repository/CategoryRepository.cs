using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace T_Repository

{
    public class CategoryRepository : ICategoryRepository
    {
        ProductsContext _dbContext;
        public CategoryRepository(ProductsContext _dbContext)
        {
            this._dbContext = _dbContext;

        }
        public async Task<IEnumerable<Category> >Get()
        {
            var list = await (from c in _dbContext.Categories
                              select c).ToListAsync();

            //foreach (var category in list)
            //{
            //    foreach (var item in _context.Products)
            //    {
            //        if (item.CategoryId==category.Id)
            //        {
            //             category.Products.Add(item);
            //        }
            //    }
            //}

            return list;
        

            //return _dbContext.Categories.ToArray();


        }
    }
}
