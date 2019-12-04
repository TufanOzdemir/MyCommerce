using MyCommerce.Product.Domain.Models.Search;
using MyCommerce.Product.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCommerce.Product.Domain.Services
{
    public class CategoryService
    {
        private readonly IReadonlyCategoryRepository _readonlyCategoryRepository;
        private readonly IWriteonlyCategoryRepository _writeonlyCategoryRepository;

        public CategoryService(IReadonlyCategoryRepository readonlyCategoryRepository, IWriteonlyCategoryRepository writeonlyCategoryRepository)
        {
            _readonlyCategoryRepository = readonlyCategoryRepository;
            _writeonlyCategoryRepository = writeonlyCategoryRepository;
        }

        public Task<IList<Category>> Get(CategorySearchArgs args)
        {
            return _readonlyCategoryRepository.Get(args);
        }

        public async Task Create(Category category)
        {
            await _writeonlyCategoryRepository.Create(category);
        }
    }
}