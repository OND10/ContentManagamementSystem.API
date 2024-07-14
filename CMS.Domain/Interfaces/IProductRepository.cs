using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync<R>(Expression<Func<Product, R>> selector, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Product>> FindAllAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken);
        Task<Product> FindAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken);
        Task<IEnumerable<R>> FindAsync<R>(Expression<Func<Product, R>> selector, Expression<Func<Product, bool>> expression);
        Task<Product> CreateAsync(Product entity, CancellationToken cancellationToken);
        Task<Product> UpdateAsync(Product entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> QueryAsync(string query, CancellationToken cancellationToken);
    }
}
