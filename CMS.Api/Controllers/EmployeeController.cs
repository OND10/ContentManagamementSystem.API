﻿using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Request;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.EmployeeDtos.Request;
using CMS.Application.DTOs.EmployeeDtos.Response;
using CMS.Application.Services.About.Commands.CreateAbout;
using CMS.Application.Services.About.Queries.GetAbout;
using CMS.Application.Services.Employee.Commands.CreateEmployee;
using CMS.Application.Services.Employee.Queries.GetEmployee;
using CMS.Application.Services.Image.Interface;
using CMS.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IImageService _service;

        public EmployeeController(ISender sender, IImageService service)
        {
            _sender = sender;
            _service = service;
        }

        [HttpGet]
        public async Task<Result<IEnumerable<EmployeeResponseDto>>> Get(CancellationToken cancellationToken)
        {
            var query = new GetEmployeeQuery();

            var response = await _sender.Send(query, cancellationToken);
            if (response.IsSuccess)
            {
                return await Result<IEnumerable<EmployeeResponseDto>>.SuccessAsync(response.Data, ResponseStatus.Success, true);
            }

            return await Result<IEnumerable<EmployeeResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }


        [HttpPost]
        public async Task<Result<EmployeeResponseDto>> Post([FromForm] EmployeeRequestDto request, CancellationToken cancellationToken)
        {

            var command = new CreateEmployeeCommand();

            //Mapping the request to the command

            var imageUrl = await _service.UploadImage(request, request.file);

            var mappedCommand = await command.FromRequest(request);

            mappedCommand.ImageUrl = imageUrl.Data;

            var response = await _sender.Send(mappedCommand, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<EmployeeResponseDto>.SuccessAsync(response.Data, ResponseStatus.CreateSuccess, true);
            }

            return await Result<EmployeeResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }


    }
}
