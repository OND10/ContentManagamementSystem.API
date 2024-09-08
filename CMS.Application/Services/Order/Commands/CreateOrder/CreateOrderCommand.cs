using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.OrderDtos.Response;
using CMS.Application.DTOs.ShoppingCartDtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : ICommand<OrderResponseDto>
    {
        public CartDto cartDto { get; set; }
    }
}
