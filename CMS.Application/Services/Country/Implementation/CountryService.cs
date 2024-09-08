using CMS.Application.Common.Handling;
using CMS.Application.DTOs.CountryDto.Request;
using CMS.Application.DTOs.CountryDto.Response;
using CMS.Application.Services.Country.Interface;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Country.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repository;
        private readonly OnMapping _mapper;
        public CountryService(ICountryRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CountryResponseDto>> CreateAsync(CountryRequestDto request, CancellationToken cancellationToken)
        {
            var model = new Domain.Entities.Country
            {
                Name = request.Name,
                Code = request.Code,
            };

            var result = await _repository.CreateAsync(model, cancellationToken);

            var response = new CountryResponseDto
            {
                Code = result.Code,
                Name = result.Name,
            };

            return await Result<CountryResponseDto>.SuccessAsync(response, ResponseStatus.CreateSuccess, true);
        }

        public async Task<Result<IEnumerable<CountryResponseDto>>> GetAllAsync(CancellationToken cancellationToken)
        {
             var result = await _repository.GetAllAsync(cancellationToken);

            var response = await _mapper.MapCollection<Domain.Entities.Country, CountryResponseDto>(result);

            return await Result<IEnumerable<CountryResponseDto>>.SuccessAsync(response.Data, ResponseStatus.GetAllSuccess, true);
        }
    }
}
