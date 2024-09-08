using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.GetEntityByLanguage
{
    public class GetEntityBasedOnLangQuery : IQuery<IEnumerable<object>>
    {
        public string tableName { get; set; }
    }


}
