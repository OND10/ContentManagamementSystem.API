using CMS.Application.Common.Handling;
using CMS.Application.DTOs.CountryDto.Request;
using CMS.Application.DTOs.CountryDto.Response;
using CMS.Application.Services.Country.Implementation;
using CMS.Application.Services.Country.Interface;
using CMS.Domain.Entities;
using CMS.Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _service;

        public CountryController(ICountryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<Result<IEnumerable<CountryResponseDto>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = await _service.GetAllAsync(cancellationToken);

            if (response.IsSuccess)
            {
                return await Result<IEnumerable<CountryResponseDto>>.SuccessAsync(response.Data, ResponseStatus.GetAllSuccess, true);
            }

            return await Result<IEnumerable<CountryResponseDto>>.FaildAsync(false, ResponseStatus.Faild);
        }


        [HttpPost]
        public async Task<Result<CountryResponseDto>> Post([FromBody] CountryRequestDto request, CancellationToken cancellationToken)
        {
            var result = await _service.CreateAsync(request, cancellationToken);

            return await Result<CountryResponseDto>.SuccessAsync(result.Data, ResponseStatus.CreateSuccess, true);
        }
    }
}
