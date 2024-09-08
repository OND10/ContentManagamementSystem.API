using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync<R>(Expression<Func<Contact, R>> selector, CancellationToken cancellationToken);
        Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Contact>> FindAllAsync(Expression<Func<Contact, bool>> expression, CancellationToken cancellationToken);
        Task<Contact> FindAsync(Expression<Func<Contact, bool>> expression, CancellationToken cancellationToken);
        Task<IEnumerable<R>> FindAsync<R>(Expression<Func<Contact, R>> selector, Expression<Func<Contact, bool>> expression);
        Task<Contact> CreateAsync(Contact entity, CancellationToken cancellationToken);
        Task<Contact> UpdateAsync(Contact entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<Contact> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Contact>> QueryAsync(string query, CancellationToken cancellationToken);
        Task<int> GetVisitorsCount(CancellationToken cancellationToken);
    }
}
