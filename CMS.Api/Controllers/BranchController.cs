using CMS.Application.Common.Handling;
using CMS.Application.DTOs.BranchDtos.Request;
using CMS.Application.DTOs.BranchDtos.Response;
using CMS.Application.DTOs.EmployeeDtos.Request;
using CMS.Application.DTOs.EmployeeDtos.Response;
using CMS.Application.Services.Branch.Commands.CreateBranch;
using CMS.Application.Services.Branch.Queries.GetBranch;
using CMS.Application.Services.Employee.Commands.CreateEmployee;
using CMS.Application.Services.Employee.Queries.GetEmployee;
using CMS.Application.Services.Image.Interface;
using CMS.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IImageService _service;

        public BranchController(ISender sender, IImageService service)
        {
            _sender = sender;
            _service = service;
        }

        [HttpGet]
        public async Task<Result<IEnumerable<BranchResponseDto>>> Get(CancellationToken cancellationToken)
        {
            var query = new GetBranchQuery();

            var response = await _sender.Send(query, cancellationToken);
            if (response.IsSuccess)
            {
                return await Result<IEnumerable<BranchResponseDto>>.SuccessAsync(response.Data, ResponseStatus.Success, true);
            }

            return await Result<IEnumerable<BranchResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }


        [HttpPost]
        public async Task<Result<BranchResponseDto>> Post([FromForm] BranchRequestDto request, CancellationToken cancellationToken)
        {

            var command = new CreateBranchCommand();

            //Mapping the request to the command

            var imageUrl = await _service.UploadImage(request, request.file);

            var mappedCommand = await command.FromRequest(request);

            mappedCommand.ImageUrl = imageUrl.Data;

            var response = await _sender.Send(mappedCommand, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<BranchResponseDto>.SuccessAsync(response.Data, ResponseStatus.CreateSuccess, true);
            }

            return await Result<BranchResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }
    }
}
