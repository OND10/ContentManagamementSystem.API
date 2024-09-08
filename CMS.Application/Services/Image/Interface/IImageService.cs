using CMS.Application.Common.Handling;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Image.Interface
{
    public interface IImageService
    {
        Task<Result<string>> UploadImage(object model, IFormFile file);
    }
}
