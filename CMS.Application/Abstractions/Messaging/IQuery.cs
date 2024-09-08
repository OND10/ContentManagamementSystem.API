using CMS.Application.Common.Handling;
using MediatR;

namespace CMS.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
