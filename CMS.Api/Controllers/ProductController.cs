using CMS.Application.Common.Handling;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.DTOs.ProductDtos.Request;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Application.Services.GetEntityByLanguage;
using CMS.Application.Services.Home.Queries.GetHomeBasedonLang;
using CMS.Application.Services.Image.Interface;
using CMS.Application.Services.Product.Commands.CreateProduct;
using CMS.Application.Services.Product.Commands.DeleteProduct;
using CMS.Application.Services.Product.Commands.UpdateProduct;
using CMS.Application.Services.Product.Queries.GetProduct;
using CMS.Application.Services.Product.Queries.GetProductBasedonLang;
using CMS.Application.Services.Product.Queries.GetProductById;
using CMS.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IImageService _service;
        public ProductController(ISender sender, IImageService service)
        {
            _sender = sender;
            _service = service;
        }

        [HttpGet]
        public async Task<Result<IEnumerable<ProductResponseDto>>> Get(CancellationToken cancellationToken)
        {
            var query = new GetProductQuery();

            var response = await _sender.Send(query, cancellationToken);
            if (response.IsSuccess)
            {
                return await Result<IEnumerable<ProductResponseDto>>.SuccessAsync(response.Data, ResponseStatus.Success, true);
            }

            return await Result<IEnumerable<ProductResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpGet("{id}")]
        public async Task<Result<ProductResponseDto>> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery
            {
                Id = id,
            };

            var response = await _sender.Send(query, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<ProductResponseDto>.SuccessAsync(response.Data, ResponseStatus.GetAllSuccess, true);
            }

            return await Result<ProductResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpPost]
        public async Task<Result<ProductResponseDto>> Post([FromForm] ProductRequestDto request, CancellationToken cancellationToken)
        {

            var command = new CreateProductCommand();

            //Mapping the request to the command

            var imageUrl = await _service.UploadImage(request, request.file);

            var mappedCommand = await command.FromRequest(request);

            mappedCommand.ImageUrl = imageUrl.Data;

            var response = await _sender.Send(mappedCommand, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<ProductResponseDto>.SuccessAsync(response.Data, ResponseStatus.CreateSuccess, true);
            }

            return await Result<ProductResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]

        public async Task<Result<ProductResponseDto>> Put([FromRoute] int id, [FromForm] ProductRequestDto request, CancellationToken cancellationToken)
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
                    return await Result<ProductResponseDto>.FaildAsync(false, ResponseStatus.Faild);
                }
            }


            var command = new UpdateProductCommand();

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

                return await Result<ProductResponseDto>.SuccessAsync(response.Data, ResponseStatus.UpdateSuccess, true);
            }


            return await Result<ProductResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteProductCommand
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


        [HttpGet("arabic")]
        public async Task<Result<IEnumerable<ProductResponseDto>>> GetArabicHostingPackages(CancellationToken cancellationToken)
        {
            var query = new GetProductBasedonLangQuery { lang = "ar" };
            var response = await _sender.Send(query, cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<IEnumerable<ProductResponseDto>>.SuccessAsync(response.Data, ResponseStatus.GetAllSuccess, true);
            }

            return await Result<IEnumerable<ProductResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpGet("english")]
        public async Task<Result<IEnumerable<ProductResponseDto>>> GetEnglishEntities(CancellationToken cancellationToken)
        {
            var query = new GetEntityBasedOnLangQuery
            {
                tableName = "Product"
            };

            var response = await _sender.Send(query, cancellationToken);

            if (response.IsSuccess)
            {
                var filteredResponse = FilterForEnglish(response.Data);
                return await Result<IEnumerable<ProductResponseDto>>.SuccessAsync(filteredResponse, ResponseStatus.GetAllSuccess, true);
            }

            return await Result<IEnumerable<ProductResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }

        private IEnumerable<ProductResponseDto> FilterForEnglish(IEnumerable<dynamic> data)
        {
            // Assuming data is of type dynamic since the function fetches records from any table
            var dtoResponseList = new List<ProductResponseDto>();

            foreach (var item in data)
            {
                // Check for properties in a dynamic way and map them to DTO
                var dtoResponse = new ProductResponseDto
                {
                    EnglishName = item.EnglishName,
                    EnglishDescription = item.EnglishDescription,
                    EnCategory = item.EnCategory,
                    Count = item.Count,
                    Id = item.Id,
                    ImageUrl = item.ImageUrl,
                    Price = item.Price,
                };

                dtoResponseList.Add(dtoResponse);
            }

            return dtoResponseList;
        }
    }
}
