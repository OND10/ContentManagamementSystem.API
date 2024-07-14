using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.ShoppingCartDtos.Request;
using CMS.Application.DTOs.ShoppingCartDtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Cart.Commands.CreateCart
{
    public class CreateCartCommand : ICommand<CartDto>
    {
        public CartResponseDto? CartResponse { get; set; }
        public IEnumerable<CartItemResponseDto>? CartItemResponse { get; set; }
    }
}
