using CMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class OrderItems : AuditableEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order? OrderHeader { get; set; }
        public int HostingPackageId { get; set; }
        [NotMapped]
        public HostingPackages? HostingPackages { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public Product Product { get; set; }
        public int Count { get; set; }
        public string HostingPackageName { get; set; }
        public double? Price { get; set; }
        public string ProductName { get; set; }
        public double? ProductPrice { get; set; }
    }
}
