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

namespace CMS.Application.Services.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryResponseDto>
    {
        private readonly ICategoryRepository _repository;
        private readonly OnMapping _mapper;
        public GetCategoryByIdQueryHandler(ICategoryRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<CategoryResponseDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id, cancellationToken);


            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.Category, CategoryResponseDto>(result);

            return await Result<CategoryResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
