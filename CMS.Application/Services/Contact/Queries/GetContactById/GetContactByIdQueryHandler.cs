using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.ContactDtos.Response;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;

namespace CMS.Application.Services.Contact.Queries.GetContactById
{
    public class GetContactByIdQueryHandler : IQueryHandler<GetContactByIdQuery, ContactResponseDto>
    {
        private readonly IContactRepository _repository;
        private readonly OnMapping _mapper;
        public GetContactByIdQueryHandler(IContactRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<ContactResponseDto>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id, cancellationToken);

            //mapping domain model to response Dto 

            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.Contact, ContactResponseDto>(result);

            return await Result<ContactResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
