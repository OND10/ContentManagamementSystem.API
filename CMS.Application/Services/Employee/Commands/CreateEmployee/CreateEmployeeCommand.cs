using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.AboutDtos.Request;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.EmployeeDtos.Request;
using CMS.Application.DTOs.EmployeeDtos.Response;
using CMS.Application.DTOs.HomeDtos.Request;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Application.Services.Home.Commands.CreateHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : ICommand<EmployeeResponseDto>
    {
        public string ArabicFullName { get; set; }
        public string EnglishFullName { get; set; }
        public string ArPosition { get; set; }
        public string EnPosition { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public string ImageUrl { get; set; }

        public async Task<CreateEmployeeCommand> FromRequest(EmployeeRequestDto request)
        {
            return await Task.FromResult<CreateEmployeeCommand>(new CreateEmployeeCommand
            {
                ArabicFullName = request.ArabicFullName,
                EnglishFullName = request.EnglishFullName,
                ArPosition = request.ArPosition,
                EnPosition = request.EnPosition,
                Location = request.Location,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Department = request.Department,
                ImageUrl = request.ImageUrl,
            });
        }
    }
}
