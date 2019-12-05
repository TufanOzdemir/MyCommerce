using AutoMapper;
using MediatR;
using MyCommerce.Authentication.Domain.Persistence;
using MyCommerce.Authentication.Domain.Search;
using MyCommerce.Authentication.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyCommerce.Authentication.Application
{
    public class LoginQuery : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly IMapper _mapper;
        private readonly IReadonlyAuthenticationRepository _readonlyAuthenticationRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public LoginQueryHandler(IMapper mapper, IReadonlyAuthenticationRepository readonlyAuthenticationRepository, ITokenGenerator tokenGenerator)
        {
            _mapper = mapper;
            _readonlyAuthenticationRepository = readonlyAuthenticationRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var search = _mapper.Map<LoginQuery, LoginSearchArgs>(request);
            var service = new AuthenticationService(_readonlyAuthenticationRepository);
            var user = await service.LoginAsync(search);
            if (user == null)
            {
                return null;
            }
            return _tokenGenerator.GetToken(user);
        }
    }
}