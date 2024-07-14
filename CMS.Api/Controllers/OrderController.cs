using CMS.Application.Common.Handling;
using CMS.Application.DTOs.OrderDtos.Response;
using CMS.Application.DTOs.ShoppingCartDtos.Request;
using CMS.Application.Services.Order.Commands.CreateOrder;
using CMS.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISender _sender;
        public OrderController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("CreateOrder")]
        public async Task<Result<OrderResponseDto>> Post(CartDto cartDto, CancellationToken cancellationToken)
        {
            var command = new CreateOrderCommand
            {
                cartDto = cartDto
            };

            var response = await _sender.Send(command, cancellationToken);
            if (response.IsSuccess)
            {
                return await Result<OrderResponseDto>.SuccessAsync(response.Data, ResponseStatus.CreateSuccess, true);
            }

            return await Result<OrderResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }
    }
}
