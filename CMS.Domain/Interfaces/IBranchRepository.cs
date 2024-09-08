using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Interfaces
{
    public interface IBranchRepository
    {
        Task<IEnumerable<Branch>> GetAllAsync(CancellationToken cancellationToken);
        Task<Branch> CreateAsync(Branch entity, CancellationToken cancellationToken);
        Task<Branch> UpdateAsync(Branch entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<Branch> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
