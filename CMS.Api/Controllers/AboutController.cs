using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Request;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.Services.About.Commands.CreateAbout;
using CMS.Application.Services.About.Commands.DeleteAbout;
using CMS.Application.Services.About.Commands.UpdateAbout;
using CMS.Application.Services.About.Queries.GetAbout;
using CMS.Application.Services.About.Queries.GetAboutById;
using CMS.Application.Services.Image.Interface;
using CMS.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IImageService _service;
        public AboutController(ISender sender, IImageService service)
        {
            _sender = sender;
            _service = service;
        }

        [HttpGet]
        public async Task<Result<IEnumerable<AboutResponseDto>>> Get(CancellationToken cancellationToken)
        {
            var query = new GetAboutQuery();

            var response = await _sender.Send(query, cancellationToken);
            if (response.IsSuccess)
            {
                return await Result<IEnumerable<AboutResponseDto>>.SuccessAsync(response.Data, ResponseStatus.Success, true);
            }

            return await Result<IEnumerable<AboutResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpGet("{id}")]
        public async Task<Result<AboutResponseDto>> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetAboutByIdQuery
            {
                Id = id,
            };

            var response = await _sender.Send(query, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<AboutResponseDto>.SuccessAsync(response.Data, ResponseStatus.GetAllSuccess, true);
            }

            return await Result<AboutResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpPost]
        public async Task<Result<AboutResponseDto>> Post([FromForm] AboutRequestDto request, CancellationToken cancellationToken)
        {

            var command = new CreateAboutCommand();

            //Mapping the request to the command

            var imageUrl = await _service.UploadImage(request, request.file);

            var mappedCommand = await command.FromRequest(request);

            mappedCommand.ImageUrl = imageUrl.Data;

            var response = await _sender.Send(mappedCommand, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<AboutResponseDto>.SuccessAsync(response.Data, ResponseStatus.CreateSuccess, true);
            }

            return await Result<AboutResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]

        public async Task<Result<AboutResponseDto>> Put([FromRoute] int id, [FromForm] AboutRequestDto request, CancellationToken cancellationToken)
        {

            string? userName = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Name).FirstOrDefault()?.Value;

            string? imageUrl = null;
            if (request.file is not null)
            {
                var uploadImage = await _service.UploadImage(request, request.file);
                if (uploadImage.IsSuccess)
                {
                    imageUrl = uploadImage.Data;
                }
                else
                {
                    return await Result<AboutResponseDto>.FaildAsync(false, ResponseStatus.Faild);
                }
            }


            var command = new UpdateAboutCommand();

            //Mapping request to command
            var mappedCommand = await command.FromRequest(request);

            if (imageUrl is not null && userName is not null)
            {

                //Assign ImageUrl from the file
                mappedCommand.ImageUrl = imageUrl;

                //Assign modifiedBy to user
                mappedCommand.ModifiedBy = userName;

                //Assign id to edit
                mappedCommand.Id = id;
            }


            var response = await _sender.Send(mappedCommand, cancellationToken);

            if (response.IsSuccess)
            {

                return await Result<AboutResponseDto>.SuccessAsync(response.Data, ResponseStatus.UpdateSuccess, true);
            }


            return await Result<AboutResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteAboutCommand
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


    }
}
