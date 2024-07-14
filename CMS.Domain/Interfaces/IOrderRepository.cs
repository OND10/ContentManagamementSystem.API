using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Interfaces
{
    public interface IOrderRepository
    {

        Task<IEnumerable<Order>> GetAllAsync<R>(Expression<Func<Order, R>> selector, CancellationToken cancellationToken);
        Task<IEnumerable<Order>> FindAllAsync(Expression<Func<Order, bool>> expression, CancellationToken cancellationToken);
        Task<Order> FindAsync(Expression<Func<Order, bool>> expression, CancellationToken cancellationToken);
        Task<IEnumerable<R>> FindAsync<R>(Expression<Func<Order, R>> selector, Expression<Func<Order, bool>> expression);
        Task<Order> CreateAsync(Order entity, CancellationToken cancellationToken);
        Task<Order> UpdateAsync(Order entity, CancellationToken cancellationToken);
        Task<Order> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Order>> QueryAsync(string query, CancellationToken cancellationToken);
    }
}
