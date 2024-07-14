using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.HomeDtos.Request;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.DTOs.HostingPackageDtos.Request;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Application.Services.HostingPackage.Commands.UpdateHostingPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Home.Commands.CreateHome
{
    public class CreateHomeCommand : ICommand<HomeResponseDto>
    {
        public string EnglishTitle { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public string LogoUrl { get; set; }
        public string ImageUrl { get; set; }

        public async Task<CreateHomeCommand> FromRequest(HomeRequestDto request)
        {
            return await Task.FromResult<CreateHomeCommand>(new CreateHomeCommand
            {
                ArabicTitle = request.ArabicTitle,
                EnglishTitle = request.EnglishTitle,
                ArabicDescription = request.ArabicDescription,
                EnglishDescription = request.EnglishDescription,
                ImageUrl = request.ImageUrl,
                LogoUrl = request.LogoUrl,
                
            });
        }
    }
}
