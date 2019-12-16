using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCommerce.Basket.Infrastructure.Data
{
    internal class FakeDB
    {
        public static FakeDB Instance = new FakeDB();

        private List<Domain.Basket> Categories;

        private FakeDB()
        {
            Categories = new List<Domain.Basket>
            {
                new Domain.Basket
                {
                    Id = 1
                }
            };
        }

        public async Task<List<Domain.Basket>> CategoriesAsync()
        {
            return Categories;
        }
    }
}