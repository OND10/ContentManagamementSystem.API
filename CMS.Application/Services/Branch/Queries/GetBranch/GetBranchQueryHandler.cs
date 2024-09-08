using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.BranchDtos.Response;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Branch.Queries.GetBranch
{
    public class GetBranchQueryHandler : IQueryHandler<GetBranchQuery, IEnumerable<BranchResponseDto>>
    {
        private readonly IBranchRepository _repository;
        private readonly OnMapping _mapper;
        public GetBranchQueryHandler(IBranchRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<BranchResponseDto>>> Handle(GetBranchQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);

            //mapping

            var mappedResponse = await _mapper.MapCollection<CMS.Domain.Entities.Branch, BranchResponseDto>(result);

            return await Result<IEnumerable<BranchResponseDto>>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
