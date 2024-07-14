using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.AboutDtos.Request;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.HomeDtos.Request;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Application.Services.About.Commands.CreateAbout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.About.Commands.UpdateAbout
{
    public class UpdateAboutCommand : ICommand<AboutResponseDto>
    {
        public int Id { get; set; }
        public string EnglishTitle { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public string ImageUrl { get; set; }
        public string ModifiedBy {  get; set; }

        public async Task<UpdateAboutCommand> FromRequest(AboutRequestDto request)
        {
            return await Task.FromResult<UpdateAboutCommand>(new UpdateAboutCommand
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
