using CMS.Domain.Shared;

namespace CMS.Domain.Entities
{
    public class Home : AuditableEntity
    {
        public int Id { get; set; }
        public string EnglishTitle { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public string LogoUrl {  get; set; }
        public string ImageUrl {  get; set; }
    }
}
