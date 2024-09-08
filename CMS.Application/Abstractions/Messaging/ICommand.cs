using CMS.Application.Common.Handling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Abstractions.Messaging
{
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
