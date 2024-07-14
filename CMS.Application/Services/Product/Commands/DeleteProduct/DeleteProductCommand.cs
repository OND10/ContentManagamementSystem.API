﻿using CMS.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : ICommand<bool>
    {
        public int Id {  get; set; }
    }
}
