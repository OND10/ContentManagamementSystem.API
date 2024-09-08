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

namespace CMS.Application.Services.Home.Queries.GetHomeById
{
    public class GetHomeByIdQueryHandler : IQueryHandler<GetHomeByIdQuery, HomeResponseDto>
    {
        private readonly IHomeRepository _repository;
        private readonly OnMapping _mapper;
        public GetHomeByIdQueryHandler(IHomeRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<HomeResponseDto>> Handle(GetHomeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id, cancellationToken);

            //mapping domain model to response Dto 

            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.Home, HomeResponseDto>(result);

            return await Result<HomeResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
