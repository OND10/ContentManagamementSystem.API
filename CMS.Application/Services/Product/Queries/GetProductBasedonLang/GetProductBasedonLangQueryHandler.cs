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

namespace CMS.Application.Services.Product.Queries.GetProductBasedonLang
{
    public class GetProductBasedonLangQueryHandler : IQueryHandler<GetProductBasedonLangQuery, IEnumerable<ProductResponseDto>>
    {
        private readonly IProductRepository _repository;
        private readonly OnMapping _mapper;
        public GetProductBasedonLangQueryHandler(IProductRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<ProductResponseDto>>> Handle(GetProductBasedonLangQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetProductByLangAsync(request.lang, cancellationToken);

            var mappedResponse = await _mapper.MapCollection<CMS.Domain.Entities.Product, ProductResponseDto>(result);

            return await Result<IEnumerable<ProductResponseDto>>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
