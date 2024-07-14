using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Request;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.ContactDtos.Request;
using CMS.Application.DTOs.ContactDtos.Response;
using CMS.Application.Services.About.Commands.CreateAbout;
using CMS.Application.Services.About.Commands.DeleteAbout;
using CMS.Application.Services.About.Commands.UpdateAbout;
using CMS.Application.Services.About.Queries.GetAbout;
using CMS.Application.Services.About.Queries.GetAboutById;
using CMS.Application.Services.Contact.Commands.CreateContact;
using CMS.Application.Services.Contact.Commands.DeleteContact;
using CMS.Application.Services.Contact.Commands.UpdateContact;
using CMS.Application.Services.Contact.Queries.GetContact;
using CMS.Application.Services.Contact.Queries.GetContactById;
using CMS.Application.Shared;
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
    public class ContactController : ControllerBase
    {

        private readonly ISender _sender;
        private readonly IImageService _service;
        public ContactController(ISender sender, IImageService service)
        {
            _sender = sender;
            _service = service;
        }

        [HttpGet]
        public async Task<Result<IEnumerable<ContactResponseDto>>> Get(CancellationToken cancellationToken)
        {
            var query = new GetContactQuery();

            var response = await _sender.Send(query, cancellationToken);
            if (response.IsSuccess)
            {
                return await Result<IEnumerable<ContactResponseDto>>.SuccessAsync(response.Data, ResponseStatus.Success, true);
            }

            return await Result<IEnumerable<ContactResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpGet("{id}")]
        public async Task<Result<ContactResponseDto>> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetContactByIdQuery
            {
                Id = id,
            };

            var response = await _sender.Send(query, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<ContactResponseDto>.SuccessAsync(response.Data, ResponseStatus.GetAllSuccess, true);
            }

            return await Result<ContactResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpPost]
        public async Task<Result<ContactResponseDto>> Post([FromForm] ContactRequestDto request, [FromForm] IFormFile file)
        {

            var command = new CreateContactCommand();

            //Mapping the request to the command

            var imageUrl = await _service.UploadImage(request, file);

            var mappedCommand = await command.FromRequest(request);

            mappedCommand.ImageUrl = imageUrl.Data;

            var cancellationToken = new CancellationToken();
            var response = await _sender.Send(mappedCommand, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<ContactResponseDto>.SuccessAsync(response.Data, ResponseStatus.CreateSuccess, true);
            }

            return await Result<ContactResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]

        public async Task<Result<ContactResponseDto>> Put([FromRoute] int id, [FromForm] ContactRequestDto request, CancellationToken cancellationToken)
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
                    return await Result<ContactResponseDto>.FaildAsync(false, ResponseStatus.Faild);
                }
            }


            var command = new UpdateContactCommand();

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

                return await Result<ContactResponseDto>.SuccessAsync(response.Data, ResponseStatus.UpdateSuccess, true);
            }


            return await Result<ContactResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteContactCommand
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
