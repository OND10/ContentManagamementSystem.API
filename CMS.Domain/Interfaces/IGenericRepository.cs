using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Interfaces
{
    public interface IGenericRepository
    {
        Task<IEnumerable<dynamic>> GetEntitiesByTableAsync(string tableName);
    }
}
