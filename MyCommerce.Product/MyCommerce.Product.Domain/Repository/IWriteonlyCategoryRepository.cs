using System.Threading.Tasks;

namespace MyCommerce.Product.Domain.Repository
{
    public interface IWriteonlyCategoryRepository
    {
        Task Create(Category category);
    }
}