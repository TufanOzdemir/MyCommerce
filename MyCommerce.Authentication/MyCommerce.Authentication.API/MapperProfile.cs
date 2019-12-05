using AutoMapper;
using MyCommerce.Authentication.API.Models;
using MyCommerce.Authentication.Application;
using MyCommerce.Authentication.Domain.Search;

namespace MyCommerce.Authentication.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<LoginRequest, LoginQuery>();
            CreateMap<LoginQuery, LoginSearchArgs>();
        }
    }
}