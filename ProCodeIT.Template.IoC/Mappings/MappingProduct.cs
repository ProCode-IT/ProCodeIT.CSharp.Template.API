using AutoMapper;
using ProCodeIT.Template.Models.Dummies;
using ProCodeIT.Template.Models.Entities;

namespace ProCodeIT.Template.IoC.Mappings
{
    public class MappingProduct : Profile
    {
        public MappingProduct()
        {
            CreateMap<ProductDummy, Product>();
            CreateMap<Product, ProductDummy>();
        }
    }
}
