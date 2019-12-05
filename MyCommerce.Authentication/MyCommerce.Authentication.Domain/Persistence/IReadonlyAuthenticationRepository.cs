using MyCommerce.Authentication.Domain.Search;
using System.Threading.Tasks;

namespace MyCommerce.Authentication.Domain.Persistence
{
    public interface IReadonlyAuthenticationRepository
    {
        Task<User> LoginAsync(LoginSearchArgs args);
    }
}