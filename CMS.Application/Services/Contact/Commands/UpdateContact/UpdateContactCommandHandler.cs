using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.ContactDtos.Response;
using CMS.Application.DTOs.HomeDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Application.Services.Product.Commands.CreateProduct;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Contact.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : ICommandHandler<UpdateContactCommand, ContactResponseDto>
    {
        private readonly IContactRepository _repository;
        private readonly OnMapping _mapper;
        public UpdateContactCommandHandler(IContactRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ContactResponseDto>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var mappedModel = await _mapper.Map<UpdateContactCommand, CMS.Domain.Entities.Contact>(request);

            var result = await _repository.UpdateAsync(mappedModel.Data, cancellationToken);

            //mapping model to response

            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.Contact, ContactResponseDto>(result);

            return await Result<ContactResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.UpdateSuccess, true);
        }
    }
}
