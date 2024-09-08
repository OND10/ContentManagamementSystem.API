using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs.EmailDtos.Request
{
    public class EmailRequestDto
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }

    }
}
