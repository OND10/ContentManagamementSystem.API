using CMS.Application.Common.Handling;
using CMS.Application.DTOs.OrderDtos.Response;
using CMS.Application.DTOs.ShoppingCartDtos.Request;
using CMS.Application.Services.Order.Commands.CreateOrder;
using CMS.Domain.Shared;
using CMS.Infustracture.Stripe.Dto.Request;
using CMS.Infustracture.Stripe.Dto.Response;
using CMS.Infustracture.Stripe.Services;
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
        private readonly IStripeService _service;
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

        [HttpPost("CreateStripeSession")]
        public async Task<Result<StripeResponseDto>> CreateStripeSession([FromBody] StripeRequestDto request, CancellationToken cancellationToken)
        {
            var response = await  _service.CreateSessionAsync(request, cancellationToken);

            if(response.IsSuccess)
            {
                return await Result<StripeResponseDto>.SuccessAsync(response.Data, $"SessionId is {ResponseStatus.CreateSuccess}", true);
            }

            return await Result<StripeResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }
    }
}
