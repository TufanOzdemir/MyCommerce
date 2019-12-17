using AutoMapper;
using MediatR;
using MyCommerce.Basket.Domain.Models.Search;
using MyCommerce.Basket.Domain.Repository;
using MyCommerce.Basket.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyCommerce.Basket.Application.Queries
{
    public class BasketQuery : IRequest<IList<Domain.Basket>>
    {
        public int? Id { get; set; }
        public Guid? CustomerGuid { get; set; }
    }

    public class CategoryQueryHandler : IRequestHandler<BasketQuery, IList<Domain.Basket>>
    {
        private readonly IMapper _mapper;
        private readonly IReadonlyBasketRepository _readonlyBasketRepository;
        private readonly IWriteonlyBasketRepository _writeonlyBasketRepository;

        public CategoryQueryHandler(IMapper mapper, IReadonlyBasketRepository readonlyCategoryRepository, IWriteonlyBasketRepository writeonlyCategoryRepository)
        {
            _mapper = mapper;
            _readonlyBasketRepository = readonlyCategoryRepository;
            _writeonlyBasketRepository = writeonlyCategoryRepository;
        }

        public Task<IList<Domain.Basket>> Handle(BasketQuery request, CancellationToken cancellationToken)
        {
            var search = _mapper.Map<BasketQuery, BasketSearchArgs>(request);
            var service = new BasketService(_readonlyBasketRepository, _writeonlyBasketRepository);
            return service.Get(search);
        }
    }
}