using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using OnMapper;
using CMS.Application.Services.User.Interface;
using CMS.Application.Services.User.Implementation;
using CMS.Application.Services.Image.Interface;
using CMS.Application.Services.Image.implementation;
using CMS.Domain.Interfaces;
using CMS.Application.Services.Country.Interface;
using CMS.Application.Services.Country.Implementation;
using System.Data;
using System.Data.Common;

namespace CMS.Application.Extensions
{
    public static class AddApplicationExtensision
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {

            service.AddScoped<OnMapping>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IImageService, ImageService>();
            service.AddScoped<ICountryService, CountryService>();
            service.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return service;
        }
    }
}
