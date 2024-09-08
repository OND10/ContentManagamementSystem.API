using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;

namespace CMS.Application.Services.About.Queries.GetAboutById
{
    public class GetAboutByIdQueryHandler : IQueryHandler<GetAboutByIdQuery, AboutResponseDto>
    {
        private readonly IAboutRepository _repository;
        private readonly OnMapping _mapper;
        public GetAboutByIdQueryHandler(IAboutRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<AboutResponseDto>> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id, cancellationToken);

            //mapping domain model to response Dto 

            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.About, AboutResponseDto>(result);

            return await Result<AboutResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
