using Microsoft.Extensions.DependencyInjection;
using Supermarket.Application.Interfaces;
using Supermarket.Application.Mapping;
using Supermarket.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Supermarket.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ProductProfile>();
            });

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductBatchService, ProductBatchService>();
            return services;
        }
    }
}
