using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.AboutDtos.Request;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.HomeDtos.Request;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Application.Services.Home.Commands.CreateHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.About.Commands.CreateAbout
{
    public class CreateAboutCommand : ICommand<AboutResponseDto>
    {
        public string EnglishTitle { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public string ImageUrl { get; set; }

        public async Task<CreateAboutCommand> FromRequest(AboutRequestDto request)
        {
            return await Task.FromResult<CreateAboutCommand>(new CreateAboutCommand
            {
                ArabicTitle = request.ArabicTitle,
                EnglishTitle = request.EnglishTitle,
                ArabicDescription = request.ArabicDescription,
                EnglishDescription = request.EnglishDescription,
                ImageUrl = request.ImageUrl,

            });
        }
    }
}
