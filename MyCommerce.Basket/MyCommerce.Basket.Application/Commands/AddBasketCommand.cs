using AutoMapper;
using MediatR;
using MyCommerce.Basket.Domain.Repository;
using MyCommerce.Basket.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyCommerce.Basket.Application.Commands
{
    public class AddToBasketCommand : IRequest<bool>
    {
        public Guid CustomerGuid { get; set; }
        public int Id { get; set; }
        public int ProductId { get; set; }
    }

    public class CategoryCreateCommandHandler : IRequestHandler<AddToBasketCommand,bool>
    {
        private readonly IMapper _mapper;
        private readonly IReadonlyBasketRepository _readonlyBasketRepository;
        private readonly IWriteonlyBasketRepository _writeonlyBasketRepository;

        public CategoryCreateCommandHandler(IMapper mapper, IReadonlyBasketRepository readonlyBasketRepository, IWriteonlyBasketRepository writeonlyBasketRepository)
        {
            _mapper = mapper;
            _readonlyBasketRepository = readonlyBasketRepository;
            _writeonlyBasketRepository = writeonlyBasketRepository;
        }

        public async Task<bool> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<AddToBasketCommand, Domain.Basket>(request);
            var service = new BasketService(_readonlyBasketRepository, _writeonlyBasketRepository);
            await service.AddToBasket(model);
            return true;
        }
    }
}