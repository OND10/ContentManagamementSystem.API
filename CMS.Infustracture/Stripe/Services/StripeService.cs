using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using CMS.Infustracture.Stripe.Dto.Request;
using CMS.Infustracture.Stripe.Dto.Response;
using Stripe;
using Stripe.Checkout;
namespace CMS.Infustracture.Stripe.Services
{
    public class StripeService : IStripeService
    {
        private readonly IOrderRepository _repository;
        public StripeService(IOrderRepository repository)
        {
            _repository = repository;   
        }

        public async Task<Application.Common.Handling.Result<StripeResponseDto>> CreateSessionAsync(StripeRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var options = new SessionCreateOptions
                {
                    SuccessUrl = request.ApprovedUrl,
                    CancelUrl = request.CancelUrl,
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                };

                foreach (var item in request.OrderHeader.OrderDetails)
                {
                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(item.ProductPrice * 100),
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Product.EnglishName,
                            }
                        },
                        Quantity = item.Count
                    };
                    options.LineItems.Add(sessionLineItem);
                }

                var service = new SessionService();
                // Creating a new session
                Session session = service.Create(options);
                request.StripeSessionUrl = session.Url;
                Order orderHeader = await _repository.GetByIdAsync(request.OrderHeader.Id, cancellationToken);
                orderHeader.StripeSessionId = session.Id;
                

                var mappedResponse = new StripeResponseDto
                {
                    StripeSessionId = request.StripeSessionId,
                    StripeSessionUrl = request.StripeSessionUrl,
                    ApprovedUrl = request.ApprovedUrl,
                    CancelUrl = request.CancelUrl,
                    OrderHeader = request.OrderHeader
                };

                return await Application.Common.Handling.Result<StripeResponseDto>.SuccessAsync(mappedResponse, $"SessionId is {ResponseStatus.CreateSuccess}", true);
            }
            catch (Exception ex)
            {
                return await Application.Common.Handling.Result<StripeResponseDto>.FaildAsync(false, ex.Message);
            }

        }
    }
}
