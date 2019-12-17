using AutoMapper;
using FluentValidation.AspNetCore;
using MassTransit;
using MassTransit.RabbitMqTransport;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MyCommerce.Basket.API.Configuration;
using MyCommerce.Basket.API.Middlewares;
using MyCommerce.Basket.API.Profiles;
using MyCommerce.Basket.Application.Commands;
using MyCommerce.Basket.Application.Consumers;
using MyCommerce.Basket.Application.Pipeline;
using MyCommerce.Basket.Application.Queries;
using MyCommerce.Basket.Domain.Repository;
using MyCommerce.Basket.Infrastructure.Repository;
using MyCommerce.Common.Core;
using System;

namespace MyCommerce.Basket.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }
        private IHostingEnvironment _environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(BasketQuery));
            var configuration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(typeof(AddToBasketCommand)));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                       new OpenApiSecurityScheme
                       {
                           Name = "Authorization",
                           Type = SecuritySchemeType.ApiKey,
                           Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                           In = ParameterLocation.Header
                       });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new[] { "" }
                    }
                });
            });
            InitializeRepositories(services);
            services.AddSingleton<IConfigResolver, ConfigResolver>();
            services.AddSingleton(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthenticationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));
            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                var resolver = provider.GetService<IConfigResolver>();
                services.AddSecurity(resolver);
                var rabbitMQConfig = resolver.Resolve<RabbitMQConfig>();
                AddEventBus(services, rabbitMQConfig);
                services.AddScoped<AddBasketMessageConsumer>();
            }
        }

        private IServiceCollection AddEventBus(IServiceCollection services, RabbitMQConfig config)
        {
            services.AddMassTransit(x =>
            {
                x.AddBus(factory => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(config.Host, hostConfigurator =>
                    {
                        hostConfigurator.Username(config.Username);
                        hostConfigurator.Password(config.Password);
                    });

                    cfg.ReceiveEndpoint(host, nameof(AddBasketMessage), e =>
                    {
                        e.Consumer<AddBasketMessageConsumer>(factory);
                    });
                }));
            });

            services.AddSingleton<Microsoft.Extensions.Hosting.IHostedService, BusService>();
            return services;
        }

        private void InitializeRepositories(IServiceCollection services)
        {
            services.AddScoped<IReadonlyBasketRepository, BasketRepository>();
            services.AddScoped<IWriteonlyBasketRepository, BasketRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseAuthentication();
            app.UseExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
