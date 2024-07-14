using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Interfaces
{
    public interface ICategoryRepository
    {

        Task<IEnumerable<Category>> GetAllAsync<R>(Expression<Func<Category, R>> selector, CancellationToken cancellationToken);
        Task<IEnumerable<Category>> GetAllAsync( CancellationToken cancellationToken);
        Task<IEnumerable<Category>> FindAllAsync(Expression<Func<Category, bool>> expression, CancellationToken cancellationToken);
        Task<Category> FindAsync(Expression<Func<Category, bool>> expression, CancellationToken cancellationToken);
        Task<IEnumerable<R>> FindAsync<R>(Expression<Func<Category, R>> selector, Expression<Func<Category, bool>> expression);
        Task<Category> CreateAsync(Category entity, CancellationToken cancellationToken);
        Task<Category> UpdateAsync(Category entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Category>> QueryAsync(string query, CancellationToken cancellationToken);
    }
}
