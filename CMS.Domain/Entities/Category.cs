using CMS.Domain.Shared;

namespace CMS.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }
        public string EnglishName { get; set; } = string.Empty;
        public string ArabicName { get; set; } = string.Empty;
        public string EnglishDescription { get; set; } = null!;
        public string ArabicDescription { get; set; } = null!;
    }
}
