using System.Threading.Tasks;

namespace MyCommerce.Product.Domain.Repository
{
    public interface IWriteonlyProductRepository
    {
        Task Create(Product product);
    }
}