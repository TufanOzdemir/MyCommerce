using AutoMapper;
using MyCommerce.Product.API.Models.Request;
using MyCommerce.Product.API.Models.Response;
using MyCommerce.Product.Application.Commands;
using MyCommerce.Product.Application.Queries;
using MyCommerce.Product.Domain;
using MyCommerce.Product.Domain.Models.Search;
using System.Collections.Generic;

namespace MyCommerce.Product.API.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SearchCategoryRequest, CategoryQuery>();
            CreateMap<ProductRequest, ProductQuery>();
            CreateMap<ProductQuery, ProductSearchArgs>();
            CreateMap<CategoryQuery, Category>();
            CreateMap<CategoryQuery, CategorySearchArgs>();

            CreateMap<Category, CategoryViewModel>();
            CreateMap<Domain.Product, ProductViewModel>()
                .ForMember(dst => dst.Links, opt => opt.MapFrom(src =>
                     new List<Link>
                         {
                            new Link { Rel="self", Url=string.Format($"localhost/api/product/{src.Id}") },
                         }
                ));

            CreateMap<CategoryCreateRequest, CategoryCreateCommand>();
            CreateMap<CategoryCreateCommand, Category>();
        }
    }
}