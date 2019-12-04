using AutoMapper;
using MyCommerce.Product.Domain.Models.Search;
using MyCommerce.Product.Domain.Repository;
using MyCommerce.Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommerce.Product.Infrastructure.Repository
{
    public class ProductRepository : IReadonlyProductRepository, IWriteonlyProductRepository
    {
        private readonly FakeDB _fakeDB;

        public ProductRepository()
        {
            _fakeDB = FakeDB.Instance;
        }

        public async Task Create(Domain.Product product)
        {
            var products = await _fakeDB.ProductsAsync();
            products.Add(product);
        }

        public async Task<IList<Domain.Product>> Get(ProductSearchArgs args)
        {
            var products = await _fakeDB.ProductsAsync();
            if (args.Id.HasValue)
            {
                return products.Where(c => c.Id == args.Id).ToList();
            }
            return products.Where(c => 
                    (c.Price < args.MaxPrice && c.Price >= args.MinPrice) 
                    || c.CategoryId == args.CategoryId
                    || c.Stock > 0)
                .Take(args.Quantity ?? 20).ToList();
        }
    }
}