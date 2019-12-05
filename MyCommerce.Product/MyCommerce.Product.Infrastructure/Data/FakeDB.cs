using MyCommerce.Product.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductModel = MyCommerce.Product.Domain.Product;

namespace MyCommerce.Product.Infrastructure.Data
{
    internal class FakeDB
    {
        public static FakeDB Instance = new FakeDB();

        private List<Category> Categories;

        private List<ProductModel> Products;

        private FakeDB()
        {
            Categories = new List<Category>
            {
                new Category
                {
                    BaseCategoryId = null,
                    Id = 1,
                    Name = "Kıyafet"
                },
                new Category
                {
                    BaseCategoryId = null,
                    Id = 2,
                    Name = "Elektronik"
                }
            };

            Products = new List<ProductModel>
            {
                new ProductModel
                {
                    CategoryId = 1,
                    Id = 1,
                    Name = "Bluz Kadın",
                    ImageUrls = null,
                    Price = 10,
                    Stock = 1
                },
                new ProductModel
                {
                    CategoryId = 2,
                    Id = 2,
                    Name = "Monster PC",
                    ImageUrls = null,
                    Price = 10000,
                    Stock = 14
                }
            };
        }

        public async Task<List<Category>> CategoriesAsync()
        {
            return Categories;
        }
        public async Task<List<ProductModel>> ProductsAsync()
        {
            return Products;
        }
    }
}
