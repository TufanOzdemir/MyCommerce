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
            var categories = await _fakeDB.CategoriesAsync();
            categories.Add(basket);
        }

        public async Task<IList<Domain.Basket>> Get(BasketSearchArgs args)
        {
            var baskets = await _fakeDB.CategoriesAsync();
            if (args.Id.HasValue)
            {
                return baskets.Where(c => c.Id == args.Id).ToList();
            }
            return baskets.Where(c=> c.CustomerGuid == args.CustomerGuid).ToList();
        }
    }
}