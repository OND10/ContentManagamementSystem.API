using CMS.Application.DTOs.ShoppingCartDtos.Request;
using CMS.Application.Services.Cart.Queries.GetCart;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infustracture.GraphQl.Carts
{
    public class Query
    {
        private readonly ISender _sender;
        public Query(ISender sender)
        {
            _sender = sender;
        }
        public async Task<IEnumerable<CartDto>> GetCarts(string userId)
        {
            var command = new GetCartQuery
            {
                userId = userId
            };
            var cancellationToken = new CancellationToken();
            var response = await _sender.Send(command, cancellationToken);
            return response.Data;
        }


    }
}
