using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
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

namespace CMS.Application.Services.Home.Commands.CreateHome
{
    public class CreateHomeCommandHandler : ICommandHandler<CreateHomeCommand, HomeResponseDto>
    {
        private readonly IHomeRepository _repository;
        private readonly OnMapping _mapper;
        public CreateHomeCommandHandler(IHomeRepository repository, OnMapping mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<HomeResponseDto>> Handle(CreateHomeCommand request, CancellationToken cancellationToken)
        {
            var mappedModel = await _mapper.Map<CreateHomeCommand, CMS.Domain.Entities.Home>(request);

            var result = await _repository.CreateAsync(mappedModel.Data, cancellationToken);

            //mapping model to response

            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.Home, HomeResponseDto>(result);

            return await Result<HomeResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.CreateSuccess, true);
        }
    }
}
