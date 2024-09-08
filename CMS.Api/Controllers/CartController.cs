using CMS.Application.Common.Handling;
using CMS.Application.DTOs.ShoppingCartDtos.Request;
using CMS.Application.Services.Cart.Commands.CreateCart;
using CMS.Application.Services.Cart.Commands.DeleteCart;
using CMS.Application.Services.Cart.Queries.GetCart;
using CMS.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ISender _sender;
        public CartController(ISender sender)
        {
            _sender = sender;
        }


        [HttpGet("{userId}")]
        public async Task<Result<IEnumerable<CartDto>>> Get(string userId, CancellationToken cancellationToken)
        {
            var query = new GetCartQuery
            {
                userId = userId
            };

            var result = await _sender.Send(query, cancellationToken);
            if (result != null && result.IsSuccess)
            {
                return await Result<IEnumerable<CartDto>>.SuccessAsync(result.Data, ResponseStatus.CreateSuccess, true);
            }

            return await Result<IEnumerable<CartDto>>.FaildAsync(false, ResponseStatus.Faild);
        }


        [HttpPost("createCart")]
        public async Task<Result<CartDto>> Post(CartDto cartDto, CancellationToken cancellationToken)
        {
            var command = new CreateCartCommand()
            {
                CartResponse = cartDto.CartResponse,
                CartItemResponse = cartDto.CartItemResponse,
            };

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return await Result<CartDto>.SuccessAsync(result.Data, ResponseStatus.CreateSuccess, true);
            }

            return await Result<CartDto>.FaildAsync(false, ResponseStatus.Faild);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<Result<bool>> Delete([FromRoute] int cartDetailsId, CancellationToken cancellationToken)
        {
            var command = new DeleteCartCommand()
            {
                Id = cartDetailsId
            };

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return await Result<bool>.SuccessAsync(true, "Deleted Successfuly", true);
            }

            return await Result<bool>.FaildAsync(false, "Not Deleted");
        }
    }
}
