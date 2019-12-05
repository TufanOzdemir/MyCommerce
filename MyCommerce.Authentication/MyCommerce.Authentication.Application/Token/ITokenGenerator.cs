using MyCommerce.Authentication.Domain;
using System.Collections.Generic;

namespace MyCommerce.Authentication.Application
{
    interface ITokenGenerator
    {
        string GetToken(IList<UserPermission> permissions, User user);
    }
}