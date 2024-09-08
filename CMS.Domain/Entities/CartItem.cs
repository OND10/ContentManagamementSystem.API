using CMS.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Domain.Entities
{
    public class CartItem : AuditableEntity
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart CartHeader { get; set; }
        public int HostingPackageId { get; set; }
        [NotMapped]
        public HostingPackages HostingPackages { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
