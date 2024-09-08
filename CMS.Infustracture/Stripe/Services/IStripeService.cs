using CMS.Application.Common.Handling;
using CMS.Infustracture.Stripe.Dto.Request;
using CMS.Infustracture.Stripe.Dto.Response;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infustracture.Stripe.Services
{
    public interface IStripeService
    {
        Task<Application.Common.Handling.Result<StripeResponseDto>> CreateSessionAsync(StripeRequestDto request, CancellationToken cancellationToken);
    }
}
