using MyCommerce.Product.Domain.Models.Search;
using MyCommerce.Product.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCommerce.Product.Domain.Services
{
    public class ProductService
    {
        private readonly IReadonlyProductRepository _readonlyProductRepository;
        private readonly IWriteonlyProductRepository _writeonlyProductRepository;

        public ProductService(IReadonlyProductRepository readonlyProductRepository, IWriteonlyProductRepository writeonlyProductRepository)
        {
            _readonlyProductRepository = readonlyProductRepository;
            _writeonlyProductRepository = writeonlyProductRepository;
        }

        public Task<IList<Product>> Get(ProductSearchArgs args)
        {
            return _readonlyProductRepository.Get(args);
        }

        public void Create(Product product)
        {
            _writeonlyProductRepository.Create(product);
        }
    }
}