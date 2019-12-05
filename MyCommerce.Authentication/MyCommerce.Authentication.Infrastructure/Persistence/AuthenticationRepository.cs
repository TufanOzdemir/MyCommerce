using MyCommerce.Authentication.Domain;
using MyCommerce.Authentication.Domain.Persistence;
using MyCommerce.Authentication.Domain.Search;
using MyCommerce.Authentication.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommerce.Authentication.Infrastructure.Persistence
{
    public class AuthenticationRepository : IReadonlyAuthenticationRepository
    {
        public async Task<User> LoginAsync(LoginSearchArgs args)
        {
            return await Task<User>.Run(() =>
            {
                return FakeDB.Instance.Users.FirstOrDefault(c => c.UserName == args.UserName && c.Password == args.Password);
            });
        }
    }
}