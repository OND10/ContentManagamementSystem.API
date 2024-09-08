using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Interfaces
{
    public interface IAboutRepository
    {
        Task<IEnumerable<About>> GetAllAsync(CancellationToken cancellationToken);
        Task<About> CreateAsync(About entity, CancellationToken cancellationToken);
        Task<About> UpdateAsync(About entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<About> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
