using CMS.Application.Common.Handling;
using CMS.Application.DTOs.ContactDtos.Request;
using CMS.Application.DTOs.ContactDtos.Response;
using CMS.Application.DTOs.EmailDtos.Request;
using CMS.Application.DTOs.EmailDtos.Response;
using CMS.Application.DTOs.RewardsEmailDtos.Response;
using CMS.Application.Services.Contact.Commands.CreateContact;
using CMS.Application.Services.Contact.Commands.DeleteContact;
using CMS.Application.Services.Contact.Commands.UpdateContact;
using CMS.Application.Services.Contact.Queries.GetContact;
using CMS.Application.Services.Contact.Queries.GetContactById;
using CMS.Application.Services.Contact.Queries.GetContactsCount;
using CMS.Application.Services.Image.Interface;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using CMS.Infustracture.Email;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
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
        private readonly IEmailSender _emailSender;
        private readonly IRewardsEmailRepository _repository;
        public ContactController(ISender sender, IImageService service, IEmailSender emailSender, IRewardsEmailRepository repository)
        {
            _sender = sender;
            _service = service;
            _emailSender = emailSender;
            _repository = repository;
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

        [HttpPost("sendEmail")]
        public async Task<Result<EmailResponseDto>>EmailPosting(EmailRequestDto request)
        {
            var result = _emailSender.SendEmailAsync(request.Email, request.Subject, request.Description);

            var response = new EmailResponseDto
            {
                Description = request.Description,
                Subject = request.Subject,
            };

            if (result.Status == TaskStatus.Faulted)
            {
                return await Result<EmailResponseDto>.SuccessAsync(response, "Faild in sending form", false);
            }
            return await Result<EmailResponseDto>.SuccessAsync(response, ResponseStatus.PostSuccess, true);
        }


        [HttpPost("sendEmailValidate")]
        public async Task<Result<RewardsEmailResponseDto>> EmailRewardPosting(SendEmailRequestDto request, CancellationToken cancellationToken)
        {
            EmailSender emailSender = new EmailSender();
            var token = Guid.NewGuid().ToString();
            var result = emailSender.SendToEmailAsync(request.Email, "Validate your Email", $"Copy your validated token to Continue submitting form  : {token}");

            var rewardEmail = new RewardsEmail
            {
                Email = request.Email,
                Token = token,
                CreatedAt = DateTime.UtcNow,
                ExpiredAt = DateTime.UtcNow.AddMinutes(2),
            };

            var add = await _repository.CreateAsync(rewardEmail, cancellationToken);
            var response = new RewardsEmailResponseDto
            {
                Token = token
            };
            return await Result<RewardsEmailResponseDto>.SuccessAsync(response, "Email is varified Successfully", true);
        }

        [HttpGet("getVisitors")]
        public async Task<Result<int>> countVisitor(CancellationToken cancellationToken)
        {
            var query = new GetContactsCountQuery();

            var response = await _sender.Send(query, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<int>.SuccessAsync(response.Data, ResponseStatus.GetAllSuccess, true);
            }

            return await Result<int>.FaildAsync(false, ResponseStatus.Faild);
        }

    }
}
