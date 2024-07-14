using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.ContactDtos.Response;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Contact.Commands.CreateContact
{
    public class CreateContactCommandHandler : ICommandHandler<CreateContactCommand, ContactResponseDto>
    {
        private readonly IContactRepository _repository;
        private readonly OnMapping _mapper;
        public CreateContactCommandHandler(IContactRepository repository, OnMapping mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<ContactResponseDto>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var mappedModel = await _mapper.Map<CreateContactCommand, CMS.Domain.Entities.Contact>(request);

            var result = await _repository.CreateAsync(mappedModel.Data, cancellationToken);

            //mapping model to response

            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.Contact, ContactResponseDto>(result);

            return await Result<ContactResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.CreateSuccess, true);
        }
    }
}
