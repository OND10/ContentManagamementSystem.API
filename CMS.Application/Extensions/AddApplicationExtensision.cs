using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using OnMapper;
using CMS.Application.Services.User.Interface;
using CMS.Application.Services.User.Implementation;
using CMS.Application.Shared;
using CMS.Domain.Entities;
using CMS.Application.DTOs.HostingPackageDtos.Request;

namespace CMS.Application.Extensions
{
    public static class AddApplicationExtensision
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {

            service.AddScoped<OnMapping>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IImageService, ImageService>();
            service.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return service;
        }
    }
}
