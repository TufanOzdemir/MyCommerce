using MyCommerce.Basket.Domain.Models.Search;
using MyCommerce.Basket.Domain.Repository;
using MyCommerce.Basket.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommerce.Basket.Infrastructure.Repository
{
    public class BasketRepository : IReadonlyBasketRepository, IWriteonlyBasketRepository
    {
        private readonly FakeDB _fakeDB;

        public BasketRepository()
        {
            _fakeDB = FakeDB.Instance;
        }

        public async Task Create(Domain.Basket basket)
        {
            var baskets = await _fakeDB.BasketsAsync();
            baskets.Add(basket);
        }

        public async Task AddToBasket(Domain.Basket basket)
        {
            var baskets = await _fakeDB.BasketsAsync();
            var dbModel = baskets.FirstOrDefault(c => c.CustomerGuid == basket.CustomerGuid);
            if (dbModel != null)
            {
                dbModel.ProductIds.AddRange(basket.ProductIds);
            }
            else
            {
                baskets.Add(basket);
            }
        }

        public async Task<IList<Domain.Basket>> Get(BasketSearchArgs args)
        {
            var baskets = await _fakeDB.BasketsAsync();
            if (args.Id.HasValue)
            {
                return baskets.Where(c => c.Id == args.Id).ToList();
            }
            return baskets.Where(c => c.CustomerGuid == args.CustomerGuid).ToList();
        }
    }
}