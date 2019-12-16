using MyCommerce.Basket.Domain.Models.Search;
using MyCommerce.Basket.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCommerce.Basket.Domain.Services
{
    public class BasketService
    {
        private readonly IReadonlyBasketRepository _readonlyCategoryRepository;
        private readonly IWriteonlyBasketRepository _writeonlyCategoryRepository;

        public BasketService(IReadonlyBasketRepository readonlyCategoryRepository, IWriteonlyBasketRepository writeonlyCategoryRepository)
        {
            _readonlyCategoryRepository = readonlyCategoryRepository;
            _writeonlyCategoryRepository = writeonlyCategoryRepository;
        }

        public Task<IList<Basket>> Get(BasketSearchArgs args)
        {
            return _readonlyCategoryRepository.Get(args);
        }

        public async Task Create(Basket category)
        {
            await _writeonlyCategoryRepository.Create(category);
        }
    }
}