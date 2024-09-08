using CMS.Domain.Interfaces;
using CMS.Infustracture.Database;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infustracture.Implementation
{
    public class GenericRepository : IGenericRepository
    {

        IDbConnection _db;
        private readonly ApplicationDapperContext _context;

        public GenericRepository(ApplicationDapperContext context)
        {
            _context = context;
            _db = _context.CreateConnection();
        }

        public async Task<IEnumerable<dynamic>> GetEntitiesByTableAsync(string tableName)
        {
            var query = "EXEC Get_Entity_By_Table @tableName";
            var result = await _db.QueryAsync<dynamic>(query, new { tableName });
            return result;
        }
    }
}
