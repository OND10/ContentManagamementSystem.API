using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.ShoppingCartDtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Cart.Queries.GetCart
{
    public class GetCartQuery : IQuery<IEnumerable<CartDto>>
    {
        public string userId {  get; set; }
    }
}
