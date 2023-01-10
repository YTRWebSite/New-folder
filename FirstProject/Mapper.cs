using AutoMapper;
using DTO;
using Entities;

namespace FirstProject
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Product, ProductDto>().ForMember(dest=>dest.CategoryName, opt=>opt.MapFrom(
                p=>p.Category.Name)).ReverseMap();
          
        }
    }
}
