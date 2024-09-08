using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.AboutDtos.Request;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.BranchDtos.Request;
using CMS.Application.DTOs.BranchDtos.Response;
using CMS.Application.DTOs.HomeDtos.Request;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Application.Services.Home.Commands.CreateHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Branch.Commands.CreateBranch
{
    public class CreateBranchCommand : ICommand<BranchResponseDto>
    {
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }

        public async Task<CreateBranchCommand> FromRequest(BranchRequestDto request)
        {
            return await Task.FromResult<CreateBranchCommand>(new CreateBranchCommand
            {
                Location = request.Location,
                PhoneNumber = request.PhoneNumber,
                Fax = request.Fax,
                Email = request.Email,
                ImageUrl = request.ImageUrl,
                
            });
        }
    }
}
