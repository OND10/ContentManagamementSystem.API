using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.EmployeeDtos.Response;
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

namespace CMS.Application.Services.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, EmployeeResponseDto>
    {
        private readonly IEmployeeRepository _repository;
        private readonly OnMapping _mapper;
        public CreateEmployeeCommandHandler(IEmployeeRepository repository, OnMapping mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<EmployeeResponseDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var mappedModel = await _mapper.Map<CreateEmployeeCommand, CMS.Domain.Entities.Employee>(request);

            var result = await _repository.CreateAsync(mappedModel.Data, cancellationToken);

            //mapping model to response

            var mappedResponse = await _mapper.Map<CMS.Domain.Entities.Employee, EmployeeResponseDto>(result);

            return await Result<EmployeeResponseDto>.SuccessAsync(mappedResponse.Data, ResponseStatus.CreateSuccess, true);
        }
    }
}
