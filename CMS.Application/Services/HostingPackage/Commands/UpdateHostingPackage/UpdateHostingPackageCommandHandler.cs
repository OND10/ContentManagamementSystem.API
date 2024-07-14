using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.HostingPackageDtos.Response;
using CMS.Application.Services.HostingPackage.Commands.CreateHostingPackage;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.HostingPackage.Commands.UpdateHostingPackage
{
    public class UpdateHostingPackageCommandHandler : ICommandHandler<UpdateHostingPackageCommand, HostingPackageResponseDto>
    {
        private readonly IHostingPackageRepository _repository;
        private readonly OnMapping _mapper;
        public UpdateHostingPackageCommandHandler(IHostingPackageRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<HostingPackageResponseDto>> Handle(UpdateHostingPackageCommand request, CancellationToken cancellationToken)
        {
            var model = await _mapper.Map<UpdateHostingPackageCommand, HostingPackages>(request);
            var result = await _repository.UpdateAsync(model.Data, cancellationToken);

            //Mapping the model result to the Response dto
            var mappedResult = await _mapper.Map<HostingPackages, HostingPackageResponseDto>(result);

            return await Result<HostingPackageResponseDto>.SuccessAsync(mappedResult.Data, "Package is Updated Successfully", true);
        }
    }
}
