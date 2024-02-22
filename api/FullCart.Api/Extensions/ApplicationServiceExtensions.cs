using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullCart.Application;
using FullCart.Application.Interfaces;
using FullCart.Infrastructure;
using FullCart.Infrastructure.Data;
using FullCart.Infrastructure.Identity;
using FullCart.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace FullCart.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
       IConfiguration configuration)
        {

            services.AddDbContext<CartDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AppIdentityDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
            services.AddCors();
            //Infrastructure DI only - API needs to DI into Application services
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}