using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs.OrderDtos.Response
{
    public class OrderResponseDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public double Discount { get; set; }
        public double OrderTotal { get; set; }
        public string? EnglishName { get; set; }
        public string? ArabicName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime OrderTime { get; set; }
        public string? Status { get; set; }
        //This properties for payment mechanism
        public string? PaymentIntentId { get; set; }
        public string? StripeSessionId { get; set; }
        //One to may relationship between the orderheader and orderdetails
        public List<OrderItemResponseDto> OrderDetails { get; set; }
    }
}
