using AutoMapper;
using MediatR;
using MyCommerce.Basket.Domain.Repository;
using MyCommerce.Basket.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyCommerce.Basket.Application.Commands
{
    public class AddBasketCommand : IRequest<bool>
    {
        public Guid CustomerGuid { get; set; }
        public int Id { get; set; }
    }

    public class CategoryCreateCommandHandler : IRequestHandler<AddBasketCommand,bool>
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

        public async Task<bool> Handle(AddBasketCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<AddBasketCommand, Domain.Basket>(request);
            var service = new BasketService(_readonlyBasketRepository, _writeonlyBasketRepository);
            await service.Create(model);
            return true;
        }
    }
}