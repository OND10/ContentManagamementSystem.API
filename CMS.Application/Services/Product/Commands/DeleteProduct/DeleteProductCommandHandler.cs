using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _repository;
        private readonly OnMapping _mapper;
        public DeleteProductCommandHandler(IProductRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteAsync(request.Id, cancellationToken);

            return await Result<bool>.SuccessAsync(result, ResponseStatus.DeletedSuccess, true);
        }
    }
}
