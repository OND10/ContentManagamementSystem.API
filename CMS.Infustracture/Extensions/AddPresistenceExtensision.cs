using CMS.Domain.Interfaces;
using CMS.Infustracture.Database;
using CMS.Infustracture.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using CMS.Domain.Entities;
using CMS.Domain.Shared;
using CMS.Infustracture.Email;
using Microsoft.AspNetCore.Identity.UI.Services;
using CMS.Application.Services.User.Interface;
using CMS.Application.Services.User.Implementation;
using CMS.Infustracture.Shared;
using CMS.Application.Shared;
using CMS.Application.DTOs.HostingPackageDtos.Request;

namespace CMS.Infustracture.Extensions
{
    public static class AddPresistenceExtensision
    {
        public static IServiceCollection AddPresistence(this IServiceCollection service, IConfiguration configuration)
        {

            service.AddScoped<ApplicationDapperContext>();
            service.AddScoped<IHostingPackageRepository, HostingPackageRepository>();
            service.AddScoped<ITokenRepository, TokenRepository>();
            service.AddScoped<IUserManagerRepository, UserManagerRepository>();
            service.AddScoped<ICartRepository, CartRepository>();
            service.AddScoped<IImageRepository, ImageRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IContactRepository, ContactRepository>();
            service.AddScoped<IHomeRepository, HomeRepository>();
            service.AddScoped<IAboutRepository, AboutRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IEmailSender, EmailSender>();

            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("defaultConnectionString"));
            });
            service.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
            
            return service;
        }
    }
}
