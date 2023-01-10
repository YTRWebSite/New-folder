using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDto
    {
        public ProductDto()
        {
          
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string Descreption { get; set; } = null!;
        public int Price { get; set; }
        public string ImgUrl { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public int CategoryId { get; set; }

        
    }
}

