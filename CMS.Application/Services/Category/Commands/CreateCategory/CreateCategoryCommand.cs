using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.CategoryDtos.Request;
using CMS.Application.DTOs.CategoryDtos.Response;
using CMS.Application.DTOs.HomeDtos.Request;
using CMS.Application.Services.Home.Commands.CreateHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : ICommand<CategoryResponseDto>
    {
        public string EnglishName { get; set; } = string.Empty;
        public string ArabicName { get; set; } = string.Empty;
        public string EnglishDescription { get; set; } = null!;
        public string ArabicDescription { get; set; } = null!;

        public async Task<CreateCategoryCommand> FromRequest(CategoryRequestDto request)
        {
            return await Task.FromResult<CreateCategoryCommand>(new CreateCategoryCommand
            {
                EnglishName = request.EnglishName,
                EnglishDescription = request.EnglishDescription,
                ArabicName = request.ArabicName,
                ArabicDescription = request.ArabicDescription,
            });
        }
    }
}
