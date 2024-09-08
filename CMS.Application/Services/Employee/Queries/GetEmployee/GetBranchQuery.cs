using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.BranchDtos.Response;
using CMS.Application.DTOs.EmployeeDtos.Response;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Employee.Queries.GetEmployee
{
    public class GetEmployeeQuery : IQuery<IEnumerable<EmployeeResponseDto>>
    {
    }
}
