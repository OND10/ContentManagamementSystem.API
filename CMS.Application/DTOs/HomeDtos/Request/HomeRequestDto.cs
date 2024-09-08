using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs.HomeDtos.Request
{
    public class HomeRequestDto
    {
        public string EnglishTitle { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public IFormFile image {  get; set; }
        public IFormFile logo {  get; set; }
    }
}
