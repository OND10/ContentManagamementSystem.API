using CMS.Domain.Shared;

namespace CMS.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double Discount { get; set; }
        public double OrderTotal { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime OrderTime { get; set; }
        public string Status { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? StripeSessionId { get; set; }
        public List<OrderItems>? OrderItems { get; set; }
    }
}
