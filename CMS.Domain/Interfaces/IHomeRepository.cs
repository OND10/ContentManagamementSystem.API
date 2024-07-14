using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Interfaces
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Home>> GetAllAsync<R>(Expression<Func<Home, R>> selector, CancellationToken cancellationToken);
        Task<IEnumerable<Home>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Home>> FindAllAsync(Expression<Func<Home, bool>> expression, CancellationToken cancellationToken);
        Task<Home> FindAsync(Expression<Func<Home, bool>> expression, CancellationToken cancellationToken);
        Task<IEnumerable<R>> FindAsync<R>(Expression<Func<Home, R>> selector, Expression<Func<Home, bool>> expression);
        Task<Home> CreateAsync(Home entity, CancellationToken cancellationToken);
        Task<Home> UpdateAsync(Home entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<Home> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Home>> QueryAsync(string query, CancellationToken cancellationToken);
    }
}
