using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.CategoryDtos.Response;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Category.Queries.GetCategory
{
    public class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, IEnumerable<CategoryResponseDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly OnMapping _mapper;
        public GetCategoryQueryHandler(ICategoryRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<CategoryResponseDto>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);

            var mappedResponse = await _mapper.MapCollection<CMS.Domain.Entities.Category, CategoryResponseDto>(result);

            return await Result<IEnumerable<CategoryResponseDto>>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
