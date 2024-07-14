using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.CategoryDtos.Response;
using CMS.Application.Services.Category.Commands.CreateCategory;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, CategoryResponseDto>
    {
        private readonly ICategoryRepository _repository;
        private readonly OnMapping _mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<CategoryResponseDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            //mapping command to model
            var mappedModel = await _mapper.Map<UpdateCategoryCommand, CMS.Domain.Entities.Category>(request);

            var result = await _repository.UpdateAsync(mappedModel.Data, cancellationToken);

            //mapping the model to response
            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.Category, CategoryResponseDto>(result);

            return await Result<CategoryResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.UpdateSuccess, true);
        }
    }
}
