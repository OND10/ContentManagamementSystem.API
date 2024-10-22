﻿using CMS.Application.Common.Handling;
using CMS.Application.DTOs.HostingPackageDtos.Request;
using CMS.Application.DTOs.HostingPackageDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Application.Services.HostingPackage.Commands.CreateHostingPackage;
using CMS.Application.Services.HostingPackage.Commands.DeleteHostingPackage;
using CMS.Application.Services.HostingPackage.Commands.UpdateHostingPackage;
using CMS.Application.Services.HostingPackage.Queries.GetHostingPackage;
using CMS.Application.Services.HostingPackage.Queries.GetHostingPackageBasedonLang;
using CMS.Application.Services.HostingPackage.Queries.GetHostingPackageById;
using CMS.Application.Shared;
using CMS.Domain.Entities;
using CMS.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostingPackageController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IImageService _service;
        public HostingPackageController(ISender sender, IImageService service)
        {
            _sender = sender;
            _service = service;
        }

        [HttpGet]
        public async Task<Result<IEnumerable<HostingPackageResponseDto>>> Get(CancellationToken cancellationToken)
        {
            var query = new GetHostingPackageQuery();
            var response = await _sender.Send(query, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<IEnumerable<HostingPackageResponseDto>>.SuccessAsync(response.Data, ResponseStatus.Success, true);
            }

            return await Result<IEnumerable<HostingPackageResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpGet("{id:int}")]
        public async Task<Result<HostingPackageResponseDto>> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetHostingPackageByIdQuery { Id = id };
            var response = await _sender.Send(query, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<HostingPackageResponseDto>.SuccessAsync(response.Data, ResponseStatus.GetAllSuccess, true);
            }

            return await Result<HostingPackageResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpGet("arabic")]
        public async Task<Result<IEnumerable<HostingPackageResponseDto>>> GetArabicHostingPackages(CancellationToken cancellationToken)
        {
            var query = new GetHostingPackageBasedonLangQuery { lang = "ar" };
            var response = await _sender.Send(query, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<IEnumerable<HostingPackageResponseDto>>.SuccessAsync(response.Data, ResponseStatus.GetAllSuccess, true);
            }

            return await Result<IEnumerable<HostingPackageResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpGet("english")]
        public async Task<Result<IEnumerable<HostingPackageResponseDto>>> GetEnglishHostingPackages(CancellationToken cancellationToken)
        {
            var query = new GetHostingPackageBasedonLangQuery { lang = "en" };
            var response = await _sender.Send(query, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<IEnumerable<HostingPackageResponseDto>>.SuccessAsync(response.Data, ResponseStatus.GetAllSuccess, true);
            }

            return await Result<IEnumerable<HostingPackageResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }
        [HttpPost]
        public async Task<Result<HostingPackageResponseDto>> Post([FromForm] HostingPackageRequestDto request, [FromForm] IFormFile file)
        {

            var command = new CreateHostingPackageCommand();

            //Mapping the request to the command

            var imageUrl = await _service.UploadImage(request, file);
            
            var mappedCommand = await command.FromRequest(request);
            
            mappedCommand.ImageUrl = imageUrl.Data;

            var cancellationToken = new CancellationToken();
            var response = await _sender.Send(mappedCommand, cancellationToken);
            
            if (response.IsSuccess)
            {
                return await Result<HostingPackageResponseDto>.SuccessAsync(response.Data, ResponseStatus.CreateSuccess, true);
            }

            return await Result<HostingPackageResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]

        public async Task<Result<HostingPackageResponseDto>> Put([FromRoute] int id, [FromForm] HostingPackageRequestDto request, CancellationToken cancellationToken)
        {

            string? userName = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Name).FirstOrDefault()?.Value;
            string? imageUrl = null;
            if (request.file is not null)
            {
                var uploadResult = await _service.UploadImage(request, request.file);
                if (uploadResult.IsSuccess)
                {
                    imageUrl = uploadResult.Data;
                }
                else
                {
                    return await Result<HostingPackageResponseDto>.FaildAsync(false, ResponseStatus.Faild);
                }
            }


            var command = new UpdateHostingPackageCommand();

            //Mapping request to command
            var mappedCommand = await command.FromRequest(request);


            if (imageUrl is not null && userName is not null)
            {

                //Assign ImageUrl from the file
                mappedCommand.ImageUrl = imageUrl;

                //Assign modifiedBy to user
                mappedCommand.ModifiedBy = userName;

                //Assign id to edit the specific record using Id
                mappedCommand.Id = id;
            }

            var response = await _sender.Send(mappedCommand, cancellationToken);

            if (response.IsSuccess)
            {

                return await Result<HostingPackageResponseDto>.SuccessAsync(response.Data, ResponseStatus.UpdateSuccess, true);
            }


            return await Result<HostingPackageResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteHostingPackageCommand
            {
                Id = id
            };

            var response = await _sender.Send(command, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<bool>.SuccessAsync(response.Data, ResponseStatus.DeletedSuccess, true);
            }
            return await Result<bool>.FaildAsync(false, ResponseStatus.Faild);

        }

        //[HttpPost("createImage")]
        //public async Task<Result<string>> Post(HostingPackageRequestDto request, IFormFile file)
        //{
        //    var response = await _service.UploadImage(model, file);

        //    if (response.IsSuccess)
        //    {
        //        return await Result<string>.SuccessAsync(response.Data, ResponseStatus.UploadedSuccess, true);
        //    }

        //    return await Result<string>.FaildAsync(false, ResponseStatus.Faild);
        //}
    }
}
