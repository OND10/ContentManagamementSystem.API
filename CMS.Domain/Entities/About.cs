using CMS.Domain.Shared;

namespace CMS.Domain.Entities
{
    public class About : AuditableEntity
    {
        public int Id { get; set; }
        public string EnglishTitle { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public string ImageUrl { get; set; }
        public int CustomersCount {  get; set; }
        public int CitiesCount {  get; set; }
        public string ArMotivationletter {  get; set; }
        public string EnMotivationletter {  get; set; }

    }
}
