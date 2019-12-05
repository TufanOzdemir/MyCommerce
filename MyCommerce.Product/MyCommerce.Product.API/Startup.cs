using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MyCommerce.Product.API.Profiles;
using MyCommerce.Product.Application.Queries;
using MyCommerce.Product.Domain;
using MyCommerce.Product.Domain.Repository;
using MyCommerce.Product.Infrastructure.Repository;

namespace MyCommerce.Product.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(CategoryQuery));
            var configuration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            InitializeRepositories(services);
            
        }

        private void InitializeRepositories(IServiceCollection services)
        {
            services.AddScoped<IReadonlyProductRepository, ProductRepository>();
            services.AddScoped<IWriteonlyProductRepository, ProductRepository>();
            services.AddScoped<IReadonlyCategoryRepository, CategoryRepository>();
            services.AddScoped<IWriteonlyCategoryRepository, CategoryRepository>();
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

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
