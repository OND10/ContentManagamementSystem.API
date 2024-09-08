using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Home.Queries.GetHomeBasedonLang
{
    public class GetHomeBasedonLangQueryHandler : IQueryHandler<GetHomeBasedonLangQuery, IEnumerable<HomeResponseDto>>
    {
        private readonly IHomeRepository _repository;
        private readonly OnMapping _mapper;

        public GetHomeBasedonLangQueryHandler(IHomeRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<HomeResponseDto>>> Handle(GetHomeBasedonLangQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetHomeByLangAsync(request.lang, cancellationToken);

            var mappedResponse = await _mapper.MapCollection<CMS.Domain.Entities.Home, HomeResponseDto>(result);

            return await Result<IEnumerable<HomeResponseDto>>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
