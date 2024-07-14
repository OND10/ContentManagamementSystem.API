using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.HostingPackageDtos.Response;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.HostingPackage.Queries.GetHostingPackageById
{
    public class GetHostingPackageByIdQueryHandler : IQueryHandler<GetHostingPackageByIdQuery, HostingPackageResponseDto>
    {
        private readonly IHostingPackageRepository _repository;
        private readonly OnMapping _mapper;
        public GetHostingPackageByIdQueryHandler(IHostingPackageRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<HostingPackageResponseDto>> Handle(GetHostingPackageByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if(result != null)
            {
                var mappedResult = await _mapper.Map<HostingPackages, HostingPackageResponseDto>(result);
                return await Result<HostingPackageResponseDto>.SuccessAsync(mappedResult.Data, ResponseStatus.Success, true);
            }

            return await Result<HostingPackageResponseDto>.FaildAsync(false, ResponseStatus.Faild);
        }
    }
}
