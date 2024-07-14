using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Application.Services.Product.Commands.CreateProduct;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, ProductResponseDto>
    {
        private readonly IProductRepository _repository;
        private readonly OnMapping _mapper;
        public UpdateProductCommandHandler(IProductRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ProductResponseDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var mappedModel = await _mapper.Map<UpdateProductCommand, CMS.Domain.Entities.Product>(request);

            var result = await _repository.UpdateAsync(mappedModel.Data, cancellationToken);

            //mapping model to response

            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.Product, ProductResponseDto>(result);

            return await Result<ProductResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.UpdateSuccess, true);
        }
    }
}
