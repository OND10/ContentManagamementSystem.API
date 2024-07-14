using CMS.Domain.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Shared
{
    public static class ImageValidation
    {
        public static void ValidationFileUpload(IFormFile file)
        {
            var preferedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!preferedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                throw new ModelNullException("file", "Image Format unsupported");
            }

            if (file.Length > 10485760)
            {
                throw new ModelNullException("file", "File size bigger than required");
            }
        }
    }
}
