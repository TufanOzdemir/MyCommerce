using MyCommerce.Authentication.Domain;
using System.Collections.Generic;

namespace MyCommerce.Authentication.Application
{
    public interface ITokenGenerator
    {
        string GetToken(User user);
    }
}