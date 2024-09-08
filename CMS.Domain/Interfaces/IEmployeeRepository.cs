using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync<R>(Expression<Func<Employee, R>> selector, CancellationToken cancellationToken);
        Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Employee>> FindAllAsync(Expression<Func<Employee, bool>> expression, CancellationToken cancellationToken);
        Task<Employee> FindAsync(Expression<Func<Employee, bool>> expression, CancellationToken cancellationToken);
        Task<IEnumerable<R>> FindAsync<R>(Expression<Func<Employee, R>> selector, Expression<Func<Employee, bool>> expression);
        Task<Employee> CreateAsync(Employee entity, CancellationToken cancellationToken);
        Task<Employee> UpdateAsync(Employee entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<Employee> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Employee>> QueryAsync(string query, CancellationToken cancellationToken);
    }
}
