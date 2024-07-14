using CMS.Application.Common.Handling;
using CMS.Application.DTOs.HomeDtos.Request;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.Services.Home.Commands.CreateHome;
using CMS.Application.Services.Home.Commands.DeleteHome;
using CMS.Application.Services.Home.Commands.UpdateHome;
using CMS.Application.Services.Home.Queries.GetHome;
using CMS.Application.Services.Home.Queries.GetHomeById;
using CMS.Application.Shared;
using CMS.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IImageService _service;
        public HomeController(ISender sender, IImageService service)
        {
            _sender = sender;
            _service = service;
        }

        [HttpGet]
        public async Task<Result<IEnumerable<HomeResponseDto>>> Get(CancellationToken cancellationToken)
        {
            var query = new GetHomeQuery();

            var response = await _sender.Send(query, cancellationToken);
           
            if (response.IsSuccess && response.Data.Count() >= 1)
            {
                return await Result<IEnumerable<HomeResponseDto>>.SuccessAsync(response.Data, ResponseStatus.Success, response.Length, true);
            }

            return await Result<IEnumerable<HomeResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpGet("{id}")]
        public async Task<Result<HomeResponseDto>> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetHomeByIdQuery
            {
                Id = id,
            };

            var response = await _sender.Send(query, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<HomeResponseDto>.SuccessAsync(response.Data, ResponseStatus.GetAllSuccess, true);
            }

            return await Result<HomeResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpPost]
        public async Task<Result<HomeResponseDto>> Post([FromForm] HomeRequestDto request, [FromForm] IFormFile file)
        {

            var command = new CreateHomeCommand();

            //Mapping the request to the command

            var imageUrl = await _service.UploadImage(request, file);

            var mappedCommand = await command.FromRequest(request);

            mappedCommand.ImageUrl = imageUrl.Data;

            var cancellationToken = new CancellationToken();
            var response = await _sender.Send(mappedCommand, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<HomeResponseDto>.SuccessAsync(response.Data, ResponseStatus.CreateSuccess, true);
            }

            return await Result<HomeResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]

        public async Task<Result<HomeResponseDto>> Put([FromRoute] int id, [FromForm] HomeRequestDto request, CancellationToken cancellationToken)
        {

            string? userName = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Name).FirstOrDefault()?.Value;

            string? imageUrl = null;
            string? logoUrl = null;
            if (request.image is not null && request.logo is not null)
            {
                var uploadImage = await _service.UploadImage(request, request.image);
                var uploadLogo = await _service.UploadImage(request, request.image);
                if (uploadImage.IsSuccess && uploadLogo.IsSuccess)
                {
                    imageUrl = uploadImage.Data;
                    logoUrl = uploadLogo.Data;
                }
                else
                {
                    return await Result<HomeResponseDto>.FaildAsync(false, ResponseStatus.Faild);
                }
            }


            var command = new UpdateHomeCommand();

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

                return await Result<HomeResponseDto>.SuccessAsync(response.Data, ResponseStatus.UpdateSuccess, true);
            }


            return await Result<HomeResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteHomeCommand
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
