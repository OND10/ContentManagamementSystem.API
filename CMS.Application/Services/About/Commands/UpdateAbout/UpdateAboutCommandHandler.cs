using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Response;
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

namespace CMS.Application.Services.About.Commands.UpdateAbout
{
    public class UpdateAboutCommandHandler : ICommandHandler<UpdateAboutCommand, AboutResponseDto>
    {
        private readonly IAboutRepository _repository;
        private readonly OnMapping _mapper;
        public UpdateAboutCommandHandler(IAboutRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<AboutResponseDto>> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var mappedModel = await _mapper.Map<UpdateAboutCommand, CMS.Domain.Entities.About>(request);

            var result = await _repository.UpdateAsync(mappedModel.Data, cancellationToken);

            //mapping model to response

            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.About, AboutResponseDto>(result);

            return await Result<AboutResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.UpdateSuccess, true);
        }
    }
}
