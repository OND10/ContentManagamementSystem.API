using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.HostingPackageDtos.Response;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.HostingPackage.Commands.HostingPackageReservation
{
    public class PackageReservationCommandHandler : ICommandHandler<PackageReservationCommand, PackageReservationResponseDto>
    {
        private readonly IHostingPackageRepository _repository;

        public PackageReservationCommandHandler(IHostingPackageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<PackageReservationResponseDto>> Handle(PackageReservationCommand request, CancellationToken cancellationToken)
        {
            var model = request.ToModel(request);

            var result = await _repository.ReservePackageAsync(model, cancellationToken);

            var response = new PackageReservationResponseDto();

            var mappedResponse = response.FromModel(result);

            return await Result<PackageReservationResponseDto>.SuccessAsync(mappedResponse, ResponseStatus.ReservationSuccess, true);

        }
    }
}
