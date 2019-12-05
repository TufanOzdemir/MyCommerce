using MyCommerce.Authentication.Domain.Persistence;
using MyCommerce.Authentication.Domain.Search;
using System.Threading.Tasks;

namespace MyCommerce.Authentication.Domain.Services
{
    public class AuthenticationService
    {
        private readonly IReadonlyAuthenticationRepository _readonlyAuthenticationRepository;

        public AuthenticationService(IReadonlyAuthenticationRepository readonlyAuthenticationRepository)
        {
            _readonlyAuthenticationRepository = readonlyAuthenticationRepository;
        }

        public Task<User> LoginAsync(LoginSearchArgs args)
        {
            return _readonlyAuthenticationRepository.LoginAsync(args);
        }
    }
}