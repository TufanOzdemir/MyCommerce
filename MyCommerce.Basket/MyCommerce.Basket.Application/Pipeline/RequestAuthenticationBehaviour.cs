using MediatR;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Authentication;
using System.Threading;
using System.Reflection;

namespace MyCommerce.Basket.Application.Pipeline
{
    public class RequestAuthenticationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public RequestAuthenticationBehaviour(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public System.Threading.Tasks.Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var attrs = request.GetType().GetCustomAttributes<RequiredPermissionAttribute>(false);

            if (attrs != null && attrs.Any())
            {
                bool hasClaim = false;
                foreach (var attr in attrs)
                {
                    hasClaim = _httpContextAccessor.HttpContext.User.HasClaim(c => c.Value == attr.RequiredPermission.PermissionCode);
                    if (hasClaim)
                        return next();
                }

                throw new AuthenticationException();
            }

            return next();
        }
    }
}