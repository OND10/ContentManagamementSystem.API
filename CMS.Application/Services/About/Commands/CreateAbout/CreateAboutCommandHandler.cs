using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Response;
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

namespace CMS.Application.Services.About.Commands.CreateAbout
{
    public class CreateAboutCommandHandler : ICommandHandler<CreateAboutCommand, AboutResponseDto>
    {
        private readonly IAboutRepository _repository;
        private readonly OnMapping _mapper;
        public CreateAboutCommandHandler(IAboutRepository repository, OnMapping mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<AboutResponseDto>> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var mappedModel = await _mapper.Map<CreateAboutCommand, CMS.Domain.Entities.About>(request);

            var result = await _repository.CreateAsync(mappedModel.Data, cancellationToken);

            //mapping model to response

            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.About, AboutResponseDto>(result);

            return await Result<AboutResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.CreateSuccess, true);
        }
    }
}
