using CMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

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
