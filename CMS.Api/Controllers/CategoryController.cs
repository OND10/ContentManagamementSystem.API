using CMS.Application.Common.Handling;
using CMS.Application.DTOs.CategoryDtos.Request;
using CMS.Application.DTOs.CategoryDtos.Response;
using CMS.Application.DTOs.HomeDtos.Request;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.Services.Category.Commands.CreateCategory;
using CMS.Application.Services.Category.Commands.UpdateCategory;
using CMS.Application.Services.Category.Queries.GetCategory;
using CMS.Application.Services.Category.Queries.GetCategoryById;
using CMS.Application.Services.Home.Commands.CreateHome;
using CMS.Application.Services.Home.Commands.DeleteHome;
using CMS.Application.Services.Home.Commands.UpdateHome;
using CMS.Application.Services.Home.Queries.GetHome;
using CMS.Application.Services.Home.Queries.GetHomeById;
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
    public class CategoryController : ControllerBase
    {
        private readonly ISender _sender;
        public CategoryController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<Result<IEnumerable<CategoryResponseDto>>> Get(CancellationToken cancellationToken)
        {
            var query = new GetCategoryQuery();

            var response = await _sender.Send(query, cancellationToken);

            if (response.IsSuccess && response.Data.Count() >= 1)
            {
                return await Result<IEnumerable<CategoryResponseDto>>.SuccessAsync(response.Data, ResponseStatus.Success, response.Length, true);
            }

            return await Result<IEnumerable<CategoryResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpGet("{id}")]
        public async Task<Result<CategoryResponseDto>> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetCategoryByIdQuery
            {
                Id = id,
            };

            var response = await _sender.Send(query, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<CategoryResponseDto>.SuccessAsync(response.Data, ResponseStatus.GetAllSuccess, true);
            }

            return await Result<CategoryResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpPost]
        public async Task<Result<CategoryResponseDto>> Post([FromForm] CategoryRequestDto request, CancellationToken cancellationToken)
        {

            var command = new CreateCategoryCommand();

            //Mapping the request to the command

            
            var mappedCommand = await command.FromRequest(request);

            var response = await _sender.Send(mappedCommand, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<CategoryResponseDto>.SuccessAsync(response.Data, ResponseStatus.CreateSuccess, true);
            }

            return await Result<CategoryResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]

        public async Task<Result<CategoryResponseDto>> Put([FromRoute] int id, [FromForm] CategoryRequestDto request, CancellationToken cancellationToken)
        {

            string? userName = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Name).FirstOrDefault()?.Value;

            var command = new UpdateCategoryCommand();

            //Mapping request to command
            var mappedCommand = await command.FromRequest(request);

            if (userName is not null)
            {

                //Assign modifiedBy to user
                mappedCommand.ModifiedBy = userName;

                //Assign id to edit
                mappedCommand.Id = id;
            }


            var response = await _sender.Send(mappedCommand, cancellationToken);

            if (response.IsSuccess)
            {

                return await Result<CategoryResponseDto>.SuccessAsync(response.Data, ResponseStatus.UpdateSuccess, true);
            }


            return await Result<CategoryResponseDto>.FaildAsync(false, ResponseStatus.Faild);
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
