using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Contact.Queries.GetContactsCount
{
    public class GetContactsCountQueryHandler : IQueryHandler<GetContactsCountQuery, int>
    {
        private readonly IContactRepository _repository;

        public GetContactsCountQueryHandler(IContactRepository repository)
        {
            _repository = repository;
        }


        public async Task<Result<int>> Handle(GetContactsCountQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetVisitorsCount(cancellationToken);

            return await Result<int>.SuccessAsync(result, ResponseStatus.GetAllSuccess, true);
        }
    }
}
