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

namespace CMS.Application.Services.About.Commands.DeleteAbout
{
    public class DeleteAboutCommandHandler : ICommandHandler<DeleteAboutCommand, bool>
    {
        private readonly IAboutRepository _repository;
        private readonly OnMapping _mapper;
        public DeleteAboutCommandHandler(IAboutRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteAsync(request.Id, cancellationToken);

            return await Result<bool>.SuccessAsync(result, ResponseStatus.DeletedSuccess, true);
        }
    }
}
