using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Shared
{
    public class AuditableEntity : ISoftDelete
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string? ModifiedBy {  get; set; }
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }

    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        string? DeletedBy { get; set; }
        DateTime? DeletedAt { get; set; }

    }
}
