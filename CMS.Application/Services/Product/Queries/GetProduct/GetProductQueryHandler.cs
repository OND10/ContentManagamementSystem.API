using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Product.Queries.GetProduct
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, IEnumerable<ProductResponseDto>>
    {
        private readonly IProductRepository _repository;
        private readonly OnMapping _mapper;
        public GetProductQueryHandler(IProductRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<ProductResponseDto>>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);

            //mapping

            var mappedResponse = await _mapper.MapCollection<CMS.Domain.Entities.Product, ProductResponseDto>(result);

            return await Result<IEnumerable<ProductResponseDto>>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
