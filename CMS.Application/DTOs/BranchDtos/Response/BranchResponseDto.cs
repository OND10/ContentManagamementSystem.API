using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs.BranchDtos.Response
{
    public class BranchResponseDto
    {
        public int Id {  get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
    }
}
