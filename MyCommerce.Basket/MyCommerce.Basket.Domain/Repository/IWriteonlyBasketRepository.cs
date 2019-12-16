using System.Threading.Tasks;

namespace MyCommerce.Basket.Domain.Repository
{
    public interface IWriteonlyBasketRepository
    {
        Task Create(Basket basket);
    }
}