using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country> CreateAsync(Country entity, CancellationToken cancellationToken);
        Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken);
    }
}
