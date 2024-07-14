using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Interfaces
{
    public interface IHostingPackageRepository
    {

        Task<IEnumerable<HostingPackages>> GetAllAsync<R>(Expression<Func<HostingPackages, R>> selector, CancellationToken cancellationToken);
        Task<IEnumerable<HostingPackages>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<HostingPackages>> FindAllAsync(Expression<Func<HostingPackages, bool>> expression, CancellationToken cancellationToken);
        Task<HostingPackages> FindAsync(Expression<Func<HostingPackages, bool>> expression, CancellationToken cancellationToken);
        Task<IEnumerable<R>> FindAsync<R>(Expression<Func<HostingPackages, R>> selector, Expression<Func<HostingPackages, bool>> expression);
        Task<HostingPackages> CreateAsync(HostingPackages entity, CancellationToken cancellationToken);
        Task<HostingPackages> UpdateAsync(HostingPackages entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<HostingPackages> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<HostingPackages>> QueryAsync(string query, CancellationToken cancellationToken);
        Task<IEnumerable<HostingPackages>> GetHostingPackagesAsync(string lang, CancellationToken cancellationToken);
    }
}
