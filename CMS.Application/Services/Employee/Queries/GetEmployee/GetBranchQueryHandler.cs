using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.AboutDtos.Response;
using CMS.Application.DTOs.BranchDtos.Response;
using CMS.Application.DTOs.EmployeeDtos.Response;
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

namespace CMS.Application.Services.Employee.Queries.GetEmployee
{
    public class GetEmployeeQueryHandler : IQueryHandler<GetEmployeeQuery, IEnumerable<EmployeeResponseDto>>
    {
        private readonly IEmployeeRepository _repository;
        private readonly OnMapping _mapper;
        public GetEmployeeQueryHandler(IEmployeeRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<EmployeeResponseDto>>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);

            //mapping

            var mappedResponse = await _mapper.MapCollection<CMS.Domain.Entities.Employee, EmployeeResponseDto>(result);

            return await Result<IEnumerable<EmployeeResponseDto>>.SuccessAsync(mappedResponse.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
