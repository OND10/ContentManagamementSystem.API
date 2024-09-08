using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.GetEntityByLanguage
{
    public class GetEntityBasedOnLangQueryHandler : IQueryHandler<GetEntityBasedOnLangQuery, IEnumerable<object>>
    {
        private readonly IGenericRepository _repository;

        public GetEntityBasedOnLangQueryHandler(IGenericRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<object>>> Handle(GetEntityBasedOnLangQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetEntitiesByTableAsync(request.tableName);
                return await Result<IEnumerable<object>>.SuccessAsync(result, ResponseStatus.GetAllSuccess, true);
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                return await Result<IEnumerable<object>>.FaildAsync(false, ex.Message);
            }
        }

    }
}
