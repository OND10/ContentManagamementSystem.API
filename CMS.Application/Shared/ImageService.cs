using CMS.Application.Common.Handling;
using CMS.Domain.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Shared
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _repository;
        public ImageService(IImageRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<string>> UploadImage(object model, IFormFile file)
        {
            var result = await _repository.Upload(model, file);

            return await Result<string>.SuccessAsync(result, ResponseStatus.UploadedSuccess, true);
        }
    }
}
