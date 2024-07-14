﻿using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.ProductDtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IQuery<ProductResponseDto>
    {
        public int Id {  get; set; }
    }
}