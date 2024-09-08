namespace CMS.Domain.Entities
{
    public class RewardsEmail
    {
        public int Id {  get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt {  get; set; }
        public DateTime ExpiredAt { get; set;}
    }
}
