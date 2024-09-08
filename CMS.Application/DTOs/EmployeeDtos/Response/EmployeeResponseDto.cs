using CMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs.EmployeeDtos.Response
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }
        public string ArabicFullName { get; set; }
        public string EnglishFullName { get; set; }
        public string ArPosition { get; set; }
        public string EnPosition { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public string ImageUrl { get; set; }
    }
}
