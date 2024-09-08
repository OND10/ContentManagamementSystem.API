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

namespace CMS.Application.Services.HostingPackage.Queries.GetHostingPackage
{
    public class GetHostingPackageQueryHandler : IQueryHandler<GetHostingPackageQuery, IEnumerable<HostingPackageResponseDto>>
    {
        private readonly IHostingPackageRepository _repository;
        private readonly OnMapping _mapper;
        public GetHostingPackageQueryHandler(IHostingPackageRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<HostingPackageResponseDto>>> Handle(GetHostingPackageQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);

            if (result.Count() > 0)
            {
                var mappedResult = await _mapper.MapCollection<HostingPackages, HostingPackageResponseDto>(result);
                return await Result<IEnumerable<HostingPackageResponseDto>>.SuccessAsync(mappedResult.Data, ResponseStatus.Success, true);
            }

            return await Result<IEnumerable<HostingPackageResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }
    }
}
