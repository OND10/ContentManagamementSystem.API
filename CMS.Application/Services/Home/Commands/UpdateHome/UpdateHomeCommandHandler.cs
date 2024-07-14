using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
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

namespace CMS.Application.Services.Home.Commands.UpdateHome
{
    public class UpdateHomeCommandHandler : ICommandHandler<UpdateHomeCommand, HomeResponseDto>
    {
        private readonly IHomeRepository _repository;
        private readonly OnMapping _mapper;
        public UpdateHomeCommandHandler(IHomeRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<HomeResponseDto>> Handle(UpdateHomeCommand request, CancellationToken cancellationToken)
        {
            var mappedModel = await _mapper.Map<UpdateHomeCommand, CMS.Domain.Entities.Home>(request);

            var result = await _repository.UpdateAsync(mappedModel.Data, cancellationToken);

            //mapping model to response

            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.Home, HomeResponseDto>(result);

            return await Result<HomeResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.UpdateSuccess, true);
        }
    }
}
