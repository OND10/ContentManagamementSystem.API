using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Cart.Commands.DeleteCart
{
    public class DeleteCartCommandHandler : ICommandHandler<DeleteCartCommand, bool>
    {
        private readonly ICartRepository _repository;
        public DeleteCartCommandHandler(ICartRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<bool>> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cartItem = await _repository.GetCartItemByCartIdAsync(request.Id, cancellationToken);
            int totalofCartItem = await _repository.GetCartItemCountByCartHeaderIdAsync(request.Id, cancellationToken);
            var cartItemResult = await _repository.DeleteCartItemAsync(cartItem.Id, cancellationToken);
            if (totalofCartItem == 1)
            {
                var result = await _repository.DeleteAsync(cartItem.CartHeader.Id, cancellationToken);

                return await Result<bool>.SuccessAsync(true, ResponseStatus.DeletedSuccess, true);
            }


            return await Result<bool>.FaildAsync(false, ResponseStatus.Faild);
        }
    }
}
