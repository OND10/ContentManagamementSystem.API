using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.CategoryDtos.Response;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CategoryResponseDto>
    {
        private readonly ICategoryRepository _repository;
        private readonly OnMapping _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CategoryResponseDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            //mapping command to model
            var mappedModel = await _mapper.Map<CreateCategoryCommand, CMS.Domain.Entities.Category>(request);
            
            var result = await _repository.CreateAsync(mappedModel.Data, cancellationToken);

            //mapping the model to response
            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.Category, CategoryResponseDto>(result);

            return await Result<CategoryResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.CreateSuccess, true);
        }
    }
}
