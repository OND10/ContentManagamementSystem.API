using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.CategoryDtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IQuery<CategoryResponseDto>
    {
        public int Id {  get; set; }
    }
}
