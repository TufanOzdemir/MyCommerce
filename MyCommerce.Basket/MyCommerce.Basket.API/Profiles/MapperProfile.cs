using AutoMapper;
using MyCommerce.Basket.API.Models.Request;
using MyCommerce.Basket.API.Models.Response;
using MyCommerce.Basket.Application.Queries;
using MyCommerce.Basket.Domain.Models.Search;
using System.Collections.Generic;

namespace MyCommerce.Basket.API.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BasketRequest, BasketQuery>();
            CreateMap<BasketQuery, Domain.Basket>();
            CreateMap<BasketQuery, BasketSearchArgs>();
            CreateMap<Domain.Basket, BasketViewModel>()
                .ForMember(dst => dst.Links, opt => opt.MapFrom(src =>
                     new List<Link>
                         {
                            new Link { Rel="self", Url=string.Format($"localhost/api/basket/{src.Id}") },
                         }
                ));
        }
    }
}