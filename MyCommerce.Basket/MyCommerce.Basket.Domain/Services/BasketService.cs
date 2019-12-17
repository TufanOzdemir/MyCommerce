using MyCommerce.Basket.Domain.Models.Search;
using MyCommerce.Basket.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCommerce.Basket.Domain.Services
{
    public class BasketService
    {
        private readonly IReadonlyBasketRepository _readonlyBasketRepository;
        private readonly IWriteonlyBasketRepository _writeonlyBasketRepository;

        public BasketService(IReadonlyBasketRepository readonlyBasketRepository, IWriteonlyBasketRepository writeonlyBasketRepository)
        {
            _readonlyBasketRepository = readonlyBasketRepository;
            _writeonlyBasketRepository = writeonlyBasketRepository;
        }

        public Task<IList<Basket>> Get(BasketSearchArgs args)
        {
            return _readonlyBasketRepository.Get(args);
        }

        public async Task Create(Basket basket)
        {
            await _writeonlyBasketRepository.Create(basket);
        }

        public async Task AddToBasket(Basket basket)
        {
            await _writeonlyBasketRepository.AddToBasket(basket);
        }
    }
}