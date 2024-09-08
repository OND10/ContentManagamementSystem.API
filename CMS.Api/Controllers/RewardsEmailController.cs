using CMS.Application.Common.Handling;
using CMS.Application.DTOs.RewardsEmailDtos.Request;
using CMS.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardsEmailController : ControllerBase
    {

        private readonly IRewardsEmailRepository _repository;
        public RewardsEmailController(IRewardsEmailRepository repository)
        {
            _repository = repository;
        }


        [HttpPost("validateEmail")]
        public async Task<Result<bool>>ValidateEmail(RewardsEmailRequestDto request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByTokenAsync(request.Token, cancellationToken);

            if (result != null && result.ExpiredAt > DateTime.UtcNow)
            {
                return await Result<bool>.SuccessAsync(true, "Token validated successfully", true);
            }

            return await Result<bool>.FaildAsync(false, "Token validation failed");
        }
    }
}
