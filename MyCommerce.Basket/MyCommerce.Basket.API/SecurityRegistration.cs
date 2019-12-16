using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyCommerce.Basket.API.Configuration;
using System;
using System.Threading.Tasks;

namespace MyCommerce.Basket.API
{
    public static class SecurityRegistration
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services, IConfigResolver configResolver)
        {
            AuthenticationConfig configuration = null;
            configuration = configResolver.Resolve<AuthenticationConfig>();

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration), "Authentication configuration is missing");


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
              )
                  .AddJwtBearer(options =>
                  {
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                          RequireExpirationTime = true,
                          ValidateLifetime = true,
                          ClockSkew = TimeSpan.Zero,
                          ValidateIssuer = true,
                          ValidIssuer = "MyCommerce.Authentication",

                          ValidateAudience = false,

                          RequireSignedTokens = true,
                          IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(configuration.Secret))
                      };
                      options.Events = new JwtBearerEvents
                      {
                          OnTokenValidated = ctx =>
                          {
                              return Task.CompletedTask;
                          },
                          OnChallenge = ctx =>
                          {

                              return Task.CompletedTask;
                          },

                          OnAuthenticationFailed = ctx =>
                          {
                              if (ctx.Exception.GetType() == typeof(SecurityTokenExpiredException))
                              {
                                  ctx.Response.Headers.Add("Token-Expired", true.ToString().ToLower());
                              }
                              ctx.Fail("Not Authorized");
                              return Task.CompletedTask;
                          }
                      };

                  });

            return services;
        }
    }
}