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
        Task<IEnumerable<About>> GetAllAsync<R>(Expression<Func<About, R>> selector, CancellationToken cancellationToken);
        Task<IEnumerable<About>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<About>> FindAllAsync(Expression<Func<About, bool>> expression, CancellationToken cancellationToken);
        Task<About> FindAsync(Expression<Func<About, bool>> expression, CancellationToken cancellationToken);
        Task<IEnumerable<R>> FindAsync<R>(Expression<Func<About, R>> selector, Expression<Func<About, bool>> expression);
        Task<About> CreateAsync(About entity, CancellationToken cancellationToken);
        Task<About> UpdateAsync(About entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<About> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<About>> QueryAsync(string query, CancellationToken cancellationToken);
    }
}
