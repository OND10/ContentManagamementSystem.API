using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductResponseDto>
    {
        private readonly IProductRepository _repository;
        private readonly OnMapping _mapper;
        public CreateProductCommandHandler(IProductRepository repository, OnMapping mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<ProductResponseDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var mappedModel = await _mapper.Map<CreateProductCommand, CMS.Domain.Entities.Product>(request);

            var result = await _repository.CreateAsync(mappedModel.Data, cancellationToken);

            //mapping model to response

            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.Product, ProductResponseDto>(result);

            return await Result<ProductResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.CreateSuccess, true);
        }
    }
}
