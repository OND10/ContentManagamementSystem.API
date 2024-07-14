using CMS.Domain.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infustracture.Shared
{
    public class ImageRepository : IImageRepository 
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ImageRepository(IWebHostEnvironment webHost, IHttpContextAccessor httpContextAccessor)
        {
            _webHost = webHost;   
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> Upload(object model, IFormFile file)
        {

            ImageValidation.ValidationFileUpload(file);
            
            string uniqueFileName = "";
            
            if (file != null)
            {
                // Uploading the image to the sepcified folder
                var localpath = System.IO.Path.Combine(_webHost.ContentRootPath, "Images", $"{ file.FileName}");
                using var stream = new FileStream(localpath, FileMode.Create);
                await file.CopyToAsync(stream);

                //Store filename and extenstion to the DB
                var httpRequest = _httpContextAccessor.HttpContext.Request;
                var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{file.FileName}";
                uniqueFileName = urlPath;

            }
            return await Task.FromResult<string>(uniqueFileName);
        }

    }
}
