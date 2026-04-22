using Microsoft.Extensions.DependencyInjection;
//using Supermarket.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Supermarket.Application.Products.Services;
using Supermarket.Application.Products.Interfaces;
using Supermarket.Application.Inventory.Interfaces;
using Supermarket.Application.Inventory.Services;

namespace Supermarket.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IInventoryService, InventoryService>();
            return services;
        }
    }
}
