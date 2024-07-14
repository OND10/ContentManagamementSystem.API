using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs.CategoryDtos.Response
{
    public class CategoryResponseDto
    {
        public int Id {  get; set; }
        public string EnglishName { get; set; } = string.Empty;
        public string ArabicName { get; set; } = string.Empty;
        public string EnglishDescription { get; set; } = null!;
        public string ArabicDescription { get; set; } = null!;
    }
}
