using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.About.Queries.GetAboutById
{
    public class GetAboutByIdQuery : IQuery<AboutResponseDto>
    {
        public int Id {  get; set; }
    }
}
