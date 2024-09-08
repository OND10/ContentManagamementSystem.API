using CMS.Application.DTOs.OrderDtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infustracture.Stripe.Dto.Response
{
    public class StripeResponseDto
    {
        public string? StripeSessionUrl { get; set; }
        public string? StripeSessionId { get; set; }
        public string? ApprovedUrl { get; set; }
        public string? CancelUrl { get; set; }
        public OrderResponseDto OrderHeader { get; set; }
    }
}
