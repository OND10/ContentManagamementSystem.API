using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.BranchDtos.Response;
using CMS.Application.DTOs.HomeDtos.Response;
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

namespace CMS.Application.Services.Branch.Commands.CreateBranch
{
    public class CreateBranchCommandHandler : ICommandHandler<CreateBranchCommand, BranchResponseDto>
    {
        private readonly IBranchRepository _repository;
        private readonly OnMapping _mapper;
        public CreateBranchCommandHandler(IBranchRepository repository, OnMapping mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<BranchResponseDto>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var mappedModel = await _mapper.Map<CreateBranchCommand, CMS.Domain.Entities.Branch>(request);

            var result = await _repository.CreateAsync(mappedModel.Data, cancellationToken);

            //mapping model to response

            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.Branch, BranchResponseDto>(result);

            return await Result<BranchResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.CreateSuccess, true);
        }
    }
}
