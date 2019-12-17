using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCommerce.Basket.Infrastructure.Data
{
    internal class FakeDB
    {
        public static FakeDB Instance = new FakeDB();

        private List<Domain.Basket> Baskets;

        private FakeDB()
        {
            Baskets = new List<Domain.Basket>
            {
                new Domain.Basket
                {
                    Id = 1,
                    CustomerGuid = Guid.NewGuid(),
                    ProductIds = new List<int>(){ 1,2,3,4 }
                },
                new Domain.Basket
                {
                    Id = 2,
                    CustomerGuid = Guid.NewGuid(),
                    ProductIds = new List<int>(){ 14 }
                },
                new Domain.Basket
                {
                    Id = 3,
                    CustomerGuid = Guid.NewGuid(),
                    ProductIds = new List<int>(){ 12,16 }
                }
            };
        }

        public async Task<List<Domain.Basket>> BasketsAsync()
        {
            return Baskets;
        }
    }
}