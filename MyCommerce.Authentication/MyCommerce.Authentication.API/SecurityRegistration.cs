﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace MyCommerce.Authentication.API
{
    public static class SecurityRegistration
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
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
                          ValidIssuer = "MngKargo.Authentication",

                          ValidateAudience = false,

                          RequireSignedTokens = true,
                          IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String("7211de8f-a2af-4b8c-aa49-17606bec91be"))
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
