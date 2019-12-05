using MediatR;
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
        public Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}