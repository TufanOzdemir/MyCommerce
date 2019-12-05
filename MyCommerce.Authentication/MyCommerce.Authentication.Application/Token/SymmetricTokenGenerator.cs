using MyCommerce.Authentication.Domain;
using System;
using System.Collections.Generic;

namespace MyCommerce.Authentication.Application.Token
{
    public class SymmetricTokenGenerator : ITokenGenerator
    {
        public string GetToken(IList<UserPermission> permissions, User user)
        {
            throw new NotImplementedException();
        }
    }
}