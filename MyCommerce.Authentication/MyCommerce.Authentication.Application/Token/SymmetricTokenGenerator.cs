using Microsoft.IdentityModel.Tokens;
using MyCommerce.Authentication.Application.Configuration;
using MyCommerce.Authentication.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace MyCommerce.Authentication.Application.Token
{
    public class SymmetricTokenGenerator : ITokenGenerator
    {
        private readonly IConfigResolver _configResolver;
        public SymmetricTokenGenerator(IConfigResolver configResolver)
        {
            _configResolver = configResolver;
        }

        public string GetToken(User user)
        {
            if (user.Permissions == null)
            {
                throw new ArgumentNullException(nameof(user.Permissions));
            }
            var authConfig = _configResolver.Resolve<AuthenticationConfig>();
            var symmetricKey = Convert.FromBase64String(authConfig.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new List<Claim>()
            {
                new Claim(Consts.SecurityLevelClaimType, SecurityLevel.Application.GetHashCode().ToString())
            };
            claims.AddRange(user.Permissions.Select(role => new Claim(Consts.ApplicationLevelClaimType, role.PermissionCode)));
            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "MyCommerce.Authentication",
                IssuedAt = now,
                Subject = new ClaimsIdentity(claims),
                Expires = now.AddMinutes(60),
                NotBefore = now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256),
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}