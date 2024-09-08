using CMS.Application.Common.Handling;
using MediatR;

namespace CMS.Application.Abstractions.Messaging
{
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>
    {
    }
}
