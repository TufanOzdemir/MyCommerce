using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyCommerce.Product.Domain;
using MyCommerce.Product.Domain.Models.Search;
using MyCommerce.Product.Domain.Repository;
using MyCommerce.Product.Infrastructure.Data;

namespace MyCommerce.Product.Infrastructure.Repository
{
    public class CategoryRepository : IReadonlyCategoryRepository, IWriteonlyCategoryRepository
    {
        private readonly FakeDB _fakeDB;

        public CategoryRepository()
        {
            _fakeDB = FakeDB.Instance;
        }

        public async Task Create(Category category)
        {
            var categories = await _fakeDB.CategoriesAsync();
            categories.Add(category);
        }

        public async Task<IList<Category>> Get(CategorySearchArgs args)
        {
            var categories = await _fakeDB.CategoriesAsync();
            if (args.Id.HasValue)
            {
                return categories.Where(c => c.Id == args.Id).ToList();
            }
            return categories.Where(c=> c.BaseCategoryId == args.BaseCategoryId || c.Name == args.Name).ToList();
        }
    }
}