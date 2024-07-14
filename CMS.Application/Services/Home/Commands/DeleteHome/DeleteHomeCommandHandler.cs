using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.Services.About.Commands.DeleteAbout;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Home.Commands.DeleteHome
{
    public class DeleteHomeCommandHandler : ICommandHandler<DeleteHomeCommand, bool>
    {
        private readonly IHomeRepository _repository;
        private readonly OnMapping _mapper;
        public DeleteHomeCommandHandler(IHomeRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(DeleteHomeCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteAsync(request.Id, cancellationToken);

            return await Result<bool>.SuccessAsync(result, ResponseStatus.DeletedSuccess, true);
        }
    }
}
