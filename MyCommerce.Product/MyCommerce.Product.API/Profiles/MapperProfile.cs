using AutoMapper;
using MyCommerce.Product.API.Models.Request;
using MyCommerce.Product.API.Models.Response;
using MyCommerce.Product.Application.Queries;
using MyCommerce.Product.Domain;
using MyCommerce.Product.Domain.Models.Search;

namespace MyCommerce.Product.API.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CategoryRequest, CategoryQuery>();
            CreateMap<ProductRequest, ProductQuery>();
            CreateMap<ProductQuery, ProductSearchArgs>();
            CreateMap<CategoryQuery, Category>();
            CreateMap<CategoryQuery, CategorySearchArgs>();

            CreateMap<Category, CategoryViewModel>();
            CreateMap<Domain.Product, ProductViewModel>();
        }
    }
}