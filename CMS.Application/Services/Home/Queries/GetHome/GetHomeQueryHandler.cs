using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Home.Queries.GetHome
{
    public class GetHomeQueryHandler : IQueryHandler<GetHomeQuery, IEnumerable<HomeResponseDto>>
    {
        private readonly IHomeRepository _repository;
        private readonly OnMapping _mapper;
        public GetHomeQueryHandler(IHomeRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<HomeResponseDto>>> Handle(GetHomeQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);

            //mapping

            var mappedResponse = await _mapper.MapCollection<CMS.Domain.Entities.Home, HomeResponseDto>(result);

            return await Result<IEnumerable<HomeResponseDto>>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
