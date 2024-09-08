using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.HostingPackage.Commands.DeleteHostingPackage
{
    public class DeleteHostingPackageCommandHandler : ICommandHandler<DeleteHostingPackageCommand, bool>
    {
        private readonly IHostingPackageRepository _repository;
        private readonly OnMapping _mapper;

        public DeleteHostingPackageCommandHandler(IHostingPackageRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(DeleteHostingPackageCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteAsync(request.Id, cancellationToken);

            if (result is true)
            {
                return await Result<bool>.SuccessAsync(result, ResponseStatus.DeletedSuccess, true);
            }

            return await Result<bool>.FaildAsync(false, ResponseStatus.Faild);
        }
    }
}
