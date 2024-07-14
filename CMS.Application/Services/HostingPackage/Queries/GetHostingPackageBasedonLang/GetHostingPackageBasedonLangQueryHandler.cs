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

namespace CMS.Application.Services.HostingPackage.Queries.GetHostingPackageBasedonLang
{
    public class GetHostingPackageBasedonLangQueryHandler : IQueryHandler<GetHostingPackageBasedonLangQuery, IEnumerable<HostingPackageResponseDto>>
    {
        private readonly IHostingPackageRepository _repository;
        private readonly OnMapping _mapper;

        public GetHostingPackageBasedonLangQueryHandler(IHostingPackageRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<HostingPackageResponseDto>>> Handle(GetHostingPackageBasedonLangQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var hostingPackages = await _repository.GetHostingPackagesAsync(request.lang, cancellationToken);
                //Mapping model to response
                var mappedResponse = await _mapper.MapCollection<HostingPackages, HostingPackageResponseDto>(hostingPackages);

                return await Result<IEnumerable<HostingPackageResponseDto>>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
            }
            catch (Exception ex)
            {
                // Log exception
                return await Result<IEnumerable<HostingPackageResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
            }
        }
    }
}
