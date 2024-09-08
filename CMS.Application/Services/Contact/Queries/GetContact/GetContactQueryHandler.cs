using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.ContactDtos.Response;
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

namespace CMS.Application.Services.Contact.Queries.GetContact
{
    public class GetContactQueryHandler : IQueryHandler<GetContactQuery, IEnumerable<ContactResponseDto>>
    {
        private readonly IContactRepository _repository;
        private readonly OnMapping _mapper;
        public GetContactQueryHandler(IContactRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<ContactResponseDto>>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);

            //mapping

            var mappedResponse = await _mapper.MapCollection<CMS.Domain.Entities.Contact, ContactResponseDto>(result);

            return await Result<IEnumerable<ContactResponseDto>>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
