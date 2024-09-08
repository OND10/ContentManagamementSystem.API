using CMS.Domain.Shared;

namespace CMS.Domain.Entities
{
    public class Contact : AuditableEntity
    {
        public int Id { get; set; }
        public string EnglishTitle { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
    }
}
