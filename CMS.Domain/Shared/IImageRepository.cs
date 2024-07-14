using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Shared
{
    public interface IImageRepository
    {
        Task<string> Upload(object model , IFormFile file);
    }
}
