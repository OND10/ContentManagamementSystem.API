using CMS.Application.Common.Handling;
using CMS.Application.DTOs.CountryDto.Request;
using CMS.Application.DTOs.CountryDto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Country.Interface
{
    public interface ICountryService
    {
        Task<Result<CountryResponseDto>> CreateAsync(CountryRequestDto request, CancellationToken cancellationToken);
        Task<Result<IEnumerable<CountryResponseDto>>> GetAllAsync(CancellationToken cancellationToken);
    }
}
