using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Response;
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

namespace CMS.Application.Services.About.Queries.GetAbout
{
    public class GetAboutQueryHandler : IQueryHandler<GetAboutQuery, IEnumerable<AboutResponseDto>>
    {
        private readonly IAboutRepository _repository;
        private readonly OnMapping _mapper;
        public GetAboutQueryHandler(IAboutRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<AboutResponseDto>>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);

            //mapping

            var mappedResponse = await _mapper.MapCollection<CMS.Domain.Entities.About, AboutResponseDto>(result);

            return await Result<IEnumerable<AboutResponseDto>>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
