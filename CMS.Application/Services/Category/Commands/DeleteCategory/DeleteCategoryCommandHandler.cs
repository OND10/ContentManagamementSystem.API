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

namespace CMS.Application.Services.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _repository;
        private readonly OnMapping _mapper;
        public DeleteCategoryCommandHandler(ICategoryRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {

            var result = await _repository.DeleteAsync(request.Id, cancellationToken);

            return await Result<bool>.SuccessAsync(result, ResponseStatus.DeletedSuccess, true);
        }
    }
}
