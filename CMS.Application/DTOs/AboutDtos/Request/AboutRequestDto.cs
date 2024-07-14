using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs.AboutDtos.Request
{
    public class AboutRequestDto
    {
        public string EnglishTitle { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile file { get; set; }
        public string ModifiedBy {  get; set; }
    }
}
