using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.CategoryDtos.Request;
using CMS.Application.DTOs.CategoryDtos.Response;
using CMS.Application.Services.Category.Commands.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : ICommand<CategoryResponseDto>
    {
        public int Id { get; set; }
        public string EnglishName { get; set; } = string.Empty;
        public string ArabicName { get; set; } = string.Empty;
        public string EnglishDescription { get; set; } = null!;
        public string ArabicDescription { get; set; } = null!;
        public string ModifiedBy {  get; set; } = string.Empty;

        public async Task<UpdateCategoryCommand> FromRequest(CategoryRequestDto request)
        {
            return await Task.FromResult<UpdateCategoryCommand>(new UpdateCategoryCommand
            {
                EnglishName = request.EnglishName,
                EnglishDescription = request.EnglishDescription,
                ArabicName = request.ArabicName,
                ArabicDescription = request.ArabicDescription,
            });
        }
    }
}
