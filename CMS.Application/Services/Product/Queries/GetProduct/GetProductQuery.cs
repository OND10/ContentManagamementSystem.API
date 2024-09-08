using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.ProductDtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Product.Queries.GetProduct
{
    public class GetProductQuery : IQuery<IEnumerable<ProductResponseDto>>
    {
    }
}
